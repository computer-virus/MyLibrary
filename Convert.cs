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
			return number switch {
				0 => (char)0x2070,
				1 => (char)0xB9,
				2 => (char)0xB2,
				3 => (char)0xB3,
				4 => (char)0x2074,
				5 => (char)0x2075,
				6 => (char)0x2076,
				7 => (char)0x2077,
				8 => (char)0x2078,
				9 => (char)0x2079,
				_ => default,
			};
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
			return (number % 100) switch {
				11 or 12 or 13 => number + "th",
				// Checks Int And Adds Proper Ordinal
				_ => (number % 10) switch {
					1 => number + "st",
					2 => number + "nd",
					3 => number + "rd",
					_ => number + "th",
				},
			};
		}

		/// <summary>
		///		<para>Formats an <see cref="TimeSpan"/> <paramref name="timespan"/> into a <see cref="string"/> in HH:MM:SS:mmm format.</para>
		///		<para>Returns <see langword="null"/> if the <paramref name="timespan"/> could not be formatted.</para>
		///		<para><see cref="ToTimer"/> must have exactly 1 <see langword="param"/>.</para>
		/// </summary>
		/// <param name="timespan"></param>
		public static string? ToTimer(TimeSpan timespan) {
			try {
				return string.Format(
					"{0:00}:{1:00}:{2:00}.{3:000}",
					timespan.Hours, timespan.Minutes, timespan.Seconds, timespan.Milliseconds
				);
			} catch {
				return null;
			}
		}
		#endregion
	}
}