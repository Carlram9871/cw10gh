using Microsoft.AspNetCore.Components;

public class CustomHashNavigationManager : NavigationManager
{
    protected override void EnsureInitialized()
    {
        var baseUri = base.BaseUri;
        Initialize(baseUri, baseUri + "#/");
    }

    protected override void NavigateToCore(string uri, bool forceLoad)
    {
        var absoluteUri = ToAbsoluteUri(uri).AbsoluteUri;

        if (!absoluteUri.Contains("#"))
        {
            absoluteUri = absoluteUri.Replace(base.BaseUri, base.BaseUri + "#/");
        }

        base.NavigateTo(absoluteUri, forceLoad);
    }
}
