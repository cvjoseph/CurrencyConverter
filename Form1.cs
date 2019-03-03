using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SQLite;
using System.Net;
using System.Web.Script.Serialization;

namespace CurrencyConverter
{


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            doConvert();
            save_lastamount(textBoxAmount.Text);
        }
        private void doConvert()
        {
            
            textBox2.Text = CurrencyConvertLocal(decimal.Parse(textBoxAmount.Text), PrimaryCurrency.Text, textBox1.Text);
            textBox4.Text = CurrencyConvertLocal(decimal.Parse(textBoxAmount.Text), PrimaryCurrency.Text, textBox3.Text);
            textBox6.Text = CurrencyConvertLocal(decimal.Parse(textBoxAmount.Text), PrimaryCurrency.Text, textBox5.Text);
            textBox8.Text = CurrencyConvertLocal(decimal.Parse(textBoxAmount.Text), PrimaryCurrency.Text, textBox7.Text);
            textBox10.Text = CurrencyConvertLocal(decimal.Parse(textBoxAmount.Text), PrimaryCurrency.Text, textBox9.Text);
            textBox12.Text = CurrencyConvertLocal(decimal.Parse(textBoxAmount.Text), PrimaryCurrency.Text, textBox11.Text);
            this.ActiveControl = textBoxAmount;
        }

        private string CurrencyConvertLocal(decimal amount, string fromCurrency, string toCurrency)
        {
            amount = amount * Decimal.Parse(multiplier.Text);
            if (fromCurrency.Equals(toCurrency))
            {
                return (amount).ToString();
            }
            Decimal rate = get_rate(fromCurrency, toCurrency);

            Decimal newamount = (amount * rate);

            newamount = Math.Round(newamount, 2);
            return newamount.ToString();
        }

        public static string CurrencyConvert(decimal amount, string fromCurrency, string toCurrency)
        {
            if(fromCurrency.Equals(toCurrency))
            {
                return amount.ToString();
            }

            //Grab your values and build your Web Request to the API
            string apiURL = String.Format("https://www.google.com/finance/converter?a={0}&from={1}&to={2}&meta={3}", amount, fromCurrency, toCurrency, Guid.NewGuid().ToString());
            //string apiURL = String.Format("https://www.google.com/finance/converter?a={0}&from={1}&to={2}&meta={3}", amount, fromCurrency, toCurrency, Guid.NewGuid().ToString());

            string apiURL = String.Format("https://rate-exchange-1.appspot.com/currency?from={0}&to={1}", fromCurrency, toCurrency);

            //Make your Web Request and grab the results
            //var request = System.Net.WebRequest.Create(apiURL);
            WebClient client = new WebClient();

 

            //Get the Response
            //var streamReader = new System.IO.StreamReader(request.GetResponse().GetResponseStream(), System.Text.Encoding.ASCII);

            string rates = client.DownloadString(apiURL);
            Rate rate = new JavaScriptSerializer().Deserialize<Rate>(rates);

            double amt = (double)amount;

            double converted_amount = amt * rate.rate;

            //Grab your converted value (ie 2.45 USD)
            //var result = Regex.Matches(streamReader.ReadToEnd(), "<span class=\"?bld\"?>([^<]+)</span>")[0].Groups[1].Value;

            //result = result.Replace(toCurrency, "");
            //result = result.Trim();

            //Decimal d = decimal.Parse(result);
            //d= Math.Round(d,5);

            decimal d = Math.Round((decimal)converted_amount, 5);
            string result = d.ToString();

            //save_rate(fromCurrency, toCurrency, d);
            
            //Get the Result
            return result;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            set_primary(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            set_primary(textBox3.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            set_primary(textBox5.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            set_primary(textBox7.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            set_primary(textBox9.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            set_primary(textBox11.Text);
        }

        private void set_primary(String value)
        {
            PrimaryCurrency.Text = value;
            this.ActiveControl = textBoxAmount;
            textBoxAmount.Select();
        }

        private static void save_lastcurrency(String value)
        {
            save_setting("last_currency", value);
        }
        private static String get_lastcurrency()
        {
            return get_setting("last_currency");
        }

        private static void save_lastamount(String value)
        {
            save_setting("last_amount", value);
        }
        private static String get_lastamount()
        {
            return get_setting("last_amount");
        }

        private static void save_setting(String code, String value)
        {
            String s = "select count(*) from settings where code = '" + code + "'";
            try
            {

                DataTable DT = sql_run_select(s);
                if (int.Parse(DT.Rows[0].ItemArray[0].ToString()) == 0)
                {
                    s = "insert into settings (code, value)  values('" + code + "', '" + value + "')";
                    String success = sql_run_update(s);
                }
                else
                {
                    s = "update settings set value = '" + value + "' where code = '" + code + "'";
                    String success = sql_run_update(s);
                }
            }
            catch(Exception e)
            { }

        }
        private static String get_setting(String code)
        {
            String s = "select value from settings where code = '" + code + "'";
            try
            {
                DataTable DT = sql_run_select(s);
                if (DT.Rows.Count > 0)
                {
                    return DT.Rows[0].ItemArray[0].ToString();
                }
                else
                {
                    return "";
                }
            }
            catch(Exception e)
            {
                return "";
            }
        }

        private static void save_rate(String from, String to, Decimal rate)
        {
            String s = "select count(*) from rates where from_currency = '" + from + "' and to_currency = '" + to + "'";
            DataTable DT = sql_run_select(s);
            if (int.Parse(DT.Rows[0].ItemArray[0].ToString()) == 0)
            {
                s = "insert into rates (from_currency,to_currency,rate)  values('" + from + "', '" + to + "'," +  rate + ")";
                String success = sql_run_update(s);
            }
            else
            {
                s = "update rates set rate = " + rate + " where from_currency = '" + from + "' and to_currency = '" + to + "'";
                String success = sql_run_update(s);
            }
        }
        private static Decimal get_rate(String from, String to)
        {
            String s = "select rate*100000 from rates where from_currency = '" + from + "' and to_currency = '" + to + "'";
            DataTable DT = sql_run_select(s);
            if (DT.Rows.Count == 0)
            {
                return 0;
            }
            return Decimal.Parse(DT.Rows[0].ItemArray[0].ToString())/100000;
        }

        private static void save_currency(int pos, String code)
        {
            String s = "select count(*) from currencies where position = " + pos;
            DataTable DT = sql_run_select(s);
            if (int.Parse(DT.Rows[0].ItemArray[0].ToString()) == 0)
            {
                s = "insert into currencies (position, code)  values(" + pos + ", '" + code + "')";
                String success = sql_run_update(s);
            }
            else
            {
                s = "update currencies set code = '" + code + "' where position = " + pos;
                String success = sql_run_update(s);
            }
        }
        private static String get_currency(int pos)
        {
            String s = "select code from currencies where position = " + pos;
            try
            {
                DataTable DT = sql_run_select(s);
                if (DT.Rows.Count > 0)
                {
                    return DT.Rows[0].ItemArray[0].ToString();
                }
                else
                {
                    return "";
                }
            }
            catch(Exception e)
            {
                return "";
            }
        }
        


        private static DataTable sql_run_select(String str)
        {
            SQLiteConnection sql_con;
            SQLiteCommand sql_cmd;
            SQLiteDataAdapter DB;
            DataSet DS = new DataSet();
            DataTable DT = new DataTable();

            sql_con = new SQLiteConnection("Data Source=settings.db3;Version=3;New=False;Compress=True;");
            sql_con.Open();

            string CommandText = str;
            DB = new SQLiteDataAdapter(CommandText, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            //dataGridView1.DataSource = DT;
            sql_con.Close();
            
            return DT;

        }
        private static String sql_run_update(String str)
        {
            SQLiteConnection sql_con;
            SQLiteCommand sql_cmd;
            SQLiteDataAdapter DB;
            DataSet DS = new DataSet();
            DataTable DT = new DataTable();
            String returnv;

            sql_con = new SQLiteConnection("Data Source=settings.db3;Version=3;New=False;Compress=True;");
            sql_con.Open();

            sql_cmd = sql_con.CreateCommand();
            try
            {
                sql_cmd.CommandText = str;
                sql_cmd.ExecuteNonQuery();
                //textBox4.Text = sql_cmd.CommandText + " : " + sql_cmd.UpdatedRowSource + " : " + sql_cmd.ToString();
                returnv = "0";

            }
            catch (Exception ex)
            {
                //textBox4.Text = "EXCEPTION : " + ex.ToString() + "- OTHER DETAILS: " + sql_cmd.CommandText + " : " + sql_cmd.UpdatedRowSource + " : " + sql_cmd.ToString();
                returnv = "1";
            }
            sql_con.Close();
            return returnv;
        }

        private void PrimaryCurrency_TextChanged(object sender, EventArgs e)
        {
            save_lastcurrency(PrimaryCurrency.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PrimaryCurrency.Text = get_lastcurrency();
            textBoxAmount.Text = get_lastamount();
            textBoxAmount.Text = "1";
            String s = get_setting("last_refresh");
            String s1 = "Last Refresh : " + s;
            lastRefresh.Text = s1;
            String x  = get_setting("last_posx");
            String y  = get_setting("last_posy");

            if(x.Length > 0)
               this.Top = int.Parse(x);
            if (y.Length > 0)
                this.Left =  int.Parse(y);

            load_currencies();
            doConvert();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            progressBar1.Maximum = 100;
            progressBar1.Step = 1;
            progressBar1.Value = 0;

            RefreshButton.Enabled = false;

            backgroundWorker1.RunWorkerAsync();

            Cursor.Current = Cursors.Default;
        }

        private void RefreshRate(String from, String to)
        {
            String rate;
            rate = CurrencyConvert(1, from, to);
            save_rate(from, to, Decimal.Parse(rate));
            rate = CurrencyConvert(1, to, from);
            save_rate(to, from, Decimal.Parse(rate));
        }

        private void lastRefresh_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            save_setting("last_posx", this.Top.ToString());
            save_setting("last_posy", this.Left.ToString());
            save_currencies();
        }

        private void save_currencies()
        {
            save_currency(1, textBox1.Text);
            save_currency(2, textBox3.Text);
            save_currency(3, textBox5.Text);
            save_currency(4, textBox7.Text);
            save_currency(5, textBox9.Text);
            save_currency(6, textBox11.Text);
        }
        private void load_currencies()
        {
            textBox1.Text = get_currency(1);
            textBox3.Text = get_currency(2);
            textBox5.Text = get_currency(3);
            textBox7.Text = get_currency(4);
            textBox9.Text = get_currency(5);
            textBox11.Text = get_currency(6);

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int maxSteps = 20;

            RefreshRate(textBox1.Text, textBox1.Text);
            //progressBar1.Value = 1 / 21;
            backgroundWorker1.ReportProgress(1*100 / maxSteps);
            RefreshRate(textBox1.Text, textBox3.Text);
            //progressBar1.Value = 2 / 21;
            backgroundWorker1.ReportProgress(2 * 100 / maxSteps);
            RefreshRate(textBox1.Text, textBox5.Text);
            //progressBar1.Value = 3 / 21;
            backgroundWorker1.ReportProgress(3 * 100 / maxSteps);
            RefreshRate(textBox1.Text, textBox7.Text);
            //progressBar1.Value = 4 / 21;
            backgroundWorker1.ReportProgress(4 * 100 / maxSteps);
            RefreshRate(textBox1.Text, textBox9.Text);
           // progressBar1.Value = 5 / 21;
            backgroundWorker1.ReportProgress(5 * 100 / maxSteps);
            RefreshRate(textBox1.Text, textBox11.Text);
            //progressBar1.Value = 6 / 21;
            backgroundWorker1.ReportProgress(6 * 100 / maxSteps);

            RefreshRate(textBox3.Text, textBox3.Text);
            //progressBar1.Value = 7 / 21;
            backgroundWorker1.ReportProgress(7 * 100 / maxSteps);
            RefreshRate(textBox3.Text, textBox5.Text);
            //progressBar1.Value = 8 / 21;
            backgroundWorker1.ReportProgress(8 * 100 / maxSteps);
            RefreshRate(textBox3.Text, textBox7.Text);
            //progressBar1.Value = 9 / 21;
            backgroundWorker1.ReportProgress(9 * 100 / maxSteps);
            RefreshRate(textBox3.Text, textBox9.Text);
           // progressBar1.Value = 10 / 21;
            backgroundWorker1.ReportProgress(10 * 100 / maxSteps);
            RefreshRate(textBox3.Text, textBox11.Text);
            //progressBar1.Value = 11 / 21;
            backgroundWorker1.ReportProgress(11 * 100 / maxSteps);

            RefreshRate(textBox5.Text, textBox5.Text);
            //progressBar1.Value = 12 / 21;
            backgroundWorker1.ReportProgress(12 * 100 / maxSteps);
            RefreshRate(textBox5.Text, textBox7.Text);
            //progressBar1.Value = 13 / 21;
            backgroundWorker1.ReportProgress(13 * 100 / maxSteps);
            RefreshRate(textBox5.Text, textBox9.Text);
            //progressBar1.Value = 14 / 21;
            backgroundWorker1.ReportProgress(14 * 100 / maxSteps);
            RefreshRate(textBox5.Text, textBox11.Text);
            //progressBar1.Value = 15 / 21;
            backgroundWorker1.ReportProgress(15 * 100 / maxSteps);

            RefreshRate(textBox7.Text, textBox7.Text);
            //progressBar1.Value = 16 / 21;
            backgroundWorker1.ReportProgress(16 * 100 / maxSteps);
            RefreshRate(textBox7.Text, textBox9.Text);
            //progressBar1.Value = 17 / 21;
            backgroundWorker1.ReportProgress(17 * 100 / maxSteps);
            RefreshRate(textBox7.Text, textBox11.Text);
            //progressBar1.Value = 18 / 21;
            backgroundWorker1.ReportProgress(18 * 100 / maxSteps);

            RefreshRate(textBox9.Text, textBox9.Text);
            //progressBar1.Value = 19 / 21;
            backgroundWorker1.ReportProgress(19 * 100 / maxSteps);
            RefreshRate(textBox9.Text, textBox11.Text);
            //progressBar1.Value = 20 / 21;
            backgroundWorker1.ReportProgress(20 * 100 / maxSteps);

            RefreshRate(textBox11.Text, textBox11.Text);
            //progressBar1.Value = 21 / 21;
            backgroundWorker1.ReportProgress(21 * 100 / maxSteps);

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage > 100)
            {
                progressBar1.Value = 100;
            }
            else
            {
                progressBar1.Value = e.ProgressPercentage;
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RefreshButton.Enabled = true;
            DateTime t = DateTime.Now;
            String s = t.ToString();
            String s1 = "Last Refresh : " + s;
            lastRefresh.Text = s1;
            save_setting("last_refresh", s);

            doConvert();
            progressBar1.Value = 100;

        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            e = validate_currency(textBox1, e);
        }
        private CancelEventArgs validate_currency(TextBox textBox, CancelEventArgs e)
        {
            String s = "select count(*) from all_currencies where code = '" + textBox.Text + "'";

            DataTable DT = sql_run_select(s);
            if (int.Parse(DT.Rows[0].ItemArray[0].ToString()) == 0)
            {
                //MessageBox.Show("Invalid Currency Code");
                e.Cancel = true;
                textBox.ForeColor = Color.Red;
                textBox.BackColor = Color.LightYellow;
            }
            else
            {
                textBox.ForeColor = Color.Black;
                textBox.BackColor = Color.White;
            }
            return e;
        }

        private CancelEventArgs validate_number(TextBox textBox, CancelEventArgs e)
        {
            Decimal d;
            try
            {
                d = Decimal.Parse(textBox.Text);
                if(d==0)
                {
                    throw new FormatException();
                }
                textBox.ForeColor = Color.Black;
                textBox.BackColor = Color.White;
            }
            catch(Exception ex)
            {
                e.Cancel = true;
                textBox.ForeColor = Color.Red;
                textBox.BackColor = Color.LightYellow;
            }

            return e;
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            e = validate_currency(textBox3, e);
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            e = validate_currency(textBox5, e);
        }

        private void textBox7_Validating(object sender, CancelEventArgs e)
        {
            e = validate_currency(textBox7, e);
        }

        private void textBox9_Validating(object sender, CancelEventArgs e)
        {
            e = validate_currency(textBox9, e);
        }

        private void textBox11_Validating(object sender, CancelEventArgs e)
        {
            e = validate_currency(textBox11, e);
        }

        private void textBoxAmount_Validating(object sender, CancelEventArgs e)
        {
            e = validate_number(textBoxAmount, e);
        }

        private void multiplier_Validating(object sender, CancelEventArgs e)
        {
            e = validate_number(multiplier, e);
        }

        private void About_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Developed by Joseph Verghese \r\n Visit");
            About form = new About();
            form.Top = this.Top;
            form.Left = this.Left;
            form.ShowDialog();
        }
    }
}
