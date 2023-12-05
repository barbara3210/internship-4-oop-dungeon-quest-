using DungeonCrawler.Domain.repositories;
using DungeonCrawler.Domain.repositories.Monsters;
using DungeonCrawler.Domain.repositories.Heroes;
using System.Text;
using System.Threading;
using System.Runtime.CompilerServices;

Intro();

bool quit=false;

while (!quit)
{
    //START
    Console.WriteLine("PRESS TO PLAY \n" +
        "PRESS X - BREAK");

    var playInput=Console.ReadLine();
    if (playInput.ToLower() == "x")
    {
        break;
    }
    Console.Clear();
    
    int choice = GetValidNumber("Choose your hero:\n" +
        "1 - Gladiator (HP:100  D:20 )\n" + 
        "2 - Enchater (HP:30  D:80 )\n"+
        "3 - Marksman (HP:60  D:45 )");

    switch (choice)
    {
        case 1:
            GladiatorChoice();
            break;
        case 2:
            EnchaterChoice();
            break;
        case 3:
            MarksmanChoice();
            break;
        default:
            RetryOrQuit();
            break;
    }

}


static void Intro()
{
    Console.WriteLine("Welcome to Dungeon Quest!\n");
    Console.WriteLine("Embark on a thrilling dungeon-crawling adventure \n" +
        "with our new game, \"Dungeon Quest\"! \n" +
        "\nThe fate of your hero lies in your hands as you navigate \n" +
        "through 10 randomly generated monster battles, each presenting \n" +
        "unique challenges and rewards.\n");
    Console.WriteLine("LET'S PLAY!\n");

}
//USER INPUTS
static int GetValidNumber(string message)
{
    int value;
    do
    {
        Console.WriteLine(message);
        var input = int.TryParse(Console.ReadLine(), out value);
        if (!input || value<1)
        {
            Console.WriteLine("Try again");
        }
        else
        {
            break;
        }
    } while (true);
    return value;
}
static string CheckYN(string message)
{
    char [] yn = { 'y', 'n' };
    do
    {
        Console.WriteLine(message);
        var input = char.TryParse(Console.ReadLine().ToLower(),out char answer);
        if (input && yn.Contains(answer))
        {
            return answer == 'y' ? "yes" : "no";
        }
        else
        {
            Console.WriteLine("Try again (Y/N)");
        }
    } while (true);
    
}



//GAME
static void StartGame(Hero hero)
{
    Console.WriteLine("Press key to start...");
    Console.ReadLine();
    Console.Clear();

    Monster[] monsters = TenNewMonsters();
    GameDisplay(monsters,hero);
    Play(monsters,hero);

}

static Dictionary<int, string> DefineMoves()
{
    Dictionary<int, string> moves = new Dictionary<int, string>();
    moves.Add(1,"CounterAttack");
    moves.Add(2, "DirectAttack");
    moves.Add(3, "SideAttack");

    return moves;
}
static void PrintMoves(Dictionary<int, string> moves)
{
    foreach (KeyValuePair<int, string> element in moves)
    {
        Console.WriteLine($"{element.Key} - {element.Value}");
    }
}
static void Play(Monster[]monsters, Hero hero)
{
    
    Dictionary<int , string> moves = DefineMoves();
    Console.WriteLine();
    
    int choice;
    int r=1;
    foreach(Monster monster in monsters)
    {

        r += 1;

        while(true)
        {
            Console.Clear();
            Console.WriteLine("=============================");
            Console.WriteLine($"{hero.GetType().Name} VS. {monster.GetType().Name}");
            Console.WriteLine($"Round: {r}");
            Console.WriteLine("=============================\n");
            PrintMoves(moves);

            choice = GenerateHeroMove(moves);
            string selectedMove = moves[choice];
            Console.WriteLine($"You: {selectedMove}");

            int monsterMove = GenerateMonsterMove();
            string selectedMonsterMove = moves[monsterMove];
            Console.WriteLine($"Monster: {selectedMonsterMove}\n");

            Round round = new Round(selectedMove, selectedMonsterMove,r);
            GameOutcome(monster, hero, round, monsters);

            string quitInput = CheckYN("Do you want to quit? Y/N");
            if (quitInput == "yes")
            {
                Console.Clear();
                return;
            }
            Console.WriteLine("Round continues...\n");
            GameDisplay(monsters, hero);
            Console.WriteLine("\nPress key to proceed to the next round...");
            Console.ReadKey();
        }
        

    }



}

