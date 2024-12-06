using Style_Forge.Common;
using System.Linq;

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

			return ProcessProperties(properties, null);
        }

		public static string GetCSSStyleOutput(this List<CSSPropertyBase> properties, List<Type> exclusions)
		{
			// Return an empty string if the list is null or empty
			if (properties == null || properties.Count == 0)
			{
				return string.Empty;
			}

			return ProcessProperties(properties, exclusions);
		}

		public static string GetCSSStyleOutput(this List<CSSPropertyBase> properties, Type exclusion1)
		{
			// Return an empty string if the list is null or empty
			if (properties == null || properties.Count == 0)
			{
				return string.Empty;
			}

			List<Type> exclusions = new List<Type>();
			exclusions.Add(exclusion1);

			return ProcessProperties(properties, exclusions);
		}

		public static string GetCSSStyleOutput(this List<CSSPropertyBase> properties, Type exclusion1, Type exclusion2)
		{
			// Return an empty string if the list is null or empty
			if (properties == null || properties.Count == 0)
			{
				return string.Empty;
			}

			List<Type> exclusions = new List<Type>();
			exclusions.Add(exclusion1);
			exclusions.Add(exclusion2);

			return ProcessProperties(properties, exclusions);
		}

		public static string GetCSSStyleOutput(this List<CSSPropertyBase> properties, Type exclusion1, Type exclusion2, Type exclusion3)
		{
			// Return an empty string if the list is null or empty
			if (properties == null || properties.Count == 0)
			{
				return string.Empty;
			}

			List<Type> exclusions = new List<Type>();
			exclusions.Add(exclusion1);
			exclusions.Add(exclusion2);
			exclusions.Add(exclusion3);

			return ProcessProperties(properties, exclusions);
		}

		public static string GetCSSStyleOutput(this List<CSSPropertyBase> properties, Type exclusion1, Type exclusion2, Type exclusion3, Type exclusion4)
		{
			// Return an empty string if the list is null or empty
			if (properties == null || properties.Count == 0)
			{
				return string.Empty;
			}

			List<Type> exclusions = new List<Type>();
			exclusions.Add(exclusion1);
			exclusions.Add(exclusion2);
			exclusions.Add(exclusion3);
			exclusions.Add(exclusion4);

			return ProcessProperties(properties, exclusions);
		}

		public static string GetCSSStyleOutput(this List<CSSPropertyBase> properties, Type exclusion1, Type exclusion2, Type exclusion3, Type exclusion4, Type exclusion5)
		{
			// Return an empty string if the list is null or empty
			if (properties == null || properties.Count == 0)
			{
				return string.Empty;
			}

			List<Type> exclusions = new List<Type>();
			exclusions.Add(exclusion1);
			exclusions.Add(exclusion2);
			exclusions.Add(exclusion3);
			exclusions.Add(exclusion4);
			exclusions.Add(exclusion5);

			return ProcessProperties(properties, exclusions);
		}

		private static string ProcessProperties(List<CSSPropertyBase> props, List<Type>? exclusions)
        {
			// Check if exclusions list is null or empty
			bool hasExclusions = exclusions != null && exclusions.Count > 0;

			// Iterate through props, exclude items whose type matches exclusions, and generate CSS strings
			var cssStrings = props
				.Where(property => !hasExclusions || !exclusions!.Contains(property.GetType())) // Exclude matching types
				.OfType<dynamic>() // Cast each property to dynamic to handle generic CSSProperty<T>
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

			// Combine all CSS strings into a single space-separated string
			return string.Join(" ", cssStrings);
		}
    }
}
