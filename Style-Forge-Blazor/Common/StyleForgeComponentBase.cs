using Microsoft.AspNetCore.Components;

namespace Style_Forge.Common
{
	public abstract class StyleForgeComponent : ComponentBase
	{
		/// <summary>
		/// CSS Properties can be set here by adding a new CSSProperty<T> To the collection.
		/// </summary>
		[Parameter] public List<CSSPropertyBase> CSSProperties { get; set; } = new List<CSSPropertyBase>();

		/// <summary>
		/// OnClick Event Callback 
		/// </summary>
		[Parameter] public EventCallback<dynamic> OnClicked { get; set; }
	}
}
