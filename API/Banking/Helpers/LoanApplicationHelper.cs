using EntityLib;

namespace Banking.Helpers
{
    public  class LoanApplicationHelper
    {
         private readonly HttpClient _httpClient;
        public  LoanApplicationHelper(HttpClient httpClient)
        {
             _httpClient = httpClient;
        }

        public  async Task<List<User>> GetUserDetails(string userIds)
        {
            var response = await _httpClient.GetFromJsonAsync<List<User>>(
                $"http://localhost:5142/api/users/name/{userIds}"
            );
            return response;
        }

        public  async Task<List<CorporateUser>> GetCorporateUserDetails(string userIds)
        {
            var response = await _httpClient.GetFromJsonAsync<List<CorporateUser>>(
                $" http://localhost:5041/api/corporates/names/{userIds}"
            );
            return response;
        }

    }
}

