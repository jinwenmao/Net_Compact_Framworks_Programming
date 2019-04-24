//-----------------------------------------------------------------------------
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace LifeGame
{
   /// <summary>
   /// One Generation.  Consists of a set of Rows.
   /// </summary>

   internal class LifeGeneration
   {
      #region Properties

      //	An array of rows.  The heart of the generation.
      internal LifeRow[] Rows = new LifeRow[LifeMain.noofCells];

      //	Generation count.
      internal uint countGeneration;

      //	Number of live cells in this generation.  
      //		Derived by obtaining the counts from
      //		the rows.  
      internal uint noofLive
      {
         get 
         {
            uint nooflive = 0;
            for (int j = lo; j <= hi; j++)
            {
               nooflive += Rows[j].noofLive;
            }
            return nooflive;
         }
      }

      //	Some convenience fields.
      internal int hi, lo, middle;
	
      #endregion

      #region System Methods
      // Constructor.
      internal LifeGeneration()
      {
         //	Set the convenience fields.
         lo = Rows.GetLowerBound(0);
         hi = Rows.GetUpperBound(0);
         middle = lo + ((hi - lo) / 2);

         //	Create the rows.
         for (int j = lo; j <= hi; j++)
         {
            Rows[j] = new LifeRow();
         }

      }
      #endregion

      #region Internal Methods

      internal LifeGeneration CalcNextGen()
      {
         //	Each row is used to calculate its next
         //		generation.
         //	The target row, the row above, and the 
         //		row below must be examined to determine 
         //		the target row's next generation.
         //	The outermost border of cells is always
         //		left blank.
         LifeGeneration genNext = new LifeGeneration();

         genNext.countGeneration = this.countGeneration + 1;

         genNext.Rows[lo] = new LifeRow();
         for (int j = lo+1; j <= hi-1; j++)
         {
            genNext.Rows[j] = 
               Rows[j].CalcNextGen(Rows[j-1],Rows[j+1]);
         }
         genNext.Rows[hi] = new LifeRow();
			
         return genNext;
      }

      internal int CompareTo( LifeGeneration genTarget )
      {
         //	CompareTo tradionally returns three
         //		possible values, 0 (==), -1 (<)
         //		and +1 (>); and we wish to 
         //		maintain that convention.  But,
         //		for a generation, only "==" 
         //		and "!=" is meaningful.  So the 
         //		definition of "<" and ">" is somewhat 
         //		arbitrary here.

         if ( genTarget == null )
            return 1;

         if (this.noofLive==0 && genTarget.noofLive==0 )
            return 0;

         if (this.noofLive < genTarget.noofLive )
            return -1;
         if (this.noofLive > genTarget.noofLive )
            return 1;

         for (int j = lo; j <= hi; j++)
         {
            if (Rows[j].CompareTo(genTarget.Rows[j]) == 0) 
               continue;
            if (Rows[j].CompareTo(genTarget.Rows[j]) < 0) 
               return -1;
            if (Rows[j].CompareTo(genTarget.Rows[j]) > 0) 
               return +1;
         }
         return 0;
      }

      internal void Clear()
      {
         //	Clear this generation.
         for (int j = lo; j <= hi; j++)
         {
            Rows[j] = new LifeRow();
         }
         countGeneration = 0;
      }

      internal void CopyTo(LifeGeneration genTarget)
      {
         //	Copy the relevant info from gen to gen.
         for (int j = lo; j <= hi; j++)
         {
            this.Rows[j].CopyTo(genTarget.Rows[j]);
         }
         genTarget.countGeneration = this.countGeneration;
      }

      internal void SaveToFile(Stream strmFileOut)
      {
         //	Use DotNet's binary serialization to
         //		save the generation to a file.
//         IFormatter formatter = new BinaryFormatter();
//         formatter.Serialize(strmFileOut, Rows);
         strmFileOut.Close();
      }
		
      internal void ReadFromFile(Stream strmFileIn)
      {
         //	Use DotNet's binary serialization to
         //		read the generation from a file.
//         IFormatter formatter = new BinaryFormatter();
//         Rows = (LifeRow[])formatter.Deserialize(strmFileIn);
         strmFileIn.Close();
      }
		
      internal void SetPattern (LifeMain.lgpPattern Pattern)
      {
         //	Convenience variables.
         int displayLo = middle - ((LifeMain.noofDisplay-1)/2) ;
         int displayHi = displayLo + (LifeMain.noofDisplay-1);
         int gap = (middle-displayLo) / 3;

         Clear();
         switch( Pattern )
         {
            case LifeMain.lgpPattern.lgpEmpty:
               break;
            case LifeMain.lgpPattern.lgpDiagonal:
               for (int j = displayLo+1; j <= displayHi - 1; j++)
               {
                  SetRow(j, new int[1]{j});
               }
               break;
            case LifeMain.lgpPattern.lgpVertical:
               for (int j = displayLo + gap; j <= displayHi - gap; j++)
               {
                  SetRow(j, new int[1]{middle});
               }
               break;
            case LifeMain.lgpPattern.lgpFlawedVertical:
               for (int j = displayLo + gap; j <= displayHi - gap; j++)
               {
                  SetRow(j, new int[1]{middle});
               }
               FlipCell(displayHi - gap, middle+1);
               break;
            case LifeMain.lgpPattern.lgpFiveCell:
               SetRow(middle-1, new int[2]{middle, middle+1});
               SetRow(middle, new int[2]{middle-1, middle});
               SetRow(middle+1, new int[1]{middle});
               break;
            case LifeMain.lgpPattern.lgpSixCell:
               SetRow(middle-1, new int[2]{middle, middle+1});
               SetRow(middle, new int[2]{middle-1, middle});
               SetRow(middle+1, new int[2]{middle, middle+1});
               break;
            case LifeMain.lgpPattern.lgpSevenCell:
               SetRow(middle-2, new int[1]{middle});
               SetRow(middle-1, new int[3]{middle-2, middle-1, middle+1});
               SetRow(middle, new int[2]{middle-1, middle+1});
               SetRow(middle+1, new int[1]{middle});
               break;
            case LifeMain.lgpPattern.lgpEightCell:
               SetRow(middle-2, new int[1]{middle-1});
               SetRow(middle-1, new int[2]{middle-1, middle+1});
               SetRow(middle, new int[3]{middle-1, middle, middle+1});
               SetRow(middle+1, new int[2]{middle-1, middle+1});
               break;
            case LifeMain.lgpPattern.lgpTenCell:
               SetRow(194, new int[2]{195,196});
               SetRow(195, new int[2]{194,195});
               SetRow(196, new int[1]{195});
               SetRow(315, new int[1]{298});
               SetRow(316, new int[2]{298,299});
               SetRow(317, new int[2]{297,298});
               break;
            case LifeMain.lgpPattern.lgpBoard:
            case LifeMain.lgpPattern.lgpSelfFix:
            case LifeMain.lgpPattern.lgpSelfDestruct:
               for (int j = lo; j <= hi; j++)
               {
                  if (j % 3 != 0)
                  {
                     for (int k = lo; k <= hi; k++)
                     {
                        if (k % 3 != 0)
                        {
                           FlipCell(k, j);
                        }
                     }
                  }
               }
               if (Pattern == LifeMain.lgpPattern.lgpSelfFix)
                  FlipCell(middle, middle);
               if (Pattern == LifeMain.lgpPattern.lgpSelfDestruct)
                  FlipCell(middle-1, middle);
               break;
            case LifeMain.lgpPattern.lgpGlider:
               SetRow(middle-1, new int[1]{middle});
               SetRow(middle, new int[2]{middle, middle+1});
               SetRow(middle+1, new int[2]{middle-1, middle+1});
               break;
            case LifeMain.lgpPattern.lgpGliderMate:
               SetRow((middle+1) - 10, new int[2]{displayHi-(1+1), displayHi-(3+1)});
               SetRow((middle+2) - 10, new int[4]{displayLo+(1+1), displayLo+(3+1), displayHi-(2+1), displayHi-(3+1)});
               SetRow((middle+3) - 10, new int[3]{displayLo+(2+1), displayLo+(3+1), displayHi-(2+1)});
               SetRow((middle+4) - 10, new int[1]{displayLo+(2+1)});
               SetRow((middle+4) + 10, new int[1]{displayHi-2});
               SetRow((middle+5) + 10, new int[3]{displayLo+(2), displayHi-2, displayHi-3});
               SetRow((middle+6) + 10, new int[4]{displayLo+(2), displayLo+(3), displayHi-1, displayHi-3});
               SetRow((middle+7) + 10, new int[2]{displayLo+(1), displayLo+(3)});
               break;
            case LifeMain.lgpPattern.lgpGliderPump:
               SetRow((middle-5), new int[1]{middle+6});
               SetRow((middle-4), new int[2]{middle+4, middle+6});
               SetRow((middle-3), new int[3]{middle-5, middle+3, middle+5});
               SetRow((middle-2), new int[6]{middle-6, middle-5, middle+2, middle+5, middle+17, middle+18});
               SetRow((middle-1), new int[8]{middle-7, middle-6, middle-1, middle-0, middle+3, middle+5, middle+17, middle+18});
               SetRow((middle),   new int[9]{middle-17, middle-16, middle-8, middle-7, middle-6, middle-1, middle-0, middle+4, middle+6});
               SetRow((middle+1), new int[7]{middle-17, middle-16, middle-7, middle-6, middle-1, middle-0, middle+6});
               SetRow((middle+2), new int[2]{middle-6, middle-5});
               SetRow((middle+3), new int[1]{middle-5});
               break;
            default:
               break;
         }
         countGeneration = 0;
      }

      internal void SetRow (int ixRow, int[] arrayArgs)
      {
         //	Have the row do it.
         Rows[ixRow].SetRow(arrayArgs);
      }

      internal void FlipCell (int ixRow, int ixCell)
      {
         //	Have the row do it.
         Rows[ixRow].FlipCell(ixCell);
      }
      #endregion

   }
}
