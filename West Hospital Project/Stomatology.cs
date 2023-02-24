using Departments;
using Doctors;
using MyExceptuinN;
using Newtonsoft.Json;

namespace Stomatology_dp
{
    internal class Stomatology : Department
    {
        public bool CryingMachine;

        public Stomatology(string? department_Name, bool CryingMachine)
        : base("Stomatology")
        {
            this.CryingMachine = CryingMachine;
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

        public void JsonToList()
        {

            string path = AppDomain.CurrentDomain.BaseDirectory[..^17] + @"JsonFiles\StomatologyDoctor.json";
            string StomatologyJson = File.ReadAllText(path);

            List<Stomatology>? doctors = JsonConvert.DeserializeObject<List<Stomatology>>(StomatologyJson);

            foreach (Stomatology doctor in doctors)
                doctors.Add(doctor);
        }
    }


}

