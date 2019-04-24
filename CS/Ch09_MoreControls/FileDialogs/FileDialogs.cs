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

namespace FileDialogs
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class FormMain : System.Windows.Forms.Form
   {
      private System.Windows.Forms.MainMenu menuMain;
      private System.Windows.Forms.MenuItem menuItem1;
      private System.Windows.Forms.MenuItem mitemFileOpen;
      private System.Windows.Forms.MenuItem mitemFileSave;
      private System.Windows.Forms.MenuItem mitemFileSaveAs;
      private System.Windows.Forms.OpenFileDialog dlgFileOpen;
      private System.Windows.Forms.SaveFileDialog dlgFileSave;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.TextBox textFileName;
      private System.Windows.Forms.TextBox textFilter;
      private System.Windows.Forms.TextBox textInitialDir;
      private System.Windows.Forms.NumericUpDown nudFilterIndex;
      private System.Windows.Forms.MenuItem mitemFileNew;

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
         this.menuMain = new System.Windows.Forms.MainMenu();
         this.menuItem1 = new System.Windows.Forms.MenuItem();
         this.mitemFileNew = new System.Windows.Forms.MenuItem();
         this.mitemFileOpen = new System.Windows.Forms.MenuItem();
         this.mitemFileSave = new System.Windows.Forms.MenuItem();
         this.mitemFileSaveAs = new System.Windows.Forms.MenuItem();
         this.dlgFileOpen = new System.Windows.Forms.OpenFileDialog();
         this.dlgFileSave = new System.Windows.Forms.SaveFileDialog();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.textFileName = new System.Windows.Forms.TextBox();
         this.textFilter = new System.Windows.Forms.TextBox();
         this.nudFilterIndex = new System.Windows.Forms.NumericUpDown();
         this.textInitialDir = new System.Windows.Forms.TextBox();
         // 
         // menuMain
         // 
         this.menuMain.MenuItems.Add(this.menuItem1);
         // 
         // menuItem1
         // 
         this.menuItem1.MenuItems.Add(this.mitemFileNew);
         this.menuItem1.MenuItems.Add(this.mitemFileOpen);
         this.menuItem1.MenuItems.Add(this.mitemFileSave);
         this.menuItem1.MenuItems.Add(this.mitemFileSaveAs);
         this.menuItem1.Text = "File";
         // 
         // mitemFileNew
         // 
         this.mitemFileNew.Text = "New";
         this.mitemFileNew.Click += new System.EventHandler(this.mitemFileNew_Click);
         // 
         // mitemFileOpen
         // 
         this.mitemFileOpen.Text = "Open...";
         this.mitemFileOpen.Click += new System.EventHandler(this.mitemFileOpen_Click);
         // 
         // mitemFileSave
         // 
         this.mitemFileSave.Text = "Save";
         this.mitemFileSave.Click += new System.EventHandler(this.mitemFileSave_Click);
         // 
         // mitemFileSaveAs
         // 
         this.mitemFileSaveAs.Text = "Save As...";
         this.mitemFileSaveAs.Click += new System.EventHandler(this.mitemFileSaveAs_Click);
         // 
         // dlgFileSave
         // 
         this.dlgFileSave.FileName = "doc1";
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(0, 16);
         this.label1.Size = new System.Drawing.Size(64, 20);
         this.label1.Text = "File Name:";
         this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // label2
         // 
         this.label2.Location = new System.Drawing.Point(16, 48);
         this.label2.Size = new System.Drawing.Size(48, 20);
         this.label2.Text = "Filter:";
         this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // label3
         // 
         this.label3.Location = new System.Drawing.Point(8, 152);
         this.label3.Size = new System.Drawing.Size(56, 32);
         this.label3.Text = "Filter  Index:";
         this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // label4
         // 
         this.label4.Location = new System.Drawing.Point(0, 192);
         this.label4.Size = new System.Drawing.Size(56, 32);
         this.label4.Text = "Initial Directory:";
         this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // textFileName
         // 
         this.textFileName.Location = new System.Drawing.Point(72, 16);
         this.textFileName.Size = new System.Drawing.Size(160, 22);
         this.textFileName.Text = "NewDoc";
         // 
         // textFilter
         // 
         this.textFilter.Location = new System.Drawing.Point(72, 48);
         this.textFilter.Multiline = true;
         this.textFilter.Size = new System.Drawing.Size(160, 88);
         this.textFilter.Text = "Pocket Word (*.psw)|*.psw|Pocket Excel (*.pxt)|*.pxt|Text Files (*.txt)|*.txt|All" +
            " Files (*.*)|*.*";
         // 
         // nudFilterIndex
         // 
         this.nudFilterIndex.Location = new System.Drawing.Point(72, 152);
         this.nudFilterIndex.Minimum = new System.Decimal(new int[] {
                                                                       1,
                                                                       0,
                                                                       0,
                                                                       0});
         this.nudFilterIndex.Size = new System.Drawing.Size(48, 20);
         this.nudFilterIndex.Value = new System.Decimal(new int[] {
                                                                     1,
                                                                     0,
                                                                     0,
                                                                     0});
         // 
         // textInitialDir
         // 
         this.textInitialDir.Location = new System.Drawing.Point(72, 192);
         this.textInitialDir.Size = new System.Drawing.Size(152, 22);
         this.textInitialDir.Text = "\\My Documents";
         // 
         // FormMain
         // 
         this.Controls.Add(this.textInitialDir);
         this.Controls.Add(this.nudFilterIndex);
         this.Controls.Add(this.textFilter);
         this.Controls.Add(this.textFileName);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Menu = this.menuMain;
         this.MinimizeBox = false;
         this.Text = "FileDialogs";

      }
      #endregion

      /// <summary>
      /// The main entry point for the application.
      /// </summary>

      static void Main() 
      {
         Application.Run(new FormMain());
      }

      private string m_strAppName = "FileDialogs";

      // mitemFileNew_Click - Handler for File->New menu item
      private void mitemFileNew_Click(
         object sender, 
         System.EventArgs e)
      {
         textFileName.Text = "NewDoc";
         textFilter.Text = "Pocket Word (*.psw)|*.psw|" +
            "Pocket Excel (*.pxt)|*.pxt|" +
            "Text Files (*.txt)|*.txt|" +
            "All Files (*.*)|*.*";
         nudFilterIndex.Value = 1;
         textInitialDir.Text = @"\My Documents";

         MessageBox.Show("Resetting fields.", m_strAppName);
      }

      // mitemFileOpen_Click - Handler for File->Open menu item
      private void mitemFileOpen_Click(
         object sender, 
         System.EventArgs e)
      {
         // Read current settings from controls.
         dlgFileOpen.FileName = textFileName.Text;
         dlgFileOpen.Filter = textFilter.Text;
         int i = (int)nudFilterIndex.Value;
         dlgFileOpen.FilterIndex = i;
         dlgFileOpen.InitialDirectory = textInitialDir.Text;
         
         string strResult;

         DialogResult dres =
         dlgFileOpen.ShowDialog();
         if (dres == DialogResult.OK)
         {
            strResult = "User clicked Ok.\n" +
               "Filename:" + dlgFileOpen.FileName;

            // Copy file name to our file name control.
            textFileName.Text = dlgFileOpen.FileName;
         }
         else
         {
            strResult = "User clicked Cancel.";
         }

         MessageBox.Show(strResult, m_strAppName);
      }

      // mitemFileSave_Click - Handler for File->Save
      private void mitemFileSave_Click(
         object sender, 
         System.EventArgs e)
      {
         MessageBox.Show("File saved.", m_strAppName);
      }

      // mitemFileSaveAs_Click - Handler for File-> Save As...
      private void mitemFileSaveAs_Click(
         object sender, 
         System.EventArgs e)
      {
         // Read current settings from controls.
         dlgFileSave.FileName = textFileName.Text;
         dlgFileSave.Filter = textFilter.Text;
         int i = (int)nudFilterIndex.Value;
         dlgFileSave.FilterIndex = i;
         dlgFileSave.InitialDirectory = textInitialDir.Text;

         string strResult;

         DialogResult dres =
            dlgFileSave.ShowDialog();
         if (dres == DialogResult.OK)
         {
            strResult = "User clicked Ok.\n" +
               "Filename: " + dlgFileSave.FileName;

            // Copy file name to our file name control.
            textFileName.Text = dlgFileSave.FileName;
         }
         else
         {
            strResult = "User clicked Cancel.";
         }
         
         MessageBox.Show(strResult, m_strAppName);
      }

   } // class
} // namespace
