namespace Simple_Punch_Out_Game
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			cpuHealthBar = new ProgressBar();
			playerHealthBar = new ProgressBar();
			player = new PictureBox();
			cpu = new PictureBox();
			cpuAttackTimer = new System.Windows.Forms.Timer(components);
			cpuMoveTimer = new System.Windows.Forms.Timer(components);
			((System.ComponentModel.ISupportInitialize)player).BeginInit();
			((System.ComponentModel.ISupportInitialize)cpu).BeginInit();
			SuspendLayout();
			// 
			// cpuHealthBar
			// 
			cpuHealthBar.Location = new Point(21, 49);
			cpuHealthBar.Name = "cpuHealthBar";
			cpuHealthBar.Size = new Size(287, 34);
			cpuHealthBar.TabIndex = 0;
			// 
			// playerHealthBar
			// 
			playerHealthBar.Location = new Point(418, 49);
			playerHealthBar.Name = "playerHealthBar";
			playerHealthBar.Size = new Size(287, 34);
			playerHealthBar.TabIndex = 0;
			// 
			// player
			// 
			player.BackColor = Color.Transparent;
			player.Image = Properties.Resources.boxer_stand;
			player.Location = new Point(336, 379);
			player.Name = "player";
			player.Size = new Size(61, 153);
			player.SizeMode = PictureBoxSizeMode.AutoSize;
			player.TabIndex = 1;
			player.TabStop = false;
			// 
			// cpu
			// 
			cpu.BackColor = Color.Transparent;
			cpu.Image = Properties.Resources.enemy_stand;
			cpu.Location = new Point(388, 285);
			cpu.Name = "cpu";
			cpu.Size = new Size(77, 185);
			cpu.SizeMode = PictureBoxSizeMode.AutoSize;
			cpu.TabIndex = 2;
			cpu.TabStop = false;
			// 
			// cpuAttackTimer
			// 
			cpuAttackTimer.Interval = 350;
			cpuAttackTimer.Tick += cpuAttackTimerEvent;
			// 
			// cpuMoveTimer
			// 
			cpuMoveTimer.Interval = 30;
			cpuMoveTimer.Tick += cpuMoveTimerEvent;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			BackgroundImage = Properties.Resources.background;
			BackgroundImageLayout = ImageLayout.Stretch;
			ClientSize = new Size(728, 544);
			Controls.Add(player);
			Controls.Add(playerHealthBar);
			Controls.Add(cpuHealthBar);
			Controls.Add(cpu);
			DoubleBuffered = true;
			Name = "Form1";
			Text = "Simple Punch Out Game";
			KeyDown += KeyIsDown;
			KeyPress += KeyIsUp;
			((System.ComponentModel.ISupportInitialize)player).EndInit();
			((System.ComponentModel.ISupportInitialize)cpu).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private ProgressBar cpuHealthBar;
		private ProgressBar playerHealthBar;
		private PictureBox player;
		private PictureBox cpu;
		private System.Windows.Forms.Timer cpuAttackTimer;
		private System.Windows.Forms.Timer cpuMoveTimer;
	}
}
