using Microsoft.AspNetCore.Components;

namespace Style_Forge.Common
{
	public abstract class StyleForgeComponent : ComponentBase
	{
        private static int _counter = -1;

        [Parameter] public int ID { get; set; }
        [Parameter] public string? Name { get; set; }
        [Parameter] public string? Text { get; set; }
        [Parameter] public bool Selected { get; set; }
        [Parameter] public bool Disabled { get; set; }
        [Parameter] public string? Value { get; set; }
        [Parameter] public string? SelectedValue { get; set; }

        /// <summary>
        /// CSS Properties can be set here by adding a new CSSProperty<T> To the collection.
        /// </summary>
        [Parameter] public List<CSSPropertyBase> CSSProperties { get; set; } = new List<CSSPropertyBase>();

		/// <summary>
		/// OnClick Event Callback 
		/// </summary>
		[Parameter] public EventCallback<dynamic> OnClicked { get; set; }
        [Parameter] public EventCallback<dynamic> OnDoubleClicked { get; set; }
        [Parameter] public EventCallback<dynamic> OnSelectionChanged { get; set; }

        public StyleForgeComponent()
		{
            ID = Interlocked.Increment(ref _counter);
        }
	}
}
