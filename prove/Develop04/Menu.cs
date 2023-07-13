public class Menu{
    private int _userChoice;
    private bool _active = true;

    public Menu(){

    }

    public void DisplayMenu(){
        Console.Clear();
        while (_active){
            Console.Write(@"
                Welcome to your Mindfulness Center.
                What activity would you like to do?:
                1. Breathing Activity
                2. Reflection Activity
                3. Listing Activity
                4. Quit
                Enter your choice's list number: ");
            _userChoice = int.Parse(Console.ReadLine());
            Console.Clear();
            RunActivity();
        }
    }

    private void RunActivity(){
        if (_userChoice == 1){
            BreathingActivity ba = new BreathingActivity(@"Breathing Activity", @"
            This activiy will guide you through relaxing, deep breathing.
            Follow the prompts to breathe in and out.");
            ba.RunBreathingActivity();
        }
        else if (_userChoice == 2){
            ReflectionActivity ra = new ReflectionActivity(@"Reflection Activity", @"
            This activity will give you prompts to guide you through positive self-reflection.
            You will get a random prompt and then a series of questions about it to help you reflect.");
            ra.RunReflectionActivity();
        }
        else if (_userChoice == 3){
            ListingActivity la = new ListingActivity(@"Listing Activity", @"
            This activity will guide you through creating a list of positive things.
            Create a list about the random positve category, pressing 'Enter' after each item.");
            la.RunListingActivity();
        }
        else if (_userChoice ==4){
            _active = false;
        }
        else{
            Console.WriteLine("Please choose from the list below.");
        };
    }
}