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
        private const string AUTHENTICATION = "1";
        private const string GETCODEA = "2";
        private const string GETCODEB = "3";
        private const string CHECKCODEAB = "4";

        //-------------------------------code from host

        private const string FROMHOST = "5";
        private const string FROMMASTER = "6";
        //---------------------------------------------codes frome host
        private const string codeActivation = "0";
        //TODO:add all hsot codes here
        //--------------------------------------------------end codes from host
        const int host_code_idx = 1;
        const int host_deviceID_idx = 2;
        const int host_dataInfo_idx = 3;
        const int host_TypeDeviceID_idx = 4;
        const int host_Token_idx = 5;
        const int host_AndroidID_idx = 6;
        const int host_MacAddress_idx = 7;
        const int host_ip_idx = 8;
        const int host_Version_idx = 9;
        //--------------------------------------------------------------------

        const int TYPEDATAIDX = 0;
        const int EMAILIDX = 2;
        const int PWDIDX = 3;
        const int TypeDeviceIDX = 4;
        const int TokenIDX = 5;
        const int AndroidIDMacAddressIDX = 6;
        const int NameIDX = 7;
        const int IpIDX = 8;
        const int DeviceIdIDX = 9;
        const int CodeAIDX = 10;
        const int CodeBIDX = 11;
        const int VersionIDX = 9;

        const int EXISTUSER = 0;
        const int ERRORSQL = -1;
        const int ERRORDB  = -2;        

        public string GetData(string data, string hash)
        {
           // Request.ServerVariables('REMOTE_ADDR');
           
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
                        Device device = Registration(listdata);
                        result = String.Format("{0}|{1}|{2}", device.UserID, device.DeviceID, device.Name);

                        if (device.UserID == EXISTUSER)
                            {
                                result = "0|0|0";
                            }
                        if (device.UserID == ERRORSQL)
                            {
                                result = "-1|0|0";
                            }
                        if (device.UserID == ERRORDB)
                            {
                                result = "-2|0|0";
                            }
                        
                        break;
                    }
                case AUTHENTICATION:
                    {
                        Device device = Authentication(listdata);
                        //{0}|{1}|{2}|{3} code-deviceID-DeviceName-token
                        result = String.Format("{0}|{1}|{2}|{3}", device.Code, device.DeviceID, device.Name, (new Guid()).ToString());
                        break;
                    }

                case GETCODEA:
                    {
                        result = getA(listdata);
                        
                        break;
                    }

                case GETCODEB:
                    {

                        result = GetB(listdata);                       

                        break;
                    }

                case CHECKCODEAB:
                    {
                        result = FinishAddHostDevice(listdata); 
                        break;
                    }
                case FROMHOST:
                    {
                        result = RequestFromHost(listdata); 
                        break;
                    }
                    
                default:
                    {
                        return String.Empty;
                    }
            }

            return result;          
        }

        private string RequestFromHost(List<string> data)
        {
            try{
                switch(data[host_code_idx])
                 {
                     case codeActivation:
                         {
                             return Activation(data);                             
                         }
                        //TODO: other codes from host here!!!!

                 }
            }
            catch(Exception ex)
            {
              return ex.Message;
            }
            return String.Empty;
        }

        private string Activation(List<string> data)
        {  
                long deviceID = 0;
                string result = String.Empty;
                if (!Int64.TryParse(data[host_deviceID_idx], out deviceID))
                {
                    return String.Empty;
                }               
                Dictionary<string, object> dic = new Dictionary<string, object>();
                try
                {
                    MyCom = new MLDBUtils.SQLCom(connectionString, "");
                    MyCom.setCommand("aActivationDevice");

                    MyCom.AddParam(deviceID);
                    MyCom.AddParam(Convert.ToInt32(data[host_TypeDeviceID_idx]));
                    MyCom.AddParam(Utils.TruncateLongString(data[host_Token_idx], 512));
                    MyCom.AddParam(Utils.TruncateLongString(data[host_AndroidID_idx], 50));
                    MyCom.AddParam(Utils.TruncateLongString(data[host_MacAddress_idx], 50));
                    MyCom.AddParam(Utils.TruncateLongString(data[host_ip_idx], 50));
                    MyCom.AddParam(Utils.TruncateLongString(data[host_Version_idx], 10));

                    dic = MyCom.GetResultD();

                    if (dic == null || dic.Count == 0)
                    {
                        return "-4";
                    }
                    result = dic["result"].ToString();
                }           
            catch (Exception ex)
            {
                return ex.Message;
            }
                return result;
        }

        private string FinishAddHostDevice(List<string> data)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            string result = String.Empty;
            try
            {
                MyCom = new MLDBUtils.SQLCom(connectionString, "");
              
                MyCom.setCommand("acheckABfinish");

                long deviceID = 0;
                if (!Int64.TryParse(data[DeviceIdIDX], out deviceID))
                {
                    return String.Empty;
                }

                MyCom.AddParam(deviceID);         
                MyCom.AddParam(Convert.ToInt32(data[CodeAIDX]));                          
                MyCom.AddParam(Convert.ToInt32(data[CodeBIDX]));
                MyCom.AddParam(Utils.TruncateLongString(data[IpIDX], 50));

                dic = MyCom.GetResultD();

                if (dic == null || dic.Count == 0)
                {
                    return "-1";
                }
                result = dic["DeviceID"].ToString();
            }
            catch (Exception ex)
            {
                return "-3";
            }

            try
            {
                //for send push after and active deviceID
                long newDeviceId = 0;
                if (Int64.TryParse(dic["DeviceID"].ToString(), out newDeviceId))
                {
                    if (newDeviceId > 0)
                    {
                        if (dic["token"] != null)
                        {
                            string mess = newDeviceId.ToString();
                            string url = "http:\\tut.by";
                            string title = "title";
                            Utils.responseGCM responcegsm = Utils.SendGCM(mess, url, title, dic["token"].ToString());
                            string err = responcegsm.Warningmess;
                            if (String.IsNullOrEmpty(err))
                            {
                                err = "OK";
                            }
                            var responce = responcegsm.ResponseLine;
                            if (String.IsNullOrEmpty(responce))
                            {
                                responce = "EMPTY";
                            }
                            string request = String.Format("{0};{1};{2}", mess, url, title);
                            MyCom = new MLDBUtils.SQLCom(connectionString, "");
                            MyCom.setCommand("aGCMlog");

                            MyCom.AddParam(Utils.TruncateLongString(request, 50));
                            MyCom.AddParam(Utils.TruncateLongString(responce, 255));
                            MyCom.AddParam(newDeviceId);
                            MyCom.AddParam(Utils.TruncateLongString(err, 50));
                            MyCom.AddParam(Utils.TruncateLongString("ADDdevice", 20));

                            MyCom.ExecuteCommand();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return "-5|" + dic["DeviceID"].ToString();
            }

            return result;
        }

        private string getA(List<string> listdata)
        {
            string deviceID = String.Empty;
            try
            {
                deviceID = listdata[DeviceIdIDX];
            }
            catch (Exception ex)
            {
                return String.Empty;
                //return ex.Message;
            }

            char first = deviceID[deviceID.Length - 1];
            char second = first;
            if (deviceID.Length > 2)
            {
                second = deviceID[deviceID.Length - 2];
            }

            string codeA = String.Format("{0}{1}{2}{3}{4}{5}",
                GetRandomNumberNotZero(),
                GetRandomNumber(),
                GetRandomNumber(),
                GetRandomNumber(),
                first,
                second
                );

            string codeB = String.Format("{0}{1}{2}{3}{4}{5}",
                GetRandomNumberNotZero(),
                GetRandomNumber(),
                GetRandomNumber(),
                GetRandomNumber(),
                GetRandomNumber(),
                GetRandomNumber()
                );

            string namedevice;
            if (String.IsNullOrEmpty(listdata[NameIDX]))
            {
                namedevice = "host new";
            }
            else
            {
                namedevice = listdata[NameIDX];
            }

            try
            {
                MyCom = new MLDBUtils.SQLCom(connectionString, "");
                Dictionary<string, object> dic = new Dictionary<string, object>();
                MyCom.setCommand("addDeviceA");
                /*
                 * 	@deviceID BIGINT,
	@codeA INT,
	@codeB INT
                 * SELECT @@IDENTITY AS ID
                 */
                MyCom.AddParam(Convert.ToInt64(deviceID));
                MyCom.AddParam(Convert.ToInt32(codeA));
                MyCom.AddParam(Convert.ToInt32(codeB));
                MyCom.AddParam(Utils.TruncateLongString(namedevice, 50));
                dic = MyCom.GetResultD();

                if (dic == null || dic.Count == 0)
                {
                    return string.Empty;
                }

                long id = 0;
                if (!Int64.TryParse(dic["ID"].ToString(), out id))
                {
                    return String.Empty;
                }
                if (id == 0)
                {
                    return String.Empty;
                }
            }
            catch (Exception ex)
            {
                return String.Empty;
            }

            return codeA;
        }
        private string GetB(List<string> data)
        {            
            try
            {
                MyCom = new MLDBUtils.SQLCom(connectionString, "");
                Dictionary<string, object> dic = new Dictionary<string, object>();
                MyCom.setCommand("addDeviceB");

                int typedevice = 0;
                if(!Int32.TryParse((data[TypeDeviceIDX]), out typedevice))
                {
                    return String.Empty;
                }              

                MyCom.AddParam(typedevice);
                MyCom.AddParam(Utils.TruncateLongString(data[TokenIDX], 500));
                
                MyCom.AddParam(Utils.TruncateLongString(data[AndroidIDMacAddressIDX], 100));//AndroidID
                MyCom.AddParam(Utils.TruncateLongString(data[AndroidIDMacAddressIDX], 20)); //MacAdress                             
                MyCom.AddParam(Convert.ToInt32(data[CodeAIDX]));
                MyCom.AddParam(Utils.TruncateLongString(data[IpIDX], 50));

                
                dic = MyCom.GetResultD();

                if (dic == null || dic.Count == 0)
                {                  
                   
                    return "-2";                    
                }

              return  dic["codeB"].ToString();

            }
            catch (Exception ex)
            {  
                return "-2";
            }
        }

        private Device Registration(List<string> data)
        {   
    //@email NVARCHAR(50), 
    //@pwd NVARCHAR(50),	
    //@TypeDeviceID INT,
    //@Token NVARCHAR(300),	
    //@AndroidIDMacaddress NVARCHAR(100),	
    //@Name NVARCHAR(50)
            Device dev = new Device();           

            int typeDevice = Convert.ToInt32(data[TypeDeviceIDX]);
            if (typeDevice < 1)
            {               
                dev.Name = "type device not define";
                return dev;
            }       
            try
            {
                MyCom = new MLDBUtils.SQLCom(connectionString, "");
                Dictionary<string, object> dic = new Dictionary<string, object>();
                MyCom.setCommand("aRegistration");

                MyCom.AddParam(Utils.TruncateLongString(data[EMAILIDX], 50));
                MyCom.AddParam(Utils.TruncateLongString(data[PWDIDX], 50));
                MyCom.AddParam(typeDevice);
                MyCom.AddParam(Utils.TruncateLongString(data[TokenIDX], 500));
                MyCom.AddParam(Utils.TruncateLongString(data[AndroidIDMacAddressIDX], 100));
                MyCom.AddParam(Utils.TruncateLongString(data[NameIDX], 50));
                MyCom.AddParam(Utils.TruncateLongString(data[VersionIDX], 10));


                dic = MyCom.GetResultD();

                if (dic == null || dic.Count == 0)
                {                   
                    dev.Name = "dic is null or empty";
                    return dev;                    
                }

                dev.UserID = Convert.ToInt64(dic["userID"].ToString());

                 if (dev.UserID == EXISTUSER)
                {
                    dev.Name = "User Exist";
                    return dev;
                }
                if (dev.UserID == ERRORSQL)
                {
                    dev.Name = "Error SQL";
                    return dev;
                }

                dev.DeviceID = Convert.ToInt64(dic["deviceID"]);
                //dev.TypeDeviceID = Convert.ToInt32(dic["TypeDeviceID"]);
                //dev.Token = dic["Token"].ToString();
                //dev.AndroidIDMacaddress = dic["AndroidIDMacaddress"].ToString();
                dev.Name = dic["Name"].ToString();
                //dev.DateCreate = Convert.ToDateTime(dic["dateCreate"]);                

            }
            catch (Exception ex)
            {     
                dev.UserID = ERRORDB;
                dev.Name = "Sql Exept. - ";
                if (ex.Message != null)
                {
                    dev.Name += ex.Message;
                }
                return dev;
            }
            return dev;
        }

        private Device Authentication(List<string> data)
        { 
            Device dev = new Device();

            int typeDevice = Convert.ToInt32(data[TypeDeviceIDX]);
            if (typeDevice < 1)
            {
                dev.Name = "type device not define";
                return dev;
            }
            try
            {
                MyCom = new MLDBUtils.SQLCom(connectionString, "");
                Dictionary<string, object> dic = new Dictionary<string, object>();
                MyCom.setCommand("aAuthentication");

                MyCom.AddParam(Utils.TruncateLongString(data[EMAILIDX], 50));
                MyCom.AddParam(Utils.TruncateLongString(data[PWDIDX], 50));
                MyCom.AddParam(typeDevice);
                MyCom.AddParam(Utils.TruncateLongString(data[TokenIDX], 500));
                MyCom.AddParam(Utils.TruncateLongString(data[AndroidIDMacAddressIDX], 100));
                MyCom.AddParam(Utils.TruncateLongString(data[IpIDX], 50));
                MyCom.AddParam(Utils.TruncateLongString(data[VersionIDX], 10));

                dic = MyCom.GetResultD();

                if (dic == null || dic.Count == 0)
                {
                    dev.Name = "dic is null or empty";
                    return dev;
                }

                //SELECT @OK AS 'returncode', @deviceID AS 'deviceID', @DeviceName AS 'DeviceName', '0' AS 'PGP'

                dev.Code = Convert.ToInt32(dic["returncode"]); 
                dev.DeviceID = Convert.ToInt64(dic["deviceID"]);
                dev.Name = dic["DeviceName"].ToString();                        

            }
            catch (Exception ex)
            {
                dev.Code = ERRORDB;
                dev.Name = "Sql Exept. - ";
                if (ex.Message != null)
                {
                    dev.Name += ex.Message;
                }
                return dev;
            }
            return dev;
        }

        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();
        private static int GetRandomNumber()
        {
            lock (syncLock)
            { // synchronize
                //int min, int max
                return getrandom.Next(10);
            }
        }

        private static int GetRandomNumberNotZero()
        {
            lock (syncLock)
            { // synchronize
                //int min, int max
                return getrandom.Next(1, 10);
            }
        }
    }
}
