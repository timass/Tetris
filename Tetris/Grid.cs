using System;
using System.Collections;
using System.Collections.Generic;
using d = Tetris.Direction;

namespace Tetris
{
    class Grid : GridUnit
    {
        public static int Length { get; private set; }
        public static int Width { get; private set; }
        public static List <GridUnit> PosiblePlace = new List<GridUnit>(); // list of all cells
        public d direction;
        public Grid(int length, int width)
        {
            if (width < 20) throw new Exception("Width is too small");
            else Width = width;
            if (length >= 30) throw new Exception("Lengt is biggest than buffer size");
            else Length = length;
        }
       public void PosiblePlaceGrid() //Create cells
       { 
           for (int y = 1; y < Length; y++)
           {
              for (int x = 1; x < Width; x++)
              {
                PosiblePlace.Add(new GridUnit(x, y, false)); // false - free cells
              }
           }
       }  
        public void Border() // Create a borders from '/'
        {

           for (int x = 0; x <= Width; x++)
            {
                    Point point = new Point(x, 0);
                    point.Draw('/');
            }
            for (int x = 0; x <= Width; x++)
            {
                Point point = new Point(x, Length);
                point.Draw('/');
            }
            for (y = 1; y < Length; y++)
            {
                Point point = new Point(0, y);
                point.Draw('/');
            }
            for (int y = 1; y < Length; y++)
            {
                Point point = new Point(Width, y);
                point.Draw('/');
            }
        }
        public bool CanMoveFreeCell(List<Point> figure, d dir = d.SlowDown) //Check: can move figure in selected direction (free or not cells)
        {
            List<Point> CheckList = new List<Point>();
            Point point;
            for (int j = 0; j < figure.Count; j++) // Select d for moving and create new point
            {
                bool trim = true;
                
                switch (dir) 
                {
                    case d.Left:
                             point = new Point(figure[j].x-1, figure[j].y);
                        break;
                    case d.Right:
                             point = new Point(figure[j].x+1, figure[j].y);
                        break;
                    default:
                             point = new Point(figure[j].x, figure[j].y + 1);
                        break;
                }
                
                    for (int k = 0; k < figure.Count; k++) // Checking point do not belong any points of figure
                {
                    if (point == figure[k])
                    {
                        trim = false;
                        break;
                    }
                }
                if (trim)                 
                { CheckList.Add(point); } // Creating new list from new point which forming when a figure try to move
            }

            foreach (Point p in CheckList) // Checking new list. If all cells is free and figure can move return true
            {
                foreach (GridUnit item in PosiblePlace)
                {
                    if ((item == p) && (item.PlaceBusy == true))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool CanMoveFreeCellRotation(List<Point> figure, List<Point> figure2)
        {
            List<Point> CheckList = new List<Point>();
            bool trim = true;
            //bool chek = true;
            Point point = new Point();
            for (int i = 0; i < figure2.Count; i++)
            {
                point = new Point(figure2[i].x, figure2[i].y);
                for (int k = 0; k < figure.Count; k++) // Checking point do not belong any points of figure
                {
                    trim = true;

                    if (point == figure[k])
                    {
                        trim = false;
                        break;
                    }
                }

                if (trim)
                { CheckList.Add(point); } // Creating new list from new point which forming when a figure try to move
            }
             foreach (Point p in CheckList) 
            {
                if ((p.x < 1) || (p.x >= Width) || (p.y >= Length))
                    return false;
            }
            foreach (Point p in CheckList) // Checking new list. If all cells is free and figure can move return true
            {
                foreach (GridUnit item in PosiblePlace)
                {
                    if ((item == p) && (item.PlaceBusy == true))
                    {
                        return false;
                    }
                }
            }
        return true;
        }
        public bool CanMoveBorders(List<Point> figure, d dir)
        {
             foreach (Point item in figure)
            {
                if (dir == d.Left)
                { if (item.x - 1 <= 0) { return false; } }
                else if (dir == d.Right)
                { if (item.x + 1 >= Width) { return false; } }
                else { if (item.y + 1 >= Length) { return false; } }
            }
            return true;
        } //Check: can move figure in selected d (there is borders or no) 
        public List<Point> MoveSide(List<Point> figure, d dir)
        {
            List<Point> figureNew = new List<Point>();

            if (dir == d.Left)
            {
                for (int i = 0; i < figure.Count; i++)
                {
                    figureNew.Add(new Point(figure[i].x - 1, figure[i].y));
                }
            }
            else if (dir == d.Right)
                for (int i = 0; i < figure.Count; i++)
                {
                    figureNew.Add(new Point(figure[i].x + 1, figure[i].y));
                }
             return figureNew; 
        }
        public List<Point> MoveDown(List<Point> figure)
        {
                List<Point> figureNew = new List<Point>();

                for (int i = 0; i < figure.Count; i++)
                {
                    figureNew.Add(new Point(figure[i].x, figure[i].y+1));
                }
          return figureNew;
        }
        public void DrawGrid()
        {
            foreach (GridUnit item in PosiblePlace)
            {
                if (item.PlaceBusy)
                { item.PointGrid.Draw('*'); }
                else item.PointGrid.Draw(' ');
            }
        } 
        public void CheckGrid(List<Point> pList) // Change cells free to busy
        {
            foreach (GridUnit item2 in PosiblePlace)
            {
                foreach (Point item1 in pList)
                {
                    if (item2 == item1)
                    {
                        item2.PlaceBusy = true;
                    }
                }
            }
        }
        public void CheckGridNotDraw(List<Point> pList) // Change cells busy to free
        {
            foreach (GridUnit item2 in PosiblePlace)
            {
                foreach (Point item1 in pList)
                {
                    if (item2 == item1)
                    {
                        item2.PlaceBusy = false;
                    }
                }
            }
        }
        public void Handlekey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)
            { direction = d.Left; }
            else if (key == ConsoleKey.RightArrow)
            { direction = d.Right; }
            else if (key == ConsoleKey.DownArrow)
            { direction = d.FastDown; }
            else if (key == ConsoleKey.Spacebar)
            { direction = d.Rotation; }
            else if (key == ConsoleKey.Escape)
            { direction = d.Stop; }
            else if (key == ConsoleKey.P)
            { direction = d.Pause; }
        }
        public bool Counting(out GridUnit LineFirstGrid)
        {
              int count;
              for (int i = PosiblePlace.Count-1; i >=0; i--)
              {
                count = 0;
                if (PosiblePlace[i].PointGrid.x == 1)
                {
                    for (int k = 0; k < Width - 1; k++)
                    {
                      if (PosiblePlace[i + k].PlaceBusy == true)
                        {count++;}
                      else
                        {break;}
                    }
                    if (count == Width - 1)
                    {
                    LineFirstGrid = PosiblePlace[i];
                    return true;
                    }
                }
              }
           LineFirstGrid = null;
        return false;
        }//Count full line
        public void Cleaning(GridUnit LineFirstGrid, out int IndexEmptyLine)
        {
            IndexEmptyLine = PosiblePlace.IndexOf(LineFirstGrid);
                {
                    for (int i = 0; i < Width - 1; i++)
                    {
                    PosiblePlace[IndexEmptyLine+i].PlaceBusy = false;
                    }
                }
        } // Delete full line
        public void Create(int IndexEmptyLine)
        {
           for (int i = IndexEmptyLine + Width - 2; i > Width - 1; i--)
                {
                    bool temp2 = PosiblePlace[IndexEmptyLine + Width - 2].PlaceBusy;
                    PosiblePlace[IndexEmptyLine+Width-2].PlaceBusy = PosiblePlace[IndexEmptyLine - 1].PlaceBusy;
                    PosiblePlace[IndexEmptyLine - 1].PlaceBusy = temp2;
                    IndexEmptyLine--;
                }
        } // change cels for deleted line
    }
}


