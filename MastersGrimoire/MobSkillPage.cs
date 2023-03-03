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
    public partial class MobSkillPage : Form
    {
        MainForm mainscreen;
        public MobSkillPage(MainForm mainpage)
        {
            InitializeComponent();
            mainscreen = mainpage;
            int skillhold;
            int abilityhold;
            for (int i = 0; i < MainForm.mobskillmobid.Count; i++)
            {
                if (MainForm.mobskillmobid[i] == MainForm.mobidcross)
                {
                    skillhold = MainForm.skillid.IndexOf(MainForm.mobskillskillid[i]);
                    MobSkillListbox.Items.Add(MainForm.skillname[skillhold] + "(Level " + (Convert.ToInt32(MainForm.mobskilllevel[i]) + 1) + ")");
                }
            }
            for (int i = 0; i < MainForm.mobabilitymobid.Count; i++)
            {
                if (MainForm.mobabilitymobid[i] == MainForm.mobidcross)
                {
                    abilityhold = MainForm.abilityid.IndexOf(MainForm.mobabilityabilityid[i]);
                    MobAbilityListbox.Items.Add(MainForm.abilityname[abilityhold] + "(" + MainForm.mobabilityamount[i] + ")");
                }
            }
        }

        private void MobSkillPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.skillopen = false;
            mainscreen.EnemySkillButtonOpen();
        }
    }
}
