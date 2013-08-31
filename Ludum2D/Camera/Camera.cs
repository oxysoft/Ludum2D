using System;
using Ludum2D.Utilities;
using Ludum2D.Utilities.Easing;
using Ludum2D.Utilities.Easing.Core;
using Microsoft.Xna.Framework;

namespace Ludum2D.Camera {
	public class Camera {
		private static Camera instance;

		public static Camera Instance {
			get {
				if (instance == null) instance = new Camera();
				return instance;
			}
		}

		public Matrix Matrix {
			get {
				return Matrix.CreateTranslation(-(int) Math.Floor(Location.X), -(int) Math.Floor(Location.Y), 0.0f) *
				       Matrix.CreateTranslation(-Rumble.X, -Rumble.Y, 0.0f) *
				       Matrix.CreateScale(Scale.X, Scale.Y, 0.0f);
			}
		}

		public Vector2 Scale { get; set; }
		public Vector2 Location { get; set; }
		public float Rotation { get; set; }
		public CameraMovement CurrentMovement;

		public Vector2 Rumble { get; set; }
		public float RumbleElapsed, RumbleDuration;
		public int InitialRumbleForce, CurrentRumbleForce;

		public Camera() {
			this.Location = new Vector2(128, 128);
			this.Scale = new Vector2(2f, 2f); //note 2 self: alway remember to set to vector one or higher
			this.Rotation = 0;
		}

		/// <summary>
		/// Is the camera rumbling
		/// </summary>
		public bool Rumbling {
			get { return RumbleElapsed < RumbleDuration; }
		}

		/// <summary>
		/// Main update method
		/// </summary>
		/// <param name="gameTime"></param>
		public void Update(GameTime gameTime) {
			if (CurrentMovement != null && CurrentMovement.Active)
				CurrentMovement.Update(gameTime);

			RumbleElapsed += (float) gameTime.ElapsedGameTime.TotalSeconds;

			if (Rumbling) {
				CurrentRumbleForce = (int) (InitialRumbleForce * ((RumbleDuration - RumbleElapsed) / RumbleDuration));
				float shakeX = (float) (Randomizer.NextDouble() - 0.5f) * 2 * CurrentRumbleForce;
				float shakeY = (float) (Randomizer.NextDouble() - 0.5f) * 2 * CurrentRumbleForce;

				this.Rumble = new Vector2(shakeX, shakeY);
			}
		}

		/// <summary>
		/// Create a translation displacement
		/// </summary>
		/// <param name="displacement">The displacement vector</param>
		/// <param name="duration">The duration of this movement</param>
		/// <param name="function1">The easing function to be used for the X axis</param>
		/// <param name="function2">The easing function to be used for the Y axis</param>
		public void Move(Vector2 displacement, float duration, IEasing function1, IEasing function2) {
			if (displacement == Vector2.Zero) return;
			this.CurrentMovement = new CameraMovement(displacement, duration, function1, function2);
		}

		/// <summary>
		/// Create a translation displacement
		/// </summary>
		/// <param name="displacement">The displacement vector</param>
		/// <param name="duration">The duration of this movement</param>
		/// <param name="function">The easing function to be used for the X and Y axis</param>
		public void Move(Vector2 displacement, float duration, IEasing function) {
			Move(displacement, duration, function, function);
		}

		/// <summary>
		/// Create a translation displacement with the default easing equations
		/// </summary>
		/// <param name="displacement">The displacement vector</param>
		/// <param name="duration">The duration of this movement</param>
		public void Move(Vector2 displacement, float duration) {
			Move(displacement, duration, Quadratic.EaseOut, Quintic.EaseOut);
		}

		/// <summary>
		/// Move the camera to a location
		/// </summary>
		/// <param name="target">The target vector to which we want the camera to move over to</param>
		/// <param name="duration">The duration of this movement</param>
		/// <param name="function1">The easing function to be used for the X axis</param>
		/// <param name="function2">The easing function to be used for the Y axis</param>
		public void MoveTo(Vector2 target, float duration, IEasing function1, IEasing function2) {
			Move(target - Location, duration);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="target">The target vector to which we want the camera to move over to</param>
		/// <param name="duration">The duration of this movement</param>
		/// <param name="function">The easing function to be used for the X and Y axis</param>
		public void MoveTo(Vector2 target, float duration, IEasing function) {
			MoveTo(target, duration, function, function);
		}

		/// <summary>
		/// Move the camera to a location
		/// </summary>
		/// <param name="target">The target vector to which we want the camera to move over to</param>
		/// <param name="duration">The duration of this movement</param>
		public void MoveTo(Vector2 target, float duration) {
			MoveTo(target, duration, Quadratic.EaseOut, Quintic.EaseOut);
		}

		/// <summary>
		/// Center the camera to a location using the default easing equations
		/// </summary>
		/// <param name="location">The location at which we will center</param>
		/// <param name="size">The size of the screen or surface on which we should center on</param>
		/// <param name="duration">The duration of this movement</param>
		/// <param name="function1">The easing function to be applied for the X axis</param>
		/// <param name="function2">The easing function to be applied for the Y axis</param>
		public void CenterAt(Vector2 location, Vector2 size, float duration, IEasing function1, IEasing function2) {
			MoveTo(location - new Vector2(size.X / 2f, size.Y / 2f) / Scale, duration);
		}

		/// <summary>
		/// Center the camera onto a location
		/// </summary>
		/// <param name="location">The location at which we will center</param>
		/// <param name="size">The size of the screen or surface on which we should center on</param>
		/// <param name="duration">The duration of this movement</param>
		/// <param name="function">The easing function to be applied for the X and Y axis</param>
		public void CenterAt(Vector2 location, Vector2 size, float duration, IEasing function) {
			CenterAt(location, size, duration, function, function);
		}

		/// <summary>
		/// Center the camera onto a location using the default easing equations
		/// </summary>
		/// <param name="location">The location at which we will center</param>
		/// <param name="size">The size of the screen or surface on which we should center on</param>
		/// <param name="duration">The duration of this movement</param>
		public void CenterAt(Vector2 location, Vector2 size, float duration) {
			CenterAt(location, size, duration, Quadratic.EaseOut, Quintic.EaseOut);
		}

		/// <summary>
		/// Shake the camera (For example, shake the screen after an explosion!) 
		/// </summary>
		/// <param name="force">The amount of force we should use for this screen shake</param>
		/// <param name="duration">The duration of this screen shake</param>
		public void Shake(int force, float duration) {
			this.InitialRumbleForce = force;
			this.CurrentRumbleForce = force;
			this.RumbleElapsed = 0;
			this.RumbleDuration = duration;
		}
	}
}