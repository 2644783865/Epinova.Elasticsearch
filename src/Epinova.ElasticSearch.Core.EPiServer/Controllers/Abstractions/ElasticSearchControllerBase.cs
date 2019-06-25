﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using Epinova.ElasticSearch.Core.Contracts;
using Epinova.ElasticSearch.Core.Models.Admin;
using Epinova.ElasticSearch.Core.Settings;
using Epinova.ElasticSearch.Core.Settings.Configuration;
using EPiServer.DataAbstraction;
using EPiServer.Globalization;
using EPiServer.Personalization;

namespace Epinova.ElasticSearch.Core.EPiServer.Controllers.Abstractions
{
    public abstract class ElasticSearchControllerBase : Controller
    {
        internal const string IndexParam = "index";
        internal const string LanguageParam = "languageId";

        private readonly ILanguageBranchRepository _languageBranchRepository;

        protected string CurrentIndex;
        protected string CurrentLanguage;
        private readonly IElasticSearchSettings _settings;
        private readonly IHttpClientHelper _httpClientHelper;

        protected ElasticSearchControllerBase(
            IElasticSearchSettings settings,
            IHttpClientHelper httpClientHelper,
            ILanguageBranchRepository languageBranchRepository)
        {
            _settings = settings;
            _httpClientHelper = httpClientHelper;
            _languageBranchRepository = languageBranchRepository;

            Indices = GetIndices();
            Languages = GetLanguages();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            CurrentLanguage = Request?.QueryString[LanguageParam] ?? Languages.First().Key;
            CurrentIndex = Request?.QueryString[IndexParam] ?? Indices.FirstOrDefault(i => i.Index.EndsWith($"-{CurrentLanguage}"))?.Index;
        }

        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
            ViewBag.SelectedIndex = CurrentIndex;
        }

        protected string SwapLanguage(string indexName, string newLanguage)
        {
            if(String.IsNullOrEmpty(indexName))
            {
                return null;
            }

            var lang = indexName.ToLower().Split('-').Last();
            var nameWithoutLanguage = indexName.Substring(0, indexName.Length - lang.Length - 1);
            return $"{nameWithoutLanguage}-{newLanguage}";
        }

        protected List<IndexInformation> Indices { get; }

        protected Dictionary<string, string> UniqueIndices =>
            Indices.Select(i =>
            {
                var lang = i.Index.ToLower().Split('-').Last();
                var nameWithoutLanguage = i.Index.Substring(0, i.Index.Length - lang.Length - 1);
                return new
                {
                    Index = nameWithoutLanguage,
                    i.DisplayName
                };
            })
            .Distinct()
            .ToDictionary(x => x.Index, x => x.DisplayName);

        protected Dictionary<string, string> Languages { get; }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            SystemLanguage.Instance.SetCulture();
            UserInterfaceLanguage.Instance.SetCulture(EPiServerProfile.Current?.Language);
        }

        private List<IndexInformation> GetIndices()
        {
            var indexHelper = new Admin.Index(_settings, _httpClientHelper, "GetIndices-NA");

            var indices = indexHelper.GetIndices().ToList();

            var config = ElasticSearchSection.GetConfiguration();

            foreach(var indexInfo in indices)
            {
                var parsed = config.IndicesParsed
                    .OrderByDescending(i => i.Name.Length)
                    .FirstOrDefault(i => indexInfo.Index.StartsWith(i.Name, StringComparison.InvariantCultureIgnoreCase));

                indexInfo.Type = String.IsNullOrWhiteSpace(parsed?.Type)
                    ? "[default]"
                    : Type.GetType(parsed.Type)?.Name;

                var displayName = new StringBuilder(parsed?.DisplayName);

                if(indexInfo.Index.Contains($"-{Constants.CommerceProviderName}".ToLowerInvariant()))
                {
                    displayName.Append(" Commerce");
                }

                indexInfo.DisplayName = displayName.ToString();
            }

            return indices;
        }

        private Dictionary<string, string> GetLanguages()
        {
            return _languageBranchRepository.ListEnabled()
                .ToDictionary(x => x.LanguageID, x => x.Name);
        }
    }
}