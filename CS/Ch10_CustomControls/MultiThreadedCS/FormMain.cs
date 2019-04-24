//-----------------------------------------------------------------------------
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using YaoDurant.Gui;

namespace MultiThreadedCS
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class FormMain : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Button cmdGetData;
      private YaoDurant.Gui.MultiThreadBox mtbPerson;

      #region Unmodified Generated Code

      static void Main() 
      {
         Application.Run(new FormMain());
      }

      public FormMain()
      {
         InitializeComponent();
      }

      protected override void Dispose( bool disposing )
      {
         base.Dispose( disposing );
      }

      #endregion

      #region Windows Form Designer generated code
      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.cmdGetData = new System.Windows.Forms.Button();
         // 
         // cmdGetData
         // 
         this.cmdGetData.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
         this.cmdGetData.Location = new System.Drawing.Point(56, 200);
         this.cmdGetData.Size = new System.Drawing.Size(112, 40);
         this.cmdGetData.Text = "Get Data";
         this.cmdGetData.Click += new System.EventHandler(this.cmdGetData_Click);
         // 
         // FormMain
         // 
         this.Controls.Add(this.cmdGetData);
         this.Text = "Multi Thread";
         this.Load += new System.EventHandler(this.FormMain_Load);

      }
      #endregion

      private void FormMain_Load(object sender, System.EventArgs e)
      {
         mtbPerson = new MultiThreadBox();
         InitializeTheControl(mtbPerson);
      }

      private void cmdGetData_Click(object sender, System.EventArgs e)
      {
         mtbPerson.RequestData();
      }

      #region Cosmetic Utility Routine

      private void InitializeTheControl(MultiThreadBox mtbPerson)
      {
         mtbPerson.Size = new Size(mtbPerson.Width*2, mtbPerson.Height*2);
         mtbPerson.Location = new Point( (this.Width/2) - (mtbPerson.Width/2), 20);
         mtbPerson.Font = new Font(mtbPerson.Font.Name, mtbPerson.Font.Size*2, mtbPerson.Font.Style);
         mtbPerson.Parent = this;
         mtbPerson.Text = string.Empty;
      }
      
      #endregion
   }
}
