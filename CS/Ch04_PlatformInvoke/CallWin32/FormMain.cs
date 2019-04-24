// FormMain.cs - main user-interface for this program
//
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.

using System;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CallWin32
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class FormMain : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox txtValue;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.RadioButton rdoByVal;
      private System.Windows.Forms.RadioButton rdoByRef;
      private System.Windows.Forms.MainMenu mainMenu1;
      private System.Windows.Forms.ComboBox cboType;
      private System.Windows.Forms.Button cmdCall;
      
      public const string strApp = "CallWin32";

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
         this.label1 = new System.Windows.Forms.Label();
         this.txtValue = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.cboType = new System.Windows.Forms.ComboBox();
         this.rdoByVal = new System.Windows.Forms.RadioButton();
         this.rdoByRef = new System.Windows.Forms.RadioButton();
         this.cmdCall = new System.Windows.Forms.Button();
         this.mainMenu1 = new System.Windows.Forms.MainMenu();
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(8, 8);
         this.label1.Size = new System.Drawing.Size(56, 20);
         this.label1.Text = "Value:";
         // 
         // txtValue
         // 
         this.txtValue.Location = new System.Drawing.Point(64, 8);
         this.txtValue.Size = new System.Drawing.Size(160, 22);
         this.txtValue.Text = "";
         // 
         // label2
         // 
         this.label2.Location = new System.Drawing.Point(8, 56);
         this.label2.Size = new System.Drawing.Size(48, 20);
         this.label2.Text = "Type:";
         // 
         // cboType
         // 
         this.cboType.Items.Add("Boolean");
         this.cboType.Items.Add("Byte");
         this.cboType.Items.Add("SByte");
         this.cboType.Items.Add("Char");
         this.cboType.Items.Add("Int16");
         this.cboType.Items.Add("UInt16");
         this.cboType.Items.Add("Int32");
         this.cboType.Items.Add("UInt32");
         this.cboType.Items.Add("IntPtr");
         this.cboType.Items.Add("Single");
         this.cboType.Items.Add("Int64");
         this.cboType.Items.Add("UInt64");
         this.cboType.Items.Add("Double");
         this.cboType.Items.Add("String");
         this.cboType.Items.Add("StringBuilder");
         this.cboType.Location = new System.Drawing.Point(64, 48);
         this.cboType.Size = new System.Drawing.Size(160, 22);
         // 
         // rdoByVal
         // 
         this.rdoByVal.Checked = true;
         this.rdoByVal.Location = new System.Drawing.Point(64, 88);
         this.rdoByVal.Text = "By Value";
         // 
         // rdoByRef
         // 
         this.rdoByRef.Location = new System.Drawing.Point(64, 112);
         this.rdoByRef.Text = "By Reference";
         // 
         // cmdCall
         // 
         this.cmdCall.Location = new System.Drawing.Point(16, 144);
         this.cmdCall.Size = new System.Drawing.Size(208, 32);
         this.cmdCall.Text = "Call Win32 Library";
         this.cmdCall.Click += new System.EventHandler(this.cmdCall_Click);
         // 
         // FormMain
         // 
         this.ClientSize = new System.Drawing.Size(234, 238);
         this.Controls.Add(this.cmdCall);
         this.Controls.Add(this.rdoByRef);
         this.Controls.Add(this.rdoByVal);
         this.Controls.Add(this.cboType);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.txtValue);
         this.Controls.Add(this.label1);
         this.Menu = this.mainMenu1;
         this.MinimizeBox = false;
         this.Text = "CallWin32";

      }
      #endregion

      /// <summary>
      /// The main entry point for the application.
      /// </summary>

      static void Main() 
      {
         Application.Run(new FormMain());
      }

      private void cmdCall_Click(object sender, System.EventArgs e)
      {
         if (this.txtValue.Text.Length == 0)
         {
             MessageBox.Show("Please enter a value", strApp);
             return;
         }
         
         if (this.cboType.SelectedIndex == -1)
         {
            MessageBox.Show("Please select a Type", strApp);
            return;
         }

         string strType = this.cboType.Text;
         string strVal  = this.txtValue.Text;
         Boolean bByRef = this.rdoByRef.Checked;

         try
         {
            CallWin32.CallWin32Lib(strVal, strType, bByRef);
         }
         catch (Exception ex)
         {
            MessageBox.Show("Exception: " + ex.Message, strApp);
         }
      }
   }
}
