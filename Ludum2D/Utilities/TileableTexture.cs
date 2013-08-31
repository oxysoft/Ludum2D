using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ludum2D.Utilities {
	public class TileableTexture {
		private Dictionary<Rectangle, Texture2D> cutCache;

		public Texture2D Texture;
		public int Columns, Rows;

		public TileableTexture(Texture2D texture, int width, int height) {
			this.Texture = texture;
			this.cutCache = new Dictionary<Rectangle, Texture2D>();
			Chop(width, height);
		}

		public int FrameWidth {
			get { return Texture.Width / Columns; }
		}

		public int FrameHeight {
			get { return Texture.Height / Rows; }
		}

		public void Chop(int w, int h) {
			Columns = Texture.Width / w;
			Rows = Texture.Height / h;
		}

		public Rectangle GetSource(int x, int y) {
			return GetSource(GetIndex(x, y));
		}

		public Rectangle GetSource(int i) {
			if (Rows == 0 || Columns == 0) return new Rectangle(0, 0, Texture.Width, Texture.Height);
			if (i == 0) return new Rectangle(0, 0, FrameWidth, FrameHeight);

			int x = i % Columns;
			int y = i / Columns;

			return new Rectangle(x * FrameWidth, y * FrameHeight, FrameWidth, FrameHeight);
		}

		public int GetIndex(int x, int y) {
			return y * Columns + x;
		}

		public Texture2D GetSub(int index) {
			Rectangle rect = GetSource(index);
			return GetSub(rect.X, rect.Y, rect.Width, rect.Height);
		}

		public Texture2D GetSub(int x, int y, int width, int height) {
			if (!cutCache.ContainsKey(new Rectangle(x, y, width, height))) {
				Texture2D result = new Texture2D(GameEngine.Instance.GraphicsDevice, width, height);
				Color[] colors = new Color[width * height];
				Color[] copyData = new Color[Texture.Width * Texture.Height];
				Texture.GetData<Color>(copyData);
				int index = 0;
				for (int j = y; j < y + height; j++) {
					for (int i = x; i < x + width; i++) {
						int copyStride = j * Texture.Width + i;
						colors[index] = copyData[copyStride];
						index++;
					}
				}

				result.SetData<Color>(colors);
				cutCache.Add(new Rectangle(x, y, width, height), result);
			}
			return cutCache[new Rectangle(x, y, width, height)];
		}
	}
}