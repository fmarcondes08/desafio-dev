using DesafioDevBackEnd.Domain.Entities;
using DesafioDevBackEnd.Domain.Interfaces.Repositories;
using DesafioDevBackEnd.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDevBackEnd.Service
{
    public class TransactionService : ITransactionService
    {
        private ITransactionRepository _repository;
        private ITransactionTypeService _serviceTransaction;
        public TransactionService(ITransactionRepository repository, ITransactionTypeService serviceTransaction)
        {
            _repository = repository;
            _serviceTransaction = serviceTransaction;
        }

        public async Task<List<Store>> ImportFile(List<byte[]> fileBytes)
        {
            var transactionsList = new List<Transaction>();

            foreach (var itemArchive in fileBytes)
            {
                transactionsList = BytesToArchive(itemArchive);
            }

            await _repository.AddRange(transactionsList);
            var addedItems = await _repository.GetTransactionList(transactionsList);
            var groupItems = addedItems.GroupBy(x => x.StoreName).ToList();
            var result = new List<Store>();

            foreach (var item in groupItems)
            {
                var store = new Store();
                store.Name = item.Key.Trim();
                store.Transactions = item.ToList();
                store.CurrentBalance = 0;

                var returnSearch = await _repository.GetTransactionByStore(item.Key);

                var transactionsGroup = returnSearch.GroupBy(x => x.TransactionType.Signal);

                foreach (var group in transactionsGroup)
                {
                    decimal sum = group.Sum(x => x.Value);

                    if (group.Key.Equals("+"))
                    {
                        store.CurrentBalance += sum;
                    }
                    else
                    {
                        store.CurrentBalance -= sum;
                    }
                }

                result.Add(store);
            }

            return result;
        }

        #region Private Methods
        private List<Transaction> BytesToArchive(byte[] fileBytes)
        {
            var transactionsList = new List<Transaction>();

            var stream = new MemoryStream((byte[])fileBytes);
            var streamFile = new StreamReader(stream);

            string line;
            while ((line = streamFile.ReadLine()) != null)
            {
                var transaction = new Transaction();

                string type = line.Substring(0, 1);
                string dateTime = line.Substring(1, 4) + "/" + line.Substring(5, 2) + "/" + line.Substring(7, 2) + " " +
                                  line.Substring(42, 2) + ":" + line.Substring(44, 2) + ":" + line.Substring(46, 2);
                string value = line.Substring(9, 10);
                string CPF = line.Substring(19, 11);
                string Card = line.Substring(30, 12);
                string StoreOwner = line.Substring(48, 14);
                string StoreName = line.Substring(62, 18);

                var search = _serviceTransaction.GetTransactionTypeByType(type);

                if (search != null)
                {
                   transaction.TransactionTypeId = search.Id;
                }

                transaction.DateTime = Convert.ToDateTime(dateTime);
                transaction.Value = Convert.ToDecimal(value) / 100;
                transaction.CPF = CPF;
                transaction.Card = Card;
                transaction.StoreOwner = StoreOwner.Trim();
                transaction.StoreName = StoreName.Trim();
                transactionsList.Add(transaction);
            }

            return transactionsList;
        }
        #endregion
    }
}
