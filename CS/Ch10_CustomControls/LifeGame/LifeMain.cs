//-----------------------------------------------------------------------------
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Drawing;
using System.IO;
using System.Threading;

namespace LifeGame
{
   /// <summary>
   /// Summary description for LifeGame.
   ///	The main object.  It controls the game.
   ///	It creates one LifeGeneration object for
   ///	each generation.  Each generation object
   ///	creates a LifeRow object for each of the
   ///	512-1 rows that make up a generation.
   /// </summary>
   /// 

   public class LifeMain
   {
      #region Predefined patterns

      //	The list of pre-defined patterns.
      public enum lgpPattern
      {
         lgpEmpty,
         lgpDiagonal,
         lgpVertical,
         lgpFlawedVertical,
         lgpFiveCell,
         lgpSixCell,
         lgpSevenCell,
         lgpEightCell,
         lgpTenCell,
         lgpBoard,
         lgpSelfFix,
         lgpSelfDestruct,
         lgpGlider,
         lgpGliderMate,
         lgpGliderPump 
      };
      #endregion

      #region Properties
      //	Reference to the LifeControl that will
      //		display the generations.
      public LifeControl refFacade;

      //	Event definition for NextGenReady.
      public delegate void deleNextGenReady( object sender, EventArgs e );
      //	Event definition for StableStateReached.
      public delegate void deleStableStateReached( object sender, EventArgs e );

      //	The size of the grid.  That is,
      //		each generation will contain 
      //		noofCells * noofCells cells.
      internal static int noofCells = 512-1;
      //	The display size.  That is
      //		the display will contain 
      //		noofDisplay * noofDisplay cells.
      internal static int noofDisplay = 64-1;

      //	A set of generations.
      //		Zero => The starting pattern.
      //		Next => The next generation.
      //		Curr => The current generation.
      //		Prev => The previous generation.
      //		Grand => The grandfather generation.
      //		Four => The great grandfather generation.
      internal LifeGeneration genZero = new LifeGeneration();
      internal LifeGeneration genNext = new LifeGeneration();
      internal LifeGeneration genCurr = new LifeGeneration();
      internal LifeGeneration genPrev = new LifeGeneration();
      internal LifeGeneration genGrand = new LifeGeneration();
      internal LifeGeneration genFour = new LifeGeneration();

      // Run speed.  No of milleseconds 
      //		between generations.
      private int m_RunSpeed = 1024;
      public int RunSpeed
      {
         get 
         {
            return m_RunSpeed;
         }
         set 
         {
            m_RunSpeed = value;
         }
      }
		
      // Number of live cells.  In
      //		actuality, the number 
      //		of live cells in the
      //		current generation.
      //	Updates the Peak number
      //		as necessary.
      public uint noofLive
      {
         get 
         {
            uint temp = genCurr.noofLive;
            if( temp > nooflivepeak ) nooflivepeak = temp;
            return temp;
         }
      }

      // Peak number of live cells.
      private uint nooflivepeak = 0;
      public uint noofLivePeak
      {
         get 
         {
            return nooflivepeak;
         }
      }
		
      //	Number of generations.  In
      //		actuality, the generation 
      //		number of the current 
      //		generation.
      public uint noofGeneration
      {
         get 
         {
            return genCurr.countGeneration;
         }
      }

      //	Lapsed time, in seconds.
      private DateTime dtStart = DateTime.Now;
      public int secondsLapsed
      {
         get 
         {
            return 
               ((DateTime.Now.Subtract(dtStart)).Minutes * 60) +
               ((DateTime.Now.Subtract(dtStart)).Seconds);			
         }
      }

      // Indicator that client is now
      //		iteratively calculating
      //		generations; that is, the
      //		client is in "run" mode.
      internal static bool boolRun;

      //	Indication that the entire pattern
      //		needs to be repainted.  When
      //		turned off, only cells that have
      //		changed are repainted.
      internal static bool boolPaintAll;
      #endregion
		
      #region System methods
      // Constructor.
      public LifeMain()
      {
         //	Set the current pattern to empty.
         genCurr.Clear();
         boolPaintAll = true;

         // Create an instance of the display control.
         refFacade = new LifeGame.LifeControl();
      }
      #endregion

      #region Public Methods

