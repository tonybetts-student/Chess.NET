﻿using System;

namespace ChessDotNet
{
    public struct PositionDelta
    {
        public int DeltaX
        {
            get;
            private set;
        }

        public int DeltaY
        {
            get;
            private set;
        }
        public PositionDelta(Position position1, Position position2)
        {
            DeltaX = Math.Abs((int)position1.File - (int)position2.File);
            DeltaY = Math.Abs((int)position1.Rank - (int)position2.Rank);
        }
    }
}
