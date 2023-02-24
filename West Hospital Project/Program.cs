using MyExceptuinN;
using HospitalN;
using Doctors;
using Departments;
using Pediatriya_dp;
using Traumatology_dp;
using Stomatology_dp;
using PatientN;
using StringExtN;

class Hospital_Project
{
    static int selectedIndex = 0;
    static void Main()
    {

        /// -------------- Deyisenler ---------------------

        string? nameDaxil = "";
        string? surnameDaxil = "";
        string? emailDaxil = "";
        string? phoneDaxil = "";
        List<Doctor> DoctorsMenyu = new List<Doctor>();
        Doctor dateDoctor;
        /// ------------------------------------------------

        Hospital hospital = new Hospital("Orxan Huseynov", "West");

        List<Department> AllDepartment = new List<Department>(); // Butun Departmentler

        Department Pediatrics = new Pediatriya("Pediatrics", 5); // Pediatr
        AllDepartment.Add(Pediatrics);

        Department Traumatology = new Traumatology("Traumatology", true, true); // Tramatolgiya
        AllDepartment.Add(Traumatology);

        Department Stomatology = new Stomatology("Stomatology", true); //Stomolgiya
        AllDepartment.Add(Stomatology);

        Doctor Ali = new("Ulviyye", "Aliyeva", 9, DoctorRanks.Chief_Doctor, Pediatrics);
        Doctor Murad = new("Fexreddin", "Gulmemmedov", 12, DoctorRanks.Specialist_Doctor, Pediatrics);

        Pediatrics.AddDoctor(Ali);
        Pediatrics.AddDoctor(Murad);

        Doctor Tosu = new("Tosu", "Zengilaniski", 15, DoctorRanks.Doctor, Traumatology);
        Doctor Balaeli = new("Balaeli", "Mastagali", 3, DoctorRanks.Specialist_Doctor, Traumatology);

        Traumatology.AddDoctor(Tosu);
        Traumatology.AddDoctor(Balaeli);

        Doctor Akif = new("Akif", "Akifov", 1, DoctorRanks.Doctor, Stomatology);
        Doctor Turqut = new("Turqut", "Aliyev", 2, DoctorRanks.Doctor, Stomatology);

        Stomatology.AddDoctor(Akif);
        Stomatology.AddDoctor(Turqut);


        Patient newPatient = new(); //bos patient yaradilib sonra ise metodun icinde doldurulur


        main_menyu(hospital, ref nameDaxil, ref surnameDaxil, ref emailDaxil, ref phoneDaxil, newPatient, AllDepartment, DoctorsMenyu);


    }

