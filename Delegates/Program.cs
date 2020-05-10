
using System;
using System.Collections.Generic;

namespace Delegates
{
    class Program
    {

        delegate double BinaryNumericOperation(double n1, double n2);

        static void Main(string[] args)
        {
            var processor = new PhotoProcessor();
            var filters = new PhotoFilters();

            Action<Photo> filterHandler = filters.ApplyBrightness;
            filterHandler += filters.ApplyContrast;
            filterHandler += RemoveRedEyeFilter;
            filterHandler += filters.Resize;

            processor.Process("photo.jpg", filterHandler);

            double a = 10;
            double b = 12;
            BinaryNumericOperation op = CalculationService.Sum;
            //BinaryNumericOperation op = new BinaryNumericOperation(CalculationService.Sum);
            // double result = op(a, b);
            double result = op.Invoke(a, b);
            Console.WriteLine(result);

            //BinaryNumericOperation op = CalculationService.ShowSum;
            //op += CalculationService.ShowMax;
            //op(a, b);


            List<Product> list = new List<Product>();

            list.Add(new Product("Tv", 900.00));
            list.Add(new Product("Mouse", 50.00));
            list.Add(new Product("Tablet", 350.50));
            list.Add(new Product("HD Case", 80.90));

            list.RemoveAll(p => p.Price >= 100.0);
            foreach (Product p in list)
            {
                Console.WriteLine(p);
            }

            list.ForEach(p => { p.Price += p.Price * 0.1; });
            foreach (Product p in list)
            {
                Console.WriteLine(p);
            }

            list.ForEach(UpdatePrice);
            foreach (Product p in list)
            {
                Console.WriteLine(p);
            }

        }

        private static void UpdatePrice(Product p)
        {
            p.Price += p.Price * 0.1;
        }

        static void RemoveRedEyeFilter(Photo photo)
        {
            Console.WriteLine("Apply RemoveRedEye");
            
        }
    }
}
