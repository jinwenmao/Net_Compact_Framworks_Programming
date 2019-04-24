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

namespace InPlaceEditManual
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>

	public class FormMain : System.Windows.Forms.Form
	{
      internal System.Windows.Forms.Label Label1;
      internal System.Windows.Forms.Panel Panel1;
      internal System.Windows.Forms.Button cmdCancel;
      internal System.Windows.Forms.Button cmdUpdate;
      internal System.Windows.Forms.Button cmdEdit;
      private System.Windows.Forms.DataGrid dgrdProjects;
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
         this.Label1 = new System.Windows.Forms.Label();
         this.Panel1 = new System.Windows.Forms.Panel();
         this.cmdCancel = new System.Windows.Forms.Button();
         this.cmdUpdate = new System.Windows.Forms.Button();
         this.cmdEdit = new System.Windows.Forms.Button();
         this.dgrdProjects = new System.Windows.Forms.DataGrid();
         // 
         // Label1
         // 
         this.Label1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
         this.Label1.Location = new System.Drawing.Point(0, 8);
         this.Label1.Size = new System.Drawing.Size(240, 24);
         // 
         // Panel1
         // 
         this.Panel1.Controls.Add(this.cmdCancel);
         this.Panel1.Controls.Add(this.cmdUpdate);
         this.Panel1.Controls.Add(this.cmdEdit);
         this.Panel1.Location = new System.Drawing.Point(0, 123);
         this.Panel1.Size = new System.Drawing.Size(240, 24);
         // 
         // cmdCancel
         // 
         this.cmdCancel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
         this.cmdCancel.Location = new System.Drawing.Point(184, 0);
         this.cmdCancel.Size = new System.Drawing.Size(56, 20);
         this.cmdCancel.Text = "Cancel";
         this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
         // 
         // cmdUpdate
         // 
         this.cmdUpdate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
         this.cmdUpdate.Location = new System.Drawing.Point(88, 0);
         this.cmdUpdate.Size = new System.Drawing.Size(56, 20);
         this.cmdUpdate.Text = "Update";
         this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
         // 
         // cmdEdit
         // 
         this.cmdEdit.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
         this.cmdEdit.Size = new System.Drawing.Size(56, 20);
         this.cmdEdit.Text = "Edit";
         this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
         // 
         // dgrdProjects
         // 
         this.dgrdProjects.Location = new System.Drawing.Point(0, 40);
         this.dgrdProjects.Size = new System.Drawing.Size(240, 80);
         this.dgrdProjects.Text = "Projects";
         // 
         // FormMain
         // 
         this.Controls.Add(this.dgrdProjects);
         this.Controls.Add(this.Panel1);
         this.Controls.Add(this.Label1);
         this.Menu = this.mainMenu1;
         this.Text = "In Place Edit";
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

      //  A TextBox control to be used for InPlace editing.
      private TextBox textEdit;

      
      private void FormMain_Load(object sender, EventArgs e)
      {
         //  Make the Project table the DataSource.
         YaoDurant.Data.UtilData  utilData = new UtilData();
         dgrdProjects.DataSource = utilData.GetProjectsDT();

         //  Use a utility routine to style the 
         //     layout of Projects in the DataGrid.
         UtilGUI.AddCustomDataTableStyle(dgrdProjects, 
                                         "Projects");

         //  Create the TextBox to be used with InPlace
         //     editing and add it to the DataGrid control.
         textEdit = new TextBox();
         textEdit.Visible = false;
         this.dgrdProjects.Controls.Add(textEdit);

         //  Set Form GUI state to "Not Editing".
         this.SetEditingState(false);
      }

      
      private void cmdEdit_Click(object sender, EventArgs e)
      {
         //  Check the DataSource's column's name
         //     if it is "ctTasks", do not update.
         DataGridCell cellCurr = dgrdProjects.CurrentCell;
         if ( dgrdProjects.TableStyles["Projects"].
                     GridColumnStyles[cellCurr.ColumnNumber].
                        MappingName == "ctTasks" ) 
         {
            MessageBox.Show("Count of tasks only changes as" +
                            " the result of adding / removing" +
                            " a task.");
            return;
         }

         //  Position textEdit for in-place editing.
         textEdit.Bounds = dgrdProjects.GetCellBounds(
                                       cellCurr.RowNumber, 
                                       cellCurr.ColumnNumber);

         //  Load the CurrentCell's value into textEdit.
         textEdit.Text = dgrdProjects[
                              cellCurr.RowNumber, 
                              cellCurr.ColumnNumber].ToString();

         //  Highlight the text.
         textEdit.SelectAll();
         
         //  Show textEdit and set the focus to it.
         textEdit.Visible = true;
         textEdit.Focus();

         //  set { Form GUI state to "Editing".
         this.SetEditingState(true);
      }


      private void cmdUpdate_Click(object sender, EventArgs e)
      {
         //  Move the contents of textEdit
         //     into the CurrentCell
         dgrdProjects[dgrdProjects.CurrentCell.RowNumber,
                      dgrdProjects.CurrentCell.ColumnNumber] = 
                      textEdit.Text;

         //  Set Form GUI state to "Not Editing".
         this.SetEditingState(false);
      }

      
      private void cmdCancel_Click(object sender, EventArgs e)
      {
         //  Set Form GUI state to "Not Editing".
         this.SetEditingState(false);
      }

   
      private void SetEditingState( bool boolInProcess) 
      {
         textEdit.Visible = boolInProcess;
         cmdEdit.Enabled = !boolInProcess;
         cmdCancel.Enabled = boolInProcess;
         cmdUpdate.Enabled = boolInProcess;
      }

   }
}
