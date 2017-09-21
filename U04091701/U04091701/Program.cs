using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U04091701
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] stack = new string[52];
            Random r = new Random();
            bool[] choice = new bool[52];
            int k = 0;
            bool done = false;
            bool moreCard = true;
            int points = 0;
            int pointSum = 0;

            //If used
            for (int i = 0; i < 52; i++)
            {
                choice[i] = true;
            }

            //Cards value
            for (int i = 0; i < 13; i++)
            {
                stack[i] = "Hjärter " + (i + 1);
            }

            for(int i = 13; i < 26; i++)
            {
                stack[i] = "Klöver " + (i - 12);
            }

            for (int i = 26; i < 39; i++)
            {
                stack[i] = "Ruter " + (i - 25);
            }

            for (int i = 39; i < 52; i++)
            {
                stack[i] = "Spader " + (i - 38);
            }

            //picks a card depending on answer
            
            while (moreCard)
            {
                done = false;
                Console.WriteLine("Vill du dra ett kort?");
                string pick = Console.ReadLine().ToLower();

                if(pick == "ja")
                {
                    moreCard = true;
                }
                else if(pick == "nej")
                {
                    moreCard = false;
                }

                if (moreCard)
                {
                    while (!done)
                    {
                        k = r.Next(0, 52);
                        if (choice[k])
                        {
                            Console.Write("Du drog kortet " +stack[k]);
                            choice[k] = false;


                            string[] cardsDrawn = stack[k].Split(' ');
                            points = Convert.ToInt32(cardsDrawn[1]);
                            pointSum += points;

                            if(pointSum > 21)
                            {
                                Console.WriteLine(", du förlorade! Du fick mer än 21");
                                done = true;
                                moreCard = false;
                            }
                            else if(pointSum == 21)
                            {
                                Console.WriteLine(". Grattis du fick 21 och vann!");
                                Console.ReadLine();
                                return;
                            }
                            else
                            {
                                Console.WriteLine(" och din poängsumma är " + pointSum);

                                done = true;
                            }
                                
                        }
                    }
                }
            }
        }

    }
}
