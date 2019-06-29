
using Project.Models.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Project.Models.Services
{
    public class MapManagmentService : IMapManagmentService
    {
        public MapManagmentService(TouristContext dbContext)
        {
            _cityRepo = new CityRepository(dbContext);
            _attractionRepo = new AttractionRepository(dbContext);
            _routeRepo = new RouteRepository(dbContext);
        }

        /// <summary>
        /// Add new city.
        /// </summary>
        /// <param name="city"></param>
        public void AddCity(City city)
        {
            _cityRepo.AddCity(city);
        }

        /// <summary>
        /// Delete city by id.
        /// </summary>
        /// <param name="id"></param>
        public void DeleteCityById(Guid id)
        {
            _cityRepo.DeleteCityById(id);
        }

        /// <summary>
        /// Get list of cities.
        /// </summary>
        /// <returns> List of cities.</returns>
        public IList<string> GetCities()
        {
            return _cityRepo.GetCities().Select(c => c.Name).ToList();
        }

        /// <summary>
        /// Add attraction.
        /// </summary>
        /// <param name="attraction"></param>
        public void AddAttraction(Attraction attraction)
        {
            _attractionRepo.Add(attraction);
        }

        /// <summary>
        /// Delete attraction by id.
        /// </summary>
        /// <param name="id"></param>
        public void DeleteAttractionById(Guid id)
        {
            _attractionRepo.Delete(id);
        }

        /// <summary>
        /// Update attraction.
        /// </summary>
        /// <param name="attraction"></param>
        public void UpdateAttraction(Attraction attraction)
        {
            _attractionRepo.Update(attraction);
        }

        /// <summary>
        /// Gets all attraction by city id.
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns>List of attractions.</returns>
        public IList<Attraction> GetAllAttractionByCityId(Guid cityId)
        {
           return _attractionRepo.GetAll(cityId);
        }

        /// <summary>
        /// Add route.
        /// </summary>
        /// <param name="route"></param>
        public void AddRoute(Route route)
        {
            _routeRepo.Add(route);
        }

        /// <summary>
        /// Delte route.
        /// </summary>
        /// <param name="id"></param>
        public void DeleteRoute(Guid id)
        {
            _routeRepo.Delete(id);
        }

        /// <summary>
        /// Gets all routes by city id.
        /// </summary>
        /// <param name="idCity"></param>
        /// <returns>List of routes.</returns>
        public IList<Route> GetAllRoutesByCityId(Guid cityId)
        {
           return _routeRepo.GetAll(cityId);
        }

        private ICiryRepository _cityRepo = null;

        private IAttractionRepository _attractionRepo = null;

        private IRouteRepository _routeRepo = null;
    }
}