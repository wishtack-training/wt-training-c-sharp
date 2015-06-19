using System;

namespace Wishtack.Training
{
	public class Price
	{

        private ICurrencyHelper _currencyHelper;

		public Price(
			decimal? amount = null,
			int? coefficient = null,
			int? exponent = null,
			string currency = null,
            ICurrencyHelper currencyHelper = null
		) {

			this.coefficient = coefficient;
			this.exponent = exponent;
			this.currency = currency;

			if (amount != null) {
				this.coefficient = (int)Math.Round ((decimal)amount * 100);
				this.exponent = -2;
			}

            if (currencyHelper == null) {
                currencyHelper = new CurrencyHelper();
            }

            this._currencyHelper = currencyHelper;

		}

        public Price ConvertCurrency(string targetCurrency) {

            var amount = this._currencyHelper.CurrentChangeRate (sourceCurrency: this.currency, targetCurrency: targetCurrency) * this.amount;

            return new Price (amount: amount, currency: targetCurrency);

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
