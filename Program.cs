using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Drawing;
using System.Reflection.Emit;
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
        const string MenuPrompt = "Choose an option (1-7) - (0) to exit: ";
        const string MSG_ThxPlay = "Exiting, thanks for playing";
        const string InputErrorMessage = "Invalid input. Please enter a number between 0 and 7.";
        string nameMenu = "Welcome {0} with the title {1} and lvl {2}";

        int op = -1;
        bool validInput;
        Random rnd = new Random();
        string? saveName = null;
        string? saveTitle = null;
        bool hasTrained = false;
        int lvl = 1;
        int realBits = 0;
        string[] inventory = new string[0];
        bool decodedOne = false;
        bool decodedTwo = false;
        bool decodedThree = false;
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

            validInput = false;
            while (!validInput)
            {
                try
                {
                    op = Convert.ToInt32(Console.ReadLine());

                    if (op < 0 || op > 7)
                    {
                        Console.WriteLine(InputErrorMessage);
                    }
                    else
                    {
                        validInput = true;
                    }
                }
                catch
                {
                    Console.WriteLine("Error: you must enter a number");
                }
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
                        //control d'errors del nom
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
                        //bucle del entrenament
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
                        //Asignació del titol
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
                        //si arribes a nivell 5 no pots lluitar més
                        if (lvl < 5)
                        {
                            //bucle que finalitza al arribar a 0 hp o menys
                            Console.WriteLine(SpawnMSG, realMonster);
                            while (realHp > 0)
                            {
                                Console.WriteLine(HP_MSG, realMonster, realHp);
                                // genera la tirada del dau
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
                    //capitol 3
                    case 3:
                        const string WelcomeMine = "Welcome to the mine, you have 5 attempts for search bits";
                        const string MSG_AxisX = "Insert the X axis (horizontal), must be a number between 0 and 4";
                        const string MSG_AxisY = "Insert the Y axis (vertical), must be a number between 0 and 4";
                        const string FoundNothing = "you mined at x:{0} y:{1} but you didn't find anything";
                        const string FoundBits = "you mined at x:{0} y:{1} and you just found {2} bits and you have {3} bits in total";
                        const string RangeMSG = "the number must be between 0 and 4";

                        int axisX = 0;
                        int axisY = 0;
                        string[,] viewMAP = { { "➖", "➖", "➖", "➖", "➖" }, { "➖", "➖", "➖", "➖", "➖" }, { "➖", "➖", "➖", "➖", "➖" }, { "➖", "➖", "➖", "➖", "➖" }, { "➖", "➖", "➖", "➖", "➖" } };
                        int[] guideArray = {0,1, 2, 3, 4};
                        int[,] coinMAP = new int[5, 5];
                        int coinChance = rnd.Next(0, 2);
                        bool validatedX = false;
                        bool validatedY = false;
                        int bits = 0;
                        int axisGuide = 0;
                        //spawn de bits
                        for (int i = 0; i < coinMAP.GetLength(0); i++)
                        {
                            for (int j = 0; j < coinMAP.GetLength(1); j++)
                            {
                                int moneda = rnd.Next(0, 2);

                                if (moneda == 1)
                                {
                                    coinMAP[i, j] = rnd.Next(5, 51);
                                }
                                else
                                {
                                    coinMAP[i, j] = 0;
                                }
                            }
                        }
                        Console.WriteLine(WelcomeMine);

                        //intents
                        for (int attempts = 0; attempts <= 4; attempts++)
                        {
                            for (int i = 0;i < guideArray.Length; i++)
                            {
                                Console.Write(" ");
                                Console.Write(guideArray[i]);
                            }
                            Console.WriteLine();
                            axisGuide = 0;
                            for (int i = 0; i < viewMAP.GetLength(0); i++)
                            {
                                Console.Write(axisGuide);
                                axisGuide++;
                                for (int j = 0; j < viewMAP.GetLength(1); j++)
                                {
                                    Console.Write(viewMAP[i, j]);

                                }
                                Console.WriteLine();
                            }
                            //control d'errors y selecció de cordenades
                            validatedX = false;
                            validatedY = false;
                            while (!validatedX)
                            {
                                try
                                {
                                    Console.Write(MSG_AxisX + "\n");
                                    axisX = Convert.ToInt32(Console.ReadLine());

                                    if (axisX < 0 || axisX > 4)
                                    {
                                        Console.WriteLine(RangeMSG);
                                    }
                                    else
                                    {
                                        validatedX = true;
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine("Error: you must enter a number");
                                }
                            }
                            while (!validatedY)
                            {
                                try
                                {
                                    Console.Write(MSG_AxisY + "\n");
                                    axisY = Convert.ToInt32(Console.ReadLine());

                                    if (axisY < 0 || axisY > 4)
                                    {
                                        Console.WriteLine(RangeMSG);
                                    }
                                    else
                                    {
                                        validatedY = true;
                                    }
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Error: you must enter a number");
                                }
                            }
                            //verificació de les cordenades (si hi ha moneda o no)
                            if (coinMAP[axisX, axisY] > 0)
                            {
                                bits = bits + coinMAP[axisX, axisY];
                                Console.WriteLine(FoundBits, axisX, axisY, coinMAP[axisX, axisY], bits);
                                viewMAP[axisX, axisY] = "💰";
                                coinMAP[axisX, axisY] = 0;
                                realBits = bits;

                            }
                            else
                            {
                                Console.WriteLine(FoundNothing, axisX, axisY);
                                viewMAP[axisX, axisY] = "❌";
                            }
                        }
                        break;
                    //capitol 4
                    case 4:
                        const string EmptyInv = "\nYour inventory is empty";
                        const string Contains = "\nYour inventory contains:";

                        if (inventory.Length == 0)
                        {
                            Console.WriteLine(EmptyInv);
                        }
                        else
                        {
                            Console.WriteLine(Contains);
                            foreach (string item in inventory)
                            {
                                Console.WriteLine(" - " + item);
                            }
                        }
                        break;
                    case 5:
                        const string WelcomeShop = "Welcome to the shop! Type a number between 1 and 5 to buy an item";
                        const string ManyCoins = "You have {0} bits\n";
                        const string TypeMSG = "Type a number between 1 and 5";
                        const string PriceMSG = "  - Price: {0} bits";
                        const string ChoiceRangeError = "Must be a number between 1 and 5 ";
                        const string BuyMSG = "You spent {0} bits on buying a {1}";

                        int itemCounter = 1;
                        string[] shopItems = { "Iron Dagger 🗡️", "Healing Potion ⚗️", "Ancient Key 🗝️", "Crossbow 🏹", "Metal Shield 🛡️" };
                        int[] priceItems = { 30, 10, 50, 40, 20 };

                        int choice = 0;
                        int realChoice = 0;
                        bool validatedChoice;

                        Console.WriteLine(WelcomeShop);
                        Console.WriteLine(ManyCoins, realBits);
                        //mostra els productes i preus
                        for (int i = 0; i < shopItems.Length; i++)
                        {
                            Console.Write(itemCounter + " " + shopItems[i]);
                            Console.WriteLine(PriceMSG, priceItems[i]);
                            itemCounter++;
                        }
                        //elecció de producta y validació
                        validatedChoice = false;
                        while (!validatedChoice)
                        {
                            try
                            {
                                Console.Write(TypeMSG + "\n");
                                choice = Convert.ToInt32(Console.ReadLine());

                                if (choice < 1 || choice > 5)
                                {
                                    Console.WriteLine(ChoiceRangeError);
                                }
                                else
                                {
                                    validatedChoice = true;
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Error: you must enter a number");
                            }
                            realChoice = choice - 1;
                        }
                        //transacció del producte
                        if (realBits >= priceItems[realChoice])
                        {
                            Console.WriteLine(BuyMSG, priceItems[realChoice], shopItems[realChoice]);
                            string[] newInventory = new string[inventory.Length + 1];
                            for (int i = 0; i < inventory.Length; i++)
                            {
                                newInventory[i] = inventory[i];
                            }
                            newInventory[newInventory.Length - 1] = shopItems[realChoice];
                            realBits = realBits - priceItems[realChoice];
                            inventory = newInventory;
                        }
                        else
                        {
                            Console.WriteLine("Not enough bits");
                        }
                    break;
                    //capitol 6
                    case 6:
                        const string AvailableMSG ="The available attacks for level {0} are:";
                        const string KeepMSG = "Keep training to unlock new attacks";

                        string[][] attacksLvl =
                        {
                            new string[] {"Magic Spark 💫"},
                            new string[] {"Fireball 🔥", "Ice Ray 🥏", "Arcane Shield ⚕️"},
                            new string[] {"Meteor ☄️", "Pure Energy Explosion 💥", "Minor Charm 🎭", "Air Strike 🍃" },
                            new string[] {"Wave of Light ⚜️", "Storm of Wings 🐦"},
                            new string[] {"Cataclysm 🌋", "Portal of Chaos 🌀", "Arcane Blood Pact 🩸", "Elemental Storm ⛈️"}
                        };

                        Console.WriteLine(AvailableMSG,lvl);
                        //impresións dels atacs segons nivell, un nivell té disponibles els seus atacs y els dels nivells anteriors
                        if (lvl == 1)
                        {
                            //bucle que recorre cada array de la jagged
                            for (int i = 0; i < 1; i++)
                            {
                                //bucle de la impresió dels atacs
                                for (int j = 0; j < attacksLvl[i].Length; j++)
                                {
                                    Console.WriteLine(attacksLvl[i][j]);
                                }
                            }
                            Console.WriteLine(KeepMSG);
                        }
                        else if (lvl == 2)
                        {
                            for (int i = 0; i < 2; i++)
                            {
                                for (int j = 0; j < attacksLvl[i].Length; j++)
                                {
                                    Console.WriteLine(attacksLvl[i][j]);
                                }
                            }
                            Console.WriteLine(KeepMSG);
                        }
                        else if (lvl == 3)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                for (int j = 0; j < attacksLvl[i].Length; j++)
                                {
                                    Console.WriteLine(attacksLvl[i][j]);
                                }
                            }
                            Console.WriteLine(KeepMSG);
                        }
                        else if (lvl == 4)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                for (int j = 0; j < attacksLvl[i].Length; j++)
                                {
                                    Console.WriteLine(attacksLvl[i][j]);
                                }
                            }
                            Console.WriteLine(KeepMSG);
                        }
                        else
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                for (int j = 0; j < attacksLvl[i].Length; j++)
                                {
                                    Console.WriteLine(attacksLvl[i][j]);
                                }
                            }
                        }
                    break;
                    //capitol 7
                    case 7:
                        const string ScrollWelcome = "You found an ancient scroll with encrypted messages";
                        const string DecodeScroll = "You must decode the following scroll:";
                        const string DecodeOperation = "Choose a decoding operation:";
                        const string DecodeRangeError = "must be a number between 1 and 3";
                        const string CompletedDecode = "You decoded all parts of the scrolls!";
                        const string FinalVowels = "There are: {0} magical runes (vowels)";
                        const string FinalCode = "the secret code is: {0}";
                        string[] DecodeOptions = { "1. Decipher spell (remove spaces)", "2. Count magical runes (vowels)", "3. Extract secret code (numbers)"};
                        string vowels = "aeiouáéíóúAEIOUÁÉÍÓÚ";
                        string[] numbers = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

                        string scrollOne = "The 🐉 sleeps in the mountain of fire 🔥";
                        string scrollTwo = "Ancient magic flows through the crystal caves";
                        string scrollThree = "Spell: Ignis 5 🔥, Aqua 6 💧, Terra 3 🌍, Ventus 8 🏆";
                        int choosenOption = 0;
                        int realOption = 0;
                        bool validatedOption=false;
                        int manyVowels = 0;

                       
                        Console.WriteLine(ScrollWelcome);
                        Console.WriteLine(DecodeScroll+"\n");
                        Console.WriteLine(scrollOne);
                        Console.WriteLine(scrollTwo);
                        Console.WriteLine(scrollThree+"\n");
                        Console.WriteLine(DecodeOperation);
                        //bucle per mostrar les opcións de decodificació
                        for (int i = 0; i< DecodeOptions.Length; i++)
                        {
                            Console.WriteLine( DecodeOptions[i]);
                        }
                        //validació de la opció triada
                        while (!validatedOption)
                        {
                            try
                            {
                                choosenOption = Convert.ToInt32(Console.ReadLine());

                                if (choosenOption < 1 || choosenOption > 3)
                                {
                                    Console.WriteLine(DecodeRangeError);
                                }
                                else
                                {
                                    validatedOption = true;
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Error: you must enter a number");
                            }
                            realOption = choosenOption - 1;
                        }
                        //decodificació del pergami
                        switch (choosenOption)
                        {
                            case 1:
                                string decodedScrollOne = scrollOne.Replace(" ", "");
                                Console.WriteLine(decodedScrollOne);
                                decodedOne = true;
                                if (decodedOne == true && decodedTwo == true && decodedThree == true)
                                {
                                    Console.WriteLine(CompletedDecode);
                                }
                                break;
                            case 2:
                                for (int i = 0;i< scrollTwo.Length; i++)
                                {
                                    char position = scrollTwo[i];
                                    if (vowels.Contains(position))
                                    {
                                        manyVowels++;
                                    }
                                }
                                Console.WriteLine(FinalVowels,manyVowels);
                                decodedTwo = true;
                                if (decodedOne == true && decodedTwo == true && decodedThree == true)
                                {
                                    Console.WriteLine(CompletedDecode);
                                }
                                break;
                            case 3:
                                string secretCode = "";
                                for (int i = 0; i < scrollThree.Length; i++)
                                {
                                    char positionTwo = scrollThree[i];

                                    if (positionTwo >= '0' && positionTwo <= '9')   // comprovem si és número
                                    {
                                        secretCode = secretCode + positionTwo;
                                    }
                                }
                                Console.WriteLine(FinalCode,secretCode);
                                decodedThree = true; 
                                if (decodedOne == true && decodedTwo == true && decodedThree == true)
                                {
                                    Console.WriteLine(CompletedDecode);
                                }
                                break;
                        }                     
                            break;
                    //Codi al triar sortir del programa
                    case 0:
                        Console.WriteLine(MSG_ThxPlay);
                        break;
                }
            }
        } while (op != 0); 

    }

}