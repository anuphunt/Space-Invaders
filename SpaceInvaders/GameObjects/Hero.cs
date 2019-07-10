using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceInvaders
{
    public class Hero: GameObjects
    {
        public char Symbol { get; set; }
        public Hero(int x, int y) : base(x, y)
        {
            Symbol = '$';
        }
    }
}
