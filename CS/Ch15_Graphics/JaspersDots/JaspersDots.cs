// JaspersDots.cs - Main form for JaspersDots game.
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

namespace JaspersDots
{
   /// <summary>
   /// Summary description for FormMain.
   /// </summary>
   public class FormMain : System.Windows.Forms.Form
   {
      private System.Windows.Forms.MainMenu menuMain;
      private System.Windows.Forms.MenuItem menuItem1;
      private System.Windows.Forms.MenuItem mitemGameNew;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Panel panel2;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Label label_Name1;
      private System.Windows.Forms.Label label_Name2;
      private System.Windows.Forms.Label label_Score1;
      private System.Windows.Forms.Label label_Score2;
      private System.Windows.Forms.Panel panelCurrPlayer;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label labelCurrPlayer;

      public FormMain()
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         // Create dot control.
         m_dot = new DotControl(this);

         // Create and display new game dialog.
         dlgGameNew = new GameNewDialog(this);
         mitemGameNew_Click(this, new EventArgs());
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
         this.menuItem1 = new System.Windows.Forms.MenuItem();
         this.mitemGameNew = new System.Windows.Forms.MenuItem();
         this.panel1 = new System.Windows.Forms.Panel();
         this.label_Score1 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.label_Name1 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.panel2 = new System.Windows.Forms.Panel();
         this.label_Score2 = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.label_Name2 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.panelCurrPlayer = new System.Windows.Forms.Panel();
         this.labelCurrPlayer = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         // 
         // menuMain
         // 
         this.menuMain.MenuItems.Add(this.menuItem1);
         // 
         // menuItem1
         // 
         this.menuItem1.MenuItems.Add(this.mitemGameNew);
         this.menuItem1.Text = "Game";
         // 
         // mitemGameNew
         // 
         this.mitemGameNew.Text = "New Game";
         this.mitemGameNew.Click += new System.EventHandler(this.mitemGameNew_Click);
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.label_Score1);
         this.panel1.Controls.Add(this.label5);
         this.panel1.Controls.Add(this.label_Name1);
         this.panel1.Controls.Add(this.label1);
         this.panel1.Size = new System.Drawing.Size(120, 56);
         // 
         // label_Score1
         // 
         this.label_Score1.Location = new System.Drawing.Point(80, 32);
         this.label_Score1.Size = new System.Drawing.Size(24, 20);
         this.label_Score1.Text = "0";
         // 
         // label5
         // 
         this.label5.Font = new System.Drawing.Font("Tahoma", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
         this.label5.Location = new System.Drawing.Point(24, 32);
         this.label5.Size = new System.Drawing.Size(56, 20);
         this.label5.Text = "Score:";
         // 
         // label_Name1
         // 
         this.label_Name1.Location = new System.Drawing.Point(64, 8);
         this.label_Name1.Size = new System.Drawing.Size(56, 20);
         // 
         // label1
         // 
         this.label1.Font = new System.Drawing.Font("Tahoma", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
         this.label1.Location = new System.Drawing.Point(0, 8);
         this.label1.Size = new System.Drawing.Size(64, 20);
         this.label1.Text = "Player 1:";
         // 
         // panel2
         // 
         this.panel2.Controls.Add(this.label_Score2);
         this.panel2.Controls.Add(this.label6);
         this.panel2.Controls.Add(this.label_Name2);
         this.panel2.Controls.Add(this.label2);
         this.panel2.Location = new System.Drawing.Point(120, 0);
         this.panel2.Size = new System.Drawing.Size(120, 56);
         // 
         // label_Score2
         // 
         this.label_Score2.Location = new System.Drawing.Point(80, 32);
         this.label_Score2.Size = new System.Drawing.Size(24, 20);
         this.label_Score2.Text = "0";
         // 
         // label6
         // 
         this.label6.Font = new System.Drawing.Font("Tahoma", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
         this.label6.Location = new System.Drawing.Point(24, 32);
         this.label6.Size = new System.Drawing.Size(48, 20);
         this.label6.Text = "Score:";
         // 
         // label_Name2
         // 
         this.label_Name2.Location = new System.Drawing.Point(64, 8);
         this.label_Name2.Size = new System.Drawing.Size(64, 20);
         // 
         // label2
         // 
         this.label2.Font = new System.Drawing.Font("Tahoma", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
         this.label2.Location = new System.Drawing.Point(0, 8);
         this.label2.Size = new System.Drawing.Size(64, 20);
         this.label2.Text = "Player 2:";
         // 
         // panelCurrPlayer
         // 
         this.panelCurrPlayer.Controls.Add(this.labelCurrPlayer);
         this.panelCurrPlayer.Controls.Add(this.label3);
         this.panelCurrPlayer.Location = new System.Drawing.Point(0, 56);
         this.panelCurrPlayer.Size = new System.Drawing.Size(240, 16);
         // 
         // labelCurrPlayer
         // 
         this.labelCurrPlayer.Location = new System.Drawing.Point(128, 0);
         // 
         // label3
         // 
         this.label3.Location = new System.Drawing.Point(40, 0);
         this.label3.Size = new System.Drawing.Size(88, 16);
         this.label3.Text = "Current Player:";
         // 
         // FormMain
         // 
         this.Controls.Add(this.panelCurrPlayer);
         this.Controls.Add(this.panel2);
         this.Controls.Add(this.panel1);
         this.Menu = this.menuMain;
         this.MinimizeBox = false;
         this.Text = "Jasper\'s Dots";

      }
      #endregion

      /// <summary>
      /// The main entry point for the application.
      /// </summary>

      static void Main() 
      {
         Application.Run(new FormMain());
      }
      
      public Players players;
      private DotControl m_dot;
      GameNewDialog dlgGameNew;
      int m_CurrentPlayer = 1;

      public int CurrentPlayer
      {
         get
         {
            return m_CurrentPlayer;
         }
         set
         {
            m_CurrentPlayer = value;
            if (m_CurrentPlayer == 1)
            {
               panelCurrPlayer.BackColor = players.clr1;
               labelCurrPlayer.Text = players.strName1;
            }
            else if (m_CurrentPlayer == 2)
            {
               panelCurrPlayer.BackColor = players.clr2;
               labelCurrPlayer.Text = players.strName2;
            }
         }
      }

      public int NextPlayer()
      {
         if (CurrentPlayer == 1)
            CurrentPlayer = 2;
         else
            CurrentPlayer = 1;

         return CurrentPlayer;
      }

      public void DisplayScore(int iPlayer, int iScore)
      {
         if (iPlayer == 1)
         {
            this.label_Score1.Text = iScore.ToString();
         }
         if (iPlayer == 2)
         {
            this.label_Score2.Text = iScore.ToString();
         }
      }

      private void 
      mitemGameNew_Click(object sender, EventArgs e)
      {
         dlgGameNew.ShowDialog();

         this.Focus();
         
         // Initialize display of player info
         label_Name1.Text = players.strName1;
         label_Name2.Text = players.strName2;
         panel1.BackColor = players.clr1;
         panel2.BackColor = players.clr2;

         int cx = dlgGameNew.cxWidth;
         int cy = dlgGameNew.cyHeight;

         // Initialize dot control.
         m_dot.SetPlayerColors(players.clr1, players.clr2);
         m_dot.SetGridSize(cx, cy);

         // Set starting player.
         CurrentPlayer = 1;
         this.BackColor = players.clr1;
      }

   } // class
} // namespace
