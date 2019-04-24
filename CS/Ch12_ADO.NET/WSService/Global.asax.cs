//-----------------------------------------------------------------------------
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;

namespace WSService 
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public Global()
		{
			InitializeComponent();
		}

      internal System.Data.SqlClient.SqlDataAdapter daptCategories;
      internal System.Data.SqlClient.SqlCommand SqlSelectCommand1;
      internal System.Data.SqlClient.SqlConnection connNorthwind;
      internal System.Data.SqlClient.SqlCommand SqlSelectCommand2;
      internal System.Data.SqlClient.SqlDataAdapter daptProducts;	
		
      public static DataSet dsetDB;

		protected void Application_Start(Object sender, EventArgs e)
		{
         dsetDB = new DataSet();
         LoadDataSet(dsetDB);
		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_Error(Object sender, EventArgs e)
		{

		}

		protected void Session_End(Object sender, EventArgs e)
		{

		}

		protected void Application_End(Object sender, EventArgs e)
		{

		}

      private void LoadDataSet( DataSet dsetDB) 
      {
         daptCategories.Fill(dsetDB, "Categories");
         daptProducts.Fill(dsetDB, "Products");
         dsetDB.Relations.Add(
            "FKProdCAt",
            dsetDB.Tables["Categories"].Columns["CategoryID"],
            dsetDB.Tables["Products"].Columns["CategoryID"],
            true);
      }
	
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
         this.daptCategories = new System.Data.SqlClient.SqlDataAdapter();
         this.SqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
         this.connNorthwind = new System.Data.SqlClient.SqlConnection();
         this.SqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
         this.daptProducts = new System.Data.SqlClient.SqlDataAdapter();
         // 
         // daptCategories
         // 
         this.daptCategories.SelectCommand = this.SqlSelectCommand1;
         this.daptCategories.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
                                                                                                 new System.Data.Common.DataTableMapping("Table", "Categories", new System.Data.Common.DataColumnMapping[] {
                                                                                                                                                                                                              new System.Data.Common.DataColumnMapping("CategoryID", "CategoryID"),
                                                                                                                                                                                                              new System.Data.Common.DataColumnMapping("CategoryName", "CategoryName"),
                                                                                                                                                                                                              new System.Data.Common.DataColumnMapping("Description", "Description"),
                                                                                                                                                                                                              new System.Data.Common.DataColumnMapping("Picture", "Picture"),
                                                                                                                                                                                                              new System.Data.Common.DataColumnMapping("rowguid", "rowguid")})});
         // 
         // SqlSelectCommand1
         // 
         this.SqlSelectCommand1.CommandText = "SELECT CategoryID, CategoryName, Description, Picture, rowguid FROM Categories";
         this.SqlSelectCommand1.Connection = this.connNorthwind;
         // 
         // connNorthwind
         // 
         this.connNorthwind.ConnectionString = "workstation id=SNOWDEN;packet size=4096;integrated security=SSPI;data source=SNOW" +
            "DEN;persist security info=False;initial catalog=Northwind";
         // 
         // SqlSelectCommand2
         // 
         this.SqlSelectCommand2.CommandText = "SELECT ProductID, ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice" +
            ", UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued, rowguid FROM Products";
         this.SqlSelectCommand2.Connection = this.connNorthwind;
         // 
         // daptProducts
         // 
         this.daptProducts.SelectCommand = this.SqlSelectCommand2;
         this.daptProducts.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
                                                                                               new System.Data.Common.DataTableMapping("Table", "Products", new System.Data.Common.DataColumnMapping[] {
                                                                                                                                                                                                          new System.Data.Common.DataColumnMapping("ProductID", "ProductID"),
                                                                                                                                                                                                          new System.Data.Common.DataColumnMapping("ProductName", "ProductName"),
                                                                                                                                                                                                          new System.Data.Common.DataColumnMapping("SupplierID", "SupplierID"),
                                                                                                                                                                                                          new System.Data.Common.DataColumnMapping("CategoryID", "CategoryID"),
                                                                                                                                                                                                          new System.Data.Common.DataColumnMapping("QuantityPerUnit", "QuantityPerUnit"),
                                                                                                                                                                                                          new System.Data.Common.DataColumnMapping("UnitPrice", "UnitPrice"),
                                                                                                                                                                                                          new System.Data.Common.DataColumnMapping("UnitsInStock", "UnitsInStock"),
                                                                                                                                                                                                          new System.Data.Common.DataColumnMapping("UnitsOnOrder", "UnitsOnOrder"),
                                                                                                                                                                                                          new System.Data.Common.DataColumnMapping("ReorderLevel", "ReorderLevel"),
                                                                                                                                                                                                          new System.Data.Common.DataColumnMapping("Discontinued", "Discontinued"),
                                                                                                                                                                                                          new System.Data.Common.DataColumnMapping("rowguid", "rowguid")})});

      }
		#endregion
	}
}

