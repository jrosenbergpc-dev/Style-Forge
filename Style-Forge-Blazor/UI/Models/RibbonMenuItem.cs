namespace Style_Forge_Blazor.UI.Models
{
    public class RibbonMenuItem
    {
        public string? FontFamily { get; set; }
        public string? FontSize { get; set; }
        public string? FontColor { get; set; }
        public string? Icon { get; set; }
        public string? Text { get; set; }
        public bool IsSelected { get; set; }
        public Type? Type { get; set; }
    }
}
