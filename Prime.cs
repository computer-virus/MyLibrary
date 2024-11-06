namespace MyLibrary {
	/// <summary>
	///		<see cref="Prime"/> contains all of <see cref="MyLibrary"/>'s prime number <see langword="methods"/>.
	/// </summary>
	public static class Prime {
		/// <summary>
		///		<para>Returns <see langword="true"/> if <see cref="int"/> <paramref name="number"/> is a prime number.</para>
		///		<para><see cref="Check(int)"/> must have exactly 1 <see langword="param"/>.</para>
		/// </summary>
		/// <param name="number"></param>
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

		/// <summary>
		///		<para>Returns a collection of the first prime numbers up to <see cref="int"/> <paramref name="size"/>.</para>
		///		<para>Returns <see langword="null"/> if <paramref name="size"/> is less than 0.</para>
		///		<para><see cref="GetList(int)"/> must have exactly 1 <see langword="param"/>.</para>
		/// </summary>
		/// <param name="size"></param>
		public static List<int>? GetList(int size) {
			if (size < 0) {
				return null;
			}

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

		/// <summary>
		///		<para>Returns the <see cref="int"/> <paramref name="nth"/> prime number.</para>
		///		<para>Returns <see langword="null"/> if <paramref name="nth"/> is less than 0.</para>
		///		<para><see cref="GetNth(int)"/> must have exactly 1 <see langword="param"/>.</para>
		/// </summary>
		/// <param name="nth"></param>
		public static int? GetNth(int nth) {
			if (nth < 1) {
				return null;
			}
			
			return GetList(nth)?[nth - 1];
		}
	}
}