namespace Wessa.SslScanner.UI
{
    partial class KnowPortForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.Source = new System.Windows.Forms.ListBox();
            this.Destination = new System.Windows.Forms.ListBox();
            this.Delete = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(250, 280);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(138, 280);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // Source
            // 
            this.Source.FormattingEnabled = true;
            this.Source.Location = new System.Drawing.Point(12, 12);
            this.Source.Name = "Source";
            this.Source.Size = new System.Drawing.Size(201, 251);
            this.Source.TabIndex = 7;
            // 
            // Destination
            // 
            this.Destination.FormattingEnabled = true;
            this.Destination.Location = new System.Drawing.Point(259, 12);
            this.Destination.Name = "Destination";
            this.Destination.Size = new System.Drawing.Size(201, 251);
            this.Destination.TabIndex = 8;
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(219, 111);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(34, 23);
            this.Delete.TabIndex = 9;
            this.Delete.Text = "<";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(219, 82);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(34, 23);
            this.Add.TabIndex = 10;
            this.Add.Text = ">";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // KnowPortForm
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(477, 314);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Destination);
            this.Controls.Add(this.Source);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Name = "KnowPortForm";
            this.Text = "KnowPortForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox Source;
        private System.Windows.Forms.ListBox Destination;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Add;
    }
}