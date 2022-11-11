namespace BombPlanes_final
{
    partial class Battle
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
            this.gridNetworkMyself = new BombPlanes_final.GridNetwork();
            this.gridNetworkCounter = new BombPlanes_final.GridNetwork();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MainButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gridNetworkMyself
            // 
            this.gridNetworkMyself.Location = new System.Drawing.Point(158, 34);
            this.gridNetworkMyself.Name = "gridNetworkMyself";
            this.gridNetworkMyself.PlaneVisiblibity = false;
            this.gridNetworkMyself.Size = new System.Drawing.Size(383, 386);
            this.gridNetworkMyself.TabIndex = 1;
            // 
            // gridNetworkCounter
            // 
            this.gridNetworkCounter.Location = new System.Drawing.Point(619, 34);
            this.gridNetworkCounter.Name = "gridNetworkCounter";
            this.gridNetworkCounter.PlaneVisiblibity = false;
            this.gridNetworkCounter.Size = new System.Drawing.Size(383, 386);
            this.gridNetworkCounter.TabIndex = 2;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(189, 474);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(242, 242);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(290, 423);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "我方";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(729, 423);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "敌方";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(146, 474);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Log:";
            // 
            // MainButton
            // 
            this.MainButton.Location = new System.Drawing.Point(512, 423);
            this.MainButton.Name = "MainButton";
            this.MainButton.Size = new System.Drawing.Size(94, 29);
            this.MainButton.TabIndex = 7;
            this.MainButton.Text = "准备";
            this.MainButton.UseVisualStyleBackColor = true;
            this.MainButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // Battle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 728);
            this.Controls.Add(this.MainButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.gridNetworkCounter);
            this.Controls.Add(this.gridNetworkMyself);
            this.Name = "Battle";
            this.Text = "Battle";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Battle_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GridNetwork gridNetworkMyself;
        private GridNetwork gridNetworkCounter;
        private ListView listView1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button MainButton;
    }
}