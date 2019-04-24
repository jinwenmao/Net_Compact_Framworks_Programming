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

namespace DrillDownSameForm
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FormMain : System.Windows.Forms.Form
	{
      internal System.Windows.Forms.Label lblProjectName;
      private System.Windows.Forms.DataGrid dgridDisplay;
      private System.Windows.Forms.ContextMenu cmenuDrill;
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
         this.lblProjectName = new System.Windows.Forms.Label();
         this.dgridDisplay = new System.Windows.Forms.DataGrid();
         this.cmenuDrill = new System.Windows.Forms.ContextMenu();
         // 
         // lblProjectName
         // 
         this.lblProjectName.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
         this.lblProjectName.Location = new System.Drawing.Point(0, 8);
         this.lblProjectName.Size = new System.Drawing.Size(240, 24);
         // 
         // dgridDisplay
         // 
         this.dgridDisplay.ContextMenu = this.cmenuDrill;
         this.dgridDisplay.Location = new System.Drawing.Point(0, 48);
         this.dgridDisplay.Size = new System.Drawing.Size(240, 160);
         this.dgridDisplay.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgridDisplay_MouseUp);
         // 
         // cmenuDrill
         // 
         this.cmenuDrill.Popup += new System.EventHandler(this.cmenuDrill_Popup);
         // 
         // FormMain
         // 
         this.Controls.Add(this.dgridDisplay);
         this.Controls.Add(this.lblProjectName);
         this.Menu = this.mainMenu1;
         this.Text = "Drill Down";
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

      //  A reference to the DataSet
      private DataSet dsetTimeTracker;
      //  A reference to the Projects DataTable
      private DataTable dtabProjects;
      //  A reference to the Tasks DataTable
      private DataTable dtabTasks;

      //  Two ContextMenu items.
      private MenuItem mitemDrillDown = new MenuItem();
      private MenuItem mitemDrillUp = new MenuItem();

      private void FormMain_Load(object sender, EventArgs e)
      {
         // Create utility objects
         YaoDurant.Data.UtilData utilData = new UtilData();
         YaoDurant.GUI.UtilGUI utilGUI = new UtilGUI();

         //  Set references to data objects.
         dsetTimeTracker = utilData.GetProjectsDataSet();
         dtabProjects = dsetTimeTracker.Tables["Projects"];
         dtabTasks = dsetTimeTracker.Tables["Tasks"];

         //  Make the Project table the DataSource.
         //  Make the strIdent field of the currently
         //     select row the Text property of the DataGrid
         //     control.
         dgridDisplay.DataSource = dtabProjects;
         dgridDisplay.DataBindings.Clear();
         dgridDisplay.DataBindings.Add(
            "Text", 
            dgridDisplay.DataSource, 
            "strIdent");

         //  Use a utility routine to style the 
         //     layout of Projects in the DataGrid.
         UtilGUI.AddCustomDataTableStyle(dgridDisplay, 
            "Projects");

         //  Initialize the ContextMenu
         InitContextMenu();
      }


      private void dgridDisplay_MouseUp(object sender, 
                                        MouseEventArgs e)
      {
      //  If the user has clicked in a row header,
      //     display the context menu.
         if (dgridDisplay.HitTest(e.X, e.Y).Type == 
             DataGrid.HitTestType.RowHeader ) 
         {
            dgridDisplay.ContextMenu.Show(
                                       dgridDisplay, 
                                       new Point(e.X, e.Y));
         }
      }


      private void cmenuDrill_Popup(object sender, EventArgs e)
      {
      //  if ( the user is "Up", they can only go "Down"; 
      //     and vice versa.
         if ( dgridDisplay.DataSource == dtabProjects ) 
         {
            mitemDrillDown.Enabled = true;
            mitemDrillDown.Checked = false;
         } else {
            mitemDrillDown.Enabled = false;
            mitemDrillDown.Checked = true;
         }
         mitemDrillUp.Enabled = ! mitemDrillDown.Enabled;
         mitemDrillUp.Checked = ! mitemDrillDown.Checked;
      }

      
      private void mitemDrillDown_Click(object sender,
                                        EventArgs e)
      {
         //  The Text property of the DataGrid has been bound
         //     to the strIdent column of the DataSource row.
         //     So, the identity of the selected Project will
         //     be in the Text property.
         DrillDown(dgridDisplay.Text);
      }

      private void mitemDrillUp_Click(object sender,
                                      EventArgs e)
      {
         DrillUp();
      }


      private void DrillDown(string  strProjIdent) 
      {
         //  Note which project is being displayed.
         lblProjectName.Text = 
            dtabProjects.Rows[
               dgridDisplay.CurrentCell.RowNumber]["strName"].
                  ToString();

         //  Create a view of the Tasks table.
         DataView  dviewProjectTasks = new DataView(dtabTasks);

         //  set { it to display only "strProjIdent" tasks.
         dviewProjectTasks.RowFilter = 
                     "strProjIdent = '" + strProjIdent + "'";

         //  Bind it to the DataGrid control.
         dgridDisplay.DataSource = dviewProjectTasks;
      }


      private void DrillUp() {
         //  Bind the Projects DataTable to the DataGrid control.
         dgridDisplay.DataSource = dtabProjects;

         //  Clear the project name display.
         lblProjectName.Text = string.Empty;
      }


      private void InitContextMenu() 
      {
         //  Add "drill down" and "drill up" entries
         //     to the context menu.
         cmenuDrill.MenuItems.Clear();

         mitemDrillDown.Text = "Drill Down";
         mitemDrillDown.Click += 
            new EventHandler(mitemDrillDown_Click);
         cmenuDrill.MenuItems.Add(mitemDrillDown);

         mitemDrillUp.Text = "Drill Up";
         mitemDrillUp.Click += 
            new EventHandler(mitemDrillUp_Click);
         cmenuDrill.MenuItems.Add(mitemDrillUp);
      }
   }
}
