// FormMain.cs - Main form for KeyInput sample.
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

namespace KeyInput
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class FormMain : System.Windows.Forms.Form
   {
      private System.Windows.Forms.TextBox textInput;
      private Microsoft.WindowsCE.Forms.InputPanel sipMain;
      
      private System.Windows.Forms.ListView lviewOutput;
      private System.Windows.Forms.ColumnHeader columnHeader1;
      private System.Windows.Forms.ColumnHeader columnHeader2;
      private System.Windows.Forms.MenuItem menuItem1;
      private System.Windows.Forms.MenuItem mitemEditClear;
      private System.Windows.Forms.ColumnHeader columnHeader3;
      private System.Windows.Forms.ColumnHeader columnHeader4;
      private System.Windows.Forms.ColumnHeader columnHeader5;
      private System.Windows.Forms.MainMenu menuMain;

      // Our data members
      private TextEventSpy textspy;
      private EventHandler m_deleNewEvent;

      public FormMain()
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         // Delegate to be called back when a new event is available.
         m_deleNewEvent = new EventHandler(this.NewEvent);

         // Put our text box (TextEventSpy) in place of 
         // default TextBox
         textspy = new TextEventSpy((Control)this, m_deleNewEvent);
         textspy.Location = textInput.Location;
         textspy.Size = textInput.Size;
         textspy.Text = textInput.Text;
         this.Controls.Add(textspy);
         this.Controls.Remove(textInput);
         
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
         this.textInput = new System.Windows.Forms.TextBox();
         this.sipMain = new Microsoft.WindowsCE.Forms.InputPanel();
         this.menuMain = new System.Windows.Forms.MainMenu();
         this.menuItem1 = new System.Windows.Forms.MenuItem();
         this.mitemEditClear = new System.Windows.Forms.MenuItem();
         this.lviewOutput = new System.Windows.Forms.ListView();
         this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
         // 
         // textInput
         // 
         this.textInput.Location = new System.Drawing.Point(8, 8);
         this.textInput.Size = new System.Drawing.Size(224, 22);
         // 
         // sipMain
         // 
         this.sipMain.EnabledChanged += new System.EventHandler(this.sipMain_EnabledChanged);
         // 
         // menuMain
         // 
         this.menuMain.MenuItems.Add(this.menuItem1);
         // 
         // menuItem1
         // 
         this.menuItem1.MenuItems.Add(this.mitemEditClear);
         this.menuItem1.Text = "Edit";
         // 
         // mitemEditClear
         // 
         this.mitemEditClear.Text = "Clear";
         this.mitemEditClear.Click += new System.EventHandler(this.mitemEditClear_Click);
         // 
         // lviewOutput
         // 
         this.lviewOutput.Columns.Add(this.columnHeader1);
         this.lviewOutput.Columns.Add(this.columnHeader2);
         this.lviewOutput.Columns.Add(this.columnHeader3);
         this.lviewOutput.Columns.Add(this.columnHeader4);
         this.lviewOutput.Columns.Add(this.columnHeader5);
         this.lviewOutput.Location = new System.Drawing.Point(0, 48);
         this.lviewOutput.Size = new System.Drawing.Size(240, 222);
         this.lviewOutput.View = System.Windows.Forms.View.Details;
         // 
         // columnHeader1
         // 
         this.columnHeader1.Text = "Event";
         this.columnHeader1.Width = 60;
         // 
         // columnHeader2
         // 
         this.columnHeader2.Text = "Char";
         this.columnHeader2.Width = 40;
         // 
         // columnHeader3
         // 
         this.columnHeader3.Text = "Code";
         this.columnHeader3.Width = 50;
         // 
         // columnHeader4
         // 
         this.columnHeader4.Text = "Val";
         this.columnHeader4.Width = 40;
         // 
         // columnHeader5
         // 
         this.columnHeader5.Text = "Mod";
         this.columnHeader5.Width = 40;
         // 
         // FormMain
         // 
         this.Controls.Add(this.lviewOutput);
         this.Controls.Add(this.textInput);
         this.Menu = this.menuMain;
         this.MinimizeBox = false;
         this.Text = "Key Input";
         this.Resize += new System.EventHandler(this.sipMain_EnabledChanged);
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

      /// <summary>
      /// NewEvent - delegate.
      /// </summary>
      /// <param name="sender">unused</param>
      /// <param name="e">unused</param>
      private void 
      NewEvent(object sender, System.EventArgs e)
      {
         KeyEventItem kei = textspy.kei;
         string strEvent = "";
         string strChar = "";
         string strCode = "";
         string strValue = "";
         string strMod = "";

         // Fetch event name.
         switch (kei.etype)
         {
            case EventType.Event_KeyDown:   
               strEvent = "KeyDown";
               break;
            case EventType.Event_KeyPress:  
               strEvent = "KeyPress"; 
               break;
            case EventType.Event_KeyUp:     
               strEvent = "KeyUp";    
               break;
            case EventType.Event_GotFocus:  
               strEvent = "GotFocus"; 
               break;
            case EventType.Event_LostFocus: 
               strEvent = "LostFocus"; 
               break;
         }

         // Fill in event details.
         if (kei.etype == EventType.Event_KeyUp ||
             kei.etype == EventType.Event_KeyDown)
         {
            strCode = kei.eUpDown.KeyCode.ToString();
            strValue = kei.eUpDown.KeyValue.ToString();
            strMod   = ((kei.eUpDown.Control) ? "C" : " ") +
                       ((kei.eUpDown.Alt) ? "A" : " ") +
                       ((kei.eUpDown.Shift) ? "S" : " ");
         }

         if (kei.etype == EventType.Event_KeyPress)
         {
            strChar = kei.ePress.KeyChar.ToString();
         }
         
         ListViewItem lvi = new ListViewItem(strEvent);
         lvi.SubItems.Add(strChar);
         lvi.SubItems.Add(strCode);
         lvi.SubItems.Add(strValue);
         lvi.SubItems.Add(strMod);
         lviewOutput.Items.Add(lvi);
         int iItem = lviewOutput.Items.Count - 1;
         lviewOutput.EnsureVisible(iItem);
      }

      private void 
      sipMain_EnabledChanged(object sender, System.EventArgs e)
      {
              // SIP is open
         if (sipMain.Enabled)
         {
            // Adjust list view height to make room for SIP.
            lviewOutput.Height = this.Height - 
               lviewOutput.Top -
               sipMain.Bounds.Height
               + 1;
         }
         else // SIP is closed
         {
            // Adjust scroll bar height to form height.
            lviewOutput.Height = this.Height - 
               lviewOutput.Top
               + 1;
         }
      }

      private void mitemEditClear_Click(object sender, System.EventArgs e)
      {
         textspy.Text = string.Empty;
         lviewOutput.Items.Clear();
         textspy.Focus();
      }

      private void FormMain_GotFocus(object sender, System.EventArgs e)
      {
         // When we get focus, set focus to textbox.
         textspy.Focus();
      }
   }
}
