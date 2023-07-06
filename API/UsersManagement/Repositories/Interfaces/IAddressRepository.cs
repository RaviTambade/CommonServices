using PersonalInfoAPI.Models;

namespace PersonalInfoAPI.Repositories.Interfaces;

public interface IAddressRepository
{
    bool Insert(Address theAddress);
    bool Update(Address theAddress);
}