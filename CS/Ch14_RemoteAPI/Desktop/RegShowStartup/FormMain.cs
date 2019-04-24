// FormMain.cs - main user-interface for RegShowStartup program
//
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.

using System;
using System.Windows.Forms;
using System.Threading;
using YaoDurant.Win32;

namespace RegShowStartup
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class FormMain : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.ComboBox cboList;
      private System.Windows.Forms.Button cmdConnect;
      private System.Windows.Forms.Button cmdDisconnect;
      private System.Windows.Forms.Button cmdFetch;
      private System.Windows.Forms.Button cmdAbout;

      public string m_strAppName = "RegShowStartup";
      
      // Startup thread definitions
      private StartupThread m_thrdStartup = null;
      private EventHandler m_deleStartup;
      private bool m_bRapiConnected = false;

      // Enumeration thread definitions
      RapiEnumRegistryThread m_thrdRapiRegEnum = null;
      private EventHandler m_deleRegEnum;
      private System.Windows.Forms.Button cmdStop;
      private System.Windows.Forms.ListBox lboxStartupItems;


      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public FormMain()
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();
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
         this.label1 = new System.Windows.Forms.Label();
         this.cboList = new System.Windows.Forms.ComboBox();
         this.cmdConnect = new System.Windows.Forms.Button();
         this.cmdDisconnect = new System.Windows.Forms.Button();
         this.lboxStartupItems = new System.Windows.Forms.ListBox();
         this.cmdFetch = new System.Windows.Forms.Button();
         this.cmdAbout = new System.Windows.Forms.Button();
         this.cmdStop = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(8, 16);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(100, 16);
         this.label1.TabIndex = 0;
         this.label1.Text = "Select Startup List:";
         // 
         // cboList
         // 
         this.cboList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cboList.Items.AddRange(new object[] {
                                                     "Startup Programs",
                                                     "Startup DLLs"});
         this.cboList.Location = new System.Drawing.Point(120, 16);
         this.cboList.Name = "cboList";
         this.cboList.Size = new System.Drawing.Size(168, 21);
         this.cboList.TabIndex = 1;
         // 
         // cmdConnect
         // 
         this.cmdConnect.Location = new System.Drawing.Point(312, 32);
         this.cmdConnect.Name = "cmdConnect";
         this.cmdConnect.Size = new System.Drawing.Size(88, 24);
         this.cmdConnect.TabIndex = 2;
         this.cmdConnect.Text = "Connect";
         this.cmdConnect.Click += new System.EventHandler(this.cmdConnect_Click);
         // 
         // cmdDisconnect
         // 
         this.cmdDisconnect.Location = new System.Drawing.Point(312, 80);
         this.cmdDisconnect.Name = "cmdDisconnect";
         this.cmdDisconnect.Size = new System.Drawing.Size(88, 24);
         this.cmdDisconnect.TabIndex = 3;
         this.cmdDisconnect.Text = "Disconnect";
         this.cmdDisconnect.Click += new System.EventHandler(this.cmdDisconnect_Click);
         // 
         // lboxStartupItems
         // 
         this.lboxStartupItems.Location = new System.Drawing.Point(16, 56);
         this.lboxStartupItems.Name = "lboxStartupItems";
         this.lboxStartupItems.ScrollAlwaysVisible = true;
         this.lboxStartupItems.Size = new System.Drawing.Size(272, 212);
         this.lboxStartupItems.TabIndex = 7;
         // 
         // cmdFetch
         // 
         this.cmdFetch.Location = new System.Drawing.Point(312, 128);
         this.cmdFetch.Name = "cmdFetch";
         this.cmdFetch.Size = new System.Drawing.Size(88, 24);
         this.cmdFetch.TabIndex = 4;
         this.cmdFetch.Text = "Fetch";
         this.cmdFetch.Click += new System.EventHandler(this.cmdFetch_Click);
         // 
         // cmdAbout
         // 
         this.cmdAbout.Location = new System.Drawing.Point(312, 224);
         this.cmdAbout.Name = "cmdAbout";
         this.cmdAbout.Size = new System.Drawing.Size(88, 24);
         this.cmdAbout.TabIndex = 6;
         this.cmdAbout.Text = "About";
         this.cmdAbout.Click += new System.EventHandler(this.cmdAbout_Click);
         // 
         // cmdStop
         // 
         this.cmdStop.Location = new System.Drawing.Point(312, 176);
         this.cmdStop.Name = "cmdStop";
         this.cmdStop.Size = new System.Drawing.Size(88, 24);
         this.cmdStop.TabIndex = 5;
         this.cmdStop.Text = "Stop";
         this.cmdStop.Click += new System.EventHandler(this.cmdStop_Click);
         // 
         // FormMain
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(424, 276);
         this.Controls.Add(this.cmdStop);
         this.Controls.Add(this.cmdAbout);
         this.Controls.Add(this.cmdFetch);
         this.Controls.Add(this.lboxStartupItems);
         this.Controls.Add(this.cmdDisconnect);
         this.Controls.Add(this.cmdConnect);
         this.Controls.Add(this.cboList);
         this.Controls.Add(this.label1);
         this.Name = "FormMain";
         this.Text = "RAPI - RegShowStartup";
         this.Load += new System.EventHandler(this.FormMain_Load);
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

      private void FormMain_Load(object sender, System.EventArgs e)
      {
         // Init user-interface objects.
         cmdDisconnect.Enabled = false;
         cmdFetch.Enabled = false;
         cmdConnect.Enabled = true;
         cmdStop.Enabled = false;
         
         // Startup thread setup details
         m_deleStartup = new EventHandler(this.StartupCallback);
         
         // Enum thread setup details
         m_deleRegEnum = new EventHandler(this.EnumRegCallback);
      
      } // FormMain_Load

      private void FormMain_Closed(object sender, System.EventArgs e)
      {
         // If threads are running, trigger shutdown.
         if (this.m_thrdStartup != null)
         {
            this.m_thrdStartup.bThreadContinue = false;
         }
         if (this.m_thrdRapiRegEnum != null)
         {
            this.m_thrdRapiRegEnum.bThreadContinue = false;
            while (m_thrdRapiRegEnum.thrd != null)
            {
               Application.DoEvents();
            }
         }

         if (m_bRapiConnected)
         {
            Rapi.CeRapiUninit();
            m_bRapiConnected = false;
         }
      } // FormMain_Closed

      private void 
      cmdConnect_Click(object sender, System.EventArgs e)
      {
         // Create thread to connect to RAPI.
         m_thrdStartup = new StartupThread(this, m_deleStartup);
         if (!m_thrdStartup.Run())
            m_thrdStartup = null;
      } // cmdConnect_Click

      private void 
      cmdDisconnect_Click(object sender, System.EventArgs e)
      {
         if (m_bRapiConnected)
         {
            Rapi.CeRapiUninit();
            m_bRapiConnected = false;
         }

         cmdDisconnect.Enabled = false;
         cmdFetch.Enabled = false;
         cmdConnect.Enabled = true;
      } // cmdDisconnect_Click

      private void 
      cmdFetch_Click(object sender, System.EventArgs e)
      {
         if (cboList.SelectedIndex == -1)
         {
            MessageBox.Show("Please select a startup item", 
               m_strAppName);
            return;
         }

         // Clear previous list.
         this.lboxStartupItems.Items.Clear();

         string strSearch = string.Empty;
         bool bKeys = false;
         if (cboList.Text == "Startup Programs")
         {
            strSearch = @"Init";
            bKeys = false;
         }
         if (cboList.Text == "Startup DLLs")
         {
            strSearch = @"Drivers\BuiltIn";
            bKeys = true;
         }

         // Create background thread object.
         m_thrdRapiRegEnum = 
            new RapiEnumRegistryThread(
               this, 
               this.m_deleRegEnum,
               bKeys,
               Rapi.HKEY_LOCAL_MACHINE,
               strSearch);
         if (m_thrdRapiRegEnum == null)
             MessageBox.Show("Cannot create thread",m_strAppName);

         // Start search in background thread.
         if (!m_thrdRapiRegEnum.Run())
            MessageBox.Show("Cannot run thread", m_strAppName);
         else
         {
            // Reset user-interface to prevent other searches,
            // and to enable stopping current search.
            cmdFetch.Enabled = false;
            cmdStop.Enabled = true;
         }

      } // cmdFetch_Click

      private void 
      cmdStop_Click(object sender, System.EventArgs e)
      {
         // Stop search
         if (this.m_thrdRapiRegEnum != null)
            this.m_thrdRapiRegEnum.bThreadContinue = false;
      } // cmdStop_Click

      private void 
      cmdAbout_Click(object sender, System.EventArgs e)
      {
         MessageBox.Show("(c) Copyright 2002-2004 Paul Yao and David Durant\r\n\r\n" +
            "RegShowStartup - RAPI Sample for the book\r\n" +
            "Programming the .NET Compact Framework", m_strAppName);
      } // cmdAbout_Click

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
               cmdDisconnect.Enabled = true;
               cmdFetch.Enabled = true;
               cmdConnect.Enabled = false;
               break;
            case INVOKE_STARTUP.STARTUP_FAILED:
               MessageBox.Show("Cannot connect to device", 
                  m_strAppName);
               break;
            case INVOKE_STARTUP.STATUS_MESSAGE:
               break;
         }
      } // StartupCallback

      /// <summary>
      /// EnumRegCallback - Interthread delegate.
      /// </summary>
      /// <param name="sender">unused</param>
      /// <param name="e">unused</param>
      private void 
      EnumRegCallback(object sender, System.EventArgs e)
      {
         INVOKE_ENUMREG it = this.m_thrdRapiRegEnum.itReason;
         string str = m_thrdRapiRegEnum.strBuffer;
         switch(it)
         {
            case INVOKE_ENUMREG.ENUMREG_NEWKEY:
               lboxStartupItems.Items.Add(str);
               break;
            case INVOKE_ENUMREG.ENUMREG_NEWVALUE:
               lboxStartupItems.Items.Add(str);
               break;
            case INVOKE_ENUMREG.ENUMREG_ENDED:
               cmdFetch.Enabled = true;
               cmdStop.Enabled = false;
               break;
            case INVOKE_ENUMREG.STATUS_MESSAGE:
               MessageBox.Show(str, m_strAppName);
               break;
         }
      } // EnumRegCallback

   }
}
