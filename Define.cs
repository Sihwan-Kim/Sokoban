﻿using System;

public class Constants
{
    public const int Road = 0;
    public const int Wall = 1;
    public const int Box = 2;
    public const int VoidTarget = 3;
    public const int FullTagget = 5;
    public const int Worker = 4;

    public const int MapColumnCnt = 10;
    public const int MapRowCnt = 10;
}

enum Direct { LEFT, RIGHT, TOP, BOTTOM };