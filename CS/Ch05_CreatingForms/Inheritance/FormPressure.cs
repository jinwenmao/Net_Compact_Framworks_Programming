// #define FORM_DESIGN

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace FormsCollection
{
   /// <summary>
   /// Summary description for FormPressure.
   /// </summary>
#if (FORM_DESIGN)
   public class FormPressure : System.Windows.Forms.Form
#else
   public class FormPressure : WeatherGage.FormGage
#endif
   {
   
      public FormPressure()
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         //
         // TODO: Add any constructor code after InitializeComponent call
         //
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
         // 
         // FormPressure
         // 
         this.Text = "FormPressure";
         this.Load += new System.EventHandler(this.FormPressure_Load);
         this.Closed += new System.EventHandler(this.FormPressure_Closed);

      }
      #endregion

      private void FormPressure_Load(object sender, System.EventArgs e)
      {
         LoadPressures();      
      }

      private void LoadPressures() 
      {
         //  Load sample barometric pressures into controls.
         double[] adblPressures  = 
                     {
                        29.92, 29.92, 29.93, 29.93, 29.93, 29.93, 
                        29.94, 29.94, 29.94, 29.95, 29.96, 29.96, 
                        29.96, 29.96, 29.97, 29.97, 29.96, 29.96, 
                        29.95, 29.95, 29.94, 29.94, 29.93, 29.93};

         lblCurrent.Text = adblPressures[0].ToString();
         foreach (double dblPressure in adblPressures)
            lboxPast.Items.Add(dblPressure.ToString());
      }

      private void FormPressure_Closed(object sender, System.EventArgs e)
      {
         Global.RemoveForm(this);
      }

   }
}
