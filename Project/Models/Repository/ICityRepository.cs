using System;
using System.Collections.Generic;

namespace Project.Models.Repository
{
    interface ICiryRepository
    {
        void AddCity(City city);

        void DeleteCityById(Guid id);
    }
}
