using System;
using System.Collections.Generic;
using System.Text;

namespace BallSortPuzzleSolver
{
    class PuzzleState
    {
        Colum[] colums;
        List<string> parents=new List<string>();
        //List<string> children;

        public PuzzleState(Colum[] cols, string parent = null)
        {
            colums = cols;
            if(parent!=null)
            {
                parents.Add(parent);
            }
        }

        public PuzzleState(PuzzleState parentState,int SourceIndex,int destinationIndex)
        {
            colums = new Colum[parentState.colums.Length];
            for (int i = 0; i < colums.Length; i++)
            {
                colums[i] = new Colum(parentState.colums[i]);
            }
            colums[destinationIndex].addChar(colums[SourceIndex].takeTopChar());
        }

        public void AddParent(string parent)
        {
            parents.Add(parent);
        }

        public override string ToString()
        {
            StringBuilder sBuilder = new StringBuilder();
            foreach (var item in colums)
            {
                
                sBuilder.Append(item.ToString());
                sBuilder.Append('\n');
            }
            return sBuilder.ToString();
        }

        public List<PuzzleState> generateChildren()
        {
           
            List<PuzzleState> children = new List<PuzzleState>();
            for (int i = 0; i < colums.Length; i++)
            {
                #region skip
                //colum empty
                if (colums[i].balls[0] == '\0') continue;
                #endregion
                for (int j = 0; j < colums.Length; j++)
                {
                    #region skip
                    //cant move onto itself
                    if (i == j) continue;
                    //colum full
                    if (colums[j].balls[3] != '\0') continue;
                    //useless move
                    if (colums[i].OnlyOneCollor() && colums[j].IsEmplty()) continue;
                    //"jugling"
                    if (colums[i].GetTopCharDepth() > colums[j].GetEmptySpaces()) continue;

                    #endregion

                    if (colums[i].getTopChar() == colums[j].getTopChar()|| colums[j].balls[0]=='\0')
                    {
                        children.Add(new PuzzleState(this, i, j));                        
                    }

                }
            }
            return children;
        }

        public bool checkForWin()
        {
            foreach (var col in colums)
            {
                if(!col.CheckCompleted())
                {
                    return false;
                }
                
            }
            return true;
        }

        public void Print()
        {
            for (int i = colums[0].balls.Length-1; i >=0 ; i--)
            {
                foreach (var col in colums)
                {
                    if(col.balls[i]=='\0')
                    {
                        Console.Write("  ");                   

                    }
                    else
                    {
                    Console.Write(col.balls[i]+" ");

                    }
                }
                Console.WriteLine();
            }
        }
        public void Print(PuzzleState previousState)
        {
            for (int i = colums[0].balls.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < colums.Length; j++)
                {
                    bool changed = colums[j].balls[i] != previousState.colums[j].balls[i];

                    if (colums[j].balls[i] == '\0')
                    {
                        if(changed)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                        }

                        Console.Write(" ");

                    }
                    else
                    {
                        if (changed)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                        }
                        Console.Write(colums[j].balls[i]);

                    }
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        public void PrintFancy(PuzzleState previousState,ColorPalet palet = null)
        {
            if (palet == null) palet = ColorPalet.defaultColors;
            int sourceIndex=0;
            int destinationIndex=0;
            for (int i = colums[0].balls.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < colums.Length; j++)
                {
                    bool changed = colums[j].balls[i] != previousState.colums[j].balls[i];

                    if (colums[j].balls[i] == '\0')
                    {
                        if (changed)
                        {
                            destinationIndex = j;
                            Console.BackgroundColor = palet.destinationColor;
                        }

                        Console.Write(" ");

                    }
                    else
                    {
                        if (changed)
                        {
                            sourceIndex = j;
                            Console.BackgroundColor = palet.sourceColor;
                        }
                        Console.ForegroundColor = palet.Get(colums[j].balls[i]);
                        Console.Write(colums[j].balls[i]);

                    }
                    Console.BackgroundColor = palet.defaultBG;
                    Console.ForegroundColor = palet.defaultText;
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
