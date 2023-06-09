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
            BTN_Connection = new Button();
            BTN_Send = new Button();
            SuspendLayout();
            // 
            // BTN_Connection
            // 
            BTN_Connection.Location = new Point(372, 142);
            BTN_Connection.Name = "BTN_Connection";
            BTN_Connection.Size = new Size(75, 23);
            BTN_Connection.TabIndex = 0;
            BTN_Connection.Text = "连接";
            BTN_Connection.UseVisualStyleBackColor = true;
            BTN_Connection.Click += BTN_Connection_Click;
            // 
            // BTN_Send
            // 
            BTN_Send.Location = new Point(372, 209);
            BTN_Send.Name = "BTN_Send";
            BTN_Send.Size = new Size(75, 23);
            BTN_Send.TabIndex = 1;
            BTN_Send.Text = "发送";
            BTN_Send.UseVisualStyleBackColor = true;
            BTN_Send.Click += BTN_Send_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BTN_Send);
            Controls.Add(BTN_Connection);
            Name = "Form1";
            Text = "ModbusMaster";
            ResumeLayout(false);
        }

        #endregion

        private Button BTN_Connection;
        private Button BTN_Send;
    }
}