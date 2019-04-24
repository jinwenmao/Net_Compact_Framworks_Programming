// FormMain.cs - Main form for keyboard caret sample.
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

namespace Caret
{
   /// <summary>
   /// Summary description for FormMain.
   /// </summary>
   public class FormMain : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox textWidth;
      private System.Windows.Forms.TextBox textHeight;
      private System.Windows.Forms.Button cmdSetFocus;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.TextBox textBlinkTime;
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
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.textWidth = new System.Windows.Forms.TextBox();
         this.textHeight = new System.Windows.Forms.TextBox();
         this.cmdSetFocus = new System.Windows.Forms.Button();
         this.label3 = new System.Windows.Forms.Label();
         this.textBlinkTime = new System.Windows.Forms.TextBox();
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(51, 56);
         this.label1.Size = new System.Drawing.Size(48, 20);
         this.label1.Text = "Width:";
         // 
         // label2
         // 
         this.label2.Location = new System.Drawing.Point(48, 88);
         this.label2.Size = new System.Drawing.Size(48, 20);
         this.label2.Text = "Height:";
         // 
         // textWidth
         // 
         this.textWidth.Location = new System.Drawing.Point(104, 54);
         this.textWidth.Size = new System.Drawing.Size(72, 22);
         this.textWidth.Text = "2";
         // 
         // textHeight
         // 
         this.textHeight.Location = new System.Drawing.Point(104, 86);
         this.textHeight.Size = new System.Drawing.Size(72, 22);
         this.textHeight.Text = "16";
         // 
         // cmdSetFocus
         // 
         this.cmdSetFocus.Location = new System.Drawing.Point(48, 176);
         this.cmdSetFocus.Size = new System.Drawing.Size(160, 20);
         this.cmdSetFocus.Text = "Set Focus to Form";
         this.cmdSetFocus.Click += new System.EventHandler(this.cmdSetFocus_Click);
         // 
         // label3
         // 
         this.label3.Location = new System.Drawing.Point(29, 120);
         this.label3.Size = new System.Drawing.Size(67, 20);
         this.label3.Text = "Blink Time:";
         // 
         // textBlinkTime
         // 
         this.textBlinkTime.Location = new System.Drawing.Point(104, 118);
         this.textBlinkTime.Size = new System.Drawing.Size(72, 22);
         this.textBlinkTime.Text = "";
         // 
         // FormMain
         // 
         this.Controls.Add(this.textBlinkTime);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.cmdSetFocus);
         this.Controls.Add(this.textHeight);
         this.Controls.Add(this.textWidth);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Menu = this.mainMenu1;
         this.MinimizeBox = false;
         this.Text = "Caret";
         this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
         this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseDown);
         this.GotFocus += new System.EventHandler(this.FormMain_GotFocus);
         this.LostFocus += new System.EventHandler(this.FormMain_LostFocus);

      }
      #endregion

      /// <summary>
      /// The main entry point for the application.
      /// </summary>

      static void Main() 
      {
         Application.Run(new FormMain());
      }

      private void cmdSetFocus_Click(object sender, System.EventArgs e)
      {
         this.Focus();
      }

      [DllImport("coredll.dll", CharSet=CharSet.Unicode)]
      public static extern int CreateCaret (IntPtr hWnd, IntPtr hBitmap, int nWidth, int nHeight);

      [DllImport("coredll.dll", CharSet=CharSet.Unicode)]
      public static extern int SetCaretPos (int X, int Y);

      [DllImport("coredll.dll", CharSet=CharSet.Unicode)]
      public static extern int ShowCaret (IntPtr hWnd);

      [DllImport("coredll.dll", CharSet=CharSet.Unicode)]
      public static extern int HideCaret (IntPtr hWnd);

      [DllImport("coredll.dll", CharSet=CharSet.Unicode)]
      public static extern int DestroyCaret ();

      [DllImport("coredll.dll", CharSet=CharSet.Unicode)]
      public static extern int GetCaretPos (ref System.Drawing.Point lpPoint);

      [DllImport("coredll.dll", CharSet=CharSet.Unicode)]
      public static extern int GetCaretBlinkTime ();

      [DllImport("coredll.dll", CharSet=CharSet.Unicode)]
      public static extern int SetCaretBlinkTime (int uMSeconds);

      [DllImport("coredll.dll", CharSet=CharSet.Unicode)]
      public static extern IntPtr GetFocus ();

      private void 
      FormMain_GotFocus(object sender, System.EventArgs e)
      {
         int cxWidth;
         int cyHeight;
         int msBlinkTime;
         try
         { 
            cxWidth = int.Parse(textWidth.Text);
         }
         catch
         {
            cxWidth = 2;
            textWidth.Text = "2";
         }
         try
         {
            cyHeight = int.Parse(textHeight.Text);
         }
         catch
         {
            cyHeight = 20;
            textHeight.Text = "20";
         }
         try
         {
            msBlinkTime = int.Parse(textBlinkTime.Text);
         }
         catch
         {
            msBlinkTime = GetCaretBlinkTime();
            textBlinkTime.Text = msBlinkTime.ToString();
         }
        
         IntPtr hwnd = GetFocus();
         CreateCaret(hwnd, IntPtr.Zero,  cxWidth, cyHeight);
         SetCaretPos(10, 10);
         SetCaretBlinkTime(msBlinkTime);
         ShowCaret(hwnd);
      }

      private void 
      FormMain_LostFocus(object sender, System.EventArgs e)
      {
         IntPtr hwnd = GetFocus();
         HideCaret(hwnd);
         DestroyCaret();
      }

      private void 
      FormMain_MouseDown(object sender, 
                         System.Windows.Forms.MouseEventArgs e)
      {
         SetCaretPos(e.X, e.Y);
      }

      private void 
      FormMain_KeyDown(object sender, 
                       System.Windows.Forms.KeyEventArgs e)
      {
         Point ptCaret = new Point();
         GetCaretPos(ref ptCaret);

         switch (e.KeyCode)
         {
            case Keys.Left:
               ptCaret.X -= 10;
               break;
            case Keys.Right:
               ptCaret.X += 10;
               break;
            case Keys.Up:
               ptCaret.Y -= 10;
               break;
            case Keys.Down:
               ptCaret.Y += 10;
               break;
         }
         
         // Make sure that caret stays in the window.
         if (ptCaret.X < 0) ptCaret.X = 0;
         if (ptCaret.Y < 0) ptCaret.Y = 0;

         int cxCaretWidth;
         try
         {
            cxCaretWidth = int.Parse(textWidth.Text);
         }
         catch
         {
            cxCaretWidth = 2;
            textWidth.Text = cxCaretWidth.ToString();
         }
         int cyCaretHeight;
         try
         {
            cyCaretHeight = int.Parse(textHeight.Text);
         }
         catch
         {
            cyCaretHeight = 20;
            textHeight.Text = cyCaretHeight.ToString();
         }

         if ((ptCaret.X +  cxCaretWidth) > this.Width)
            ptCaret.X = this.Width - cxCaretWidth;
         if ((ptCaret.Y + cyCaretHeight) > this.Height)
            ptCaret.Y = this.Height - cyCaretHeight;

         // Move caret to new position.
         SetCaretPos(ptCaret.X, ptCaret.Y);
         
      } // FormMain_KeyDown

   } // class FormMain
} // namespace Caret
