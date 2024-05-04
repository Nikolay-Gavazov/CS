namespace OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Teacher teacher = new Teacher("prof. Ivanov");
  

            Student student = new Student("Petur Petrov");

            teacher.SendMessage(student, "Hi Petur Petrov! You past the exam with 6!");
            student.SendMessage(teacher, "Hi prof. Ivanov! Thanks a lot!");

            Archive.DisplayArchive();
        }
    }
}