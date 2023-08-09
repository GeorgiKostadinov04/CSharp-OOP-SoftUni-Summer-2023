using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;

namespace EDriveRent.Repositories
{
    public class UserRepository : IRepository<IUser>
    {
        private readonly List<IUser> users;

        public UserRepository()
        {
            this.users = new List<IUser>();
        }
        public void AddModel(IUser model)
        {
            this.users.Add(model);
        }

        public IUser FindById(string identifier)
        {
            return this.users.FirstOrDefault(u => u.DrivingLicenseNumber == identifier);
        }

        public IReadOnlyCollection<IUser> GetAll()
        {
            return this.users;
        }

        public bool RemoveById(string identifier)
        {
             return this.users.Remove(FindById(identifier));
        }
    }
}
