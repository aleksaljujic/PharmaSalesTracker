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
            Test test = new Test();

            //.PokretanjeServera();
            //test.PokretanjeServera();
            //test.SimulacijaKlijenta();
            //test.SimulacijaKlijenta();
            //test.SimulacijaLogin();
            //test.TestPrikaziSmenePrekoServera(2);
            //Console.WriteLine("Dodavanje smene za apotekara sa ID 2...");
            //test.TestDodajSmenu(2);
            //test.TestPrikaziSmenePrekoServera(2);
            //Console.WriteLine("Prikaz kupaca:");
            //test.TestPrikaziKupce();
            //Console.WriteLine("Dodavanje kupca:");
            //test.TestDodajKupca();
            //Console.WriteLine("Prikaz kupaca nakon dodavanja:");
            //test.TestPrikaziKupce();
            //test.ZaustavljanjeServera();
            //Console.ReadKey();

            // PRIKAZ FORME:
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmServer());
        }
    }
}