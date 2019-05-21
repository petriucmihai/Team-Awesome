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

        public QueryViewModel GetQueryResources(int num)
        {
            QueryViewModel data = new QueryViewModel();

            data.Clinic = queryRepository.GetClinic(num);
            data.Province = queryRepository.GetProvince(num);
            data.Date = queryRepository.GetDate(num);
            data.Device = queryRepository.GetDevice(num);

            return data;
        }

        
    }
}



   