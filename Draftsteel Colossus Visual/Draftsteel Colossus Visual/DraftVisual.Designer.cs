namespace Draftsteel_Colossus_Visual
{
    partial class Draft_Visual
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
            this.btn_StartDraft = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_StartDraft
            // 
            this.btn_StartDraft.Font = new System.Drawing.Font("Beleren2016", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_StartDraft.Location = new System.Drawing.Point(25, 40);
            this.btn_StartDraft.Name = "btn_StartDraft";
            this.btn_StartDraft.Size = new System.Drawing.Size(250, 164);
            this.btn_StartDraft.TabIndex = 0;
            this.btn_StartDraft.Text = "Start Draft";
            this.btn_StartDraft.UseVisualStyleBackColor = true;
            this.btn_StartDraft.Click += new System.EventHandler(this.btn_StartDraft_Click);
            // 
            // Draft_Visual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1884, 1084);
            this.Controls.Add(this.btn_StartDraft);
            this.Name = "Draft_Visual";
            this.Text = "Draft Simulator";
            this.Load += new System.EventHandler(this.Draft_Visual_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_StartDraft;
    }
}