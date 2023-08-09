﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;

namespace BankLoan.Repositories
{
    public class BankRepository : IRepository<IBank>
    {
        private readonly List<IBank> banks;

        public BankRepository()
        {
            banks = new List<IBank>();
        }
        public IReadOnlyCollection<IBank> Models => banks;

        public void AddModel(IBank model)
        {
            banks.Add(model);
        }

        public IBank FirstModel(string name)
        {
            return Models.FirstOrDefault(x => x.Name == name);
        }

        public bool RemoveModel(IBank model)
        {
            return banks.Remove(model);
        }
    }
}
