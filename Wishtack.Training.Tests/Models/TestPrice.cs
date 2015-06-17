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
	}
}

