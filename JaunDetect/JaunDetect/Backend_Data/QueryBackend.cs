using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JaunDetect.Models;

namespace JaunDetect.Backend_Data
{
    public class QueryBackend
    {
        #region SingletonPattern
        private static volatile QueryBackend instance;
        private static object syncRoot = new object();

        private QueryBackend() { }

        public static QueryBackend Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new QueryBackend();
                    }
                }

                return instance;
            }
        }
        #endregion SingletonPattern

        // Hook up the Repositry
        private IQueryUserInputRepository queryRepository = new QueryUserInputBackendRepository();
        QueryViewModel model = new QueryViewModel();

        public QueryViewModel GetQuery()
        {     
            model.UserInputClinic = queryRepository.GetUserInputClinic();
            model.UserInputProvince = queryRepository.GetUserInputProvince();
            model.UserInputStartDate = queryRepository.GetUserInputStartDate();
            model.UserInputEndDate = queryRepository.GetUserInputEndDate();
            model.UserInputDevice = queryRepository.GetUserInputDevice();
            model.RecordList = queryRepository.InitializeList();
            return model;
        }


        public bool UpdateUserInputClinic(string newData)
        {
            return queryRepository.UpdateClinic(newData);
        }

        public bool UpdateUserInputProvince(string newData)
        {
            return queryRepository.UpdateProvince(newData);
        }

        public bool UpdateUserInputStartDate(string newData)
        {
            return queryRepository.UpdateStartDate(newData);
        }

        public bool UpdateUserInputEndDate(string newData)
        {
            return queryRepository.UpdateEndDate(newData);
        }

        public bool UpdateUserInputDevice(string newData)
        {
            return queryRepository.UpdateDevice(newData);
        }

        public QueryViewModel GetSearchResults()
        {
            model.RecordList = queryRepository.GetRecordList(); 
            return model;
        }
    }
}


       
       