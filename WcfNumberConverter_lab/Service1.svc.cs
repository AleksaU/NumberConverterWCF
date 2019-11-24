using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using WcfNumberConverter_lab.Models;

namespace WcfNumberConverter_lab
{
  
    public class Service1 : IService1
    {
        public void AddUser(User usr)
        {
            NumberConverterContext ncc = new NumberConverterContext();

            usr.Id = Guid.NewGuid();
            ncc.Users.Add(usr);
            ncc.SaveChanges();
        }

        public void AddRequest(Request req)
        {
            NumberConverterContext ncc = new NumberConverterContext();
            req.Id = Guid.NewGuid();
            ncc.Requests.Add(req);
            ncc.SaveChanges();
        }

        public void AddUserRequest(String login, Request req)
        {
                NumberConverterContext ncc = new NumberConverterContext();
                var u = (from usr in ncc.Users
                         where usr.Login == login
                        select usr).First(); 
                                            

                u.Requests = new Collection<Request>();
            req.Id = Guid.NewGuid();
            u.Requests.Add(req);
                ncc.SaveChanges();

        }

        
        public User checkIfUserExists(string login, string password)
        {
            NumberConverterContext ncc = new NumberConverterContext();
            var c = (from usr in ncc.Users
                     .Where(x => x.Login == login && x.Password == password)
                     select usr).FirstOrDefault();

            if (c != null)
            {
                return c;
            }

            return null;
        }


        public bool checkIfUserExistsBool(string login, string password)
        {
            NumberConverterContext ncc = new NumberConverterContext();
            var c = (from usr in ncc.Users
                     .Where(x => x.Login == login && x.Password == password)
                     select usr).FirstOrDefault();


            if (c != null)
            {
                return true;
            }

            return false;
        }

        public IEnumerable<User> GetUsers()
        {
            List<User> list = new List<User>();
            NumberConverterContext ncc = new NumberConverterContext();
            list = ncc.Users.ToList();
            return list;
        }

        public IEnumerable<Request> GetUsersRequests()
        {
            throw new NotImplementedException();
        }



        private string[] ThouLetters = { "", "M", "MM", "MMM", "MMMM", "MMMMM", "MMMMMM" };
        private string[] HundLetters =
            { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
        private string[] TensLetters =
            { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
        private string[] OnesLetters =
            { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };


        public string ArabicToRoman(int arabic)
        {
            string result = "";

            int num;
            num = arabic / 1000;
            result += ThouLetters[num];
            arabic %= 1000;

            num = arabic / 100;
            result += HundLetters[num];
            arabic %= 100;

            num = arabic / 10;
            result += TensLetters[num];
            arabic %= 10;

            result += OnesLetters[arabic];
            return result;
        }
    }
}