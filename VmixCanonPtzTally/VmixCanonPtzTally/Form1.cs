namespace VmixCanonPtzTally
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formInformation = new FormInformation();
            formInformation.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Are you sure you want to exit? \nThis will stop the connection and switch off tallys", "Exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes) {
                Application.Exit();
                // TODO: ON APPLICATION EXIT, ALWAYS SWITCH OFF TALLYS
            }
        }
    }
}
