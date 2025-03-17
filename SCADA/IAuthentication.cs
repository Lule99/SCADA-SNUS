using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SCADA
{
    [ServiceContract]
    interface IAuthentication
    {
        [OperationContract]
        bool Register(string username, string password, bool admin);

        [OperationContract]
        string[] LogIn(string username, string password);

        [OperationContract]
        bool LogOut(string token);

        [OperationContract]
        bool emptyDb();

        [OperationContract]
        bool ValidateUser(string Token, bool isAdmin);

    }
}
