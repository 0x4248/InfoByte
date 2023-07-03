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

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainWindow());

		}
	}
}
