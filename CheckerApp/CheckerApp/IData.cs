using System;
using System.Collections.Generic;
using System.Text;

namespace CheckerApp
{
    public interface IData
    {
        List<Location> GetLocations();

        List<Location> PatchLocations(dynamic location);

        string PostLocation();
        string DeleteLocation();
        User GetUser(string Login);
        User PostUser(User user);


    }
}
