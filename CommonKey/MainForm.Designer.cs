namespace CommonKey
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.newProject = new System.Windows.Forms.ToolStripMenuItem();
            this.openProject = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProject = new System.Windows.Forms.ToolStripMenuItem();
            this.closeProject = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitFSM = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.版本号ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MainTbl = new System.Windows.Forms.DataGridView();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.BTN_DelRow = new System.Windows.Forms.Button();
            this.BTN_AddRow = new System.Windows.Forms.Button();
            this.BTN_EditConnect = new System.Windows.Forms.Button();
            this.BTN_DelConnect = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainTbl)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel11.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel12.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem5,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 25);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProject,
            this.openProject,
            this.saveProject,
            this.closeProject,
            this.toolStripSeparator3,
            this.exitFSM});
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(44, 21);
            this.toolStripMenuItem5.Text = "文件";
            // 
            // newProject
            // 
            this.newProject.Name = "newProject";
            this.newProject.Size = new System.Drawing.Size(124, 22);
            this.newProject.Text = "新建工程";
            this.newProject.Click += new System.EventHandler(this.newProject_Click);
            // 
            // openProject
            // 
            this.openProject.Name = "openProject";
            this.openProject.Size = new System.Drawing.Size(124, 22);
            this.openProject.Text = "打开工程";
            this.openProject.Click += new System.EventHandler(this.openProject_Click);
            // 
            // saveProject
            // 
            this.saveProject.Name = "saveProject";
            this.saveProject.Size = new System.Drawing.Size(124, 22);
            this.saveProject.Text = "保存工程";
            this.saveProject.Click += new System.EventHandler(this.saveProject_Click);
            // 
            // closeProject
            // 
            this.closeProject.Name = "closeProject";
            this.closeProject.Size = new System.Drawing.Size(124, 22);
            this.closeProject.Text = "关闭工程";
            this.closeProject.Click += new System.EventHandler(this.closeProject_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(121, 6);
            // 
            // exitFSM
            // 
            this.exitFSM.Name = "exitFSM";
            this.exitFSM.Size = new System.Drawing.Size(124, 22);
            this.exitFSM.Text = "退出";
            this.exitFSM.Click += new System.EventHandler(this.exit_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.版本号ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // 版本号ToolStripMenuItem
            // 
            this.版本号ToolStripMenuItem.Name = "版本号ToolStripMenuItem";
            this.版本号ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.版本号ToolStripMenuItem.Text = "使用方法";
            this.版本号ToolStripMenuItem.Click += new System.EventHandler(this.版本号ToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(6, 6);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1008, 576);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.panel8);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1000, 544);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "编辑界面";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.MainTbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(878, 538);
            this.panel1.TabIndex = 8;
            // 
            // MainTbl
            // 
            this.MainTbl.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.MainTbl.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.MainTbl.BackgroundColor = System.Drawing.Color.White;
            this.MainTbl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTbl.Location = new System.Drawing.Point(0, 0);
            this.MainTbl.MultiSelect = false;
            this.MainTbl.Name = "MainTbl";
            this.MainTbl.ReadOnly = true;
            this.MainTbl.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MainTbl.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.MainTbl.RowTemplate.Height = 23;
            this.MainTbl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.MainTbl.Size = new System.Drawing.Size(878, 538);
            this.MainTbl.TabIndex = 6;
            this.MainTbl.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MainTbl_CellDoubleClick);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel11);
            this.panel8.Controls.Add(this.BTN_EditConnect);
            this.panel8.Controls.Add(this.BTN_DelConnect);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(881, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(116, 538);
            this.panel8.TabIndex = 7;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.BTN_DelRow);
            this.panel11.Controls.Add(this.BTN_AddRow);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel11.Location = new System.Drawing.Point(0, 472);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(116, 66);
            this.panel11.TabIndex = 5;
            // 
            // BTN_DelRow
            // 
            this.BTN_DelRow.Location = new System.Drawing.Point(4, 35);
            this.BTN_DelRow.Name = "BTN_DelRow";
            this.BTN_DelRow.Size = new System.Drawing.Size(109, 28);
            this.BTN_DelRow.TabIndex = 5;
            this.BTN_DelRow.Text = "删除本行";
            this.BTN_DelRow.UseVisualStyleBackColor = true;
            this.BTN_DelRow.Click += new System.EventHandler(this.BTN_DelRow_Click);
            // 
            // BTN_AddRow
            // 
            this.BTN_AddRow.Location = new System.Drawing.Point(3, 3);
            this.BTN_AddRow.Name = "BTN_AddRow";
            this.BTN_AddRow.Size = new System.Drawing.Size(109, 28);
            this.BTN_AddRow.TabIndex = 4;
            this.BTN_AddRow.Text = "添加新行";
            this.BTN_AddRow.UseVisualStyleBackColor = true;
            this.BTN_AddRow.Click += new System.EventHandler(this.BTN_AddRow_Click);
            // 
            // BTN_EditConnect
            // 
            this.BTN_EditConnect.Location = new System.Drawing.Point(3, 3);
            this.BTN_EditConnect.Name = "BTN_EditConnect";
            this.BTN_EditConnect.Size = new System.Drawing.Size(109, 28);
            this.BTN_EditConnect.TabIndex = 3;
            this.BTN_EditConnect.Text = "编辑当前";
            this.BTN_EditConnect.UseVisualStyleBackColor = true;
            this.BTN_EditConnect.Click += new System.EventHandler(this.BTN_EditConnect_Click);
            // 
            // BTN_DelConnect
            // 
            this.BTN_DelConnect.Location = new System.Drawing.Point(3, 37);
            this.BTN_DelConnect.Name = "BTN_DelConnect";
            this.BTN_DelConnect.Size = new System.Drawing.Size(109, 28);
            this.BTN_DelConnect.TabIndex = 2;
            this.BTN_DelConnect.Text = "删除当前";
            this.BTN_DelConnect.UseVisualStyleBackColor = true;
            this.BTN_DelConnect.Click += new System.EventHandler(this.BTN_DelConnect_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel7);
            this.tabPage1.Controls.Add(this.panel4);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1000, 544);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "设定界面";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel9);
            this.panel7.Controls.Add(this.panel2);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(3, 83);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(994, 40);
            this.panel7.TabIndex = 10;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.progressBar1);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(108, 10);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(886, 30);
            this.panel9.TabIndex = 8;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(886, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(108, 40);
            this.panel2.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(5, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "生成代码";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 43);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(994, 40);
            this.panel4.TabIndex = 9;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.textBox2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(108, 10);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(886, 30);
            this.panel6.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox2.Location = new System.Drawing.Point(0, 0);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(886, 21);
            this.textBox2.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(108, 40);
            this.panel5.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "生成代码模块名：";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel10);
            this.panel3.Controls.Add(this.panel12);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(994, 40);
            this.panel3.TabIndex = 8;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.textBox1);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel10.Location = new System.Drawing.Point(108, 10);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(886, 30);
            this.panel10.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(886, 21);
            this.textBox1.TabIndex = 0;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.label1);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(108, 40);
            this.panel12.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "生成代码文件名：";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 601);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "CommonKey";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainTbl)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem newProject;
        private System.Windows.Forms.ToolStripMenuItem openProject;
        private System.Windows.Forms.ToolStripMenuItem saveProject;
        private System.Windows.Forms.ToolStripMenuItem closeProject;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exitFSM;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 版本号ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button BTN_AddRow;
        private System.Windows.Forms.Button BTN_EditConnect;
        private System.Windows.Forms.Button BTN_DelConnect;
        private System.Windows.Forms.DataGridView MainTbl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BTN_DelRow;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label label1;
    }
}

