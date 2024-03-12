using System;


namespace Sokoban
{
    internal class Field
    {
        public int[,] fieldArray = new int[10, 10]
        {
            { 0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,4,4,4,0,0,0,0 },
            { 0,0,0,4,1,4,0,0,0,0 },
            { 0,0,0,4,0,4,4,4,4,0 },
            { 0,4,4,4,2,0,2,1,4,0 },
            { 0,4,1,0,2,0,4,4,4,0 },
            { 0,4,4,4,4,2,4,0,0,0 },
            { 0,0,0,0,4,1,4,0,0,0 },
            { 0,0,0,0,4,4,4,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0 }
        };

        public Worker worker = new Worker(new Point(5,5));

        public Field()
        {
        }

        public void loadField(int StageNumber)
        {
        }
    }

    internal class Worker
    {
        public Point Position = new Point(5, 5);
        public Direction MoveDirection { set; get; }

        public Worker(Point position) { this.Position = position; }
    }
}
