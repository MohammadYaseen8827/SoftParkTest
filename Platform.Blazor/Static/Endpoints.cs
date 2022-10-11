namespace Platform.Blazor.Static

{
    public static class Endpoints
    {
        public static string BaseUrl = "https://localhost:44330/";

        public static string HousesEndpoint = $"{BaseUrl}api/Houses/";
        public static string CustomersEndpoint = $"{BaseUrl}api/Customers/";
        public static string RegisterEndpoint = $"{BaseUrl}api/account/register/";
        public static string LoginEndpoint = $"{BaseUrl}api/account/authenticate/";

    }
}
