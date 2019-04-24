// DlgOptions.cs - Options dialog box.
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

namespace PrintHPMobile
{
   /// <summary>
   /// DlgOptions - Sample dialog box
   /// </summary>
   public class DlgToolsOptions : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.CheckBox chkProgMenu;
      private System.Windows.Forms.RadioButton optBothScroll;
      private System.Windows.Forms.RadioButton optHorzScroll;
      private System.Windows.Forms.RadioButton optVertScroll;
      private System.Windows.Forms.RadioButton optNoScroll;
      private System.Windows.Forms.ComboBox comboTextAlign;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.CheckBox chkWordWrap;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.CheckBox chkToolbar;

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
         this.chkProgMenu = new System.Windows.Forms.CheckBox();
         this.chkToolbar = new System.Windows.Forms.CheckBox();
         this.optBothScroll = new System.Windows.Forms.RadioButton();
         this.optHorzScroll = new System.Windows.Forms.RadioButton();
         this.optVertScroll = new System.Windows.Forms.RadioButton();
         this.optNoScroll = new System.Windows.Forms.RadioButton();
         this.comboTextAlign = new System.Windows.Forms.ComboBox();
         this.label2 = new System.Windows.Forms.Label();
         this.chkWordWrap = new System.Windows.Forms.CheckBox();
         this.label3 = new System.Windows.Forms.Label();
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(24, 120);
         this.label1.Text = "Scroll Bars";
         // 
         // chkProgMenu
         // 
         this.chkProgMenu.Location = new System.Drawing.Point(24, 56);
         this.chkProgMenu.Text = "Program Menu";
         // 
         // chkToolbar
         // 
         this.chkToolbar.Location = new System.Drawing.Point(144, 56);
         this.chkToolbar.Size = new System.Drawing.Size(72, 20);
         this.chkToolbar.Text = "Toolbar";
         // 
         // optBothScroll
         // 
         this.optBothScroll.Location = new System.Drawing.Point(32, 136);
         this.optBothScroll.Size = new System.Drawing.Size(64, 20);
         this.optBothScroll.Text = "Both";
         // 
         // optHorzScroll
         // 
         this.optHorzScroll.Location = new System.Drawing.Point(32, 160);
         this.optHorzScroll.Size = new System.Drawing.Size(112, 20);
         this.optHorzScroll.Text = "Only horizontal";
         // 
         // optVertScroll
         // 
         this.optVertScroll.Location = new System.Drawing.Point(32, 184);
         this.optVertScroll.Text = "Only vertical";
         // 
         // optNoScroll
         // 
         this.optNoScroll.Location = new System.Drawing.Point(32, 208);
         this.optNoScroll.Size = new System.Drawing.Size(56, 20);
         this.optNoScroll.Text = "None";
         // 
         // comboTextAlign
         // 
         this.comboTextAlign.Items.Add("Left");
         this.comboTextAlign.Items.Add("Center");
         this.comboTextAlign.Items.Add("Right");
         this.comboTextAlign.Location = new System.Drawing.Point(152, 136);
         this.comboTextAlign.Size = new System.Drawing.Size(72, 22);
         this.comboTextAlign.SelectedIndexChanged += new System.EventHandler(this.comboTextAlign_SelectedIndexChanged);
         // 
         // label2
         // 
         this.label2.Location = new System.Drawing.Point(152, 120);
         this.label2.Size = new System.Drawing.Size(72, 20);
         this.label2.Text = "Text Align:";
         // 
         // chkWordWrap
         // 
         this.chkWordWrap.Location = new System.Drawing.Point(144, 208);
         this.chkWordWrap.Size = new System.Drawing.Size(80, 20);
         this.chkWordWrap.Text = "Word wrap";
         this.chkWordWrap.CheckStateChanged += new System.EventHandler(this.chkWordWrap_CheckStateChanged);
         // 
         // label3
         // 
         this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Underline);
         this.label3.Location = new System.Drawing.Point(0, 96);
         this.label3.Size = new System.Drawing.Size(232, 20);
         this.label3.Text = "Text Box Settings__________________";
         // 
         // DlgToolsOptions
         // 
         this.Controls.Add(this.comboTextAlign);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.chkWordWrap);
         this.Controls.Add(this.optNoScroll);
         this.Controls.Add(this.optVertScroll);
         this.Controls.Add(this.optHorzScroll);
         this.Controls.Add(this.optBothScroll);
         this.Controls.Add(this.chkToolbar);
         this.Controls.Add(this.chkProgMenu);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.label3);
         this.Text = "PrintHPMobile";
         this.Load += new System.EventHandler(this.DlgToolsOptions_Load);
         this.Closed += new System.EventHandler(this.DlgToolsOptions_Closed);
         this.Paint += new System.Windows.Forms.PaintEventHandler(this.DlgToolsOptions_Paint);

      }
      #endregion

      // Our private data.
      private Control m_formParent;  // main form.

      // Public fields for initial & updated values.
      public ScrollBars sbScrollBars;
      public bool bProgramMenu;
      public bool bToolbar;
      public HorizontalAlignment haTextAlign;
      public bool bWordWrap;

      enum Align
      {
         Left = 0,
         Center,
         Right
      }

      public DlgToolsOptions(Control ctrlParent)
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         // Remember parent to help later in cleanup
         m_formParent = ctrlParent;

         // Set default values.
         sbScrollBars = ScrollBars.None;
         bProgramMenu = true;
         bToolbar = true;
         haTextAlign = HorizontalAlignment.Left;
         bWordWrap = false;
      }

      /// DlgToolsOptions_Load - Initialize dialog box controls.
      private void DlgToolsOptions_Load(
         object sender, 
         System.EventArgs e)
      {
         // For Pocket PC -- hide parent on load. 
         m_formParent.Visible = false;

         // Initialize scroll bar settings.
         switch(sbScrollBars)
         {
            case ScrollBars.Both:
               optBothScroll.Checked = true;
               break;
            case ScrollBars.Horizontal:
               optHorzScroll.Checked = true;
               break;
            case ScrollBars.Vertical:
               optVertScroll.Checked = true;
               break;
            case ScrollBars.None:
               optNoScroll.Checked = true;
               break;
         }

         // Initialize program menu & toolbar settings.
         chkProgMenu.Checked = bProgramMenu;
         chkToolbar.Checked = bToolbar;

         // Set text alignment
         if (haTextAlign == HorizontalAlignment.Left)
            comboTextAlign.SelectedIndex = (int)Align.Left;
         else if (haTextAlign == HorizontalAlignment.Center)
            comboTextAlign.SelectedIndex = (int)Align.Center;
         else
            comboTextAlign.SelectedIndex = (int)Align.Right;

         // Set word wrap
         chkWordWrap.Checked = bWordWrap;

         // Initialize constraints
         UpdateTextAlignConstraints();
         UpdateWordWrapConstraints();
      }

      /// DlgToolsOptions_Closed - Copy values from dialog
      /// controls to associated public fields.
      private void DlgToolsOptions_Closed(
         object sender, 
         System.EventArgs e)
      {
         // Make window visible when closing.
         m_formParent.Visible = true;

         // Update scrollbar setting.      
         if (optBothScroll.Checked)
            sbScrollBars = ScrollBars.Both;
         else if (optVertScroll.Checked)
            sbScrollBars = ScrollBars.Vertical;
         else if (optHorzScroll.Checked)
            sbScrollBars = ScrollBars.Horizontal;
         else
            sbScrollBars = ScrollBars.None;

         // Update program menu & toolbar settings.
         bProgramMenu = chkProgMenu.Checked;
         bToolbar = chkToolbar.Checked;

         // Update text alignment setting.
         Align iSel = (Align)comboTextAlign.SelectedIndex;
         if (iSel == Align.Left)
            haTextAlign = HorizontalAlignment.Left;
         else if (iSel == Align.Center)
            haTextAlign = HorizontalAlignment.Center;
         else
            haTextAlign = HorizontalAlignment.Right;

         // Update word wrap ssetting.
         bWordWrap = chkWordWrap.Checked;
      }

      /// DlgToolsOptions_Paint - Handle Paint event for dialog,
      /// which means draw a line and post name of dialog
      private void DlgToolsOptions_Paint(
         object sender, 
         System.Windows.Forms.PaintEventArgs e)
      {
         Graphics g = e.Graphics;

         Brush brText = new SolidBrush(SystemColors.ActiveCaption);
         g.DrawString("Options", Font, brText, 5, 5);

         Pen penBlack = new Pen(Color.Black);
         g.DrawLine(penBlack, 0, 25, 240, 25);
      }

      /// UpdateTextAlignConstraints -- When text alignment
      /// changes, update word wrap setting to reflect
      /// behavior of actual text box.
      private void UpdateTextAlignConstraints()
      {
         // Alignment center or right --
         // turn wordwrap *on* and disable.
         if (comboTextAlign.SelectedIndex != (int)Align.Left)
         {
            chkWordWrap.Checked = true;
            chkWordWrap.Enabled = false;
         }
         else
         {
            // Alignment left --
            // enable wordwrap
            chkWordWrap.Enabled = true;
         }
      }

      /// UpdateWordWrapConstraints -- when word wrap
      /// changes, update scroll bar settings to reflect
      /// actual behavior of text box.
      private void UpdateWordWrapConstraints()
      {
         if (chkWordWrap.Checked)
         {
            if (optBothScroll.Checked)
            {
               optBothScroll.Checked = false;
               optVertScroll.Checked = true;
            }
            else if (optHorzScroll.Checked)
            {
               optHorzScroll.Checked = false;
               optNoScroll.Checked = true;
            }
            optBothScroll.Enabled = false;
            optHorzScroll.Enabled = false;
         }
         else
         {
            optBothScroll.Enabled = true;
            optHorzScroll.Enabled = true;
         }
      }

      /// comboTextAlign_SelectedIndexChanged - Handle change to
      /// text alignment value
      private void comboTextAlign_SelectedIndexChanged(
         object sender, 
         System.EventArgs e)
      {
         UpdateTextAlignConstraints();
      }

      /// chkWordWrap_CheckStateChanged - Handle change to
      /// wordwrap checkbox
      private void chkWordWrap_CheckStateChanged(
         object sender, 
         System.EventArgs e)
      {
         UpdateWordWrapConstraints();
      }

   } // class
} // namespace
