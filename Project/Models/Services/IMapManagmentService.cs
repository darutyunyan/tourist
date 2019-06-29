
using System;
using System.Collections.Generic;

namespace Project.Models.Services
{
    interface IMapManagmentService
    {
        /// <summary>
        /// Add new city.
        /// </summary>
        /// <param name="city"></param>
        void AddCity(City city);

        /// <summary>
        /// Delete city by id.
        /// </summary>
        /// <param name="id"></param>
        void DeleteCityById(Guid id);

        /// <summary>
        /// Get list of cities.
        /// </summary>
        /// <returns> List of cities.</returns>
        IList<string> GetCities();

        /// <summary>
        /// Add attraction.
        /// </summary>
        /// <param name="attraction"></param>
        void AddAttraction(Attraction attraction);

        /// <summary>
        /// Delete attraction by id.
        /// </summary>
        /// <param name="id"></param>
        void DeleteAttractionById(Guid id);

        /// <summary>
        /// Update attraction.
        /// </summary>
        /// <param name="attraction"></param>
        void UpdateAttraction(Attraction attraction);

        /// <summary>
        /// Gets all attraction by city id.
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns>List of attractions.</returns>
        IList<Attraction> GetAllAttractionByCityId(Guid cityId);

        /// <summary>
        /// Add route.
        /// </summary>
        /// <param name="route"></param>
        void AddRoute(Route route);

        /// <summary>
        /// Delte route.
        /// </summary>
        /// <param name="id"></param>
        void DeleteRoute(Guid id);
        
        /// <summary>
        /// Gets all routes by city id.
        /// </summary>
        /// <param name="idCity"></param>
        /// <returns>List of routes.</returns>
        IList<Route> GetAllRoutesByCityId(Guid idCity);
    }
}