
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;

namespace Project.Models.Repository
{
    public class AttractionRepository : IAttractionRepository
    {

        #region Constructor

        public AttractionRepository(TouristContext touristContext)
        {
            _touristContext = touristContext;
        }

        #endregion

        #region Public action
        public void AddAttraction(Attraction attraction) // exception
        {
            Debug.Assert(attraction.Id != Guid.Empty);
            Debug.Assert(attraction.IdCity != Guid.Empty);
            Debug.Assert(!string.IsNullOrEmpty(attraction.Name));
            Debug.Assert(!string.IsNullOrEmpty(attraction.Description));
            Debug.Assert(!string.IsNullOrEmpty(attraction.Coordinates));

            this._touristContext.Attractions.Add(attraction);
        }


        public void DeleteAttactionById(Guid id) // exception
        {
            Debug.Assert(id != Guid.Empty);

            Attraction attraction = _touristContext.Attractions.Where(a => a.Id == id).FirstOrDefault();

            this._touristContext.Attractions.Remove(attraction);
            this._touristContext.SaveChanges();
        }

        public void UpdateAttraction(Attraction attraction) // exception
        {
            Debug.Assert(attraction.Id != Guid.Empty);
            Debug.Assert(attraction.IdCity != Guid.Empty);
            Debug.Assert(!string.IsNullOrEmpty(attraction.Name));
            Debug.Assert(!string.IsNullOrEmpty(attraction.Description));
            Debug.Assert(!string.IsNullOrEmpty(attraction.Coordinates));

            this._touristContext.Entry(attraction).State = EntityState.Modified;
            this._touristContext.SaveChanges();
        }

        public IList<Attraction> GetAllAttractionsByCity(Guid idCity) // exception
        {
            Debug.Assert(idCity != Guid.Empty);

            return this._touristContext.Attractions.Where(a => a.IdCity == idCity).ToList();
        }

        #endregion

        #region Private Field

        private TouristContext _touristContext;

        #endregion
    }
}