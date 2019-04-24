//-----------------------------------------------------------------------------
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Drawing;
using System.Windows.Forms;
using YaoDurant.Gui;

namespace TestDateControl
{
	/// <summary>
	/// Summary description for FormMain.
	/// </summary>
	public class FormMain : System.Windows.Forms.Form
	{
//      private YaoDurant.Gui.TextBoxPlus tboxpTest;
//      private YaoDurant.Gui.DateBox dboxTest;
      private YaoDurant.Gui.TaskStatus tskdatOne;
      private YaoDurant.Gui.DateBox OurDateBox;
//      private YaoDurant.Gui.TaskStatus tskdatTwo;
//      private YaoDurant.Gui.DateBox dateBox1;

		private System.Windows.Forms.MainMenu mainMenu1;

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
         this.mainMenu1 = new System.Windows.Forms.MainMenu();
         this.OurDateBox = new YaoDurant.Gui.DateBox();
         // 
         // OurDateBox
         // 
         this.OurDateBox.BackColor = System.Drawing.Color.White;
         this.OurDateBox.Date = new System.DateTime(2003, 8, 5, 19, 10, 30, 796);
         this.OurDateBox.Location = new System.Drawing.Point(48, 72);
         this.OurDateBox.MaxValue = new System.DateTime(9999, 12, 31, 23, 59, 59, 999);
         this.OurDateBox.MinValue = new System.DateTime(((long)(0)));
         this.OurDateBox.Size = new System.Drawing.Size(88, 20);
         this.OurDateBox.Text = "8/5/2003";
         // 
         // FormMain
         // 
         this.Controls.Add(this.OurDateBox);
         this.Menu = this.mainMenu1;
         this.Text = "Test Date Control";
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

      private void FormMain_Load(object sender, 
                                 System.EventArgs e)
      {
//         tboxpTest = new YaoDurant.Gui.TextBoxPlus();
//         this.Controls.Add(tboxpTest);

//         dboxTest = new YaoDurant.Gui.DateBox();
//         this.Controls.Add(dboxTest);

         tskdatOne = new YaoDurant.Gui.TaskStatus();
         tskdatOne.Parent = this;
         tskdatOne.Visible = true;
         tskdatOne.Location = new Point(10 ,40);
         tskdatOne.dateBegin = DateTime.Today.AddDays(-5);
         tskdatOne.dateEnd = DateTime.Today.AddDays(5);
         tskdatOne.durActual = 50;
         tskdatOne.durEstimated = 50;
//
//         tskdatTwo = new YaoDurant.Gui.TaskStatus();
//         tskdatTwo.Parent = this;
//         tskdatTwo.Visible = true;
//         tskdatTwo.Location = new Point(10 ,80);
//         tskdatTwo.dateBegin = DateTime.Today.AddDays(-5);
//         tskdatTwo.dateEnd = DateTime.Today.AddDays(5);
//         tskdatTwo.durActual = 50;
//         tskdatTwo.durEstimated = 50;
      }

//      private void button1_Click(object sender, System.EventArgs e)
//      {
//         //MessageBox.Show( DateTime.Today.ToString() );
//         //this.textBox1.Text = (tboxpTest.ToString()).ToString();
//      }

	}
}
