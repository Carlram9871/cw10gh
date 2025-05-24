using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;

namespace CuestionarioWeb10.Services
{
    public class CustomHashNavigationManager : NavigationManager
    {
        private readonly IJSRuntime _jsRuntime;

        public CustomHashNavigationManager(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        protected override void NavigateToCore(string uri, bool forceLoad)
        {
            // Para GitHub Pages, manejamos la navegación con hash
            if (uri.StartsWith("http"))
            {
                // URI absoluta
                var baseUri = BaseUri.TrimEnd('/');
                if (uri.StartsWith(baseUri))
                {
                    var relativePath = uri.Substring(baseUri.Length);
                    uri = $"{baseUri}/#{relativePath}";
                }
            }
            else
            {
                // URI relativa - agregar hash
                uri = $"#{uri}";
            }

            if (forceLoad)
            {
                _jsRuntime.InvokeVoidAsync("window.location.replace", uri);
            }
            else
            {
                _jsRuntime.InvokeVoidAsync("window.history.pushState", null, "", uri);
                NotifyLocationChanged(false);
            }
        }
    }
}
