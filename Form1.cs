using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Simple_Punch_Out_Game
{
	public partial class Form1 : Form
	{
		string playerWinMessage = "You Win. Play again?";
		string cpuWinMessage = "You Lose. Try again?";
		bool playerBlock = false;
		bool enemyBlock = false;
		Random random = new Random();
		int enemySpeed = 5;
		int index = 0;
		int playerHealth = 100;
		int enemyHealth = 120;
		List<string> enemyAttack = new List<string> { "left", "right", "block"};

		bool canPunch = true;
		System.Windows.Forms.Timer punchCoolDownTimer = new System.Windows.Forms.Timer();

		public Form1()
		{
			InitializeComponent();
			// Initialize the punch cooldown timer
			punchCoolDownTimer.Interval = 300; // Cooldown period in milliseconds
			punchCoolDownTimer.Tick += PunchCoolDownTimer_Tick;

			ResetGame();
		}

		private void PunchCoolDownTimer_Tick(object sender, EventArgs e)
		{
			canPunch = true; // Allow the player to punch again
			punchCoolDownTimer.Stop(); // Stop the timer
		}

		private void cpuAttackTimerEvent(object sender, EventArgs e)
		{
			//
			index = random.Next(0, enemyAttack.Count);

			switch (enemyAttack[index].ToString())
			{
				case "left":
					cpu.Image = Properties.Resources.enemy_punch1;
					enemyBlock = false;

					if (cpu.Bounds.IntersectsWith(player.Bounds) && playerBlock == false)
					{
						playerHealth -= 6;
					}

					break;

				case "right":

					cpu.Image = Properties.Resources.enemy_punch2;
					enemyBlock = false;

					if (cpu.Bounds.IntersectsWith(player.Bounds) && playerBlock == false)
					{
						playerHealth -= 6;
					}

					break;

				case "block":

					cpu.Image = Properties.Resources.enemy_block;
					enemyBlock = true;

					break;

			}
		}

		private void cpuMoveTimerEvent(object sender, EventArgs e)
		{
			// set up both health bars here
			if (playerHealth > 1)
			{
				playerHealthBar.Value = playerHealth;
			}

			if (enemyHealth > 1)
			{
				cpuHealthBar.Value = enemyHealth;
			}

			// moves the cpu
			cpu.Left += enemySpeed;

			if (cpu.Left > 430)
			{
				enemySpeed = -5;
			}

			if (cpu.Left < 220)
			{
				enemySpeed = 5;
			}

			// check for end game
			if (enemyHealth < 1)
			{
				cpuAttackTimer.Stop();
				cpuMoveTimer.Stop();
				EndGame(playerWinMessage);
				
			}
			if (playerHealth < 1)
			{
				cpuAttackTimer.Stop();
				cpuMoveTimer.Stop();
				EndGame(cpuWinMessage);
			}
		}

		private void KeyIsDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Left && canPunch)
			{
				player.Image = Properties.Resources.boxer_left_punch;
				playerBlock = false;

				if (player.Bounds.IntersectsWith(cpu.Bounds) && enemyBlock == false)
				{
					enemyHealth -= 6;
				}

				canPunch = false;
				punchCoolDownTimer.Start();
			}
			if (e.KeyCode == Keys.Down && canPunch)
			{
				player.Image = Properties.Resources.boxer_block;
				playerBlock = true;

				canPunch = false;
				punchCoolDownTimer.Start();
			}

			if (e.KeyCode == Keys.Right && canPunch)
			{
				player.Image = Properties.Resources.boxer_right_punch;
				playerBlock = true;

				if (player.Bounds.IntersectsWith(cpu.Bounds) && enemyBlock == false)
				{
					enemyHealth -= 6;
				}

				canPunch = false;
				punchCoolDownTimer.Start();
			}
		}

		private void KeyIsUp(object sender, KeyPressEventArgs e)
		{
				player.Image = Properties.Resources.boxer_stand;
				playerBlock = false;
		
		}

		private void EndGame(string message)
		{
			// Stop all timers
			cpuAttackTimer.Stop();
			cpuMoveTimer.Stop();
			punchCoolDownTimer.Stop();

			// Show end game message
			DialogResult result = MessageBox.Show(message, "Game Over", MessageBoxButtons.OK);

			//Reset if user selects OK
			if (result == DialogResult.OK) 
			{
				ResetGame();
			}
		}

		private void ResetGame()
		{
			// Reset health, positioning, and timers
			cpuAttackTimer.Start();
			cpuMoveTimer.Start();
			playerHealth = 100;
			enemyHealth = 100;

			cpu.Left = 400;

			cpu.Image = Properties.Resources.enemy_stand; //show the enemy stand image
			player.Image = Properties.Resources.boxer_stand; //show the player stand image 

			// Restart timers
			cpuAttackTimer.Start();
			cpuMoveTimer.Start();
		}

		private void CheckGame()
		{

		}
	}
}