      public void Start()
         //	Start the generation
         //		calculation loop.
      {
         // Remove the menu.  Must be done here because
         //    this control is responsible for erasing
         //    its own background.
         Redraw();

         //	Save the current pattern, for
         //		"reset" purposes.
         genCurr.CopyTo(genZero);

         //	Clear all previous patterns.
         genPrev.SetPattern(lgpPattern.lgpEmpty);
         genGrand.SetPattern(lgpPattern.lgpEmpty);
         genFour.SetPattern(lgpPattern.lgpEmpty);

         //	Init some properties.
         dtStart = DateTime.Now;

         //	Start calcuating generations
         boolRun = true;
         while (boolRun)
         {
            CalcNextGen();
            boolPaintAll = false;
            OnNextGenReady();
            boolPaintAll = true;
            Thread.Sleep( (int)RunSpeed );
         }
      }

      public void Stop()
         //	Halt the generation
         //		calculation loop.
      {
         // Remove the menu.  Must be done here because
         //    this control is responsible for erasing
         //    its own background.
         Redraw();
         
         // Halt.
         boolRun = false;
      }

      public void CalcNextGen()
      {
         //	Have the current generation calculate
         //		the next generation.
         genNext = genCurr.CalcNextGen();

         //	Check to see if a static state has been
         //		has been reached.
         if( genNext.countGeneration >= 4 && genNext.CompareTo(genFour) == 0 ) OnStableStateReached();

         //	Age the generations
         genFour = genGrand;
         genGrand = genPrev;
         genPrev = genCurr;
         genCurr = genNext;
      }

      public void ChangeDisplaySize(int gsZoom)
      {
         noofDisplay = gsZoom;
         Redraw();
      }

      public void ChangeRunSpeed(int gsSpeed)
      {
         RunSpeed = gsSpeed;
         Redraw();
      }

      public void SetPattern (lgpPattern Pattern)
      {
         //	Have the current generation do it.
         genCurr.SetPattern(Pattern);
         Redraw();
      }

      public void SetRow (int ixRow, int[] arrayArgs)
      {
         //	Have the current generation do it.
         genCurr.SetRow(ixRow, arrayArgs);
         Redraw();
      }

      public void Reset()
      {
         //	Restore the current pattern.
         genZero.CopyTo(genCurr);

         //	Clear all previous patterns.
         genPrev.SetPattern(lgpPattern.lgpEmpty);
         genGrand.SetPattern(lgpPattern.lgpEmpty);
         genFour.SetPattern(lgpPattern.lgpEmpty);
         Redraw();
      }

      public void SaveToFile(Stream strmFileOut)
      {
         //	Have the current generation do it.
         genCurr.SaveToFile(strmFileOut);
      }
		
      public void ReadFromFile(Stream strmFileIn)
      {
         //	Have the current generation do it.
         genCurr.ReadFromFile(strmFileIn);
         Redraw();
      }

      public void ShowAbout()
      {
         //	Shell IE to display About.htm file.
         //		Not sure that it will work in all 
         //		environments; such as DotNetCF.
         
//         System.Diagnostics.Process refHelp;
//
//         bool boolrun = boolRun;
//
//         if( boolrun ) Stop();
//         try
//         {
//            refHelp = System.Diagnostics.Process.Start(
//               System.Windows.Forms.Application.StartupPath + 
//               "/../../" + "About.htm");
//            refHelp.WaitForExit();
//         }
//         catch
//         {
//            refHelp = System.Diagnostics.Process.Start(
//               System.Windows.Forms.Application.StartupPath + 
//               "/" + "About.htm");
//            refHelp.WaitForExit();
//         }
//         finally
//         {
//            Redraw();
//            if( boolrun ) Start();
//         }
      }

      #endregion

      #region Private Methods

      private void Redraw()
      {
         //	Do a complete repaint of
         //		the current generation.
         boolPaintAll = true;
         OnNextGenReady();
      }

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

      #region Event Raisers
      //	Event raisers.
      //		This object raises two events, the "next generation
      //		has been calculated" event and the "game has reached
      //    a stable state" event.  Both events pass no 
      //    additional information when raised.

      public event deleNextGenReady NextGenReady;
      protected virtual void OnNextGenReady()
      {
         if( NextGenReady != null ) 
            NextGenReady(this, EventArgs.Empty);
      }

      public event deleStableStateReached StableStateReached;
      protected virtual void OnStableStateReached()
      {
         if( StableStateReached != null ) 
            StableStateReached(this, EventArgs.Empty);
      }
      #endregion

   }
}
