// FormMain.cs - main user-interface for CallDeviceDll program
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
using System.Runtime.InteropServices;
using YaoDurant.Win32;


namespace CallDeviceDll
{
   /// <summary>
   /// Summary description for FormMain.
   /// </summary>
   public class FormMain : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Button cmdConnect;
      private System.Windows.Forms.Button cmdInvoke;
      private System.Windows.Forms.Button cmdDisconnect;
      private System.Windows.Forms.TextBox textInput;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      // Startup thread definitions
      private StartupThread m_thrdStartup = null;
      private EventHandler m_deleStartup;
      private bool m_bRapiConnected = false;

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
         this.cmdInvoke = new System.Windows.Forms.Button();
         this.cmdDisconnect = new System.Windows.Forms.Button();
         this.textInput = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // cmdConnect
         // 
         this.cmdConnect.Location = new System.Drawing.Point(24, 88);
         this.cmdConnect.Name = "cmdConnect";
         this.cmdConnect.TabIndex = 0;
         this.cmdConnect.Text = "Connect";
         this.cmdConnect.Click += new System.EventHandler(this.cmdConnect_Click);
         // 
         // cmdInvoke
         // 
         this.cmdInvoke.Location = new System.Drawing.Point(136, 88);
         this.cmdInvoke.Name = "cmdInvoke";
         this.cmdInvoke.TabIndex = 1;
         this.cmdInvoke.Text = "Invoke";
         this.cmdInvoke.Click += new System.EventHandler(this.cmdInvoke_Click);
         // 
         // cmdDisconnect
         // 
         this.cmdDisconnect.Location = new System.Drawing.Point(256, 88);
         this.cmdDisconnect.Name = "cmdDisconnect";
         this.cmdDisconnect.TabIndex = 2;
         this.cmdDisconnect.Text = "Disconnect";
         this.cmdDisconnect.Click += new System.EventHandler(this.cmdDisconnect_Click);
         // 
         // textInput
         // 
         this.textInput.Location = new System.Drawing.Point(24, 48);
         this.textInput.Name = "textInput";
         this.textInput.Size = new System.Drawing.Size(312, 20);
         this.textInput.TabIndex = 3;
         this.textInput.Text = "";
         this.textInput.TextChanged += new System.EventHandler(this.textInput_TextChanged);
         // 
         // FormMain
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(352, 142);
         this.Controls.Add(this.textInput);
         this.Controls.Add(this.cmdDisconnect);
         this.Controls.Add(this.cmdInvoke);
         this.Controls.Add(this.cmdConnect);
         this.Name = "FormMain";
         this.Text = "Call Device DLL";
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
         cmdInvoke.Enabled = false;
         cmdDisconnect.Enabled = false;
         textInput.Enabled = false;
      
         // Setup inter-thread delegates.
         m_deleStartup = new EventHandler(this.StartupCallback);
      }

      private void cmdConnect_Click(object sender, System.EventArgs e)
      {
         // Create thread to connect to RAPI.
         m_thrdStartup = new StartupThread(this, m_deleStartup);
         if (!m_thrdStartup.Run())
            m_thrdStartup = null;
      }

      //--------------------------------------------------------
      private void 
      cmdInvoke_Click(object sender, System.EventArgs e)
      {
         // Set up data to send to DLL
         string strHello = textInput.Text;
         int cbInput = (strHello.Length + 1 ) * 2;
         int cbOutput = 0;
         IntPtr ipInput = Marshal.StringToHGlobalUni(strHello);
         IntPtr ipOutput = IntPtr.Zero;

         try
         {
            // Call device-side DLL
            int hr = 
            Rapi.CeRapiInvoke(@"\windows\SimpleBlockModeInvoke.dll",
               "UpperCaseInvoke",
               cbInput,
               ipInput,
               ref cbOutput,
               ref ipOutput,
               0, 0);

            if (hr == Rapi.S_OK)
            {
               // Convert return value to a string.
               string strOutput = Marshal.PtrToStringUni(ipOutput, cbOutput);
               
               // Free memory returned from call to CeRapiInvoke.
               Marshal.FreeHGlobal(ipOutput);
         
               // Display resulting string.
               MessageBox.Show(strOutput, "CallDeviceDll");
            }
            else
            {
               throw (new System.Exception());
            }
         }
         catch
         {
            // In case of error, free memory we allocated.
            Marshal.FreeHGlobal(ipInput);

            MessageBox.Show("Error in calling device DLL.\n\n" +
               "Download SimpleBlockModeInvoke.dll " +
               "to the device.\nThen try again.",
               "CallDeviceDll");
         }

      } // cmdInvoke_Click

      private void cmdDisconnect_Click(object sender, System.EventArgs e)
      {
         // Disconnect from RAPI.
         Rapi.CeRapiUninit();
      
         // Change UI.
         cmdInvoke.Enabled = false;
         cmdDisconnect.Enabled = false;
         cmdConnect.Enabled = true;
         textInput.Text = String.Empty;
         textInput.Enabled = false;

         // Set flag that we are disconnected
         m_bRapiConnected = false;

      } // cmdDisconnect_Click

      private void FormMain_Closed(object sender, System.EventArgs e)
      {
         // If threads are running, trigger shutdown.
         if (this.m_thrdStartup != null)
            this.m_thrdStartup.bThreadContinue = false;

         if (m_bRapiConnected)
         {
            Rapi.CeRapiUninit();
            m_bRapiConnected = false;
         }
      } // FormMain_Closed

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
               cmdInvoke.Enabled = true;
               cmdDisconnect.Enabled = true;
               cmdConnect.Enabled = false;
               textInput.Enabled = true;
               break;
            case INVOKE_STARTUP.STARTUP_FAILED:
               cmdInvoke.Enabled = false;
               cmdDisconnect.Enabled = false;
               cmdConnect.Enabled = true;
               textInput.Enabled = false;
               break;
         }
      } // StartupCallback

      private void textInput_TextChanged(object sender, System.EventArgs e)
      {
         bool bHasText = (textInput.Text.Length > 0);
         cmdInvoke.Enabled = bHasText;
         
      } // textInput_TextChanged

   } // class FormMain 
} // namespace CallDeviceDll
