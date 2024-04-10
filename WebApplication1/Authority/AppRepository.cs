namespace FirstWebApi.Authority
{
    public static class AppRepository
    {
        private static List<Application> _applications = new List<Application>()
        {
            new Application
            {
                ApplicationId = 1,
                ApplicationName = "MVCWebApp",
                ClientId = "974765d5-9567-4ff9-8d0f-426865bc3f16",
                Secret = "4bb51cf9-3276-4302-8999-04e9752bc4b8",
                Scopes = "read,write"
            }
        };

        public static bool Authenticate(string clientId, string secret)
        {
            return _applications.Any(x => x.ClientId == clientId && x.Secret == secret);
        }

        public static Application? GetApplicationByClientId(string clientId)
        {
            return _applications.FirstOrDefault(x => x.ClientId == clientId);
        }
    }
}