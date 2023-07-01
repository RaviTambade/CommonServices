using PersonalInfoAPI.Models;

namespace PersonalInfoAPI.Repositories.Interfaces;
public interface IPeopleRepository
{
   Task<List<People>> GetAllPeoples();
   Task<bool> AddPerson(People people);

   Task<bool> UpdatePerson(int id,People people);
}