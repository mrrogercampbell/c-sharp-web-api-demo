using System;
namespace test_web_api.Models
{
    public class Person
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Hometown { get; set; }

        public Person(string name, int age, string hometown)
        {
            Guid guid = Guid.NewGuid();
            this.Id = guid.ToString();
            this.Name = name;
            this.Age = age;
            this.Hometown = hometown;
        }

        public Person()
        {
          
        }

        
    }
}
