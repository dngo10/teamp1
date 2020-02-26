using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WindowsFormsApp4
{
    public partial class NewProjectForm : Form
    {
        private FolderBrowserDialog folderBrowserDialog;

        public static string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
        JObject jObject = JObject.Parse(File.ReadAllText(Path.GetDirectoryName(exePath) + "\\data.json"));
        string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string exeFileName = "helper.exe";

        string dllCommand = "fixXref";
        string dllPath = Path.GetDirectoryName(exePath) + "\\FixXref_File1.dll";
        string outputFile;

        string mPath;
        string nPath;
        string gPath;
        public NewProjectForm()
        {
            InitializeComponent();

            folderBrowserDialog = new FolderBrowserDialog();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void NewProjectForm_Load(object sender, EventArgs e)
        {
            mPath = jObject["drive"]["M"].ToString();

            oldLocationTextBox.Text =  gPath = jObject["drive"]["G"].ToString() + "\\";
            newLocationTextBox.Text = nPath = mPath + "\\Name\\" + Environment.GetEnvironmentVariable("USERNAME") + "\\";
            
        }

        private void oldLocationButtonSearch_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = folderBrowserDialog.ShowDialog();
            if(dialogResult == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
            {
                if (Directory.Exists(folderBrowserDialog.SelectedPath))
                {
                    oldLocationTextBox.Text = folderBrowserDialog.SelectedPath;
                }
                // There is basically no else here.
            }
        }

        private void newLocationButtonSearch_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = folderBrowserDialog.ShowDialog();
            if (dialogResult == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
            {
                newLocationTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            string oldLocation = oldLocationTextBox.Text;
            string newLocation = newLocationTextBox.Text;

            if (!Directory.Exists(oldLocation))
            {
                var oldColor = oldLocationTextBox.BackColor; 
                oldLocationTextBox.BackColor = Color.DarkOrange;
                 MessageBox.Show("Folder does not exist, please choose a different folder", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                oldLocationTextBox.BackColor = oldColor;
            }
            else
            {
                if (Directory.Exists(newLocation))
                {
                    var newColor = newLocationTextBox.BackColor;
                    newLocationTextBox.BackColor = Color.DarkOrange;
                    DialogResult dialogResult = MessageBox.Show("Folder exists, do you want to delete it ?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    if(dialogResult == DialogResult.OK)
                    {
                        try { Directory.Delete(newLocation, true); }
                        catch (Exception deteleteError)
                        {
                            MessageBox.Show($"Can't delete folder, {deteleteError.Message}", "Delete Error!", MessageBoxButtons.OK);
                        }
                    }
                    newLocationTextBox.BackColor = newColor;
                }
                else
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(newLocation);
                    string newLocationParentPath = Directory.GetParent(newLocation).FullName;
                    if (!IsDirectoryWritable(newLocationParentPath))
                    {
                        var newColor = newLocationTextBox.BackColor;
                        newLocationTextBox.BackColor = Color.DarkOrange;
                        MessageBox.Show($"Path to create folder: {newLocationParentPath} is NOT editable, please choose a different one.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        newLocationTextBox.BackColor = newColor;
                    }
                    else
                    {
                        //Serialize Json
                        ExportClass exportClass = new ExportClass();
                        exportClass.newLocation = newLocation;
                        exportClass.oldLocation = oldLocation;
                        exportClass.dllCommand = dllCommand;
                        exportClass.dllPath = dllPath;
                        
                        string result = JsonConvert.SerializeObject(exportClass);
                        string tick = DateTime.Now.Ticks.ToString();
                        string fileToWrite = $"{tick}jsondata.json";
                        outputFile = Path.GetDirectoryName(exePath) + $"\\{tick}checkIt.json";

                        File.WriteAllText( exeDirectory + fileToWrite, result);
                        ProcessStartInfo processStartInfo = new ProcessStartInfo(exeDirectory + exeFileName, fileToWrite);
                        Process process = new Process();
                        process.StartInfo = processStartInfo;
                        process.Start();
                        process.WaitForExit();
                    }
                }
            }
        }

        public bool IsDirectoryWritable(string dirPath, bool throwIfFails = false)
        {
            try
            {
                using (FileStream fs = File.Create(
                    Path.Combine(
                        dirPath,
                        Path.GetRandomFileName()
                    ),
                    1,
                    FileOptions.DeleteOnClose)
                )
                { }
                return true;
            }
            catch
            {
                if (throwIfFails)
                    throw;
                else
                    return false;
            }
        }
    }

    public class ExportClass
    {
        public string oldLocation;
        public string newLocation;
        public string dllCommand;
        public string dllPath;
        public string outputFile;
    }

    
}
