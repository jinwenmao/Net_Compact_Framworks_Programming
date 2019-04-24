// ShowBitmap.cs - Main form for ShowBitmap program, which
// demonstrates several ways to create and display bitmaps.
//
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.

using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Reflection; // Needed for Assembly
using System.IO;         // Needed for Stream
using System.Drawing.Imaging;  // Needed for ImageAttributes

namespace ShowBitmap
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FormMain : System.Windows.Forms.Form
	{
      private System.Windows.Forms.MainMenu menuMain;
      private System.Windows.Forms.MenuItem mitemFilePopup;
      private System.Windows.Forms.MenuItem mitemFileOpen;
      private System.Windows.Forms.MenuItem mitemResourcePopup;
      private System.Windows.Forms.MenuItem mitemResourceCup;
      private System.Windows.Forms.MenuItem mitemScalePopup;
      private System.Windows.Forms.MenuItem mitemScale50;
      private System.Windows.Forms.MenuItem mitemScale100;
      private System.Windows.Forms.MenuItem mitemScale200;
      private System.Windows.Forms.MenuItem mitemScale400;
      private System.Windows.Forms.MenuItem mitemResourceBell;
      private System.Windows.Forms.MenuItem mitemResourceClub;
      private System.Windows.Forms.MenuItem mitemResourceDiamond;
      private System.Windows.Forms.MenuItem mitemResourceHeart;
      private System.Windows.Forms.MenuItem mitemResourceSpade;
      private System.Windows.Forms.MenuItem menuItem6;
      private System.Windows.Forms.OpenFileDialog dlgFileOpen;

		public FormMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
		   DisposeBitmap(ref bmpDraw);
			base.Dispose( disposing );
		}
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
         this.menuMain = new System.Windows.Forms.MainMenu();
         this.mitemFilePopup = new System.Windows.Forms.MenuItem();
         this.mitemFileOpen = new System.Windows.Forms.MenuItem();
         this.mitemResourcePopup = new System.Windows.Forms.MenuItem();
         this.mitemResourceClub = new System.Windows.Forms.MenuItem();
         this.mitemResourceDiamond = new System.Windows.Forms.MenuItem();
         this.mitemResourceHeart = new System.Windows.Forms.MenuItem();
         this.mitemResourceSpade = new System.Windows.Forms.MenuItem();
         this.menuItem6 = new System.Windows.Forms.MenuItem();
         this.mitemResourceBell = new System.Windows.Forms.MenuItem();
         this.mitemResourceCup = new System.Windows.Forms.MenuItem();
         this.mitemScalePopup = new System.Windows.Forms.MenuItem();
         this.mitemScale50 = new System.Windows.Forms.MenuItem();
         this.mitemScale100 = new System.Windows.Forms.MenuItem();
         this.mitemScale200 = new System.Windows.Forms.MenuItem();
         this.mitemScale400 = new System.Windows.Forms.MenuItem();
         this.dlgFileOpen = new System.Windows.Forms.OpenFileDialog();
         // 
         // menuMain
         // 
         this.menuMain.MenuItems.Add(this.mitemFilePopup);
         this.menuMain.MenuItems.Add(this.mitemResourcePopup);
         this.menuMain.MenuItems.Add(this.mitemScalePopup);
         // 
         // mitemFilePopup
         // 
         this.mitemFilePopup.MenuItems.Add(this.mitemFileOpen);
         this.mitemFilePopup.Text = "File";
         // 
         // mitemFileOpen
         // 
         this.mitemFileOpen.Text = "Open...";
         this.mitemFileOpen.Click += new System.EventHandler(this.mitemFileOpen_Click);
         // 
         // mitemResourcePopup
         // 
         this.mitemResourcePopup.MenuItems.Add(this.mitemResourceClub);
         this.mitemResourcePopup.MenuItems.Add(this.mitemResourceDiamond);
         this.mitemResourcePopup.MenuItems.Add(this.mitemResourceHeart);
         this.mitemResourcePopup.MenuItems.Add(this.mitemResourceSpade);
         this.mitemResourcePopup.MenuItems.Add(this.menuItem6);
         this.mitemResourcePopup.MenuItems.Add(this.mitemResourceBell);
         this.mitemResourcePopup.MenuItems.Add(this.mitemResourceCup);
         this.mitemResourcePopup.Text = "Resource";
         // 
         // mitemResourceClub
         // 
         this.mitemResourceClub.Text = "Club";
         this.mitemResourceClub.Click += new System.EventHandler(this.mitemResourceClub_Click);
         // 
         // mitemResourceDiamond
         // 
         this.mitemResourceDiamond.Text = "Diamond";
         this.mitemResourceDiamond.Click += new System.EventHandler(this.mitemResourceDiamond_Click);
         // 
         // mitemResourceHeart
         // 
         this.mitemResourceHeart.Text = "Heart";
         this.mitemResourceHeart.Click += new System.EventHandler(this.mitemResourceHeart_Click);
         // 
         // mitemResourceSpade
         // 
         this.mitemResourceSpade.Text = "Spade";
         this.mitemResourceSpade.Click += new System.EventHandler(this.mitemResourceSpade_Click);
         // 
         // menuItem6
         // 
         this.menuItem6.Text = "-";
         // 
         // mitemResourceBell
         // 
         this.mitemResourceBell.Text = "Bell";
         this.mitemResourceBell.Click += new System.EventHandler(this.mitemResourceBell_Click);
         // 
         // mitemResourceCup
         // 
         this.mitemResourceCup.Text = "Cup";
         this.mitemResourceCup.Click += new System.EventHandler(this.mitemResourceCup_Click);
         // 
         // mitemScalePopup
         // 
         this.mitemScalePopup.MenuItems.Add(this.mitemScale50);
         this.mitemScalePopup.MenuItems.Add(this.mitemScale100);
         this.mitemScalePopup.MenuItems.Add(this.mitemScale200);
         this.mitemScalePopup.MenuItems.Add(this.mitemScale400);
         this.mitemScalePopup.Text = "Scale";
         // 
         // mitemScale50
         // 
         this.mitemScale50.Text = "50%";
         this.mitemScale50.Click += new System.EventHandler(this.mitemScale_Click);
         // 
         // mitemScale100
         // 
         this.mitemScale100.Text = "100%";
         this.mitemScale100.Click += new System.EventHandler(this.mitemScale_Click);
         // 
         // mitemScale200
         // 
         this.mitemScale200.Checked = true;
         this.mitemScale200.Text = "200%";
         this.mitemScale200.Click += new System.EventHandler(this.mitemScale_Click);
         // 
         // mitemScale400
         // 
         this.mitemScale400.Text = "400%";
         this.mitemScale400.Click += new System.EventHandler(this.mitemScale_Click);
         // 
         // FormMain
         // 
         this.Menu = this.menuMain;
         this.MinimizeBox = false;
         this.Text = "Show Bitmap";
         this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseDown);
         this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormMain_Paint);

      }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>

		static void Main() 
		{
			Application.Run(new FormMain());
		}

      private Bitmap bmpDraw;
      bool bFirstTime = true;
      bool bResource = false;
      string strResName;

      // Draw a bitmap using transparency where the mouse
      // down event is received.
      private void 
      FormMain_MouseDown(object sender, MouseEventArgs e)
      {
#if false
         CreateAndDraw(e.X, e.Y);
#endif
         // Get graphics object for form.
         Graphics g = CreateGraphics();

         // Create bitmap and graphics object for bitmap.
         Bitmap bmpNew = new Bitmap(100,100);
         Graphics gbmp = Graphics.FromImage(bmpNew);

         // Clear bitmap background.
         gbmp.Clear(Color.LightGray);

         // Some drawing objects.
         Pen penBlack = new Pen(Color.Black);
         Brush brBlack = new SolidBrush(Color.Black);
         Brush brYellow = new SolidBrush(Color.Yellow);

         // Draw onto bitmap.         
         gbmp.FillEllipse(brYellow, 0, 0, 98, 98);
         gbmp.DrawEllipse(penBlack, 0, 0, 98, 98);
         gbmp.DrawString("At " + e.X.ToString() + "," + e.Y.ToString(), Font, brBlack, 40, 40);

         // Copy bitmap to window at mouse down location.
         if (bFirstTime)
         {
            // Copy without transparency.
            g.DrawImage(bmpNew, e.X, e.Y);
            bFirstTime = false;
         }
         else
         {
            // Copy bitmap using transparency.
            Rectangle rectDest = new Rectangle(e.X, e.Y, 100, 100);
            ImageAttributes imgatt = new ImageAttributes();
            imgatt.SetColorKey(Color.LightGray, Color.LightGray);
            g.DrawImage(bmpNew, rectDest, 0, 0, 99, 99, GraphicsUnit.Pixel, imgatt);
         }

         // Clean up when we are done.
         g.Dispose();
         gbmp.Dispose();
         bmpNew.Dispose();
      }

      private void FormMain_Paint(object sender, PaintEventArgs e)
      {
         Graphics g = e.Graphics;
         float sinX = 10.0F;
         float sinY = 10.0F;
         SizeF szfText = g.MeasureString("X", Font);
         float cyLine = szfText.Height;

         Brush brText = new SolidBrush(SystemColors.WindowText);
         if (bmpDraw != null)
         {
            if (bResource)
            {
               g.DrawString("Resource: " + strResName,
                  Font, brText, sinX, sinY);
            }
            else
            {
               g.DrawString("File: " + dlgFileOpen.FileName,
                  Font, brText, sinX, sinY);
            }
            sinY += cyLine;

            g.DrawString("Bitmap Height = " + bmpDraw.Height,
               Font, brText, sinX, sinY);
            sinY += cyLine;

            g.DrawString("Bitmap Width = " + bmpDraw.Width,
               Font, brText, sinX, sinY);
            sinY += cyLine;
            sinY += cyLine;

            if (mitemScale100.Checked)
            {
               g.DrawImage(bmpDraw, (int)sinX, (int)sinY);
            }
            else
            {
               Rectangle rectSrc = new Rectangle(0, 0, 
                  bmpDraw.Width, bmpDraw.Height);
               int xScaled = 0;
               int yScaled = 0;
               if (mitemScale50.Checked)
               {
                  xScaled = bmpDraw.Width / 2;
                  yScaled = bmpDraw.Height / 2;
               }
               else if (mitemScale200.Checked)
               {
                  xScaled = bmpDraw.Width * 2;
                  yScaled = bmpDraw.Height * 2;
               }
               else if (mitemScale400.Checked)
               {
                  xScaled = bmpDraw.Width * 4;
                  yScaled = bmpDraw.Height * 4;
               }

               Rectangle rectDest = new Rectangle((int)sinX,
                  (int)sinY, xScaled, yScaled);
               g.DrawImage(bmpDraw, rectDest, rectSrc, 
                  GraphicsUnit.Pixel);
            }
         }
         else
         {
            g.DrawString("File: None", Font, brText, sinX, sinY);
         }
      }

      private void 
      mitemFileOpen_Click(object sender, EventArgs e)
      {
         dlgFileOpen.Filter = "Bitmap (*.bmp)|*.bmp|" +
                              "Picture (*.jpg)|*.jpg|" +
                              "PNG Files (*.png)|*.png|" +
                              "TIF Files (*.tif)|*.tif|" +
                              "GIF Files (*.gif)|*.gif |" +
                              "All Files (*.*)|*.*";
         if (dlgFileOpen.ShowDialog() == DialogResult.OK)
         {
            Bitmap bmpNew = null;
            try
            {
               bmpNew = new Bitmap(dlgFileOpen.FileName);
               bResource = false;
            }
            catch
            {
               MessageBox.Show("Cannot create bitmap from " +
                  "File: " + dlgFileOpen.FileName);
               return;
            }

            DisposeBitmap (ref bmpDraw);
            bmpDraw = bmpNew;
            Invalidate();
         }
      }

      private void 
      mitemScale_Click(object sender, EventArgs e)
      {
         // Clear checkmark on related items.
         mitemScale50.Checked = false;
         mitemScale100.Checked = false;
         mitemScale200.Checked = false;
         mitemScale400.Checked = false;

         // Set checkmark on selected menu item.
         ((MenuItem)sender).Checked = true;

         // Request paint to redraw bitmap.
         Invalidate();
      }


      private void 
      mitemResourceCup_Click(object sender, EventArgs e)
      {
         DisposeBitmap(ref bmpDraw);
         bmpDraw = LoadBitmapResource("CUP.BMP");
         Invalidate();
      }

      private void 
      mitemResourceBell_Click(object sender, EventArgs e)
      {
         DisposeBitmap(ref bmpDraw);
         bmpDraw = LoadBitmapResource("BELL.BMP");
         Invalidate();
      }

      private void 
      mitemResourceSpade_Click(object sender, EventArgs e)
      {
         DisposeBitmap(ref bmpDraw);
         bmpDraw = LoadBitmapResource("SPADE.BMP");
         Invalidate();
      }

      private void 
      mitemResourceHeart_Click(object sender, EventArgs e)
      {
         DisposeBitmap(ref bmpDraw);
         bmpDraw = LoadBitmapResource("HEART.BMP");
         Invalidate();
      }

      private void 
      mitemResourceDiamond_Click(object sender, EventArgs e)
      {
         DisposeBitmap(ref bmpDraw);
         bmpDraw = LoadBitmapResource("DIAMOND.BMP");
         Invalidate();
      }

      private void 
      mitemResourceClub_Click(object sender, EventArgs e)
      {
         DisposeBitmap(ref bmpDraw);
         bmpDraw = LoadBitmapResource("CLUB.BMP");
         Invalidate();
      }

      private Bitmap LoadBitmapResource(string strName)
      {
         Assembly assembly = Assembly.GetExecutingAssembly();
         string strRes = "ShowBitmap." + strName;
         Stream stream = assembly.GetManifestResourceStream(strRes);
         Bitmap bmp = null;
         try 
         {
            bmp = new Bitmap(stream); 
            strResName = strRes;
            bResource = true;
         }
         catch { }
         stream.Close();

         return bmp;
      }

      private void DisposeBitmap(ref Bitmap bmp)
      {
         if (bmp != null)
         {
            bmp.Dispose();
         }
         bmp = null;
      }

      // Simplest possible bitmap: create a bitmap, clear
      // bitmap background, draw bitmap to display screen.
      private void
      CreateAndDraw(int x, int y)
      {
         // Create bitmap and graphics object for bitmap.
         Bitmap bmpNew = new Bitmap(100,100);
         Graphics gbmp = Graphics.FromImage(bmpNew);

         // Clear bitmap background.
         gbmp.Clear(Color.LightGray);

         // Get graphics object for form.
         Graphics g = CreateGraphics();

         // Copy bitmap to window at (x,y) location
         g.DrawImage(bmpNew, x, y);

         // Clean up when we are done.
         g.Dispose();
         gbmp.Dispose();
         bmpNew.Dispose();
      }

	} // class
} // namespace
