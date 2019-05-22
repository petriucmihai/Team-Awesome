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
        private IQueryRepository queryRepository = new QueryBackendRepository();
        QueryViewModel userData = new QueryViewModel();

        public QueryViewModel GetQuery()
        {     
            userData.Clinic = queryRepository.GetClinic();
            userData.Province = queryRepository.GetProvince();
            userData.Date = queryRepository.GetDate();
            userData.Device = queryRepository.GetDevice();
            return userData;
        }

        private IQueryDataRepository queryResultRepository = new QueryDataBackendRepository();
        QueryResultViewModel data = new QueryResultViewModel();

        public QueryResultViewModel GetResultQuery()
        {
            data.Clinic = queryResultRepository.GetClinic(0);
            data.Province = queryResultRepository.GetProvince(0);
            data.Date = queryResultRepository.GetDate(0);
            data.Device = queryResultRepository.GetDevice(0);
            data.Dt = queryResultRepository.GetDataTable();
              
            return data;
        }

    }
}


       
       