using System;
using System.Collections.Generic;
using System.Text;
using static EventDemo.Utility;

namespace EventDemo
{
    class Stock
    {
        string symbol;
        decimal price;

        private int fluctuationCount = 0;
        public int FluctuationCount => fluctuationCount;
        private List<decimal> priceHistory = new List<decimal>();
        public IReadOnlyList<decimal> PriceHistory => priceHistory;


        public Stock(string symbol) { this.symbol = symbol; }

        public event EventHandler<PriceChangedEventArgs> PriceChanged;

        protected virtual void OnPriceChanged(PriceChangedEventArgs e)
        {
            PriceChanged?.Invoke(this, e);
        }

        public void PriceFluctuation()
        {
            if (GetRandomInteger(10) < 7)
            {
                Price += GetRandomInteger(-5, 6);
            }
        }



        public decimal Price
        {
            get { return price; }
            set
            {
                if (price == value) return;
                decimal oldPrice = price;
                price = value;
                OnPriceChanged(new PriceChangedEventArgs(oldPrice, price));
            }
        }

        public string Symbol { get => symbol; set => symbol = value; }

        public void stock_PriceChanged(object sender, PriceChangedEventArgs e)
        {
            if (e.NewPrice > e.LastPrice)
            {
                Print($"{Symbol} price increased! Previous: {e.LastPrice}, New: {e.NewPrice}, Change: {e.NewPrice - e.LastPrice}");
            }
            else if (e.NewPrice < e.LastPrice)
            {
                Print($"{Symbol} price decreased. Previous: {e.LastPrice}, New: {e.NewPrice}, Change: {e.NewPrice - e.LastPrice}");
            }
        }


        public class PriceChangedEventArgs : EventArgs
        {
            public readonly decimal LastPrice;
            public readonly decimal NewPrice;

            public PriceChangedEventArgs(decimal lastPrice, decimal newPrice)
            {
                LastPrice = lastPrice; NewPrice = newPrice;
            }
        }

    }
}
