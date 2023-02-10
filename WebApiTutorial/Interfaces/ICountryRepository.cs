using WebApiTutorial.Models;

namespace WebApiTutorial.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int countryid);
        Country GetCountryOfAnOwner(int ownerId);
        bool CountryExists(int countryid);
    }
}
