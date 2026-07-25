using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Core
{
    public static class SystemMessage
    {
        public static string SomethingWentWrong = "Something went wrong.";
        public static string RecordAddSuccessfully = "Record Add Succesfully.";
        public static string RecordUpdateSuccesfully = "Record Update Succesfully.";
        public static string RecordFetchSuccesfully  = "Record Fetch Succesfully.";
        public static string RecordNotFound  = "Record Not Found.";
        public static string RequestbodyNull  = "Request Body null.";
        public static string RequiredId  = "Id is required.";
        public static string UnAuthorized  = "You are not Authorized User.";
        public static string NotFindEmail  = "Email is Invalid.";
        public static string NotFindPassword  = "Password is Invalid.";
        public static string NotGenrateToke  = "Token Genrate is problem";
        public static string LoginSuccess  = "Login Succesfully.";
        public static string InActiveData  = "Before Update! Please Restore Data Becuase curruntly soft Delete.";
    }
}
