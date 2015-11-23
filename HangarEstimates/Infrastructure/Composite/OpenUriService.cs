using System;
using Microsoft.Practices.Prism;

namespace HangarEstimates.Infrastructure.Composite
{
    public class OpenUriService
    {
        public Uri GenerateNavigationUri<T>(string viewName, T openParameters, UriKind kind) where T : class
        {
            var uriQuery = new UriQuery();
            var guid = NavigationParametersCache.CreateParameter(openParameters);
            uriQuery.Add(typeof(T).GetHashCode().ToString(), guid.ToString());

            return new Uri(viewName + uriQuery, kind);
        }

        public T ParseNavigationUri<T>(UriQuery uri)
            where T: class
        {
            var paramGuid = new Guid(uri[typeof(T).GetHashCode().ToString()]);

            return NavigationParametersCache.Request<T>(paramGuid);
        }
    }
}
