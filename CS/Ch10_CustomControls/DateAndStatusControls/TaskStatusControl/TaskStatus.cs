//-----------------------------------------------------------------------------
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using YaoDurant.Gui;

namespace YaoDurant.Gui
{
   /// <summary>
   /// Summary description for TaskStatus.
   /// </summary>
   public class TaskStatus : System.Windows.Forms.Control 
   {
      #region Properties

      // The contained controls.
      private DateBox tskdtBegin, tskdtEnd;
      private TextBox txtEstimated, txtActual;

      // Their four values.
      public DateTime dateBegin
      {
         get { return tskdtBegin.Date; }
         set { tskdtBegin.Date = value; }
      }
      public DateTime dateEnd
      {
         get { return tskdtEnd.Date; }
         set { tskdtEnd.Date = value; }
      }
      public int durEstimated
      {
         get { return Convert.ToInt32(txtEstimated.Text); }
         set { txtEstimated.Text = value.ToString(); }
      }
      public int durActual
      {
         get { return Convert.ToInt32(txtActual.Text); }
         set { txtActual.Text = value.ToString(); }
      }
      
      // The current display mode:  Text or graphic.
      private enum Modes { modeText, modeGraphic }
      private Modes m_Mode;
      private Modes Mode 
      {
         get { return m_Mode; }
         set 
         {
            // Set the Mode.
            m_Mode = value;

            // Child controls are used only when in modeText.
            foreach( Control cntlX in this.Controls )
            {
               cntlX.Visible = (m_Mode==Modes.modeText);
            }

            // State has changed; redraw this.
            this.Invalidate();
         }
      }

      // Brushes for filling.
      private SolidBrush brushRed = 
         new SolidBrush(Color.Red);
      private SolidBrush brushGray = 
         new SolidBrush(Color.LightSlateGray);
      private SolidBrush brushGreen = 
         new SolidBrush(Color.Green);
      private SolidBrush brushBlack = 
         new SolidBrush(Color.Black);

      #endregion

      #region Initialization and Termination

      public TaskStatus()
      {
         // Set background color to light gray.
         this.BackColor = Color.LightSlateGray;

         // Create two DateBoxes and two TextBoxes 
         tskdtBegin = new DateBox();
         tskdtBegin.Parent = this;
         tskdtBegin.Validating += 
            new CancelEventHandler(this.Dates_Validating);
         tskdtEnd = new DateBox();
         tskdtEnd.Parent = this;
         tskdtEnd.Validating += 
            new CancelEventHandler(this.Dates_Validating);
         txtEstimated = new TextBox();
         txtEstimated.Parent = this;
         txtEstimated.Width = tskdtBegin.Width / 2;
         txtActual = new TextBox();
         txtActual.Parent = this;
         txtActual.Width = tskdtBegin.Width / 2;

         // Position them from left to right to fill this.
         int PrevRight = 0;
         foreach( Control cntlX in this.Controls )
         {
            cntlX.Left = PrevRight;
            PrevRight += cntlX.Width;
            cntlX.Visible = true;
         }
         this.Height = tskdtEnd.Height;
         this.Width = PrevRight + (this.Height / 3);

         // Set the Mode.
         this.m_Mode = Modes.modeText;
      }
      #endregion
      
      #region Overrides

      protected override void OnClick(EventArgs e)
      {
         // Call base class method.
         base.OnClick(e);

         // Swap modes.
         switch( this.Mode )
         {
            case Modes.modeText: 
               { this.Mode = Modes.modeGraphic; break; }
            case Modes.modeGraphic: 
               { this.Mode = Modes.modeText; break; }
         }
      }

      protected override void OnPaint(PaintEventArgs e)
      {
         // Call base class method.
         base.OnPaint(e);

         switch( this.Mode )
         {
            case Modes.modeText:
            {
               // In textMode the contained controls
               //    do all the work.
               break;
            }
            case Modes.modeGraphic:
            {
               // The client rectangle represents the time
               //    from task start to task end.  Draw a
               //    rectangle from the left that represents
               //    the percentage of task completion.  Draw
               //    a small triangle to mark today, relative
               //    to task start / end.
               // If more time has passed than task has been
               //    completed, the task is behind schedule;
               //    color the rectangle red.  Otherwise color
               //    it green.

               // Calculate coordinates.
               int daysStartToEnd = 
                  dateEnd.Subtract(this.dateBegin).Days;
               int daysStartToNow = 
                  DateTime.Today.Subtract(this.dateBegin).Days;
               Rectangle rectX = this.ClientRectangle;
               int xposToday = 
                  (rectX.Width*daysStartToNow) / daysStartToEnd;
               int xposComplete = 
                  (rectX.Width * durActual) / 100;
               int yposAll = this.Height / 2;
               Point[] arrptTriangle = 
                  {
                    new Point(xposToday-(yposAll/2), 0)
                  , new Point(xposToday, yposAll)
                  , new Point(xposToday+(yposAll/2), 0) };
               
               // Draw rectangle.
               rectX.Width = xposComplete;
               e.Graphics.FillRectangle(
                  (xposToday <= xposComplete) ? 
                                       brushGreen : brushRed, 
                  rectX);

               // Draw triangle.
               e.Graphics.FillPolygon(brushBlack, arrptTriangle);

               break;
            }
         }
      }
      #endregion

      #region Events
      
      private void Dates_Validating(object sender, 
                                    CancelEventArgs e)
      {
         // If the DateBox's validation routine says that
         //    the date is invalid, do not continue to 
         //    validate it.  (There is only "bad", there
         //    is no "badder").
         if( e.Cancel != true )
         {
            // Convert the two date textbox's Text 
            //    property values into dates.
            DateTime dtBegin = System.Convert.ToDateTime(tskdtBegin.Text);
            DateTime dtEnd = System.Convert.ToDateTime(tskdtEnd.Text);

            // Start date must be prior to end date.
            if( dtEnd < dtBegin )
            {
            MessageBox.Show( 
               "Start date must be prior to end date.", 
               "Error", 
               MessageBoxButtons.OK, 
               MessageBoxIcon.Exclamation, 
               MessageBoxDefaultButton.Button1);
            e.Cancel = true;
            }
         }
      }
      #endregion
   }
}
