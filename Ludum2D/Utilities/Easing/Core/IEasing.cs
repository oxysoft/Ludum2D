namespace Ludum2D.Utilities.Easing.Core {
	public interface IEasing {
		/*Shell for easing function classes*/
		/// <summary>
		/// Returns the current value inbetween b and c based on the current elapsed time
		/// </summary>
		/// <param name="t">Elapsed time</param>
		/// <param name="b">Start value</param>
		/// <param name="c">Target value</param>
		/// <param name="d">Duration</param>
		/// <returns></returns>
		float Ease(float t, float b, float c, float d);
	}
}
