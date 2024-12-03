using Style_Forge_Blazor.BaseTemplates;
using Style_Forge_Blazor.Common.Enums.Style;

namespace Style_Forge_Blazor.UI.Models
{
    public class NavMenuItem : NavMenuItemBase
    {
        // Static counter to keep track of the current index
        private static int _counter = -1;

        // Public property for the auto-incremented index
        public int Index { get; private set; }

        public bool IsSelected { get; set; }
        public NavLinkStyle LinkStyle { get; set; } = NavLinkStyle.Text;
        public string? Page { get; set; }
        public Type? Section { get; set; }
        public NavMenuItemBase? Type { get; set; }
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
