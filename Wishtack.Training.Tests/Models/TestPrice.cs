using Moq;
using NUnit.Framework;
using System;

namespace Wishtack.Training.Tests
{
	[TestFixture]
	public class TestPrice
	{
		[Test]
		public void ShouldHandleDecimalAmount () {

			Price price = null;

			/*
			 * Empty price. 
			 */
			price = new Price ();

			Assert.AreEqual (null, price.coefficient);
			Assert.AreEqual (null, price.exponent);
			Assert.AreEqual (null, price.amount);
			Assert.AreEqual (null, price.currency);

			/*
			 * Simple coefficient + exponent price.
			 */

			price = new Price (coefficient: 1000, exponent: -2, currency: "EUR");

			Assert.AreEqual (1000, price.coefficient);
			Assert.AreEqual (-2, price.exponent);
			Assert.AreEqual (10, price.amount);
			Assert.AreEqual ("EUR", price.currency);

			/*
			 * Price with amount.
			 */

			price = new Price (amount: 100.312m);

			Assert.AreEqual (10031, price.coefficient);
			Assert.AreEqual (-2, price.exponent);
			Assert.AreEqual (100.31, price.amount);
			Assert.AreEqual (null, price.currency);

		}

        public void ShouldConvertCurrency () {

            Price priceEur = null;
            Price priceUsd = null;

            Mock<ICurrencyHelper> mockCurrencyHelper = new Mock<ICurrencyHelper> ();

            mockCurrencyHelper.Setup(instance => instance.CurrentChangeRate("EUR", "USD")).Returns(1.1m);

            priceEur = new Price (amount: 100, currency: "EUR", currencyHelper: mockCurrencyHelper.Object);

            priceUsd = priceEur.ConvertCurrency (targetCurrency: "USD");

            Assert.AreEqual (110, priceUsd.amount);
            Assert.AreEqual ("USD", priceUsd.currency);

            mockCurrencyHelper.Verify(instance => instance.CurrentChangeRate("EUR", "USD"), Times.Exactly(1));

        }

	}
}

