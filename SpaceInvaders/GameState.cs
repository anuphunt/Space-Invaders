using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceInvadersV2
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
            Hero = new Hero(20, 20);
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
                Console.ReadKey(false);
                switch (key.Key)
                {
                    case ConsoleKey.W:
                        UpdateHeroPosition('W');
                        break;

                    case ConsoleKey.A:
                        UpdateHeroPosition('A');
                        break;

                    case ConsoleKey.S:
                        UpdateHeroPosition('S');
                        break;

                    case ConsoleKey.D:
                        UpdateHeroPosition('D');
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
            int x = random.Next(0, 40);
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
                }
            }
            Invaders = activeInvaders;
        }
        private void UpdateHeroPosition(char c)
        {
            switch (c)
            {
                case 'W':
                    if (Hero.PositionY != 0)
                    {
                        Hero.PositionY -= 1;
                    }
                    break;

                case 'A':
                    if (Hero.PositionX != 0)
                    {
                        Hero.PositionX -= 1;
                    }
                    break;

                case 'S':
                    if (Hero.PositionY != 30)
                    {
                        Hero.PositionY += 1;
                    }
                    break;

                case 'D':
                    if (Hero.PositionX != 80)
                    {
                        Hero.PositionX += 1;
                    }
                    break;
            }
        }
    }
}
