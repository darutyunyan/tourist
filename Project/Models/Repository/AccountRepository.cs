
namespace Project.Models.Repository
{
    public class AccountRepository : IAccountRepository
    {

        #region Constructor

        public AccountRepository()
        {
            _touristContext = new TouristContext();
        }

        #endregion

        #region Public action
        public void AddAccount(Account account)
        {
            
        }
        
        public void DeleteAccountByEmail(string email)
        {

        }

        public void UpdateAccount(Account account)
        {

        }

        public Account GetAccountByEmail(string email)
        {


            return new Account();
        }

        #endregion

        #region Private Field

        private TouristContext _touristContext;

        #endregion
    }
}