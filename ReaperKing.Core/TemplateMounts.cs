using System;

namespace ReaperKing.Core
{
    /**
     * Registers a mount on default include namespace for its
     * lifetime.
     */
    public struct TemplateDefaultMount : IDisposable
    {
        private Site _site;
        private string[] _roots;

        public TemplateDefaultMount(Site site, string root)
            : this(site, new [] { root })
        { }

        public TemplateDefaultMount(Site site, string[] roots)
        {
            _site = site;
            _roots = roots;

            foreach (var root in _roots)
            {
                _site.TryAddTemplateDefaultIncludePath(root);
            }
        }
        
        public void Dispose()
        {
            foreach (var root in _roots)
            {
                _site.RemoveTemplateDefaultIncludePath(root);
            }

            _roots = null;
            _site = null;
        }
    }
    
    /**
     * Registers a mount on a specific include namespace for its
     * lifetime.
     */
    public readonly struct TemplateNamespaceMount : IDisposable
    {
        private readonly Site _site;
        private readonly string _ns;
        private readonly string _root;

        public TemplateNamespaceMount(Site site, string ns, string root)
        {
            (_site, _ns, _root) = (site, ns, root);
            _site.TryAddTemplateIncludeNamespace(ns, root);
        }

        public void Dispose()
        {
            _site.RemoveTemplateNamespace(_ns, _root);
        }
    }
}