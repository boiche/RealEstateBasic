using Newtonsoft.Json;
using System;

namespace RealEstate
{
    public static class LoginHandler
    {
        public static void RecordLogin()
        {
            RecordLoginModel model = new RecordLoginModel(DateTime.Now);
            JsonConvert.SerializeObject(model);
            Console.WriteLine("Logged in successfully!");
        }

        private class RecordLoginModel
        {
            public DateTime dateTimeOfLogin;
            public RecordLoginModel(DateTime dateTime)
            {
                dateTimeOfLogin = dateTime;
            }
        }
    }  
}
