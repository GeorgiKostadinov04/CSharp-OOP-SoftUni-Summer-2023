using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;

namespace EDriveRent.Repositories
{
    public class RouteRepository : IRepository<IRoute>
    {
        private readonly List<IRoute> routes;

        public RouteRepository()
        {
            this.routes = new List<IRoute>();
        }
        public void AddModel(IRoute model)
        {
            this.routes.Add(model);
        }

        public IRoute FindById(string identifier)
        {
            return this.routes.FirstOrDefault(r=> r.RouteId == int.Parse(identifier));
        }

        public IReadOnlyCollection<IRoute> GetAll()
        {
            return this.routes;
        }

        public bool RemoveById(string identifier)
        {
            return this.routes.Remove(FindById(identifier));
        }
    }
}
