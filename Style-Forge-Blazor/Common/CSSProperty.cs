using Style_Forge.Common.CSSProperties;

namespace Style_Forge.Common
{
    public abstract class CSSPropertyBase
    {
    }

    public class CSSProperty<T> where T : CSSPropertyBase, new()
    {
        public T Value { get; set; } = new T();

        public string CSSValue()
        {
            string retValue = string.Empty;

            if (typeof(T) == typeof(Background))
            {

            }
            else if (typeof(T) == typeof(TextColor))
            {
                var textColor = Value as TextColor;
                if (textColor != null)
                {
                    retValue = $"color: {textColor.Color} !important;";
                }
            }

            return retValue;
        }
    }
}
