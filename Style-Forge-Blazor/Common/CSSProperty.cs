using Style_Forge.Common.CSSProperties;
using Style_Forge.Common.Enums;

namespace Style_Forge.Common
{
    public abstract class CSSPropertyBase
    {
    }

    public class CSSProperty<T> : CSSPropertyBase where T : CSSPropertyBase, new()
    {
        public T Value { get; set; } = new T();

        public string CSSValue()
        {
            string retValue = string.Empty;

            if (typeof(T) == typeof(Background))
            {

            }
            else if (typeof(T) == typeof(Border))
            {
                var tempValue = Value as Border;

                if (tempValue != null)
                {
                    if (tempValue.Radius > 0)
                    {
                        retValue = $"border: {tempValue.Thickness}{GetSizeTypeValue(tempValue.ThicknessType)} {tempValue.Style.ToString().ToLower()} {tempValue.Color} !important; border-radius: {tempValue.Radius}{GetSizeTypeValue(tempValue.RadiusType)} !important;";
                    }
                    else
                    {
                        retValue = $"border: {tempValue.Thickness}{GetSizeTypeValue(tempValue.ThicknessType)} {tempValue.Style.ToString().ToLower()} {tempValue.Color} !important;";
                    }
                }
            }
            else if (typeof(T) == typeof(FontColor))
            {
                var tempValue = Value as FontColor;

                if (tempValue != null)
                {
                    retValue = $"color: {tempValue.Color} !important;";
                }
            }
            else if (typeof(T) == typeof(FontFamily))
            {
                var tempValue = Value as FontFamily;

                if (tempValue != null)
                {
                    retValue = $"font-family: {tempValue.Family} !important;";
                }
            }
            else if (typeof(T) == typeof(FontSize))
            {
                var tempValue = Value as FontSize;

                if (tempValue != null)
                {
                    retValue = $"font-size: {tempValue.Size}{GetSizeTypeValue(tempValue.SizeType)} !important;";
                }
            }
            else if (typeof(T) == typeof(Height))
            {
                var tempValue = Value as Height;

                if (tempValue != null)
                {
                    retValue = $"height: {tempValue.Size}{GetSizeTypeValue(tempValue.SizeType)} !important;";
                }
            }
            else if (typeof(T) == typeof(LineHeight))
            {
                var tempValue = Value as LineHeight;

                if (tempValue != null)
                {
                    retValue = $"line-height: {tempValue.Height}{GetSizeTypeValue(tempValue.SizeType)} !important;";
                }
            }
            else if (typeof(T) == typeof(Width))
            {
                var tempValue = Value as Width;

                if (tempValue != null)
                {
                    retValue = $"width: {tempValue.Size}{GetSizeTypeValue(tempValue.SizeType)} !important;";
                }
            }

            return retValue;
        }

        private string GetSizeTypeValue(SizeType size)
        {
            if (size == SizeType.Pixel)
            {
                return "px";
            }
            else if (size == SizeType.Percent)
            {
                return "%";
            }
            else if (size == SizeType.VariableWidth)
            {
                return "vw";
            }
            else if (size == SizeType.VariableHeight)
            {
                return "vh";
            }
            else
            {
                return "";
            }
        }
    }
}
