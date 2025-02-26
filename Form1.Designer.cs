namespace DuelingMonsters
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
            textBox1 = new TextBox();
            battle = new Button();
            currentTeam = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.BackColor = SystemColors.ActiveCaptionText;
            textBox1.ForeColor = SystemColors.Info;
            textBox1.Location = new Point(12, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(530, 23);
            textBox1.TabIndex = 99;
            textBox1.Text = "CHOOSE YOUR MONSTERS";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // battle
            // 
            battle.Location = new Point(215, 403);
            battle.Name = "battle";
            battle.Size = new Size(105, 23);
            battle.TabIndex = 7;
            battle.Text = "Start Battle?";
            battle.UseVisualStyleBackColor = true;
            // 
            // currentTeam
            // 
            currentTeam.Location = new Point(404, 403);
            currentTeam.Name = "currentTeam";
            currentTeam.Size = new Size(138, 23);
            currentTeam.TabIndex = 100;
            currentTeam.Text = "Current Team";
            currentTeam.UseVisualStyleBackColor = true;
            currentTeam.Click += currentTeam_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(554, 438);
            Controls.Add(currentTeam);
            Controls.Add(battle);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button battle;
        private Button currentTeam;
    }
}
