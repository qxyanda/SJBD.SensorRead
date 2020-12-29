
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
            this.SuspendLayout();
            // 
            // btn_Read
            // 
            this.btn_Read.Location = new System.Drawing.Point(12, 12);
            this.btn_Read.Name = "btn_Read";
            this.btn_Read.Size = new System.Drawing.Size(75, 38);
            this.btn_Read.TabIndex = 0;
            this.btn_Read.Text = "读取数据";
            this.btn_Read.UseVisualStyleBackColor = true;
            this.btn_Read.Click += new System.EventHandler(this.btn_Read_Click);
            // 
            // tb_Msg
            // 
            this.tb_Msg.Location = new System.Drawing.Point(13, 56);
            this.tb_Msg.Multiline = true;
            this.tb_Msg.Name = "tb_Msg";
            this.tb_Msg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_Msg.Size = new System.Drawing.Size(775, 382);
            this.tb_Msg.TabIndex = 1;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tb_Msg);
            this.Controls.Add(this.btn_Read);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Read;
        private System.Windows.Forms.TextBox tb_Msg;
    }
}

