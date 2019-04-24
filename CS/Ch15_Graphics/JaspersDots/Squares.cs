// Squares.cs - Handles details of game squares for 
// JasperDots game.
//
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.

using System;
using System.Drawing;
using System.Windows.Forms;

namespace JaspersDots
{
   /// <summary>
   /// Summary description for Squares.
   /// </summary>
   public class Squares
   {
      public int Width
      {   
         get   { return cxWidth; }  
      }
      public int Height
      {
         get   { return cyHeight; }  
      }

      private int cxLeft = 15;
      private int cyTop  = 15;
      private int cxWidth;
      private int cyHeight;
      const int cxLine = 20;
      const int cyLine = 20;
      const int cxyDelta = 5;
      private Square [,] m_asq;

      private Control m_ctrlParent;
      private Brush m_brPlayer1;
      private Brush m_brPlayer2;
      private Brush m_brBackground = new
         SolidBrush(SystemColors.Window);
      private Brush hbrBlack = new SolidBrush(Color.Black);
      private Point ptTest = new Point(0,0);
      Rectangle rc = new Rectangle(0, 0, 0, 0);
      private Size  szDot = new Size(4,4);
      
      Pen penLine = new Pen(Color.Black);

      public Squares(Control ctrlParent)
      {
         m_ctrlParent = ctrlParent;
      } // Squares()

      public bool SetGridSize(
         int cxNewWidth,     // Width of array.
         int cyNewHeight     // Height of array.
         )
      {
         // Temporary scratch space.
         Rectangle rcTemp = new Rectangle(0,0,0,0);
         Point     ptTemp = new Point(0,0);
         Size      szTemp = new Size(0,0);

         // Set up array to track squares.
         cxWidth = cxNewWidth;
         cyHeight = cyNewHeight;
         m_asq = new Square[cxWidth, cyHeight];
         if (m_asq == null)
            return false;

         int x, y;
         for (x = 0; x < cxWidth; x++)
         {
            for (y = 0; y < cyHeight; y++)
            {
               m_asq[x,y].iOwner = 0; // No owner.
               int xLeft = cxLeft + x * cxLine;
               int yTop = cyTop + y * cyLine;
               int xRight = cxLeft + (x+1) * cxLine;
               int yBottom = cyTop + (y+1) * cyLine;
               int cxTopBottom = cxLine - (2 * cxyDelta);
               int cyTopBottom = cxyDelta * 2;
               int cxLeftRight = cxyDelta * 2;
               int cyLeftRight = cxLine - (2 * cxyDelta);

               // Main rectangle.
               ptTemp.X = xLeft + 1;
               ptTemp.Y = yTop + 1;
               szTemp.Width = xRight - xLeft - 1;
               szTemp.Height = yBottom - yTop - 1;
               rcTemp.Location = ptTemp;
               rcTemp.Size = szTemp;
               m_asq[x,y].rcMain = rcTemp;

               // Top hit rectangle.
               m_asq[x,y].rcTop =
                  new Rectangle(xLeft + cxyDelta, 
                  yTop - cxyDelta,
                  cxTopBottom,
                  cyTopBottom);
               m_asq[x,y].bTop = false;

               // Right hit rectangle.
               m_asq[x,y].rcRight =
                  new Rectangle(xRight - cxyDelta,
                  yTop + cxyDelta,
                  cxLeftRight,
                  cyLeftRight);
               m_asq[x,y].bRight = false;

               // Bottom hit rectangle.
               m_asq[x,y].rcBottom =
                  new Rectangle(xLeft + cxyDelta, 
                  yBottom - cxyDelta,
                  cxTopBottom,
                  cyTopBottom);
               m_asq[x,y].bBottom = false;

               // Left hit rectangle.
               m_asq[x,y].rcLeft =
                  new Rectangle(xLeft - cxyDelta,
                  yTop + cxyDelta,
                  cxLeftRight,
                  cyLeftRight);
               m_asq[x,y].bLeft = false;

            } // for y
         } // for x

         return true;
      }

      public bool 
      SetPlayerBrushes(
         Brush br1,      // Brush color for player 1.
         Brush br2       // Brush color for player 2.
         )
      {
         m_brPlayer1 = br1;
         m_brPlayer2 = br2;

         return true;
      }

      //--------------------------------------------------------
      public void
      FillOneSquare(Graphics g, int x, int y)
      {
         Brush brCurrent = m_brBackground;
         if (m_asq[x,y].iOwner == 1)
            brCurrent = m_brPlayer1;
         else if (m_asq[x,y].iOwner == 2)
            brCurrent = m_brPlayer2;
         g.FillRectangle(brCurrent, m_asq[x,y].rcMain);
      }

      // FillSquares -- Fill owned squares with a player's color
      //
      public void 
      FillSquares(Graphics g)
      {
         int x, y;
         for (x = 0; x < cxWidth; x++)
         {
            for (y = 0; y < cyHeight; y++)
            {
               if (m_asq[x,y].iOwner != 0)
               {
                  FillOneSquare(g, x, y);
               }
            }
         }
      } // FillSquares()

