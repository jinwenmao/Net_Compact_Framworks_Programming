//-----------------------------------------------------------------------------
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using YaoDurant.UtilSqlCe;

namespace CreateDatabase
{
	/// <summary>
	/// Summary description for FormGrids.
	/// </summary>
	public class FormGridsBetter : System.Windows.Forms.Form
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

		public FormGridsBetter()
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
         this.mitemDisplayUpdater = new System.Windows.Forms.MenuItem();
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
         // mitemDisplayUpdater
         // 
         this.mitemDisplayUpdater.Text = "Display Updater";
         this.mitemDisplayUpdater.Click += new System.EventHandler(this.mitemDisplayUpdater_Click);
         // 
         // dgridParent
         // 
         this.dgridParent.Size = new System.Drawing.Size(240, 80);
         this.dgridParent.CurrentCellChanged += new System.EventHandler(this.dgridParent_CurrentCellChanged);
         // 
         // dgridChild
         // 
         this.dgridChild.Location = new System.Drawing.Point(0, 136);
         this.dgridChild.Size = new System.Drawing.Size(240, 128);
         // 
         // FormGridsBetter
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

		static void Main() 
		{
			Application.Run(new FormGridsBetter());
		}


      //  Connection string.
      private string  strConn = 
         "data source=207.202.168.30;" + 
         "initial catalog=Northwind;" +
         "user id=DeliveryDriver;" + 
         "pwd=DD;" + 
         "workstation id=SNOWDEN;" + 
         "packet size=4096;" + 
         "persist security info=False;";

      //  The DataSet
      private DataSet dsetDB;

      //  The DataAdapters
      private SqlDataAdapter daptCategories;
      private SqlDataAdapter daptProducts;


      private void FormGrids_Load(object sender, EventArgs e)
      {
         //  Display a Close box.
         this.MinimizeBox = false;

         //  Let the form present itself.
         Application.DoEvents();

         // Make menu selections load and display data.
         mitemBuildDS_Click(mitemBuildDS, EventArgs.Empty);
         mitemDisplayDS_Click(mitemDisplayDS, EventArgs.Empty);
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
            SqlDataAdapter( 
               "SELECT CategoryID, CategoryName FROM Categories", 
               strConn);
         daptCategories.Fill(dsetDB, "Categories");

         //  Now do the same for Products.
         daptProducts = new
            SqlDataAdapter(
               " SELECT P.ProductID, P.ProductName, " +
               "        P.CategoryID, C.CategoryName " +
               "   FROM Products P " +
               "   JOIN Categories C ON " +
               "                   C.CategoryID = P.CategoryID",
            strConn);
         SqlCommandBuilder  cbldProducts = new                        SqlCommandBuilder(daptProducts);
         daptProducts.Fill(dsetDB, "Products");

         //  Now define the relationship 
         //     between Products and Categories.
         dsetDB.Relations.Add(
            "FKProdCat",
            dsetDB.Tables["Categories"].Columns["CategoryID"],
            dsetDB.Tables["Products"].Columns["CategoryID"], 
            true);
      }

      
      private void mitemDisplayDS_Click(object sender, EventArgs e)
      {
         //  Display the Categories and Products tables
         //     in the parent and child DataGrids.
         dgridParent.DataSource = 
            dsetDB.Tables["Categories"];
         dgridChild.DataSource = 
            dsetDB.Tables["Products"].DefaultView;

         // Initialize the Categories selection to the first category.
         dgridParent.CurrentCell = new DataGridCell(0,0);
         dgridParent_CurrentCellChanged(dgridParent, EventArgs.Empty);
      }


      private void dgridParent_CurrentCellChanged(object sender, 
                                                  EventArgs e)
      {
         // Set the Product's row filter to view
         //    only Products for the selected Category.
         DataTable dtabParent = (DataTable)dgridParent.DataSource;
         DataView dviewChild = (DataView)dgridChild.DataSource;
         dviewChild.RowFilter = 
            "CategoryID = " + 
            dtabParent.Rows[dgridParent.CurrentRowIndex]["CategoryID"];
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
