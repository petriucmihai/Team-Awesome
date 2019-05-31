using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using JaunDetect.Models;
using System.Globalization; 

namespace JaunDetect.Backend_Data
{
    public class QueryUserInputBackendRepository : IQueryUserInputRepository
    {
        const int ROWS = 100;
        const double FAILURE_LIKELIHOOD = 0.05; 
        TextInfo ti = new CultureInfo("en-US", false).TextInfo;
        string[] clinics = {"Lagos First Clinic", "Lagos Second Clinic", "Onitsha Clinic", "Kano Clinic", "Ibadan Clinic",
            "Uyo Clinic", "Nsukka Clinic", "Abuja First Clinic", "Abuja Second Clinic", "Aba Clinic" };
        string[] provinces = { "Lagos", "Lagos", "Onitsha", "Kano", "Ibadan", "Uyo", "Nsukka", "Abuja", "Abuja", "Aba" };
        string[] dates = { "1/1/2019", "1/15/2019", "2/2/2019", "2/15/2019", "3/3/2019", "3/15/201", "4/4/2019", "4/21/2019", "5/5/2019", "5/30/2019", "6/6/2019", "6/15/2019",
                            "7/7/2019", "7/28/2019", "8/8/2019", "8/21/2019", "9/9/2019", "10/10/2019", "11/1/2019", "12/31/2019" };
        string[] devices = { "Samsung Galaxy S8", "Samsung Galaxy Note", "Sony Xperia", "Sony Xperia", "Tecno Spark", "Motorola One", "Huawei Y9", "Huawei P10", "Huawei P10", "OnePlus 5" };
        string[] biliConcentrations = { "5%", "10%", "15%", "20%", "25%"};
        string[] osList = { "9.0 Pie", "8.0 Oreo", "8.1 Oreo", "7.0 Nougat", "7.1 Nougat", "6.0 Marshmallow", "5.0 Lollipop", "4.4 KitKat", "4.1 Jelly Bean", "4.0 Ice Cream Sandwich" };

        QueryViewModel model = new QueryViewModel();
        public QueryUserInputBackendRepository()
        {
            int num = 0;
            Initialize(num);
        }

        public void Initialize(int i)
        {
            model.UserInputClinic = "";
            model.UserInputProvince = "";
            model.UserInputStartDate = "";
            model.UserInputEndDate = "";
            model.UserInputDevice = "";
            model.Clinic = clinics[i];
            model.Province = provinces[i];
            model.Date = dates[i];
            model.Device = devices[i];
            model.RecordList = InitializeList();
        }

        public string GetUserInputClinic()
        {
            return model.UserInputClinic;
        }

        public string GetUserInputProvince()
        {
            return model.UserInputProvince;
        }

        public string GetUserInputStartDate()
        {
            return model.UserInputStartDate;
        }

