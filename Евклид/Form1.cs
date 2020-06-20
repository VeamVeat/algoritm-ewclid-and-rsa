using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Numerics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Евклид
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int val1 = Convert.ToInt32(textBox1.Text);
            int val2 = Convert.ToInt32(textBox2.Text);
            label13.Text = GetNod(val1, val2).ToString();

        }

        public int GetNod(int val1, int val2)
        {
            while ((val1 != 0) && (val2 != 0))
            {
                if (val1 > val2)
                    val1 -= val2;
                else
                    val2 -= val1;

            }
            return Math.Max(val1, val2);

        }
        public int GetNodResurs(int val3, int val4)
        {
            if (val4 == 0)
                return val3;
           
            else
                return GetNodResurs(val4, val3 % val4);
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            int val1 = Convert.ToInt32(textBox3.Text);
            int val2 = Convert.ToInt32(textBox4.Text);
            label21.Text = GetNodResurs(val1, val2).ToString();

        }

        private void Button3_Click(object sender, EventArgs e)
        {

            int val1 = Convert.ToInt32(textBox5.Text);
            int val2 = Convert.ToInt32(textBox6.Text);
            int val4 = val1, val5 = val2, val3, count = 1;

            while ((val1 != 0) && (val2 != 0))
            {
                val3 = val1 % val2;
                val1 = val2;
                val2 = val3;
                count++;
                if (val2 == 0)
                    count++;
            }

            int Coll = 5;
            int Row = count;
            int[,] array = new int[Row, Coll];
            array[0, 2] = val4;
            array[1, 2] = val5;
            array[0, 3] = 1;
            array[0, 4] = 0;
            array[1, 3] = 0;
            array[1, 4] = 1;
            textBox7.Text += "i" + "     " + "qi" + "     " + "ai" + "     " + "xi" + "     " + "yi";
            textBox7.Text += Environment.NewLine;
            for (int i = 0; i < Row; i++)
            {
                array[i, 0] = i;
                if (i <= Row - 3)
                    array[i + 1, 1] = array[i, 2] / array[i + 1, 2];

                if (i <= Row - 4)
                    array[i + 2, 2] = array[i, 2] - (array[i + 1, 1] * array[i + 1, 2]);

                if (i <= Row - 4)
                {
                    array[i + 2, 3] = array[i, 3] - (array[i + 1, 1] * array[i + 1, 3]);
                    array[i + 2, 4] = array[i, 4] - (array[i + 1, 1] * array[i + 1, 4]);
                }

                for (int j = 0; j < Coll; j++)
                {
                    textBox7.Text += array[i, j].ToString() + "     ";
                }
                textBox7.Text += Environment.NewLine;
            }
            label16.Text = array[Row - 2, 2].ToString();
            label22.Text = array[Row - 2, 3].ToString();
            label23.Text = array[Row - 2, 4].ToString();
            label20.Text = "  " + "(" + val4.ToString() + " * " + array[Row - 2, 3].ToString() + ")" + " + "
                + "(" + val5.ToString() + " * " + array[Row - 2, 4].ToString() + ")" + " = " + array[Row - 2, 2].ToString();

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();

        }


        async private void PictureBox1_Click(object sender, EventArgs e)
        {
            for (int i = 122; i < 354; i += 12)
            {

                ClientSize = new Size(480, i);
                await Task.Delay(1);
            }
        
        }

        async private void PictureBox3_Click(object sender, EventArgs e)
        {
            for (int i = 352; i > 112; i -= 10)
            {

                ClientSize = new Size(480, i);
                await Task.Delay(1);
            }
           
        }


        string IshodText = @"Исходный текст.txt";
        string ShifrovText = @"Зашифрованый текст.txt";
        string ShifrovTextSave = @"Зашифрованый текст.txt";
        string IshodTextSave = @"Исходный текст.txt";
        string linese = "";

        private void Button7_Click(object sender, EventArgs e)
        {
            using (FileStream file = new FileStream(IshodText, FileMode.OpenOrCreate))
            {
                using (StreamReader red = new StreamReader(file, System.Text.Encoding.Default))
                {
                    while ((linese = red.ReadLine()) != null)
                    {

                        textBox10.Text += linese + Environment.NewLine;

                    }
                }
            }
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            File.Create(IshodText).Close();
            using (FileStream files = new FileStream(IshodTextSave, FileMode.OpenOrCreate))
            {
                using (StreamWriter wr = new StreamWriter(files, System.Text.Encoding.Default))
                {

                    wr.WriteLine(textBox10.Text);
                }
            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            using (FileStream file = new FileStream(ShifrovText, FileMode.OpenOrCreate))
            {
                using (StreamReader str = new StreamReader(file, System.Text.Encoding.Default))
                {
                    while (!str.EndOfStream)
                    {
                        textBox11.Text += str.ReadLine() + Environment.NewLine;

                    }
                }
            }
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            File.Create(ShifrovText).Close();
            using (FileStream files = new FileStream(ShifrovTextSave, FileMode.OpenOrCreate))
            {
                using (StreamWriter write = new StreamWriter(files, System.Text.Encoding.Default))
                {
                    write.WriteLine(textBox11.Text);
                }
            }
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            textBox10.Clear();
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            textBox11.Clear();
        }
        public char[] Alfavit = { '#', 'А', 'Б', 'В', 'Г', 'Д', 'Е',
            'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р',
            'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ',
            'Э', 'Ю', 'Я', 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з',
            'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у',
            'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ь', 'ы', 'ъ', 'э', 'ю', 'я',
            '!', '"', '@', '№', '#', '$', ';', '%',' ', '—', ':', '~', '&',
            '*', '(', ')', '_', '-', '+', '=', '{', '}', '[', ']', '\\',
            '|', '/', ':', ';', ',', '.', '>', '<', '?' };

        private void Button5_Click(object sender, EventArgs e)
        {
            long p = Convert.ToInt64(textBox8.Text);
            long q = Convert.ToInt64(textBox9.Text);
            if (Simple(p) && Simple(q))
            {
                long n = p * q;
                textBox13.Text = n.ToString();
                long d = Bnumber(p, q);
                textBox12.Text = d.ToString();
                long Enum = Enumber(p, q, d);
                //textBox7.Text = Enum.ToString();
                string IshodTexte = textBox10.Text;
                BigInteger Index;
                for (int i = 0; i < IshodTexte.Length; i++)
                {
                    for (int j = 0; j < Alfavit.Length; j++)
                    {

                        if (IshodTexte[i] == Alfavit[j])
                        {
                            Index = new BigInteger(j);
                            Index = BigInteger.Pow(Index, (int)Enum);
                            BigInteger Nn = new BigInteger((int)n);
                            Index = Index % Nn;
                            textBox11.Text += Index.ToString();
                            textBox11.Text += Environment.NewLine;
                        }

                    }

                }
                using (FileStream files = new FileStream(ShifrovTextSave, FileMode.OpenOrCreate))
                {
                    using (StreamWriter write = new StreamWriter(files, System.Text.Encoding.Default))
                    {
                        write.WriteLine(textBox11.Text);
                    }
                }
                Process.Start("Зашифрованый текст.txt");


            }
            else
            {
                MessageBox.Show("Уведомление", "Выбирете два различных случайных простых числа ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }
        public long GetNodResur(long val3, long val4)
        {
            if (val4 == 0)
            {
                return val3;
            }
            else
            {
                return GetNodResur(val4, val3 % val4);
            }
        }
        private long Bnumber(long p, long q)
        {
            long k = (p - 1) * (q - 1);
            long d = k - 1;
            long N;
            for (long i = 3; i <= d; i++)
            {
                N = GetNodResur(k, i);
                if (N == 1)
                {
                    d = i;
                    break;
                }
            }

            return d;

        }
        private bool Simple(long n)
        {
            if (n < 2) // если наше значение меньше 2 то оно ни как не может быть простым
                return false;

            if (n == 2) // если оно равно 2 то оно простое и вернуть true так 2 это самое наименьшее простое число в таблице простых чисел
                return true;

            for (long i = 2; i < n; i++) // сдесь мы проходим циклом он 2 так как это наименьшее простое число и до числа которое миы передали 
            {
                if (n % i == 0)// и если остаток от деление переданного значения в функцию на i будет равен 0 , тоесть оно будет не проссто мы возращаем false 
                {
                    return false;
                } 
            }


            return true;

        }
        private long Enumber(long p, long q, long d)
        {

            long rezult = 19;
            long k = (p - 1) * (q - 1);
            //for (long i = 1; i < k; i++)
            //{
            //    if ((i * d) % k == 1)
            //    {
            //        rezult = i;
            //        break;
            //    }

            //}
            //return rezult;
            long val1 = d;
            long val2 = k;
            long val4 = val1, val5 = val2, val3, count = 1;

            while ((val1 != 0) && (val2 != 0))
            {
                val3 = val1 % val2;
                val1 = val2;
                val2 = val3;
                count++;
                if (val2 == 0)
                    count++;
            }

            long Coll = 5;
            long Row = count;
            long[,] array = new long[Row, Coll];
            array[0, 2] = val4;
            array[1, 2] = val5;
            array[0, 3] = 1;
            array[0, 4] = 0;
            array[1, 3] = 0;
            array[1, 4] = 1;
            textBox14.Text += "i" + "     " + "qi" + "     " + "ai" + "     " + "xi" + "     " + "yi";
            textBox14.Text += Environment.NewLine;
            for (int i = 0; i < Row; i++)
            {
                array[i, 0] = i;
                if (i <= Row - 3)
                    array[i + 1, 1] = array[i, 2] / array[i + 1, 2];

                if (i <= Row - 4)
                    array[i + 2, 2] = array[i, 2] - (array[i + 1, 1] * array[i + 1, 2]);

                if (i <= Row - 4)
                {
                    array[i + 2, 3] = array[i, 3] - (array[i + 1, 1] * array[i + 1, 3]);
                    array[i + 2, 4] = array[i, 4] - (array[i + 1, 1] * array[i + 1, 4]);
                }

                for (int j = 0; j < Coll; j++)
                {
                    textBox14.Text += array[i, j].ToString() + "     ";
                }
                textBox14.Text += Environment.NewLine;
            }

            label31.Text = array[Row - 2, 3].ToString();
           // label23.Text = array[Row - 2, 4].ToString();
            rezult = array[Row - 2, 3];
            if (rezult < 0)
            {
                rezult *= (-1);
            }
            return rezult ;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            long N = Convert.ToInt32(textBox13.Text);
            long D = Convert.ToInt32(textBox12.Text);

            long line;

            using (FileStream file = new FileStream(ShifrovText, FileMode.OpenOrCreate))
            {
                using (StreamReader red = new StreamReader(file, System.Text.Encoding.Default))
                {

                    BigInteger Number;
                    while (!red.EndOfStream)
                    {
                        try
                        {

                            line = Convert.ToInt32(red.ReadLine());
                            Number = BigInteger.Pow(line, (int)D);
                            Number = (Number % N);
                            textBox10.Text += Alfavit[(int)Number].ToString();

                        }
                        catch
                        {
                            break;
                        }

                    }
                }
            }

        }

        async private void PictureBox2_Click(object sender, EventArgs e)
        {
            for (int i = 350; i <= 710; i += 10)
            {
                ClientSize = new Size(480, i);
                await Task.Delay(1);
            }
            //479, 352
        }

        async private void PictureBox4_Click(object sender, EventArgs e)
        {
            for (int i = 705; i >= 355; i -=10 )
            {
                ClientSize = new Size(479, i);
                await Task.Delay(1);
            }
            //479, 705
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
