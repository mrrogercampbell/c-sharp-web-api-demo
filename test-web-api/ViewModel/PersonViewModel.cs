using System;
namespace test_web_api.ViewModel
{
    public class PersonViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Hometown { get; set; }

        public PersonViewModel(string name, int age, string hometown)
        {
            Guid guid = Guid.NewGuid();
            this.Id = guid.ToString();
            this.Name = name;
            this.Age = age;
            this.Hometown = hometown;
        }

        public PersonViewModel()
        {

        }
    }
}
