namespace projeto_banco_de_dados
{
    partial class FrmLog
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            LstLogs = new ListBox();
            SuspendLayout();
            // 
            // LstLogs
            // 
            LstLogs.FormattingEnabled = true;
            LstLogs.ItemHeight = 15;
            LstLogs.Location = new Point(48, 50);
            LstLogs.Name = "LstLogs";
            LstLogs.Size = new Size(474, 364);
            LstLogs.TabIndex = 9;
            // 
            // FrmLog
            // 
            ClientSize = new Size(568, 470);
            Controls.Add(LstLogs);
            Name = "FrmLog";
            Text = "Registro de Logs";
            Load += FrmLog_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox LstLogs;
    }
}