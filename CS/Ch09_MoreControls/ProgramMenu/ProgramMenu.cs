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

namespace ProgramMenu
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class FormMain : System.Windows.Forms.Form
   {
      private System.Windows.Forms.MenuItem menuItem1;
      private System.Windows.Forms.MainMenu menuStartup;
      private System.Windows.Forms.MenuItem mitemNewDocument;
      private System.Windows.Forms.MenuItem mitemNewCheckServer;
      private System.Windows.Forms.Button cmdHideMenus;
      private System.Windows.Forms.Button cmdShowStartupMenu;
      private System.Windows.Forms.Button cmdShowEditMenu;
      private System.Windows.Forms.Button cmdEmptyMenu;
      private System.Windows.Forms.MainMenu menuEmpty;
      private System.Windows.Forms.MenuItem mitemNewHTML;
      internal System.Windows.Forms.MainMenu menuEdit;
      internal System.Windows.Forms.MenuItem menuItem2;
      internal System.Windows.Forms.MenuItem mitemEditUndo;
      internal System.Windows.Forms.MenuItem mitemEditRedo;
      internal System.Windows.Forms.MenuItem menuItem7;
      internal System.Windows.Forms.MenuItem mitemEditCut;
      internal System.Windows.Forms.MenuItem mitemEditCopy;
      internal System.Windows.Forms.MenuItem mitemEditPaste;
      internal System.Windows.Forms.MenuItem mitemEditClear;
      internal System.Windows.Forms.MenuItem mitemEditSelectAll;
      internal System.Windows.Forms.MenuItem menuItem13;
      internal System.Windows.Forms.MenuItem mitemEditFill;
      internal System.Windows.Forms.MenuItem menuItem15;
      internal System.Windows.Forms.MenuItem mitemEditRename;
      internal System.Windows.Forms.MenuItem menuItem17;
      internal System.Windows.Forms.MenuItem mitemViewToolbar;
      internal System.Windows.Forms.MenuItem mitemViewHorzScroll;
      internal System.Windows.Forms.MenuItem mitemViewVertScroll;
      internal System.Windows.Forms.MenuItem mitemViewStat;
      internal System.Windows.Forms.MenuItem mitemViewHeadings;
      internal System.Windows.Forms.MenuItem menuItem23;
      internal System.Windows.Forms.MenuItem mitemViewSplit;
      internal System.Windows.Forms.MenuItem mitemViewFreeze;
      internal System.Windows.Forms.MenuItem menuItem26;
      internal System.Windows.Forms.MenuItem mitemViewFullScreen;
      internal System.Windows.Forms.MenuItem menuItem28;
      internal System.Windows.Forms.MenuItem mitemZoom50;
      internal System.Windows.Forms.MenuItem mitemZoom75;
      internal System.Windows.Forms.MenuItem mitemZoom100;
      internal System.Windows.Forms.MenuItem mitemZoom125;
      internal System.Windows.Forms.MenuItem mitemZoom150;
      internal System.Windows.Forms.MenuItem menuItem34;
      internal System.Windows.Forms.MenuItem mitemFormatCells;
      internal System.Windows.Forms.MenuItem menuItem36;
      internal System.Windows.Forms.MenuItem mitemInsertCells;
      internal System.Windows.Forms.MenuItem mitemDeleteCells;
      private System.Windows.Forms.MenuItem menuItem5;

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
         this.menuStartup = new System.Windows.Forms.MainMenu();
         this.menuItem1 = new System.Windows.Forms.MenuItem();
         this.mitemNewDocument = new System.Windows.Forms.MenuItem();
         this.mitemNewHTML = new System.Windows.Forms.MenuItem();
         this.menuItem5 = new System.Windows.Forms.MenuItem();
         this.mitemNewCheckServer = new System.Windows.Forms.MenuItem();
         this.cmdHideMenus = new System.Windows.Forms.Button();
         this.cmdShowStartupMenu = new System.Windows.Forms.Button();
         this.cmdShowEditMenu = new System.Windows.Forms.Button();
         this.cmdEmptyMenu = new System.Windows.Forms.Button();
         this.menuEmpty = new System.Windows.Forms.MainMenu();
         this.menuEdit = new System.Windows.Forms.MainMenu();
         this.menuItem2 = new System.Windows.Forms.MenuItem();
         this.mitemEditUndo = new System.Windows.Forms.MenuItem();
         this.mitemEditRedo = new System.Windows.Forms.MenuItem();
         this.menuItem7 = new System.Windows.Forms.MenuItem();
         this.mitemEditCut = new System.Windows.Forms.MenuItem();
         this.mitemEditCopy = new System.Windows.Forms.MenuItem();
         this.mitemEditPaste = new System.Windows.Forms.MenuItem();
         this.mitemEditClear = new System.Windows.Forms.MenuItem();
         this.mitemEditSelectAll = new System.Windows.Forms.MenuItem();
         this.menuItem13 = new System.Windows.Forms.MenuItem();
         this.mitemEditFill = new System.Windows.Forms.MenuItem();
         this.menuItem15 = new System.Windows.Forms.MenuItem();
         this.mitemEditRename = new System.Windows.Forms.MenuItem();
         this.menuItem17 = new System.Windows.Forms.MenuItem();
         this.mitemViewToolbar = new System.Windows.Forms.MenuItem();
         this.mitemViewHorzScroll = new System.Windows.Forms.MenuItem();
         this.mitemViewVertScroll = new System.Windows.Forms.MenuItem();
         this.mitemViewStat = new System.Windows.Forms.MenuItem();
         this.mitemViewHeadings = new System.Windows.Forms.MenuItem();
         this.menuItem23 = new System.Windows.Forms.MenuItem();
         this.mitemViewSplit = new System.Windows.Forms.MenuItem();
         this.mitemViewFreeze = new System.Windows.Forms.MenuItem();
         this.menuItem26 = new System.Windows.Forms.MenuItem();
         this.mitemViewFullScreen = new System.Windows.Forms.MenuItem();
         this.menuItem28 = new System.Windows.Forms.MenuItem();
         this.mitemZoom50 = new System.Windows.Forms.MenuItem();
         this.mitemZoom75 = new System.Windows.Forms.MenuItem();
         this.mitemZoom100 = new System.Windows.Forms.MenuItem();
         this.mitemZoom125 = new System.Windows.Forms.MenuItem();
         this.mitemZoom150 = new System.Windows.Forms.MenuItem();
         this.menuItem34 = new System.Windows.Forms.MenuItem();
         this.mitemFormatCells = new System.Windows.Forms.MenuItem();
         this.menuItem36 = new System.Windows.Forms.MenuItem();
         this.mitemInsertCells = new System.Windows.Forms.MenuItem();
         this.mitemDeleteCells = new System.Windows.Forms.MenuItem();
         // 
         // menuStartup
         // 
         this.menuStartup.MenuItems.Add(this.menuItem1);
         // 
         // menuItem1
         // 
         this.menuItem1.MenuItems.Add(this.mitemNewDocument);
         this.menuItem1.MenuItems.Add(this.mitemNewHTML);
         this.menuItem1.MenuItems.Add(this.menuItem5);
         this.menuItem1.MenuItems.Add(this.mitemNewCheckServer);
         this.menuItem1.Text = "New";
         // 
         // mitemNewDocument
         // 
         this.mitemNewDocument.Text = "Document";
         // 
         // mitemNewHTML
         // 
         this.mitemNewHTML.Enabled = false;
         this.mitemNewHTML.Text = "HTML Page";
         // 
         // menuItem5
         // 
         this.menuItem5.Text = "-";
         // 
         // mitemNewCheckServer
         // 
         this.mitemNewCheckServer.Text = "Check server";
         // 
         // cmdHideMenus
         // 
         this.cmdHideMenus.Location = new System.Drawing.Point(32, 32);
         this.cmdHideMenus.Size = new System.Drawing.Size(184, 24);
         this.cmdHideMenus.Text = "Hide Menus";
         this.cmdHideMenus.Click += new System.EventHandler(this.cmdHideMenus_Click);
         // 
         // cmdShowStartupMenu
         // 
         this.cmdShowStartupMenu.Location = new System.Drawing.Point(32, 112);
         this.cmdShowStartupMenu.Size = new System.Drawing.Size(184, 24);
         this.cmdShowStartupMenu.Text = "Show Startup Menu";
         this.cmdShowStartupMenu.Click += new System.EventHandler(this.cmdShowStartupMenu_Click);
         // 
         // cmdShowEditMenu
         // 
         this.cmdShowEditMenu.Location = new System.Drawing.Point(32, 160);
         this.cmdShowEditMenu.Size = new System.Drawing.Size(184, 24);
         this.cmdShowEditMenu.Text = "Show Editing Menu";
         this.cmdShowEditMenu.Click += new System.EventHandler(this.cmdShowEditMenu_Click);
         // 
         // cmdEmptyMenu
         // 
         this.cmdEmptyMenu.Location = new System.Drawing.Point(32, 72);
         this.cmdEmptyMenu.Size = new System.Drawing.Size(184, 24);
         this.cmdEmptyMenu.Text = "Show Empty Menu (for SIP)";
         this.cmdEmptyMenu.Click += new System.EventHandler(this.cmdEmptyMenu_Click);
         // 
         // menuEdit
         // 
         this.menuEdit.MenuItems.Add(this.menuItem2);
         this.menuEdit.MenuItems.Add(this.menuItem17);
         this.menuEdit.MenuItems.Add(this.menuItem34);
         // 
         // menuItem2
         // 
         this.menuItem2.MenuItems.Add(this.mitemEditUndo);
         this.menuItem2.MenuItems.Add(this.mitemEditRedo);
         this.menuItem2.MenuItems.Add(this.menuItem7);
         this.menuItem2.MenuItems.Add(this.mitemEditCut);
         this.menuItem2.MenuItems.Add(this.mitemEditCopy);
         this.menuItem2.MenuItems.Add(this.mitemEditPaste);
         this.menuItem2.MenuItems.Add(this.mitemEditClear);
         this.menuItem2.MenuItems.Add(this.mitemEditSelectAll);
         this.menuItem2.MenuItems.Add(this.menuItem13);
         this.menuItem2.MenuItems.Add(this.mitemEditFill);
         this.menuItem2.MenuItems.Add(this.menuItem15);
         this.menuItem2.MenuItems.Add(this.mitemEditRename);
         this.menuItem2.Text = "Edit";
         // 
         // mitemEditUndo
         // 
         this.mitemEditUndo.Text = "Undo";
         // 
         // mitemEditRedo
         // 
         this.mitemEditRedo.Text = "Redo";
         // 
         // menuItem7
         // 
         this.menuItem7.Text = "-";
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
         // mitemEditClear
         // 
         this.mitemEditClear.Text = "Clear";
         // 
         // mitemEditSelectAll
         // 
         this.mitemEditSelectAll.Text = "Select All";
         // 
         // menuItem13
         // 
         this.menuItem13.Text = "-";
         // 
         // mitemEditFill
         // 
         this.mitemEditFill.Text = "Fill...";
         // 
         // menuItem15
         // 
         this.menuItem15.Text = "-";
         // 
         // mitemEditRename
         // 
         this.mitemEditRename.Text = "Rename/Move...";
         // 
         // menuItem17
         // 
         this.menuItem17.MenuItems.Add(this.mitemViewToolbar);
         this.menuItem17.MenuItems.Add(this.mitemViewHorzScroll);
         this.menuItem17.MenuItems.Add(this.mitemViewVertScroll);
         this.menuItem17.MenuItems.Add(this.mitemViewStat);
         this.menuItem17.MenuItems.Add(this.mitemViewHeadings);
         this.menuItem17.MenuItems.Add(this.menuItem23);
         this.menuItem17.MenuItems.Add(this.mitemViewSplit);
         this.menuItem17.MenuItems.Add(this.mitemViewFreeze);
         this.menuItem17.MenuItems.Add(this.menuItem26);
         this.menuItem17.MenuItems.Add(this.mitemViewFullScreen);
         this.menuItem17.MenuItems.Add(this.menuItem28);
         this.menuItem17.Text = "View";
         // 
         // mitemViewToolbar
         // 
         this.mitemViewToolbar.Text = "Toolbar";
         // 
         // mitemViewHorzScroll
         // 
         this.mitemViewHorzScroll.Text = "Horizontal Scroll Bar";
         // 
         // mitemViewVertScroll
         // 
         this.mitemViewVertScroll.Text = "Vertical Scroll Bar";
         // 
         // mitemViewStat
         // 
         this.mitemViewStat.Text = "Status Bar";
         // 
         // mitemViewHeadings
         // 
         this.mitemViewHeadings.Text = "Row/Column Headings";
         // 
         // menuItem23
         // 
         this.menuItem23.Text = "-";
         // 
         // mitemViewSplit
         // 
         this.mitemViewSplit.Text = "Split";
         // 
         // mitemViewFreeze
         // 
         this.mitemViewFreeze.Text = "Freeze Panes";
         // 
         // menuItem26
         // 
         this.menuItem26.Text = "-";
         // 
         // mitemViewFullScreen
         // 
         this.mitemViewFullScreen.Text = "Full Screen";
         // 
         // menuItem28
         // 
         this.menuItem28.MenuItems.Add(this.mitemZoom50);
         this.menuItem28.MenuItems.Add(this.mitemZoom75);
         this.menuItem28.MenuItems.Add(this.mitemZoom100);
         this.menuItem28.MenuItems.Add(this.mitemZoom125);
         this.menuItem28.MenuItems.Add(this.mitemZoom150);
         this.menuItem28.Text = "Zoom";
         // 
         // mitemZoom50
         // 
         this.mitemZoom50.Text = "50%";
         // 
         // mitemZoom75
         // 
         this.mitemZoom75.Text = "75%";
         // 
         // mitemZoom100
         // 
         this.mitemZoom100.Text = "100%";
         // 
         // mitemZoom125
         // 
         this.mitemZoom125.Text = "125%";
         // 
         // mitemZoom150
         // 
         this.mitemZoom150.Text = "150%";
         // 
         // menuItem34
         // 
         this.menuItem34.MenuItems.Add(this.mitemFormatCells);
         this.menuItem34.MenuItems.Add(this.menuItem36);
         this.menuItem34.MenuItems.Add(this.mitemInsertCells);
         this.menuItem34.MenuItems.Add(this.mitemDeleteCells);
         this.menuItem34.Text = "Format";
         // 
         // mitemFormatCells
         // 
         this.mitemFormatCells.Text = "Cells...";
         // 
         // menuItem36
         // 
         this.menuItem36.Text = "-";
         // 
         // mitemInsertCells
         // 
         this.mitemInsertCells.Text = "Insert Cells...";
         // 
         // mitemDeleteCells
         // 
         this.mitemDeleteCells.Text = "Delete Cells...";
         // 
         // FormMain
         // 
         this.Controls.Add(this.cmdEmptyMenu);
         this.Controls.Add(this.cmdShowEditMenu);
         this.Controls.Add(this.cmdShowStartupMenu);
         this.Controls.Add(this.cmdHideMenus);
         this.Menu = this.menuStartup;
         this.MinimizeBox = false;
         this.Text = "Program Menu";

      }
      #endregion

      /// <summary>
      /// The main entry point for the application.
      /// </summary>

      static void Main() 
      {
         Application.Run(new FormMain());
      }

   private void 
   cmdHideMenus_Click(object sender, System.EventArgs e)
   {
      this.Menu = null;
   }

   private void 
   cmdShowStartupMenu_Click(object sender, 
   System.EventArgs e)
   {
      this.Menu = menuStartup;
   }

   private void 
   cmdShowEditMenu_Click(object sender, 
   System.EventArgs e)
   {
      this.Menu = menuEdit;
   }

   private void 
   cmdEmptyMenu_Click(object sender, 
   System.EventArgs e)
   {
      this.Menu = menuEmpty;
   }
   }
}
