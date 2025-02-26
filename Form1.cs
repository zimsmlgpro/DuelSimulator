using System.Text;

namespace DuelingMonsters
{
    public partial class Form1 : Form
    {
        private Bitmap MyImage;
        private List<DuelMonsters> duelMonsters = [];
        List<DuelMonsters> selectedMonster = new List<DuelMonsters>();
        public Form1()
        {
            InitializeComponent();
            InitializesPictures();

        }

        private void CreateMonsters()
        {
            duelMonsters = new List<DuelMonsters>
            {
                new DuelMonsters("Dark Magician", 2500, 2100, @"..\..\..\darkmagician.jpg", 149, 115),
                new DuelMonsters("Kuriboh", 300, 200, @"..\..\..\Kuriboh.jpg", 149, 115),
                new DuelMonsters("Elemental Hero Stratos", 1800, 300, @"..\..\..\stratos.jpg", 149, 115),
                new DuelMonsters("Sacred Fire King Garunix", 2700, 1700, @"..\..\..\sacred_fire_king_garunix_artwork_by_d_evil6661_dgeteqq-fullview.jpg", 149, 115),
                new DuelMonsters("ABC-Dragon Buster", 3000, 2800, @"..\..\..\abc.jpg", 149, 115),
                new DuelMonsters("Blue-Eyes White Dragon", 3000, 2500, @"..\..\..\blueeyes.jpg", 149, 115)
            };


        }
        private void InitializesPictures()
        {
            CreateMonsters();
            Tuple<int, int>[] positions = new Tuple<int, int>[]
            {
                Tuple.Create(12, 51),
                Tuple.Create(198, 51),
                Tuple.Create(393, 51),
                Tuple.Create(12, 184),
                Tuple.Create(198, 184),
                Tuple.Create(393, 184)
            };
            for (int i = 0; i < duelMonsters.Count && i < positions.Length; i++)
            {
                var monster = duelMonsters[i];
                var pos = positions[i];

                PictureBox pictureBox = new PictureBox
                {
                    Location = new Point(pos.Item1, pos.Item2),
                    Size = new Size(monster.XSize, monster.YSize),
                    Image = Image.FromFile(monster.ImageFile),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Tag = monster
                };

                pictureBox.Click += ChosenMonster;

                this.Controls.Add(pictureBox);
            }
        }

        private void ChosenMonster(object? sender, EventArgs e)
        {
            if (sender is not PictureBox { Tag: DuelMonsters monster } pictureBox) return;
            selectedMonster.Add(monster);
            MessageBox.Show($"{monster.Name} has been added to the team");
        }

        private void currentTeam_Click(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();

            foreach (var monster in selectedMonster)
            {
                builder.AppendLine(monster.Name);
            }

            MessageBox.Show(builder.ToString());
        }
    }
}
