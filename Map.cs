using System;

namespace Sokoban
{
    internal class Field
    {
        public int[,] fieldArray = new int[10, 10];
        public Worker worker = new Worker(new Point(0,0));
        //----------------------------------------------------------------------------------------
        public Field()
        {

        }
        //----------------------------------------------------------------------------------------
        public void loadStage(string StageFile)
        {
            using(StreamReader sr = new StreamReader(StageFile))
            {
                string? position = sr.ReadLine();
                string[] pos = position!.Split(',');
                int index = 0;

                worker.Position.X = int.Parse(pos[0]);
                worker.Position.Y = int.Parse(pos[1]);

                while(!sr.EndOfStream)
                {
                    string? line = sr.ReadLine();

                    if(line is not null)
                    {
                        string[] data = line.Split(',');
                        int x = 0;

                        foreach(var value in data)
                        {
                            fieldArray[x++, index] = int.Parse(value) ;
                        }

                        index++;
                    }
                }
            }
        }
        //----------------------------------------------------------------------------------------
    }

    internal class Worker
    {
        public Point Position = new Point(0,0);
        public Direction MoveDirection { set; get; }

        public Worker(Point position) { this.Position = position; }
    }
}
