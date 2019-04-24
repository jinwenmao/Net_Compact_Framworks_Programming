// FormMain.cs - Main form for FindMemoryCard sample.
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

namespace FindMemoryCard
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class frmMain : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Button cmdFindFirst;
      private System.Windows.Forms.Button cmdFindNext;
      private System.Windows.Forms.Button cmdFindClose;
      private System.Windows.Forms.MainMenu mainMenu1;

      public frmMain()
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
         this.cmdFindFirst = new System.Windows.Forms.Button();
         this.cmdFindNext = new System.Windows.Forms.Button();
         this.cmdFindClose = new System.Windows.Forms.Button();
         // 
         // cmdFindFirst
         // 
         this.cmdFindFirst.Location = new System.Drawing.Point(32, 48);
         this.cmdFindFirst.Size = new System.Drawing.Size(176, 20);
         this.cmdFindFirst.Text = "FindFirstFlashCard()";
         this.cmdFindFirst.Click += new System.EventHandler(this.cmdFindFirst_Click);
         // 
         // cmdFindNext
         // 
         this.cmdFindNext.Location = new System.Drawing.Point(32, 104);
         this.cmdFindNext.Size = new System.Drawing.Size(176, 20);
         this.cmdFindNext.Text = "FindNextFlashCard()";
         this.cmdFindNext.Click += new System.EventHandler(this.cmdFindNext_Click);
         // 
         // cmdFindClose
         // 
         this.cmdFindClose.Location = new System.Drawing.Point(32, 160);
         this.cmdFindClose.Size = new System.Drawing.Size(176, 20);
         this.cmdFindClose.Text = "Call FindClose()";
         this.cmdFindClose.Click += new System.EventHandler(this.cmdFindClose_Click);
         // 
         // frmMain
         // 
         this.Controls.Add(this.cmdFindClose);
         this.Controls.Add(this.cmdFindNext);
         this.Controls.Add(this.cmdFindFirst);
         this.Menu = this.mainMenu1;
         this.MinimizeBox = false;
         this.Text = "FindMemoryCard";

      }
      #endregion

      /// <summary>
      /// The main entry point for the application.
      /// </summary>

      static void Main() 
      {
         Application.Run(new frmMain());
      }

      string strAppName = "FindMemoryCard";

      IntPtr hffc = new IntPtr(EnumFlash.INVALID_HANDLE_VALUE);
      EnumFlash.WIN32_FIND_DATA wfd = new EnumFlash.WIN32_FIND_DATA();

      private void cmdFindFirst_Click(object sender, System.EventArgs e)
      {
          hffc = EnumFlash.FindFirstFlashCard (ref wfd);
          if (hffc.ToInt32() == EnumFlash.INVALID_HANDLE_VALUE)
              MessageBox.Show("Error in FindMemoryCard()", strAppName); 
          else
              MessageBox.Show(wfd.cFileName, strAppName);
      }

      private void cmdFindNext_Click(object sender, System.EventArgs e)
      {
         if (hffc.ToInt32() == EnumFlash.INVALID_HANDLE_VALUE)
            MessageBox.Show("Must first call FindMemoryCard()", strAppName);
         
         if (EnumFlash.FindNextFlashCard(hffc, ref wfd))
            MessageBox.Show(wfd.cFileName, strAppName);
         else
            MessageBox.Show("No more flash cards available", strAppName); 
      }

      private void cmdFindClose_Click(object sender, System.EventArgs e)
      {
         if (hffc.ToInt32() == EnumFlash.INVALID_HANDLE_VALUE)
            MessageBox.Show("Must first call FindMemoryCard()", strAppName);
         else
         {
            EnumFlash.FindClose(hffc);
            hffc = new IntPtr(EnumFlash.INVALID_HANDLE_VALUE);
         }
      }  // cmdFindClose_Click

   } // class
} // namespace
