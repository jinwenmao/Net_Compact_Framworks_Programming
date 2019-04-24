// FormMain.cs - Main form for Start sample program.
//
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.

using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;

namespace Start
{
   /// <summary>
   /// Summary description for FormMain.
   /// </summary>
   public class FormMain : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox textPath;
      private System.Windows.Forms.Button cmdStart;
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
         this.label1 = new System.Windows.Forms.Label();
         this.textPath = new System.Windows.Forms.TextBox();
         this.cmdStart = new System.Windows.Forms.Button();
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(16, 24);
         this.label1.Text = "Program Path:";
         // 
         // textPath
         // 
         this.textPath.Location = new System.Drawing.Point(16, 48);
         this.textPath.Size = new System.Drawing.Size(216, 22);
         this.textPath.Text = "";
         // 
         // cmdStart
         // 
         this.cmdStart.Location = new System.Drawing.Point(56, 96);
         this.cmdStart.Size = new System.Drawing.Size(112, 24);
         this.cmdStart.Text = "Start Program";
         this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
         // 
         // FormMain
         // 
         this.Controls.Add(this.cmdStart);
         this.Controls.Add(this.textPath);
         this.Controls.Add(this.label1);
         this.Menu = this.mainMenu1;
         this.MinimizeBox = false;
         this.Text = "Start";
         this.GotFocus += new System.EventHandler(this.FormMain_GotFocus);

      }
      #endregion

      /// <summary>
      /// The main entry point for the application.
      /// </summary>

      static void Main() 
      {
         Application.Run(new FormMain());
      }

      static string strAppName = "Start";

      [DllImport("coredll.dll")]
      public static extern int 
      CreateProcess (string pszImageName, string pszCmdLine, 
      int Res1, int Res2, int Res3, CREATE_FLAG fdwCreate, 
      int Res4, int Res5, int Res6, 
      ref PROCESS_INFORMATION pProcInfo);

      [DllImport("coredll.dll")]
      public static extern int 
      CreateProcess (string pszImageName, int pszEmptyPath, 
      int Res1, int Res2, int Res3, CREATE_FLAG fdwCreate, 
      int Res4, int Res5, int Res6, 
      ref PROCESS_INFORMATION pProcInfo);

      [DllImport("coredll.dll")]
      public static extern int CloseHandle (IntPtr hObject);

      [DllImport("coredll.dll")]
      public static extern int GetLastError ();

      public struct PROCESS_INFORMATION
      {
         public IntPtr hProcess;
         public IntPtr hThread;
         public int dwProcessId;
         public int dwThreadId;
      };

      public enum CREATE_FLAG
      {
         CREATE_SUSPENDED = 4,
         CREATE_NEW_CONSOLE = 0x10,
      }

      private void 
      cmdStart_Click(object sender, System.EventArgs e)
      {
         string strPath = textPath.Text;
         PROCESS_INFORMATION pi = new PROCESS_INFORMATION();
         int bOk = CreateProcess(strPath, 0, 0, 0, 0, 0, 0, 0, 0, 
         ref pi);
         if (bOk > 0)
         {
            CloseHandle(pi.hProcess);
            CloseHandle(pi.hThread);
         }
         else
         {
            MessageBox.Show("CreateProcess Failed", strAppName);
         }
      }

      private void FormMain_GotFocus(object sender, System.EventArgs e)
      {
         textPath.Focus();
      }

   } // class
} // namespace
