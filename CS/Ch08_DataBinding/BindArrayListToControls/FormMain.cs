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
using YaoDurant.Data;

namespace BindArrayListToControls
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FormMain : System.Windows.Forms.Form
	{
      internal System.Windows.Forms.Panel panelTaskFields;
      internal System.Windows.Forms.TextBox txtTaskActual;
      internal System.Windows.Forms.TextBox txtTaskEstimated;
      internal System.Windows.Forms.TextBox txtTaskName;
      internal System.Windows.Forms.TextBox txtTaskStart;
      internal System.Windows.Forms.TextBox txtTaskEnd;
      internal System.Windows.Forms.TextBox txtTaskNo;
      internal System.Windows.Forms.Button btnCancel;
      internal System.Windows.Forms.Button btnAddTask;
      internal System.Windows.Forms.ComboBox cboxTasks;
      internal System.Windows.Forms.Label lblProjEnd;
      internal System.Windows.Forms.Label lblProjName;
      internal System.Windows.Forms.Button btnNewTask;
      internal System.Windows.Forms.Label lblProjStart;
		private System.Windows.Forms.MainMenu mainMenu1;

		public FormMain()
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
         this.panelTaskFields = new System.Windows.Forms.Panel();
         this.txtTaskActual = new System.Windows.Forms.TextBox();
         this.txtTaskEstimated = new System.Windows.Forms.TextBox();
         this.txtTaskName = new System.Windows.Forms.TextBox();
         this.txtTaskStart = new System.Windows.Forms.TextBox();
         this.txtTaskEnd = new System.Windows.Forms.TextBox();
         this.txtTaskNo = new System.Windows.Forms.TextBox();
         this.btnCancel = new System.Windows.Forms.Button();
         this.btnAddTask = new System.Windows.Forms.Button();
         this.cboxTasks = new System.Windows.Forms.ComboBox();
         this.lblProjEnd = new System.Windows.Forms.Label();
         this.lblProjName = new System.Windows.Forms.Label();
         this.btnNewTask = new System.Windows.Forms.Button();
         this.lblProjStart = new System.Windows.Forms.Label();
         // 
         // panelTaskFields
         // 
         this.panelTaskFields.Controls.Add(this.txtTaskActual);
         this.panelTaskFields.Controls.Add(this.txtTaskEstimated);
         this.panelTaskFields.Controls.Add(this.txtTaskName);
         this.panelTaskFields.Controls.Add(this.txtTaskStart);
         this.panelTaskFields.Controls.Add(this.txtTaskEnd);
         this.panelTaskFields.Controls.Add(this.txtTaskNo);
         this.panelTaskFields.Location = new System.Drawing.Point(0, 125);
         this.panelTaskFields.Size = new System.Drawing.Size(240, 64);
         // 
         // txtTaskActual
         // 
         this.txtTaskActual.Location = new System.Drawing.Point(200, 40);
         this.txtTaskActual.Size = new System.Drawing.Size(32, 22);
         this.txtTaskActual.Text = "";
         // 
         // txtTaskEstimated
         // 
         this.txtTaskEstimated.Location = new System.Drawing.Point(160, 40);
         this.txtTaskEstimated.Size = new System.Drawing.Size(32, 22);
         this.txtTaskEstimated.Text = "";
         // 
         // txtTaskName
         // 
         this.txtTaskName.Location = new System.Drawing.Point(8, 40);
         this.txtTaskName.Size = new System.Drawing.Size(144, 22);
         this.txtTaskName.Text = "";
         // 
         // txtTaskStart
         // 
         this.txtTaskStart.Location = new System.Drawing.Point(72, 8);
         this.txtTaskStart.Size = new System.Drawing.Size(72, 22);
         this.txtTaskStart.Text = "";
         this.txtTaskStart.Validating += new System.ComponentModel.CancelEventHandler(this.txtTaskDates_Validating);
         // 
         // txtTaskEnd
         // 
         this.txtTaskEnd.Location = new System.Drawing.Point(160, 8);
         this.txtTaskEnd.Size = new System.Drawing.Size(72, 22);
         this.txtTaskEnd.Text = "";
         this.txtTaskEnd.Validating += new System.ComponentModel.CancelEventHandler(this.txtTaskDates_Validating);
         // 
         // txtTaskNo
         // 
         this.txtTaskNo.Location = new System.Drawing.Point(8, 8);
         this.txtTaskNo.Size = new System.Drawing.Size(40, 22);
         this.txtTaskNo.Text = "";
         // 
         // btnCancel
         // 
         this.btnCancel.Location = new System.Drawing.Point(160, 237);
         this.btnCancel.Text = "&Cancel";
         this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
         // 
         // btnAddTask
         // 
         this.btnAddTask.Location = new System.Drawing.Point(0, 237);
         this.btnAddTask.Text = "Add &Task";
         this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
         // 
         // cboxTasks
         // 
         this.cboxTasks.Location = new System.Drawing.Point(8, 197);
         this.cboxTasks.Size = new System.Drawing.Size(224, 22);
         // 
         // lblProjEnd
         // 
         this.lblProjEnd.Location = new System.Drawing.Point(192, 13);
         this.lblProjEnd.Size = new System.Drawing.Size(40, 20);
         this.lblProjEnd.TextChanged += new System.EventHandler(this.lblProjEnd_TextChanged);
         // 
         // lblProjName
         // 
         this.lblProjName.Location = new System.Drawing.Point(16, 13);
         this.lblProjName.Size = new System.Drawing.Size(120, 27);
         // 
         // btnNewTask
         // 
         this.btnNewTask.Location = new System.Drawing.Point(80, 237);
         this.btnNewTask.Text = "New &Task";
         this.btnNewTask.Click += new System.EventHandler(this.btnNewTask_Click);
         // 
         // lblProjStart
         // 
         this.lblProjStart.Location = new System.Drawing.Point(144, 13);
         this.lblProjStart.Size = new System.Drawing.Size(40, 20);
         // 
         // FormMain
         // 
         this.Controls.Add(this.panelTaskFields);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.btnAddTask);
         this.Controls.Add(this.cboxTasks);
         this.Controls.Add(this.lblProjEnd);
         this.Controls.Add(this.lblProjName);
         this.Controls.Add(this.btnNewTask);
         this.Controls.Add(this.lblProjStart);
         this.Menu = this.mainMenu1;
         this.Text = "Time Tracker";
         this.Load += new System.EventHandler(this.FormMain_Load);

      }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>

		static void Main() 
		{
			Application.Run(new FormMain());
		}

      //  The current project.
      private YaoDurant.Data.UtilData.Project theProject;
      //  The tasks of the current project.
      private ArrayList alTasks = new ArrayList();

      //  A control to be created later
      private TextBox txtTaskComments;

      //  The index number of the previous task.  We will
      //     need to know it in case the users cancels out 
      //     during task creation.
      private int ixTaskPrev;

      private void FormMain_Load(object sender, System.EventArgs e)
      {
         //  set { the initial state of the controls.
         InitControlState();

         //  Load and display a project.
         YaoDurant.Data.UtilData utilData = new UtilData();
         theProject = utilData.GetProject("17");
         alTasks = utilData.GetTasks("17");
         DisplayProject();
      }

      private void lblProjEnd_TextChanged(object sender, System.EventArgs e)
      {
      //  if ( this project is due or overdue,
      //      make the background light red.
      SetBkColor(lblProjEnd, Color.LightPink);
      }

      private void txtTaskDates_Validating(object sender, System.ComponentModel.CancelEventArgs e)
      {
         //  if ( the date entered is not within one year
         //     of today, make the background light red.
         TextBox txtSender = (TextBox)sender;
         if ( Convert.ToDateTime(txtSender.Text) <= 
                           DateTime.Today.AddYears(-1) || 
              Convert.ToDateTime(txtSender.Text) >= 
                           DateTime.Today.AddYears(1))
         {
            txtSender.BackColor = Color.LightPink;
         }
      }

      private void btnNewTask_Click(object sender, System.EventArgs e)
      {
      //  Save the index number of the previous task.  We will
      //     need to know it in case the users cancels out 
      //     during task creation.
      ixTaskPrev = cboxTasks.SelectedIndex;

      //  Unbind the Tasks ArrayList from the controls.
      UnbindTasksFromControls();

      //  Create and display a multiline textbox
      //     for the user to enter comments.
      txtTaskComments = new TextBox();
      txtTaskComments.Multiline = true;

      //  Locate it relative to other 
      //     controls on the form.
      txtTaskComments.Left = txtTaskNo.Left;
      txtTaskComments.Top = lblProjName.Top;
      txtTaskComments.Width = 
         this.Width - (2 * txtTaskComments.Left);
      txtTaskComments.Height = 
         (txtTaskNo.Top - txtTaskComments.Top) - 
            (txtTaskNo.Height / 3);

      //  Enter and select the instructions.
      txtTaskComments.Text = "Add task comments here.";
      txtTaskComments.SelectAll();

      //  Add the control to the form.
      this.Controls.Add(txtTaskComments);

      //  Bring it to the z-axis top and
      //     set the focus into it.
      txtTaskComments.BringToFront();
      txtTaskComments.Focus();

      //  Designate the handler for the TextChanged
      //      event of the newly created control.

      txtTaskComments.TextChanged += new EventHandler(this.txtTaskComments_TextChanged);

      //  Hide self and show Add and Cancel.
      btnAddTask.Visible = true;
      btnCancel.Visible = true;
      btnNewTask.Visible = false;
      }

      private void btnAddTask_Click(object sender, System.EventArgs e)
      {
         //  Add the task to the Tasks array list.
         alTasks.Add(new YaoDurant.Data.UtilData.Task(
            txtTaskNo.Text, "17", txtTaskName.Text,
            Convert.ToDateTime(txtTaskStart.Text), 
            Convert.ToDateTime(txtTaskEnd.Text), 
            Convert.ToInt32(txtTaskEstimated.Text), 
            Convert.ToInt32(txtTaskActual.Text), 
            txtTaskComments.Text));

         //  Rebind the Tasks ArrayList to the controls.
         BindTasksToControls();

         //  Select the new task.
         cboxTasks.SelectedIndex = alTasks.Count - 1;

         //  Reset the form.
         AfterNewTaskCleanup(ixTaskPrev);
      }

      private void btnCancel_Click(object sender, System.EventArgs e)
      {
         //  Rebind the Tasks ArrayList from the controls.
         BindTasksToControls();

         //  Select the previous task.
         cboxTasks.SelectedIndex = ixTaskPrev;

         //  Reset the form.
         AfterNewTaskCleanup(ixTaskPrev);
      } 

      //  The event handler for a control
      //     that is created "on the fly".
      private void txtTaskComments_TextChanged(object sender,  
                                             EventArgs e ) 
      {
         //  if ( the comment is more than thirty characters
         //     long, set the background color of the 
         //     container panel to red.
            txtTaskComments.BackColor = 
               (txtTaskComments.Text.Length > 30) ? 
                  Color.Red : Color.White;
      }

      private void InitControlState() 
      {
         //  Hide the Add button directly under the new button.
         btnAddTask.Visible = false;
         btnAddTask.Bounds = btnNewTask.Bounds;

         //  Hide the Cancel button
         btnCancel.Visible = false;
      }

      private void DisplayProject() 
      {
         //  Load Proj data into the labels.
         lblProjName.Text = theProject.strName;
         lblProjStart.Text = theProject.dateStart.ToString("ddMMM");
         lblProjEnd.Text = theProject.dateEnd.ToString("ddMMM");

         //  Bind the dropdown ComboBox to the Tasks ArrayList.
         BindTasksToControls();

         //  Start with the first task as 
         //     the currently selected task.
         cboxTasks.SelectedIndex = 0;

         //  set { focus to the tasks ComboBox.
         cboxTasks.Focus();
      }

      private void BindTasksToControls() 
      {
         //  Bind the dropdown ComboBox to the Tasks ArrayList.
         cboxTasks.DataSource = alTasks;
         cboxTasks.DisplayMember = "strName";
         cboxTasks.ValueMember = "strIdent";

         //  Bind the textboxes to a column of the dropdown 
         //     ComboBox's DataSource (the Task ArrayList).
         BindToTextbox(txtTaskNo, "strIdent");
         BindToTextbox(txtTaskName, "strName");
         BindToTextbox(txtTaskStart, "dateStart");
         BindToTextbox(txtTaskEnd, "dateEnd");
         BindToTextbox(txtTaskActual, "durActual");
         BindToTextbox(txtTaskEstimated, "durEstimated");
     }

      private void BindToTextbox( TextBox txtTarget,  
                                 string  strColumnName) 
      {
         //  Bind the textbox to a column of the dropdown 
         //     ComboBox's DataSource (the Task ArrayList).
         txtTarget.DataBindings.Add("Text", 
                                    cboxTasks.DataSource, 
                                    strColumnName);
         //  Specify an event handler for formating those
         //     fields that are datatype //DateTime//.
         if( txtTarget == txtTaskStart || 
             txtTarget == txtTaskEnd ) 
         {
            txtTarget.DataBindings[0].Format += 
               new ConvertEventHandler(this.Date_Format);
         }
      } 

      private void Date_Format( object sender,  
                                ConvertEventArgs e) 
      {
         //  Format each date as it is moved by data binding
         //     from the ArrayList into a Textbox.
         //e.value = e.Value.ToString("d");
      }

      private void UnbindTasksFromControls() 
      {
         //  Iterate through all the controls in the TaskFields 
         //     panel, unbind them and clear them.
         foreach( Control theControl in panelTaskFields.Controls )
         {
            theControl.DataBindings.Clear();
            theControl.Text = string.Empty;
         } 

         //  Unbind the ComboBox.
         cboxTasks.DataSource = null;
      }

      private void AfterNewTaskCleanup( int ixTask) 
      {
         //  Destroy the comments textbox
         txtTaskComments.Dispose();
         txtTaskComments = null;

         //  Hide Add and Cancel and show new.
         btnAddTask.Visible = false;
         btnCancel.Visible = false;
         btnNewTask.Visible = true;

         //  set { focus to the tasks ComboBox.
         cboxTasks.Focus();
      }

      private void SetBkColor( Label lblTarget,  
                               Color colorBack ) 
      {
         //  if ( the desired background color is the background 
         //     color of this form, remove the label from the
         //     panel and dispose of the panel.
         Panel  panelBackColor = new Panel();
         if ( colorBack.Equals(this.BackColor) ) 
         {
            if (! (lblTarget.Parent == this) ) 
            {
               panelBackColor = (Panel)lblTarget.Parent;
               lblTarget.Bounds = panelBackColor.Bounds;
               lblTarget.Parent = this;
               panelBackColor.Dispose();
            }
         } 
         else 
         {
            //  if ( the desired background color is not the 
            //     background color of this form, then if the
            //     label is already inside a panel, set the
            //     background color of that panel.  if ( not,
            //     create a panel, position it, put the label 
            //     in it, and set the background color.  
            if ( lblTarget.Parent == this ) 
            {
               panelBackColor = new Panel();
               this.Controls.Add(panelBackColor);
               panelBackColor.Visible = true;
               panelBackColor.Bounds = lblTarget.Bounds;
               lblTarget.Location = new Point(0, 0);
               panelBackColor.Controls.Add(lblTarget);
            }
            panelBackColor.BackColor = colorBack;
         }
      }
   }
}
