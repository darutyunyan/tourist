using System;
using System.Collections.Generic;

namespace Project.Models.Repository
{
    interface IRouteRepository
    {
        void AddRoute(Route route);

        void DeleteRoute(Guid id);

        IList<Route> GetAllRoutesByCityId(Guid idCity);
    }
}
