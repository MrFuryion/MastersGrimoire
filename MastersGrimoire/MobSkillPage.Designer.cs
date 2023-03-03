namespace HeroesAgeBestiary
{
    partial class MobSkillPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MobSkillPage));
            this.MobSkillListbox = new System.Windows.Forms.ListBox();
            this.MobAbilityListbox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MobSkillListbox
            // 
            this.MobSkillListbox.FormattingEnabled = true;
            this.MobSkillListbox.HorizontalScrollbar = true;
            this.MobSkillListbox.Location = new System.Drawing.Point(12, 24);
            this.MobSkillListbox.Name = "MobSkillListbox";
            this.MobSkillListbox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.MobSkillListbox.Size = new System.Drawing.Size(244, 173);
            this.MobSkillListbox.TabIndex = 0;
            // 
            // MobAbilityListbox
            // 
            this.MobAbilityListbox.FormattingEnabled = true;
            this.MobAbilityListbox.HorizontalScrollbar = true;
            this.MobAbilityListbox.Location = new System.Drawing.Point(270, 24);
            this.MobAbilityListbox.Name = "MobAbilityListbox";
            this.MobAbilityListbox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.MobAbilityListbox.Size = new System.Drawing.Size(244, 173);
            this.MobAbilityListbox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(360, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mob Abilities";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(107, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mob Skills";
            // 
            // MobSkillPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 208);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MobAbilityListbox);
            this.Controls.Add(this.MobSkillListbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MobSkillPage";
            this.Text = "Mob Skills";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MobSkillPage_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox MobSkillListbox;
        private System.Windows.Forms.ListBox MobAbilityListbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}