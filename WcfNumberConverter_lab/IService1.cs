using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using WcfNumberConverter_lab.Models;

namespace WcfNumberConverter_lab
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        IEnumerable<User> GetUsers();

        [OperationContract]
        ICollection<Request> GetUsersRequests(string login);

        [OperationContract]
        void AddUser(User usr);

        [OperationContract]
        User checkIfUserExists(string login, string password);

        [OperationContract]
        bool checkIfUserExistsBool(string login, string password);

        [OperationContract]
        User checkIfUserExistsByLogin(string login);

        [OperationContract]
        string AddUserRequest(String login, int ArabNumber);

        [OperationContract]
        string ArabicToRoman(int arabic);







    }
}
