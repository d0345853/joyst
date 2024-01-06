namespace Joy_T16000M
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label_joy = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_X = new System.Windows.Forms.TextBox();
            this.textBox_S = new System.Windows.Forms.TextBox();
            this.textBox_Z = new System.Windows.Forms.TextBox();
            this.textBox_Y = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 22);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 32);
            this.label5.TabIndex = 9;
            this.label5.Text = "T16000M :";
            // 
            // label_joy
            // 
            this.label_joy.AutoSize = true;
            this.label_joy.Font = new System.Drawing.Font("Arial", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_joy.Location = new System.Drawing.Point(158, 22);
            this.label_joy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_joy.Name = "label_joy";
            this.label_joy.Size = new System.Drawing.Size(95, 32);
            this.label_joy.TabIndex = 10;
            this.label_joy.Text = "Failed";
            this.label_joy.Click += new System.EventHandler(this.label_joy_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(86, 83);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(99, 31);
            this.comboBox1.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(192, 79);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 38);
            this.button1.TabIndex = 13;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_X
            // 
            this.textBox_X.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_X.Location = new System.Drawing.Point(200, 203);
            this.textBox_X.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_X.Name = "textBox_X";
            this.textBox_X.ReadOnly = true;
            this.textBox_X.Size = new System.Drawing.Size(76, 32);
            this.textBox_X.TabIndex = 22;
            this.textBox_X.Text = "0";
            this.textBox_X.TextChanged += new System.EventHandler(this.textBox_X_TextChanged);
            // 
            // textBox_S
            // 
            this.textBox_S.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_S.Location = new System.Drawing.Point(200, 338);
            this.textBox_S.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_S.Name = "textBox_S";
            this.textBox_S.ReadOnly = true;
            this.textBox_S.Size = new System.Drawing.Size(76, 32);
            this.textBox_S.TabIndex = 21;
            this.textBox_S.Text = "0";
            // 
            // textBox_Z
            // 
            this.textBox_Z.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Z.Location = new System.Drawing.Point(200, 293);
            this.textBox_Z.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Z.Name = "textBox_Z";
            this.textBox_Z.ReadOnly = true;
            this.textBox_Z.Size = new System.Drawing.Size(76, 32);
            this.textBox_Z.TabIndex = 20;
            this.textBox_Z.Text = "0";
            // 
            // textBox_Y
            // 
            this.textBox_Y.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Y.Location = new System.Drawing.Point(200, 248);
            this.textBox_Y.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Y.Name = "textBox_Y";
            this.textBox_Y.ReadOnly = true;
            this.textBox_Y.Size = new System.Drawing.Size(76, 32);
            this.textBox_Y.TabIndex = 19;
            this.textBox_Y.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 83);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 32);
            this.label6.TabIndex = 23;
            this.label6.Text = "COM";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(91, 335);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 32);
            this.label4.TabIndex = 3;
            this.label4.Text = "Slide :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 290);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "RotationZ :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(140, 246);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Y :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(140, 201);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "X :";
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(316, 287);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 83);
            this.button2.TabIndex = 24;
            this.button2.Text = "Send";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(326, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 25;
            this.label7.Text = "收到的值";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(326, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 12);
            this.label8.TabIndex = 26;
            this.label8.Text = "wait";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(465, 287);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 27;
            this.button3.Text = "Q";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 456);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_X);
            this.Controls.Add(this.textBox_S);
            this.Controls.Add(this.textBox_Z);
            this.Controls.Add(this.textBox_Y);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label_joy);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_joy;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_X;
        private System.Windows.Forms.TextBox textBox_S;
        private System.Windows.Forms.TextBox textBox_Z;
        private System.Windows.Forms.TextBox textBox_Y;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button3;
    }
}

