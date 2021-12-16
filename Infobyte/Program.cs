using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Security.Principal;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Infobyte
{
	internal class Program
	{
		static void Main(string[] args)
		{
			try
			{
				if (args[0] == "-v")
				{
					Console.WriteLine(Assembly.GetEntryAssembly().GetName().Version.ToString());
					Environment.Exit(0);
				}
			}
			catch (Exception)
			{
				//pass
			}
			
			DateTime timeofstart = DateTime.UtcNow;
			//TODO: Make Arg's
			Console.WriteLine("Starting Diagnostics...");
			if (IsElevated == false)
			{
				Console.WriteLine("WARNING: InfoByte Is not elevated please run the program as a admin");
			}
			// Cpu Usage
			var cpuUsage = new PerformanceCounter("Processor", "% Processor Time", "_Total");
			Thread.Sleep(10);
			var firstCall = cpuUsage.NextValue();
			Thread.Sleep(10);
			var cpu = cpuUsage.NextValue() + "%";
			//Processes
			Process[] processlist = Process.GetProcesses();
			File.WriteAllText("SystemInfo.txt", "InfoByte Diagnostics:");
			File.AppendAllText("SystemInfo.txt", Environment.NewLine + "Time of Diagnostics: " + timeofstart.ToString());
			File.AppendAllText("SystemInfo.txt", Environment.NewLine + "Machine Name: " + Environment.MachineName);

			File.AppendAllText("SystemInfo.txt", Environment.NewLine + "CPU at the time of the test: " + cpu);
			File.AppendAllText("SystemInfo.txt", Environment.NewLine + "===================================");
			foreach (Process process in processlist)
			{
				File.AppendAllText("SystemInfo.txt", Environment.NewLine + "Process |" + process.ProcessName);
			}
			File.AppendAllText("SystemInfo.txt", Environment.NewLine + "===================================");
			//Drive Info
			DriveInfo[] allDrives = DriveInfo.GetDrives();

			foreach (DriveInfo d in allDrives)
			{
				File.AppendAllText("SystemInfo.txt", Environment.NewLine+"Drive "+ d.Name);
				File.AppendAllText("SystemInfo.txt", Environment.NewLine+"  Drive type: "+ d.DriveType);
				if (d.IsReady == true)
				{
					File.AppendAllText("SystemInfo.txt", Environment.NewLine+"  Volume label:"+ d.VolumeLabel);
					File.AppendAllText("SystemInfo.txt", Environment.NewLine+"  File system: "+ d.DriveFormat);
					File.AppendAllText("SystemInfo.txt", Environment.NewLine+"  Available space to current user: "+d.AvailableFreeSpace+" Bytes");
					File.AppendAllText("SystemInfo.txt", Environment.NewLine+"  Total available space:" + d.TotalFreeSpace+" Bytes");
					File.AppendAllText("SystemInfo.txt", Environment.NewLine+"  Total size of drive:"+d.TotalSize+" Bytes");
				}
				
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new Messagebox());
				
			}
			
		}
		static bool IsElevated
		{
			get
			{
				return WindowsIdentity.GetCurrent().Owner
				  .IsWellKnown(WellKnownSidType.BuiltinAdministratorsSid);
			}
		}
	}
}