static int GenerateMonsterMove()
{
    Random random = new Random();
    return random.Next(1, 4);
}
static int GenerateHeroMove(Dictionary<int, string> moves)
{
    int choice;
    do
    {
        choice = GetValidNumber("\nChoose your move: ");
        if (!moves.ContainsKey(choice))
        {
            Console.WriteLine("Try again (1/2/3)");
        }
    } while (!moves.ContainsKey(choice));
    return choice;
}
static void GameOutcome(Monster monster, Hero hero, Round round, Monster[]monsters)
{
    bool heroWon = round.HeroWins(hero, monster);

    if (monster.GetType() == typeof(Witch))
    {
        Witch witch = (Witch)monster;
        if (witch.DjumbusAttack)
            witch.DjumbusMonsters(monsters);
    }
    if (heroWon)
    {
        hero.LevelUp();
        
    }
    else if (hero.IsDefeated())
    {
        GameOver(hero);
        
    }
    
}


//HERO CHOICE
static void GladiatorChoice()
{
    
    Gladiator gladiator = new Gladiator("Player1", 100, 20, 0);
    CreateHero(gladiator);
    Console.Clear();
    StartGame(gladiator);
    


}

static void EnchaterChoice()
{
   
    Enchater enchater = new Enchater("Player1", 30, 80, 0);
    CreateHero(enchater);
    Console.Clear();
    StartGame(enchater);

}
static void MarksmanChoice()
{
    Marksman marksman = new Marksman("Player1", 60, 45, 0);
    CreateHero(marksman);
    Console.Clear();
    StartGame(marksman);


}

//CREATE AND PRINT
static void CreateHero(Hero hero)
{
    Console.Clear();

    int input = GetValidNumber("1 - set up your hero\n" +
        "2 - generate your hero");

    if (input==1)
    {
        string name;
        while (true)
        {
            Console.WriteLine("Hero name: ");
            var inputName = Console.ReadLine();

            if (string.IsNullOrEmpty(inputName))
            {
                Console.WriteLine("Name cannot be empty");
            }
            else
            {
                name = inputName;
                break;
            }
        }
        hero.Player = name;

        int hp = GetValidNumber("Input Health Points: ");
        hero.HealthPoints = hp;

        int damage = GetValidNumber("Input Damage Points: ");
        hero.Damage = damage;

    }
    else if(input == 2)
    {
        Console.WriteLine($"Hero: {hero.GetType().Name} - Damage: {hero.Damage} - HP: {hero.HealthPoints} - XP: {hero.Experience}\n");
    }
    else
    {
        Console.WriteLine("We are generating your hero...");
    }

}
static Monster[] TenNewMonsters()
{
    Random random = new Random();
    Monster[] monsters = new Monster[10];

    for (int i = 0; i < 10; i++)
    {
        
        double randomDouble = random.NextDouble();
        int randomHP = random.Next(30, 101);
        int randomDamage = random.Next(1, 81);
        int randomXP = random.Next(20, 81);

        if (randomDouble < 0.6)
        {
            monsters[i] = new Goblin(randomHP, randomDamage, randomXP,false);
        }
        else if (randomDouble > 0.7)
        {
            monsters[i] = new Brute(randomHP, randomDamage, randomXP,false);
        }
        else if (randomDouble < 0.7 && random.NextDouble() > 0.6)
        {
            monsters[i] = new Witch(randomHP, randomDamage, randomXP, false);
        }
    }


    return monsters;
}
static void PrintAllMonsters(Monster[] monsters)
{
    Console.WriteLine("MONSTERS:");
    for (int i = 0; i < monsters.Length; i++)
    {
        if (monsters[i] != null)
        {
            Console.WriteLine($"{monsters[i].GetType().Name} - Damage: {monsters[i].Damage} - Health: {monsters[i].HealthPoints}");
        }
    }
}
static void PrintHeroStat(Hero hero)
{
    Console.WriteLine("YOUR HERO:");
    Console.WriteLine($"{hero.GetType().Name} - Damage: {hero.Damage} - HP: {hero.HealthPoints} - XP: {hero.Experience}");

}

//GAME STATICS
static void GameDisplay(Monster[] monsters,Hero hero)
{
    Console.WriteLine("Current game state:\n");
    PrintHeroStat(hero);
    PrintAllMonsters(monsters);
    

}

static void GameOver(Hero hero)
{
    Console.Clear();
    Console.WriteLine("--GAME OVER--");
    PrintHeroStat(hero);

    

}
static void RetryOrQuit()
{
    string retry = CheckYN("Do you want to try again? Y/N");
    if (retry == "yes")
    {
        Console.Clear();
    }
    else
    {
        return;
    }
}
