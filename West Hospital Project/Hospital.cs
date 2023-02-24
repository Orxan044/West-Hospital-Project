
namespace HospitalN
{

    internal class Hospital
    {
        public string? Hospital_Boos_NameFull;
        public string? Hospital_Name;

        public Hospital(string? hospital_Boos_NameFull, string? hospital_Name)
        {
            Hospital_Boos_NameFull = hospital_Boos_NameFull;
            Hospital_Name = hospital_Name;
        }

        public void HospitalLogo()
        {
            string west = @"

                            ██╗  ██╗ ██████╗ ███████╗██████╗ ██╗████████╗ █████╗ ██╗     
                            ██║  ██║██╔═══██╗██╔════╝██╔══██╗██║╚══██╔══╝██╔══██╗██║     
                            ███████║██║   ██║███████╗██████╔╝██║   ██║   ███████║██║     
                            ██╔══██║██║   ██║╚════██║██╔═══╝ ██║   ██║   ██╔══██║██║     
                            ██║  ██║╚██████╔╝███████║██║     ██║   ██║   ██║  ██║███████╗
                            ╚═╝  ╚═╝ ╚═════╝ ╚══════╝╚═╝     ╚═╝   ╚═╝   ╚═╝  ╚═╝╚══════╝                                             
            ";
            Console.WriteLine(west);

        }
    }
};
