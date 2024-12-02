using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Style_Forge_Blazor.Extensions
{
    public static class DictionaryExtensions
    {
        public static Dictionary<TKey, TValue> MergeWith<TKey, TValue>(this Dictionary<TKey, TValue> defaults, Dictionary<TKey, TValue>? custom)
        {
            if (custom == null)
            {
                return new Dictionary<TKey, TValue>(defaults); // Ensure the original dictionary isn't modified
            }

            return defaults.Concat(custom).GroupBy(kvp => kvp.Key).ToDictionary(group => group.Key, group => group.Last().Value);
        }
    }
}
