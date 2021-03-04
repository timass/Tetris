using System.Collections.Generic;

namespace Tetris
{
    class FigureCreator
    {
        public static List<Point> Creation(int RandomNamber)
        {
            List<Point> pList = new List<Point>();
            
            switch (RandomNamber)
            {
                case 0:

                    pList.Add(new Point(Grid.Width / 2, 1)); //  *
                    pList.Add(new Point(Grid.Width / 2, 2)); //  *
                    pList.Add(new Point(Grid.Width / 2, 3)); //  *
                    pList.Add(new Point(Grid.Width / 2, 4)); //  *
                    break;
                case 1:
                    pList.Add(new Point((Grid.Width / 2)-1, 2));//  **
                    pList.Add(new Point((Grid.Width / 2), 2)); //   **
                    pList.Add(new Point((Grid.Width / 2) - 1, 1));
                    pList.Add(new Point((Grid.Width / 2), 1));
                    break;
                case 2:
                    pList.Add(new Point((Grid.Width / 2)-1, 1)); //  *
                    pList.Add(new Point((Grid.Width / 2)-1, 2)); //  *
                    pList.Add(new Point((Grid.Width / 2)-1, 3)); //  **
                    pList.Add(new Point((Grid.Width / 2), 3));
                    break;
                case 3:
                    pList.Add(new Point((Grid.Width / 2)-1, 3)); //  
                    pList.Add(new Point((Grid.Width / 2), 3));   //  *
                    pList.Add(new Point((Grid.Width / 2)+1, 3)); // ***
                    pList.Add(new Point((Grid.Width / 2), 2));
                    break;
                case 4:
                    pList.Add(new Point((Grid.Width / 2)-1, 3));   //  *
                    pList.Add(new Point((Grid.Width / 2), 3));     //  *
                    pList.Add(new Point((Grid.Width / 2), 2));     // **
                    pList.Add(new Point((Grid.Width / 2), 1));
                    break;
                case 5:
                    pList.Add(new Point((Grid.Width / 2) - 1, 3)); //  *
                    pList.Add(new Point((Grid.Width / 2) - 1, 2)); // **
                    pList.Add(new Point((Grid.Width / 2), 2));     // *
                    pList.Add(new Point((Grid.Width / 2), 1));
                    break;
                case 6:
                    pList.Add(new Point((Grid.Width / 2) - 1, 1)); // * 
                    pList.Add(new Point((Grid.Width / 2) - 1, 2)); // **
                    pList.Add(new Point((Grid.Width / 2), 2));     //  *
                    pList.Add(new Point((Grid.Width / 2), 3));
                    break;
            }
            return pList;
        }

