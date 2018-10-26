namespace Mandelbrot
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.tolerance = new System.Windows.Forms.TextBox();
			this.realw = new System.Windows.Forms.TextBox();
			this.realh = new System.Windows.Forms.TextBox();
			this.oy = new System.Windows.Forms.TextBox();
			this.ox = new System.Windows.Forms.TextBox();
			this.ax = new System.Windows.Forms.CheckBox();
			this.ay = new System.Windows.Forms.CheckBox();
			this.canvas1 = new Mandelbrot.Canvas();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(513, 13);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Draw";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// tolerance
			// 
			this.tolerance.Location = new System.Drawing.Point(12, 15);
			this.tolerance.Name = "tolerance";
			this.tolerance.Size = new System.Drawing.Size(47, 20);
			this.tolerance.TabIndex = 2;
			this.tolerance.Text = "50";
			// 
			// realw
			// 
			this.realw.Location = new System.Drawing.Point(86, 15);
			this.realw.Name = "realw";
			this.realw.Size = new System.Drawing.Size(43, 20);
			this.realw.TabIndex = 3;
			this.realw.Text = "3";
			// 
			// realh
			// 
			this.realh.Location = new System.Drawing.Point(135, 15);
			this.realh.Name = "realh";
			this.realh.Size = new System.Drawing.Size(43, 20);
			this.realh.TabIndex = 4;
			this.realh.Text = "2";
			// 
			// oy
			// 
			this.oy.Location = new System.Drawing.Point(246, 15);
			this.oy.Name = "oy";
			this.oy.Size = new System.Drawing.Size(43, 20);
			this.oy.TabIndex = 5;
			this.oy.Text = "0";
			// 
			// ox
			// 
			this.ox.Location = new System.Drawing.Point(197, 15);
			this.ox.Name = "ox";
			this.ox.Size = new System.Drawing.Size(43, 20);
			this.ox.TabIndex = 6;
			this.ox.Text = "0";
			// 
			// ax
			// 
			this.ax.AutoSize = true;
			this.ax.Location = new System.Drawing.Point(295, 18);
			this.ax.Name = "ax";
			this.ax.Size = new System.Drawing.Size(33, 17);
			this.ax.TabIndex = 7;
			this.ax.Text = "X";
			this.ax.UseVisualStyleBackColor = true;
			// 
			// ay
			// 
			this.ay.AutoSize = true;
			this.ay.Location = new System.Drawing.Point(334, 18);
			this.ay.Name = "ay";
			this.ay.Size = new System.Drawing.Size(33, 17);
			this.ay.TabIndex = 8;
			this.ay.Text = "Y";
			this.ay.UseVisualStyleBackColor = true;
			// 
			// canvas1
			// 
			this.canvas1.BackColor = System.Drawing.Color.Black;
			this.canvas1.Location = new System.Drawing.Point(0, 50);
			this.canvas1.Name = "canvas1";
			this.canvas1.Size = new System.Drawing.Size(600, 400);
			this.canvas1.TabIndex = 0;
			this.canvas1.Text = "canvas1";
			this.canvas1.Click += new System.EventHandler(this.canvas1_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.SlateGray;
			this.ClientSize = new System.Drawing.Size(600, 450);
			this.Controls.Add(this.ay);
			this.Controls.Add(this.ax);
			this.Controls.Add(this.ox);
			this.Controls.Add(this.oy);
			this.Controls.Add(this.realh);
			this.Controls.Add(this.realw);
			this.Controls.Add(this.tolerance);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.canvas1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "Form1";
			this.Text = "Insieme di Mandelbrot";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Canvas canvas1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox tolerance;
		private System.Windows.Forms.TextBox realw;
		private System.Windows.Forms.TextBox realh;
		private System.Windows.Forms.TextBox oy;
		private System.Windows.Forms.TextBox ox;
		private System.Windows.Forms.CheckBox ax;
		private System.Windows.Forms.CheckBox ay;
	}
}

