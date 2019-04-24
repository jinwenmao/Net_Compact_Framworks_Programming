// Bookdings.cs - Shows use of bookdings font in buttons
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

namespace BookDings
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class FormMain : System.Windows.Forms.Form
   {
      internal System.Windows.Forms.Button cmdRewind;
      internal System.Windows.Forms.Button cmdBack;
      internal System.Windows.Forms.Button cmdPause;
      internal System.Windows.Forms.Button cmdNext;
      internal System.Windows.Forms.Button cmdForward;
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
         this.cmdRewind = new System.Windows.Forms.Button();
         this.cmdBack = new System.Windows.Forms.Button();
         this.cmdPause = new System.Windows.Forms.Button();
         this.cmdNext = new System.Windows.Forms.Button();
         this.cmdForward = new System.Windows.Forms.Button();
         // 
         // cmdRewind
         // 
         this.cmdRewind.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular);
         this.cmdRewind.Location = new System.Drawing.Point(8, 240);
         this.cmdRewind.Size = new System.Drawing.Size(24, 20);
         this.cmdRewind.Text = "2";
         // 
         // cmdBack
         // 
         this.cmdBack.Location = new System.Drawing.Point(56, 240);
         this.cmdBack.Size = new System.Drawing.Size(24, 20);
         this.cmdBack.Text = "3";
         // 
         // cmdPause
         // 
         this.cmdPause.Location = new System.Drawing.Point(104, 240);
         this.cmdPause.Size = new System.Drawing.Size(24, 20);
         this.cmdPause.Text = "0";
         // 
         // cmdNext
         // 
         this.cmdNext.Location = new System.Drawing.Point(152, 240);
         this.cmdNext.Size = new System.Drawing.Size(24, 20);
         this.cmdNext.Text = "4";
         // 
         // cmdForward
         // 
         this.cmdForward.Location = new System.Drawing.Point(200, 240);
         this.cmdForward.Size = new System.Drawing.Size(24, 20);
         this.cmdForward.Text = "7";
         // 
         // FormMain
         // 
         this.Controls.Add(this.cmdForward);
         this.Controls.Add(this.cmdNext);
         this.Controls.Add(this.cmdPause);
         this.Controls.Add(this.cmdBack);
         this.Controls.Add(this.cmdRewind);
         this.Menu = this.mainMenu1;
         this.MinimizeBox = false;
         this.Text = "Bookdings Font";
         this.Load += new System.EventHandler(this.FormMain_Load);

      }
      #endregion

      /// <summary>
      /// The main entry point for the application.
      /// </summary>

      static void Main() 
      {
         Application.Run(new FormMain());
      }

      private void 
      FormMain_Load(object sender, System.EventArgs e)
      {
         Font fontBookDings = new Font("BookDings", 14, FontStyle.Bold);

         // [ << ] button
         cmdRewind.Font = fontBookDings;
         cmdRewind.Text = "2";

         // [ <  ] button
         cmdBack.Font = fontBookDings;
         cmdBack.Text = "3";

         // [ || ] button
         cmdPause.Font = fontBookDings;
         cmdPause.Text = "0";

         // [ >  ] button
         cmdNext.Font = fontBookDings;
         cmdNext.Text = "4";

         // [ >> ] button
         cmdForward.Font = fontBookDings;
         cmdForward.Text = "7";

         fontBookDings.Dispose();
      }

   } // class
} // namespace
