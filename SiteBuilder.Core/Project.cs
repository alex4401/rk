using System;
using System.Collections.Generic;

namespace SiteBuilder.Core
{
    public struct Project
    {
        public string Inherits;
        public PathConfig Paths;
        public ResourceConfig Resources;
        public BuildConfig Build;

        public struct PathConfig
        {
            public string Root;
            public string Deployment;
            public string Resources;
        }

        public struct ResourceConfig
        {
            public string[] CopyNonVersioned;
        }

        public struct BuildConfig
        {
            public bool MinifyHtml;
            public string[] RunBefore;
        }
    }
}