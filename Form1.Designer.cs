namespace ToliEnkhzul
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtSearch = new TextBox();
            cmbLang = new ComboBox();
            lblLang = new Label();
            dataGridView1 = new DataGridView();
            dataGridView2 = new DataGridView();
            lblSaved = new Label();
            txtEng = new TextBox();
            txtMon = new TextBox();
            txtRus = new TextBox();
            Англи = new Label();
            label3 = new Label();
            label4 = new Label();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            btnSave = new Button();
            lblCount = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 48);
            label1.Name = "label1";
            label1.Size = new Size(45, 20);
            label1.TabIndex = 0;
            label1.Text = "Хайх:";
            label1.Click += label1_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(33, 85);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(250, 27);
            txtSearch.TabIndex = 1;
            txtSearch.Text = "хайх үг....";
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // cmbLang
            // 
            cmbLang.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLang.FormattingEnabled = true;
            cmbLang.Location = new Point(352, 89);
            cmbLang.Name = "cmbLang";
            cmbLang.Size = new Size(120, 28);
            cmbLang.TabIndex = 2;
            cmbLang.SelectedIndexChanged += cmbLang_SelectedIndexChanged;
            // 
            // lblLang
            // 
            lblLang.AutoSize = true;
            lblLang.Location = new Point(310, 92);
            lblLang.Name = "lblLang";
            lblLang.Size = new Size(36, 20);
            lblLang.TabIndex = 3;
            lblLang.Text = "Хэл:";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(33, 133);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(550, 300);
            dataGridView1.TabIndex = 4;
        
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(620, 133);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.Size = new Size(250, 300);
            dataGridView2.TabIndex = 5;
            // 
            // lblSaved
            // 
            lblSaved.AutoSize = true;
            lblSaved.Location = new Point(620, 97);
            lblSaved.Name = "lblSaved";
            lblSaved.Size = new Size(91, 20);
            lblSaved.TabIndex = 6;
            lblSaved.Text = "Санасан үгс";
            lblSaved.Click += lblSaved_Click;
            // 
            // txtEng
            // 
            txtEng.Location = new Point(94, 473);
            txtEng.Name = "txtEng";
            txtEng.Size = new Size(200, 27);
            txtEng.TabIndex = 7;
            // 
            // txtMon
            // 
            txtMon.Location = new Point(379, 473);
            txtMon.Name = "txtMon";
            txtMon.Size = new Size(200, 27);
            txtMon.TabIndex = 8;
            // 
            // txtRus
            // 
            txtRus.Location = new Point(654, 473);
            txtRus.Name = "txtRus";
            txtRus.Size = new Size(200, 27);
            txtRus.TabIndex = 9;
            // 
            // Англи
            // 
            Англи.AutoSize = true;
            Англи.Location = new Point(33, 476);
            Англи.Name = "Англи";
            Англи.Size = new Size(55, 20);
            Англи.TabIndex = 10;
            Англи.Text = "Англи ";
            Англи.Click += Англи_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(310, 476);
            label3.Name = "label3";
            label3.Size = new Size(63, 20);
            label3.TabIndex = 11;
            label3.Text = "Монгол";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(603, 480);
            label4.Name = "label4";
            label4.Size = new Size(45, 20);
            label4.TabIndex = 12;
            label4.Text = "Орос";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(33, 561);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(150, 40);
            btnAdd.TabIndex = 13;
            btnAdd.Text = "Нэмэх";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(196, 561);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(150, 40);
            btnUpdate.TabIndex = 14;
            btnUpdate.Text = "Засах";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(362, 561);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(150, 40);
            btnDelete.TabIndex = 15;
            btnDelete.Text = "Устгах";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(535, 561);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(150, 40);
            btnClear.TabIndex = 16;
            btnClear.Text = "Цэвэрлэх";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(703, 561);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 40);
            btnSave.TabIndex = 17;
            btnSave.Text = "Санах";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.Location = new Point(36, 634);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(76, 20);
            lblCount.TabIndex = 18;
            lblCount.Text = "Нийт: 0 үг";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 753);
            Controls.Add(lblCount);
            Controls.Add(btnSave);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(Англи);
            Controls.Add(txtRus);
            Controls.Add(txtMon);
            Controls.Add(txtEng);
            Controls.Add(lblSaved);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Controls.Add(lblLang);
            Controls.Add(cmbLang);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Гурван хэлний толь бичиг";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtSearch;
        private ComboBox cmbLang;
        private Label lblLang;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private Label lblSaved;
        private TextBox txtEng;
        private TextBox txtMon;
        private TextBox txtRus;
        private Label Англи;
        private Label label3;
        private Label label4;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private Button btnSave;
        private Label lblCount;
    }
}
