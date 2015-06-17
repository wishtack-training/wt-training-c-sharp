using System;

namespace Wishtack.Training
{
	public class Price
	{

		public Price(
			decimal? amount = null,
			int? coefficient = null,
			int? exponent = null,
			string currency = null
		) {

			this.coefficient = coefficient;
			this.exponent = exponent;
			this.currency = currency;

			if (amount != null) {
				this.coefficient = (int)Math.Round ((decimal)amount * 100);
				this.exponent = -2;
			}

		}

		public decimal? amount {
			get {

				if (this.coefficient == null || this.exponent == null) {
					return null;
				}

				return (decimal)(this.coefficient * Math.Pow (10d, (double)this.exponent));
			}
		}
		public int? coefficient { get; }
		public int? exponent { get; }
		public string currency { get; }

	}

}
