using System;
using System.Collections.Generic;
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
         IEnumerable<Request> GetUsersRequests();

        [OperationContract]
        void AddUser(User usr);

        [OperationContract]
           void AddRequest(Request req);

        [OperationContract]
        User checkIfUserExists(string login, string password);

        [OperationContract]
        bool checkIfUserExistsBool(string login, string password);

        [OperationContract]
          void AddUserRequest(String login, Request req);

        [OperationContract]
        string ArabicToRoman(int arabic);





    }
}
