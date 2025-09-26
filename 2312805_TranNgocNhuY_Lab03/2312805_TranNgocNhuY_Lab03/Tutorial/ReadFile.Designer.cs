namespace _2312805_TranNgocNhuY_Lab03.Tutorial
{
    partial class ReadFile
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
            this.btnText = new System.Windows.Forms.Button();
            this.btnJson = new System.Windows.Forms.Button();
            this.btnXML = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnText
            // 
            this.btnText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnText.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnText.Location = new System.Drawing.Point(29, 61);
            this.btnText.Name = "btnText";
            this.btnText.Size = new System.Drawing.Size(173, 45);
            this.btnText.TabIndex = 0;
            this.btnText.Text = "READ TEXT FILE";
            this.btnText.UseVisualStyleBackColor = true;
            this.btnText.Click += new System.EventHandler(this.btnText_Click);
            // 
            // btnJson
            // 
            this.btnJson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJson.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJson.Location = new System.Drawing.Point(300, 61);
            this.btnJson.Name = "btnJson";
            this.btnJson.Size = new System.Drawing.Size(173, 45);
            this.btnJson.TabIndex = 0;
            this.btnJson.Text = "READ JSON FILE";
            this.btnJson.UseVisualStyleBackColor = true;
            this.btnJson.Click += new System.EventHandler(this.btnJson_Click);
            // 
            // btnXML
            // 
            this.btnXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXML.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXML.Location = new System.Drawing.Point(578, 61);
            this.btnXML.Name = "btnXML";
            this.btnXML.Size = new System.Drawing.Size(173, 45);
            this.btnXML.TabIndex = 0;
            this.btnXML.Text = "READ XML FILE";
            this.btnXML.UseVisualStyleBackColor = true;
            this.btnXML.Click += new System.EventHandler(this.btnXML_Click);
            // 
            // ReadFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 153);
            this.Controls.Add(this.btnXML);
            this.Controls.Add(this.btnJson);
            this.Controls.Add(this.btnText);
            this.Name = "ReadFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Read FIle";
            this.Load += new System.EventHandler(this.ReadFile_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnText;
        private System.Windows.Forms.Button btnJson;
        private System.Windows.Forms.Button btnXML;
    }
}