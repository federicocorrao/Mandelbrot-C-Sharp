using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Collections.Generic;

namespace Mandelbrot
{
	class Complex
	{
		public double real;
		public double imaginary;

		public Complex(double r, double i)
		{
			this.real = r;
            this.imaginary = i;
		}
	}

	class PointD
	{
		public double X;
		public double Y;

		public PointD(double _x, double _y)
		{
			this.X = _x;
            this.Y = _y;
		}

		public override string ToString()
		{
			return "(" + this.X.ToString() + ", " + this.Y.ToString() + ")";
		}
	}

	class SizeD
	{
		public double Width;
		public double Height;

		public SizeD(double width, double height)
		{
			this.Width = width;
            this.Height = height;
		}

		public override string ToString()
		{
			return "Width: " + this.Width + "\nHeight: " + this.Height;
		}
	}

	class VerticalLine
	{
		public int X;

		public void Draw(ref PaintEventArgs g, ref Pen p)
		{
			g.Graphics.DrawLine(p,this.X, 0, this.X, g.ClipRectangle.Height);
		}
	}

	class HorizontalLine
	{
		public int Y;

		public void Draw(ref PaintEventArgs g, ref Pen p)
		{
			g.Graphics.DrawLine(p, 0, this.Y, g.ClipRectangle.Width, this.Y);
		}
	}

	class Canvas : Control
	{
		Bitmap Buff;
		Point Origin = new Point();
		VerticalLine YAxis = new VerticalLine();
		HorizontalLine XAxis = new HorizontalLine();
		Pen AxisColor = new Pen(new HatchBrush(HatchStyle.DottedGrid, Color.White));
		SizeD Realsize = new SizeD(3, 2);
		SizeD ScaleFactor;

		public Canvas()
        {
        }

		public void Initialize()
		{
			Origin.X = this.Size.Width - this.Size.Width/3;
			Origin.Y = this.Size.Height / 2;
			YAxis.X = Origin.X;
			XAxis.Y = Origin.Y;
			Buff = new Bitmap(this.Size.Width, this.Size.Height);
			ScaleFactor = new SizeD((double)this.Size.Width / Realsize.Width, (double)this.Size.Height / Realsize.Height);
		}

		bool Ax, Ay;
		public void Update(int tol, double rw, double rh, double ox, double oy, bool ax, bool ay)
		{
			this.tolerance = tol;
			this.Realsize = new SizeD(rw, rh);
			this.Origin = toAbsolute(new PointD(ox, oy));
			ScaleFactor = new SizeD((double)this.Size.Width / Realsize.Width, (double)this.Size.Height / Realsize.Height);

			Buff = new Bitmap(this.Size.Width, this.Size.Height);
			Ax = ax; Ay = ay;
			UpdateBuffer();
		}

		public void Update(int ox, int oy)
		{
			this.Origin.X = ox; this.Origin.Y = oy;
			XAxis.Y = oy; YAxis.X = ox;
			Ax = Ay = true;
			Buff = new Bitmap(this.Size.Width, this.Size.Height);
			UpdateBuffer();
		}
        
		private Point toAbsolute(PointD relative)
		{
			return new Point(
				(int)(Origin.X + (relative.X * ScaleFactor.Width)),
				(int)(Origin.Y - (relative.Y * ScaleFactor.Height))
			);
		}

		private PointD toRelative(int x, int y)
		{
			return new PointD(
				((double)((double)x - (double)Origin.X) / (double)ScaleFactor.Width + 0.0025),
				((double)((double)Origin.Y - (double)y) / (double)ScaleFactor.Height)					
			);
		}

		int tolerance = 50;

		private void UpdateBuffer()
		{
			Stopwatch s = new Stopwatch(); s.Start();
			int width = this.Size.Width;
			int height = this.Size.Height;

			for(int i = 0; i < width; i++)
			{
				for(int j = 0; j < height; j++)
				{
					PointD c = toRelative(i, j);
					int k = 0;

					Complex z = new Complex(0,0);
					
					while(((z.real * z.real + z.imaginary * z.imaginary) < 4) && k < tolerance)
					{
						double newreal = (z.real * z.real - z.imaginary * z.imaginary);
						double newimg = 2 * z.real * z.imaginary;
						z.real = newreal;
						z.imaginary = newimg;

						z.real += c.X;
						z.imaginary += c.Y;

						k++;
					}
					if ((z.real * z.real + z.imaginary * z.imaginary) >= 4 || k > tolerance)
					{
						int n = k*255 / tolerance;
						Buff.SetPixel(i, j,	Color.FromArgb(255-n, 255-n, 255-n));
					}
				}	
			}

			s.Stop(); this.TopLevelControl.Text = "Done in " + s.ElapsedMilliseconds.ToString() + "ms";
			this.Refresh();
		}

		public bool _RUNTIME = false;

		protected override void OnPaint(PaintEventArgs e)
		{
			if (!_RUNTIME) return;
            
			if (Buff != null)
			{
				e.Graphics.Clear(Color.Black);
				e.Graphics.DrawImage(Buff, 0, 0);
			}

			e.Graphics.DrawString("Scale ratio: (1X = " + ScaleFactor.Width + " px, 1Y = " +
				ScaleFactor.Height + " px)",
				new Font("Tahoma", 9), Brushes.White, new PointF(0, 0));

			if(Ax) XAxis.Draw(ref e, ref AxisColor);
			if(Ay) YAxis.Draw(ref e, ref AxisColor);
		}

		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			pevent.Graphics.Clear(Color.Black);
		}

		protected override void OnMouseClick(MouseEventArgs e)
		{
			Update(this.Origin.X - e.X, this.Origin.Y + e.Y);
		}

		protected override void OnMouseDoubleClick(MouseEventArgs e)
		{
			MessageBox.Show("");
		}
	}
}

