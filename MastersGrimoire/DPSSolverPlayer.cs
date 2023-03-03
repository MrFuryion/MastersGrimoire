using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HeroesAgeBestiary
{
    public partial class DPSSolverPlayer : Form
    {
        public DPSSolverPlayer()
        {
            InitializeComponent();
            Level.Text = MainForm.solverplayerlevel.ToString();
            Attack.Text = MainForm.solverattack.ToString();
            WeaponAbility.Text = MainForm.solverweaponability.ToString();
            SkillAbility.Text = MainForm.solverskillability.ToString();
            CritStrike.Text = MainForm.solvercritstrike.ToString();
            CritSkills.Text = MainForm.solvercritskills.ToString();
            Class.SelectedIndex = MainForm.solverclass;
            AttackSpeed.Text = MainForm.solverattackspeed.ToString();
            Strength.Text = MainForm.solverstrength.ToString();
            Dexterity.Text = MainForm.solverdexterity.ToString();
            Focuss.Text = MainForm.solverfocus.ToString();
            Vitality.Text = MainForm.solvervitality.ToString();
            Pierce.Text = MainForm.solverpierce.ToString();
            Slash.Text = MainForm.solverslash.ToString();
            Crush.Text = MainForm.solvercrush.ToString();
            Poison.Text = MainForm.solverpoison.ToString();
            Heat.Text = MainForm.solverheat.ToString();
            Cold.Text = MainForm.solvercold.ToString();
            Magic.Text = MainForm.solvermagic.ToString();
            Divine.Text = MainForm.solverdivine.ToString();
            Chaos.Text = MainForm.solverchaos.ToString();
            True.Text = MainForm.solvertrue.ToString();
        }

        private void KeyPressNumberOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void SavePlayerStats_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(AttackSpeed.Text))
            {
                if (float.Parse(AttackSpeed.Text) < 1)
                {
                    DialogResult dialogResult = MessageBox.Show("The Auto Attack speed cap is 1 second(1000 milliseconds/speed), you entered a number below this. Would you like to continue with a speed of 1000?", "Error", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        MainForm.solverattackspeed = 1000;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(AttackSpeed.Text) == true) MainForm.solverattackspeed = 0;
                    else MainForm.solverattackspeed = float.Parse(AttackSpeed.Text);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(AttackSpeed.Text) == true) MainForm.solverattackspeed = 0;
                else MainForm.solverattackspeed = float.Parse(AttackSpeed.Text);
            }
            if (string.IsNullOrEmpty(Level.Text) == true) MainForm.solverplayerlevel = 0;
            else MainForm.solverplayerlevel = float.Parse(Level.Text);
            if (string.IsNullOrEmpty(Attack.Text) == true) MainForm.solverattack = 0;
            else MainForm.solverattack = float.Parse(Attack.Text);
            if (string.IsNullOrEmpty(WeaponAbility.Text) == true) MainForm.solverweaponability = 0;
            else MainForm.solverweaponability = float.Parse(WeaponAbility.Text);
            if (string.IsNullOrEmpty(SkillAbility.Text) == true) MainForm.solverskillability = 0;
            else MainForm.solverskillability = float.Parse(SkillAbility.Text);
            if (string.IsNullOrEmpty(CritStrike.Text) == true) MainForm.solvercritstrike = 0;
            else MainForm.solvercritstrike = float.Parse(CritStrike.Text);
            if (string.IsNullOrEmpty(CritSkills.Text) == true) MainForm.solvercritskills = 0;
            else MainForm.solvercritskills = float.Parse(CritSkills.Text);
            switch (Class.SelectedIndex)
            {
                case 0: MainForm.solverclass = 0; break;
                case 1: MainForm.solverclass = 1; break;
                case 2: MainForm.solverclass = 2; break;
                case 3: MainForm.solverclass = 3; break;
                case 4: MainForm.solverclass = 4; break;
            }
            if (string.IsNullOrEmpty(Strength.Text) == true) MainForm.solverstrength = 0;
            else MainForm.solverstrength = float.Parse(Strength.Text);
            if (string.IsNullOrEmpty(Dexterity.Text) == true) MainForm.solverdexterity = 0;
            else MainForm.solverdexterity = float.Parse(Dexterity.Text);
            if (string.IsNullOrEmpty(Focuss.Text) == true) MainForm.solverfocus = 0;
            else MainForm.solverfocus = float.Parse(Focuss.Text);
            if (string.IsNullOrEmpty(Vitality.Text) == true) MainForm.solvervitality = 0;
            else MainForm.solvervitality = float.Parse(Vitality.Text);
            if (string.IsNullOrEmpty(Pierce.Text) == true) MainForm.solverpierce = 0;
            else MainForm.solverpierce = float.Parse(Pierce.Text);
            if (string.IsNullOrEmpty(Slash.Text) == true) MainForm.solverslash = 0;
            else MainForm.solverslash = float.Parse(Slash.Text);
            if (string.IsNullOrEmpty(Crush.Text) == true) MainForm.solvercrush = 0;
            else MainForm.solvercrush = float.Parse(Crush.Text);
            if (string.IsNullOrEmpty(Poison.Text) == true) MainForm.solverpoison = 0;
            else MainForm.solverpoison = float.Parse(Poison.Text);
            if (string.IsNullOrEmpty(Heat.Text) == true) MainForm.solverheat = 0;
            else MainForm.solverheat = float.Parse(Heat.Text);
            if (string.IsNullOrEmpty(Cold.Text) == true) MainForm.solvercold = 0;
            else MainForm.solvercold = float.Parse(Cold.Text);
            if (string.IsNullOrEmpty(Magic.Text) == true) MainForm.solvermagic = 0;
            else MainForm.solvermagic = float.Parse(Magic.Text);
            if (string.IsNullOrEmpty(Divine.Text) == true) MainForm.solverdivine = 0;
            else MainForm.solverdivine = float.Parse(Divine.Text);
            if (string.IsNullOrEmpty(Chaos.Text) == true) MainForm.solverchaos = 0;
            else MainForm.solverchaos = float.Parse(Chaos.Text);
            if (string.IsNullOrEmpty(True.Text) == true) MainForm.solvertrue = 0;
            else MainForm.solvertrue = float.Parse(True.Text);
            MainForm.playerdone = true;
            this.Close();
        }
    }
}
