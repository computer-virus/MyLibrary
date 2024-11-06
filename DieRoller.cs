namespace MyLibrary {
	/// <summary>
	///		<see cref="DieRoller"/> contains all of <see cref="MyLibrary"/>'s die-based random <see langword="methods"/>.
	/// </summary>
	public static class DieRoller {
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

		#region Multiple Dice Total Methods
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
				return Enumerable.Repeat(RollD(size, rand) ?? 0, x).ToList();
			}

			List<int> list = [];
			for (int i = 0; i < x; i++) {
				list.Add(RollD(size, rand) ?? 0);
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
				return Enumerable.Repeat((RollD(size, rand) ?? 0) + mod, x).ToList();
			}

			List<int> list = RollXD(x, size, rand) ?? [];
			for (int i = 0; i < list.Count; i++) {
				list[i] += mod;
			}
			return list;
		}
		#endregion
		#endregion
	}
}