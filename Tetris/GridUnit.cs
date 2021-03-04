namespace Tetris
{
    class GridUnit : Point
    {
        public bool PlaceBusy { get; set; }
        public Point PointGrid { get; set; }
        public GridUnit()
        {}
        public GridUnit(int X, int Y, bool Pos)
        {
            PointGrid = new Point(X, Y);
            PlaceBusy = Pos;
        }
       public static bool operator ==(GridUnit grid1, Point grid2)
        {
            return (grid1.PointGrid == grid2);

        }
        public static bool operator !=(GridUnit grid1, Point grid2)
        {
            return (grid1.PointGrid != grid2);

        }
    }
}
