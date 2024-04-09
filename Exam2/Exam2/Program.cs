namespace Exam2
{
    internal class Program
    {

        static string name = "Nikolay";
        static string fNumber = "321iz";

        static double maxNum = double.MinValue;

        private static void FindMaxNum(double currentNumber)
        {
            if (currentNumber > maxNum)
            {
                maxNum = currentNumber;
            }
        }
        static void Main()
        {
            
            Console.Write("Enter the dimension of the array (n): ");
            int n = int.Parse(Console.ReadLine());
            double[] numberArr = new double[n];

            for (int i = 0; i < n; i++)
            {
                numberArr[i] = Math.Abs(n * i - 3);
                FindMaxNum(numberArr[i]);
            }

            Console.WriteLine("Array values: " + string.Join(", ", numberArr));
            Console.WriteLine(maxNum);
        }
    }
}