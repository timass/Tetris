using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Xml.Serialization;
using d = Tetris.Direction;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            SaveScore start;
            XmlSerializer formatter = new XmlSerializer(typeof(SaveScore));
            if (File.Exists(@"C:\Tetris\score.xml")) //Load MaxScore
            {
                using (FileStream sr1 = new FileStream(@"C:\Tetris\score.xml", FileMode.OpenOrCreate))
                {
                    start = (SaveScore)formatter.Deserialize(sr1);
                }
            }
            else
            {
                start = new SaveScore();
            }
            Console.SetBufferSize(120, 30);
            Console.CursorVisible = false;
            int count = 0;
            List<Point> n = new List<Point>();
            Grid newgrid = new Grid(23, 20); //Can change field's parameters. Length and Width must be less than SetBufferSize.
            newgrid.PosiblePlaceGrid();
            newgrid.Border();
            newgrid.DrawGrid();
            newgrid.direction = new d();
            while (true)
            {
                if (newgrid.direction == d.Stop)
                { break; }
                while (newgrid.Counting(out GridUnit LineFirstGrid))
                {
                    count++;
                    newgrid.Cleaning(LineFirstGrid, out int IndexEmptyLine);
                    newgrid.DrawGrid();
                    Thread.Sleep(100);
                    newgrid.Create(IndexEmptyLine);
                    newgrid.DrawGrid();
                    Thread.Sleep(100);
                }
                if (start.Score <= count)
                {
                    start.date = DateTime.Now;
                }
                Random namber = new Random();
                Random rotation = new Random();
                int TypeFigure = namber.Next(0, 7);
                int StartRotationPosition = rotation.Next(0, 4);
                List<Point> figure = FigureCreator.Creation(TypeFigure); // create figure
                FigureCreator.StartRotation(TypeFigure, StartRotationPosition, figure); // set start rotatin position
                if (!newgrid.CanMoveFreeCell(figure))//checkin possibility to move 
                {
                    Console.WriteLine("Game over");
                    break;
                }
                for (; ; )
                {
                    Console.SetCursorPosition(Grid.Width + 5, Grid.Length / 5);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(@"Press P - pause, Space - rotation, Esc - stop");
                    Console.SetCursorPosition(Grid.Width + 5, Grid.Length / 2);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"Count: {count}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(Grid.Width + 5, Grid.Length / 2 + 1);
                    Console.Write($"MaxScore:{start.Score} Date:{start.date} ");
                    newgrid.CheckGrid(figure); // Set true  for the GridPosition 
                    newgrid.DrawGrid();
                    Thread.Sleep(100);
                    while (true)
                    {
                        if(newgrid.direction == d.Stop)
                        { break; }
                        newgrid.direction = d.SlowDown;
                        if (Console.KeyAvailable)
                        {
                            ConsoleKeyInfo key = Console.ReadKey();
                            newgrid.Handlekey(key.Key);
                        }

                        if (newgrid.direction == d.Pause) //Pause
                        {
                            while (true)
                            {
                                Thread.Sleep(100);
                                ConsoleKeyInfo k = Console.ReadKey();
                                if (k.KeyChar == 'з'|| k.KeyChar == 'p')
                                {
                                    newgrid.direction = d.SlowDown;
                                    break;
                                }
                            }
                        }
                        if (newgrid.direction == d.Left || newgrid.direction == d.Right)
                        {
                            if (newgrid.CanMoveBorders(figure, newgrid.direction) && newgrid.CanMoveFreeCell(figure, newgrid.direction))
                            {
                                newgrid.CheckGridNotDraw(figure);
                                newgrid.DrawGrid();
                                figure = newgrid.MoveSide(figure, newgrid.direction);
                            }
                            else newgrid.direction = d.SlowDown;
                        }
                        else if (newgrid.direction == d.SlowDown || newgrid.direction == d.FastDown)
                        {
                            if (newgrid.CanMoveBorders(figure, newgrid.direction) && newgrid.CanMoveFreeCell(figure, newgrid.direction))
                            {
                                if (newgrid.direction == d.SlowDown)
                                {
                                    if (count <= 5)
                                        Thread.Sleep(400);
                                    else if (count > 5 && count <= 10)
                                        Thread.Sleep(300);
                                    else Thread.Sleep(200);
                                }
                                else Thread.Sleep(100);
                                newgrid.CheckGridNotDraw(figure);
                                newgrid.DrawGrid();
                                figure = newgrid.MoveDown(figure);
                            }
                            else break;
                        }

                        else if (newgrid.direction == d.Rotation)
                        {
                            newgrid.CheckGridNotDraw(figure);
                            n = Point.CloneList(figure);
                            FigureCreator.RotationInAction(TypeFigure, StartRotationPosition + 1, n);
                            if (newgrid.CanMoveFreeCellRotation(figure, n))
                            {
                                FigureCreator.RotationInAction(TypeFigure, ++StartRotationPosition, figure);
                            }
                            else { newgrid.direction = d.SlowDown; }
                        }
                        newgrid.CheckGrid(figure);
                        newgrid.DrawGrid();
                    }
                    break;
                 }
             }
            string path = @"C:\Tetris";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            if (count > start.Score)
            {
                start.Score = count;
                start.date = DateTime.Now;
                using (FileStream sr2 = new FileStream(@"C:\Tetris\score.xml", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(sr2, start);
                    Console.WriteLine("MaxScore saved");
                }
            }
        }
    }
}
        