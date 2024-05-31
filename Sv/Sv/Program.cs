namespace Sv
{
    internal class Program
    {
        static void Main()
        {
            
            Console.Write("Enter the number of rows (m): ");
            int m = int.Parse(Console.ReadLine());

            Console.Write("Enter the number of columns (n): ");
            int n = int.Parse(Console.ReadLine());

            
            int[,] Arr = new int[m, n];

            
            Console.WriteLine("Enter values for the array:");

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"Arr[{i},{j}]: ");
                    Arr[i, j] = int.Parse(Console.ReadLine());
                }
            }

            
            Console.WriteLine("Entered array as a matrix:");

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{Arr[i, j]} \t");
                }
                Console.WriteLine();
            }

            
            bool hasDistinctElements = CheckDistinctElements(Arr);

            
            if (hasDistinctElements)
            {
                Console.WriteLine("The array consists of distinct elements.");
            }
            else
            {
                Console.WriteLine("The array contains duplicate elements.");
            }
        }

        static bool CheckDistinctElements(int[,] array)
        {
            
            HashSet<int> uniqueElements = new HashSet<int>();

            
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    
                    if (uniqueElements.Contains(array[i, j]))
                    {
                        
                        return false;
                    }

                    
                    uniqueElements.Add(array[i, j]);
                }
            }

            return true;
        }
    }
}