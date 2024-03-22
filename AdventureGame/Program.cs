public class Program
{
    public static void Main(string[] args)
    {
        Room room1 = new Room("Room 1", "You are in Room 1. There is a door to the east.");
        Room room2 = new Room("Room 2", "You are in Room 2. There are doors to the west and east.");
        Room room3 = new Room("Room 3", "You are in Room 3. There is a door to the west.");
        Room room4 = new Room("Room 4", "You are in Room 4. There is a door to the west.");
        Room room5 = new Room("Room 5", "You are in Room 5. There is a wall to the west.");

        room1.EastRoom = room2;
        room2.WestRoom = room1;
        room2.EastRoom = room3;
        room3.WestRoom = room2;

        // test

        Player player = new Player(room1);


        // menu 

        Console.WriteLine("Welcome to the game");
        Console.WriteLine("Type 'go east' to go east");
        Console.WriteLine("Type 'go west' to go west");
        

        while (true)
        {
            Console.WriteLine(player.CurrentRoom.Description);

            string command = Console.ReadLine();

            if (command == "go east")
            {
                if (player.CurrentRoom.EastRoom != null)
                {
                    player.CurrentRoom = player.CurrentRoom.EastRoom;
                }
                else
                {
                    Console.WriteLine("You can't go that way.");
                }
            }
            else if (command == "go west")
            {
                if (player.CurrentRoom.WestRoom != null)
                {
                    player.CurrentRoom = player.CurrentRoom.WestRoom;
                }
                else
                {
                    Console.WriteLine("You can't go that way.");
                }
            }
            else
            {
                Console.WriteLine("Invalid command.");
            }
        }
    }
}

public class Room
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Room EastRoom { get; set; }
    public Room WestRoom { get; set; }

    public Room(string name, string description)
    {
        Name = name;
        Description = description;
    }
}

public class Player
{
    public Room CurrentRoom { get; set; }

    public Player(Room currentRoom)
    {
        CurrentRoom = currentRoom;
    }
}