using System.ComponentModel;

namespace MyLibrary {
	/// <summary>
	///		<see cref="Console"/> contains all of <see cref="MyLibrary"/>'s console <see langword="methods"/>.
	/// </summary>
	public static class Console {
		#region ReadLine Loop Methods
		/// <summary>
		///		<para>Writes <paramref name="prompt"/> to <see cref="System.Console"/> and then attempts to convert <see cref="System.Console.ReadLine"/> to the requested data type <typeparamref name="T"/>.</para>
		///		<para>If the conversion fails, writes a generic error to <see cref="System.Console"/>, removes <see cref="System.Console.ReadLine"/>'s input from <see cref="System.Console"/>, and loops.</para>
		///		<para><see cref="ReadLineLoop{T}(string, string, bool)"/> can have 1 to 3 <see langword="params"/>.</para>
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="prompt"></param>
		public static T? ReadLineLoop<T>(string prompt) {
			return ReadLineLoop<T>(prompt, "Please enter your input in the correct format.", false);
		}

		/// <summary>
		///		<para>Writes <paramref name="prompt"/> to <see cref="System.Console"/> and then attempts to convert <see cref="System.Console.ReadLine"/> output to the requested data type <typeparamref name="T"/>.</para>
		///		<para>If the conversion fails, writes <paramref name="errorMessage"/> to <see cref="System.Console"/>, removes <see cref="System.Console.ReadLine"/>'s input from <see cref="System.Console"/>, and loops.</para>
		///		<para><see cref="ReadLineLoop{T}(string , string, bool)"/> can have 1 to 3 <see langword="params"/>.</para>
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="prompt"></param>
		/// <param name="errorMessage"></param>
		public static T? ReadLineLoop<T>(string prompt, string errorMessage) {
			return ReadLineLoop<T>(prompt, errorMessage, false);
		}

		/// <summary>
		///		<para>Writes <paramref name="prompt"/> to <see cref="System.Console"/> and then attempts to convert <see cref="System.Console.ReadLine"/> output to the requested data type <typeparamref name="T"/>.</para>
		///		<para>If the conversion fails, writes <paramref name="errorMessage"/> to <see cref="System.Console"/>, removes <see cref="System.Console.ReadLine"/>'s input from <see cref="System.Console"/>, and loops.</para>
		///		<para>If <paramref name="nullable"/> is set to <see langword="true"/>, then empty <see cref="System.Console.ReadLine"/> outputs will count as a valid input to convert.</para>
		///		<para><see cref="ReadLineLoop{T}(string , string, bool)"/> can have 1 to 3 <see langword="params"/>.</para>
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="prompt"></param>
		/// <param name="errorMessage"></param>
		/// <param name="nullable"></param>
		public static T? ReadLineLoop<T>(string prompt, string errorMessage, bool nullable) {
			// Writes Prompt
			System.Console.Write(prompt);

			// Declares Method Vars
			dynamic? returnVar = default(T);
			int[] currentCursorPos = [System.Console.CursorLeft, System.Console.CursorTop];
			int[] errorCursorPos = [-1, -1];
			bool isConverted = false;
			bool userDidError = false;
			string readLineResult = "";

			// Declares Delegate For Error Correction
			Action errorCorrection = new(() => {
				// Erases User Input
				System.Console.SetCursorPosition(currentCursorPos[0], currentCursorPos[1]);
				Console.Erase(readLineResult.Length, true);
				System.Console.WriteLine();
				// Notes That User Made Error And Tracks Console Cursor Position At Beginning Of Error Message
				isConverted = false;
				if (!userDidError) {
					userDidError = true;
					errorCursorPos = [System.Console.CursorLeft, System.Console.CursorTop];
					// Writes Error Message
					Console.ColorWrite(errorMessage, ConsoleColor.Red);
				}
				// Resets Console Cursor Position And Allows User To Try Again
				System.Console.SetCursorPosition(currentCursorPos[0], currentCursorPos[1]);
			});

			// While User Input Is Not Converted
			while (!isConverted) {
				// Saves ReadLine
				readLineResult = System.Console.ReadLine() ?? "";
				// Attempts To Convert, Catches Exceptions, Gets User To Try Again
				try {
					// Checks If ReadLine Return Is Not Empty
					if (!readLineResult.Equals("")) {
						// Conversion Method
						returnVar = TypeDescriptor.GetConverter(typeof(T)).ConvertFromString(readLineResult);
						isConverted = true;
					} else if (!nullable) {
						// ReadLine Returned Empty; Preforms Correction Without Needing To Throw Exception
						errorCorrection();
					} else {
						returnVar = default(T);
						isConverted = true;
					}
				} catch {
					// Preforms Error Correction
					errorCorrection();
				}
			}

			// Checks If User Made A Mistake Previously
			if (userDidError) {
				// Erases Previous Error Message
				System.Console.SetCursorPosition(errorCursorPos[0], errorCursorPos[1]);
				Console.Erase(errorMessage.Length, true);
			}

			// Returns Converted ReadLine
			return returnVar;
		}
		#endregion

