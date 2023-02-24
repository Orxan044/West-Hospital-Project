using Departments;
using Doctors;
using MyExceptuinN;

namespace Traumatology_dp
{
    internal class Traumatology : Department
    {
        public bool HasCTScanner { get; set; }
        public bool HasMRI { get; set; }

        public Traumatology(string? department_Name, bool hasCTScanner, bool hasMRI)
        : base("Traumatology")
        {
            HasCTScanner = hasCTScanner;
            HasMRI = hasMRI;
        }

        public override void AddDoctor(Doctor doctor) => Doctors.Add(doctor);
        public override void RemoveDoctor(Doctor doctor) => Doctors.Remove(doctor);

        public override void DoctorsPrint()
        {
            bool control = true;
            try
            {
                foreach (var item in Doctors)
                {
                    if (item.DoctorDepartment.ToString() == Department_Name)
                    {
                        control = false;
                        Console.WriteLine($"{item.ToString()}\n");
                    }
                }
                if (control) { throw new MyException("Sorry, We don't have doctors in this department"); }
            }
            catch (MyException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
