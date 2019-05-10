
using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;

namespace Project.Models.Repository
{
    public class AccountRepository : IAccountRepository
    {
        #region Constructor

        public AccountRepository(TouristContext touristContext)
        {
            _touristContext = touristContext;
        }

        #endregion

        #region Public action
        public void AddAccount(Account account) // exception
        {
            Debug.Assert(account.Id != Guid.Empty);
            Debug.Assert(!string.IsNullOrEmpty(account.Email));
            Debug.Assert(!string.IsNullOrEmpty(account.FirstName));
            Debug.Assert(!string.IsNullOrEmpty(account.LastName));
            Debug.Assert(!string.IsNullOrEmpty(account.Password));
            Debug.Assert(!string.IsNullOrEmpty(account.Country));

            this._touristContext.Accounts.Add(account);
            this._touristContext.SaveChanges();
        }
        
        public void DeleteAccountByEmail(string email) // exception
        {
            Debug.Assert(!string.IsNullOrEmpty(email));

            Account account = _touristContext.Accounts.Where(a=>a.Email == email).FirstOrDefault();

            this._touristContext.Accounts.Remove(account);
            this._touristContext.SaveChanges();
        }

        public bool IsLogged(string email, string password)
        {
            Debug.Assert(!string.IsNullOrEmpty(email));
            Debug.Assert(!string.IsNullOrEmpty(password));

            Account account = this._touristContext.Accounts.Where(a => a.Email == email && a.Password == password).FirstOrDefault();

            return (account != null) ? true : false;
        }

        public void UpdateAccount(Account account) // exception
        {
            Debug.Assert(account.Id != Guid.Empty);
            Debug.Assert(!string.IsNullOrEmpty(account.Email));
            Debug.Assert(!string.IsNullOrEmpty(account.FirstName));
            Debug.Assert(!string.IsNullOrEmpty(account.LastName));
            Debug.Assert(!string.IsNullOrEmpty(account.Password));
            Debug.Assert(!string.IsNullOrEmpty(account.Country));

            this._touristContext.Entry(account).State = EntityState.Modified;
            this._touristContext.SaveChanges();
        }

        public Account GetAccountByEmail(string email) // exception
        {
            Debug.Assert(!string.IsNullOrEmpty(email));

            return this._touristContext.Accounts.Where(a => a.Email == email).FirstOrDefault();
        }

        #endregion

        #region Private Field

        private TouristContext _touristContext;

        #endregion
    }
}