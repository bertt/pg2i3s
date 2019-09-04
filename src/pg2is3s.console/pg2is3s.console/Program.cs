using Dapper;
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

            var table = "bertt.buildings_3857";
            var geoms = conn.Query<Geometry>($"select ST_AsBinary(geom) as geometry from {table}").AsList();
            Console.WriteLine("Number of geometries: " + geoms.Count);
            foreach(var geom in geoms)
            {
                var surface = (PolyhedralSurface)geom;
                Console.WriteLine("triangles:" + surface.Geometries.Count);

                // todo: Write Scene layer package file (only buildings as a start)
                // todo: write json files
                // todo: write bin files (use I3sWriter.WriteI3s)
                // todo: zip it up to slpk
                // todo: verify it works in client viewer
            }
            conn.Close();
        }
    }
}
