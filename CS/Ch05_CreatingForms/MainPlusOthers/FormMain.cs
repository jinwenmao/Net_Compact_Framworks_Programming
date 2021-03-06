//-----------------------------------------------------------------------------
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;

namespace MainPlusOthers
{
   /// <summary>
   /// Summary description for FormMain.
   /// </summary>
   public class FormMain : System.Windows.Forms.Form
   {
      internal System.Windows.Forms.Button cmdPrecip;
      internal System.Windows.Forms.Button cmdTemp;
      internal System.Windows.Forms.Button cmdPress;
      internal System.Windows.Forms.Label lblTitle;
      internal System.Windows.Forms.Label lblIntro;
      private System.Windows.Forms.MainMenu mainMenu1;

      private FormTemperature frmTemp;
      private WeakReference weakTemp;

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
         this.cmdPrecip = new System.Windows.Forms.Button();
         this.cmdTemp = new System.Windows.Forms.Button();
         this.cmdPress = new System.Windows.Forms.Button();
         this.lblTitle = new System.Windows.Forms.Label();
         this.lblIntro = new System.Windows.Forms.Label();
         // 
         // cmdPrecip
         // 
         this.cmdPrecip.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
         this.cmdPrecip.Location = new System.Drawing.Point(88, 231);
         this.cmdPrecip.Size = new System.Drawing.Size(64, 24);
         this.cmdPrecip.Text = "Precip";
         this.cmdPrecip.Click += new System.EventHandler(this.cmdPrecip_Click);
         // 
         // cmdTemp
         // 
         this.cmdTemp.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
         this.cmdTemp.Location = new System.Drawing.Point(8, 231);
         this.cmdTemp.Size = new System.Drawing.Size(64, 24);
         this.cmdTemp.Text = "Temp";
         this.cmdTemp.Click += new System.EventHandler(this.cmdTemp_Click);
         // 
         // cmdPress
         // 
         this.cmdPress.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
         this.cmdPress.Location = new System.Drawing.Point(168, 231);
         this.cmdPress.Size = new System.Drawing.Size(64, 24);
         this.cmdPress.Text = "Pressure";
         this.cmdPress.Click += new System.EventHandler(this.cmdPress_Click);
         // 
         // lblTitle
         // 
         this.lblTitle.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular);
         this.lblTitle.Location = new System.Drawing.Point(0, 15);
         this.lblTitle.Size = new System.Drawing.Size(240, 48);
         this.lblTitle.Text = "Welcome to your Weather";
         this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
         // 
         // lblIntro
         // 
         this.lblIntro.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
         this.lblIntro.Location = new System.Drawing.Point(0, 79);
         this.lblIntro.Size = new System.Drawing.Size(240, 136);
         this.lblIntro.Text = "Click on a button to see more information about temperature, precipitation, or ba" +
            "rametric pressure.";
         this.lblIntro.TextAlign = System.Drawing.ContentAlignment.TopCenter;
         // 
         // FormMain
         // 
         this.Controls.Add(this.cmdPrecip);
         this.Controls.Add(this.cmdTemp);
         this.Controls.Add(this.cmdPress);
         this.Controls.Add(this.lblTitle);
         this.Controls.Add(this.lblIntro);
         this.Menu = this.mainMenu1;
         this.Text = "FormMain";
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

      private void cmdTemp_Click(object sender, System.EventArgs e)
      {
         //  Use a WeakReference to verify that the orphaned
         //     form does not get garbage collected.
         frmTemp = new FormTemperature();
         GC.Collect();
         if ( weakTemp == null ) 
         {
            weakTemp = new WeakReference(frmTemp);
            frmTemp.Text = "First Form Created";
         }
         FormTemperature frmTempFirst = (FormTemperature)weakTemp.Target;
         frmTemp.Show();
         //  To verify:
         //     (Try with and without "GC.Collect())"
         //     (Try with and without "frmTemp.MinimizeBox = False"
         //     Set a break point here.
         //     Run the app.
         //     Show and hide this form several times.
         //     In the Command window,
         //        Enter "? frmTempFirst.Text"
      }

      private void cmdPrecip_Click(object sender, 
                                   System.EventArgs e)
      {
         if ( Global.frmPrecipitation == null ) {
            Global.frmPrecipitation = new FormPrecipitation();
         }
         Global.frmPrecipitation.Show();
      }

      private void cmdPress_Click(object sender, System.EventArgs e)
      {
         FormPressure  frmPress = new FormPressure();
         frmPress.Show();
      }

      private void FormMain_Load(object sender, System.EventArgs e)
      {
         this.MinimizeBox = false;
      }
   }
}
