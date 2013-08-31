using System;

namespace Ludum2D.Utilities.Extensions {
	public static class EventHandlerExtensions {
		public static void SafeInvoke(this EventHandler handler, object sender, EventArgs args) {
			if (handler != null) {
				handler.Invoke(sender, args);
			}
		}
	}
}
