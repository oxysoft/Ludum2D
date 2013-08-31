using System;
using Ludum2D.Utilities;
using Ludum2D.Utilities.Easing;
using Ludum2D.Utilities.Easing.Core;
using Microsoft.Xna.Framework;

namespace Ludum2D.Camera {
	public class CameraMovement {
		public Vector2 From, To;
		public float Elapsed, Duration;
		public IEasing EasingX { get; private set; }
		public IEasing EasingY { get; private set; }

		public bool Active {
			get { return Elapsed < Duration || ((int) Camera.Instance.Location.X == (int) To.X && (int) Camera.Instance.Location.Y == (int) To.Y); }
		}

		public CameraMovement(Vector2 to, float duration, IEasing formula1, IEasing formula2) {
			this.From = Camera.Instance.Location;
			this.To = to;
			this.Duration = duration;
			this.EasingX = formula1;
			this.EasingY = formula2;
		}

		public void Update(GameTime gameTime) {
			Elapsed += (float) gameTime.ElapsedGameTime.TotalSeconds;
			if (!Active) return;

			float x = EasingX.Ease(Elapsed, From.X, To.X, Duration);
			float y = EasingY.Ease(Elapsed, From.Y, To.Y, Duration);

			Camera.Instance.Location = new Vector2(x, y);
		}
	}
}