using System;
using System.Collections;
using System.Collections.Generic;

namespace Tetris
{
    class Point:ICloneable
    {
        public int x;
        public int y;
        public char sym;
        public Point()
        { }
        public Point(int X, int Y)
        {
            x = X;
            y = Y;
        }
        public Point(int X, int Y, char Sym)
        {
            x = X;
            y = Y;
            sym = Sym;
        }

        public void Draw(char sym)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }
        public static bool operator ==(Point point1, Point point2)
        {
            return (point1.x == point2.x) && (point1.y == point2.y);

        }
        public static bool operator !=(Point point1, Point point2)
        {
            return (point1.x != point2.x) || (point1.y != point2.y);

        }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }
        public object Clone()
        { 
            return new Point { x = this.x, y = this.y, sym = this.sym }; 
        }
        public static List<Point> CloneList(List<Point> List)
        {
            List<Point> List2 = new List<Point>();
            for (int i = 0; i<List.Count; i++)
            {
                List2.Add((Point)List[i].Clone());
            }
            return List2;
        }
    }
}
