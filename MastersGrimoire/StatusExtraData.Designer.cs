namespace HeroesAgeBestiary
{
    partial class StatusExtraData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatusExtraData));
            this.AuraInfo = new System.Windows.Forms.Label();
            this.AuraTarget = new System.Windows.Forms.Label();
            this.AuraRange = new System.Windows.Forms.Label();
            this.Drawing1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CharacterEffectListbox = new System.Windows.Forms.ListBox();
            this.CharacterEffectInfo = new System.Windows.Forms.Label();
            this.CharacterEffectName = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // AuraInfo
            // 
            this.AuraInfo.AutoSize = true;
            this.AuraInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AuraInfo.Location = new System.Drawing.Point(99, 11);
            this.AuraInfo.Name = "AuraInfo";
            this.AuraInfo.Size = new System.Drawing.Size(50, 13);
            this.AuraInfo.TabIndex = 0;
            this.AuraInfo.Text = "Aura Info";
            // 
            // AuraTarget
            // 
            this.AuraTarget.AutoSize = true;
            this.AuraTarget.Location = new System.Drawing.Point(6, 30);
            this.AuraTarget.Name = "AuraTarget";
            this.AuraTarget.Size = new System.Drawing.Size(66, 13);
            this.AuraTarget.TabIndex = 2;
            this.AuraTarget.Text = "Aura Target:";
            // 
            // AuraRange
            // 
            this.AuraRange.AutoSize = true;
            this.AuraRange.Location = new System.Drawing.Point(6, 48);
            this.AuraRange.Name = "AuraRange";
            this.AuraRange.Size = new System.Drawing.Size(67, 13);
            this.AuraRange.TabIndex = 3;
            this.AuraRange.Text = "Aura Range:";
            // 
            // Drawing1
            // 
            this.Drawing1.Location = new System.Drawing.Point(6, 7);
            this.Drawing1.Name = "Drawing1";
            this.Drawing1.Size = new System.Drawing.Size(241, 190);
            this.Drawing1.TabIndex = 4;
            this.Drawing1.Text = resources.GetString("Drawing1.Text");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Drawing1);
            this.groupBox1.Location = new System.Drawing.Point(-7, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 219);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // CharacterEffectListbox
            // 
            this.CharacterEffectListbox.FormattingEnabled = true;
            this.CharacterEffectListbox.HorizontalScrollbar = true;
            this.CharacterEffectListbox.Location = new System.Drawing.Point(251, 44);
            this.CharacterEffectListbox.Name = "CharacterEffectListbox";
            this.CharacterEffectListbox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.CharacterEffectListbox.Size = new System.Drawing.Size(235, 212);
            this.CharacterEffectListbox.TabIndex = 6;
            // 
            // CharacterEffectInfo
            // 
            this.CharacterEffectInfo.AutoSize = true;
            this.CharacterEffectInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CharacterEffectInfo.Location = new System.Drawing.Point(316, 4);
            this.CharacterEffectInfo.Name = "CharacterEffectInfo";
            this.CharacterEffectInfo.Size = new System.Drawing.Size(105, 13);
            this.CharacterEffectInfo.TabIndex = 7;
            this.CharacterEffectInfo.Text = "Character Effect Info";
            // 
            // CharacterEffectName
            // 
            this.CharacterEffectName.AutoSize = true;
            this.CharacterEffectName.Location = new System.Drawing.Point(252, 24);
            this.CharacterEffectName.Name = "CharacterEffectName";
            this.CharacterEffectName.Size = new System.Drawing.Size(118, 13);
            this.CharacterEffectName.TabIndex = 8;
            this.CharacterEffectName.Text = "Character Effect Name:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.AuraTarget);
            this.groupBox2.Controls.Add(this.AuraInfo);
            this.groupBox2.Controls.Add(this.AuraRange);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Location = new System.Drawing.Point(-1, -7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(247, 280);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // StatusExtraData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 263);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.CharacterEffectName);
            this.Controls.Add(this.CharacterEffectInfo);
            this.Controls.Add(this.CharacterEffectListbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StatusExtraData";
            this.Text = "Status Extra Data";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AuraInfo;
        private System.Windows.Forms.Label AuraTarget;
        private System.Windows.Forms.Label AuraRange;
        private System.Windows.Forms.Label Drawing1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox CharacterEffectListbox;
        private System.Windows.Forms.Label CharacterEffectInfo;
        private System.Windows.Forms.Label CharacterEffectName;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}