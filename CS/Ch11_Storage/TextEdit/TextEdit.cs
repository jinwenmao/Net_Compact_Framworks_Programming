// TextEdit.cs - Main form for TextEdit sample.
//
// Code from _Programming the .NET Compact Framework 
// with C# and _Programming the .NET Compact Framework 
// with VB 
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.

using System;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace DialogBoxes
{
   /// <summary>
   /// DialogBoxes -- Displays two dialog boxes which show
   /// settings for a text box.
   /// </summary>
   
   public class FormMain : Form
   {
      #region Menu items and Toolbar buttons

      private MainMenu menuMain;
      private MenuItem mitemFilePopup;
      private MenuItem mitemFileOpen;
      private MenuItem mitemFileSave;
      private MenuItem mitemFileSaveAs;
      private MenuItem mitemFileFormat;
      private MenuItem mitemFFAscii;
      private MenuItem mitemFFUnicode;
      private MenuItem mitemFFUtf7;
      private MenuItem mitemFFUtf8;
      private MenuItem mitemFFDefault;
      private MenuItem mitemSettingsPopup;
      private MenuItem mitemSettingsSave;
      private MenuItem mitemSettingsRestore;
      private MenuItem mitemSettingsInit;
      private MenuItem mitemEditPopup;
      private MenuItem mitemToolsPopup;
      private TextBox textInput;
      private ToolBar tbarCommands;
      private ToolBarButton tbbEditFormat;
      private ToolBarButton tbbViewOptions;
      private ImageList ilistCommands;
      private ContextMenu cmenuMain;
      private MenuItem mitemProgramMenu;
      private MenuItem mitemToolbar;
      private MenuItem mitemEditFont;
      private MenuItem mitemToolsOptions;

      #endregion

      public FormMain()
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();
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
         System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormMain));
         this.menuMain = new System.Windows.Forms.MainMenu();
         this.mitemFilePopup = new System.Windows.Forms.MenuItem();
         this.mitemFileOpen = new System.Windows.Forms.MenuItem();
         this.mitemFileSave = new System.Windows.Forms.MenuItem();
         this.mitemFileSaveAs = new System.Windows.Forms.MenuItem();
         this.mitemFileFormat = new System.Windows.Forms.MenuItem();
         this.mitemFFAscii = new System.Windows.Forms.MenuItem();
         this.mitemFFUnicode = new System.Windows.Forms.MenuItem();
         this.mitemFFUtf7 = new System.Windows.Forms.MenuItem();
         this.mitemFFUtf8 = new System.Windows.Forms.MenuItem();
         this.mitemFFDefault = new System.Windows.Forms.MenuItem();
         this.mitemEditPopup = new System.Windows.Forms.MenuItem();
         this.mitemEditFont = new System.Windows.Forms.MenuItem();
         this.mitemToolsPopup = new System.Windows.Forms.MenuItem();
         this.mitemToolsOptions = new System.Windows.Forms.MenuItem();
         this.mitemSettingsPopup = new System.Windows.Forms.MenuItem();
         this.mitemSettingsSave = new System.Windows.Forms.MenuItem();
         this.mitemSettingsRestore = new System.Windows.Forms.MenuItem();
         this.mitemSettingsInit = new System.Windows.Forms.MenuItem();
         this.textInput = new System.Windows.Forms.TextBox();
         this.tbarCommands = new System.Windows.Forms.ToolBar();
         this.tbbEditFormat = new System.Windows.Forms.ToolBarButton();
         this.tbbViewOptions = new System.Windows.Forms.ToolBarButton();
         this.ilistCommands = new System.Windows.Forms.ImageList();
         this.cmenuMain = new System.Windows.Forms.ContextMenu();
         this.mitemProgramMenu = new System.Windows.Forms.MenuItem();
         this.mitemToolbar = new System.Windows.Forms.MenuItem();
         // 
         // menuMain
         // 
         this.menuMain.MenuItems.Add(this.mitemFilePopup);
         this.menuMain.MenuItems.Add(this.mitemEditPopup);
         this.menuMain.MenuItems.Add(this.mitemToolsPopup);
         this.menuMain.MenuItems.Add(this.mitemSettingsPopup);
         // 
         // mitemFilePopup
         // 
         this.mitemFilePopup.MenuItems.Add(this.mitemFileOpen);
         this.mitemFilePopup.MenuItems.Add(this.mitemFileSave);
         this.mitemFilePopup.MenuItems.Add(this.mitemFileSaveAs);
         this.mitemFilePopup.MenuItems.Add(this.mitemFileFormat);
         this.mitemFilePopup.Text = "File";
         // 
         // mitemFileOpen
         // 
         this.mitemFileOpen.Text = "Open...";
         this.mitemFileOpen.Click += new System.EventHandler(this.mitemFileOpen_Click);
         // 
         // mitemFileSave
         // 
         this.mitemFileSave.Text = "Save";
         this.mitemFileSave.Click += new System.EventHandler(this.mitemFileSave_Click);
         // 
         // mitemFileSaveAs
         // 
         this.mitemFileSaveAs.Text = "SaveAs...";
         this.mitemFileSaveAs.Click += new System.EventHandler(this.mitemFileSaveAs_Click);
         // 
         // mitemFileFormat
         // 
         this.mitemFileFormat.MenuItems.Add(this.mitemFFAscii);
         this.mitemFileFormat.MenuItems.Add(this.mitemFFUnicode);
         this.mitemFileFormat.MenuItems.Add(this.mitemFFUtf7);
         this.mitemFileFormat.MenuItems.Add(this.mitemFFUtf8);
         this.mitemFileFormat.MenuItems.Add(this.mitemFFDefault);
         this.mitemFileFormat.Text = "Format";
         // 
         // mitemFFAscii
         // 
         this.mitemFFAscii.Text = "Ascii";
         this.mitemFFAscii.Click += new System.EventHandler(this.mitemFFFormat_Click);
         // 
         // mitemFFUnicode
         // 
         this.mitemFFUnicode.Text = "Unicode";
         this.mitemFFUnicode.Click += new System.EventHandler(this.mitemFFFormat_Click);
         // 
         // mitemFFUtf7
         // 
         this.mitemFFUtf7.Text = "Utf7";
         this.mitemFFUtf7.Click += new System.EventHandler(this.mitemFFFormat_Click);
         // 
         // mitemFFUtf8
         // 
         this.mitemFFUtf8.Text = "Utf8";
         this.mitemFFUtf8.Click += new System.EventHandler(this.mitemFFFormat_Click);
         // 
         // mitemFFDefault
         // 
         this.mitemFFDefault.Text = "Default";
         this.mitemFFDefault.Click += new System.EventHandler(this.mitemFFFormat_Click);
         // 
         // mitemEditPopup
         // 
         this.mitemEditPopup.MenuItems.Add(this.mitemEditFont);
         this.mitemEditPopup.Text = "Edit";
         // 
         // mitemEditFont
         // 
         this.mitemEditFont.Text = "Font...";
         this.mitemEditFont.Click += new System.EventHandler(this.mitemEditFont_Click);
         // 
         // mitemToolsPopup
         // 
         this.mitemToolsPopup.MenuItems.Add(this.mitemToolsOptions);
         this.mitemToolsPopup.Text = "Tools";
         // 
         // mitemToolsOptions
         // 
         this.mitemToolsOptions.Text = "Options...";
         this.mitemToolsOptions.Click += new System.EventHandler(this.mitemToolsOptions_Click);
         // 
         // mitemSettingsPopup
         // 
         this.mitemSettingsPopup.MenuItems.Add(this.mitemSettingsSave);
         this.mitemSettingsPopup.MenuItems.Add(this.mitemSettingsRestore);
         this.mitemSettingsPopup.MenuItems.Add(this.mitemSettingsInit);
         this.mitemSettingsPopup.Text = "Settings";
         // 
         // mitemSettingsSave
         // 
         this.mitemSettingsSave.Text = "Save";
         this.mitemSettingsSave.Click += new System.EventHandler(this.mitemSettingsSave_Click);
         // 
         // mitemSettingsRestore
         // 
         this.mitemSettingsRestore.Text = "Restore";
         this.mitemSettingsRestore.Click += new System.EventHandler(this.mitemSettingsRestore_Click);
         // 
         // mitemSettingsInit
         // 
         this.mitemSettingsInit.Text = "Initialize";
         this.mitemSettingsInit.Click += new System.EventHandler(this.mitemSettingsInit_Click);
         // 
         // textInput
         // 
         this.textInput.Location = new System.Drawing.Point(8, 8);
         this.textInput.Multiline = true;
         this.textInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
         this.textInput.Size = new System.Drawing.Size(224, 248);
         this.textInput.Text = "Some text inside a textbox.";
         // 
         // tbarCommands
         // 
         this.tbarCommands.Buttons.Add(this.tbbEditFormat);
         this.tbarCommands.Buttons.Add(this.tbbViewOptions);
         this.tbarCommands.ImageList = this.ilistCommands;
         this.tbarCommands.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tbarCommands_ButtonClick);
         // 
         // tbbEditFormat
         // 
         this.tbbEditFormat.ImageIndex = 0;
         // 
         // tbbViewOptions
         // 
         this.tbbViewOptions.ImageIndex = 1;
         // 
         // ilistCommands
         // 
         this.ilistCommands.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
         this.ilistCommands.Images.Add(((System.Drawing.Image)(resources.GetObject("resource1"))));
         this.ilistCommands.ImageSize = new System.Drawing.Size(16, 16);
         // 
         // cmenuMain
         // 
         this.cmenuMain.MenuItems.Add(this.mitemProgramMenu);
         this.cmenuMain.MenuItems.Add(this.mitemToolbar);
         this.cmenuMain.Popup += new System.EventHandler(this.cmenuMain_Popup);
         // 
         // mitemProgramMenu
         // 
         this.mitemProgramMenu.Text = "Program Menu";
         this.mitemProgramMenu.Click += new System.EventHandler(this.mitemProgramMenu_Click);
         // 
         // mitemToolbar
         // 
         this.mitemToolbar.Text = "Toolbar";
         this.mitemToolbar.Click += new System.EventHandler(this.mitemToolbar_Click);
         // 
         // FormMain
         // 
         this.ContextMenu = this.cmenuMain;
         this.Controls.Add(this.textInput);
         this.Controls.Add(this.tbarCommands);
         this.Menu = this.menuMain;
         this.MinimizeBox = false;
         this.Text = "TextEdit";
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

      private void FormMain_Load(object sender, System.EventArgs e)
      {
         mitemSettingsRestore_Click(this, EventArgs.Empty);
      }

      #region Fonts and Settings

      /// mitemEditFont - Respond to menu selection Edit->Font...
      private void mitemEditFont_Click(
         object sender, 
         System.EventArgs e)
      {
         DlgFont dlg = new DlgFont(this);

         // Initialize input values to dialog.
         dlg.strFontName = textInput.Font.Name;
         dlg.cemFontSize = textInput.Font.Size;
         FontStyle fsTemp = textInput.Font.Style;
         dlg.bBold = ((fsTemp & FontStyle.Bold) != 0);
         dlg.bItalic = ((fsTemp & FontStyle.Italic) != 0);
         dlg.bUnderline = ((fsTemp & FontStyle.Underline) != 0);

         // Summon dialog box.
         if (dlg.ShowDialog() != DialogResult.OK)
            return;

         // Modify settings based on user input.
         Font fontOld = textInput.Font;
         fsTemp = 0;
         if (dlg.bBold) fsTemp |= FontStyle.Bold;
         if (dlg.bItalic) fsTemp |= FontStyle.Italic;
         if (dlg.bUnderline) fsTemp |= FontStyle.Underline;
         textInput.Font = 
            new Font(dlg.strFontName, dlg.cemFontSize, fsTemp);
         fontOld.Dispose();
      } // mitemEditFont_Click

      /// mitemToolsOptions -- Respond to menu selection
      /// Tools->Options...
      private void mitemToolsOptions_Click(
         object sender, 
         System.EventArgs e)
      {
         DlgToolsOptions dlg = new DlgToolsOptions(this);

         // Get flag for whether toolbar is being displayed
         bool bHasTB = this.Controls.Contains(tbarCommands);

         // Initialize input values to dialog.
         dlg.sbScrollBars = textInput.ScrollBars;
         dlg.bProgramMenu = (this.Menu != null);
         dlg.bToolbar = bHasTB;
         dlg.haTextAlign = textInput.TextAlign;
         dlg.bWordWrap = textInput.WordWrap;

         // Summon dialog box.
         if (dlg.ShowDialog() != DialogResult.OK)
            return;

         // Hide textbox to minimize redrawing time.
         textInput.Visible = false;

         // Modify settings based on user input.
         textInput.ScrollBars = dlg.sbScrollBars;
         this.Menu = (dlg.bProgramMenu) ? menuMain : null;

         // Do we need to add toolbar?
         // (adding a toolbar twice causes an
         //  exception, so we have to be careful)
         if(dlg.bToolbar && (!bHasTB))
            this.Controls.Add(tbarCommands);

         // Do we need to remove toolbar?
         // (okay to remove a toolbar twice -- we
         //  do the following to parallel the add code)
         if (bHasTB && (!dlg.bToolbar))
            this.Controls.Remove(tbarCommands);

         // Update text alignment.
         textInput.TextAlign = dlg.haTextAlign;

         // Update word-wrap setting.
         textInput.WordWrap = dlg.bWordWrap;

         // Make textbox visible again.
         textInput.Visible = true;

      } // mitemToolsOptions_Click

      /// tbarCommands_ButtonClick - Respond to ButtonClick
      /// event for toolbar tbarCommands
      private void tbarCommands_ButtonClick(
         object sender, 
         ToolBarButtonClickEventArgs e)
      {
         if (e.Button == tbbEditFormat)
         {
            mitemEditFont_Click(sender, e);
         }
         else if (e.Button == tbbViewOptions)
         {
            mitemToolsOptions_Click (sender, e);
         }
      }

      /// cmenuMain_Popup -- Handle Popup event for
      /// context menu. Set/clear check-mark on context
      /// menu items.
      private void cmenuMain_Popup(
         object sender, 
         System.EventArgs e)
      {
         bool bMenu = (this.Menu != null);
         mitemProgramMenu.Checked = bMenu;

         bool bTB = this.Controls.Contains(tbarCommands);
         mitemToolbar.Checked = bTB;
      }

      /// mitemProgramMenu_Click -- Handle Click on context
      /// menu to toggle visibility of program menu.
      private void mitemProgramMenu_Click(
         object sender, 
         System.EventArgs e)
      {
         this.Menu = (this.Menu == null) ? menuMain : null;
      }

      /// mitemToolbar_Click -- Handle Click on context
      /// menu to toggle visibility of toolbar.
      private void mitemToolbar_Click(
         object sender, 
         System.EventArgs e)
      {
         if (mitemToolbar.Checked)
            this.Controls.Remove(tbarCommands);
         else
            this.Controls.Add(tbarCommands);
      }

      #endregion

      #region Text FileIO routines

      //  Routines to read / write the Text property 
      //     of the multiline Textbox to / from a file.

      private OpenFileDialog fdlgOpen;
      private SaveFileDialog fdlgSave;
      private Encoding encodeFile = Encoding.Default;
      private string  strCurrentFile = string.Empty;


      private void mitemFileOpen_Click(object sender, 
                                       EventArgs e)
      {
         //  Create a OpenFile dialog if necessary.
         if ( fdlgOpen == null ) 
            { fdlgOpen = new OpenFileDialog(); }
         fdlgOpen.InitialDirectory = "NotepadCE";
         fdlgOpen.Filter = 
            "dat files (*.dat)|*.dat|" +
            "txt files (*.txt)|*.txt|" +
            "All files (*.*)|*.*";

         //  Show it.
         switch (fdlgOpen.ShowDialog()) 
         { 
            //  Check user//s response.
            case DialogResult.OK:
            
               //  Save file name.
               strCurrentFile = fdlgOpen.FileName;

               //  Open, read, close file.
               StreamReader srdrFile = 
                  new StreamReader(
                     new FileStream(strCurrentFile,
                                    FileMode.Open),
                     this.encodeFile);
                  this.textInput.Text = srdrFile.ReadToEnd();
                  srdrFile.Close();
               break;

            default:
               break;
         }
      }


      private void mitemFileSave_Click(object sender, 
                                       EventArgs e)
      {
         //  if the user has not yet specified
         //     a file name, do SaveAs.
         //  else,
         //     open, write, close file.
         if ( strCurrentFile == string.Empty ) 
         {
            mitemFileSaveAs_Click(sender, e);
         } 
         else 
         {
            //  If the file does not exist,
            //     create it.
            if (! File.Exists(strCurrentFile) ) 
            {
               File.Create(strCurrentFile).Close();
            }

            //  Create Writer
            StreamWriter swrtFile = 
               new StreamWriter(
                  new FileStream(strCurrentFile,
                                 FileMode.Truncate),
                  this.encodeFile);
            
            //  Write the file.
            swrtFile.Write(this.textInput.Text);

            //  Close the file.
            swrtFile.Close();
         }
      }

      
      private void mitemFileSaveAs_Click(object sender, 
                                         EventArgs e)
      {
         //  get { the file name from the user.
         if ( fdlgSave == null ) 
         {
            fdlgSave = new SaveFileDialog();
         }

         switch (fdlgSave.ShowDialog()) 
         {
            case DialogResult.OK:
               //  Save file name.
               strCurrentFile = fdlgSave.FileName;
               //  Save file.
               mitemFileSave_Click(sender, e);
               break;
            default:
               break;
         }
      }


      private void mitemFFFormat_Click(object sender, 
                                       EventArgs e)
      {
         //  Set this.encodeFile to the selected encoding.
         if (sender.Equals(mitemFFAscii))
         {
            this.encodeFile = Encoding.ASCII;
         }
         else if (sender.Equals(mitemFFUnicode))
         {
            this.encodeFile = Encoding.Unicode;
         }
         else if (sender.Equals(mitemFFUtf8))
         {
            this.encodeFile = Encoding.UTF8;
         }
         else if (sender.Equals(mitemFFUtf7))
         {
            this.encodeFile = Encoding.UTF7;
         }
         else 
         {
            this.encodeFile = Encoding.Default;
         }
      }

      #endregion

      #region Binary File IO routines 

      private string  strDirName = @"My Documents\NotepadCE";
      private string  strFileName = "Settings.dat";

      private void SaveSettingsToFile() 
      {
         //  Create the directory if it does not
         //     already exist, and make it the
         //     current directory.
         if (! Directory.Exists(strDirName) ) 
         {
            Directory.CreateDirectory(strDirName);
         }
         Directory.SetCurrentDirectory(strDirName);

         //  Create the file if it does not
         //     already exist.
         if (! File.Exists(strFileName) ) 
         {
            File.Create(strFileName).Close();
         }

         //  Create a BinaryWriter (wrapped around a 
         //     FileStream wrapped around the file)
         //     for output using the user specified 
         //     encoding.
         BinaryWriter bwrtFile = 
            new BinaryWriter(
            new FileStream(strFileName,
                           FileMode.OpenOrCreate, 
                           FileAccess.Write,
                           FileShare.None), 
            encodeFile);

         //  Write the three fields, each of a 
         //     different data type.  
         //  Close the file.
         bwrtFile.Write(textInput.Font.Name);
         bwrtFile.Write(textInput.Font.Size);
         bwrtFile.Write(unchecked((int)textInput.Font.Style));
         bwrtFile.Close();

         //  Create an ourFontInfo structure, load it from
         //     TextInput's font, have the structure save
         //     its contents to the file.
//      
//         ourFontInfo fiFont;
//         fiFont.strName = textInput.Font.Name;
//         fiFont.sglSize = textInput.Font.Size;
//         fiFont.intStyle = textInput.Font.Style;
//         fiFont.WriteToFile(strDirName, 
//                            strFileName, 
//                            Encoding.Default);
      }

      private void ReadSettingsFromFile() 
      {

         //  Make the directory the current directory.
         Directory.SetCurrentDirectory(strDirName);

         //  Create a BinaryReader (wrapped around a 
         //     FileStream wrapped around the file)
         //     for input using the user specified 
         //     encoding.
         BinaryReader brdrFile = 
            new BinaryReader(
               new FileStream(strFileName, 
                              FileMode.OpenOrCreate,
                              FileAccess.Read,
                              FileShare.None), 
               encodeFile);

         //  Read the three fields and create the font.
         //  Close the file.
         textInput.Font = 
            new Font(brdrFile.ReadString(), 
                     brdrFile.ReadSingle(), 
                     (FontStyle)brdrFile.ReadInt32());
         brdrFile.Close();

      }
      #endregion

      #region Font Settings Structure

      //  A structure containing font information and 
      //     the routines to write / restore that info 
      //     to / from a file.
      private struct ourFontInfo
      {
         public string strName;
         public float sglSize;
         public FontStyle fsStyle;

         public void WriteToFile(string  strDirName,  
                                 string  strFileName,  
                                 Encoding encodeFile) 
         {
            //  Create the directory if it does not
            //     already exist, and make it the
            //     current directory.
            if (! Directory.Exists(strDirName) ) 
            {
               Directory.CreateDirectory(strDirName);
            }
            Directory.SetCurrentDirectory(strDirName);

            //  Create the file if it does not
            //     already exist.
            if (! File.Exists(strFileName) ) 
            {
               File.Create(strFileName).Close();
            }

            //  Create a BinaryWriter (wrapped around a 
            //     FileStream wrapped around the file)
            //     for output using the user specified 
            //     encoding.
            BinaryWriter bwrtFile = 
                           new BinaryWriter(
                              new FileStream(
                                       strFileName,
                                       FileMode.OpenOrCreate, 
                                       FileAccess.Write,
                                       FileShare.None), 
                           encodeFile);

            //  Write the three fields, each of a 
            //     different data type.  
            //  Close the file.
            bwrtFile.Write(this.strName);
            bwrtFile.Write(this.sglSize);
            bwrtFile.Write((int)this.fsStyle);
            bwrtFile.Close();
         }

         public void ReadFromFile(string  strDirName,  
                                  string  strFileName,  
                                  Encoding encodeFile) 
         {
            //  Set the current directory
            Directory.SetCurrentDirectory(strDirName);

            //  Create a BinaryReader (wrapped around a 
            //     FileStream wrapped around the file)
            //     for input using the user specified 
            //     encoding.
            BinaryReader brdrFile = 
                           new BinaryReader(
                              new FileStream(
                                       strFileName, 
                                       FileMode.OpenOrCreate,
                                       FileAccess.Read,
                                       FileShare.None), 
                           encodeFile);
                
            //  Read the three fields.
            //  Close the file.
            try
            {
               this.strName = brdrFile.ReadString();
               this.sglSize = brdrFile.ReadSingle();
               this.fsStyle = (FontStyle)brdrFile.ReadInt32();
            }
            catch
            {
               this.strName = "Tahoma";
               this.sglSize = 9;
               this.fsStyle = FontStyle.Regular;
            }
            finally
            {
               brdrFile.Close();
            }
         }
      }

      #endregion

      #region Save/Restore to Registry

      //  Variables for registry access.
      UtilRegistry  urNotepad = new UtilRegistry();

      string  strNotepadCE = "NotepadCe";
      string  strFont = "Font";
      string  strName = "Name";
      string  strSize = "Size";
      string  strStyle = "Style";
      string  strOptions = "Options";
      string  strMenu = "Menu";
      string  strToolBar = "ToolBar";
      string  strScrollBars = "ScrollBars";
      string  strTextAlign = "TextAlign";
      string  strWordWrap = "WordWrap";

      private void mitemSettingsSave_Click(object sender, 
                                           EventArgs e)
      {
         //    Use the UtilRegistry object to save the
         //       font settings.
         //    UtilRegistry has three overloads for 
         //       SetValue; string, integer, and boolean.
         //    Font Size and Style are data types that
         //       derive from integer; they have to 
         //       be converted to integer for this call.  
         //    Font.Style data type, because it has 
         //       the [Flags] attribute, requires an 
         //       unchecked conversion.
         urNotepad.SetValue(
            strNotepadCE + @"\" + strFont, 
            strName, 
            textInput.Font.Name);
         urNotepad.SetValue(
            strNotepadCE + @"\" + strFont, 
            strSize, 
            Convert.ToInt32(textInput.Font.Size));
         urNotepad.SetValue(
            strNotepadCE + @"\" + strFont, 
            strStyle, 
            unchecked((System.Int32)textInput.Font.Style));

         //    Use the UtilRegistry object to save the
         //       Textbox settings; three of which are
         //       boolean, two of which are [Flags] 
         //       attributed unsigned integers.
         urNotepad.SetValue(
            strNotepadCE + @"\" + strOptions, 
            strMenu, 
            this.Menu == this.menuMain);
         urNotepad.SetValue(
            strNotepadCE + @"\" + strOptions, 
            strToolBar, 
            this.Controls.Contains(tbarCommands));
         urNotepad.SetValue(
            strNotepadCE + @"\" + strOptions, 
            strScrollBars, 
            unchecked((System.Int32)textInput.ScrollBars));
         urNotepad.SetValue(strNotepadCE + @"\" + strOptions, 
            strTextAlign, 
            unchecked((System.Int32)textInput.TextAlign));
         urNotepad.SetValue(strNotepadCE + @"\" + strOptions, 
            strWordWrap, 
            textInput.WordWrap);
      }

      // Version that uses the ourFontInfo structure
