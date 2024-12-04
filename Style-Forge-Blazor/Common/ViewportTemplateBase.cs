using Microsoft.AspNetCore.Components;

namespace Style_Forge_Blazor.Common
{
    public abstract class ViewportTemplateBase : ComponentBase
    {
        [Parameter] public EventCallback<dynamic> ItemClicked { get; set; }
    }
}
