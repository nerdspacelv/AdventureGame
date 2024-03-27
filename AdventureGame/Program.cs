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


    static char[,] maze = {
        { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' , '#' , '#' , '#', '#' , '#' , '#' , '#' , '#' , '#', '#' , '#' , '#', '#' },
        { '#', ' ', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', ' ', ' ', ' ', '#', ' ', '#', '#' , '#' , '#' , '#', '#' , '#' , '#' , '#' , '#' , '#', '#' , '#' , '#', '#' },
        { '#', ' ', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', ' ', '#', ' ', '#', ' ', '#', '#' , '#' , '#' , '#', '#' , '#' , '#' , '#' , '#' , '#', '#' , '#' , '#', '#' },
        { '#', ' ', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', ' ', '#', ' ', '#', ' ', '#', '#' , '#' , '#' , '#', '#' , '#' , '#' , '#' , '#' , '#', '#' , '#' , '#', '#' },
        { '#', ' ', '#', '#', '#', '#', ' ', '#', '#', '#', '#', '#', ' ', '#', ' ', '#', ' ', '#', '#' , '#' , '#' , '#', '#' , '#' , '#' , '#' , '#' , '#', '#' , '#' , '#', '#' },
        { '#', ' ', '#', '#', ' ', ' ', ' ', '#', '#', '#', '#', '#', ' ', '#', ' ', ' ', ' ', '#', '#' , '#' , '#' , '#', '#' , '#' , '#' , '#' , '#' , '#', '#' , '#' , '#', '#' },
        { '#', ' ', '#', '#', ' ', '#', '#', '#', '#', '#', '#', '#', ' ', '#', '#', '#', '#', '#', '#' , '#' , '#' , '#', '#' , '#' , '#' , '#' , '#' , '#', '#' , '#' , '#', '#' },
        { '#', ' ', '#', '#', ' ', '#', '#', '#', '#', '#', '#', '#', ' ', '#', '#', '#', '#', '#', '#' , '#' , '#' , '#', '#' , '#' , '#' , '#' , '#' , '#', '#' , '#' , '#', '#' },
        { '#', ' ', '#', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', '#', '#', '#', '#', '#' , '#' , '#' , '#', '#' , '#' , '#' , '#' , '#' , '#', '#' , '#' , '#', '#' },
        { '#', ' ', '&', ' ', ' ', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' , '#' , '#' , '#', '#' , '#' , '#' , '#' , '#' , '#', '#' , '#' , '#', '#' },
        { '#', ' ', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' , '#' , '#' , '#', '#' , '#' , '#' , '#' , '#' , '#', '#' , '#' , '#', '#' },
        { '#', ' ', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' , '#' , '#' , '#', '#' , '#' , '#' , '#' , '#' , '#', '#' , '#' , '#', '#' },
        { '#', ' ', ' ', ' ', ' ', '*', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' , '#' , '#' , '#', '#' , '#' , '#' , '#' , '#' , '#', '#' , '#' , '#', '#' },
        { '#', ' ', '#', '#', '#', ' ', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' , '#' , '#' , '#', '#' , '#' , '#' , '#' , '#' , '#', '#' , '#' , '#', '#' },
        };

    static int playerX = 1;
    static int playerY = 13;

    static void Game()
    {
        while (true)
        {
            Console.Clear();
            DrawMaze();
            MovePlayer(Console.ReadKey(true).Key);
        }
    }

    static void DrawMaze()
    {
        for (int i = 0; i < maze.GetLength(0); i++)
        {
            for (int j = 0; j < maze.GetLength(1); j++)
            {
                char ch = maze[i, j];

                if (i == playerY && j == playerX)
                {
                    ch = '@';
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (ch == '&') // '& represents an enemy
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (ch == '#') // '#' represents a wall
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else if (ch == '*') // '*' represents a door
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }

                Console.Write(ch);
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }

    static void MovePlayer(ConsoleKey key)
    {
        int newX = playerX;
        int newY = playerY;

        switch (key)
        {
            case ConsoleKey.UpArrow:
                newY--;
                break;
            case ConsoleKey.DownArrow:
                newY++;
                break;
            case ConsoleKey.LeftArrow:
                newX--;
                break;
            case ConsoleKey.RightArrow:
                newX++;
                break;
            case ConsoleKey.Q:
                Environment.Exit(0);
                break;
        }

        if (maze[newY, newX] == ' ')
        {
            playerX = newX;
            playerY = newY;
        }
    }


    static void NewGame()
    {
        Game();
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