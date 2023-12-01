using DungeonCrawler.Domain.repositories;
using System.Xml.Serialization;

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

string UserName()
{
    string name;
    do
    {
        Console.WriteLine("Name: ");
        name = Console.ReadLine();

    } while (name == null);
    return name;
}
void PrintHeroMenu()
{
    Console.WriteLine("Choose your hero:");
    Console.WriteLine("1 - Gladiator (HP:100  D:20 )\n" +
        "2 - Enchater (HP:30  D:80 )\n" +
        "3 - Marksman (HP:60  D:45 )");
}
int UserInput()
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


while (true)
{
    string playerName=UserName();
    PrintHeroMenu();
    int choice = UserInput();

    switch (choice)
    {
        case 0:
        case 1:
        case 2:
        case 3:
        default:
            break;
    }




}