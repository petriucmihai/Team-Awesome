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

        // creates a new View Model that takes in information from user input stored in the backend repository
        private IQueryUserInputRepository queryRepository = new QueryUserInputBackendRepository(); // the repository containing the user input data
        QueryViewModel model = new QueryViewModel(); // the View Model where the Query Results will be displayed

        public QueryViewModel GetQuery()
        {
            model.UserInputClinic = queryRepository.GetUserInputClinic();
            model.UserInputProvince = queryRepository.GetUserInputProvince();
            model.UserInputStartDate = queryRepository.GetUserInputStartDate();
            model.UserInputEndDate = queryRepository.GetUserInputEndDate();
            model.UserInputDevice = queryRepository.GetUserInputDevice();
            model.RecordList = queryRepository.InitializeList();
            model.VisualizationChoice = queryRepository.GetVisualizationChoice();
            return model;
        }

        // creates a new View Model with user input search results 
        public QueryViewModel GetSearchResults()
        {
            model.RecordList = queryRepository.GetRecordList();
            model.VisualizationChoice = queryRepository.GetVisualizationChoice();
            return model;
        }

        // methods to update the query backend repository through user input; parameters represent user input
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

        public bool UpdateVisualizationChoice(int choice)
        {
            return queryRepository.UpdateVisualizationChoice(choice);
        }

    }
}    