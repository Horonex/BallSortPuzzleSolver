using System;
using System.Collections.Generic;
using System.Text;

namespace BallSortPuzzleSolver
{
    class PuzzleGraph
    {
        PuzzleState startingState;
        HashSet<string> visitedStates = new HashSet<string>();

        public PuzzleGraph(PuzzleState initalState)
        {
            startingState = initalState;
        }

        public void Solve()
        {
            Console.WriteLine(CheckChildrenNonRecursive(startingState));
            //Console.WriteLine(CheckChildren(startingState));
            //startingState.Print();
        }
        public void Solve(ColorPalet colors)
        {

            Console.WriteLine(CheckChildrenNonRecursive(startingState,colors));
        }

        public bool CheckChildren(PuzzleState state)
        {
            if(state.checkForWin())
            {
                return true;
            }    
            List<PuzzleState> children = state.generateChildren();
            if (children.Count == 0)
            {
                return false;
            }
            foreach (var child in children)
            {
                if (visitedStates.Contains(child.ToString()))
                {
                    continue;
                }
                visitedStates.Add(child.ToString());

                if (CheckChildren(child))
                {
                    child.Print();
                    return true;
                }
            }
            return false;
        }

        public bool CheckChildrenNonRecursive(PuzzleState state, ColorPalet colors=null)
        {
            Stack<PuzzleState> stack = new Stack<PuzzleState>();
            stack.Push(state);

            while(stack.Count>0)
            {
                var curr = stack.Peek();
                if(curr.checkForWin())
                {
                    break;
                }
                List<PuzzleState> children = curr.generateChildren();
                if(children.Count>0)
                {
                    bool allVisited = true;
                    foreach (var child in children)
                    {
                        if(visitedStates.Contains(child.ToString()))
                        {
                            //skip
                        }
                        else
                        {
                            stack.Push(child);
                            visitedStates.Add(child.ToString());
                            allVisited = false;
                            break;
                        }
                    }
                    if(allVisited)
                    {
                        stack.Pop();
                    }
                }
                else
                {
                    //dead
                    stack.Pop();
                }
                

            }

            Console.WriteLine(stack.Count+" Steps");

            var prev = stack.Pop();

            while(stack.Count>0)
            {
                var curr = stack.Pop();
                curr.PrintFancy(prev,colors);
                prev =curr;

                Console.WriteLine();
            }

            return true;
        }

    }
}
