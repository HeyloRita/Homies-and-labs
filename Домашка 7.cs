using System;

namespace RetailWholesalePricing
{
    public class Product
    {
        public double RetailPricePerKg { get; set; }
        public double DiscountPercentage { get; set; }
        public double DollarExchangeRate { get; set; }

        public Product(double retailPricePerKg, double discountPercentage, double dollarExchangeRate)
        {
            RetailPricePerKg = retailPricePerKg;
            DiscountPercentage = discountPercentage;
            DollarExchangeRate = dollarExchangeRate;
        }

        public double GetWholesalePricePerKg()
        {
            return RetailPricePerKg * (1 - DiscountPercentage / 100);
        }

        public double CalculatePriceInRubles(int quantity)
        {
            return RetailPricePerKg * quantity;
        }

        public double CalculateWholesalePriceInRubles(int quantity)
        {
            return GetWholesalePricePerKg() * quantity;
        }

        public double ConvertToDollars(double priceInRubles)
        {
            return priceInRubles / DollarExchangeRate;
        }

        public void DisplayPrices(int quantity)
        {
            double retailPrice = CalculatePriceInRubles(quantity);
            double wholesalePrice = CalculateWholesalePriceInRubles(quantity);

            Console.WriteLine($"Для {quantity} кг товара:");
            Console.WriteLine($"Розничная цена: {retailPrice} руб. / {ConvertToDollars(retailPrice):F2} $");
            Console.WriteLine($"Оптовая цена: {wholesalePrice} руб. / {ConvertToDollars(wholesalePrice):F2} $");
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите розничную цену за 1 кг (C): ");
            double retailPrice = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите процент оптовой скидки (p): ");
            double discountPercentage = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите текущий курс доллара (D): ");
            double dollarExchangeRate = Convert.ToDouble(Console.ReadLine());

            Product product = new Product(retailPrice, discountPercentage, dollarExchangeRate);

            for (int quantity = 5; quantity <= 50; quantity += 5)
            {
                product.DisplayPrices(quantity);
            }

            Console.ReadKey();
        }
    }
}
