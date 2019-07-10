using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceInvadersV2
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
            Console.SetCursorPosition(hero.PositionX, hero.PositionY);
            Console.Write(hero.Symbol);
        }

        public void RenderInvaders(List<Invader> invaders)
        {
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
        public void HideCursor()
        {
            Console.CursorVisible = false;
        }

    }
}
