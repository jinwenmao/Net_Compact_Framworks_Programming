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
	/// Summary description for FormGrids.
	/// </summary>
	public class FormGrids : System.Windows.Forms.Form
	{
      internal System.Windows.Forms.MainMenu MenuMain;
      internal System.Windows.Forms.MenuItem mitemFile;
      internal System.Windows.Forms.MenuItem mitemExit;
      internal System.Windows.Forms.MenuItem MenuItem1;
      private System.Windows.Forms.DataGrid dgridParent;
      private System.Windows.Forms.DataGrid dgridChild;
      private System.Windows.Forms.MenuItem mitemDisplayDS;
      private System.Windows.Forms.MenuItem mitemDisplayProducts;
      private System.Windows.Forms.MenuItem mitemDisplayUpdater;
      internal System.Windows.Forms.MenuItem mitemBuildDS;

		public FormGrids()
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
         this.mitemDisplayDS = new System.Windows.Forms.MenuItem();
         this.mitemDisplayProducts = new System.Windows.Forms.MenuItem();
         this.dgridParent = new System.Windows.Forms.DataGrid();
         this.dgridChild = new System.Windows.Forms.DataGrid();
         this.mitemDisplayUpdater = new System.Windows.Forms.MenuItem();
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
         this.MenuItem1.MenuItems.Add(this.mitemDisplayDS);
         this.MenuItem1.MenuItems.Add(this.mitemDisplayProducts);
         this.MenuItem1.MenuItems.Add(this.mitemDisplayUpdater);
         this.MenuItem1.Text = "DataSet";
         // 
         // mitemBuildDS
         // 
         this.mitemBuildDS.Text = "Build DS";
         this.mitemBuildDS.Click += new System.EventHandler(this.mitemBuildDS_Click);
         // 
         // mitemDisplayDS
         // 
         this.mitemDisplayDS.Text = "Display DS";
         this.mitemDisplayDS.Click += new System.EventHandler(this.mitemDisplayDS_Click);
         // 
         // mitemDisplayProducts
         // 
         this.mitemDisplayProducts.Text = "Display One Row";
         this.mitemDisplayProducts.Click += new System.EventHandler(this.mitemDisplayProducts_Click);
         // 
         // dgridParent
         // 
         this.dgridParent.Size = new System.Drawing.Size(240, 80);
         this.dgridParent.Click += new System.EventHandler(this.dgridParent_Click);
         // 
         // dgridChild
         // 
         this.dgridChild.Location = new System.Drawing.Point(0, 136);
         this.dgridChild.Size = new System.Drawing.Size(240, 128);
         // 
         // mitemDisplayUpdater
         // 
         this.mitemDisplayUpdater.Text = "Display Updater";
         this.mitemDisplayUpdater.Click += new System.EventHandler(this.mitemDisplayUpdater_Click);
         // 
         // FormGrids
         // 
         this.Controls.Add(this.dgridChild);
         this.Controls.Add(this.dgridParent);
         this.Menu = this.MenuMain;
         this.MinimizeBox = false;
         this.Text = "FormGrids";
         this.Load += new System.EventHandler(this.FormGrids_Load);

      }
		#endregion


		/// <summary>
		/// The main entry point for the application.
		/// </summary>

//		static void Main() 
//		{
//			Application.Run(new FormGrids());
//		}


      //  File path and name.
      private string strFile =
         @"My Documents\ourProduceCo.sdf";

      //  Connection string.
      private string strConn =
         "Data Source=" + @"My Documents\ourProduceCo.sdf";

      //  The DataSet
      private DataSet dsetDB;

      //  The DataAdapters
      private SqlCeDataAdapter daptCategories;
      private SqlCeDataAdapter daptProducts;


      private void FormGrids_Load(object sender, EventArgs e)
      {
         //  Display a Close box.
         this.MinimizeBox = false;

         //  Let the form present itself.
         Application.DoEvents();

         //  Ensure that the database exists.
         if (! File.Exists(strFile) ) 
         {
            MessageBox.Show(
               "Database not found.  Run the CreateDatabase " +
               "program for this chapter first.  Then run " +
               "this program.");
         }

         mitemBuildDS_Click(mitemBuildDS, EventArgs.Empty);
      }

      private void mitemBuildDS_Click(object sender, EventArgs e)
      {
         //  Create the dataset.
         dsetDB = new DataSet("Produce");

         //  Load the Categories and Products tables
         //     from the database into the dataset.

         //  Create an adapter to load Categories.  Pass it
         //     the SQL statement and the connection string.
         //     Use its Fill method to transfer the rows from
         //     the database to the dataset.
         daptCategories = new         
            SqlCeDataAdapter( 
               "SELECT CategoryID, CategoryName FROM Categories", 
               strConn);
         daptCategories.Fill(dsetDB, "Categories");

         //  Now do the same for Products.
         daptProducts = new
            SqlCeDataAdapter(
               " SELECT P.ProductID, P.ProductName, " +
               "        P.CategoryID, C.CategoryName " +
               "   FROM Products P " +
               "   JOIN Categories C ON " +
               "                   C.CategoryID = P.CategoryID",
            strConn);
         SqlCeCommandBuilder  cbldProducts = new                        SqlCeCommandBuilder(daptProducts);
         daptProducts.Fill(dsetDB, "Products");

         //  Now define the relationship 
         //     between Products and Categories.
         dsetDB.Relations.Add(
            "FKProdCat",
            dsetDB.Tables["Categories"].Columns["CategoryID"],
            dsetDB.Tables["Products"].Columns["CategoryID"],                  true);
      }

      
      private void mitemDisplayDS_Click(object sender, EventArgs e)
      {
         //  Display the Categories and Products tables
         //     in the parent and child DataGrids.
         dgridParent.DataSource = dsetDB.Tables["Categories"];
         dgridChild.DataSource = dsetDB.Tables["Products"];
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


      private void mitemDisplayProducts_Click(object sender, EventArgs e)
      {
         ModData.dsetDB = this.dsetDB;
         ModData.daptProducts = this.daptProducts;
         ModData.daptCategories = this.daptCategories;
         FormOneRow frmOneRow = new FormOneRow();
         frmOneRow.MinimizeBox = false;
         frmOneRow.Show();
      }


      private void mitemExit_Click(object sender, EventArgs e)
      {
         Application.Exit();
      }

      private void mitemDisplayUpdater_Click(object sender, EventArgs e)
      {
         FormUpdate frmUpdate = new FormUpdate();
         frmUpdate.Show();
      }

   }
}
