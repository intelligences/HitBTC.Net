namespace HitBTC.Net.Requests
{
    internal class LoginRequest : HitBTCSocketRequest
    {
        public LoginRequest(int id, string key, string secret) : base(0, "login")
        {
            this.AddParameter("algo", "BASIC");
            this.AddParameter("pKey", key);
            this.AddParameter("sKey", secret);
        }
    }
}
