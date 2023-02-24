using Departments;
using MyExceptuinN;

enum DoctorRanks { Doctor, Specialist_Doctor, Chief_Doctor }


namespace Doctors
{

    internal class Doctor
    {
        static int selectedIndex = 0;

        public string? DoctorName;
        public string? DoctorSurname;
        public int DoctorExperience;
        public DoctorRanks? DoctorRanks;
        public Department DoctorDepartment;
        public Dictionary<DateTime, List<string>> Rezervs { get; set; } = new();

        public Doctor(string? doctorName, string? doctorSurname, int doctorExperience, DoctorRanks? doctorRanks, Department department)
        {
            DoctorName = doctorName;
            DoctorSurname = doctorSurname;
            DoctorExperience = doctorExperience;
            DoctorRanks = doctorRanks;
            DoctorDepartment = department;
        }


        public override string ToString() => $@"Doctor Name > {DoctorName}
Doctor Surname -> {DoctorSurname}
Doctor Experience -> {DoctorExperience}
Doctor Ranks -> {DoctorRanks}
Doctor Department -> {DoctorDepartment}
";


        protected void Calendar()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\t\tPlease Enter The Date in This Windows, Enter It Correctly !!!\n\n");
            Console.ForegroundColor = ConsoleColor.White;
            DateTime date = DateTime.Now;
            Console.WriteLine($"Mo Tu We Th Fr Sa Su\t\t\t\t\t\t{DateTime.Now}");

            int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            int firstDayOfWeek = (int)date.AddDays(1 - date.Day).DayOfWeek;

            for (int i = 0; i < firstDayOfWeek; i++) Console.Write("   ");
            for (int i = 1; i <= daysInMonth; i++)
            {
                Console.Write($"{i,2} ");
                if ((i + firstDayOfWeek) % 7 == 0 || i == daysInMonth) Console.WriteLine();
            }

        }



        protected void ChooiseHour(DateTime date)
        {

            while (true)
            {
                bool control = true;
                bool @break = false;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n\t\t\tDoctor's hours \n");
                Console.ForegroundColor = ConsoleColor.White;
                string[] menuItems = { $"09:00 - 11:00", $"12:00 - 14:00", $"15:00 - 17:00" };

                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        if (Rezervs.ContainsKey(date) && Rezervs[date].Contains(menuItems[selectedIndex]))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"<< {menuItems[i]} Reserved >>");
                        }
                        else Console.WriteLine($"<< {menuItems[i]} Not Reserved >>");


                        Console.ResetColor();
                    }
                    else Console.WriteLine(" " + menuItems[i]);

                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        Console.Clear();
                        selectedIndex = Math.Max(0, selectedIndex - 1);
                        break;

                    case ConsoleKey.DownArrow:
                        Console.Clear();
                        selectedIndex = Math.Min(menuItems.Length - 1, selectedIndex + 1);
                        break;

                    case ConsoleKey.Enter:
                        try
                        {
                            if (!Rezervs.ContainsKey(date)) Rezervs[date] = new();
                            if (selectedIndex == 0 && !Rezervs[date].Contains("09:00 - 11:00"))
                            {
                                Rezervs[date].Add("09:00 - 11:00");
                                control = false;
                            }
                            else if (selectedIndex == 1 && !Rezervs[date].Contains("12:00 - 14:00"))
                            {
                                Rezervs[date].Add("12:00 - 14:00");
                                control = false;
                            }
                            else if (selectedIndex == 2 && !Rezervs[date].Contains("15:00 - 17:00"))
                            {
                                Rezervs[date].Add("15:00 - 17:00");
                                control = false;
                            }
                            if (control)
                            {
                                if (selectedIndex == 0) throw new MyException("The Time You Enter is Reserved");
                                if (selectedIndex == 1) throw new MyException("The Time You Enter is Reserved");
                                if (selectedIndex == 2) throw new MyException("The Time You Enter is Protected");
                            }
                            else
                            {
                                @break = true;
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine($"\n\n\n\tDear Person, You have Booked {DoctorRanks}.{DoctorName} {DoctorSurname} on {date} o'clock. " +
                                    $"\n\n\tPlease be at the hospital ahead of time. Contact the hospital at *4444");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("\n\n\n\t\t\t\t\t<< Press to Any Key >>");
                                Console.ReadKey();


                            }
                        }
                        catch (MyException ex)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"\n\n\t\t\t\t\t{ex.Message}");
                            Thread.Sleep(1500);
                            Console.Clear();
                            ChooiseHour(date);

                        }
                        break;
                }
                if (@break) break;

            }

        }

        public void Rezerv()
        {
            DateTime date;
            Calendar();
            try
            {
                Console.Write("\n\nEnter the date in the format 'yyyy.MM.dd': ");
                string? dateString = Console.ReadLine();
                if (DateTime.TryParseExact(dateString, "yyyy.MM.dd", null, System.Globalization.DateTimeStyles.None, out date))
                {
                    Console.Clear();
                    if (Rezervs.ContainsKey(date) && (Rezervs[date].Contains("09:00 - 11:00") && Rezervs[date].Contains("12:00 - 14:00") && Rezervs[date].Contains("15:00 - 17:00")))
                    {
                        throw new MyException("The Choosen Day is Fully Reserved!");
                    }
                    else if (date <= DateTime.Now)
                    {
                        throw new ArgumentException("The date input is from the past.");
                    }
                    ChooiseHour(date);
                }
                else throw new ArgumentException("Invalid Date Format");
            }
            catch (ArgumentException ex)
            {

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n\n\t\t\t\t\t{ex.Message}");
                Thread.Sleep(1500);
                Rezerv();
                Console.Clear();
            }
            catch (MyException ex1)
            {

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n\n\t\t\t\t\t{ex1.Message}");
                Thread.Sleep(1500);
                Rezerv();
                Console.Clear();
            }

        }

    }

};

