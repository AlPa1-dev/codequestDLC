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