namespace OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Teacher teacher = new Teacher("Dimitrov", "prof.");
  

            Student student = new Student("Georgiev", "student");

            teacher.SendMessage(student, "Hi Ivan Georgiev. Please send me the course work.");
            teacher.SendMessage(student, "The deadline is till the end of the mounth.");
            student.SendMessage(teacher, "Hi prof. Dimitrov, I send it 2 days ago. Please check in the spam also.");
            teacher.SendMessage(student, "Hi Ivan Georgiev!I found it! You past the course with 6!");
            student.SendMessage(teacher, "Hi prof. Dimitrov! Thanks a lot!");

            ChatHistory.PrintChats();
        }
    }
}