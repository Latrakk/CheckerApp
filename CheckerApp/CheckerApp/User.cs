using Newtonsoft.Json;
using System;


namespace CheckerApp
{
    public class User
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Permission { get; set; }

    }
}
