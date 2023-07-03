using System;
using System.Windows.Forms;
using System.Diagnostics;
namespace Infobyte
{
	public partial class Messagebox : Form
	{
		public Messagebox()
		{
			InitializeComponent();
		}

		private void Close_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}
		private void Notepad_Click(object sender, EventArgs e)
		{
			string strCmdText = "Systeminfo.txt";
			Process.Start("notepad", strCmdText);
			Environment.Exit(0);
			
		}
	}
}
