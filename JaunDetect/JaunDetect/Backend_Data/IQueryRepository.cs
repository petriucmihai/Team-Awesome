using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaunDetect.Backend_Data
{
    interface IQueryRepository
    {
        #region
        string GetClinic();
        string GetProvince();
        string GetDate();
        string GetDevice();
        List<string[]> QueryFound(string[,] database); 
        #endregion
    }
}