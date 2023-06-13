namespace ModbusMaster
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            BTN_Send = new Button();
            toolStrip1 = new ToolStrip();
            TSB_Connect = new ToolStripButton();
            TSB_Disconnect = new ToolStripButton();
            TSTB_Port = new ToolStripTextBox();
            toolStripLabel2 = new ToolStripLabel();
            TSTB_IP = new ToolStripTextBox();
            toolStripLabel1 = new ToolStripLabel();
            TB_Info = new TextBox();
            TB_StartAddress = new TextBox();
            TB_AddressLength = new TextBox();
            GB_AddressSet = new GroupBox();
            label2 = new Label();
            label1 = new Label();
            CB_Register = new ComboBox();
            GB_SetData = new GroupBox();
            BTN_Modify = new Button();
            TB_Value = new TextBox();
            label4 = new Label();
            TB_Address = new TextBox();
            label3 = new Label();
            toolStrip1.SuspendLayout();
            GB_AddressSet.SuspendLayout();
            GB_SetData.SuspendLayout();
            SuspendLayout();
            // 
            // BTN_Send
            // 
            BTN_Send.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BTN_Send.Location = new Point(39, 104);
            BTN_Send.Name = "BTN_Send";
            BTN_Send.Size = new Size(75, 23);
            BTN_Send.TabIndex = 1;
            BTN_Send.Text = "查看";
            BTN_Send.UseVisualStyleBackColor = true;
            BTN_Send.Click += BTN_Send_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new ToolStripItem[] { TSB_Connect, TSB_Disconnect, TSTB_Port, toolStripLabel2, TSTB_IP, toolStripLabel1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // TSB_Connect
            // 
            TSB_Connect.DisplayStyle = ToolStripItemDisplayStyle.Text;
            TSB_Connect.Image = (Image)resources.GetObject("TSB_Connect.Image");
            TSB_Connect.ImageTransparentColor = Color.Magenta;
            TSB_Connect.Name = "TSB_Connect";
            TSB_Connect.Size = new Size(36, 22);
            TSB_Connect.Text = "连接";
            TSB_Connect.Click += TSB_Connect_Click;
            // 
            // TSB_Disconnect
            // 
            TSB_Disconnect.DisplayStyle = ToolStripItemDisplayStyle.Text;
            TSB_Disconnect.Image = (Image)resources.GetObject("TSB_Disconnect.Image");
            TSB_Disconnect.ImageTransparentColor = Color.Magenta;
            TSB_Disconnect.Name = "TSB_Disconnect";
            TSB_Disconnect.Size = new Size(36, 22);
            TSB_Disconnect.Text = "断开";
            TSB_Disconnect.Click += TSB_Disconnect_Click;
            // 
            // TSTB_Port
            // 
            TSTB_Port.Alignment = ToolStripItemAlignment.Right;
            TSTB_Port.Name = "TSTB_Port";
            TSTB_Port.Size = new Size(50, 25);
            TSTB_Port.Text = "9600";
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Alignment = ToolStripItemAlignment.Right;
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(32, 22);
            toolStripLabel2.Text = "Port";
            // 
            // TSTB_IP
            // 
            TSTB_IP.Alignment = ToolStripItemAlignment.Right;
            TSTB_IP.Name = "TSTB_IP";
            TSTB_IP.Size = new Size(100, 25);
            TSTB_IP.Text = "192.168.1.15";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Alignment = ToolStripItemAlignment.Right;
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(19, 22);
            toolStripLabel1.Text = "IP";
            // 
            // TB_Info
            // 
            TB_Info.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TB_Info.Location = new Point(12, 28);
            TB_Info.Multiline = true;
            TB_Info.Name = "TB_Info";
            TB_Info.Size = new Size(776, 276);
            TB_Info.TabIndex = 3;
            // 
            // TB_StartAddress
            // 
            TB_StartAddress.Location = new Point(73, 22);
            TB_StartAddress.Name = "TB_StartAddress";
            TB_StartAddress.Size = new Size(80, 23);
            TB_StartAddress.TabIndex = 4;
            TB_StartAddress.Text = "0";
            // 
            // TB_AddressLength
            // 
            TB_AddressLength.Location = new Point(73, 51);
            TB_AddressLength.Name = "TB_AddressLength";
            TB_AddressLength.Size = new Size(80, 23);
            TB_AddressLength.TabIndex = 5;
            TB_AddressLength.Text = "100";
            // 
            // GB_AddressSet
            // 
            GB_AddressSet.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            GB_AddressSet.Controls.Add(label2);
            GB_AddressSet.Controls.Add(TB_StartAddress);
            GB_AddressSet.Controls.Add(label1);
            GB_AddressSet.Controls.Add(TB_AddressLength);
            GB_AddressSet.Controls.Add(BTN_Send);
            GB_AddressSet.Location = new Point(12, 311);
            GB_AddressSet.Name = "GB_AddressSet";
            GB_AddressSet.Size = new Size(170, 134);
            GB_AddressSet.TabIndex = 6;
            GB_AddressSet.TabStop = false;
            GB_AddressSet.Text = "地址设置";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 54);
            label2.Name = "label2";
            label2.Size = new Size(56, 17);
            label2.TabIndex = 8;
            label2.Text = "地址长度";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 25);
            label1.Name = "label1";
            label1.Size = new Size(56, 17);
            label1.TabIndex = 7;
            label1.Text = "起始地址";
            // 
            // CB_Register
            // 
            CB_Register.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            CB_Register.FormattingEnabled = true;
            CB_Register.Items.AddRange(new object[] { "保持寄存器", "输入寄存器" });
            CB_Register.Location = new Point(667, 310);
            CB_Register.Name = "CB_Register";
            CB_Register.Size = new Size(121, 25);
            CB_Register.TabIndex = 7;
            CB_Register.Text = "保持寄存器";
            CB_Register.SelectedValueChanged += CB_Register_SelectedValueChanged;
            // 
            // GB_SetData
            // 
            GB_SetData.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            GB_SetData.Controls.Add(BTN_Modify);
            GB_SetData.Controls.Add(TB_Value);
            GB_SetData.Controls.Add(label4);
            GB_SetData.Controls.Add(TB_Address);
            GB_SetData.Controls.Add(label3);
            GB_SetData.Location = new Point(188, 311);
            GB_SetData.Name = "GB_SetData";
            GB_SetData.Size = new Size(170, 134);
            GB_SetData.TabIndex = 8;
            GB_SetData.TabStop = false;
            GB_SetData.Text = "保持寄存器修改";
            // 
            // BTN_Modify
            // 
            BTN_Modify.Location = new Point(42, 104);
            BTN_Modify.Name = "BTN_Modify";
            BTN_Modify.Size = new Size(75, 23);
            BTN_Modify.TabIndex = 9;
            BTN_Modify.Text = "修改";
            BTN_Modify.UseVisualStyleBackColor = true;
            BTN_Modify.Click += BTN_Modify_Click;
            // 
            // TB_Value
            // 
            TB_Value.Location = new Point(54, 51);
            TB_Value.Name = "TB_Value";
            TB_Value.Size = new Size(100, 23);
            TB_Value.TabIndex = 3;
            TB_Value.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 54);
            label4.Name = "label4";
            label4.Size = new Size(20, 17);
            label4.TabIndex = 2;
            label4.Text = "值";
            // 
            // TB_Address
            // 
            TB_Address.Location = new Point(54, 22);
            TB_Address.Name = "TB_Address";
            TB_Address.Size = new Size(100, 23);
            TB_Address.TabIndex = 1;
            TB_Address.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 25);
            label3.Name = "label3";
            label3.Size = new Size(32, 17);
            label3.TabIndex = 0;
            label3.Text = "地址";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(GB_SetData);
            Controls.Add(CB_Register);
            Controls.Add(GB_AddressSet);
            Controls.Add(TB_Info);
            Controls.Add(toolStrip1);
            Name = "Form1";
            Text = "ModbusMaster";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            GB_AddressSet.ResumeLayout(false);
            GB_AddressSet.PerformLayout();
            GB_SetData.ResumeLayout(false);
            GB_SetData.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button BTN_Send;
        private ToolStrip toolStrip1;
        private ToolStripButton TSB_Connect;
        private ToolStripButton TSB_Disconnect;
        private ToolStripTextBox TSTB_Port;
        private ToolStripLabel toolStripLabel2;
        private ToolStripTextBox TSTB_IP;
        private ToolStripLabel toolStripLabel1;
        private TextBox TB_Info;
        private TextBox TB_StartAddress;
        private TextBox TB_AddressLength;
        private GroupBox GB_AddressSet;
        private Label label2;
        private Label label1;
        private ComboBox CB_Register;
        private GroupBox GB_SetData;
        private TextBox TB_Address;
        private Label label3;
        private TextBox TB_Value;
        private Label label4;
        private Button BTN_Modify;
    }
}