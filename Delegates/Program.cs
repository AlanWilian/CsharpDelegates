
using System;

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
        }

        static void RemoveRedEyeFilter(Photo photo)
        {
            Console.WriteLine("Apply RemoveRedEye");
            
        }
    }
}