        public string GetUserInputEndDate()
        {
            return model.UserInputEndDate;
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

        public bool UpdateStartDate(string newData)
        {
            model.UserInputStartDate = newData;
            return true;
        }

        public bool UpdateEndDate(string newData)
        {
            model.UserInputEndDate = newData;
            return true;
        }

        public bool UpdateDevice(string newData)
        {
            model.UserInputDevice = newData;
            return true;
        }

        public List<QueryRecord> InitializeList()
        {
            List<QueryRecord> result = new List<QueryRecord>();

            // Use random number generator from backend_data for this!
            Random rand = new Random();

            for (int i = 0; i < ROWS; i++)
            {
                QueryRecord record = new QueryRecord();
                record.Province = provinces[rand.Next(10)];
                record.Device = devices[rand.Next(10)];
                record.Clinic = clinics[rand.Next(10)];
                record.Date = dates[rand.Next(20)];
                if (record.FailedPhoto)
                    record.BiliConcentration = "N/A";
                else 
                    record.BiliConcentration = biliConcentrations[rand.Next(5)];
                record.DeviceOS = osList[rand.Next(10)];
                // random bool
                record.FailedPhoto = rand.NextDouble() <= FAILURE_LIKELIHOOD;

                result.Add(record);
            }

            return result;
        }

        public void GetSearchResults()
        {
            List<QueryRecord> result = new List<QueryRecord>();

            if (model.UserInputClinic == null && model.UserInputStartDate == null && model.UserInputProvince == null && model.UserInputDevice == null)
            {
                model.RecordList = InitializeList();
            }
            else
            {

                foreach (QueryRecord record in model.RecordList)
                {
                    if (string.Equals(model.UserInputClinic, record.Clinic) || string.Equals(model.UserInputStartDate, record.Date) || string.Equals(model.UserInputProvince, record.Province)
                        || string.Equals(model.UserInputDevice, record.Device))
                    {
                        result.Add(record);
                    }
                }

                model.RecordList = result;
                //return result;
            }

        }

        private bool ClinicMatch(QueryRecord singleRecord)
        {
            if (!string.IsNullOrWhiteSpace(model.UserInputClinic))
                return String.Equals(singleRecord.Clinic, model.UserInputClinic) || singleRecord.Clinic.Contains(model.UserInputClinic) ||
               singleRecord.Clinic.Contains(ti.ToTitleCase(model.UserInputClinic));
            else
                return false; 
        }

        private bool ProvinceMatch(QueryRecord singleRecord)
        {
            if (!string.IsNullOrWhiteSpace(model.UserInputProvince))
                return String.Equals(singleRecord.Province, model.UserInputProvince) || singleRecord.Province.Contains(model.UserInputProvince) ||
                 singleRecord.Province.Contains(ti.ToTitleCase(model.UserInputProvince));
            else
                return false; 
        }
    
        private bool DateMatch(QueryRecord singleRecord)
        {
            bool condition = false;
            string[] formats = new string[] { "M-d-yyyy", "M/d/yyyy", "MM-dd-yyyy", "MM/dd/yyyy"};
            if (!string.IsNullOrWhiteSpace(model.UserInputStartDate) || !string.IsNullOrWhiteSpace(model.UserInputEndDate))
            {
                try
                {
                    if (DateTime.ParseExact(singleRecord.Date, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None) >=
               DateTime.ParseExact(model.UserInputStartDate, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None) &&
               DateTime.ParseExact(singleRecord.Date, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None) <=
               DateTime.ParseExact(model.UserInputEndDate, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None))
                        condition = true;
                }
                catch { }; 
            }    
           
            return condition;
        }

        private bool DeviceMatch(QueryRecord singleRecord)
        {
            if (!string.IsNullOrWhiteSpace(model.UserInputDevice))
                return String.Equals(singleRecord.Device, model.UserInputDevice) || singleRecord.Device.Contains(model.UserInputDevice) ||
                 singleRecord.Device.Contains(ti.ToTitleCase(model.UserInputDevice));
            else
                return false; 
        }

        private bool ClinicNull()
        {
            return String.Equals(model.UserInputClinic, null);
        }

        private bool ProvinceNull()
        {
            return String.Equals(model.UserInputProvince, null);
        }

        private bool DateNull()
        {
            return String.Equals(model.UserInputStartDate, null) || String.Equals(model.UserInputEndDate, null);
        }

        private bool DeviceNull()
        {
            return String.Equals(model.UserInputDevice, null);
        }

        public List<QueryRecord> GetRecordList()
                {
                    List<QueryRecord> result = new List<QueryRecord>();

                foreach (QueryRecord record in model.RecordList)
                
                {
                        // if no query is entered, the whole list is presented
                        if (ClinicNull() && ProvinceNull() && DateNull() && DeviceNull())
                            result.Add(record);
                  

                        // if one query matches 
                        if ((ClinicMatch(record) && ProvinceNull() && DateNull() && DeviceNull()) || (ProvinceMatch(record) && ClinicNull() && DateNull() && DeviceNull()) 
                            || (DateMatch(record) && ProvinceNull() && ClinicNull() && DeviceNull()) || (DeviceMatch(record) && ProvinceNull() && DateNull() && ClinicNull()))
                            result.Add(record);

                        // if two queries match
                        if ((ClinicMatch(record) && ProvinceMatch(record) && DateNull() && DeviceNull()) || (ClinicMatch(record) && ProvinceNull() && DateMatch(record) && DeviceNull())
                            || (ClinicMatch(record) && ProvinceNull() && DateMatch(record) && DeviceNull()) || (ClinicMatch(record) && ProvinceNull() && DateNull() && DeviceMatch(record))
                            || (ClinicNull() && ProvinceMatch(record) && DateMatch(record) && DeviceNull()) || (ClinicNull()) && ProvinceMatch(record) && DateNull() && DeviceMatch(record)
                            || (ClinicNull() && ProvinceNull() && DateMatch(record) && DeviceMatch(record)))
                            result.Add(record);

                        // if three queries match
                        if ((ClinicMatch(record) && ProvinceMatch(record) && DateMatch(record) && DeviceNull()) || (ClinicMatch(record) && ProvinceMatch(record) && DateNull() && DeviceMatch(record))
                            || (ClinicMatch(record) && ProvinceNull() && DateMatch(record) && DeviceMatch(record)) || (ClinicNull() && ProvinceMatch(record) && DateMatch(record) && DeviceMatch(record)))
                            result.Add(record);

                        // if all queries match
                        if ((ClinicMatch(record) && ProvinceMatch(record) && DateMatch(record) && DeviceMatch(record)))
                            result.Add(record);

                       
                }
                return result;
        }
    }
}

      