using Corporate.Models;
using System.Threading.Tasks;
using System.Collections;
using System.Net.Http.Headers;
using Corporate.Models;
namespace  Corporate.Repositories.Interfaces;
public interface ICorporateRepository{
    Task<List<Corporation>> GetAll();
    Task<Corporation> GetById(int id);
    Task<bool> Insert(Corporation corporate);
    Task<bool> Update(int id, Corporation corporate);
    Task<bool> Delete(int id);
}

