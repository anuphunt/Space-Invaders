using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceInvaders
{
    public class GameState
    {
        public Hero Hero { get; set; }
        public List<Invader> Invaders { get; set; }
        public List<Bullet> Bullets { get; set; }
        public int GameScore { get; set; }
        public int EscapedInvaderCount { get; set; }

        public GameState()
        {
            Hero = new Hero(38, 30);
            Bullets = new List<Bullet>();
            Invaders = new List<Invader>()
            {
                new Invader(20, 0)
            };
        }

        public void GetKeyStrokes()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.W:
                        Hero.PositionY -= 1;
                        break;

                    case ConsoleKey.A:
                        Hero.PositionX -= 1;
                        break;

                    case ConsoleKey.S:
                        Hero.PositionY += 1;
                        break;

                    case ConsoleKey.D:
                        Hero.PositionX += 1;
                        break;

                    case ConsoleKey.Spacebar:
                        Bullets.Add(new Bullet(Hero.PositionX, Hero.PositionY));
                        break;
                }
            }
        }

        public void GenerateInvader()
        {
            Random random = new Random();
            int x = random.Next(10, 70);
            var invader = new Invader(x, 0);
            Invaders.Add(invader);
        }

        public void UpdateBulletLocation()
        {
            var activeBullets = new List<Bullet>();

            if (Bullets != null)
            {
                foreach (var bullet in Bullets)
                {
                    if (!CheckKill(bullet))
                    {
                        if (bullet.PositionY != 0)
                        {
                            bullet.PositionY -= 1;
                            activeBullets.Add(bullet);
                        }
                    };
                }
            }
            Bullets = activeBullets;
        }

        private bool CheckKill(Bullet bullet)
        {
            if (bullet != null)
            {
                var killedInvader = Invaders.Find(x => x.PositionX == bullet.PositionX && x.PositionY == bullet.PositionY);
                if (killedInvader != null)
                {
                    Invaders.Remove(killedInvader);
                    GameScore++;
                    return true;
                }
                return false;
            }
            return false;
        }

        public void UpdateInvaderLocation()
        {
            var activeInvaders = new List<Invader>();

            if (Invaders != null)
            {
                foreach (var invader in Invaders)
                {
                    if (invader.PositionY != 30)
                    {
                        invader.PositionY += 1;
                        activeInvaders.Add(invader);
                    }
                    else if (invader.PositionY == 30)
                    {
                        EscapedInvaderCount++;
                    }
                }
            }
            Invaders = activeInvaders;
        }

        public bool CheckGameOver()
        {
            if (EscapedInvaderCount >= 5)
                return true;
            else
                return false;
        }
    }
}