        public static void RotationLine(int PositionFigure, List<Point> figure)
        {
            if (PositionFigure == 1 || PositionFigure % 2 == 1)
            {
                figure[0].x += 2;
                figure[0].y += 1;
                figure[1].x += 1;
                figure[2].y -= 1;
                figure[3].x -= 1;
                figure[3].y -= 2;
            }
            else if (PositionFigure % 2 == 0)
            {
                figure[0].x -= 2;
                figure[0].y -= 1;
                figure[1].x -= 1;
                figure[2].y += 1;
                figure[3].x += 1;
                figure[3].y += 2;
            }
        }
        public static void RotationL(int PositionFigure, List<Point> figure)
        {
            if (PositionFigure == 1 || PositionFigure % 4 == 1)
            {
               figure[0].x += 2;
               figure[0].y += 1;
               figure[1].x += 1;
               figure[2].y -= 1;
               figure[3].x -= 1;
            }
            else if (PositionFigure == 2 || PositionFigure % 4 == 2)
            {
                figure[0].x -= 1;
                figure[0].y += 1;
                figure[2].x += 1;
                figure[2].y -= 1;
                figure[3].y-=2;
            }
            else if (PositionFigure == 3 || PositionFigure % 4 == 3)
            {
                figure[0].x -= 1;
                figure[0].y -= 1;
                figure[2].x+=1;
                figure[2].y +=1;
                figure[3].x +=2;                
            }
            else if (PositionFigure == 4 || PositionFigure % 4 == 0)
            {
                figure[0].x +=1;
                figure[0].y -= 1;
                figure[2].x-=1;
                figure[2].y +=1;
                figure[3].y+=2;
            }
        }
        public static void RotationTri(int PositionFigure, List<Point> figure)
        {
            if (PositionFigure == 1 || PositionFigure % 4 == 1)
            {
                figure[0].x += 1;
                figure[0].y -= 2;
                figure[1].y -= 1;
                figure[2].x -= 1;
                figure[3].x += 1;
            }
            if (PositionFigure == 2 || PositionFigure % 4 == 2)
            {
                figure[0].x += 1;
                figure[0].y += 1;
                figure[2].x -= 1;
                figure[2].y -= 1;
                figure[3].x -= 1;
                figure[3].y += 1;
            }
            if (PositionFigure == 3 || PositionFigure % 4 == 3)
            {
                figure[0].x -= 1;
                figure[0].y += 1;
                figure[2].x += 1;
                figure[2].y -= 1;
                figure[3].x -= 1;
                figure[3].y -= 1;
            }
            if (PositionFigure == 4 || PositionFigure % 4 == 0)
            {
                figure[0].x -= 1;
                figure[1].y += 1;
                figure[2].x += 1;
                figure[2].y += 2;
                figure[3].x += 1;
            }
        }
      public static void RotationReversalL(int PositionFigure, List<Point> figure)
        {
            if (PositionFigure == 1 || PositionFigure % 4 == 1)
            {
                figure[0].y -= 1;
                figure[1].x -= 1;
                figure[2].y += 1;
                figure[3].x += 1;
                figure[3].y += 2;
            }
            else if (PositionFigure == 2 || PositionFigure % 4 == 2)
            {
                figure[0].x += 2;
                figure[0].y -= 1;
                figure[1].x += 1;
                figure[1].y -= 2;
                figure[2].y -= 1;
                figure[3].x -= 1;
            }
            else if (PositionFigure == 3 || PositionFigure % 4 == 3)
            {
                figure[0].y += 2;
                figure[1].x += 1;
                figure[1].y += 1;
                figure[3].x -= 1;
                figure[3].y -= 1;
            }
            else if (PositionFigure == 4 || PositionFigure % 4 == 0)
            {
                figure[0].x -= 2;
                figure[1].x -= 1;
                figure[1].y += 1;
                figure[3].x += 1;
                figure[3].y -= 1;
            }

        }
        public static void RotationLeftAngle(int PositionFigure, List<Point> figure)
        {
            if (PositionFigure == 1 || PositionFigure % 4 == 1 || PositionFigure == 3 || PositionFigure % 4 == 3)
            {
                figure[0].y -= 1;
                figure[1].x += 1;
                figure[2].y += 1;
                figure[3].x += 1;
                figure[3].y += 2;
            }
            else if (PositionFigure == 2 || PositionFigure % 4 == 2 || PositionFigure == 4 || PositionFigure % 4 == 0)
            {
                figure[0].y += 1;
                figure[1].x -= 1;
                figure[2].y -= 1;
                figure[3].x -= 1;
                figure[3].y -= 2;
            }
        }
        public static void RotationRightAngle(int PositionFigure, List<Point> figure)
        {
                if (PositionFigure == 1 || PositionFigure % 4 == 1 || PositionFigure == 3 || PositionFigure % 4 == 3)
                {
                    figure[0].x += 2;
                    figure[1].x += 1;
                    figure[1].y -= 1;
                    figure[3].x -= 1;
                    figure[3].y -= 1;
                }
                else if (PositionFigure == 2 || PositionFigure % 4 == 2 || PositionFigure == 4 || PositionFigure % 4 == 0)
                {
                    figure[0].x -= 2;
                    figure[1].x -= 1;
                    figure[1].y += 1;
                    figure[3].x += 1;
                    figure[3].y += 1;
                }
        }
        public static void StartRotation(int TypeFigure,int StartRotationPosition, List<Point> figure)
        {
            for (int x = 1; x <= StartRotationPosition; x++)
            {
                  if (TypeFigure == 0)
                  { FigureCreator.RotationLine(x, figure); }
                  else if (TypeFigure == 2)
                  { FigureCreator.RotationL(x, figure); }
                  else if (TypeFigure == 3)
                  { FigureCreator.RotationTri(x, figure); }
                  else if (TypeFigure == 4)
                  { FigureCreator.RotationReversalL(x, figure); }
                  else if (TypeFigure == 5)
                  { FigureCreator.RotationLeftAngle(x, figure); }
                  else if (TypeFigure == 6)
                  { FigureCreator.RotationRightAngle(x, figure); }
            }
        }
         public static void RotationInAction(int TypeFigure, int StartRotationPosition, List<Point> figure)
        {
                  if (TypeFigure == 0)
                  { FigureCreator.RotationLine(StartRotationPosition, figure); }
                  else if (TypeFigure == 2)
                  { FigureCreator.RotationL(StartRotationPosition, figure); }
                  else if (TypeFigure == 3)
                  { FigureCreator.RotationTri(StartRotationPosition, figure); }
                  else if (TypeFigure == 4)
                  { FigureCreator.RotationReversalL(StartRotationPosition, figure); }
                  else if (TypeFigure == 5)
                  { FigureCreator.RotationLeftAngle(StartRotationPosition, figure); }
                  else if (TypeFigure == 6)
                  { FigureCreator.RotationRightAngle(StartRotationPosition, figure); }
        }
    }
}

