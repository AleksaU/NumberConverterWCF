using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using WcfNumberConverter_lab.Models;

namespace WcfNumberConverter_lab
{

    public class Service1 : IService1
    {
        NumberConverterContext ncc = new NumberConverterContext();

        public void AddUser(User usr)
        {
            usr.Id = Guid.NewGuid();
            ncc.Users.Add(usr);
            ncc.SaveChanges();
        }

        public void AddRequest(Request req)
        {
            req.Id = Guid.NewGuid();
            ncc.Requests.Add(req);
            ncc.SaveChanges();
        }

        public string AddUserRequest(String login, int arabNumber)
        {
            //get user by login
            var u = (from usr in ncc.Users
                     where usr.Login == login
                     select usr).First();
            string romanToReq = ArabicToRoman(arabNumber);

            Request reqServ = new Request();
            reqServ.ArabNumber = arabNumber;
            reqServ.RomanNumber = romanToReq;
            reqServ.Time = DateTime.Now;
            u.Requests = new Collection<Request>();
            reqServ.Id = Guid.NewGuid();
            u.Requests.Add(reqServ);
            ncc.SaveChanges();
            return reqServ.RomanNumber;
        }

        public User checkIfUserExists(string login, string password)
        {
            var c = (from usr in ncc.Users
                     .Where(x => x.Login == login && x.Password == password)
                     select usr).FirstOrDefault();

            if (c != null)
            {
                return c;
            }

            return null;
        }

        public User checkIfUserExistsByLogin(string login)
        {
            var c = (from usr in ncc.Users
                     .Where(x => x.Login == login)
                     select usr).FirstOrDefault();

            if (c != null)
            {
                return c;
            }

            return null;
        }


        public bool checkIfUserExistsBool(string login, string password)
        {
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

        public ICollection<Request> GetUsersRequests(string login)
        {
            var req = ncc.Requests.Join(
                           ncc.Users,
                           r => r.UsersRequests.Id,
                           u => u.Id,
                           (r, u) => new
                           {
                               Arab = r.ArabNumber,
                               Rom = r.RomanNumber,
                               Time = r.Time,
                               Login = u.Login
                           }).Where(all => all.Login == login).ToList();

            ICollection<Request> requests = new Collection<Request>();

            foreach (var r in req)
                requests.Add(new RequestBuilder().ArabNumber(r.Arab).RomanNumber(r.Rom).SetTime(r.Time).create());

            return requests;
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