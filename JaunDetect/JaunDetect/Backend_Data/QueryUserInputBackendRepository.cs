using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using JaunDetect.Models;

namespace JaunDetect.Backend_Data
{
    public class QueryUserInputBackendRepository : IQueryUserInputRepository
    {
        const int ROWS = 10;
        string[] clinics = {"Lagos First Clinic", "Lagos Second Clinic", "Onitsha Clinic", "Kano Clinic", "Ibadan Clinic",
            "Uyo Clinic", "Nsukka Clinic", "Abuja First Clinic", "Abuja Second Clinic", "Aba Clinic" };
        string[] provinces = { "Lagos", "Lagos", "Onitsha", "Kano", "Ibadan", "Uyo", "Nsukka", "Abuja", "Abuja", "Aba" };
        string[] dates = { "1/1/2019", "2/2/2019", "3/3/2019", "4/4/2019", "5/5/2019", "6/6/2019", "7/7/2019", "8/8/2019", "9/9/2019", "10/10/2019" };
        string[] devices = { "Samsung Galaxy S8", "Samsung Galaxy Note", "Sony Xperia", "Sony Xperia", "Tecno Spark", "Motorola One", "Huawei Y9", "Huawei P10", "Huawei P10", "OnePlus 5" };
        

    QueryViewModel model = new QueryViewModel();
        public QueryUserInputBackendRepository()
        {
            int num = 0;
            Initialize(num);
        }

        public void Initialize(int i)
        {
            model.UserInputClinic = GetUserInputClinic();
            model.UserInputProvince = GetUserInputProvince();
            model.UserInputDate = GetUserInputDate();
            model.UserInputDevice = GetUserInputDevice();
            model.Clinic = clinics[i];
            model.Province = provinces[i];
            model.Date = dates[i];
            model.Device = devices[i];
            model.List = new List<string>(); 
        }
        
        public string GetUserInputClinic()
        {
            return model.UserInputClinic;
        }

        public string GetUserInputProvince()
        {
            return model.UserInputProvince;
        }

        public string GetUserInputDate()
        {
            return model.UserInputDate;
        }

        public string GetUserInputDevice()
        {
            return model.UserInputDevice;
        }

    
        public bool UpdateClinic(string newData)
        {
            model.UserInputClinic = newData;
            return true;
        }

        public bool UpdateProvince(string newData)
        {
            model.UserInputProvince = newData;
            return true;
        }

        public bool UpdateDate(string newData)
        {
            model.UserInputDate = newData;
            return true;
        }

        public bool UpdateDevice(string newData)
        {
            model.UserInputDevice = newData;
            return true;
        }

        public List<String> GetList()
        {
           
            String lagos = "Lagos";

            List<String> list = new List<String>();


            IQueryUserInputRepository repository = new QueryUserInputBackendRepository();

            for (int i = 0; i < ROWS; i++)
            {
                //if (String.Equals(GetUserInputProvince(), lagos))
                {
                    string toAdd = clinics[i] + repository.GetUserInputClinic() + provinces[i] + repository.GetUserInputProvince() +
                        dates[i] + repository.GetUserInputDate() + devices[i] + repository.GetUserInputDevice();
                    
                }

            }
            return list;
        }
    }
}


       

      