// NamedFonts.cs - Shows creating fonts by hard-coded name.
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

namespace NamedFonts
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class FormMain : System.Windows.Forms.Form
   {
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
         // 
         // FormMain
         // 
         this.Menu = this.mainMenu1;
         this.Text = "Named Fonts";
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

      private void FormMain_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
      {
         Graphics g = e.Graphics;
         float x = 10;
         float y = 10;

         Font font1 = new Font("Tahoma", 14, FontStyle.Regular);
         Font font2 = new Font("Courier New", 10, FontStyle.Regular);
         Font font3 = new Font("Bookdings", 12, FontStyle.Regular);

         Brush brText = new SolidBrush(SystemColors.WindowText);

         g.DrawString("14 Point Tahoma", font1, brText, x, y);
         SizeF sizeX = g.MeasureString("X", font1);
         y += sizeX.Height;

         g.DrawString("10 Point Courier New", font2, brText, x, y);
         sizeX = g.MeasureString("X", font2);
         y += sizeX.Height;

         g.DrawString("12 Point Bookdings", font3, brText, x, y);
         
         // Cleanup
         font1.Dispose();
         font2.Dispose();
         font3.Dispose();
         brText.Dispose();
      }
   }
}
