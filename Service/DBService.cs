using Pract_6_Demin.Models;

using System.Collections.ObjectModel;

namespace Pract_6_Demin.Service
{
    public class DBService
    {
        private DBService()
        {
            context = new WebApiDatabaseContext();
        }
        private static DBService? instance;
        public static DBService Instance
        {
            get
            {
                if (instance == null)
                    instance = new DBService();
                return instance;
            }
        }
        private WebApiDatabaseContext context;
        public WebApiDatabaseContext Context => context;


        

        //public readonly WebApiDatabaseContext db = DBService.Instance.Context;
    }
}
