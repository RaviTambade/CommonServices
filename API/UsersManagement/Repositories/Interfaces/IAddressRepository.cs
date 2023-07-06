using UsersManagement.Models;

namespace UsersManagement.Repositories.Interfaces;

public interface IAddressRepository
{
    bool Insert(Address theAddress);
    bool Update(Address theAddress);
}