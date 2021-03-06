using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> listOfBirthday = new List<IBirthable>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                var data = input.Split();
                var type = data[0];
                var nameOrModel = data[1];
                if (type == "Citizen")
                {
                    listOfBirthday.Add(CreateCitizen(nameOrModel, data));
                }
                else if (type == "Pet")
                {
                    listOfBirthday.Add(CreatePet(nameOrModel, data));
                }
            }
            string year = Console.ReadLine();
            listOfBirthday = listOfBirthday.Where(x => x.Birthdate.EndsWith(year)).ToList();
            listOfBirthday.ForEach(Console.WriteLine);
        }
        public static IBirthable CreateCitizen(string name, string[] data)
        {
            var age = int.Parse(data[2]);
            var id = data[3];
            var birthday = data[4];
            IBirthable citizen = new Citizen(name, age, id, birthday);
            return citizen;
        }
        public static IBirthable CreatePet(string name, string[] data)
        {
            var birthdate = data[2];
            IBirthable pet = new Pet(name, birthdate);
            return pet;
        }
    }
}

