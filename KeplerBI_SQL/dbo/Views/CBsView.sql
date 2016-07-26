CREATE VIEW [dbo].[CBsView]
	AS 
	Select  ID,
		Name,
		'Planet' as [Type],
		MassInEarthmasses,
		MassInEarthMoons, 
		GravityInMeterPerSecSec,
		EquatorialdiameterInKm,
		PolarDiameterInKm,
		MeanSurfaceTemp,		
		HasRings,
		OrbitalspeedInKmPerSec,
		OrbitalradiusInAU,	
		MoonCount	 
	FROM dbo.PlanetsView
Union
Select  ID,
		Name,
		'Moon' as [Type],
		MassInEarthmasses,
		MassInEarthMoons, 
		GravityInMeterPerSecSec,
		EquatorialdiameterInKm,
		PolarDiameterInKm,
		MeanSurfaceTemp,		
		HasRings,
		OrbitalspeedInKmPerSec,
		OrbitalradiusInAU,	
		0 as MoonCount	 
	FROM dbo.MoonsView
Union
Select  ID,
		Name,
		'Asteroid' as [Type],
		MassInEarthmasses,
		MassInEarthMoons, 
		GravityInMeterPerSecSec,
		EquatorialdiameterInKm,
		PolarDiameterInKm,
		MeanSurfaceTemp,		
		HasRings,
		OrbitalspeedInKmPerSec,
		OrbitalradiusInAU,	
		MoonCount	 
	FROM dbo.AsteroidsView

