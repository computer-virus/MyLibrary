using System.Diagnostics;

namespace MyLibrary {
	/// <summary>
	///		<see cref="Shell"/> contains all of <see cref="MyLibrary"/>'s file and directory <see langword="methods"/>.
	/// </summary>
	public static class Shell {
		#region Open Path Methods
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
		#endregion
	}
}
