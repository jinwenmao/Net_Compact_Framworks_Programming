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
	/// Summary description for FormData.
	/// </summary>
	public class FormData : System.Windows.Forms.Form
	{
      private System.Windows.Forms.DataGrid dgridNorthwind;
   
		public FormData()
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
         this.dgridNorthwind = new System.Windows.Forms.DataGrid();
         // 
         // dgridNorthwind
         // 
         this.dgridNorthwind.Size = new System.Drawing.Size(240, 200);
         this.dgridNorthwind.Text = "dataGrid1";
         // 
         // FormData
         // 
         this.Controls.Add(this.dgridNorthwind);
         this.Text = "FormData";
         this.Load += new System.EventHandler(this.FormData_Load);

      }
		#endregion

      private void FormData_Load(object sender, EventArgs e)
      {
         DataSupplier.DataSupplier  refDataSupplier = 
            new DataSupplier.DataSupplier();

         dgridNorthwind.DataSource =
            refDataSupplier.GetNorthwindData().Tables["Categories"];
      }
	}
}
