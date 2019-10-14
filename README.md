# pg2i3s

Tools for converting 3D geometries (like buildings) from PostGIS to I3S Scene Layer Package file.

## Disclaimer

At the moment, this project really does nothing. Developers are welcome to contribute and get this project started.

## I3S Specs

Spec: https://github.com/Esri/i3s-spec/blob/master/format/Indexed%203d%20Scene%20Layer%20Format%20Specification.md#_6_7

OGC Indexed 3d Scene Layer (I3S) and Scene Layer Package Format Specification: http://docs.opengeospatial.org/cs/17-014r5/17-014r5.html

## Getting started


Start a POSTGIS database 

```
$ docker run --name some-postgis -e POSTGRES_PASSWORD=postgres -p 5432:5432 mdillon/postgis
```

Create table according to the SQL in sample_Data/buildings.sql:

```
$ psql -h localhost -U postgres -f buildings.sql
```

The testtable contains 100 polyhedredalsurface geometries in Amsterdam consisting of triangles:

```
$  psql -U postgres

Password for user postgres:
psql (11.5 (Ubuntu 11.5-3.pgdg16.04+1), server 11.2 (Debian 11.2-1.pgdg90+1))
Type "help" for help.

postgres=# select count(*) from public.buildings_3857;
 count
-------
   100
(1 row)

postgres=#
```

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