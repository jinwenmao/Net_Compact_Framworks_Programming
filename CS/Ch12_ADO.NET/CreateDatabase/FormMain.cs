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
      internal System.Windows.Forms.MenuItem mitemBase;
      internal System.Windows.Forms.MenuItem mitemCreateDB;
      internal System.Windows.Forms.MenuItem mitemCreateTables;
      internal System.Windows.Forms.MenuItem mitemLoadData;
      internal System.Windows.Forms.MenuItem mitemDropDB;
      internal System.Windows.Forms.MenuItem MenuItem1;
      private System.Windows.Forms.DataGrid dgridParent;
      private System.Windows.Forms.DataGrid dgridChild;
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
         this.mitemBase = new System.Windows.Forms.MenuItem();
         this.mitemCreateDB = new System.Windows.Forms.MenuItem();
         this.mitemCreateTables = new System.Windows.Forms.MenuItem();
         this.mitemLoadData = new System.Windows.Forms.MenuItem();
         this.mitemDropDB = new System.Windows.Forms.MenuItem();
         this.MenuItem1 = new System.Windows.Forms.MenuItem();
         this.mitemBuildDS = new System.Windows.Forms.MenuItem();
         this.dgridParent = new System.Windows.Forms.DataGrid();
         this.dgridChild = new System.Windows.Forms.DataGrid();
         // 
         // MenuMain
         // 
         this.MenuMain.MenuItems.Add(this.mitemFile);
         this.MenuMain.MenuItems.Add(this.mitemBase);
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
         // mitemBase
         // 
         this.mitemBase.MenuItems.Add(this.mitemCreateDB);
         this.mitemBase.MenuItems.Add(this.mitemCreateTables);
         this.mitemBase.MenuItems.Add(this.mitemLoadData);
         this.mitemBase.MenuItems.Add(this.mitemDropDB);
         this.mitemBase.Text = "Database";
         // 
         // mitemCreateDB
         // 
         this.mitemCreateDB.Text = "Create DB";
         this.mitemCreateDB.Click += new System.EventHandler(this.mitemCreateDB_Click);
         // 
         // mitemCreateTables
         // 
         this.mitemCreateTables.Text = "Create Tables";
         this.mitemCreateTables.Click += new System.EventHandler(this.mitemCreateTables_Click);
         // 
         // mitemLoadData
         // 
         this.mitemLoadData.Text = "Load Data";
         this.mitemLoadData.Click += new System.EventHandler(this.mitemLoadData_Click);
         // 
         // mitemDropDB
         // 
         this.mitemDropDB.Text = "Drop Database";
         this.mitemDropDB.Click += new System.EventHandler(this.mitemDropDB_Click);
         // 
         // MenuItem1
         // 
         this.MenuItem1.MenuItems.Add(this.mitemBuildDS);
         this.MenuItem1.Text = "DataSet";
         // 
         // mitemBuildDS
         // 
         this.mitemBuildDS.Text = "Build DS";
         this.mitemBuildDS.Click += new System.EventHandler(this.mitemBuildDS_Click);
         // 
         // dgridParent
         // 
         this.dgridParent.Size = new System.Drawing.Size(240, 80);
         // 
         // dgridChild
         // 
         this.dgridChild.Location = new System.Drawing.Point(0, 192);
         this.dgridChild.Size = new System.Drawing.Size(240, 72);
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


      private string  strFile = @"My Documents\ourProduceCo.sdf";
      private string  strConn = "Data Source=" + 
                                @"My Documents\ourProduceCo.sdf";

      private void FormMain_Load(object sender, System.EventArgs e)
      {
         this.MinimizeBox = false;
      }

      private void mitemCreateDB_Click(object sender, System.EventArgs e)
      {
         if ( File.Exists(strFile) ) { File.Delete(strFile); }

         SqlCeEngine dbEngine = new SqlCeEngine();
         dbEngine.LocalConnectionString = strConn;
         try
         {
            dbEngine.CreateDatabase();
         }
         catch( SqlCeException exSQL )
         {
            MessageBox.Show("Unable to create database at " + 
                            strFile + 
                            ". Reason:  " + 
                            exSQL.Errors[0].Message );
         }
      }

      private void mitemCreateTables_Click(object sender, System.EventArgs e)
      {
         SqlCeConnection  connDB = new SqlCeConnection();
         SqlCeCommand  cmndDB = new SqlCeCommand();

         connDB.ConnectionString = strConn;
         connDB.Open();

         cmndDB.Connection = connDB;

         cmndDB.CommandText =
            " CREATE TABLE Categories " +
            "  ( CategoryID integer not null " +
            "         CONSTRAINT PKCategories PRIMARY KEY " +
            "  , CategoryName nchar(20) not null " +
            "  )";
         cmndDB.ExecuteNonQuery();

         cmndDB.CommandText =
            " CREATE TABLE Products " +
            "  ( ProductID integer not null " +
            "         CONSTRAINT PKProducts PRIMARY KEY " +
            "  , ProductName nchar(20) not null " +
            "  , CategoryID integer not null " +
            "  , CONSTRAINT FKProdCat " +
            "       foreign key (CategoryID) " +
            "       references Categories(CategoryID) " +
            "  )";
         cmndDB.ExecuteNonQuery();

         connDB.Close();
      }

      private void mitemLoadData_Click(object sender, System.EventArgs e)
      {
         SqlCeConnection  connDB = new SqlCeConnection();
         SqlCeCommand  cmndDB = new SqlCeCommand();

         connDB.ConnectionString = strConn;
         connDB.Open();

         cmndDB.Connection = connDB;
         cmndDB.CommandText =
            " INSERT Categories " +
            "   (CategoryID, CategoryName)" +
            "   VALUES (1, 'Franistans' )";
         cmndDB.ExecuteNonQuery();
         cmndDB.CommandText =
            " INSERT Categories " +
            "   (CategoryID, CategoryName)" +
            "   VALUES (2, 'Widgets' )";
         cmndDB.ExecuteNonQuery();

         cmndDB.CommandText =
            " INSERT Products " +
            "   (ProductID, ProductName, CategoryID)" +
            "   VALUES (11, 'Franistans - Large', 1 )";
         cmndDB.ExecuteNonQuery();
         cmndDB.CommandText =
            " INSERT Products " +
            "   (ProductID, ProductName, CategoryID)" +
            "   VALUES (12, 'Franistans - Medium', 1 )";
         cmndDB.ExecuteNonQuery();
         cmndDB.CommandText =
            " INSERT Products " +
            "   (ProductID, ProductName, CategoryID)" +
            "   VALUES (13, 'Franistans - Small', 1 )";
         cmndDB.ExecuteNonQuery();
         cmndDB.CommandText =
            " INSERT Products " +
            "   (ProductID, ProductName, CategoryID)" +
            "   VALUES (21, 'Widgets - Large', 2 )";
         cmndDB.ExecuteNonQuery();
         cmndDB.CommandText =
            " INSERT Products " +
            "   (ProductID, ProductName, CategoryID)" +
            "   VALUES (22, 'Widgets - Medium', 2 )";
         cmndDB.ExecuteNonQuery();
         cmndDB.CommandText =
            " INSERT Products " +
            "   (ProductID, ProductName, CategoryID)" +
            "   VALUES (23, 'Widgets - Small', 2 )";
         cmndDB.ExecuteNonQuery();

         connDB.Close();
      }

      private void mitemDropDB_Click(object sender, System.EventArgs e)
      {
         File.Delete(strFile);
      }

      private void mitemBuildDS_Click(object sender, System.EventArgs e)
      {
         //  Build the DataSet from the Database.
         DataSet dsetWork = UtilData.BuildDataSet(strFile);
         DataTable dtabCurrent = dsetWork.Tables[0];

         //  Display the first table in the 
         //     Parent datagrid control.
         dgridParent.DataSource = dtabCurrent;
         dgridParent.Text = dtabCurrent.TableName;
      }

      private void mitemExit_Click(object sender, System.EventArgs e)
      {
         Application.Exit();
      }

   }
}
