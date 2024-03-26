# Adventure game

The purpoise of this document is to outline the design of the game, but won't touch on the technical implementation. This is all subject to change! Some inspirations could be taken from an older game, like Rogue: https://en.wikipedia.org/wiki/Rogue_(video_game)

## Contents
- General description
- Scenes
  - Main menu
  - Credits
  - Load Game
  - Save Game
  - New Game (Character creation)
    - Choose hero race
    - Choose hero class
    - Name the hero
  - Main scene
  - Combat
  - Inventory

## General description

Jump into the world of ASCII and terminal to enjoy a simple adventure! Take on a role of a hero to explore dungeons, help viligers with diferent tasks and level up to be the strongest adventurer in your guild!

## Scenes

The text adventure game contains different scenes, each with it's own purpoise. 

Scenes will contain ASCII art, which comes with a limitation _ASCII art doesn't scale_. Keep in mind that there should be a minimum width of the terminal screen for the game to be playable.

Each scene that is not `Main menu` should include `[0] Go Back to Main Menu` item.

### Main menu

The first thing a player will see when opening the game is main menu, the menu ofers these options[^1] :
```
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
[1] New Game
[2] Load Game
[3] Credits
[4] Exit

[9] Save Game
[0] Continue

Write [N] number of the menu item to proceed and press ENTER
|
```
[^1]: The ASCII dragon art is taken from: https://www.asciiart.eu/mythology/dragons

The end-user will type the number of the menu item, for example, `3` to go to `Credits` scene.

The `[0] Continue` and `[9] Save Game` items are only visible if the player is currently in an active game.

### Credits

When entering credits scene it will show the following[^2] :
```
                     [ CREDITS ]

This is an OPEN SOURCE game project made by NerdSpace community, you can reach out to us by visiting our homepage [insert homepage link]!

Thank you everyone who participated in making this game:
    Name 1
    Name 2
    Name 3
    ...
    Name n

[0] Go Back to Main Menu

Write [N] number of the menu item to proceed and press ENTER
|
```
[^2]: The Credits scene should be updated every time someone contributes to the project before we do a build

### Load Game
```
                     [ LOAD GAME ]
[1] My save (Fri, Sep 13, 2024, 13:13)
[2] cxd (Fri, Sep 13, 2024, 12:30)
[3] dddd (Fri, Sep 13, 2024, 11:11)
[4] first adventure yay (Fri, Sep 13, 2024, 10:36)
[5] love this game (Fri, Sep 13, 2024, 09:42)

[0] Go Back to Main Menu

Write [N] number of the menu item to proceed and press ENTER
|
```

### Save Game

```
                     [ SAVE GAME ]

                 Name your saved game!

[0] Go Back

Write the name of your save and press ENTER
or
Write [N] number of the menu item to proceed and press ENTER
|
```

### New Game (Character creation)

The "New Game" scene actually contains X scenes, and is implemented in a "setup wizard" format.

#### Choose hero race
```
[ COOSE HERO CLASS ]
[1] Human
[2] Elf
[3] Dwarf

[0] Go Back

Write [N] number of the menu item to proceed and press ENTER
|
```

#### Choose hero class
```
[ COOSE HERO CLASS ]
[1] Archer
[2] Warrior
[3] Mage

[0] Go Back

Write [N] number of the menu item to proceed and press ENTER
|
```

#### Choose hero name
```
[ COOSE HERO NAME ]

[0] Go Back

Enter your Heroe's name to start the game
OR
Write [N] number of the menu item to proceed and press ENTER
|
```

### Main scene

Main scene is where all the game happens, where the player can move, encounter enemies or NPCs.

