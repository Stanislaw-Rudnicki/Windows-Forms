namespace Wf04_1_t01
{
    partial class Form2
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
            this.labelPib = new System.Windows.Forms.Label();
            this.labelBday = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxPib = new System.Windows.Forms.TextBox();
            this.dateTimePickerBday = new System.Windows.Forms.DateTimePicker();
            this.labelAvg = new System.Windows.Forms.Label();
            this.textBoxAvg = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPib
            // 
            this.labelPib.AutoSize = true;
            this.labelPib.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPib.Location = new System.Drawing.Point(18, 21);
            this.labelPib.Name = "labelPib";
            this.labelPib.Size = new System.Drawing.Size(28, 16);
            this.labelPib.TabIndex = 0;
            this.labelPib.Text = "ПІБ";
            // 
            // labelBday
            // 
            this.labelBday.AutoSize = true;
            this.labelBday.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBday.Location = new System.Drawing.Point(18, 64);
            this.labelBday.Name = "labelBday";
            this.labelBday.Size = new System.Drawing.Size(114, 16);
            this.labelBday.TabIndex = 2;
            this.labelBday.Text = "Дата народження";
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonSave.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSave.Location = new System.Drawing.Point(62, 141);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(122, 47);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Зберегти";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.Location = new System.Drawing.Point(214, 141);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(119, 47);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Відміна";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxPib
            // 
            this.textBoxPib.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPib.Location = new System.Drawing.Point(64, 18);
            this.textBoxPib.Margin = new System.Windows.Forms.Padding(15, 3, 3, 15);
            this.textBoxPib.Name = "textBoxPib";
            this.textBoxPib.Size = new System.Drawing.Size(310, 23);
            this.textBoxPib.TabIndex = 1;
            // 
            // dateTimePickerBday
            // 
            this.dateTimePickerBday.Checked = false;
            this.dateTimePickerBday.CustomFormat = "  dd MMMM yyyy";
            this.dateTimePickerBday.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerBday.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerBday.Location = new System.Drawing.Point(150, 59);
            this.dateTimePickerBday.Margin = new System.Windows.Forms.Padding(15, 3, 3, 15);
            this.dateTimePickerBday.MaxDate = new System.DateTime(2020, 7, 12, 0, 0, 0, 0);
            this.dateTimePickerBday.Name = "dateTimePickerBday";
            this.dateTimePickerBday.Size = new System.Drawing.Size(224, 23);
            this.dateTimePickerBday.TabIndex = 3;
            this.dateTimePickerBday.Value = new System.DateTime(2020, 7, 12, 0, 0, 0, 0);
            // 
            // labelAvg
            // 
            this.labelAvg.AutoSize = true;
            this.labelAvg.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAvg.Location = new System.Drawing.Point(18, 103);
            this.labelAvg.Name = "labelAvg";
            this.labelAvg.Size = new System.Drawing.Size(86, 16);
            this.labelAvg.TabIndex = 4;
            this.labelAvg.Text = "Середній бал";
            // 
            // textBoxAvg
            // 
            this.textBoxAvg.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxAvg.Location = new System.Drawing.Point(150, 100);
            this.textBoxAvg.Margin = new System.Windows.Forms.Padding(15, 3, 3, 15);
            this.textBoxAvg.Name = "textBoxAvg";
            this.textBoxAvg.Size = new System.Drawing.Size(95, 23);
            this.textBoxAvg.TabIndex = 5;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(395, 207);
            this.Controls.Add(this.labelPib);
            this.Controls.Add(this.textBoxPib);
            this.Controls.Add(this.labelBday);
            this.Controls.Add(this.dateTimePickerBday);
            this.Controls.Add(this.labelAvg);
            this.Controls.Add(this.textBoxAvg);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Child";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPib;
        private System.Windows.Forms.Label labelBday;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxPib;
        private System.Windows.Forms.DateTimePicker dateTimePickerBday;
        private System.Windows.Forms.Label labelAvg;
        private System.Windows.Forms.TextBox textBoxAvg;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}