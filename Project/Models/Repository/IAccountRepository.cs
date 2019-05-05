namespace Project.Models.Repository
{
    interface IAccountRepository
    {
        void AddAccount(Account account);

        void DeleteAccountByEmail(string email);

        void UpdateAccount(Account account);

        bool IsLogged(string email, string password);

        Account GetAccountByEmail(string email);
    }
}
