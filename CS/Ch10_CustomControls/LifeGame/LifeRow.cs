//-----------------------------------------------------------------------------
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Drawing;

namespace LifeGame
{
   /// <summary>
   /// Summary description for LifeRow.
   ///   Contains an array of integer cells.  Each cell 
   ///      is either alive (1) or dead (0).
   /// </summary>

   internal class LifeRow
   {
      #region Properties

      //	Member variables.
      internal byte[] cellsRow = new byte[LifeMain.noofCells];
      internal uint noofLive;

      //	Some convenience fields.
      internal int hi, lo, middle;

      #endregion

      #region System Methods
	
      internal LifeRow()
      {
         //	Set the convenience fields.
         lo = cellsRow.GetLowerBound(0);
         hi = cellsRow.GetUpperBound(0);
         middle = lo + ((hi - lo) / 2);
      }

      #endregion

      #region Internal Methods
	
      internal LifeRow CalcNextGen(LifeRow rowAbove, LifeRow rowBelow)
      {
         //	Create an empty row.
         LifeRow rowNextGen = new LifeRow();
			
         //	If this row and the row above 
         //		and the row below are all
         //		empty, then the next generation
         //		will be an empty row.
         if (this.noofLive==0 && rowAbove.noofLive==0 && rowBelow.noofLive==0)
         {
            return rowNextGen;
         }

         //	For each cell in the row:
         //		(Leave the end cells blank.)
         int workSum;
         for (int j = lo+1; j <= hi-1; j++)
         {
            //	Sum the number of adjacent live cells.
            workSum = 
               + cellsRow[j-1]
               + cellsRow[j+1]
               + rowAbove.cellsRow[j-1]
               + rowAbove.cellsRow[j]
               + rowAbove.cellsRow[j+1]
               + rowBelow.cellsRow[j-1]
               + rowBelow.cellsRow[j]
               + rowBelow.cellsRow[j+1];

            //	Any cell with three live neighbors
            //		will become/remain a live cell.  
            //		Any live	cell with two live
            //		neighbors will remain a live cell.
            rowNextGen.cellsRow[j] = (byte)
               (	( workSum == 3 
               || ( cellsRow[j] == 1 && workSum == 2 ) )
               ? 1 : 0);

            // Increment the live cell count,
            //		as appropriate.
            rowNextGen.noofLive += rowNextGen.cellsRow[j];
         }
         return rowNextGen;
      }

      internal void SetRow (int[] arrayArgs)
      {
         //	Every cell specified by arrayArgs
         //		becomes a live cell.  All other
         //		cells die.
         cellsRow = new byte[LifeMain.noofCells];
         foreach (int argIn in arrayArgs)
         {
            cellsRow[argIn] = 1;
            noofLive++;
         }
      }

      internal void FlipCell (int ixCell)
      {
         //	Toggle the cell specified
         //		by ixCell.
         if (cellsRow[ixCell] == 0)
         {
            cellsRow[ixCell] = 1;
            noofLive++;
         }
         else
         {
            cellsRow[ixCell] = 0;
            noofLive--;
         }
      }

      internal void CopyTo( LifeRow rowTarget )
      {
         //	Check for null reference.
         if ( rowTarget == null )
            return;

         //	Copy the relevant info from row to row.
         this.cellsRow.CopyTo(rowTarget.cellsRow, 0);
         rowTarget.noofLive = this.noofLive;
      }

      internal int CompareTo( LifeRow rowTarget )
      {
         //	CompareTo tradionally returns three
         //		possible values, 0 (==), -1 (<)
         //		and +1 (>); and we wish to 
         //		maintain that convention.  But,
         //		for a row, only "==" and "!=" 
         //		is meaningful.  So the definition
         //		of "<" and ">" is somewhat arbitrary 
         //		here.
         //	The definition of "<" and ">" in
         //		this code sequence is optimized
         //		for performance, given that 
         //		most CompareTo calls will be
         //		comparing the Nth row of one
         //		generation to the Nth row of
         //		an adjacent generation.
         //	"Equal" means identical values in
         //		cells of equal index values for 
         //		all possible index values.

         if ( rowTarget == null )
            return 1;

         if (this.noofLive==0 && rowTarget.noofLive==0 )
            return 0;

         if (this.noofLive < rowTarget.noofLive )
            return -1;
         if (this.noofLive > rowTarget.noofLive )
            return 1;

         for (int j = lo; j <= hi; j++)
         {
            if (cellsRow[j] == rowTarget.cellsRow[j]) 
               continue;
            if (cellsRow[j] < rowTarget.cellsRow[j]) 
               return -1;
            if (cellsRow[j] > rowTarget.cellsRow[j]) 
               return +1;
         }
         return 0;
      }

      internal int CompareTo( LifeRow rowTarget
         , int ixBegin, int ixEnd )
      {
         //	Overloaded version.  Specifies a 
         //		begin and end for the range of
         //		cells to compare.

         if ( rowTarget == null )
            return 1;

         for (int j = ixBegin; j <= ixEnd; j++)
         {
            if (cellsRow[j] == rowTarget.cellsRow[j]) 
               continue;
            if (cellsRow[j] < rowTarget.cellsRow[j]) 
               return -1;
            if (cellsRow[j] > rowTarget.cellsRow[j]) 
               return +1;
         }
         return 0;
      }

      #endregion
   }
}
