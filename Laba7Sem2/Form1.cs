using Logic;
namespace Laba7Sem2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && Convert.ToInt32(textBox2.Text) > 0)
            {
                string gentext = await Logic.Logic.GenerateText(Convert.ToInt32(textBox2.Text));
                this.Invoke((MethodInvoker)delegate
                {
                    textBox1.Text += gentext;
                });
            }
            else
            {
                MessageBox.Show("Неправильный формат данных");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            string aboba = await Logic.Logic.ReadOrCreateFileAsync();
            textBox3.Text = aboba;
        }



        private async void button4_Click(object sender, EventArgs e)
        {
            await Logic.Logic.WriteToFileAsync(this.textBox3.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox3.Text = string.Empty;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox3.Text += textBox1.Text;
            textBox1.Text = string.Empty;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += textBox3.Text;
            textBox3.Text = string.Empty;
        }
    }
}

