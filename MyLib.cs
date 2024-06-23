using System.ComponentModel;

namespace MyLibrary {

	/// <summary>
	/// <see cref="MyLib"/> contains all of Edward Tagliapietra's personal custom methods.
	/// </summary>
	public class MyLib() {

		/// <summary>
		///		<see cref="Convert"/> contains all of <see cref="MyLib"/>'s custom conversion <see langword="methods"/>.
		/// </summary>
		public class Convert() {

			/// <summary>
			///		<para>Writes <paramref name="prompt"/> to <see cref="System.Console"/> and then attempts to convert <see cref="System.Console.ReadLine"/> to the requested data type <typeparamref name="T"/>.</para>
			///		<para>If the conversion fails, writes a generic error to <see cref="System.Console"/>, removes <see cref="System.Console.ReadLine"/>'s input from <see cref="System.Console"/>, and loops.</para>
			///		<para><see cref="ReadLineLoop{Task}(string, string)"/> can have 1 to 2 <see langword="params"/>.</para>
			/// </summary>
			/// <typeparam name="T"></typeparam>
			/// <param name="prompt"></param>
			public static T? ReadLineLoop<T>(string prompt) {
				return ReadLineLoop<T>(prompt, "Please enter your input in the correct format.");
			}

			/// <summary>
			///		<para>Writes <paramref name="prompt"/> to <see cref="System.Console"/> and then attempts to convert <see cref="System.Console.ReadLine"/> to the requested data type <typeparamref name="T"/>.</para>
			///		<para>If the conversion fails, writes <paramref name="errorMessage"/> to <see cref="System.Console"/>, removes <see cref="System.Console.ReadLine"/>'s input from <see cref="System.Console"/>, and loops.</para>
			///		<para><see cref="ReadLineLoop{Task}(string , string)"/> can have 1 to 2 <see langword="params"/>.</para>
			/// </summary>
			/// <typeparam name="T"></typeparam>
			/// <param name="prompt"></param>
			/// <param name="errorMessage"></param>
			public static T? ReadLineLoop<T>(string prompt, string errorMessage) {
				// Writes Prompt
				System.Console.Write(prompt);

				// Declares Method Vars
				dynamic? returnVar = default(T);
				int[] currentCursorPos = [System.Console.CursorLeft, System.Console.CursorTop];
				int[] errorCursorPos = [-1, -1];
				bool isConverted = false;
				bool userDidError = false;
				string readLineResult;

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
						} else {
							// ReadLine Returned Empty; Throws Exception
							throw new Exception();
						}
					} catch {
						// Erases User Input
						System.Console.SetCursorPosition(currentCursorPos[0], currentCursorPos[1]);
						System.Console.Write(new string(' ', readLineResult.Length) + "\n");

						// Notes That User Made Error And Tracks Console Cursor Position At Beginning Of Error Message
						isConverted = false;
						if (!userDidError) {
							userDidError = true;
							errorCursorPos = [System.Console.CursorLeft, System.Console.CursorTop];

							// Writes Error Message
							System.Console.Write(errorMessage);
						}

						// Resets Console Cursor Position And Allows User To Try Again
						System.Console.SetCursorPosition(currentCursorPos[0], currentCursorPos[1]);
					}
				}

				// Checks If User Made A Mistake Previously
				if (userDidError) {
					// Erases Previous Error Message
					System.Console.SetCursorPosition(errorCursorPos[0], errorCursorPos[1]);
					System.Console.Write(new string(' ', errorMessage.Length));
					System.Console.SetCursorPosition(errorCursorPos[0], errorCursorPos[1]);
				}

				// Returns Converted ReadLine
				return returnVar;
			}

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
		}

		/// <summary>
		///		<see cref="MyLib"/>.<see cref="Console"/> contains all of <see cref="MyLib"/>'s console <see langword="methods"/>.
		/// </summary>
		public class Console() {

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
		}

		/// <summary>
		///		<see cref="MyLib"/>.<see cref="Random"/> contains all of <see cref="MyLib"/>'s random <see langword="methods"/>.
		/// </summary>
		public class Random() {

			/// <summary>
			///		<para>Default value for <see cref="NextChar()"/> and <see cref="NextChar(System.Random)"/>.</para>
			///		<para>Contains all possible <see cref="char"/>s that can be typed on a keyboard without a numpad.</para>
			/// </summary>
			private const string ALLKEYBOARDCHARS = "`~1!2@3#4$5%6^7&8*9(0)-_=+qQwWeErRtTyYuUiIoOpP[{]}\\|aAsSdDfFgGhHjJkKlL;:'\"zZxXcCvVbBnNmM,<.>/?";

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
		}
	}
}