
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace serverwcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        protected string connectionString = ConfigurationManager.ConnectionStrings["alexandr_gorbunov_ConnectionString"].ConnectionString;
        protected MLDBUtils.SQLCom MyCom;

        //public string GetData(int value)
        //{
        //    return string.Format("You entered: {0}", value);
        //}

        public string GetData(int value)
        {
            //get data from SQL  DB
#if DEBUG
            connectionString = ConfigurationManager.ConnectionStrings["Local_alexandr_gorbunov_ConnectionString"].ConnectionString;
#endif
            MyCom = new MLDBUtils.SQLCom(connectionString, "");
            Dictionary<string, object> dic = new Dictionary<string, object>();
            MyCom.setCommand("aGetData");
            MyCom.AddParam(value);
            dic = MyCom.GetResultD();
            if (dic == null || dic.Count == 0)
            {                
                return String.Empty;
            }
            string result = dic["lastname"].ToString();

            if (result == null)
            {
                result = String.Empty;
            }
            return result;
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
