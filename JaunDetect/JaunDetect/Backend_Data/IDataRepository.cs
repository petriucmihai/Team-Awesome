using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaunDetect.Backend_Data
{
    interface IDataRepository
    {
        // Methods needed to provide data for charts on the Resources page
        #region Resources charts backend methods
        string[] GetClinics();

        int[] GetUsages();

        string[] GetMonths();

        int[] GetPatients();

        double GetTestStripPrice();

        bool UpdateTestStripPrice(double price);

        double[] GetTestStripCosts();
        #endregion
    }
}
