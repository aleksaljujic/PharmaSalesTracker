using System.Runtime.InteropServices;

namespace Server
{
    public static class Program
    {
        [DllImport("kernel32.dll")]
        static extern bool AllocConsole();

        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            AllocConsole();

            // 2. TESTIRANJE SERVERA BEZ FORME
            //Test test = new Test();

            //IzmenaKupca();
            //PrikaziApotekare();
            //PrikaziGradove();
            //PrikaziLekove();
            //PrikaziRacune();
            //PrikaziStavkeRacuna();

            // PRIKAZ FORME:
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmServer());
        }

        public static void IzmenaKupca()
        {
            Test test = new Test();
            test.PokretanjeServera();
            test.TestPrikaziKupce();
            Console.WriteLine("Izmena kupca...");
            test.TestIzmeniKupca();
            Console.WriteLine("Prikaz kupaca nakon izmene:");
            test.TestPrikaziKupce();
            test.ZaustavljanjeServera();
        }

        public static void PrikaziApotekare()
        {
            Test test = new Test();
            test.PokretanjeServera();
            test.TestPrikaziApotekare();
            test.ZaustavljanjeServera();
        }

        public static void PrikaziGradove()
        {
            Test test = new Test();
            test.PokretanjeServera();
            test.TestPrikaziGradove();
            test.ZaustavljanjeServera();
        }

        public static void PrikaziRacune()
        {
            Test test = new Test();
            test.PokretanjeServera();
            //test.TestPrikaziRacune();
            test.TestPrikaziRacun(3);
            test.ZaustavljanjeServera();
        }

        public static void PrikaziLekove()
        {
            Test test = new Test();
            test.PokretanjeServera();
            //test.TestPrikaziLekove();
            test.TestPrikaziLek(3);
            test.TestPrikaziLekID();
            test.ZaustavljanjeServera();
        }

        public static void PrikaziStavkeRacuna()
        {
            Test test = new Test();
            test.PokretanjeServera();
            test.TestPrikaziStavkeRacuna();
            test.ZaustavljanjeServera();
        }
    }
}