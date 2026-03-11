using Microsoft.VisualBasic.Logging;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GUI2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            txtSentences.Text = Properties.Settings.Default.txtSentences.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = "";

            try
            {
                text = this.txtSentences.Text;

                if (string.IsNullOrEmpty(text))
                {
                    throw new ArgumentNullException("", "Строка пуста.\n");
                }
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Properties.Settings.Default.txtSentences = text;
            string result = Logic.PercenageOfLetters(text);

            MessageBox.Show(result);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.txtSentences = this.txtSentences.Text;
            Properties.Settings.Default.Save();
        }
    }
    public class Logic
    {
        public static string PercenageOfLetters(string text)
        {
            int letterCount = 0;
            double percentage;
            string result = "";

            foreach (char symbol in text)
            {
                if (char.IsLetter(symbol))
                {
                    letterCount++;
                }
            }

            percentage = Math.Round((double)letterCount / text.Length * 100, 2);

            result = $"Доля букв: {percentage}%";

            return result;
        }
    }
}
