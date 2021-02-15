
namespace Watchdog.Ribbon
{
    partial class WdRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public WdRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">"true", wenn verwaltete Ressourcen gelöscht werden sollen, andernfalls "false".</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WdRibbon));
            this.wdRibbonTab = this.Factory.CreateRibbonTab();
            this.wdRibbonGroup = this.Factory.CreateRibbonGroup();
            this.wdRibbonButtonSettings = this.Factory.CreateRibbonButton();
            this.wdRibbonButtonFundAdmin = this.Factory.CreateRibbonButton();
            this.wdRibbonButtonRuleAdmin = this.Factory.CreateRibbonButton();
            this.wdRibbonTab.SuspendLayout();
            this.wdRibbonGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // wdRibbonTab
            // 
            this.wdRibbonTab.Groups.Add(this.wdRibbonGroup);
            this.wdRibbonTab.Label = "Depotbank";
            this.wdRibbonTab.Name = "wdRibbonTab";
            // 
            // wdRibbonGroup
            // 
            this.wdRibbonGroup.Items.Add(this.wdRibbonButtonSettings);
            this.wdRibbonGroup.Items.Add(this.wdRibbonButtonFundAdmin);
            this.wdRibbonGroup.Items.Add(this.wdRibbonButtonRuleAdmin);
            this.wdRibbonGroup.Label = "Depotbank";
            this.wdRibbonGroup.Name = "wdRibbonGroup";
            // 
            // wdRibbonButtonSettings
            // 
            this.wdRibbonButtonSettings.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.wdRibbonButtonSettings.Image = ((System.Drawing.Image)(resources.GetObject("wdRibbonButtonSettings.Image")));
            this.wdRibbonButtonSettings.Label = "Einstellungen";
            this.wdRibbonButtonSettings.Name = "wdRibbonButtonSettings";
            this.wdRibbonButtonSettings.ShowImage = true;
            this.wdRibbonButtonSettings.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.WdRibbonButtonSettings_Click);
            // 
            // wdRibbonButtonFundAdmin
            // 
            this.wdRibbonButtonFundAdmin.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.wdRibbonButtonFundAdmin.Image = ((System.Drawing.Image)(resources.GetObject("wdRibbonButtonFundAdmin.Image")));
            this.wdRibbonButtonFundAdmin.Label = "Fondsadministration";
            this.wdRibbonButtonFundAdmin.Name = "wdRibbonButtonFundAdmin";
            this.wdRibbonButtonFundAdmin.ShowImage = true;
            this.wdRibbonButtonFundAdmin.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.WdRibbonButtonFundAdminClick);
            // 
            // wdRibbonButtonRuleAdmin
            // 
            this.wdRibbonButtonRuleAdmin.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.wdRibbonButtonRuleAdmin.Image = global::Watchdog.Properties.Resources.ruleset;
            this.wdRibbonButtonRuleAdmin.Label = "Regelverwaltung";
            this.wdRibbonButtonRuleAdmin.Name = "wdRibbonButtonRuleAdmin";
            this.wdRibbonButtonRuleAdmin.ShowImage = true;
            this.wdRibbonButtonRuleAdmin.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.WdRibbonButtonRuleAdmin_Click);
            // 
            // WdRibbon
            // 
            this.Name = "WdRibbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.wdRibbonTab);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.WdRibbon_Load);
            this.wdRibbonTab.ResumeLayout(false);
            this.wdRibbonTab.PerformLayout();
            this.wdRibbonGroup.ResumeLayout(false);
            this.wdRibbonGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab wdRibbonTab;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup wdRibbonGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton wdRibbonButtonFundAdmin;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton wdRibbonButtonSettings;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton wdRibbonButtonRuleAdmin;
    }
}
