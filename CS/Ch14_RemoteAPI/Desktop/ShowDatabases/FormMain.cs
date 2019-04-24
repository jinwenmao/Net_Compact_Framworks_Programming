// FormMain.cs - Main user interface for ShowDatabases sample
//
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using YaoDurant.Win32;

namespace ShowDatabases
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class FormMain : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Button cmdConnect;
      private System.Windows.Forms.Button cmdDisconnect;
      private System.Windows.Forms.Button cmdAbout;
      private System.Windows.Forms.ListBox lboxDatabases;
      private System.Windows.Forms.Button cmdFindVolumes;
      private System.Windows.Forms.Button cmdFindDatabases;

      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      private string m_strAppName = "ShowDatabases";

      // Startup thread definitions
      private StartupThread m_thrdStartup = null;
      private EventHandler m_deleStartup;
      private bool m_bRapiConnected = false;

      // Find Database thread definitions
      private RapiEnumDBThread m_thrdFindDB = null;
      private EventHandler m_deleFindDB;

      public FormMain()
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         //
         // TODO: Add any constructor code after InitializeComponent call
         //
         EnableButtons(false);

         // Setup inter-thread delegates.
         m_deleStartup = new EventHandler(this.StartupCallback);
         m_deleFindDB = new EventHandler(this.FindDBCallback);
      }

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      protected override void Dispose( bool disposing )
      {
         if( disposing )
         {
            if (components != null) 
            {
               components.Dispose();
            }
         }
         base.Dispose( disposing );
      }

      #region Windows Form Designer generated code
      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.cmdConnect = new System.Windows.Forms.Button();
         this.cmdDisconnect = new System.Windows.Forms.Button();
         this.cmdFindDatabases = new System.Windows.Forms.Button();
         this.cmdAbout = new System.Windows.Forms.Button();
         this.lboxDatabases = new System.Windows.Forms.ListBox();
         this.cmdFindVolumes = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // cmdConnect
         // 
         this.cmdConnect.Location = new System.Drawing.Point(360, 16);
         this.cmdConnect.Name = "cmdConnect";
         this.cmdConnect.Size = new System.Drawing.Size(112, 23);
         this.cmdConnect.TabIndex = 2;
         this.cmdConnect.Text = "Connect";
         this.cmdConnect.Click += new System.EventHandler(this.cmdConnect_Click);
         // 
         // cmdDisconnect
         // 
         this.cmdDisconnect.Location = new System.Drawing.Point(360, 56);
         this.cmdDisconnect.Name = "cmdDisconnect";
         this.cmdDisconnect.Size = new System.Drawing.Size(112, 23);
         this.cmdDisconnect.TabIndex = 3;
         this.cmdDisconnect.Text = "Disconnect";
         this.cmdDisconnect.Click += new System.EventHandler(this.cmdDisconnect_Click);
         // 
         // cmdFindDatabases
         // 
         this.cmdFindDatabases.Location = new System.Drawing.Point(360, 136);
         this.cmdFindDatabases.Name = "cmdFindDatabases";
         this.cmdFindDatabases.Size = new System.Drawing.Size(112, 23);
         this.cmdFindDatabases.TabIndex = 4;
         this.cmdFindDatabases.Text = "Find Databases";
         this.cmdFindDatabases.Click += new System.EventHandler(this.cmdFind_Click);
         // 
         // cmdAbout
         // 
         this.cmdAbout.Location = new System.Drawing.Point(360, 176);
         this.cmdAbout.Name = "cmdAbout";
         this.cmdAbout.Size = new System.Drawing.Size(112, 23);
         this.cmdAbout.TabIndex = 5;
         this.cmdAbout.Text = "About";
         this.cmdAbout.Click += new System.EventHandler(this.cmdAbout_Click);
         // 
         // lboxDatabases
         // 
         this.lboxDatabases.Location = new System.Drawing.Point(16, 16);
         this.lboxDatabases.Name = "lboxDatabases";
         this.lboxDatabases.Size = new System.Drawing.Size(328, 199);
         this.lboxDatabases.TabIndex = 6;
         // 
         // cmdFindVolumes
         // 
         this.cmdFindVolumes.Location = new System.Drawing.Point(360, 96);
         this.cmdFindVolumes.Name = "cmdFindVolumes";
         this.cmdFindVolumes.Size = new System.Drawing.Size(112, 23);
         this.cmdFindVolumes.TabIndex = 7;
         this.cmdFindVolumes.Text = "Find Volumes";
         this.cmdFindVolumes.Click += new System.EventHandler(this.cmdFindVolumes_Click);
         // 
         // FormMain
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(488, 230);
         this.Controls.Add(this.cmdFindVolumes);
         this.Controls.Add(this.lboxDatabases);
         this.Controls.Add(this.cmdAbout);
         this.Controls.Add(this.cmdFindDatabases);
         this.Controls.Add(this.cmdDisconnect);
         this.Controls.Add(this.cmdConnect);
         this.Name = "FormMain";
         this.Text = "RAPI - ShowDatabases";
         this.Closed += new System.EventHandler(this.FormMain_Closed);
         this.ResumeLayout(false);

      }
      #endregion

      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main() 
      {
         Application.Run(new FormMain());
      }

      private void cmdConnect_Click(object sender, System.EventArgs e)
      {
         // Create thread to connect to RAPI.
         m_thrdStartup = new StartupThread(this, m_deleStartup);
         if (!m_thrdStartup.Run())
            m_thrdStartup = null;

         // Clear out previous contents of listbox.
         this.lboxDatabases.Items.Clear();
      }

      private void cmdDisconnect_Click(object sender, System.EventArgs e)
      {
         // Disconnect from RAPI.
         Rapi.CeRapiUninit();

         EnableButtons(false);
         m_bRapiConnected = false;
      }

      private void cmdFindVolumes_Click(object sender, System.EventArgs e)
      {
         // Disable Find buttons.
         this.cmdFindDatabases.Enabled = false;
         this.cmdFindVolumes.Enabled = false;

         // Clear out previous contents of file listbox.
         this.lboxDatabases.Items.Clear();
         
         m_thrdFindDB = new RapiEnumDBThread(this, m_deleFindDB, true);
         if (!m_thrdFindDB.Run())
            m_thrdFindDB = null;
      }

      private void cmdFind_Click(object sender, System.EventArgs e)
      {
         // Disable Find buttons.
         this.cmdFindDatabases.Enabled = false;
         this.cmdFindVolumes.Enabled = false;

         // Clear out previous contents of file listbox.
         this.lboxDatabases.Items.Clear();
         
         m_thrdFindDB = new RapiEnumDBThread(this, m_deleFindDB, false);
         if (!m_thrdFindDB.Run())
            m_thrdFindDB = null;
      }

      private void cmdAbout_Click(object sender, System.EventArgs e)
      {
         MessageBox.Show(this,"(c) Copyright 2002-2004 " +
            "Paul Yao and David Durant\n\n" +
            "ShowDatabases - RAPI Sample for \n" +
            "Programming the .NET Compact Framework with C#,\n"+
            "& Programming the .NET Compact Framework with VB."
            , m_strAppName);
      }

      private void EnableButtons(bool bConnected)
      {
         this.cmdConnect.Enabled = !bConnected;
         this.cmdDisconnect.Enabled = bConnected;
         this.cmdFindDatabases.Enabled = bConnected;
         this.cmdFindVolumes.Enabled = bConnected;
      }

      /// <summary>
      /// StartupCallback - Interthread delegate.
      /// </summary>
      /// <param name="sender">unused</param>
      /// <param name="e">unused</param>
      private void 
         StartupCallback(object sender, System.EventArgs e)
      {
         INVOKE_STARTUP it = this.m_thrdStartup.itReason;
         switch(it)
         {
            case INVOKE_STARTUP.STARTUP_SUCCESS:
               m_bRapiConnected = true;
               EnableButtons(true);
               break;
            case INVOKE_STARTUP.STARTUP_FAILED:
               EnableButtons(false);
               break;
            case INVOKE_STARTUP.STATUS_MESSAGE:
               MessageBox.Show(m_thrdStartup.strBuffer,m_strAppName);
               break;
         }
      }

      /// <summary>
      /// FindDBCallback - Interthread delegate.
      /// </summary>
      /// <param name="sender">unused</param>
      /// <param name="e">unused</param>
      private void 
      FindDBCallback(object sender, System.EventArgs e)
      {
         INVOKE_ENUMDB it = this.m_thrdFindDB.itReason;
         string strIn = m_thrdFindDB.strBuffer;
         switch(it)
         {
            case INVOKE_ENUMDB.ENUMDB_NEWVOLUME:
               this.lboxDatabases.Items.Add(strIn);
               break;
            case INVOKE_ENUMDB.ENUMDB_NEWDATABASE:
               this.lboxDatabases.Items.Add(strIn);
               break;
            case INVOKE_ENUMDB.ENUMDB_COMPLETE:
               // Enable Find buttons.
               this.cmdFindDatabases.Enabled = true;
               this.cmdFindVolumes.Enabled = true;
               break;
            case INVOKE_ENUMDB.STATUS_MESSAGE:
               MessageBox.Show(strIn, m_strAppName);
               break;
         }
      }

      private void FormMain_Closed(object sender, System.EventArgs e)
      {
         // If threads are running, trigger shutdown.
         if (this.m_thrdStartup != null)
            this.m_thrdStartup.bThreadContinue = false;
         if (this.m_thrdFindDB != null)
            this.m_thrdFindDB.bThreadContinue = false;

         if (m_bRapiConnected)
         {
            Rapi.CeRapiUninit();
            m_bRapiConnected = false;
         }
      }

   } // class FormMain
} // namespace ShowDatabases
