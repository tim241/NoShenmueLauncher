using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace NoShenmueLauncher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // start shenmue 1 when no arguments have been provided
            string exec = Path.Combine(Environment.CurrentDirectory, @"sm1\Shenmue.exe");

            // when the argument is 'sm2', launch shenmue 2
            if (args.Length > 0 && args[0] == "sm2")
                exec = Path.Combine(Environment.CurrentDirectory, @"sm2\Shenmue2.exe");

            // make sure the executable actually exists, if not, display an error
            if(!File.Exists(exec))
            {
                MessageBox.Show("Cannot find the shenmue/shenmue2 executable!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // launch the selected game
            using(Process p = new Process())
            {
                p.StartInfo = new ProcessStartInfo()
                {
                    FileName = exec,
                    UseShellExecute = false,
                    CreateNoWindow = false,
                    WorkingDirectory = Path.GetDirectoryName(exec)
                };

                p.Start();
                p.WaitForExit();
            }
        }
    }
}
