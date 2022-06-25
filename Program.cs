using System;
using System.Collections.Generic;
using System.Linq;

namespace Treasure_Hunt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> chest = Console.ReadLine().Split('|').ToList();
            List<string> command = Console.ReadLine().Split().ToList();

            while (command[0] != "Yohoho!")
            {
                string action = command[0];

                switch (action)
                {
                    case "Loot":
                        for (int i = 0; i < command.Count - 1; i++)
                        {
                            if (chest.Contains(command[i + 1]))
                            {
                                continue;
                            }
                            else
                            {
                                chest.Insert(0, command[i + 1]);
                            }
                        }
                        break;
                    case "Drop":
                        if (Convert.ToInt32(command[1]) < 0 || Convert.ToInt32(command[1]) > chest.Count - 1)
                        {
                            break;
                        }

                        string temp = chest[Convert.ToInt32(command[1])];

                        if (chest.Contains(temp))
                        {
                            chest.Remove(temp);
                            chest.Add(temp);
                        }
                        break;

                    case "Steal":
                        int index = Convert.ToInt32(command[1]);
                        List<string> stealingItems = new List<string>();

                        if (index < 0)
                        {
                            break;
                        }

                        if (index >= chest.Count)
                        {
                            for (int i = 0; i <= chest.Count - 1; i++)
                            {
                                stealingItems.Add(chest[chest.Count - 1 - i]);
                            }
                            stealingItems.Reverse();
                            Console.WriteLine(string.Join(", ", stealingItems));
                            chest.RemoveRange(0, chest.Count);
                            break;
                        }

                        for (int i = 0; i < index; i++)
                        {
                            stealingItems.Add(chest[chest.Count - 1]);
                            chest.RemoveAt(chest.Count - 1);
                        }
                        stealingItems.Reverse();
                        Console.WriteLine(string.Join(", ", stealingItems));

                        break;

                }

                command = Console.ReadLine().Split().ToList();
            }

            if (chest.Count == 0)
            {
                Console.WriteLine("Failed treasure hunt.");
            }
            else
            {
                double sum = 0;

                for (int i = 0; i < chest.Count; i++)
                {
                    sum += chest[i].Count();
                }
                sum /= chest.Count;
                Console.WriteLine($"Average treasure gain: {sum:f2} pirate credits.");
            }
        }
    }
}
