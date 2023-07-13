class Assignment{
    protected string _studentName;
    protected string _topic;

    public Assignment(string name, string topic){
        _studentName = name;
        _topic = topic;
    }

    public string GetSummary(){
        return $"{_studentName}'s assignment on {_topic}";
    }

    public string GetName(){
        return _studentName;
    }

    public string GetTopic(){
        return _topic;
    }
}