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

namespace WSClient
{
	/// <summary>
	/// Summary description for FormPrimes.
	/// </summary>
	public class FormPrimes : System.Windows.Forms.Form
	{
      internal System.Windows.Forms.Button cmdGet;
      internal System.Windows.Forms.TextBox txtTarget;
      internal System.Windows.Forms.Label lblFloorPrime;
   
		public FormPrimes()
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
         this.cmdGet = new System.Windows.Forms.Button();
         this.txtTarget = new System.Windows.Forms.TextBox();
         this.lblFloorPrime = new System.Windows.Forms.Label();
         // 
         // cmdGet
         // 
         this.cmdGet.Location = new System.Drawing.Point(94, 173);
         this.cmdGet.Text = "Get";
         this.cmdGet.Click += new System.EventHandler(this.cmdGet_Click);
         // 
         // txtTarget
         // 
         this.txtTarget.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular);
         this.txtTarget.Location = new System.Drawing.Point(70, 77);
         this.txtTarget.Text = "";
         // 
         // lblFloorPrime
         // 
         this.lblFloorPrime.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular);
         this.lblFloorPrime.Location = new System.Drawing.Point(70, 125);
         // 
         // FormPrimes
         // 
         this.Controls.Add(this.cmdGet);
         this.Controls.Add(this.txtTarget);
         this.Controls.Add(this.lblFloorPrime);
         this.Text = "FormPrimes";

      }
		#endregion

      private void cmdGet_Click(object sender, EventArgs e)
      {
         Primes.Primes  refPrimes = new Primes.Primes();

         lblFloorPrime.Text =
            refPrimes.GetFloorPrime(
               int.Parse(txtTarget.Text)).ToString();
      }
	}
}
