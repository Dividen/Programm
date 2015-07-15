namespace OtherBase
{
    partial class FailedMissions
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
            Telerik.Reporting.InstanceReportSource instanceReportSource1 = new Telerik.Reporting.InstanceReportSource();
            this.reportViewer1 = new Telerik.ReportViewer.WinForms.ReportViewer();
            this.report21 = new OtherBase.UncomChalenge();
            this.uncomChalenge1 = new OtherBase.UncomChalenge();
            ((System.ComponentModel.ISupportInitialize)(this.report21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uncomChalenge1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            instanceReportSource1.ReportDocument = this.uncomChalenge1;
            this.reportViewer1.ReportSource = instanceReportSource1;
            this.reportViewer1.Size = new System.Drawing.Size(712, 262);
            this.reportViewer1.TabIndex = 0;
            // 
            // report21
            // 
            this.report21.Name = "Report2";
            // 
            // uncomChalenge1
            // 
            this.uncomChalenge1.Name = "UncomChalenge";
            // 
            // FailedMissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 262);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FailedMissions";
            this.Text = "FailedMissions";
            ((System.ComponentModel.ISupportInitialize)(this.report21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uncomChalenge1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.ReportViewer.WinForms.ReportViewer reportViewer1;
        private UncomChalenge report21;
        private UncomChalenge uncomChalenge1;
    }
}