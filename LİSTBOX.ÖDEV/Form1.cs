namespace LİSTBOX.ÖDEV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text);
            listBox2.Items.Add(textBox2.Text);
            listBox3.Items.Add(textBox3.Text);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ind;
            ind = listBox1.SelectedIndex;
            if (ind < 0)
            {
                MessageBox.Show("Önce silinecek elemanı seçin");

            }

            else
            {
                listBox1.Items.RemoveAt(ind);
                listBox2.Items.RemoveAt(ind);
                listBox3.Items.RemoveAt(ind);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            listBox2.SelectedIndexChanged += new EventHandler(listBox1_SelectedIndexChanged);
            listBox3.SelectedIndexChanged += new EventHandler(listBox1_SelectedIndexChanged);


            try
            {

                System.IO.TextReader bilgi = System.IO.File.OpenText("bilgi.dat");
                string satır;

                while ((satır = bilgi.ReadLine()) != null)
                {
                    listBox1.Items.Add(satır);
                    satır = bilgi.ReadLine();
                    listBox2.Items.Add(satır);
                    satır = bilgi.ReadLine();
                    listBox3.Items.Add(satır);

                }
                bilgi.Close();
            }
            catch
            {
                ;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ind;
            ind = (sender as ListBox).SelectedIndex;

            listBox1.SelectedIndex = ind;
            listBox2.SelectedIndex = ind;
            listBox3.SelectedIndex = ind;
            int Top_ind;
            Top_ind = (sender as ListBox).TopIndex;

            listBox1.TopIndex = Top_ind;
            listBox2.TopIndex = Top_ind;
            listBox3.TopIndex = Top_ind;


            textBox1.Text = listBox1.Text;
            textBox2.Text = listBox2.Text;
            textBox3.Text = listBox3.Text;

        }
        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            System.IO.TextWriter bilgi = System.IO.File.CreateText("bilgi.dat");

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                bilgi.WriteLine(listBox1.Items[i]);
                bilgi.WriteLine(listBox2.Items[i]);
                bilgi.WriteLine(listBox3.Items[i]);
            }

            bilgi.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}