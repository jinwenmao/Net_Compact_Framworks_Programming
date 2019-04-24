// GameNewDialog.cs - New Game dialog for JaspersDots game.
//
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace JaspersDots
{
   /// <summary>
   /// Summary description for GameNewDialog.
   /// </summary>
   public class GameNewDialog : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox textPlayer1;
      private System.Windows.Forms.TextBox textPlayer2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Panel panel2;
      private System.Windows.Forms.Panel panel3;
      private System.Windows.Forms.Panel panel4;
      private System.Windows.Forms.Panel panel5;
      private System.Windows.Forms.Panel panelA;
      private System.Windows.Forms.Panel panelB;
      private System.Windows.Forms.Panel panelC;
      private System.Windows.Forms.Panel panelD;
      private System.Windows.Forms.Panel panelE;
      public System.Windows.Forms.TextBox textWidth;
      public System.Windows.Forms.TextBox textHeight;
      private System.Windows.Forms.MainMenu mainMenu1;

      private FormMain formParent;

      public GameNewDialog(FormMain form)
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         formParent = form;

         // Set up click handler for player 1 panels
         // Note: Windows Forms Designers does not support this
         // so we have to do it manually.
         panel1.Click += new EventHandler(this.Panel1_Click);
         panel2.Click += new System.EventHandler(this.Panel1_Click);
         panel3.Click += new System.EventHandler(this.Panel1_Click);
         panel4.Click += new System.EventHandler(this.Panel1_Click);
         panel5.Click += new System.EventHandler(this.Panel1_Click);

         // Set up click handler for player 2 panels
         // Note: Windows Forms Designers does not support this
         // so we have to do it manually.
         panelA.Click += new EventHandler(this.Panel2_Click);
         panelB.Click += new System.EventHandler(this.Panel2_Click);
         panelC.Click += new System.EventHandler(this.Panel2_Click);
         panelD.Click += new System.EventHandler(this.Panel2_Click);
         panelE.Click += new System.EventHandler(this.Panel2_Click);
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
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.textPlayer1 = new System.Windows.Forms.TextBox();
         this.textPlayer2 = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.panel1 = new System.Windows.Forms.Panel();
         this.panel2 = new System.Windows.Forms.Panel();
         this.panel3 = new System.Windows.Forms.Panel();
         this.panel4 = new System.Windows.Forms.Panel();
         this.panel5 = new System.Windows.Forms.Panel();
         this.panelA = new System.Windows.Forms.Panel();
         this.panelB = new System.Windows.Forms.Panel();
         this.panelC = new System.Windows.Forms.Panel();
         this.panelD = new System.Windows.Forms.Panel();
         this.panelE = new System.Windows.Forms.Panel();
         this.label5 = new System.Windows.Forms.Label();
         this.textWidth = new System.Windows.Forms.TextBox();
         this.label6 = new System.Windows.Forms.Label();
         this.textHeight = new System.Windows.Forms.TextBox();
         this.mainMenu1 = new System.Windows.Forms.MainMenu();
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(16, 16);
         this.label1.Size = new System.Drawing.Size(88, 20);
         this.label1.Text = "Player 1:";
         // 
         // label2
         // 
         this.label2.Location = new System.Drawing.Point(16, 128);
         this.label2.Size = new System.Drawing.Size(88, 20);
         this.label2.Text = "Player 2:";
         // 
         // textPlayer1
         // 
         this.textPlayer1.Location = new System.Drawing.Point(112, 16);
         this.textPlayer1.Text = "P1";
         // 
         // textPlayer2
         // 
         this.textPlayer2.Location = new System.Drawing.Point(120, 128);
         this.textPlayer2.Size = new System.Drawing.Size(88, 26);
         this.textPlayer2.Text = "P2";
         // 
         // label3
         // 
         this.label3.Location = new System.Drawing.Point(16, 48);
         this.label3.Text = "Pick Color:";
         // 
         // label4
         // 
         this.label4.Location = new System.Drawing.Point(16, 160);
         this.label4.Text = "Pick Color:";
         // 
         // panel1
         // 
         this.panel1.BackColor = System.Drawing.Color.Salmon;
         this.panel1.Location = new System.Drawing.Point(24, 80);
         this.panel1.Size = new System.Drawing.Size(24, 24);
         // 
         // panel2
         // 
         this.panel2.BackColor = System.Drawing.Color.LawnGreen;
         this.panel2.Location = new System.Drawing.Point(64, 80);
         this.panel2.Size = new System.Drawing.Size(24, 24);
         // 
         // panel3
         // 
         this.panel3.BackColor = System.Drawing.Color.CornflowerBlue;
         this.panel3.Location = new System.Drawing.Point(104, 80);
         this.panel3.Size = new System.Drawing.Size(24, 24);
         // 
         // panel4
         // 
         this.panel4.BackColor = System.Drawing.Color.Cyan;
         this.panel4.Location = new System.Drawing.Point(144, 80);
         this.panel4.Size = new System.Drawing.Size(24, 24);
         // 
         // panel5
         // 
         this.panel5.BackColor = System.Drawing.Color.Magenta;
         this.panel5.Location = new System.Drawing.Point(184, 80);
         this.panel5.Size = new System.Drawing.Size(24, 24);
         // 
         // panelA
         // 
         this.panelA.BackColor = System.Drawing.Color.Salmon;
         this.panelA.Location = new System.Drawing.Point(24, 192);
         this.panelA.Size = new System.Drawing.Size(24, 24);
         // 
         // panelB
         // 
         this.panelB.BackColor = System.Drawing.Color.LawnGreen;
         this.panelB.Location = new System.Drawing.Point(64, 192);
         this.panelB.Size = new System.Drawing.Size(24, 24);
         // 
         // panelC
         // 
         this.panelC.BackColor = System.Drawing.Color.CornflowerBlue;
         this.panelC.Location = new System.Drawing.Point(104, 192);
         this.panelC.Size = new System.Drawing.Size(24, 24);
         // 
         // panelD
         // 
         this.panelD.BackColor = System.Drawing.Color.Cyan;
         this.panelD.Location = new System.Drawing.Point(144, 192);
         this.panelD.Size = new System.Drawing.Size(24, 24);
         // 
         // panelE
         // 
         this.panelE.BackColor = System.Drawing.Color.Magenta;
         this.panelE.Location = new System.Drawing.Point(184, 192);
         this.panelE.Size = new System.Drawing.Size(24, 24);
         // 
         // label5
         // 
         this.label5.Location = new System.Drawing.Point(16, 232);
         this.label5.Size = new System.Drawing.Size(72, 20);
         this.label5.Text = "Grid size:";
         // 
         // textWidth
         // 
         this.textWidth.Location = new System.Drawing.Point(88, 232);
         this.textWidth.Size = new System.Drawing.Size(24, 26);
         this.textWidth.Text = "8";
         // 
         // label6
         // 
         this.label6.Location = new System.Drawing.Point(120, 232);
         this.label6.Size = new System.Drawing.Size(24, 20);
         this.label6.Text = "x";
         // 
         // textHeight
         // 
         this.textHeight.Location = new System.Drawing.Point(144, 232);
         this.textHeight.Size = new System.Drawing.Size(24, 26);
         this.textHeight.Text = "8";
         // 
         // GameNewDialog
         // 
         this.Controls.Add(this.textHeight);
         this.Controls.Add(this.label6);
         this.Controls.Add(this.textWidth);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.panelE);
         this.Controls.Add(this.panelD);
         this.Controls.Add(this.panelC);
         this.Controls.Add(this.panelB);
         this.Controls.Add(this.panelA);
         this.Controls.Add(this.panel5);
         this.Controls.Add(this.panel4);
         this.Controls.Add(this.panel3);
         this.Controls.Add(this.panel2);
         this.Controls.Add(this.panel1);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.textPlayer2);
         this.Controls.Add(this.textPlayer1);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Menu = this.mainMenu1;
         this.Text = "Jasper\'s Dots - New Game";
         this.Closing += new System.ComponentModel.CancelEventHandler(this.GameNewDialog_Closing);
         this.Load += new System.EventHandler(this.GameNewDialog_Load);
         this.Closed += new System.EventHandler(this.GameNewDialog_Closed);
         this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameNewDialog_Paint);

      }
      #endregion

      private int iColor1;
      private Color clr1;
      private int iColor2;
      private Color clr2;
      public int cxWidth;
      public int cyHeight;

      private void 
      GameNewDialog_Load(object sender, EventArgs e)
      {
         iColor1 = 0;
         iColor2 = 1;

         formParent.Visible = false;
      }

      private void 
         GameNewDialog_Closed(object sender, EventArgs e)
      {
         formParent.Visible = true;
      }

      private void 
      GameNewDialog_Closing(object sender, CancelEventArgs e)
      {
         // Make sure players each have a different color.
         if (iColor1 == iColor2)
         {
            MessageBox.Show("Players picked the same color.\n" +
               "Please pick a unique color for each player.", 
               "JaspersDots");
            e.Cancel = true;
         }

         // Make sure game board is no larger than 9x11
         int cx;
         int cy;
         try
         {
            cx = int.Parse(textWidth.Text);
         }
         catch
         {
            cx = -1;
         }

         try
         {
            cy = int.Parse(textHeight.Text);
         }
         catch
         {
            cy = -1;
         }

         if (cx <= 0 || cy <= 0)
         {
            MessageBox.Show("Bad grid size -- switching to 8x8", "JaspersDots");
            cx = 8;
            cy = 8;
         }

         if (cx > 11)
         {
            MessageBox.Show("Max width is 11", "JaspersDots");
            e.Cancel = true;
            return;
         }

         if (cy > 9)
         {
            MessageBox.Show("Max height is 9", "JaspersDots");
            e.Cancel = true;
            return;
         }

         cxWidth = cx;
         cyHeight = cy;

         formParent.players = new Players();
         formParent.players.clr1 = clr1;
         formParent.players.clr2 = clr2;
         formParent.players.strName1 = textPlayer1.Text;
         formParent.players.strName2 = textPlayer2.Text;
      }


      private void 
      Panel1_Click(object sender, EventArgs e)
      {
         if (sender == (object)panel1)
            iColor1 = 0;
         else if (sender == (object)panel2)
            iColor1 = 1;
         else if (sender == (object)panel3)
            iColor1 = 2;
         else if (sender == (object)panel4)
            iColor1 = 3;
         else if (sender == (object)panel5)
            iColor1 = 4;
         
         // Redraw window
         Invalidate();
      }

      private void 
      Panel2_Click(object sender, EventArgs e)
      {
         if (sender == (object)panelA)
            iColor2 = 0;
         else if (sender == (object)panelB)
            iColor2 = 1;
         else if (sender == (object)panelC)
            iColor2 = 2;
         else if (sender == (object)panelD)
            iColor2 = 3;
         else if (sender == (object)panelE)
            iColor2 = 4;
         
         // Redraw window
         Invalidate();
      }

      private void 
      GameNewDialog_Paint(object sender, PaintEventArgs e)
      {
         Panel panel = panel1;
         
         //
         // Player 1
         //
         // What is current player 1 panel?
         switch(iColor1)
         {
            case 0: 
               panel = panel1;
               break;
            case 1: 
               panel = panel2;
               break;
            case 2: 
               panel = panel3;
               break;
            case 3: 
               panel = panel4;
               break;
            case 4: 
               panel = panel5;
               break;
         }
         clr1 = panel.BackColor;

         // Draw rectangle around color selected by player 1.
         Pen penBlack = new Pen(Color.Black);
         Rectangle rc = new 
            Rectangle(panel.Left - 3, 
            panel.Top - 3, 
            panel.Width + 5, 
            panel.Height + 5);
         e.Graphics.DrawRectangle(penBlack, rc);
         rc.Inflate(1, 1); 
         e.Graphics.DrawRectangle(penBlack, rc);
         rc.Inflate(1, 1); 
         e.Graphics.DrawRectangle(penBlack, rc);

         //
         // Player 2
         //
         // What is current player 2 panel?
         switch(iColor2)
         {
            case 0:
               panel = panelA;
               break;
            case 1:
               panel = panelB;
               break;
            case 2: 
               panel = panelC;
               break;
            case 3: 
               panel = panelD;
               break;
            case 4: 
               panel = panelE;
               break;
         }
         clr2 = panel.BackColor;

         // Draw rectangle around color selected by player 2.
         rc = new Rectangle(panel.Left - 3, 
            panel.Top - 3, 
            panel.Width + 5, 
            panel.Height + 5);
         e.Graphics.DrawRectangle(penBlack, rc);
         rc.Inflate(1, 1); 
         e.Graphics.DrawRectangle(penBlack, rc);
         rc.Inflate(1, 1); 
         e.Graphics.DrawRectangle(penBlack, rc);
      }

   } // class
} // namespace
