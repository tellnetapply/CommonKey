namespace CommonKey
{
    partial class EditDialog
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
            this.BT_CANCEL = new System.Windows.Forms.Button();
            this.txtString = new System.Windows.Forms.TextBox();
            this.BT_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BT_CANCEL
            // 
            this.BT_CANCEL.Location = new System.Drawing.Point(339, 12);
            this.BT_CANCEL.Name = "BT_CANCEL";
            this.BT_CANCEL.Size = new System.Drawing.Size(75, 21);
            this.BT_CANCEL.TabIndex = 5;
            this.BT_CANCEL.Text = "取消";
            this.BT_CANCEL.UseVisualStyleBackColor = true;
            this.BT_CANCEL.Click += new System.EventHandler(this.BT_CANCEL_Click);
            // 
            // txtString
            // 
            this.txtString.Location = new System.Drawing.Point(12, 12);
            this.txtString.Name = "txtString";
            this.txtString.Size = new System.Drawing.Size(240, 21);
            this.txtString.TabIndex = 3;
            // 
            // BT_OK
            // 
            this.BT_OK.Location = new System.Drawing.Point(258, 12);
            this.BT_OK.Name = "BT_OK";
            this.BT_OK.Size = new System.Drawing.Size(75, 21);
            this.BT_OK.TabIndex = 4;
            this.BT_OK.Text = "确认";
            this.BT_OK.UseVisualStyleBackColor = true;
            this.BT_OK.Click += new System.EventHandler(this.BT_OK_Click);
            // 
            // EditDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 50);
            this.Controls.Add(this.BT_CANCEL);
            this.Controls.Add(this.txtString);
            this.Controls.Add(this.BT_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EditDialog";
            this.Text = "EditDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BT_CANCEL;
        private System.Windows.Forms.TextBox txtString;
        private System.Windows.Forms.Button BT_OK;

    }
}