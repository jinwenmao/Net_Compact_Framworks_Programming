//-----------------------------------------------------------------------------
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace PropSheet
{
   /// <summary>
   /// Summary description for DlgFileProperties.
   /// </summary>
   public class DlgFileProperties : System.Windows.Forms.Form
   {
      private System.Windows.Forms.TabControl tabFileProperties;
      private System.Windows.Forms.TabPage tpageOptions;
      private System.Windows.Forms.TabPage tpageFont;
      private System.Windows.Forms.ComboBox comboTextAlign;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.CheckBox chkWordWrap;
      private System.Windows.Forms.RadioButton optNoScroll;
      private System.Windows.Forms.RadioButton optVertScroll;
      private System.Windows.Forms.RadioButton optHorzScroll;
      private System.Windows.Forms.RadioButton optBothScroll;
      private System.Windows.Forms.CheckBox chkToolbar;
      private System.Windows.Forms.CheckBox chkProgMenu;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.CheckBox chkUnderline;
      private System.Windows.Forms.CheckBox chkItalic;
      private System.Windows.Forms.CheckBox chkBold;
      private System.Windows.Forms.ComboBox comboSize;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.ComboBox comboFont;
      private System.Windows.Forms.MainMenu menuMain;
      private System.Windows.Forms.Label label5;
   
      public DlgFileProperties()
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
         this.tabFileProperties = new System.Windows.Forms.TabControl();
         this.tpageOptions = new System.Windows.Forms.TabPage();
         this.comboTextAlign = new System.Windows.Forms.ComboBox();
         this.label2 = new System.Windows.Forms.Label();
         this.chkWordWrap = new System.Windows.Forms.CheckBox();
         this.optNoScroll = new System.Windows.Forms.RadioButton();
         this.optVertScroll = new System.Windows.Forms.RadioButton();
         this.optHorzScroll = new System.Windows.Forms.RadioButton();
         this.optBothScroll = new System.Windows.Forms.RadioButton();
         this.chkToolbar = new System.Windows.Forms.CheckBox();
         this.chkProgMenu = new System.Windows.Forms.CheckBox();
         this.label1 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.tpageFont = new System.Windows.Forms.TabPage();
         this.chkUnderline = new System.Windows.Forms.CheckBox();
         this.chkItalic = new System.Windows.Forms.CheckBox();
         this.chkBold = new System.Windows.Forms.CheckBox();
         this.comboSize = new System.Windows.Forms.ComboBox();
         this.label4 = new System.Windows.Forms.Label();
         this.comboFont = new System.Windows.Forms.ComboBox();
         this.label5 = new System.Windows.Forms.Label();
         this.menuMain = new System.Windows.Forms.MainMenu();
         // 
         // tabFileProperties
         // 
         this.tabFileProperties.Controls.Add(this.tpageOptions);
         this.tabFileProperties.Controls.Add(this.tpageFont);
         this.tabFileProperties.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
         this.tabFileProperties.SelectedIndex = 0;
         this.tabFileProperties.Size = new System.Drawing.Size(240, 270);
         // 
         // tpageOptions
         // 
         this.tpageOptions.Controls.Add(this.comboTextAlign);
         this.tpageOptions.Controls.Add(this.label2);
         this.tpageOptions.Controls.Add(this.chkWordWrap);
         this.tpageOptions.Controls.Add(this.optNoScroll);
         this.tpageOptions.Controls.Add(this.optVertScroll);
         this.tpageOptions.Controls.Add(this.optHorzScroll);
         this.tpageOptions.Controls.Add(this.optBothScroll);
         this.tpageOptions.Controls.Add(this.chkToolbar);
         this.tpageOptions.Controls.Add(this.chkProgMenu);
         this.tpageOptions.Controls.Add(this.label1);
         this.tpageOptions.Controls.Add(this.label3);
         this.tpageOptions.Location = new System.Drawing.Point(4, 4);
         this.tpageOptions.Size = new System.Drawing.Size(232, 243);
         this.tpageOptions.Text = "Options";
         // 
         // comboTextAlign
         // 
         this.comboTextAlign.Items.Add("Left");
         this.comboTextAlign.Items.Add("Center");
         this.comboTextAlign.Items.Add("Right");
         this.comboTextAlign.Location = new System.Drawing.Point(152, 101);
         this.comboTextAlign.Size = new System.Drawing.Size(72, 22);
         // 
         // label2
         // 
         this.label2.Location = new System.Drawing.Point(152, 85);
         this.label2.Size = new System.Drawing.Size(72, 20);
         this.label2.Text = "Text Align:";
         // 
         // chkWordWrap
         // 
         this.chkWordWrap.Location = new System.Drawing.Point(144, 173);
         this.chkWordWrap.Size = new System.Drawing.Size(80, 20);
         this.chkWordWrap.Text = "Word wrap";
         // 
         // optNoScroll
         // 
         this.optNoScroll.Location = new System.Drawing.Point(32, 173);
         this.optNoScroll.Size = new System.Drawing.Size(56, 20);
         this.optNoScroll.Text = "None";
         // 
         // optVertScroll
         // 
         this.optVertScroll.Location = new System.Drawing.Point(32, 149);
         this.optVertScroll.Text = "Only vertical";
         // 
         // optHorzScroll
         // 
         this.optHorzScroll.Location = new System.Drawing.Point(32, 125);
         this.optHorzScroll.Size = new System.Drawing.Size(112, 20);
         this.optHorzScroll.Text = "Only horizontal";
         // 
         // optBothScroll
         // 
         this.optBothScroll.Location = new System.Drawing.Point(32, 101);
         this.optBothScroll.Size = new System.Drawing.Size(64, 20);
         this.optBothScroll.Text = "Both";
         // 
         // chkToolbar
         // 
         this.chkToolbar.Location = new System.Drawing.Point(144, 21);
         this.chkToolbar.Size = new System.Drawing.Size(72, 20);
         this.chkToolbar.Text = "Toolbar";
         // 
         // chkProgMenu
         // 
         this.chkProgMenu.Location = new System.Drawing.Point(24, 21);
         this.chkProgMenu.Text = "Program Menu";
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(24, 85);
         this.label1.Text = "Scroll Bars";
         // 
         // label3
         // 
         this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Underline);
         this.label3.Location = new System.Drawing.Point(0, 61);
         this.label3.Size = new System.Drawing.Size(232, 20);
         this.label3.Text = "Text Box Settings__________________";
         // 
         // tpageFont
         // 
         this.tpageFont.Controls.Add(this.chkUnderline);
         this.tpageFont.Controls.Add(this.chkItalic);
         this.tpageFont.Controls.Add(this.chkBold);
         this.tpageFont.Controls.Add(this.comboSize);
         this.tpageFont.Controls.Add(this.label4);
         this.tpageFont.Controls.Add(this.comboFont);
         this.tpageFont.Controls.Add(this.label5);
         this.tpageFont.Location = new System.Drawing.Point(4, 4);
         this.tpageFont.Size = new System.Drawing.Size(232, 243);
         this.tpageFont.Text = "Font";
         // 
         // chkUnderline
         // 
         this.chkUnderline.Location = new System.Drawing.Point(40, 149);
         this.chkUnderline.Text = "Underline";
         // 
         // chkItalic
         // 
         this.chkItalic.Location = new System.Drawing.Point(40, 125);
         this.chkItalic.Text = "Italic";
         // 
         // chkBold
         // 
         this.chkBold.Location = new System.Drawing.Point(40, 101);
         this.chkBold.Text = "Bold";
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
         this.comboSize.Location = new System.Drawing.Point(160, 61);
         this.comboSize.Size = new System.Drawing.Size(56, 22);
         // 
         // label4
         // 
         this.label4.Location = new System.Drawing.Point(160, 45);
         this.label4.Size = new System.Drawing.Size(56, 20);
         this.label4.Text = "Size:";
         // 
         // comboFont
         // 
         this.comboFont.Location = new System.Drawing.Point(16, 61);
         this.comboFont.Size = new System.Drawing.Size(120, 22);
         // 
         // label5
         // 
         this.label5.Location = new System.Drawing.Point(16, 45);
         this.label5.Size = new System.Drawing.Size(48, 20);
         this.label5.Text = "Font:";
         // 
         // DlgFileProperties
         // 
         this.ClientSize = new System.Drawing.Size(240, 293);
         this.Controls.Add(this.tabFileProperties);
         this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular);
         this.Menu = this.menuMain;
         this.Text = "PropSheet";

      }
      #endregion

      private void tpageOptions_EnabledChanged(object sender, System.EventArgs e)
      {
      
      }
   }
}
