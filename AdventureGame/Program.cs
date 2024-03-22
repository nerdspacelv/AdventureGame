public class Program
{
    public static void Main(string[] args)
    {
        MainMenu();
    }

    static void MainMenu()
    {
        string menuArt = @"
                                                       ____________
                                 (`-..________....---''  ____..._.-`
                                  \\`._______.._,.---'''     ,'
                                  ; )`.      __..-'`-.      /
                                 / /     _.-' _,.;;._ `-._,'
                                / /   ,-' _.-'  //   ``--._``._
                              ,','_.-' ,-' _.- (( =-    -. `-._`-._____
                            ,;.''__..-'   _..--.\\.--'````--.._``-.`-._`.
             _          |\,' .-''        ```-'`---'`-...__,._  ``-.`-.`-.`.
  _     _.-,'(__)\__)\-'' `     ___  .          `     \      `--._
,',)---' /|)          `     `      ``-.   `     /     /     `     `-.
\_____--.  '`  `               __..-.  \     . (   < _...-----..._   `.
 \_,--..__. \\ .-`.\----'';``,..-.__ \  \      ,`_. `.,-'`--'`---''`.  )
           `.\`.\  `_.-..' ,'   _,-..'  /..,-''(, ,' ; ( _______`___..'__
                   ((,(,__(    ((,(,__,'  ``'-- `'`.(\  `.,..______   __
                                                      ``--------..._``--.__
        ";
        Console.WriteLine(menuArt);
        Console.WriteLine("Welcome to Your Game!");
        Console.WriteLine("1. New Game");
        Console.WriteLine("2. Load Game");
        Console.WriteLine("3. Exit");
        Console.Write("Enter your choice: ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                NewGame();
                break;
            case "2":
                LoadGame();
                break;
            case "3":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                MainMenu();
                break;
        }
    }

    static void NewGame()
    {
        Console.WriteLine("Starting a New Game...");
        // TODO: Add game logic here
        Console.WriteLine("New Game created!");
    }

    static void LoadGame()
    {
        Console.WriteLine("Loading Game...");
        // TODO: Add game loading logic here
        Console.WriteLine("Game Loaded!");
    }

    static void SaveGame(string gameData)
    {
        // TODO: Add game saving logic here

        //string saveDirectory = "./SavedGames";
        //if (!Directory.Exists(saveDirectory))
        //{
        //    Directory.CreateDirectory(saveDirectory);
        //}

        //string saveFileName = $"Save_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
        //string saveFilePath = Path.Combine(saveDirectory, saveFileName);
        //File.WriteAllText(saveFilePath, gameData);
        //Console.WriteLine($"Game saved successfully as {saveFileName}");
    }
}