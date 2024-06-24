namespace UnoGame;

using MenuSystem;

public class UnoGame
{
    public static void Main()
    {
        Menu menu = new Menu("First menu", EMenuLevel.First);
        menu.AddMenuItems(new List<MenuItem>()
        {
            new MenuItem("A", "New Menu", RunSecondMenu),
            new MenuItem("P", "Papa", null),
            new MenuItem("C", "Charlie", null),
        });
        menu.Run();
    }

    public static string RunSecondMenu()
    {
        Menu menu = new Menu("Second menu", EMenuLevel.Second);
        menu.AddMenuItems(new List<MenuItem>()
        {
            new MenuItem("D", "Delta", null),
            new MenuItem("F", "New Menu", RunThirdMenu),
            new MenuItem("G", "Golf", null),
        });
        return menu.Run();
    }
    
    public static string RunThirdMenu()
    {
        Menu menu = new Menu("Third menu", EMenuLevel.More);
        menu.AddMenuItems(new List<MenuItem>()
        {
            new MenuItem("H", "Hotel", null),
            new MenuItem("I", "India", null),
            new MenuItem("J", "Juliet", null),
        });
        return menu.Run();
    }
}