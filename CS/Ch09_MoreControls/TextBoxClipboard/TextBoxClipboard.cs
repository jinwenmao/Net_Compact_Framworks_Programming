// TextBoxClipboard.cs - FormMain class and EventGrabberWindow
// class to support context menu in a text box.
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
using Microsoft.WindowsCE.Forms;
using YaoDurant.Controls;

namespace TextBoxClipboard
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class FormMain : System.Windows.Forms.Form
   {
      private System.Windows.Forms.MenuItem mitemCut;
      private System.Windows.Forms.MenuItem mitemCopy;
      private System.Windows.Forms.MenuItem mitemPaste;
      private System.Windows.Forms.MenuItem menuItem1;
      private System.Windows.Forms.MenuItem mitemClear;
      private System.Windows.Forms.TextBox textEditor;
      private System.Windows.Forms.ContextMenu cmenuClipboard;
      private System.Windows.Forms.MainMenu menuMain;
      private System.Windows.Forms.MenuItem menuItem2;
      private System.Windows.Forms.MenuItem mitemEditCut;
      private System.Windows.Forms.MenuItem mitemEditCopy;
      private System.Windows.Forms.MenuItem mitemEditPaste;
      private System.Windows.Forms.MenuItem menuItem6;
      private System.Windows.Forms.MenuItem mitemEditClear;
      private System.Windows.Forms.MenuItem mitemEditUndo;
      private Microsoft.WindowsCE.Forms.InputPanel sipMain;
      private System.Windows.Forms.MenuItem mitemUndo;

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
         this.menuMain = new System.Windows.Forms.MainMenu();
         this.menuItem2 = new System.Windows.Forms.MenuItem();
         this.mitemEditCut = new System.Windows.Forms.MenuItem();
         this.mitemEditCopy = new System.Windows.Forms.MenuItem();
         this.mitemEditPaste = new System.Windows.Forms.MenuItem();
         this.menuItem6 = new System.Windows.Forms.MenuItem();
         this.mitemEditClear = new System.Windows.Forms.MenuItem();
         this.mitemEditUndo = new System.Windows.Forms.MenuItem();
         this.cmenuClipboard = new System.Windows.Forms.ContextMenu();
         this.mitemCut = new System.Windows.Forms.MenuItem();
         this.mitemCopy = new System.Windows.Forms.MenuItem();
         this.mitemPaste = new System.Windows.Forms.MenuItem();
         this.menuItem1 = new System.Windows.Forms.MenuItem();
         this.mitemClear = new System.Windows.Forms.MenuItem();
         this.mitemUndo = new System.Windows.Forms.MenuItem();
         this.textEditor = new System.Windows.Forms.TextBox();
         this.sipMain = new Microsoft.WindowsCE.Forms.InputPanel();
         // 
         // menuMain
         // 
         this.menuMain.MenuItems.Add(this.menuItem2);
         // 
         // menuItem2
         // 
         this.menuItem2.MenuItems.Add(this.mitemEditCut);
         this.menuItem2.MenuItems.Add(this.mitemEditCopy);
         this.menuItem2.MenuItems.Add(this.mitemEditPaste);
         this.menuItem2.MenuItems.Add(this.menuItem6);
         this.menuItem2.MenuItems.Add(this.mitemEditClear);
         this.menuItem2.MenuItems.Add(this.mitemEditUndo);
         this.menuItem2.Text = "Edit";
         // 
         // mitemEditCut
         // 
         this.mitemEditCut.Text = "Cut";
         this.mitemEditCut.Click += new System.EventHandler(this.mitemCut_Click);
         // 
         // mitemEditCopy
         // 
         this.mitemEditCopy.Text = "Copy";
         this.mitemEditCopy.Click += new System.EventHandler(this.mitemCopy_Click);
         // 
         // mitemEditPaste
         // 
         this.mitemEditPaste.Text = "Paste";
         this.mitemEditPaste.Click += new System.EventHandler(this.mitemPaste_Click);
         // 
         // menuItem6
         // 
         this.menuItem6.Text = "-";
         // 
         // mitemEditClear
         // 
         this.mitemEditClear.Text = "Clear";
         this.mitemEditClear.Click += new System.EventHandler(this.mitemClear_Click);
         // 
         // mitemEditUndo
         // 
         this.mitemEditUndo.Text = "Undo";
         this.mitemEditUndo.Click += new System.EventHandler(this.mitemUndo_Click);
         // 
         // cmenuClipboard
         // 
         this.cmenuClipboard.MenuItems.Add(this.mitemCut);
         this.cmenuClipboard.MenuItems.Add(this.mitemCopy);
         this.cmenuClipboard.MenuItems.Add(this.mitemPaste);
         this.cmenuClipboard.MenuItems.Add(this.menuItem1);
         this.cmenuClipboard.MenuItems.Add(this.mitemClear);
         this.cmenuClipboard.MenuItems.Add(this.mitemUndo);
         // 
         // mitemCut
         // 
         this.mitemCut.Text = "Cut";
         this.mitemCut.Click += new System.EventHandler(this.mitemCut_Click);
         // 
         // mitemCopy
         // 
         this.mitemCopy.Text = "Copy";
         this.mitemCopy.Click += new System.EventHandler(this.mitemCopy_Click);
         // 
         // mitemPaste
         // 
         this.mitemPaste.Text = "Paste";
         this.mitemPaste.Click += new System.EventHandler(this.mitemPaste_Click);
         // 
         // menuItem1
         // 
         this.menuItem1.Text = "-";
         // 
         // mitemClear
         // 
         this.mitemClear.Text = "Clear";
         this.mitemClear.Click += new System.EventHandler(this.mitemClear_Click);
         // 
         // mitemUndo
         // 
         this.mitemUndo.Text = "Undo";
         this.mitemUndo.Click += new System.EventHandler(this.mitemUndo_Click);
         // 
         // textEditor
         // 
         this.textEditor.AcceptsReturn = true;
         this.textEditor.ContextMenu = this.cmenuClipboard;
         this.textEditor.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
         this.textEditor.Location = new System.Drawing.Point(-1, -1);
         this.textEditor.Multiline = true;
         this.textEditor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
         this.textEditor.Size = new System.Drawing.Size(100, 100);
         this.textEditor.Text = "";
         // 
         // sipMain
         // 
         this.sipMain.EnabledChanged += new System.EventHandler(this.sipMain_EnabledChanged);
         // 
         // FormMain
         // 
         this.Controls.Add(this.textEditor);
         this.Menu = this.menuMain;
         this.MinimizeBox = false;
         this.Text = "TextBoxClipboard";
         this.Load += new System.EventHandler(this.FormMain_Load);
         this.Closed += new System.EventHandler(this.FormMain_Closed);

      }
      #endregion

      /// <summary>
      /// The main entry point for the application.
      /// </summary>

      static void Main() 
      {
         Application.Run(new FormMain());
      }

      //--------------------------------------------------------
      private EventGrabberWindow m_emw;   // Gets grabbed msgs
      private EventGrabber m_eg;          // Event grabber
      private Microsoft.WindowsCE.Forms.Message m_msg;

      // Event grabber flags
      public const int EVENT_KEYDOWN = 0x0001;
      public const int EVENT_KEYPRESS = 0x0002;
      public const int EVENT_KEYUP = 0x0004;
      public const int EVENT_MOUSEDOWN = 0x0008;
      public const int EVENT_MOUSEMOVE = 0x0010;
      public const int EVENT_MOUSEUP = 0x0020;

      // Clipboard messages
      public const int WM_CUT = 0x0300;
      public const int WM_COPY = 0x0301;
      public const int WM_PASTE = 0x0302;
      public const int WM_CLEAR = 0x0303;
      public const int WM_UNDO = 0x0304;

      // P/Invoke declaration
      [DllImport("coredll.dll", CharSet=CharSet.Unicode)]
      public static extern IntPtr GetFocus();

      private void FormMain_Load(
         object sender, 
         System.EventArgs e)
      {
         // Textbox origin is (-1,-1)
         // Adjust textbox size to available screen space.
         // Add *two* to hide right and bottom borders.
         textEditor.Width = this.Width + 2;
         SetEditorHeight();

         // Set focus to text box window.
         textEditor.Focus();

         // Fetch window handle of text box.
         IntPtr hwndEditor = GetFocus();

         // Create message structure for sending Win32 messages
         m_msg = Message.Create(hwndEditor, 0, IntPtr.Zero, 
            IntPtr.Zero);

         // MessageWindow-derived object receives MouseDown
         m_emw = new EventGrabberWindow(textEditor, hwndEditor);

         // Event grabber sends MouseDown event
         m_eg = new EventGrabber(hwndEditor, m_emw, 
            EVENT_MOUSEDOWN );
      }

      private void FormMain_Closed(
         object sender, 
         System.EventArgs e)
      {
         // Clean up event grabber.
         m_eg.Dispose();
      }

      private void SetEditorHeight()
      {
         if (sipMain.Enabled)
            textEditor.Height = sipMain.VisibleDesktop.Height + 2;
         else
            textEditor.Height = this.Height + 2;
      }

      private void sipMain_EnabledChanged(
         object sender, 
         System.EventArgs e)
      {
         SetEditorHeight();
      }

      private void mitemCut_Click(
         object sender, 
         System.EventArgs e)
      {
         m_msg.Msg = WM_CUT; // WM_CUT does not work...

         // ...and yet Copy & Clear work, so we do that instead
         m_msg.Msg = WM_COPY;
         MessageWindow.SendMessage(ref m_msg);
         m_msg.Msg = WM_CLEAR;
         MessageWindow.SendMessage(ref m_msg);
      }

      private void mitemCopy_Click(
      object sender, 
      System.EventArgs e)
      {
         m_msg.Msg = WM_COPY;
         MessageWindow.SendMessage(ref m_msg);
      }

      private void mitemPaste_Click(
         object sender, 
         System.EventArgs e)
      {
         m_msg.Msg = WM_PASTE;
         MessageWindow.SendMessage(ref m_msg);
      }

      private void mitemClear_Click(
         object sender, 
         System.EventArgs e)
      {
         m_msg.Msg = WM_CLEAR;
         MessageWindow.SendMessage(ref m_msg);
      }

      private void mitemUndo_Click(
         object sender, 
         System.EventArgs e)
      {
         m_msg.Msg = WM_UNDO;
         MessageWindow.SendMessage(ref m_msg);
      }

   } // FormMain class

   //-----------------------------------------------------------
   // MessageWindow-derived class to support grabbing the
   // WM_LBUTTONDOWN message (or MouseDown event) from the
   // text box.
   //-----------------------------------------------------------
   class EventGrabberWindow : MessageWindow
   {
      private Control m_ctrlTarget;
      private IntPtr m_hwndTarget;

      public EventGrabberWindow(
         Control ctrlTarget,
         IntPtr hwndTarget)
      {
         m_ctrlTarget = ctrlTarget;
         m_hwndTarget = hwndTarget;
      }

      // Message values
      public const int WM_MOUSEMOVE = 0x0200;
      public const int WM_LBUTTONDOWN = 0x0201;
      public const int WM_LBUTTONUP = 0x0202;
      public const int WM_KEYDOWN = 0x0100;
      public const int WM_KEYUP = 0x0101;
      public const int WM_CHAR = 0x0102;

      // Start -- SHRecognizeGesture declarations.
      [DllImport("AygShell.dll", CharSet=CharSet.Unicode)]
      public static extern int SHRecognizeGesture (
         ref SHRGINFO shrg);
      public struct SHRGINFO
      {
         public int cbSize;
         public IntPtr hwndClient;
         public System.Drawing.Point ptDown;
         public int dwFlags;
      };
      public const int GN_CONTEXTMENU = 1000;
      public const int SHRG_RETURNCMD = 0x00000001;
      // End -- SHRecognizeGesture declarations.

      protected override void WndProc(
         ref Microsoft.WindowsCE.Forms.Message msg)
      {
         switch (msg.Msg)
         {
            case WM_MOUSEMOVE:
               break;

            case WM_LBUTTONDOWN:
               int xyBundle = (int)msg.LParam;
               int x = xyBundle & 0xffff;
               int y = (xyBundle >> 16);

               SHRGINFO    shinfo;
               shinfo = new SHRGINFO();
               shinfo.cbSize = Marshal.SizeOf(shinfo);
               shinfo.hwndClient = m_hwndTarget;
               shinfo.ptDown.X = x;
               shinfo.ptDown.Y = y;
               shinfo.dwFlags = SHRG_RETURNCMD;

               if (SHRecognizeGesture(ref shinfo) == GN_CONTEXTMENU) 
               {
                  Point pt = new Point(x,y);
                  Point pt2 = m_ctrlTarget.PointToScreen(pt);
                  m_ctrlTarget.ContextMenu.Show(m_ctrlTarget, pt2);
                  
                  // We handle event.
                  // Do not pass to original wndproc
                  msg.Result = IntPtr.Zero;
               }
               else
               {
                  // Tell handler to send to original wndproc
                  msg.Result = (IntPtr)1;
               }
               break;

            case WM_LBUTTONUP:
               break;

            case WM_KEYDOWN:
               break;

            case WM_KEYUP:
               break;

            case WM_CHAR:
               break;
         } // switch
      } // WndProc
   } // EventMessageWindow class
} // namespace
