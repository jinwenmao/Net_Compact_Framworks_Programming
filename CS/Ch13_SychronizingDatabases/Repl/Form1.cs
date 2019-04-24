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

namespace Repl
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FormMain : System.Windows.Forms.Form
	{
      internal System.Windows.Forms.MainMenu MenuMain;
      internal System.Windows.Forms.MenuItem mitemFile;
      internal System.Windows.Forms.MenuItem mitemExit;
      internal System.Windows.Forms.MenuItem MenuItem3;
      internal System.Windows.Forms.MenuItem mitemRecreate;
      internal System.Windows.Forms.MenuItem MenuItem2;
      internal System.Windows.Forms.MenuItem mitemCreateSubscription;
      internal System.Windows.Forms.MenuItem mitemSynchronize;
      internal System.Windows.Forms.MenuItem mitemLocalUpdate;
      internal System.Windows.Forms.MenuItem MenuItem1;
      internal System.Windows.Forms.MenuItem mitemObjects;
      internal System.Windows.Forms.MenuItem mitemConstraints;
      internal System.Windows.Forms.MenuItem MenuItem4;
      internal System.Windows.Forms.MenuItem mitemEmployees;
      internal System.Windows.Forms.MenuItem mitemCustomers;
      internal System.Windows.Forms.MenuItem mitemProducts;
      internal System.Windows.Forms.MenuItem mitemOrders;
      private System.Windows.Forms.DataGrid dgridOutput;
      internal System.Windows.Forms.MenuItem mitemOrderDetails;

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
         this.MenuItem3 = new System.Windows.Forms.MenuItem();
         this.mitemRecreate = new System.Windows.Forms.MenuItem();
         this.MenuItem2 = new System.Windows.Forms.MenuItem();
         this.mitemCreateSubscription = new System.Windows.Forms.MenuItem();
         this.mitemSynchronize = new System.Windows.Forms.MenuItem();
         this.mitemLocalUpdate = new System.Windows.Forms.MenuItem();
         this.MenuItem1 = new System.Windows.Forms.MenuItem();
         this.mitemObjects = new System.Windows.Forms.MenuItem();
         this.mitemConstraints = new System.Windows.Forms.MenuItem();
         this.MenuItem4 = new System.Windows.Forms.MenuItem();
         this.mitemEmployees = new System.Windows.Forms.MenuItem();
         this.mitemCustomers = new System.Windows.Forms.MenuItem();
         this.mitemProducts = new System.Windows.Forms.MenuItem();
         this.mitemOrders = new System.Windows.Forms.MenuItem();
         this.mitemOrderDetails = new System.Windows.Forms.MenuItem();
         this.dgridOutput = new System.Windows.Forms.DataGrid();
         // 
         // MenuMain
         // 
         this.MenuMain.MenuItems.Add(this.mitemFile);
         this.MenuMain.MenuItems.Add(this.MenuItem3);
         this.MenuMain.MenuItems.Add(this.MenuItem2);
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
         this.MenuItem2.MenuItems.Add(this.mitemCreateSubscription);
         this.MenuItem2.MenuItems.Add(this.mitemSynchronize);
         this.MenuItem2.MenuItems.Add(this.mitemLocalUpdate);
         this.MenuItem2.Text = "Repl";
         // 
         // mitemCreateSubscription
         // 
         this.mitemCreateSubscription.Text = "Create Subscription";
         this.mitemCreateSubscription.Click += new System.EventHandler(this.mitemCreateSubscription_Click);
         // 
         // mitemSynchronize
         // 
         this.mitemSynchronize.Text = "Synchronize";
         this.mitemSynchronize.Click += new System.EventHandler(this.mitemSynchronize_Click);
         // 
         // mitemLocalUpdate
         // 
         this.mitemLocalUpdate.Text = "Do Local Update";
         this.mitemLocalUpdate.Click += new System.EventHandler(this.mitemLocalUpdate_Click);
         // 
         // MenuItem1
         // 
         this.MenuItem1.MenuItems.Add(this.mitemObjects);
         this.MenuItem1.MenuItems.Add(this.mitemConstraints);
         this.MenuItem1.MenuItems.Add(this.MenuItem4);
         this.MenuItem1.Text = "View";
         // 
         // mitemObjects
         // 
         this.mitemObjects.Text = "Objects";
         this.mitemObjects.Click += new System.EventHandler(this.mitemObjects_Click);
         // 
         // mitemConstraints
         // 
         this.mitemConstraints.Text = "Contraints";
         this.mitemConstraints.Click += new System.EventHandler(this.mitemConstraints_Click);
         // 
         // MenuItem4
         // 
         this.MenuItem4.MenuItems.Add(this.mitemEmployees);
         this.MenuItem4.MenuItems.Add(this.mitemCustomers);
         this.MenuItem4.MenuItems.Add(this.mitemProducts);
         this.MenuItem4.MenuItems.Add(this.mitemOrders);
         this.MenuItem4.MenuItems.Add(this.mitemOrderDetails);
         this.MenuItem4.Text = "Tables";
         // 
         // mitemEmployees
         // 
         this.mitemEmployees.Text = "Employees";
         this.mitemEmployees.Click += new System.EventHandler(this.mitemTables_Click);
         // 
         // mitemCustomers
         // 
         this.mitemCustomers.Text = "Customers";
         this.mitemCustomers.Click += new System.EventHandler(this.mitemTables_Click);
         // 
         // mitemProducts
         // 
         this.mitemProducts.Text = "Products";
         this.mitemProducts.Click += new System.EventHandler(this.mitemTables_Click);
         // 
         // mitemOrders
         // 
         this.mitemOrders.Text = "Orders";
         this.mitemOrders.Click += new System.EventHandler(this.mitemTables_Click);
         // 
         // mitemOrderDetails
         // 
         this.mitemOrderDetails.Text = "\"Order Details\"";
         this.mitemOrderDetails.Click += new System.EventHandler(this.mitemTables_Click);
         // 
         // dgridOutput
         // 
         this.dgridOutput.Size = new System.Drawing.Size(240, 200);
         this.dgridOutput.Text = "dataGrid1";
         // 
         // FormMain
         // 
         this.Controls.Add(this.dgridOutput);
         this.Menu = this.MenuMain;
         this.Text = "Replication";
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

      //  The URL
      private string strURL = 
         "http://207.202.168.30/YaoDurantRDA/sscesa20.dll";

      private void FormMain_Load(object sender, System.EventArgs e)
      {
         this.MinimizeBox = false;      
      }

      private void mitemRecreate_Click(object sender, System.EventArgs e)
      {
         if(File.Exists(strDBFile)) { File.Delete(strDBFile); }
      }

      private void mitemCreateSubscription_Click(object sender, 
                                                 EventArgs e)
      {
         SqlCeReplication  replNW = new SqlCeReplication();
         try 
         {
            replNW.ExchangeType = ExchangeType.BiDirectional;
            replNW.InternetUrl = strURL;
            replNW.InternetLogin = "";
            replNW.InternetPassword = "";
            replNW.Publisher = "SNOWDEN";
            replNW.PublisherDatabase = "Northwind";
            replNW.Publication = "EmployeeOrderInfo";
            replNW.PublisherSecurityMode =
               SecurityType.DBAuthentication;
            replNW.PublisherLogin = "Davolio";
            replNW.PublisherPassword = "Nancy";
            replNW.Subscriber = "YaoDurant";
            replNW.SubscriberConnectionString = strConnLocal;

            replNW.AddSubscription(AddOption.CreateDatabase);
         } 
         catch( SqlCeException exSQL ) 
         { 
            HandleSQLException(exSQL);
         } 
         finally 
         {
            replNW.Dispose();
         }
      }

      private void mitemSynchronize_Click(object sender, System.EventArgs e)
      {
         SqlCeReplication  replNW = new SqlCeReplication();
         try 
         {
            replNW.ExchangeType = ExchangeType.BiDirectional;
            replNW.InternetUrl = strURL;
            replNW.InternetLogin = "";
            replNW.InternetPassword = "";
            replNW.Publisher = "SNOWDEN";
            replNW.PublisherDatabase = "Northwind";
            replNW.Publication = "EmployeeOrderInfo";
            replNW.PublisherSecurityMode =
               SecurityType.DBAuthentication;
            replNW.PublisherLogin = "Davolio";
            replNW.PublisherPassword = "Nancy";
            replNW.Subscriber = "YaoDurant";
            replNW.SubscriberConnectionString = strConnLocal;

            replNW.Synchronize();
         } 
         catch( SqlCeException exSQL ) 
         { 
            HandleSQLException(exSQL);
         } 
         finally 
         {
            replNW.Dispose();
         }
      }

      private void mitemLocalUpdate_Click(object sender, System.EventArgs e)
      {
         SqlCeConnection  connLocal = 
            new SqlCeConnection(strConnLocal);
         connLocal.Open();

         SqlCeCommand  cmndLocal = new SqlCeCommand();
         try {
            cmndLocal.Connection = connLocal;
            cmndLocal.CommandText = 
               "INSERT \"Order Details\" " +
               " (OrderID, ProductID, UnitPrice, " +
               "  Quantity, Discount) " +
               " VALUES (10258, 1, 19.95, 44, 0.0)";
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

      private void mitemObjects_Click(object sender, System.EventArgs e)
      {
         //  Show all database objects.
         DisplayResultSet("SELECT * FROM msysObjects", 
                          "Type, Flags DESC, Name");
      }

      private void mitemConstraints_Click(object sender, System.EventArgs e)
      {
         //  Show all database constraints.
         DisplayResultSet(
            "SELECT * FROM msysConstraints",
            "TABLE_NAME, CONSTRAINT_TYPE DESC, CONSTRAINT_NAME, ORDINAL");
      }

      private void mitemTables_Click(object sender, System.EventArgs e)
      {
         DisplayResultSet("SELECT * FROM " + 
                             (sender as MenuItem).Text, 
                          String.Empty);
      }

      private void mitemExit_Click(object sender, EventArgs e)
      {
         Application.DoEvents();
         Application.Exit();
      }

      private void DisplayResultSet(string  strSQL,  
                                    string  strSort) 
      {
         //  Create adapter.
         SqlCeDataAdapter  daptDB = 
            new SqlCeDataAdapter(strSQL, strConnLocal);

         //  Create data table.
         DataTable  dtabTemp = new DataTable("Temp");

         //  Fill it.
         daptDB.Fill(dtabTemp);

         //  Sort it
         dtabTemp.DefaultView.Sort = strSort;

         //  Display it.
         dgridOutput.DataSource = dtabTemp;
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
