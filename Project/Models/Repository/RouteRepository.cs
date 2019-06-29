
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;

namespace Project.Models.Repository
{
    public class RouteRepository : IRouteRepository
    {
        #region Constructor

        public RouteRepository(TouristContext touristContext)
        {
            _touristContext = touristContext;
        }

        #endregion

        #region Public action
        public void Add(Route route) // exception
        {
            Debug.Assert(route.Id != Guid.Empty);
            Debug.Assert(route.IdCity != Guid.Empty);
            Debug.Assert(!string.IsNullOrEmpty(route.Coordinates));

            this._touristContext.Routes.Add(route);
            this._touristContext.SaveChanges();
        }

        public void Delete(Guid id) // exception
        {
            Debug.Assert(id != Guid.Empty);

            Route route = _touristContext.Routes.Where(a => a.Id == id).FirstOrDefault();

            this._touristContext.Routes.Remove(route);
            this._touristContext.SaveChanges();
        }

        public IList<Route> GetAll(Guid idCity) // exception
        {
            Debug.Assert(idCity != Guid.Empty);

            return this._touristContext.Routes.Where(a => a.IdCity == idCity).ToList();
        }

        #endregion

        #region Private Field

        private TouristContext _touristContext;

        #endregion
    }
}