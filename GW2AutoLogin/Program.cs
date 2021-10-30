using System;
using System.Diagnostics;
using System.IO;
using WindowsInput;
using WindowsInput.Native;

namespace GW2AutoLogin
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {


                string[] lines = System.IO.File.ReadAllLines(Directory.GetCurrentDirectory()  + @"\config.txt");

                string path = lines[0];
                //int timeOut = int.Parse(lines[1]);


                Process firstProc = new Process();

                firstProc.StartInfo.UseShellExecute = true;
                firstProc.StartInfo.WorkingDirectory = path;
                firstProc.StartInfo.FileName = "Gw2-64";
                firstProc.EnableRaisingEvents = true;

                for (int i =2; i < lines.Length; i+=2)
                {
                    firstProc.Start();
                    System.Threading.Thread.Sleep(10 * 1000);
                    InputSimulator s = new InputSimulator();

                    s.Keyboard.TextEntry(lines[i]);



                    s.Keyboard.KeyPress(VirtualKeyCode.TAB);

                    s.Keyboard.TextEntry(lines[i+1]);

                    s.Keyboard.KeyPress(VirtualKeyCode.RETURN);

                    System.Threading.Thread.Sleep(10 * 1000);
                    s.Keyboard.KeyPress(VirtualKeyCode.RETURN);

                    System.Threading.Thread.Sleep(10 * 1000);
                    s.Keyboard.KeyPress(VirtualKeyCode.RETURN);

                    System.Threading.Thread.Sleep(30 * 1000);


                    firstProc.Kill();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred!!!: " + ex.Message);
                return;
            }
        }
    }
}
