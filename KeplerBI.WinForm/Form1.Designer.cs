namespace KeplerBI.WinForm
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCsvImportCancel = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnCsvFileOpen = new System.Windows.Forms.Button();
            this.lblCsvFileName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.openAsteroidsCSVFile = new System.Windows.Forms.OpenFileDialog();
            this.AsteroidCatalogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiameterInKm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MassInEarthMoonMasses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SemiMajorAxisLengthInAU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MeanOrbitVelocityInKmPerSec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.albedoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControlBaseFormMain.SuspendLayout();
            this.tabPageBaseFormLogs.SuspendLayout();
            this.tabPageBaseForm1.SuspendLayout();
            this.panelBaseFormtabPageLogs.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AsteroidCatalogBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPageBaseForm1
            // 
            this.tabPageBaseForm1.Controls.Add(this.dataGridView2);
            this.tabPageBaseForm1.Controls.Add(this.panel1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCsvImportCancel);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.btnCsvFileOpen);
            this.panel1.Controls.Add(this.lblCsvFileName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(831, 71);
            this.panel1.TabIndex = 0;
            // 
            // btnCsvImportCancel
            // 
            this.btnCsvImportCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCsvImportCancel.BackColor = System.Drawing.Color.LightCoral;
            this.btnCsvImportCancel.Location = new System.Drawing.Point(750, 3);
            this.btnCsvImportCancel.Name = "btnCsvImportCancel";
            this.btnCsvImportCancel.Size = new System.Drawing.Size(75, 36);
            this.btnCsvImportCancel.TabIndex = 4;
            this.btnCsvImportCancel.Text = "Cancel";
            this.btnCsvImportCancel.UseVisualStyleBackColor = false;
            this.btnCsvImportCancel.Click += new System.EventHandler(this.btnCsvImportCancel_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(89, 45);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(737, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // btnCsvFileOpen
            // 
            this.btnCsvFileOpen.Location = new System.Drawing.Point(8, 45);
            this.btnCsvFileOpen.Name = "btnCsvFileOpen";
            this.btnCsvFileOpen.Size = new System.Drawing.Size(75, 23);
            this.btnCsvFileOpen.TabIndex = 2;
            this.btnCsvFileOpen.Text = "CSV- File Öffnen";
            this.btnCsvFileOpen.UseVisualStyleBackColor = true;
            this.btnCsvFileOpen.Click += new System.EventHandler(this.btnCsvFileOpen_Click);
            // 
            // lblCsvFileName
            // 
            this.lblCsvFileName.AutoSize = true;
            this.lblCsvFileName.Location = new System.Drawing.Point(5, 23);
            this.lblCsvFileName.Name = "lblCsvFileName";
            this.lblCsvFileName.Size = new System.Drawing.Size(16, 13);
            this.lblCsvFileName.TabIndex = 1;
            this.lblCsvFileName.Text = "...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "CSV- Datei mit Asteroiden";
            // 
            // openAsteroidsCSVFile
            // 
            this.openAsteroidsCSVFile.Filter = "CSV-Files|*.csv";
            this.openAsteroidsCSVFile.Title = "CSV- Datei mit Asteroidendaten";
            // 
            // AsteroidCatalogBindingSource
            // 
            this.AsteroidCatalogBindingSource.DataSource = typeof(KeplerBI.RAM.NaturalCelesticalBodies.IAsteroidFlat);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name,
            this.DiameterInKm,
            this.MassInEarthMoonMasses,
            this.SemiMajorAxisLengthInAU,
            this.MeanOrbitVelocityInKmPerSec,
            this.albedoDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.AsteroidCatalogBindingSource;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 74);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(831, 311);
            this.dataGridView2.TabIndex = 1;
            // 
            // Name
            // 
            this.Name.DataPropertyName = "Name";
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            // 
            // DiameterInKm
            // 
            this.DiameterInKm.DataPropertyName = "DiameterInKm";
            this.DiameterInKm.HeaderText = "d [km]";
            this.DiameterInKm.Name = "DiameterInKm";
            this.DiameterInKm.ReadOnly = true;
            // 
            // MassInEarthMoonMasses
            // 
            this.MassInEarthMoonMasses.DataPropertyName = "MassInEarthMoonMasses";
            this.MassInEarthMoonMasses.HeaderText = "Masse [xMond]";
            this.MassInEarthMoonMasses.Name = "MassInEarthMoonMasses";
            this.MassInEarthMoonMasses.ReadOnly = true;
            // 
            // SemiMajorAxisLengthInAU
            // 
            this.SemiMajorAxisLengthInAU.DataPropertyName = "SemiMajorAxisLengthInAU";
            this.SemiMajorAxisLengthInAU.HeaderText = "r Sonne [AU]";
            this.SemiMajorAxisLengthInAU.Name = "SemiMajorAxisLengthInAU";
            this.SemiMajorAxisLengthInAU.ReadOnly = true;
            // 
            // MeanOrbitVelocityInKmPerSec
            // 
            this.MeanOrbitVelocityInKmPerSec.DataPropertyName = "MeanOrbitVelocityInKmPerSec";
            this.MeanOrbitVelocityInKmPerSec.HeaderText = "v Bahn [km/sec]";
            this.MeanOrbitVelocityInKmPerSec.Name = "MeanOrbitVelocityInKmPerSec";
            this.MeanOrbitVelocityInKmPerSec.ReadOnly = true;
            // 
            // albedoDataGridViewTextBoxColumn
            // 
            this.albedoDataGridViewTextBoxColumn.DataPropertyName = "Albedo";
            this.albedoDataGridViewTextBoxColumn.HeaderText = "Albedo";
            this.albedoDataGridViewTextBoxColumn.Name = "albedoDataGridViewTextBoxColumn";
            this.albedoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(845, 460);
            //this.Name = "Form1";
            this.tabControlBaseFormMain.ResumeLayout(false);
            this.tabPageBaseFormLogs.ResumeLayout(false);
            this.tabPageBaseForm1.ResumeLayout(false);
            this.panelBaseFormtabPageLogs.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AsteroidCatalogBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnCsvFileOpen;
        private System.Windows.Forms.Label lblCsvFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openAsteroidsCSVFile;
        private System.Windows.Forms.BindingSource AsteroidCatalogBindingSource;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnCsvImportCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiameterInKm;
        private System.Windows.Forms.DataGridViewTextBoxColumn MassInEarthMoonMasses;
        private System.Windows.Forms.DataGridViewTextBoxColumn SemiMajorAxisLengthInAU;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeanOrbitVelocityInKmPerSec;
        private System.Windows.Forms.DataGridViewTextBoxColumn albedoDataGridViewTextBoxColumn;
    }
}
