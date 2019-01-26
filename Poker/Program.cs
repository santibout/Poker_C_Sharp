using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            //no need to instantiate any other classes because deal cards inherits from deck which inherits from card
            // and drawCard is Static so no need to instantiate
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.SetWindowSize(65, 40);
            //Remove scroll bars by setting the buffer to the actual window size
            Console.BufferWidth = 65;
            Console.BufferHeight = 40;
            Console.Title = "Poker Game";
            DealCards d = new DealCards();
            bool quit = false;

            while (!quit)
            {
                d.Deal();

                char selection = ' ';
                while(!selection.Equals('Y') && (!selection.Equals('N')))
                {
                    Console.WriteLine("Play again? Y or N");
                    selection = Convert.ToChar(Console.ReadLine().ToUpper());

                    if(selection == 'Y')
                    {
                        quit = false;
                    }
                    else if(selection == 'N')
                    {
                        quit = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Selection.  Try Again");
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
