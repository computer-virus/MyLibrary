namespace MyLibrary {
	// Missing XML Comment
	public static class Prime {
		// Missing XML Comment
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

		// Missing XML Comment
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

		// Missing XML Comment
		public static int GetNth(int n) {
			if (n < 1) {
				throw new ArgumentOutOfRangeException($"{nameof(n)} must be an integer greater than 0.");
			}

			return GetList(n)[n - 1];
		}
	}
}