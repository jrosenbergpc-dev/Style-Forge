using Style_Forge.Common.Enums;

namespace Style_Forge.Common.CSSProperties
{
	public class FontSize : CSSPropertyBase
	{
		public double Size { get; set; } = 12.0;
		public SizeType SizeType { get; set; } = SizeType.Pixel;
	}
}
