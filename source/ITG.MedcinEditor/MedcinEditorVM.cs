using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Input;

using ITG.Common;
using System.Xml;
using System.Collections.ObjectModel;
using DALT.Utility;

namespace ITG.MedcinEditor
{
    // TODO: implement passive validation!

    public class MedcinEditorVM : ViewModelBase
    {
        #region FIELDS

        private bool dirty = false;
        private bool busy = false;

        private const string APPNAME = "ITG Medcin Editor";
        private string curFilePath = "";

        #endregion


        #region CONSTRUCTOR

        public MedcinEditorVM()
        {
            NewDatabaseCommand = new MyCommand(ExecuteNewDatabaseCommand);
            OpenDatabaseCommand = new MyCommand(ExecuteOpenDatabaseCommand);
            SaveDatabaseCommand = new MyCommand(CanExecuteSaveDatabaseCommand, ExecuteSaveDatabaseCommand);
            SaveAsDatabaseCommand = new MyCommand(CanExecuteSaveDatabaseCommand, ExecuteSaveAsDatabaseCommand);
            
            // ValidateDatabaseCommand = new MyCommand(CanExecuteValidateDatabaseCommand, ExecuteValidateDatabaseCommand);
            // ValidateMedcinUIdCommand = new MyCommand(CanExecuteValidateMedcinUIdCommand, ExecuteValidateMedcinUIdCommand);
        }

        #endregion


        #region PROPERTIES

        public ObservableCollection<MedcinTerm> Terms
        { get { return MedcinData.Terms; } }

        public bool Dirty
        {
            get { return dirty; }
            set
            {
                if (dirty != value)
                {
                    dirty = value;
                    NotifyPropertyChanged("Dirty");
                    NotifyPropertyChanged("WindowTitle");
                }
            }
        }

        public bool Busy
        {
            // Editor display of busy status not currently implemented
            get { return busy; }
            set
            {
                if (busy != value)
                {
                    busy = value;
                    NotifyPropertyChanged("Busy");
                }
            }
        }

        public string WindowTitle
        {
            get
            {
                if ((CurrentFilePath == "") && (!Dirty))
                    return APPNAME;
                if ((CurrentFilePath == "") && (Dirty))
                    return APPNAME + "*";
                else
                {
                    if (Dirty)
                        return APPNAME + " - " + CurrentFileName + "*";
                    else
                        return APPNAME + " - " + CurrentFileName;
                }
            }
        }

        public string CurrentFilePath
        {
            get { return curFilePath; }
            set
            {
                if (curFilePath != value)
                {
                    curFilePath = value;
                    NotifyPropertyChanged("CurrentFilePath");
                    NotifyPropertyChanged("WindowTitle");
                }
            }
        }

        public string CurrentFileName
        {
            get
            {
                return Path.GetFileName(CurrentFilePath);
            }
        }

        #endregion


        #region COMMANDS

        public MyCommand NewDatabaseCommand { get; private set; }
        private void ExecuteNewDatabaseCommand(object parameter)
        {
            // prevent user from inadvertently losing work
            if (!MedcinData.IsEmpty() && Dirty)
            {
                MessageBoxResult result = MessageBox.Show("Current database has unsaved changes which will be lost. Proceed?", 
                    "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.No)
                    return;
            }

            MedcinData.Reset();
            curFilePath = "";
            Dirty = false;
        }

        public MyCommand OpenDatabaseCommand { get; private set; }
        private void ExecuteOpenDatabaseCommand(object parameter)
        {
            // prevent user from inadvertently losing work
            if (!MedcinData.IsEmpty() && Dirty)
            {
                MessageBoxResult result = MessageBox.Show("Current database has unsaved changes which will be lost. Proceed?", 
                    "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.No) 
                    return;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Xml (*.xml)|*.xml";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == true)
            {
                CurrentFilePath = openFileDialog.FileName;
                MedcinData.Reset();
                ImportXml(CurrentFilePath);   
            }
        }

        public MyCommand SaveDatabaseCommand { get; private set; }
        private void ExecuteSaveDatabaseCommand(object parameter)
        {
            if (!Dirty) return; // no point saving if no changes to save

            if (CurrentFilePath == "") // need a filename first!
                SaveAsDatabaseCommand.Execute(parameter);
            else
                ExportXml(CurrentFilePath);
        }

        private bool CanExecuteSaveDatabaseCommand(object parameter)
        {
            if (MedcinData.IsEmpty())
                return false;
            else 
                return true;
        }

        public MyCommand SaveAsDatabaseCommand { get; private set; }
        private void ExecuteSaveAsDatabaseCommand(object parameter)
        {            
            // Call validation
            // ...
            
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Xml (*.xml)|*.xml";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == true)
            {
                CurrentFilePath = saveFileDialog.FileName;
                ExportXml(CurrentFilePath);
            }
        }

        /* REGARDING TAKING OVER DELETE FUNCTIONS ETC ...
         * you would need to create and bind SelectedItem to act on that 
         * (then it would reflect in the view/datagrid)
         * but then it also needs handling/converters for when the interface
         * goes to the "new item" line. Trust you - you tried it already,
         * but it was way too much work to start at 03:40 on the ward. ;-)
         */

        /*
        public MyCommand ValidateDatabaseCommand { get; private set; }
        private void ExecuteValidateDatabaseCommand(object parameter)
        {
            MessageBox.Show("Not implemented.");
        }

        private bool CanExecuteValidateDatabaseCommand(object parameter)
        {
            if (MedcinData.IsEmpty()) 
                return false;
            else 
                return true;
        }

        public MyCommand ValidateMedcinUIdCommand { get; private set; }
        private void ExecuteValidateMedcinUIdCommand(object parameter)
        {
            MessageBox.Show("Not implemented.");
        }

        private bool CanExecuteValidateMedcinUIdCommand(object parameter)
        {
            if (MedcinData.IsEmpty()) return false;
            else return true;
        } */
        
        #endregion


        #region METHODS

        private void ExportXml(string path)
        {
            Busy = true;

            // create a temporary file stream so that if something goes wrong,
            // it doesn't corrupt the existing file
            string tempFile = Path.GetTempFileName();
            using (FileStream stream = File.Create(tempFile))
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;

                using (XmlWriter writer = XmlWriter.Create(stream, settings))
                {
                    writer.WriteStartElement("MedcinTerms");
                    MedcinData.WriteXml(writer);
                    writer.WriteEndElement();
                }
            }

            File.Copy(tempFile, path, true);
            File.Delete(tempFile);
            
            Dirty = false;
            Busy = false;
        }

        private void ImportXml(string path)
        {
            Busy = true;

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            
            using (XmlReader reader = XmlReader.Create(path, settings))
            {
                MedcinData.ReadXml(reader);
            }

            Dirty = false;
            Busy = false;
        }

        #endregion
    }
}