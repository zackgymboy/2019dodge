using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2019dodge
{
    public partial class frmDodge : Form
    {
        Graphics g; //declare a graphics object called g
        Planet[] planet = new Planet[7];
        Random yspeed = new Random();


        public frmDodge()
        {
            InitializeComponent();
            for (int i = 0; i < 7; i++)
            {
                int x = 10 + (i * 75);
                planet[i] = new Planet(x);
            }

        }

        private void frmDodge_Load(object sender, EventArgs e)
        {

        }

        private void pnlGame_Paint(object sender, PaintEventArgs e)
        {
            //get the graphics used to paint on the panel control
            g = e.Graphics;
            for (int i = 0; i < 7; i++)
            {
                // generate a random number from 5 to 20 and put it in rndmspeed
                int rndmspeed = yspeed.Next(5, 20);
                planet[i].y += rndmspeed;

                //call the Planet class's drawPlanet method to draw the images
                planet[i].drawPlanet(g);
            }
        }

        private void tmrPlanet_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 7; i++)
            {
                planet[i].movePlanet();
            }
            PnlGame.Invalidate();//makes the paint event fire to redraw the panel
        }
    }
}
