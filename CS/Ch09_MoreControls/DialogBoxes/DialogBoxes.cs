// DialogBoxes.cs - Main form for DialogBoxes sample.
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

namespace DialogBoxes
{
   /// <summary>
   /// DialogBoxes -- Displays two dialog boxes which show
   /// settings for a text box.
   /// </summary>
   public class FormMain : System.Windows.Forms.Form
   {
      private System.Windows.Forms.MainMenu menuMain;
      private System.Windows.Forms.MenuItem mitemEditPopup;
      private System.Windows.Forms.MenuItem mitemToolsPopup;
      private System.Windows.Forms.TextBox textInput;
      private System.Windows.Forms.ToolBar tbarCommands;
      private System.Windows.Forms.ToolBarButton tbbEditFormat;
      private System.Windows.Forms.ToolBarButton tbbViewOptions;
      private System.Windows.Forms.ImageList ilistCommands;
      private System.Windows.Forms.ContextMenu cmenuMain;
      private System.Windows.Forms.MenuItem mitemProgramMenu;
      private System.Windows.Forms.MenuItem mitemToolbar;
      private System.Windows.Forms.MenuItem mitemEditFont;
      private System.Windows.Forms.MenuItem mitemToolsOptions;

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
         System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormMain));
         this.menuMain = new System.Windows.Forms.MainMenu();
         this.mitemEditPopup = new System.Windows.Forms.MenuItem();
         this.mitemEditFont = new System.Windows.Forms.MenuItem();
         this.mitemToolsPopup = new System.Windows.Forms.MenuItem();
         this.mitemToolsOptions = new System.Windows.Forms.MenuItem();
         this.textInput = new System.Windows.Forms.TextBox();
         this.tbarCommands = new System.Windows.Forms.ToolBar();
         this.tbbEditFormat = new System.Windows.Forms.ToolBarButton();
         this.tbbViewOptions = new System.Windows.Forms.ToolBarButton();
         this.ilistCommands = new System.Windows.Forms.ImageList();
         this.cmenuMain = new System.Windows.Forms.ContextMenu();
         this.mitemProgramMenu = new System.Windows.Forms.MenuItem();
         this.mitemToolbar = new System.Windows.Forms.MenuItem();
         // 
         // menuMain
         // 
         this.menuMain.MenuItems.Add(this.mitemEditPopup);
         this.menuMain.MenuItems.Add(this.mitemToolsPopup);
         // 
         // mitemEditPopup
         // 
         this.mitemEditPopup.MenuItems.Add(this.mitemEditFont);
         this.mitemEditPopup.Text = "Edit";
         // 
         // mitemEditFont
         // 
         this.mitemEditFont.Text = "Font...";
         this.mitemEditFont.Click += new System.EventHandler(this.mitemEditFont_Click);
         // 
         // mitemToolsPopup
         // 
         this.mitemToolsPopup.MenuItems.Add(this.mitemToolsOptions);
         this.mitemToolsPopup.Text = "Tools";
         // 
         // mitemToolsOptions
         // 
         this.mitemToolsOptions.Text = "Options...";
         this.mitemToolsOptions.Click += new System.EventHandler(this.mitemToolsOptions_Click);
         // 
         // textInput
         // 
         this.textInput.Location = new System.Drawing.Point(8, 8);
         this.textInput.Multiline = true;
         this.textInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
         this.textInput.Size = new System.Drawing.Size(216, 224);
         this.textInput.Text = "Some text inside a textbox.";
         // 
         // tbarCommands
         // 
         this.tbarCommands.Buttons.Add(this.tbbEditFormat);
         this.tbarCommands.Buttons.Add(this.tbbViewOptions);
         this.tbarCommands.ImageList = this.ilistCommands;
         this.tbarCommands.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tbarCommands_ButtonClick);
         // 
         // tbbEditFormat
         // 
         this.tbbEditFormat.ImageIndex = 0;
         // 
         // tbbViewOptions
         // 
         this.tbbViewOptions.ImageIndex = 1;
         // 
         // ilistCommands
         // 
         this.ilistCommands.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
         this.ilistCommands.Images.Add(((System.Drawing.Image)(resources.GetObject("resource1"))));
         this.ilistCommands.ImageSize = new System.Drawing.Size(16, 16);
         // 
         // cmenuMain
         // 
         this.cmenuMain.MenuItems.Add(this.mitemProgramMenu);
         this.cmenuMain.MenuItems.Add(this.mitemToolbar);
         this.cmenuMain.Popup += new System.EventHandler(this.cmenuMain_Popup);
         // 
         // mitemProgramMenu
         // 
         this.mitemProgramMenu.Text = "Program Menu";
         this.mitemProgramMenu.Click += new System.EventHandler(this.mitemProgramMenu_Click);
         // 
         // mitemToolbar
         // 
         this.mitemToolbar.Text = "Toolbar";
         this.mitemToolbar.Click += new System.EventHandler(this.mitemToolbar_Click);
         // 
         // FormMain
         // 
         this.ContextMenu = this.cmenuMain;
         this.Controls.Add(this.textInput);
         this.Controls.Add(this.tbarCommands);
         this.MaximizeBox = false;
         this.Menu = this.menuMain;
         this.MinimizeBox = false;
         this.Text = "DialogBoxes";

      }
      #endregion

      /// <summary>
      /// The main entry point for the application.
      /// </summary>

      static void Main() 
      {
         Application.Run(new FormMain());
      }

      /// mitemEditFont - Respond to menu selection Edit->Font...
      private void mitemEditFont_Click(
         object sender, 
         System.EventArgs e)
      {
         DlgFont dlg = new DlgFont(this);

         // Initialize input values to dialog.
         dlg.strFontName = textInput.Font.Name;
         dlg.cemFontSize = textInput.Font.Size;
         FontStyle fsTemp = textInput.Font.Style;
         dlg.bBold = ((fsTemp & FontStyle.Bold) != 0);
         dlg.bItalic = ((fsTemp & FontStyle.Italic) != 0);
         dlg.bUnderline = ((fsTemp & FontStyle.Underline) != 0);

         // Summon dialog box.
         if (dlg.ShowDialog() != DialogResult.OK)
            return;

         // Modify settings based on user input.
         Font fontOld = textInput.Font;
         fsTemp = 0;
         if (dlg.bBold) fsTemp |= FontStyle.Bold;
         if (dlg.bItalic) fsTemp |= FontStyle.Italic;
         if (dlg.bUnderline) fsTemp |= FontStyle.Underline;
         textInput.Font = new Font(dlg.strFontName,
            dlg.cemFontSize, fsTemp);
         fontOld.Dispose();
      } // mitemEditFont_Click

      /// mitemToolsOptions -- Respond to menu selection
      /// Tools->Options...
      private void mitemToolsOptions_Click(
         object sender, 
         System.EventArgs e)
      {
         DlgToolsOptions dlg = new DlgToolsOptions(this);

         // Get flag for whether toolbar is being displayed
         bool bHasTB = this.Controls.Contains(tbarCommands);

         // Initialize input values to dialog.
         dlg.sbScrollBars = textInput.ScrollBars;
         dlg.bProgramMenu = (this.Menu != null);
         dlg.bToolbar = bHasTB;
         dlg.haTextAlign = textInput.TextAlign;
         dlg.bWordWrap = textInput.WordWrap;

         // Summon dialog box.
         if (dlg.ShowDialog() != DialogResult.OK)
            return;

         // Hide textbox to minimize redrawing time.
         textInput.Visible = false;

         // Modify settings based on user input.
         textInput.ScrollBars = dlg.sbScrollBars;
         this.Menu = (dlg.bProgramMenu) ? menuMain : null;

         // Do we need to add toolbar?
         // (adding a toolbar twice causes an
         //  exception, so we have to be careful)
         if(dlg.bToolbar && (!bHasTB))
            this.Controls.Add(tbarCommands);

         // Do we need to remove toolbar?
         // (okay to remove a toolbar twice -- we
         //  do the following to parallel the add code)
         if (bHasTB && (!dlg.bToolbar))
            this.Controls.Remove(tbarCommands);

         // Update text alignment.
         textInput.TextAlign = dlg.haTextAlign;

         // Update word-wrap setting.
         textInput.WordWrap = dlg.bWordWrap;

         // Make textbox visible again.
         textInput.Visible = true;

      } // mitemToolsOptions_Click

      /// tbarCommands_ButtonClick - Respond to ButtonClick
      /// event for toolbar tbarCommands
      private void tbarCommands_ButtonClick(
         object sender, 
         System.Windows.Forms.ToolBarButtonClickEventArgs e)
      {
         if (e.Button == tbbEditFormat)
         {
            mitemEditFont_Click(sender, e);
         }
         else if (e.Button == tbbViewOptions)
         {
            mitemToolsOptions_Click (sender, e);
         }
      }

      /// cmenuMain_Popup -- Handle Popup event for
      /// context menu. Set/clear check-mark on context
      /// menu items.
      private void cmenuMain_Popup(
         object sender, 
         System.EventArgs e)
      {
         bool bMenu = (this.Menu != null);
         mitemProgramMenu.Checked = bMenu;

         bool bTB = this.Controls.Contains(tbarCommands);
         mitemToolbar.Checked = bTB;
      }

      /// mitemProgramMenu_Click -- Handle Click on context
      /// menu to toggle visibility of program menu.
      private void mitemProgramMenu_Click(
         object sender, 
         System.EventArgs e)
      {
         this.Menu = (this.Menu == null) ? menuMain : null;
      }

      /// mitemToolbar_Click -- Handle Click on context
      /// menu to toggle visibility of toolbar.
      private void mitemToolbar_Click(
         object sender, 
         System.EventArgs e)
      {
         if (mitemToolbar.Checked)
            this.Controls.Remove(tbarCommands);
         else
            this.Controls.Add(tbarCommands);
      }
   } // class
} // namespace
