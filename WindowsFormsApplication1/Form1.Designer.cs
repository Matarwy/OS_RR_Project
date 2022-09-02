using System;

namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Process = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Burst_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Arrival_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtbox_number_processes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.button1 = new System.Windows.Forms.Button();
            this.txtQuantum = new System.Windows.Forms.TextBox();
            this.lblQuantum = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.reset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Process,
            this.Burst_Time,
            this.Arrival_Time,});
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.Location = new System.Drawing.Point(617, 13);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 30;
            this.dataGridView1.Size = new System.Drawing.Size(496, 330);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Process
            // 
            this.Process.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Process.HeaderText = "Process";
            this.Process.MinimumWidth = 20;
            this.Process.Name = "Process";
            this.Process.Width = 114;
            // 
            // Burst_Time
            // 
            this.Burst_Time.HeaderText = "Burst_Time";
            this.Burst_Time.MinimumWidth = 6;
            this.Burst_Time.Name = "Burst_Time";
            this.Burst_Time.Width = 120;
            // 
            // Arrival_Time
            // 
            this.Arrival_Time.HeaderText = "Arrival_Time";
            this.Arrival_Time.MinimumWidth = 6;
            this.Arrival_Time.Name = "Arrival_Time";
            this.Arrival_Time.Width = 145;

            // 
            // txtbox_number_processes
            // 
            this.txtbox_number_processes.Location = new System.Drawing.Point(354, 165);
            this.txtbox_number_processes.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtbox_number_processes.Multiline = true;
            this.txtbox_number_processes.Name = "txtbox_number_processes";
            this.txtbox_number_processes.Size = new System.Drawing.Size(74, 38);
            this.txtbox_number_processes.TabIndex = 1;
            this.txtbox_number_processes.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 11;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(10, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(24, 636);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(886, 383);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(227, 67);
            this.button1.TabIndex = 7;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtQuantum
            // 
            this.txtQuantum.Location = new System.Drawing.Point(354, 90);
            this.txtQuantum.Multiline = true;
            this.txtQuantum.Name = "txtQuantum";
            this.txtQuantum.Size = new System.Drawing.Size(74, 36);
            this.txtQuantum.TabIndex = 8;
            this.txtQuantum.TextChanged += new System.EventHandler(this.txtQuantum_TextChanged);
            // 
            // lblQuantum
            // 
            this.lblQuantum.AutoSize = true;
            this.lblQuantum.Location = new System.Drawing.Point(52, 90);
            this.lblQuantum.Name = "lblQuantum";
            this.lblQuantum.Size = new System.Drawing.Size(223, 24);
            this.lblQuantum.TabIndex = 9;
            this.lblQuantum.Text = "Enter desired quantum";
            this.lblQuantum.Click += new System.EventHandler(this.lblQuantum_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // reset
            // 
            this.reset.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.reset.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.reset.Location = new System.Drawing.Point(617, 383);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(215, 67);
            this.reset.TabIndex = 10;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = false;
            this.reset.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 636);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.lblQuantum);
            this.Controls.Add(this.txtQuantum);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbox_number_processes);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void lblQuantum_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtbox_number_processes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtQuantum;
        private System.Windows.Forms.Label lblQuantum;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.DataGridViewTextBoxColumn Process;
        private System.Windows.Forms.DataGridViewTextBoxColumn Burst_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Arrival_Time;
    }
}

