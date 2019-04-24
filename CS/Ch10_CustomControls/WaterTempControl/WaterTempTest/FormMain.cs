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
using YaoDurant.Types;

namespace WaterTempTest
{
	/// <summary>
	/// Summary description for FormMain.
	/// </summary>
	public class FormMain : System.Windows.Forms.Form
	{
      private YaoDurant.Gui.WaterBox wbTest;
      private System.Windows.Forms.TextBox txtUofM;
      private System.Windows.Forms.MenuItem menuItem1;
      private System.Windows.Forms.MenuItem mnuExit;
      private System.Windows.Forms.TextBox txtTemp;
      private System.Windows.Forms.Label lblTemperature;
      private System.Windows.Forms.Label lblUofM;
      private System.Windows.Forms.Button cmdLoad;
      private System.Windows.Forms.Button cmdConvert;
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
         this.menuItem1 = new System.Windows.Forms.MenuItem();
         this.mnuExit = new System.Windows.Forms.MenuItem();
         this.cmdLoad = new System.Windows.Forms.Button();
         this.txtTemp = new System.Windows.Forms.TextBox();
         this.txtUofM = new System.Windows.Forms.TextBox();
         this.cmdConvert = new System.Windows.Forms.Button();
         this.lblTemperature = new System.Windows.Forms.Label();
         this.lblUofM = new System.Windows.Forms.Label();
         // 
         // mainMenu1
         // 
         this.mainMenu1.MenuItems.Add(this.menuItem1);
         // 
         // menuItem1
         // 
         this.menuItem1.MenuItems.Add(this.mnuExit);
         this.menuItem1.Text = "&File";
         // 
         // mnuExit
         // 
         this.mnuExit.Text = "E&xit";
         this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
         // 
         // cmdLoad
         // 
         this.cmdLoad.Location = new System.Drawing.Point(16, 136);
         this.cmdLoad.Text = "Load";
         this.cmdLoad.Click += new System.EventHandler(this.cmdLoad_Click);
         // 
         // txtTemp
         // 
         this.txtTemp.Location = new System.Drawing.Point(8, 40);
         this.txtTemp.Text = "";
         // 
         // txtUofM
         // 
         this.txtUofM.Location = new System.Drawing.Point(136, 40);
         this.txtUofM.Text = "";
         // 
         // cmdConvert
         // 
         this.cmdConvert.Location = new System.Drawing.Point(152, 136);
         this.cmdConvert.Text = "Convert";
         this.cmdConvert.Click += new System.EventHandler(this.cmdConvert_Click);
         // 
         // lblTemperature
         // 
         this.lblTemperature.Location = new System.Drawing.Point(8, 16);
         this.lblTemperature.Text = "Temperature";
         // 
         // lblUofM
         // 
         this.lblUofM.Location = new System.Drawing.Point(136, 16);
         this.lblUofM.Text = "UofM";
         // 
         // FormMain
         // 
         this.Controls.Add(this.lblUofM);
         this.Controls.Add(this.lblTemperature);
         this.Controls.Add(this.cmdConvert);
         this.Controls.Add(this.txtUofM);
         this.Controls.Add(this.txtTemp);
         this.Controls.Add(this.cmdLoad);
         this.Menu = this.mainMenu1;
         this.Text = "FormMain";
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

      private void FormMain_Load(object sender, System.EventArgs e)
      {
         wbTest = new YaoDurant.Gui.WaterBox("44f");
         wbTest.Location = 
            new Point( (this.Width/2) - (wbTest.Width/2),
                       txtTemp.Bottom + 30);
         wbTest.Parent = this;
         wbTest.Focus();
      }

      private void cmdLoad_Click(object sender, 
                                 System.EventArgs e)
      {
         wbTest.Temperature = 
            new WaterTemp(txtTemp.Text + txtUofM.Text);
      }

      private void cmdConvert_Click(object sender, 
                                    System.EventArgs e)
      {
         wbTest.Temperature = 
            wbTest.Temperature.Convert(txtUofM.Text);
      }

      private void mnuExit_Click(object sender, 
                                 System.EventArgs e)
      {
         Application.Exit();
      }
	}
}
