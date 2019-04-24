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

namespace FormsCollection
{
   /// <summary>
   /// Summary description for FormPressure.
   /// </summary>
   public class FormPressure : System.Windows.Forms.Form
   {
      internal System.Windows.Forms.ListBox lboxPast;
      internal System.Windows.Forms.Label Label3;
      internal System.Windows.Forms.Label lblCurrent;
      internal System.Windows.Forms.Label Label1;
   
      public FormPressure()
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
         // FormPressure
         // 
         this.Controls.Add(this.lboxPast);
         this.Controls.Add(this.Label3);
         this.Controls.Add(this.lblCurrent);
         this.Controls.Add(this.Label1);
         this.Text = "FormPressure";
         this.Load += new System.EventHandler(this.FormPressure_Load);
         this.Closed += new System.EventHandler(this.FormPressure_Closed);

      }
      #endregion

      private void FormPressure_Load(object sender, System.EventArgs e)
      {
         LoadPressures();      
      }

      private void LoadPressures() 
      {
         //  Load sample barometric pressures into controls.
         double[] adblPressures  = 
                     {
                        29.92, 29.92, 29.93, 29.93, 29.93, 29.93, 
                        29.94, 29.94, 29.94, 29.95, 29.96, 29.96, 
                        29.96, 29.96, 29.97, 29.97, 29.96, 29.96, 
                        29.95, 29.95, 29.94, 29.94, 29.93, 29.93};

         lblCurrent.Text = adblPressures[0].ToString();
         foreach (double dblPressure in adblPressures)
            lboxPast.Items.Add(dblPressure.ToString());
      }

      private void FormPressure_Closed(object sender, System.EventArgs e)
      {
         Global.RemoveForm(this);
      }

   }
}
