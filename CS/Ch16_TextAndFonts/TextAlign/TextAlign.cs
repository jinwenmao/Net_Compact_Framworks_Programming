// TextAlign.cs - Shows twelve alignments of text.
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

namespace TextAlign
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class FormMain : System.Windows.Forms.Form
   {

      public FormMain()
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();
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
         this.mitemVerticalPopup = new System.Windows.Forms.MenuItem();
         this.mitemVerticalTop = new System.Windows.Forms.MenuItem();
         this.mitemVerticalMiddle = new System.Windows.Forms.MenuItem();
         this.mitemVerticalBaseline = new System.Windows.Forms.MenuItem();
         this.mitemVerticalBottom = new System.Windows.Forms.MenuItem();
         this.mitemHorizontalPopup = new System.Windows.Forms.MenuItem();
         this.mitemHorizontalLeft = new System.Windows.Forms.MenuItem();
         this.mitemHorizontalCenter = new System.Windows.Forms.MenuItem();
         this.mitemHorizontalRight = new System.Windows.Forms.MenuItem();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.lblVert = new System.Windows.Forms.Label();
         this.lblHorz = new System.Windows.Forms.Label();
         // 
         // menuMain
         // 
         this.menuMain.MenuItems.Add(this.mitemVerticalPopup);
         this.menuMain.MenuItems.Add(this.mitemHorizontalPopup);
         // 
         // mitemVerticalPopup
         // 
         this.mitemVerticalPopup.MenuItems.Add(this.mitemVerticalTop);
         this.mitemVerticalPopup.MenuItems.Add(this.mitemVerticalMiddle);
         this.mitemVerticalPopup.MenuItems.Add(this.mitemVerticalBaseline);
         this.mitemVerticalPopup.MenuItems.Add(this.mitemVerticalBottom);
         this.mitemVerticalPopup.Text = "Vertical";
         // 
         // mitemVerticalTop
         // 
         this.mitemVerticalTop.Checked = true;
         this.mitemVerticalTop.Text = "Top";
         this.mitemVerticalTop.Click += new System.EventHandler(this.mitemVerticalTop_Click);
         // 
         // mitemVerticalMiddle
         // 
         this.mitemVerticalMiddle.Text = "Middle";
         this.mitemVerticalMiddle.Click += new System.EventHandler(this.mitemVerticalMiddle_Click);
         // 
         // mitemVerticalBaseline
         // 
         this.mitemVerticalBaseline.Text = "Baseline";
         this.mitemVerticalBaseline.Click += new System.EventHandler(this.mitemVerticalBaseline_Click);
         // 
         // mitemVerticalBottom
         // 
         this.mitemVerticalBottom.Text = "Bottom";
         this.mitemVerticalBottom.Click += new System.EventHandler(this.mitemVerticalBottom_Click);
         // 
         // mitemHorizontalPopup
         // 
         this.mitemHorizontalPopup.MenuItems.Add(this.mitemHorizontalLeft);
         this.mitemHorizontalPopup.MenuItems.Add(this.mitemHorizontalCenter);
         this.mitemHorizontalPopup.MenuItems.Add(this.mitemHorizontalRight);
         this.mitemHorizontalPopup.Text = "Horizontal";
         // 
         // mitemHorizontalLeft
         // 
         this.mitemHorizontalLeft.Checked = true;
         this.mitemHorizontalLeft.Text = "Left";
         this.mitemHorizontalLeft.Click += new System.EventHandler(this.mitemHorizontalLeft_Click);
         // 
         // mitemHorizontalCenter
         // 
         this.mitemHorizontalCenter.Text = "Center";
         this.mitemHorizontalCenter.Click += new System.EventHandler(this.mitemHorizontalCenter_Click);
         // 
         // mitemHorizontalRight
         // 
         this.mitemHorizontalRight.Text = "Right";
         this.mitemHorizontalRight.Click += new System.EventHandler(this.mitemHorizontalRight_Click);
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(8, 0);
         this.label1.Size = new System.Drawing.Size(128, 20);
         this.label1.Text = "Vertical Alignment:";
         this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // label2
         // 
         this.label2.Location = new System.Drawing.Point(8, 16);
         this.label2.Size = new System.Drawing.Size(128, 20);
         this.label2.Text = "Horizontal Alignment:";
         this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // lblVert
         // 
         this.lblVert.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
         this.lblVert.Location = new System.Drawing.Point(144, 0);
         this.lblVert.Size = new System.Drawing.Size(88, 20);
         this.lblVert.Text = "Top";
         // 
         // lblHorz
         // 
         this.lblHorz.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
         this.lblHorz.Location = new System.Drawing.Point(144, 16);
         this.lblHorz.Text = "Left";
         // 
         // FormMain
         // 
         this.Controls.Add(this.lblHorz);
         this.Controls.Add(this.lblVert);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular);
         this.Menu = this.menuMain;
         this.MinimizeBox = false;
         this.Text = "TextAlign";
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

      private System.Windows.Forms.MainMenu menuMain;
      private System.Windows.Forms.MenuItem mitemVerticalTop;
      private System.Windows.Forms.MenuItem mitemVerticalMiddle;
      private System.Windows.Forms.MenuItem mitemVerticalBaseline;
      private System.Windows.Forms.MenuItem mitemVerticalBottom;
      private System.Windows.Forms.MenuItem mitemHorizontalLeft;
      private System.Windows.Forms.MenuItem mitemHorizontalCenter;
      private System.Windows.Forms.MenuItem mitemHorizontalRight;
      private System.Windows.Forms.MenuItem mitemVerticalPopup;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label lblVert;
      private System.Windows.Forms.Label lblHorz;
      private System.Windows.Forms.MenuItem mitemHorizontalPopup;

      private int m_cxAdjust = 0;
      private int m_cyAdjust = 0;
      private string strDisplay = "Text";
      private IntPtr m_hwndForm;

      public enum Alignment
      {
         V_TOP,
         V_MIDDLE,
         V_BASELINE,
         V_BOTTOM,
         H_LEFT,
         H_CENTER,
         H_RIGHT
      }

      //
      // Handlers for menu item selections
      //
      private void mitemVerticalTop_Click(object sender,
      System.EventArgs e)
      {
         SetVerticalAlignment(Alignment.V_TOP);
      }

      private void mitemVerticalMiddle_Click(object sender,
      System.EventArgs e)
      {
         SetVerticalAlignment(Alignment.V_MIDDLE);
      }

      private void mitemVerticalBaseline_Click(object sender, 
      System.EventArgs e)
      {
         SetVerticalAlignment(Alignment.V_BASELINE);
      }

      private void mitemVerticalBottom_Click(object sender, 
      System.EventArgs e)
      {
         SetVerticalAlignment(Alignment.V_BOTTOM);
      }

      private void mitemHorizontalLeft_Click(object sender, 
      System.EventArgs e)
      {
         SetHorizontalAlignment(Alignment.H_LEFT);
      }

      private void mitemHorizontalCenter_Click(object sender, 
      System.EventArgs e)
      {
         SetHorizontalAlignment(Alignment.H_CENTER);
      }

      private void mitemHorizontalRight_Click(object sender, 
      System.EventArgs e)
      {
         SetHorizontalAlignment(Alignment.H_RIGHT);
      }

      //
      // Calculate offset for vertical alignment.
      //
      private void SetVerticalAlignment(Alignment align)
      {
         // Remove check mark from all menu items.
         mitemVerticalTop.Checked = false;
         mitemVerticalMiddle.Checked = false;
         mitemVerticalBaseline.Checked = false;
         mitemVerticalBottom.Checked = false;

         // Calculate size of string bounding box.
         Graphics g = CreateGraphics();
         SizeF size = g.MeasureString(strDisplay, Font);
         g.Dispose();

         // Update based on selected alignment.
         switch (align)
         {
            case Alignment.V_TOP:
               mitemVerticalTop.Checked = true;
               m_cyAdjust = 0;
               lblVert.Text = "Top";
               break;
            case Alignment.V_MIDDLE:
               mitemVerticalMiddle.Checked = true;
               m_cyAdjust = (int)(size.Height / 2);
               lblVert.Text = "Middle";
               break;
            case Alignment.V_BASELINE:
               mitemVerticalBaseline.Checked = true;
               m_cyAdjust = GetFontBaseline(Font.Name, 
                  (int)Font.Size);
               lblVert.Text = "Baseline";
               break;
            case Alignment.V_BOTTOM:
               mitemVerticalBottom.Checked = true;
               m_cyAdjust = (int)size.Height;
               lblVert.Text = "Bottom";
               break;
         }
         // Redraw
         Invalidate();
      } // SetVerticalAlignment

      //
      // Calculate offset for horizontal alignment
      //
      public void SetHorizontalAlignment(Alignment align)
      {
         // Remove check mark from all menu items.
         mitemHorizontalLeft.Checked = false;
         mitemHorizontalCenter.Checked = false;
         mitemHorizontalRight.Checked = false;

         // Calculate size of string bounding box.
         Graphics g = CreateGraphics();
         SizeF size = g.MeasureString(strDisplay, Font);
         g.Dispose();

         // Update based on selected alignment.
         switch(align)
         {
            case Alignment.H_LEFT:
               mitemHorizontalLeft.Checked = true;
               m_cxAdjust = 0;
               lblHorz.Text = "Left";
               break;
            case Alignment.H_CENTER:
               mitemHorizontalCenter.Checked = true;
               m_cxAdjust = (int)(size.Width / 2);
               lblHorz.Text = "Center";
               break;
            case Alignment.H_RIGHT:
               mitemHorizontalRight.Checked = true;
               m_cxAdjust = (int)size.Width;
               lblHorz.Text = "Right";
               break;
         }
         // Redraw
         Invalidate();
      } // SetHorizontalAlignment

      //
      // Calculate font baseline for baseline alignment.
      //
      private int GetFontBaseline(string strFont, int cptHeight)
      {
         int cyReturn;

         // Fetch a Win32 DC.
         IntPtr hdc = GdiGraphics.GetDC(m_hwndForm);

         // Create a Win32 font.
         IntPtr hfont = GdiFont.Create(hdc, strFont, cptHeight, 0);

         // Select font into DC.
         IntPtr hfontOld = GdiGraphics.SelectObject(hdc, hfont);

         // Allocate font metric structure.
         GdiFont.TEXTMETRIC tm =
            new GdiFont.TEXTMETRIC();

         // Fetch font metrics.
         GdiFont.GetTextMetrics(hdc, ref tm);

         // Fetch return value.
         cyReturn = tm.tmAscent;

         // Disconnect font from DC -- *Critical* because....
         GdiGraphics.SelectObject(hdc, hfontOld);

         // ... clean up of Win32 font object requires font to
         // be disconnected from any and all DCs.
         GdiGraphics.DeleteObject(hfont);

         // Disconnect from Win32 DC.
         GdiGraphics.ReleaseDC(m_hwndForm, hdc);

         return cyReturn;
      } // GetFontBaseline

      private void 
      FormMain_GotFocus(object sender, EventArgs e)
      {
         m_hwndForm = WinFocus.GetFocus();
      } 

      private void FormMain_Paint(object sender, 
      System.Windows.Forms.PaintEventArgs e)
      {
         Graphics g = e.Graphics;

         int x = this.Width / 2;
         int y = this.Height / 2;

         // Adjust values to accommodate alignment request.
         float sinTextX = (float)(x - m_cxAdjust);
         float sinTextY = (float)(y - m_cyAdjust);

         // Calculate size of string bounding box.
         SizeF size = g.MeasureString(strDisplay, Font);
         int cxWidth  = (int)size.Width;
         int cyHeight = (int)size.Height;

         // Draw text bounding box.
         Brush hbrFill = new SolidBrush(Color.Gray);
         Rectangle rc = new Rectangle((int)sinTextX, 
                                      (int)sinTextY, 
                                      cxWidth, 
                                      cyHeight);
         g.FillRectangle(hbrFill, rc);

         // Draw string.
         Brush brText = new SolidBrush(SystemColors.WindowText);
         g.DrawString(strDisplay, Font, brText, sinTextX, sinTextY);

         // Draw reference cross-hairs.
         Pen penBlack = new Pen(SystemColors.WindowText);
         g.DrawLine(penBlack, x, 0, x, this.Height);
         g.DrawLine(penBlack, 0, y, this.Width, y);

      } // FormMain_Paint

   } // class
} // namespace
