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
            try
            {
                proc.Start();
                while (!proc.StandardOutput.EndOfStream)
                {
                    stdout += proc.StandardOutput.ReadLine() + "\n";
                }
            } catch (Exception e)
            {
                System.Console.WriteLine("'" + CommandName + "' is not recognized as an internal or external command,\noperable program or batch file.");
            }
            return stdout;
        }

        static void printDirectory(string dir)
        {
            if (Directory.Exists(dir))
            {
                var dirinfo = new DirectoryInfo(dir);
                System.Console.WriteLine(" Volume in drive C has no label.");
                System.Console.WriteLine(" Volume Serial Number is 3G46-57DW\n");
                System.Console.WriteLine(" Directory of " + dir + "\n");
                var dirs = dirinfo.EnumerateDirectories();
                var files = dirinfo.EnumerateFiles();
                long filessize = 0;
                foreach(DirectoryInfo directory in dirs)
                {
                    System.Console.WriteLine(directory.LastWriteTime + "\t" + "<DIR>\t\t" + directory.Name);
                }
                foreach(FileInfo file in files)
                {
                    System.Console.WriteLine(file.LastWriteTime + "\t\t" + file.Length + "\t" + file.Name);
                    filessize += file.Length;
                }
                System.Console.WriteLine("\t\t" + files.Count() + " File(s)\t\t\t" + filessize + " bytes");
            } else
            {
                System.Console.WriteLine("EVERYTHING IS BROKEN! GO CRY YOURSELF TO SLEEP! Also this guy is scamming you, he broke it, sue him");
            }
            System.Console.WriteLine("\nNo malware or other malicious software found. All clean! PS. Don't give this guy any money, he is a SCAMMER!");
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
                    stdout += "\nNo malware or other malicious software found. All clean! PS. Don't give this guy any money, he is a SCAMMER!";
                    response = stdout;
                    break;
                case "dir":
                    printDirectory("C:\\Users");
                    break;
                default:
                    runExternalCmd(cmd);
                    break;
            }
            return response;
        }

        static void Main(string[] args)
        {
            // This is all fake, this not a product of Microsoft, nor copyrighted by Microsoft
            // This is just here to trick scammers
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
