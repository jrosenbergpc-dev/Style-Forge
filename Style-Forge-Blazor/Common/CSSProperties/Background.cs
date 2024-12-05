using Style_Forge.Common.Enums;
using Style_Forge.Common.Enums.Style;

namespace Style_Forge.Common.CSSProperties
{
    public class Background : CSSPropertyBase
    {
        public bool IsUsingGradient { get; set; }
        public bool IsUsingImage { get; set; }

        public string? Url { get; set; }
        public string? Color { get; set; } = "#FFFFFF";
		public double Width { get; set; } = 100.0;
		public double Height { get; set; } = 100.0;

		public BackgroundSize Size { get; set; } = BackgroundSize.Auto;
        public SizeType WidthType { get; set; } = SizeType.Percent;
        public SizeType HeightType { get; set; } = SizeType.Percent;
        public BackgroundRepeatStyles RepeatStyle { get; set; } = BackgroundRepeatStyles.NoRepeat;
        public GradientDirections GradientDirection { get; set; }
	}
}
