using Microsoft.AspNetCore.Components;

namespace Style_Forge_Blazor.BaseTemplates
{
    public abstract class NavMenuItemBase : ComponentBase
    {
        [Parameter] public string? Name { get; set; }
        [Parameter] public string? Icon { get; set; }
        [Parameter] public string? IconWidth { get; set; }
        [Parameter] public string? IconHeight { get; set; }
        [Parameter] public string? Width { get; set; }
        [Parameter] public string? Height { get; set; }
        [Parameter] public string? FontFamily { get; set; }
        [Parameter] public string? FontSize { get; set; }
        [Parameter] public string? FontColor {  get; set; }
        [Parameter] public string? LineHeight { get; set; }
        [Parameter] public string? Text { get; set; }
        [Parameter] public EventCallback<dynamic> OnClicked { get; set; }
    }
}
