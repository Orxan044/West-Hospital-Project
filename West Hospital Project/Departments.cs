using Doctors;


//Burada Department Abstract Classdir !!!!!

namespace Departments
{

    internal abstract class Department
    {
        public string? Department_Name;
        public List<Doctor> Doctors;

        public Department(string department_Name)
        {
            Department_Name = department_Name;
            Doctors = new List<Doctor>();
        }
        public abstract void AddDoctor(Doctor doctor);  //abstract metod
        public abstract void RemoveDoctor(Doctor doctor);  //abstract metod

        public override string ToString() => $@"{Department_Name}";

        public abstract void DoctorsPrint(); //abstract metod



    }

};

