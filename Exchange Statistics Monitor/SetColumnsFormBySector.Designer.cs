namespace Exchange_Statistics_Monitor
{
    partial class SetColumnsFormBySector
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
            this.ButtonsBottom = new System.Windows.Forms.Panel();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonShow = new System.Windows.Forms.Button();
            this.buttonHide = new System.Windows.Forms.Button();
            this.listBoxAll = new System.Windows.Forms.ListBox();
            this.listBoxVisible = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.ButtonsBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonsBottom
            // 
            this.ButtonsBottom.Controls.Add(this.buttonSave);
            this.ButtonsBottom.Controls.Add(this.buttonCancel);
            this.ButtonsBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonsBottom.Location = new System.Drawing.Point(0, 482);
            this.ButtonsBottom.Name = "ButtonsBottom";
            this.ButtonsBottom.Size = new System.Drawing.Size(593, 34);
            this.ButtonsBottom.TabIndex = 15;
            // 
            // buttonSave
            // 
            this.buttonSave.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonSave.Location = new System.Drawing.Point(0, 0);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(295, 34);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonCancel.Location = new System.Drawing.Point(298, 0);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(295, 34);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(451, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Все столбцы";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Отобразить";
            // 
            // buttonShow
            // 
            this.buttonShow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonShow.Location = new System.Drawing.Point(213, 52);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(165, 23);
            this.buttonShow.TabIndex = 12;
            this.buttonShow.Text = "Показать";
            this.buttonShow.UseVisualStyleBackColor = true;
            this.buttonShow.Click += new System.EventHandler(this.ButtonShow_Click);
            // 
            // buttonHide
            // 
            this.buttonHide.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonHide.Location = new System.Drawing.Point(213, 81);
            this.buttonHide.Name = "buttonHide";
            this.buttonHide.Size = new System.Drawing.Size(165, 23);
            this.buttonHide.TabIndex = 11;
            this.buttonHide.Text = "Скрыть";
            this.buttonHide.UseVisualStyleBackColor = true;
            this.buttonHide.Click += new System.EventHandler(this.ButtonHide_Click);
            // 
            // listBoxAll
            // 
            this.listBoxAll.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBoxAll.FormattingEnabled = true;
            this.listBoxAll.Location = new System.Drawing.Point(384, 52);
            this.listBoxAll.Name = "listBoxAll";
            this.listBoxAll.Size = new System.Drawing.Size(195, 420);
            this.listBoxAll.TabIndex = 10;
            // 
            // listBoxVisible
            // 
            this.listBoxVisible.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBoxVisible.FormattingEnabled = true;
            this.listBoxVisible.Location = new System.Drawing.Point(12, 52);
            this.listBoxVisible.Name = "listBoxVisible";
            this.listBoxVisible.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxVisible.Size = new System.Drawing.Size(195, 420);
            this.listBoxVisible.TabIndex = 9;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(567, 21);
            this.comboBox1.TabIndex = 16;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // SetColumnsFormBySector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 516);
            this.ControlBox = false;
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.ButtonsBottom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonShow);
            this.Controls.Add(this.buttonHide);
            this.Controls.Add(this.listBoxAll);
            this.Controls.Add(this.listBoxVisible);
            this.Name = "SetColumnsFormBySector";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Выберите столбцы для отображения";
            this.ButtonsBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel ButtonsBottom;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.Button buttonHide;
        private System.Windows.Forms.ListBox listBoxAll;
        private System.Windows.Forms.ListBox listBoxVisible;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}