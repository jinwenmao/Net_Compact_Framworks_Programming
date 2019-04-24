//-----------------------------------------------------------------------------
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Collections;
using System.Data;

namespace YaoDurant.Data
{
	/// <summary>
	/// Summary description for UtilData.
	/// </summary>
	public class UtilData
	{
      #region Database Structure Simulated
      public struct Project
      {
         private string  m_strIdent;
         private string  m_strName;
         private DateTime m_dateStart;
         private DateTime m_dateEnd;
         private int m_ctTasks;
         private string  m_strComments;

         public string  strIdent  
         {
            get 
            {
               return m_strIdent;
            }
            set 
            {
               m_strIdent = value;
            }
         }
         public string  strName  
         {
            get 
            {
               return m_strName;
            }
            set 
            {
               m_strName = value;
            }
         }
         public DateTime dateStart  
         {
            get 
            {
               return m_dateStart;
            }
            set 
            {
               m_dateStart = value;
            }
         }
         public DateTime dateEnd  
         {
            get 
            {
               return m_dateEnd;
            }
            set 
            {
               m_dateEnd = value;
            }
         }
         public int ctTasks  
         {
            get 
            {
               return m_ctTasks;
            }
            set 
            {
               m_ctTasks = value;
            }
         }
         public string  strComments  
         {
            get 
            {
               return m_strComments;
            }
            set 
            {
               m_strComments = value;
            }
         }
         public Project( string strIdent, string strName,  
                         DateTime dateStart, DateTime dateEnd,
                         int ctTasks, string strComments) 
         {
            this.m_strIdent = strIdent;
            this.m_strName = strName;
            this.m_dateStart = dateStart;
            this.m_dateEnd = dateEnd;
            this.m_ctTasks = ctTasks;
            this.m_strComments = strComments;
         }
      }

      public struct Task
      {
         private string  m_strIdent;
         private string  m_strProjIdent;
         private string  m_strName;
         private DateTime m_dateStart;
         private DateTime m_dateEnd;
         private int m_durEstimated;  
         private int m_durActual;  
         private string  m_strComments;

         public string  strIdent  
         {
            get 
            {
               return m_strIdent;
            }
            set 
            {
               m_strIdent = value;
            }
         }
         public string  strProjIdent  
         {
            get 
            {
               return m_strProjIdent;
            }
            set 
            {
               m_strProjIdent = value;
            }
         }
         public string  strName  
         {
            get 
            {
               return m_strName;
            }
            set 
            {
               m_strName = value;
            }
         }
         public DateTime dateStart  
         {
            get 
            {
               return m_dateStart;
            }
            set 
            {
               m_dateStart = value;
            }
         }
         public DateTime dateEnd  
         {
            get 
            {
               return m_dateEnd;
            }
            set 
            {
               m_dateEnd = value;
            }
         }
         public int durEstimated  
         {
            get 
            {
               return m_durEstimated;
            }
            set 
            {
               m_durEstimated = value;
            }
         }
         public int durActual  
         {
            get 
            {
               return m_durActual;
            }
            set 
            {
               m_durActual = value;
            }
         }
         public string  strComments  
         {
            get 
            {
               return m_strComments;
            }
            set 
            {
               m_strComments = value;
            }
         }

         public Task( string  strIdent,  
                      string  strProjIdent,  
                      string  strName,  
                      DateTime dateStart,  DateTime dateEnd,  
                      int durEstimated,  int durActual,  
                      string  strComments) 
         {
            this.m_strIdent = strIdent;
            this.m_strProjIdent = strProjIdent;
            this.m_strName = strName;
            this.m_dateStart = dateStart;
            this.m_dateEnd = dateEnd;
            this.m_durEstimated = durEstimated;
            this.m_durActual = durActual;
            this.m_strComments = strComments;
         }
     }
     #endregion
      
      //  All objects listed here will be loaded with
      //     data whenever an instance of this class
      //     is created.

      //  The projects, stored in an ArrayList
      private ArrayList alProjects;
      //  The tasks, stored in an ArrayList
      private ArrayList alTasks;

      //  The projects, stored in a DataTable
      private DataTable dtblProjects;
      //  The tasks, stored in a DataTable
      private DataTable dtblTasks;
      //  A DataSet to hold the two DataTables.
      private DataSet dsetTimeTracker;

      public UtilData()
		{
         LoadData();
		}

      internal DataSet GetProjectsDataSet() 
      {
         return dsetTimeTracker;
      }

      internal Project GetProject(string strIdent)
      {
         // Just for this sample, return Project 17.
         return (Project)alProjects[1];
      }

      internal ArrayList GetTasks(string strProjIdent)
      {
         // Just for this sample, return the Tasks ofProject 17.
         return alTasks;
      }

