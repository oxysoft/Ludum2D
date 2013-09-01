using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ludum2D.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ludum2D.World {
	public abstract class GameLevel {
		public Tile[] Tiles;
		public int Width, Height;

		protected GameLevel() {
		}

		public void Initialize(Texture2D baseImage, TileMapping mapping) {
			this.Width = baseImage.Width;
			this.Height = baseImage.Height;

			Color[] colors = new Color[Width * Height];
			baseImage.GetData<Color>(colors);

			for (int i = 0; i < Width; i++) {
				for (int j = 0; j < Height; j++) {
					Color c = colors[GetIndex(i, j)];
					int r = c.R;
					int g = c.G;
					int b = c.B;
					int col = r << 16 | g << 8 | b;

					IMappingAction action = mapping.Default;
					if (action != null) action.Execute(this, i, j);

					if (mapping.Get(col) != null) action = mapping.Get(col);
					if (action != null) action.Execute(this, i, j);
				}
			}
		}

		public int GetIndex(int x, int y) {
			return y * Width + x;
		}

		public Tile GetTile(int x, int y) {
			if (x < 0 || y < 0 || x >= Width || y >= Height) {
				return null;
			}
			return Tiles[y * Width + x];
		}

		public abstract void Update(GameTime gameTime);
		public abstract void Draw(GameTime gameTime);
	}
}