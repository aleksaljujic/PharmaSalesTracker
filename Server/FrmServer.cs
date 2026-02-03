using Common.Communication;

namespace Server
{
    public partial class FrmServer : Form
    {
        private Server server;
        private JsonNetworkSerializer serializer;
        private bool statusServera = false;
        public FrmServer()
        {
            InitializeComponent();
            server = new Server();

            // Dodaj kolonu programski ako nemaš u Designer-u
            if (dgvKlijenti.Columns.Count == 0)
            {
                dgvKlijenti.Columns.Add("colInfo", "Informacije o klijentu");
            }
        }



        private void FrmServer_Load(object sender, EventArgs e)
        {
            if (statusServera)
            {
                lbStatus.Text = "Status: Server je pokrenut";
            }
            else
            {
                lbStatus.Text = "Status: Server nije pokrenut";
            }
        }

        private void btnPokreni_Click(object sender, EventArgs e)
        {
            if (statusServera)
            {
                MessageBox.Show("Server je već pokrenut!");
                return;
            }
            server.Start();
            statusServera = true;
            server.OnBrojKlijenata += AzurirajUI;
            lbStatus.Text = "Status: Server je pokrenut";
        }

        private void AzurirajUI(int brojac)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => AzurirajUI(brojac)));
                return;
            }

            tbBrojac.Text = brojac.ToString();

            List<string> listaKlijenata = server.VratiListuKlijenata();

            dgvKlijenti.Rows.Clear();

            foreach (string info in listaKlijenata)
            {
                dgvKlijenti.Rows.Add(info);
            }
        }

        private void btnZaustavi_Click(object sender, EventArgs e)
        {
            if (!statusServera)
            {
                MessageBox.Show("Server nije pokrenut!");
                return;
            }

            server.OnBrojKlijenata -= AzurirajUI;
            server.Stop();
            statusServera = false;

            dgvKlijenti.Rows.Clear();
            tbBrojac.Text = "0";
            lbStatus.Text = "Status: Server nije pokrenut";
        }

        private void tbBrojac_TextChanged(object sender, EventArgs e)
        {
            dgvKlijenti.Rows.Clear();

            List<string> listaKlijenata = server.VratiListuKlijenata();

            dgvKlijenti.Rows.Clear();

            foreach (string info in listaKlijenata)
            {
                dgvKlijenti.Rows.Add(info);
            }
        }

    }
}
