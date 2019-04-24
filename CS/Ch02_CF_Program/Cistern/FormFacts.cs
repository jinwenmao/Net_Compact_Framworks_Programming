//-----------------------------------------------------------------------------
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Cistern
{
	/// <summary>
	/// Summary description for FormFacts.
	/// </summary>
	public class FormFacts : System.Windows.Forms.Form
	{
      private System.Windows.Forms.Label lblHeader;
      private System.Windows.Forms.Label lblFact1;
      private System.Windows.Forms.Label lblFact2;
      private System.Windows.Forms.Label lblFact3;
      private System.Windows.Forms.Label lblFact4;
      private System.Windows.Forms.Label lblFact5;
      private System.Windows.Forms.Label lblFact6;
   
		public FormFacts()
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
         this.lblHeader = new System.Windows.Forms.Label();
         this.lblFact1 = new System.Windows.Forms.Label();
         this.lblFact2 = new System.Windows.Forms.Label();
         this.lblFact3 = new System.Windows.Forms.Label();
         this.lblFact4 = new System.Windows.Forms.Label();
         this.lblFact5 = new System.Windows.Forms.Label();
         this.lblFact6 = new System.Windows.Forms.Label();
         // 
         // lblHeader
         // 
         this.lblHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
         this.lblHeader.Text = "Water Facts";
         // 
         // lblFact1
         // 
         this.lblFact1.Location = new System.Drawing.Point(16, 32);
         this.lblFact1.Size = new System.Drawing.Size(208, 20);
         this.lblFact1.Text = "1 cu ft water = 7.48 gal";
         // 
         // lblFact2
         // 
         this.lblFact2.Location = new System.Drawing.Point(16, 64);
         this.lblFact2.Size = new System.Drawing.Size(208, 20);
         this.lblFact2.Text = "1 gal water = 8.34 lbs";
         // 
         // lblFact3
         // 
         this.lblFact3.Location = new System.Drawing.Point(16, 96);
         this.lblFact3.Size = new System.Drawing.Size(208, 20);
         this.lblFact3.Text = "1 cu ft water = 62.38 lbs";
         // 
         // lblFact4
         // 
         this.lblFact4.Location = new System.Drawing.Point(16, 128);
         this.lblFact4.Size = new System.Drawing.Size(208, 32);
         this.lblFact4.Text = "1 in rain on 1000 sq ft roof = 623 gal";
         // 
         // lblFact5
         // 
         this.lblFact5.Location = new System.Drawing.Point(16, 168);
         this.lblFact5.Size = new System.Drawing.Size(208, 20);
         this.lblFact5.Text = "Avg annual Seattle rainfall = 35 in";
         // 
         // lblFact6
         // 
         this.lblFact6.Location = new System.Drawing.Point(16, 200);
         this.lblFact6.Size = new System.Drawing.Size(208, 32);
         this.lblFact6.Text = "Est runoff from Seattleite who stands in the rain for 1 year = 22 gal";
         // 
         // FormFacts
         // 
         this.Controls.Add(this.lblFact6);
         this.Controls.Add(this.lblFact5);
         this.Controls.Add(this.lblFact4);
         this.Controls.Add(this.lblFact3);
         this.Controls.Add(this.lblFact2);
         this.Controls.Add(this.lblFact1);
         this.Controls.Add(this.lblHeader);
         this.Text = "FormFacts";

      }
		#endregion
	}
}
