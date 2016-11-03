using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Cryptonite
{
    public static class Program
    {
        public static bool[] settings = new bool[2];
        public static readonly string applicationDataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Cryptonite";
        public static readonly string[] fileNames = { applicationDataDirectory + "\\settings.ini", applicationDataDirectory + "\\cryman.exe" };
        
        public static Form form;

        [STAThread]
        public static void Main(string[] args)
        {
            try
            {
                Cryptography.LoadDatabase();
            }
            catch
            {
                MessageBox.Show(null, "Sorry, we were unable to load the database.",
                    "Cryptonite", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            form = new Form();

            if (args.Length > 0)
            {
                form.fileName = args[0];
            }

            Application.Run(form);
        }

        private static void CreateApplicationDataDirectory()
        {
            try
            {
                if (!Directory.Exists(applicationDataDirectory))
                {
                    Directory.CreateDirectory(applicationDataDirectory);
                }
            }
            catch
            {
                throw new Exception();
            }
        }

        public static void WriteSettings()
        {
            try
            {
                CreateApplicationDataDirectory();

                using (StreamWriter streamWriter = new StreamWriter(fileNames[0]))
                {
                    streamWriter.WriteLine(settings[0]);
                    streamWriter.WriteLine(settings[1]);
                    streamWriter.Flush();
                }
            }
            catch
            {
                /*
                 * don't need to handle this exception...
                 */
            }
        }

        public static void ReadSettings()
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(fileNames[0]))
                {
                    Boolean.TryParse(streamReader.ReadLine(), out settings[0]);
                    Boolean.TryParse(streamReader.ReadLine(), out settings[1]);
                }
            }
            catch
            {
                /*
                 * don't need to handle this exception...
                 */
            }
        }

        public static void StartProcess(string argument)
        {
            try
            {
                CreateApplicationDataDirectory();

                if (!File.Exists(fileNames[1]))
                {
                    using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Cryptonite.Resources.cryman.exe"))
                    {
                        using (FileStream fileStream = new FileStream(fileNames[1], FileMode.Create))
                        {
                            for (int i = 0; i < stream.Length; i++)
                            {
                                fileStream.WriteByte((byte)stream.ReadByte());
                            }
                        }
                    }
                }

                Process process = new Process();
                process.StartInfo.FileName = fileNames[1];
                process.StartInfo.Arguments = "\"" + Application.ExecutablePath + "\" " + argument;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.Verb = "runas";
                process.Start();

                process.WaitForExit();
                process.Close();
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}