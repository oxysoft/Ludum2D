using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ludum2D.World;

namespace Ludum2D.Tiles {
	public class MappingActionDelegate : IMappingAction {
		public Action<GameLevel, int, int> Callback;

		public MappingActionDelegate(Action<GameLevel, int, int> callback) {
			this.Callback = callback;
		}

		public void Execute(GameLevel l, int x, int y) {
			Callback(l, x, y);
		}
	}
}