using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceInvaders
{
    public class GameObjects
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public GameObjects(int x, int y)
        {
            PositionX = x;
            PositionY = y;
        }
    }
}
