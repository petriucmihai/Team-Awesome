using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using JaunDetect.Models;
using System.Text.RegularExpressions;

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
        string[] biliConcentrations = { "5%", "10%", "15%", "20%", "25%", "5%", "10%", "15%", "20%", "25%" };
        string[] osList = { "9.0 Pie", "8.0 Oreo", "8.1 Oreo", "7.0 Nougat", "7.1 Nougat", "6.0 Marshmallow", "5.0 Lollipop", "4.4 KitKat", "4.1 Jelly Bean", "4.0 Ice Cream Sandwich" };
        bool[] photoUpload = { true, true, false, true, false, false, false, true, true, false };

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
            model.UserInputDate = "";
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
                record.Date = dates[rand.Next(10)];
                record.BiliConcentration = biliConcentrations[rand.Next(5)];
                record.DeviceOS = osList[rand.Next(10)];
                // random bool
                record.PhotoUpload = rand.NextDouble() > 0.5;

                result.Add(record);
            }

            return result;
        }

        public void GetSearchResults()
        {
            List<QueryRecord> result = new List<QueryRecord>();

            if (model.UserInputClinic == null && model.UserInputDate == null && model.UserInputProvince == null && model.UserInputDevice == null)
            {
                model.RecordList = InitializeList();
            }
            else
            {

                foreach (QueryRecord record in model.RecordList)
                {
                    if (string.Equals(model.UserInputClinic, record.Clinic) || string.Equals(model.UserInputDate, record.Date) || string.Equals(model.UserInputProvince, record.Province)
                        || string.Equals(model.UserInputDevice, record.Device))
                    {
                        result.Add(record);
                    }
                }

                model.RecordList = result;
                //return result;
            }

        }


        
                public List<QueryRecord> GetRecordList()
                {
                    List<QueryRecord> result = new List<QueryRecord>();

                foreach (QueryRecord record in model.RecordList)
                
                {
                        // if no query is entered, the whole list is presented
                       /* if (String.Equals(model.UserInputClinic, null) && String.Equals(model.UserInputProvince, null) &&
                            String.Equals(model.UserInputDate, null) && String.Equals(model.UserInputDevice, null))
                        {
                            {
                            result.Add(record);
                            }
                        }
                        */
                        // if only the clinic matches, that query is returned
                        if (String.Equals(record.Clinic, model.UserInputClinic) && String.Equals(null, model.UserInputProvince)
                            && String.Equals(null, model.UserInputDate) && String.Equals(null, model.UserInputDevice))
                        {
                            {
                        result.Add(record);
                    }
                        }

                        // if only the province matches, that query is returned 
                        if (String.Equals(null, model.UserInputClinic) && String.Equals(record.Province, model.UserInputProvince)
                            && String.Equals(null, model.UserInputDate) && String.Equals(null, model.UserInputDevice))
                        {
                            {
                        result.Add(record);
                    }   
                        }

                        // if only the date matches, that query is returned
                        if (String.Equals(null, model.UserInputClinic) && String.Equals(null, model.UserInputProvince)
                            && String.Equals(record.Date, model.UserInputDate) && String.Equals(null, model.UserInputDevice))
                        {
                            {
                        result.Add(record);
                    }
                        }

                        //if only the device matches, that query is returned 
                        if (String.Equals(null, model.UserInputClinic) && String.Equals(null, model.UserInputProvince)
                             && String.Equals(null, model.UserInputDate) && String.Equals(record.Device, model.UserInputDevice))
                        {
                            {
                        result.Add(record);
                    }
                        }

                        if (String.Equals(record.Clinic, model.UserInputClinic) && String.Equals(record.Province, model.UserInputProvince)
                            && String.Equals(null, model.UserInputDate) && String.Equals(null, model.UserInputDevice))
                        {
                            {
                        result.Add(record);
                    }
                        }

                        if (String.Equals(record.Clinic, model.UserInputClinic) && String.Equals(null, model.UserInputProvince)
                            && String.Equals(record.Date, model.UserInputDate) && String.Equals(null, model.UserInputDevice))
                        {
                            {
                        result.Add(record);
                    }
                        }

                        if (String.Equals(record.Clinic, model.UserInputClinic) && String.Equals(null, model.UserInputProvince)
                            && String.Equals(null, model.UserInputDate) && String.Equals(record.Device, model.UserInputDevice))
                        {
                            {
                        result.Add(record);
                    }
                        }

                        if (String.Equals(null, model.UserInputClinic) && String.Equals(record.Province, model.UserInputProvince)
                            && String.Equals(record.Date, model.UserInputDate) && String.Equals(null, model.UserInputDevice))
                        {
                            {
                        result.Add(record);
                    }
                        }

                        if (String.Equals(null, model.UserInputClinic) && String.Equals(record.Province, model.UserInputProvince)
                            && String.Equals(null, model.UserInputDate) && String.Equals(record.Device, model.UserInputDevice))
                        {
                            {
                        result.Add(record);
                    }
                        }

                        if (String.Equals(null, model.UserInputClinic) && String.Equals(null, model.UserInputProvince)
                             && String.Equals(record.Date, model.UserInputDate) && String.Equals(record.Device, model.UserInputDevice))
                        {
                            {
                        result.Add(record);
                    }
                        }

                        if (String.Equals(null, model.UserInputClinic) && String.Equals(record.Province, model.UserInputProvince)
                             && String.Equals(record.Date, model.UserInputDate) && String.Equals(record.Device, model.UserInputDevice))
                        {
                            {
                        result.Add(record);
                    }
                        }

                        if (String.Equals(record.Clinic, model.UserInputClinic) && String.Equals(null, model.UserInputProvince)
                            && String.Equals(record.Date, model.UserInputDate) && String.Equals(record.Device, model.UserInputDevice))
                        {
                            {
                        result.Add(record);
                    }
                        }

                        if (String.Equals(record.Clinic, model.UserInputClinic) && String.Equals(record.Province, model.UserInputProvince)
                            && String.Equals(null, model.UserInputDate) && String.Equals(record.Device, model.UserInputDevice))
                        {
                            {
                        result.Add(record);
                    }
                        }

                        if (String.Equals(record.Clinic, model.UserInputClinic) && String.Equals(record.Province, model.UserInputProvince)
                            && String.Equals(record.Date, model.UserInputDate) && String.Equals(null, model.UserInputDevice))
                        {
                            {
                        result.Add(record);
                    }
                        }


                        if (String.Equals(record.Clinic, model.UserInputClinic) && String.Equals(record.Province, model.UserInputProvince)
                            && String.Equals(record.Date, model.UserInputDate) && String.Equals(record.Device, model.UserInputDevice))
                        {
                            {
                        result.Add(record);
                    }
                        }



                    }
                    return result;
                }
            }
          
    }

      