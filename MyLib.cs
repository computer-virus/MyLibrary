﻿using System.ComponentModel;
using System.Diagnostics;

namespace MyLibrary {

	/// <summary>
	/// <see cref="MyLib"/> contains all of Edward Tagliapietra's personal custom methods.
	/// </summary>
	public static class MyLib {

		/// <summary>
		///		<see cref="Convert"/> contains all of <see cref="MyLib"/>'s custom conversion <see langword="methods"/>.
		/// </summary>
		public static class Convert {

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

			public static string TimeSpanToTimer(TimeSpan ts) {
				return string.Format(
					"{0:00}:{1:00}:{2:00}.{3:000}",
					ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds
				);
			}
		}

		/// <summary>
		///		<see cref="MyLib"/>.<see cref="Console"/> contains all of <see cref="MyLib"/>'s console <see langword="methods"/>.
		/// </summary>
		public static class Console {

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
				Action errorCorrection = new Action(() => {
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
		}

		/// <summary>
		///		<see cref="MyLib"/>.<see cref="Random"/> contains all of <see cref="MyLib"/>'s random <see langword="methods"/>.
		/// </summary>
		public static class Random {

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

		/// <summary>
		///		<see cref="MyLib"/>.<see cref="File"/> contains all of <see cref="MyLib"/>'s file <see langword="methods"/>.
		/// </summary>
		public static class File {

			/// <summary>
			///		<para>Creates a new file with a path of <see cref="string"/> <paramref name="path"/>, writes <see cref="string"/>[] <paramref name="contents"/> to the file, and then closes the file.</para>
			///		<para>If the file already exists, it gets overwritten.</para>
			///		<para><see cref="WriteAllLines(string, string[])"/> must have exactly 2 <see langword="params"/>.</para>
			/// </summary>
			/// <param name="path"></param>
			/// <param name="contents"></param>
			public static void WriteAllLines(string path, string[] contents) {
				System.IO.File.WriteAllText(path, string.Join(Environment.NewLine, contents));
			}

			/// <summary>
			///		<para>Opens a file, directory, or url using the given <see cref="string"/> <paramref name="path"/>, <see cref="string"/> <paramref name="arguments"/>, and <see cref="string"/> <paramref name="verb"/>.</para>
			///		<para><see cref="Open(string, string, string)"/> can have 1 to 3 <see langword="params"/>.</para>
			/// </summary>
			/// <param name="path"></param>
			/// <param name="arguments"></param>
			/// <param name="verb"></param>
			public static void Open(string path, string arguments, string verb) {
				Process.Start(new ProcessStartInfo {
					FileName = path,
					Arguments = arguments,
					UseShellExecute = true,
					Verb = verb
				});
			}

			/// <summary>
			///		<para>Opens a file, directory, or url using the given <see cref="string"/> <paramref name="path"/> and <see cref="string"/> <paramref name="arguments"/>.</para>
			///		<para><see cref="Open(string, string, string)"/> can have 1 to 3 <see langword="params"/>.</para>
			/// </summary>
			/// <param name="path"></param>
			/// <param name="arguments"></param>
			public static void Open(string path, string arguments) {
				Open(path, arguments, "");
			}

			/// <summary>
			///		<para>Opens a file, directory, or url using the given <see cref="string"/> <paramref name="path"/>.</para>
			///		<para><see cref="Open(string, string, string)"/> can have 1 to 3 <see langword="params"/>.</para>
			/// </summary>
			/// <param name="path"></param>
			public static void Open(string path) {
				Open(path, "", "");
			}
		}

		/// <summary>
		///		<see cref="MyLib"/>.<see cref="Array"/> contains all of <see cref="MyLib"/>'s array <see langword="methods"/>.
		/// </summary>
		public static class Array {

			/// <summary>
			///		<para>Counts the number of occurrences of <typeparamref name="T"/> <paramref name="value"/> in <typeparamref name="T"/>[] <paramref name="array"/> and returns result as an <see cref="int"/>.</para>
			///		<para><see cref="CountOccurrences{T}(T, T[])"/> must have exactly 2 <see langword="params"/>.</para>
			/// </summary>
			/// <typeparam name="T"></typeparam>
			/// <param name="value"></param>
			/// <param name="array"></param>
			public static int CountOccurrences<T>(T value, T[] array) {
				int count = 0;

				foreach (T item in array) {
					if (item != null && item.Equals(value)) {
						count++;
					}
				}

				return count;
			}
		}

		public static class Prime {
			public static bool Check(int number) {
				if (number < 2) {
					return false;
				}

				if (number == 2) {
					return true;
				}

				if (number % 2 == 0) {
					return false;
				}

				int upperBounds = (int)Math.Floor(Math.Sqrt(number));

				for (int i = 3; i <= upperBounds; i += 2) {
					if (number % i == 0) {
						return false;
					}
				}

				return true;
			}

			public static List<int> GetList(int size) {
				ArgumentOutOfRangeException.ThrowIfNegative(size, $"{nameof(size)} must be a positive integer.");

				if (size == 0) {
					return [];
				}

				if (size == 1) {
					return [2];
				}

				List<int> primes = [2];

				for (int i = 3; primes.Count < size; i += 2) {
					bool valid = true;

					foreach (int prime in primes) {
						if (i % prime == 0) {
							valid = false;
							break;
						}
					}

					if (valid) {
						primes.Add(i);
					}
				}

				return primes;
			}

			public static int GetNth(int n) {
				if (n < 1) {
					throw new ArgumentOutOfRangeException($"{nameof(n)} must be an integer greater than 0.");
				}

				return GetList(n)[n - 1];
			}
		}
	}
}