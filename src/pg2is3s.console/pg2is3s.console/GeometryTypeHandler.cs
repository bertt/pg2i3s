using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Wkx;

namespace pg2is3s.console
{

    public class GeometryTypeHandler : SqlMapper.TypeHandler<Geometry>
    {
        public override Geometry Parse(object value)
        {
            if (value == null)
                return null;

            var stream = (byte[])value;
            var g = Geometry.Deserialize<WkbSerializer>(stream);
            return g;
        }

        public override void SetValue(IDbDataParameter parameter, Geometry value)
        {
            parameter.Value = value;
        }
    }
}
