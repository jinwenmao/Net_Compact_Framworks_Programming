//-----------------------------------------------------------------------------
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;

namespace Toolbar
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class FormMain : System.Windows.Forms.Form
   {
      private System.Windows.Forms.MainMenu menuMain;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Button cmdAdd1;
      private System.Windows.Forms.Button cmdRemove1;
      private System.Windows.Forms.Button cmdAdd2;
      private System.Windows.Forms.Button cmdRemove2;
      private System.Windows.Forms.Button cmdShowMenu;
      private System.Windows.Forms.MenuItem mitemFile;
      private System.Windows.Forms.MenuItem mitemFileNew;
      private System.Windows.Forms.MenuItem mitemFileOpen;
      private System.Windows.Forms.MenuItem mitemFileSave;
      private System.Windows.Forms.MenuItem mitemFileSaveAs;
      private System.Windows.Forms.MenuItem mitemSep1;
      private System.Windows.Forms.MenuItem mitemFileExit;
      private System.Windows.Forms.MenuItem mitemEdit;
      private System.Windows.Forms.MenuItem mitemEditCut;
      private System.Windows.Forms.MenuItem mitemEditCopy;
      private System.Windows.Forms.MenuItem mitemEditPaste;
      private System.Windows.Forms.MenuItem mitemSep2;
      private System.Windows.Forms.MenuItem mitemEditUndo;
      private System.Windows.Forms.MenuItem mitemEditClear;
      private System.Windows.Forms.ImageList ilistEdit;
      private System.Windows.Forms.ToolBar tbarEdit;
      private System.Windows.Forms.ToolBar tbarFile;
      private System.Windows.Forms.ImageList ilistFile;
      private System.Windows.Forms.MenuItem mitemFilePrint;
      private System.Windows.Forms.MenuItem menuItem2;
      private System.Windows.Forms.ToolBarButton tbbCut;
      private System.Windows.Forms.ToolBarButton tbbCopy;
      private System.Windows.Forms.ToolBarButton tbbPaste;
      private System.Windows.Forms.ToolBarButton tbbUndo;
      private System.Windows.Forms.ToolBarButton tbbClear;
      private System.Windows.Forms.ToolBarButton tbbNew;
      private System.Windows.Forms.ToolBarButton tbbOpen;
      private System.Windows.Forms.ToolBarButton tbbSave;
      private System.Windows.Forms.ToolBarButton tbbPrint;
      private System.Windows.Forms.MenuItem mitem16x16;
      private System.Windows.Forms.MenuItem mitem20x20;
      private System.Windows.Forms.MenuItem mitem24x24;
      private System.Windows.Forms.MenuItem mitem32x32;
      private System.Windows.Forms.MenuItem menuItem5;
      private System.Windows.Forms.MenuItem mitem18x18;
      private System.Windows.Forms.MenuItem mitem12x12;
      private System.Windows.Forms.MenuItem mitem12x20;
      private System.Windows.Forms.MenuItem mitem16x20;
      private System.Windows.Forms.MenuItem mitem14x20;
      private System.Windows.Forms.MenuItem mitem18x20;
      private System.Windows.Forms.MenuItem menuSizePopup;
      private System.Windows.Forms.MenuItem mitem14x14;
      private System.Windows.Forms.MenuItem menuItem3;
      private System.Windows.Forms.Button cmdHideMenu;

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
         System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormMain));
         this.menuMain = new System.Windows.Forms.MainMenu();
         this.mitemFile = new System.Windows.Forms.MenuItem();
         this.mitemFileNew = new System.Windows.Forms.MenuItem();
         this.mitemFileOpen = new System.Windows.Forms.MenuItem();
         this.mitemFileSave = new System.Windows.Forms.MenuItem();
         this.mitemFileSaveAs = new System.Windows.Forms.MenuItem();
         this.mitemSep1 = new System.Windows.Forms.MenuItem();
         this.mitemFilePrint = new System.Windows.Forms.MenuItem();
         this.menuItem2 = new System.Windows.Forms.MenuItem();
         this.mitemFileExit = new System.Windows.Forms.MenuItem();
         this.mitemEdit = new System.Windows.Forms.MenuItem();
         this.mitemEditCut = new System.Windows.Forms.MenuItem();
         this.mitemEditCopy = new System.Windows.Forms.MenuItem();
         this.mitemEditPaste = new System.Windows.Forms.MenuItem();
         this.mitemSep2 = new System.Windows.Forms.MenuItem();
         this.mitemEditUndo = new System.Windows.Forms.MenuItem();
         this.mitemEditClear = new System.Windows.Forms.MenuItem();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.cmdAdd1 = new System.Windows.Forms.Button();
         this.cmdRemove1 = new System.Windows.Forms.Button();
         this.cmdAdd2 = new System.Windows.Forms.Button();
         this.cmdRemove2 = new System.Windows.Forms.Button();
         this.cmdShowMenu = new System.Windows.Forms.Button();
         this.cmdHideMenu = new System.Windows.Forms.Button();
         this.ilistEdit = new System.Windows.Forms.ImageList();
         this.tbarEdit = new System.Windows.Forms.ToolBar();
         this.tbbCut = new System.Windows.Forms.ToolBarButton();
         this.tbbCopy = new System.Windows.Forms.ToolBarButton();
         this.tbbPaste = new System.Windows.Forms.ToolBarButton();
         this.tbbUndo = new System.Windows.Forms.ToolBarButton();
         this.tbbClear = new System.Windows.Forms.ToolBarButton();
         this.tbarFile = new System.Windows.Forms.ToolBar();
         this.tbbNew = new System.Windows.Forms.ToolBarButton();
         this.tbbOpen = new System.Windows.Forms.ToolBarButton();
         this.tbbSave = new System.Windows.Forms.ToolBarButton();
         this.tbbPrint = new System.Windows.Forms.ToolBarButton();
         this.ilistFile = new System.Windows.Forms.ImageList();
         this.menuSizePopup = new System.Windows.Forms.MenuItem();
         this.mitem16x16 = new System.Windows.Forms.MenuItem();
         this.mitem20x20 = new System.Windows.Forms.MenuItem();
         this.mitem24x24 = new System.Windows.Forms.MenuItem();
         this.mitem32x32 = new System.Windows.Forms.MenuItem();
         this.mitem18x18 = new System.Windows.Forms.MenuItem();
         this.menuItem5 = new System.Windows.Forms.MenuItem();
         this.mitem12x20 = new System.Windows.Forms.MenuItem();
         this.mitem16x20 = new System.Windows.Forms.MenuItem();
         this.mitem14x20 = new System.Windows.Forms.MenuItem();
         this.mitem18x20 = new System.Windows.Forms.MenuItem();
         this.mitem12x12 = new System.Windows.Forms.MenuItem();
         this.mitem14x14 = new System.Windows.Forms.MenuItem();
         this.menuItem3 = new System.Windows.Forms.MenuItem();
         // 
         // menuMain
         // 
         this.menuMain.MenuItems.Add(this.mitemFile);
         this.menuMain.MenuItems.Add(this.mitemEdit);
         this.menuMain.MenuItems.Add(this.menuSizePopup);
         // 
         // mitemFile
         // 
         this.mitemFile.MenuItems.Add(this.mitemFileNew);
         this.mitemFile.MenuItems.Add(this.mitemFileOpen);
         this.mitemFile.MenuItems.Add(this.mitemFileSave);
         this.mitemFile.MenuItems.Add(this.mitemFileSaveAs);
         this.mitemFile.MenuItems.Add(this.mitemSep1);
         this.mitemFile.MenuItems.Add(this.mitemFilePrint);
         this.mitemFile.MenuItems.Add(this.menuItem2);
         this.mitemFile.MenuItems.Add(this.mitemFileExit);
         this.mitemFile.Text = "File";
         // 
         // mitemFileNew
         // 
         this.mitemFileNew.Text = "New";
         // 
         // mitemFileOpen
         // 
         this.mitemFileOpen.Text = "Open...";
         // 
         // mitemFileSave
         // 
         this.mitemFileSave.Text = "Save";
         // 
         // mitemFileSaveAs
         // 
         this.mitemFileSaveAs.Text = "Save As...";
         // 
         // mitemSep1
         // 
         this.mitemSep1.Text = "-";
         // 
         // mitemFilePrint
         // 
         this.mitemFilePrint.Text = "Print";
         // 
         // menuItem2
         // 
         this.menuItem2.Text = "-";
         // 
         // mitemFileExit
         // 
         this.mitemFileExit.Text = "Exit";
         // 
         // mitemEdit
         // 
         this.mitemEdit.MenuItems.Add(this.mitemEditCut);
         this.mitemEdit.MenuItems.Add(this.mitemEditCopy);
         this.mitemEdit.MenuItems.Add(this.mitemEditPaste);
         this.mitemEdit.MenuItems.Add(this.mitemSep2);
         this.mitemEdit.MenuItems.Add(this.mitemEditUndo);
         this.mitemEdit.MenuItems.Add(this.mitemEditClear);
         this.mitemEdit.Text = "Edit";
         // 
         // mitemEditCut
         // 
         this.mitemEditCut.Text = "Cut";
         // 
         // mitemEditCopy
         // 
         this.mitemEditCopy.Text = "Copy";
         // 
         // mitemEditPaste
         // 
         this.mitemEditPaste.Text = "Paste";
         // 
         // mitemSep2
         // 
         this.mitemSep2.Text = "-";
         // 
         // mitemEditUndo
         // 
         this.mitemEditUndo.Text = "Undo";
         // 
         // mitemEditClear
         // 
         this.mitemEditClear.Text = "Clear";
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(16, 40);
         this.label1.Size = new System.Drawing.Size(64, 40);
         this.label1.Text = "File Toolbar:";
         this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // label2
         // 
         this.label2.Location = new System.Drawing.Point(16, 88);
         this.label2.Size = new System.Drawing.Size(64, 32);
         this.label2.Text = "Edit Toolbar:";
         this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // label3
         // 
         this.label3.Location = new System.Drawing.Point(24, 136);
         this.label3.Size = new System.Drawing.Size(56, 32);
         this.label3.Text = "Program Menu:";
         this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // cmdAdd1
         // 
         this.cmdAdd1.Location = new System.Drawing.Point(96, 48);
         this.cmdAdd1.Size = new System.Drawing.Size(64, 20);
         this.cmdAdd1.Text = "Add";
         this.cmdAdd1.Click += new System.EventHandler(this.cmdAdd1_Click);
         // 
         // cmdRemove1
         // 
         this.cmdRemove1.Location = new System.Drawing.Point(168, 48);
         this.cmdRemove1.Size = new System.Drawing.Size(64, 20);
         this.cmdRemove1.Text = "Remove";
         this.cmdRemove1.Click += new System.EventHandler(this.cmdRemove1_Click);
         // 
         // cmdAdd2
         // 
         this.cmdAdd2.Location = new System.Drawing.Point(96, 96);
         this.cmdAdd2.Size = new System.Drawing.Size(64, 20);
         this.cmdAdd2.Text = "Add";
         this.cmdAdd2.Click += new System.EventHandler(this.cmdAdd2_Click);
         // 
         // cmdRemove2
         // 
         this.cmdRemove2.Location = new System.Drawing.Point(168, 96);
         this.cmdRemove2.Size = new System.Drawing.Size(64, 20);
         this.cmdRemove2.Text = "Remove";
         this.cmdRemove2.Click += new System.EventHandler(this.cmdRemove2_Click);
         // 
         // cmdShowMenu
         // 
         this.cmdShowMenu.Location = new System.Drawing.Point(96, 144);
         this.cmdShowMenu.Size = new System.Drawing.Size(64, 20);
         this.cmdShowMenu.Text = "Show";
         this.cmdShowMenu.Click += new System.EventHandler(this.cmdShowMenu_Click);
         // 
         // cmdHideMenu
         // 
         this.cmdHideMenu.Location = new System.Drawing.Point(168, 144);
         this.cmdHideMenu.Size = new System.Drawing.Size(64, 20);
         this.cmdHideMenu.Text = "Hide";
         this.cmdHideMenu.Click += new System.EventHandler(this.cmdHideMenu_Click);
         // 
         // ilistEdit
         // 
         this.ilistEdit.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
         this.ilistEdit.Images.Add(((System.Drawing.Image)(resources.GetObject("resource1"))));
         this.ilistEdit.Images.Add(((System.Drawing.Image)(resources.GetObject("resource2"))));
         this.ilistEdit.Images.Add(((System.Drawing.Image)(resources.GetObject("resource3"))));
         this.ilistEdit.Images.Add(((System.Drawing.Image)(resources.GetObject("resource4"))));
         this.ilistEdit.ImageSize = new System.Drawing.Size(16, 16);
         // 
         // tbarEdit
         // 
         this.tbarEdit.Buttons.Add(this.tbbCut);
         this.tbarEdit.Buttons.Add(this.tbbCopy);
         this.tbarEdit.Buttons.Add(this.tbbPaste);
         this.tbarEdit.Buttons.Add(this.tbbUndo);
         this.tbarEdit.Buttons.Add(this.tbbClear);
         this.tbarEdit.ImageList = this.ilistEdit;
         this.tbarEdit.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tbarEdit_ButtonClick);
         // 
         // tbbCut
         // 
         this.tbbCut.ImageIndex = 0;
         // 
         // tbbCopy
         // 
         this.tbbCopy.ImageIndex = 1;
         // 
         // tbbPaste
         // 
         this.tbbPaste.ImageIndex = 2;
         // 
         // tbbUndo
         // 
         this.tbbUndo.ImageIndex = 3;
         // 
         // tbbClear
         // 
         this.tbbClear.ImageIndex = 4;
         // 
         // tbarFile
         // 
         this.tbarFile.Buttons.Add(this.tbbNew);
         this.tbarFile.Buttons.Add(this.tbbOpen);
         this.tbarFile.Buttons.Add(this.tbbSave);
         this.tbarFile.Buttons.Add(this.tbbPrint);
         this.tbarFile.ImageList = this.ilistFile;
         this.tbarFile.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tbarFile_ButtonClick);
         // 
         // tbbNew
         // 
         this.tbbNew.ImageIndex = 0;
         // 
         // tbbOpen
         // 
         this.tbbOpen.ImageIndex = 1;
         // 
         // tbbSave
         // 
         this.tbbSave.ImageIndex = 2;
         // 
         // tbbPrint
         // 
         this.tbbPrint.ImageIndex = 3;
         // 
         // ilistFile
         // 
         this.ilistFile.Images.Add(((System.Drawing.Image)(resources.GetObject("resource5"))));
         this.ilistFile.Images.Add(((System.Drawing.Image)(resources.GetObject("resource6"))));
         this.ilistFile.Images.Add(((System.Drawing.Image)(resources.GetObject("resource7"))));
         this.ilistFile.Images.Add(((System.Drawing.Image)(resources.GetObject("resource8"))));
         this.ilistFile.ImageSize = new System.Drawing.Size(16, 16);
         // 
         // menuSizePopup
         // 
         this.menuSizePopup.MenuItems.Add(this.mitem12x12);
         this.menuSizePopup.MenuItems.Add(this.mitem12x20);
         this.menuSizePopup.MenuItems.Add(this.mitem14x14);
         this.menuSizePopup.MenuItems.Add(this.mitem14x20);
         this.menuSizePopup.MenuItems.Add(this.menuItem3);
         this.menuSizePopup.MenuItems.Add(this.mitem16x16);
         this.menuSizePopup.MenuItems.Add(this.mitem16x20);
         this.menuSizePopup.MenuItems.Add(this.mitem18x18);
         this.menuSizePopup.MenuItems.Add(this.mitem18x20);
         this.menuSizePopup.MenuItems.Add(this.mitem20x20);
         this.menuSizePopup.MenuItems.Add(this.menuItem5);
         this.menuSizePopup.MenuItems.Add(this.mitem24x24);
         this.menuSizePopup.MenuItems.Add(this.mitem32x32);
         this.menuSizePopup.Text = "Size";
         // 
         // mitem16x16
         // 
         this.mitem16x16.Text = "16x16";
         this.mitem16x16.Click += new System.EventHandler(this.mitem16x16_Click);
         // 
         // mitem20x20
         // 
         this.mitem20x20.Text = "20x20";
         this.mitem20x20.Click += new System.EventHandler(this.mitem20x20_Click);
         // 
         // mitem24x24
         // 
         this.mitem24x24.Text = "24x24";
         this.mitem24x24.Click += new System.EventHandler(this.mitem24x24_Click);
         // 
         // mitem32x32
         // 
         this.mitem32x32.Text = "32x32";
         this.mitem32x32.Click += new System.EventHandler(this.mitem32x32_Click);
         // 
         // mitem18x18
         // 
         this.mitem18x18.Text = "18x18";
         this.mitem18x18.Click += new System.EventHandler(this.mitem18x18_Click);
         // 
         // menuItem5
         // 
         this.menuItem5.Text = "-";
         // 
         // mitem12x20
         // 
         this.mitem12x20.Text = "12x20";
         this.mitem12x20.Click += new System.EventHandler(this.mitem12x20_Click);
         // 
         // mitem16x20
         // 
         this.mitem16x20.Text = "16x20";
         this.mitem16x20.Click += new System.EventHandler(this.mitem16x20_Click);
         // 
         // mitem14x20
         // 
         this.mitem14x20.Text = "14x20";
         this.mitem14x20.Click += new System.EventHandler(this.mitem14x20_Click);
         // 
         // mitem18x20
         // 
         this.mitem18x20.Text = "18x20";
         this.mitem18x20.Click += new System.EventHandler(this.mitem18x20_Click);
         // 
         // mitem12x12
         // 
         this.mitem12x12.Text = "12x12";
         this.mitem12x12.Click += new System.EventHandler(this.mitem12x12_Click);
         // 
         // mitem14x14
         // 
         this.mitem14x14.Text = "14x14";
         this.mitem14x14.Click += new System.EventHandler(this.mitem14x14_Click);
         // 
         // menuItem3
         // 
         this.menuItem3.Text = "-";
         // 
         // FormMain
         // 
         this.Controls.Add(this.cmdHideMenu);
         this.Controls.Add(this.cmdShowMenu);
         this.Controls.Add(this.cmdRemove2);
         this.Controls.Add(this.cmdAdd2);
         this.Controls.Add(this.cmdRemove1);
         this.Controls.Add(this.cmdAdd1);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.tbarFile);
         this.Menu = this.menuMain;
         this.MinimizeBox = false;
         this.Text = "ToolBar";
         this.Load += new System.EventHandler(this.FormMain_Load);

      }
      #endregion

      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      static void Main() 
      {
         Application.Run(new FormMain());
      }

      // Remember currently-selected toolbar
      private System.Windows.Forms.ToolBar m_tbarCurrent;

      private void FormMain_Load(
         object sender, 
         System.EventArgs e)
      {
         // Disconnect both toolbars, so we always know which
         // toolbar we start with (can change this inadvertently
         // in forms designer.
         this.Controls.Remove(tbarEdit);
         this.Controls.Remove(tbarFile);

         m_tbarCurrent = tbarFile;
         this.Controls.Add(m_tbarCurrent);
      }

      private void cmdAdd1_Click(
         object sender, 
         System.EventArgs e)
      {
         Controls.Add(tbarFile);
         m_tbarCurrent = tbarFile;
      }

      private void cmdRemove1_Click(
         object sender, 
         System.EventArgs e)
      {
         Controls.Remove(tbarFile);
         if (m_tbarCurrent == tbarFile)
            m_tbarCurrent = null;
      }

      private void cmdAdd2_Click(
         object sender, 
         System.EventArgs e)
      {
         Controls.Add(tbarEdit);
         m_tbarCurrent = tbarEdit;
      }

      private void cmdRemove2_Click(
         object sender, 
         System.EventArgs e)
      {
         Controls.Remove(tbarEdit);
         if (m_tbarCurrent == tbarEdit)
            m_tbarCurrent = null;
      }

      private void cmdShowMenu_Click(
         object sender, 
         System.EventArgs e)
      {
         this.Menu = menuMain;
      }

      private void cmdHideMenu_Click(
         object sender, 
         System.EventArgs e)
      {
         this.Menu = null;
      }

      private void ResetImageListSize(
         int cxWidth, 
         int cyHeight)
      {
         this.ilistEdit.ImageSize = 
            new System.Drawing.Size(cxWidth, cyHeight);
         this.ilistFile.ImageSize = 
            new System.Drawing.Size(cxWidth, cyHeight);
         if (m_tbarCurrent != null)
         {
            this.Controls.Remove(m_tbarCurrent);
            this.Controls.Add(m_tbarCurrent);
         }
      }

      private void ToggleMenuCheckMark(
         MenuItem mitemSender)
      {
         // Clear check mark from all other menu items.
         int citems = menuSizePopup.MenuItems.Count;
         for (int i = 0; i < citems; i++)
         {
            menuSizePopup.MenuItems[i].Checked = false;
         }

         // Set check mark on requested menu item.
         mitemSender.Checked = true;
      }

      private void mitem12x12_Click(
         object sender, System.EventArgs e)
      {
         ResetImageListSize(12,12);
         ToggleMenuCheckMark((MenuItem)sender);
      }

      private void mitem12x20_Click(
         object sender, System.EventArgs e)
      {
         ResetImageListSize(12,20);
         ToggleMenuCheckMark((MenuItem)sender);
      }

      private void mitem14x14_Click(
         object sender, System.EventArgs e)
      {
         ResetImageListSize(14,14);
         ToggleMenuCheckMark((MenuItem)sender);
      }

      private void mitem14x20_Click(
         object sender, System.EventArgs e)
      {
         ResetImageListSize(14,20);
         ToggleMenuCheckMark((MenuItem)sender);
      }
      private void mitem16x16_Click(
         object sender, System.EventArgs e)
      {
         ResetImageListSize(16,16);
         ToggleMenuCheckMark((MenuItem)sender);
      }

      private void mitem16x20_Click(
         object sender, System.EventArgs e)
      {
         ResetImageListSize(16,20);
         ToggleMenuCheckMark((MenuItem)sender);
      }

      private void mitem18x18_Click(
         object sender, System.EventArgs e)
      {
         ResetImageListSize(18,18);
         ToggleMenuCheckMark((MenuItem)sender);
      }

      private void mitem18x20_Click(
         object sender, System.EventArgs e)
      {
         ResetImageListSize(18,20);
         ToggleMenuCheckMark((MenuItem)sender);
      }

      private void mitem20x20_Click(
         object sender, System.EventArgs e)
      {
         ResetImageListSize(20,20);
         ToggleMenuCheckMark((MenuItem)sender);
      }

      private void mitem24x24_Click(
         object sender, System.EventArgs e)
      {
         ResetImageListSize(24,24);
         ToggleMenuCheckMark((MenuItem)sender);
      }

      private void mitem32x32_Click(
         object sender, System.EventArgs e)
      {
         ResetImageListSize(32,32);
         ToggleMenuCheckMark((MenuItem)sender);
      }

      private void tbarFile_ButtonClick(
         object sender, 
         System.Windows.Forms.ToolBarButtonClickEventArgs e)
      {
         string strButtonName = string.Empty;
         if (e.Button == tbbNew)
         {
            strButtonName = "tbbNew";
         }
         else if (e.Button ==  tbbOpen)
         {
            strButtonName = "tbbOpen";
         }
         else if (e.Button == tbbSave)
         {
            strButtonName = "tbbSave";
         }
         else if (e.Button == tbbPrint)
         {
            strButtonName = "tbbPrint";
         }
         
         MessageBox.Show("User clicked " + strButtonName + 
         " tool bar button.");
      }

      private void tbarEdit_ButtonClick(
         object sender, 
         System.Windows.Forms.ToolBarButtonClickEventArgs e)
      {
         string strButtonName = string.Empty;
         if (e.Button == tbbCut)
         {
            strButtonName = "tbbCut";
         }
         else if (e.Button ==  tbbCopy)
         {
            strButtonName = "tbbCopy";
         }
         else if (e.Button == tbbPaste)
         {
            strButtonName = "tbbPaste";
         }
         else if (e.Button == tbbUndo)
         {
            strButtonName = "tbbUndo";
         }
         else if (e.Button == tbbClear)
         {
            strButtonName = "tbbClear";
         }
         
         MessageBox.Show("User clicked " + strButtonName + 
            " tool bar button.");
      }

   } // class
} // namespace
