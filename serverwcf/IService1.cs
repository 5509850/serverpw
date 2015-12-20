using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace serverwcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(string data, string hash);

        
        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Device
    {
        int code = 0;

        public int Code
        {
            get { return code; }
            set { code = value; }
        }
        long deviceID = 0;
        int typeDeviceID = 0;
        long userID = 0;
        string token = String.Empty;
        string androidIDMacaddress = String.Empty;
        string name = String.Empty;
        DateTime dateCreate = DateTime.Now.Date;
        public long UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        public string Token
        {
            get { return token; }
            set { token = value; }
        }
        public string AndroidIDMacaddress
        {
            get { return androidIDMacaddress; }
            set { androidIDMacaddress = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public DateTime DateCreate
        {
            get { return dateCreate; }
            set { dateCreate = value; }
        }

        [DataMember]
        public long  DeviceID
        {
            get { return deviceID; }
            set { deviceID = value; }
        }
        [DataMember]
        public int TypeDeviceID
        {
            get { return typeDeviceID; }
            set { typeDeviceID = value; }
        }

      
    }
}
