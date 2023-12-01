namespace Draftsteel_Colossus_Visual
{
    partial class Bingus
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
            this.btn_ClickMe = new System.Windows.Forms.Button();
            this.lb_MyLabel = new System.Windows.Forms.Label();
            this.tb_InputBox = new System.Windows.Forms.TextBox();
            this.lv_FileView = new System.Windows.Forms.ListView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_ClickMe
            // 
            this.btn_ClickMe.Font = new System.Drawing.Font("Beleren2016", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ClickMe.Location = new System.Drawing.Point(12, 289);
            this.btn_ClickMe.Name = "btn_ClickMe";
            this.btn_ClickMe.Size = new System.Drawing.Size(208, 71);
            this.btn_ClickMe.TabIndex = 0;
            this.btn_ClickMe.Text = "Add File";
            this.btn_ClickMe.UseVisualStyleBackColor = true;
            this.btn_ClickMe.Click += new System.EventHandler(this.btn_ClickMe_Click);
            // 
            // lb_MyLabel
            // 
            this.lb_MyLabel.AutoSize = true;
            this.lb_MyLabel.Location = new System.Drawing.Point(363, 146);
            this.lb_MyLabel.Name = "lb_MyLabel";
            this.lb_MyLabel.Size = new System.Drawing.Size(71, 16);
            this.lb_MyLabel.TabIndex = 1;
            this.lb_MyLabel.Text = "Something";
            this.lb_MyLabel.Click += new System.EventHandler(this.lb_MyLabel_Click);
            // 
            // tb_InputBox
            // 
            this.tb_InputBox.Location = new System.Drawing.Point(539, 61);
            this.tb_InputBox.Name = "tb_InputBox";
            this.tb_InputBox.Size = new System.Drawing.Size(154, 22);
            this.tb_InputBox.TabIndex = 2;
            this.tb_InputBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lv_FileView
            // 
            this.lv_FileView.HideSelection = false;
            this.lv_FileView.Location = new System.Drawing.Point(12, 12);
            this.lv_FileView.Name = "lv_FileView";
            this.lv_FileView.Size = new System.Drawing.Size(208, 271);
            this.lv_FileView.TabIndex = 3;
            this.lv_FileView.UseCompatibleStateImageBehavior = false;
            this.lv_FileView.View = System.Windows.Forms.View.List;
            this.lv_FileView.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(539, 110);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(235, 288);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Bingus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 446);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lv_FileView);
            this.Controls.Add(this.tb_InputBox);
            this.Controls.Add(this.lb_MyLabel);
            this.Controls.Add(this.btn_ClickMe);
            this.Name = "Bingus";
            this.Text = "Bingus";
            this.Load += new System.EventHandler(this.Bingus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ClickMe;
        private System.Windows.Forms.Label lb_MyLabel;
        private System.Windows.Forms.TextBox tb_InputBox;
        private System.Windows.Forms.ListView lv_FileView;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

