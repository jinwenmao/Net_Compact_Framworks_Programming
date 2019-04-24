// FormMain.cs - main user-interface for DrawRectangles program
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
using System.Runtime.InteropServices;

namespace DrawRectangles
{
   /// <summary>
   /// Summary description for FormMain.
   /// </summary>
   public class FormMain : System.Windows.Forms.Form
   {

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
         this.menuItem1 = new System.Windows.Forms.MenuItem();
         this.mitemEditClear = new System.Windows.Forms.MenuItem();
         this.menuItem3 = new System.Windows.Forms.MenuItem();
         this.mitemViewGrid = new System.Windows.Forms.MenuItem();
         this.mitemViewCoordinates = new System.Windows.Forms.MenuItem();
         // 
         // menuMain
         // 
         this.menuMain.MenuItems.Add(this.menuItem1);
         this.menuMain.MenuItems.Add(this.menuItem3);
         // 
         // menuItem1
         // 
         this.menuItem1.MenuItems.Add(this.mitemEditClear);
         this.menuItem1.Text = "Edit";
         // 
         // mitemEditClear
         // 
         this.mitemEditClear.Text = "Clear";
         this.mitemEditClear.Click += new System.EventHandler(this.mitemEditClear_Click);
         // 
         // menuItem3
         // 
         this.menuItem3.MenuItems.Add(this.mitemViewGrid);
         this.menuItem3.MenuItems.Add(this.mitemViewCoordinates);
         this.menuItem3.Text = "View";
         // 
         // mitemViewGrid
         // 
         this.mitemViewGrid.Text = "Grid";
         this.mitemViewGrid.Click += new System.EventHandler(this.mitemViewGrid_Click);
         // 
         // mitemViewCoordinates
         // 
         this.mitemViewCoordinates.Text = "Coordinates";
         this.mitemViewCoordinates.Click += new System.EventHandler(this.mitemViewCoordinates_Click);
         // 
         // FormMain
         // 
         this.Menu = this.menuMain;
         this.MinimizeBox = false;
         this.Text = "DrawRectangles";
         this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseDown);
         this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseUp);
         this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormMain_Paint);
         this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseMove);

      }
      #endregion

      /// <summary>
      /// The main entry point for the application.
      /// </summary>

      static void Main() 
      {
         Application.Run(new FormMain());
      }

      private ArrayList alRectangles = new ArrayList(50);
      private System.Windows.Forms.MenuItem menuItem1;
      private Rectangle rectCurrent = new Rectangle(0,0,0,0);
      private System.Windows.Forms.MenuItem menuItem3;
      private System.Windows.Forms.MainMenu menuMain;
      private System.Windows.Forms.MenuItem mitemEditClear;
      private System.Windows.Forms.MenuItem mitemViewGrid;
      private System.Windows.Forms.MenuItem mitemViewCoordinates;
      private StretchRectangle stretch = new StretchRectangle();

      private void
      EchoCoordinates(int x, int y)
      {
          this.Text = "Drawing (" + x.ToString() + 
                      "," + y.ToString() + ")";
      }

      private void 
      FormMain_MouseDown(object sender, 
                         System.Windows.Forms.MouseEventArgs e)
      {
         rectCurrent.X = e.X;
         rectCurrent.Y = e.Y;

         // Echo mouse coordinates to caption bar.
         if (mitemViewCoordinates.Checked)
            EchoCoordinates(e.X, e.Y);

         // Start stretchable rectangle drawing.
         stretch.Init(e.X, e.Y, (Control)this);
      }

      private void 
      FormMain_MouseMove(object sender, 
                         System.Windows.Forms.MouseEventArgs e)
      {
         // Move stretchable rectangle.
         stretch.Move(e.X, e.Y);

         // Echo mouse coordinates to caption bar.
         if (mitemViewCoordinates.Checked)
            EchoCoordinates(e.X, e.Y);
      }
      private void 
      FormMain_MouseUp(object sender, 
                       System.Windows.Forms.MouseEventArgs e)
      {
         int iTemp;
         int x = e.X;
         int y = e.Y;

         // End stretchable rectangle drawing.
         stretch.Done();

         // Echo mouse coordinates to caption bar.
         if (mitemViewCoordinates.Checked)
            EchoCoordinates(e.X, e.Y);

         // Make sure rectCurrent holds smaller X and Y values
         if (rectCurrent.X > x)
         {
             iTemp = rectCurrent.X;
             rectCurrent.X = x;
             x = iTemp;
         }
         
         if (rectCurrent.Y > y)
         {
            iTemp = rectCurrent.Y;
            rectCurrent.Y = y;
            y = iTemp;
         }

         // Calculate rectangle width and height
         rectCurrent.Width = x - rectCurrent.X + 1;
         rectCurrent.Height = y - rectCurrent.Y + 1;

         // Add rectangle to ArrayList
         alRectangles.Add(rectCurrent);

         // Request Paint event.
         Invalidate(rectCurrent);
      }

      private void 
      FormMain_Paint(object sender, 
                     System.Windows.Forms.PaintEventArgs e)
      {
         Graphics g = e.Graphics;

         // Draw grid
         if (mitemViewGrid.Checked)
         {
            int cxWidth = this.Width;
            int cyHeight = this.Height;
            Pen penGray = new Pen(System.Drawing.Color.LightBlue);
            for (int x = 0; x < cxWidth; x += 10)
            {
               g.DrawLine(penGray, x, 0, x, cyHeight);
            }
            for (int y = 0; y < cyHeight; y += 10)
            {
               g.DrawLine(penGray, 0, y, cxWidth, y);
            }
         }

         // Draw rectangles.
         Pen penBlack = new Pen(System.Drawing.Color.Black);
         Brush brWhite = new SolidBrush(System.Drawing.Color.White);
         foreach (Rectangle rect in alRectangles)
         {
            g.FillRectangle(brWhite, rect);
            g.DrawRectangle(penBlack, rect);
         }
      }

      private void 
      mitemEditClear_Click(object sender, System.EventArgs e)
      {
         alRectangles.Clear();
         Invalidate();
      }

      private void 
      mitemViewGrid_Click(object sender, System.EventArgs e)
      {
         // Toggle checked menu item.
         mitemViewGrid.Checked = (!mitemViewGrid.Checked);
          
         // Redraw.
         Invalidate();
      }

      private void 
      mitemViewCoordinates_Click(object sender, System.EventArgs e)
      {
         // Toggle checked menu item.
         mitemViewCoordinates.Checked = (!mitemViewCoordinates.Checked);

         if (!mitemViewCoordinates.Checked)
            this.Text = "Draw Rectangles";
      }
   }
}
