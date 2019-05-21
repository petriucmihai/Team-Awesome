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
        QueryViewModel data = new QueryViewModel();

        public QueryViewModel GetQuery()
        {
            
            data.Clinic = queryRepository.GetClinic();
            data.Province = queryRepository.GetProvince();
            data.Date = queryRepository.GetDate();
            data.Device = queryRepository.GetDevice();

            return data;
        }

    }
}


       
       