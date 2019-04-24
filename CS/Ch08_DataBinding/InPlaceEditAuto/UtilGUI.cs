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

namespace YaoDurant.GUI
{
	/// <summary>
	/// Summary description for UtilGUI.
	/// </summary>
	public class UtilGUI
	{
		public UtilGUI()
		{
		}

      internal static void AddCustomDataTableStyle
                                    (  
                                       DataGrid dgridTarget,  
                                       string  strTable 
                                    ) 
      {
         DataGridTableStyle dgtsStyle;
         DataGridTextBoxColumn dgtsColumn;

         switch (strTable)
         {
            case "Projects":
               //  Define a Style for the "Projects" 
               //     DataTable or ArrayList to be used by
               //     the DataGrid when displaying projects.

               dgtsStyle = new DataGridTableStyle();
               //  Specify that it is to be applied whenever
               //     a data object named Projects is assigned
               //     to the DataGrid//s DataSource property.
               dgtsStyle.MappingName = "Projects";

               //  Add columns.
               //  Specify:
               //     Column/field name
               //     Column header
               //     Column width in pixels.

               dgtsColumn = new DataGridTextBoxColumn();
               dgtsColumn.MappingName = "strName";
               dgtsColumn.HeaderText = "Name";
               dgtsColumn.Width = 100;
               dgtsStyle.GridColumnStyles.Add(dgtsColumn);

               dgtsColumn = new DataGridTextBoxColumn();
               dgtsColumn.MappingName = "dateStart";
               dgtsColumn.HeaderText = "Start";
               dgtsColumn.Width = 50;
               dgtsStyle.GridColumnStyles.Add(dgtsColumn);

               dgtsColumn = new DataGridTextBoxColumn();
               dgtsColumn.MappingName = "dateEnd";
               dgtsColumn.HeaderText = "End";
               dgtsColumn.Width = 50;
               dgtsStyle.GridColumnStyles.Add(dgtsColumn);

               dgtsColumn = new DataGridTextBoxColumn();
               dgtsColumn.MappingName = "ctTasks";
               dgtsColumn.HeaderText = "Tasks";
               dgtsColumn.Width = 50;
               dgtsStyle.GridColumnStyles.Add(dgtsColumn);

               //  Add the style to the DataGrid.
               dgridTarget.TableStyles.Add(dgtsStyle);

               break;
            case "Tasks":
               break;
            default:
               break;
         }
      }

   }
}
