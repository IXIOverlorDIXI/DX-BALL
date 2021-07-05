using System.Collections.Generic;
using System.Net.Security;
using System.Reflection.Metadata.Ecma335;

namespace Core
{
    public class Platform
    {
        public double XPosition
        {
            get => _XPosition;
            set
            {
                if (value < 0 || (value + Width) > Level_Width)
                {
                    
                }
                else
                {
                    _XPosition = value;
                }
            }
        }

        private double _XPosition;

        public double YPosition { get; set; }

        public double Width
        {
            get => _width;
            set
            {
                if (value <= 50 || value >= Level_Width)
                {
                }
                else
                {
                    _width = value;
                }
            }
        }

        private double _width;

        public bool isElectric { get; set; }
        
        public double Level_Width
        {
            get => _Level_Width;
            set
            {
                if (value < 600)
                {
                }
                else
                {
                    _Level_Width = value;
                }
            }
        }

        private double _Level_Width;

        public Platform(double _levelWidth, double _width)
        {
            Level_Width = _levelWidth;
            Width = _width;
            XPosition = (Level_Width - Width) / 2;
        }
    }
}