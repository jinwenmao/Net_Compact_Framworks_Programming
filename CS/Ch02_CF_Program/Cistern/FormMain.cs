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
using YaoDurant.CFBook.Utilities;

namespace Cistern
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FormMain : System.Windows.Forms.Form
	{
      // Variable to hold a reference to FormFacts.
      private Form refFormFacts;

      private System.Windows.Forms.TextBox textRoof;
      private System.Windows.Forms.TextBox textRain;
      private System.Windows.Forms.Button cmdCalc;
      private System.Windows.Forms.Button cmdFacts;
      private System.Windows.Forms.Label lblRoof;
      private System.Windows.Forms.Label lblRain;
      private System.Windows.Forms.Label lblAnswerHdr;
      private System.Windows.Forms.Label lblAnswer;
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
         this.textRoof = new System.Windows.Forms.TextBox();
         this.textRain = new System.Windows.Forms.TextBox();
         this.cmdCalc = new System.Windows.Forms.Button();
         this.cmdFacts = new System.Windows.Forms.Button();
         this.lblRoof = new System.Windows.Forms.Label();
         this.lblRain = new System.Windows.Forms.Label();
         this.lblAnswerHdr = new System.Windows.Forms.Label();
         this.lblAnswer = new System.Windows.Forms.Label();
         // 
         // textRoof
         // 
         this.textRoof.Location = new System.Drawing.Point(16, 48);
         this.textRoof.Size = new System.Drawing.Size(64, 22);
         this.textRoof.Text = "";
         // 
         // textRain
         // 
         this.textRain.Location = new System.Drawing.Point(136, 48);
         this.textRain.Size = new System.Drawing.Size(64, 22);
         this.textRain.Text = "";
         // 
         // cmdCalc
         // 
         this.cmdCalc.Location = new System.Drawing.Point(24, 208);
         this.cmdCalc.Text = "Calc";
         this.cmdCalc.Click += new System.EventHandler(this.cmdCalc_Click);
         // 
         // cmdFacts
         // 
         this.cmdFacts.Location = new System.Drawing.Point(136, 208);
         this.cmdFacts.Text = "Show";
         this.cmdFacts.Click += new System.EventHandler(this.cmdFacts_Click);
         // 
         // lblRoof
         // 
         this.lblRoof.Location = new System.Drawing.Point(16, 24);
         this.lblRoof.Size = new System.Drawing.Size(80, 20);
         this.lblRoof.Text = "Roof (Sq. ft.)";
         // 
         // lblRain
         // 
         this.lblRain.Location = new System.Drawing.Point(136, 24);
         this.lblRain.Size = new System.Drawing.Size(80, 20);
         this.lblRain.Text = "Rain (Inches)";
         // 
         // lblAnswerHdr
         // 
         this.lblAnswerHdr.Location = new System.Drawing.Point(64, 120);
         this.lblAnswerHdr.Text = "Volume (Gallons)";
         // 
         // lblAnswer
         // 
         this.lblAnswer.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
         this.lblAnswer.Location = new System.Drawing.Point(64, 144);
         this.lblAnswer.Size = new System.Drawing.Size(100, 24);
         // 
         // FormMain
         // 
         this.Controls.Add(this.lblAnswer);
         this.Controls.Add(this.lblAnswerHdr);
         this.Controls.Add(this.lblRain);
         this.Controls.Add(this.lblRoof);
         this.Controls.Add(this.cmdFacts);
         this.Controls.Add(this.cmdCalc);
         this.Controls.Add(this.textRain);
         this.Controls.Add(this.textRoof);
         this.Menu = this.mainMenu1;
         this.Text = "Cistern";

      }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>

      static void Main() 
      {
         Application.Run(new Cistern.FormMain());
      }

      private void cmdFacts_Click(object sender, 
                                  System.EventArgs e)
      {
         // Create an instance of the form.
         this.refFormFacts = new FormFacts();
         // Show it.
         this.refFormFacts.Show();
      }

      private void cmdCalc_Click(object sender, 
                                 System.EventArgs e)
      {
         //  Calculate the runoff.
         lblAnswer.Text = 
            YaoDurant.CFBook.Utilities.WaterMath.GetVolume(
               double.Parse(textRoof.Text), 
               int.Parse(textRain.Text) ).ToString();
      }

	}
}
