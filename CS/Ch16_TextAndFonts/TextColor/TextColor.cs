// TextColor.cs - Main user-interface for TextColor sample.
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
using YaoDurant.Drawing;

namespace TextColor
{
   /// <summary>
   /// Summary description for FormMain.
   /// </summary>
   public class FormMain : System.Windows.Forms.Form
   {
      private System.Windows.Forms.MainMenu menuMain;
      private System.Windows.Forms.MenuItem mitemTextPopup;
      private System.Windows.Forms.MenuItem mitemTextSetColor;
      private System.Windows.Forms.MenuItem mitemBackgroundPopup;
      private System.Windows.Forms.MenuItem mitemBackgroundSetColor;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label lblTextR;
      private System.Windows.Forms.Label lblTextG;
      private System.Windows.Forms.Label lblTextB;
      private System.Windows.Forms.Label lblBackR;
      private System.Windows.Forms.Label lblBackG;
      private System.Windows.Forms.MenuItem menuItem1;
      private System.Windows.Forms.MenuItem mitemTextControlText;
      private System.Windows.Forms.MenuItem mitemTextGrayText;
      private System.Windows.Forms.MenuItem mitemTextHighlightText;
      private System.Windows.Forms.MenuItem mitemTextInfoText;
      private System.Windows.Forms.MenuItem mitemTextMenuText;
      private System.Windows.Forms.MenuItem mitemTextWindowText;
      private System.Windows.Forms.MenuItem menuItem8;
      private System.Windows.Forms.MenuItem mitemTextAliceBlue;
      private System.Windows.Forms.MenuItem mitemTextBeige;
      private System.Windows.Forms.MenuItem mitemTextCoral;
      private System.Windows.Forms.MenuItem mitemTextDeepPink;
      private System.Windows.Forms.MenuItem mitemTextFireBrick;
      private System.Windows.Forms.MenuItem mitemTextGainsboro;
      private System.Windows.Forms.MenuItem mitemTextHoneyDew;
      private System.Windows.Forms.MenuItem menuItem2;
      private System.Windows.Forms.MenuItem mitemBackControl;
      private System.Windows.Forms.MenuItem mitemBackHighlight;
      private System.Windows.Forms.MenuItem mitemBackInfo;
      private System.Windows.Forms.MenuItem mitemBackMenu;
      private System.Windows.Forms.MenuItem mitemBackWindow;
      private System.Windows.Forms.MenuItem menuItem9;
      private System.Windows.Forms.MenuItem mitemBackIndigo;
      private System.Windows.Forms.MenuItem mitemBackKhaki;
      private System.Windows.Forms.MenuItem mitemBackMagenta;
      private System.Windows.Forms.MenuItem mitemBackNavy;
      private System.Windows.Forms.MenuItem mitemBackOlive;
      private System.Windows.Forms.MenuItem mitemBackPlum;
      private System.Windows.Forms.MenuItem mitemBackLavender;
      private System.Windows.Forms.Label lblBackB;

