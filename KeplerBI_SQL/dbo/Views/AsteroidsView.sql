CREATE VIEW [dbo].[AsteroidsView]
	AS SELECT 
		CB.ID as ID,
		CB.Name as Name,
		CB.MassInEarthmasses as MassInEarthmasses,
		CB.MassInEarthmasses * dbo.Earthmass() / dbo.EarthMoonMass() as MassInEarthMoons, 
		CB.GravityInMeterPerSec as GravityInMeterPerSecSec,
		CB.EquatorialDiameterInKilometer as EquatorialdiameterInKm,
		CB.PolarDiameterInKilometer as PolarDiameterInKm,
		CB.MeanSurfaceTemp as MeanSurfaceTemp,		
		0 as HasRings,
		POrb.MeanVelocitiOfCirculationInKmPerSec as OrbitalspeedInKmPerSec,
		POrb.SemiMajorAxisInKilometer * 1000.0 / dbo.AU() as OrbitalradiusInAU,	
		(Select COUNT(*) from dbo.Orbits as Orb where Orb.CentralBodyId = CB.ID) as MoonCount	 
	FROM dbo.Asteroids as P Join dbo.CelestialBodyBases as CB on P.ID = CB.ID
	Join dbo.CelesticalBodyTypeDescriptors as CBDescr on CB.[Type] = CBDescr.[Type]
	Join dbo.Orbits as POrb on CB.ID = POrb.SatelliteId
