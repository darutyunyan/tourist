namespace Project.Models.Repository
{
    interface IAccountRepository
    {
        void AddAccount(Account account);

        void DeleteAccountByEmail(string email);

        void UpdateAccount(Account account);

        Account GetAccountByEmail(string email);
    }
}
