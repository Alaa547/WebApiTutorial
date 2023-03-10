using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiTutorial.DTO;
using WebApiTutorial.Interfaces;
using WebApiTutorial.Models;

namespace WebApiTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryController(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        public IActionResult GetCountries()
        {
            var countries = _mapper.Map<List<CountryDTO>>(_countryRepository.GetCountries());

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(countries);
        }

        [HttpGet("{countryid}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public IActionResult GetCountry(int countryid)
        {
            if (!_countryRepository.CountryExists(countryid))
                return NotFound();

            var country = _mapper.Map<CountryDTO>(_countryRepository.GetCountry(countryid));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(country);
        }

        [HttpGet("/Country/{ownerId}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public IActionResult GetCountryOfAnOwner(int ownerId)
        {
            var country = _mapper.Map<CountryDTO>(
                _countryRepository.GetCountryOfAnOwner(ownerId));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(country);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCoutry([FromBody] CountryDTO countryCreate)
        {
            if (countryCreate == null)
                return BadRequest(ModelState);

            var country = _countryRepository.GetCountries()
                .Where(c => c.Name.Trim().ToUpper() == countryCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (country != null)
            {
                ModelState.AddModelError("", "Country already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var countryMap = _mapper.Map<Country>(countryCreate);

            if (!_countryRepository.CreateCountry(countryMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
    }
}
