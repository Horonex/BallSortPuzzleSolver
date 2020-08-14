using System;
using System.Collections.Generic;
using System.Text;

namespace BallSortPuzzleSolver
{
    class ColorPalet
    {
        public static ColorPalet defaultColors = new ColorPalet();

        Dictionary<char, ConsoleColor> colorSceme;

        public ConsoleColor sourceColor;
        public ConsoleColor destinationColor;
        public ConsoleColor defaultBG;
        public ConsoleColor defaultText;



        public ColorPalet(ConsoleColor sourceC = ConsoleColor.DarkRed, ConsoleColor destinationC = ConsoleColor.Red, ConsoleColor defaultBG = ConsoleColor.Black, ConsoleColor defaultText = ConsoleColor.White)
        {
            colorSceme = new Dictionary<char, ConsoleColor>();
            sourceColor = sourceC;
            destinationColor = destinationC;
            this.defaultBG = defaultBG;
            this.defaultText = defaultText;
        }

        public void Add(char c, ConsoleColor color)
        {
            colorSceme.Add(c, color);
        }

        public ConsoleColor Get(char c)
        {
            if (colorSceme.ContainsKey(c))
                return colorSceme[c];
            else return defaultText;
        }
    }
}
