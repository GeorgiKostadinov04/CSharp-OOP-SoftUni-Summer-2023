using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankLoan.Models.Contracts;
using BankLoan.Repositories;
using BankLoan.Repositories.Contracts;
using BankLoan.Utilities.Messages;

namespace BankLoan.Models
{
    public abstract class Bank : IBank
    {
        private string name;
        private int capacity;
        private IRepository<ILoan> loans;
        private readonly List<IClient> clients;

        protected Bank(string name, int capacity)
        {
            Name = name;
            this.capacity = capacity;
            this.loans = new LoanRepository();
            this.clients = new List<IClient>();
        }

        public string Name
        {
            get => name; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BankNameNullOrWhiteSpace);
                }
                name = value;
            }
        }

        public int Capacity { get => capacity; }

        public IReadOnlyCollection<ILoan> Loans => loans.Models;

        public IReadOnlyCollection<IClient> Clients => clients;

        public void AddClient(IClient Client)
        {
            if(clients.Count >= Capacity)
            {
                throw new ArgumentException("Not enough capacity for this client.");
            }
            clients.Add(Client);
        }

        public void AddLoan(ILoan loan)
        {
            this.loans.AddModel(loan);
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {Name}, Type: {this.GetType().Name}");
            sb.Append("Clients: ");
            

            if(clients.Count == 0)
            {
                sb.Append("none ");
            }
            else
            {
                List<string> names = new List<string>();

                foreach (var client in clients)
                {
                    names.Add(client.Name);
                }
                    sb.Append(string.Join(", ", names));
                sb.Append(" ");
            }
            sb.AppendLine();
            sb.AppendLine($"Loans: {loans.Models.Count}, Sum of Rates: {SumRates()}");

            return sb.ToString().TrimEnd();


        }

        public void RemoveClient(IClient Client)
        {
            clients.Remove(Client);
        }

        public double SumRates()
        {
            double sum = 0;

            foreach(var loan in Loans)
            {
                sum += loan.InterestRate;
            }

            return sum;
        }
    }
}
