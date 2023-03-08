namespace Modbus
{
    partial class SetForm
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
            this.TC_Set = new System.Windows.Forms.TabControl();
            this.TP_ConnectionSet = new System.Windows.Forms.TabPage();
            this.TB_Port = new System.Windows.Forms.TextBox();
            this.TB_IP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TP_OtherSet = new System.Windows.Forms.TabPage();
            this.BTN_Save1 = new System.Windows.Forms.Button();
            this.TC_Set.SuspendLayout();
            this.TP_ConnectionSet.SuspendLayout();
            this.SuspendLayout();
            // 
            // TC_Set
            // 
            this.TC_Set.Controls.Add(this.TP_ConnectionSet);
            this.TC_Set.Controls.Add(this.TP_OtherSet);
            this.TC_Set.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TC_Set.Location = new System.Drawing.Point(0, 0);
            this.TC_Set.Name = "TC_Set";
            this.TC_Set.SelectedIndex = 0;
            this.TC_Set.Size = new System.Drawing.Size(584, 361);
            this.TC_Set.TabIndex = 0;
            // 
            // TP_ConnectionSet
            // 
            this.TP_ConnectionSet.Controls.Add(this.BTN_Save1);
            this.TP_ConnectionSet.Controls.Add(this.TB_Port);
            this.TP_ConnectionSet.Controls.Add(this.TB_IP);
            this.TP_ConnectionSet.Controls.Add(this.label2);
            this.TP_ConnectionSet.Controls.Add(this.label1);
            this.TP_ConnectionSet.Location = new System.Drawing.Point(4, 26);
            this.TP_ConnectionSet.Name = "TP_ConnectionSet";
            this.TP_ConnectionSet.Padding = new System.Windows.Forms.Padding(3);
            this.TP_ConnectionSet.Size = new System.Drawing.Size(576, 331);
            this.TP_ConnectionSet.TabIndex = 0;
            this.TP_ConnectionSet.Text = "连接设置";
            this.TP_ConnectionSet.UseVisualStyleBackColor = true;
            // 
            // TB_Port
            // 
            this.TB_Port.Location = new System.Drawing.Point(59, 44);
            this.TB_Port.Name = "TB_Port";
            this.TB_Port.Size = new System.Drawing.Size(100, 23);
            this.TB_Port.TabIndex = 3;
            // 
            // TB_IP
            // 
            this.TB_IP.Location = new System.Drawing.Point(59, 12);
            this.TB_IP.Name = "TB_IP";
            this.TB_IP.Size = new System.Drawing.Size(100, 23);
            this.TB_IP.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "端口：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP地址：";
            // 
            // TP_OtherSet
            // 
            this.TP_OtherSet.Location = new System.Drawing.Point(4, 26);
            this.TP_OtherSet.Name = "TP_OtherSet";
            this.TP_OtherSet.Padding = new System.Windows.Forms.Padding(3);
            this.TP_OtherSet.Size = new System.Drawing.Size(576, 331);
            this.TP_OtherSet.TabIndex = 1;
            this.TP_OtherSet.Text = "其他";
            this.TP_OtherSet.UseVisualStyleBackColor = true;
            // 
            // BTN_Save1
            // 
            this.BTN_Save1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_Save1.Location = new System.Drawing.Point(493, 300);
            this.BTN_Save1.Name = "BTN_Save1";
            this.BTN_Save1.Size = new System.Drawing.Size(75, 23);
            this.BTN_Save1.TabIndex = 4;
            this.BTN_Save1.Text = "保存";
            this.BTN_Save1.UseVisualStyleBackColor = true;
            this.BTN_Save1.Click += new System.EventHandler(this.BTN_Save1_Click);
            // 
            // SetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.TC_Set);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置";
            this.TC_Set.ResumeLayout(false);
            this.TP_ConnectionSet.ResumeLayout(false);
            this.TP_ConnectionSet.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl TC_Set;
        private TabPage TP_ConnectionSet;
        private TabPage TP_OtherSet;
        private Label label2;
        private Label label1;
        public TextBox TB_Port;
        public TextBox TB_IP;
        private Button BTN_Save1;
    }
}