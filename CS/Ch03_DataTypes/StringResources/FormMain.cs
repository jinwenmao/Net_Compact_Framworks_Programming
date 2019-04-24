//-----------------------------------------------------------------------------
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Resources;
using System.Reflection;

namespace StringResources
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
         this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
         this.Menu = this.mainMenu1;
         this.MinimizeBox = false;
         this.Text = "StringResources";
         this.Load += new System.EventHandler(this.FormMain_Load);
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
      
      // Resource manager for our set of strings.
      ResourceManager resman;

      // The four strings we load
      string strA;
      string strB;
      string strC;
      string strD;

      private void 
      FormMain_Load(object sender, System.EventArgs e)
      {
         // Create the resource manager.
         Assembly assembly = this.GetType().Assembly;
         resman = new ResourceManager(
            "StringResources.Strings", assembly);

         // Load the strings.
         strA = resman.GetString("A");
         strB = resman.GetString("B");
         strC = resman.GetString("C");
         strD = resman.GetString("D");
      }

      private void 
      FormMain_Paint(object sender, PaintEventArgs e)
      {
         float sinX = 10;
         float sinY = 10;
         SizeF szf;

         Brush brText = new SolidBrush(SystemColors.WindowText);
         szf = e.Graphics.MeasureString(strA, Font);

         e.Graphics.DrawString(strA, Font, brText, sinX, sinY);
         sinY = sinY + szf.Height;
         e.Graphics.DrawString(strB, Font, brText, sinX, sinY);
         sinY = sinY + szf.Height;
         e.Graphics.DrawString(strC, Font, brText, sinX, sinY);
         sinY = sinY + szf.Height;
         e.Graphics.DrawString(strD, Font, brText, sinX, sinY);
         sinY = sinY + szf.Height;
      }


   } // class
} // namespace
