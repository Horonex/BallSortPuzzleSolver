using System;
using System.Collections.Generic;
using System.Text;

namespace BallSortPuzzleSolver
{
    class Colum
    {
        public char[] balls=new char[4];

        public Colum()
        {

        }
        public Colum(char i0, char i1, char i2, char i3)
        {
            balls[0] = i0;
            balls[1] = i1;
            balls[2] = i2;
            balls[3] = i3;
        }

        public Colum(Colum original)
        {
            for (int i = 0; i < balls.Length; i++)
            {
                balls[i] = original.balls[i];
            }
        }

        public override string ToString()
        {
            StringBuilder sBuilser = new StringBuilder();
            foreach (var item in balls)
            {
                if(item=='\0')
                {
                    sBuilser.Append(' ');
                }
                sBuilser.Append(item);
            }
            return sBuilser.ToString();
        }

        public char getTopChar()
        {
            for (int i = balls.Length-1; i >= 0; i--)
            {
                if (balls[i] != '\0')
                {
                    return balls[i];
                }
            }
            return '\0';
        }

        public void removeTopChar()
        {
            for (int i = balls.Length - 1; i >= 0; i--)
            {

                if (balls[i] != '\0')
                {
                    balls[i]='\0';
                    return;
                }
            }
        }

        public char takeTopChar()
        {
            var topChar = getTopChar();
            removeTopChar();
            return topChar;
        }

        public bool addChar(char c)
        {
            for (int i = 0; i < balls.Length; i++)
            {
                if (balls[i]=='\0')
                {
                    balls[i] = c;
                    return true;
                }
            }
            return false;
        }

        public bool CheckCompleted()
        {
            char c = balls[0];
            for (int i = 1; i < balls.Length; i++)
            {
                if (balls[i] != c) return false;
            }
            return true;
        }
        public bool OnlyOneCollor()
        {
            char c = balls[0];
            for (int i = 1; i < balls.Length; i++)
            {
                if (balls[i] != c && balls[i] !='\0') return false;
            }
            return true;
        }
        public bool IsEmplty()
        {
            return GetEmptySpaces() == 4;
        }

        public int GetTopCharDepth()
        {
            char top = getTopChar();
            int count = 0;
            for (int i = balls.Length - 1; i >= 0; i--)
            {
                if (balls[i] != '\0')
                {
                    if(balls[i]==top)
                    {
                        count++;
                    }
                    else
                    {
                        return count;
                    }
                   
                }
            }
            return count;
        }

        public int GetEmptySpaces()
        {
            int count = 0;
            for (int i = balls.Length-1; i >= 0; i--)
            {
                if (balls[i] == '\0')
                {
                    count++;
                }
            }
            return count;
        }

    }
}
