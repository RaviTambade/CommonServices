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

       /* public  async Task<User> GetUserDetailById(int userId)
        {
            var response = await _httpClient.GetFromJsonAsync<User>(
                $"http://localhost:5142/api/users/{userId}"
            );
            return response;
        }

        public  async Task<CorporateUser> GetCorporateUserDetailById(int userId)
        {
            var response = await _httpClient.GetFromJsonAsync<CorporateUser>(
                $" http://localhost:5041/api/corporates/{userId}"
            );
            return response;
        }*/
        public  async Task <List<LoanaplicantsInfo>> applicantsDetails(List<LoanaplicantsInfo> applicants )
        {
            
            String user_ids = string.Join(',',applicants.Where(applicant=> applicant.ApplicantType == "I").Select(applicant => applicant.CustomerUserId  ).ToList());

            String corporateuser_ids =  string.Join(',',applicants.Where(applicant=> applicant.ApplicantType == "C").Select(applicant => applicant.CustomerUserId  ).ToList());
        
            Console.WriteLine(user_ids);
            List<User> users = null;
            if(!String.IsNullOrEmpty(user_ids))
            {
                users =  await GetUserDetails(user_ids);
            }
            List<CorporateUser> corporateusers = null;
            if(!String.IsNullOrEmpty(corporateuser_ids))
            {
                corporateusers = await GetCorporateUserDetails(corporateuser_ids);
            }
            
            foreach(var applicant in applicants)
            {
                if(applicant.ApplicantType == "I")
                {
                    User user = users.FirstOrDefault(u => u.Id == applicant.CustomerUserId);
                    applicant.ApplicantName = user.FirstName + " " + user.LastName;
                }
                else
                {
                    //if(applicant.ApplicantType == "C")
                    //{
                        CorporateUser cuser = corporateusers.FirstOrDefault(u => u.Id == applicant.CustomerUserId);
                        applicant.ApplicantName = cuser.Name;
                    //}
                }
            }

            return applicants;
        }


       /* public  async Task <LoanaplicantsInfo> applicantDetailsById(LoanaplicantsInfo applicant )
        {
            
            //int user_id = string.Join(',',applicant.Where(applicant=> applicant.ApplicantType == "I").Select(applicant => applicant.CustomerUserId  ));

            //int corporateuser_id =  string.Join(',',applicants.Where(applicant=> applicant.ApplicantType == "C").Select(applicant => applicant.CustomerUserId  ).ToList());
        
            Console.WriteLine(applicant);
            User user = null;
            if(applicant!=null)
            {
                user =  await GetUserDetailById(applicant.ApplicantId);
            }
            CorporateUser corporateuser = null;
            if(applicant!=null)
            {
                corporateuser = await GetCorporateUserDetailById(applicant.ApplicantId);
            }
            
            
                if(applicant.ApplicantType == "I")
                {
                    //User user = user.FirstOrDefault(u => u.Id == applicant.CustomerUserId);
                    applicant.ApplicantName = user.FirstName + " " + user.LastName;
                }
                else
                {
                    //if(applicant.ApplicantType == "C")
                    //{
                        //CorporateUser cuser = corporateusers.FirstOrDefault(u => u.Id == applicant.CustomerUserId);
                        applicant.ApplicantName = corporateuser.Name;
                    //}
                }

                return applicant;
            }*/
        
    }
}

