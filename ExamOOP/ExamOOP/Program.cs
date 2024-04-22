namespace ExamOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SavingsAccount sa1 = new SavingsAccount("Ivan", 10000);
            CreditAccount ca1 = new CreditAccount("Mitko", 10000);
            Customer Petar = new Customer(65, "Petar");
            Customer Dimitar = new Customer(45, "Dimitar");

            sa1.GetCredit(1000, Dimitar);
            ca1.GetCredit(4000, Petar);
            
        }
    }
}