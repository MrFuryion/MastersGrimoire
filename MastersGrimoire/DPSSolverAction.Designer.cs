namespace HeroesAgeBestiary
{
    partial class DPSSolverAction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DPSSolverAction));
            this.label57 = new System.Windows.Forms.Label();
            this.SkillLevelDropdown = new System.Windows.Forms.ComboBox();
            this.SkillNameSearchTextbox = new System.Windows.Forms.TextBox();
            this.label58 = new System.Windows.Forms.Label();
            this.SkillSearchListbox = new System.Windows.Forms.ListBox();
            this.label60 = new System.Windows.Forms.Label();
            this.AddAutoAttack = new System.Windows.Forms.Button();
            this.AddSkill = new System.Windows.Forms.Button();
            this.AddEmptySpace = new System.Windows.Forms.Button();
            this.EmptySpaceSeconds = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DirectDamage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CooldownReduction = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Strength = new System.Windows.Forms.TextBox();
            this.Focuss = new System.Windows.Forms.TextBox();
            this.Attack = new System.Windows.Forms.TextBox();
            this.Dexterity = new System.Windows.Forms.TextBox();
            this.Vitality = new System.Windows.Forms.TextBox();
            this.WeaponAbility = new System.Windows.Forms.TextBox();
            this.SkillAbility = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(227, 4);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(55, 13);
            this.label57.TabIndex = 157;
            this.label57.Text = "Skill Level";
            // 
            // SkillLevelDropdown
            // 
            this.SkillLevelDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SkillLevelDropdown.FormattingEnabled = true;
            this.SkillLevelDropdown.Location = new System.Drawing.Point(210, 21);
            this.SkillLevelDropdown.Name = "SkillLevelDropdown";
            this.SkillLevelDropdown.Size = new System.Drawing.Size(85, 21);
            this.SkillLevelDropdown.TabIndex = 1;
            // 
            // SkillNameSearchTextbox
            // 
            this.SkillNameSearchTextbox.Location = new System.Drawing.Point(93, 21);
            this.SkillNameSearchTextbox.Name = "SkillNameSearchTextbox";
            this.SkillNameSearchTextbox.Size = new System.Drawing.Size(111, 20);
            this.SkillNameSearchTextbox.TabIndex = 0;
            this.SkillNameSearchTextbox.TextChanged += new System.EventHandler(this.SkillNameSearchTextbox_TextChanged);
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(4, 24);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(89, 13);
            this.label58.TabIndex = 153;
            this.label58.Text = "Search by Name:";
            // 
            // SkillSearchListbox
            // 
            this.SkillSearchListbox.FormattingEnabled = true;
            this.SkillSearchListbox.HorizontalScrollbar = true;
            this.SkillSearchListbox.Location = new System.Drawing.Point(7, 47);
            this.SkillSearchListbox.Name = "SkillSearchListbox";
            this.SkillSearchListbox.Size = new System.Drawing.Size(288, 121);
            this.SkillSearchListbox.TabIndex = 2;
            this.SkillSearchListbox.SelectedIndexChanged += new System.EventHandler(this.SkillSearchListbox_SelectedIndexChanged);
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(116, 4);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(63, 13);
            this.label60.TabIndex = 154;
            this.label60.Text = "Skill Search";
            // 
            // AddAutoAttack
            // 
            this.AddAutoAttack.Location = new System.Drawing.Point(7, 357);
            this.AddAutoAttack.Name = "AddAutoAttack";
            this.AddAutoAttack.Size = new System.Drawing.Size(142, 23);
            this.AddAutoAttack.TabIndex = 14;
            this.AddAutoAttack.Text = "Add Auto Attack";
            this.AddAutoAttack.UseVisualStyleBackColor = true;
            this.AddAutoAttack.Click += new System.EventHandler(this.AddAutoAttack_Click);
            // 
            // AddSkill
            // 
            this.AddSkill.Enabled = false;
            this.AddSkill.Location = new System.Drawing.Point(153, 357);
            this.AddSkill.Name = "AddSkill";
            this.AddSkill.Size = new System.Drawing.Size(142, 23);
            this.AddSkill.TabIndex = 15;
            this.AddSkill.Text = "Add Selected Skill";
            this.AddSkill.UseVisualStyleBackColor = true;
            this.AddSkill.Click += new System.EventHandler(this.AddSkill_Click);
            // 
            // AddEmptySpace
            // 
            this.AddEmptySpace.Location = new System.Drawing.Point(7, 331);
            this.AddEmptySpace.Name = "AddEmptySpace";
            this.AddEmptySpace.Size = new System.Drawing.Size(118, 22);
            this.AddEmptySpace.TabIndex = 13;
            this.AddEmptySpace.Text = "Add Empty Space";
            this.AddEmptySpace.UseVisualStyleBackColor = true;
            this.AddEmptySpace.Click += new System.EventHandler(this.AddEmptySpace_Click);
            // 
            // EmptySpaceSeconds
            // 
            this.EmptySpaceSeconds.Location = new System.Drawing.Point(130, 332);
            this.EmptySpaceSeconds.Name = "EmptySpaceSeconds";
            this.EmptySpaceSeconds.ShortcutsEnabled = false;
            this.EmptySpaceSeconds.Size = new System.Drawing.Size(115, 20);
            this.EmptySpaceSeconds.TabIndex = 12;
            this.EmptySpaceSeconds.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EmptySpaceSeconds_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(246, 335);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 164;
            this.label1.Text = "Seconds";
            // 
            // DirectDamage
            // 
            this.DirectDamage.Location = new System.Drawing.Point(130, 174);
            this.DirectDamage.Name = "DirectDamage";
            this.DirectDamage.ShortcutsEnabled = false;
            this.DirectDamage.Size = new System.Drawing.Size(115, 20);
            this.DirectDamage.TabIndex = 3;
            this.DirectDamage.Text = "0";
            this.DirectDamage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressNumberOnly);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 168;
            this.label2.Text = "Direct Skill Boost:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(253, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 169;
            this.label3.Text = "Points";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(249, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 172;
            this.label4.Text = "Percent";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 171;
            this.label5.Text = "Cooldown Reduction:";
            // 
            // CooldownReduction
            // 
            this.CooldownReduction.Location = new System.Drawing.Point(130, 200);
            this.CooldownReduction.Name = "CooldownReduction";
            this.CooldownReduction.ShortcutsEnabled = false;
            this.CooldownReduction.Size = new System.Drawing.Size(115, 20);
            this.CooldownReduction.TabIndex = 4;
            this.CooldownReduction.Text = "0";
            this.CooldownReduction.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressNumberOnly);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Strength);
            this.groupBox1.Controls.Add(this.Focuss);
            this.groupBox1.Controls.Add(this.Attack);
            this.groupBox1.Controls.Add(this.Dexterity);
            this.groupBox1.Controls.Add(this.Vitality);
            this.groupBox1.Controls.Add(this.WeaponAbility);
            this.groupBox1.Controls.Add(this.SkillAbility);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(7, 220);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 107);
            this.groupBox1.TabIndex = 173;
            this.groupBox1.TabStop = false;
            // 
            // Strength
            // 
            this.Strength.Location = new System.Drawing.Point(50, 35);
            this.Strength.Name = "Strength";
            this.Strength.ShortcutsEnabled = false;
            this.Strength.Size = new System.Drawing.Size(91, 20);
            this.Strength.TabIndex = 5;
            this.Strength.Text = "0";
            this.Strength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValueTextbox_KeyPress);
            // 
            // Focuss
            // 
            this.Focuss.Location = new System.Drawing.Point(50, 57);
            this.Focuss.Name = "Focuss";
            this.Focuss.ShortcutsEnabled = false;
            this.Focuss.Size = new System.Drawing.Size(91, 20);
            this.Focuss.TabIndex = 6;
            this.Focuss.Text = "0";
            this.Focuss.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValueTextbox_KeyPress);
            // 
            // Attack
            // 
            this.Attack.Location = new System.Drawing.Point(193, 13);
            this.Attack.Name = "Attack";
            this.Attack.ShortcutsEnabled = false;
            this.Attack.Size = new System.Drawing.Size(91, 20);
            this.Attack.TabIndex = 8;
            this.Attack.Text = "0";
            this.Attack.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValueTextbox_KeyPress);
            // 
            // Dexterity
            // 
            this.Dexterity.Location = new System.Drawing.Point(193, 35);
            this.Dexterity.Name = "Dexterity";
            this.Dexterity.ShortcutsEnabled = false;
            this.Dexterity.Size = new System.Drawing.Size(91, 20);
            this.Dexterity.TabIndex = 9;
            this.Dexterity.Text = "0";
            this.Dexterity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValueTextbox_KeyPress);
            // 
            // Vitality
            // 
            this.Vitality.Location = new System.Drawing.Point(193, 57);
            this.Vitality.Name = "Vitality";
            this.Vitality.ShortcutsEnabled = false;
            this.Vitality.Size = new System.Drawing.Size(91, 20);
            this.Vitality.TabIndex = 10;
            this.Vitality.Text = "0";
            this.Vitality.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValueTextbox_KeyPress);
            // 
            // WeaponAbility
            // 
            this.WeaponAbility.Location = new System.Drawing.Point(50, 79);
            this.WeaponAbility.Name = "WeaponAbility";
            this.WeaponAbility.ShortcutsEnabled = false;
            this.WeaponAbility.Size = new System.Drawing.Size(91, 20);
            this.WeaponAbility.TabIndex = 7;
            this.WeaponAbility.Text = "0";
            this.WeaponAbility.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValueTextbox_KeyPress);
            // 
            // SkillAbility
            // 
            this.SkillAbility.Location = new System.Drawing.Point(193, 79);
            this.SkillAbility.Name = "SkillAbility";
            this.SkillAbility.ShortcutsEnabled = false;
            this.SkillAbility.Size = new System.Drawing.Size(91, 20);
            this.SkillAbility.TabIndex = 11;
            this.SkillAbility.Text = "0";
            this.SkillAbility.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValueTextbox_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(144, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "Attack:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(144, 82);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "S Ability:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "W Ability:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(144, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Vitality:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(144, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Dexterity:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Focus:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Strength:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(37, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Stat Modifiers";
            // 
            // DPSSolverAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 385);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CooldownReduction);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DirectDamage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EmptySpaceSeconds);
            this.Controls.Add(this.AddEmptySpace);
            this.Controls.Add(this.AddSkill);
            this.Controls.Add(this.AddAutoAttack);
            this.Controls.Add(this.label57);
            this.Controls.Add(this.SkillLevelDropdown);
            this.Controls.Add(this.SkillNameSearchTextbox);
            this.Controls.Add(this.label58);
            this.Controls.Add(this.SkillSearchListbox);
            this.Controls.Add(this.label60);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DPSSolverAction";
            this.Text = "DPS/Aggro Solver Action";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.ComboBox SkillLevelDropdown;
        private System.Windows.Forms.TextBox SkillNameSearchTextbox;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.ListBox SkillSearchListbox;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Button AddAutoAttack;
        private System.Windows.Forms.Button AddSkill;
        private System.Windows.Forms.Button AddEmptySpace;
        private System.Windows.Forms.TextBox EmptySpaceSeconds;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DirectDamage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox CooldownReduction;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox SkillAbility;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox Strength;
        private System.Windows.Forms.TextBox Focuss;
        private System.Windows.Forms.TextBox Attack;
        private System.Windows.Forms.TextBox Dexterity;
        private System.Windows.Forms.TextBox Vitality;
        private System.Windows.Forms.TextBox WeaponAbility;
    }
}