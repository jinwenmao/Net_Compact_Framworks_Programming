//-----------------------------------------------------------------------------
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Data.Common;
using System.Data.SqlServerCe;
using YaoDurant.UtilSqlCe;

namespace CreateDatabase
{
	/// <summary>
	/// Summary description for FormMain.
	/// </summary>
	public class FormMain : System.Windows.Forms.Form
	{
      internal System.Windows.Forms.MainMenu MenuMain;
      internal System.Windows.Forms.MenuItem mitemFile;
      internal System.Windows.Forms.MenuItem mitemExit;
      internal System.Windows.Forms.MenuItem MenuItem1;
      private System.Windows.Forms.DataGrid dgridParent;
      private System.Windows.Forms.DataGrid dgridChild;
      private System.Windows.Forms.MenuItem mitemWriteXML;
      internal System.Windows.Forms.MenuItem mitemBuildDS;

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
         this.MenuMain = new System.Windows.Forms.MainMenu();
         this.mitemFile = new System.Windows.Forms.MenuItem();
         this.mitemExit = new System.Windows.Forms.MenuItem();
         this.MenuItem1 = new System.Windows.Forms.MenuItem();
         this.mitemBuildDS = new System.Windows.Forms.MenuItem();
         this.mitemWriteXML = new System.Windows.Forms.MenuItem();
         this.dgridParent = new System.Windows.Forms.DataGrid();
         this.dgridChild = new System.Windows.Forms.DataGrid();
         // 
         // MenuMain
         // 
         this.MenuMain.MenuItems.Add(this.mitemFile);
         this.MenuMain.MenuItems.Add(this.MenuItem1);
         // 
         // mitemFile
         // 
         this.mitemFile.MenuItems.Add(this.mitemExit);
         this.mitemFile.Text = "File";
         // 
         // mitemExit
         // 
         this.mitemExit.Text = "Exit";
         this.mitemExit.Click += new System.EventHandler(this.mitemExit_Click);
         // 
         // MenuItem1
         // 
         this.MenuItem1.MenuItems.Add(this.mitemBuildDS);
         this.MenuItem1.MenuItems.Add(this.mitemWriteXML);
         this.MenuItem1.Text = "DataSet";
         // 
         // mitemBuildDS
         // 
         this.mitemBuildDS.Text = "Build DS";
         this.mitemBuildDS.Click += new System.EventHandler(this.mitemBuildDS_Click);
         // 
         // mitemWriteXML
         // 
         this.mitemWriteXML.Text = "Write as XML";
         this.mitemWriteXML.Click += new System.EventHandler(this.mitemWriteXML_Click);
         // 
         // dgridParent
         // 
         this.dgridParent.Size = new System.Drawing.Size(240, 80);
         this.dgridParent.Click += new System.EventHandler(this.dgridParent_Click);
         // 
         // dgridChild
         // 
         this.dgridChild.Location = new System.Drawing.Point(0, 168);
         this.dgridChild.Size = new System.Drawing.Size(240, 96);
         // 
         // FormMain
         // 
         this.Controls.Add(this.dgridChild);
         this.Controls.Add(this.dgridParent);
         this.Menu = this.MenuMain;
         this.MinimizeBox = false;
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


      //  The dataset
      private DataSet dsetDB;

      //  The database file.
      private string strDBFile = 
                              @"My Documents\ourProduceCo.sdf";

      //  The connection string.
      private string  strConn = "Data Source=" +
                                @"My Documents\ourProduceCo.sdf";

      //  The XML file.
      private string strXMLFile = 
                              @"My Documents\ourProduceCo.xml";


      private void FormMain_Load(object sender, EventArgs e)
      {
         //  Display a Close box.
         this.MinimizeBox = false;

         //  Let the form present itself.
         Application.DoEvents();

         //  Ensure that the database exists.
         if (! File.Exists(strDBFile) ) 
         {
            MessageBox.Show(
               "Database not found.  Run the CreateDatabase " +
               "program for this chapter first.  Then run " +
               "this program.");
         }
      }

      
      private void mitemBuildDS_Click(object sender, EventArgs e)
      {
         //  Build the DataSet from the Database.
         dsetDB = UtilData.BuildDataSet(strDBFile);
         DataTable dtabCurrent = dsetDB.Tables[0];

         //  Display the first table in the 
         //     Parent datagrid control.
         dgridParent.DataSource = dtabCurrent;
         dgridParent.Text = dtabCurrent.TableName;
      }

      
      private void mitemWriteXML_Click(object sender, 
                                       EventArgs e)
      {
         //  Write the dataset as XML to a file.
         if ( File.Exists(strXMLFile) ) 
         { 
            File.Delete(strXMLFile);
         }
         dsetDB.WriteXml(strXMLFile);
         MessageBox.Show("XML File written to " +
                         "'My Documents' directory");
      }

      
      private void dgridParent_Click(object sender, EventArgs e)
      {
         //  get the child rows of the currently selected row,
         //     based on the "FKProdCat" relationship.  Turn that
         //     array of rows into a table and make that table
         //     the DataSource of the child DataGrid.

         //  The Parent DataGrid's DataTable
         DataTable dtabParent =
            dgridParent.DataSource as DataTable;

         //  The selected row in the Parent DataGrid
         int ixSelectedRow = dgridParent.CurrentRowIndex;

         //  Retrieve the table of child rows.
         dgridChild.DataSource =
            UtilData.ConvertArrayToTable(
               dtabParent.Rows[ixSelectedRow]
                  .GetChildRows("FKProdCat"));
      }


      private void mitemExit_Click(object sender, EventArgs e)
      {
         Application.Exit();
      }

   }
}
