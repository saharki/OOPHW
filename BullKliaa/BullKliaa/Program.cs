
//Game.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace BullKliaa
{
    class Game
    {
        Choice[] choice;
        Choice computerChoice;
        public Game()
        {
            choice = new Choice[5040];
            int x = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (j != i)
                    {
                        for (int k = 0; k < 10; k++)
                        {
                            if (k != j && k != i)
                            {
                                for (int l = 0; l < 10; l++)
                                {
                                    if (l != k && l != j && l != i)
                                    {
                                        int[] temp = new int[] { i, j, k, l };
                                        choice[x] = new Choice(temp);
                                        x++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            computerChoice = choice[RandomNumber(0, choice.Length - 1)];
        }
        void filter(int[] arr, int bulls, int kliot)
        {
            int count = 0;
            int b, k;
            Choice[] temp_choice = new Choice[5040];
            for (int i = 0; i < choice.Length; i++)
            {
                b = 0;
                k = 0;
                choice[i].test_choice(arr, out b, out k);
                if (b == bulls && k == kliot)
                {
                    temp_choice[count] = choice[i];
                    count++;
                }
            }
            Array.Resize(ref temp_choice, count);
            choice = temp_choice;
            temp_choice = null;
        }
        int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        int make_a_choice()
        {
            int b, k;
            Choice guess;
            guess = choice[RandomNumber(0, choice.Length - 1)];
            Console.Write("My guess is: ");
            guess.print_choice();
            Console.Write("How many bulls? ");
            b = Convert.ToInt32(Console.ReadLine());
            Console.Write("How many kliot? ");
            k = Convert.ToInt32(Console.ReadLine());
            filter(guess.get_choice(), b, k);
            if (b == 4) return 1;
            else return 0;
        }
        void play()
        {
            string userGuess;
            int b, k;
            while (true)
            {
                Console.Write("Your guess is: ");
                userGuess = Console.ReadLine();
                //computerChoice.test_choice(new int[] {                Convert.ToInt32(userGuess[0]), Convert.ToInt32(userGuess[1]),Convert.ToInt32(userGuess[2]), Convert.ToInt32(userGuess[3]) }, out b, out k);
            computerChoice.test_choice(new int[] { userGuess[0]-48,
userGuess[1]-48, userGuess[2]-48, userGuess[3]-48 }, out b, out k);
            Console.WriteLine("You guess, {0} bulls and {1} kliot", b, k);
            if (b == 4)
            {
                Console.WriteLine("You WON!!");
                break;
            }
            if (make_a_choice() == 1)
            {
                Console.WriteLine("Computer WON!!");
                break;
            }
        }
        Console.WriteLine("Game Over...");
}
    static void Main(string[] args)
    {
        Game g = new Game();
        g.play();
        Console.ReadLine();
    }
}

    class Choice
    {
        int[] value;
        public Choice(int[] ivalue)
        {
            value = ivalue;
        }
        public void test_choice(int[] pguess, out int bulls, out int kliot)
        {
            bulls = 0;
            kliot = 0;
            for (int i = 0; i < 4; i++)
            {
                if (pguess[i] == value[i]) bulls++;
                else
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (pguess[i] == value[j]) kliot++;
                    }
                }
            }
        }
        public void print_choice()
        {
            Console.WriteLine("{0}{1}{2}{3}", value[0], value[1], value[2], value[3]);
        }
        public int[] get_choice()
        {
            return value;
        }
    }
}
