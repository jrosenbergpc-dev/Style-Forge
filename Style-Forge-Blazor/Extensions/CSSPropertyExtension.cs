using Style_Forge.Common;

namespace Style_Forge.Extensions
{
    public static class CSSPropertyExtension
    {
        public static string GetCSSStyleOutput(this List<CSSPropertyBase> properties)
        {
            // Return an empty string if the list is null or empty
            if (properties == null || properties.Count == 0)
            {
                return string.Empty;
            }

            // Iterate through each item, cast it as CSSProperty<T>, and call CSSValue()
            var cssStrings = properties
                .OfType<dynamic>() // Use dynamic to handle the generic type
                .Select(property =>
                {
                    try
                    {
                        return property.CSSValue(); // Call the CSSValue() method
                    }
                    catch
                    {
                        return string.Empty; // Safeguard in case of invalid items
                    }
                })
                .Where(css => !string.IsNullOrWhiteSpace(css)); // Filter out null or empty values

            // Combine all CSS strings into a single comma-separated string
            return string.Join(" ", cssStrings);
        }
    }
}
