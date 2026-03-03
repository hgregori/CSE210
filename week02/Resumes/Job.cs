 public class Job
    {
        public string _company;
        public string _jobTitle;
        public int _startYear;
        public int _endYear;

        // Each class is responsible for displaying itself.
        public void Display()
        {
            Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
        }
    }