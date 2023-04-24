using System;

namespace Coding_Test
{
    public class Employee
    {

        private long _id;
        private string _name;
        private DateTime _dob;
        private long _employeeId;
        private string _designation;
        private DateTime _doj;
        private string _photo;

        [System.Text.Json.Serialization.JsonIgnore]
        public long Id
        {
            get => _id;

            set { _id = value; }
        }

        public string Name
        {
            get => _name;

            set { _name = value; }

        }

        public DateTime DoB
        {
            get => _dob;

            set { _dob = value; }
        }

        public long EmployeeId
        {
            get => _employeeId;

            set { _employeeId = value; }
        }

        public string Designation
        {
            get => _designation;

            set { _designation = value; }
        }

        public DateTime DoJ
        {
            get => _doj;

            set { _doj = value; }
        }

        public string Photo
        {
            get => _photo;

            set { _photo = value; }
        }
    }
}