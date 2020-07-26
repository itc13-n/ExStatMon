namespace Exchange_Statistics_Monitor
{
    partial class LoadingOptions
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
            this.ButtonsBottom = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.labelDelay = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelCounter = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtonParallel = new System.Windows.Forms.RadioButton();
            this.radioButtonSuccessive = new System.Windows.Forms.RadioButton();
            this.textBoxCounter = new System.Windows.Forms.TextBox();
            this.textBoxDelay = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ButtonsBottom.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonsBottom
            // 
            this.ButtonsBottom.Controls.Add(this.button3);
            this.ButtonsBottom.Controls.Add(this.button1);
            this.ButtonsBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonsBottom.Location = new System.Drawing.Point(0, 110);
            this.ButtonsBottom.Name = "ButtonsBottom";
            this.ButtonsBottom.Size = new System.Drawing.Size(374, 34);
            this.ButtonsBottom.TabIndex = 9;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Left;
            this.button3.Location = new System.Drawing.Point(0, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(184, 34);
            this.button3.TabIndex = 4;
            this.button3.Text = "Запустить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Location = new System.Drawing.Point(190, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 34);
            this.button1.TabIndex = 7;
            this.button1.Text = "Закрыть";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(374, 110);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.textBoxDelay);
            this.panel5.Controls.Add(this.labelDelay);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 77);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(368, 30);
            this.panel5.TabIndex = 6;
            // 
            // labelDelay
            // 
            this.labelDelay.AutoSize = true;
            this.labelDelay.Location = new System.Drawing.Point(9, 9);
            this.labelDelay.Name = "labelDelay";
            this.labelDelay.Size = new System.Drawing.Size(166, 13);
            this.labelDelay.TabIndex = 1;
            this.labelDelay.Text = "Время ожидания при загрузке:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.textBoxCounter);
            this.panel3.Controls.Add(this.labelCounter);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 42);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(368, 29);
            this.panel3.TabIndex = 8;
            // 
            // labelCounter
            // 
            this.labelCounter.AutoSize = true;
            this.labelCounter.Location = new System.Drawing.Point(59, 9);
            this.labelCounter.Name = "labelCounter";
            this.labelCounter.Size = new System.Drawing.Size(79, 13);
            this.labelCounter.TabIndex = 0;
            this.labelCounter.Text = "Загружать по:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButtonSuccessive);
            this.panel1.Controls.Add(this.radioButtonParallel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(368, 33);
            this.panel1.TabIndex = 10;
            // 
            // radioButtonParallel
            // 
            this.radioButtonParallel.AutoSize = true;
            this.radioButtonParallel.Location = new System.Drawing.Point(9, 9);
            this.radioButtonParallel.Name = "radioButtonParallel";
            this.radioButtonParallel.Size = new System.Drawing.Size(148, 17);
            this.radioButtonParallel.TabIndex = 0;
            this.radioButtonParallel.TabStop = true;
            this.radioButtonParallel.Text = "Параллельная загрузка";
            this.radioButtonParallel.UseVisualStyleBackColor = true;
            this.radioButtonParallel.CheckedChanged += new System.EventHandler(this.RadioButton1_CheckedChanged);
            // 
            // radioButtonSuccessive
            // 
            this.radioButtonSuccessive.AutoSize = true;
            this.radioButtonSuccessive.Location = new System.Drawing.Point(187, 9);
            this.radioButtonSuccessive.Name = "radioButtonSuccessive";
            this.radioButtonSuccessive.Size = new System.Drawing.Size(171, 17);
            this.radioButtonSuccessive.TabIndex = 1;
            this.radioButtonSuccessive.TabStop = true;
            this.radioButtonSuccessive.Text = "Последовательная загрузка";
            this.radioButtonSuccessive.UseVisualStyleBackColor = true;
            this.radioButtonSuccessive.CheckedChanged += new System.EventHandler(this.RadioButton2_CheckedChanged);
            // 
            // textBoxCounter
            // 
            this.textBoxCounter.Location = new System.Drawing.Point(181, 6);
            this.textBoxCounter.Name = "textBoxCounter";
            this.textBoxCounter.Size = new System.Drawing.Size(47, 20);
            this.textBoxCounter.TabIndex = 1;
            this.textBoxCounter.Text = "10";
            this.textBoxCounter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxDelay
            // 
            this.textBoxDelay.Location = new System.Drawing.Point(181, 6);
            this.textBoxDelay.Name = "textBoxDelay";
            this.textBoxDelay.Size = new System.Drawing.Size(47, 20);
            this.textBoxDelay.TabIndex = 2;
            this.textBoxDelay.Text = "1000";
            this.textBoxDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(234, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "компаний";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(234, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "миллисекунд";
            // 
            // LoadingOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 144);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.ButtonsBottom);
            this.Name = "LoadingOptions";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройка загрузки";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.LoadingOptions_Load);
            this.ButtonsBottom.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ButtonsBottom;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton radioButtonSuccessive;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelCounter;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label labelDelay;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButtonParallel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCounter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDelay;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}