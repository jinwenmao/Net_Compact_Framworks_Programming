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
using YaoDurant.Data;
using YaoDurant.GUI;

namespace BindToDataGridStyled
{
	/// <summary>
	/// Summary description for FormMain.
	/// </summary>
	public class FormMain : System.Windows.Forms.Form
	{
      private System.Windows.Forms.DataGrid dgridDisplay;
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
         this.dgridDisplay = new System.Windows.Forms.DataGrid();
         // 
         // dgridDisplay
         // 
         this.dgridDisplay.Location = new System.Drawing.Point(0, 40);
         this.dgridDisplay.Size = new System.Drawing.Size(240, 112);
         // 
         // FormMain
         // 
         this.Controls.Add(this.dgridDisplay);
         this.Menu = this.mainMenu1;
         this.Text = "Styled";
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
         //  Make the Project table the DataSource.
         YaoDurant.Data.UtilData utilData = new UtilData();
         dgridDisplay.DataSource = utilData.GetProjectsDT();

         //  Use a utility routine to style the 
         //     layout of Projects in the DataGrid.
         YaoDurant.GUI.UtilGUI.AddCustomDataTableStyle(
                                    dgridDisplay, "Projects");
      }
	}
}
