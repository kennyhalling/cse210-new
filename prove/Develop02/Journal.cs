// Journal:
//   -Displays menu that user can interact with in order to access different parts
//       of their virtual journal
//   -Attributes:
//       -_userChoice string
//       -_journalEntriesList string
//       -_fileName string
//   -Behaviors:
//       -SaveFile()
//       -LoadFile()
//       -NewEntry()
//       -Display()
using System.IO;

public class Journal
{
    public void JournalMenu()
    {
        string dash = "--------------------------------------------------------------";
        string fileName = "currentEntries.txt";
        Boolean active = true;
        while (active == true){
            Console.WriteLine($"\r\n{dash}");
            Console.Write(@"Welcome to your virtual journal!
            Please select one of the following choices: 
            1. Write New Entry
            2. Display Journal
            3. Load Journal
            4. Save Journal
            5. Exit Program
            What would you like to do?: ");
            int _userChoice = int.Parse(Console.ReadLine());
            Console.WriteLine($"{dash}\r\n");
            if (_userChoice == 1)
            {
                NewEntry(fileName);
            }
            if (_userChoice == 2)
            {
                DisplayJournal(fileName);
            }
            if (_userChoice == 3)
            {
                SaveJournal(fileName);
                LoadJournal(fileName);
            }
            if (_userChoice == 4)
            {
                SaveJournal(fileName);
            }
            if (_userChoice == 5)
            {
                active = false;
            }
        }
    }

    public Journal()
    {}

    public void NewEntry(string fileName)
    {
        NewEntry entry = new NewEntry();
        string prompt = entry.GetPrompt();
        Console.WriteLine(prompt);
        string date = entry.getDate();
        string message =  entry.GetInput();
        string Entry = $"{date}:\r\n{prompt}\r\n{message}";
        using (StreamWriter outputfile = new StreamWriter(fileName, true))
        {
            outputfile.WriteLine($"{Entry}");
            outputfile.WriteLine();
        }
    }

    public void DisplayJournal(string fileName)
    {
        string[] lines = System.IO.File.ReadAllLines(fileName);
        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }
    }

    public void LoadJournal(string fileName)
    {
        Console.WriteLine("Which file would you like to load?: ");
        string loadFile = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(loadFile);
        using (StreamWriter outputfile = new StreamWriter(fileName))
        {
            foreach (string line in lines)
            {
                outputfile.WriteLine(line);
            }
        }
    }

    public void SaveJournal(string fileName)
    {
        string[] lines = System.IO.File.ReadAllLines(fileName);
        Console.Write("Where would you like to save your current entries to?: ");
        string saveFile = Console.ReadLine();
        using (StreamWriter outputfile = new StreamWriter(saveFile, true))
        {
            foreach (string line in lines)
            {
                outputfile.WriteLine(line);
            }
        }
    }
}