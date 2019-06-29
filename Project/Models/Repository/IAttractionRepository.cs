using System;
using System.Collections.Generic;

namespace Project.Models.Repository
{
    interface IAttractionRepository
    {
        void Add(Attraction attraction);

        void Delete(Guid id);

        void Update(Attraction attraction);

        IList<Attraction> GetAll(Guid idCity);
    }
}