		#region Erase Methods
		/// <summary>
		///		<para>Moves <see cref="System.Console"/> cursor 1 position backwards and removes <see cref="char"/> on that position.</para>
		///		<para><see cref="Erase(int, bool)"/> uses a feature similar to <see langword="text-wrap"/> if process would go past the <see cref="System.Console"/> border.</para>
		///		<para><see cref="Erase(int, bool)"/> can have 0 to 2 <see langword="params"/>.</para>
		/// </summary>
		public static void Erase() {
			Erase(1, false);
		}

		/// <summary>
		///		<para>If value of <see cref="bool"/> <paramref name="forwards"/> is <see langword="false"/>, moves <see cref="System.Console"/> cursor 1 position backwards and removes <see cref="char"/> on that position of <see cref="System.Console"/>.</para>
		///		<para>Otherwise, removes <see cref="char"/> on current cursor position of <see cref="System.Console"/>.</para>
		///		<para>If value of <paramref name="forwards"/> is <see langword="false"/>, then <see cref="System.Console"/></para>
		///		<para><see cref="Erase(int, bool)"/> uses a feature similar to <see langword="text-wrap"/> if process would go past the <see cref="System.Console"/> border.</para>
		///		<para><see cref="Erase(int, bool)"/> can have 0 to 2 <see langword="params"/>.</para>
		/// </summary>
		/// <param name="forwards"></param>
		public static void Erase(bool forwards) {
			Erase(1, forwards);
		}

		/// <summary>
		///		<para>Moves <see cref="System.Console"/> cursor <see cref="int"/> <paramref name="numberOfCharacters"/> backwards and removes all <see cref="char"/>s within <paramref name="numberOfCharacters"/> positions ahead.</para>
		///		<para><see cref="Erase(int, bool)"/> uses a feature similar to <see langword="text-wrap"/> if process would go past the <see cref="System.Console"/> border.</para>
		///		<para><see cref="Erase(int, bool)"/> can have 0 to 2 <see langword="params"/>.</para>
		/// </summary>
		/// <param name="numberOfCharacters"></param>
		public static void Erase(int numberOfCharacters) {
			Erase(numberOfCharacters, false);
		}

		/// <summary>
		///		<para>If value of <see cref="bool"/> <paramref name="forwards"/> is <see langword="true"/>, removes all <see cref="char"/>s within <see cref="int"/> <paramref name="numberOfCharacters"/> positions ahead.</para>
		///		<para>Otherwise, moves <see cref="System.Console"/> cursor <paramref name="numberOfCharacters"/> positions backwards and removes all <see cref="char"/>s within <paramref name="numberOfCharacters"/> positions ahead.</para>
		///		<para><see cref="Erase(int, bool)"/> uses a feature similar to <see langword="text-wrap"/> if process would go past the <see cref="System.Console"/> border.</para>
		///		<para><see cref="Erase(int, bool)"/> can have 0 to 2 <see langword="params"/>.</para>
		/// </summary>
		/// <param name="numberOfCharacters"></param>
		/// <param name="forwards"></param>
		public static void Erase(int numberOfCharacters, bool forwards) {
			if (forwards) {
				int[] cursorPosition = [System.Console.CursorLeft, System.Console.CursorTop];
				System.Console.Write(new string(' ', numberOfCharacters));
				System.Console.SetCursorPosition(cursorPosition[0], cursorPosition[1]);
			} else {
				for (int i = 0; i < numberOfCharacters; i++) {
					int[] cursorPosition = [System.Console.CursorLeft, System.Console.CursorTop];
					if (cursorPosition[0] < 1) {
						if (cursorPosition[1] > 0) {
							cursorPosition[0] = System.Console.WindowWidth - 1;
							cursorPosition[1]--;
							System.Console.SetCursorPosition(cursorPosition[0], cursorPosition[1]);
							System.Console.Write(" ");
						}
					} else {
						System.Console.Write("\b \b");
					}

				}
			}
		}
		#endregion

		#region Fill Methods
		/// <summary>
		///		<para>Fills all of <see cref="System.Console"/> with <see cref="char"/> <paramref name="c"/>.</para>
		///		<para><see cref="Fill(char)"/> must have exactly 1 <see langword="param"/> but it can be a <see cref="string"/> to make <see cref="Fill(string)"/>.</para>
		/// </summary>
		/// <param name="c"></param>
		public static void Fill(char c) {
			System.Console.Write(new string(c, System.Console.WindowWidth * System.Console.WindowHeight));
		}

