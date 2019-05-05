using System;
using System.Collections.Generic;

namespace Project.Models.Repository
{
    interface IAttractionRepository
    {
        void AddAttraction(Attraction attraction);

        void DeleteAttactionById(Guid id);

        void UpdateAttraction(Attraction attraction);

        IList<Attraction> GetAllAttractionsByCity(Guid idCity);
    }
}
