//-----------------------------------------------------------------------------
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace LifeGame
{
   /// <summary>
   /// Summary description for LifeControl.
   /// The display control for a Life game.
   ///   Draws one generation.  this.genCurr 
   ///   is always the generation that will 
   ///   be drawn.
   /// Also handles mouse clicks that occur in
   ///   its client area.
   /// A reference to this is stored in the 
   ///   refFacade property of the LifeMain 
   ///   object.
   /// </summary>
   public class LifeControl : System.Windows.Forms.Control
   {
      #region Properties

      // Properties used for drawing.
      //    The current generation is the one that is displayed;
      //    the previous generation is used for optimization.
      //    They will be set by the LifeMain   object before this
      //    control is invalidated.
      internal LifeGeneration refCurr;
      internal LifeGeneration refPrev;

      #endregion

      #region Constructor

      public LifeControl()
      {
      }

      #endregion

      #region Base Class Overrides

      protected override void OnMouseUp(MouseEventArgs e)
      {
         // Determine the cell that was clicked.
         int displayLo = 
            (LifeMain.noofCells - LifeMain.noofDisplay) / 2;
         int xUnit = 
            (int)(ClientRectangle.Width / LifeMain.noofDisplay);
         int yUnit = 
            (int)(ClientRectangle.Height / LifeMain.noofDisplay);

         // Tell the current generation to toggle this cell.
         refCurr.FlipCell( 
            (e.Y / yUnit) + displayLo + 1, 
            (e.X / xUnit) + displayLo + 1);
         
         // Have the current display repainted, including
         //    a background erase.
         LifeMain.boolPaintAll = true;
         this.Invalidate();

         // Call the base class.
         base.OnMouseUp( e );
      }

      protected override void OnPaint(PaintEventArgs pe)
      {
         // If requested, erase the background.
         if( LifeMain.boolPaintAll ) 
            pe.Graphics.FillRectangle
               (new SolidBrush(this.BackColor),
                pe.ClipRectangle);

         // Draw the current generation.
         //   The previous generation is included for optimization 
         //   purposes only (only draw what has changed).
         if( refCurr != null )
         {
            this.DrawGeneration(refCurr, refPrev, pe.Graphics);
         }
      }

      protected override void OnPaintBackground
                                 (PaintEventArgs pe)
      {
         // Do NOT call the base class routine.  
         //    This control does its own erase
         //    background from within the paint
         //    event.
      }

      #endregion

      #region Drawing Routines

      // Draw the current generation.
      internal void DrawGeneration( 
         LifeGeneration genCurr, 
         LifeGeneration genPrev, 
         Graphics graphLifeGame)
         {
         // Calculate the range of rows to display.
         int displayLo = 
            genCurr.middle - ((LifeMain.noofDisplay-1)/2);
         int displayHi = 
            displayLo + (LifeMain.noofDisplay-1);

         // For each of those rows.
         for (int j = displayLo; j <= displayHi; j++)
         {
            // Only draw the row if necessary.
            if( LifeMain.boolPaintAll == true
               || genCurr.countGeneration <= 1
               || genCurr.Rows[j].CompareTo(genPrev.Rows[j]) 
                  != 0 )
            {
               this.DrawRow(genCurr.Rows[j], 
                            genPrev.Rows[j], 
                            j,
                            graphLifeGame);
            }
         }
      }

      // Draw the current row.
      internal void DrawRow( 
         LifeRow rowCurr, 
         LifeRow rowPrev, 
         int ixRow, 
         Graphics graphLifeGame)
      {
         // Calculate the range of rows to display.
         int displaySpan = LifeMain.noofDisplay;
         int displayLo = rowCurr.middle - ((displaySpan-1)/2) ;
         int displayHi = displayLo + (displaySpan-1);

         // Drawing tools
         int xUnit = 
            (int)(this.ClientRectangle.Width / displaySpan);
         int yUnit = 
            (int)(this.ClientRectangle.Height / displaySpan);
         SolidBrush brshLive = new SolidBrush(Color.Black);
         SolidBrush brshDead = new SolidBrush(Color.Tan);

         // This routine attemps to optimize the
         //    drawing of rows.  Rows are drawn
         //    using FillRect.  The three primary
         //    optimizations are:
         // 1.   Do not erase the background.
         // 2.   Draw contiguous cells of the same
         //      state (color) in a single FillRect
         //      call.
         // 3.   Do not call FillRect if the rectangle
         //      specified is already the correct
         //      color.  That is, if there is no 
         //      change in the range of cells since
         //      the previous generation.

         int ixStart = displayLo  // The left cell of the rect.
            , ixEnd = displayHi   // The right cell of the rect.
            , j = displayLo;      // The current cell.
         byte byteCurrent = rowCurr.cellsRow[displayLo];

         // Force the last cell of a row to end a rectangle.
         byte cellTemp = rowCurr.cellsRow[displayHi];
         rowCurr.cellsRow[displayHi] = 2;

         // Scan from the end of the previous rectangle until 
         //    a change in cell value occurs, indicating the
         //    need for a new rectangle.
         for (j = displayLo; j <= displayHi; j++)
         {
            if (rowCurr.cellsRow[j] != byteCurrent)
            {
               // Note the end of the rectangle.
               ixEnd = j-1;

               // Only call FillRect if nexessary.
               if ( LifeMain.boolPaintAll
                  || rowCurr.CompareTo(rowPrev, ixStart, ixEnd) != 0 ) 
               {
                  graphLifeGame.FillRectangle(
                     byteCurrent == 1 ? brshLive : brshDead,
                     (ixStart-displayLo)*xUnit,
                     (ixRow-displayLo)*yUnit,
                     ((ixEnd-ixStart)+1)*xUnit,
                     1*yUnit);
               }
               
               // Note the start of the next rectangle.
               ixStart = j;
               // Note the value of the new rectangle's
               //    starting cell.
               byteCurrent = rowCurr.cellsRow[j];
            }
         }

         // Restore the last cell to its origional value.
         rowCurr.cellsRow[displayHi] = cellTemp;
      }

      #endregion
   }
}
