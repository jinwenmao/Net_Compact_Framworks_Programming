#define FORM_DESIGN

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;


namespace FormsCollection
{
   /// <summary>
   /// Summary description for FormTemperature.
   /// </summary>
   /// 

#if (FORM_DESIGN)
   public class FormTemperature : System.Windows.Forms.Form
#else
   public class FormTemperature : WeatherGage.FormGage
#endif
   {
      private System.Windows.Forms.Button button1;
   
      public FormTemperature()
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
         this.button1 = new System.Windows.Forms.Button();
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(16, 176);
         this.button1.Text = "button1";
         // 
         // FormTemperature
         // 
         this.Controls.Add(this.button1);
         this.Text = "FormTemperature";
         this.Load += new System.EventHandler(this.FormTemperature_Load);
         this.Closed += new System.EventHandler(this.FormTemperature_Closed);

      }
      #endregion

      private void LoadTemperatures() 
      {
         //  Load sample temperatures into controls.
         int[] intTemperatures  = 
                     {  92, 92, 93, 93, 93, 93, 
                        94, 94, 94, 95, 96, 96, 
                        96, 96, 97, 97, 96, 96, 
                        95, 95, 94, 94, 93, 93 };

         lblCurrent.Text = intTemperatures[0].ToString();
         foreach (int intTemp in intTemperatures)
            lboxPast.Items.Add(intTemp.ToString());
      }

      private void FormTemperature_Load(object sender, System.EventArgs e)
      {
         LoadTemperatures();
      }

      private void FormTemperature_Closed(object sender, System.EventArgs e)
      {
         Global.RemoveForm(this);
      }

   }
}
