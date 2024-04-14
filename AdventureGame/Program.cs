using System.Security.Cryptography.X509Certificates;

public class Program
{
    // Hero details
    static string heroName = "Jānis";
    static int initialHealth = 10;
    static int initialAttack = 5;
    static int initialDefense = 5;
    static int initialGold = 150;
    static int initialLevel = 1;

    static void Main(string[] args)
    {
        MainMenu();
    }

    static void MainMenu()
    {
        string menuArt = @"
                 ___====-_  _-====___
           _--^^^#####//      \\#####^^^--_
        _-^##########// (    ) \\##########^-_
       -############//  |\^^/|  \\############-
     _/############//   (@::@)   \\############\_
    /#############((     \\//     ))#############\
   -###############\\    (oo)    //###############-
  -#################\\  / VV \  //#################-
 -###################\\/      \//###################-
_#/|##########/\######(   /\   )######/\##########|\#_
|/ |#/\#/\#/\/  \#/\##\  |  |  /##/\#/  \/\#/\#/\#| \|
`  |/  V  V  `   V  \#\| |  | |/#/  V   '  V  V  \|  '
   `   `  `      `   / | |  | | \   '      '  '   '
                    (  | |  | |  )
                   __\ | |  | | /__
                  (vvv(VVV)(VVV)vvv)
                    
                  [ ADVENTURE GAME ]
        ";
        Console.WriteLine(menuArt);
        Console.WriteLine("[1] New Game");
        Console.WriteLine("[2] Load Game");
        Console.WriteLine("[3] Credits");
        Console.WriteLine("[4] Exit");
        Console.WriteLine("");
        Console.WriteLine("[9] Save Game");
        Console.WriteLine("[0] Continue");
        Console.WriteLine("");
        Console.WriteLine("Write [N] number of the menu item to proceed and press ENTER");

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
                // Credits
                break;
            case "4":
                Environment.Exit(0);
                break;
            case "9":
                //SaveGame("gameData");
                break;
            case "0":
                Game();
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                MainMenu();
                break;
        }
    }

    static char[,] maze = {
        { 'a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a','a',' ','a'},
        { '8',' ','8',' ',' ',' ',' ',' ',' ',' ',' ','8',' ',' ',' ',' ',' ',' ',' ',' ','8',' ',' ',' ',' ',' ','8',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','8',' ','8'},
        { '8',' ','8',' ','a','a','a','a','a','a',' ','8',' ','a','a','a',' ','a','a','a','8','a','a',' ','a','a','8',' ','a','a','a',' ','a','a','a','a',' ',' ','8',' ','8'},
        { '8',' ',' ',' ',' ',' ',' ',' ','8',' ',' ',' ',' ','8',' ','8',' ',' ',' ',' ',' ',' ','8',' ',' ',' ',' ',' ','8',' ','8',' ',' ',' ',' ',' ',' ',' ','8',' ','8'},
        { '8','a','a','a','a',' ','a',' ','8','a','a','a','a','8',' ','8','a','a','a','a','a',' ','a','8','a','a','a',' ','8',' ','8',' ','a','a','a','a','a','a','8',' ','8'},
        { '8',' ',' ',' ','8',' ','8',' ',' ',' ',' ',' ',' ',' ',' ','8',' ',' ',' ',' ',' ',' ','8',' ','8',' ','8',' ','8',' ','8',' ',' ',' ',' ',' ',' ',' ','8',' ','8'},
        { '8',' ','a',' ','8','a','8','a','a','a','a','a',' ','a',' ','8',' ','a','a','a','a','a','8',' ','8','a','8',' ',' ',' ','8','a','a','a','a','a','a',' ','8',' ','8'},
        { '8',' ','8',' ',' ',' ',' ',' ',' ',' ',' ','8',' ','8',' ','8',' ',' ',' ',' ','8',' ',' ',' ',' ',' ',' ','8',' ',' ',' ',' ',' ','8',' ',' ',' ',' ','8',' ','8'},
        { '8',' ','8','a','a','a','a','a','a','a',' ','8','a','8',' ','8','a','a','a',' ','8',' ','a','a','a','a',' ','8','a','a','a','a',' ','8',' ','a','a','a','8',' ','8'},
        { '8',' ',' ',' ',' ',' ','8',' ',' ',' ',' ','8',' ','8',' ',' ',' ',' ','8',' ','8',' ',' ',' ',' ','8',' ',' ',' ',' ',' ','8',' ','8',' ',' ',' ',' ',' ',' ','8'},
        { '8',' ','a','a','a',' ','8','a','a','a',' ','8',' ','8','a','a','a',' ','8',' ','8','a','a','a','a','8',' ','a',' ','a',' ','8',' ','8','a','a','a','a','a','a','8'},
        { '8',' ',' ',' ','8',' ',' ',' ',' ','8',' ','8',' ','8',' ',' ',' ',' ','8',' ',' ',' ','8',' ',' ',' ',' ','8',' ','8',' ','8',' ',' ',' ',' ','8',' ',' ',' ','8'},
        { '8','a','a','a','8','a','a','a',' ','8',' ','8',' ','8',' ',' ','a','a','8','a','a',' ','8',' ','a','a','a','8',' ','8',' ','8','a','a','a',' ','8','a','a',' ','8'},
        { '8',' ',' ',' ',' ',' ',' ','8',' ','8',' ',' ',' ',' ',' ',' ','8',' ',' ',' ','8',' ','8',' ',' ',' ',' ','8',' ','8',' ',' ',' ',' ','8',' ',' ',' ',' ',' ','8'},
        { '8',' ','a','a','a','a',' ','8',' ','8','a','a','a','a','a',' ','8','a','a',' ','8',' ','8','a','a','a',' ','8','a','8',' ','a','a','a','8','a','a','a',' ',' ','8'},
        { '8',' ','8',' ',' ',' ',' ','8',' ',' ',' ',' ',' ',' ','8',' ',' ',' ',' ',' ','8',' ',' ',' ',' ','8',' ','8',' ','8',' ',' ',' ',' ',' ',' ',' ','8',' ',' ','8'},
        { '8',' ','8',' ','a','a','a','8','a','a','a',' ','a',' ','8','a','a',' ','a','a','8','a','a','a',' ','8',' ','8',' ','8','a','a','a','a','a','a',' ','8',' ',' ','8'},
        { '8',' ','8',' ',' ',' ',' ',' ',' ',' ','8',' ','8',' ','8',' ','8',' ','8',' ',' ',' ',' ',' ',' ','8',' ',' ',' ',' ',' ',' ',' ','8',' ','8',' ',' ',' ',' ','8'},
        { '8',' ','8','a','a','a','a','a','a',' ','8',' ','8',' ','8',' ','8','a','8',' ','8','a','a','a','a','8',' ','a','a','a','a','a',' ','8',' ','8','a','a','a','a','8'},
        { '8',' ','8',' ',' ',' ',' ',' ','8',' ','8',' ','8',' ',' ',' ',' ',' ','8',' ',' ',' ',' ',' ',' ','8',' ','8',' ',' ',' ','8',' ',' ',' ',' ',' ',' ',' ',' ','8'},
        { '8',' ','8',' ','a','a','a','a','8',' ','8','a','8',' ','a','a','a',' ','8','a','a','a','a','a',' ','8','a','8',' ','a',' ','8','a','a','a','a','a',' ','a',' ','8'},
        { '8',' ','8',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','8',' ',' ',' ',' ',' ','8',' ',' ',' ',' ',' ',' ',' ',' ','8',' ',' ',' ',' ',' ',' ',' ',' ','8',' ','8'},
        { '8',' ','8','a','a','a','a','a','a','a','a','a','a','a','8','a','a','a','a','a','8','a','a','a','a','a','a','a','a','8','a','a','a','a','a','a','a','a','8','a','8'}
        };

    static int playerX = 1;
    static int playerY = 23;

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
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
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
        Console.WriteLine("-------------------------------------------------------------------------");
        Console.WriteLine($"Hero: {heroName}    HP: {initialHealth}/10    ATK: {initialAttack}    DEF: {initialDefense}    GOLD: {initialGold}    LVL: {initialLevel}");
        Console.WriteLine("-------------------------------------------------------------------------");
        Console.WriteLine(" ");
        Console.WriteLine("[MENU]");
        Console.WriteLine("[9] Access inventory");
        Console.WriteLine("[0] Main menu");
        Console.WriteLine(" ");
        Console.WriteLine("Enter a command");
        Console.WriteLine("OR");
        Console.WriteLine("Write [N] number of the menu item to proceed and press ENTER");

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
