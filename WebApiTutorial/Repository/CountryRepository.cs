using WebApiTutorial.Data;
using WebApiTutorial.Interfaces;
using WebApiTutorial.Models;

namespace WebApiTutorial.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _context;

        public CountryRepository(DataContext context)
        {
            _context = context;
        }
        public bool CountryExists(int countryid)
        {
            return _context.Countries.Any(c => c.Id == countryid);
        }

        public bool CreateCountry(Country country)
        {
            _context.Add(country);
            return Save();
        }

        public ICollection<Country> GetCountries()
        {
            return _context.Countries.ToList();
        }

        public Country GetCountry(int countryid)
        {
            return _context.Countries.Where(c => c.Id == countryid).FirstOrDefault();
        }
        public Country GetCountryOfAnOwner(int ownerId)
        {
            return _context.Owners.Where(o => o.Id == ownerId).Select(c => c.Country).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
