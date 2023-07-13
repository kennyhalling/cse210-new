using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new Assignment("Ashton", "Division");
        Console.Clear();
        Console.WriteLine(assignment1.GetSummary());

        MathAssignment assignment2 = new MathAssignment("Ashton", "Division", "8.2", "1-12");
        Console.WriteLine(assignment2.GetHomeworkList());

        WritingAssignment assignment3 = new WritingAssignment("Nathan Young", "1900s America", "The Cold War");
        Console.WriteLine(assignment3.GetWritingInfo());
    }
}