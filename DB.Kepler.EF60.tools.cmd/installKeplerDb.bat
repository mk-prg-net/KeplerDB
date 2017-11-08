REM Martin Korneffel 2017
REM Installation der KeplerDB
@echo off
Title Installation der KeplerDB
DB.Kepler.EF60.tools.cmd serverName .\sql2016dev databaseName KeplerDbTest createDB initDB createSolarSysPlanets asteroidsCsv .\Asteroids.csv
