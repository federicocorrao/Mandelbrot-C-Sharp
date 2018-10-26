using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mandelbrot
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			canvas1.Initialize();
			canvas1._RUNTIME = true;
		}

		private void canvas1_Click(object sender, EventArgs e)
		{
			
		}

		private void Form1_Load(object sender, EventArgs e)
		{
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Text += ": Calcolando...";
			button1.Enabled = false;
			
			canvas1.Update(
				int.Parse(tolerance.Text),
				double.Parse(realw.Text),
				double.Parse(realh.Text),
				double.Parse(ox.Text),
				double.Parse(oy.Text),
				ax.Checked, ay.Checked);

			button1.Enabled = true;
		}
	}
}