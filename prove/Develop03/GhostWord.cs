public class GhostWord{
    private string _ghostWord;
    private string _currentWord;
    private bool _show = true;

    public GhostWord(string word, string ghostWord){
       _currentWord = word;
       _ghostWord = ghostWord;
       if (_currentWord == _ghostWord){
            _show = false;
       }
    }

    public string RenderedText(){
        if (_show){
            return _currentWord;
        }
        else{
            return "____";
        }
    }   
}