namespace HeroesAgeBestiary
{
    partial class ItemAdvancedSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemAdvancedSearch));
            this.FilterGroupBox = new System.Windows.Forms.GroupBox();
            this.AddFilterButton = new System.Windows.Forms.Button();
            this.RemoveFilterButton = new System.Windows.Forms.Button();
            this.StartSearchButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FilterGroupBox
            // 
            this.FilterGroupBox.AutoSize = true;
            this.FilterGroupBox.Location = new System.Drawing.Point(0, 0);
            this.FilterGroupBox.Name = "FilterGroupBox";
            this.FilterGroupBox.Size = new System.Drawing.Size(400, 300);
            this.FilterGroupBox.TabIndex = 0;
            this.FilterGroupBox.TabStop = false;
            // 
            // AddFilterButton
            // 
            this.AddFilterButton.Location = new System.Drawing.Point(9, 5);
            this.AddFilterButton.Name = "AddFilterButton";
            this.AddFilterButton.Size = new System.Drawing.Size(199, 23);
            this.AddFilterButton.TabIndex = 0;
            this.AddFilterButton.Text = "Add New Filter";
            this.AddFilterButton.UseVisualStyleBackColor = true;
            this.AddFilterButton.Click += new System.EventHandler(this.AddFilterButton_Click);
            // 
            // RemoveFilterButton
            // 
            this.RemoveFilterButton.Enabled = false;
            this.RemoveFilterButton.Location = new System.Drawing.Point(212, 5);
            this.RemoveFilterButton.Name = "RemoveFilterButton";
            this.RemoveFilterButton.Size = new System.Drawing.Size(199, 23);
            this.RemoveFilterButton.TabIndex = 1;
            this.RemoveFilterButton.Text = "Remove Last Filter";
            this.RemoveFilterButton.UseVisualStyleBackColor = true;
            this.RemoveFilterButton.Click += new System.EventHandler(this.RemoveFilterButton_Click);
            // 
            // StartSearchButton
            // 
            this.StartSearchButton.Enabled = false;
            this.StartSearchButton.Location = new System.Drawing.Point(9, 331);
            this.StartSearchButton.Name = "StartSearchButton";
            this.StartSearchButton.Size = new System.Drawing.Size(402, 23);
            this.StartSearchButton.TabIndex = 2;
            this.StartSearchButton.Text = "Start Search";
            this.StartSearchButton.UseVisualStyleBackColor = true;
            this.StartSearchButton.Click += new System.EventHandler(this.StartSearchButton_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.FilterGroupBox);
            this.panel1.Location = new System.Drawing.Point(10, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 300);
            this.panel1.TabIndex = 2;
            // 
            // ItemAdvancedSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 359);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.StartSearchButton);
            this.Controls.Add(this.RemoveFilterButton);
            this.Controls.Add(this.AddFilterButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ItemAdvancedSearch";
            this.Text = "Item Inspector Advanced Search Tool";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox FilterGroupBox;
        private System.Windows.Forms.Button AddFilterButton;
        private System.Windows.Forms.Button RemoveFilterButton;
        private System.Windows.Forms.Button StartSearchButton;
        private System.Windows.Forms.Panel panel1;
    }
}