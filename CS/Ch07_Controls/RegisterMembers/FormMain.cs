//-----------------------------------------------------------------------------
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;

namespace RegisterMembers
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FormRegister : System.Windows.Forms.Form
	{
      internal System.Windows.Forms.Panel panelChild;
      internal System.Windows.Forms.Label lblGender;
      internal System.Windows.Forms.RadioButton optFemale;
      internal System.Windows.Forms.RadioButton optMale;
      internal System.Windows.Forms.Label lblBorn;
      internal System.Windows.Forms.TextBox textBorn;
      internal System.Windows.Forms.Panel panelWho;
      internal System.Windows.Forms.TextBox textName;
      internal System.Windows.Forms.Label lblName;
      internal System.Windows.Forms.Label lblID;
      internal System.Windows.Forms.TextBox textID;
      internal System.Windows.Forms.Panel panelSponsor;
      internal System.Windows.Forms.Label lblSponsID;
      internal System.Windows.Forms.TextBox textSponsID;
      internal System.Windows.Forms.Panel panelAddress;
      internal System.Windows.Forms.ComboBox cboxCity;
      internal System.Windows.Forms.Label lblSP;
      internal System.Windows.Forms.Label lblCity;
      internal System.Windows.Forms.Label lblStreet;
      internal System.Windows.Forms.TextBox textSP;
      internal System.Windows.Forms.TextBox textCity;
      internal System.Windows.Forms.TextBox textStreet;
      internal System.Windows.Forms.Label lblPC;
      internal System.Windows.Forms.TextBox textPC;
      internal System.Windows.Forms.Panel panelMemberType;
      internal System.Windows.Forms.RadioButton optAssociate;
      internal System.Windows.Forms.RadioButton optChild;
      internal System.Windows.Forms.RadioButton optAdult;
      internal System.Windows.Forms.Button cmdAdd;
		private System.Windows.Forms.MainMenu mainMenu1;

      private string genderMember;

		public FormRegister()
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
         this.mainMenu1 = new System.Windows.Forms.MainMenu();
         this.panelChild = new System.Windows.Forms.Panel();
         this.lblGender = new System.Windows.Forms.Label();
         this.optFemale = new System.Windows.Forms.RadioButton();
         this.optMale = new System.Windows.Forms.RadioButton();
         this.lblBorn = new System.Windows.Forms.Label();
         this.textBorn = new System.Windows.Forms.TextBox();
         this.panelWho = new System.Windows.Forms.Panel();
         this.textName = new System.Windows.Forms.TextBox();
         this.lblName = new System.Windows.Forms.Label();
         this.lblID = new System.Windows.Forms.Label();
         this.textID = new System.Windows.Forms.TextBox();
         this.panelSponsor = new System.Windows.Forms.Panel();
         this.lblSponsID = new System.Windows.Forms.Label();
         this.textSponsID = new System.Windows.Forms.TextBox();
         this.panelAddress = new System.Windows.Forms.Panel();
         this.cboxCity = new System.Windows.Forms.ComboBox();
         this.lblSP = new System.Windows.Forms.Label();
         this.lblCity = new System.Windows.Forms.Label();
         this.lblStreet = new System.Windows.Forms.Label();
         this.textSP = new System.Windows.Forms.TextBox();
         this.textCity = new System.Windows.Forms.TextBox();
         this.textStreet = new System.Windows.Forms.TextBox();
         this.lblPC = new System.Windows.Forms.Label();
         this.textPC = new System.Windows.Forms.TextBox();
         this.panelMemberType = new System.Windows.Forms.Panel();
         this.optAssociate = new System.Windows.Forms.RadioButton();
         this.optChild = new System.Windows.Forms.RadioButton();
         this.optAdult = new System.Windows.Forms.RadioButton();
         this.cmdAdd = new System.Windows.Forms.Button();
         // 
         // panelChild
         // 
         this.panelChild.Controls.Add(this.lblGender);
         this.panelChild.Controls.Add(this.optFemale);
         this.panelChild.Controls.Add(this.optMale);
         this.panelChild.Controls.Add(this.lblBorn);
         this.panelChild.Controls.Add(this.textBorn);
         this.panelChild.Location = new System.Drawing.Point(4, 189);
         this.panelChild.Size = new System.Drawing.Size(232, 48);
         // 
         // lblGender
         // 
         this.lblGender.Location = new System.Drawing.Point(8, 0);
         this.lblGender.Size = new System.Drawing.Size(56, 20);
         this.lblGender.Text = "Gender";
         this.lblGender.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // optFemale
         // 
         this.optFemale.Location = new System.Drawing.Point(73, 0);
         this.optFemale.Size = new System.Drawing.Size(32, 20);
         this.optFemale.Text = "F";
         // 
         // optMale
         // 
         this.optMale.Location = new System.Drawing.Point(112, 0);
         this.optMale.Size = new System.Drawing.Size(32, 20);
         this.optMale.Text = "M";
         // 
         // lblBorn
         // 
         this.lblBorn.Location = new System.Drawing.Point(8, 24);
         this.lblBorn.Size = new System.Drawing.Size(56, 20);
         this.lblBorn.Text = "Born";
         this.lblBorn.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // textBorn
         // 
         this.textBorn.Location = new System.Drawing.Point(72, 23);
         this.textBorn.Text = "";
         // 
         // panelWho
         // 
         this.panelWho.Controls.Add(this.textName);
         this.panelWho.Controls.Add(this.lblName);
         this.panelWho.Controls.Add(this.lblID);
         this.panelWho.Controls.Add(this.textID);
         this.panelWho.Location = new System.Drawing.Point(4, 45);
         this.panelWho.Size = new System.Drawing.Size(232, 48);
         // 
         // textName
         // 
         this.textName.Location = new System.Drawing.Point(72, 24);
         this.textName.Text = "";
         // 
         // lblName
         // 
         this.lblName.Location = new System.Drawing.Point(8, 25);
         this.lblName.Size = new System.Drawing.Size(56, 20);
         this.lblName.Text = "Name";
         this.lblName.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // lblID
         // 
         this.lblID.Location = new System.Drawing.Point(8, 0);
         this.lblID.Size = new System.Drawing.Size(56, 20);
         this.lblID.Text = "ID No";
         this.lblID.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // textID
         // 
         this.textID.Location = new System.Drawing.Point(72, 0);
         this.textID.Text = "";
         // 
         // panelSponsor
         // 
         this.panelSponsor.Controls.Add(this.lblSponsID);
         this.panelSponsor.Controls.Add(this.textSponsID);
         this.panelSponsor.Location = new System.Drawing.Point(4, 93);
         this.panelSponsor.Size = new System.Drawing.Size(232, 24);
         // 
         // lblSponsID
         // 
         this.lblSponsID.Location = new System.Drawing.Point(8, 1);
         this.lblSponsID.Size = new System.Drawing.Size(56, 20);
         this.lblSponsID.Text = "Spons ID";
         this.lblSponsID.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // textSponsID
         // 
         this.textSponsID.Location = new System.Drawing.Point(72, 0);
         this.textSponsID.Text = "";
         // 
         // panelAddress
         // 
         this.panelAddress.Controls.Add(this.cboxCity);
         this.panelAddress.Controls.Add(this.lblSP);
         this.panelAddress.Controls.Add(this.lblCity);
         this.panelAddress.Controls.Add(this.lblStreet);
         this.panelAddress.Controls.Add(this.textSP);
         this.panelAddress.Controls.Add(this.textCity);
         this.panelAddress.Controls.Add(this.textStreet);
         this.panelAddress.Controls.Add(this.lblPC);
         this.panelAddress.Controls.Add(this.textPC);
         this.panelAddress.Location = new System.Drawing.Point(4, 117);
         this.panelAddress.Size = new System.Drawing.Size(232, 72);
         // 
         // cboxCity
         // 
         this.cboxCity.Items.Add("Seattle");
         this.cboxCity.Items.Add("Bellevue");
         this.cboxCity.Items.Add("Kirkland");
         this.cboxCity.Items.Add("Redmond");
         this.cboxCity.Items.Add("Bothell");
         this.cboxCity.Items.Add("Monroe");
         this.cboxCity.Location = new System.Drawing.Point(72, 23);
         this.cboxCity.Size = new System.Drawing.Size(152, 22);
         this.cboxCity.SelectedIndexChanged += new System.EventHandler(this.cboxCity_SelectedIndexChanged);
         // 
         // lblSP
         // 
         this.lblSP.Location = new System.Drawing.Point(8, 48);
         this.lblSP.Size = new System.Drawing.Size(56, 20);
         this.lblSP.Text = "SP";
         this.lblSP.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // lblCity
         // 
         this.lblCity.Location = new System.Drawing.Point(8, 26);
         this.lblCity.Size = new System.Drawing.Size(56, 20);
         this.lblCity.Text = "City";
         this.lblCity.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // lblStreet
         // 
         this.lblStreet.Location = new System.Drawing.Point(8, 6);
         this.lblStreet.Size = new System.Drawing.Size(56, 16);
         this.lblStreet.Text = "Street";
         this.lblStreet.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // textSP
         // 
         this.textSP.Location = new System.Drawing.Point(72, 46);
         this.textSP.Size = new System.Drawing.Size(40, 22);
         this.textSP.Text = "";
         // 
         // textCity
         // 
         this.textCity.Location = new System.Drawing.Point(72, 23);
         this.textCity.Size = new System.Drawing.Size(152, 22);
         this.textCity.Text = "";
         this.textCity.Validated += new System.EventHandler(this.textCity_Validated);
         // 
         // textStreet
         // 
         this.textStreet.Location = new System.Drawing.Point(72, 0);
         this.textStreet.Size = new System.Drawing.Size(152, 22);
         this.textStreet.Text = "";
         // 
         // lblPC
         // 
         this.lblPC.Location = new System.Drawing.Point(120, 49);
         this.lblPC.Size = new System.Drawing.Size(24, 20);
         this.lblPC.Text = "PC";
         this.lblPC.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // textPC
         // 
         this.textPC.Location = new System.Drawing.Point(152, 47);
         this.textPC.Size = new System.Drawing.Size(72, 22);
         this.textPC.Text = "";
         // 
         // panelMemberType
         // 
         this.panelMemberType.Controls.Add(this.optAssociate);
         this.panelMemberType.Controls.Add(this.optChild);
         this.panelMemberType.Controls.Add(this.optAdult);
         this.panelMemberType.Location = new System.Drawing.Point(36, 5);
         this.panelMemberType.Size = new System.Drawing.Size(200, 32);
         // 
         // optAssociate
         // 
         this.optAssociate.Location = new System.Drawing.Point(112, 8);
         this.optAssociate.Size = new System.Drawing.Size(80, 20);
         this.optAssociate.Text = "Associate";
         this.optAssociate.CheckedChanged += new System.EventHandler(this.optAny_CheckedChanged);
         // 
         // optChild
         // 
         this.optChild.Location = new System.Drawing.Point(64, 8);
         this.optChild.Size = new System.Drawing.Size(48, 20);
         this.optChild.Text = "Child";
         this.optChild.CheckedChanged += new System.EventHandler(this.optAny_CheckedChanged);
         // 
         // optAdult
         // 
         this.optAdult.Location = new System.Drawing.Point(8, 8);
         this.optAdult.Size = new System.Drawing.Size(56, 20);
         this.optAdult.Text = "Adult";
         this.optAdult.CheckedChanged += new System.EventHandler(this.optAny_CheckedChanged);
         // 
         // cmdAdd
         // 
         this.cmdAdd.Location = new System.Drawing.Point(196, 245);
         this.cmdAdd.Size = new System.Drawing.Size(40, 20);
         this.cmdAdd.Text = "Add";
         this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
         // 
         // FormRegister
         // 
         this.Controls.Add(this.panelChild);
         this.Controls.Add(this.panelWho);
         this.Controls.Add(this.panelSponsor);
         this.Controls.Add(this.panelAddress);
         this.Controls.Add(this.panelMemberType);
         this.Controls.Add(this.cmdAdd);
         this.Menu = this.mainMenu1;
         this.Text = "Register";
         this.Load += new System.EventHandler(this.FormRegister_Load);

      }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>

		static void Main() 
		{
			Application.Run(new FormRegister());
		}

      private void FormRegister_Load(object sender, 
                                     EventArgs e)
      {
         //  Clear the input fields
         ClearInputFields(this);

         //  Place the option buttons in a line along the
         //     top of the form, right justified.
         PositionOptionButtons();

         //  Co-locate the City combobox and 
         //     its associated text box.
         textCity.Bounds = cboxCity.Bounds;

         //  Add the "(new Entry)" item at to top of the list.
         //  Select it.
         //  Show the ComboBox
         cboxCity.Items.Insert(0, "(new Entry)");
         cboxCity.SelectedIndex = 0;
         cboxCity.BringToFront();

         //  Default to an Adult entry.
         this.optAdult.Checked = true;
      }

      private void optAny_CheckedChanged(object sender, 
                                         System.EventArgs e)
      {
         //  Hide what you do not need, 
         //     show what you do need.
         panelSponsor.Visible = 
               optAssociate.Checked || optChild.Checked;
         panelAddress.Visible = 
               optAdult.Checked || optAssociate.Checked;
         panelChild.Visible = optChild.Checked;

         //  Position panels.
         int topNext = panelWho.Bottom;
         if (panelSponsor.Visible ) 
         {
            panelSponsor.Top = topNext;
            topNext = panelSponsor.Bottom;
         }
         if (panelAddress.Visible ) 
         {
            panelAddress.Top = topNext;
            topNext = panelAddress.Bottom;
         }
         if (panelChild.Visible ) 
         {
            panelChild.Top = topNext;
            topNext = panelChild.Bottom;
         }
      }

      private void cboxCity_SelectedIndexChanged(object sender,
                                                 EventArgs e)
      {
         //  if ( the user requested free form test entry
         if ( cboxCity.SelectedIndex == 0 ) 
         {
            //  Clear the TextBox
            //  Show it
            //  Give it the focus.
            textCity.Text = string .Empty;
            textCity.BringToFront();
            textCity.Focus();
         }
      }

      private void textCity_Validated(object sender, 
                                      EventArgs e)
      {
         //  The user has completed their data entry
         //     and that data has passed all edits.
         if ( textCity.Text.Trim() != string.Empty ) 
         {
            //  Add their entry to the ComboBox//s dropdown list.
            //  Select it.
            //  Show the ComboBox.
            cboxCity.Items.Insert(1, textCity.Text);
            cboxCity.SelectedIndex = 1;
         }
         cboxCity.BringToFront();
      }

      private void cmdAdd_Click(object sender, System.EventArgs e)
      {
         //  Code to register a member goes here 
         //        :
         //        :
         genderMember = 
            optFemale.Checked ? "F" : 
               optMale.Checked ? "M" : "X";
         //        :
         //        :
         ClearInputFields(this);
      } 
   
      private void PositionOptionButtons() 
      {
      //  Place the option buttons in a line along the
      //     top of the form, right justified.
         panelMemberType.BackColor = Color.Bisque;
         panelMemberType.Height = optAdult.Height;
         panelMemberType.Width = optAdult.Width 
                               + optAssociate.Width 
                               + optChild.Width;
         panelMemberType.Location = 
            new Point(this.ClientRectangle.Width - 
                           panelMemberType.Width, 0);
         optAssociate.Location = 
            new Point(panelMemberType.ClientRectangle.Width - 
                           optAssociate.Width, 0);
         optChild.Location = 
            new Point(optAssociate.Left - optChild.Width, 0);
         optAdult.Location = 
            new Point(optChild.Left - optAdult.Width, 0);
      }

      private void ClearInputFields(Control ctrlContainer) 
      {
         ClearTextBoxes(ctrlContainer);
         cboxCity.SelectedIndex = 0;
         textID.Focus();
      }

      private void ClearTextBoxes(Control ctrlContainer) 
      {
         foreach(Control theControl in ctrlContainer.Controls )
         {
            //  Recursively perform this routine.
            ClearInputFields(theControl);
            //  Clear all TextBoxes that are first
            //     level children of this control.
            if (theControl.GetType().ToString() ==
               "System.Windows.Forms.TextBox")
            {
               theControl.Text = string.Empty;
            }
         }
      }

   }
}
