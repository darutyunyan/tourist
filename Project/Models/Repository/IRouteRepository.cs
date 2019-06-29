using System;
using System.Collections.Generic;

namespace Project.Models.Repository
{
    interface IRouteRepository
    {
        void Add(Route route);

        void Delete(Guid id);

        IList<Route> GetAll(Guid idCity);
    }
}
