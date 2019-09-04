# pg2i3s

Tools for converting 3D geometries (like buildings) from PostGIS to I3S Scene Layer Package file.

## Disclaimer

At the moment, this project really does nothing. Developers are welcome to contribute and get this project started.

## I3S Specs

Spec: https://github.com/Esri/i3s-spec/blob/master/format/Indexed%203d%20Scene%20Layer%20Format%20Specification.md#_6_7

OGC Indexed 3d Scene Layer (I3S) and Scene Layer Package Format Specification: http://docs.opengeospatial.org/cs/17-014r5/17-014r5.html

## Getting started

Start a POSTGIS database and create table according to the SQL in sample_Data/buildings.sql.

The testtable contains 100 polyhedredalsurface geometries in Amsterdam consisting of triangles.

Now change the connection string in Program.cs and get the project running.

## Docker

Docker image or other releases not there yet.

## Work priorities

First milestone is to read 3D building geometries from database and produce a slpk file thats usable in one of the 
existing (Javascript) clients for visualization.  

## Dependencies

- i3s-tile-cs: For reading/writing binary i3s files https://github.com/bertt/i3s-tile-cs

- Dapper: For micro-ORM https://github.com/StackExchange/Dapper

- Npgsql: For PostgreSQL database access https://github.com/npgsql/npgsql

- Wkx: For handling geometries https://github.com/cschwarz/wkx-sharp

- CommandLineParser: For handling command line options: https://github.com/commandlineparser/commandline