using SharpDX;
using System.Runtime.InteropServices;

namespace IV_Gallery
{
	[StructLayoutAttribute(LayoutKind.Sequential)]
	public struct IV_VertexPosColor
	{
		public readonly Vector3 IVPos;
		public readonly Color4 IVColor;

		public IV_VertexPosColor(Vector3 temp_pos, Color4 temp_color)
		{
			IVPos = temp_pos;
			IVColor = temp_color;
		}
	}
}
