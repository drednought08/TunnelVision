using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TunnelVision;

namespace Dev_LocationMaker
{
    public partial class Form1 : Form
    {
        int xPos = 0;
        int yPos = 0;
        //Point clickPoint = new Point();

        //======================================================================================

        public Form1()
        {
            InitializeComponent();
            LocationMakerInstance.maker.MarkLocations(Graphics.FromImage(displayedMap.Image));
        }

        //======================================================================================

        private void displayedMap_MouseClick(object sender, MouseEventArgs e)
        {
            xPos = e.X;
            yPos = e.Y;

            //MessageBox.Show("X = " + xPos + "     Y = "  + yPos);   //Debug


            LocationMakerInstance.maker.CreateLocation(xPos, yPos);
            displayedMap.Refresh();
        }

        //======================================================================================

        private void displayedMap_Paint(object sender, PaintEventArgs e)
        {
            LocationMakerInstance.maker.MarkLocations(e.Graphics);








            /*
            //Graphics g1 = this.CreateGraphics();
            Graphics g = Graphics.FromImage(displayedMap.Image);
            Pen locationPen = new Pen(Color.Red, 10);

            Point clickPoint = new Point(xPos, yPos);
            Point upLeft = new Point(clickPoint.X - 5, clickPoint.Y - 5);
            Point downRight = new Point(clickPoint.X + 5, clickPoint.Y + 5);
            Point downLeft = new Point(clickPoint.X - 5, clickPoint.Y + 5);
            Point upRight = new Point(clickPoint.X + 5, clickPoint.Y - 5);

            g.DrawLine(locationPen, upLeft, downRight);
            g.DrawLine(locationPen, downLeft, upRight);
            g.Save();
            //locationPen.Dispose();
            //g.Dispose();
            //displayedMap.Invalidate();
            */
        }

        //======================================================================================

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //======================================================================================

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("This will delete all stored Locations. Are you sure you want to proceed?", 
                "Confirm Deletion", MessageBoxButtons.YesNo);

            if (result1 == DialogResult.Yes)
            {
                DialogResult result2 = MessageBox.Show("Are you REALLY sure?",
                "Confirm Deletion", MessageBoxButtons.YesNo);

                if (result2 == DialogResult.Yes)
                {
                    LocationManagerInstance.manager.ClearLocationList();
                    displayedMap.Refresh();
                    MessageBox.Show("All Locations deleted.");
                }
            }
        }
    }
}
