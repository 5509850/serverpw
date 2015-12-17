﻿
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

        const int TYPEDATAIDX = 0;
        const int EMAILIDX = 2;
        const int PWDIDX = 3;
        const int TypeDeviceIDX = 4;
        const int TokenIDX = 5;
        const int AndroidIDMacAddressIDX = 6;
        const int NameIDX = 7;
        const int IpIDX = 8;


        const int EXISTUSER = 0;
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
                        Device device = Registration(listdata);
                        result = String.Format("{0}|{1}|{2}", device.UserID, device.DeviceID, device.Name);

                        if (device.DeviceID == EXISTUSER)
                            {
                                result = "0";
                            }
                        if (device.DeviceID == ERRORSQL)
                            {
                                result = "-1";
                            }
                        if (device.DeviceID == ERRORDB)
                            {
                                result = "-2";
                            }
                        
                        break;
                    }
                case AUTHENTICATION:
                    {
                        Device device = Authentication(listdata);
                        result = String.Format("{0}|{1}|{2}", device.UserID, device.DeviceID, device.Name);

                        if (device.DeviceID == EXISTUSER)
                        {
                            result = "0";
                        }
                        if (device.DeviceID == ERRORSQL)
                        {
                            result = "-1";
                        }
                        if (device.DeviceID == ERRORDB)
                        {
                            result = "-2";
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
                MyCom.AddParam(Utils.TruncateLongString(data[TokenIDX], 300));
                MyCom.AddParam(Utils.TruncateLongString(data[AndroidIDMacAddressIDX], 100));
                MyCom.AddParam(Utils.TruncateLongString(data[NameIDX], 50));


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

        //TODO:!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        private Device Authentication(List<string> data)
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
                MyCom.setCommand("aAuthentication");

                MyCom.AddParam(Utils.TruncateLongString(data[EMAILIDX], 50));
                MyCom.AddParam(Utils.TruncateLongString(data[PWDIDX], 50));
                MyCom.AddParam(typeDevice);
                MyCom.AddParam(Utils.TruncateLongString(data[TokenIDX], 300));
                MyCom.AddParam(Utils.TruncateLongString(data[AndroidIDMacAddressIDX], 100));
                MyCom.AddParam(Utils.TruncateLongString(data[IpIDX], 50));
                


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
    }
}
