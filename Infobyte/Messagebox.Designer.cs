namespace Infobyte
{
	partial class Messagebox
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.Do_Nothing = new System.Windows.Forms.Button();
			this.Notepad = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(115, 31);
			this.label1.TabIndex = 0;
			this.label1.Text = "InfoByte";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(18, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(306, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Do you want to open the results in notepad or copy to clipboard";
			// 
			// Do_Nothing
			// 
			this.Do_Nothing.Location = new System.Drawing.Point(249, 62);
			this.Do_Nothing.Name = "Do_Nothing";
			this.Do_Nothing.Size = new System.Drawing.Size(75, 23);
			this.Do_Nothing.TabIndex = 2;
			this.Do_Nothing.Text = "Do nothing";
			this.Do_Nothing.UseVisualStyleBackColor = true;
			this.Do_Nothing.Click += new System.EventHandler(this.Close_Click);
			// 
			// Notepad
			// 
			this.Notepad.Location = new System.Drawing.Point(143, 62);
			this.Notepad.Name = "Notepad";
			this.Notepad.Size = new System.Drawing.Size(100, 23);
			this.Notepad.TabIndex = 3;
			this.Notepad.Text = "Open in Notepad";
			this.Notepad.UseVisualStyleBackColor = true;
			this.Notepad.Click += new System.EventHandler(this.Notepad_Click);
			// 
			// Messagebox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(329, 97);
			this.Controls.Add(this.Notepad);
			this.Controls.Add(this.Do_Nothing);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "Messagebox";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button Do_Nothing;
		private System.Windows.Forms.Button Notepad;
	}
}