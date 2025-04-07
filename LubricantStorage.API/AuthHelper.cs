namespace LubricantStorage.API
{
    public class AuthHelper
    {
        public const string Key = "JWT:SecretKey";
        public const string Issuer = "JWT:Issuer";
        public const string Audience = "JWT:Audience";
        public const string RefreshTokenName = "1v34f.g3546c$rvtyuio`pk4658jhf";
        public static readonly DateTime ExpirationDateOfAccessToken = DateTime.Now.AddMinutes(60);
    }
}