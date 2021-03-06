﻿namespace CM.Deployer
{
    partial class DeployForm
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
            this.uxConfigurationGroup = new System.Windows.Forms.GroupBox();
            this.uxLoadExternalFile = new System.Windows.Forms.Button();
            this.uxExternalFile = new System.Windows.Forms.TextBox();
            this.uxEnvironments = new System.Windows.Forms.ComboBox();
            this.uxUseExternalFile = new System.Windows.Forms.RadioButton();
            this.uxUsePackagedFile = new System.Windows.Forms.RadioButton();
            this.uxConfigurationPropertiesGroup = new System.Windows.Forms.GroupBox();
            this.uxProperties = new System.Windows.Forms.DataGridView();
            this.uxKeyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uxValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uxDeploy = new System.Windows.Forms.Button();
            this.uxSave = new System.Windows.Forms.Button();
            this.uxConfigurationGroup.SuspendLayout();
            this.uxConfigurationPropertiesGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // uxConfigurationGroup
            // 
            this.uxConfigurationGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uxConfigurationGroup.Controls.Add(this.uxLoadExternalFile);
            this.uxConfigurationGroup.Controls.Add(this.uxExternalFile);
            this.uxConfigurationGroup.Controls.Add(this.uxEnvironments);
            this.uxConfigurationGroup.Controls.Add(this.uxUseExternalFile);
            this.uxConfigurationGroup.Controls.Add(this.uxUsePackagedFile);
            this.uxConfigurationGroup.Location = new System.Drawing.Point(12, 12);
            this.uxConfigurationGroup.Name = "uxConfigurationGroup";
            this.uxConfigurationGroup.Size = new System.Drawing.Size(667, 101);
            this.uxConfigurationGroup.TabIndex = 0;
            this.uxConfigurationGroup.TabStop = false;
            this.uxConfigurationGroup.Text = "Load Configuration Settings";
            // 
            // uxLoadExternalFile
            // 
            this.uxLoadExternalFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uxLoadExternalFile.Location = new System.Drawing.Point(620, 68);
            this.uxLoadExternalFile.Name = "uxLoadExternalFile";
            this.uxLoadExternalFile.Size = new System.Drawing.Size(30, 23);
            this.uxLoadExternalFile.TabIndex = 4;
            this.uxLoadExternalFile.Text = "...";
            this.uxLoadExternalFile.UseVisualStyleBackColor = true;
            // 
            // uxExternalFile
            // 
            this.uxExternalFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uxExternalFile.Location = new System.Drawing.Point(155, 68);
            this.uxExternalFile.Name = "uxExternalFile";
            this.uxExternalFile.ReadOnly = true;
            this.uxExternalFile.Size = new System.Drawing.Size(460, 20);
            this.uxExternalFile.TabIndex = 3;
            // 
            // uxEnvironments
            // 
            this.uxEnvironments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uxEnvironments.FormattingEnabled = true;
            this.uxEnvironments.Location = new System.Drawing.Point(155, 31);
            this.uxEnvironments.Name = "uxEnvironments";
            this.uxEnvironments.Size = new System.Drawing.Size(494, 21);
            this.uxEnvironments.TabIndex = 2;
            // 
            // uxUseExternalFile
            // 
            this.uxUseExternalFile.AutoSize = true;
            this.uxUseExternalFile.Location = new System.Drawing.Point(20, 68);
            this.uxUseExternalFile.Name = "uxUseExternalFile";
            this.uxUseExternalFile.Size = new System.Drawing.Size(107, 17);
            this.uxUseExternalFile.TabIndex = 1;
            this.uxUseExternalFile.TabStop = true;
            this.uxUseExternalFile.Text = "Use External File:";
            this.uxUseExternalFile.UseVisualStyleBackColor = true;
            // 
            // uxUsePackagedFile
            // 
            this.uxUsePackagedFile.AutoSize = true;
            this.uxUsePackagedFile.Location = new System.Drawing.Point(20, 31);
            this.uxUsePackagedFile.Name = "uxUsePackagedFile";
            this.uxUsePackagedFile.Size = new System.Drawing.Size(118, 17);
            this.uxUsePackagedFile.TabIndex = 0;
            this.uxUsePackagedFile.TabStop = true;
            this.uxUsePackagedFile.Text = "Use Packaged File:";
            this.uxUsePackagedFile.UseVisualStyleBackColor = true;
            // 
            // uxConfigurationPropertiesGroup
            // 
            this.uxConfigurationPropertiesGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uxConfigurationPropertiesGroup.Controls.Add(this.uxProperties);
            this.uxConfigurationPropertiesGroup.Location = new System.Drawing.Point(13, 120);
            this.uxConfigurationPropertiesGroup.Name = "uxConfigurationPropertiesGroup";
            this.uxConfigurationPropertiesGroup.Size = new System.Drawing.Size(667, 316);
            this.uxConfigurationPropertiesGroup.TabIndex = 1;
            this.uxConfigurationPropertiesGroup.TabStop = false;
            this.uxConfigurationPropertiesGroup.Text = "Configuration Properties";
            // 
            // uxProperties
            // 
            this.uxProperties.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.uxProperties.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.uxProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uxProperties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.uxKeyColumn,
            this.uxValueColumn});
            this.uxProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxProperties.Location = new System.Drawing.Point(3, 16);
            this.uxProperties.MultiSelect = false;
            this.uxProperties.Name = "uxProperties";
            this.uxProperties.RowHeadersVisible = false;
            this.uxProperties.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.uxProperties.Size = new System.Drawing.Size(661, 297);
            this.uxProperties.TabIndex = 0;
            // 
            // uxKeyColumn
            // 
            this.uxKeyColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.uxKeyColumn.FillWeight = 200F;
            this.uxKeyColumn.HeaderText = "Key";
            this.uxKeyColumn.MinimumWidth = 200;
            this.uxKeyColumn.Name = "uxKeyColumn";
            this.uxKeyColumn.Width = 200;
            // 
            // uxValueColumn
            // 
            this.uxValueColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.uxValueColumn.HeaderText = "Value";
            this.uxValueColumn.Name = "uxValueColumn";
            // 
            // uxDeploy
            // 
            this.uxDeploy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uxDeploy.Location = new System.Drawing.Point(604, 442);
            this.uxDeploy.Name = "uxDeploy";
            this.uxDeploy.Size = new System.Drawing.Size(75, 23);
            this.uxDeploy.TabIndex = 2;
            this.uxDeploy.Text = "Deploy";
            this.uxDeploy.UseVisualStyleBackColor = true;
            // 
            // uxSave
            // 
            this.uxSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uxSave.Location = new System.Drawing.Point(523, 441);
            this.uxSave.Name = "uxSave";
            this.uxSave.Size = new System.Drawing.Size(75, 23);
            this.uxSave.TabIndex = 3;
            this.uxSave.Text = "Save";
            this.uxSave.UseVisualStyleBackColor = true;
            // 
            // DeployForm
            // 
            this.AcceptButton = this.uxDeploy;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 472);
            this.Controls.Add(this.uxSave);
            this.Controls.Add(this.uxDeploy);
            this.Controls.Add(this.uxConfigurationPropertiesGroup);
            this.Controls.Add(this.uxConfigurationGroup);
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "DeployForm";
            this.Text = "Deploy";
            this.uxConfigurationGroup.ResumeLayout(false);
            this.uxConfigurationGroup.PerformLayout();
            this.uxConfigurationPropertiesGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uxProperties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox uxConfigurationGroup;
        private System.Windows.Forms.RadioButton uxUseExternalFile;
        private System.Windows.Forms.RadioButton uxUsePackagedFile;
        private System.Windows.Forms.ComboBox uxEnvironments;
        private System.Windows.Forms.Button uxLoadExternalFile;
        private System.Windows.Forms.TextBox uxExternalFile;
        private System.Windows.Forms.GroupBox uxConfigurationPropertiesGroup;
        private System.Windows.Forms.Button uxDeploy;
        private System.Windows.Forms.Button uxSave;
        private System.Windows.Forms.DataGridView uxProperties;
        private System.Windows.Forms.DataGridViewTextBoxColumn uxKeyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uxValueColumn;
    }
}