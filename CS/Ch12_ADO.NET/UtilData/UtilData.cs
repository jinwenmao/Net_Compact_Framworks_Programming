//-----------------------------------------------------------------------------
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.IO;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace YaoDurant.UtilSqlCe
{
   public class UtilData {
      private static string strGetTableNames =
         "SELECT TABLE_NAME" +
         "  FROM Information_Schema.TABLES" +
         " WHERE TABLE_TYPE = 'TABLE'";

      private static string strGetTableRows =
         "SELECT * FROM ";

      private static string strGetRelationships =
         "SELECT C.CONSTRAINT_NAME" +
         "     , C.REFERENCED_TABLE_NAME" +
         "     , C.REFERENCED_COLUMN_NAME" +
         "     , C.TABLE_NAME" +
         "     , C.CONSTRAINT_COLUMN_NAME" +
         "  FROM MSysConstraints C" +
         "  WHERE C.CONSTRAINT_TYPE = 1";

      public UtilData()
      {
      }
      
      public static DataSet BuildDataSet( string  strDB ) 
      {
         DataSet dsetWork;

         string  strConn = "Data Source=" + strDB;
         SqlConnection connDB;
         connDB = new SqlConnection(strConn);
         connDB.Open();

         dsetWork = new DataSet("ourProduceCo");

         SqlDataReader drdrTableNames;
         drdrTableNames = GetTableNames(connDB);
         while ( drdrTableNames.Read() )
         {
            LoadTable(dsetWork, 
                     connDB, 
                     drdrTableNames.GetString(0));
         }
         drdrTableNames.Close();

         LoadRelationships(dsetWork, connDB);

         connDB.Close();

         return dsetWork;
      }


      // *****************************************************//
      //
      //     GENERIC ROUTINES
      //

      public static SqlDataReader GetTableNames 
                                      ( SqlConnection connDB )
      {
            SqlCommand  cmndDB = 
               new SqlCommand(strGetTableNames, connDB);
            return cmndDB.ExecuteReader();
      }

      public static void LoadTable (DataSet dsetDB,  
                                    SqlConnection connDB,  
                                    string  strTable) 
      {
         SqlCommand cmndDB = 
            new SqlCommand(strGetTableRows + strTable, connDB);
         SqlDataAdapter daptProducts = 
            new SqlDataAdapter(cmndDB);
         daptProducts.Fill(dsetDB, strTable);
      }

      public static SqlDataReader GetRelationships 
                                       ( SqlConnection connDB ) 
      {
         SqlCommand cmndDB = 
            new SqlCommand(strGetRelationships, connDB);
         return cmndDB.ExecuteReader();
      }

      public static void LoadRelationships( 
                                       DataSet dsetDB,  
                                       SqlConnection connDB) 
      {
         //  Retrieve foreign key information from the
         //     database.  for ( each foreign key, create
         //     a relationship in the DataSet.

         //  Create GetRelationships command object
         SqlCommand cmndDB = 
            new SqlCommand(strGetRelationships, connDB);

         //  Execute GetRelationships
         SqlDataReader drdrRelationships;
         drdrRelationships = cmndDB.ExecuteReader();
         string  strRelation;
         DataColumn dcolParent, dcolChild;

         while ( drdrRelationships.Read() )
         {
            //  for each foreign key in the database 

            //  Extract and convert name, parent, child info.
            strRelation = 
               drdrRelationships.GetString(0);
            dcolParent = 
               dsetDB.Tables[drdrRelationships.GetString(1)]
                     .Columns[drdrRelationships.GetString(2)];
            dcolChild = 
               dsetDB.Tables[drdrRelationships.GetString(3)]
                     .Columns[drdrRelationships.GetString(4)];

            //  Add relation to DataSet.
            dsetDB.Relations.Add
                          (strRelation, dcolParent, dcolChild);
         }
         drdrRelationships.Close();

         //  Make each relationship a nested relationship
         foreach( DataRelation drelForXML in dsetDB.Relations )
         {
            drelForXML.Nested = true;
         }
      }

      public static DataTable ConvertArrayToTable
                                          ( DataRow[] arrRows ) 
      {
         //  Create and empty table to hold these rows by
         //     cloning the structure of the table that
         //     these rows came from.
         DataTable dtabWork = arrRows[0].Table.Clone();

         //  Add the rows to the table.
         foreach( DataRow drowWork in arrRows )
         {
            dtabWork.ImportRow(drowWork);
         } 

         //  return the table.
         return dtabWork;
      }

      public static SqlDataReader RetrieveDataReader 
                                       ( SqlConnection connDB,
                                         string  strSelect )
      {
         SqlCommand cmndDb = 
            new SqlCommand(strSelect, connDB);
         SqlDataReader drdrWork;
         drdrWork = cmndDb.ExecuteReader();
         return drdrWork;
      }

      public static DataTable RetrieveDataTable 
                                       ( SqlConnection connDB,  
                                         string  strSelect )
      {
         SqlDataAdapter daptProducts = 
            new SqlDataAdapter(strSelect, connDB);
         DataTable dtabWork = new DataTable();
         daptProducts.Fill(dtabWork);
         return dtabWork;
      }

      private void CreateTable() 
      {
         //  Create empty table.
         DataTable  dtabCustomers = new DataTable("Customers");

         //  Create three columns.
         DataColumn  dcolID = new DataColumn("ID");
         dcolID.DataType = typeof(int);
         dcolID.AutoIncrement = true;

         DataColumn  dcolName = new DataColumn("Name");
         dcolName.DataType = typeof(string );

         DataColumn  dcolAddress = new DataColumn("Address");
         dcolAddress.DataType = typeof(string );

         //  Add columns to table.
         dtabCustomers.Columns.Add(dcolID);
         dtabCustomers.Columns.Add(dcolName);
         dtabCustomers.Columns.Add(dcolAddress);

         //  Add a primary key constraint.
         dtabCustomers.Constraints.Add("PKCust", dcolID, true);

         //  Add two rows to the table
         DataRow drowCust;
         drowCust = dtabCustomers.NewRow();
         drowCust["ID"] = 1;
         drowCust["Name"] = "Amalgamated United";
         drowCust["Address"] = "PO Box 123, 98765";
         dtabCustomers.Rows.Add(drowCust);
         drowCust = dtabCustomers.NewRow();
         drowCust["ID"] = 2;
         drowCust["Name"] = "United Amalgamated";
         drowCust["Address"] = "PO Box 987, 12345";
         dtabCustomers.Rows.Add(drowCust);
      } 

   }
}
