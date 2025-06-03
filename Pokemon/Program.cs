using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            Pokemon bulbasaur = new Pokemon("Bulbasaur", 1, "bu", 1f, 0.1f, 0.05f, 100f, 14.95f, false, false, false, "grass"); // grass
            Pokemon caterpie = new Pokemon("Caterpie", 2, "ca", 1f, 0.08f, 0.08f, 90f, 14.92f, false, false, false, "grass"); // grass
            Pokemon oddish = new Pokemon("Oddish", 3, "od", 1f, 0.09f, 0.08f, 100f, 14.92f, false, false, false, "grass"); // grass
            Pokemon arcanine = new Pokemon("Arcanine", 4, "ar", 1f, 0.05f, 0.04f, 120f, 14.96f, false, false, false, "fire"); // fire
            Pokemon charmander = new Pokemon("Charmander", 5, "ch", 1f, 0.08f, 0.08f, 70f, 19.92f, false, false, false, "fire"); // fire
            Pokemon flareon = new Pokemon("Flareon", 6, "fl", 1f, 0.07f, 0.06f, 90f, 15.94f, false, false, false, "fire"); // fire
            Pokemon magnemite = new Pokemon("Magnemite", 7, "ma", 1f, 0.03f, 0.1f, 150f, 11.9f, false, false, false, "steel"); // steel
            Pokemon steelix = new Pokemon("Steelix", 8, "st", 1f, 0.07f, 0.1f, 130f, 15.9f, false, false, false, "steel"); // steel
            Pokemon porygon = new Pokemon("Porygon", 9, "po", 1f, 0.1f, 0.08f, 120f, 14.92f, false, false, false, "steel"); // steel
            Pokemon squirtle = new Pokemon("Squirtle", 10, "sq", 1f, 0.12f, 0.04f, 80f, 15.96f, false, false, false, "water"); // water
            Pokemon vaporeon = new Pokemon("Vaporeon", 11, "va", 1f, 0.08f, 0.05f, 90f, 14.95f, false, false, false, "water"); // water
            Pokemon omanyte = new Pokemon("Omanyte", 12, "om", 1f, 0.1f, 0.04f, 90f, 19.96f, false, false, false, "water"); // water
            Pokemon pikachu = new Pokemon("Pikachu", 13, "pi", 1f, 0.05f, 0.1f, 150f, 14.9f, false, false, false, "electric"); // electric
            Pokemon jolteon = new Pokemon("Jolteon", 14, "jo", 1f, 0.06f, 0.07f, 90f, 15.93f, false, false, false, "electric"); // electric
            Pokemon ampharos = new Pokemon("Ampharos", 15, "am", 1f, 0.06f, 0.08f, 90f, 14.92f, false, false, false, "electric"); // electric
            Pokemon weedle = new Pokemon("Weedle", 16, "we", 1f, 0.05f, 0.1f, 100f, 12.9f, false, false, false, "poison"); // poison
            Pokemon koffing = new Pokemon("Koffing", 17, "ko", 1f, 0.08f, 0.05f, 80f, 24.95f, false, false, false, "poison"); // poison
            Pokemon ekans = new Pokemon("Ekans", 18, "ek", 1f, 0.04f, 0.15f, 100f, 19.85f, false, false, false, "poison"); // poison
            Pokemon diglett = new Pokemon("Diglett", 19, "di", 1f, 0.05f, 0.05f, 100f, 14.95f, false, false, false, "rock"); // rock
            Pokemon geodude = new Pokemon("Geodude", 20, "ge", 1f, 0.04f, 0.1f, 200f, 19.9f, false, false, false, "rock"); // rock
            Pokemon onix = new Pokemon("Onix", 21, "on", 1f, 0.05f, 0.1f, 150f, 14.9f, false, false, false, "rock"); // rock

            // Store all Pokemon in an array
            Pokemon[] allPokemon = new Pokemon[]
            {
            bulbasaur, caterpie, oddish, arcanine, charmander, flareon, magnemite, steelix,
            porygon, squirtle, vaporeon, omanyte, pikachu, jolteon, ampharos, weedle,
            koffing, ekans, diglett, geodude, onix
            };

            int[] playerPokemons = new int[3];


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
            int firstPok = 0;           // This will give the first pokemon you choose a value you can later use
            int secondPok = 0;          // This will give the second pokemon you choose a value you can later use
            int thirdPok = 0;           // This will give the third pokemon you choose a value you can later use
            int nameLength = 0;         // This uses in my print pokemon method and check how long the name of the pokemon is
            int namelenghtminus = 0;    // This uses in my print pokemon method
            string effectiveColor = ""; // This will choose the color the following words will have
            string effective = "";      // This will print words like uneffective and super effective when the attack hits
            float effectiveness = 1.0f; // Default multiplier
            bool playerBlock = false;   // Checks if the player is blocking or not
            bool enemyBlock = false;    // Checks if the enemy is blocking or not
            int usingPok = 0;           // This is the current Pokémon the player is using
            bool switching = true;      // Checks if the player is switching the Pokémon or not
            int currentEnemy = 0;       // This is the current enemy pokémon.
            bool justDied = false;      // Checks if a Pokémon died in a previus loop



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
            void WriteColor(string mode, string message, string color = "")
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

            void ChooseAnotherPokemon()
            {
                switching = true;
                Console.WriteLine();
                WriteColor("line", "Choose a pokemon (write the number):", "white");

                if (usingPok == 0 || allPokemon[playerPokemons[0]].Hp <= 0)
                {
                    WriteColor("line", "1--" + allPokemon[playerPokemons[0]].Name, "rock");
                }
                else
                {
                    WriteColor("line", "1--" + allPokemon[playerPokemons[0]].Name, allPokemon[playerPokemons[0]].Type);
                }

                if (usingPok == 1 || allPokemon[playerPokemons[1]].Hp <= 0)
                {
                    WriteColor("line", "2--" + allPokemon[playerPokemons[1]].Name, "rock");
                }
                else
                {
                    WriteColor("line", "2--" + allPokemon[playerPokemons[1]].Name, allPokemon[playerPokemons[1]].Type);
                }

                if (usingPok == 2 || allPokemon[playerPokemons[2]].Hp <= 0)
                {
                    WriteColor("line", "3--" + allPokemon[playerPokemons[2]].Name, "rock");
                }
                else
                {
                    WriteColor("line", "3--" + allPokemon[playerPokemons[2]].Name, allPokemon[playerPokemons[2]].Type);
                }


                while (switching)
                {
                    string changed = Console.ReadLine();
                    changed = changed.ToLower();

                    switch (changed)
                    {
                        case "1":

                            if (allPokemon[playerPokemons[0]].Hp <= 0f)
                            {
                                WriteColor("line", "Has already fainted, Please choose another one!", "red");

                            }
                            else
                            {
                                usingPok = 0;
                                switching = false;
                            }
                            break;
                        case "2":

                            if (allPokemon[playerPokemons[1]].Hp <= 0f)
                            {
                                WriteColor("line", "Has already fainted, Please choose another one!", "red");
                                break;
                            }
                            else
                            {
                                usingPok = 1;
                                switching = false;
                            }
                            break;
                        case "3":

                            if (allPokemon[playerPokemons[2]].Hp <= 0f)
                            {
                                WriteColor("line", "Has already fainted, Please choose another one!", "red");
                                break;
                            }
                            else
                            {
                                usingPok = 2;
                                switching = false;
                            }
                            break;

                    }
                }
            }


            // Prints a list of all the pokemon and some of thier stats
            void PokemonlList()
            {
                for (int a = 0; a <= 20; a++)
                {
                    nameLength = allPokemon[a].Name.Length;
                    namelenghtminus = 12 - nameLength;
                    WriteColor("write", allPokemon[a].Name + " ", allPokemon[a].Type);

                    for (int b = 0; b < namelenghtminus; b++)
                    {
                        WriteColor("write", "-", allPokemon[a].Type);
                    }

                    WriteColor("write", " " + allPokemon[a].Type + " | HP: " + allPokemon[a].Hp + " | DMG: " + allPokemon[a].Damage, allPokemon[a].Type);
                    Console.WriteLine();
                    if (a == 2 || a == 5 || a == 8 || a == 11 || a == 14 || a == 17 || a == 21)
                    {
                        Console.WriteLine();
                    }
                }

                Console.WriteLine();
            }


            WriteColor("line", "Welcome to Pokémon!", "cyan"); // Welcomes the player
            Console.WriteLine();


            // Prints the pokemon list
            PokemonlList();




            Console.Clear();
            PokemonlList();

            for (int i = 0; i < 3; i++)
            {
                string ordinal = i == 0 ? "first" : i == 1 ? "second" : "third";

                while (true)
                {
                    WriteColor("line", "Choose your " + ordinal + " Pokémon (enter first 2 letters):", "white");
                    string input = Console.ReadLine().ToLower();

                    int selectedIndex = -1;

                    // Find Pokémon that matches input
                    for (int a = 0; a < allPokemon.Length; a++)
                    {
                        if (allPokemon[a].ChosenChar == input)
                        {
                            selectedIndex = a;
                            break;
                        }
                    }

                    if (selectedIndex == -1)
                    {
                        WriteColor("line", "Invalid input. Please enter the first two letters of a valid Pokémon.", "red");
                        continue;
                    }

                    // Check if already chosen
                    bool alreadyChosen = false;
                    for (int j = 0; j < i; j++)
                    {
                        if (playerPokemons[j] == selectedIndex)
                        {
                            alreadyChosen = true;
                            break;
                        }
                    }

                    if (alreadyChosen)
                    {
                        WriteColor("line", "You already chose this Pokémon. Pick a different one!", "red");
                        continue;
                    }

                    // Assign the Pokémon
                    playerPokemons[i] = selectedIndex;

                    if (i == 0)
                    {
                        allPokemon[selectedIndex].Active = true;
                        youreActive = allPokemon[selectedIndex].Name;
                    }
                    else
                    {
                        allPokemon[selectedIndex].Inventory = true;
                        if (i == 1) inventory1 = allPokemon[selectedIndex].Name;
                        else if (i == 2) inventory2 = allPokemon[selectedIndex].Name;
                    }

                    break; // move to next Pokémon
                }

                Console.Clear();
                PokemonlList();
            }





            // Multiplies the damage and hp with their multipliers so you can change the damage and health with levels
            allPokemon[playerPokemons[usingPok]].Damage = allPokemon[playerPokemons[usingPok]].Level * allPokemon[playerPokemons[usingPok]].DamageMulti + allPokemon[playerPokemons[usingPok]].BaseDamage;
            allPokemon[playerPokemons[usingPok]].Hp = allPokemon[playerPokemons[usingPok]].Level * allPokemon[playerPokemons[usingPok]].HpMulti + allPokemon[playerPokemons[usingPok]].BaseHp;


            Random random = new Random();



            int[] enemyNumbers = new int[3];

            while (true)
            {
                HashSet<int> generated = new HashSet<int>();

                while (generated.Count < 3)
                {
                    int num = random.Next(1, 22); // 1 to 21
                    generated.Add(num);
                }

                // If no overlap with player, store in enemyNumbers array and break
                if (!generated.Intersect(playerPokemons).Any())
                {
                    enemyNumbers = generated.ToArray();
                    break;
                }

            }

            Console.WriteLine("Enemy Numbers: " + string.Join(", ", enemyNumbers));

            string enemyHealth = (allPokemon[enemyNumbers[currentEnemy]].Hp).ToString(); // Makes enemys hp into a string 

            WriteColor("line", "The fight has begun!", "red"); // Intoduces the fight 


            // Makes the pokemons into attacking or defending and saving thier types
            string attackerType = allPokemon[playerPokemons[usingPok]].Type;
            string defenderType = allPokemon[enemyNumbers[currentEnemy]].Type;

            // makes a method for the enemys attack
            void EnemyAttack()
            {


                effectiveness = 1.0f; // Default multiplier

                attackerType = allPokemon[playerPokemons[usingPok]].Type;
                defenderType = allPokemon[enemyNumbers[currentEnemy]].Type;

                if (TypeChart.TypeEffectiveness.ContainsKey(defenderType))
                {

                    var effectivenessDict = TypeChart.TypeEffectiveness[defenderType];

                    if (effectivenessDict.ContainsKey(attackerType))
                    {
                        effectiveness = effectivenessDict[attackerType];
                    }
                }

                float enemyDealt = allPokemon[enemyNumbers[currentEnemy]].Damage * effectiveness;

                if (playerBlock == true)
                {
                    enemyDealt = enemyDealt * 0.2f;
                    playerBlock = false;
                }

                allPokemon[playerPokemons[usingPok]].Hp = allPokemon[playerPokemons[usingPok]].Hp - enemyDealt;


                // does pretty much the exact same as in when the player attacks 

                // prints the hp and effectiveness
                WriteColor("write", "Youre opponents ", "white");
                WriteColor("write", allPokemon[enemyNumbers[currentEnemy]].Name, allPokemon[enemyNumbers[currentEnemy]].Type);
                WriteColor("write", " dealt ", "white");
                WriteColor("write", enemyDealt.ToString("0.00"), "red");
                WriteColor("write", " damage and it was ", "white");

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
                WriteColor("write", effective, effectiveColor);
                Console.ReadLine();
            }

            // Checks if the pokemons are fighting
            while (fighting)
            {

                Console.Clear();

                if (justDied == true)
                {
                    WriteColor("write", "The oppnents ", "white");
                    WriteColor("write", allPokemon[enemyNumbers[currentEnemy - 1]].Name, allPokemon[enemyNumbers[currentEnemy - 1]].Type);
                    WriteColor("write", " died! \nYou are now battling ", " white");
                    WriteColor("write", allPokemon[enemyNumbers[currentEnemy]].Name + "!", allPokemon[enemyNumbers[currentEnemy]].Type);
                    justDied = false;
                }





                if (allPokemon[playerPokemons[0]].Hp <= 0)
                {
                 //   break;
                }

                // Prints the current stats of the pokemons and asks what move to use
                enemyHealth = (allPokemon[enemyNumbers[0]].Hp).ToString();
                
                WriteColor("write", "Player: ", "white");
                WriteColor("write", allPokemon[playerPokemons[usingPok]].Name + "\n", allPokemon[playerPokemons[usingPok]].Type);
                WriteColor("write", "Enemy:  ", "white");
                WriteColor("write", allPokemon[enemyNumbers[currentEnemy]].Name + "\n", allPokemon[enemyNumbers[currentEnemy]].Type);
                // WriteColor("write", "Your ", "white");
                Console.WriteLine();
                WriteColor("write", allPokemon[playerPokemons[usingPok]].Name + "s", allPokemon[playerPokemons[usingPok]].Type);
                WriteColor("write", " HP: ", "white");
                WriteColor("write", allPokemon[playerPokemons[usingPok]].Hp + "\n", "red");
                Console.WriteLine();
               // WriteColor("write", "Your opponents ", "white");
                WriteColor("write", allPokemon[enemyNumbers[currentEnemy]].Name + "s ", allPokemon[enemyNumbers[currentEnemy]].Type);
                WriteColor("write", "HP: ");
                WriteColor("write", allPokemon[enemyNumbers[currentEnemy]].Hp + "\n" , "red");
                Console.WriteLine();
                WriteColor("line", "Choose between 1-3!", "white");
                WriteColor("write", "1. ", "red");
                WriteColor("write", "Use basic attack \n", "white");
                WriteColor("write", "2. ", "cyan");
                WriteColor("write", "Use block \n", "white");
                WriteColor("write", "3. ", "purple");
                WriteColor("write", "Switch Pokemon \n", "white");
                Console.Write("Player input: ");
                string fightingAnswer = Console.ReadLine(); // saves the answer

                // Checks what the answer is
                switch (fightingAnswer)
                {


                    case "1": // Makes the basic attack

                        attackerType = allPokemon[playerPokemons[usingPok]].Type;
                        defenderType = allPokemon[enemyNumbers[currentEnemy]].Type;

                        effectiveness = 1.0f; // Default multiplier

                        if (TypeChart.TypeEffectiveness.ContainsKey(attackerType)) // Cheacks if the type of the pokemon matches the dictionary
                        {

                            var effectivenessDict = TypeChart.TypeEffectiveness[attackerType];

                            if (effectivenessDict.ContainsKey(defenderType))           // checks if the dictionary inside the other one got the defending type
                            {
                                effectiveness = effectivenessDict[defenderType];
                            }
                        }

                        float damageDealt = allPokemon[playerPokemons[usingPok]].Damage * effectiveness; // calculates the damge after applying the effectiveness



                        // writes how much damge you dealt to youre opponent
                        WriteColor("write", "Your ", "white");
                        WriteColor("write", allPokemon[playerPokemons[usingPok]].Name, allPokemon[playerPokemons[usingPok]].Type);
                        WriteColor("write", " dealt ", "white");
                        WriteColor("write", damageDealt.ToString("0.00"), "red");
                        WriteColor("write", " damage and it was ", "white");





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

                        WriteColor("write", effective, effectiveColor);
                        Console.WriteLine();

                        allPokemon[enemyNumbers[currentEnemy]].Hp = allPokemon[enemyNumbers[currentEnemy]].Hp - damageDealt; // calculates the hp after subtracting the damage





                        break;

                    case "2":
                        playerBlock = true;

                        WriteColor("write", "You used ", "white");
                        WriteColor("write", "block ", "cyan");
                        WriteColor("write", "! absorbing most of the damage. ", "white");
                        break;

                    case "3":
                        ChooseAnotherPokemon();
                        break;
                }


               
               

               

                EnemyAttack(); // makes the enemy attack in an forever loop.

                // writes how much hp the pokemons have
                /*
                WriteColor("write", "Your ", "white");
                WriteColor("write", allPokemon[playerPokemons[usingPok]].Name, allPokemon[playerPokemons[usingPok]].Type);
                WriteColor("write", " have ", "white");
                WriteColor("write", allPokemon[playerPokemons[usingPok]].Hp + " Hp", "red");
                WriteColor("write", " and your opponents ", "white");
                WriteColor("write", allPokemon[enemyNumbers[currentEnemy]].Name, allPokemon[enemyNumbers[currentEnemy]].Type);
                WriteColor("write", " have ");
                */
                if (allPokemon[enemyNumbers[currentEnemy]].Hp < 0)
                {
                    allPokemon[enemyNumbers[currentEnemy]].Hp = 0;
                }

              //  WriteColor("write", allPokemon[enemyNumbers[currentEnemy]].Hp + " Hp", "red");
               // Console.ReadLine();



                
                // checks if you lost or won
                if (allPokemon[enemyNumbers[currentEnemy]].Hp <= 0f)
                {
                    
                    if (currentEnemy < 3)
                    {
                        Console.WriteLine("jsutdied is true now hopefully");
                        currentEnemy++;
                        justDied = true;
                    }
                    else
                    {
                        Console.WriteLine(currentEnemy);
                        WriteColor("line", "!!! YOU WON !!!", "green");
                        fighting = false;
                    }
                }
                else if (allPokemon[playerPokemons[usingPok]].Hp <= 0)
                {
                    if (allPokemon[playerPokemons[0]].Hp <= 0)
                    {
                        if (allPokemon[playerPokemons[1]].Hp <= 0)
                        {
                            if (allPokemon[playerPokemons[2]].Hp <= 0)
                            {
                                Console.Clear();
                                WriteColor("line", "!!! YOU LOST !!!", "red");
                                break;
                            }
                        }
                    }

                    ChooseAnotherPokemon();
                }
                
            }

            WriteColor("line", "Restart the program if you wish to play again!", "white");
        }




    }
}
