namespace MenuSystem;

public class MenuItem
{
    public string Shortcut { get; set; } = "";
    public string Title { get; set; } = "";
    public Func<string?>? MethodToRun { get; set; } = null;

    public MenuItem(string shortcut, string title, Func<string>? function)
    {
        Shortcut = shortcut;
        Title = title;
        MethodToRun = function;
    }

    public MenuItem()
    {
        
    }

    public override string ToString()
    {
        return Shortcut + ") " + Title;
    }
}