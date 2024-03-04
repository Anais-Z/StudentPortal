using StudentPortal.Data;
using StudentPortal.Interfaces;
using StudentPortal.Models;

namespace StudentPortal.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DataContext _context;

        public AddressRepository(DataContext context) 
        {
            _context = context;
        }
        public bool AddressExists(int id)
        {
           _context.Addresses.Where(a => a.Id == id).FirstOrDefault();
            return true;
        }

        public bool CreateAddress(Address address)
        {
            _context.Add(address);
            return Save();
        }

        public bool DeleteAddress(Address address)
        {
            _context.Remove(address);
            return Save();
        }

        public Address GetAddressById(int id)
        {
            return _context.Addresses.Where(a => a.Id == id).FirstOrDefault();
        }

        public ICollection<Address> GetAddresses()
        {
            return _context.Addresses.OrderBy(a => a.Id).ToList();
        }

        public bool UpdateAddress(Address address)
        {
            _context.ChangeTracker.Clear();
            _context.Update(address);
            return Save();
        }

        public bool Save()
        {

            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
