using System;
using System.Text.Json;

namespace ConsoleApp28
{
    
    class Program
    {
        
        static void Main(string[] args)
        {
            //Database model objects
            Models.User user = new Models.User()
            {
                Id = 1,
                Name = "Ofer"
            };
            Models.Adult adult = new Models.Adult()
            {
                Proffesion = "teacher",
                UserNavigation = user
            };

            //Controller code
            DTO.Adult dtoAdult = new DTO.Adult()
            {
                Id = adult.UserNavigation.Id,
                Name = adult.UserNavigation.Name,
                Proffesion = adult.Proffesion
            };

            //Server conbvert object to json
            Object obj = dtoAdult;
            string jsonAdult = JsonSerializer.Serialize<Object>(dtoAdult);


            //Application proxy gets the json without knowing if the user is adult or a kid
            AppModels.User u = null;
            AppModels.Adult clientAdult = null;
            AppModels.Kid clientKid = null;
            
            clientKid = JsonSerializer.Deserialize<AppModels.Kid>(jsonAdult);

            if (String.IsNullOrEmpty(clientKid.Hobby))
            {
                clientAdult = JsonSerializer.Deserialize<AppModels.Adult>(jsonAdult);
                u = clientAdult;
                clientKid = null;
            }

            //The proxy return a User, so it returns Adult or Kid based on the object that was deserialized!


            //Other direction (client to server) (proxy gets adult)
            jsonAdult = JsonSerializer.Serialize<AppModels.Adult>(clientAdult);

            //Server gets DTO.Adult
            DTO.Adult serverAdult = JsonSerializer.Deserialize<DTO.Adult>(jsonAdult);

            //Create Models.Adult
            Models.Adult modelsAdult = new Models.Adult()
            {
                Proffesion = serverAdult.Proffesion,
                UserNavigation = new Models.User()
                {
                    Id = serverAdult.Id,
                    Name = serverAdult.Name
                }
            };
        }
    }
}
