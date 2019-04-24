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

namespace FormEvents
{
   /// <summary>
   /// Summary description for FormMain.
   /// </summary>
   public class FormMain : System.Windows.Forms.Form
   {
      string strAppName = "Form Events";
      private int m_cEvents;
      private int cEvents
      {
         get { return m_cEvents; }
         set 
         { 
            m_cEvents = value;
            Text = strAppName + " (" 
                              + m_cEvents.ToString() 
                              + ")";
         }
      }
      private bool bShowMouseMove = false;

      private System.Windows.Forms.ListBox lboxEvents;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.CheckBox chkMouseMove;
      private System.Windows.Forms.Button cmdMessageBox;
      private System.Windows.Forms.Button cmdFormFocus;
      private System.Windows.Forms.TextBox textBox2;
      private System.Windows.Forms.Button cmdNothing;
      private System.Windows.Forms.TextBox textBox1;
      private System.Windows.Forms.Label Label1;
      private System.Windows.Forms.Button cmdClear;
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
         this.lboxEvents = new System.Windows.Forms.ListBox();
         this.cmdClear = new System.Windows.Forms.Button();
         this.panel1 = new System.Windows.Forms.Panel();
         this.cmdFormFocus = new System.Windows.Forms.Button();
         this.chkMouseMove = new System.Windows.Forms.CheckBox();
         this.cmdMessageBox = new System.Windows.Forms.Button();
         this.textBox2 = new System.Windows.Forms.TextBox();
         this.cmdNothing = new System.Windows.Forms.Button();
         this.textBox1 = new System.Windows.Forms.TextBox();
         this.Label1 = new System.Windows.Forms.Label();
         // 
         // lboxEvents
         // 
         this.lboxEvents.Location = new System.Drawing.Point(-1, -1);
         this.lboxEvents.Size = new System.Drawing.Size(242, 72);
         // 
         // cmdClear
         // 
         this.cmdClear.Location = new System.Drawing.Point(184, 80);
         this.cmdClear.Size = new System.Drawing.Size(48, 20);
         this.cmdClear.Text = "Clear";
         this.cmdClear.Click += new System.EventHandler(this.cmdReset_Click);
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.cmdFormFocus);
         this.panel1.Controls.Add(this.chkMouseMove);
         this.panel1.Controls.Add(this.lboxEvents);
         this.panel1.Controls.Add(this.cmdClear);
         this.panel1.Size = new System.Drawing.Size(240, 104);
         // 
         // cmdFormFocus
         // 
         this.cmdFormFocus.Location = new System.Drawing.Point(96, 80);
         this.cmdFormFocus.Size = new System.Drawing.Size(80, 20);
         this.cmdFormFocus.Text = "Form Focus";
         this.cmdFormFocus.Click += new System.EventHandler(this.cmdFormFocus_Click);
         // 
         // chkMouseMove
         // 
         this.chkMouseMove.Location = new System.Drawing.Point(4, 80);
         this.chkMouseMove.Size = new System.Drawing.Size(88, 16);
         this.chkMouseMove.Text = "Mouse Move";
         this.chkMouseMove.CheckStateChanged += new System.EventHandler(this.chkMouseMove_CheckStateChanged);
         // 
         // cmdMessageBox
         // 
         this.cmdMessageBox.Location = new System.Drawing.Point(56, 192);
         this.cmdMessageBox.Size = new System.Drawing.Size(120, 24);
         this.cmdMessageBox.Text = "Show MessageBox";
         this.cmdMessageBox.Click += new System.EventHandler(this.cmdMessageBox_Click);
         // 
         // textBox2
         // 
         this.textBox2.Location = new System.Drawing.Point(56, 152);
         this.textBox2.Size = new System.Drawing.Size(168, 22);
         this.textBox2.Text = "textBox2";
         // 
         // cmdNothing
         // 
         this.cmdNothing.Location = new System.Drawing.Point(56, 224);
         this.cmdNothing.Size = new System.Drawing.Size(120, 24);
         this.cmdNothing.Text = "Do Nothing";
         // 
         // textBox1
         // 
         this.textBox1.Location = new System.Drawing.Point(56, 120);
         this.textBox1.Size = new System.Drawing.Size(168, 22);
         this.textBox1.Text = "textBox1";
         // 
         // Label1
         // 
         this.Label1.Location = new System.Drawing.Point(8, 122);
         this.Label1.Size = new System.Drawing.Size(40, 20);
         this.Label1.Text = "Label:";
         // 
         // FormMain
         // 
         this.BackColor = System.Drawing.Color.LightGray;
         this.Controls.Add(this.Label1);
         this.Controls.Add(this.textBox1);
         this.Controls.Add(this.cmdNothing);
         this.Controls.Add(this.textBox2);
         this.Controls.Add(this.cmdMessageBox);
         this.Controls.Add(this.panel1);
         this.Menu = this.mainMenu1;
         this.MinimizeBox = false;
         this.Text = "Form Events";
         this.Disposed += new System.EventHandler(this.FormMain_Disposed);
         this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
         this.Resize += new System.EventHandler(this.FormMain_Resize);
         this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseDown);
         this.EnabledChanged += new System.EventHandler(this.FormMain_EnabledChanged);
         this.Click += new System.EventHandler(this.FormMain_Click);
         this.Closing += new System.ComponentModel.CancelEventHandler(this.FormMain_Closing);
         this.GotFocus += new System.EventHandler(this.FormMain_GotFocus);
         this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormMain_KeyPress);
         this.Load += new System.EventHandler(this.FormMain_Load);
         this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseUp);
         this.Validating += new System.ComponentModel.CancelEventHandler(this.FormMain_Validating);
         this.ParentChanged += new System.EventHandler(this.FormMain_ParentChanged);
         this.Validated += new System.EventHandler(this.FormMain_Validated);
         this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyUp);
         this.Closed += new System.EventHandler(this.FormMain_Closed);
         this.LostFocus += new System.EventHandler(this.FormMain_LostFocus);
         this.Activated += new System.EventHandler(this.FormMain_Activated);
         this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormMain_Paint);
         this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseMove);
         this.TextChanged += new System.EventHandler(this.FormMain_TextChanged);
         this.Deactivate += new System.EventHandler(this.FormMain_Deactivate);

      }
      #endregion

      /// <summary>
      /// The main entry point for the application.
      /// </summary>

      static void Main() 
      {
         Application.Run(new FormMain());
      }

      private void AddItem(string strItem)
      {
         lboxEvents.Items.Add(strItem);
         lboxEvents.SelectedIndex = cEvents;
         cEvents++;
      }

      private void FormMain_Activated(object sender, System.EventArgs e)
      {
         AddItem("FormMain_Activated");
      }

      private void FormMain_Click(object sender, System.EventArgs e)
      {
         AddItem("FormMain_Click");
      }

      private void FormMain_Closed(object sender, System.EventArgs e)
      {
         AddItem("FormMain_Closed");
         MessageBox.Show("FormMain_Closed", strAppName);
      }

      private void FormMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
      {
         AddItem("FormMain_Closing");
         MessageBox.Show("FormMain_Closing", strAppName);
      }

      private void FormMain_Deactivate(object sender, System.EventArgs e)
      {
         AddItem("FormMain_Deactivate");
         //MessageBox.Show("FormMain_Deactivate", strAppName);
      }

      private void FormMain_Disposed(object sender, System.EventArgs e)
      {
         AddItem("FormMain_Disposed");
         MessageBox.Show("FormMain_Disposed", strAppName);
      }

      private void FormMain_EnabledChanged(object sender, System.EventArgs e)
      {
         AddItem("FormMain_EnabledChanged");
      }

      private void FormMain_GotFocus(object sender, System.EventArgs e)
      {
         AddItem("FormMain_GotFocus");
      }

      private void FormMain_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
      {
         string str = "FormMain_KeyDown (";
         if (e.Alt) str += "Alt/";
         if (e.Control) str += "Ctl/";
         if (e.Shift) str += "Sh/";
         str += e.KeyCode.ToString();
         str += ")";
            
         AddItem(str);
      }

      private void FormMain_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
      {
         string str = "FormMain_KeyDown (";
         str += e.KeyChar;
         str += ")";
         AddItem(str);
      }

      private void FormMain_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
      {
         string str = "FormMain_KeyUp (";
         if (e.Alt) str += "Alt/";
         if (e.Control) str += "Ctl/";
         if (e.Shift) str += "Sh/";
         str += e.KeyCode.ToString();
         str += ")";
            
         AddItem(str);
      }

      private void FormMain_Load(object sender, System.EventArgs e)
      {
         AddItem("FormMain_Load");
      }

      private void FormMain_LostFocus(object sender, System.EventArgs e)
      {
         AddItem("FormMain_LostFocus");
      }

      private void FormMain_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
      {
         string str = "FormMain_MouseDown (";
         str += e.X.ToString() + "," + e.Y.ToString();
         str += ")";
         AddItem(str);
      }

      private void FormMain_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
      {
         if (bShowMouseMove)
         {
            string str = "FormMain_MouseMove (";
            str += e.X.ToString() + "," + e.Y.ToString();
            str += ")";
            AddItem(str);
         }
      }

      private void FormMain_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
      {
         string str = "FormMain_MouseUp (";
         str += e.X.ToString() + "," + e.Y.ToString();
         str += ")";
         AddItem(str);
      }

      private void FormMain_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
      {
         AddItem("FormMain_Paint");
      }

      private void FormMain_ParentChanged(object sender, System.EventArgs e)
      {
         AddItem("FormMain_ParentChanged");
      }

      private void FormMain_Resize(object sender, System.EventArgs e)
      {
         string str = "FormMain_Resize (" +
            ClientRectangle.Left.ToString() + "," +
            ClientRectangle.Top.ToString() + "," +
            ClientRectangle.Right.ToString() + "," +
            ClientRectangle.Bottom.ToString() + ")";

         AddItem(str);
      }

      private void FormMain_TextChanged(object sender, System.EventArgs e)
      {
         // Hide this to avoid infinite loops
         // because AddItem changes form's text (caption),
         // which causes this event to occur.
         // AddItem("FormMain_TextChanged");
      }

      private void FormMain_Validated(object sender, System.EventArgs e)
      {
         AddItem("FormMain_Validated");
      }

      private void FormMain_Validating(object sender, System.ComponentModel.CancelEventArgs e)
      {
         AddItem("FormMain_Validating");
      }

      private void cmdReset_Click(object sender, System.EventArgs e)
      {
         lboxEvents.Items.Clear();
         cEvents = 0;
      }

      private void cmdMessageBox_Click(object sender, System.EventArgs e)
      {
         MessageBox.Show("A Message Box", strAppName);
      }

      private void chkMouseMove_CheckStateChanged(object sender, System.EventArgs e)
      {
         bShowMouseMove = chkMouseMove.Checked;
      }

      private void cmdFormFocus_Click(object sender, System.EventArgs e)
      {
         this.Focus();
      }
   }
}
