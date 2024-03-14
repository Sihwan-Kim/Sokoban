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
        public bool loadStage(string StageFile)
        {
            bool result = true;
            try
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
                                fieldArray[x++, index] = int.Parse(value);
                            }

                            index++;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("This is the last stage.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }

            return result;
        }
        //----------------------------------------------------------------------------------------
    }

    internal class Worker
    {
        public Point Position = new Point(0,0);
        public Direction MoveDirection { set; get; }

        public Worker(Point position) { this.Position = position; }
    }

    internal class UndoInform
    {
        public Direction direction;
        public bool pushInform;

        public UndoInform(Direction direction, bool pushInform)
        {
            this.direction = direction;
            this.pushInform = pushInform;
        }
    }
}
