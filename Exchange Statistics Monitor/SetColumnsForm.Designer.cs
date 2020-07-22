namespace Exchange_Statistics_Monitor
{
    partial class SetColumnsForm
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
            this.listBoxVisible = new System.Windows.Forms.ListBox();
            this.listBoxAll = new System.Windows.Forms.ListBox();
            this.buttonHide = new System.Windows.Forms.Button();
            this.buttonShow = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.ButtonsBottom = new System.Windows.Forms.Panel();
            this.ButtonsBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxVisible
            // 
            this.listBoxVisible.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBoxVisible.FormattingEnabled = true;
            this.listBoxVisible.Location = new System.Drawing.Point(12, 22);
            this.listBoxVisible.Name = "listBoxVisible";
            this.listBoxVisible.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxVisible.Size = new System.Drawing.Size(195, 446);
            this.listBoxVisible.TabIndex = 0;
            // 
            // listBoxAll
            // 
            this.listBoxAll.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBoxAll.FormattingEnabled = true;
            this.listBoxAll.Location = new System.Drawing.Point(384, 22);
            this.listBoxAll.Name = "listBoxAll";
            this.listBoxAll.Size = new System.Drawing.Size(195, 446);
            this.listBoxAll.TabIndex = 1;
            // 
            // buttonHide
            // 
            this.buttonHide.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonHide.Location = new System.Drawing.Point(213, 51);
            this.buttonHide.Name = "buttonHide";
            this.buttonHide.Size = new System.Drawing.Size(165, 23);
            this.buttonHide.TabIndex = 2;
            this.buttonHide.Text = "Скрыть";
            this.buttonHide.UseVisualStyleBackColor = true;
            this.buttonHide.Click += new System.EventHandler(this.buttonHide_Click);
            // 
            // buttonShow
            // 
            this.buttonShow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonShow.Location = new System.Drawing.Point(213, 22);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(165, 23);
            this.buttonShow.TabIndex = 3;
            this.buttonShow.Text = "Показать";
            this.buttonShow.UseVisualStyleBackColor = true;
            this.buttonShow.Click += new System.EventHandler(this.buttonShow_Click);
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
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Отобразить";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(451, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Все столбцы";
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
            // ButtonsBottom
            // 
            this.ButtonsBottom.Controls.Add(this.buttonSave);
            this.ButtonsBottom.Controls.Add(this.buttonCancel);
            this.ButtonsBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonsBottom.Location = new System.Drawing.Point(0, 474);
            this.ButtonsBottom.Name = "ButtonsBottom";
            this.ButtonsBottom.Size = new System.Drawing.Size(593, 34);
            this.ButtonsBottom.TabIndex = 8;
            // 
            // SetColumnsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 508);
            this.ControlBox = false;
            this.Controls.Add(this.ButtonsBottom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonShow);
            this.Controls.Add(this.buttonHide);
            this.Controls.Add(this.listBoxAll);
            this.Controls.Add(this.listBoxVisible);
            this.Name = "SetColumnsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выберите столбцы для отображения";
            this.Load += new System.EventHandler(this.SetColumnsForm_Load);
            this.ButtonsBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxVisible;
        private System.Windows.Forms.ListBox listBoxAll;
        private System.Windows.Forms.Button buttonHide;
        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Panel ButtonsBottom;
    }
}