// FormMain.cs - Main form for KeyState sample.
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

namespace KeyState
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class FormMain : System.Windows.Forms.Form
   {
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
         // 
         // label1
         // 
         this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
         this.label1.Location = new System.Drawing.Point(16, 16);
         this.label1.Size = new System.Drawing.Size(192, 136);
         this.label1.Text = "This program shows how to tell the difference between rocker input and 4-way inpu" +
            "t on a Pocket PC.";
         // 
         // FormMain
         // 
         this.Controls.Add(this.label1);
         this.Menu = this.mainMenu1;
         this.MinimizeBox = false;
         this.Text = "Key State";
         this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);

      }
      #endregion

      /// <summary>
      /// The main entry point for the application.
      /// </summary>

      static void Main() 
      {
         Application.Run(new FormMain());
      }

      private System.Windows.Forms.Label label1;

      [DllImport("coredll.dll", CharSet=CharSet.Unicode)]
      public static extern short GetAsyncKeyState (Keys vKey);

      private void 
      FormMain_KeyDown(object sender, 
                       System.Windows.Forms.KeyEventArgs e)
      {
         // Detecting the difference between the rocker switch
         // and the 4-way switch can be done in two different
         // ways, one appears within the #if block and a second
         // appears in the #else block.
         // The #if block responds first to the F20 / F21 key
         // code, and then calls GetAsyncKeyState to see the
         // state of the direction key.
         // The #else block looks for the Up / Down key code,
         // and then calls GetAsyncKeyState to see the state
         // of the F20 and F21 keys.
         //
         // Note: The Pocket PC 2002 emulator echoes F21 for 
         // both rocker and 4-way switch; you must run this 
         // code on a smart device to see how rocker and 4-way
         // are handled differently.
#if true
         // Detecting F20 / F21
         if (e.KeyCode == Keys.F21)
         {
            if (GetAsyncKeyState(Keys.Up) < 0)
            {
               MessageBox.Show("Four-Way - Up");
            }
            
            if (GetAsyncKeyState(Keys.Down) < 0)
            {
               MessageBox.Show("Four-Way - Down");
            }
         }
         
         if (e.KeyCode == Keys.F20)
         {
            if (GetAsyncKeyState(Keys.Up) < 0)
            {
               MessageBox.Show("Rocker - Up");
            }
            
            if (GetAsyncKeyState(Keys.Down) < 0)
            {
               MessageBox.Show("Rocker - Down");
            }
         }
#else
         // Detecting Up / Down
         if (e.KeyCode == Keys.Up)
         {
            if (GetAsyncKeyState(Keys.F21) < 0)
            {
               MessageBox.Show("Four-Way - Up");
            }
            if (GetAsyncKeyState(Keys.F20) < 0)
            {
               MessageBox.Show("Rocker - Up");
            }
         }
         
         if (e.KeyCode == Keys.Down)
         {
            if (GetAsyncKeyState(Keys.F21) < 0)
            {
               MessageBox.Show("Four-Way - Down");
            }
            if (GetAsyncKeyState(Keys.F20) < 0)
            {
               MessageBox.Show("Rocker - Down");
            }
         }

#endif

         // Detect Action key
         if (e.KeyCode == Keys.F23)
         {
            MessageBox.Show("Action key");
         }
      } // FormMain_KeyDown

   } // class FormMain 
} // namespace KeyState
