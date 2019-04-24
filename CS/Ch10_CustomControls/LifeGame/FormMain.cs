//-----------------------------------------------------------------------------
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;

namespace LifeGame
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class FormMain : System.Windows.Forms.Form
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      #region Windows Form Designer generated code
      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.mnuMain = new System.Windows.Forms.MainMenu();
         this.panelCells = new System.Windows.Forms.Panel();
         this.btnStartStop = new System.Windows.Forms.Button();
         // 
         // btnStartStop
         // 
         this.btnStartStop.Location = new System.Drawing.Point(344, 240);
         this.btnStartStop.Text = "S&tart";
         this.btnStartStop.Click += new System.EventHandler(this.mnuStartStop_Click);
         // 
         // FormMain
         // 
         this.ClientSize = new System.Drawing.Size(506, 301);
         this.Menu = this.mnuMain;
         this.Text = "Life Game";
         this.Closing += new System.ComponentModel.CancelEventHandler(this.FormMain_Closing);
         this.Load += new System.EventHandler(this.FormMain_Load);

      }
      #endregion

      #region Properties
		
      //	The LifeMain object.  It contains,
      //		and runs, the Life Game; and it
      //		supplies the control needed to
      //		display the game.
      private LifeMain refLifeMain;

      //	"Game is running" indicator.
      private bool boolRun = false;
		
      #endregion

      #region Controls
      private System.Windows.Forms.Panel panelCells;
      private System.Windows.Forms.Button btnStartStop;
      private LifeGame.LifeControl facadeLifeGame;

      private System.Windows.Forms.MainMenu mnuMain;

      private System.Windows.Forms.MenuItem mnuFile;
      private System.Windows.Forms.MenuItem mnuStartStop;
      private System.Windows.Forms.MenuItem mnuExit;

      private System.Windows.Forms.MenuItem mnuPattern;
      private System.Windows.Forms.MenuItem mnuEmpty;
      private System.Windows.Forms.MenuItem mnuReset;
      private System.Windows.Forms.MenuItem mnuManual;

      private System.Windows.Forms.MenuItem mnuCheckers;
      private System.Windows.Forms.MenuItem mnuBoard;
      private System.Windows.Forms.MenuItem mnuSelfFix;
      private System.Windows.Forms.MenuItem mnuSelfDestruct;

      private System.Windows.Forms.MenuItem mnuLines;
      private System.Windows.Forms.MenuItem mnuDiagonal;
      private System.Windows.Forms.MenuItem mnuVertical;
      private System.Windows.Forms.MenuItem mnuFlawedVertical;

      private System.Windows.Forms.MenuItem mnuGliders;
      private System.Windows.Forms.MenuItem mnuGlider;
      private System.Windows.Forms.MenuItem mnuGliderMate;
      private System.Windows.Forms.MenuItem mnuGliderPump;

      private System.Windows.Forms.MenuItem mnuSmalls;
      private System.Windows.Forms.MenuItem mnuFiveCell;
      private System.Windows.Forms.MenuItem mnuSixCell;
      private System.Windows.Forms.MenuItem mnuEightCell;
      private System.Windows.Forms.MenuItem mnuTenCell;
         
      private System.Windows.Forms.MenuItem mnuSpeed;
      private System.Windows.Forms.MenuItem mnuFastest;
      private System.Windows.Forms.MenuItem mnuFast;
      private System.Windows.Forms.MenuItem mnuFaster;
      private System.Windows.Forms.MenuItem mnuSpeedNormal;
      private System.Windows.Forms.MenuItem mnuSlower;
      private System.Windows.Forms.MenuItem mnuSlow;
      private System.Windows.Forms.MenuItem mnuSlowest;

      private System.Windows.Forms.MenuItem mnuZoom;
      private System.Windows.Forms.MenuItem mnuInnest;
      private System.Windows.Forms.MenuItem mnuIn;
      private System.Windows.Forms.MenuItem mnuSizeNormal;
      private System.Windows.Forms.MenuItem mnuOut;
      private System.Windows.Forms.MenuItem mnuOutest;

      private System.Windows.Forms.MenuItem mnuAbout;
      #endregion
		
      #region System Methods

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
         if( disposing )
         {
            if (components != null) 
            {
               components.Dispose();
            }
         }
         base.Dispose( disposing );
      }

      #endregion

      #region Initialization

      /// <summary>
      /// The main entry point for the application.
      /// </summary>

      static void Main() 
      {
         Application.Run(new FormMain());
      }

      private void FormMain_Load(object sender, System.EventArgs e)
      {
         InitLifeGame();
         InitMenus();
         WindowState = FormWindowState.Maximized;
         PositionControls();
      }

      private void InitLifeGame()
      {
         //	Create a new LifeMain object.
         refLifeMain = new LifeMain();

         //	Specify the delegate function to be notified
         //		when a new generation has been calculated.
         refLifeMain.NextGenReady += new LifeMain.deleNextGenReady( LifeMain_NextGenReady );
			
         //	Specify the delegate function to be notified
         //		when a static state has been reached.
         refLifeMain.StableStateReached += new LifeMain.deleStableStateReached( LifeMain_StableStateReached );

         //	Get the display control from the LifeGame 
         //		object.  Make it visible.  Specify a
         //		click event for it.  Add it to the form.
         facadeLifeGame = refLifeMain.refFacade;
         facadeLifeGame.Visible = true;
         facadeLifeGame.MouseUp += new System.Windows.Forms.MouseEventHandler(this.facadeLifeGame_MouseUp);
         this.Controls.Add( this.facadeLifeGame );
      }

      private void PositionControls()
      {
         //	Postion controls on form.
         facadeLifeGame.BackColor = Color.Tan;
         utilGUI.SetBounds(facadeLifeGame,
            ClientRectangle.Left,
            ClientRectangle.Top,
            (ClientRectangle.Width < ClientRectangle.Height) ? ClientRectangle.Width : ClientRectangle.Height,
            (ClientRectangle.Width < ClientRectangle.Height) ? ClientRectangle.Width : ClientRectangle.Height);

         utilGUI.SetBounds(panelCells,
            facadeLifeGame.Width,
            (ClientRectangle.Height / 4) * 2,
            ClientRectangle.Width - facadeLifeGame.Width,
            ClientRectangle.Height / 4);

         btnStartStop.Enabled = mnuStartStop.Enabled = false;
      }

      #endregion

      #region Menu Initialization

      private void InitMenus()
      {
         this.mnuFile = new System.Windows.Forms.MenuItem();
         this.mnuStartStop = new System.Windows.Forms.MenuItem();
         this.mnuExit = new System.Windows.Forms.MenuItem();
         this.mnuPattern = new System.Windows.Forms.MenuItem();
         this.mnuEmpty = new System.Windows.Forms.MenuItem();
         this.mnuReset = new System.Windows.Forms.MenuItem();
         this.mnuManual = new System.Windows.Forms.MenuItem();
         this.mnuSmalls = new System.Windows.Forms.MenuItem();
         this.mnuFiveCell = new System.Windows.Forms.MenuItem();
         this.mnuSixCell = new System.Windows.Forms.MenuItem();
         this.mnuEightCell = new System.Windows.Forms.MenuItem();
         this.mnuTenCell = new System.Windows.Forms.MenuItem();
         this.mnuSpeed = new System.Windows.Forms.MenuItem();
         this.mnuFastest = new System.Windows.Forms.MenuItem();
         this.mnuFast = new System.Windows.Forms.MenuItem();
         this.mnuFaster = new System.Windows.Forms.MenuItem();
         this.mnuSpeedNormal = new System.Windows.Forms.MenuItem();
         this.mnuSlower = new System.Windows.Forms.MenuItem();
         this.mnuSlow = new System.Windows.Forms.MenuItem();
         this.mnuSlowest = new System.Windows.Forms.MenuItem();
         this.mnuZoom = new System.Windows.Forms.MenuItem();
         this.mnuInnest = new System.Windows.Forms.MenuItem();
         this.mnuIn = new System.Windows.Forms.MenuItem();
         this.mnuSizeNormal = new System.Windows.Forms.MenuItem();
         this.mnuOut = new System.Windows.Forms.MenuItem();
         this.mnuOutest = new System.Windows.Forms.MenuItem();
         this.mnuLines = new System.Windows.Forms.MenuItem();
         this.mnuDiagonal = new System.Windows.Forms.MenuItem();
         this.mnuVertical = new System.Windows.Forms.MenuItem();
         this.mnuFlawedVertical = new System.Windows.Forms.MenuItem();
         this.mnuCheckers = new System.Windows.Forms.MenuItem();
         this.mnuBoard = new System.Windows.Forms.MenuItem();
         this.mnuSelfFix = new System.Windows.Forms.MenuItem();
         this.mnuSelfDestruct = new System.Windows.Forms.MenuItem();
         this.mnuGliders = new System.Windows.Forms.MenuItem();
         this.mnuGlider = new System.Windows.Forms.MenuItem();
         this.mnuGliderMate = new System.Windows.Forms.MenuItem();
         this.mnuGliderPump = new System.Windows.Forms.MenuItem();
         this.mnuAbout = new System.Windows.Forms.MenuItem();
         // 
         // mnuMain
         // 
         this.mnuMain.MenuItems.Add(this.mnuFile);
         this.mnuMain.MenuItems.Add(this.mnuPattern);
         this.mnuMain.MenuItems.Add(this.mnuSpeed);
         this.mnuMain.MenuItems.Add(this.mnuZoom);
         // 
         // mnuFile
         // 
         this.mnuFile.MenuItems.Add(this.mnuStartStop);
         this.mnuFile.MenuItems.Add(this.mnuExit);
         this.mnuFile.Text = "File";
         // 
         // mnuStartStop
         // 
         this.mnuStartStop.Text = "S&tart";
         this.mnuStartStop.Click += new System.EventHandler(this.mnuStartStop_Click);
         // 
         // mnuExit
         // 
         this.mnuExit.Text = "E&xit";
         this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
         // 
         // mnuPattern
         // 
         this.mnuPattern.MenuItems.Add(this.mnuEmpty);
         this.mnuPattern.MenuItems.Add(this.mnuReset);
         this.mnuPattern.MenuItems.Add(this.mnuManual);
         this.mnuPattern.MenuItems.Add(this.mnuSmalls);
         this.mnuPattern.MenuItems.Add(this.mnuLines);
         this.mnuPattern.MenuItems.Add(this.mnuCheckers);
         this.mnuPattern.MenuItems.Add(this.mnuGliders);
         this.mnuPattern.Text = "Pattern";
         // 
         // mnuEmpty
         // 
         this.mnuEmpty.Text = "Empty";
         this.mnuEmpty.Click += new System.EventHandler(this.mnuPatterns_Click);
         // 
         // mnuReset
         // 
         this.mnuReset.Text = "Reset";
         this.mnuReset.Click += new System.EventHandler(this.mnuReset_Click);
         // 
         // mnuManual
         // 
         this.mnuManual.Text = "Manual";
         this.mnuManual.Click += new System.EventHandler(this.mnuManual_Click);
         // 
         // mnuSmalls
         // 
         this.mnuSmalls.MenuItems.Add(this.mnuFiveCell);
         this.mnuSmalls.MenuItems.Add(this.mnuSixCell);
         this.mnuSmalls.MenuItems.Add(this.mnuEightCell);
         this.mnuSmalls.MenuItems.Add(this.mnuTenCell);
         this.mnuSmalls.Text = "Smalls";
         // 
         // mnuFiveCell
         // 
         this.mnuFiveCell.Text = "Five Cell";
         this.mnuFiveCell.Click += new System.EventHandler(this.mnuPatterns_Click);
         // 
         // mnuSixCell
         // 
         this.mnuSixCell.Text = "Six Cell";
         this.mnuSixCell.Click += new System.EventHandler(this.mnuPatterns_Click);
         // 
         // mnuEightCell
         // 
         this.mnuEightCell.Text = "Eight Cell";
         this.mnuEightCell.Click += new System.EventHandler(this.mnuPatterns_Click);
         // 
         // mnuTenCell
         // 
         this.mnuTenCell.Text = "Ten Cell";
         this.mnuTenCell.Click += new System.EventHandler(this.mnuPatterns_Click);
         // 
         // mnuSpeed
         // 
         this.mnuSpeed.MenuItems.Add(this.mnuFastest);
         this.mnuSpeed.MenuItems.Add(this.mnuFast);
         this.mnuSpeed.MenuItems.Add(this.mnuFaster);
         this.mnuSpeed.MenuItems.Add(this.mnuSpeedNormal);
         this.mnuSpeed.MenuItems.Add(this.mnuSlower);
         this.mnuSpeed.MenuItems.Add(this.mnuSlow);
         this.mnuSpeed.MenuItems.Add(this.mnuSlowest);
         this.mnuSpeed.Text = "Speed";
         // 
         // mnuFastest
         // 
         this.mnuFastest.Text = "Fastest";
         this.mnuFastest.Click += new System.EventHandler(this.mnuSpeed_Click);
         // 
         // mnuFast
         // 
         this.mnuFast.Text = "Fast";
         this.mnuFast.Click += new System.EventHandler(this.mnuSpeed_Click);
         // 
         // mnuFaster
         // 
         this.mnuFaster.Text = "Faster";
         this.mnuFaster.Click += new System.EventHandler(this.mnuSpeed_Click);
         // 
         // mnuSpeedNormal
         // 
         this.mnuSpeedNormal.Text = "Normal";
         this.mnuSpeedNormal.Click += new System.EventHandler(this.mnuSpeed_Click);
         // 
         // mnuSlower
         // 
         this.mnuSlower.Text = "Slower";
         this.mnuSlower.Click += new System.EventHandler(this.mnuSpeed_Click);
         // 
         // mnuSlow
         // 
         this.mnuSlow.Text = "Slow";
         this.mnuSlow.Click += new System.EventHandler(this.mnuSpeed_Click);
         // 
         // mnuSlowest
         // 
         this.mnuSlowest.Text = "Slowest";
         this.mnuSlowest.Click += new System.EventHandler(this.mnuSpeed_Click);
         // 
         // mnuZoom
         // 
         this.mnuZoom.MenuItems.Add(this.mnuInnest);
         this.mnuZoom.MenuItems.Add(this.mnuIn);
         this.mnuZoom.MenuItems.Add(this.mnuSizeNormal);
         this.mnuZoom.MenuItems.Add(this.mnuOut);
         this.mnuZoom.MenuItems.Add(this.mnuOutest);
         this.mnuZoom.Text = "Zoom";
         this.mnuZoom.Click += new System.EventHandler(this.mnuZoom_Click);
         // 
         // mnuInnest
         // 
         this.mnuInnest.Text = "Innest";
         this.mnuInnest.Click += new System.EventHandler(this.mnuZoom_Click);
         // 
         // mnuIn
         // 
         this.mnuIn.Text = "In";
         this.mnuIn.Click += new System.EventHandler(this.mnuZoom_Click);
         // 
         // mnuSizeNormal
         // 
         this.mnuSizeNormal.Text = "Normal";
         this.mnuSizeNormal.Click += new System.EventHandler(this.mnuZoom_Click);
         // 
         // mnuOut
         // 
         this.mnuOut.Text = "Out";
         this.mnuOut.Click += new System.EventHandler(this.mnuZoom_Click);
         // 
         // mnuOutest
         // 
         this.mnuOutest.Text = "Outest";
         this.mnuOutest.Click += new System.EventHandler(this.mnuZoom_Click);
         // 
         // mnuLines
         // 
         this.mnuLines.MenuItems.Add(this.mnuDiagonal);
         this.mnuLines.MenuItems.Add(this.mnuVertical);
         this.mnuLines.MenuItems.Add(this.mnuFlawedVertical);
         this.mnuLines.Text = "Lines";
         // 
         // mnuDiagonal
         // 
         this.mnuDiagonal.Text = "Diagonal";
         this.mnuDiagonal.Click += new System.EventHandler(this.mnuPatterns_Click);
         // 
         // mnuVertical
         // 
         this.mnuVertical.Text = "Vertical";
         this.mnuVertical.Click += new System.EventHandler(this.mnuPatterns_Click);
         // 
         // mnuFlawedVertical
         // 
         this.mnuFlawedVertical.Text = "FlawedVertical";
         this.mnuFlawedVertical.Click += new System.EventHandler(this.mnuPatterns_Click);
         // 
         // mnuCheckers
         // 
         this.mnuCheckers.MenuItems.Add(this.mnuBoard);
         this.mnuCheckers.MenuItems.Add(this.mnuSelfFix);
         this.mnuCheckers.MenuItems.Add(this.mnuSelfDestruct);
         this.mnuCheckers.Text = "Checkers";
         // 
         // mnuBoard
         // 
         this.mnuBoard.Text = "Board";
         this.mnuBoard.Click += new System.EventHandler(this.mnuPatterns_Click);
         // 
         // mnuSelfFix
         // 
         this.mnuSelfFix.Text = "Self Fixing";
         this.mnuSelfFix.Click += new System.EventHandler(this.mnuPatterns_Click);
         // 
         // mnuSelfDestruct
         // 
         this.mnuSelfDestruct.Text = "Self Destructive";
         this.mnuSelfDestruct.Click += new System.EventHandler(this.mnuPatterns_Click);
         // 
         // mnuGliders
         // 
         this.mnuGliders.MenuItems.Add(this.mnuGlider);
         this.mnuGliders.MenuItems.Add(this.mnuGliderMate);
         this.mnuGliders.MenuItems.Add(this.mnuGliderPump);
         this.mnuGliders.Text = "Gliders";
         // 
         // mnuGlider
         // 
         this.mnuGlider.Text = "Single";
         this.mnuGlider.Click += new System.EventHandler(this.mnuPatterns_Click);
         // 
         // mnuGliderMate
         // 
         this.mnuGliderMate.Text = "Mate";
         this.mnuGliderMate.Click += new System.EventHandler(this.mnuPatterns_Click);
         // 
         // mnuGliderPump
         // 
         this.mnuGliderPump.Text = "Pump";
         this.mnuGliderPump.Click += new System.EventHandler(this.mnuPatterns_Click);
         // 
         // mnuAbout
         // 
         this.mnuAbout.Text = "&Help";
         this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);

         // Starting selections
         this.mnuSpeed_Click(this.mnuSpeedNormal, EventArgs.Empty);
         this.mnuZoom_Click(this.mnuSizeNormal, EventArgs.Empty);
      }

      # endregion

      #region Utilities

      private int LittlePowerOfTwo(int exponent)
      {
         //	Don't laugh.  It is not in the CLR 
         //		(except for SQL non-integer types).
         switch( exponent )
         {
            case 0: return 1;
            case 1: return 2;
            case 2: return 4;
            case 3: return 8;
            case 4: return 16;
            case 5: return 32;
            case 6: return 64;
            case 7: return 128;
            case 8: return 256;
            case 9: return 512;
            case 10: return 1024;
            default: return 1024;
         }
      }

      #endregion

      #region Menu Processing
      private void mnuStartStop_Click(object sender, System.EventArgs e)
      {
         //	The Start/Stop button is a toggle.
         boolRun = !boolRun;

         //	If requested to run.
         if( boolRun ) 
         {
            //	Do not allow the user to do certain
            //		things while the game is running.
            btnStartStop.Text = mnuStartStop.Text = "S&top";
            mnuExit.Enabled = false;

            //	Notify the object to start the game.
            refLifeMain.Start();
         }
         else
            //	If requested to stop.
         {
            refLifeMain.Stop();
            btnStartStop.Text = mnuStartStop.Text = "S&tart";
            mnuExit.Enabled = true;
         }
         
      }

      private void mnuExit_Click(object sender, System.EventArgs e)
      {
         Application.Exit();
      }

      private void mnuPatterns_Click(object sender, System.EventArgs e)
      {
         //	Some pattern work best at certain sizes.
         //         if( sender == mnuTenCell ) tbarSize.Value = 7;
         //         if( sender == mnuFlawedVertical ) tbarSize.Value = 7;

         //	Inform the LifeMain object of the 
         //		requested pattern.
         if( sender == mnuEmpty ) refLifeMain.SetPattern( LifeMain.lgpPattern.lgpEmpty );
         if( sender == mnuFiveCell ) refLifeMain.SetPattern( LifeMain.lgpPattern.lgpFiveCell );
         if( sender == mnuSixCell ) refLifeMain.SetPattern( LifeMain.lgpPattern.lgpSixCell );
         if( sender == mnuEightCell ) refLifeMain.SetPattern( LifeMain.lgpPattern.lgpEightCell );
         if( sender == mnuTenCell ) refLifeMain.SetPattern( LifeMain.lgpPattern.lgpTenCell );
         if( sender == mnuVertical ) refLifeMain.SetPattern( LifeMain.lgpPattern.lgpVertical );
         if( sender == mnuFlawedVertical ) refLifeMain.SetPattern( LifeMain.lgpPattern.lgpFlawedVertical );
         if( sender == mnuDiagonal ) refLifeMain.SetPattern( LifeMain.lgpPattern.lgpDiagonal );
         if( sender == mnuBoard ) refLifeMain.SetPattern( LifeMain.lgpPattern.lgpBoard );
         if( sender == mnuSelfFix ) refLifeMain.SetPattern( LifeMain.lgpPattern.lgpSelfFix );
         if( sender == mnuSelfDestruct ) refLifeMain.SetPattern( LifeMain.lgpPattern.lgpSelfDestruct );
         if( sender == mnuGlider ) refLifeMain.SetPattern( LifeMain.lgpPattern.lgpGlider );
         if( sender == mnuGliderMate ) refLifeMain.SetPattern( LifeMain.lgpPattern.lgpGliderMate );
         if( sender == mnuGliderPump ) refLifeMain.SetPattern( LifeMain.lgpPattern.lgpGliderPump );

         //	If there is a pattern in the window,
         //		enable the start button and give
         //		it the focus.
         btnStartStop.Enabled = mnuStartStop.Enabled = !(sender == mnuEmpty);
         if( btnStartStop.Enabled ) btnStartStop.Focus();

         //	Prepare to draw the patterns.
         facadeLifeGame.Invalidate();
      }

      private void mnuReset_Click(object sender, System.EventArgs e)
      {
         refLifeMain.Reset();
         facadeLifeGame.Invalidate();
      }

      private void mnuManual_Click(object sender, System.EventArgs e)
      {
         MessageBox.Show("Click in the window to create or alter a pattern");
      }

      private void mnuSpeed_Click(object sender, 
         System.EventArgs e)
      {
         if( refLifeMain == null ) return;
         switch (((MenuItem)sender).Text)
         {
            case "Fastest":
               refLifeMain.ChangeRunSpeed
                  ((int)utilGUI.gameSpeed.gsFastest);
               break;
            case "Fast":
               refLifeMain.ChangeRunSpeed
                  ((int)utilGUI.gameSpeed.gsFast);
               break;
            case "Faster":
               refLifeMain.ChangeRunSpeed
                  ((int)utilGUI.gameSpeed.gsFaster);
               break;
            case "Normal":
               refLifeMain.ChangeRunSpeed
                  ((int)utilGUI.gameSpeed.gsNormal);
               break;
            case "Slower":
               refLifeMain.ChangeRunSpeed
                  ((int)utilGUI.gameSpeed.gsSlower);
               break;
            case "Slow":
               refLifeMain.ChangeRunSpeed
                  ((int)utilGUI.gameSpeed.gsSlow);
               break;
            case "Slowest":
               refLifeMain.ChangeRunSpeed
                  ((int)utilGUI.gameSpeed.gsSlowest);
               break;
         }
      }

      private void mnuZoom_Click(object sender, 
         System.EventArgs e)
      {
         if( refLifeMain == null ) return;
         switch (((MenuItem)sender).Text)
         {
            case "Innest":
               refLifeMain.ChangeDisplaySize
                  ((int)utilGUI.gameZoom.gzInnest);
               break;
            case "In":
               refLifeMain.ChangeDisplaySize
                  ((int)utilGUI.gameZoom.gzIn);
               break;
               //            case "Inner":
               //               refLifeMain.ChangeDisplaySize
               //                  ((int)utilGUI.gameZoom.gzInner);
               //               break;
            case "Normal":
               refLifeMain.ChangeDisplaySize
                  ((int)utilGUI.gameZoom.gzNormal);
               break;
               //            case "Outer":
               //               refLifeMain.ChangeDisplaySize
               //                  ((int)utilGUI.gameZoom.gzOuter);
               //               break;
            case "Out":
               refLifeMain.ChangeDisplaySize
                  ((int)utilGUI.gameZoom.gzOut);
               break;
            case "Outest":
               refLifeMain.ChangeDisplaySize
                  ((int)utilGUI.gameZoom.gzOutest);
               break;
         }
      }

      private void mnuAbout_Click(object sender, System.EventArgs e)
      {
         //	Have the LifeGame object do it.
         refLifeMain.ShowAbout();
      }

      #endregion

      #region Event Handlers

      private void facadeLifeGame_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
      {
         //	The user is entering a pattern,
         //		enable Run.
         btnStartStop.Enabled = mnuStartStop.Enabled = true;
      }

      private void LifeMain_NextGenReady( object sender, EventArgs e )
      {
         // Place a reference to the current and previous
         //    generation into properties of the control.
         //    Then have the control draw the current 
         //    generation.
         this.facadeLifeGame.refCurr = refLifeMain.genCurr;
         this.facadeLifeGame.refPrev = refLifeMain.genPrev;
         this.facadeLifeGame.Invalidate();
         Application.DoEvents();
      }


      private void LifeMain_StableStateReached( object sender, EventArgs e )
      {
         //	Delegate routine.  Called by LifeMain
         //		when the pattern is now static.
         mnuStartStop_Click( this, EventArgs.Empty );
         Application.DoEvents();
         MessageBox.Show("Steady State");
      }

      #endregion

      #region Termination

      private void FormMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
      {
         //	If the form is closing, STOP THE GAME.	
         if( refLifeMain != null ) refLifeMain.Stop();
      }

      #endregion

   }
}
