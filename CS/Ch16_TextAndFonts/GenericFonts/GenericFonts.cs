// GenericFonts.cs - Creates generic fonts.
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

namespace GenericFonts
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class FormMain : System.Windows.Forms.Form
   {
      private System.Windows.Forms.MenuItem menuMain;
      private System.Windows.Forms.MenuItem mitemSize8;
      private System.Windows.Forms.MenuItem mitemSize10;
      private System.Windows.Forms.MenuItem mitemSize12;
      private System.Windows.Forms.MenuItem mitemSize14;
      private System.Windows.Forms.MenuItem mitemSize16;
      private System.Windows.Forms.MenuItem mitemSize18;
      private System.Windows.Forms.MenuItem mitemSize24;
      private System.Windows.Forms.MenuItem menuItem1;
      private System.Windows.Forms.MenuItem mitemFontMono;
      private System.Windows.Forms.MenuItem mitemFontSans;
      private System.Windows.Forms.MenuItem mitemFontSerif;
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
         this.menuMain = new System.Windows.Forms.MenuItem();
         this.mitemSize8 = new System.Windows.Forms.MenuItem();
         this.mitemSize10 = new System.Windows.Forms.MenuItem();
         this.mitemSize12 = new System.Windows.Forms.MenuItem();
         this.mitemSize14 = new System.Windows.Forms.MenuItem();
         this.mitemSize18 = new System.Windows.Forms.MenuItem();
         this.mitemSize24 = new System.Windows.Forms.MenuItem();
         this.menuItem1 = new System.Windows.Forms.MenuItem();
         this.mitemFontMono = new System.Windows.Forms.MenuItem();
         this.mitemFontSans = new System.Windows.Forms.MenuItem();
         this.mitemFontSerif = new System.Windows.Forms.MenuItem();
         this.mitemSize16 = new System.Windows.Forms.MenuItem();
         // 
         // mainMenu1
         // 
         this.mainMenu1.MenuItems.Add(this.menuMain);
         this.mainMenu1.MenuItems.Add(this.menuItem1);
         // 
         // menuMain
         // 
         this.menuMain.MenuItems.Add(this.mitemSize8);
         this.menuMain.MenuItems.Add(this.mitemSize10);
         this.menuMain.MenuItems.Add(this.mitemSize12);
         this.menuMain.MenuItems.Add(this.mitemSize14);
         this.menuMain.MenuItems.Add(this.mitemSize16);
         this.menuMain.MenuItems.Add(this.mitemSize18);
         this.menuMain.MenuItems.Add(this.mitemSize24);
         this.menuMain.Text = "Size";
         // 
         // mitemSize8
         // 
         this.mitemSize8.Text = "8 Point";
         this.mitemSize8.Click += new System.EventHandler(this.mitemSize8_Click);
         // 
         // mitemSize10
         // 
         this.mitemSize10.Checked = true;
         this.mitemSize10.Text = "10 Point";
         this.mitemSize10.Click += new System.EventHandler(this.mitemSize10_Click);
         // 
         // mitemSize12
         // 
         this.mitemSize12.Text = "12 Point";
         this.mitemSize12.Click += new System.EventHandler(this.mitemSize12_Click);
         // 
         // mitemSize14
         // 
         this.mitemSize14.Text = "14 Point";
         this.mitemSize14.Click += new System.EventHandler(this.mitemSize14_Click);
         // 
         // mitemSize18
         // 
         this.mitemSize18.Text = "18 Point";
         this.mitemSize18.Click += new System.EventHandler(this.mitemSize18_Click);
         // 
         // mitemSize24
         // 
         this.mitemSize24.Text = "24 Point";
         this.mitemSize24.Click += new System.EventHandler(this.mitemSize24_Click);
         // 
         // menuItem1
         // 
         this.menuItem1.MenuItems.Add(this.mitemFontMono);
         this.menuItem1.MenuItems.Add(this.mitemFontSans);
         this.menuItem1.MenuItems.Add(this.mitemFontSerif);
         this.menuItem1.Text = "Font";
         // 
         // mitemFontMono
         // 
         this.mitemFontMono.Checked = true;
         this.mitemFontMono.Text = "MonoSpace";
         this.mitemFontMono.Click += new System.EventHandler(this.mitemFontMono_Click);
         // 
         // mitemFontSans
         // 
         this.mitemFontSans.Checked = true;
         this.mitemFontSans.Text = "Sans Serif";
         this.mitemFontSans.Click += new System.EventHandler(this.mitemFontSans_Click);
         // 
         // mitemFontSerif
         // 
         this.mitemFontSerif.Checked = true;
         this.mitemFontSerif.Text = "Serif";
         this.mitemFontSerif.Click += new System.EventHandler(this.mitemFontSerif_Click);
         // 
         // mitemSize16
         // 
         this.mitemSize16.Text = "16 Point";
         this.mitemSize16.Click += new System.EventHandler(this.mitemSize16_Click);
         // 
         // FormMain
         // 
         this.Menu = this.mainMenu1;
         this.MinimizeBox = false;
         this.Text = "GenericFonts - 10 pt.";
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

      // Our private class data.
      private int m_ptSize = 10;

      private void 
      DisplayMonoFont(Graphics g, ref float x, ref float y)
      {
         // Create brush for standard text color.
         Brush brText = new SolidBrush(SystemColors.WindowText);

         // Create monospace regular m_ptSize pt font.
         Font font = new Font(FontFamily.GenericMonospace, m_ptSize, 
            FontStyle.Regular);
         string str = "Mono: ";
         g.DrawString(str, font, brText, x, y);
         SizeF sizeString = g.MeasureString(str, font);
         x += sizeString.Width;

         // Draw with monospace bold m_ptSize pt font.
         str = "Regular (" + font.Name + ")";
         g.DrawString(str, font, brText, x, y);
         sizeString = g.MeasureString(str, font);
         y += sizeString.Height;
         font.Dispose();

         // Create monospace italic m_ptSize pt font.
         font = new Font(FontFamily.GenericMonospace, m_ptSize, 
            FontStyle.Italic);
         str = "Italic";
         g.DrawString(str, font, brText, x, y);
         sizeString = g.MeasureString(str, font);
         y += sizeString.Height;
         font.Dispose();
           
         // Create monospace bold m_ptSize pt font.
         font = new Font(FontFamily.GenericMonospace, m_ptSize, 
            FontStyle.Bold);
         str = "Bold";
         g.DrawString(str, font, brText, x, y);
         sizeString = g.MeasureString(str, font);
         y += sizeString.Height;
         font.Dispose();
           
         // Create monospace strikeout m_ptSize pt font.
         font = new Font(FontFamily.GenericMonospace, m_ptSize, 
            FontStyle.Strikeout);
         str = "Strikeout";
         g.DrawString(str, font, brText, x, y);
         sizeString = g.MeasureString(str, font);
         y += sizeString.Height;
         font.Dispose();
           
         // Create monospace underline m_ptSize pt font.
         font = new Font(FontFamily.GenericMonospace, m_ptSize, 
            FontStyle.Underline);
         str = "Underline";
         g.DrawString(str, font, brText, x, y);
         sizeString = g.MeasureString(str, font);
         y += sizeString.Height;
         font.Dispose();

         // Add spacing between text blocks.
         y += sizeString.Height / 2;
      }


      private void 
      DisplaySansSerifFont(Graphics g, ref float x, ref float y)
      {
         // Create brush for standard text color.
         Brush brText = new SolidBrush(SystemColors.WindowText);

         // Create Sans Serif bold m_ptSize pt font.
         Font font = new Font(FontFamily.GenericSansSerif, 
            m_ptSize, FontStyle.Regular);
         string str = "SansSerif: ";
         x = 10;
         g.DrawString(str, font, brText, x, y);
         SizeF sizeString = g.MeasureString(str, font);
         x += sizeString.Width;

         // Draw with Sans Serif regular m_ptSize pt font.
         str = "Regular (" + font.Name + ")";
         g.DrawString(str, font, brText, x, y);
         sizeString = g.MeasureString(str, font);
         y += sizeString.Height;
         font.Dispose();

         // Create Sans Serif italic m_ptSize pt font.
         font = new Font(FontFamily.GenericSansSerif, m_ptSize, 
            FontStyle.Italic);
         str = "Italic";
         g.DrawString(str, font, brText, x, y);
         sizeString = g.MeasureString(str, font);
         y += sizeString.Height;
         font.Dispose();
           
         // Create Sans Serif bold m_ptSize pt font.
         font = new Font(FontFamily.GenericSansSerif, m_ptSize, 
            FontStyle.Bold);
         str = "Bold";
         g.DrawString(str, font, brText, x, y);
         sizeString = g.MeasureString(str, font);
         y += sizeString.Height;
         font.Dispose();
           
         // Create Sans Serif strikeout m_ptSize pt font.
         font = new Font(FontFamily.GenericSansSerif, m_ptSize, 
            FontStyle.Strikeout);
         str = "Strikeout";
         g.DrawString(str, font, brText, x, y);
         sizeString = g.MeasureString(str, font);
         y += sizeString.Height;
         font.Dispose();
           
         // Create Sans Serif underline m_ptSize pt font.
         font = new Font(FontFamily.GenericSansSerif, m_ptSize, 
            FontStyle.Underline);
         str = "Underline";
         g.DrawString(str, font, brText, x, y);
         sizeString = g.MeasureString(str, font);
         y += sizeString.Height;
         font.Dispose();

         // Add spacing between text blocks.
         y += sizeString.Height / 2;
      }

      private void 
      DisplaySerifFont(Graphics g, ref float x, ref float y)
      {
         // Create brush for standard text color.
         Brush brText = new SolidBrush(SystemColors.WindowText);

         // Create a serif regular m_ptSize point font.
         Font font = new Font(FontFamily.GenericSerif, m_ptSize, 
            FontStyle.Regular);
         string str = "Serif: ";
         x = 10;
         g.DrawString(str, font, brText, x, y);
         SizeF sizeString = g.MeasureString(str, font);
         x += sizeString.Width;

         // Draw with the serif regular m_ptSize point font.
         str = "Regular (" + font.Name + ")";
         g.DrawString(str, font, brText, x, y);
         sizeString = g.MeasureString(str, font);
         y += sizeString.Height;
         font.Dispose();

         // Create a serif italic m_ptSize point font.
         font = new Font(FontFamily.GenericSerif, m_ptSize, 
            FontStyle.Italic);
         str = "Italic";
         g.DrawString(str, font, brText, x, y);
         sizeString = g.MeasureString(str, font);
         y += sizeString.Height;
         font.Dispose();
           
         // Create a serif bold m_ptSize point font.
         font = new Font(FontFamily.GenericSerif, m_ptSize, 
            FontStyle.Bold);
         str = "Bold";
         g.DrawString(str, font, brText, x, y);
         sizeString = g.MeasureString(str, font);
         y += sizeString.Height;
         font.Dispose();
           
         // Create a serif strikeout m_ptSize point font.
         font = new Font(FontFamily.GenericSerif, m_ptSize, 
            FontStyle.Strikeout);
         str = "Strikeout";
         g.DrawString(str, font, brText, x, y);
         sizeString = g.MeasureString(str, font);
         y += sizeString.Height;
         font.Dispose();
           
         // Create a serif underline m_ptSize point font.
         font = new Font(FontFamily.GenericSerif, m_ptSize, 
            FontStyle.Underline);
         str = "Underline";
         g.DrawString(str, font, brText, x, y);
         sizeString = g.MeasureString(str, font);
         y += sizeString.Height;
         font.Dispose();

         // Add spacing between text blocks.
         y += sizeString.Height / 2;
      }


      private void 
      FormMain_Paint(object sender, 
      System.Windows.Forms.PaintEventArgs e)
      {
         Graphics g = e.Graphics;
         float x = 10;
         float y = 10;

         //
         //  GenericMonospace Font Styles
         //
         if (mitemFontMono.Checked)
         {
            DisplayMonoFont(g, ref x, ref y);
         }
           
         //
         //  GenericSansSerif Font Styles
         //
         if (mitemFontSans.Checked)
         {
            DisplaySansSerifFont(g, ref x, ref y);
         }
         
         //
         //  GenericSerif Font Styles
         //
         if (mitemFontSerif.Checked)
         {
            DisplaySerifFont(g, ref x, ref y);
         }
      }

      private void UncheckAllSizes()
      {
         mitemSize8.Checked = false;
         mitemSize10.Checked = false;
         mitemSize12.Checked = false;
         mitemSize14.Checked = false;
         mitemSize16.Checked = false;
         mitemSize18.Checked = false;
         mitemSize24.Checked = false;
      }

      private void mitemSize8_Click(object sender, System.EventArgs e)
      {
         UncheckAllSizes();
         mitemSize8.Checked = true;
         Text = "GenericFonts - 8 pt.";
         m_ptSize = 8;
         Invalidate();
      }

      private void mitemSize10_Click(object sender, System.EventArgs e)
      {
         UncheckAllSizes();
         mitemSize10.Checked = true;
         Text = "GenericFonts - 10 pt.";
         m_ptSize = 10;
         Invalidate();
      }

      private void mitemSize12_Click(object sender, System.EventArgs e)
      {
         UncheckAllSizes();
         mitemSize12.Checked = true;
         Text = "GenericFonts - 12 pt.";
         m_ptSize = 12;
         Invalidate();
      }

      private void mitemSize14_Click(object sender, System.EventArgs e)
      {
         UncheckAllSizes();
         mitemSize14.Checked = true;
         Text = "GenericFonts - 14 pt.";
         m_ptSize = 14;
         Invalidate();
      }

      private void mitemSize16_Click(object sender, System.EventArgs e)
      {
         UncheckAllSizes();
         mitemSize16.Checked = true;
         Text = "GenericFonts - 16 pt.";
         m_ptSize = 16;
         Invalidate();
      }

      private void mitemSize18_Click(object sender, System.EventArgs e)
      {
         UncheckAllSizes();
         mitemSize18.Checked = true;
         Text = "GenericFonts - 18 pt.";
         m_ptSize = 18;
         Invalidate();
      }

      private void mitemSize24_Click(object sender, System.EventArgs e)
      {
         UncheckAllSizes();
         mitemSize24.Checked = true;
         Text = "GenericFonts - 24 pt.";
         m_ptSize = 24;
         Invalidate();
      }

      private void mitemFontMono_Click(object sender, System.EventArgs e)
      {
         mitemFontMono.Checked = !mitemFontMono.Checked;
         Invalidate();
      }

      private void mitemFontSans_Click(object sender, System.EventArgs e)
      {
         mitemFontSans.Checked = !mitemFontSans.Checked;
         Invalidate();
      }

      private void mitemFontSerif_Click(object sender, System.EventArgs e)
      {
         mitemFontSerif.Checked = !mitemFontSerif.Checked;
         Invalidate();
      }


   } // class
} // namespace
