using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SpaceInvaders
{
    public class WelcomeScreen
    {
        public void IntroduceFleet()
        {
            Console.Clear();
            string year = "YEAR: 2210";
            string location = "LOCATION: UNITED SOL FEDERATION COMBINED FLEET";
            string intro1 = "Earth's widespread galactic colonies have been obliterated by the relentless invaders from distant planet Atrox.";
            string intro2 = "They have invaded thousands of colonies and slaughtered billions of people.";
            string intro3 = "The time has come to take a last stand against the Atrox Invaders.";


            Console.SetCursorPosition(5, 8);
            for (int i = 0; i < year.Length; i++)
            {
                Console.Write(year[i]);
                Thread.Sleep(60);
            }

            Console.SetCursorPosition(5, 10);
            for (int i = 0; i < location.Length; i++)
            {
                Console.Write(location[i]);
                Thread.Sleep(60);
            }

            Console.SetCursorPosition(5, 12);
            for (int i = 0; i < intro1.Length; i++)
            {
                Console.Write(intro1[i]);
                Thread.Sleep(60);
            }

            Console.SetCursorPosition(5, 14);
            for (int i = 0; i < intro2.Length; i++)
            {
                Console.Write(intro2[i]);
                Thread.Sleep(60);
            }

            Console.SetCursorPosition(5, 16);
            for (int i = 0; i < intro3.Length; i++)
            {
                Console.Write(intro3[i]);
                Thread.Sleep(60);
            }
            Thread.Sleep(1000);
        }

        public void ConversationWithCaptain()
        {
            Console.Clear();

            string playerName = "";
            string intro1 = "CAPTAIN: Greetings, Fighter Pilot. This is Captain Holt. I am the Commander of the Fleet.";
            string intro2 = "CAPTAIN: What's your name?";
            string intro4 = "CAPTAIN: I have a new assignment for you. ";
            string intro5 = "CAPTAIN: We have detected a new fleet of Atrox invaders approaching towards Earth.";
            string intro6 = "CAPTAIN: Your job is to defend our home planet and kill the invaders.";

            Console.SetCursorPosition(5, 8);
            for (int i = 0; i < intro1.Length; i++)
            {
                Console.Write(intro1[i]);
                Thread.Sleep(60);
            }

            Console.SetCursorPosition(5, 10);
            for (int i = 0; i < intro2.Length; i++)
            {
                Console.Write(intro2[i]);
                Thread.Sleep(60);
            }
            Console.SetCursorPosition(5, 11);
            playerName = Console.ReadLine();
            string intro3 = "CAPTAIN: Welcome to our Battle Fortress, " + playerName + "!" + " Thank you for joining us.";

            Console.SetCursorPosition(5, 13);
            for (int i = 0; i < intro3.Length; i++)
            {
                Console.Write(intro3[i]);
                Thread.Sleep(60);
            }

            Console.SetCursorPosition(5, 15);
            for (int i = 0; i < intro4.Length; i++)
            {
                Console.Write(intro4[i]);
                Thread.Sleep(60);
            }

            Console.SetCursorPosition(5, 17);
            for (int i = 0; i < intro5.Length; i++)
            {
                Console.Write(intro5[i]);
                Thread.Sleep(60);
            }

            Console.SetCursorPosition(5, 19);
            for (int i = 0; i < intro6.Length; i++)
            {
                Console.Write(intro6[i]);
                Thread.Sleep(60);
            }
            Thread.Sleep(1000);
            Console.SetCursorPosition(5, 23);
            Console.WriteLine("Press any key if you are ready.");
            Console.ReadKey();
        }

        public void Instructions()
        {
            Console.Clear();
            Console.SetCursorPosition(5, 5);
            Console.WriteLine("INSTRUCTIONS");
            Console.SetCursorPosition(5, 8);
            Console.WriteLine("CONTROLS:");
            Console.SetCursorPosition(5, 10);
            Console.WriteLine("Move Around: WASD");
            Console.SetCursorPosition(5, 11);
            Console.WriteLine("Fire Bullets: Spacebar");
            Console.SetCursorPosition(5, 12);
            Console.WriteLine("The game will be over if 5 Enemies escaped.");
            Console.SetCursorPosition(5, 15);
            Console.WriteLine("Press any key to start game.");
            Console.ReadKey();
        }

        public void RenderWelcomeScreen()
        {
            IntroduceFleet();
            ConversationWithCaptain();
            Instructions();
        }
    }
}
