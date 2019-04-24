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

namespace DataReader
{
	/// <summary>
	/// Summary description for FormMain.
	/// </summary>
	public class FormMain : System.Windows.Forms.Form
	{
      internal System.Windows.Forms.Label lblCategoryName;
      internal System.Windows.Forms.Label lblProductName;
      internal System.Windows.Forms.Label lblProductID;
      internal System.Windows.Forms.TextBox textCategoryName;
      internal System.Windows.Forms.TextBox textProductName;
      internal System.Windows.Forms.TextBox textProductID;
      internal System.Windows.Forms.ComboBox comboKeys;
      
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
         this.lblCategoryName = new System.Windows.Forms.Label();
         this.lblProductName = new System.Windows.Forms.Label();
         this.lblProductID = new System.Windows.Forms.Label();
         this.textCategoryName = new System.Windows.Forms.TextBox();
         this.textProductName = new System.Windows.Forms.TextBox();
         this.textProductID = new System.Windows.Forms.TextBox();
         this.comboKeys = new System.Windows.Forms.ComboBox();
         // 
         // lblCategoryName
         // 
         this.lblCategoryName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
         this.lblCategoryName.Location = new System.Drawing.Point(20, 128);
         this.lblCategoryName.Size = new System.Drawing.Size(80, 16);
         // 
         // lblProductName
         // 
         this.lblProductName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
         this.lblProductName.Location = new System.Drawing.Point(20, 88);
         this.lblProductName.Size = new System.Drawing.Size(80, 16);
         // 
         // lblProductID
         // 
         this.lblProductID.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
         this.lblProductID.Location = new System.Drawing.Point(20, 48);
         this.lblProductID.Size = new System.Drawing.Size(80, 16);
         // 
         // textCategoryName
         // 
         this.textCategoryName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
         this.textCategoryName.Location = new System.Drawing.Point(116, 120);
         this.textCategoryName.Size = new System.Drawing.Size(120, 22);
         this.textCategoryName.Text = "";
         // 
         // textProductName
         // 
         this.textProductName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
         this.textProductName.Location = new System.Drawing.Point(116, 80);
         this.textProductName.Size = new System.Drawing.Size(120, 22);
         this.textProductName.Text = "";
         this.textProductName.Validated += new System.EventHandler(this.textProductName_Validated);
         // 
         // textProductID
         // 
         this.textProductID.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
         this.textProductID.Location = new System.Drawing.Point(116, 40);
         this.textProductID.Size = new System.Drawing.Size(120, 22);
         this.textProductID.Text = "";
         // 
         // comboKeys
         // 
         this.comboKeys.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
         this.comboKeys.Location = new System.Drawing.Point(4, 0);
         this.comboKeys.Size = new System.Drawing.Size(48, 22);
         this.comboKeys.SelectedIndexChanged += new System.EventHandler(this.comboKeys_SelectedIndexChanged);
         // 
         // FormMain
         // 
         this.Controls.Add(this.lblCategoryName);
         this.Controls.Add(this.lblProductName);
         this.Controls.Add(this.lblProductID);
         this.Controls.Add(this.textCategoryName);
         this.Controls.Add(this.textProductName);
         this.Controls.Add(this.textProductID);
         this.Controls.Add(this.comboKeys);
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
      
      
      //  File path and name.
      private string  strFile = @"My Documents\ourProduceCo.sdf";

      //  Connection string.
      private string  strConn = "Data Source=" + 
                                @"My Documents\ourProduceCo.sdf";

      //  Select product keys
      private string strGetProductIDs =
         " SELECT ProductID " +      "   FROM Products ";

      //  Select one product, joined with its category.
      private string strGetOneProduct =
         " SELECT ProductID, ProductName, CategoryName " +
         "   FROM Products P " +
         "   JOIN Categories C on C.CategoryID = P.CategoryID " +
         "  WHERE P.ProductID = ";

      //  Used to bypass the SelectIndexChanged event 
      //     during the loading of the ComboBox.
      private bool boolLoading = true;

      
      private void FormMain_Load(object sender, EventArgs e)
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

         //  Load product keys into the ComboBox
         //     and select the first one.
         LoadProductIDs();
         comboKeys.SelectedIndex = 0;
      }

      private void comboKeys_SelectedIndexChanged(object sender, 
                                                  EventArgs e)
      {
         //  A product key has been selected, retrieve
         //     and display the corresponding product.
         if (! boolLoading ) 
         {
            LoadOneProduct((int)comboKeys.SelectedItem);
         }
      }

