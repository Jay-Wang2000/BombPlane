namespace BombPlanes_final
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Server_Connection = new System.Windows.Forms.Button();
            this.Client_Connection = new System.Windows.Forms.Button();
            this.AI = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(251, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "目标主机：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(324, 160);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 27);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(324, 224);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(200, 27);
            this.textBox2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(271, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port:";
            // 
            // Server_Connection
            // 
            this.Server_Connection.Location = new System.Drawing.Point(265, 343);
            this.Server_Connection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Server_Connection.Name = "Server_Connection";
            this.Server_Connection.Size = new System.Drawing.Size(75, 31);
            this.Server_Connection.TabIndex = 4;
            this.Server_Connection.Text = "房主";
            this.Server_Connection.UseVisualStyleBackColor = true;
            this.Server_Connection.Click += new System.EventHandler(this.Server_Connection_ClickAsync);
            // 
            // Client_Connection
            // 
            this.Client_Connection.Location = new System.Drawing.Point(364, 343);
            this.Client_Connection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Client_Connection.Name = "Client_Connection";
            this.Client_Connection.Size = new System.Drawing.Size(75, 31);
            this.Client_Connection.TabIndex = 5;
            this.Client_Connection.Text = "连接";
            this.Client_Connection.UseVisualStyleBackColor = true;
            this.Client_Connection.Click += new System.EventHandler(this.Client_Connection_Click);
            // 
            // AI
            // 
            this.AI.Location = new System.Drawing.Point(463, 343);
            this.AI.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AI.Name = "AI";
            this.AI.Size = new System.Drawing.Size(75, 31);
            this.AI.TabIndex = 6;
            this.AI.Text = "AI";
            this.AI.UseVisualStyleBackColor = true;
            this.AI.Click += new System.EventHandler(this.button3_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.AI);
            this.Controls.Add(this.Client_Connection);
            this.Controls.Add(this.Server_Connection);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Server_Connection;
        private System.Windows.Forms.Button Client_Connection;
        private System.Windows.Forms.Button AI;
    }
}

