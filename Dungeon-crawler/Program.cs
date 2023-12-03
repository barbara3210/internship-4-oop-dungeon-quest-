using DungeonCrawler.Domain.repositories;
using DungeonCrawler.Domain.repositories.Monsters;
using DungeonCrawler.Domain.repositories.Heroes;
using System.Xml.Serialization;

Intro();
while (true)
{
    string playerName = UserName();
    Round round = new Round();

    Console.WriteLine("Choose your hero:");
    Console.WriteLine("1 - Gladiator (HP:100  D:20 )\n" +
        "2 - Enchater (HP:30  D:80 )\n" +
        "3 - Marksman (HP:60  D:45 )");
    int choice = UserInputHero();
    if (choice == 0)
        break;

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
            break;
    }
}


static void Intro()
{
    Console.WriteLine("Welcome to Dungeon Quest!\n");
    Console.WriteLine("Embark on a thrilling dungeon-crawling adventure \n" +
        "with our new game, \"Dungeon Quest\"! \n" +
        "Create your own hero and traverse through a \n" +
        "mysterious castle filled with formidable monsters, \n" +
        "challenging battles, and exciting strategic encounters. \n" +
        "\nThe fate of your hero lies in your hands as you navigate \n" +
        "through 10 randomly generated monster battles, each presenting \n" +
        "unique challenges and rewards.\n");
    Console.WriteLine("LET'S PLAY!\n");

}
//USER INPUTS
string UserName()
{
    string name;
    do
    {
        Console.WriteLine("Player name: ");
        name = Console.ReadLine();

    } while (name == null);
    return name;
}
int UserInputHero()
{
    int choice;
    do
    {
        Console.WriteLine("Your hero: ");
        var c = Console.ReadLine();
        if (int.TryParse(c, out choice))
            break;
        Console.WriteLine("Try again");
    } while (true);
    return choice;
}

//HERO CHOICE
static void GladiatorChoice()
{
    Monster[] monsters=TenNewMonsters();

    PrintAllMonsters(monsters);


}

static void EnchaterChoice()
{
    Monster[] monsters = TenNewMonsters();


}
static void MarksmanChoice()
{
    Monster[] monsters = TenNewMonsters();


}

//MONSTERS
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
            monsters[i] = new Goblin(randomHP, randomDamage, randomXP);
        }
        else if (randomDouble > 0.7)
        {
            monsters[i] = new Brute(randomHP, randomDamage, randomXP);
        }
        else if (randomDouble < 0.7 && random.NextDouble() > 0.6)
        {
            monsters[i] = new Witch(randomHP, randomDamage, randomXP);
        }
    }


    return monsters;
}
static void PrintAllMonsters(Monster[] monsters)
{
    Console.WriteLine("MONSTERS:");
    foreach (Monster m in monsters)
    {
        Console.WriteLine($"{m.GetType().Name} - Damage: {m.Damage}");
    }
}