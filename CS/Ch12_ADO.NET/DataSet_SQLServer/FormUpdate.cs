//-----------------------------------------------------------------------------
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using YaoDurant.UtilSqlCe;

namespace CreateDatabase
{
	/// <summary>
	/// Summary description for FormUpdate.
	/// </summary>
	public class FormUpdate : System.Windows.Forms.Form
	{
      internal System.Windows.Forms.Panel panelCategory;
      internal System.Windows.Forms.ComboBox comboCategoryIDs;
      internal System.Windows.Forms.TextBox textCategoryName;
      internal System.Windows.Forms.Label lblCategoryName;
      internal System.Windows.Forms.TextBox textCategoryID;
      internal System.Windows.Forms.Label lblCategoryID;
   
		public FormUpdate()
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
         this.panelCategory = new System.Windows.Forms.Panel();
         this.comboCategoryIDs = new System.Windows.Forms.ComboBox();
         this.textCategoryName = new System.Windows.Forms.TextBox();
         this.lblCategoryName = new System.Windows.Forms.Label();
         this.textCategoryID = new System.Windows.Forms.TextBox();
         this.lblCategoryID = new System.Windows.Forms.Label();
         // 
         // panelCategory
         // 
         this.panelCategory.Controls.Add(this.comboCategoryIDs);
         this.panelCategory.Controls.Add(this.textCategoryName);
         this.panelCategory.Controls.Add(this.lblCategoryName);
         this.panelCategory.Controls.Add(this.textCategoryID);
         this.panelCategory.Controls.Add(this.lblCategoryID);
         this.panelCategory.Location = new System.Drawing.Point(0, 11);
         this.panelCategory.Size = new System.Drawing.Size(240, 248);
         // 
         // comboCategoryIDs
         // 
         this.comboCategoryIDs.Size = new System.Drawing.Size(136, 22);
         // 
         // textCategoryName
         // 
         this.textCategoryName.Location = new System.Drawing.Point(120, 144);
         this.textCategoryName.Size = new System.Drawing.Size(120, 22);
         this.textCategoryName.Text = "";
         this.textCategoryName.Validated += new System.EventHandler(this.textCategoryName_Validated);
         // 
         // lblCategoryName
         // 
         this.lblCategoryName.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
         this.lblCategoryName.Location = new System.Drawing.Point(120, 120);
         this.lblCategoryName.Size = new System.Drawing.Size(120, 20);
         // 
         // textCategoryID
         // 
         this.textCategoryID.Location = new System.Drawing.Point(120, 80);
         this.textCategoryID.Size = new System.Drawing.Size(120, 22);
         this.textCategoryID.Text = "";
         // 
         // lblCategoryID
         // 
         this.lblCategoryID.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
         this.lblCategoryID.Location = new System.Drawing.Point(120, 56);
         this.lblCategoryID.Size = new System.Drawing.Size(120, 20);
         // 
         // FormUpdate
         // 
         this.Controls.Add(this.panelCategory);
         this.Text = "FormUpdate";
         this.Closing += new System.ComponentModel.CancelEventHandler(this.FormUpdate_Closing);
         this.Load += new System.EventHandler(this.FormUpdate_Load);

      }
		#endregion


      //  Connection string.
      private string  strConn = 
         "data source=207.202.168.30;" + 
         "initial catalog=Northwind;" +
         "user id=DeliveryDriver;" + 
         "pwd=DD;" + 
         "workstation id=SNOWDEN;" + 
         "packet size=4096;" + 
         "persist security info=False;";

      //  The dataset, adapter, table. 
      private DataSet dsetDB;
      private SqlDataAdapter daptCategories;
      private DataTable dtabCategories;

      private void FormUpdate_Load(object sender, EventArgs e)
      {
         //  Present a Close box.
         this.MinimizeBox = false;

         //  Create the data set.
         dsetDB = new DataSet("Produce");

         //  Create the data adapter.
         daptCategories = new
            SqlDataAdapter("SELECT CategoryID, CategoryName " +
                             "  FROM Categories",
            strConn);

         //  Create and fill the data table,
         //     save a reference to it.
         daptCategories.Fill(dsetDB, "Categories");
         dtabCategories = dsetDB.Tables["Categories"];

         //  Initialize the command (including 
         //    creating the parameters).
         SqlCommand cmndDB = new SqlCommand();
         cmndDB.CommandText = "procModifyCategoryInfo";
         cmndDB.CommandType = CommandType.StoredProcedure;
         cmndDB.Connection = 
            daptCategories.SelectCommand.Connection;
         cmndDB.Parameters.Add(
            new SqlParameter(
            "@RETURN_VALUE", SqlDbType.Int, 4, 
            ParameterDirection.ReturnValue, false, 
            ((System.Byte)(0)), ((System.Byte)(0)), 
            "", DataRowVersion.Current, null));
         cmndDB.Parameters.Add(
            new SqlParameter(
            "@CategoryID", SqlDbType.Int, 4, "CategoryID"));
         cmndDB.Parameters.Add(
            new SqlParameter(
            "@CategoryName", SqlDbType.NVarChar, 40, "CategoryName"));

         cmndDB.Parameters["@CategoryID"].SourceVersion = 
            DataRowVersion.Original;

         daptCategories.UpdateCommand = cmndDB;

         //  Bind the ComboBox with the Category names.
         comboCategoryIDs.DataSource = dtabCategories;
         comboCategoryIDs.DisplayMember = "CategoryName";
         comboCategoryIDs.ValueMember = "CategoryID";
         comboCategoryIDs.SelectedIndex = 0;

         //  Load lables with DataTable column names.
         lblCategoryID.Text = "CategoryID";
         lblCategoryName.Text = "CategoryName";

         //  Bind the DataTable's columns to the textboxes.
         textCategoryID.DataBindings.Add
            ("Text", dtabCategories, "CategoryID");
         textCategoryName.DataBindings.Add
            ("Text", dtabCategories, "CategoryName");


         //  Give the panel some tone.
         panelCategory.BackColor = Color.Beige;

         //  Loading is finished.
         comboCategoryIDs.SelectedIndex = 0;
      }

      private void textCategoryName_Validated(object sender, 
                                              EventArgs e)
      {
         //  Force the current modification to complete.
         this.BindingContext[dtabCategories].EndCurrentEdit();
      }

      private void FormUpdate_Closing(object sender, 
                                      CancelEventArgs e)
      {
         try
         {
            //  Force the current modification to complete.
            this.BindingContext[dtabCategories].EndCurrentEdit();

            //  Push dataset changes back to database.
            daptCategories.Update(dsetDB, "Categories");
         }
         catch( SqlException exSQL )
         {
            foreach( SqlError errSQL in exSQL.Errors )
            {
               MessageBox.Show(errSQL.Message);
            }
         }
         finally
         {
         }
      }
	}
}
