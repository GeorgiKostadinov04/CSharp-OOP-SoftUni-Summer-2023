using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;

namespace BankLoan.Repositories
{
    public class LoanRepository : IRepository<ILoan>
    {
        private readonly List<ILoan> loanList;

        public LoanRepository()
        {
            loanList = new List<ILoan>();
        }
        public IReadOnlyCollection<ILoan> Models => loanList;


        public void AddModel(ILoan model)
        {
            loanList.Add(model);
        }

        public ILoan FirstModel(string name)
        {
            return Models.FirstOrDefault(l => l.GetType().Name == name);
        }

        public bool RemoveModel(ILoan model)
        {
            return loanList.Remove(model);
        }
    }
}
