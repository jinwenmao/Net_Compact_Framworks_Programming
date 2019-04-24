//-----------------------------------------------------------------------------
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MultiThreaded
{
   /// <summary>
   /// Summary description for FormPrecipitation.
   /// </summary>
   public class FormPrecipitation : System.Windows.Forms.Form
   {
      internal System.Windows.Forms.ListBox lboxPast;
      internal System.Windows.Forms.Label Label3;
      internal System.Windows.Forms.Label lblCurrent;
      internal System.Windows.Forms.Label Label1;
   
      public FormPrecipitation()
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
         this.lboxPast = new System.Windows.Forms.ListBox();
         this.Label3 = new System.Windows.Forms.Label();
         this.lblCurrent = new System.Windows.Forms.Label();
         this.Label1 = new System.Windows.Forms.Label();
         // 
         // lboxPast
         // 
         this.lboxPast.Location = new System.Drawing.Point(130, 53);
         this.lboxPast.Size = new System.Drawing.Size(100, 184);
         // 
         // Label3
         // 
         this.Label3.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
         this.Label3.Location = new System.Drawing.Point(130, 21);
         this.Label3.Text = "Past 24 Hours";
         // 
         // lblCurrent
         // 
         this.lblCurrent.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular);
         this.lblCurrent.Location = new System.Drawing.Point(10, 53);
         // 
         // Label1
         // 
         this.Label1.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular);
         this.Label1.Location = new System.Drawing.Point(10, 21);
         this.Label1.Text = "Current";
         // 
         // FormPrecipitation
         // 
         this.Controls.Add(this.lboxPast);
         this.Controls.Add(this.Label3);
         this.Controls.Add(this.lblCurrent);
         this.Controls.Add(this.Label1);
         this.Text = "FormPrecipitation";
         this.Load += new System.EventHandler(this.FormPrecipitation_Load);
         this.Closed += new System.EventHandler(this.FormPrecipitation_Closed);

      }
      #endregion

      private void FormPrecipitation_Load(object sender, System.EventArgs e)
      {
         LoadRainFalls();
      } 

      private void LoadRainFalls() 
      {
         //  Load sample rainfalls into controls.
         double[] adblRains  = 
                     {0.12, 0.12, 0.13, 0.13, 0.13, 0.13, 
                      0.14, 0.14, 0.14, 0.15, 0.16, 0.16, 
                      0.16, 0.16, 0.17, 0.17, 0.16, 0.16, 
                      0.15, 0.15, 0.14, 0.14, 0.13, 0.13};

         lblCurrent.Text = adblRains[0].ToString();
         foreach (double dblRain in adblRains)
            lboxPast.Items.Add(dblRain.ToString());
      }

      private void FormPrecipitation_Closed(object sender, System.EventArgs e)
      {
         Global.RemoveForm(this);
      }
   } 
}

