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

namespace PropSheet
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class Form1 : System.Windows.Forms.Form
   {
      private System.Windows.Forms.MainMenu menuMain;
      private System.Windows.Forms.MenuItem mitemFilePopup;
      private System.Windows.Forms.TextBox textInput;
      private System.Windows.Forms.MenuItem mitemFileProperties;

      public Form1()
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
         this.mitemFilePopup = new System.Windows.Forms.MenuItem();
         this.mitemFileProperties = new System.Windows.Forms.MenuItem();
         this.textInput = new System.Windows.Forms.TextBox();
         // 
         // menuMain
         // 
         this.menuMain.MenuItems.Add(this.mitemFilePopup);
         // 
         // mitemFilePopup
         // 
         this.mitemFilePopup.MenuItems.Add(this.mitemFileProperties);
         this.mitemFilePopup.Text = "File";
         // 
         // mitemFileProperties
         // 
         this.mitemFileProperties.Text = "Properties...";
         this.mitemFileProperties.Click += new System.EventHandler(this.mitemFileProperties_Click);
         // 
         // textInput
         // 
         this.textInput.Location = new System.Drawing.Point(40, 32);
         this.textInput.Multiline = true;
         this.textInput.Size = new System.Drawing.Size(144, 112);
         this.textInput.Text = "Some test to display and edit...";
         // 
         // Form1
         // 
         this.Controls.Add(this.textInput);
         this.Menu = this.menuMain;
         this.MinimizeBox = false;
         this.Text = "PropSheet";

      }
      #endregion

      /// <summary>
      /// The main entry point for the application.
      /// </summary>

      static void Main() 
      {
         Application.Run(new Form1());
      }

      // User selected File->Properties... menu item
      private void mitemFileProperties_Click(
         object sender, 
         System.EventArgs e)
      {
         DlgFileProperties dlg = new DlgFileProperties();
         dlg.ShowDialog();
      }
   }
}
