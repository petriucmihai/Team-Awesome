using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JaunDetect.Models;

namespace JaunDetect.Backend_Data
{
    public class QueryDataBackend
    {

        #region SingletonPattern
        private static volatile QueryDataBackend instance;
        private static object syncRoot = new object();

        private QueryDataBackend() { }

        public static QueryDataBackend Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new QueryDataBackend();
                    }
                }

                return instance;
            }
        }
        #endregion SingletonPattern

        private IQueryDataRepository queryRepository = new QueryDataBackendRepository();
        private IQueryRepository repository = new QueryBackendRepository();

        public QueryViewModel GetQuery()
        {
            QueryViewModel userData = new QueryViewModel();

            userData.Clinic = repository.GetClinic();
            userData.Province = repository.GetProvince();
            userData.Date = repository.GetDate();
            userData.Device = repository.GetDevice();

            return userData; 
        }

        public QueryResultViewModel GetQueryResources(int num)
        {
            QueryResultViewModel data = new QueryResultViewModel();

            data.Clinic = queryRepository.GetClinic(num);
            data.Province = queryRepository.GetProvince(num);
            data.Date = queryRepository.GetDate(num);
            data.Device = queryRepository.GetDevice(num);

            return data;
        }

        
    }
}



   