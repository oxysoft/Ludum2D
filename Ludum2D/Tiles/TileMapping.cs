using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Ludum2D.Tiles {
	public class TileMapping {
		private Dictionary<int, Type> hash = new Dictionary<int,Type>();

		public TileMapping() {
		}

		/// <summary>
		/// Returns the type mapped to the hex color c
		/// </summary>
		/// <param name="c">The color in hexadecimal. note: Alpha channel not supported</param>
		/// <returns></returns>
		public Type Get(int c) {
			if (hash.ContainsKey(c)) {
				return hash[c];
			}
			throw new NotImplementedException(string.Format("There is no tile type mapped to the color '{0}'", c.ToString("X6")));
		}

		/// <summary>
		/// Map a color to a tile
		/// </summary>
		/// <param name="c">The color in hexadecimal. note: Alpha channel not supported</param>
		/// <param name="t">The type of the tile. (e.g: typeof(GrassTile))</param>
		public TileMapping Insert(int c, Type t) {
			hash.Add(c, t);
			return this;
		}

	}
}
