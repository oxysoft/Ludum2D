using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ludum2D.Tiles;
using Ludum2D.World;
using Microsoft.Xna.Framework;

namespace Ludum2D.Core {
	public class LudumCore {
		private static LudumCore instance;

		public static LudumCore Instance {
			get {
				if (instance == null) {
					instance = new LudumCore();
				}
				return instance;
			}
		}

		private LudumCore() {
		}

		public bool Initialized { get; private set; }

		/// <summary>
		/// Initialize the cores of the engine
		/// </summary>
		public void Initialize() {
		}

		/// <summary>
		/// Sets the size of a tile
		/// </summary>
		/// <param name="sq">Width and height of a tile; Must be x^2</param>
		public void SetTileSize(int sq) {
			if (!Initialized) {
				throw new Exception("The tile size cannot be modified once the the LudumCore has been initialized");
			}
			Tile.Width = sq;
		}
	}
}