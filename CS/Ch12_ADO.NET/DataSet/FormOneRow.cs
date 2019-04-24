//-----------------------------------------------------------------------------
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CreateDatabase
{
	/// <summary>
	/// Summary description for FormOneRow.
	/// </summary>
	public class FormOneRow : System.Windows.Forms.Form
	{
      internal System.Windows.Forms.Panel panelProduct;
      internal System.Windows.Forms.Button cmdGet;
      internal System.Windows.Forms.TextBox textGet;
      internal System.Windows.Forms.ComboBox comboProductIDs;
      internal System.Windows.Forms.HScrollBar hsbRows;
      internal System.Windows.Forms.TextBox textCategoryName;
      internal System.Windows.Forms.Label lblCategoryName;
      internal System.Windows.Forms.TextBox textProductName;
      internal System.Windows.Forms.Label lblProductName;
      internal System.Windows.Forms.TextBox textProductID;
      internal System.Windows.Forms.Label lblProductID;
   
		public FormOneRow()
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
         this.panelProduct = new System.Windows.Forms.Panel();
         this.cmdGet = new System.Windows.Forms.Button();
         this.textGet = new System.Windows.Forms.TextBox();
         this.comboProductIDs = new System.Windows.Forms.ComboBox();
         this.hsbRows = new System.Windows.Forms.HScrollBar();
         this.textCategoryName = new System.Windows.Forms.TextBox();
         this.lblCategoryName = new System.Windows.Forms.Label();
         this.textProductName = new System.Windows.Forms.TextBox();
         this.lblProductName = new System.Windows.Forms.Label();
         this.textProductID = new System.Windows.Forms.TextBox();
         this.lblProductID = new System.Windows.Forms.Label();
         // 
         // panelProduct
         // 
         this.panelProduct.Controls.Add(this.cmdGet);
         this.panelProduct.Controls.Add(this.textGet);
         this.panelProduct.Controls.Add(this.comboProductIDs);
         this.panelProduct.Controls.Add(this.hsbRows);
         this.panelProduct.Controls.Add(this.textCategoryName);
         this.panelProduct.Controls.Add(this.lblCategoryName);
         this.panelProduct.Controls.Add(this.textProductName);
         this.panelProduct.Controls.Add(this.lblProductName);
         this.panelProduct.Controls.Add(this.textProductID);
         this.panelProduct.Controls.Add(this.lblProductID);
         this.panelProduct.Location = new System.Drawing.Point(0, 11);
         this.panelProduct.Size = new System.Drawing.Size(240, 248);
         // 
         // cmdGet
         // 
         this.cmdGet.Location = new System.Drawing.Point(200, 0);
         this.cmdGet.Size = new System.Drawing.Size(40, 20);
         this.cmdGet.Text = "Get";
         this.cmdGet.Click += new System.EventHandler(this.cmdGet_Click);
         // 
         // textGet
         // 
         this.textGet.Location = new System.Drawing.Point(160, 0);
         this.textGet.Size = new System.Drawing.Size(40, 22);
         this.textGet.Text = "";
         // 
         // comboProductIDs
         // 
         this.comboProductIDs.Size = new System.Drawing.Size(136, 22);
         this.comboProductIDs.SelectedIndexChanged += new System.EventHandler(this.comboProductIDs_SelectedIndexChanged);
         // 
         // hsbRows
         // 
         this.hsbRows.Location = new System.Drawing.Point(0, 232);
         this.hsbRows.Maximum = 91;
         this.hsbRows.Size = new System.Drawing.Size(240, 13);
         this.hsbRows.ValueChanged += new System.EventHandler(this.hsbRows_ValueChanged);
         // 
         // textCategoryName
         // 
         this.textCategoryName.Location = new System.Drawing.Point(120, 208);
         this.textCategoryName.Size = new System.Drawing.Size(120, 22);
         this.textCategoryName.Text = "";
         // 
         // lblCategoryName
         // 
         this.lblCategoryName.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
         this.lblCategoryName.Location = new System.Drawing.Point(120, 184);
         this.lblCategoryName.Size = new System.Drawing.Size(120, 20);
         // 
         // textProductName
         // 
         this.textProductName.Location = new System.Drawing.Point(120, 144);
         this.textProductName.Size = new System.Drawing.Size(120, 22);
         this.textProductName.Text = "";
         // 
         // lblProductName
         // 
         this.lblProductName.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
         this.lblProductName.Location = new System.Drawing.Point(120, 120);
         this.lblProductName.Size = new System.Drawing.Size(120, 20);
         // 
         // textProductID
         // 
         this.textProductID.Location = new System.Drawing.Point(120, 80);
         this.textProductID.Size = new System.Drawing.Size(120, 22);
         this.textProductID.Text = "";
         // 
         // lblProductID
         // 
         this.lblProductID.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
         this.lblProductID.Location = new System.Drawing.Point(120, 56);
         this.lblProductID.Size = new System.Drawing.Size(120, 20);
         // 
         // FormOneRow
         // 
         this.Controls.Add(this.panelProduct);
         this.Text = "FormOneRow";
         this.Load += new System.EventHandler(this.FormOneRow_Load);

      }
		#endregion


      private DataSet dsetDB;
      private SqlCeDataAdapter daptProducts;

      private DataTable dtabProducts;

      //  The Products table contains four columns.  Since we often
      //     need to use the column name, and since that name might
      //     change in later versions of our app, we store the
      //     column names by their symbolic meaning.  
      //  Now, as long as we do NOT resequence the columns.....
      private string strPKName;      //  "ProductID";
      private string strPKDesc;      //  "ProductName";
      private string strFKName;      //  "CategoryID";
      private string strFKDesc;      //  "CategoryName";

      private bool boolLoading = true;

      private void FormOneRow_Load(object sender, System.EventArgs e)
      {
         //  Present a Close box.
         this.MinimizeBox = false;

         //  FormGrids stored a reference to the dataset
         //     in the code module.  Use it to get a 
         //     reference to the Products DataTable.
         this.dsetDB = ModData.dsetDB;
         this.daptProducts = ModData.daptProducts;
         dtabProducts = dsetDB.Tables["Products"];

         strPKName = dtabProducts.Columns[0].ColumnName;
         strPKDesc = dtabProducts.Columns[1].ColumnName;
         strFKName = dtabProducts.Columns[2].ColumnName;
         strFKDesc = dtabProducts.Columns[3].ColumnName;

         //  Initialize scroll bar properties.
         hsbRows.Minimum = 0;
         hsbRows.Maximum = dtabProducts.Rows.Count;
         hsbRows.SmallChange = 1;
         hsbRows.LargeChange = 
            ((hsbRows.Maximum - hsbRows.Minimum) / 10) + 1;

         //  Bind the ComboBox with the Product names.
         comboProductIDs.DataSource = dtabProducts;
         comboProductIDs.DisplayMember = strPKDesc;
         comboProductIDs.ValueMember = strPKName;
         comboProductIDs.SelectedIndex = 0;

         //  Load lables with DataTable column names.
         lblProductID.Text = strPKName;
         lblProductName.Text = strPKDesc;
         lblCategoryName.Text = strFKDesc;

         //  Bind the DataTable's columns to the textboxes.
         textProductID.DataBindings.Add
            ("Text", dtabProducts, strPKName);
         textProductName.DataBindings.Add
            ("Text", dtabProducts, strPKDesc);
         textCategoryName.DataBindings.Add
            ("Text", dtabProducts, strFKDesc);

         //  Give the panel some tone.
         panelProduct.BackColor = Color.Beige;

         //  Loading is finished.
         boolLoading = false;
         comboProductIDs.SelectedIndex = 0;
      }

      private void hsbRows_ValueChanged(object sender, 
                                        EventArgs e)
      {
         //  Get the binding context for the data table.
         //     Set the "current" row to the one indicated
         //     by the position of the scroll bar thumb.
         this.BindingContext[dtabProducts].Position = 
            hsbRows.Value;
      }

      private void comboProductIDs_SelectedIndexChanged(
                                             object sender, 
                                             EventArgs e)
      {
         if( ! boolLoading )
         {
            hsbRows.Value = comboProductIDs.SelectedIndex;
            textGet.Text = 
               comboProductIDs.SelectedValue.ToString();
         }
      }

      private void cmdGet_Click(object sender, EventArgs e)
      {
         comboProductIDs.SelectedValue = textGet.Text;
      }
	}
}
