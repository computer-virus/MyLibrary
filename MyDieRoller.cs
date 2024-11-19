namespace MyLibrary {
	/// <summary>
	///		<see cref="MyDieRoller"/> contains all of <see cref="MyLibrary"/>'s die-based random <see langword="methods"/>.
	/// </summary>
	public static class MyDieRoller {
		#region Single Die Methods
		/// <summary>
		///		<para>Chooses a random <see cref="int"/> on a die with <see cref="int"/> <paramref name="size"/> faces.</para>
		///		<para>Returns <see langword="null"/> if the <paramref name="size"/> if less than 0.</para>
		///		<para><see cref="RollD(int, System.Random)"/> can have 1 to 2 <see langword="params"/>.</para>
		/// </summary>
		/// <param name="size"></param>
		public static int? RollD(int size) {
			return RollD(size, new());
		}

		/// <summary>
		///		<para>Chooses a random <see cref="int"/> on a die with <see cref="int"/> <paramref name="size"/> faces using <see cref="System.Random"/> <paramref name="rand"/>.</para>
		///		<para>Returns <see langword="null"/> if the <paramref name="size"/> if less than 0.</para>
		///		<para><see cref="RollD(int, System.Random)"/> can have 1 to 2 <see langword="params"/>.</para>
		/// </summary>
		/// <param name="size"></param>
		/// <param name="rand"></param>
		public static int? RollD(int size, System.Random rand) {
			if (size < 0) {
				return null;
			}

			if (size < 2) {
				return size;
			}

			return rand.Next(size) + 1;
		}
		#endregion

		#region Multiple Dice Methods
		/// <summary>
		///		<para>Chooses <see cref="int"/> <paramref name="x"/> random <see cref="int"/>s on a die with <see cref="int"/> <paramref name="size"/> faces.</para>
		///		<para>Returns <see langword="null"/> if <paramref name="x"/> or <paramref name="size"/> if less than 0.</para>
		///		<para><see cref="RollXD(int, int, System.Random)"/> can have 2 to 3 <see langword="params"/>.</para>
		/// </summary>
		/// <param name="x"></param>
		/// <param name="size"></param>
		public static List<int>? RollXD(int x, int size) {
			return RollXD(x, size, new());
		}

		/// <summary>
		///		<para>Chooses <see cref="int"/> <paramref name="x"/> random <see cref="int"/>s on a die with <see cref="int"/> <paramref name="size"/> faces using <see cref="System.Random"/> <paramref name="rand"/>.</para>
		///		<para>Returns <see langword="null"/> if <paramref name="x"/> or <paramref name="size"/> if less than 0.</para>
		///		<para><see cref="RollXD(int, int, System.Random)"/> can have 2 to 3 <see langword="params"/>.</para>
		/// </summary>
		/// <param name="x"></param>
		/// <param name="size"></param>
		/// <param name="rand"></param>
		public static List<int>? RollXD(int x, int size, System.Random rand) {
			if (x < 0 || size < 0) {
				return null;
			}

			if (size < 2) {
				return Enumerable.Repeat(size, x).ToList();
			}

			if (x < 2) {
				return Enumerable.Repeat(rand.Next(size) + 1, x).ToList();
			}

			List<int> list = [];
			for (int i = 0; i < x; i++) {
				list.Add(rand.Next(size) + 1);
			}
			return list;
		}

		#region With Individual Modifiers
		/// <summary>
		///		<para>Chooses <see cref="int"/> <paramref name="x"/> random <see cref="int"/>s on a die with <see cref="int"/> <paramref name="size"/> faces plus <see cref="int"/> <paramref name="mod"/>.</para>
		///		<para>Returns <see langword="null"/> if <paramref name="x"/> or <paramref name="size"/> if less than 0.</para>
		///		<para><see cref="RollXDM(int, int, int, System.Random)"/> can have 3 to 4 <see langword="params"/>.</para>
		/// </summary>
		/// <param name="x"></param>
		/// <param name="size"></param>
		/// <param name="mod"></param>
		public static List<int>? RollXDM(int x, int size, int mod) {
			return RollXDM(x, size, mod, new());
		}

		/// <summary>
		///		<para>Chooses <see cref="int"/> <paramref name="x"/> random <see cref="int"/>s on a die with <see cref="int"/> <paramref name="size"/> faces plus <see cref="int"/> <paramref name="mod"/> using <see cref="System.Random"/> <paramref name="rand"/>.</para>
		///		<para>Returns <see langword="null"/> if <paramref name="x"/> or <paramref name="size"/> if less than 0.</para>
		///		<para><see cref="RollXDM(int, int, int, System.Random)"/> can have 3 to 4 <see langword="params"/>.</para>
		/// </summary>
		/// <param name="x"></param>
		/// <param name="size"></param>
		/// <param name="mod"></param>
		/// <param name="rand"></param>
		public static List<int>? RollXDM(int x, int size, int mod, System.Random rand) {
			if (x < 0 || size < 0) {
				return null;
			}

			if (size < 2) {
				return Enumerable.Repeat(size + mod, x).ToList();
			}

			if (x < 2) {
				return Enumerable.Repeat(rand.Next(size) + 1 + mod, x).ToList();
			}

			List<int> list = RollXD(x, size, rand) ?? [];
			for (int i = 0; i < list.Count; i++) {
				list[i] += mod;
			}
			return list;
		}
		#endregion
		#endregion

		#region Multiple Roll Methods
		#region Advantage
		/// <summary>
		///		<para>Chooses the higher of 2 random <see cref="int"/>s on a die with <see cref="int"/> <paramref name="size"/> faces.</para>
		///		<para>Returns <see langword="null"/> if <paramref name="size"/> if less than 0.</para>
		///		<para><see cref="AdvRollD(int, System.Random)"/> can have 1 to 2 <see langword="params"/>.</para>
		/// </summary>
		/// <param name="size"></param>
		public static int? AdvRollD(int size) {
			return AdvRollD(size, new());
		}

		/// <summary>
		///		<para>Chooses the higher of 2 random <see cref="int"/>s on a die with <see cref="int"/> <paramref name="size"/> faces using <see cref="System.Random"/> <paramref name="rand"/>.</para>
		///		<para>Returns <see langword="null"/> if <paramref name="size"/> if less than 0.</para>
		///		<para><see cref="AdvRollD(int, System.Random)"/> can have 1 to 2 <see langword="params"/>.</para>
		/// </summary>
		/// <param name="size"></param>
		/// <param name="rand"></param>
		public static int? AdvRollD(int size, System.Random rand) {
			if (size < 0) {
				return null;
			}

			if (size < 2) {
				return size;
			}

			return Math.Max(rand.Next(size) + 1, rand.Next(size) + 1);
		}
		#endregion

		#region Disadvantage
		/// <summary>
		///		<para>Chooses the lower of 2 random <see cref="int"/>s on a die with <see cref="int"/> <paramref name="size"/> faces.</para>
		///		<para>Returns <see langword="null"/> if <paramref name="size"/> if less than 0.</para>
		///		<para><see cref="DisRollD(int, System.Random)"/> can have 1 to 2 <see langword="params"/>.</para>
		/// </summary>
		/// <param name="size"></param>
		public static int? DisRollD(int size) {
			return DisRollD(size, new());
		}

		/// <summary>
		///		<para>Chooses the lower of 2 random <see cref="int"/>s on a die with <see cref="int"/> <paramref name="size"/> faces using <see cref="System.Random"/> <paramref name="rand"/>.</para>
		///		<para>Returns <see langword="null"/> if <paramref name="size"/> if less than 0.</para>
		///		<para><see cref="DisRollD(int, System.Random)"/> can have 1 to 2 <see langword="params"/>.</para>
		/// </summary>
		/// <param name="size"></param>
		/// <param name="rand"></param>
		public static int? DisRollD(int size, System.Random rand) {
			if (size < 0) {
				return null;
			}

			if (size < 2) {
				return size;
			}

			return Math.Min(rand.Next(size) + 1, rand.Next(size) + 1);
		}
		#endregion

		#region Reroll On X Or Less
		/// <summary>
		///		<para>Chooses a random <see cref="int"/> on a die with <see cref="int"/> <paramref name="size"/> faces.</para>
		///		<para>If the <see langword="value"/> would be less than <see cref="int"/> <paramref name="range"/>, the it rechooses once instead.</para>
		///		<para>Returns <see langword="null"/> if the <paramref name="size"/> if less than 0.</para>
		///		<para><see cref="ReRollD(int, int, bool, System.Random)"/> can have 2 to 4 <see langword="params"/>.</para>
		/// </summary>
		/// <param name="size"></param>
		/// <param name="range"></param>
		public static int? ReRollD(int size, int range) {
			return ReRollD(size, range, true, new());
		}

		/// <summary>
		///		<para>Chooses a random <see cref="int"/> on a die with <see cref="int"/> <paramref name="size"/> faces.</para>
		///		<para>If the <see langword="value"/> would be less than <see cref="int"/> <paramref name="range"/>, the it rechooses instead.</para>
		///		<para>It rechooses only once if <see cref="bool"/> <paramref name="once"/> is <see langword="true"/> or until the <see langword="value"/> is greater than <paramref name="range"/> if <see langword="false"/>.</para>
		///		<para>Returns <see langword="null"/> if the <paramref name="size"/> if less than 0.</para>
		///		<para><see cref="ReRollD(int, int, bool, System.Random)"/> can have 2 to 4 <see langword="params"/>.</para>
		/// </summary>
		/// <param name="size"></param>
		/// <param name="range"></param>
		/// <param name="once"></param>
		public static int? ReRollD(int size, int range, bool once) {
			return ReRollD(size, range, once, new());
		}

		/// <summary>
		///		<para>Chooses a random <see cref="int"/> on a die with <see cref="int"/> <paramref name="size"/> faces using <see cref="System.Random"/> <paramref name="rand"/>.</para>
		///		<para>If the <see langword="value"/> would be less than <see cref="int"/> <paramref name="range"/>, the it rechooses once instead.</para>
		///		<para>Returns <see langword="null"/> if the <paramref name="size"/> if less than 0.</para>
		///		<para><see cref="ReRollD(int, int, bool, System.Random)"/> can have 2 to 4 <see langword="params"/>.</para>
		/// </summary>
		/// <param name="size"></param>
		/// <param name="range"></param>
		/// <param name="rand"></param>
		public static int? ReRollD(int size, int range, System.Random rand) {
			return ReRollD(size, range, true, rand);
		}

		/// <summary>
		///		<para>Chooses a random <see cref="int"/> on a die with <see cref="int"/> <paramref name="size"/> faces using <see cref="System.Random"/> <paramref name="rand"/>.</para>
		///		<para>If the <see langword="value"/> would be less than <see cref="int"/> <paramref name="range"/>, the it rechooses instead.</para>
		///		<para>It rechooses only once if <see cref="bool"/> <paramref name="once"/> is <see langword="true"/> or until the <see langword="value"/> is greater than <paramref name="range"/> if <see langword="false"/>.</para>
		///		<para>Returns <see langword="null"/> if the <paramref name="size"/> if less than 0.</para>
		///		<para><see cref="ReRollD(int, int, bool, System.Random)"/> can have 2 to 4 <see langword="params"/>.</para>
		/// </summary>
		/// <param name="size"></param>
		/// <param name="range"></param>
		/// <param name="once"></param>
		/// <param name="rand"></param>
		public static int? ReRollD(int size, int range, bool once, System.Random rand) {
			if (size < 0) {
				return null;
			}

			if (size < 2) {
				return size;
			}

			int a = rand.Next(size) + 1;
			if (a > range) {
				return a;
			}

			int b;
			do {
				b = rand.Next(size) + 1;
				if (b > range) {
					return b;
				}
			} while (!once);

			return b;
		}
		#endregion
		#endregion
	}
}