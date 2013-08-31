using Microsoft.Xna.Framework;

namespace Ludum2D.Utilities {
	public class SimpleBoxDrawer {
		/// <summary>
		/// Draw a box on screen etc. etc.
		/// </summary>
		/// <param name="tileable">The tileable containing the box</param>
		/// <param name="dx">Location in X to draw on screen</param>
		/// <param name="dy">Location in X to draw on screen</param>
		/// <param name="w">Amount of tiles in width</param>
		/// <param name="h">Amount of tiles in heihgt</param>
		/// <param name="xs">Start x in tileable</param>
		/// <param name="ys">Start y in tileable</param>
		public static void DrawBox(TileableTexture tileable, int dx, int dy, int w, int h, int xs, int ys) {
			int fw = tileable.FrameWidth;
			int fh = tileable.FrameHeight;
			for (int y = 0; y < h; y++) {
				for (int x = 0; x < w; x++) {
					int xd = 0;
					int yd = 0;

					if (x > 0) xd++;
					if (y > 0) yd++;
					if (x == w - 1) xd++;
					if (y == h - 1) yd++;

					GameEngine.Instance.SpriteBatch.Draw(tileable.Texture, new Rectangle(dx + x * fw, dy + y * fh, fw, fh), tileable.GetSource(xd + xs * 3, yd + ys * 3), Color.White);
				}
			}
		}
	}
}