// DlgFont.cs - Edit Font dialog box.
//
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DialogBoxes
{
   /// <summary>
   /// DlgFont -- Dialog box for font selection.
   /// </summary>
   public class DlgFont : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.ComboBox comboFont;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.ComboBox comboSize;
      private System.Windows.Forms.CheckBox chkBold;
      private System.Windows.Forms.CheckBox chkItalic;
      private System.Windows.Forms.CheckBox chkUnderline;

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
         this.label2 = new System.Windows.Forms.Label();
         this.comboFont = new System.Windows.Forms.ComboBox();
         this.label3 = new System.Windows.Forms.Label();
         this.comboSize = new System.Windows.Forms.ComboBox();
         this.chkBold = new System.Windows.Forms.CheckBox();
         this.chkItalic = new System.Windows.Forms.CheckBox();
         this.chkUnderline = new System.Windows.Forms.CheckBox();
         // 
         // label2
         // 
         this.label2.Location = new System.Drawing.Point(8, 32);
         this.label2.Size = new System.Drawing.Size(48, 20);
         this.label2.Text = "Font:";
         // 
         // comboFont
         // 
         this.comboFont.Location = new System.Drawing.Point(8, 48);
         this.comboFont.Size = new System.Drawing.Size(120, 22);
         // 
         // label3
         // 
         this.label3.Location = new System.Drawing.Point(152, 32);
         this.label3.Size = new System.Drawing.Size(56, 20);
         this.label3.Text = "Size:";
         // 
         // comboSize
         // 
         this.comboSize.Items.Add("8");
         this.comboSize.Items.Add("9");
         this.comboSize.Items.Add("10");
         this.comboSize.Items.Add("11");
         this.comboSize.Items.Add("12");
         this.comboSize.Items.Add("14");
         this.comboSize.Items.Add("16");
         this.comboSize.Items.Add("20");
         this.comboSize.Items.Add("24");
         this.comboSize.Items.Add("28");
         this.comboSize.Items.Add("36");
         this.comboSize.Location = new System.Drawing.Point(152, 48);
         this.comboSize.Size = new System.Drawing.Size(56, 22);
         // 
         // chkBold
         // 
         this.chkBold.Location = new System.Drawing.Point(32, 88);
         this.chkBold.Text = "Bold";
         // 
         // chkItalic
         // 
         this.chkItalic.Location = new System.Drawing.Point(32, 112);
         this.chkItalic.Text = "Italic";
         // 
         // chkUnderline
         // 
         this.chkUnderline.Location = new System.Drawing.Point(32, 136);
         this.chkUnderline.Text = "Underline";
         // 
         // DlgFont
         // 
         this.Controls.Add(this.chkUnderline);
         this.Controls.Add(this.chkItalic);
         this.Controls.Add(this.chkBold);
         this.Controls.Add(this.comboSize);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.comboFont);
         this.Controls.Add(this.label2);
         this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
         this.Text = "DialogBoxes";
         this.Load += new System.EventHandler(this.DlgFont_Load);
         this.Closed += new System.EventHandler(this.DlgFont_Closed);
         this.Paint += new System.Windows.Forms.PaintEventHandler(this.DlgFont_Paint);

      }
      #endregion

      // Our private data.
      private Control m_formParent;  // main form.

      // Public fields
      public string strFontName;
      public Single cemFontSize;
      public bool bBold;
      public bool bItalic;
      public bool bUnderline;

      public DlgFont(Control ctrlParent)
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         // Default values for public fields
         strFontName = string.Empty;
         cemFontSize = 10;
         bBold = false;
         bItalic = false;
         bUnderline = false;

         // Remember parent to help later in cleanup
         m_formParent = ctrlParent;
      }

      /// DlgFont_Load - Initialize dialog box controls.
      private void DlgFont_Load(
         object sender, 
         System.EventArgs e)
      {
         // Add font face names to comboFont combo box
         YaoDurant.Drawing.FontCollection fonts;
         int iCurrent = -1;
         try
         { 
            // Create managed code font collection.
            fonts = new YaoDurant.Drawing.FontCollection();

            // Loop through collection, adding all items to combo box
            for (int i = 0; i < fonts.Count; i++)
            {
               comboFont.Items.Add(fonts[i]); 
               if (strFontName == fonts[i])
                  iCurrent = i;
            }
            
            fonts.Dispose();
            fonts = null;

            // Set current face name.
            comboFont.SelectedIndex = iCurrent;

            // Set font size.
            string strFontSize = cemFontSize.ToString();
            comboSize.SelectedItem = strFontSize;

            // Set font styles.
            chkBold.Checked = bBold;
            chkItalic.Checked = bItalic;
            chkUnderline.Checked = bUnderline;

            // Hide parent.
            m_formParent.Visible = false;
         }
         catch
         {
            string str = "Error: cannot create FontCollection" +
               " -- make sure fontlist.dll is installed";
            MessageBox.Show(str, "DialogBox");
            DialogResult = DialogResult.Cancel;
            Close();
         }
      }

      /// DlgFont_Closed - Copy values from dialog controls to
      /// associated public fields.
      private void DlgFont_Closed(
         object sender, 
         System.EventArgs e)
      {
         if (DialogResult == DialogResult.Cancel)
            return;

         // Package up return values
         strFontName = comboFont.SelectedItem.ToString();
         Single sinTemp;
         try
         {
            string str = comboSize.SelectedItem.ToString();
            sinTemp = Single.Parse(str);
         }
         catch
         {
            sinTemp = 10;
         }
         cemFontSize = sinTemp;

         bBold = chkBold.Checked;
         bItalic = chkItalic.Checked;
         bUnderline = chkUnderline.Checked;

         // Show parent form.
        m_formParent.Visible = true;
      }

      /// DlgFont_Paint - Handle Paint event for dialog, which
      /// means draw a line and post name of dialog
      private void DlgFont_Paint(
         object sender,
         System.Windows.Forms.PaintEventArgs e)
      {
         Graphics g = e.Graphics;
         
         Brush brText;
         brText = new SolidBrush(SystemColors.ActiveCaption);
         g.DrawString("Font", Font, brText, 5, 5);

         Pen penBlack = new Pen(Color.Black);
         g.DrawLine(penBlack, 0, 25, 240, 25);
      }

   } // class
} // namespace
