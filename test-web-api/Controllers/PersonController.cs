using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using test_web_api.Models;
using test_web_api.ViewModel;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace test_web_api.Controllers
{
    // This attribute tells ASP that this call is an APIController and preloads some default behavior
    [ApiController]

    // This attribute defines a default route that that has to be used to access this controller
    // ie: You would able to access this controller by sending request to: https://localhost:5001/api/person/
    [Route("api/person")]
    public class PersonController : Controller
    {
        // Default data that I added which simulates our Database
        // I use the static modifer so that this List persist while the application is running
        public static List<Person> people = new List<Person>
        {
            new Person("Roger", 31, "Coral Springs, FL"),
            new Person("Doc", 1, "Ocala, FL")
        };
            

        // GET: api/person
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return people;
        }

        // GET api/person/5
        [HttpGet("{id}")]
        public Task<Person> Get(string id)
        {
            return GetSinglePerson(id);
        }


        private async Task<Person> GetSinglePerson(string id)
        {
            Person selectedPerson = null;

            foreach (var person in people)
            {
                await Task.Delay(500);

                if (person.Id == id)
                    selectedPerson = person;
            }

            return selectedPerson;
        }


        // POST api/person
        [HttpPost]
        public IEnumerable<Person> Post([FromBody] PersonViewModel newPerson)
        {
            Person brandNewPerson = new Person(newPerson.Name, newPerson.Age, newPerson.Hometown);

            people.Add(brandNewPerson);

            return people;
        }

        // PUT api/person/5
        [HttpPut("{id}")]
        public Person Put(string id, [FromBody] Person submitedPersonData)
        {
            Person updatedPerson = null;

            foreach (var person in people)
            {
                if (person.Id == id)
                {
                    person.Age = submitedPersonData.Age;
                    person.Name = submitedPersonData.Name;
                    person.Hometown = submitedPersonData.Hometown;

                    updatedPerson = person;
                    break;
                }

            }

            return updatedPerson;
        }

        // DELETE api/person/5
        [HttpDelete("{id}")]
        public IEnumerable<Person> Delete(string id)
        {
            foreach (var person in people)
            {
                if (person.Id == id)
                {
                    int index = people.IndexOf(person);
                    people.RemoveAt(index);
                    break;
                }
            }

            return people;
        }
    }
}
