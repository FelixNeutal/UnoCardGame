namespace MenuSystem;

public class Menu
{
    public List<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
    public List<MenuItem> SpecialMenuItems { get; set; } = new List<MenuItem>();
    public List<string> ReservedShortcuts { get; set; } = new List<string>() {"E", "B", "M"};
    public string Title { get; set; } = default!;
    public EMenuLevel MenuLevel { get; set; }
    public string MenuSeparator { get; set; } = "============================================";

    public Menu(string title, EMenuLevel menuLevel)
    {
        Title = title;
        MenuLevel = menuLevel;
        
        GenerateSpecialMenuItems();
    }

    public void AddMenuItem(MenuItem item)
    {
        //  throw new ApplicationException($"Conflicting menu shortcut {item.ShortCut.ToUpper()}");
        MenuItems.Add(item);
    }

    public void AddMenuItems(List<MenuItem> items)
    {
        foreach (var item in items)
        {
            AddMenuItem(item);
        }
    }

    private void GenerateSpecialMenuItems()
    {
        if (MenuLevel == EMenuLevel.Second)
        {
            SpecialMenuItems.Add(new MenuItem("B", "Back", null));    
        } else if (MenuLevel == EMenuLevel.More)
        {
            SpecialMenuItems.Add(new MenuItem("B", "Back", null));    
            SpecialMenuItems.Add(new MenuItem("M", "Main menu", null));    
        }
        SpecialMenuItems.Add(new MenuItem("E", "Exit", null));
    }
    
    public string Run()
    {
        string? playerInput = "";
        MenuItem selectedMenuItem = new MenuItem();
        Func<string>? runItem = null;
        do
        {
            Console.Clear();
            Console.WriteLine(MenuSeparator);
            Console.WriteLine(Title);
            Console.WriteLine(MenuSeparator);
            foreach (var item in MenuItems)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            foreach (var item in SpecialMenuItems)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(MenuSeparator);
            
            Console.Write("Your choice: ");
            playerInput = Console.ReadLine()?.ToUpper() ?? "";
            if (ListContains(MenuItems, playerInput))
            {
                selectedMenuItem = GetMenuItem(MenuItems, playerInput);
                runItem = selectedMenuItem.MethodToRun;
                if (runItem != null)
                {
                    playerInput = runItem();
                    if (playerInput == "B" || (playerInput == "M" && MenuLevel == EMenuLevel.First))
                    {
                        playerInput = "";
                    }
                }
            }
        } while (!ReservedShortcuts.Contains(playerInput));
        return playerInput;
    }

    public bool ListContains(List<MenuItem> items, string shortcut)
    {
        bool isFound = false;
        foreach (var item in items)
        {
            if (item.Shortcut.Equals(shortcut))
            {
                isFound = true;
                break;
            }
        }
        return isFound;
    }
    
    public MenuItem GetMenuItem(List<MenuItem> items, string shortcut)
    {
        MenuItem foundItem = new MenuItem();
        foreach (var item in items)
        {
            if (item.Shortcut.Equals(shortcut))
            {
                foundItem = item;
                break;
            }
        }
        return foundItem;
    }
}