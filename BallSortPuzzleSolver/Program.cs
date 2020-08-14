
using System;

namespace BallSortPuzzleSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            #region char definition
            char a = 'a';
            char b = 'b';
            char c = 'c';
            char d = 'd';

            char e = 'e';
            char f = 'f';
            char g = 'g';
            char h = 'h';

            char i = 'i';
            char j = 'j';
            char k = 'k';
            char l = 'l';

            char lightGreen = a;
            char gray = b;
            char orange = c;
            char yellow = d;

            char red = e;
            char purple = f;
            char khaki = g;
            char lightBlue = h;

            char pink = i;
            char brown = j;
            char darkBlue = k;
            char darkGreen = l;

            char empty = '\0';
            #endregion

            ColorPalet colors = new ColorPalet(sourceC: ConsoleColor.Gray, destinationC: ConsoleColor.White);

            colors.Add(lightGreen, ConsoleColor.Green);
            colors.Add(gray, ConsoleColor.DarkGray);
            colors.Add(orange, ConsoleColor.DarkYellow);
            colors.Add(yellow, ConsoleColor.Yellow);
            colors.Add(red, ConsoleColor.Red);
            colors.Add(purple, ConsoleColor.DarkMagenta);
            colors.Add(khaki, ConsoleColor.DarkCyan);
            colors.Add(lightBlue, ConsoleColor.Cyan);
            colors.Add(pink, ConsoleColor.Magenta);
            colors.Add(brown, ConsoleColor.DarkRed);
            colors.Add(darkBlue, ConsoleColor.DarkBlue);
            colors.Add(darkGreen, ConsoleColor.DarkGreen);


            Colum[] cols0 = new Colum[]
            {
                new Colum(),
                new Colum(),
                new Colum(),
                new Colum(),

                new Colum(),
                new Colum(),
                new Colum(),
                new Colum(),

                new Colum(),
                new Colum(),
                new Colum(),
                new Colum(),

                new Colum(),
                new Colum()


};
            Colum[] cols1 = new Colum[]
            {
                new Colum(c,b,a,a),
                new Colum(c,b,c,b),
                new Colum(a,c,b,a),
                new Colum(),
                new Colum()
            };
            Colum[] cols2 = new Colum[]
            {
                new Colum(a,a,a,b),
                new Colum(b,b,b,a),
                new Colum()
            };
            Colum[] cols3 = new Colum[]
{
                new Colum(a,a,a,empty),
                new Colum(b,b,b,b),
                new Colum(a,empty,empty,empty)
};

            Colum[] cols4 = new Colum[]
{
                new Colum(yellow,orange,gray,lightGreen),
                new Colum(lightBlue,khaki,purple,red),
                new Colum(purple,lightGreen,pink,khaki),
                new Colum(brown,red,pink,yellow),

                new Colum(purple,brown,darkBlue,khaki),
                new Colum(yellow,purple,gray,khaki),
                new Colum(darkGreen,lightBlue,gray,orange),
                new Colum(pink,lightBlue,darkGreen,red),

                new Colum(lightGreen,lightBlue,darkBlue,darkBlue),
                new Colum(orange,pink,brown,darkGreen),
                new Colum(orange,yellow,lightGreen,gray),
                new Colum(darkBlue,darkGreen,brown,red),

                new Colum(),
                new Colum()


};

            Colum[] cols5 = new Colum[]
{
                new Colum(gray,brown,orange,lightBlue),
                new Colum(purple,lightGreen,yellow,gray),
                new Colum(lightBlue,pink,khaki,orange),
                new Colum(yellow,red,yellow,darkBlue),

                new Colum(yellow,orange,purple,brown),
                new Colum(darkGreen,khaki,lightGreen,darkGreen),
                new Colum(darkBlue,red,darkBlue,khaki),
                new Colum(red,brown,lightGreen,brown),

                new Colum(purple,lightBlue,lightGreen,pink),
                new Colum(pink,orange,khaki,purple),
                new Colum(darkGreen,darkGreen,pink,gray),
                new Colum(darkBlue,lightBlue,red,gray),

                new Colum(),
                new Colum()


};



            PuzzleState pState1 = new PuzzleState(cols1);
            PuzzleState pState2 = new PuzzleState(cols2);

            PuzzleGraph pGraph1 = new PuzzleGraph(pState1);
            PuzzleGraph pGraph2 = new PuzzleGraph(pState2);
            PuzzleGraph lvl107 = new PuzzleGraph(new PuzzleState(cols4));
            PuzzleGraph lvl109 = new PuzzleGraph(new PuzzleState(cols5));

            lvl107.Solve(colors);

        }
    }
}
