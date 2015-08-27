﻿using System;
using System.Globalization;

namespace ChessDotNet
{
    public class Position
    {
        public enum Files
        {
            A = 0,
            B = 1,
            C = 2,
            D = 3,
            E = 4,
            F = 5,
            G = 6,
            H = 7,
            None = -1
        }

        public enum Ranks
        {
            One = 7,
            Two = 6,
            Three = 5,
            Four = 4,
            Five = 3,
            Six = 2,
            Seven = 1,
            Eight = 0,
            None = -1
        }

        Files _file;
        public Files File
        {
            get
            {
                return _file;
            }
        }

        Ranks _rank;
        public Ranks Rank
        {
            get
            {
                return _rank;
            }
        }

        public Position(Files file, Ranks rank)
        {
            _file = file;
            _rank = rank;
        }

        public Position(string position)
        {
            if (position.Length != 2)
            {
                throw new ArgumentException("Length of `pos` is not 2.");
            }

            position = position.ToUpperInvariant();
            char file = position[0];
            char rank = position[1];
            switch (file)
            {
                case 'A':
                    _file = Files.A;
                    break;
                case 'B':
                    _file = Files.B;
                    break;
                case 'C':
                    _file = Files.C;
                    break;
                case 'D':
                    _file = Files.D;
                    break;
                case 'E':
                    _file = Files.E;
                    break;
                case 'F':
                    _file = Files.F;
                    break;
                case 'G':
                    _file = Files.G;
                    break;
                case 'H':
                    _file = Files.H;
                    break;
                default:
                    throw new ArgumentException("First char of `pos` not in range A-F.");
            }

            switch (rank)
            {
                case '1':
                    _rank = Ranks.One;
                    break;
                case '2':
                    _rank = Ranks.Two;
                    break;
                case '3':
                    _rank = Ranks.Three;
                    break;
                case '4':
                    _rank = Ranks.Four;
                    break;
                case '5':
                    _rank = Ranks.Five;
                    break;
                case '6':
                    _rank = Ranks.Six;
                    break;
                case '7':
                    _rank = Ranks.Seven;
                    break;
                case '8':
                    _rank = Ranks.Eight;
                    break;
                default:
                    throw new ArgumentException("Second char of `pos` not in range 1-8.");
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;
            if (obj == null || GetType() != obj.GetType())
                return false;
            Position pos2 = (Position)obj;
            return File == pos2.File && Rank == pos2.Rank;
        }

        public override int GetHashCode()
        {
            return new { File, Rank }.GetHashCode();
        }

        public static bool operator ==(Position position1, Position position2)
        {
            if (ReferenceEquals(position1, position2))
                return true;
            if ((object)position1 == null || (object)position2 == null)
                return false;
            return position1.Equals(position2);
        }

        public static bool operator !=(Position position1, Position position2)
        {
            if (ReferenceEquals(position1, position2))
                return false;
            if ((object)position1 == null || (object)position2 == null)
                return true;
            return !position1.Equals(position2);
        }

        public override string ToString()
        {
            return File.ToString() + (8 - (int)Rank).ToString(CultureInfo.InvariantCulture);
        }
    }
}
