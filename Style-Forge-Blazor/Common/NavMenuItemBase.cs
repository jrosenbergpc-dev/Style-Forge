using Microsoft.AspNetCore.Components;

namespace Style_Forge.Common
{
    public abstract class NavMenuItemBase : ComponentBase
    {
        /// <summary>
        /// CSS Properties can be set here by adding a new CSSProperty<T> To the collection.
        /// </summary>
        [Parameter] public List<CSSPropertyBase> CSSProperties { get; set; } = new List<CSSPropertyBase>();

        /// <summary>
        /// Name of NavMenuItem for reference purposes blank by default.
        /// </summary>
        [Parameter] public string? Name { get; set; }

        /// <summary>
        /// Icon = path to image file e.g "images\somefile.jpg"
        /// </summary>
        [Parameter] public string? Icon { get; set; }

        /// <summary>
        /// IconWidth = css string for Icon's Width "32px", "2.4vw", "50%"
        /// </summary>
        [Parameter] public string? IconWidth { get; set; }

		/// <summary>
		/// IconHeight = css string for Icon's Height "32px", "2.4vw", "50%"
		/// </summary>
		[Parameter] public string? IconHeight { get; set; }

        /// <summary>
        /// Sets the Text Value for the Displayed UserControl/Element
        /// </summary>
        [Parameter] public string? Text { get; set; }

        /// <summary>
        /// OnClick Event Callback 
        /// </summary>
        [Parameter] public EventCallback<dynamic> OnClicked { get; set; }
    }
}