		/// <summary>
		///		<para>Fills all of <see cref="System.Console"/> with <see cref="string"/> <paramref name="fillString"/>, repeating <paramref name="fillString"/> should the string be too short.</para>
		///		<para><see cref="Fill(string)"/> must have exactly 1 <see langword="param"/> but it can be a <see cref="char"/> to make <see cref="Fill(char)"/>.</para>
		/// </summary>
		/// <param name="fillString"></param>
		public static void Fill(string fillString) {
			int totalChars = System.Console.WindowWidth * System.Console.WindowHeight;

			for (int i = 0; i < totalChars; i++) {
				System.Console.Write(fillString[i % fillString.Length]);
			}
		}
		#endregion

		#region Shift Cursor Methods
		/// <summary>
		///		<para>Shifts <see cref="System.Console"/> cursor's horizontal position in the direct and value of <see cref="int"/> <paramref name="horizontalShift"/>.</para>
		///		<para>The value of <paramref name="horizontalShift"/> will be clipped to fit within <see cref="System.Console"/> bounds.</para>
		///		<para><see cref="ShiftCursorPosition(int, int)"/> can have 1 to 2 <see langword="params"/>.</para>
		/// </summary>
		/// <param name="horizontalShift"></param>
		public static void ShiftCursorPosition(int horizontalShift) {
			ShiftCursorPosition(horizontalShift, 0);
		}

		/// <summary>
		///		<para>Shifts <see cref="System.Console"/> cursor's position in the direction and value of <see cref="int"/> <paramref name="horizontalShift"/> and <see cref="int"/> <paramref name="verticalShift"/>.</para>
		///		<para>The values of <paramref name="horizontalShift"/> and <paramref name="verticalShift"/> will be clipped to fit within <see cref="System.Console"/> bounds.</para>
		///		<para><see cref="ShiftCursorPosition(int, int)"/> can have 1 to 2 <see langword="params"/>.</para>
		/// </summary>
		/// <param name="horizontalShift"></param>
		/// <param name="verticalShift"></param>
		public static void ShiftCursorPosition(int horizontalShift, int verticalShift) {
			int hShift = Math.Max(System.Console.CursorLeft + horizontalShift, 0);
			hShift = Math.Min(hShift, System.Console.WindowWidth - 1);

			int vShift = Math.Max(System.Console.CursorTop + verticalShift, 0);
			vShift = Math.Min(vShift, System.Console.WindowHeight - 1);

			System.Console.SetCursorPosition(hShift, vShift);
		}
		#endregion

		#region Color Console Methods
		/// <summary>
		///		<para>Writes the specified <see cref="string"/> <paramref name="value"/> to the standard output stream in the given <see cref="ConsoleColor"/> <paramref name="color"/>.</para>
		///		<para><see cref="ColorWrite(string, ConsoleColor)"/> must have exactly 2 <see langword="params"/>.</para>
		/// </summary>
		/// <param name="value"></param>
		/// <param name="color"></param>
		public static void ColorWrite(string value, ConsoleColor color) {
			ConsoleColor origCol = System.Console.ForegroundColor;

			System.Console.ForegroundColor = color;
			System.Console.Write(value);
			System.Console.ForegroundColor = origCol;
		}

		/// <summary>
		///		<para>Writes the specified <see cref="string"/> <paramref name="value"/>, followed by the current line terminator, to the standard output stream in the given <see cref="ConsoleColor"/> <paramref name="color"/>.</para>
		///		<para><see cref="ColorWriteLine(string, ConsoleColor)"/> must have exactly 2 <see langword="params"/>.</para>
		/// </summary>
		/// <param name="value"></param>
		/// <param name="color"></param>
		public static void ColorWriteLine(string value, ConsoleColor color) {
			ColorWrite(value + Environment.NewLine, color);
		}

		/// <summary>
		///		<para>Reads the next line of character from the standard input stream.</para>
		///		<para>Manual inputs to the stream will be colored in the given <see cref="ConsoleColor"/> <paramref name="color"/>.</para>
		///		<para><see cref="ColorReadLine(ConsoleColor)"/> must have exactly 1 <see langword="param"/>.</para>
		/// </summary>
		/// <param name="color"></param>
		public static string? ColorReadLine(ConsoleColor color) {
			ConsoleColor origCol = System.Console.ForegroundColor;

			System.Console.ForegroundColor = color;
			string? input = System.Console.ReadLine();
			System.Console.ForegroundColor = origCol;

			return input;
		}
		#endregion
	}
}
