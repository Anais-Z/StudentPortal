using StudentPortal.Models;

namespace StudentPortal.Interfaces
{
    public interface IAddressRepository
    {
        ICollection<Address> GetAddresses();

        Address GetAddressById(int id);

        bool CreateAddress(Address address);

        bool AddressExists(int id);

        bool UpdateAddress(Address address);

        bool DeleteAddress(Address address);
    }
}
