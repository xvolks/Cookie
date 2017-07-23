using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace DofusMapControl
{
    [Serializable]
    [Flags]
    public enum CellState
    {
        None = 0,
        Walkable = 1,
        NonWalkable = 2,
        BluePlacement = 4,
        RedPlacement = 8,
        Trigger = 16,
        Road = 32
    }

    [Serializable]
    [Flags]
    public enum DrawMode
    {
        None = 0,
        Movements = 1,
        Fights = 2,
        Triggers = 4,
        Others = 8,
        All = 0xF
    }

    [Serializable]
    public sealed class MapControl : UserControl
    {
        public delegate void CellClickedHandler(MapControl control, MapCell cell, MouseButtons buttons, bool hold);

        private MapCell _mCellOnDown;
        private MapCell _mHoldedCell;

        private bool _mLesserQuality;

        private int _mMapHeight;

        private int _mMapWidth;
        private bool _mMouseDown;

        public MapControl()
        {
            Entities = new List<MapEntity>();
            DoubleBuffered = true;
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint, true);
            MapHeight = 20;
            MapWidth = 14;
            CommonCellHeight = 43;
            CommonCellWidth = 86;
            ViewGrid = true;
            DrawMode = DrawMode.All;
            TraceOnOver = false;
            InactiveCellColor = Color.DarkGray;
            ActiveCellColor = Color.Transparent;
            StatesColors = new Dictionary<CellState, Color>
            {
                [CellState.Walkable] = Color.DarkGray,
                [CellState.NonWalkable] = Color.Black,
                [CellState.BluePlacement] = Color.DodgerBlue,
                [CellState.RedPlacement] = Color.Red,
                [CellState.Trigger] = Color.Orange,
                [CellState.Road] = Color.LightGoldenrodYellow
            };
            SetCellNumber();
            BuildMap();
        }

        public int MapHeight
        {
            get => _mMapHeight;
            set
            {
                _mMapHeight = value;
                SetCellNumber();
            }
        }

        public int MapWidth
        {
            get => _mMapWidth;
            set
            {
                _mMapWidth = value;
                SetCellNumber();
            }
        }

        public double CommonCellHeight { get; set; }

        public double CommonCellWidth { get; set; }

        [Browsable(false)]
        public int RealCellHeight { get; private set; }

        [Browsable(false)]
        public int RealCellWidth { get; private set; }

        public Color InactiveCellColor { get; set; }

        public Color ActiveCellColor { get; set; }

        public DrawMode DrawMode { get; set; }

        public bool ViewGrid { get; set; }

        public bool TraceOnOver { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public MapCell CurrentCellOver { get; set; }

        public Color BorderColorOnOver { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Dictionary<CellState, Color> StatesColors { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public List<MapEntity> Entities { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public MapCell[] Cells { get; set; }

        public bool LesserQuality
        {
            get => _mLesserQuality;
            set
            {
                _mLesserQuality = value;
                Invalidate();
            }
        }

        public event CellClickedHandler CellClicked;

        private void OnCellClicked(MapCell cell, MouseButtons buttons, bool hold)
        {
            CellClicked?.Invoke(this, cell, buttons, hold);
        }

        public event Action<MapControl, MapCell, MapCell> CellOver;

        private void OnCellOver(MapCell cell, MapCell last)
        {
            var handler = CellOver;
            handler?.Invoke(this, cell, last);
        }

        private void ApplyQuality(Graphics g)
        {
            if (_mLesserQuality)
            {
                g.CompositingMode = CompositingMode.SourceOver;
                g.CompositingQuality = CompositingQuality.HighSpeed;
                g.InterpolationMode = InterpolationMode.Low;
                g.SmoothingMode = SmoothingMode.HighSpeed;
            }
            else
            {
                g.CompositingMode = CompositingMode.SourceOver;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
            }
        }

        private void SetCellNumber()
        {
            Cells = new MapCell[2 * MapHeight * MapWidth];

            var cellId = 0;
            for (var y = 0; y < MapHeight; y++)
            for (var x = 0; x < MapWidth * 2; x++)
            {
                var cell = new MapCell(cellId++);
                Cells[cell.Id] = cell;
            }
        }

        private double GetMaxScaling()
        {
            var cellWidth = Width / (double) (MapWidth + 1);
            var cellHeight = Height / (double) (MapHeight + 1);
            cellWidth = Math.Min(cellHeight * 2, cellWidth);
            return cellWidth;
        }

        public void BuildMap()
        {
            var cellId = 0;
            var cellWidth = GetMaxScaling();
            var cellHeight = Math.Ceiling(cellWidth / 2);

            var offsetX = (int) ((Width - (MapWidth + 0.5) * cellWidth) / 2);
            var offsetY = (int) ((Height - (MapHeight + 0.5) * cellHeight) / 2);

            var midCellHeight = cellHeight / 2;
            var midCellWidth = cellWidth / 2;

            for (var y = 0; y < 2 * MapHeight; y++)
                if (y % 2 == 0)
                    for (var x = 0; x < MapWidth; x++)
                    {
                        var left = new Point((int) (offsetX + x * cellWidth),
                            (int) (offsetY + y * midCellHeight + midCellHeight));
                        var top = new Point((int) (offsetX + x * cellWidth + midCellWidth),
                            (int) (offsetY + y * midCellHeight));
                        var right = new Point((int) (offsetX + x * cellWidth + cellWidth),
                            (int) (offsetY + y * midCellHeight + midCellHeight));
                        var down = new Point((int) (offsetX + x * cellWidth + midCellWidth),
                            (int) (offsetY + y * midCellHeight + cellHeight));
                        Cells[cellId++].Points = new[] {left, top, right, down};
                    }
                else
                    for (var x = 0; x < MapWidth; x++)
                    {
                        var left = new Point((int) (offsetX + x * cellWidth + midCellWidth),
                            (int) (offsetY + y * midCellHeight + midCellHeight));
                        var top = new Point((int) (offsetX + x * cellWidth + cellWidth),
                            (int) (offsetY + y * midCellHeight));
                        var right = new Point((int) (offsetX + x * cellWidth + cellWidth + midCellWidth),
                            (int) (offsetY + y * midCellHeight + midCellHeight));
                        var down = new Point((int) (offsetX + x * cellWidth + cellWidth),
                            (int) (offsetY + y * midCellHeight + cellHeight));
                        Cells[cellId++].Points = new[] {left, top, right, down};
                    }

            RealCellHeight = (int) cellHeight;
            RealCellWidth = (int) cellWidth;
        }

        public void Draw(Graphics g)
        {
            ApplyQuality(g);

            g.Clear(BackColor);

            var pen = new Pen(ForeColor);

            foreach (var cell in Cells)
                if (cell.IsInRectange(g.ClipBounds))
                {
                    cell.DrawBackground(this, g, DrawMode);
                    cell.DrawForeground(this, g, DrawMode);
                }
            foreach (var entity in Entities)
            {
                const int pointWidth = 20;
                const int pointHeight = 20;
                var cell = GetCell(entity.CellId);
                var rect = cell.Rectangle;
                rect.Size = new Size(pointWidth, pointHeight);
                rect.Location = new Point(cell.Center.X - pointWidth / 2, cell.Center.Y - pointHeight / 2);
                g.FillEllipse(new SolidBrush(entity.Color), rect);
            }
            if (!ViewGrid) return;
            {
                foreach (var cell in Cells)
                    if (cell.IsInRectange(g.ClipBounds))
                        cell.DrawBorder(g, pen);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Draw(e.Graphics);

            base.OnPaint(e);
        }

        protected override void OnResize(EventArgs e)
        {
            BuildMap();
            Invalidate();

            base.OnResize(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (_mMouseDown)
            {
                var cell = GetCell(e.Location);
                if (_mHoldedCell != null && _mHoldedCell != cell)
                {
                    OnCellClicked(_mHoldedCell, e.Button, true);
                    _mHoldedCell = cell;
                }
                if (cell != null)
                    OnCellClicked(cell, e.Button, true);
            }

            if (TraceOnOver)
            {
                var cell = GetCell(e.Location);
                var rect = Rectangle.Empty;
                MapCell last = null;

                if (CurrentCellOver != null && CurrentCellOver != cell)
                {
                    CurrentCellOver.MouseOverPen = null;

                    rect = CurrentCellOver.Rectangle;
                    last = CurrentCellOver;
                }

                if (cell != null)
                {
                    cell.MouseOverPen = new Pen(BorderColorOnOver, 1);

                    rect = rect != Rectangle.Empty ? Rectangle.Union(rect, cell.Rectangle) : cell.Rectangle;

                    CurrentCellOver = cell;
                }

                OnCellOver(cell, last);

                if (rect != Rectangle.Empty)
                    Invalidate(rect);
            }

            base.OnMouseMove(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            var cell = GetCell(e.Location);

            if (cell != null)
                _mHoldedCell = _mCellOnDown = cell;

            _mMouseDown = true;

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _mMouseDown = false;

            var cell = GetCell(e.Location);

            if (_mHoldedCell != null)
            {
                OnCellClicked(_mHoldedCell, e.Button, cell != _mCellOnDown);
                _mHoldedCell = null;
            }

            base.OnMouseUp(e);
        }

        public MapCell GetCell(Point p)
        {
            var searchRect = new Rectangle(p.X - RealCellWidth, p.Y - RealCellHeight, RealCellWidth, RealCellHeight);

            return Cells.FirstOrDefault(cell => cell.IsInRectange(searchRect) && PointInPoly(p, cell.Points));
        }

        public MapCell GetCell(int id)
        {
            return Cells.FirstOrDefault(cell => cell.Id == id);
        }

        public void Invalidate(MapCell cell)
        {
            Invalidate(cell.Rectangle);
        }

        public void Invalidate(params MapCell[] cells)
        {
            if (cells.Length == 0)
                base.Invalidate();
            else
                Invalidate(cells as IEnumerable<MapCell>);
        }

        public void Invalidate(IEnumerable<MapCell> cells)
        {
            Invalidate(cells.Select(entry => entry.Rectangle).Aggregate(Rectangle.Union));
        }

        public static bool PointInPoly(Point p, Point[] poly)
        {
            var inside = false;

            if (poly.Length < 3)
                return false;

            var xold = poly[poly.Length - 1].X;
            var yold = poly[poly.Length - 1].Y;

            foreach (var t in poly)
            {
                var xnew = t.X;
                var ynew = t.Y;

                int x1;
                int y1;
                int x2;
                int y2;
                if (xnew > xold)
                {
                    x1 = xold;
                    x2 = xnew;
                    y1 = yold;
                    y2 = ynew;
                }
                else
                {
                    x1 = xnew;
                    x2 = xold;
                    y1 = ynew;
                    y2 = yold;
                }

                if (xnew < p.X == p.X <= xold && (p.Y - (long) y1) * (x2 - x1) < (y2 - (long) y1) * (p.X - x1))
                    inside = !inside;
                xold = xnew;
                yold = ynew;
            }
            return inside;
        }
    }

    public class MapEntity
    {
        public MapEntity(double id, int cellId, Color color)
        {
            ID = id;
            CellId = cellId;
            Color = color;
        }

        public double ID { get; set; }
        public int CellId { get; set; }
        public Color Color { get; set; }
    }

    public class MapCell
    {
        public static CellState HighestState = Enum.GetValues(typeof(CellState)).Cast<CellState>().Max();

        private List<Image> _mOverlayImages = new List<Image>();

        private Point[] _mPoints;

        public int Id;

        public MapCell(int id)
        {
            Id = id;
            Active = true;
        }

        public Point[] Points
        {
            get => _mPoints;
            set
            {
                _mPoints = value;

                RefreshBounds();
            }
        }

        public bool Active { get; set; }

        public CellState State { get; set; }

        public Brush CustomBrush { get; set; }

        public Pen CustomBorderPen { get; set; }

        public Pen MouseOverPen { get; set; }

        public List<Image> OverlayImages
        {
            get => _mOverlayImages;
            set
            {
                _mOverlayImages = value;
                RefreshBounds();
            }
        }

        public string Text { get; set; }

        public Brush TextBrush { get; set; }

        public Point Center => new Point((Points[0].X + Points[2].X) / 2, (Points[1].Y + Points[3].Y) / 2);

        public int Height => Points[3].Y - Points[1].Y;

        public int Width => Points[2].X - Points[0].X;

        public Rectangle Rectangle { get; private set; }

        public void RefreshBounds()
        {
            var x = Points.Min(entry => entry.X);
            var y = Points.Min(entry => entry.Y);

            var width = Points.Max(entry => entry.X) - x;
            var height = Points.Max(entry => entry.Y) - y;

            Rectangle = new Rectangle(x, y, width, height);

            if (OverlayImages == null) return;
            foreach (var image in OverlayImages)
            {
                var rect = new Rectangle(Center.X - image.Width / 2, Center.Y - image.Height / 2, image.Width,
                    image.Height);
                Rectangle = Rectangle.Union(Rectangle, rect);
            }
        }

        public virtual void DrawBorder(Graphics g, Pen pen)
        {
            if (Points != null)
                g.DrawPolygon(MouseOverPen ?? (CustomBorderPen ?? pen), Points);
        }

        public virtual void DrawBackground(MapControl parent, Graphics g, DrawMode mode)
        {
            var brush = GetDefaultBrush(parent);

            if (!Active)
                brush = new SolidBrush(parent.InactiveCellColor);
            else if (CustomBrush != null)
                brush = CustomBrush;
            else
                for (var state = HighestState; state > CellState.None; state = (CellState) ((int) state >> 1))
                    if (State.HasFlag(state) && IsStateValid(state, mode) && parent.StatesColors.ContainsKey(state))
                        brush = new SolidBrush(parent.StatesColors[state]);

            if (Points != null)
                g.FillPolygon(brush, Points);
        }

        public virtual void DrawForeground(MapControl parent, Graphics g, DrawMode mode)
        {
            if (mode == DrawMode.All && OverlayImages != null)
                foreach (var image in OverlayImages)
                    g.DrawImage(image, Center.X - image.Width / 2, Center.Y - image.Height / 2);

            var format = new StringFormat {Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center};
            g.DrawString(Text, parent.Font, TextBrush ?? Brushes.Black,
                new RectangleF(Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height), format);
        }

        protected virtual bool IsStateValid(CellState state, DrawMode mode)
        {
            if (mode == DrawMode.None)
                return false;

            if (mode == DrawMode.All)
                return true;

            if ((state.HasFlag(CellState.Walkable) || state.HasFlag(CellState.NonWalkable)) &&
                mode.HasFlag(DrawMode.Movements))
                return true;

            if ((state.HasFlag(CellState.BluePlacement) || state.HasFlag(CellState.RedPlacement)) &&
                mode.HasFlag(DrawMode.Fights))
                return true;

            if (state.HasFlag(CellState.Trigger) && mode.HasFlag(DrawMode.Triggers))
                return true;

            return state.HasFlag(CellState.Road) && mode.HasFlag(DrawMode.Others);
        }

        public virtual Brush GetDefaultBrush(MapControl parent)
        {
            return new SolidBrush(Active ? parent.ActiveCellColor : parent.InactiveCellColor);
        }

        public bool IsInRectange(Rectangle rect)
        {
            return Rectangle.IntersectsWith(rect);
        }

        public bool IsInRectange(RectangleF rect)
        {
            return Rectangle.IntersectsWith(Rectangle.Ceiling(rect));
        }
    }
}