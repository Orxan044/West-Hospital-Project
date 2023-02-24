
using Newtonsoft.Json;
using System.Collections;


namespace PatientN
{
    internal class Patient
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? E_mail { get; set; }
        public string? PhoneNumber { get; set; }
        public object Json { get; private set; }

        public Patient() { }

        public Patient(string? name, string? surname, string? e_mail, string? phoneNumber)
        {
            Name = name;
            Surname = surname;
            E_mail = e_mail;
            PhoneNumber = phoneNumber;
        }

        class Users : IEnumerable<Patient>
        {
            private readonly List<Patient> Userss = new();

            public void AddUser(Patient user)
            {
                bool condition = true;
                foreach (var item in Userss)
                    if (item.PhoneNumber == user.PhoneNumber || item.E_mail == user.E_mail)
                        condition = false;
                if (condition) Userss.Add(user);
                else throw new ArgumentException("Phone number or email registered you can not enter again!");
            }

            public IEnumerator<Patient> GetEnumerator() => Userss.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            public void ListToJson()
            {
                string json = JsonConvert.SerializeObject(Userss, Newtonsoft.Json.Formatting.Indented);

                string path = AppDomain.CurrentDomain.BaseDirectory[..^17] + @"JsonFiles\Patient.json";
                File.WriteAllText(path, json);
            }

            public void JsonToList()
            {
                string path = AppDomain.CurrentDomain.BaseDirectory[..^17] + @"JsonFiles\Users.json";
                string UsersJson = File.ReadAllText(path);

                List<Patient>? users = JsonConvert.DeserializeObject<List<Patient>>(UsersJson);
                if (users != null)
                {
                    foreach (Patient user in users)
                        Userss.Add(user);
                }
            }

            IEnumerator<Patient> IEnumerable<Patient>.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }
    }
}
