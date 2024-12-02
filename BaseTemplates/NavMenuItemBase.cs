using Microsoft.AspNetCore.Components;

namespace Style_Forge_Blazor.BaseTemplates
{
    public abstract class NavMenuItemBase : ComponentBase
    {
        [Parameter] public string? Text { get; set; }
        [Parameter] public EventCallback<dynamic> OnClicked { get; set; }
    }
}
