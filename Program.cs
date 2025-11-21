Cousing System;
using System.ComponentModel.Design;
using System.Drawing;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        const string MenuTitle = "\n===== MAIN MENU - CODEQUEST =====";
        const string MenuOption1 = "1. Train your wizard";
        const string MenuOption2 = "2. Increase yout lvl";
        const string MenuOption3 = "3. Loot the mine";
        const string MenuOption4 = "4. Show inventory";
        const string MenuOption5 = "5. Buy items";
        const string MenuOption6 = "6. Show attacks by lvl";
        const string MenuOption7 = "7. Decode Ancient Scroll";
        const string MenuOptionExit = "0. Exit game";
        const string MenuPrompt = "Choose an option (1-3) - (0) to exit: ";
        const string MSG_ThxPlay = "Exiting, thanks for playing";
        const string InputErrorMessage = "Invalid input. Please enter a number between 0 and 3.";
        string nameMenu = "Welcome {0} with the title {1} and lvl {2}";

        int op = 0;
        bool validInput;
        Random rnd = new Random();
        string? saveName = null;
        string? saveTitle = null;
        bool hasTrained = false;
        int lvl = 1;
        //menu y bucle del joc
        do
        {
            Console.WriteLine(MenuTitle);
            if (hasTrained == true)
            {
                Console.WriteLine("\n" + nameMenu, saveName, saveTitle, lvl + "\n");
            }
            Console.WriteLine(MenuOption1);
            Console.WriteLine(MenuOption2);
            Console.WriteLine(MenuOption3);
            Console.WriteLine(MenuOption4);
            Console.WriteLine(MenuOption5);
            Console.WriteLine(MenuOption6);
            Console.WriteLine(MenuOption7);
            Console.WriteLine(MenuOptionExit);
            Console.Write(MenuPrompt);

            validInput = true;
            try
            {
                op = Convert.ToInt32(Console.ReadLine());

            }
            catch (FormatException)
            {
                Console.WriteLine(InputErrorMessage);
                validInput = false;
            }
            catch (Exception)
            {
                Console.WriteLine(InputErrorMessage);
                validInput = false;
            }

            if (validInput)
            {
                Console.WriteLine(op);
            }
            else
            {
                Console.WriteLine(InputErrorMessage);
                validInput = false;
            }
            // codi dels nivells
            if (validInput)
            {
                switch (op)
                {
                    // nivell 1 (train your wizard)
                    case 1:
                        const string NameMessage = "Enter a name for your wizard";
                        const string NameErrorMessage = "Invalid name, please enter a real one.";
                        const string NameErrorNull = "You have to type something";
                        string? wizardName;
                        validInput = true;
                        int Day;
                        long trained;
                        string title;
                        Day = 1;
                        trained = 0;
                        try
                        {
                            Console.WriteLine(NameMessage);
                            wizardName = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(wizardName))
                            {
                                Console.WriteLine(NameErrorNull);
                                if (!validInput)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                char capitalLetter = char.ToUpper(wizardName[0]);
                                string restName = wizardName.Substring(1).ToLower();
                                wizardName = string.Concat(capitalLetter, restName);
                                Console.WriteLine("Your Name: " + wizardName);
                                saveName = wizardName;
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine(NameErrorMessage);
                            validInput = false;
                        }
                        while (Day <= 5)
                        {
                            long NumHours = rnd.NextInt64(1, 25);
                            long Power = rnd.NextInt64(1, 11);
                            Console.WriteLine("today you have meditated: " + NumHours + "hours");
                            Console.WriteLine("you won: " + Power + " points today");
                            trained = trained + Power;
                            Console.WriteLine("In total you have: " + trained + " points");

                            Day++;
                        }
                        if (trained < 20)
                        {
                            Console.WriteLine("You have to repeat the second call");
                            title = "Raoden el Elantr ";
                            Console.WriteLine("Your title is: " + title);
                            saveTitle = title;
                        }
                        else if (trained >= 20 && trained <= 29)
                        {
                            Console.WriteLine("you confuse a wand with a spoon");
                            title = "Zyn el buguejat";
                            Console.WriteLine("Your title is: " + title);
                            saveTitle = title;
                        }
                        else if (trained >= 30 && trained < 35)
                        {
                            Console.WriteLine("Magic wind caster");
                            title = "Arka nullpointer";
                            Console.WriteLine("Your title is: " + title);
                            saveTitle = title;
                        }
                        else if (trained >= 35 && trained < 40)
                        {
                            Console.WriteLine("You can cast dragons without set the lab on fire");
                            title = "Elarion de les brases";
                            Console.WriteLine("Your title is: " + title);
                            saveTitle = title;
                        }
                        else if (trained >= 40)
                        {
                            Console.WriteLine("you are now an Arcane Master");
                            title = "ITB-Wizard el Gris";
                            Console.WriteLine("Your title is: " + title);
                            saveTitle = title;
                        }
                        hasTrained = true;
                        break;
                    //nivell 2 (increase lvl)
                    case 2:
                        const string SpawnMSG = "A wild {0} appears! Rolling dice to deteminate the outcome of the battle";
                        const string HP_MSG = "The {0} has {1} HP";
                        const string DamageMSG = "the monster takes damage";
                        const string RollAgain = "Press any key to roll again";
                        const string LvlUp = "LVL UP! Your actual level is {0}";
                        const string MaxLVL = "You are now at the max lvl (5), you can't kill more monsters";
                        const string numDice1 = """
    
                           ________
                          /       /|   
                         /_______/ |
                         |       | |
                         |   o   | /
                         |       |/ 
                         '-------'
                            
                        """;
                        const string numDice2 = """
                           ________
                          /       /|   
                         /_______/ |
                         |     o | |
                         |       | /
                         | o     |/ 
                         '-------'
                        
                        """;
                        const string numDice3 = """
                           ________
                          /       /|   
                         /_______/ |
                         |     o | |
                         |   o   | /
                         | o     |/ 
                         '-------'
                         
                        """;
                        const string numDice4 = """
                           ________
                          /       /|   
                         /_______/ |
                         | o   o | |
                         |       | /
                         | o   o |/ 
                         '-------'   
                         
                        """;
                        const string numDice5 = """
                           ________
                          /       /|   
                         /_______/ |
                         | o   o | |
                         |   o   | /
                         | o   o |/ 
                         '-------'   
                         
                        """;
                        const string numDice6 = """
                           ________
                          /       /|   
                         /_______/ |
                         | o   o | |
                         | o   o | /
                         | o   o |/ 
                         '-------'   
                         
                        """;
                        int Spawn = rnd.Next(0, 8);
                        string[] monsters = { "Wandering Skeleton 💀", "Forest Goblin 👹", "Green Slime 🟢", "Ember Wolf 🐺", "Giant Spider 🕷️", "Iron Golem 🤖", "Lost Necromancer 🧝‍♂️", "Ancient Dragon 🐉" };
                        int[] hp = { 3, 5, 10, 11, 18, 15, 20, 50 };
                        string realMonster = monsters[Spawn];
                        int realHp = hp[Spawn];

                        if (lvl < 5)
                        {
                            Console.WriteLine(SpawnMSG, realMonster);
                            while (realHp > 0)
                            {
                                Console.WriteLine(HP_MSG, realMonster, realHp);
                                int dice = rnd.Next(1, 7);
                                if (dice == 1)
                                {
                                    Console.WriteLine(numDice1);
                                    realHp = realHp - 1;
                                    Console.WriteLine(DamageMSG);
                                    Console.WriteLine(RollAgain);
                                }
                                else if (dice == 2)
                                {
                                    Console.WriteLine(numDice2);
                                    realHp = realHp - 2;
                                    Console.WriteLine(DamageMSG);
                                    Console.WriteLine(RollAgain);
                                }
                                else if (dice == 3)
                                {
                                    Console.WriteLine(numDice3);
                                    realHp = realHp - 3;
                                    Console.WriteLine(DamageMSG);
                                    Console.WriteLine(RollAgain);
                                }
                                else if (dice == 4)
                                {
                                    Console.WriteLine(numDice4);
                                    realHp = realHp - 4;
                                    Console.WriteLine(DamageMSG);
                                    Console.WriteLine(RollAgain);
                                }
                                else if (dice == 5)
                                {
                                    Console.WriteLine(numDice5);
                                    realHp = realHp - 5;
                                    Console.WriteLine(DamageMSG);
                                    Console.WriteLine(RollAgain);
                                }
                                else
                                {
                                    Console.WriteLine(numDice6);
                                    realHp = realHp - 6;
                                    Console.WriteLine(DamageMSG);
                                    Console.WriteLine(RollAgain);
                                }
                                if (realHp == 0 || realHp < 0)
                                {
                                    Console.WriteLine();
                                }
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.WriteLine(MaxLVL);
                        }

                        if (lvl < 5)
                        {
                            lvl = lvl + 1;
                            Console.WriteLine("\n" + LvlUp, lvl + "\n");
                        }
                        break;

                    case 3:

                        break;
                    case 4:

                        break;
                    case 5:

                        break;
                    case 6:

                        break;
                    case 7:

                        break;
                    case 0:
                        Console.WriteLine(MSG_ThxPlay);
                        break;
                }
            }
        } while (op != 0);

    }

}