// FormMain.cs - Sleep sample displays various timeout values
// for Windows CE system.
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

namespace Sleep
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class FormMain : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Button cmdSleepButton;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Button cmdSetBatteryTimeout;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Button cmdSetSnoozeTimeout;
      private System.Windows.Forms.TextBox textBattery;
      private System.Windows.Forms.TextBox textExternal;
      private System.Windows.Forms.TextBox textSnooze;
      private System.Windows.Forms.MainMenu mainMenu1;
      private System.Windows.Forms.Button cmdSetExternalTimeout;

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
         this.cmdSleepButton = new System.Windows.Forms.Button();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.textBattery = new System.Windows.Forms.TextBox();
         this.cmdSetBatteryTimeout = new System.Windows.Forms.Button();
         this.label3 = new System.Windows.Forms.Label();
         this.textExternal = new System.Windows.Forms.TextBox();
         this.cmdSetExternalTimeout = new System.Windows.Forms.Button();
         this.label4 = new System.Windows.Forms.Label();
         this.textSnooze = new System.Windows.Forms.TextBox();
         this.cmdSetSnoozeTimeout = new System.Windows.Forms.Button();
         // 
         // cmdSleepButton
         // 
         this.cmdSleepButton.Location = new System.Drawing.Point(32, 192);
         this.cmdSleepButton.Size = new System.Drawing.Size(168, 24);
         this.cmdSleepButton.Text = "Push Power Button";
         this.cmdSleepButton.Click += new System.EventHandler(this.cmdSleepButton_Click);
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(72, 24);
         this.label1.Size = new System.Drawing.Size(112, 32);
         this.label1.Text = "Inactivity Timer Settings (in sec.)";
         // 
         // label2
         // 
         this.label2.Location = new System.Drawing.Point(21, 72);
         this.label2.Size = new System.Drawing.Size(48, 20);
         this.label2.Text = "Battery:";
         // 
         // textBattery
         // 
         this.textBattery.Location = new System.Drawing.Point(88, 70);
         this.textBattery.Size = new System.Drawing.Size(64, 22);
         this.textBattery.Text = "";
         // 
         // cmdSetBatteryTimeout
         // 
         this.cmdSetBatteryTimeout.Location = new System.Drawing.Point(168, 70);
         this.cmdSetBatteryTimeout.Size = new System.Drawing.Size(40, 22);
         this.cmdSetBatteryTimeout.Text = "Set";
         this.cmdSetBatteryTimeout.Click += new System.EventHandler(this.cmdSetBatteryTimeout_Click);
         // 
         // label3
         // 
         this.label3.Location = new System.Drawing.Point(16, 112);
         this.label3.Size = new System.Drawing.Size(56, 20);
         this.label3.Text = "External:";
         // 
         // textExternal
         // 
         this.textExternal.Location = new System.Drawing.Point(88, 110);
         this.textExternal.Size = new System.Drawing.Size(64, 22);
         this.textExternal.Text = "";
         // 
         // cmdSetExternalTimeout
         // 
         this.cmdSetExternalTimeout.Location = new System.Drawing.Point(168, 110);
         this.cmdSetExternalTimeout.Size = new System.Drawing.Size(40, 22);
         this.cmdSetExternalTimeout.Text = "Set";
         this.cmdSetExternalTimeout.Click += new System.EventHandler(this.cmdSetExternalTimeout_Click);
         // 
         // label4
         // 
         this.label4.Location = new System.Drawing.Point(21, 152);
         this.label4.Size = new System.Drawing.Size(48, 20);
         this.label4.Text = "Snooze:";
         // 
         // textSnooze
         // 
         this.textSnooze.Location = new System.Drawing.Point(88, 150);
         this.textSnooze.Size = new System.Drawing.Size(64, 22);
         this.textSnooze.Text = "";
         // 
         // cmdSetSnoozeTimeout
         // 
         this.cmdSetSnoozeTimeout.Location = new System.Drawing.Point(168, 150);
         this.cmdSetSnoozeTimeout.Size = new System.Drawing.Size(40, 22);
         this.cmdSetSnoozeTimeout.Text = "Set";
         this.cmdSetSnoozeTimeout.Click += new System.EventHandler(this.cmdSetSnoozeTimeout_Click);
         // 
         // FormMain
         // 
         this.Controls.Add(this.cmdSetSnoozeTimeout);
         this.Controls.Add(this.textSnooze);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.cmdSetExternalTimeout);
         this.Controls.Add(this.textExternal);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.cmdSetBatteryTimeout);
         this.Controls.Add(this.textBattery);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.cmdSleepButton);
         this.Menu = this.mainMenu1;
         this.MinimizeBox = false;
         this.Text = "Sleep";
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

      string strAppName = "Sleep";

      [DllImport("coredll.dll", CharSet=CharSet.Unicode)]
      public static extern void 
      keybd_event (byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
      public const int VK_OFF = 0xDF;

      [DllImport("coredll.dll", CharSet=CharSet.Unicode)]
      public static extern int 
      SystemParametersInfo (int uiAction, int uiParam, 
         ref int piParam, int fWinIni);

      [DllImport("coredll.dll", CharSet=CharSet.Unicode)]
      public static extern int 
      SystemParametersInfo (int uiAction, int uiParam, 
         IntPtr iReserved, int fWinIni);

      public const int SPI_SETBATTERYIDLETIMEOUT = 251;
      public const int SPI_GETBATTERYIDLETIMEOUT = 252;
      public const int SPI_SETEXTERNALIDLETIMEOUT = 253;
      public const int SPI_GETEXTERNALIDLETIMEOUT = 254;
      public const int SPI_SETWAKEUPIDLETIMEOUT = 255;
      public const int SPI_GETWAKEUPIDLETIMEOUT = 256;

      public const int SPIF_UPDATEINIFILE = 0x0001;
      public const int SPIF_SENDCHANGE = 0x0002;

      private void FormMain_Load(object sender, System.EventArgs e)
      {
         int iValue = 0;
         SystemParametersInfo(SPI_GETBATTERYIDLETIMEOUT, 0, ref iValue, 0);
         textBattery.Text = iValue.ToString();
         SystemParametersInfo(SPI_GETEXTERNALIDLETIMEOUT, 0, ref iValue, 0);
         textExternal.Text = iValue.ToString();
         SystemParametersInfo(SPI_GETWAKEUPIDLETIMEOUT, 0, ref iValue, 0);
         textSnooze.Text = iValue.ToString();
      }

      private void 
      cmdSleepButton_Click(object sender, System.EventArgs e)
      {
         keybd_event(VK_OFF, 0, 0, 0);
      }

      private void 
      cmdSetBatteryTimeout_Click(object sender, 
                                 System.EventArgs e)
      {
         try
         {
            int iValue = int.Parse(textBattery.Text);
            if (iValue < 0)
               throw(new Exception());
            SystemParametersInfo(SPI_SETBATTERYIDLETIMEOUT, iValue, 
               IntPtr.Zero, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
         }
         catch
         {
            MessageBox.Show("Invalid timeout value entered.", 
               strAppName);
         }
      }

      private void 
      cmdSetExternalTimeout_Click(object sender, 
                               System.EventArgs e)
      {
         try
         {
            int iValue = int.Parse(textExternal.Text);
            if (iValue < 0)
               throw(new Exception());
            SystemParametersInfo(SPI_SETEXTERNALIDLETIMEOUT, iValue,
            IntPtr.Zero, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
         }
         catch
         {
            MessageBox.Show("Invalid timeout value entered.", 
               strAppName);
         }
      }

      private void 
      cmdSetSnoozeTimeout_Click(object sender, 
                                System.EventArgs e)
      {
         try
         {
            int iValue = int.Parse(textSnooze.Text);
            if (iValue < 0)
               throw(new Exception());
            SystemParametersInfo(SPI_SETWAKEUPIDLETIMEOUT, iValue,
            IntPtr.Zero, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
         }
         catch
         {
            MessageBox.Show("Invalid timeout value entered.", 
               strAppName);
         }
      }

   } // class FormMain 
} // namespace Sleep
