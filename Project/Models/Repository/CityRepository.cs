
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;

namespace Project.Models.Repository
{
    public class CityRepository : ICiryRepository
    {
        #region Constructor

        public CityRepository(TouristContext touristContext)
        {
            _touristContext = touristContext;
        }

        #endregion

        #region Public action

        public void AddCity(City city) // exception
        {
            Debug.Assert(city.Id != Guid.Empty);
            Debug.Assert(!string.IsNullOrEmpty(city.Name));

            this._touristContext.Cities.Add(city);
        }


        public void DeleteCityById(Guid id) // exception
        {
            Debug.Assert(id != Guid.Empty);

            City city = _touristContext.Cities.Where(a => a.Id == id).FirstOrDefault();

            this._touristContext.Cities.Remove(city);
            this._touristContext.SaveChanges();
        }

        #endregion

        #region Private Field

        private TouristContext _touristContext;

        #endregion
    }
}