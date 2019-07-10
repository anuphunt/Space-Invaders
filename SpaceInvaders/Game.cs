using System;
using System.Collections.Generic;
using System.Threading;

namespace SpaceInvadersV2
{
    class Game
    {
        static int FrameCount = 0;
        static void Main(string[] args)
        {
            var gameState = new GameState();

            while (true)
            {
                var initialTimeStamp = DateTime.Now;

                // handles the updated gamestate
                var state = HandleFrame(gameState);

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

            if (FrameCount%4 == 0)
            {
                state.UpdateInvaderLocation();
            }
            if(FrameCount%50 == 0)
            {
                state.GenerateInvader();
            }

            var newState = new GameState();
            newState.Bullets = state.Bullets;
            newState.Invaders = state.Invaders;
            newState.EscapedInvaderCount = state.EscapedInvaderCount;
            newState.Hero = state.Hero;
            newState.GameScore = state.GameScore;

            return newState;
        }

        static void Render(GameState state)
        {
            var board = new GameBoard();

            board.SetBoardSize(40, 35);

            board.ClearScreen();
            board.RenderHero(state.Hero);
            board.RenderInvaders(state.Invaders);
            board.RenderBullets(state.Bullets);
            board.DisplayGameScore(state.GameScore);
             board.HideCursor();
        }

        //time for the thread to sleep to maintain the game speed. 
        static int GetNapTime(DateTime initialTime)
        {
            var finalTimeStamp = DateTime.Now;
            var timeDifference = (finalTimeStamp - initialTime).TotalMilliseconds;
            int naptime = 0;
            if (timeDifference < 160)
            {
                naptime = (int)(100 - timeDifference);
            }
            return naptime > 0 ? naptime : 0;
        }
    }
}
