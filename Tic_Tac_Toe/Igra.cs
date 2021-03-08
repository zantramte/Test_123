using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public class Igra
    {
        public static int Stevec = 0, stevko = 0;
        public static string skupaj = "";
        public static int  Zmagica_X = 0,  Zmagica_O = 0;
        public static List<Button> gumbi = new List<Button>();

        public static bool Zmaga_X(Panel p, Button sedaj)
        {

            foreach (Button gumb in p.Controls)
            {
                if (gumb.Location.X == sedaj.Location.X)
                {
                    gumbi.Add(gumb);
                }
            }


            foreach (Button gumb in gumbi)
            {
                skupaj = skupaj + gumb.Text;
            }


            if (skupaj == "XXX" || skupaj == "OOO")
            {
                foreach (Button gumb in gumbi)
                {
                    gumb.BackColor = Color.Orange;
                    gumb.ForeColor = Color.DarkRed;
                }

                return true;
            }

            else
            {
                return false;
            }
        }

        public static bool Zmaga_Y(Panel p, Button sedaj)
        {
            foreach (Button gumb in p.Controls)
            {
                if (gumb.Location.Y == sedaj.Location.Y)
                {
                    gumbi.Add(gumb);
                }
            }

            foreach (Button gumb in gumbi)
            {
                skupaj = skupaj + gumb.Text;
            }

            if (skupaj == "XXX" || skupaj == "OOO")
            {
                foreach (Button gumb in gumbi)
                {
                    gumb.BackColor = Color.Orange;
                    gumb.ForeColor = Color.DarkRed;
                }

                return true;
            }

            else
            {
                return false;
            }
        }

        public static Panel Pocisti(Panel polje)
        {
            foreach (Button gumb in polje.Controls)
            {
                gumb.Text = "";
                gumb.BackColor = Color.Gold;
            }

            return polje;
        }

        public static bool Preveri_Neodloceno(Panel polje)
        {
            foreach (Button gumb in polje.Controls)
            {
                if (gumb.Text != "")
                {
                    stevko++;
                }
            }

            if (stevko == polje.Controls.Count)
            {
                return true;
            }

            else
            {
                stevko = 0;
                return false;
            }
        }
    }
}
