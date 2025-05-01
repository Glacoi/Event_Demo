/*
 * Stock Prices (Event Handlers)
 * Trent Hitchcock
 * 3/12/25
 * credit: help from my brother Tyler
 */

using System;

namespace EventDemo
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Programming II Stock Prices (Event Handlers) by Trent Hitchcock";
            Exchange exchange = new Exchange();
            exchange.Open();
        }
    }
}
