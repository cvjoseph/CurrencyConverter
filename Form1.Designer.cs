namespace CurrencyConverter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonDo = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PrimaryCurrency = new System.Windows.Forms.Label();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.lastRefresh = new System.Windows.Forms.Label();
            this.multiplier = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // buttonDo
            // 
            this.buttonDo.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonDo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.150944F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDo.Location = new System.Drawing.Point(14, 38);
            this.buttonDo.Name = "buttonDo";
            this.buttonDo.Size = new System.Drawing.Size(265, 26);
            this.buttonDo.TabIndex = 15;
            this.buttonDo.Text = "Convert...";
            this.buttonDo.UseVisualStyleBackColor = false;
            this.buttonDo.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(108, 85);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(47, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "INR";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 82);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Set Primary";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(155, 85);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(124, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Primary Currency";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // PrimaryCurrency
            // 
            this.PrimaryCurrency.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.150944F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrimaryCurrency.ForeColor = System.Drawing.Color.Blue;
            this.PrimaryCurrency.Location = new System.Drawing.Point(108, 8);
            this.PrimaryCurrency.Name = "PrimaryCurrency";
            this.PrimaryCurrency.Size = new System.Drawing.Size(47, 26);
            this.PrimaryCurrency.TabIndex = 6;
            this.PrimaryCurrency.Text = "EUR";
            this.PrimaryCurrency.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PrimaryCurrency.TextChanged += new System.EventHandler(this.PrimaryCurrency_TextChanged);
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Location = new System.Drawing.Point(155, 10);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(79, 20);
            this.textBoxAmount.TabIndex = 0;
            this.textBoxAmount.Text = "1";
            this.textBoxAmount.TextChanged += new System.EventHandler(this.textBoxAmount_TextChanged);
            this.textBoxAmount.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxAmount_Validating);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(155, 123);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(124, 20);
            this.textBox4.TabIndex = 10;
            this.textBox4.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(14, 120);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Set Primary";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(108, 123);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(47, 20);
            this.textBox3.TabIndex = 5;
            this.textBox3.Text = "USD";
            this.textBox3.Validating += new System.ComponentModel.CancelEventHandler(this.textBox3_Validating);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(155, 163);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(124, 20);
            this.textBox6.TabIndex = 13;
            this.textBox6.TabStop = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(14, 160);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Set Primary";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(108, 163);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(47, 20);
            this.textBox5.TabIndex = 7;
            this.textBox5.Text = "EUR";
            this.textBox5.Validating += new System.ComponentModel.CancelEventHandler(this.textBox5_Validating);
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(155, 282);
            this.textBox12.Name = "textBox12";
            this.textBox12.ReadOnly = true;
            this.textBox12.Size = new System.Drawing.Size(124, 20);
            this.textBox12.TabIndex = 22;
            this.textBox12.TabStop = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(14, 279);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(88, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "Set Primary";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(108, 282);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(47, 20);
            this.textBox11.TabIndex = 13;
            this.textBox11.Text = "GBP";
            this.textBox11.Validating += new System.ComponentModel.CancelEventHandler(this.textBox11_Validating);
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(155, 242);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(124, 20);
            this.textBox10.TabIndex = 19;
            this.textBox10.TabStop = false;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(14, 239);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(88, 23);
            this.button5.TabIndex = 10;
            this.button5.Text = "Set Primary";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(108, 242);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(47, 20);
            this.textBox9.TabIndex = 11;
            this.textBox9.Text = "RUB";
            this.textBox9.Validating += new System.ComponentModel.CancelEventHandler(this.textBox9_Validating);
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(155, 204);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(124, 20);
            this.textBox8.TabIndex = 16;
            this.textBox8.TabStop = false;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(14, 201);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(88, 23);
            this.button6.TabIndex = 8;
            this.button6.Text = "Set Primary";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(108, 204);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(47, 20);
            this.textBox7.TabIndex = 9;
            this.textBox7.Text = "AED";
            this.textBox7.Validating += new System.ComponentModel.CancelEventHandler(this.textBox7_Validating);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(140, 357);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(142, 23);
            this.RefreshButton.TabIndex = 14;
            this.RefreshButton.Text = "Refresh Rates Online";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // lastRefresh
            // 
            this.lastRefresh.Location = new System.Drawing.Point(14, 324);
            this.lastRefresh.Name = "lastRefresh";
            this.lastRefresh.Size = new System.Drawing.Size(268, 22);
            this.lastRefresh.TabIndex = 25;
            this.lastRefresh.Text = "Last Refresh : ";
            this.lastRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lastRefresh.Click += new System.EventHandler(this.lastRefresh_Click);
            // 
            // multiplier
            // 
            this.multiplier.Location = new System.Drawing.Point(249, 10);
            this.multiplier.Name = "multiplier";
            this.multiplier.Size = new System.Drawing.Size(30, 20);
            this.multiplier.TabIndex = 1;
            this.multiplier.Text = "1";
            this.multiplier.Validating += new System.ComponentModel.CancelEventHandler(this.multiplier_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(234, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 20);
            this.label2.TabIndex = 27;
            this.label2.Text = "*";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(141, 349);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(140, 10);
            this.progressBar1.TabIndex = 28;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // Form1
            // 
            this.AcceptButton = this.buttonDo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 390);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.multiplier);
            this.Controls.Add(this.lastRefresh);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBoxAmount);
            this.Controls.Add(this.PrimaryCurrency);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonDo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Fx Converter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label PrimaryCurrency;
        private System.Windows.Forms.TextBox textBoxAmount;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Label lastRefresh;
        private System.Windows.Forms.TextBox multiplier;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

