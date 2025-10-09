namespace _2312805_TranNgocNhuY_PC634
{
	partial class QuanLyNhaCungCap
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtID = new System.Windows.Forms.TextBox();
			this.mtxtPhone = new System.Windows.Forms.MaskedTextBox();
			this.btnDefault = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.rbtnPhone = new System.Windows.Forms.RadioButton();
			this.rbtnName = new System.Windows.Forms.RadioButton();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.dtgvProducers = new System.Windows.Forms.DataGridView();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.txtAddress = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.btnExport = new System.Windows.Forms.TextBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.btnExportXML = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dtgvProducers)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(31, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(91, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Mã nhà cung cấp";
			// 
			// txtID
			// 
			this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtID.Location = new System.Drawing.Point(132, 18);
			this.txtID.Name = "txtID";
			this.txtID.ReadOnly = true;
			this.txtID.Size = new System.Drawing.Size(292, 20);
			this.txtID.TabIndex = 1;
			// 
			// mtxtPhone
			// 
			this.mtxtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mtxtPhone.Location = new System.Drawing.Point(543, 23);
			this.mtxtPhone.Mask = "___________";
			this.mtxtPhone.Name = "mtxtPhone";
			this.mtxtPhone.Size = new System.Drawing.Size(245, 20);
			this.mtxtPhone.TabIndex = 2;
			this.mtxtPhone.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mtxtPhone_MaskInputRejected);
			// 
			// btnDefault
			// 
			this.btnDefault.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btnDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDefault.Location = new System.Drawing.Point(327, 138);
			this.btnDefault.Name = "btnDefault";
			this.btnDefault.Size = new System.Drawing.Size(75, 23);
			this.btnDefault.TabIndex = 3;
			this.btnDefault.Text = "Mặc định";
			this.btnDefault.UseVisualStyleBackColor = false;
			this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.rbtnPhone);
			this.panel1.Controls.Add(this.rbtnName);
			this.panel1.Controls.Add(this.txtSearch);
			this.panel1.Location = new System.Drawing.Point(327, 180);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(461, 59);
			this.panel1.TabIndex = 4;
			// 
			// rbtnPhone
			// 
			this.rbtnPhone.AutoSize = true;
			this.rbtnPhone.Location = new System.Drawing.Point(120, 21);
			this.rbtnPhone.Name = "rbtnPhone";
			this.rbtnPhone.Size = new System.Drawing.Size(75, 17);
			this.rbtnPhone.TabIndex = 0;
			this.rbtnPhone.TabStop = true;
			this.rbtnPhone.Text = "Theo SDT";
			this.rbtnPhone.UseVisualStyleBackColor = true;
			// 
			// rbtnName
			// 
			this.rbtnName.AutoSize = true;
			this.rbtnName.Location = new System.Drawing.Point(13, 21);
			this.rbtnName.Name = "rbtnName";
			this.rbtnName.Size = new System.Drawing.Size(68, 17);
			this.rbtnName.TabIndex = 0;
			this.rbtnName.TabStop = true;
			this.rbtnName.Text = "Theo tên";
			this.rbtnName.UseVisualStyleBackColor = true;
			// 
			// txtSearch
			// 
			this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtSearch.Location = new System.Drawing.Point(230, 18);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(145, 20);
			this.txtSearch.TabIndex = 1;
			this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
			// 
			// dtgvProducers
			// 
			this.dtgvProducers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtgvProducers.Location = new System.Drawing.Point(12, 262);
			this.dtgvProducers.Name = "dtgvProducers";
			this.dtgvProducers.Size = new System.Drawing.Size(776, 150);
			this.dtgvProducers.TabIndex = 5;
			this.dtgvProducers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvProducers_CellContentClick);
			this.dtgvProducers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvProducers_CellDoubleClick);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(31, 71);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(95, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Tên nhà cung cấp";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(31, 119);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Địa chỉ";
			// 
			// txtName
			// 
			this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtName.Location = new System.Drawing.Point(132, 71);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(292, 20);
			this.txtName.TabIndex = 1;
			// 
			// txtAddress
			// 
			this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtAddress.Location = new System.Drawing.Point(132, 112);
			this.txtAddress.Name = "txtAddress";
			this.txtAddress.Size = new System.Drawing.Size(292, 20);
			this.txtAddress.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(467, 25);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(70, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "Số điện thoại";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(337, 172);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(49, 13);
			this.label5.TabIndex = 0;
			this.label5.Text = "Tìm kiếm";
			// 
			// btnExport
			// 
			this.btnExport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.btnExport.Location = new System.Drawing.Point(543, 54);
			this.btnExport.Multiline = true;
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new System.Drawing.Size(245, 74);
			this.btnExport.TabIndex = 1;
			// 
			// btnSave
			// 
			this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSave.Location = new System.Drawing.Point(426, 138);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 3;
			this.btnSave.Text = "Lưu";
			this.btnSave.UseVisualStyleBackColor = false;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(31, 246);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(128, 13);
			this.label6.TabIndex = 0;
			this.label6.Text = "Danh sách nhà cung cấp";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(467, 56);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(34, 13);
			this.label7.TabIndex = 0;
			this.label7.Text = "Mô tả";
			// 
			// btnExportXML
			// 
			this.btnExportXML.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btnExportXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnExportXML.Location = new System.Drawing.Point(692, 418);
			this.btnExportXML.Name = "btnExportXML";
			this.btnExportXML.Size = new System.Drawing.Size(75, 23);
			this.btnExportXML.TabIndex = 3;
			this.btnExportXML.Text = "Xuất JSON";
			this.btnExportXML.UseVisualStyleBackColor = false;
			this.btnExportXML.Click += new System.EventHandler(this.s_Click);
			// 
			// QuanLyNhaCungCap
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.dtgvProducers);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.btnExportXML);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnDefault);
			this.Controls.Add(this.mtxtPhone);
			this.Controls.Add(this.btnExport);
			this.Controls.Add(this.txtAddress);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.txtID);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label1);
			this.Name = "QuanLyNhaCungCap";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.QuanLyNhaCungCap_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dtgvProducers)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtID;
		private System.Windows.Forms.MaskedTextBox mtxtPhone;
		private System.Windows.Forms.Button btnDefault;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.RadioButton rbtnPhone;
		private System.Windows.Forms.RadioButton rbtnName;
		private System.Windows.Forms.TextBox txtSearch;
		private System.Windows.Forms.DataGridView dtgvProducers;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.TextBox txtAddress;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox btnExport;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button btnExportXML;
	}
}