      //
      // DrawOneLine
      //
      public void DrawOneLineSet(Graphics g, int x, int y)
      {
         int xLeft = cxLeft + x * cxLine;
         int yTop = cyTop + y * cyLine;
         int xRight = cxLeft + (x+1) * cxLine;
         int yBottom = cyTop + (y+1) * cyLine;
               
         if (m_asq[x,y].bTop)
            g.DrawLine(penLine, xLeft, yTop, xRight, yTop);
         if (m_asq[x,y].bRight)
            g.DrawLine(penLine, xRight, yTop, xRight, yBottom);
         if (m_asq[x,y].bBottom)
            g.DrawLine(penLine, xRight, yBottom, xLeft, yBottom);
         if (m_asq[x,y].bLeft)
            g.DrawLine(penLine, xLeft, yBottom, xLeft, yTop);
      } // DrawOneLineSet()

      //
      // DrawLines -- Draw lines which have been hit.
      //
      public void DrawLines(Graphics g)
      {
         int x, y;
         for (x = 0; x < cxWidth; x++)
         {
            for (y = 0; y < cyHeight; y++)
            {
               DrawOneLineSet(g, x, y);
            }
         }
      } // DrawLines()

      public void DrawDots (Graphics g)
      {
         // Draw array of dots.
         int x, y;
         for (x = 0; x <= cxWidth; x++)
         {
            for (y = 0; y <= cyHeight; y++)
            {
               ptTest.X = (cxLeft - 2) + x * cxLine;
               ptTest.Y = (cyTop - 2) + y * cyLine;
               rc.Location = ptTest;
               rc.Size = szDot;
               g.FillEllipse(hbrBlack, rc);
            }
         }
      } // DrawDots

      public enum Side
      {
         None,
         Left,
         Top,
         Right,
         Bottom
      }

      //
      // HitTest - check whether a point hits a line.
      //
      // Return values:
      // 0 = miss
      // 1 = hit a line
      // 2 = hit and completed a square.
      public int HitTest(int xIn, int yIn, int iPlayer)
      {
         int x, y;
         bool bHit1 = false;
         bool bHit2 = false;
         Side sideHit = Side.None;
         for (x = 0; x < cxWidth; x++)
         {
            for (y = 0; y < cyHeight; y++)
            {
               // If already owned, do not check
               if (m_asq[x,y].iOwner != 0)
                  continue;

               // Otherwise check for lines against point.
               if (m_asq[x,y].rcTop.Contains(xIn, yIn))
               {
                  // Line already hit?
                  if (m_asq[x,y].bTop) // Line already hit?
                     return 0;
                  // If not, set line as hit.
                  sideHit = Side.Top;
                  m_asq[x,y].bTop = true;
               }
               else if (m_asq[x,y].rcLeft.Contains(xIn, yIn))
               {
                  // Line already hit?
                  if (m_asq[x,y].bLeft) // Line already hit?
                     return 0;
                  // If not, set line as hit.
                  sideHit = Side.Left;
                  m_asq[x,y].bLeft = true;
               }
               else if (m_asq[x,y].rcRight.Contains(xIn, yIn))
               {
                  // Line already hit?
                  if (m_asq[x,y].bRight) // Line already hit?
                     return 0;
                  // If not, set line as hit.
                  sideHit = Side.Right;
                  m_asq[x,y].bRight = true;
               }
               else if (m_asq[x,y].rcBottom.Contains(xIn, yIn))
               {
                  // Line already hit?
                  if (m_asq[x,y].bBottom) // Line already hit?
                     return 0;
                  // If not, set line as hit.
                  sideHit = Side.Bottom;
                  m_asq[x,y].bBottom = true;
               }
               
               // No hit in current square -- keep looking
               if (sideHit == Side.None)
                  continue;

               // We hit a side
               bHit1 = true;

               // Draw sides
               Graphics g = m_ctrlParent.CreateGraphics();
               DrawOneLineSet(g, x, y);

               // Check whether square is now complete.
               // We hit a line - check for hitting a square.
               if (m_asq[x,y].bLeft &&
                     m_asq[x,y].bTop &&
                     m_asq[x,y].bRight &&
                     m_asq[x,y].bBottom)
               {
                  // Side is complete.
                  m_asq[x,y].iOwner = iPlayer;
                  bHit2 = true;

                  // Fill current square
                  FillOneSquare(g, x, y);
               }
               
               g.Dispose();

            } // for y
         } // for x

         if (bHit2) return 2;
         else if (bHit1) return 1;
         else return 0;

      } // HitTest

      //
      // GetScore - Get current score for player N
      //
      public int GetScore (int iPlayer)
      {
         int iScore = 0;
         int x, y;
         for (x = 0; x < cxWidth; x++)
         {
            for (y = 0; y < cyHeight; y++)
            {
               if (m_asq[x,y].iOwner == iPlayer)
                  iScore++;
            }
         }
         return iScore;
      } // GetScore

   } // class Squares

} // namespace
