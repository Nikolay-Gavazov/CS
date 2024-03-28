namespace Course_Work
{
    internal class Program
    {
        static void Main()
        {
            int limit = 4000000;
            int sum = 0;
            int first = 1;
            int second = 2;

            while (second <= limit)
            {
                if (second % 2 == 0)
                {
                    sum += second;
                }

                int next = first + second;
                first = second;
                second = next;
            }
            string result = "The sum of even-valued terms in the Fibonacci sequence is: ";
            Console.WriteLine(result + sum);
        }

    }
}