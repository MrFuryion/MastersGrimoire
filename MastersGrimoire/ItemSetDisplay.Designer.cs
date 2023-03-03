namespace HeroesAgeBestiary
{
    partial class ItemSetDisplay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemSetDisplay));
            this.SetItemParts = new System.Windows.Forms.ListBox();
            this.SetItemReward = new System.Windows.Forms.ListBox();
            this.SetBonusAmount = new System.Windows.Forms.Label();
            this.SetBonusReward = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SetEquipSort = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SetBonusSelected = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // SetItemParts
            // 
            this.SetItemParts.FormattingEnabled = true;
            this.SetItemParts.HorizontalScrollbar = true;
            this.SetItemParts.Location = new System.Drawing.Point(10, 21);
            this.SetItemParts.Name = "SetItemParts";
            this.SetItemParts.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.SetItemParts.Size = new System.Drawing.Size(288, 329);
            this.SetItemParts.TabIndex = 0;
            // 
            // SetItemReward
            // 
            this.SetItemReward.FormattingEnabled = true;
            this.SetItemReward.HorizontalScrollbar = true;
            this.SetItemReward.Location = new System.Drawing.Point(308, 21);
            this.SetItemReward.Name = "SetItemReward";
            this.SetItemReward.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.SetItemReward.Size = new System.Drawing.Size(288, 329);
            this.SetItemReward.TabIndex = 1;
            // 
            // SetBonusAmount
            // 
            this.SetBonusAmount.Location = new System.Drawing.Point(10, 4);
            this.SetBonusAmount.Name = "SetBonusAmount";
            this.SetBonusAmount.Size = new System.Drawing.Size(288, 13);
            this.SetBonusAmount.TabIndex = 2;
            this.SetBonusAmount.Text = "Items Below Required To Activate Set Bonus: ???";
            this.SetBonusAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SetBonusReward
            // 
            this.SetBonusReward.Location = new System.Drawing.Point(308, 4);
            this.SetBonusReward.Name = "SetBonusReward";
            this.SetBonusReward.Size = new System.Drawing.Size(288, 13);
            this.SetBonusReward.TabIndex = 3;
            this.SetBonusReward.Text = "Set Bonus Reward: ???";
            this.SetBonusReward.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Sort By Equipment Slot:";
            // 
            // SetEquipSort
            // 
            this.SetEquipSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SetEquipSort.FormattingEnabled = true;
            this.SetEquipSort.Location = new System.Drawing.Point(117, 13);
            this.SetEquipSort.Name = "SetEquipSort";
            this.SetEquipSort.Size = new System.Drawing.Size(166, 21);
            this.SetEquipSort.TabIndex = 2;
            this.SetEquipSort.SelectedIndexChanged += new System.EventHandler(this.SetEquipSort_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Set Bonus Selected:";
            // 
            // SetBonusSelected
            // 
            this.SetBonusSelected.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SetBonusSelected.FormattingEnabled = true;
            this.SetBonusSelected.Location = new System.Drawing.Point(103, 13);
            this.SetBonusSelected.Name = "SetBonusSelected";
            this.SetBonusSelected.Size = new System.Drawing.Size(180, 21);
            this.SetBonusSelected.TabIndex = 3;
            this.SetBonusSelected.SelectedIndexChanged += new System.EventHandler(this.SetBonusSelected_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SetEquipSort);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(10, 343);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 50);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SetBonusSelected);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(308, 343);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(288, 50);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // ItemSetDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 383);
            this.Controls.Add(this.SetItemReward);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.SetItemParts);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SetBonusReward);
            this.Controls.Add(this.SetBonusAmount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ItemSetDisplay";
            this.Text = "Item Inspector Set Bonus Viewer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox SetItemParts;
        private System.Windows.Forms.ListBox SetItemReward;
        private System.Windows.Forms.Label SetBonusAmount;
        private System.Windows.Forms.Label SetBonusReward;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox SetEquipSort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox SetBonusSelected;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}