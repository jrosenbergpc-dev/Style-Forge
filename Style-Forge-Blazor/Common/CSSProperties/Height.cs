using Style_Forge.Common.Enums;

namespace Style_Forge.Common.CSSProperties
{
	public class Height : CSSPropertyBase
	{
		public double Size { get; set; } = 100.0;
		public SizeType SizeType { get; set; } = SizeType.Percent;
	}
}
