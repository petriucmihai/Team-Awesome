using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaunDetect.Backend_Data
{
    interface IQueryUserInputRepository
    {
        #region
        string GetUserInputClinic();
        string GetUserInputProvince();
        string GetUserInputDate();
        string GetUserInputDevice();

        bool UpdateClinic(string newData);
        bool UpdateProvince(string newData);
        bool UpdateDate(string newData);
        bool UpdateDevice(string newData);
        List<String> GetList();
        #endregion

    }
}