      #region Database Read Simulation
      private void LoadData()
      {
         //  Simulate having retrieved project data
         //     from a database.  Here, we'll use our
         //     Project and Task data structures to
         //     hold the data.

         alProjects = new ArrayList();
         alProjects.Add(new Project(
            "1", 
            "Build Ark", 
            DateTime.Today.AddDays(-17), 
            DateTime.Today.AddDays(22), 
            5, 
            "Must be done in less than 40 days."));
         alProjects.Add(new Project(
            "17", 
            "Develop CF Application", 
            DateTime.Today.AddDays(-17), 
            DateTime.Today.AddDays(22), 
            5, 
            "To ensure success, read the Yao-Durant book."));
         alProjects.Add(new Project(
            "9", 
            "Write CF Book", 
            DateTime.Today.AddDays(-17), 
            DateTime.Today.AddDays(22), 
            5, 
            "The endless cycle: Code, test, write, revise."));

         alTasks = new ArrayList();
         foreach( Project projWork in alProjects )
         {
            // Just for this sample, use only Tasks ofProject 17.
            if( projWork.strIdent == "17" )
            {
               alTasks.Add(new Task("0", projWork.strIdent,
                  "Create Blueprints", 
                  DateTime.Today.AddDays(-17), 
                  DateTime.Today.AddDays(22), 
                  120, 60, ""));
               alTasks.Add(new Task("1",  projWork.strIdent,
                  "Build Franistans", 
                  DateTime.Today.AddDays(-11), 
                  DateTime.Today.AddDays(0), 
                  35, 30, ""));
               alTasks.Add(new Task("2",  projWork.strIdent,
                  "Build Widgets", 
                  DateTime.Today.AddDays(-4), 
                  DateTime.Today.AddDays(44), 
                  400, 45, ""));
               alTasks.Add(new Task("3",  projWork.strIdent,
                  "Assemble Woobletogles", 
                  DateTime.Today.AddDays(-19), 
                  DateTime.Today.AddDays(2), 
                  20, 20, ""));
               alTasks.Add(new Task("4",  projWork.strIdent,
                  "Weld Mainwareing", 
                  DateTime.Today.AddDays(-100), 
                  DateTime.Today.AddDays(50), 
                  20, 6, ""));
            }
         }

         dsetTimeTracker = new DataSet("TimeTracker");
         DataColumn dcolWork;

         dtblProjects = new DataTable("Projects");

         dcolWork = new DataColumn("strIdent", typeof(string ));
         dtblProjects.Columns.Add(dcolWork);
         dcolWork = new DataColumn("strName", typeof(string ));
         dtblProjects.Columns.Add(dcolWork);
         dcolWork = 
            new DataColumn("dateStart", typeof(DateTime));
         dtblProjects.Columns.Add(dcolWork);
         dcolWork = new DataColumn("dateEnd", typeof(DateTime));
         dtblProjects.Columns.Add(dcolWork);
         dcolWork = new DataColumn("ctTasks", typeof(int));
         dtblProjects.Columns.Add(dcolWork);
         dcolWork = 
            new DataColumn("strComments", typeof(string ));
         dtblProjects.Columns.Add(dcolWork);

         dtblTasks = new DataTable("Tasks");

         dcolWork = new DataColumn("strIdent", typeof(string ));
         dtblTasks.Columns.Add(dcolWork);
         dcolWork = 
            new DataColumn("strProjIdent", typeof(string ));
         dtblTasks.Columns.Add(dcolWork);
         dcolWork = new DataColumn("strName", typeof(string ));
         dtblTasks.Columns.Add(dcolWork);
         dcolWork = 
            new DataColumn("dateStart", typeof(DateTime));
         dtblTasks.Columns.Add(dcolWork);
         dcolWork = new DataColumn("dateEnd", typeof(DateTime));
         dtblTasks.Columns.Add(dcolWork);
         dcolWork = new DataColumn("durEstimated", typeof(int));
         dtblTasks.Columns.Add(dcolWork);
         dcolWork = new DataColumn("durActual", typeof(int));
         dtblTasks.Columns.Add(dcolWork);
         dcolWork = 
            new DataColumn("strComments", typeof(string ));
         dtblTasks.Columns.Add(dcolWork);

         // Add the tables to the DataSet.
         dsetTimeTracker.Tables.Add(dtblProjects);
         dsetTimeTracker.Tables.Add(dtblTasks);

         // Create a DataRelation, and add it to the DataSet.
         dsetTimeTracker.Relations.Add(
            new DataRelation(
                     "ProjectTask", 
                     dtblProjects.Columns["strIdent"], 
                     dtblTasks.Columns["strProjIdent"]));

         //  Load the Projects DataTable from 
         //     the Projects ArrayList.
         foreach ( Project projWork in alProjects )
         {
            dtblProjects.Rows.Add(new object[] 
                                  { projWork.strIdent, 
                                    projWork.strName, 
                                    projWork.dateStart, 
                                    projWork.dateEnd, 
                                    projWork.ctTasks, 
                                    projWork.strComments});
         }

         foreach ( Task taskWork in alTasks )
         {
            dtblTasks.Rows.Add(new object[] 
                               { taskWork.strIdent, 
                                 taskWork.strProjIdent, 
                                 taskWork.strName, 
                                 taskWork.dateStart, 
                                 taskWork.dateEnd, 
                                 taskWork.durEstimated, 
                                 taskWork.durActual, 
                                 taskWork.strComments});
         }
      }

      #endregion

   }
}
