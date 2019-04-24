// MeasureString.cs - Shows operation of MeasureString function
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

namespace MeasureString
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class FormMain : System.Windows.Forms.Form
   {
      private System.Windows.Forms.ComboBox cboxFont;
      private System.Windows.Forms.ComboBox cboxSize;
      private System.Windows.Forms.ComboBox cboxStyle;
      private System.Windows.Forms.TextBox textSample;
      private System.Windows.Forms.Label labelWidth;
      private System.Windows.Forms.Label labelHeight;
      private System.Windows.Forms.MainMenu mainMenu1;

      public FormMain()
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         try
         { 
            // Create managed code font collection.
            m_fonts = new YaoDurant.Drawing.FontCollection();

            // Loop through collection, adding all items to combo box
            for (int i = 0; i < m_fonts.Count; i++)
            {
               cboxFont.Items.Add(m_fonts[i]); 
            }
         }
         catch
         {
            string str = "Error: cannot create FontCollection" +
               " -- make sure fontlist.dll is installed";
            MessageBox.Show(str, "FontPicker");
            Close();
            return;
         }

         cboxFont.SelectedIndex = 0;
         cboxSize.SelectedIndex = 0;
         cboxStyle.SelectedIndex = 0;
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
         this.cboxFont = new System.Windows.Forms.ComboBox();
         this.cboxSize = new System.Windows.Forms.ComboBox();
         this.cboxStyle = new System.Windows.Forms.ComboBox();
         this.textSample = new System.Windows.Forms.TextBox();
         this.labelWidth = new System.Windows.Forms.Label();
         this.labelHeight = new System.Windows.Forms.Label();
         // 
         // cboxFont
         // 
         this.cboxFont.Size = new System.Drawing.Size(120, 22);
         this.cboxFont.SelectedIndexChanged += new System.EventHandler(this.cboxFont_SelectedIndexChanged);
         // 
         // cboxSize
         // 
         this.cboxSize.Items.Add("8");
         this.cboxSize.Items.Add("10");
         this.cboxSize.Items.Add("12");
         this.cboxSize.Items.Add("14");
         this.cboxSize.Items.Add("16");
         this.cboxSize.Items.Add("18");
         this.cboxSize.Items.Add("20");
         this.cboxSize.Items.Add("22");
         this.cboxSize.Items.Add("24");
         this.cboxSize.Items.Add("28");
         this.cboxSize.Items.Add("32");
         this.cboxSize.Items.Add("36");
         this.cboxSize.Items.Add("40");
         this.cboxSize.Items.Add("48");
         this.cboxSize.Items.Add("72");
         this.cboxSize.Location = new System.Drawing.Point(128, 0);
         this.cboxSize.Size = new System.Drawing.Size(40, 22);
         this.cboxSize.SelectedIndexChanged += new System.EventHandler(this.cboxSize_SelectedIndexChanged);
         // 
         // cboxStyle
         // 
         this.cboxStyle.Items.Add("Regular");
         this.cboxStyle.Items.Add("Bold");
         this.cboxStyle.Items.Add("Italic");
         this.cboxStyle.Items.Add("Strikeout");
         this.cboxStyle.Items.Add("Underline");
         this.cboxStyle.Location = new System.Drawing.Point(176, 0);
         this.cboxStyle.Size = new System.Drawing.Size(64, 22);
         this.cboxStyle.SelectedIndexChanged += new System.EventHandler(this.cboxStyle_SelectedIndexChanged);
         // 
         // textSample
         // 
         this.textSample.Location = new System.Drawing.Point(16, 32);
         this.textSample.Size = new System.Drawing.Size(208, 22);
         this.textSample.Text = "Sample";
         this.textSample.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textSample_KeyUp);
         // 
         // labelWidth
         // 
         this.labelWidth.Location = new System.Drawing.Point(120, 64);
         this.labelWidth.Size = new System.Drawing.Size(112, 20);
         this.labelWidth.Text = "Width = ";
         // 
         // labelHeight
         // 
         this.labelHeight.Location = new System.Drawing.Point(8, 64);
         this.labelHeight.Size = new System.Drawing.Size(104, 20);
         this.labelHeight.Text = "Height = ";
         // 
         // FormMain
         // 
         this.Controls.Add(this.labelHeight);
         this.Controls.Add(this.labelWidth);
         this.Controls.Add(this.textSample);
         this.Controls.Add(this.cboxStyle);
         this.Controls.Add(this.cboxSize);
         this.Controls.Add(this.cboxFont);
         this.Menu = this.mainMenu1;
         this.MinimizeBox = false;
         this.Text = "Measure String";
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

      // My private data.
      private YaoDurant.Drawing.FontCollection m_fonts;

      //--------------------------------------------------------
      private void SetFont()
      {
         int iFont = cboxFont.SelectedIndex;
         int iSize = cboxSize.SelectedIndex;
         int iStyle = cboxStyle.SelectedIndex; 
         if (iFont != -1 && iSize != -1 && iStyle != -1)
         {
            //string strFont = (string)cboxFont.Items[iFont];
            //string strSize = (string)cboxSize.Items[iSize];
            string strFont = cboxFont.Items[iFont].ToString();
            string strSize = cboxSize.Items[iSize].ToString();
            iSize = int.Parse(strSize);
            
            FontStyle fs;
            if (iStyle == 0)
               fs = FontStyle.Regular;
            else if (iStyle == 1)
               fs = FontStyle.Bold;
            else if (iStyle == 2)
               fs = FontStyle.Italic;
            else if (iStyle == 3)
               fs = FontStyle.Strikeout;
            else
               fs = FontStyle.Underline;

            // Create a new font.
            Font font = new Font(strFont, (float)iSize, fs);

            // Connect font to textbox
            Font = font;
            Invalidate();
         }
      }

      private void cboxFont_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         SetFont();
      }

      private void cboxSize_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         SetFont();
      }

      private void cboxStyle_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         SetFont();
      }

      private void FormMain_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
      {
         string str = textSample.Text;
         Brush brFore = new SolidBrush(SystemColors.Window);
         Brush brBack = new SolidBrush(SystemColors.WindowText);
         float sinX = 240 / 4;
         float sinY = 320 / 3;

         SizeF szf = e.Graphics.MeasureString(str, Font);

         // Draw rectangle in text background.
         int xRect = (int)sinX;
         int yRect = (int)sinY;
         int cxRect = (int)szf.Width;
         int cyRect = (int)szf.Height;
         Rectangle rc;
         rc = new Rectangle(xRect, yRect,cxRect,cyRect);
            
         e.Graphics.FillRectangle(brBack, rc);

         // Draw string.
         e.Graphics.DrawString(str, Font, brFore, sinX, sinY);

         // Draw lines to height label.
         //
         //  --- (A)
         //   |
         //   |  (B)
         //   |
         //  --- (C)
         Pen penBlack = new Pen(Color.Black);
         int x1, y1, x2, y2;
         x1 = labelHeight.Left + labelHeight.Width / 4;
         y1 = labelHeight.Top + labelHeight.Height;
         x2 = xRect - 5;
         y2 = yRect + cyRect / 2;
         e.Graphics.DrawLine(penBlack, x1, y1, x2, y2);

         // Line (A)
         x1 = xRect - 3;
         y1 = yRect;
         x2 = xRect - 7;
         y2 = yRect;
         e.Graphics.DrawLine(penBlack, x1, y1, x2, y2);

         // Line (B)
         x1 = xRect - 5;
         y1 = yRect;
         x2 = xRect - 5;
         y2 = yRect + cyRect - 1;
         e.Graphics.DrawLine(penBlack, x1, y1, x2, y2);

         // Line (C)
         x1 = xRect - 3;
         y1 = yRect + cyRect - 1;
         x2 = xRect - 7;
         y2 = yRect + cyRect - 1;
         e.Graphics.DrawLine(penBlack, x1, y1, x2, y2);

         // Draw lines to width label.
         //
         //  |            |
         //  |------------|
         //  |            |
         // (D)   (E)    (F)
         x1 = labelWidth.Left + labelWidth.Width / 4;
         y1 = labelWidth.Top + labelWidth.Height;
         x2 = xRect + cxRect / 2;
         y2 = yRect - 5;
         e.Graphics.DrawLine(penBlack, x1, y1, x2, y2);

         // Line (D)
         x1 = xRect;
         y1 = yRect - 3;
         x2 = xRect;
         y2 = yRect - 7;
         e.Graphics.DrawLine(penBlack, x1, y1, x2, y2);

         // Line (E)
         x1 = xRect;
         y1 = yRect - 5;
         x2 = xRect + cxRect - 1;
         y2 = yRect - 5;
         e.Graphics.DrawLine(penBlack, x1, y1, x2, y2);

         // Line (F)
         x1 = xRect + cxRect - 1;
         y1 = yRect - 3;
         x2 = xRect + cxRect - 1;
         y2 = yRect - 7;
         e.Graphics.DrawLine(penBlack, x1, y1, x2, y2);

         // Update controls with string size.
         labelHeight.Text = "Height = " + szf.Height.ToString();
         labelWidth.Text = "Width = " + szf.Width.ToString();
      }

      private void textSample_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
      {
         Invalidate();
      }

   } // class
} // namespace
