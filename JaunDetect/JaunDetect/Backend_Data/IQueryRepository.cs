using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace JaunDetect.Backend_Data
{
    interface IQueryRepository
    {
        #region
        string GetClinic();
        string GetProvince();
        string GetDate();
        string GetDevice();
      
        #endregion

    }
}