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

/// <summary>
/// Summary description for FormMain.
/// </summary>

public class FormMain : System.Windows.Forms.Form
{
   internal System.Windows.Forms.Button cmdCancel;
   internal System.Windows.Forms.Button cmdAddTask;
   internal System.Windows.Forms.ComboBox cboxTasks;
   internal System.Windows.Forms.TextBox txtTaskActual;
   internal System.Windows.Forms.TextBox txtTaskEstimated;
   internal System.Windows.Forms.TextBox txtTaskName;
   internal System.Windows.Forms.TextBox txtTaskStart;
   internal System.Windows.Forms.TextBox txtTaskEnd;
   internal System.Windows.Forms.TextBox txtTaskNo;
   internal System.Windows.Forms.Label lblProjEnd;
   internal System.Windows.Forms.Label lblProjName;
   internal System.Windows.Forms.Button cmdNewTask;
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
      this.cmdCancel = new System.Windows.Forms.Button();
      this.cmdAddTask = new System.Windows.Forms.Button();
      this.cboxTasks = new System.Windows.Forms.ComboBox();
      this.txtTaskActual = new System.Windows.Forms.TextBox();
      this.txtTaskEstimated = new System.Windows.Forms.TextBox();
      this.txtTaskName = new System.Windows.Forms.TextBox();
      this.txtTaskStart = new System.Windows.Forms.TextBox();
      this.txtTaskEnd = new System.Windows.Forms.TextBox();
      this.txtTaskNo = new System.Windows.Forms.TextBox();
      this.lblProjEnd = new System.Windows.Forms.Label();
      this.lblProjName = new System.Windows.Forms.Label();
      this.cmdNewTask = new System.Windows.Forms.Button();
      this.lblProjStart = new System.Windows.Forms.Label();
      // 
      // cmdCancel
      // 
      this.cmdCancel.Location = new System.Drawing.Point(164, 237);
      this.cmdCancel.Text = "&Cancel";
      this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
      // 
      // cmdAddTask
      // 
      this.cmdAddTask.Location = new System.Drawing.Point(4, 237);
      this.cmdAddTask.Text = "Add &Task";
      this.cmdAddTask.Click += new System.EventHandler(this.cmdAddTask_Click);
      // 
      // cboxTasks
      // 
      this.cboxTasks.Location = new System.Drawing.Point(12, 197);
      this.cboxTasks.Size = new System.Drawing.Size(224, 22);
      this.cboxTasks.SelectedIndexChanged += new System.EventHandler(this.cboxTasks_SelectedIndexChanged);
      // 
      // txtTaskActual
      // 
      this.txtTaskActual.Location = new System.Drawing.Point(204, 165);
      this.txtTaskActual.Size = new System.Drawing.Size(32, 22);
      this.txtTaskActual.Text = "";
      // 
      // txtTaskEstimated
      // 
      this.txtTaskEstimated.Location = new System.Drawing.Point(164, 165);
      this.txtTaskEstimated.Size = new System.Drawing.Size(32, 22);
      this.txtTaskEstimated.Text = "";
      // 
      // txtTaskName
      // 
      this.txtTaskName.Location = new System.Drawing.Point(12, 165);
      this.txtTaskName.Size = new System.Drawing.Size(144, 22);
      this.txtTaskName.Text = "";
      // 
      // txtTaskStart
      // 
      this.txtTaskStart.Location = new System.Drawing.Point(100, 133);
      this.txtTaskStart.Size = new System.Drawing.Size(64, 22);
      this.txtTaskStart.Text = "";
      this.txtTaskStart.Validating += new System.ComponentModel.CancelEventHandler(this.txtTaskDates_Validating);
      // 
      // txtTaskEnd
      // 
      this.txtTaskEnd.Location = new System.Drawing.Point(172, 133);
      this.txtTaskEnd.Size = new System.Drawing.Size(64, 22);
      this.txtTaskEnd.Text = "";
      this.txtTaskEnd.Validating += new System.ComponentModel.CancelEventHandler(this.txtTaskDates_Validating);
      // 
      // txtTaskNo
      // 
      this.txtTaskNo.Location = new System.Drawing.Point(12, 133);
      this.txtTaskNo.Size = new System.Drawing.Size(40, 22);
      this.txtTaskNo.Text = "";
      // 
      // lblProjEnd
      // 
      this.lblProjEnd.Location = new System.Drawing.Point(196, 13);
      this.lblProjEnd.Size = new System.Drawing.Size(40, 20);
      this.lblProjEnd.TextChanged += new System.EventHandler(this.lblProjEnd_TextChanged);
      // 
      // lblProjName
      // 
      this.lblProjName.Location = new System.Drawing.Point(20, 13);
      this.lblProjName.Size = new System.Drawing.Size(120, 20);
      // 
      // cmdNewTask
      // 
      this.cmdNewTask.Location = new System.Drawing.Point(84, 237);
      this.cmdNewTask.Text = "New &Task";
      this.cmdNewTask.Click += new System.EventHandler(this.cmdNewTask_Click);
      // 
      // lblProjStart
      // 
      this.lblProjStart.Location = new System.Drawing.Point(148, 13);
      this.lblProjStart.Size = new System.Drawing.Size(40, 20);
      // 
      // FormMain
      // 
      this.Controls.Add(this.cmdCancel);
      this.Controls.Add(this.cmdAddTask);
      this.Controls.Add(this.cboxTasks);
      this.Controls.Add(this.txtTaskActual);
      this.Controls.Add(this.txtTaskEstimated);
      this.Controls.Add(this.txtTaskName);
      this.Controls.Add(this.txtTaskStart);
      this.Controls.Add(this.txtTaskEnd);
      this.Controls.Add(this.txtTaskNo);
      this.Controls.Add(this.lblProjEnd);
      this.Controls.Add(this.lblProjName);
      this.Controls.Add(this.cmdNewTask);
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

