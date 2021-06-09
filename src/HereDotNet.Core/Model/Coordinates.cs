using System;
using System.Collections.Generic;
using System.Text;

namespace HereDotNet.Core.Model
{

    //public readonly struct Coordinates1
    //{
    //    public double Lat { get;  }
    //    public double Lng { get;  }
    //    public Coordinates1(double latitude, double longitude)
    //    {
    //        Lat = latitude;
    //        Lng = longitude;
    //       // return ;
    //    }
    //}

    public class Coordinates
    {
        public double Lat { get; set; } 
        public double Lng { get; set; }

        public Coordinates()
        {

        }

        public Coordinates(double latitude, double longitude)
        {
            Lat = latitude;
            Lng = longitude;
        }

        public override string ToString()
        {
            return $"{Lat},{Lng}";
        }
    }
}
