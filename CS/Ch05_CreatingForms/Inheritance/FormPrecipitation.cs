#define FORM_DESIGN

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace FormsCollection
{
   /// <summary>
   /// Summary description for FormPrecipitation.
   /// </summary>
#if (FORM_DESIGN)
   public class FormPrecipitation : System.Windows.Forms.Form
#else
   public class FormPrecipitation : WeatherGage.FormGage
#endif
   {
   
      public FormPrecipitation()
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
         // FormPrecipitation
         // 
         this.Text = "FormPrecipitation";
         this.Load += new System.EventHandler(this.FormPrecipitation_Load);
         this.Closed += new System.EventHandler(this.FormPrecipitation_Closed);

      }
      #endregion

      private void FormPrecipitation_Load(object sender, System.EventArgs e)
      {
         LoadRainFalls();
      } 

      private void LoadRainFalls() 
      {
         //  Load sample rainfalls into controls.
         double[] adblRains  = 
                     {0.12, 0.12, 0.13, 0.13, 0.13, 0.13, 
                      0.14, 0.14, 0.14, 0.15, 0.16, 0.16, 
                      0.16, 0.16, 0.17, 0.17, 0.16, 0.16, 
                      0.15, 0.15, 0.14, 0.14, 0.13, 0.13};

         lblCurrent.Text = adblRains[0].ToString();
         foreach (double dblRain in adblRains)
            lboxPast.Items.Add(dblRain.ToString());
      }

      private void FormPrecipitation_Closed(object sender, System.EventArgs e)
      {
         Global.RemoveForm(this);
      }
   } 
}