   #region Database struct Simulated
   private struct Project
   {
      public string  strProjNo;
      public string  strProjName;
      public DateTime dateProjStart;
      public DateTime dateProjEnd;
      public int ctProjTasks;
      public string  strProjComments;

      public Project( string  strNo,  string  strName,  
         DateTime dateStart,  DateTime dateEnd,  
         int ctTasks,  string  strComments) 
      {
         strProjNo = strNo;
         strProjName = strName;
         dateProjStart = dateStart;
         dateProjEnd = dateEnd;
         ctProjTasks = ctTasks;
         strProjComments = strComments;
      }
   } 

   private struct Task
   {
      private string  m_strTaskIdent;
      private string  m_strTaskName;
      public DateTime dateTaskStart;
      public DateTime dateTaskEnd;
      public int durTaskEstimated;  //  In hours;
      public int durTaskActual;     //  In hours;
      public string  strTaskComments;

      public string strTaskIdent  
      {
         get 
         {
            return m_strTaskIdent;
         }
         set 
         {
            m_strTaskIdent = value;
         }
      }
      public string strTaskName  
      {
         get 
         {
            return m_strTaskName;
         }
         set 
         {
            m_strTaskName = value;
         }
      }

      public Task( string strNo, string strName,  
         DateTime dateStart,  DateTime dateEnd,  
         int durEstimated,  int durActual,  
         string  strComments) 
      {
         m_strTaskIdent = strNo;
         m_strTaskName = strName;
         dateTaskStart = dateStart;
         dateTaskEnd = dateEnd;
         durTaskEstimated = durEstimated;
         durTaskActual = durActual;
         strTaskComments = strComments;
      }
   }

   #endregion

