using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Ludum2D.Tiles {
	public class TileMapping {
		private Dictionary<int, IMappingAction> hash = new Dictionary<int, IMappingAction>();
		public IMappingAction Default { get; private set; }
		public bool SuppressWarnings { get; private set; }

		public TileMapping(bool suppressWarnings) {
			this.SuppressWarnings = suppressWarnings;
		}

		/// <summary>
		/// Returns the type mapped to the hex color c
		/// </summary>
		/// <param name="c">The color in hexadecimal. note: Alpha channel not supported</param>
		/// <returns></returns>
		public IMappingAction Get(int c) {
			if (hash.ContainsKey(c)) {
				return hash[c];
			}
			Console.WriteLine("Warning: there is no tile type mapped to the color '{0}'", c.ToString("X6"));
			return null;
		}

		/// <summary>
		/// Map a color to a tile
		/// </summary>
		/// <param name="c">The color in hexadecimal. note: Alpha channel not supported</param>
		/// <param name="t">The type of the tile. (e.g: typeof(GrassTile))</param>
		public TileMapping Insert(int c, IMappingAction t) {
			hash.Add(c, t);
			return this;
		}

		/// <summary> Sets the default action to be executed in the events that no action was matched for a </summary>
		/// <remarks>The default action should probably be a tile action, such as setting the tile to an air tile</remarks>
		/// <param name="t"></param>
		/// <returns></returns>
		public TileMapping SetDefault(IMappingAction t) {
			this.Default = t;
			return this;
		}
	}
}