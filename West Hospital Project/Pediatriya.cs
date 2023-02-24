using Doctors;
using Departments;
using MyExceptuinN;

namespace Pediatriya_dp
{
    internal class Pediatriya : Department
    {
        public int NumberOfPediatricBeds { get; set; }
        public Pediatriya(string? department_Name, int numberOfPediatricBeds)
            : base("Pediatrics")
        {
            NumberOfPediatricBeds = numberOfPediatricBeds;
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