      public FormMain()
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         DisplayRGBComponents();
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
         this.mitemTextPopup = new System.Windows.Forms.MenuItem();
         this.mitemTextSetColor = new System.Windows.Forms.MenuItem();
         this.mitemBackgroundPopup = new System.Windows.Forms.MenuItem();
         this.mitemBackgroundSetColor = new System.Windows.Forms.MenuItem();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.lblTextB = new System.Windows.Forms.Label();
         this.lblTextG = new System.Windows.Forms.Label();
         this.lblTextR = new System.Windows.Forms.Label();
         this.lblBackB = new System.Windows.Forms.Label();
         this.lblBackG = new System.Windows.Forms.Label();
         this.lblBackR = new System.Windows.Forms.Label();
         this.menuItem1 = new System.Windows.Forms.MenuItem();
         this.mitemTextControlText = new System.Windows.Forms.MenuItem();
         this.mitemTextGrayText = new System.Windows.Forms.MenuItem();
         this.mitemTextHighlightText = new System.Windows.Forms.MenuItem();
         this.mitemTextInfoText = new System.Windows.Forms.MenuItem();
         this.mitemTextMenuText = new System.Windows.Forms.MenuItem();
         this.mitemTextWindowText = new System.Windows.Forms.MenuItem();
         this.menuItem8 = new System.Windows.Forms.MenuItem();
         this.mitemTextAliceBlue = new System.Windows.Forms.MenuItem();
         this.mitemTextBeige = new System.Windows.Forms.MenuItem();
         this.mitemTextCoral = new System.Windows.Forms.MenuItem();
         this.mitemTextDeepPink = new System.Windows.Forms.MenuItem();
         this.mitemTextFireBrick = new System.Windows.Forms.MenuItem();
         this.mitemTextGainsboro = new System.Windows.Forms.MenuItem();
         this.mitemTextHoneyDew = new System.Windows.Forms.MenuItem();
         this.menuItem2 = new System.Windows.Forms.MenuItem();
         this.mitemBackControl = new System.Windows.Forms.MenuItem();
         this.mitemBackHighlight = new System.Windows.Forms.MenuItem();
         this.mitemBackInfo = new System.Windows.Forms.MenuItem();
         this.mitemBackMenu = new System.Windows.Forms.MenuItem();
         this.mitemBackWindow = new System.Windows.Forms.MenuItem();
         this.menuItem9 = new System.Windows.Forms.MenuItem();
         this.mitemBackIndigo = new System.Windows.Forms.MenuItem();
         this.mitemBackKhaki = new System.Windows.Forms.MenuItem();
         this.mitemBackLavender = new System.Windows.Forms.MenuItem();
         this.mitemBackMagenta = new System.Windows.Forms.MenuItem();
         this.mitemBackNavy = new System.Windows.Forms.MenuItem();
         this.mitemBackOlive = new System.Windows.Forms.MenuItem();
         this.mitemBackPlum = new System.Windows.Forms.MenuItem();
         // 
         // menuMain
         // 
         this.menuMain.MenuItems.Add(this.mitemTextPopup);
         this.menuMain.MenuItems.Add(this.mitemBackgroundPopup);
         // 
         // mitemTextPopup
         // 
         this.mitemTextPopup.MenuItems.Add(this.mitemTextSetColor);
         this.mitemTextPopup.MenuItems.Add(this.menuItem1);
         this.mitemTextPopup.MenuItems.Add(this.menuItem8);
         this.mitemTextPopup.Text = "Text";
         // 
         // mitemTextSetColor
         // 
         this.mitemTextSetColor.Text = "Set Color...";
         this.mitemTextSetColor.Click += new System.EventHandler(this.mitemTextSetColor_Click);
         // 
         // mitemBackgroundPopup
         // 
         this.mitemBackgroundPopup.MenuItems.Add(this.mitemBackgroundSetColor);
         this.mitemBackgroundPopup.MenuItems.Add(this.menuItem2);
         this.mitemBackgroundPopup.MenuItems.Add(this.menuItem9);
         this.mitemBackgroundPopup.Text = "Background";
         // 
         // mitemBackgroundSetColor
         // 
         this.mitemBackgroundSetColor.Text = "Set Color...";
         this.mitemBackgroundSetColor.Click += new System.EventHandler(this.mitemBackgroundSetColor_Click);
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(36, 152);
         this.label1.Size = new System.Drawing.Size(40, 20);
         this.label1.Text = "Text:";
         this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // label2
         // 
         this.label2.Location = new System.Drawing.Point(0, 176);
         this.label2.Size = new System.Drawing.Size(80, 20);
         this.label2.Text = "Background:";
         this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // label3
         // 
         this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
         this.label3.Location = new System.Drawing.Point(88, 128);
         this.label3.Size = new System.Drawing.Size(40, 20);
         this.label3.Text = "Red";
         // 
         // label4
         // 
         this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
         this.label4.Location = new System.Drawing.Point(120, 128);
         this.label4.Size = new System.Drawing.Size(48, 20);
         this.label4.Text = "Green";
         // 
         // label5
         // 
         this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
         this.label5.Location = new System.Drawing.Point(168, 128);
         this.label5.Size = new System.Drawing.Size(40, 20);
         this.label5.Text = "Blue";
         // 
         // lblTextB
         // 
         this.lblTextB.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
         this.lblTextB.Location = new System.Drawing.Point(168, 152);
         this.lblTextB.Size = new System.Drawing.Size(40, 20);
         // 
         // lblTextG
         // 
         this.lblTextG.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
         this.lblTextG.Location = new System.Drawing.Point(128, 152);
         this.lblTextG.Size = new System.Drawing.Size(40, 20);
         // 
         // lblTextR
         // 
         this.lblTextR.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
         this.lblTextR.Location = new System.Drawing.Point(88, 152);
         this.lblTextR.Size = new System.Drawing.Size(40, 20);
         // 
         // lblBackB
         // 
         this.lblBackB.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
         this.lblBackB.Location = new System.Drawing.Point(168, 176);
         this.lblBackB.Size = new System.Drawing.Size(40, 20);
         // 
         // lblBackG
         // 
         this.lblBackG.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
         this.lblBackG.Location = new System.Drawing.Point(128, 176);
         this.lblBackG.Size = new System.Drawing.Size(40, 20);
         // 
         // lblBackR
         // 
         this.lblBackR.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
         this.lblBackR.Location = new System.Drawing.Point(88, 176);
         this.lblBackR.Size = new System.Drawing.Size(40, 20);
         // 
         // menuItem1
         // 
         this.menuItem1.MenuItems.Add(this.mitemTextControlText);
         this.menuItem1.MenuItems.Add(this.mitemTextGrayText);
         this.menuItem1.MenuItems.Add(this.mitemTextHighlightText);
         this.menuItem1.MenuItems.Add(this.mitemTextInfoText);
         this.menuItem1.MenuItems.Add(this.mitemTextMenuText);
         this.menuItem1.MenuItems.Add(this.mitemTextWindowText);
         this.menuItem1.Text = "System Colors";
         // 
         // mitemTextControlText
         // 
         this.mitemTextControlText.Text = "ControlText";
         this.mitemTextControlText.Click += new System.EventHandler(this.mitemTextControlText_Click);
         // 
         // mitemTextGrayText
         // 
         this.mitemTextGrayText.Text = "GrayText";
         this.mitemTextGrayText.Click += new System.EventHandler(this.mitemTextGrayText_Click);
         // 
         // mitemTextHighlightText
         // 
         this.mitemTextHighlightText.Text = "HighlightText";
         this.mitemTextHighlightText.Click += new System.EventHandler(this.mitemTextHighlightText_Click);
         // 
         // mitemTextInfoText
         // 
         this.mitemTextInfoText.Text = "InfoText";
         this.mitemTextInfoText.Click += new System.EventHandler(this.mitemTextInfoText_Click);
         // 
         // mitemTextMenuText
         // 
         this.mitemTextMenuText.Text = "MenuText";
         this.mitemTextMenuText.Click += new System.EventHandler(this.mitemTextMenuText_Click);
         // 
         // mitemTextWindowText
         // 
         this.mitemTextWindowText.Text = "WindowText";
         this.mitemTextWindowText.Click += new System.EventHandler(this.mitemTextWindowText_Click);
         // 
         // menuItem8
         // 
         this.menuItem8.MenuItems.Add(this.mitemTextAliceBlue);
         this.menuItem8.MenuItems.Add(this.mitemTextBeige);
         this.menuItem8.MenuItems.Add(this.mitemTextCoral);
         this.menuItem8.MenuItems.Add(this.mitemTextDeepPink);
         this.menuItem8.MenuItems.Add(this.mitemTextFireBrick);
         this.menuItem8.MenuItems.Add(this.mitemTextGainsboro);
         this.menuItem8.MenuItems.Add(this.mitemTextHoneyDew);
         this.menuItem8.Text = "Named Colors";
         // 
         // mitemTextAliceBlue
         // 
         this.mitemTextAliceBlue.Text = "AliceBlue";
         this.mitemTextAliceBlue.Click += new System.EventHandler(this.mitemTextAliceBlue_Click);
         // 
         // mitemTextBeige
         // 
         this.mitemTextBeige.Text = "Beige";
         this.mitemTextBeige.Click += new System.EventHandler(this.mitemTextBeige_Click);
         // 
         // mitemTextCoral
         // 
         this.mitemTextCoral.Text = "Coral";
         this.mitemTextCoral.Click += new System.EventHandler(this.mitemTextCoral_Click);
         // 
         // mitemTextDeepPink
         // 
         this.mitemTextDeepPink.Text = "DeepPink";
         this.mitemTextDeepPink.Click += new System.EventHandler(this.mitemTextDeepPink_Click);
         // 
         // mitemTextFireBrick
         // 
         this.mitemTextFireBrick.Text = "FireBrick";
         this.mitemTextFireBrick.Click += new System.EventHandler(this.mitemTextFireBrick_Click);
         // 
         // mitemTextGainsboro
         // 
         this.mitemTextGainsboro.Text = "Gainsboro";
         this.mitemTextGainsboro.Click += new System.EventHandler(this.mitemTextGainsboro_Click);
         // 
         // mitemTextHoneyDew
         // 
         this.mitemTextHoneyDew.Text = "HoneyDew";
         this.mitemTextHoneyDew.Click += new System.EventHandler(this.mitemTextHoneyDew_Click);
         // 
         // menuItem2
         // 
         this.menuItem2.MenuItems.Add(this.mitemBackControl);
         this.menuItem2.MenuItems.Add(this.mitemBackHighlight);
         this.menuItem2.MenuItems.Add(this.mitemBackInfo);
         this.menuItem2.MenuItems.Add(this.mitemBackMenu);
         this.menuItem2.MenuItems.Add(this.mitemBackWindow);
         this.menuItem2.Text = "System Colors";
         // 
         // mitemBackControl
         // 
         this.mitemBackControl.Text = "Control";
         this.mitemBackControl.Click += new System.EventHandler(this.mitemBackControl_Click);
         // 
         // mitemBackHighlight
         // 
         this.mitemBackHighlight.Text = "Highlight";
         this.mitemBackHighlight.Click += new System.EventHandler(this.mitemBackHighlight_Click);
         // 
         // mitemBackInfo
         // 
         this.mitemBackInfo.Text = "Info";
         this.mitemBackInfo.Click += new System.EventHandler(this.mitemBackInfo_Click);
         // 
         // mitemBackMenu
         // 
         this.mitemBackMenu.Text = "Menu";
         this.mitemBackMenu.Click += new System.EventHandler(this.mitemBackMenu_Click);
         // 
         // mitemBackWindow
         // 
         this.mitemBackWindow.Text = "Window";
         this.mitemBackWindow.Click += new System.EventHandler(this.mitemBackWindow_Click);
         // 
         // menuItem9
         // 
         this.menuItem9.MenuItems.Add(this.mitemBackIndigo);
         this.menuItem9.MenuItems.Add(this.mitemBackKhaki);
         this.menuItem9.MenuItems.Add(this.mitemBackLavender);
         this.menuItem9.MenuItems.Add(this.mitemBackMagenta);
         this.menuItem9.MenuItems.Add(this.mitemBackNavy);
         this.menuItem9.MenuItems.Add(this.mitemBackOlive);
         this.menuItem9.MenuItems.Add(this.mitemBackPlum);
         this.menuItem9.Text = "Named Colors";
         // 
         // mitemBackIndigo
         // 
         this.mitemBackIndigo.Text = "Indigo";
         this.mitemBackIndigo.Click += new System.EventHandler(this.mitemBackIndigo_Click);
         // 
         // mitemBackKhaki
         // 
         this.mitemBackKhaki.Text = "Khaki";
         this.mitemBackKhaki.Click += new System.EventHandler(this.mitemBackKhaki_Click);
         // 
         // mitemBackLavender
         // 
         this.mitemBackLavender.Text = "Lavender";
         this.mitemBackLavender.Click += new System.EventHandler(this.mitemBackLavender_Click);
         // 
         // mitemBackMagenta
         // 
         this.mitemBackMagenta.Text = "Magenta";
         this.mitemBackMagenta.Click += new System.EventHandler(this.mitemBackMagenta_Click);
         // 
         // mitemBackNavy
         // 
         this.mitemBackNavy.Text = "Navy";
         this.mitemBackNavy.Click += new System.EventHandler(this.mitemBackNavy_Click);
         // 
         // mitemBackOlive
         // 
         this.mitemBackOlive.Text = "Olive";
         this.mitemBackOlive.Click += new System.EventHandler(this.mitemBackOlive_Click);
         // 
         // mitemBackPlum
         // 
         this.mitemBackPlum.Text = "Plum";
         this.mitemBackPlum.Click += new System.EventHandler(this.mitemBackPlum_Click);
         // 
         // FormMain
         // 
         this.Controls.Add(this.lblBackB);
         this.Controls.Add(this.lblBackG);
         this.Controls.Add(this.lblBackR);
         this.Controls.Add(this.lblTextB);
         this.Controls.Add(this.lblTextG);
         this.Controls.Add(this.lblTextR);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular);
         this.Menu = this.menuMain;
         this.MinimizeBox = false;
         this.Text = "TextColor";
         this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormMain_Paint);

      }
      #endregion

      /// <summary>
      /// The main entry point for the application.
      /// </summary>

      static void Main() 
      {
         Application.Run(new FormMain());
      }

      //
      // Display color picker dialog -- foreground color
      //
      private void 
      mitemTextSetColor_Click(object sender, EventArgs e)
      {
         ChooseColorDlg ccdlg = new ChooseColorDlg();
         ccdlg.Init(this);
         if (ccdlg.ShowDialog(ref m_clrText))
         {
            Invalidate();
            DisplayRGBComponents();
         }
      }

      //
      // Display color picker dialog -- background color
      //
      private void 
      mitemBackgroundSetColor_Click(object sender, EventArgs e)
      {
         ChooseColorDlg ccdlg = new ChooseColorDlg();
         ccdlg.Init(this);
         if (ccdlg.ShowDialog(ref m_clrBack))
         {
            Invalidate();
            DisplayRGBComponents();
         }
      }

      // Private data
      Color m_clrBack = SystemColors.Window;
      Color m_clrText = SystemColors.WindowText;

      private void 
         FormMain_Paint(object sender, PaintEventArgs e)
      {
         Graphics g = e.Graphics;

         // The string to draw.
         string strDraw = "Text Color";

         // String location -- in floating point.
         float sinX = 10F;
         float sinY = 10F;

         // Location as integers.
         int x = (int)sinX;
         int y = (int)sinY;

         // Draw background if needed
         if (m_clrBack != SystemColors.Window)
         {
            // Calculate size of string bounding box.
            SizeF size = g.MeasureString(strDraw, Font);
            int cx = (int)size.Width;
            int cy = (int)size.Height;

            // Draw text bounding box.
            Rectangle rc = new Rectangle(x, y, cx, cy);

            Brush brBack = new SolidBrush(m_clrBack);
            g.FillRectangle(brBack, rc);
            brBack.Dispose();
         }

         Brush brText = new SolidBrush(m_clrText);
         g.DrawString(strDraw, Font, brText, sinX, sinY);
         brText.Dispose();
      } // FormMain_Paint

      private void DisplayRGBComponents()
      {
         byte byt = m_clrText.R;
         lblTextR.Text = byt.ToString("000");
         byt = m_clrText.G;
         lblTextG.Text = byt.ToString("000");      
         byt = m_clrText.B;
         lblTextB.Text = byt.ToString("000");

         byt = m_clrBack.R;
         lblBackR.Text = byt.ToString("000");
         byt = m_clrBack.G;
         lblBackG.Text = byt.ToString("000");
         byt = m_clrBack.B;
         lblBackB.Text = byt.ToString("000");
      } // DisplayRGBComponents

      private void SetTextColor(Color clr)
      {
         m_clrText = clr;
         Invalidate();
         DisplayRGBComponents();
      }

      private void SetBackColor(Color clr)
      {
         m_clrBack = clr;
         Invalidate();
         DisplayRGBComponents();
      }

      private void 
      mitemTextControlText_Click(object sender, EventArgs e)
      {
         SetTextColor(SystemColors.ControlText);
      }

      private void 
      mitemTextGrayText_Click(object sender, EventArgs e)
      {
         SetTextColor(SystemColors.GrayText);
      }

      private void 
      mitemTextHighlightText_Click(object sender, EventArgs e)
      {
         SetTextColor(SystemColors.HighlightText);
      }

      private void 
      mitemTextInfoText_Click(object sender, EventArgs e)
      {
         SetTextColor(SystemColors.InfoText);
      }

      private void 
      mitemTextMenuText_Click(object sender, EventArgs e)
      {
         SetTextColor(SystemColors.MenuText);
      }

      private void 
      mitemTextWindowText_Click(object sender, EventArgs e)
      {
         SetTextColor(SystemColors.WindowText);
      }

      private void 
      mitemTextAliceBlue_Click(object sender, EventArgs e)
      {
         SetTextColor(Color.AliceBlue);
      }

      private void 
      mitemTextBeige_Click(object sender, EventArgs e)
      {
         SetTextColor(Color.Beige);
      }

      private void 
      mitemTextCoral_Click(object sender, EventArgs e)
      {
         SetTextColor(Color.Coral);
      }

      private void 
      mitemTextDeepPink_Click(object sender, EventArgs e)
      {
         SetTextColor(Color.DeepPink);
      }

      private void 
      mitemTextFireBrick_Click(object sender, EventArgs e)
      {
         SetTextColor(Color.Firebrick);
      }

      private void 
      mitemTextGainsboro_Click(object sender, EventArgs e)
      {
         SetTextColor(Color.Gainsboro);
      }

      private void 
      mitemTextHoneyDew_Click(object sender, EventArgs e)
      {
         SetTextColor(Color.Honeydew);
      }

      private void 
      mitemBackControl_Click(object sender, EventArgs e)
      {
         SetBackColor(SystemColors.Control);
      }

      private void 
      mitemBackHighlight_Click(object sender, EventArgs e)
      {
         SetBackColor(SystemColors.Highlight);
      }

      private void 
      mitemBackInfo_Click(object sender, EventArgs e)
      {
         SetBackColor(SystemColors.Info);
      }

      private void 
      mitemBackMenu_Click(object sender, EventArgs e)
      {
         SetBackColor(SystemColors.Menu);
      }

      private void 
      mitemBackWindow_Click(object sender, EventArgs e)
      {
         SetBackColor(SystemColors.Window);
      }

      private void 
      mitemBackIndigo_Click(object sender, EventArgs e)
      {
         SetBackColor(Color.Indigo);
      }

      private void 
      mitemBackKhaki_Click(object sender, EventArgs e)
      {
         SetBackColor(Color.Khaki);
      }

      private void 
      mitemBackLavender_Click(object sender, EventArgs e)
      {
         SetBackColor(Color.Lavender);
      }

      private void 
      mitemBackMagenta_Click(object sender, EventArgs e)
      {
         SetBackColor(Color.Magenta);
      }

      private void 
      mitemBackNavy_Click(object sender, EventArgs e)
      {
         SetBackColor(Color.Navy);
      }

      private void 
      mitemBackOlive_Click(object sender, EventArgs e)
      {
         SetBackColor(Color.Olive);
      }

      private void 
      mitemBackPlum_Click(object sender, EventArgs e)
      {
         SetBackColor(Color.Plum);
      }

   } // class
} // namespace
