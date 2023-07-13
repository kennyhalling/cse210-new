public class Scripture
{
    private string _reference;
    private string _scripture;
    private string _userInput;
    private string _ghostword;
    private bool _active = true;
    private List<string> _scriptureWords;
    private List<string> _shownWords;

    public Scripture(string reference, string scripture){
        _reference = reference;
        _scripture = scripture;
        _scriptureWords = _scripture.Split(" ").ToList<string>();
        _shownWords = _scripture.Split(" ").ToList<string>();
    }

    public void RenderScripture(){
        while (_active){
            Console.Clear();
            Console.WriteLine(@$"{_reference}: {_scripture}");
            Console.Write("\nPlease hit enter or type 'quit': ");
            _userInput = Console.ReadLine();
            if (_userInput == "quit"){
                AllHidden();
            }
            else{
                HideWords();
            };
        }
    }

    private void HideWords(){
        // Using this list, I will only select words that haven't already been hidden
        Random rnd = new Random();
        int rndIndex = rnd.Next(_shownWords.Count);
        _ghostword = _shownWords[rndIndex];
        _shownWords.Remove(_ghostword);
        foreach(string word in _scriptureWords.ToList()){
            GhostWord gw = new GhostWord(word, _ghostword);
            string result = gw.RenderedText();
            if (result == "____"){
                int index = _scriptureWords.FindIndex(a => a.Contains(_ghostword));
                if (index != -1)
                    _scriptureWords[index] = result;
            }   
        }
        _scripture = String.Join(" ", _scriptureWords);
        if (_shownWords.Count == 0){
            AllHidden();
        }
    }

    private void AllHidden(){
        _active = false;
        Console.Clear();
    }
}