using Ludum2D.Utilities.Easing.Core;

namespace Ludum2D.Utilities.Easing {
	public class Linear {
		public static IEasing NoEase = new In();

		protected class In : IEasing {
			public float Ease(float t, float b, float c, float d) {
				return c * t / d + b;
			}
		}
	}
}