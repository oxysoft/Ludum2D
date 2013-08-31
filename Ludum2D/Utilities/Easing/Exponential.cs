using System;
using Ludum2D.Utilities.Easing.Core;

namespace Ludum2D.Utilities.Easing {
	public class Exponential {
		public static IEasing EaseIn = new In();
		public static IEasing EaseOut = new Out();
		public static IEasing EaseInOut = new InOut();

		private class In : IEasing {
			public float Ease(float t, float b, float c, float d) {
				return (float) (c * Math.Pow(2, 10 * (t / d - 1)) + b);
			}
		}

		private class Out : IEasing {
			public float Ease(float t, float b, float c, float d) {
				return (float) (c * (-Math.Pow(2, -10 * t / d) + 1) + b);
			}
		}

		private class InOut : IEasing {
			public float Ease(float t, float b, float c, float d) {
				t /= d / 2;
				if (t < 1) return (float) (c / 2 * Math.Pow(2, 10 * (t - 1)) + b);
				t--;
				return (float) (c / 2 * (-Math.Pow(2, -10 * t) + 2) + b);
			}
		}
	}
}