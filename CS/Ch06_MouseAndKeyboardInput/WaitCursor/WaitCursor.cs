// WaitCursor.cs - Shows all available system cursors.
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

namespace WaitCursor
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class FormMain : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Button cmdShow;
      private System.Windows.Forms.Button CmdHide;
      private System.Windows.Forms.Button cmdSetCursor;
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
         this.cmdShow = new System.Windows.Forms.Button();
         this.CmdHide = new System.Windows.Forms.Button();
         this.cmdSetCursor = new System.Windows.Forms.Button();
         // 
         // cmdShow
         // 
         this.cmdShow.Location = new System.Drawing.Point(48, 48);
         this.cmdShow.Size = new System.Drawing.Size(136, 20);
         this.cmdShow.Text = "Show Wait Cursor";
         this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
         // 
         // CmdHide
         // 
         this.CmdHide.Location = new System.Drawing.Point(48, 80);
         this.CmdHide.Size = new System.Drawing.Size(136, 20);
         this.CmdHide.Text = "Hide Wait Cursor";
         this.CmdHide.Click += new System.EventHandler(this.CmdHide_Click);
         // 
         // cmdSetCursor
         // 
         this.cmdSetCursor.Location = new System.Drawing.Point(48, 176);
         this.cmdSetCursor.Size = new System.Drawing.Size(136, 20);
         this.cmdSetCursor.Text = "Call SetCursor";
         this.cmdSetCursor.Click += new System.EventHandler(this.cmdSetCursor_Click);
         // 
         // FormMain
         // 
         this.Controls.Add(this.cmdSetCursor);
         this.Controls.Add(this.CmdHide);
         this.Controls.Add(this.cmdShow);
         this.Menu = this.mainMenu1;
         this.MinimizeBox = false;
         this.Text = "Wait Cursor";

      }
      #endregion

      /// <summary>
      /// The main entry point for the application.
      /// </summary>

      static void Main() 
      {
         Application.Run(new FormMain());
      }


      [DllImport("coredll.dll", CharSet=CharSet.Unicode)]
      public static extern IntPtr LoadCursor (IntPtr hInstance, int iCursorID);

      [DllImport("coredll.dll", CharSet=CharSet.Unicode)]
      public static extern IntPtr SetCursor (IntPtr hCursor);

      [DllImport("coredll.dll", CharSet=CharSet.Unicode)]
      public static extern void Sleep (int dwMilliseconds);

      public const int IDC_WAIT    = 32514;
      public const int IDC_ARROW   = 32512;
      public const int IDC_IBEAM   = 32513;
      public const int IDC_CROSS   = 32515;
      public const int IDC_UPARROW = 32516;
      public const int IDC_NO      = 32648;
      public const int IDC_HELP    = 32651;
      public const int IDC_HAND    = 32649;

      private void cmdShow_Click(object sender, System.EventArgs e)
      {
         // Display wait cursor.
         Cursor.Current = Cursors.WaitCursor;
      }

      private void CmdHide_Click(object sender, System.EventArgs e)
      {
         // Display default cursor (or no cursor for Pocket PC)
         Cursor.Current = Cursors.Default;
      }

      private void 
      cmdSetCursor_Click(object sender, System.EventArgs e)
      {
         // Get button text.
         string strButtonText = cmdSetCursor.Text;

         // Create table of cursor IDs and names.
         Hashtable ht = new Hashtable();
         ht.Add(IDC_WAIT   , "IDC_WAIT");
         ht.Add(IDC_ARROW  , "IDC_ARROW");
         ht.Add(IDC_IBEAM  , "IDC_IBEAM");
         ht.Add(IDC_CROSS  , "IDC_CROSS");
         ht.Add(IDC_UPARROW, "IDC_UPARROW");
         ht.Add(IDC_NO     , "IDC_NO");
         ht.Add(IDC_HELP   , "IDC_HELP");
         ht.Add(IDC_HAND   , "IDC_HAND");

         foreach (object oKey in ht.Keys)
         {
             int iCursor = (int)oKey;
             SetCursor(LoadCursor(IntPtr.Zero,iCursor));
             cmdSetCursor.Text = (string)ht[oKey];
             
             Sleep(1000);  // Pause for one second
         }

         // Display default cursor (no cursor for Pocket PC)
         Cursor.Current = Cursors.Default;
         cmdSetCursor.Text = strButtonText;
      }
   }
}
