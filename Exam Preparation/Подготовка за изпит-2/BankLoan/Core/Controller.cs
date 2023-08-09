using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankLoan.Core.Contracts;
using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Repositories;
using BankLoan.Repositories.Contracts;
using BankLoan.Utilities.Messages;

namespace BankLoan.Core
{
    public class Controller : IController
    {
        private IRepository<ILoan> loans;
        private IRepository<IBank> banks;

        public Controller() 
        {
            loans = new LoanRepository();
            banks = new BankRepository();
        }
        public string AddBank(string bankTypeName, string name)
        {
            if(bankTypeName != nameof(BranchBank) && bankTypeName != nameof(CentralBank))
            {
                throw new ArgumentException(ExceptionMessages.BankTypeInvalid);
            }
            IBank bank;
            if(bankTypeName == nameof(BranchBank))
            {
                bank = new BranchBank(name);
            }
            else
            {
                bank = new CentralBank(name);
            }

            banks.AddModel(bank);
            return string.Format(OutputMessages.BankSuccessfullyAdded, bankTypeName);
        }

        public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
        {
            if(clientTypeName != nameof(Student) && clientTypeName != nameof(Adult))
            {
                throw new ArgumentException(ExceptionMessages.ClientTypeInvalid);
            }


            var bank = banks.FirstModel(bankName);

            if(clientTypeName == nameof(Student) && bank.GetType().Name == nameof(CentralBank))
            {
                return OutputMessages.UnsuitableBank;
            }
            else if(clientTypeName == nameof(Adult) && bank.GetType().Name == nameof(BranchBank))
            {
                return OutputMessages.UnsuitableBank;
            }
            else
            {
                IClient client;
                if(clientTypeName == nameof(Student))
                {
                    client = new Student(clientName, id, income);
                }
                else
                {
                    client = new Adult(clientName, id, income);
                }
                bank.AddClient(client);
                return string.Format(OutputMessages.ClientAddedSuccessfully, clientTypeName, bankName);
            }
        }

        public string AddLoan(string loanTypeName)
        {
            if(loanTypeName != nameof(StudentLoan) && loanTypeName != nameof(MortgageLoan))
            {
                throw new ArgumentException(ExceptionMessages.LoanTypeInvalid);
            }
            ILoan loan;

            if(loanTypeName == nameof(StudentLoan))
            {
                loan = new StudentLoan();
            }
            else
            {
                loan = new MortgageLoan();
            }
            loans.AddModel(loan);
            return string.Format(OutputMessages.LoanSuccessfullyAdded, loanTypeName);
        }

        public string FinalCalculation(string bankName)
        {
            var bank = banks.FirstModel(bankName);

            double sum = 0;

            foreach(var loan in bank.Loans)
            {
                sum += loan.Amount;
            }

            foreach(var client in bank.Clients)
            {
                sum += client.Income;
            }

            return $"The funds of the bank {bankName} are {sum:f2}.";

        }

        public string ReturnLoan(string bankName, string loanTypeName)
        {
            var loan = loans.FirstModel(loanTypeName);
            
            if(loan == null)
            {
                return string.Format(ExceptionMessages.MissingLoanFromType, loanTypeName);
            }
            

            banks.FirstModel(bankName).AddLoan(loan);
            loans.RemoveModel(loan);
            return string.Format(OutputMessages.LoanReturnedSuccessfully, loanTypeName, bankName);
        }

        public string Statistics()
        {
            StringBuilder sb = new StringBuilder();

            foreach(var bank in banks.Models)
            {
                sb.AppendLine(bank.GetStatistics());
                
            }

            return sb.ToString().TrimEnd();
        }
    }
}
