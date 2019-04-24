// RotateText.cs - Show various effects which are possible by
// creating a rotated Win32 font.
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
using YaoDurant.Drawing;
using YaoDurant.Win32;

namespace RotateText
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class FormMain : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.StatusBar sbarMain;
      private System.Windows.Forms.TextBox textAngle;
      private System.Windows.Forms.Button cmdRedraw;
      private System.Windows.Forms.Button cmdFanBlade;
      private System.Windows.Forms.Button cmdClear;
      private System.Windows.Forms.Button cmdAnimate;

      public FormMain()
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         m_xText = Width/2;
         m_yText = Height/2;
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
         this.label1 = new System.Windows.Forms.Label();
         this.sbarMain = new System.Windows.Forms.StatusBar();
         this.textAngle = new System.Windows.Forms.TextBox();
         this.cmdRedraw = new System.Windows.Forms.Button();
         this.cmdFanBlade = new System.Windows.Forms.Button();
         this.cmdClear = new System.Windows.Forms.Button();
         this.cmdAnimate = new System.Windows.Forms.Button();
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(0, 11);
         this.label1.Size = new System.Drawing.Size(104, 16);
         this.label1.Text = "Angle of rotation:";
         // 
         // sbarMain
         // 
         this.sbarMain.Location = new System.Drawing.Point(0, 248);
         this.sbarMain.Size = new System.Drawing.Size(240, 22);
         this.sbarMain.Text = "Click to set text origin";
         // 
         // textAngle
         // 
         this.textAngle.Location = new System.Drawing.Point(104, 8);
         this.textAngle.Size = new System.Drawing.Size(32, 22);
         this.textAngle.Text = "45";
         // 
         // cmdRedraw
         // 
         this.cmdRedraw.Location = new System.Drawing.Point(8, 40);
         this.cmdRedraw.Size = new System.Drawing.Size(64, 20);
         this.cmdRedraw.Text = "Redraw";
         this.cmdRedraw.Click += new System.EventHandler(this.cmdRedraw_Click);
         // 
         // cmdFanBlade
         // 
         this.cmdFanBlade.Location = new System.Drawing.Point(80, 40);
         this.cmdFanBlade.Text = "Fan Blade";
         this.cmdFanBlade.Click += new System.EventHandler(this.cmdFanBlade_Click);
         // 
         // cmdClear
         // 
         this.cmdClear.Location = new System.Drawing.Point(160, 8);
         this.cmdClear.Text = "Clear";
         this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
         // 
         // cmdAnimate
         // 
         this.cmdAnimate.Location = new System.Drawing.Point(160, 40);
         this.cmdAnimate.Text = "Animate";
         this.cmdAnimate.Click += new System.EventHandler(this.cmdAnimate_Click);
         // 
         // FormMain
         // 
         this.Controls.Add(this.cmdAnimate);
         this.Controls.Add(this.cmdClear);
         this.Controls.Add(this.cmdFanBlade);
         this.Controls.Add(this.cmdRedraw);
         this.Controls.Add(this.textAngle);
         this.Controls.Add(this.sbarMain);
         this.Controls.Add(this.label1);
         this.MinimizeBox = false;
         this.Text = "RotateText";
         this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseDown);
         this.GotFocus += new System.EventHandler(this.FormMain_GotFocus);
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

      private int m_xText;
      private int m_yText;
      private int m_degRotate = 0;
      private IntPtr m_hwndForm;
      
      public int degRotate
      {
         get
         {
            string strRotate = textAngle.Text;
            m_degRotate = 0;
            try { m_degRotate = int.Parse(strRotate); }
            catch {} 
            return m_degRotate;
         }
      }

      //--------------------------------------------------------
      private void FormMain_GotFocus(object sender, EventArgs e)
      {
         m_hwndForm = WinFocus.GetFocus();
      }

      private void 
      FormMain_Paint(object sender, PaintEventArgs e)
      {
         // Fetch a Win32 DC.
         IntPtr hdc = GdiGraphics.GetDC(m_hwndForm);

         // Create a Win32 font.
         IntPtr hfont = GdiFont.Create(hdc, "Tahoma", 12, m_degRotate);

         // Select font into DC.
         IntPtr hfontOld = GdiGraphics.SelectObject(hdc, hfont);

         // Draw using Win32 text drawing function.
         GdiGraphics.ExtTextOut(hdc, m_xText, m_yText, 0, 
            IntPtr.Zero, "Rotated Text", 12, IntPtr.Zero);

         // Disconnect font from DC -- *Critical* because....
         GdiGraphics.SelectObject(hdc, hfontOld);

         // ... clean up of Win32 font object requires font to
         // be disconnected from any and all DCs.
         GdiGraphics.DeleteObject(hfont);

         // Disconnect from Win32 DC.
         GdiGraphics.ReleaseDC(m_hwndForm, hdc);
      }

      //--------------------------------------------------------
      private void 
      FormMain_MouseDown(object sender, MouseEventArgs e)
      {
         m_xText = e.X;
         m_yText = e.Y;
         Invalidate();
      }

      //--------------------------------------------------------
      private void cmdRedraw_Click(object sender, EventArgs e)
      {
         m_degRotate = degRotate;
         Invalidate();
      }

      //--------------------------------------------------------
      private void 
      cmdFanBlade_Click(object sender, EventArgs e)
      {
         int cIncrement = degRotate;
         if (cIncrement == 0)
            cIncrement = 45;

         IntPtr hdc = GdiGraphics.GetDC(m_hwndForm);

         for (int i = 0; i < 360; i += cIncrement)
         {
            IntPtr hfont = GdiFont.Create(hdc, "Tahoma", 12, i);
            IntPtr hfontOld = GdiGraphics.SelectObject(hdc, hfont);

            GdiGraphics.ExtTextOut(hdc, m_xText, m_yText, 0, 
               IntPtr.Zero, "Rotated Text", 12, IntPtr.Zero);

            GdiGraphics.SelectObject(hdc, hfontOld);
            GdiGraphics.DeleteObject(hfont);
         }

         GdiGraphics.ReleaseDC(m_hwndForm, hdc);
      }

      private void cmdClear_Click(object sender, EventArgs e)
      {
         Graphics g = this.CreateGraphics();
         g.Clear(SystemColors.Window);
      }

      private void cmdAnimate_Click(object sender, EventArgs e)
      {
         // Use degrees as rotational increment.
         int cIncrement = degRotate;
         if (cIncrement == 0)
            cIncrement = 45;

         for (int i = 0; i < 360; i += cIncrement)
         {
            m_degRotate = i;
            Invalidate();
            Update();
         }

         m_degRotate = 0;
         Invalidate();
         Update();
      }

   } // class
} // namespace
