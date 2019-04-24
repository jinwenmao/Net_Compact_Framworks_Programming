// FontPicker.cs - Enumerates fonts and allows user to pick
// font name, size, and style.
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

namespace FontPicker
{
   /// <summary>
   /// Program's main form.
   /// </summary>
   public class FormMain : System.Windows.Forms.Form
   {
      private System.Windows.Forms.ComboBox cboxFont;
      private System.Windows.Forms.ComboBox cboxSize;
      private System.Windows.Forms.TextBox textSample;
      private System.Windows.Forms.ComboBox cboxStyle;
      private System.Windows.Forms.MainMenu menuMain;

      public FormMain()
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         // Add font face names to cboxFont combo box
         try
         { 
            // Create managed code font collection.
            fonts = new YaoDurant.Drawing.FontCollection();

            // Loop through collection, adding all items to combo box
            for (int i = 0; i < fonts.Count; i++)
            {
               cboxFont.Items.Add(fonts[i]); 
            }
            
            fonts.Dispose();
            fonts = null;
         }
         catch
         {
            string str = "Error: cannot create FontCollection" +
               " -- make sure fontlist.dll is installed";
            MessageBox.Show(str, "FontPicker");
         }

         // Set initial font name, size, and style.
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
         this.menuMain = new System.Windows.Forms.MainMenu();
         this.cboxFont = new System.Windows.Forms.ComboBox();
         this.cboxSize = new System.Windows.Forms.ComboBox();
         this.textSample = new System.Windows.Forms.TextBox();
         this.cboxStyle = new System.Windows.Forms.ComboBox();
         // 
         // cboxFont
         // 
         this.cboxFont.Size = new System.Drawing.Size(128, 22);
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
         this.cboxSize.Items.Add("24");
         this.cboxSize.Items.Add("28");
         this.cboxSize.Items.Add("36");
         this.cboxSize.Items.Add("72");
         this.cboxSize.Location = new System.Drawing.Point(128, 0);
         this.cboxSize.Size = new System.Drawing.Size(40, 22);
         this.cboxSize.SelectedIndexChanged += new System.EventHandler(this.cboxSize_SelectedIndexChanged);
         // 
         // textSample
         // 
         this.textSample.Location = new System.Drawing.Point(16, 40);
         this.textSample.Multiline = true;
         this.textSample.Size = new System.Drawing.Size(208, 216);
         this.textSample.Text = "Sample Text";
         // 
         // cboxStyle
         // 
         this.cboxStyle.Items.Add("Regular");
         this.cboxStyle.Items.Add("Bold");
         this.cboxStyle.Items.Add("Italic");
         this.cboxStyle.Items.Add("Strikeout");
         this.cboxStyle.Items.Add("Underline");
         this.cboxStyle.Location = new System.Drawing.Point(168, 0);
         this.cboxStyle.Size = new System.Drawing.Size(72, 22);
         this.cboxStyle.SelectedIndexChanged += new System.EventHandler(this.cboxStyle_SelectedIndexChanged);
         // 
         // FormMain
         // 
         this.Controls.Add(this.cboxStyle);
         this.Controls.Add(this.textSample);
         this.Controls.Add(this.cboxSize);
         this.Controls.Add(this.cboxFont);
         this.Menu = this.menuMain;
         this.MinimizeBox = false;
         this.Text = "FontPicker";

      }
      #endregion

      /// <summary>
      /// The main entry point for the application.
      /// </summary>

      static void Main() 
      {
         Application.Run(new FormMain());
      }

      private YaoDurant.Drawing.FontCollection fonts;

      private void SetFont()
      {
         int iFont = cboxFont.SelectedIndex;
         int iSize = cboxSize.SelectedIndex;
         int iStyle = cboxStyle.SelectedIndex; 
         if (iFont != -1 && iSize != -1 && iStyle != -1)
         {
            string strFont = (string)cboxFont.Items[iFont];
            string strSize = (string)cboxSize.Items[iSize];
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
            textSample.Font = font;

            // Clean up font.
            font.Dispose();
         }
      }

      private void 
      cboxFont_SelectedIndexChanged(object sender, EventArgs e)
      {
         SetFont();
      }

      private void 
      cboxSize_SelectedIndexChanged(object sender, EventArgs e)
      {
         SetFont();
      }

      private void 
      cboxStyle_SelectedIndexChanged(object sender, EventArgs e)
      {
         SetFont();
      }

   } // class
} // namespace
