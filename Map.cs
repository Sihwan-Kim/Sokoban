using System;


namespace Sokoban
{
    internal class Field
    {
        public readonly Bitmap[] icons = {Properties.Resources.Empty, Properties.Resources.brick, Properties.Resources.Box, Properties.Resources.target, Properties.Resources.Box, Properties.Resources.Empty};

        public int[,] fieldArray = new int[10, 10]
        {
        { 0,0,1,1,1,0,0,0,0,0 },
        { 0,0,1,3,1,0,0,0,0,0 },
        { 0,0,1,0,1,1,1,1,0,0 },
        { 1,1,1,2,0,2,3,1,0,0 },
        { 1,3,0,2,0,1,1,1,0,0 },
        { 1,1,1,1,2,1,0,0,0,0 },
        { 0,0,0,1,3,1,0,0,0,0 },
        { 0,0,0,1,1,1,0,0,0,0 },
        { 0,0,0,0,0,0,0,0,0,0 },
        { 0,0,0,0,0,0,0,0,0,0 },
        };

        public Field()
        {
        }

        public void loadField(int StageNumber)
        {
        }
    }
}
