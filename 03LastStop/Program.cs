using System;
using System.Collections.Generic;
using System.Linq;

namespace _03LastStop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> paintings = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input = Console.ReadLine();

            while (input != "END")
            {
                List<string> commands = input.Split().ToList();

                if (commands[0] == "Insert")
                {
                    int place = int.Parse(commands[1]) + 1;
                    int paintingNumber = int.Parse(commands[2]);
                    if (place <= paintings.Count-1)
                    {
                        paintings.Insert(place, paintingNumber);
                    }
                }
                else if (commands[0] == "Hide")
                {
                    int paintingNumber = int.Parse(commands[1]);
                    bool doesExist = false;

                    for (int i = 0; i < paintings.Count; i++)
                    {
                        if (paintings[i] == paintingNumber)
                        {
                            doesExist = true;
                            break;
                        }
                    }

                    if (doesExist)
                    {
                        paintings.Remove(paintingNumber);
                    }
                }
                else if (commands[0] == "Reverse")
                {
                    paintings.Reverse();
                }
                else if (commands[0] == "Change")
                {
                    int paintingNumber = int.Parse(commands[1]);
                    int paintingNumberChanged = int.Parse(commands[2]);
                    bool doesExist = false;
                    int index = 0;

                    for (int i = 0; i < paintings.Count; i++)
                    {
                        if (paintings[i] == paintingNumber)
                        {
                            doesExist = true;
                            index = i;
                            break;
                        }
                    }

                    if (doesExist)
                    {
                        paintings[index] = paintingNumberChanged;
                    }
                }
                else if (commands[0] == "Switch")
                {
                    int firstPaintingNumber = int.Parse(commands[1]);
                    int secondPaintingNumber = int.Parse(commands[2]);
                    bool doesExist = false;
                    int indexFirst = 0;
                    int indexSecond = 0;

                    for (int i = 0; i < paintings.Count; i++)
                    {
                        if (paintings[i] == firstPaintingNumber)
                        {
                            doesExist = true;
                            indexFirst = i;
                            break;
                        }
                    }
                    for (int j = 0; j < paintings.Count; j++)
                    {
                        if (paintings[j] == secondPaintingNumber)
                        {
                            doesExist = true;
                            indexSecond = j;
                            break;
                        }
                    }

                    if (doesExist)
                    {
                        paintings[indexFirst] = secondPaintingNumber;
                        paintings[indexSecond] = firstPaintingNumber;
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var item in paintings)
            {
                //if (item == paintings[paintings.Count-1])
                //{
                //    Console.Write($"{item}");
                //    break;
                //}
                Console.Write($"{item} ");
                
            }
            Console.WriteLine();
        }
    }
}
