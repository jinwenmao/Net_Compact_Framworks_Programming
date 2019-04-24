// DotControl.cs - Custom control for JaspersDots game.
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
   /// Summary description for DotControl.
   /// </summary>
   public class DotControl : System.Windows.Forms.Control
   {
      private FormMain formParent;
      private Brush m_brPlayer1;
      private Brush m_brPlayer2;
      private Squares sq;

      public DotControl(FormMain form)
      {
         formParent = form;

         formParent.Controls.Add(this);
         this.Paint += new 
            PaintEventHandler(this.DotControl_Paint);
         this.MouseDown += new 
            MouseEventHandler(this.DotControl_MouseDown);
         this.Left = 0;
         this.Top = 64;
         this.Width = 240;
         this.Height = 240;

         sq = new Squares(this);
      }

      public bool SetGridSize(int cxWidth, int cyHeight)
      {
         return sq.SetGridSize(cxWidth, cyHeight);
      }

      public bool SetPlayerColors(Color clr1, Color clr2)
      {
         m_brPlayer1 = new SolidBrush(clr1);
         m_brPlayer2 = new SolidBrush(clr2);
         
         return sq.SetPlayerBrushes(m_brPlayer1, m_brPlayer2);
      }


      private void 
      DotControl_MouseDown(object sender, MouseEventArgs e)
      {
         // Check result.
         int iResult = sq.HitTest(e.X, e.Y, 
            formParent.CurrentPlayer);

         // Click on available line, no score.
         if(iResult == 1)
         {
            formParent.NextPlayer();
         }

         // Click on available line, score.
         if (iResult == 2)
         {
            int iScore1 = sq.GetScore(1);
            formParent.DisplayScore(1, iScore1);
            int iScore2 = sq.GetScore(2);
            formParent.DisplayScore(2, iScore2);
            
            int count = sq.Height * sq.Width;
            if (iScore1 + iScore2 == count)
            {
               string strResult = null;

               if (iScore1 > iScore2)
                  strResult = "Player 1 wins!";
               else if (iScore1 < iScore2)
                  strResult = "Player 2 wins!";
               else
                  strResult = "Tie Game!";

               MessageBox.Show(strResult, "JaspersDots");
            }
         }
      }

      private void 
      DotControl_Paint(object sender, PaintEventArgs e)
      {
         // Fill squares which players now own.
         sq.FillSquares(e.Graphics);

         // Draw lines which players have selected.
         sq.DrawLines(e.Graphics);

         // Draw dots in grid.
         sq.DrawDots(e.Graphics);
      }

   } // class
} // namespace
