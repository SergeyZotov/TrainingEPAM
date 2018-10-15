using System;
using System.Collections.Generic;

namespace Task4
{
    sealed class Field : Objects
    {
        internal static int width;
        internal static int height;

        internal Tuple<int, int>[,] cells = new Tuple<int, int>[width , height];

        public Field(string width, string height, Player player, List<Enemies> enemies, 
            List<Obstacles> obstacles, List<Bonuses> bonuses) : 
            base(width, height)
        {
            if (X <= 0 || Y <= 0)
                throw new ArgumentException("Must be positive!");

            Width = X;
            Height = Y;
        }

        internal int Width { private set; get; }

        internal int Height { private set; get; }
    }
}
