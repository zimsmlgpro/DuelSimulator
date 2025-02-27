using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DuelingMonsters
{
    public partial class Battle_Scene : Form
    {
        private List<DuelMonsters> playerTeam;
        private List<DuelMonsters> opponentTeam;
        private int currentPlayerIndex = 0;
        private int currentOpponentIndex = 0;

        private DuelMonsters playerMonster;
        private DuelMonsters opponentMonster;

        private static Random rnd = new Random();

        private PictureBox pbPlayer;
        private PictureBox pbOpponent;
        private Label lblVS;
        private Button btnBattle;

        public Battle_Scene(List<DuelMonsters> playerTeam, List<DuelMonsters> opponentPool)
        {
            this.ClientSize = new Size(816, 489);
            InitializeComponent();

            this.playerTeam = playerTeam;
            this.opponentTeam = new List<DuelMonsters>();

            List<DuelMonsters> poolCopy = new List<DuelMonsters>(opponentPool);
            Random rnd = new Random();

            while (this.opponentTeam.Count < 3 && poolCopy.Count > 0)
            {
                int randomIndex = rnd.Next(poolCopy.Count);
                this.opponentTeam.Add(poolCopy[randomIndex]);
                poolCopy.RemoveAt(randomIndex); 
            }

            SetupBattleScene();
            StartNewBattle();
        }



        private void SetupBattleScene()
        {
            pbPlayer = new PictureBox { SizeMode = PictureBoxSizeMode.StretchImage };
            pbOpponent = new PictureBox { SizeMode = PictureBoxSizeMode.StretchImage };

            lblVS = new Label
            {
                Font = new Font("Arial", 14, FontStyle.Bold),
                AutoSize = true
            };

            btnBattle = new Button
            {
                Text = "Battle!",
                Size = new Size(100, 30)
            };
            btnBattle.Click += (s, e) => SimulateBattle();

            this.Controls.Add(pbPlayer);
            this.Controls.Add(pbOpponent);
            this.Controls.Add(lblVS);
            this.Controls.Add(btnBattle);
        }

        private void StartNewBattle()
        {
            if (currentPlayerIndex >= playerTeam.Count)
            {
                MessageBox.Show("Your team has been eliminated. You lose!");
                this.Close();
                return;
            }
            if (currentOpponentIndex >= opponentTeam.Count)
            {
                MessageBox.Show("The opponent team has been eliminated. You win!");
                this.Close();
                return;
            }

            playerMonster = playerTeam[currentPlayerIndex];
            opponentMonster = opponentTeam[currentOpponentIndex];

            UpdateLayout();
        }

        private void UpdateLayout()
        {
            int gap = 50;
            int totalWidth = playerMonster.XSize + gap + opponentMonster.XSize;
            int startX = (this.ClientSize.Width - totalWidth) / 2;
            int pictureY = (this.ClientSize.Height - playerMonster.YSize) / 2;

            pbPlayer.Location = new Point(startX, pictureY);
            pbPlayer.Size = new Size(playerMonster.XSize, playerMonster.YSize);
            pbPlayer.Image = Image.FromFile(playerMonster.ImageFile);

            pbOpponent.Location = new Point(startX + playerMonster.XSize + gap, pictureY);
            pbOpponent.Size = new Size(opponentMonster.XSize, opponentMonster.YSize);
            pbOpponent.Image = Image.FromFile(opponentMonster.ImageFile);

            lblVS.Text = $"{playerMonster.Name}  VS  {opponentMonster.Name}";
            lblVS.Location = new Point((this.ClientSize.Width - lblVS.PreferredWidth) / 2, pictureY - 60);

            btnBattle.Location = new Point((this.ClientSize.Width - btnBattle.Width) / 2, pictureY + playerMonster.YSize + 20);
        }

        private void SimulateBattle()
        {
            int playerScore = playerMonster.Attack + playerMonster.Defense;
            int opponentScore = opponentMonster.Attack + opponentMonster.Defense;

            if (playerScore > opponentScore)
            {
                MessageBox.Show($"{playerMonster.Name} wins the battle!");
                currentOpponentIndex++; 
            }
            else if (opponentScore > playerScore)
            {
                MessageBox.Show($"{playerMonster.Name} loses the battle!");
                currentPlayerIndex++; 
            }
            else
            {
                MessageBox.Show("It's a tie! Both monsters die!");
                currentPlayerIndex++;   
                currentOpponentIndex++; 
            }

            StartNewBattle();
        }

    }
}
