namespace GadgetAlternativeApps
{
    partial class GadgetManagerForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.titleLabel = new System.Windows.Forms.Label();
            this.gadgetListPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.importGadgetLabel = new System.Windows.Forms.LinkLabel();
            this.gadgetBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.titleLabel.Location = new System.Drawing.Point(215, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(144, 32);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Gadget List";
            // 
            // gadgetListPanel
            // 
            this.gadgetListPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gadgetListPanel.Location = new System.Drawing.Point(13, 45);
            this.gadgetListPanel.Name = "gadgetListPanel";
            this.gadgetListPanel.Size = new System.Drawing.Size(557, 356);
            this.gadgetListPanel.TabIndex = 2;
            // 
            // importGadgetLabel
            // 
            this.importGadgetLabel.AutoSize = true;
            this.importGadgetLabel.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.importGadgetLabel.Location = new System.Drawing.Point(12, 421);
            this.importGadgetLabel.Name = "importGadgetLabel";
            this.importGadgetLabel.Size = new System.Drawing.Size(165, 23);
            this.importGadgetLabel.TabIndex = 3;
            this.importGadgetLabel.TabStop = true;
            this.importGadgetLabel.Text = "Import New Gadget";
            this.importGadgetLabel.VisitedLinkColor = System.Drawing.Color.Blue;
            this.importGadgetLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.importGadgetLabel_LinkClicked);
            // 
            // GadgetManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 453);
            this.Controls.Add(this.importGadgetLabel);
            this.Controls.Add(this.gadgetListPanel);
            this.Controls.Add(this.titleLabel);
            this.Name = "GadgetManagerForm";
            this.Text = "Gadget Manager";
            this.Load += new System.EventHandler(this.GadgetManagerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.FlowLayoutPanel gadgetListPanel;
        private System.Windows.Forms.LinkLabel importGadgetLabel;
        private System.Windows.Forms.FolderBrowserDialog gadgetBrowserDialog;
    }
}

