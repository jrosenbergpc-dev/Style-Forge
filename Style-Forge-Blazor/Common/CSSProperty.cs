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
            else if (typeof(T) == typeof(FontColor))
            {
                var textColor = Value as FontColor;
                if (textColor != null)
                {
                    retValue = $"color: {textColor.Color} !important;";
                }
            }

            return retValue;
        }
    }
}