#### Map
In this scene player can move around to try and complete their quests. [^3]
```

aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa   a
8   8               8               8           8                   8   8
8   8   aaaaaaaaa   8   aaaaa   aaaa8aaaa   aaaa8   aaaaa   aaaaa   8   8
8               8       8   8           8           8   8   8       8   8
8aaaaaaaa   a   8aaaaaaa8   8aaaaaaaa   8aaaa   a   8   8   8aaaaaaa8   8
8       8   8               8           8   8   8   8   8           8   8
8   a   8aaa8aaaaaaaa   a   8   aaaaaaaa8   8aaa8   8   8aaaaaaaa   8   8
8   8               8   8   8       8           8           8       8   8
8   8aaaaaaaaaaaa   8aaa8   8aaaa   8   aaaaa   8aaaaaaaa   8   aaaa8   8
8           8       8   8       8   8       8           8   8           8
8   aaaaa   8aaaa   8   8aaaa   8   8aaaaaaa8   a   a   8   8aaaaaaaaaaa8
8       8       8   8   8       8       8       8   8   8       8       8
8aaaaaaa8aaaa   8   8   8   aaaa8aaaa   8   aaaa8   8   8aaaa   8aaaa   8
8           8   8           8       8   8       8   8       8           8
8   aaaaa   8   8aaaaaaaa   8aaaa   8   8aaaa   8aaa8   aaaa8aaaaaaaa   8
8   8       8           8           8       8   8   8               8   8
8   8   aaaa8aaaa   a   8aaaa   aaaa8aaaa   8   8   8aaaaaaaaaaaa   8   8
8   8           8   8   8   8   8           8               8   8       8
8   8aaaaaaaa   8   8   8   8aaa8   8aaaaaaa8   aaaaaaaaa   8   8aaaaaaa8
8   8       8   8   8           8           8   8       8               8
8   8   aaaa8   8aaa8   aaaaa   8aaaaaaaa   8aaa8   a   8aaaaaaaa   a   8
8   8                   8           8               8               8   8
8 © 8aaaaaaaaaaaaaaaaaaa8aaaaaaaaaaa8aaaaaaaaaaaaaaa8aaaaaaaaaaaaaaa8aaa8

-------------------------------------------------------------------------
Hero: [name]    HP: 10/10    ATK: 5    DEF: 5    GOLD: 150    LVL: 1
-------------------------------------------------------------------------

[MENU]
[9] Access inventory
[0] Main menu

Enter a command
OR
Write [N] number of the menu item to proceed and press ENTER
|
```
[^3]: Maze ASCII art taken from: https://ascii.co.uk/art/maze

The hero location is indicated by `©` character. Player can type a command like `GO NORTH`, `GO EAST`, `GO WEST` or `GO SOUTH` to move.

#### Combat
Combat is turn based. 1st it's the player's turn, 2nd is the enemy turn - it goes on like that until one falls. [^4]

```
-------------------------------------------------------------------------
Enemy: Rat    HP: 10/10    ATK: 5    DEF: 5    GOLD: 1    LVL: 1
-------------------------------------------------------------------------

                       ,     .
                       (\,;,/)
                        (o o)\//,
                         \ /     \,
                         `+'(  (   \    )
                            //  \   |_./
                          '~' '~----'              

-------------------------------------------------------------------------
Hero: [name]    HP: 10/10    ATK: 5    DEF: 5    GOLD: 150    LVL: 1
-------------------------------------------------------------------------

[MENU]
[9] Access inventory
[0] Main menu

Enter a command
OR
Write [N] number of the menu item to proceed and press ENTER
|
```
[^4]: Rat ASCII art taken from: https://ascii.co.uk/art/rat

In the `Combat` scene the player can issue a comand like `ATTACK` or `RUN`.

#### Inventory
```
-------------------------------------------------------------------------
Hero: [name]    HP: 10/10    ATK: 5    DEF: 5    GOLD: 150    LVL: 1
-------------------------------------------------------------------------

[1] Health Potion (2)
[2] Mushroom (3)
[3] Bread
[4] Excalibur (Equiped)
[5] Wooden shield (Equiped)

[MENU]
[0] Go back

Write [N] number of the menu item to proceed and press ENTER
|
```