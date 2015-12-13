
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

        private const string REGISTRATION = "0";

        const int TYPEDATAIDX = 0;
        const int EMAILIDX = 2;
        const int PWDIDX = 3;
        const int TypeDeviceIDX = 4;
        const int TokenIDX = 5;
        const int AndroidIDMacAddressIDX = 6;
        const int NameIDX = 7;
        const int IpIDX = 8;


        const int ERRORSQL = -1;
        const int ERRORDB  = -2; 
        //public string GetData(int value)
        //{
        //    return string.Format("You entered: {0}", value);
        //}

        public string GetData(string data, string hash)
        {
            if (!hash.Equals(Utils.GetHashString(data)))
            {
                return String.Empty;
            }

            //get data from SQL  DB
#if DEBUG
            connectionString = ConfigurationManager.ConnectionStrings["Local_alexandr_gorbunov_ConnectionString"].ConnectionString;
#endif

            string[] datadic = data.Split('|');
            if (datadic == null || datadic.Length == 0)
            {
                return String.Empty;
            }

            List<string> listdata = new List<string>();
            for (int i = 0; i < datadic.Length; i++)            
            {
                if (i % 2 != 0)
                {
                    listdata.Add(datadic[i]);
                }
            }

            string result  = String.Empty;

            switch (listdata[TYPEDATAIDX])
            {
                case REGISTRATION:
                    {
                        result = Registration(listdata);
                        long id = 0;
                        if (Int64.TryParse(result, out id))
                        {
                            if (id == 0)
                            {
                                result = "user Exist!";
                            }
                            if (id == ERRORSQL)
                            {
                                result = "Error SQL!";
                            }
                            if (id == ERRORDB)
                            {
                                result = "Error DB!";
                            }
                        } 
                        else
                            {
                                result = "Error Empty";
                            }
                        break;
                    }
                default:
                    {
                        return String.Empty;
                    }
            }

            return result;          
        }

        

        private string[] Registration(List<string> data)
        {   
    //@email NVARCHAR(50), 
    //@pwd NVARCHAR(50),	
    //@TypeDeviceID INT,
    //@Token NVARCHAR(300),	
    //@AndroidIDMacaddress NVARCHAR(100),	
    //@Name NVARCHAR(50)

            int typeDevice = Convert.ToInt32(data[TypeDeviceIDX]);
            if (typeDevice < 1)
            { 
                return String.Empty;
            }
            string result = String.Empty;
            try
            {
                MyCom = new MLDBUtils.SQLCom(connectionString, "");
                Dictionary<string, object> dic = new Dictionary<string, object>();
                MyCom.setCommand("aRegistration");

                MyCom.AddParam(Utils.TruncateLongString(data[EMAILIDX], 50));
                MyCom.AddParam(Utils.TruncateLongString(data[PWDIDX], 50));
                MyCom.AddParam(typeDevice);
                MyCom.AddParam(Utils.TruncateLongString(data[TokenIDX], 300));
                MyCom.AddParam(Utils.TruncateLongString(data[AndroidIDMacAddressIDX], 100));
                MyCom.AddParam(Utils.TruncateLongString(data[NameIDX], 50));


                dic = MyCom.GetResultD();

                if (dic == null || dic.Count == 0)
                {
                    return ERRORDB.ToString();
                }

                result = dic["userID"].ToString();
                string deviceID = dic["deviceID"].ToString();
                

                if (result == null)
                {
                    result = ERRORDB.ToString();
                }

            }
            catch (Exception)
            {
                return ERRORDB.ToString();
            }

            //return value
            //1-10000 userID
            //0 = user (email) exist!!!
            //-1 = error SQL!!!!
            //-2 = error DB
            
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
