using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ludum2D.World;

namespace Ludum2D.Tiles {
	public class MappingActionTile : IMappingAction {
		public Type TileType;

		/// <param name="t">The type of a tile</param>
		public MappingActionTile(Type t) {
			if (!t.IsSubclassOf(typeof (Tile))) {
				throw new ArgumentException("'t' must be a child of the Tile class");
			}
			this.TileType = t;
		}

		public void Execute(GameLevel l, int x, int y) {
			l.Tiles[l.GetIndex(x, y)] = (Tile) Activator.CreateInstance(TileType, x, y);
		}
	}
}