      private void textProductName_Validated(object sender, System.EventArgs e)
      {
         //  Update this product row in the database.
         UpdateSelectedRow(int.Parse(textProductID.Text), 
                           textProductName.Text);
      }

      private void LoadProductIDs() 
      {
         //  Clear the ComboBox
         comboKeys.Items.Clear();

         //  A connection, a command, and a reader.
         SqlCeConnection connDB = 
            new SqlCeConnection(strConn);
         SqlCeCommand cmndDB = 
            new SqlCeCommand(strGetProductIDs, connDB);
         SqlCeDataReader drdrDB;

         //  Open the connection.
         connDB.Open();

         //  Submit the SQL statement and receive
         //     the SqlCeReader for the results set. 
         drdrDB = cmndDB.ExecuteReader();

         //  Read each row.  Add the contents of its
         //     only column as an entry in the ComboBox.
         //     Close the reader when done.
         while ( drdrDB.Read() )
         {
            comboKeys.Items.Add(drdrDB["ProductID"]);
         }
         drdrDB.Close();

         //  Close the connection.
         connDB.Close();

         //  Start responding to ComboBox//s
         //     SelectedIndexChanged events.
         this.boolLoading = false;
      }

      private void LoadOneProduct( int intProductID) 
      {
         //  A connection, a command, and a reader.
         SqlCeConnection  connDB = new SqlCeConnection(strConn);
         SqlCeCommand cmndDB = new SqlCeCommand();
         SqlCeDataReader drdrDB;

         //  Open the connection.
         connDB.Open();

         //  Set the command object to retrieve
         //     rows from one table via one index.
         //  Then retrieve the reader.
         cmndDB.Connection = connDB;
         cmndDB.CommandType = CommandType.TableDirect;
         cmndDB.CommandText = "Products";
         cmndDB.IndexName = "PKProducts";
         drdrDB = cmndDB.ExecuteReader();

         //  Retrieve the first (only) row from the
         //     Products table that has the ProductID
         //     that was selected in the ComboBox.
         //  Load the fields into the form's controls.
         //  Close the reader.
         drdrDB.Seek(DbSeekOptions.FirstEqual, intProductID);
            if( drdrDB.Read() ) 
            {
               LoadControlsFromRow(drdrDB);
            }
         drdrDB.Close();

         //  Close the connection.
         connDB.Close();
      }

   //   private void LoadOneProduct( int intProductID) 
   //   {
   //      //  Append the desired ProductID to the SELECT statement.
   //       string  strSQL = strGetOneProduct + intProductID;
   //
   //      //  A connection, a command, and a reader.
   //      SqlCeConnection  connDB = new SqlCeConnection(strConn);
   //      SqlCeCommand  cmndDB = new SqlCeCommand();
   //      SqlCeDataReader drdrDB;
   //
   //      //  Open the connection.
   //      connDB.Open();
   //
   //      //  Submit the SQL statement and receive
   //      //     the SqlCeReader for the one-row 
   //      //     results set. 
   //      drdrDB = cmndDB.ExecuteReader();
   //
   //      //  Read the first (only) row.  
   //      //     Display it.  Close the reader.
   //      if ( drdrDB.Read() ) 
   //      {
   //         LoadControlsFromRow(drdrDB);
   //      }
   //      drdrDB.Close();
   //
   //      //  Close the connection.
   //      connDB.Close();
   //   }

      private void LoadControlsFromRow(  SqlCeDataReader drdrDB) 
      {
         //  Transfer the colum titles and the field
         //     contents of the current row from the
         //     reader to the form//s controls.
         lblProductID.Text = drdrDB.GetName(0);
         textProductID.Text = drdrDB.GetValue(0).ToString();
         lblProductName.Text = drdrDB.GetName(1);
         textProductName.Text = drdrDB.GetValue(1).ToString();
         lblCategoryName.Text = drdrDB.GetName(2);
         textCategoryName.Text = drdrDB.GetValue(2).ToString();
      }

      private void UpdateSelectedRow(int intProductID,  
                                    string strProductName) 
      {
         //  A connection and a command.
         SqlCeConnection connDB = new SqlCeConnection(strConn);
         SqlCeCommand cmndDB = new SqlCeCommand();

         //  Open the connection.
         connDB.Open();

         //  Update the product name for the selected product.
         cmndDB.Connection = connDB;
         cmndDB.CommandText =
            " UPDATE Products " +
            " SET ProductName = " + "'" + strProductName + "'" +
            " WHERE ProductID = " + intProductID;
         cmndDB.ExecuteNonQuery();

         //  Close the connection.
         connDB.Close();
      }
   }
}
