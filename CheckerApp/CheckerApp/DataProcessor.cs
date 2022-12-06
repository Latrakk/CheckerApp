using Flurl.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace CheckerApp
{
    public class DataProcessor : IData
    {
        public string DeleteLocation()
        {
            throw new NotImplementedException();
        }

        public List< Location> GetLocations()
        {
            string url = "http://checkerapi.ru/location";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string resp = reader.ReadToEnd();
            var location = JsonConvert.DeserializeObject<List<Location>>(resp);
            return location;

        }

        public User GetUser(string Login)
        {
            
            string url = "http://checkerapi.ru/users/" + Login;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string resp = reader.ReadToEnd();
            User user = JsonConvert.DeserializeObject<User>(resp);

            return user;
        }

        

        public string PostLocation()
        {
            throw new NotImplementedException();
        }

        

        public User PostUser(User user)
        {
            var responseString = "http://checkerapi.ru/users"
            .PostUrlEncodedAsync(new { user.Name, user.Login, user.Surname, user.Permission, user.Password })
            .ReceiveString();
            return user;


        }

        List<Location> IData.PatchLocations(dynamic location)
        {
            
                throw new NotImplementedException();

            }
        }
    }

