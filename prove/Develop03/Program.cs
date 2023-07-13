using System;

class Program
{
    static void Main(string[] args)
    {
        Reference refString = new Reference("Proverbs", "3", "5", "6");
        string reference = refString.RenderReference();
        Console.WriteLine(reference);

        Scripture scripture = new Scripture(reference, "Trust in the Lord with all thine heart; and lean not unto thine own understanding; In all thy ways acknowledge him, and he shall direct thy paths.");
        scripture.RenderScripture();
    }
}