# erinle
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dwarf
{
    public partial class Form1 : Form
    {
        enum Position
        {
            Left, 
            Right,
            Down
        }
        private int _x;
        private int _y;
        private Position _objPosition;
        public Form1()
        {
            InitializeComponent();
            _x = 100;
            _y = 200;
            _objPosition = Position.Down;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           // e.Graphics.FillRectangle(Brushes.Aquamarine, _x, _y, 100, 100);
            e.Graphics.DrawImage(new Bitmap("Mushroom.JPG"), _x, _y, 64, 64);
        }

        private void timrMoving_Tick(object sender, EventArgs e)
        {
            if (_objPosition == Position.Right)
            {
                _x += 10;
               
            }
            else if (_objPosition == Position.Left)
            {
                _x -= 10;

            }
            else if (_objPosition == Position.Down)
            {
                _x += 0;

            }
            
            Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                _objPosition = Position.Left;
            }
            else if (e.KeyCode == Keys.Right)
            {
                _objPosition = Position.Right;
            }
            else if (e.KeyCode == Keys.Down)
            {
                _objPosition = Position.Down;
            }
            else if (e.KeyCode == Keys.Up)
            {
                _objPosition = Position.Down;
            }
            

        }
    }
}
