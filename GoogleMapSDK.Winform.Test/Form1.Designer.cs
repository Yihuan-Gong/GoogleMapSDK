namespace GoogleMapSDK.Winform.Test
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.searchBoxFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.mapFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // searchBoxFlowLayoutPanel
            // 
            this.searchBoxFlowLayoutPanel.Location = new System.Drawing.Point(71, 84);
            this.searchBoxFlowLayoutPanel.Name = "searchBoxFlowLayoutPanel";
            this.searchBoxFlowLayoutPanel.Size = new System.Drawing.Size(849, 165);
            this.searchBoxFlowLayoutPanel.TabIndex = 0;
            // 
            // mapFlowLayoutPanel
            // 
            this.mapFlowLayoutPanel.Location = new System.Drawing.Point(72, 382);
            this.mapFlowLayoutPanel.Name = "mapFlowLayoutPanel";
            this.mapFlowLayoutPanel.Size = new System.Drawing.Size(847, 814);
            this.mapFlowLayoutPanel.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(72, 289);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 51);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 1237);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mapFlowLayoutPanel);
            this.Controls.Add(this.searchBoxFlowLayoutPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel searchBoxFlowLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel mapFlowLayoutPanel;
        private System.Windows.Forms.Button button1;
    }
}