    static void GreatPaitent(ref string? nameDaxil, ref string? surnameDaxil, ref string? emailDaxil, ref string? numberDaxil, Patient newPatient)
    {
        try
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("* Name -> ");
            Console.ForegroundColor = ConsoleColor.Blue;
            string? Namedaxil = Console.ReadLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("* Surname -> ");
            Console.ForegroundColor = ConsoleColor.Blue;
            string? Surnamedaxil = Console.ReadLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("E Mail -> ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string? emaildaxil = Console.ReadLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("* Phone -> ");
            Console.ForegroundColor = ConsoleColor.Green;
            string? Telfondaxil = Console.ReadLine();
            if (Namedaxil?.Substring(0, 1) == " " || Surnamedaxil?.Substring(0, 1) == " " || Telfondaxil?.Substring(0, 1) == " ")
            {
                throw new MyException("Not fully loaded!!! Cannot Be The First Space");
                throw new ArgumentOutOfRangeException();
            }

            else if (StringExt.IsAlpha(Namedaxil) == false || StringExt.IsAlpha(Surnamedaxil) == false || StringExt.IsNumeric(Telfondaxil) == false)
            { throw new MyException("Please Enter Correct !!!!"); }

            newPatient = new Patient(Namedaxil, Surnamedaxil, emaildaxil, Telfondaxil);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\n\n\t\t\t\tRegistration Complete ...");
            Thread.Sleep(1500);
        }
        catch (ArgumentOutOfRangeException ex1)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n\n\n\n\t\t\t\t{ex1.Message}");
            Thread.Sleep(1500);
            GreatPaitent(ref nameDaxil, ref surnameDaxil, ref emailDaxil, ref numberDaxil, newPatient);


        }
        catch (MyException ex)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n\n\t\t\t\t\t{ex.Message}");
            Thread.Sleep(1500);
            GreatPaitent(ref nameDaxil, ref surnameDaxil, ref emailDaxil, ref numberDaxil, newPatient);
        }

    }

    static void ChooseDepertment(ref List<Department> departments, List<Doctor> DoctorsMenyu)
    {

        selectedIndex = 0;
        string text = "  Thank you for REGISTERING, Select a department and immediately select a doctor working in the department";
        while (true)
        {
            bool @break = false;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < departments.Count; i++)
            {
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("<< " + departments[i] + " >>");
                    Console.ResetColor();
                }
                else Console.WriteLine(" " + departments[i]);

            }

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex = Math.Max(0, selectedIndex - 1);
                    break;

                case ConsoleKey.DownArrow:
                    selectedIndex = Math.Min(departments.Count - 1, selectedIndex + 1);
                    break;

                case ConsoleKey.Enter:
                    @break = true;
                    DoctorsMenyu.Clear();
                    for (int i = 0; i < departments[selectedIndex].Doctors.Count; i++) DoctorsMenyu.Add(departments[selectedIndex].Doctors[i]);
                    break;

            }
            if (@break) break;
        }

    }

    static void ChooseDoctors(List<Doctor> DoctorsMenuyu, Patient patient)
    {
        selectedIndex = 0;
        string text = "\t\t\t\tDoctors of the departments of your choice !!! " +
            "\n\n\tDoctors are informed and if you have any questions after deciding on a booking, please contact *4444.";
        while (true)
        {
            bool @break = false;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < DoctorsMenuyu.Count; i++)
            {
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("> " + DoctorsMenuyu[i]);
                    Console.ResetColor();
                }
                else Console.WriteLine(" " + DoctorsMenuyu[i]);

            }

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex = Math.Max(0, selectedIndex - 1);
                    Console.WriteLine();
                    break;

                case ConsoleKey.DownArrow:
                    selectedIndex = Math.Min(DoctorsMenuyu.Count - 1, selectedIndex + 1);
                    Console.WriteLine();
                    break;

                case ConsoleKey.Enter:
                    @break = true;
                    Console.Clear();
                    DoctorsMenuyu[selectedIndex].Rezerv();
                    break;
            }
            if (@break) break;
        }
    }


    static void main_menyu(Hospital hospital, ref string? nameDaxil, ref string? surnameDaxil, ref string? emailDaxil, ref string? numberDaxil,
        Patient newPatient, List<Department> departments, List<Doctor> DoctosMenyu)
    {
        string[] menuItems = { "\n\n\n\n\n\t\t\t\t\t\t\b\b<< Registration >>", "\t\t\t\t\t\t\b\b\b\b<< About The Hospital >>" };
        while (true)
        {
            Console.Clear();
            hospital.HospitalLogo();
            Console.ForegroundColor = ConsoleColor.Yellow;
            string text = "      Welcome , You can Register and make an appointment or get information about the Hospital and our Doctors";
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < menuItems.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(menuItems[i]);
                    Console.ResetColor();
                }
                else Console.WriteLine("  " + menuItems[i]);

            }

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex = Math.Max(0, selectedIndex - 1);
                    break;

                case ConsoleKey.DownArrow:
                    selectedIndex = Math.Min(menuItems.Length - 1, selectedIndex + 1);
                    break;

                case ConsoleKey.Enter:
                    if (selectedIndex == 0)
                    {
                        Console.Clear();
                        GreatPaitent(ref nameDaxil, ref surnameDaxil, ref emailDaxil, ref numberDaxil, newPatient);
                        ChooseDepertment(ref departments, DoctosMenyu);
                        ChooseDoctors(DoctosMenyu, newPatient);
                        main_menyu(hospital, ref nameDaxil, ref surnameDaxil, ref emailDaxil, ref numberDaxil, newPatient, departments, DoctosMenyu);
                    }
                    else if (selectedIndex == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("\t\t\t\t\tWelcome\n\n");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"Hospital Name -> {hospital.Hospital_Name} Hospital\n");
                        Console.WriteLine($"Hospital Boss NameFull -> {hospital.Hospital_Boos_NameFull}\n");
                        Console.WriteLine($"Hospital Contact -> *4444\n");
                        Console.WriteLine($"Hospital Instegram -> west_hospital \n\n\n");
                        Console.ForegroundColor = ConsoleColor.Red;
                        string text2 = "\t\t\t\tWe Have Been Working For You For 4 Years";
                        for (int i = 0; i < text2.Length; i++)
                        {
                            Console.Write(text2[i]);
                            Thread.Sleep(10);
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\n\n\nPress to Any Key");
                        Console.ReadKey();

                    }
                    break;
            }
        }
    }
}

