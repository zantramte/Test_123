using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        WindowsMediaPlayer player_2 = new WindowsMediaPlayer();

        public Form1()
        {
            InitializeComponent();
            player_2.settings.setMode("loop", true);
            player_2.URL = "super.mp3";
        }

        public void Klici_konec()
        {
            switch (Igra.skupaj[0])
            {
                case 'X':
                    Igra.Zmagica_X++;
                    label3.Text = Convert.ToString(Igra.Zmagica_X);
                    player.URL = "happy.wav";
                    DialogResult d = MessageBox.Show("BRAVO!!! Sladka zmaga za X! Bi poskusil/a še enkrat?", "Sonček sporoča", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (d == DialogResult.Yes)
                    {
                        Igra.Stevec = 1;
                        Igra.skupaj = "";
                        Igra.Pocisti(panel1);
                    }

                    else
                    {
                        Application.Exit();
                    }
                    break;

                case 'O':
                    Igra.Zmagica_O++;
                    label4.Text = Convert.ToString(Igra.Zmagica_O);
                    player.URL = "happy.wav";
                    DialogResult dd = MessageBox.Show("BRAVO!!! Sladka zmaga za O! Bi poskusil/a še enkrat?", "Sonček sporoča", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dd == DialogResult.Yes)
                    {
                        Igra.Stevec = 0;
                        Igra.skupaj = "";
                        Igra.Pocisti(panel1);
                    }

                    else
                    {
                        Application.Exit();
                    }
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button polje = sender as Button;
            Igra.Stevec++;
            player.URL = "splash.wav";

            if (polje.Text == "")
            {
                if (Igra.Stevec % 2 != 0)
                {
                    polje.Text = "X";
                    polje.ForeColor = Color.Black;
                    Igra.skupaj = "";
                    Igra.gumbi.Clear();
                    label6.Text = "O";

                    if (Igra.Zmaga_X(panel1, polje) == true)
                    {
                        Klici_konec();
                        label6.Text = "X";
                    }

                    else
                    {
                        Igra.skupaj = "";
                        Igra.gumbi.Clear();

                        if (Igra.Zmaga_Y(panel1, polje) == true)
                        {
                            Klici_konec();
                            label6.Text = "X";
                        }

                        else
                        {
                            if (Igra.Preveri_Neodloceno(panel1) == true)
                            {
                                player.URL = "piano.wav";
                                DialogResult d = MessageBox.Show("NEODLOČENO! Bi poskusil/a še enkrat?", "Sonček sporoča", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (d == DialogResult.Yes)
                                {
                                    Igra.Stevec = 1;
                                    Igra.skupaj = "";
                                    Igra.Pocisti(panel1);
                                }

                                else
                                {
                                    Application.Exit();
                                }
                            }
                        }
                    }
                }

                else if (Igra.Stevec % 2 == 0)
                {
                    polje.Text = "O";
                    polje.ForeColor = Color.Black;
                    Igra.skupaj = "";
                    Igra.gumbi.Clear();
                    label6.Text = "X";

                    if (Igra.Zmaga_X(panel1, polje) == true)
                    {
                        Klici_konec();
                        label6.Text = "X";
                    }

                    else
                    {
                        Igra.skupaj = "";
                        Igra.gumbi.Clear();

                        if (Igra.Zmaga_Y(panel1, polje) == true)
                        {
                            Klici_konec();
                            label6.Text = "X";
                        }

                        else
                        {
                            if (Igra.Preveri_Neodloceno(panel1) == true)
                            {
                                player.URL = "piano.wav";
                                DialogResult d = MessageBox.Show("NEODLOČENO! Bi poskusil/a še enkrat?", "Sonček sporoča", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (d == DialogResult.Yes)
                                {
                                    Igra.Stevec = 1;
                                    Igra.skupaj = "";
                                    Igra.Pocisti(panel1);
                                }

                                else
                                {
                                    Application.Exit();
                                }
                            }
                        }
                    }
                }
            }

            else
            {
                MessageBox.Show("Polje je že zasedeno!", "Sonček sporoča", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            Button polje = sender as Button;
            polje.Size = new Size(93, 84);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            Button polje = sender as Button;
            polje.Size = new Size(89, 80);
        }
    }
}
