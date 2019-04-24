//-----------------------------------------------------------------------------
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Data.Common;
using System.Data.SqlServerCe;

namespace RDA
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FormMain : System.Windows.Forms.Form
	{
      internal System.Windows.Forms.MainMenu MenuMain;
      internal System.Windows.Forms.MenuItem MenuItem1;
      internal System.Windows.Forms.MenuItem mitemExit;
      internal System.Windows.Forms.MenuItem MenuItem3;
      internal System.Windows.Forms.MenuItem mitemRecreate;
      internal System.Windows.Forms.MenuItem MenuItem2;
      internal System.Windows.Forms.MenuItem mitemPull;
      internal System.Windows.Forms.MenuItem mitemUpdate;
      internal System.Windows.Forms.MenuItem mitemPush;
      internal System.Windows.Forms.MenuItem mitemSubmitSQL;

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
         this.MenuItem1 = new System.Windows.Forms.MenuItem();
         this.mitemExit = new System.Windows.Forms.MenuItem();
         this.MenuItem3 = new System.Windows.Forms.MenuItem();
         this.mitemRecreate = new System.Windows.Forms.MenuItem();
         this.MenuItem2 = new System.Windows.Forms.MenuItem();
         this.mitemPull = new System.Windows.Forms.MenuItem();
         this.mitemUpdate = new System.Windows.Forms.MenuItem();
         this.mitemPush = new System.Windows.Forms.MenuItem();
         this.mitemSubmitSQL = new System.Windows.Forms.MenuItem();
         // 
         // MenuMain
         // 
         this.MenuMain.MenuItems.Add(this.MenuItem1);
         this.MenuMain.MenuItems.Add(this.MenuItem3);
         this.MenuMain.MenuItems.Add(this.MenuItem2);
         // 
         // MenuItem1
         // 
         this.MenuItem1.MenuItems.Add(this.mitemExit);
         this.MenuItem1.Text = "File";
         // 
         // mitemExit
         // 
         this.mitemExit.Text = "Exit";
         this.mitemExit.Click += new System.EventHandler(this.mitemExit_Click);
         // 
         // MenuItem3
         // 
         this.MenuItem3.MenuItems.Add(this.mitemRecreate);
         this.MenuItem3.Text = "DataBase";
         // 
         // mitemRecreate
         // 
         this.mitemRecreate.Text = "Re-create";
         this.mitemRecreate.Click += new System.EventHandler(this.mitemRecreate_Click);
         // 
         // MenuItem2
         // 
         this.MenuItem2.MenuItems.Add(this.mitemPull);
         this.MenuItem2.MenuItems.Add(this.mitemUpdate);
         this.MenuItem2.MenuItems.Add(this.mitemPush);
         this.MenuItem2.MenuItems.Add(this.mitemSubmitSQL);
         this.MenuItem2.Text = "RDA";
         // 
         // mitemPull
         // 
         this.mitemPull.Text = "Pull";
         this.mitemPull.Click += new System.EventHandler(this.mitemPull_Click);
         // 
         // mitemUpdate
         // 
         this.mitemUpdate.Text = "Update";
         this.mitemUpdate.Click += new System.EventHandler(this.mitemUpdate_Click);
         // 
         // mitemPush
         // 
         this.mitemPush.Text = "Push";
         this.mitemPush.Click += new System.EventHandler(this.mitemPush_Click);
         // 
         // mitemSubmitSQL
         // 
         this.mitemSubmitSQL.Text = "Submit SQL";
         this.mitemSubmitSQL.Click += new System.EventHandler(this.mitemSubmitSQL_Click);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         // 
         // FormMain
         // 
         this.BackColor = System.Drawing.Color.White;
         this.ClientSize = new System.Drawing.Size(240, 270);
         this.Menu = this.MenuMain;
         this.Text = "RDA";
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

      //  The database file.
      private string  strDBFile = @"My Documents\Northwind.sdf";

      //  The local connection string.
      private string  strConnLocal = 
              "Data Source=" + @"My Documents\Northwind.sdf";

      //  The remote connection string.
      private string strConnRemote = "Provider=sqloledb; " 
                                   + "Data Source=Snowden; " 
                                   + "Initial Catalog=Northwind; " 
                                   + "Integrated Security=SSPI;";

      //  The URL
      private string strURL = 
              "http://207.202.168.30/YaoDurantRDA/sscesa20.dll";

      
      private void FormMain_Load(object sender, EventArgs e)
      {
//         mitemRecreate_Click(mitemRecreate, EventArgs.Empty);
//         mitemPull_Click(mitemPull, EventArgs.Empty);
//         mitemUpdate_Click(mitemUpdate, EventArgs.Empty);
//         mitemSubmitSQL_Click(mitemSubmitSQL, EventArgs.Empty);
//         mitemPush_Click(mitemPush, EventArgs.Empty);

         this.MinimizeBox = false;
      }


      private void mitemRecreate_Click(object sender, EventArgs e)
      {
         if(File.Exists(strDBFile)) { File.Delete(strDBFile); }

         SqlCeEngine  engine = new SqlCeEngine(strConnLocal);
         engine.CreateDatabase();
         engine.Dispose();
      }

      
      private void mitemPull_Click(object sender, EventArgs e)
      {
      //  Create a remote data access object
              SqlCeRemoteDataAccess  rdaNW = 
                 new SqlCeRemoteDataAccess(strURL, strConnLocal);
         try 
         {
            //  Have RDA:
            //     Create local tables named Categories and
            //        ErrorCategories.  
            //     Connect to the remote server and submit the
            //        SELECT statement.
            //     Place the results in the local Categories table.
            rdaNW.LocalConnectionString = strConnLocal;
            rdaNW.InternetUrl = strURL;
            rdaNW.InternetLogin = "";
            rdaNW.InternetPassword = "";
            rdaNW.Pull("Categories",
                        "SELECT CategoryID, CategoryName " + 
                        "  FROM Categories",                  
                        strConnRemote,
                        RdaTrackOption.TrackingOnWithIndexes,
                        "ErrorCategories");
         } 
         catch( SqlCeException exSQL )
         { 
            HandleSQLException(exSQL);
         } 
         finally 
         {
            rdaNW.Dispose();
         }


         //  The Identity property seed value of the new table
         //     is at 1, even after the retrieved rows have 
         //     been added to the table.  "Fix" it.
         SqlCeConnection connLocal = 
            new SqlCeConnection(strConnLocal);
         connLocal.Open();

         SqlCeCommand  cmndLocal = new SqlCeCommand();
         int intMaxCategoryID;
         try 
         {
            cmndLocal.Connection = connLocal;

            //  Retrieve the highest CategoryID in the table.
            cmndLocal.CommandText = 
               "SELECT max(CategoryID) FROM Categories";
            string strMaxCategoryID = 
               cmndLocal.ExecuteScalar().ToString();
            intMaxCategoryID = int.Parse(strMaxCategoryID);

            //  set the seed one higher.
            cmndLocal.CommandText =
               "ALTER TABLE Categories " + 
               "ALTER COLUMN CategoryID IDENTITY (" +
               (intMaxCategoryID + 1).ToString() + ",1)";
            cmndLocal.ExecuteNonQuery();
         } 
         catch( SqlCeException exSQL )
         { 
            HandleSQLException(exSQL);
         } 
         finally 
         {
            connLocal.Close();
         }
      }

      private void mitemUpdate_Click(object sender, EventArgs e)
      {
         SqlCeConnection  connLocal = 
            new SqlCeConnection(strConnLocal);
         connLocal.Open();

         SqlCeCommand  cmndLocal = new SqlCeCommand();
         try 
         {
            cmndLocal.Connection = connLocal;
            cmndLocal.CommandText = 
                          "UPDATE Categories " +
                          "   SET CategoryName = 'new Name'  " +
                          " WHERE CategoryID = 2";
            cmndLocal.ExecuteNonQuery();
            
            cmndLocal.CommandText =
               "DELETE Categories WHERE CategoryID = 3";
            cmndLocal.ExecuteNonQuery();

            cmndLocal.CommandText =
               "INSERT Categories (CategoryName) " +
               "       VALUES ('new Category I') ";
            cmndLocal.ExecuteNonQuery();
         } 
         catch( SqlCeException exSQL )
         { 
            HandleSQLException(exSQL);
         } 
         finally 
         {
            cmndLocal.Dispose();
            connLocal.Close();
         }
      }

      private void mitemPush_Click(object sender, EventArgs e)
      {
         //  Create a remote data access object
         SqlCeRemoteDataAccess  rdaNW = 
            new SqlCeRemoteDataAccess(strURL, strConnLocal);
         try 
         {
            //  Have RDA:
            //     Create local tables named Categories and
            //        ErrorCategories.  
            //     Connect to the remote server and submit
            //        the changes.
            rdaNW.LocalConnectionString = strConnLocal;
            rdaNW.InternetUrl = strURL;
            rdaNW.InternetLogin = "";
            rdaNW.InternetPassword = "";
            rdaNW.Push("Categories", strConnRemote);
         } 
         catch( SqlCeException exSQL )
         { 
            HandleSQLException(exSQL);
         } 
         finally 
         {
            rdaNW.Dispose();
         }
      }

      private void mitemSubmitSQL_Click(object sender, 
                                        EventArgs e)
      {
         //  Create a remote data access object
         SqlCeRemoteDataAccess  rdaNW = 
            new SqlCeRemoteDataAccess(strURL, strConnLocal);
         try 
         {
            //  Have RDA:
            //     Create local tables named Categories and
            //        ErrorCategories.  
            //     Connect to the remote server and submit
            //        the changes.
            rdaNW.LocalConnectionString = strConnLocal;
            rdaNW.InternetUrl = strURL;
            rdaNW.InternetLogin = "";
            rdaNW.InternetPassword = "";
            rdaNW.SubmitSql(
               "INSERT Categories (CategoryName, Description)" +
                  "VALUES ('New Category II', 'From SubmitSQL')",
               strConnRemote);
         } 
         catch( SqlCeException exSQL )
         { 
            HandleSQLException(exSQL);
         } 
         finally 
         {
            rdaNW.Dispose();
         }
      }

      private void mitemExit_Click(object sender, EventArgs e)
      {
         Application.DoEvents();
         Application.Exit();
      }

      private void HandleSQLException( SqlCeException exSQL) 
      {
         foreach( SqlCeError errSQL in exSQL.Errors )
         {
            MessageBox.Show(errSQL.Message + " : " + errSQL.Source);
         }
      } 
   }
}

