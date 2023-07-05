using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get { return length; }
            private set
            {
                if(value > 0)
                {
                    length = value;
                }
                else
                {
                    throw new ArgumentException($"{nameof(Length)} cannot be zero or negative.");
                }
            }
        }
        public double Width
        {
            get { return width; }
            private set
            {
                if (value > 0)
                {
                    width = value;
                }
                else
                {
                    throw new ArgumentException($"{nameof(Width)} cannot be zero or negative.");
                    
                }
            }
        }

        public double Height
        {
            get { return height; }
            private set
            {
                if (value > 0)
                {
                    height = value;
                }
                else
                {
                    throw new ArgumentException($"{nameof(Height)} cannot be zero or negative.");
                }
            }
        }

        public double SurfaceArea()
        {
            return 2 * Length * Width + LateralSurfaceArea();
        }

        public double LateralSurfaceArea()
        {
            return 2 * Length * Height + 2 * Width * Height;
        }

        public double Volume() 
        {
            return Width*Height*Length;
        }
    }
}