//      private void mitemSettingsSave_Click(object sender, 
//         EventArgs e)
//      {
//         string  strDirName = @"My Documents\NotepadCE";
//         string  strFileName = "Settings.dat";
//
//         //  Create an ourFontInfo structure, load it from
//         //     TextInput's font, have the structure save
//         //     its contents to the file.
//      
//         ourFontInfo fiFont= new ourFontInfo();
//         fiFont.strName = textInput.Font.Name;
//         fiFont.sglSize = textInput.Font.Size;
//         fiFont.fsStyle = textInput.Font.Style;
//         fiFont.WriteToFile(
//            strDirName, strFileName, Encoding.Default);
//      }


      private void mitemSettingsRestore_Click(object sender, 
                                              EventArgs e)
      {
         //  Read Font info, if any, from the registry, 
         //  Create a font from that info, or use default
         //     values if no info is in the registry.
         //  Set textInput.Font = that font.
         string  strFontName;
         int intFontSize;
         int intFontStyle;

         strFontName = "Tahoma";
         urNotepad.GetValue(strNotepadCE + @"\" + strFont, 
                            strName, 
                            ref strFontName);

         intFontSize = 9;
         urNotepad.GetValue(strNotepadCE + @"\" + strFont, 
                            strSize, 
                            ref intFontSize);

         intFontStyle = (int)FontStyle.Regular;
         urNotepad.GetValue(strNotepadCE + @"\" + strFont, 
                            strStyle, 
                            ref intFontStyle);
            textInput.Font = 
               new Font(strFontName, 
                        intFontSize, 
                        (FontStyle)intFontStyle);

         //  Read Option info, if any, from the registry.
         //  Set the properties from that info, or use default
         //     values if no info is in the registry.
         bool boolTemp;
         int intTemp;

         //  .Menu is either menuMain or null
         boolTemp = true;
         urNotepad.GetValue(strNotepadCE + @"\" + strOptions, 
                            strMenu, 
                            ref boolTemp);
         this.Menu = boolTemp ? this.menuMain : null;

         //  .Controls either contains 
         //     tbarCommands or it doesn't
         boolTemp = true;
         urNotepad.GetValue(strNotepadCE + @"\" + strOptions, 
                            strToolBar, 
                            ref boolTemp);
            if ( boolTemp ) 
            {
               if (! this.Controls.Contains(this.tbarCommands) ) 
               {
                  this.Controls.Add(this.tbarCommands);
               }
            } 
            else 
            {
               if ( this.Controls.Contains(this.tbarCommands) ) 
               {
                  this.Controls.Remove(this.tbarCommands);
               }
            }

         //  .ScrollBars
         intTemp = (int)ScrollBars.Both;
         urNotepad.GetValue(strNotepadCE + @"\" + strOptions, 
                            strScrollBars, 
                            ref intTemp);
            textInput.ScrollBars = (ScrollBars)intTemp;

         //  .TextAlign
         intTemp = (int)HorizontalAlignment.Left;
         urNotepad.GetValue(strNotepadCE + @"\" + strOptions, 
                            strTextAlign, 
                            ref intTemp);
            textInput.TextAlign = (HorizontalAlignment)intTemp;

         //  .WordWrap
         boolTemp = true;
         urNotepad.GetValue(strNotepadCE + @"\" + strOptions, 
                            strWordWrap, 
                            ref boolTemp);
            textInput.WordWrap = boolTemp;
      }


      // Version that uses the ourFontInfo structure
//      private void mitemSettingsRestore_Click(object sender, 
//                                              EventArgs e)
//      {
//         string  strDirName = @"My Documents\NotepadCE";
//         string  strFileName = "Settings.dat";
//
//         //  Create an ourFontInfo structure, have the 
//         //     structure load itself from the file, 
//         //     create the font from the loaded info.
//         ourFontInfo fiFont = new ourFontInfo();
//         fiFont.ReadFromFile(
//            strDirName, strFileName, Encoding.Default);
//         textInput.Font = 
//            new Font(
//            fiFont.strName, fiFont.sglSize, fiFont.fsStyle);
//      }


      private void mitemSettingsInit_Click(object sender, 
                                           EventArgs e)
      {
         //    Initialize the settings by deleting the
         //       registry key where they are stored and
         //       then restoring from the non existant
         //       key to reinstate all default values.
         urNotepad.DeleteKey(strNotepadCE);
         mitemSettingsRestore_Click(this, EventArgs.Empty);
      }
      #endregion
   }
} 