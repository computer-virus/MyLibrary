namespace MyLibrary {
	/// <summary>
	///		<see cref="Convert"/> contains all of <see cref="MyLibrary"/>'s custom conversion <see langword="methods"/>.
	/// </summary>
	public static class Convert {
		#region Script Conversion Methods
		/// <summary>
		///		<para>Converts a non-negative single digit <see cref="int"/> <paramref name="number"/> into a <see cref="char"/> containing the <paramref name="number"/> in superscript.</para>
		///		<para>Reutrns <see langword="default"/> if <paramref name="number"/> is not a non-negative single digit <see cref="int"/>.</para>
		///		<para>Note that not all superscript <see cref="char"/>s display properly in <see cref="System.Console"/> by default.</para>
		///		<para><see cref="ToSuperscript"/> must have exactly 1 <see langword="param"/>.</para>
		/// </summary>
		/// <param name="number"></param>
		public static char ToSuperscript(int number) {
			switch (number) {
				default:
					return default;
				case 0:
					return (char)0x2070;
				case 1:
					return (char)0xB9;
				case 2:
					return (char)0xB2;
				case 3:
					return (char)0xB3;
				case 4:
					return (char)0x2074;
				case 5:
					return (char)0x2075;
				case 6:
					return (char)0x2076;
				case 7:
					return (char)0x2077;
				case 8:
					return (char)0x2078;
				case 9:
					return (char)0x2079;

			}
		}

		/// <summary>
		///		<para>Converts a single digit <see cref="int"/> <paramref name="number"/> into a <see cref="char"/> containing the <paramref name="number"/> in subscript.</para>
		///		<para>Reutrns <see langword="default"/> if <paramref name="number"/> is not a non-negative single digit <see cref="int"/>.</para>
		///		<para>Note that no subscript <see cref="char"/> displays properly in <see cref="System.Console"/> by default.</para>
		///		<para><see cref="ToSubscript"/> must have exactly 1 <see langword="param"/>.</para>
		/// </summary>
		/// <param name="number"></param>
		public static char ToSubscript(int number) {
			return (char)(0x2080 + number);
		}
		#endregion

		#region Format Methods
		/// <summary>
		///		<para>Converts an <see cref="int"/> <paramref name="number"/> into a <see cref="string"/> containing the <paramref name="number"/>'s english ordinal.</para>
		///		<para>Returns <see langword="null"/> if the <paramref name="number"/> has no english ordinal.</para>
		///		<para><see cref="Ordinal"/> must have exactly 1 <see langword="param"/>.</para>
		/// </summary>
		/// <param name="number"></param>
		public static string? Ordinal(int number) {
			// Checks If Int Is Not An Ordinal
			if (number <= 0) {
				return null;
			}

			// Checks if Int Is The 11th, 12th, Or 13th Of Each 100 And Adds Proper Ordinal If So
			switch (number % 100) {
				case 11:
				case 12:
				case 13:
					return number + "th";
			}

			// Checks Int And Adds Proper Ordinal
			switch (number % 10) {
				case 1:
					return number + "st";
				case 2:
					return number + "nd";
				case 3:
					return number + "rd";
				default:
					return number + "th";
			}
		}

		// Missing XML Comment
		public static string ToTimer(TimeSpan ts) {
			return string.Format(
				"{0:00}:{1:00}:{2:00}.{3:000}",
				ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds
			);
		}
		#endregion
	}
}