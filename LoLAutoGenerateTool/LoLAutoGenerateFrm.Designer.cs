namespace LoLAutoGenerateTool
{
    partial class LoLAutoGenerateFrm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txbDefaultDtoPath = new System.Windows.Forms.TextBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(533, 87);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "生成";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txbDefaultDtoPath
            // 
            this.txbDefaultDtoPath.Location = new System.Drawing.Point(12, 12);
            this.txbDefaultDtoPath.Multiline = true;
            this.txbDefaultDtoPath.Name = "txbDefaultDtoPath";
            this.txbDefaultDtoPath.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txbDefaultDtoPath.Size = new System.Drawing.Size(260, 46);
            this.txbDefaultDtoPath.TabIndex = 1;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(12, 64);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(515, 394);
            this.webBrowser1.TabIndex = 2;
            this.webBrowser1.Url = new System.Uri("D:\\WangjqWork\\MyTool\\LoLMetroAT\\LoLAutoGenerateTool\\Riot Developer Portal.html", System.UriKind.Absolute);
            // 
            // LoLAutoGenerateFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 525);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.txbDefaultDtoPath);
            this.Controls.Add(this.btnGenerate);
            this.Name = "LoLAutoGenerateFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoLAutoGenerateTool";
            this.Load += new System.EventHandler(this.LoLAutoGenerateFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox txbDefaultDtoPath;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}

