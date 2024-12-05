using Style_Forge.Common.Enums;
using Style_Forge.Common.Enums.Style;

namespace Style_Forge.Common.CSSProperties
{
    public class Border : CSSPropertyBase
    {
        public int Thickness { get; set; } = 1;
        public int Radius { get; set; } = 0;
        public SizeType ThicknessType { get; set; } = SizeType.Pixel;
        public SizeType RadiusType { get; set; } = SizeType.Pixel;
        public BorderStyle Style { get; set; } = BorderStyle.Solid;
        public string? Color { get; set; } = "#000000";
    }
}
