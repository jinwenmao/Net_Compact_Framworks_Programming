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

namespace MyAddress
{
   /// <summary>
   /// Summary description for FormMain.
   /// </summary>
   public class FormMain : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox tboxName;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox tboxAddr1;
      private System.Windows.Forms.TextBox tboxAddr2;
      private System.Windows.Forms.ComboBox cboxCountry;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.TextBox tboxPostalCode;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.TextBox tboxCity;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.TextBox tboxStateProvince;
      private System.Windows.Forms.Button cmdSave;
      private System.Windows.Forms.Button cmdClear;
      private System.Windows.Forms.MainMenu mainMenu1;

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
         this.mainMenu1 = new System.Windows.Forms.MainMenu();
         this.label1 = new System.Windows.Forms.Label();
         this.tboxName = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.tboxAddr1 = new System.Windows.Forms.TextBox();
         this.tboxAddr2 = new System.Windows.Forms.TextBox();
         this.cboxCountry = new System.Windows.Forms.ComboBox();
         this.label3 = new System.Windows.Forms.Label();
         this.tboxPostalCode = new System.Windows.Forms.TextBox();
         this.label4 = new System.Windows.Forms.Label();
         this.tboxCity = new System.Windows.Forms.TextBox();
         this.label5 = new System.Windows.Forms.Label();
         this.tboxStateProvince = new System.Windows.Forms.TextBox();
         this.cmdSave = new System.Windows.Forms.Button();
         this.cmdClear = new System.Windows.Forms.Button();
         // 
         // label1
         // 
         this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
         this.label1.Location = new System.Drawing.Point(8, 12);
         this.label1.Size = new System.Drawing.Size(56, 20);
         this.label1.Text = "Name:";
         this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // tboxName
         // 
         this.tboxName.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
         this.tboxName.Location = new System.Drawing.Point(80, 8);
         this.tboxName.Size = new System.Drawing.Size(144, 28);
         this.tboxName.Text = "Mr. Our Visitor";
         // 
         // label2
         // 
         this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
         this.label2.Location = new System.Drawing.Point(0, 44);
         this.label2.Size = new System.Drawing.Size(72, 20);
         this.label2.Text = "Address:";
         this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // tboxAddr1
         // 
         this.tboxAddr1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
         this.tboxAddr1.Location = new System.Drawing.Point(80, 40);
         this.tboxAddr1.Size = new System.Drawing.Size(144, 28);
         this.tboxAddr1.Text = "1212 Visitor Home Ave.";
         // 
         // tboxAddr2
         // 
         this.tboxAddr2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
         this.tboxAddr2.Location = new System.Drawing.Point(80, 72);
         this.tboxAddr2.Size = new System.Drawing.Size(144, 28);
         this.tboxAddr2.Text = "Suite 12";
         // 
         // cboxCountry
         // 
         this.cboxCountry.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
         this.cboxCountry.Items.Add("(Choose country)");
         this.cboxCountry.Items.Add("Canada");
         this.cboxCountry.Items.Add("Mexico");
         this.cboxCountry.Items.Add("Singapore");
         this.cboxCountry.Location = new System.Drawing.Point(48, 104);
         this.cboxCountry.Size = new System.Drawing.Size(176, 29);
         // 
         // label3
         // 
         this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
         this.label3.Location = new System.Drawing.Point(16, 138);
         this.label3.Size = new System.Drawing.Size(104, 24);
         this.label3.Text = "Postal Code:";
         this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // tboxPostalCode
         // 
         this.tboxPostalCode.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
         this.tboxPostalCode.Location = new System.Drawing.Point(128, 136);
         this.tboxPostalCode.Size = new System.Drawing.Size(56, 28);
         this.tboxPostalCode.Text = "";
         // 
         // label4
         // 
         this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
         this.label4.Location = new System.Drawing.Point(80, 170);
         this.label4.Size = new System.Drawing.Size(40, 24);
         this.label4.Text = "City:";
         this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // tboxCity
         // 
         this.tboxCity.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
         this.tboxCity.Location = new System.Drawing.Point(128, 168);
         this.tboxCity.Size = new System.Drawing.Size(96, 28);
         this.tboxCity.Text = "";
         // 
         // label5
         // 
         this.label5.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
         this.label5.Location = new System.Drawing.Point(0, 200);
         this.label5.Size = new System.Drawing.Size(120, 20);
         this.label5.Text = "State/Province:";
         this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // tboxStateProvince
         // 
         this.tboxStateProvince.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
         this.tboxStateProvince.Location = new System.Drawing.Point(128, 200);
         this.tboxStateProvince.Size = new System.Drawing.Size(96, 28);
         this.tboxStateProvince.Text = "";
         // 
         // cmdSave
         // 
         this.cmdSave.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
         this.cmdSave.Location = new System.Drawing.Point(32, 232);
         this.cmdSave.Size = new System.Drawing.Size(72, 32);
         this.cmdSave.Text = "&Save";
         this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
         // 
         // cmdClear
         // 
         this.cmdClear.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
         this.cmdClear.Location = new System.Drawing.Point(120, 232);
         this.cmdClear.Size = new System.Drawing.Size(72, 32);
         this.cmdClear.Text = "&Clear";
         this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
         // 
         // FormMain
         // 
         this.Controls.Add(this.cmdClear);
         this.Controls.Add(this.cmdSave);
         this.Controls.Add(this.tboxStateProvince);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.tboxCity);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.tboxPostalCode);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.cboxCountry);
         this.Controls.Add(this.tboxAddr2);
         this.Controls.Add(this.tboxAddr1);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.tboxName);
         this.Controls.Add(this.label1);
         this.Menu = this.mainMenu1;
         this.MinimizeBox = false;
         this.Text = "MyAddress";
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

      private string strAppName = "MyAddress";

      private void FormMain_Load(object sender, System.EventArgs e)
      {
         // Start with first item selected.
         cboxCountry.SelectedIndex = 0;
      }

      private void cmdSave_Click(object sender, System.EventArgs e)
      {
         string strSummary = tboxName.Text + "\n" + 
            tboxAddr1.Text + "\n" +
            tboxAddr2.Text + "\n" +
            tboxCity.Text + "," + tboxStateProvince.Text + "  " + tboxPostalCode.Text + "\n" +
            cboxCountry.SelectedItem;
            
         MessageBox.Show(strSummary, "Saved");
            
      }

      private void cmdClear_Click(object sender, System.EventArgs e)
      {
         //tboxName.Text = string.Empty;
         //tboxAddr1.Text = string.Empty;
         //tboxAddr2.Text = string.Empty;
         tboxCity.Text = string.Empty;
         tboxStateProvince.Text = string.Empty;
         tboxPostalCode.Text = string.Empty;
         cboxCountry.SelectedIndex = 0;
      }


   } // class
} // namespace
