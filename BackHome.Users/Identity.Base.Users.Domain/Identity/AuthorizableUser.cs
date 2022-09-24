namespace Identity.Base.Users.Domain.Identity
{
    public class AuthorizableUser
    {
        private static int Max_Failed_Access;

        private string _email;
        private string _password;

        private int _failedAccessNumber;

        private static bool _lockEnabled;
        private DateTime _lockExpirationDate;

        public AuthorizableUser(string email, string password)
        {
            _email = email;
            _password = password;
        }

    }
}