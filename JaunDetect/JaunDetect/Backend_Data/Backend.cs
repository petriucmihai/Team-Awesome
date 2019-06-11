using JaunDetect.Models;

namespace JaunDetect.Backend_Data
{
    public class Backend
    {
        #region SingletonPattern
        private static volatile Backend instance;
        private static object syncRoot = new object();

        private Backend() { }

        public static Backend Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Backend();
                    }
                }

                return instance;
            }
        }
        #endregion SingletonPattern

        // Hook up the Repositry
        private IDataBackendRepository repository = new DataBackendRepository();

        public ResourcesChartModel GetResources()
        {
            var myData = new ResourcesChartModel();
            myData.Clinics = repository.GetClinics();
            myData.HospitalPatients = repository.GetPatients();
            myData.ClinicWorkers = repository.GetClinicWorkers();
            myData.Months = repository.GetMonths();
            myData.TestStripUsages = repository.GetUsages();
            myData.TestStripPrice = repository.GetTestStripPrice();
            myData.TestStripCosts = repository.GetTestStripCosts();
            myData.WorkerSalary = repository.GetWorkerSalary();
            myData.SalaryCosts = repository.GetSalaryCosts();

            return myData;
        }

        public HomeChartModel GetHomeData()
        {
            var myData = new HomeChartModel();
            myData.BilirubinData = repository.GetBilirubinData();
            myData.BilirubinLevels = repository.GetBilirubinLevels();
            myData.Clinics = repository.GetHomeClinics();
            myData.TimeOptionsList = repository.GetOptionsList();
            myData.Timeframe = repository.GetTimeframe();
            myData.TimeOption = repository.GetTimeOption();
            myData.TimeOptionString = repository.GetTimeOptionString();
            myData.ClinicOption = repository.GetClinicOption();
            myData.ClinicOptionString = repository.GetClinicOptionString();
            myData.ClinicOptionsList = repository.GetClinicOptionsList();

            return myData;
        }

        public CrashChartModel GetCrashData()
        {
            var myData = new CrashChartModel();
            myData.CrashesByTime = repository.GetCrashesByTime();
            myData.CrashesByType = repository.GetCrashesByType();
            myData.CrashTypes = repository.GetCrashTypes();
            myData.DeviceTypes = repository.GetDeviceTypes();
            myData.DeviceIDs = repository.GetDeviceIDs();
            myData.CrashesByID = repository.GetCrashesByID();
            myData.NumbersOfDevices = repository.GetNumbersOfDevices();
            myData.OptionsList = repository.GetOptionsList();
            myData.Timeframe = repository.GetCrashesTimeframe();
            myData.TimeOption = repository.GetCrashesTimeOption();
            myData.TimeOptionString = repository.GetTimeOptionString();

            return myData;
        }

        public bool UpdateStripPrice(double price)
        {
            return repository.UpdateTestStripPrice(price);
        }

        public bool UpdateWorkerSalary(double salary)
        {
            return repository.UpdateWorkerSalary(salary);
        }

        public bool UpdateTimeOptionString(string timeOptionString)
        {
            return repository.UpdateTimeOptionString(timeOptionString);
        }

        public bool UpdateClinicOptionString(string clinicOptionString)
        {
            return repository.UpdateClinicOptionString(clinicOptionString);
        }

        public bool UpdateCrashTimeOptionString(string timeOptionString)
        {
            return repository.UpdateCrashTimeOptionString(timeOptionString);
        }

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