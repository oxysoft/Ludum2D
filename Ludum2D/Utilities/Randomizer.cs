using System;

namespace Ludum2D.Utilities {
	public class Randomizer {
		public static readonly Random Random = new Random();

		public static float Next() {
			return Random.Next();
		}

		public static int Next(int i) {
			return Random.Next(i);
		}

		public static int Next(int i, int o) {
			return Random.Next(i, o + 1);
		}

		public static double NextDouble() {
			return Random.NextDouble();
		}

		public static double NextDouble(double min, double max) {
			return min + (Random.NextDouble() * (max - min));
		}

		public static bool NextBoolean() {
			return Random.Next(2) == 1;
		}
	}
}