using Style_Forge.Common.CSSProperties;
using Style_Forge.Common.Enums;

namespace Style_Forge.Common
{
    public abstract class CSSPropertyBase
    {
    }

    public class CSSProperty<T> : CSSPropertyBase where T : CSSPropertyBase, new()
    {
        private const string ImportantFlag = "!important;";

        public T Value { get; set; } = new T();

        public string CSSValue()
        {
            string retValue = string.Empty;

            if (typeof(T) == typeof(Background))
            {
                if (Value != null)
                {
                    retValue = $"";
                }
            }
            else if (typeof(T) == typeof(Border))
            {
                if (Value != null)
                {
                    retValue = $"{GetPropertyTypeValue(typeof(T))}{(Value as Border).Thickness}{GetSizeTypeValue((Value as Border).ThicknessType)} {(Value as Border).Style.ToString().ToLower()} {(Value as Border).Color} {ImportantFlag}";

                    if ((Value as Border).Radius > 0)
                    {
                        retValue = retValue + $"border-radius: {(Value as Border).Radius}{GetSizeTypeValue((Value as Border).RadiusType)} {ImportantFlag}";
                    }
                }
            }
            else if (typeof(T) == typeof(FontColor))
            {
                if (Value != null)
                {
                    retValue = $"{GetPropertyTypeValue(typeof(T))}{(Value as FontColor).Color ?? String.Empty} {ImportantFlag}";
                }
            }
            else if (typeof(T) == typeof(FontFamily))
            {
                if (Value != null)
                {
                    retValue = $"{GetPropertyTypeValue(typeof(T))}{(Value as FontFamily).Family} {ImportantFlag}";
                }
            }
            else if (typeof(T) == typeof(FontSize))
            {
                if (Value != null)
                {
                    retValue = $"{GetPropertyTypeValue(typeof(T))}{(Value as FontSize).Size}{GetSizeTypeValue((Value as FontSize).SizeType)} {ImportantFlag}";
                }
            }
            else if (typeof(T) == typeof(Height))
            {
                if (Value != null)
                {
                    retValue = $"{GetPropertyTypeValue(typeof(T))}{(Value as Height).Size}{GetSizeTypeValue((Value as Height).SizeType)} {ImportantFlag}";
                }
            }
            else if (typeof(T) == typeof(LineHeight))
            {
                if (Value != null)
                {
                    retValue = $"{GetPropertyTypeValue(typeof(T))}{(Value as LineHeight).Height}{GetSizeTypeValue((Value as LineHeight).SizeType)} {ImportantFlag}";
                }
            }
            else if (typeof(T) == typeof(Width))
            {
                if (Value != null)
                {
                    retValue = $"{GetPropertyTypeValue(typeof(T))}{(Value as Width).Size}{GetSizeTypeValue((Value as Width).SizeType)} {ImportantFlag}";
                }
            }

            return retValue;
        }

        private string GetPropertyTypeValue(Type type)
        {
            string retValue = string.Empty;

            if (type == typeof(FontColor))
            {
                retValue = "color";
            }
            else if (type == typeof(FontFamily))
            {
                retValue = "font-family";
            }
            else if (type == typeof(FontSize))
            {
                retValue = "font-size";
            }
            else if (type == typeof(LineHeight))
            {
                retValue = "line-height";
            }
            else
            {
                retValue = type.Name.ToLower();
            }

            return retValue + ": ";
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
