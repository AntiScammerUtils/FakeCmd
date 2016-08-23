using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Scammer_Cmd
{
    class Program
    {

        /*
         * Takes command, returns stdout
         */
        static String runExternalCmd(string cmd)
        {
            String stdout = "";
            String[] cmdElements = cmd.Split(' ');
            String CommandName = cmdElements[0];
            String args = "";
            for(int i = 1; i < cmdElements.Length; i++)
            {
                args += cmdElements[i] + " ";
            }
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = CommandName,
                    Arguments = args,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    WorkingDirectory = "C:\\"
                }
            };
            proc.Start();
            while (!proc.StandardOutput.EndOfStream)
            {
                stdout += proc.StandardOutput.ReadLine() + "\n";
            }
            return stdout;
        }

        static String processCmd(string cmd)
        {
            String response = "";
            String stdout;
            switch (cmd.Split(' ')[0])
            {
                case "netstat":
                    stdout = runExternalCmd(cmd);
                    stdout += "\nEverything you see here is completely normal, THIS IS NOT HACKING!";
                    response = stdout;
                    break;
                case "tree":
                    stdout = runExternalCmd(cmd + ".com");
                    stdout += "\nNo malware or other malicious software found. All clean! PS. Don't give this guy any money";
                    response = stdout;
                    break;
                case "dir":
                    var dirinfo = new DirectoryInfo("C:\\");
                    break;
                default:
                    response = "'" + cmd.Split(' ')[0] + "' is not recognized as an internal or external command,\noperable program or batch file.";
                    break;
            }
            return response;
        }

        static void Main(string[] args)
        {
            // Main Loop
            System.Console.WriteLine("Microsoft Windows [version 10.0.10240]");
            System.Console.WriteLine("(c) 2015 Microsoft Corporation. All rights reserved.\n");
            while (true)
            {
                System.Console.Write("C:\\>");
                String input = System.Console.ReadLine();
                System.Console.WriteLine(processCmd(input));
            }
        }
    }
}
