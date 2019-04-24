// SimpleDrawString.cs - Shows simplest way to draw a line of text.
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

namespace SimpleDrawString
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class FormMain : System.Windows.Forms.Form
   {
      private System.Windows.Forms.StatusBar sbarMain;
      private System.Windows.Forms.MainMenu mainMenu1;

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
         this.mainMenu1 = new System.Windows.Forms.MainMenu();
         this.sbarMain = new System.Windows.Forms.StatusBar();
         // 
         // sbarMain
         // 
         this.sbarMain.Location = new System.Drawing.Point(0, 248);
         this.sbarMain.Size = new System.Drawing.Size(240, 22);
         this.sbarMain.Text = "Tap to set text location  -  (10,10)";
         // 
         // FormMain
         // 
         this.Controls.Add(this.sbarMain);
         this.Menu = this.mainMenu1;
         this.MinimizeBox = false;
         this.Text = "SimpleDrawString";
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

      private float xDraw = 10;
      private float yDraw = 10;

      private void 
      FormMain_Paint(object sender, PaintEventArgs e)
      {
         Brush brText = new SolidBrush(this.ForeColor);
         e.Graphics.DrawString("Simple Draw String", Font, brText, 
         xDraw, yDraw);

         // Highlight origin.
         int x = (int)xDraw;
         int y = (int)yDraw;
         Pen penBlack = new Pen(Color.Black);
         e.Graphics.DrawLine(penBlack, x, y, x-8, y);
         e.Graphics.DrawLine(penBlack, x, y, x, y-8);

         // Cleanup
         brText.Dispose();
         penBlack.Dispose();
      }

      private void FormMain_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
      {
         sbarMain.Text = "Tap to set text location  -  (" +
            e.X.ToString() + "," + e.Y.ToString() + ")";
         xDraw = e.X;
         yDraw = e.Y;
         Invalidate();
      }

   } // class
} // namespace
