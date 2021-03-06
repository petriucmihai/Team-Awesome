﻿using System.Collections.Generic;
using JaunDetect.Models;

namespace JaunDetect.Backend_Data
{
    interface IQueryUserInputRepository
    {
        #region
        string GetUserInputClinic();
        string GetUserInputProvince();
        string GetUserInputStartDate();
        string GetUserInputEndDate();
        string GetUserInputDevice();
        int GetVisualizationChoice();

        bool UpdateVisualizationChoice(int choice);
        bool UpdateClinic(string newData);
        bool UpdateProvince(string newData);
        bool UpdateStartDate(string newData);
        bool UpdateEndDate(string newData);
        bool UpdateDevice(string newData);
        List<QueryRecord> InitializeList();
        List<QueryRecord> GetRecordList();
        #endregion
    }
}