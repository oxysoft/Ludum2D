using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ludum2D.World;

namespace Ludum2D.Tiles {
	public interface IMappingAction {
		void Execute(GameLevel l, int x, int y);
	}
}
