using Style_Forge_Blazor.Common.Enums.Style;

namespace Style_Forge_Blazor.UI.Models
{
    public class NavMenuItem
    {
        // Static counter to keep track of the current index
        private static int _counter = -1;

        // Public property for the auto-incremented index
        public int Index { get; private set; }

        public string? Name { get; set; }
        public string? Text { get; set; }
        public string? Icon { get; set; }
        public string? IconWidth { get; set; }
        public string? IconHeight { get; set; }
        public string? Width { get; set; }
        public string? Height { get; set; }
        public bool IsSelected { get; set; }
        public NavLinkStyle LinkStyle { get; set; } = NavLinkStyle.Text;
        public string? Page { get; set; }
        public Type? Section { get; set; }
        public Type? Type { get; set; }
        public Dictionary<string, object>? CustomAttributes { get; set; }
        public Action? CustomLinkAction { get; set; }

        // Constructor
        public NavMenuItem()
        {
            // Increment the counter and assign it to the Index
            Index = Interlocked.Increment(ref _counter);
        }
    }
}
