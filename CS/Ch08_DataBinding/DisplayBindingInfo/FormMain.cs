//-----------------------------------------------------------------------------
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using YaoDurant.Data; 
using YaoDurant.GUI;

namespace DisplayBindingInfo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FormMain : System.Windows.Forms.Form
	{
      internal System.Windows.Forms.Panel panelChoice;
      internal System.Windows.Forms.RadioButton optMouseOver;
      internal System.Windows.Forms.RadioButton optCellSelection;
      internal System.Windows.Forms.Panel panelBindingData;
      internal System.Windows.Forms.Label lblDatumDataType;
      internal System.Windows.Forms.Label lblHdrDataType;
      internal System.Windows.Forms.Label lblDatumKey;
      internal System.Windows.Forms.Label lblHdrKey;
      internal System.Windows.Forms.Label lblDatumValue;
      internal System.Windows.Forms.Label lblHdrValue;
      internal System.Windows.Forms.Label lblDatumName;
      internal System.Windows.Forms.Label lblHdrName;
      internal System.Windows.Forms.Label lblDatumColumn;
      internal System.Windows.Forms.Label lblHdrColumn;
      internal System.Windows.Forms.Label lblDatumRow;
      internal System.Windows.Forms.Label lblHdrRow;
      internal System.Windows.Forms.Label lblDatumType;
      internal System.Windows.Forms.Label lblHdrType;
      internal System.Windows.Forms.Label lblDatumEvent;
      private System.Windows.Forms.DataGrid dgridProjects;
		private System.Windows.Forms.MainMenu mainMenu1;

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
         this.mainMenu1 = new System.Windows.Forms.MainMenu();
         this.panelChoice = new System.Windows.Forms.Panel();
         this.optMouseOver = new System.Windows.Forms.RadioButton();
         this.optCellSelection = new System.Windows.Forms.RadioButton();
         this.panelBindingData = new System.Windows.Forms.Panel();
         this.lblDatumDataType = new System.Windows.Forms.Label();
         this.lblHdrDataType = new System.Windows.Forms.Label();
         this.lblDatumKey = new System.Windows.Forms.Label();
         this.lblHdrKey = new System.Windows.Forms.Label();
         this.lblDatumValue = new System.Windows.Forms.Label();
         this.lblHdrValue = new System.Windows.Forms.Label();
         this.lblDatumName = new System.Windows.Forms.Label();
         this.lblHdrName = new System.Windows.Forms.Label();
         this.lblDatumColumn = new System.Windows.Forms.Label();
         this.lblHdrColumn = new System.Windows.Forms.Label();
         this.lblDatumRow = new System.Windows.Forms.Label();
         this.lblHdrRow = new System.Windows.Forms.Label();
         this.lblDatumType = new System.Windows.Forms.Label();
         this.lblHdrType = new System.Windows.Forms.Label();
         this.lblDatumEvent = new System.Windows.Forms.Label();
         this.dgridProjects = new System.Windows.Forms.DataGrid();
         // 
         // panelChoice
         // 
         this.panelChoice.Controls.Add(this.optMouseOver);
         this.panelChoice.Controls.Add(this.optCellSelection);
         this.panelChoice.Size = new System.Drawing.Size(240, 24);
         // 
         // optMouseOver
         // 
         this.optMouseOver.Location = new System.Drawing.Point(136, 0);
         this.optMouseOver.Text = "MouseOver";
         this.optMouseOver.CheckedChanged += new System.EventHandler(this.optAny_CheckedChanged);
         // 
         // optCellSelection
         // 
         this.optCellSelection.Text = "Cell Selection";
         this.optCellSelection.CheckedChanged += new System.EventHandler(this.optAny_CheckedChanged);
         // 
         // panelBindingData
         // 
         this.panelBindingData.Controls.Add(this.lblDatumDataType);
         this.panelBindingData.Controls.Add(this.lblHdrDataType);
         this.panelBindingData.Controls.Add(this.lblDatumKey);
         this.panelBindingData.Controls.Add(this.lblHdrKey);
         this.panelBindingData.Controls.Add(this.lblDatumValue);
         this.panelBindingData.Controls.Add(this.lblHdrValue);
         this.panelBindingData.Controls.Add(this.lblDatumName);
         this.panelBindingData.Controls.Add(this.lblHdrName);
         this.panelBindingData.Controls.Add(this.lblDatumColumn);
         this.panelBindingData.Controls.Add(this.lblHdrColumn);
         this.panelBindingData.Controls.Add(this.lblDatumRow);
         this.panelBindingData.Controls.Add(this.lblHdrRow);
         this.panelBindingData.Controls.Add(this.lblDatumType);
         this.panelBindingData.Controls.Add(this.lblHdrType);
         this.panelBindingData.Controls.Add(this.lblDatumEvent);
         this.panelBindingData.Location = new System.Drawing.Point(0, 32);
         this.panelBindingData.Size = new System.Drawing.Size(240, 104);
         // 
         // lblDatumDataType
         // 
         this.lblDatumDataType.ForeColor = System.Drawing.Color.Blue;
         this.lblDatumDataType.Location = new System.Drawing.Point(72, 56);
         this.lblDatumDataType.Size = new System.Drawing.Size(160, 16);
         // 
         // lblHdrDataType
         // 
         this.lblHdrDataType.Location = new System.Drawing.Point(0, 56);
         this.lblHdrDataType.Size = new System.Drawing.Size(64, 16);
         this.lblHdrDataType.Text = "Data Type";
         this.lblHdrDataType.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // lblDatumKey
         // 
         this.lblDatumKey.ForeColor = System.Drawing.Color.Blue;
         this.lblDatumKey.Location = new System.Drawing.Point(72, 88);
         this.lblDatumKey.Size = new System.Drawing.Size(160, 16);
         // 
         // lblHdrKey
         // 
         this.lblHdrKey.Location = new System.Drawing.Point(24, 88);
         this.lblHdrKey.Size = new System.Drawing.Size(40, 16);
         this.lblHdrKey.Text = "Key";
         this.lblHdrKey.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // lblDatumValue
         // 
         this.lblDatumValue.ForeColor = System.Drawing.Color.Blue;
         this.lblDatumValue.Location = new System.Drawing.Point(72, 72);
         this.lblDatumValue.Size = new System.Drawing.Size(160, 16);
         // 
         // lblHdrValue
         // 
         this.lblHdrValue.Location = new System.Drawing.Point(24, 72);
         this.lblHdrValue.Size = new System.Drawing.Size(40, 16);
         this.lblHdrValue.Text = "Value";
         this.lblHdrValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // lblDatumName
         // 
         this.lblDatumName.ForeColor = System.Drawing.Color.Blue;
         this.lblDatumName.Location = new System.Drawing.Point(72, 40);
         this.lblDatumName.Size = new System.Drawing.Size(160, 16);
         // 
         // lblHdrName
         // 
         this.lblHdrName.Location = new System.Drawing.Point(24, 40);
         this.lblHdrName.Size = new System.Drawing.Size(40, 18);
         this.lblHdrName.Text = "Name";
         this.lblHdrName.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // lblDatumColumn
         // 
         this.lblDatumColumn.ForeColor = System.Drawing.Color.Blue;
         this.lblDatumColumn.Location = new System.Drawing.Point(208, 24);
         this.lblDatumColumn.Size = new System.Drawing.Size(32, 16);
         // 
         // lblHdrColumn
         // 
         this.lblHdrColumn.Location = new System.Drawing.Point(168, 24);
         this.lblHdrColumn.Size = new System.Drawing.Size(32, 16);
         this.lblHdrColumn.Text = "Col";
         this.lblHdrColumn.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // lblDatumRow
         // 
         this.lblDatumRow.ForeColor = System.Drawing.Color.Blue;
         this.lblDatumRow.Location = new System.Drawing.Point(128, 24);
         this.lblDatumRow.Size = new System.Drawing.Size(32, 16);
         // 
         // lblHdrRow
         // 
         this.lblHdrRow.Location = new System.Drawing.Point(88, 24);
         this.lblHdrRow.Size = new System.Drawing.Size(32, 16);
         this.lblHdrRow.Text = "Row";
         this.lblHdrRow.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // lblDatumType
         // 
         this.lblDatumType.ForeColor = System.Drawing.Color.Blue;
         this.lblDatumType.Location = new System.Drawing.Point(48, 24);
         this.lblDatumType.Size = new System.Drawing.Size(32, 16);
         // 
         // lblHdrType
         // 
         this.lblHdrType.Location = new System.Drawing.Point(8, 24);
         this.lblHdrType.Size = new System.Drawing.Size(32, 16);
         this.lblHdrType.Text = "Type";
         this.lblHdrType.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // lblDatumEvent
         // 
         this.lblDatumEvent.Size = new System.Drawing.Size(168, 20);
         // 
         // dgridProjects
         // 
         this.dgridProjects.Location = new System.Drawing.Point(0, 152);
         this.dgridProjects.Size = new System.Drawing.Size(240, 96);
         this.dgridProjects.CurrentCellChanged += new System.EventHandler(this.dgridProjects_CurrentCellChanged);
         this.dgridProjects.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgridProjects_MouseMove);
         // 
         // FormMain
         // 
         this.Controls.Add(this.dgridProjects);
         this.Controls.Add(this.panelChoice);
         this.Controls.Add(this.panelBindingData);
         this.Menu = this.mainMenu1;
         this.Text = "Binding Info";
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

      private void FormMain_Load(object sender, EventArgs e)
      {
         YaoDurant.Data.UtilData utilData = new UtilData();
         YaoDurant.GUI.UtilGUI utilGUI = new UtilGUI();

         //  Make the Project table the DataSource.
         //  Make the strIdent field of the currently
         //     select row the Text property of the DataGrid
         //     control.
         dgridProjects.DataSource = utilData.GetProjectsDT();
         dgridProjects.DataBindings.Clear();
         dgridProjects.DataBindings.Add(
                              "Text", 
                              dgridProjects.DataSource, 
                              "strIdent");

         //  Use a utility routine to style the 
         //     layout of Projects in the DataGrid.
         UtilGUI.AddCustomDataTableStyle(dgridProjects, 
                                         "Projects");
      }

      private void dgridProjects_MouseMove(object sender, 
                                           MouseEventArgs e)
      {
         //  if the user is not interested in
         //      this event, do not handle it.
         if (! optMouseOver.Checked ) 
         {
            return;
         }

         //  Tell the user what information they are seeing.
         lblDatumEvent.Text = "Cell Under Mouse";

         //  Store the DataGrid object for early binding.
         DataGrid dgridSender = (DataGrid)sender;

         //  Store the DataGrid's DataSource object
         DataTable dtabDataSource = 
            (DataTable)dgridSender.DataSource;

         //  Use the DataSource name to retrieve
         //      and store the current TableStyle.
         DataGridTableStyle dgtsCurrent = 
            dgridSender.TableStyles[dtabDataSource.TableName];

         //  Use the DataGrid's HitTest method to get the 
         //     HitTest object for this Click.
         DataGrid.HitTestInfo httstInfo;
         httstInfo = dgridSender.HitTest(e.X, e.Y);

         //  Clear the labels that are meaningful only
         //     if the mouse is over a data cell.
         lblDatumName.Text = string.Empty;
         lblDatumValue.Text = string.Empty;
         lblDatumDataType.Text = string.Empty;

         //  Display HitTest properties in the labels
         lblDatumType.Text = httstInfo.Type.ToString();
         lblDatumRow.Text = httstInfo.Row.ToString();
         lblDatumColumn.Text = httstInfo.Column.ToString();

         //  if the mouse is positioned over a data column...
         if (httstInfo.Column != -1 ) 
         {
            //  Obtain the DataSource's column name from
            //     the ColumnStyles collection of the
            //     current TableStyle.
            string  strColumnName = 
               dgtsCurrent.GridColumnStyles[httstInfo.Column].
                  MappingName;
            lblDatumName.Text = strColumnName;

            //  Obtain the DataSource's column's data type.
            lblDatumDataType.Text = 
               dtabDataSource.Rows[0][strColumnName].
                  GetType().ToString();

            //  if ( the mouse is positioned over a data cell...
            if (httstInfo.Row != -1 ) 
            {
               //           ETHER

               //  Obtain and display the cell value from
               //     the underlying data source object.
               lblDatumValue.Text = 
                  dtabDataSource.Rows[httstInfo.Row]
                                     [strColumnName].ToString();

               //              OR

               //  Obtain and display the cell value from
               //     the DataGrid itself.
               lblDatumValue.Text = 
                  dgridSender[httstInfo.Row, 
                              httstInfo.Column].ToString();
            }
         }
      }

      private void dgridProjects_CurrentCellChanged(
                                             object sender, 
                                             EventArgs e)
      {
         //  if the user is not interested in
         //      this event, do not handle it.
         if (! optCellSelection.Checked ) 
         {
            return;
         }

         //  Tell the user what information they are seeing.
         lblDatumEvent.Text = "Current Cell";

         //  Store the DataGrid object for early binding.
         DataGrid dgridSender = (DataGrid)sender;

         //  Store the DataGrid's DataSource object
         DataTable dtabDataSource = 
            (DataTable)dgridSender.DataSource;

         //  Use the DataSource name to retrieve
         //      and store the current TableStyle.
         DataGridTableStyle dgtsCurrent = 
            dgridSender.TableStyles[dtabDataSource.TableName];

         DataGridCell cellCurr = dgridSender.CurrentCell;

         //  Display CurrentCell properties in the labels
         lblDatumType.Text = "1";
         lblDatumRow.Text = cellCurr.RowNumber.ToString();
         lblDatumColumn.Text = cellCurr.ColumnNumber.ToString();

         //  Obtain the DataSource's column name from
         //     the ColumnStyles collection of the
         //     current TableStyle.
         string  strColumnName = 
            dgtsCurrent.GridColumnStyles[cellCurr.ColumnNumber].
               MappingName;
         lblDatumName.Text = strColumnName;

         //  Obtain the DataSource's column's data type.
         lblDatumDataType.Text = 
            dtabDataSource.Rows[0][strColumnName].
               GetType().ToString();

         //           ETHER

         //  Obtain and display the cell value from
         //     the underlying data source object.
         lblDatumValue.Text = 
            dtabDataSource.Rows[cellCurr.RowNumber]
                               [strColumnName].ToString();

         //              OR

         //  Obtain and display the cell value from
         //     the DataGrid itself.
         lblDatumValue.Text = 
            dgridSender[cellCurr.RowNumber,
                        cellCurr.ColumnNumber].ToString();

         //  Display the primary key of the row; based on
         //     the DataBindings entry that was added 
         //     during the Load event.
         lblDatumKey.Text = dgridSender.Text;
      }

      private void optAny_CheckedChanged(object sender, 
                                         EventArgs e)
      {
         //  Clear the Labels
         this.lblDatumEvent.Text = string.Empty;
         this.lblDatumType.Text = string.Empty;
         this.lblDatumRow.Text = string.Empty;
         this.lblDatumColumn.Text = string.Empty;
         this.lblDatumName.Text = string.Empty;
         this.lblDatumValue.Text = string.Empty;
         this.lblDatumKey.Text = string.Empty;
         this.lblDatumDataType.Text = string.Empty;
         this.lblHdrKey.Visible = optCellSelection.Checked;
      }
   }
}
