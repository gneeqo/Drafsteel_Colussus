namespace Draftsteel_Colossus_Visual
{
    partial class Simulator
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
            this.btn_GenerateDraft = new System.Windows.Forms.Button();
            this.lv_CardFiles = new System.Windows.Forms.ListView();
            this.btn_AddCardFile = new System.Windows.Forms.Button();
            this.lv_PlayerFiles = new System.Windows.Forms.ListView();
            this.btn_AddPlayerFile = new System.Windows.Forms.Button();
            this.lb_SelectedCardLabel = new System.Windows.Forms.Label();
            this.lb_SelectedCardFile = new System.Windows.Forms.Label();
            this.lb_SelectedPlayerFile = new System.Windows.Forms.Label();
            this.lb_SelectedPlayerLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_GenerateDraft
            // 
            this.btn_GenerateDraft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_GenerateDraft.Font = new System.Drawing.Font("Beleren2016", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GenerateDraft.Location = new System.Drawing.Point(539, 319);
            this.btn_GenerateDraft.Name = "btn_GenerateDraft";
            this.btn_GenerateDraft.Size = new System.Drawing.Size(296, 148);
            this.btn_GenerateDraft.TabIndex = 0;
            this.btn_GenerateDraft.Text = "Generate Draft";
            this.btn_GenerateDraft.UseVisualStyleBackColor = true;
            this.btn_GenerateDraft.Click += new System.EventHandler(this.btn_GenerateDraft_Click);
            // 
            // lv_CardFiles
            // 
            this.lv_CardFiles.HideSelection = false;
            this.lv_CardFiles.Location = new System.Drawing.Point(12, 12);
            this.lv_CardFiles.Name = "lv_CardFiles";
            this.lv_CardFiles.Size = new System.Drawing.Size(177, 182);
            this.lv_CardFiles.TabIndex = 1;
            this.lv_CardFiles.UseCompatibleStateImageBehavior = false;
            this.lv_CardFiles.View = System.Windows.Forms.View.List;
            this.lv_CardFiles.SelectedIndexChanged += new System.EventHandler(this.lv_CardFiles_SelectedIndexChanged);
            // 
            // btn_AddCardFile
            // 
            this.btn_AddCardFile.Font = new System.Drawing.Font("Beleren2016", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddCardFile.Location = new System.Drawing.Point(49, 200);
            this.btn_AddCardFile.Name = "btn_AddCardFile";
            this.btn_AddCardFile.Size = new System.Drawing.Size(105, 32);
            this.btn_AddCardFile.TabIndex = 2;
            this.btn_AddCardFile.Text = "Add Card File";
            this.btn_AddCardFile.UseVisualStyleBackColor = true;
            this.btn_AddCardFile.Click += new System.EventHandler(this.btn_AddCardFile_Click);
            // 
            // lv_PlayerFiles
            // 
            this.lv_PlayerFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lv_PlayerFiles.HideSelection = false;
            this.lv_PlayerFiles.Location = new System.Drawing.Point(12, 319);
            this.lv_PlayerFiles.Name = "lv_PlayerFiles";
            this.lv_PlayerFiles.Size = new System.Drawing.Size(177, 182);
            this.lv_PlayerFiles.TabIndex = 3;
            this.lv_PlayerFiles.UseCompatibleStateImageBehavior = false;
            this.lv_PlayerFiles.View = System.Windows.Forms.View.Tile;
            this.lv_PlayerFiles.SelectedIndexChanged += new System.EventHandler(this.lv_PlayerFiles_SelectedIndexChanged);
            // 
            // btn_AddPlayerFile
            // 
            this.btn_AddPlayerFile.Font = new System.Drawing.Font("Beleren2016", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddPlayerFile.Location = new System.Drawing.Point(38, 505);
            this.btn_AddPlayerFile.Name = "btn_AddPlayerFile";
            this.btn_AddPlayerFile.Size = new System.Drawing.Size(127, 32);
            this.btn_AddPlayerFile.TabIndex = 4;
            this.btn_AddPlayerFile.Text = "Add Player File";
            this.btn_AddPlayerFile.UseVisualStyleBackColor = true;
            this.btn_AddPlayerFile.Click += new System.EventHandler(this.btn_AddPlayerFile_Click);
            // 
            // lb_SelectedCardLabel
            // 
            this.lb_SelectedCardLabel.AutoSize = true;
            this.lb_SelectedCardLabel.Font = new System.Drawing.Font("Beleren2016", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_SelectedCardLabel.Location = new System.Drawing.Point(218, 12);
            this.lb_SelectedCardLabel.Name = "lb_SelectedCardLabel";
            this.lb_SelectedCardLabel.Size = new System.Drawing.Size(180, 24);
            this.lb_SelectedCardLabel.TabIndex = 5;
            this.lb_SelectedCardLabel.Text = "Selected Card File:";
            // 
            // lb_SelectedCardFile
            // 
            this.lb_SelectedCardFile.AutoSize = true;
            this.lb_SelectedCardFile.Font = new System.Drawing.Font("Beleren2016", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_SelectedCardFile.Location = new System.Drawing.Point(218, 36);
            this.lb_SelectedCardFile.Name = "lb_SelectedCardFile";
            this.lb_SelectedCardFile.Size = new System.Drawing.Size(86, 24);
            this.lb_SelectedCardFile.TabIndex = 6;
            this.lb_SelectedCardFile.Text = "NOT SET";
            // 
            // lb_SelectedPlayerFile
            // 
            this.lb_SelectedPlayerFile.AutoSize = true;
            this.lb_SelectedPlayerFile.Font = new System.Drawing.Font("Beleren2016", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_SelectedPlayerFile.Location = new System.Drawing.Point(222, 343);
            this.lb_SelectedPlayerFile.Name = "lb_SelectedPlayerFile";
            this.lb_SelectedPlayerFile.Size = new System.Drawing.Size(86, 24);
            this.lb_SelectedPlayerFile.TabIndex = 8;
            this.lb_SelectedPlayerFile.Text = "NOT SET";
            // 
            // lb_SelectedPlayerLabel
            // 
            this.lb_SelectedPlayerLabel.AutoSize = true;
            this.lb_SelectedPlayerLabel.Font = new System.Drawing.Font("Beleren2016", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_SelectedPlayerLabel.Location = new System.Drawing.Point(222, 319);
            this.lb_SelectedPlayerLabel.Name = "lb_SelectedPlayerLabel";
            this.lb_SelectedPlayerLabel.Size = new System.Drawing.Size(193, 24);
            this.lb_SelectedPlayerLabel.TabIndex = 7;
            this.lb_SelectedPlayerLabel.Text = "Selected Player File:";
            // 
            // Simulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 593);
            this.Controls.Add(this.lb_SelectedPlayerFile);
            this.Controls.Add(this.lb_SelectedPlayerLabel);
            this.Controls.Add(this.lb_SelectedCardFile);
            this.Controls.Add(this.lb_SelectedCardLabel);
            this.Controls.Add(this.btn_AddPlayerFile);
            this.Controls.Add(this.lv_PlayerFiles);
            this.Controls.Add(this.btn_AddCardFile);
            this.Controls.Add(this.lv_CardFiles);
            this.Controls.Add(this.btn_GenerateDraft);
            this.Name = "Simulator";
            this.Text = "Simulator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_GenerateDraft;
        private System.Windows.Forms.ListView lv_CardFiles;
        private System.Windows.Forms.Button btn_AddCardFile;
        private System.Windows.Forms.ListView lv_PlayerFiles;
        private System.Windows.Forms.Button btn_AddPlayerFile;
        private System.Windows.Forms.Label lb_SelectedCardLabel;
        private System.Windows.Forms.Label lb_SelectedCardFile;
        private System.Windows.Forms.Label lb_SelectedPlayerFile;
        private System.Windows.Forms.Label lb_SelectedPlayerLabel;
    }
}