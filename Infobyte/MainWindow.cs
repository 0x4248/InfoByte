using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Security.Principal;
using System.Reflection;
using System.Threading.Tasks;
namespace Infobyte
{
	public partial class MainWindow : Form
	{
		public MainWindow()
		{
			InitializeComponent();
			DateTime timeofstart = DateTime.UtcNow;
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
			progressBar.Value = 10;
			//Processes
			Process[] processlist = Process.GetProcesses();
			File.WriteAllText("SystemInfo.txt", "InfoByte Diagnostics:");
			File.AppendAllText("SystemInfo.txt", Environment.NewLine + "Time of Diagnostics: " + timeofstart.ToString());
			File.AppendAllText("SystemInfo.txt", Environment.NewLine + "Machine Name: " + Environment.MachineName);

			File.AppendAllText("SystemInfo.txt", Environment.NewLine + "CPU at the time of the test: " + cpu);
			File.AppendAllText("SystemInfo.txt", Environment.NewLine + "===================================");
			progressBar.Value = 20;
			foreach (Process process in processlist)
			{
				File.AppendAllText("SystemInfo.txt", Environment.NewLine + "Process |" + process.ProcessName);
			}
			progressBar.Value = 40;
			File.AppendAllText("SystemInfo.txt", Environment.NewLine + "===================================");
			//Drive Info
			DriveInfo[] allDrives = DriveInfo.GetDrives();
			progressBar.Value = 100;
			foreach (DriveInfo d in allDrives)
			{
				File.AppendAllText("SystemInfo.txt", Environment.NewLine + "Drive " + d.Name);
				File.AppendAllText("SystemInfo.txt", Environment.NewLine + "  Drive type: " + d.DriveType);
				if (d.IsReady == true)
				{
					File.AppendAllText("SystemInfo.txt", Environment.NewLine + "  Volume label:" + d.VolumeLabel);
					File.AppendAllText("SystemInfo.txt", Environment.NewLine + "  File system: " + d.DriveFormat);
					File.AppendAllText("SystemInfo.txt", Environment.NewLine + "  Available space to current user: " + d.AvailableFreeSpace + " Bytes");
					File.AppendAllText("SystemInfo.txt", Environment.NewLine + "  Total available space:" + d.TotalFreeSpace + " Bytes");
					File.AppendAllText("SystemInfo.txt", Environment.NewLine + "  Total size of drive:" + d.TotalSize + " Bytes");
				}
			}
			Messagebox msg = new Messagebox();
			msg.Show();
			this.Hide();
		}

		private void stop_Click(object sender, EventArgs e)
		{
			string message = "Do you want to close this window? Doing this will stop the test";
			string title = "Close Window";
			MessageBoxButtons buttons = MessageBoxButtons.YesNo;
			DialogResult result = MessageBox.Show(message, title, buttons);
			if (result == DialogResult.Yes)
			{
				Environment.Exit(0);
			}
			else
			{
				;
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
