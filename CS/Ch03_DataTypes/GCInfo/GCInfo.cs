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
using System.Runtime.InteropServices;

namespace GCInfo
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class FormMain : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label labMaxGenerations;
      private System.Windows.Forms.Button cmdCollect;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label labTotalMemory;
      private System.Windows.Forms.Button cmdWaitForFinalizers;
      private System.Windows.Forms.Button cmdAllocFree;
      private System.Windows.Forms.TextBox textNumObjects;
      private System.Windows.Forms.ComboBox cboxObjects;
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
         int c = GC.MaxGeneration;
         labMaxGenerations.Text = c.ToString();
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
         this.labMaxGenerations = new System.Windows.Forms.Label();
         this.cmdCollect = new System.Windows.Forms.Button();
         this.button1 = new System.Windows.Forms.Button();
         this.label2 = new System.Windows.Forms.Label();
         this.labTotalMemory = new System.Windows.Forms.Label();
         this.cmdWaitForFinalizers = new System.Windows.Forms.Button();
         this.cmdAllocFree = new System.Windows.Forms.Button();
         this.textNumObjects = new System.Windows.Forms.TextBox();
         this.cboxObjects = new System.Windows.Forms.ComboBox();
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(16, 16);
         this.label1.Text = "MaxGeneration:";
         this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // labMaxGenerations
         // 
         this.labMaxGenerations.Location = new System.Drawing.Point(128, 16);
         this.labMaxGenerations.Size = new System.Drawing.Size(40, 20);
         // 
         // cmdCollect
         // 
         this.cmdCollect.Location = new System.Drawing.Point(24, 48);
         this.cmdCollect.Size = new System.Drawing.Size(120, 20);
         this.cmdCollect.Text = "Collect";
         this.cmdCollect.Click += new System.EventHandler(this.cmdCollect_Click);
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(24, 88);
         this.button1.Size = new System.Drawing.Size(120, 20);
         this.button1.Text = "GetTotalMemory";
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // label2
         // 
         this.label2.Location = new System.Drawing.Point(32, 120);
         this.label2.Size = new System.Drawing.Size(88, 20);
         this.label2.Text = "Total Memory:";
         // 
         // labTotalMemory
         // 
         this.labTotalMemory.Location = new System.Drawing.Point(128, 120);
         this.labTotalMemory.Size = new System.Drawing.Size(64, 20);
         // 
         // cmdWaitForFinalizers
         // 
         this.cmdWaitForFinalizers.Location = new System.Drawing.Point(24, 152);
         this.cmdWaitForFinalizers.Size = new System.Drawing.Size(168, 20);
         this.cmdWaitForFinalizers.Text = "WaitForPendingFinalizers";
         this.cmdWaitForFinalizers.Click += new System.EventHandler(this.cmdWaitForFinalizers_Click);
         // 
         // cmdAllocFree
         // 
         this.cmdAllocFree.Enabled = false;
         this.cmdAllocFree.Location = new System.Drawing.Point(40, 232);
         this.cmdAllocFree.Text = "Allocate";
         this.cmdAllocFree.Click += new System.EventHandler(this.cmdAllocFree_Click);
         // 
         // textNumObjects
         // 
         this.textNumObjects.Location = new System.Drawing.Point(40, 192);
         this.textNumObjects.Size = new System.Drawing.Size(48, 22);
         this.textNumObjects.Text = "";
         this.textNumObjects.TextChanged += new System.EventHandler(this.textNumObjects_TextChanged);
         // 
         // cboxObjects
         // 
         this.cboxObjects.Items.Add("Brushes");
         this.cboxObjects.Items.Add("Controls");
         this.cboxObjects.Items.Add("Graphics");
         this.cboxObjects.Items.Add("Integers (in Array)");
         this.cboxObjects.Items.Add("Longs (In Array)");
         this.cboxObjects.Location = new System.Drawing.Point(104, 192);
         this.cboxObjects.Size = new System.Drawing.Size(112, 22);
         this.cboxObjects.SelectedIndexChanged += new System.EventHandler(this.cboxObjects_SelectedIndexChanged);
         // 
         // FormMain
         // 
         this.Controls.Add(this.cboxObjects);
         this.Controls.Add(this.textNumObjects);
         this.Controls.Add(this.cmdAllocFree);
         this.Controls.Add(this.cmdWaitForFinalizers);
         this.Controls.Add(this.labTotalMemory);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.cmdCollect);
         this.Controls.Add(this.labMaxGenerations);
         this.Controls.Add(this.label1);
         this.Menu = this.mainMenu1;
         this.MinimizeBox = false;
         this.Text = "GC Info";

      }
      #endregion

      /// <summary>
      /// The main entry point for the application.
      /// </summary>

      static void Main() 
      {
         Application.Run(new FormMain());
      }

      private void cmdCollect_Click(object sender, System.EventArgs e)
      {
         GC.Collect();
      }

      private void button1_Click(object sender, System.EventArgs e)
      {
         long lmem = GC.GetTotalMemory(false);
         labTotalMemory.Text = lmem.ToString("D");
      }

      private void cmdWaitForFinalizers_Click(object sender, System.EventArgs e)
      {
         GC.WaitForPendingFinalizers();
      }

      private int cObjects = 0;
      private int iItem = -1;
      private bool bAllocate = true;

      private void SetButtonState()
      {
         cmdAllocFree.Enabled = (iItem >= -1 && cObjects > 0);
      }

      private void textNumObjects_TextChanged(object sender, System.EventArgs e)
      {
         try
         {
            cObjects = int.Parse(textNumObjects.Text);
         }
         catch
         {
            cObjects = 0;
         }

         SetButtonState();
      }

      private void cboxObjects_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         iItem = cboxObjects.SelectedIndex;
         SetButtonState();
      }

      Brush [] abr = null;
      Control [] actrl = null;
      Graphics [] ag = null;
      int [] ai = null;
      long [] al = null;

      private void cmdAllocFree_Click(object sender, System.EventArgs e)
      {
         if (bAllocate)
         {
            bAllocate = false;
            cmdAllocFree.Text = "Free";
            cboxObjects.Enabled = false;
            object objCurrent = null;
            int cbObject = 0;
            int i;
            switch (iItem)
            {
               case 0:
                  abr = new SolidBrush [cObjects];
                  objCurrent = abr;
                  cbObject = Marshal.SizeOf(abr[0].GetType());
                  break;
               case 1:
                  actrl = new Control [cObjects];
                  objCurrent = actrl;
                  cbObject = Marshal.SizeOf(actrl[0].GetType());
                  break;
               case 2:
                  ag = new Graphics[cObjects];
                  objCurrent = ag;
                  cbObject = Marshal.SizeOf(ag[0].GetType());
                  break;
               case 3:
                  ai = new int[cObjects];
                  for (i = 0; i < cObjects; i++)
                     ai[i] = i + 3;
                  objCurrent = ai;
                  cbObject = Marshal.SizeOf(ai[0].GetType());
                  break;
               case 4:
                  al = new long[cObjects];
                  objCurrent = al;
                  cbObject = Marshal.SizeOf(al[0].GetType());
                  break;
            }
            
            int cbTot = cbObject * cObjects;
            MessageBox.Show("Allocated " + cbTot.ToString() + " bytes");
         }
         else
         {
            bAllocate = true;
            cmdAllocFree.Text = "Allocate";
            cboxObjects.Enabled = true;
            abr = null;
            actrl = null;
            ag = null;
            ai = null;
            al = null;
            MessageBox.Show("Freed stuff");
         }
      }

   } // class
} // namespace
