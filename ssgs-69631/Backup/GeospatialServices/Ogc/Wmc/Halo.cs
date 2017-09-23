using System;
using System.Collections.Generic;
using System.Text;

namespace GeospatialServices.Ogc.Wmc
{
    public class Halo
    {
        private decimal m_Radius;

        public decimal Radius
        {
            get { return m_Radius; }
            set { m_Radius = value; }
        }
        private Fill m_Fill;

        public Fill Fill
        {
            get { return m_Fill; }
            set { m_Fill = value; }
        }
    }
}
