using System;

namespace Wishtack.Training
{
    public interface ICurrencyHelper
    {

        decimal CurrentChangeRate (string sourceCurrency, string targetCurrency);

    }
}

