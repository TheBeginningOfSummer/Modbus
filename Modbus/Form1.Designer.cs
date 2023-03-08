namespace Modbus
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
            this.TC_Main = new System.Windows.Forms.TabControl();
            this.TP_AutoPage = new System.Windows.Forms.TabPage();
            this.LB_ConnectionStatus = new System.Windows.Forms.Label();
            this.LB_连接状态 = new System.Windows.Forms.Label();
            this.BTN_Test = new System.Windows.Forms.Button();
            this.LB_AlarmStatus = new System.Windows.Forms.Label();
            this.LB_报警状态 = new System.Windows.Forms.Label();
            this.LB_DeviceStatus = new System.Windows.Forms.Label();
            this.LB_设备状态 = new System.Windows.Forms.Label();
            this.BTN_Stop = new System.Windows.Forms.Button();
            this.BTN_Start = new System.Windows.Forms.Button();
            this.BTN_Manual = new System.Windows.Forms.Button();
            this.BTN_Auto = new System.Windows.Forms.Button();
            this.TS_Connection = new System.Windows.Forms.ToolStrip();
            this.TSB_Listening = new System.Windows.Forms.ToolStripButton();
            this.TSB_Set = new System.Windows.Forms.ToolStripButton();
            this.TP_DataPage = new System.Windows.Forms.TabPage();
            this.GB_Inquire = new System.Windows.Forms.GroupBox();
            this.BTN_Inquire = new System.Windows.Forms.Button();
            this.DTP_Max = new System.Windows.Forms.DateTimePicker();
            this.DTP_Min = new System.Windows.Forms.DateTimePicker();
            this.DGV_InquireData = new System.Windows.Forms.DataGridView();
            this.TC_Main.SuspendLayout();
            this.TP_AutoPage.SuspendLayout();
            this.TS_Connection.SuspendLayout();
            this.TP_DataPage.SuspendLayout();
            this.GB_Inquire.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_InquireData)).BeginInit();
            this.SuspendLayout();
            // 
            // TC_Main
            // 
            this.TC_Main.Controls.Add(this.TP_AutoPage);
            this.TC_Main.Controls.Add(this.TP_DataPage);
            this.TC_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TC_Main.Location = new System.Drawing.Point(0, 0);
            this.TC_Main.Name = "TC_Main";
            this.TC_Main.SelectedIndex = 0;
            this.TC_Main.Size = new System.Drawing.Size(800, 450);
            this.TC_Main.TabIndex = 0;
            // 
            // TP_AutoPage
            // 
            this.TP_AutoPage.Controls.Add(this.LB_ConnectionStatus);
            this.TP_AutoPage.Controls.Add(this.LB_连接状态);
            this.TP_AutoPage.Controls.Add(this.BTN_Test);
            this.TP_AutoPage.Controls.Add(this.LB_AlarmStatus);
            this.TP_AutoPage.Controls.Add(this.LB_报警状态);
            this.TP_AutoPage.Controls.Add(this.LB_DeviceStatus);
            this.TP_AutoPage.Controls.Add(this.LB_设备状态);
            this.TP_AutoPage.Controls.Add(this.BTN_Stop);
            this.TP_AutoPage.Controls.Add(this.BTN_Start);
            this.TP_AutoPage.Controls.Add(this.BTN_Manual);
            this.TP_AutoPage.Controls.Add(this.BTN_Auto);
            this.TP_AutoPage.Controls.Add(this.TS_Connection);
            this.TP_AutoPage.Location = new System.Drawing.Point(4, 26);
            this.TP_AutoPage.Name = "TP_AutoPage";
            this.TP_AutoPage.Padding = new System.Windows.Forms.Padding(3);
            this.TP_AutoPage.Size = new System.Drawing.Size(792, 420);
            this.TP_AutoPage.TabIndex = 0;
            this.TP_AutoPage.Text = "主界面";
            this.TP_AutoPage.UseVisualStyleBackColor = true;
            // 
            // LB_ConnectionStatus
            // 
            this.LB_ConnectionStatus.BackColor = System.Drawing.Color.Silver;
            this.LB_ConnectionStatus.Location = new System.Drawing.Point(99, 99);
            this.LB_ConnectionStatus.Name = "LB_ConnectionStatus";
            this.LB_ConnectionStatus.Size = new System.Drawing.Size(30, 15);
            this.LB_ConnectionStatus.TabIndex = 11;
            this.LB_ConnectionStatus.Text = "     ";
            // 
            // LB_连接状态
            // 
            this.LB_连接状态.AutoSize = true;
            this.LB_连接状态.Location = new System.Drawing.Point(22, 99);
            this.LB_连接状态.Name = "LB_连接状态";
            this.LB_连接状态.Size = new System.Drawing.Size(59, 17);
            this.LB_连接状态.TabIndex = 10;
            this.LB_连接状态.Text = "连接状态:";
            // 
            // BTN_Test
            // 
            this.BTN_Test.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BTN_Test.Location = new System.Drawing.Point(555, 320);
            this.BTN_Test.Name = "BTN_Test";
            this.BTN_Test.Size = new System.Drawing.Size(75, 23);
            this.BTN_Test.TabIndex = 9;
            this.BTN_Test.Text = "测试";
            this.BTN_Test.UseVisualStyleBackColor = true;
            this.BTN_Test.Click += new System.EventHandler(this.BTN_Test_Click);
            // 
            // LB_AlarmStatus
            // 
            this.LB_AlarmStatus.BackColor = System.Drawing.Color.Silver;
            this.LB_AlarmStatus.Location = new System.Drawing.Point(99, 71);
            this.LB_AlarmStatus.Name = "LB_AlarmStatus";
            this.LB_AlarmStatus.Size = new System.Drawing.Size(30, 15);
            this.LB_AlarmStatus.TabIndex = 8;
            this.LB_AlarmStatus.Text = "     ";
            // 
            // LB_报警状态
            // 
            this.LB_报警状态.AutoSize = true;
            this.LB_报警状态.Location = new System.Drawing.Point(22, 71);
            this.LB_报警状态.Name = "LB_报警状态";
            this.LB_报警状态.Size = new System.Drawing.Size(71, 17);
            this.LB_报警状态.TabIndex = 7;
            this.LB_报警状态.Text = "报警灯状态:";
            // 
            // LB_DeviceStatus
            // 
            this.LB_DeviceStatus.AutoSize = true;
            this.LB_DeviceStatus.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LB_DeviceStatus.Location = new System.Drawing.Point(87, 44);
            this.LB_DeviceStatus.Name = "LB_DeviceStatus";
            this.LB_DeviceStatus.Size = new System.Drawing.Size(54, 17);
            this.LB_DeviceStatus.TabIndex = 6;
            this.LB_DeviceStatus.Text = "Default";
            // 
            // LB_设备状态
            // 
            this.LB_设备状态.AutoSize = true;
            this.LB_设备状态.Location = new System.Drawing.Point(22, 44);
            this.LB_设备状态.Name = "LB_设备状态";
            this.LB_设备状态.Size = new System.Drawing.Size(59, 17);
            this.LB_设备状态.TabIndex = 5;
            this.LB_设备状态.Text = "设备状态:";
            // 
            // BTN_Stop
            // 
            this.BTN_Stop.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BTN_Stop.Location = new System.Drawing.Point(474, 320);
            this.BTN_Stop.Name = "BTN_Stop";
            this.BTN_Stop.Size = new System.Drawing.Size(75, 23);
            this.BTN_Stop.TabIndex = 4;
            this.BTN_Stop.Text = "停止";
            this.BTN_Stop.UseVisualStyleBackColor = true;
            this.BTN_Stop.Click += new System.EventHandler(this.BTN_Stop_Click);
            // 
            // BTN_Start
            // 
            this.BTN_Start.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BTN_Start.Location = new System.Drawing.Point(393, 320);
            this.BTN_Start.Name = "BTN_Start";
            this.BTN_Start.Size = new System.Drawing.Size(75, 23);
            this.BTN_Start.TabIndex = 3;
            this.BTN_Start.Text = "启动";
            this.BTN_Start.UseVisualStyleBackColor = true;
            this.BTN_Start.Click += new System.EventHandler(this.BTN_Start_Click);
            // 
            // BTN_Manual
            // 
            this.BTN_Manual.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BTN_Manual.Location = new System.Drawing.Point(312, 320);
            this.BTN_Manual.Name = "BTN_Manual";
            this.BTN_Manual.Size = new System.Drawing.Size(75, 23);
            this.BTN_Manual.TabIndex = 2;
            this.BTN_Manual.Text = "手动";
            this.BTN_Manual.UseVisualStyleBackColor = true;
            this.BTN_Manual.Click += new System.EventHandler(this.BTN_Manual_Click);
            // 
            // BTN_Auto
            // 
            this.BTN_Auto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BTN_Auto.Location = new System.Drawing.Point(231, 320);
            this.BTN_Auto.Name = "BTN_Auto";
            this.BTN_Auto.Size = new System.Drawing.Size(75, 23);
            this.BTN_Auto.TabIndex = 1;
            this.BTN_Auto.Text = "自动";
            this.BTN_Auto.UseVisualStyleBackColor = true;
            this.BTN_Auto.Click += new System.EventHandler(this.BTN_Auto_Click);
            // 
            // TS_Connection
            // 
            this.TS_Connection.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.TS_Connection.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSB_Listening,
            this.TSB_Set});
            this.TS_Connection.Location = new System.Drawing.Point(3, 3);
            this.TS_Connection.Name = "TS_Connection";
            this.TS_Connection.Size = new System.Drawing.Size(786, 25);
            this.TS_Connection.TabIndex = 0;
            this.TS_Connection.Text = "toolStrip1";
            // 
            // TSB_Listening
            // 
            this.TSB_Listening.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TSB_Listening.Image = ((System.Drawing.Image)(resources.GetObject("TSB_Listening.Image")));
            this.TSB_Listening.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Listening.Name = "TSB_Listening";
            this.TSB_Listening.Size = new System.Drawing.Size(60, 22);
            this.TSB_Listening.Text = "开始监听";
            this.TSB_Listening.Click += new System.EventHandler(this.TSB_Listening_Click);
            // 
            // TSB_Set
            // 
            this.TSB_Set.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TSB_Set.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TSB_Set.Image = ((System.Drawing.Image)(resources.GetObject("TSB_Set.Image")));
            this.TSB_Set.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Set.Name = "TSB_Set";
            this.TSB_Set.Size = new System.Drawing.Size(36, 22);
            this.TSB_Set.Text = "设置";
            this.TSB_Set.Click += new System.EventHandler(this.TSB_Set_Click);
            // 
            // TP_DataPage
            // 
            this.TP_DataPage.Controls.Add(this.GB_Inquire);
            this.TP_DataPage.Controls.Add(this.DGV_InquireData);
            this.TP_DataPage.Location = new System.Drawing.Point(4, 26);
            this.TP_DataPage.Name = "TP_DataPage";
            this.TP_DataPage.Padding = new System.Windows.Forms.Padding(3);
            this.TP_DataPage.Size = new System.Drawing.Size(792, 420);
            this.TP_DataPage.TabIndex = 1;
            this.TP_DataPage.Text = "数据";
            this.TP_DataPage.UseVisualStyleBackColor = true;
            // 
            // GB_Inquire
            // 
            this.GB_Inquire.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GB_Inquire.Controls.Add(this.BTN_Inquire);
            this.GB_Inquire.Controls.Add(this.DTP_Max);
            this.GB_Inquire.Controls.Add(this.DTP_Min);
            this.GB_Inquire.Location = new System.Drawing.Point(605, 3);
            this.GB_Inquire.Name = "GB_Inquire";
            this.GB_Inquire.Size = new System.Drawing.Size(179, 111);
            this.GB_Inquire.TabIndex = 1;
            this.GB_Inquire.TabStop = false;
            this.GB_Inquire.Text = "查询";
            // 
            // BTN_Inquire
            // 
            this.BTN_Inquire.Location = new System.Drawing.Point(6, 80);
            this.BTN_Inquire.Name = "BTN_Inquire";
            this.BTN_Inquire.Size = new System.Drawing.Size(75, 23);
            this.BTN_Inquire.TabIndex = 2;
            this.BTN_Inquire.Text = "查询";
            this.BTN_Inquire.UseVisualStyleBackColor = true;
            this.BTN_Inquire.Click += new System.EventHandler(this.BTN_Inquire_Click);
            // 
            // DTP_Max
            // 
            this.DTP_Max.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.DTP_Max.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTP_Max.Location = new System.Drawing.Point(6, 51);
            this.DTP_Max.Name = "DTP_Max";
            this.DTP_Max.Size = new System.Drawing.Size(167, 23);
            this.DTP_Max.TabIndex = 1;
            // 
            // DTP_Min
            // 
            this.DTP_Min.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.DTP_Min.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTP_Min.Location = new System.Drawing.Point(6, 22);
            this.DTP_Min.Name = "DTP_Min";
            this.DTP_Min.Size = new System.Drawing.Size(167, 23);
            this.DTP_Min.TabIndex = 0;
            // 
            // DGV_InquireData
            // 
            this.DGV_InquireData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV_InquireData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DGV_InquireData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_InquireData.Location = new System.Drawing.Point(0, 0);
            this.DGV_InquireData.Name = "DGV_InquireData";
            this.DGV_InquireData.ReadOnly = true;
            this.DGV_InquireData.RowTemplate.Height = 25;
            this.DGV_InquireData.Size = new System.Drawing.Size(599, 420);
            this.DGV_InquireData.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TC_Main);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "称重";
            this.TC_Main.ResumeLayout(false);
            this.TP_AutoPage.ResumeLayout(false);
            this.TP_AutoPage.PerformLayout();
            this.TS_Connection.ResumeLayout(false);
            this.TS_Connection.PerformLayout();
            this.TP_DataPage.ResumeLayout(false);
            this.GB_Inquire.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_InquireData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl TC_Main;
        private TabPage TP_AutoPage;
        private TabPage TP_DataPage;
        private ToolStrip TS_Connection;
        private ToolStripButton TSB_Listening;
        private ToolStripButton TSB_Set;
        private Button BTN_Manual;
        private Button BTN_Auto;
        private DataGridView DGV_InquireData;
        private GroupBox GB_Inquire;
        private DateTimePicker DTP_Max;
        private DateTimePicker DTP_Min;
        private Button BTN_Inquire;
        private Button BTN_Stop;
        private Button BTN_Start;
        private Label LB_DeviceStatus;
        private Label LB_设备状态;
        private Label LB_报警状态;
        private Label LB_AlarmStatus;
        private Button BTN_Test;
        private Label LB_连接状态;
        private Label LB_ConnectionStatus;
    }
}