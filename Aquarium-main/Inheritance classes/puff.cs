﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Forms;
using System.Drawing;

namespace HelloWorldWinForms
{
    [Serializable]
    internal class puff : fish
    {
        public const int _buy_puff = 50;
        public const int _sell_puff = 47;
        private static Random rand = new Random();
        public override void makeNoise()
        {
            SoundPlayer noise = new SoundPlayer(Properties.Resources.Shark_sound);
            noise.Play();
            noise.Dispose();
        }
        public puff() : base()
        {
            _spieces = 0;
        }
        public puff(int id) : base()
        {
            _id = id;
            _spieces = 0;
        }
        ~puff()
        {

        }
        public override void displayAnimal(PictureBox visual)
        {
            visual.Image = global::HelloWorldWinForms.Properties.Resources.puff;
            visual.InitialImage = global::HelloWorldWinForms.Properties.Resources.puff;
            visual.Size = new System.Drawing.Size(64, 64);
            visual.BackColor = System.Drawing.Color.Transparent;
            visual.Cursor = System.Windows.Forms.Cursors.Hand;
            visual.Location = new System.Drawing.Point((int)getX(), (int)getY());
            visual.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            visual.TabIndex = 13;
            visual.TabStop = false;
        }
        public override void updateLocation(bool changeDirection)
        {
            if (changeDirection)
                createDirection();
            if (_coordinates.X + _direction.X <= 130 || _coordinates.X + _direction.X >= 760 ||
                _coordinates.Y + _direction.Y <= 0 || _coordinates.Y + _direction.Y >= 470)
            {
                if (_coordinates.X + _direction.X <= 130 && _coordinates.X + _direction.X > 0 &&
                    _coordinates.Y + _direction.Y > 30 && _coordinates.Y + _direction.Y < 450)
                {
                    _coordinates += _direction;
                    return;
                }
                    _direction = -_direction;
            }
            _coordinates += _direction;
        }
        public override void createDirection()
        {
            _direction.X = rand.Next(0, 200) - 100;
            _direction.Y = rand.Next(0, 200) - 100;
            _direction.Normalize();
            _direction *= _speed;
        }
        public override bool isInside(int X, int Y)
        {
            return Math.Abs(X - _coordinates.X) <= 32 && Math.Abs(Y - _coordinates.Y) <= 32;
        }
        public override void updateStats()
        {
            if (_hunger - 3 <= 0 || _health - 2 <= 0 || _affection - 2 <= 0)
                _isAlive = false;
            else
            {
                _nextEgg++;
                _hunger -= 3;
                _affection -= 2;
                _health -= 2;
                if (_nextEgg == 3)
                {
                    if (_sex == false) // females only !!!
                        _eggs++;
                    _nextEgg = 0;
                }
            }
            
        }
    }
}
