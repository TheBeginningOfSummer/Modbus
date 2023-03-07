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
            this.BTN_Manual = new System.Windows.Forms.Button();
            this.BTN_Auto = new System.Windows.Forms.Button();
            this.TS_Connection = new System.Windows.Forms.ToolStrip();
            this.TSB_Listening = new System.Windows.Forms.ToolStripButton();
            this.TSB_Stop = new System.Windows.Forms.ToolStripButton();
            this.TSB_Save = new System.Windows.Forms.ToolStripButton();
            this.TSTB_Port = new System.Windows.Forms.ToolStripTextBox();
            this.TSL_端口 = new System.Windows.Forms.ToolStripLabel();
            this.TSTB_IP = new System.Windows.Forms.ToolStripTextBox();
            this.TSL_IP = new System.Windows.Forms.ToolStripLabel();
            this.TP_DataPage = new System.Windows.Forms.TabPage();
            this.GB_Inquire = new System.Windows.Forms.GroupBox();
            this.BTN_Test = new System.Windows.Forms.Button();
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
            // BTN_Manual
            // 
            this.BTN_Manual.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BTN_Manual.Location = new System.Drawing.Point(480, 320);
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
            this.TSB_Stop,
            this.TSB_Save,
            this.TSTB_Port,
            this.TSL_端口,
            this.TSTB_IP,
            this.TSL_IP});
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
            // TSB_Stop
            // 
            this.TSB_Stop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TSB_Stop.Enabled = false;
            this.TSB_Stop.Image = ((System.Drawing.Image)(resources.GetObject("TSB_Stop.Image")));
            this.TSB_Stop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Stop.Name = "TSB_Stop";
            this.TSB_Stop.Size = new System.Drawing.Size(60, 22);
            this.TSB_Stop.Text = "停止监听";
            this.TSB_Stop.Click += new System.EventHandler(this.TSB_Stop_Click);
            // 
            // TSB_Save
            // 
            this.TSB_Save.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TSB_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TSB_Save.Image = ((System.Drawing.Image)(resources.GetObject("TSB_Save.Image")));
            this.TSB_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Save.Name = "TSB_Save";
            this.TSB_Save.Size = new System.Drawing.Size(60, 22);
            this.TSB_Save.Text = "保存地址";
            this.TSB_Save.Click += new System.EventHandler(this.TSB_Save_Click);
            // 
            // TSTB_Port
            // 
            this.TSTB_Port.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TSTB_Port.Name = "TSTB_Port";
            this.TSTB_Port.Size = new System.Drawing.Size(50, 25);
            // 
            // TSL_端口
            // 
            this.TSL_端口.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TSL_端口.Name = "TSL_端口";
            this.TSL_端口.Size = new System.Drawing.Size(44, 22);
            this.TSL_端口.Text = "端口：";
            // 
            // TSTB_IP
            // 
            this.TSTB_IP.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TSTB_IP.Name = "TSTB_IP";
            this.TSTB_IP.Size = new System.Drawing.Size(100, 25);
            // 
            // TSL_IP
            // 
            this.TSL_IP.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TSL_IP.Name = "TSL_IP";
            this.TSL_IP.Size = new System.Drawing.Size(31, 22);
            this.TSL_IP.Text = "IP：";
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
            this.GB_Inquire.Controls.Add(this.BTN_Test);
            this.GB_Inquire.Controls.Add(this.BTN_Inquire);
            this.GB_Inquire.Controls.Add(this.DTP_Max);
            this.GB_Inquire.Controls.Add(this.DTP_Min);
            this.GB_Inquire.Location = new System.Drawing.Point(605, 3);
            this.GB_Inquire.Name = "GB_Inquire";
            this.GB_Inquire.Size = new System.Drawing.Size(179, 172);
            this.GB_Inquire.TabIndex = 1;
            this.GB_Inquire.TabStop = false;
            this.GB_Inquire.Text = "查询";
            // 
            // BTN_Test
            // 
            this.BTN_Test.Location = new System.Drawing.Point(98, 80);
            this.BTN_Test.Name = "BTN_Test";
            this.BTN_Test.Size = new System.Drawing.Size(75, 23);
            this.BTN_Test.TabIndex = 3;
            this.BTN_Test.Text = "测试";
            this.BTN_Test.UseVisualStyleBackColor = true;
            this.BTN_Test.Click += new System.EventHandler(this.BTN_Test_Click);
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
        private ToolStripButton TSB_Stop;
        private ToolStripButton TSB_Save;
        private ToolStripTextBox TSTB_Port;
        private ToolStripLabel TSL_端口;
        private ToolStripTextBox TSTB_IP;
        private ToolStripLabel TSL_IP;
        private Button BTN_Manual;
        private Button BTN_Auto;
        private DataGridView DGV_InquireData;
        private GroupBox GB_Inquire;
        private DateTimePicker DTP_Max;
        private DateTimePicker DTP_Min;
        private Button BTN_Inquire;
        private Button BTN_Test;
    }
}