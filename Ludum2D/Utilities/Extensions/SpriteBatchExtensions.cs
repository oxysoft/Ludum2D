using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ludum2D.Utilities.Extensions {
	public static class SpriteBatchExtensions {
		public static void Begin(this SpriteBatch spriteBatch, Matrix transformMatrix) {
			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp, null, null, null, transformMatrix);
		}
	}
}
