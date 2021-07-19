using BookApiCore.Dtos;
using BookApiCore.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApiCore.Controllers
{
    // Because I called this class CountriesController the route will automatically be called countries.
    // If I want a specific name for my route then replace [controller] with what I want.
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : Controller
    {
        private ICountryRepository _countryRepository;
        private IAuthorRepository _authorRepository;

        public CountriesController(ICountryRepository countryRepository, IAuthorRepository authorRepository)
        {
            _countryRepository = countryRepository;
            _authorRepository = authorRepository;
        }

        // aoi/countries
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CountryDto>))]
        public IActionResult GetCountries()
        {
            var countries = _countryRepository.GetCountries().ToList();

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var countriesDto = new List<CountryDto>();
            foreach(var country in countries)
            {
                countriesDto.Add(new CountryDto
                {
                    Id = country.Id,
                    Name = country.Name
                });
            }

            return Ok(countriesDto);
        }

        // api/countries/countryId
        [HttpGet("{countryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)] // Not found.
        [ProducesResponseType(200, Type = typeof(CountryDto))]
        public IActionResult GetCountry(int countryId)
        {
            if(!_countryRepository.CountryExists(countryId))
            {
                return NotFound();
            }

            var country = _countryRepository.GetCountry(countryId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var countryDto = new CountryDto()
            {
                Id = country.Id,
                Name = country.Name
            };

            return Ok(countryDto);
        }

        // We need to differentiate book id from author id so 'authors' was added to the route.
        // api/countries/authors/authorId
        [HttpGet("authors/{authorId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)] // Not found.
        [ProducesResponseType(200, Type = typeof(CountryDto))]
        public IActionResult GetCountryOfAnAuthor(int authorId)
        {
            if(!_authorRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var country = _countryRepository.GetCountryOfAnAuthor(authorId);

            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var countryDto = new CountryDto()
            {
                Id = country.Id,
                Name = country.Name
            };

            return Ok(countryDto);
        }

        // api/countries/countryId/authors
        [HttpGet("{countryId}/authors")] 
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AuthorDto>))]
        public IActionResult GetAuthorsFromACountry(int countryId)
        {
            if(!_countryRepository.CountryExists(countryId))
            {
                return NotFound();
            }

            var authors = _countryRepository.GetAuthorsFromACountry(countryId);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var authorsDto = new List<AuthorDto>();
            foreach(var author in authors)
            {
                authorsDto.Add(new AuthorDto()
                {
                    Id = author.Id,
                    FirstName = author.FirstName,
                    LastName = author.LastName
                });
            }

            return Ok(authorsDto);
        }
    }
}
