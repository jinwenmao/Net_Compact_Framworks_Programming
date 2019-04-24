// WordWrap.cs - Word wrapping sample.
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

namespace WordWrap
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class FormMain : System.Windows.Forms.Form
   {
      private System.Windows.Forms.MainMenu menuMain;
      private System.Windows.Forms.MenuItem menuItem1;
      private System.Windows.Forms.MenuItem menuItem10;
      private System.Windows.Forms.MenuItem menuItem2;
      private System.Windows.Forms.MenuItem mitemTextDefault;
      private System.Windows.Forms.MenuItem mitemWindowBlack;
      private System.Windows.Forms.MenuItem mitemWindowDefault;
      private System.Windows.Forms.MenuItem mitemRectangleBorder;
      private System.Windows.Forms.MenuItem menuItem3;
      private System.Windows.Forms.MenuItem mitemRectangleYellow;
      private System.Windows.Forms.MenuItem mitemRectangleAqua;
      private System.Windows.Forms.MenuItem mitemRectangleDefault;
      private System.Windows.Forms.MenuItem mitemTextRed;
      private System.Windows.Forms.MenuItem mitemTextBlue;
      private System.Windows.Forms.MenuItem mitemWindowGreen;

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
         this.menuItem2 = new System.Windows.Forms.MenuItem();
         this.mitemTextRed = new System.Windows.Forms.MenuItem();
         this.mitemTextBlue = new System.Windows.Forms.MenuItem();
         this.mitemTextDefault = new System.Windows.Forms.MenuItem();
         this.menuItem1 = new System.Windows.Forms.MenuItem();
         this.mitemRectangleYellow = new System.Windows.Forms.MenuItem();
         this.mitemRectangleAqua = new System.Windows.Forms.MenuItem();
         this.mitemRectangleDefault = new System.Windows.Forms.MenuItem();
         this.menuItem3 = new System.Windows.Forms.MenuItem();
         this.mitemRectangleBorder = new System.Windows.Forms.MenuItem();
         this.menuItem10 = new System.Windows.Forms.MenuItem();
         this.mitemWindowGreen = new System.Windows.Forms.MenuItem();
         this.mitemWindowBlack = new System.Windows.Forms.MenuItem();
         this.mitemWindowDefault = new System.Windows.Forms.MenuItem();
         // 
         // menuMain
         // 
         this.menuMain.MenuItems.Add(this.menuItem2);
         this.menuMain.MenuItems.Add(this.menuItem1);
         this.menuMain.MenuItems.Add(this.menuItem10);
         // 
         // menuItem2
         // 
         this.menuItem2.MenuItems.Add(this.mitemTextRed);
         this.menuItem2.MenuItems.Add(this.mitemTextBlue);
         this.menuItem2.MenuItems.Add(this.mitemTextDefault);
         this.menuItem2.Text = "Text";
         // 
         // mitemTextRed
         // 
         this.mitemTextRed.Text = "Red";
         this.mitemTextRed.Click += new System.EventHandler(this.mitemTextRed_Click);
         // 
         // mitemTextBlue
         // 
         this.mitemTextBlue.Text = "Blue";
         this.mitemTextBlue.Click += new System.EventHandler(this.mitemTextBlue_Click);
         // 
         // mitemTextDefault
         // 
         this.mitemTextDefault.Checked = true;
         this.mitemTextDefault.Text = "Default";
         this.mitemTextDefault.Click += new System.EventHandler(this.mitemTextDefault_Click);
         // 
         // menuItem1
         // 
         this.menuItem1.MenuItems.Add(this.mitemRectangleYellow);
         this.menuItem1.MenuItems.Add(this.mitemRectangleAqua);
         this.menuItem1.MenuItems.Add(this.mitemRectangleDefault);
         this.menuItem1.MenuItems.Add(this.menuItem3);
         this.menuItem1.MenuItems.Add(this.mitemRectangleBorder);
         this.menuItem1.Text = "Rectangle";
         // 
         // mitemRectangleYellow
         // 
         this.mitemRectangleYellow.Text = "Yellow";
         this.mitemRectangleYellow.Click += new System.EventHandler(this.mitemRectangleYellow_Click);
         // 
         // mitemRectangleAqua
         // 
         this.mitemRectangleAqua.Text = "Aqua";
         this.mitemRectangleAqua.Click += new System.EventHandler(this.mitemRectangleAqua_Click);
         // 
         // mitemRectangleDefault
         // 
         this.mitemRectangleDefault.Checked = true;
         this.mitemRectangleDefault.Text = "Default";
         this.mitemRectangleDefault.Click += new System.EventHandler(this.mitemRectangleDefault_Click);
         // 
         // menuItem3
         // 
         this.menuItem3.Text = "-";
         // 
         // mitemRectangleBorder
         // 
         this.mitemRectangleBorder.Checked = true;
         this.mitemRectangleBorder.Text = "Border";
         this.mitemRectangleBorder.Click += new System.EventHandler(this.mitemRectangleDraw_Click);
         // 
         // menuItem10
         // 
         this.menuItem10.MenuItems.Add(this.mitemWindowGreen);
         this.menuItem10.MenuItems.Add(this.mitemWindowBlack);
         this.menuItem10.MenuItems.Add(this.mitemWindowDefault);
         this.menuItem10.Text = "Window";
         // 
         // mitemWindowGreen
         // 
         this.mitemWindowGreen.Text = "Green";
         this.mitemWindowGreen.Click += new System.EventHandler(this.mitemWindowGreen_Click);
         // 
         // mitemWindowBlack
         // 
         this.mitemWindowBlack.Text = "Black";
         this.mitemWindowBlack.Click += new System.EventHandler(this.mitemWindowBlack_Click);
         // 
         // mitemWindowDefault
         // 
         this.mitemWindowDefault.Checked = true;
         this.mitemWindowDefault.Text = "Default";
         this.mitemWindowDefault.Click += new System.EventHandler(this.mitemWindowDefault_Click);
         // 
         // FormMain
         // 
         this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular);
         this.Menu = this.menuMain;
         this.MinimizeBox = false;
         this.Text = "WordWrap";
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

      private RectangleF rcDraw = new RectangleF(16, 16, 208, 160);
      private StretchRectangle stretch = new StretchRectangle();

      private void 
      FormMain_Paint(object sender, 
      System.Windows.Forms.PaintEventArgs e)
      {
         string str = "Font: " + Font.Name + "\n" +
            "Font Size: " + Font.Size.ToString() + "\n" +
            "Font Style: " + Font.Style.ToString() + "\n" +
            "Window Rect: (" +
               Bounds.X.ToString() + "," +
               Bounds.Y.ToString() + "," +
               Bounds.Right.ToString() + "," +
               Bounds.Bottom.ToString() + ")\n" +
            "Draw Rect: (" + 
               rcDraw.X.ToString() + "," +
               rcDraw.Y.ToString() + "," +
               rcDraw.Right.ToString() + "," +
               rcDraw.Bottom.ToString() + ")\n\n" +
            "This is a long string " +
            "that may need to be word wrapped." +
            " And that is why we pass a rectangle " +
            "in the call to DrawString.";
         
         // Set the text color.
         Brush brText;
         if (mitemTextDefault.Checked)
            brText = new SolidBrush(SystemColors.WindowText);
         else if (mitemTextRed.Checked)
            brText = new SolidBrush(Color.Red);
         else
            brText = new SolidBrush(Color.Blue);

         // Set the background color.
         Brush brRect;
         if (mitemRectangleDefault.Checked)
            brRect = new SolidBrush(SystemColors.Window);
         else if (mitemRectangleAqua.Checked)
            brRect = new SolidBrush(Color.Aqua);
         else
            brRect = new SolidBrush(Color.Yellow);

         // Create an integer rectangle (for vector calls)
         Rectangle rc = Rectangle.Round(rcDraw);

         // Fetch background color.
         Color clrClear;
         if (mitemWindowBlack.Checked)
            clrClear = Color.Black;
         else if (mitemWindowGreen.Checked)
            clrClear = Color.Green;
         else
            clrClear = SystemColors.Window;

         // Erase background.
         e.Graphics.Clear(clrClear);

         // Draw background rectangle.
         e.Graphics.FillRectangle(brRect, rc);

         // Draw text
         e.Graphics.DrawString(str, this.Font, brText, rcDraw);

         if (mitemRectangleBorder.Checked)
         {
            e.Graphics.DrawRectangle(new Pen(Color.Black), rc);
         }
      } // FormMain_Paint

      private void FormMain_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
      {
         // Start stretchable rectangle drawing.
         stretch.Init(e.X, e.Y, (Control)this);
         rcDraw = new RectangleF(e.X, e.Y, 0, 0);
      }

      private void FormMain_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
      {
         // Move stretchable rectangle.
         stretch.Move(e.X, e.Y);
         rcDraw.Width = e.X - rcDraw.X;
         rcDraw.Height = e.Y - rcDraw.Y;
      }

      private void FormMain_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
      {
         // End stretchable rectangle drawing.
         stretch.Done();
         rcDraw.Width = e.X - rcDraw.X;
         rcDraw.Height = e.Y - rcDraw.Y;
         
         // Reverse coordinates for negative values.
         if (rcDraw.Width < 0)
         {
            rcDraw.X = rcDraw.X + rcDraw.Width;
            rcDraw.Width *= (-1);
         }
         if (rcDraw.Height < 0)
         {
            rcDraw.Y = rcDraw.Y + rcDraw.Height;
            rcDraw.Height *= (-1);
         }
         Invalidate();
      }

      private void mitemRectangleDraw_Click(object sender, System.EventArgs e)
      {
         mitemRectangleBorder.Checked = !mitemRectangleBorder.Checked;
         Invalidate();
      }

      private void mitemTextBlue_Click(object sender, System.EventArgs e)
      {
         if (!mitemTextBlue.Checked)
         {
            mitemTextBlue.Checked = true;
            mitemTextRed.Checked = false;
            mitemTextDefault.Checked = false;
            Invalidate();
         }
      }

      private void mitemTextRed_Click(object sender, System.EventArgs e)
      {
         if (!mitemTextRed.Checked)
         {
            mitemTextBlue.Checked = false;
            mitemTextRed.Checked = true;
            mitemTextDefault.Checked = false;
            Invalidate();
         }
      }

      private void mitemTextDefault_Click(object sender, System.EventArgs e)
      {
         if (!mitemTextDefault.Checked)
         {
            mitemTextBlue.Checked = false;
            mitemTextRed.Checked = false;
            mitemTextDefault.Checked = true;
            Invalidate();
         }
      }

      private void mitemWindowGreen_Click(object sender, System.EventArgs e)
      {
         if (!mitemWindowGreen.Checked)
         {
            mitemWindowGreen.Checked = true;
            mitemWindowBlack.Checked = false;
            mitemWindowDefault.Checked = false;
            Invalidate();
         }
      }

      private void mitemWindowBlack_Click(object sender, System.EventArgs e)
      {
         if (!mitemWindowBlack.Checked)
         {
            mitemWindowGreen.Checked = false;
            mitemWindowBlack.Checked = true;
            mitemWindowDefault.Checked = false;
            Invalidate();
         }
      }

      private void mitemWindowDefault_Click(object sender, System.EventArgs e)
      {
         if (!mitemWindowDefault.Checked)
         {
            mitemWindowGreen.Checked = false;
            mitemWindowBlack.Checked = false;
            mitemWindowDefault.Checked = true;
            Invalidate();
         }
      }

      private void mitemRectangleYellow_Click(object sender, System.EventArgs e)
      {
         if (!mitemRectangleYellow.Checked)
         {
            mitemRectangleYellow.Checked = true;
            mitemRectangleAqua.Checked = false;
            mitemRectangleDefault.Checked = false;
            Invalidate();
         }
      }

      private void mitemRectangleAqua_Click(object sender, System.EventArgs e)
      {
         if (!mitemRectangleAqua.Checked)
         {
            mitemRectangleYellow.Checked = false;
            mitemRectangleAqua.Checked = true;
            mitemRectangleDefault.Checked = false;
            Invalidate();
         }
      }

      private void mitemRectangleDefault_Click(object sender, System.EventArgs e)
      {
         if (!mitemRectangleDefault.Checked)
         {
            mitemRectangleYellow.Checked = true;
            mitemRectangleAqua.Checked = false;
            mitemRectangleDefault.Checked = true;
            Invalidate();
         }
      }

   } // class
} // namespace
