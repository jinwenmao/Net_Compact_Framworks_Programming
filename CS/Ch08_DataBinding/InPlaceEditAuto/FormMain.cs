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
using System.ComponentModel;
using YaoDurant.Data;
using YaoDurant.GUI;


namespace InPlaceEditAuto
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FormMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
      private System.Windows.Forms.ContextMenu cmenuEdit;
      private System.Windows.Forms.DataGrid dgrdProjects;
   
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
         this.dgrdProjects = new System.Windows.Forms.DataGrid();
         this.cmenuEdit = new System.Windows.Forms.ContextMenu();
         // 
         // dgrdProjects
         // 
         this.dgrdProjects.Size = new System.Drawing.Size(240, 120);
         this.dgrdProjects.Text = "dataGrid1";
         this.dgrdProjects.CurrentCellChanged += new System.EventHandler(this.dgrdProjects_CurrentCellChanged);
         this.dgrdProjects.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgrdProjects_MouseUp);
         this.dgrdProjects.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgrdProjects_MouseDown);
         // 
         // FormMain
         // 
         this.Controls.Add(this.dgrdProjects);
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

      private MenuItem mitemUpdate = new MenuItem();
      private MenuItem mitemCancel = new MenuItem();

      //  The DataGrid's CurrentCell.  We must save it 
      //     because a new CurrentCell may be assigned
      //     before we are finished with the old one.
      private DataGridCell CurrentCell;

      //  These fields are used to determine when
      //     in-place editing should begin.
      private bool boolMouseDriven;
      private bool boolDoEdit;

      //  This field is to track whether the update
      //     should be completed or cancelled.
      private bool boolCancelUpdate;


      private void FormMain_Load(object sender, System.EventArgs e)
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

         //  Initialize the Update/Cancel context menu
         this.InitContextMenu();

         //  The default is:  Do the update.
         this.boolCancelUpdate = false;
      }

      
      private void dgrdProjects_MouseDown(object sender, 
                                          MouseEventArgs e)
      {
         //  if editing is in progress
         if( textEdit.Visible && e.Button == MouseButtons.Right ) 
         {
            //  if ( the user tapped in the row header of the row
            //     being edited, display the Update/Cancel context 
            //     menu to the user.
            if( dgrdProjects.HitTest(e.X, e.Y).Type == 
                DataGrid.HitTestType.RowHeader 
            &&  dgrdProjects.HitTest(e.X, e.Y).Row == 
                dgrdProjects.CurrentRowIndex ) 
            {
               cmenuEdit.Show(textEdit, new Point(0, 0));
            }
         }

         //  When the user taps on a data cell or a row
         //     header, the current cell will change.  
         //     Our CurrentCellChanged event will need to
         //     know that this was caused by a mouse tap,
         //     rather than by a Tab or programatically.
         boolMouseDriven = 
            ( (dgrdProjects.HitTest(e.X, e.Y).Type == 
               DataGrid.HitTestType.Cell)
            ||
              (dgrdProjects.HitTest(e.X, e.Y).Type ==
               DataGrid.HitTestType.RowHeader) );
      }


      private void dgrdProjects_CurrentCellChanged(object sender, 
         EventArgs e)
      {
         // if ( this is a mouse caused event, we must wait 
         //    for the Click and MouseUp events to complete 
         //    before displaying the Edit TextBox.  if not 
         //    mouse caused, we can display the Edit TextBox 
         //    after this message has completed processing.
         if ( boolMouseDriven ) 
         {
            boolDoEdit = true;
         } 
         else 
         {
            this.InitEdit();
         }
         boolMouseDriven = false;
      }

      
      private void dgrdProjects_MouseUp(object sender, 
                                        MouseEventArgs e)
      {
         //  if editing has been requested, we need 
         //     to display textEdit to the user.
         if ( boolDoEdit ) 
         {
            this.InitEdit();
         }
      }

      private void MenuItem_Click(object sender, 
                                  EventArgs e)
      {
         //  Note which was requested.
         //  Hide the edit TextBox.
         this.boolCancelUpdate = (sender == mitemCancel);
         textEdit.Visible = false;
      }
      

      private void textEdit_KeyUp(object sender,  
         KeyEventArgs e)
      {
         //  Check to see if the keystroke was Enter or Escape
         switch (e.KeyCode) 
         {
            case Keys.Enter:
               this.boolCancelUpdate = true;
               textEdit.Visible = false;
               break;
            case Keys.Escape:
               this.boolCancelUpdate = false;
               textEdit.Visible = false;
               break;
            default:
               break;
         }
      }


      private void textEdit_Validating(object sender, 
                                       CancelEventArgs e) 
      {
         //  To cancel or not to cancel, 
         //     that is the question.
         e.Cancel = boolCancelUpdate;
         boolCancelUpdate = false;
      }


      private void textEdit_Validated(object sender, 
         EventArgs e) 
      {
         //  Do the update.
         //  Two issues must be addressed here.  The cell 
         //     we need to update might no longer be
         //     the CurrentCell; and modifying the contents 
         //     a cell makes it the CurrentCell.  Therefore,
         //     we need to save the identity of the CurrentCell 
         //     at the start, update the cell whose identity 
         //     was saved during InitEdit, then restore the 
         //     identity of the CurrentCell.
         //  Save identity of CurrentCell.
         DataGridCell CurrentCell = dgrdProjects.CurrentCell;

         //  Move the contents of textEdit into the 
         //     "correct" CurrentCell.
         dgrdProjects[this.CurrentCell.RowNumber,
            this.CurrentCell.ColumnNumber] = 
            textEdit.Text;

         //  Restore the identity of the CurrentCell.
         dgrdProjects.CurrentCell = CurrentCell;
      }

      internal void InitEdit() 
      {
         //  Add the event handlers
         textEdit.KeyUp += new KeyEventHandler(textEdit_KeyUp);
         textEdit.Validating += 
            new System.ComponentModel.CancelEventHandler(textEdit_Validating);
         textEdit.Validated += 
            new EventHandler(textEdit_Validated);

         //  Position textEdit for in-place editing
         DataGridCell cellCurr = dgrdProjects.CurrentCell;
         textEdit.Bounds = dgrdProjects.GetCellBounds(
            cellCurr.RowNumber, 
            cellCurr.ColumnNumber);
         textEdit.Text = dgrdProjects[cellCurr.RowNumber, 
                                      cellCurr.ColumnNumber].
                                             ToString();
         textEdit.SelectAll();
         textEdit.Visible = true;
         textEdit.Focus();

         //  Save the CurrentCell.  We must save it because,
         //     if the user terminates the edit by tapping on
         //     a different cell, a new CurrentCell will be
         //     assigned before we are finished with the old 
         //     one.
         this.CurrentCell = dgrdProjects.CurrentCell;

         //  Set Form GUI state to "Editing".
         boolDoEdit = false;
      }

      private void InitContextMenu() 
      {
         //  Add "Update" and "Cancel" entries
         //     to the context menu.
         mitemUpdate.Text = "Update";
         mitemUpdate.Click += new EventHandler(MenuItem_Click);
         mitemCancel.Text = "Cancel";
         mitemCancel.Click += new EventHandler(MenuItem_Click);

         cmenuEdit.MenuItems.Clear();
         cmenuEdit.MenuItems.Add(mitemUpdate);
         cmenuEdit.MenuItems.Add(mitemCancel);
      }
      
   }
}
