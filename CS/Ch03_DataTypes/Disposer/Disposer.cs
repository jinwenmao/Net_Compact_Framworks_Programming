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

namespace Disposer
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class FormMain : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Button cmdCreate;
      private System.Windows.Forms.Button cmdDereference;
      private System.Windows.Forms.Button cmdCollect;
      private System.Windows.Forms.Button cmdDispose;
      private System.Windows.Forms.Button cmdSuppress;
      private System.Windows.Forms.MainMenu mainMenu1;

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
         this.cmdCreate = new System.Windows.Forms.Button();
         this.cmdDereference = new System.Windows.Forms.Button();
         this.cmdCollect = new System.Windows.Forms.Button();
         this.cmdDispose = new System.Windows.Forms.Button();
         this.cmdSuppress = new System.Windows.Forms.Button();
         // 
         // cmdCreate
         // 
         this.cmdCreate.Location = new System.Drawing.Point(24, 40);
         this.cmdCreate.Size = new System.Drawing.Size(128, 20);
         this.cmdCreate.Text = "1) Create Object";
         this.cmdCreate.Click += new System.EventHandler(this.cmdCreate_Click);
         // 
         // cmdDereference
         // 
         this.cmdDereference.Location = new System.Drawing.Point(24, 160);
         this.cmdDereference.Size = new System.Drawing.Size(128, 20);
         this.cmdDereference.Text = "4) DeReference";
         this.cmdDereference.Click += new System.EventHandler(this.cmdDereference_Click);
         // 
         // cmdCollect
         // 
         this.cmdCollect.Location = new System.Drawing.Point(24, 200);
         this.cmdCollect.Size = new System.Drawing.Size(128, 20);
         this.cmdCollect.Text = "5) Garbage Collect";
         this.cmdCollect.Click += new System.EventHandler(this.cmdCollect_Click);
         // 
         // cmdDispose
         // 
         this.cmdDispose.Location = new System.Drawing.Point(24, 80);
         this.cmdDispose.Size = new System.Drawing.Size(128, 20);
         this.cmdDispose.Text = "2) Dispose";
         this.cmdDispose.Click += new System.EventHandler(this.cmdDispose_Click);
         // 
         // cmdSuppress
         // 
         this.cmdSuppress.Location = new System.Drawing.Point(24, 120);
         this.cmdSuppress.Size = new System.Drawing.Size(128, 20);
         this.cmdSuppress.Text = "3) Suppress Finalize";
         this.cmdSuppress.Click += new System.EventHandler(this.cmdSuppress_Click);
         // 
         // FormMain
         // 
         this.Controls.Add(this.cmdSuppress);
         this.Controls.Add(this.cmdDispose);
         this.Controls.Add(this.cmdCollect);
         this.Controls.Add(this.cmdDereference);
         this.Controls.Add(this.cmdCreate);
         this.Menu = this.mainMenu1;
         this.MinimizeBox = false;
         this.Text = "Disposer";

      }
      #endregion

      /// <summary>
      /// The main entry point for the application.
      /// </summary>

      static void Main() 
      {
         Application.Run(new FormMain());
      }

      ResourceWrapper rw = null;

      private void cmdCreate_Click(object sender, EventArgs e)
      {
         rw = new ResourceWrapper();
      }

      private void cmdDispose_Click(object sender, EventArgs e)
      {
         if(rw == null)
            MessageBox.Show("rw == null -> Exception!");
         else
            rw.Dispose();
      }

      private void cmdSuppress_Click(object sender, EventArgs e)
      {
         if(rw == null)
            MessageBox.Show("rw == null -> Exception!");
         else
            GC.SuppressFinalize(rw);
      }

      private void cmdDereference_Click(object sender, EventArgs e)
      {
         rw = null;
      }

      private void cmdCollect_Click(object sender, EventArgs e)
      {
         GC.Collect();
      }


   } // class FormMain

   //
   // Simple resource wrapper class to demonstrate managed-code
   // support for manual cleanup functions
   //
   public class ResourceWrapper : System.Object, IDisposable
   {
      public ResourceWrapper()
      {
         MessageBox.Show("Constructor called");
      }
      ~ResourceWrapper()
      {
         MessageBox.Show("Finalize called");
         Dispose(false);

         // Call Dispose when supported by base class.
         // base.Dispose();
      }
      public void Dispose()
      {
         MessageBox.Show("Public Dispose called");
         Dispose(true);
      }

      protected void Dispose(bool bDisposing)
      {
         if (bDisposing)
            MessageBox.Show("Dispose(true) -- are disposing");
         else
            MessageBox.Show("Dispose(false) -- are finalizing");
      }
   } // class ResourceWrapper

} // namespace
