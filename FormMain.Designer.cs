
namespace SensorRead
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Read = new System.Windows.Forms.Button();
            this.tb_Msg = new System.Windows.Forms.TextBox();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.btn_test = new System.Windows.Forms.Button();
            this.cbConnect = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btn_Read
            // 
            this.btn_Read.Location = new System.Drawing.Point(9, 10);
            this.btn_Read.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Read.Name = "btn_Read";
            this.btn_Read.Size = new System.Drawing.Size(120, 30);
            this.btn_Read.TabIndex = 0;
            this.btn_Read.Text = "读取数据";
            this.btn_Read.UseVisualStyleBackColor = true;
            this.btn_Read.Click += new System.EventHandler(this.btn_Read_Click);
            // 
            // tb_Msg
            // 
            this.tb_Msg.Location = new System.Drawing.Point(10, 45);
            this.tb_Msg.Margin = new System.Windows.Forms.Padding(2);
            this.tb_Msg.Multiline = true;
            this.tb_Msg.Name = "tb_Msg";
            this.tb_Msg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_Msg.Size = new System.Drawing.Size(894, 306);
            this.tb_Msg.TabIndex = 1;
            // 
            // btn_Stop
            // 
            this.btn_Stop.Location = new System.Drawing.Point(134, 10);
            this.btn_Stop.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(120, 30);
            this.btn_Stop.TabIndex = 2;
            this.btn_Stop.Text = "停止读取";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // btn_test
            // 
            this.btn_test.Location = new System.Drawing.Point(258, 10);
            this.btn_test.Margin = new System.Windows.Forms.Padding(2);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(120, 30);
            this.btn_test.TabIndex = 3;
            this.btn_test.Text = "test";
            this.btn_test.UseVisualStyleBackColor = true;
            this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
            // 
            // cbConnect
            // 
            this.cbConnect.FormattingEnabled = true;
            this.cbConnect.Items.AddRange(new object[] {
            "server=49.232.51.71;port=8400;user=root;password=root; database=cam;",
            "server=10.37.1.113;port=3306;user=root;password=root; database=cam;"});
            this.cbConnect.Location = new System.Drawing.Point(384, 13);
            this.cbConnect.Name = "cbConnect";
            this.cbConnect.Size = new System.Drawing.Size(515, 20);
            this.cbConnect.TabIndex = 4;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 360);
            this.Controls.Add(this.cbConnect);
            this.Controls.Add(this.btn_test);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.tb_Msg);
            this.Controls.Add(this.btn_Read);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Read;
        private System.Windows.Forms.TextBox tb_Msg;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Button btn_test;
        private System.Windows.Forms.ComboBox cbConnect;
    }
}

