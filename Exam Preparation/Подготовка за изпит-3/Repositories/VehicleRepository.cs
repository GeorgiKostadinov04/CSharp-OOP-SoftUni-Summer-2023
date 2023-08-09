using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;

namespace EDriveRent.Repositories
{
    public class VehicleRepository : IRepository<IVehicle>
    {
        private readonly List<IVehicle> vehicles;

        public VehicleRepository()
        {
            this.vehicles = new List<IVehicle>();
        }
        public void AddModel(IVehicle model)
        {
            this.vehicles.Add(model);
        }

        public IVehicle FindById(string identifier)
        {
            return this.vehicles.FirstOrDefault(v => v.LicensePlateNumber == identifier);
        }

        public IReadOnlyCollection<IVehicle> GetAll()
        {
            return this.vehicles;
        }

        public bool RemoveById(string identifier)
        {
            return this.vehicles.Remove(FindById(identifier));
        }
    }
}
