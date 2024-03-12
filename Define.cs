using System;

namespace Sokoban
{
    public class Constants
    {
        public const int Road = 0x00;
        public const int Store = 0x01;
        public const int Box = 0x02;
        public const int FullStore = 0x03;
        public const int Wall = 0x08;

        public const int WorkerTop = 0x10;
        public const int WorkerDown = 0x20;
        public const int WorkerLeft = 0x40;
        public const int WorkerRight = 0x80;

        public const int MapColumnCnt = 10;
        public const int MapRowCnt = 10;
    }

    enum Direction { TOP = 0x10, BOTTOM = 0x20, LEFT = 0x40, RIGHT = 0x80 };
}
