using Dapper;
using I3s.Tile;
using Npgsql;
using System;
using Wkx;

namespace pg2is3s.console
{
    class Program
    {
        static void Main(string[] args)
        {
            var slpk_output = "test.slpk";
            Console.WriteLine("Hello World!");

            var connectionString = "Host=localhost;Username=postgres;Password=postgres;Database=postgres;Port=5432";
            SqlMapper.AddTypeHandler(new GeometryTypeHandler());
            var conn = new NpgsqlConnection(connectionString);
            conn.Open();

            var table = "buildings_3857";
            var geoms = conn.Query<Geometry>($"select ST_AsBinary(geom) as geometry from {table}").AsList();
            Console.WriteLine("Number of geometries: " + geoms.Count);
            foreach(var geom in geoms)
            {
                var surface = (PolyhedralSurface)geom;
                Console.WriteLine("triangles:" + surface.Geometries.Count);

                // todo: Write Scene layer package file (only buildings as a start)
                // todo: write json files
                // todo: write bin files (use I3sWriter.WriteI3s)
                // sample code writing bin files:
                // var i3s_file = new I3s.Tile.I3s();
                // I3sWriter.WriteI3s(slpk_output, i3s_file);
                // i3s_file.FeatureVertices = vertices;
                // todo: zip it up to slpk
                // todo: verify it works in client viewer
            }
            conn.Close();
        }
    }
}
