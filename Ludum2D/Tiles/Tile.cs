using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Ludum2D.Tiles {
	public abstract class Tile {
		public static int Width = 16;

		public static int Height {
			get { return Width; }
		}

		public static Vector2 Size {
			get { return new Vector2(Width, Height); }
		}

		protected Tile(int x, int y) {
			this.Location = new Vector2(x, y);
		}

		public Vector2 Location;
		public abstract int Id { get; }

		public abstract void Update(GameTime gameTime);
		public abstract void Draw(GameTime gameTime);
	}
}