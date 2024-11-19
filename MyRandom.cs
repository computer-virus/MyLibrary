namespace MyLibrary {
	/// <summary>
	///		<see cref="MyRandom"/> contains all of <see cref="MyLibrary"/>'s standard random <see langword="methods"/>.
	/// </summary>
	public static class MyRandom {

		/// <summary>
		///		<para>Default value for <see cref="NextChar()"/> and <see cref="NextChar(System.Random)"/>.</para>
		///		<para>Contains all possible <see cref="char"/>s that can be typed on a keyboard without a numpad.</para>
		/// </summary>
		private const string ALLKEYBOARDCHARS = "`~1!2@3#4$5%6^7&8*9(0)-_=+qQwWeErRtTyYuUiIoOpP[{]}\\|aAsSdDfFgGhHjJkKlL;:'\"zZxXcCvVbBnNmM,<.>/?";

		#region NextChar Methods
		/// <summary>
		///		<para>Chooses a random <see cref="char"/> from <see cref="ALLKEYBOARDCHARS"/>.</para>
		///		<para><see cref="NextChar(string, System.Random)"/> can have 0 to 2 <see langword="params"/> but the <see cref="string"/> <see langword="param"/> can be switched for a <see cref="char"/>[] to make <see cref="NextChar(char[], System.Random)"/>.</para>
		/// </summary>
		public static char NextChar() {
			return NextChar(ALLKEYBOARDCHARS, new System.Random());
		}

		/// <summary>
		///		<para>Chooses a random <see cref="char"/> from <see cref="string"/> <paramref name="charPool"/>.</para>
		///		<para><see cref="NextChar(string, System.Random)"/> can have 0 to 2 <see langword="params"/> but the <see cref="string"/> <see langword="param"/> can be switched for a <see cref="char"/>[] to make <see cref="NextChar(char[], System.Random)"/>.</para>
		/// </summary>
		/// <param name="charPool"></param>
		public static char NextChar(string charPool) {
			return NextChar(charPool, new System.Random());
		}

		/// <summary>
		///		<para>Chooses a random <see cref="char"/> from <see cref="char"/>[] <paramref name="charPool"/>.</para>
		///		<para><see cref="NextChar(char[], System.Random)"/> can have 0 to 2 <see langword="params"/> but the <see cref="char"/>[] <see langword="param"/> can be switched for a <see cref="string"/> to make <see cref="NextChar(string, System.Random)"/>.</para>
		/// </summary>
		/// <param name="charPool"></param>
		public static char NextChar(char[] charPool) {
			return NextChar(string.Concat(charPool), new System.Random());
		}

		/// <summary>
		///		<para>Chooses a random <see cref="char"/> from <see cref="ALLKEYBOARDCHARS"/> using <see cref="System.Random"/> <paramref name="rand"/>.</para>
		///		<para><see cref="NextChar(string, System.Random)"/> can have 0 to 2 <see langword="params"/> but the <see cref="string"/> <see langword="param"/> can be switched for a <see cref="char"/>[] to make <see cref="NextChar(char[], System.Random)"/>.</para>
		/// </summary>
		/// <param name="rand"></param>
		public static char NextChar(System.Random rand) {
			return NextChar(ALLKEYBOARDCHARS, rand);
		}

		/// <summary>
		///		<para>Chooses a random <see cref="char"/> from <see cref="char"/>[] <paramref name="charPool"/> using <see cref="System.Random"/> <paramref name="rand"/>.</para>
		///		<para><see cref="NextChar(char[], System.Random)"/> can have 0 to 2 <see langword="params"/> but the <see cref="char"/>[] <see langword="param"/> can be switched for a <see cref="string"/> to make <see cref="NextChar(string, System.Random)"/>.</para>
		/// </summary>
		/// <param name="charPool"></param>
		/// <param name="rand"></param>
		public static char NextChar(char[] charPool, System.Random rand) {
			return NextChar(string.Concat(charPool), rand);
		}

		/// <summary>
		///		<para>Chooses a random <see cref="char"/> from <see cref="string"/> <paramref name="charPool"/> using <see cref="System.Random"/> <paramref name="rand"/>.</para>
		///		<para><see cref="NextChar(string, System.Random)"/> can have 0 to 2 <see langword="params"/> but the <see cref="string"/> <see langword="param"/> can be switched for a <see cref="char"/>[] to make <see cref="NextChar(char[], System.Random)"/>.</para>
		/// </summary>
		/// <param name="charPool"></param>
		/// <param name="rand"></param>
		public static char NextChar(string charPool, System.Random rand) {
			return charPool[rand.Next(charPool.Length)];
		}
		#endregion

		#region NextString Methods
		/// <summary>
		///		<para>Creates a random <see cref="string"/> with a length of <see cref="int"/> <paramref name="length"/> using <see cref="char"/>s from <see cref="ALLKEYBOARDCHARS"/>.</para>
		///		<para><see cref="NextString(int, string, System.Random)"/> can have 1 to 3 <see langword="params"/> but the <see cref="string"/> <see langword="param"/> can be switched for a <see cref="char"/>[] to make <see cref="NextString(int, char[], System.Random)"/></para>
		/// </summary>
		/// <param name="length"></param>
		public static string NextString(int length) {
			return NextString(length, ALLKEYBOARDCHARS, new System.Random());
		}

		/// <summary>
		///		<para>Creates a random <see cref="string"/> with a length of <see cref="int"/> <paramref name="length"/> using <see cref="char"/>s from <see cref="string"/> <paramref name="charPool"/>.</para>
		///		<para><see cref="NextString(int, string, System.Random)"/> can have 1 to 3 <see langword="params"/> but the <see cref="string"/> <see langword="param"/> can be switched for a <see cref="char"/>[] to make <see cref="NextString(int, char[], System.Random)"/></para>
		/// </summary>
		/// <param name="length"></param>
		/// <param name="charPool"></param>
		public static string NextString(int length, string charPool) {
			return NextString(length, charPool, new System.Random());
		}

		/// <summary>
		///		<para>Creates a random <see cref="string"/> with a length of <see cref="int"/> <paramref name="length"/> using <see cref="char"/>[] <paramref name="charPool"/>.</para>
		///		<para><see cref="NextString(int, char[], System.Random)"/> can have 1 to 3 <see langword="params"/> but the <see cref="char"/>[] <see langword="param"/> can be switched for a <see cref="string"/> to make <see cref="NextString(int, char[], System.Random)"/></para>
		/// </summary>
		/// <param name="length"></param>
		/// <param name="charPool"></param>
		public static string NextString(int length, char[] charPool) {
			return NextString(length, string.Concat(charPool), new System.Random());
		}

		/// <summary>
		///		<para>Creates a random <see cref="string"/> with a length of <see cref="int"/> <paramref name="length"/> using <see cref="System.Random"/> <paramref name="rand"/> and <see cref="char"/>s from <see cref="ALLKEYBOARDCHARS"/>.</para>
		///		<para><see cref="NextString(int, string, System.Random)"/> can have 1 to 3 <see langword="params"/> but the <see cref="string"/> <see langword="param"/> can be switched for a <see cref="char"/>[] to make <see cref="NextString(int, char[], System.Random)"/></para>
		/// </summary>
		/// <param name="length"></param>
		/// <param name="rand"></param>
		public static string NextString(int length, System.Random rand) {
			return NextString(length, ALLKEYBOARDCHARS, rand);
		}

		/// <summary>
		///		<para>Creates a random <see cref="string"/> with a length of <see cref="int"/> <paramref name="length"/> using <see cref="System.Random"/> <paramref name="rand"/> and <see cref="char"/>[] <paramref name="charPool"/>.</para>
		///		<para><see cref="NextString(int, char[], System.Random)"/> can have 1 to 3 <see langword="params"/> but the <see cref="char"/>[] <see langword="param"/> can be switched for a <see cref="string"/> to make <see cref="NextString(int, char[], System.Random)"/></para>
		/// </summary>
		/// <param name="length"></param>
		/// <param name="charPool"></param>
		/// <param name="rand"></param>
		public static string NextString(int length, char[] charPool, System.Random rand) {
			return NextString(length, string.Concat(charPool), rand);
		}

		/// <summary>
		///		<para>Creates a random <see cref="string"/> with a length of <see cref="int"/> <paramref name="length"/> using <see cref="System.Random"/> <paramref name="rand"/> and <see cref="char"/>s from <see cref="string"/> <paramref name="charPool"/>.</para>
		///		<para><see cref="NextString(int, string, System.Random)"/> can have 1 to 3 <see langword="params"/> but the <see cref="string"/> <see langword="param"/> can be switched for a <see cref="char"/>[] to make <see cref="NextString(int, char[], System.Random)"/></para>
		/// </summary>
		/// <param name="length"></param>
		/// <param name="charPool"></param>
		/// <param name="rand"></param>
		public static string NextString(int length, string charPool, System.Random rand) {
			string randString = "";

			for (int i = 0; i < length; i++) {
				randString += charPool[rand.Next(charPool.Length)];
			}

			return randString;
		}
		#endregion

		#region Random Chance Methods
		/// <summary>
		///		<para>Returns <see langword="true"/> a percentage of the time equal to <see cref="int"/> <paramref name="percent"/>.</para>
		///		<para>Values of <paramref name="percent"/> greater than or equal to 100 always return <see langword="true"/> and values of <paramref name="percent"/> less than or equal to 0 always return <see langword="false"/>.</para>
		///		<para><see cref="Chance(int, System.Random)"/> can have 1 to 2 <see langword="params"/> but the <see cref="int"/> <see langword="param"/> can be switched for a <see cref="double"/> to make <see cref="Chance(double, System.Random)"/>.</para>
		/// </summary>
		/// <param name="percent"></param>
		public static bool Chance(int percent) {
			return Chance(percent, new System.Random());
		}

		/// <summary>
		///		<para>Returns <see langword="true"/> a percentage of the time equal to <see cref="int"/> <paramref name="percent"/> using <see cref="System.Random"/> <paramref name="rand"/>.</para>
		///		<para>Values of <paramref name="percent"/> greater than or equal to 100 always return <see langword="true"/> and values of <paramref name="percent"/> less than or equal to 0 always return <see langword="false"/>.</para>
		///		<para><see cref="Chance(int, System.Random)"/> can have 1 to 2 <see langword="params"/> but the <see cref="int"/> <see langword="param"/> can be switched for a <see cref="double"/> to make <see cref="Chance(double, System.Random)"/>.</para>
		/// </summary>
		/// <param name="percent"></param>
		/// <param name="rand"></param>
		public static bool Chance(int percent, System.Random rand) {
			if (percent > rand.Next(100)) {
				return true;
			}
			return false;
		}

		/// <summary>
		///		<para>Returns <see langword="true"/> a percentage of the time equal to <see cref="double"/> <paramref name="percent"/>.</para>
		///		<para>Values of <paramref name="percent"/> greater than or equal to 1.0 always return <see langword="true"/> and values of <paramref name="percent"/> less than or equal to 0.0 always return <see langword="false"/>.</para>
		///		<para><see cref="Chance(double, System.Random)"/> can have 1 to 2 <see langword="params"/> but the <see cref="double"/> <see langword="param"/> can be switched for a <see cref="int"/> to make <see cref="Chance(int, System.Random)"/>.</para>
		/// </summary>
		/// <param name="percent"></param>
		public static bool Chance(double percent) {
			return Chance(percent, new System.Random());
		}

		/// <summary>
		///		<para>Returns <see langword="true"/> a percentage of the time equal to <see cref="double"/> <paramref name="percent"/> using <see cref="System.Random"/> <paramref name="rand"/>.</para>
		///		<para>Values of <paramref name="percent"/> greater than or equal to 1.0 always return <see langword="true"/> and values of <paramref name="percent"/> less than or equal to 0.0 always return <see langword="false"/>.</para>
		///		<para><see cref="Chance(double, System.Random)"/> can have 1 to 2 <see langword="params"/> but the <see cref="double"/> <see langword="param"/> can be switched for a <see cref="int"/> to make <see cref="Chance(int, System.Random)"/>.</para>
		/// </summary>
		/// <param name="percent"></param>
		/// <param name="rand"></param>
		public static bool Chance(double percent, System.Random rand) {
			if (percent > rand.NextDouble()) {
				return true;
			}
			return false;
		}
		#endregion
	}
}