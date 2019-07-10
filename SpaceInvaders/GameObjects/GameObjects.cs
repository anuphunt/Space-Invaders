using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceInvadersV2
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
