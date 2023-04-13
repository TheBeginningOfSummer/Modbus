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
            TC_Set = new TabControl();
            TP_ConnectionSet = new TabPage();
            BTN_Save1 = new Button();
            TB_Port = new TextBox();
            TB_IP = new TextBox();
            label2 = new Label();
            label1 = new Label();
            TP_OtherSet = new TabPage();
            TB_TableName = new TextBox();
            TB_DatabaseName = new TextBox();
            label4 = new Label();
            label3 = new Label();
            BTN_Save2 = new Button();
            GB_Database = new GroupBox();
            GB_TCPIP = new GroupBox();
            TC_Set.SuspendLayout();
            TP_ConnectionSet.SuspendLayout();
            TP_OtherSet.SuspendLayout();
            GB_Database.SuspendLayout();
            GB_TCPIP.SuspendLayout();
            SuspendLayout();
            // 
            // TC_Set
            // 
            TC_Set.Controls.Add(TP_ConnectionSet);
            TC_Set.Controls.Add(TP_OtherSet);
            TC_Set.Dock = DockStyle.Fill;
            TC_Set.Location = new Point(0, 0);
            TC_Set.Name = "TC_Set";
            TC_Set.SelectedIndex = 0;
            TC_Set.Size = new Size(584, 361);
            TC_Set.TabIndex = 0;
            // 
            // TP_ConnectionSet
            // 
            TP_ConnectionSet.Controls.Add(GB_TCPIP);
            TP_ConnectionSet.Controls.Add(BTN_Save1);
            TP_ConnectionSet.Location = new Point(4, 26);
            TP_ConnectionSet.Name = "TP_ConnectionSet";
            TP_ConnectionSet.Padding = new Padding(3);
            TP_ConnectionSet.Size = new Size(576, 331);
            TP_ConnectionSet.TabIndex = 0;
            TP_ConnectionSet.Text = "连接设置";
            TP_ConnectionSet.UseVisualStyleBackColor = true;
            // 
            // BTN_Save1
            // 
            BTN_Save1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BTN_Save1.Location = new Point(493, 300);
            BTN_Save1.Name = "BTN_Save1";
            BTN_Save1.Size = new Size(75, 23);
            BTN_Save1.TabIndex = 4;
            BTN_Save1.Text = "保存";
            BTN_Save1.UseVisualStyleBackColor = true;
            BTN_Save1.Click += BTN_Save1_Click;
            // 
            // TB_Port
            // 
            TB_Port.Location = new Point(80, 48);
            TB_Port.Name = "TB_Port";
            TB_Port.Size = new Size(100, 23);
            TB_Port.TabIndex = 3;
            // 
            // TB_IP
            // 
            TB_IP.Location = new Point(80, 16);
            TB_IP.Name = "TB_IP";
            TB_IP.Size = new Size(100, 23);
            TB_IP.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 48);
            label2.Name = "label2";
            label2.Size = new Size(44, 17);
            label2.TabIndex = 1;
            label2.Text = "端口：";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(55, 17);
            label1.TabIndex = 0;
            label1.Text = "IP地址：";
            // 
            // TP_OtherSet
            // 
            TP_OtherSet.Controls.Add(GB_Database);
            TP_OtherSet.Controls.Add(BTN_Save2);
            TP_OtherSet.Location = new Point(4, 26);
            TP_OtherSet.Name = "TP_OtherSet";
            TP_OtherSet.Padding = new Padding(3);
            TP_OtherSet.Size = new Size(576, 331);
            TP_OtherSet.TabIndex = 1;
            TP_OtherSet.Text = "其他";
            TP_OtherSet.UseVisualStyleBackColor = true;
            // 
            // TB_TableName
            // 
            TB_TableName.Location = new Point(80, 48);
            TB_TableName.Name = "TB_TableName";
            TB_TableName.Size = new Size(100, 23);
            TB_TableName.TabIndex = 4;
            // 
            // TB_DatabaseName
            // 
            TB_DatabaseName.Location = new Point(80, 16);
            TB_DatabaseName.Name = "TB_DatabaseName";
            TB_DatabaseName.Size = new Size(100, 23);
            TB_DatabaseName.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 51);
            label4.Name = "label4";
            label4.Size = new Size(68, 17);
            label4.TabIndex = 2;
            label4.Text = "存储表名：";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 19);
            label3.Name = "label3";
            label3.Size = new Size(68, 17);
            label3.TabIndex = 1;
            label3.Text = "数据库名：";
            // 
            // BTN_Save2
            // 
            BTN_Save2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BTN_Save2.Location = new Point(493, 300);
            BTN_Save2.Name = "BTN_Save2";
            BTN_Save2.Size = new Size(75, 23);
            BTN_Save2.TabIndex = 0;
            BTN_Save2.Text = "保存";
            BTN_Save2.UseVisualStyleBackColor = true;
            BTN_Save2.Click += BTN_Save2_Click;
            // 
            // GB_Database
            // 
            GB_Database.Controls.Add(label3);
            GB_Database.Controls.Add(TB_TableName);
            GB_Database.Controls.Add(label4);
            GB_Database.Controls.Add(TB_DatabaseName);
            GB_Database.Location = new Point(8, 6);
            GB_Database.Name = "GB_Database";
            GB_Database.Size = new Size(190, 82);
            GB_Database.TabIndex = 5;
            GB_Database.TabStop = false;
            GB_Database.Text = "数据库";
            // 
            // GB_TCPIP
            // 
            GB_TCPIP.Controls.Add(label1);
            GB_TCPIP.Controls.Add(label2);
            GB_TCPIP.Controls.Add(TB_Port);
            GB_TCPIP.Controls.Add(TB_IP);
            GB_TCPIP.Location = new Point(8, 6);
            GB_TCPIP.Name = "GB_TCPIP";
            GB_TCPIP.Size = new Size(190, 82);
            GB_TCPIP.TabIndex = 5;
            GB_TCPIP.TabStop = false;
            GB_TCPIP.Text = "TCP/IP";
            // 
            // SetForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 361);
            Controls.Add(TC_Set);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "SetForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "设置";
            TC_Set.ResumeLayout(false);
            TP_ConnectionSet.ResumeLayout(false);
            TP_OtherSet.ResumeLayout(false);
            GB_Database.ResumeLayout(false);
            GB_Database.PerformLayout();
            GB_TCPIP.ResumeLayout(false);
            GB_TCPIP.PerformLayout();
            ResumeLayout(false);
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
        private Button BTN_Save2;
        private Label label4;
        private Label label3;
        private TextBox TB_TableName;
        private TextBox TB_DatabaseName;
        private GroupBox GB_Database;
        private GroupBox GB_TCPIP;
    }
}