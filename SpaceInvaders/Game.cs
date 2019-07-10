using System;
using System.Collections.Generic;
using System.Threading;

namespace SpaceInvaders
{
    class Game
    {
        static int FrameCount = 0;
        static void Main(string[] args)
        {
            //RenderWelcomeScreen();
            var gameState = new GameState();

            while (true)
            {
                var initialTimeStamp = DateTime.Now;

                // handles the updated gamestate
                var state = HandleFrame(gameState);
                if (state.CheckGameOver())
                {
                    RenderGameOverScreen(state);
                    var key = Console.ReadKey(true).Key;

                    if (key == ConsoleKey.Q)
                    {
                        break;
                    }
                    else
                    {
                        state.EscapedInvaderCount = 0;
                        state.GameScore = 0;
                        state.Hero = new Hero(40, 32);
                        state.Invaders = new List<Invader>();
                        state.Bullets = new List<Bullet>();
                    }
                }

                //Draws State to console
                Render(state);

                gameState = state;

                //Extra sleep time to maintain uniform speed
                int napTime = GetNapTime(initialTimeStamp);
                FrameCount++;
                Thread.Sleep(napTime);
            }
        }

        static GameState HandleFrame(GameState state)
        {
            state.GetKeyStrokes();
            state.UpdateBulletLocation();

            if (FrameCount % 10 == 0)
            {
                state.UpdateInvaderLocation();
            }
            if (FrameCount % 60 == 0)
            {
                state.GenerateInvader();
            }
            return state;
        }

        static void Render(GameState state)
        {
            var board = new GameBoard();

            board.SetBoardSize(80, 35);
            board.ClearScreen();
            board.RenderHero(state.Hero);
            board.RenderInvaders(state.Invaders);
            board.RenderBullets(state.Bullets);
            board.DisplayGameScore(state.GameScore);
            board.DisplayEscapedInvaderCount(state.EscapedInvaderCount);
            board.HideCursor();
        }

        //time for the thread to sleep to maintain the game speed. 
        static int GetNapTime(DateTime initialTime)
        {
            var finalTimeStamp = DateTime.Now;
            var timeDifference = (finalTimeStamp - initialTime).TotalMilliseconds;
            int naptime = 0;
            if (timeDifference < 33.3)
            {
                naptime = (int)(33.3 - timeDifference);
            }
            return naptime > 0 ? naptime : 0;
        }
        static void RenderGameOverScreen(GameState state)
        {
            Console.Clear();
            Console.SetCursorPosition(30, 14);
            Console.Write("Game Over");
            Console.SetCursorPosition(28, 20);
            Console.Write(String.Format("Your Score: {0}", state.GameScore));
            Console.SetCursorPosition(15, 32);
            Console.Write("Press any key to play again. Press Q to quit the game.");
        }

        static void RenderWelcomeScreen()
        {
            var welcomeScreen = new WelcomeScreen();
            welcomeScreen.RenderWelcomeScreen();
        }
    }
}
