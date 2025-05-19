using System.ComponentModel;
using System.Data;
using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace PokemonGame
{
    class Program
    {

        static void Main(string[] args)
        {


            // Makes all Pokemon with stats and type
            Pokemon bulbasaur = new Pokemon("Bulbasaur", "bu", 1f, 0.1f, 0.05f, 1f, 14.95f, false, false, false, "grass"); // grass
            Pokemon charmander = new Pokemon("Charmander", "ch", 1f, 0.08f, 0.08f, 70f, 19.92f, false, false, false, "fire"); // fire
            Pokemon squirtle = new Pokemon("Squirtle", "sq", 1f, 0.12f, 0.04f, 80f, 15.96f, false, false, false, "water"); // water
            Pokemon caterpie = new Pokemon("Caterpie", "ca", 1f, 0.08f, 0.08f, 90f, 14.92f, false, false, false, "grass"); // grass
            Pokemon weedle = new Pokemon("Weedle", "we", 1f, 0.05f, 0.1f, 100f, 12.9f, false, false, false, "poison"); // poison
            Pokemon ekans = new Pokemon("Ekans", "ek", 1f, 0.04f, 0.15f, 100f, 19.85f, false, false, false, "poison"); // poison
            Pokemon pikachu = new Pokemon("Pikachu", "pi", 1f, 0.05f, 0.1f, 150f, 14.9f, false, false, false, "electric"); // electric
            Pokemon oddish = new Pokemon("Oddish", "od", 1f, 0.09f, 0.08f, 100f, 14.92f, false, false, false, "grass"); // grass
            Pokemon diglett = new Pokemon("Diglett", "di", 1f, 0.05f, 0.05f, 100f, 14.95f, false, false, false, "rock"); // rock
            Pokemon geodude = new Pokemon("Geodude", "ge", 1f, 0.04f, 0.1f, 200f, 19.9f, false, false, false, "rock"); // rock
            Pokemon magnemite = new Pokemon("Magnemite", "ma", 1f, 0.03f, 0.1f, 150f, 11.9f, false, false, false, "steel"); // steel
            Pokemon vaporeon = new Pokemon("Vaporeon", "va", 1f, 0.08f, 0.05f, 90f, 14.95f, false, false, false, "water"); // water
            Pokemon jolteon = new Pokemon("Jolteon", "jo", 1f, 0.06f, 0.07f, 90f, 15.93f, false, false, false, "electric"); // electric
            Pokemon flareon = new Pokemon("Flareon", "fl", 1f, 0.07f, 0.06f, 90f, 15.94f, false, false, false, "fire"); // fire
            Pokemon porygon = new Pokemon("Porygon", "po", 1f, 0.1f, 0.08f, 120f, 14.92f, false, false, false, "steel"); // steel
            Pokemon onix = new Pokemon("Onix", "on", 1f, 0.05f, 0.1f, 150f, 14.9f, false, false, false, "rock"); // rock
            Pokemon arcanine = new Pokemon("Arcanine", "ar", 1f, 0.05f, 0.04f, 120f, 14.96f, false, false, false, "fire"); // fire
            Pokemon steelix = new Pokemon("Steelix", "st", 1f, 0.07f, 0.1f, 130f, 15.9f, false, false, false, "steel"); // steel
            Pokemon ampharos = new Pokemon("Ampharos", "am", 1f, 0.06f, 0.08f, 90f, 14.92f, false, false, false, "electric"); // electric
            Pokemon omanyte = new Pokemon("Omanyte", "om", 1f, 0.1f, 0.04f, 90f, 19.96f, false, false, false, "water"); // water
            Pokemon koffing = new Pokemon("Koffing", "ko", 1f, 0.08f, 0.05f, 80f, 24.95f, false, false, false, "poison"); // poison


            // Store all Pokemon in an array
            Pokemon[] allPokemon = new Pokemon[]
            {
    bulbasaur, caterpie, oddish, arcanine, charmander, flareon, magnemite, steelix,
    porygon, squirtle, vaporeon, omanyte, pikachu, jolteon, ampharos, weedle,
    koffing, ekans, diglett, geodude, onix
            };


            // Variables 
            bool askingPokemon = true;  // Checks if its asking about pokemon
            bool secondTime = false;    // Checks if its the first or the second time the loop is run
            bool askingForMore = true;  // Asks for the second and third pokemon        
            string time = "second";     // Just makes a diffrent print with either second or third in the asking promt
            string youreActive = "XXX"; // First stored pokemon
            string inventory1 = "XXX";  // Second stored pokemon
            string inventory2 = "XXX";  // Third stored pokemon
            bool doneAsking = false;    // Checks if its done asking the first segment in the choosing of pokemons    
            bool fighting = true;       // This checks if the pokemonms are fighting
            int firstPokInt = 0;        // This will give the first pokemon you choose a value you can later use
            int nameLength = 0;         // This uses in my print pokemon method and check how long the name of the pokemon is
            int namelenghtminus = 0;    // This uses in my print pokemon method
            string effectiveColor = ""; // This will choose the color the following words will have
            string effective = "";      // This will print words like uneffective and super effective when the attack hits
            float effectiveness = 1.0f; // Default multiplier


            // this is the color i can use in the following method, i also have the types in here so i can use my array of objects
            Dictionary<string, ConsoleColor> Colours = new Dictionary<string, ConsoleColor>
                {
                    {"green", ConsoleColor.Green},
                    {"orange", ConsoleColor.DarkYellow},
                     {"electric", ConsoleColor.DarkYellow},
                    {"cyan", ConsoleColor.Cyan},
                    {"yellow", ConsoleColor.Yellow},
                    {"red", ConsoleColor.Red},
                    {"fire", ConsoleColor.Red},
                    {"purple", ConsoleColor.Magenta },
                    {"blue", ConsoleColor.Blue },
                    {"water", ConsoleColor.Blue },
                     {"gray", ConsoleColor.DarkGray },
                     {"rock", ConsoleColor.DarkGray },
                     {"poison", ConsoleColor.Magenta },
                      {"grass", ConsoleColor.Green },

                };

            // this method rewrites the console.writeline and console.write so i can add the color of the print in the same line
            void writecolor(string mode, string message, string color = "")
            {

                foreach (var item in Colours)
                {
                    if (item.Key == color.ToLower())
                    {
                        Console.ForegroundColor = item.Value;
                    }
                    else if (color == "")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }


                if (mode.ToLower() == "line")       // Makes the function into a Console.Write
                {
                    Console.WriteLine(message);
                }
                else if (mode.ToLower() == "write")  // Makes the function into a Console.Writeline
                {
                    Console.Write(message);
                }
                Console.ResetColor();


            }


            // Prints a list of all the pokemon and some of thier stats
            void PokemonlList()
            {
                for (int a = 0; a <= 20; a++)
                {
                    nameLength = allPokemon[a].Name.Length;
                    namelenghtminus = 12 - nameLength;
                    writecolor("write", allPokemon[a].Name + " ", allPokemon[a].Type);
                    for (int b = 0; b < namelenghtminus; b++)
                    {
                        writecolor("write", "-", allPokemon[a].Type);
                    }
                    writecolor("write", " " + allPokemon[a].Type + " Hp-" + allPokemon[a].Hp + " Damage-" + allPokemon[a].Damage, allPokemon[a].Type);
                    Console.WriteLine();
                    if (a == 2 || a == 5 || a == 8 || a == 11 || a == 14 || a == 17 || a == 21)
                    {
                        Console.WriteLine();
                    }
                }

                Console.WriteLine();
            }


            writecolor("line", "Welcome to PokeMon!", "cyan"); // Welcomes the player
            Console.WriteLine();


            // Prints the pokemon list
            PokemonlList();




            // Ask what pokemon the player wants
            while (askingPokemon)
            {
                if (secondTime)
                {
                    writecolor("line", "Incorrect massage, try again!", "red");
                }
                writecolor("line", "Please write the 2 first letters of the pokemon you want too choose", "white");
                string firstPok = Console.ReadLine();

                firstPok = firstPok.ToLower();

                for (int a = 0; a < 21; a++)
                {
                    if (firstPok == allPokemon[a].ChosenChar)
                    {
                        allPokemon[a].Active = true;
                        youreActive = allPokemon[a].Name;
                        firstPokInt = a;
                        askingPokemon = false;
                    }

                }

                secondTime = true;
            }

            secondTime = false;

            while (askingForMore)
            {
                if (secondTime)
                {
                    writecolor("line", "Incorrect massage, try again!", "red");
                }
                Console.Clear();
                PokemonlList();
                writecolor("line", "Now type the first 2 letters of the " + time + " pokemon you want.", "white");
                string secondPok = Console.ReadLine();
                secondPok = secondPok.ToLower();
                if (doneAsking == false)
                {
                    for (int a = 0; a < 21; a++)
                    {
                        if (secondPok == allPokemon[a].ChosenChar)
                        {
                            allPokemon[a].Inventory = true;
                            inventory1 = allPokemon[a].Name;
                            doneAsking = true;
                            time = "third";
                        }
                        secondTime = true;
                    }
                }


                // Checks if its done asking for the first pokemon
                if (doneAsking)
                {
                    Console.Clear();
                    PokemonlList();
                    writecolor("line", "Now type the first 2 letters of the " + time + " pokemon you want.", "white");
                    secondPok = Console.ReadLine();
                    secondPok = secondPok.ToLower();

                    for (int a = 0; a < 21; a++) // Checks if your answer matches one of the pokemons
                    {
                        if (secondPok == allPokemon[a].ChosenChar)
                        {
                            allPokemon[a].Inventory = true;
                            inventory2 = allPokemon[a].Name;

                            askingForMore = false;

                        }

                    }
                }




            }

            // Multiplies the damage and hp with their multipliers so you can change the damage and health with levels
            allPokemon[firstPokInt].Damage = allPokemon[firstPokInt].Level * allPokemon[firstPokInt].DamageMulti + allPokemon[firstPokInt].BaseDamage;
            allPokemon[firstPokInt].Hp = allPokemon[firstPokInt].Level * allPokemon[firstPokInt].HpMulti + allPokemon[firstPokInt].BaseHp;



            Random random = new Random();
            HashSet<int> numbers = new HashSet<int>(); // makes it so it dosnt repeat numbers

            while (numbers.Count < 3) // makes 3 unique number that represent the enemies pokemon
            {
                int num = random.Next(1, 22); // 1 to 21
                numbers.Add(num); // Only adds if not already there
            }

            List<int> numberList = new List<int>(numbers); // Makes a list with the enemy pokemons

            string enemyHealth = (allPokemon[numberList[0]].Hp).ToString(); // Makes enemys hp into a string 

            writecolor("line", "The fight has begun!", "red"); // Intoduces the fight 


            // Makes the pokemons into attacking or defending and saving thier types
            string attackerType = allPokemon[firstPokInt].Type;
            string defenderType = allPokemon[numberList[0]].Type;


            // Checks if the pokemons are fighting
            while (fighting)
            {


                if (allPokemon[firstPokInt].Hp <= 0)
                {
                    break;
                }

                // Prints the current stats of the pokemons and asks what move to use
                enemyHealth = (allPokemon[numberList[0]].Hp).ToString();
                Console.Clear();
                writecolor("write", "Your opponent are using ", "white");
                writecolor("write", allPokemon[numberList[0]].Name, allPokemon[numberList[0]].Type);
                writecolor("write", " you are using ", "white");
                writecolor("write", allPokemon[firstPokInt].Name, allPokemon[firstPokInt].Type);
                writecolor("write", "!", "white");
                Console.WriteLine();
                writecolor("write", "Your ", "white");
                writecolor("write", allPokemon[firstPokInt].Name, allPokemon[firstPokInt].Type);
                writecolor("write", " have ", "white");
                writecolor("write", allPokemon[firstPokInt].Hp + " Hp", "red");
                writecolor("write", " and your opponents ", "white");
                writecolor("write", allPokemon[numberList[0]].Name, allPokemon[numberList[0]].Type);
                writecolor("write", " have ");
                writecolor("write", enemyHealth + " Hp", "red");
                Console.WriteLine();
                writecolor("line", "Choose between 1-4!", "white");
                writecolor("line", "1. Use basic attack", "white");
                writecolor("line", "2. Use block", "white");
                writecolor("line", "3. Use Spacial move", "white");
                writecolor("line", "4. Switch Pokemon", "white");

                string fightingAnswer = Console.ReadLine(); // saves the answer

                // Checks what the answer is
                switch (fightingAnswer)
                {


                    case "1": // Makes the basic attack

                        attackerType = allPokemon[firstPokInt].Type;
                        defenderType = allPokemon[numberList[0]].Type;

                        effectiveness = 1.0f; // Default multiplier

                        if (TypeChart.TypeEffectiveness.ContainsKey(attackerType)) // Cheacks if the type of the pokemon matches the dictionary
                        {

                            var effectivenessDict = TypeChart.TypeEffectiveness[attackerType];

                            if (effectivenessDict.ContainsKey(defenderType))           // checks if the dictionary inside the other one got the defending type
                            {
                                effectiveness = effectivenessDict[defenderType];
                            }
                        }
                        float damageDealt = allPokemon[firstPokInt].Damage * effectiveness; // calculates the damge after applying the effectiveness

                        allPokemon[numberList[0]].Hp = allPokemon[numberList[0]].Hp - damageDealt; // calculates the hp after subtracting the damage

                        // writes how much hp the pokemons have
                        writecolor("write", "Your ", "white");
                        writecolor("write", allPokemon[firstPokInt].Name, allPokemon[firstPokInt].Type);
                        writecolor("write", " have ", "white");
                        writecolor("write", allPokemon[firstPokInt].Hp + " Hp", "red");
                        writecolor("write", " and your opponents ", "white");
                        writecolor("write", allPokemon[numberList[0]].Name, allPokemon[numberList[0]].Type);
                        writecolor("write", " have ");
                        writecolor("write", enemyHealth + " Hp", "red");
                        Console.WriteLine();

                        // writes how much damge you dealt to youre opponent
                        writecolor("write", "Your ", "white");
                        writecolor("write", allPokemon[firstPokInt].Name, allPokemon[firstPokInt].Type);
                        writecolor("write", " dealt ", "white");
                        writecolor("write", damageDealt.ToString("0.00"), "red");
                        writecolor("write", " damage and it was ", "white");

                        // checks how effective the attack was
                        switch (effectiveness)
                        {
                            case 1f:
                                effective = "Neutral.";
                                effectiveColor = "white";
                                break;

                            case 2f:
                                effective = "SUPER EFFECTIVE!";
                                effectiveColor = "purple";
                                break;

                            case 0.5f:
                                effective = "uneffective.";
                                effectiveColor = "rock";
                                break;

                            case 0f:
                                effective = "IMMUNE!";
                                effectiveColor = "blue";
                                break;
                        }


                        writecolor("write", effective, effectiveColor);





                        break;




                }


                Console.ReadLine();

                Console.Clear();

                if (allPokemon[numberList[0]].Hp <= 0f)
                {
                    break;
                }

                // makes a method for the enemys attack
                void EnemyAttack()
                {


                    effectiveness = 1.0f; // Default multiplier

                    attackerType = allPokemon[firstPokInt].Type;
                    defenderType = allPokemon[numberList[0]].Type;

                    if (TypeChart.TypeEffectiveness.ContainsKey(defenderType))
                    {

                        var effectivenessDict = TypeChart.TypeEffectiveness[defenderType];

                        if (effectivenessDict.ContainsKey(attackerType))
                        {
                            effectiveness = effectivenessDict[attackerType];
                        }
                    }

                    float enemyDealt = allPokemon[numberList[0]].Damage * effectiveness;

                    allPokemon[firstPokInt].Hp = allPokemon[firstPokInt].Hp - enemyDealt;


                    // does pretty much the exact same as in when the player attacks 

                    // prints the hp and effectiveness
                    writecolor("write", "Youre opponents ", "white");
                    writecolor("write", allPokemon[numberList[0]].Name, allPokemon[numberList[0]].Type);
                    writecolor("write", " dealt ", "white");
                    writecolor("write", enemyDealt.ToString("0.00"), "red");
                    writecolor("write", " damage and it was ", "white");

                    // Checks how effective the attack was
                    switch (effectiveness)
                    {
                        case 1f:
                            effective = "Neutral.";
                            effectiveColor = "white";
                            break;

                        case 2f:
                            effective = "SUPER EFFECTIVE!";
                            effectiveColor = "purple";
                            break;

                        case 0.5f:
                            effective = "uneffective.";
                            effectiveColor = "rock";
                            break;

                        case 0f:
                            effective = "IMMUNE!";
                            effectiveColor = "blue";
                            break;
                    }
                    writecolor("write", effective, effectiveColor);
                    Console.ReadLine();
                }

                EnemyAttack(); // makes the enemy attack in an forever loop.
            }

            // checks if you lost or won
            //more comment
            if (allPokemon[numberList[0]].Hp <= 0f)
            {
                writecolor("line", "YOU WON!!!", "green");
            }
            else if (allPokemon[firstPokInt].Hp <= 0)
            {
                writecolor("line", "You lost :(", "red");
            }
        }




    }
}
