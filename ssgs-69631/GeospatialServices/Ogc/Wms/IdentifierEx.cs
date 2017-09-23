using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace GeospatialServices.Ogc.Wms
{
    public partial class Identifier: IEqualityComparer
    {
        #region IEqualityComparer Members

        bool IEqualityComparer.Equals(object x, object y)
        {
            Identifier x1 = x as Identifier;
            Identifier y1 = y as Identifier;
 
            if (x1 == null || y1 == null)
            {
                return false;
            }
            else
            {
                return (x1.Authority == y1.Authority && x1.Value == y1.Value); 
            }
        }

        int IEqualityComparer.GetHashCode(object obj)
        {
            return obj.GetHashCode(); 
        }

        #endregion
    }
}