   private Project theProject;
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
      if ( LoadProject(42) ) 
      {
         DisplayProject();
      } 
      else 
      {
         this.Close();
      }
   }

   private void cmdNewTask_Click(object sender, 
                                 System.EventArgs e)
   {
      lblProjName.Enabled = !lblProjName.Enabled;
      //  Save the index number of the previous task.  We will
      //     need to know it in case the users cancels out 
      //     during task creation.
      ixTaskPrev = cboxTasks.SelectedIndex;

      //  Deselect the current task from the dropdown
      //     ComboBox.  This will also cause the 
      //     SelectedIndexChanged event to fire 
      //     which will cause the task fields to clear.
      cboxTasks.SelectedIndex = -1;
      cboxTasks.SelectedIndex = -1;

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

      //  Enter and select some text.
      txtTaskComments.Text = "Add task comments here.";
      txtTaskComments.SelectAll();

      //  Add the control to the form.
      this.Controls.Add(txtTaskComments);

      //  Bring it to the z-axis top and
      //     set the focus into it.
      txtTaskComments.BringToFront();
      txtTaskComments.Focus();

      //  Associate the TextChanged event handler
      //     that we have written for this
      //     control with this control.
      this.txtTaskComments.TextChanged += 
         new System.EventHandler(
            this.txtTaskComments_TextChanged);

      //  Hide self and show Add and Cancel.
      cmdAddTask.Visible = true;
      cmdCancel.Visible = true;
      cmdNewTask.Visible = false;
   }

   private void cmdAddTask_Click(object sender, System.EventArgs e)
   {
//      //  Unbind the Tasks array list from 
//      //     the dropdown ComboBox.
//      cboxTasks.DataSource = null;
//
      //  Add the task to the Tasks array list.
      alTasks.Add(new Task(
         txtTaskNo.Text, 
         txtTaskName.Text, 
         Convert.ToDateTime(txtTaskStart.Text), 
         Convert.ToDateTime(txtTaskEnd.Text), 
         Convert.ToInt32(txtTaskEstimated.Text), 
         Convert.ToInt32(txtTaskActual.Text), 
         txtTaskComments.Text));

//      //  Rebind the Tasks array list to 
//      //     the dropdown ComboBox.
//      cboxTasks.DataSource = alTasks;
//      cboxTasks.DisplayMember = "strTaskName";
//      cboxTasks.ValueMember = "strTaskIdent";

      //  Cleanup the form and select the new task.
      AfterNewTaskCleanup(alTasks.Count - 1);
   }

   private void cmdCancel_Click(object sender, 
                                System.EventArgs e)
   {
      //  Cleanup the form and re-select the old task.
      AfterNewTaskCleanup(ixTaskPrev);
   }

   private void cboxTasks_SelectedIndexChanged(
      object sender, 
      System.EventArgs e)
   {
      LoadTaskFields(cboxTasks.SelectedIndex);
   }

   private void lblProjEnd_TextChanged(object sender, 
      System.EventArgs e)
   {
      //  if this project is due or
      //      overdue, use red ink.
      SetBkColor(lblProjEnd,Color.Red);
   }

   private void txtTaskDates_Validating(
      object sender, 
      System.ComponentModel.CancelEventArgs e)
   {
      //  if the date entered is not within one year
      //     of today, make the background light red.
      TextBox txtSender = (TextBox)sender;
      if ( Convert.ToDateTime(txtSender.Text) <= 
         DateTime.Today.AddYears(-1) 
         || Convert.ToDateTime(txtSender.Text) >= 
         DateTime.Today.AddYears(1) ) 
      {
         txtSender.BackColor = Color.LightPink;
      }
   } 

   private void txtTaskComments_TextChanged(object sender, 
                                            EventArgs e ) 
   {
      txtTaskComments.BackColor = 
         (txtTaskComments.Text.Length > 30) ? 
         Color.Red : Color.White;
   }

   private void InitControlState() 
   {
      //  Hide the Add button directly under the new button.
      cmdAddTask.Visible = false;
      cmdAddTask.Bounds = cmdNewTask.Bounds;
      //  Hide the cancel button
      cmdCancel.Visible = false;
   }

   private void DisplayProject() 
   {
      //  Load Proj data into the labels.
      lblProjName.Text = theProject.strProjName;
      lblProjStart.Text = 
         theProject.dateProjStart.ToString("ddMMM");
      lblProjEnd.Text = 
         theProject.dateProjEnd.ToString("ddMMM");

      //  Load the tasks into the dropdown ComboBox.
      foreach( Task theTask in alTasks )
      {
         cboxTasks.Items.Add(theTask.strTaskName);
      }

      //  Start with the first task as 
      //     the currently selected task.
      cboxTasks.SelectedIndex = 0;

      //  set { focus to the tasks ComboBox.
      cboxTasks.Focus();
   }

   private void LoadTaskFields( int intTaskNo) 
   {
      //  Load the fields for the specified
      //     task into the text boxes.  if (
      //     intTaskNo is out of range, clear
      //     the textboxes.
      if ( intTaskNo >= 0 && intTaskNo < alTasks.Count ) 
      {
         //  Create a variable of a specific type 
         //     so that we can do early binding.
         Task refTask = (Task)alTasks[intTaskNo];
         txtTaskNo.Text = refTask.strTaskIdent;
         txtTaskName.Text = refTask.strTaskName;
         txtTaskStart.Text = 
            refTask.dateTaskStart.ToString("MM/dd/yy");
         txtTaskEnd.Text = 
            refTask.dateTaskEnd.ToString("MM/dd/yy");
         txtTaskEstimated.Text = 
            refTask.durTaskEstimated.ToString();
         txtTaskActual.Text = 
            refTask.durTaskActual.ToString();
      } 
      else 
      {
         txtTaskNo.Text = string.Empty;
         txtTaskName.Text = string.Empty;
         txtTaskStart.Text = string.Empty;
         txtTaskEnd.Text = string.Empty;
         txtTaskEstimated.Text = string.Empty;
         txtTaskActual.Text = string.Empty;
      }
   }

   private void AfterNewTaskCleanup(int ixTask) 
   {
      //  Destroy the comments textbox
      txtTaskComments.Dispose();
      txtTaskComments = null;

      //  Hide Add and Cancel and show new.
      cmdAddTask.Visible = false;
      cmdCancel.Visible = false;
      cmdNewTask.Visible = true;

      //  Select the specified task.
      cboxTasks.SelectedIndex = ixTask;

      //  set { focus to the tasks ComboBox.
      cboxTasks.Focus();
   }

   private void SetBkColor(Label lblTarget,  Color colorBack) 
   {
      //  if the desired background color is the background 
      //     color of this form, remove the label from the
      //     panel and dispose of the panel.
      if ( colorBack.Equals(this.BackColor) ) 
      {
         if (lblTarget.Parent.Equals(this) ) 
         {
         }
         else
         {
            Panel panelBackColor = (Panel)(lblTarget.Parent);
            lblTarget.Bounds = panelBackColor.Bounds;
            lblTarget.Parent = this;
            panelBackColor.Dispose();
         }
      } 
      else 
      {
         //  if the desired background color is not the 
         //     background color of this form, then if the
         //     label is already inside a panel, set the
         //     background color of that panel.  if not,
         //     create a panel, position it, put the label 
         //     in it, and set the background color.  
         if ( lblTarget.Parent.Equals(this) ) 
         {
            Panel panelBackColor = new Panel();
            panelBackColor.BackColor = colorBack;
            this.Controls.Add(panelBackColor);
            panelBackColor.Visible = true;
            panelBackColor.Bounds = lblTarget.Bounds;
            lblTarget.Location = new Point(0, 0);
            panelBackColor.Controls.Add(lblTarget);
         }
         else
         {
            ((Panel)(lblTarget.Parent)).BackColor = colorBack;
         }
      }
   }

   #region Database Read Simulation

   private bool LoadProject(  int ProjectID ) 
   {
      //  Simulate having retrieved project data
      //     from a database.  Here, we'll use our
      //     Project and Task data structures to
      //     hold the data.

      theProject.strProjNo = "1";
      theProject.strProjName = "Net CF Book";
      theProject.dateProjStart = DateTime.Today.AddDays(-100);
      theProject.dateProjEnd = DateTime.Today.AddDays(100);

      alTasks.Add(new Task("0", 
         "Create Blueprints", 
         DateTime.Today.AddDays(-17), DateTime.Today.AddDays(22), 
         120, 60, ""));
      alTasks.Add(new Task("1", 
         "Build Franistans", 
         DateTime.Today.AddDays(-11), DateTime.Today.AddDays(0), 
         35, 30, ""));
      alTasks.Add(new Task("2", 
         "Build Widgets", 
         DateTime.Today.AddDays(-4), DateTime.Today.AddDays(44), 
         400, 45, ""));
      alTasks.Add(new Task("3", 
         "Assemble Woobletogles", 
         DateTime.Today.AddDays(-19), DateTime.Today.AddDays(2), 
         20, 20, ""));
      alTasks.Add(new Task("4", 
         "Weld Mainwareing", 
         DateTime.Today.AddDays(-100), DateTime.Today.AddDays(50), 
         20, 6, ""));
      return true;
   }

   #endregion

}
