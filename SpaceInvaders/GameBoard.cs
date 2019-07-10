using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceInvaders
{
    public class GameBoard
    {
        public void SetBoardSize(int width, int height)
        {
            Console.SetWindowSize(width, height);
        }

        public void ClearScreen()
        {
            Console.Clear();
        }

        public void RenderHero(Hero hero)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if(hero.PositionX < 0)
            {
                hero.PositionX = 0;
            }
            else if(hero.PositionX > 80)
            {
                hero.PositionX = 80;
            }
            else if(hero.PositionY < 0)
            {
                hero.PositionY = 0;
            }
            else if(hero.PositionY > 30)
            {
                hero.PositionY = 30;
            }
            Console.SetCursorPosition(hero.PositionX, hero.PositionY);
            Console.Write(hero.Symbol);
            Console.ResetColor();
        }

        public void RenderInvaders(List<Invader> invaders)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (invaders != null)
            {
                foreach (var invader in invaders)
                {
                    if (invader.PositionY == 30)
                    {
                        RemoveOutOfBoundInvader(invader);
                    }
                    else
                    {
                        Console.SetCursorPosition(invader.PositionX, invader.PositionY);
                        Console.Write(invader.Symbol);
                    }
                }
            }
            Console.ResetColor();
        }

        public void RenderBullets(List<Bullet> bullets)
        {
            if (bullets != null)
            {
                foreach (var bullet in bullets)
                {
                    if (bullet.PositionY == 0)
                    {
                        RemoveOutOfBoundBullet(bullet);
                    }
                    else
                    {
                        Console.SetCursorPosition(bullet.PositionX, bullet.PositionY);
                        Console.Write(bullet.Symbol);
                    }
                }
            }
        }

        private void RemoveOutOfBoundBullet(Bullet bullet)
        {
            if (bullet != null)
            {
                Console.SetCursorPosition(bullet.PositionX, bullet.PositionY);
                Console.Write(' ');
            }
        }

        private void RemoveOutOfBoundInvader(Invader invader)
        {
            if (invader != null)
            {
                Console.SetCursorPosition(invader.PositionX, invader.PositionY);
                Console.Write(' ');
            }
        }

        public void DisplayGameScore(int gameScore)
        {
            Console.SetCursorPosition(5, 32);
            Console.Write(String.Format("Game Score: {0}",gameScore));
        }

        public void DisplayEscapedInvaderCount(int escapedInvadersCount)
        {
            Console.SetCursorPosition(50, 32);
            Console.Write(String.Format("Escaped Invaders: {0}", escapedInvadersCount));
        }

        public void HideCursor()
        {
            Console.CursorVisible = false;
        }

    }
}
