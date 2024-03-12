using System;


namespace Sokoban
{
    internal class Field
    {
        public int[,] fieldArray = new int[10, 10]
        {
            { 0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,8,8,8,0,0,0,0 },
            { 0,0,0,8,1,8,0,0,0,0 },
            { 0,0,0,8,0,8,8,8,8,0 },
            { 0,8,8,8,2,0,2,1,8,0 },
            { 0,8,1,0,2,0,8,8,8,0 },
            { 0,8,8,8,8,2,8,0,0,0 },
            { 0,0,0,0,8,1,8,0,0,0 },
            { 0,0,0,0,8,8,8,0,0,0 },
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
