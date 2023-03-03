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
    public partial class DPSSolverAction : Form
    {
        float lasttime = 0;
        float lastduration = 0;
        float attackspeedmulti = 1;
        int pvpmode;
        public DPSSolverAction()
        {
            InitializeComponent();
            if (MainForm.solverpvp == true) pvpmode = 1;
            else pvpmode = 0;
            yiholder.Add(new List<int>());
            for (int x = 0; x < MainForm.skillname.Count; x++)
            {
                yiholder[0].Add(x);
            }
            for (int x = 0; x < MainForm.solveractiontype.Count; x++)
            {
                if (MainForm.solveractiontype[x] == 2)
                {
                    if (MainForm.statuseffect[MainForm.solverstatusid[x]] == "17")
                    {
                        lasttime = MainForm.solverskillhittime[x];
                        lastduration = MainForm.solverstatusmaxduration[x];
                        attackspeedmulti = Math.Abs((float.Parse(MainForm.statuslvbase[MainForm.solverskilllevel[x] + pvpmode]) + float.Parse(MainForm.statuslvinitial[MainForm.solverskilllevel[x] + pvpmode]) / 100) - 1);
                    }
                }
            }
        }

        private void KeyPressNumberOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void EmptySpaceSeconds_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                if (!Char.Equals(e.KeyChar, '.'))
                {
                    e.Handled = true;
                }
                else
                {
                    if (EmptySpaceSeconds.Text.Contains('.'))
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        bool hasstatus = false;
        List<int> yholder = new List<int>();
        List<int> yholder2 = new List<int>();
        int yholder3;
        List<int> yholder4 = new List<int>();
        List<List<int>> yiholder = new List<List<int>>();
        int yilength = 0;
        int yilength2 = 0;
        string yisearch;
        bool yiwarning = false;
        float timercount = 0;
        bool skillhandled = false;
        bool autohandled = false;

        private void SkillNameSearchTextbox_TextChanged(object sender, EventArgs e)
        {
            SkillSearchListbox.Items.Clear();
            yholder.Clear();
            AddSkill.Enabled = false;
            SkillLevelDropdown.Items.Clear();
            SkillSearchListbox.BeginUpdate();
            yilength2 = SkillNameSearchTextbox.Text.Length - yilength;
            if (string.IsNullOrEmpty(yisearch) == false)
            {
                if (yisearch.Length > SkillNameSearchTextbox.Text.Length)
                {
                    if (yisearch.Substring(0, SkillNameSearchTextbox.Text.Length) != SkillNameSearchTextbox.Text)
                    {
                        yiwarning = true;
                    }
                }
                else
                {
                    if (SkillNameSearchTextbox.Text.Substring(0, yisearch.Length) != yisearch)
                    {
                        yiwarning = true;
                    }
                }
            }
            if (yilength > SkillNameSearchTextbox.Text.Length && yiwarning == false)
            {
                for (int i = 0; i < yiholder[SkillNameSearchTextbox.Text.Length].Count; i++)
                {
                    if (MainForm.skillname[yiholder[SkillNameSearchTextbox.Text.Length][i]].ToUpper().Contains(SkillNameSearchTextbox.Text.ToUpper()))
                    {
                        SkillSearchListbox.Items.Add(MainForm.skillname[yiholder[SkillNameSearchTextbox.Text.Length][i]]);
                        yholder.Add(yiholder[SkillNameSearchTextbox.Text.Length][i]);
                    }
                }
                yiholder.RemoveRange(SkillNameSearchTextbox.Text.Length + 1, yilength - SkillNameSearchTextbox.Text.Length);
                yilength = SkillNameSearchTextbox.Text.Length;
            }
            else
            {
                if (yiwarning == true)
                {
                    yilength = 0;
                    yiholder.RemoveRange(1, yiholder.Count - 1);
                }
                yilength2 = yilength;
                for (int a = 0; a < SkillNameSearchTextbox.Text.Length - yilength2; a++)
                {
                    yiholder.Add(new List<int>());
                    for (int i = 0; i < yiholder[yilength].Count; i++)
                    {
                        if (MainForm.skillname[yiholder[yilength][i]].ToUpper().Contains(SkillNameSearchTextbox.Text.Substring(0, yilength + 1).ToUpper()))
                        {
                            yiholder[yilength + 1].Add(yiholder[yilength][i]);
                        }
                    }
                    yilength = yilength + 1;
                }
                yholder.Clear();
                for (int i = 0; i < yiholder[yilength].Count; i++)
                {
                    yholder.Add(yiholder[yilength][i]);
                    SkillSearchListbox.Items.Add(MainForm.skillname[yiholder[yilength][i]]);
                }
            }
            SkillSearchListbox.EndUpdate();
            yisearch = SkillNameSearchTextbox.Text;
            yiwarning = false;
        }

        private void SkillSearchListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddSkill.Enabled = true;
            hasstatus = false;
            yholder2.Clear();
            yholder3 = -1;
            if (SkillSearchListbox.SelectedIndex > -1)
            {
                SkillLevelDropdown.Items.Clear();
                int old = -1;
                if (MainForm.skilllvid.IndexOf(MainForm.skillid[yholder[SkillSearchListbox.SelectedIndex]]) != -1)
                {
                    for (int i = 0; i < MainForm.skilllvid.Count; i++)
                    {
                        if (MainForm.skillid[yholder[SkillSearchListbox.SelectedIndex]] == MainForm.skilllvid[i])
                        {
                            if (Convert.ToInt32(MainForm.skilllvlevel[i]) != old)
                            {
                                SkillLevelDropdown.Items.Add((Convert.ToInt32(MainForm.skilllvlevel[i]) + 1).ToString());
                            }
                            old = Convert.ToInt32(MainForm.skilllvlevel[i]);
                            yholder2.Add(i);
                        }
                    }
                }
            }
            if (MainForm.statusid.IndexOf(MainForm.skillstatus[yholder[SkillSearchListbox.SelectedIndex]]) != -1)
            {
                yholder3 = MainForm.statusid.IndexOf(MainForm.skillstatus[yholder[SkillSearchListbox.SelectedIndex]]);
                hasstatus = true;
            }
            if (SkillLevelDropdown.Items.Count > 0)
            {
                SkillLevelDropdown.SelectedIndex = 0;
            }
        }

        private void AddSpace(float time)
        {
            MainForm.solveractiontype.Add(3);
            MainForm.solverskillid.Add(-1);
            MainForm.solverskilllevel.Add(-1);
            MainForm.solverskillhittime.Add(-1);
            MainForm.solverstatusid.Add(-1);
            MainForm.solverstatusmaxduration.Add(-1);
            MainForm.solverstatusduration.Add(-1);
            MainForm.solverstatusticktime.Add(-1);
            MainForm.solverstatusamount.Add(-1);
            MainForm.solverstatusovercharge.Add(-1);
            MainForm.solverstatusoverchargeslash.Add(-1);
            MainForm.solverstatusoverchargecrush.Add(-1);
            MainForm.solverstatusapplied.Add(false);
            MainForm.solverstatusend.Add(false);
            MainForm.solverdirectdamage.Add(0);
            MainForm.solvercooldown.Add(0);
            MainForm.solvercasttime.Add(time);
            MainForm.solverlockout.Add(0);
            MainForm.solverstalltime.Add(0);
            MainForm.solverhaspvpversion.Add(false);
            MainForm.solverattackmod.Add(0);
            MainForm.solverstrengthmod.Add(0);
            MainForm.solverdexteritymod.Add(0);
            MainForm.solverfocusmod.Add(0);
            MainForm.solvervitalitymod.Add(0);
            MainForm.solverweaponabilitymod.Add(0);
            MainForm.solverskillabilitymod.Add(0);
            MainForm.solversinglemaxdamage.Add(-1);
            MainForm.solversingleactualdamage.Add(-1);
            MainForm.solversingleresistdamage.Add(-1);
            MainForm.solversingleleveldamage.Add(-1);
            MainForm.solversingledps.Add(-1);
            MainForm.solversinglechancetohit.Add(-1);
            MainForm.solversinglecritchance.Add(-1);
            MainForm.solversingleaggro.Add(-1);
            MainForm.solversinglelock.Add(-1);
            MainForm.solversingletimeforaction.Add(-1);
            MainForm.solvermobstatsave.Add(new List<float>());
            MainForm.solvermobstatinfo.Add(new List<float>());
            MainForm.solverplayerstatsave.Add(new List<float>());
            MainForm.solverplayerstatinfo.Add(new List<float>());
        }

        private void AddAuto(float time)
        {
            MainForm.solveractiontype.Add(0);
            MainForm.solverskillid.Add(-1);
            MainForm.solverskilllevel.Add(-1);
            MainForm.solverskillhittime.Add(-1);
            MainForm.solverstatusid.Add(-1);
            MainForm.solverstatusmaxduration.Add(-1);
            MainForm.solverstatusduration.Add(-1);
            MainForm.solverstatusticktime.Add(-1);
            MainForm.solverstatusamount.Add(-1);
            MainForm.solverstatusovercharge.Add(-1);
            MainForm.solverstatusoverchargeslash.Add(-1);
            MainForm.solverstatusoverchargecrush.Add(-1);
            MainForm.solverstatusapplied.Add(false);
            MainForm.solverstatusend.Add(false);
            MainForm.solverdirectdamage.Add(0);
            if (lasttime + lastduration >= MainForm.timeholder + (MainForm.solverattackspeed * attackspeedmulti)) // assuming that autos arent percentage based, and when haste is lost it has to travel to the new auto attack cooldown
            {
                MainForm.solvercooldown.Add(time * attackspeedmulti);
            }
            else MainForm.solvercooldown.Add(time);
            MainForm.solvercasttime.Add(0);
            MainForm.solverlockout.Add(0);
            MainForm.solverstalltime.Add(0);
            MainForm.solverhaspvpversion.Add(false);
            if (!string.IsNullOrEmpty(Attack.Text))
            {
                MainForm.solverattackmod.Add(float.Parse(Attack.Text));
            }
            else MainForm.solverattackmod.Add(0);
            if (!string.IsNullOrEmpty(Strength.Text))
            {
                MainForm.solverstrengthmod.Add(float.Parse(Strength.Text));
            }
            else MainForm.solverstrengthmod.Add(0);
            MainForm.solverdexteritymod.Add(0);
            MainForm.solverfocusmod.Add(0);
            MainForm.solvervitalitymod.Add(0);
            if (!string.IsNullOrEmpty(WeaponAbility.Text))
            {
                MainForm.solverweaponabilitymod.Add(float.Parse(WeaponAbility.Text));
            }
            else MainForm.solverweaponabilitymod.Add(0);
            MainForm.solverskillabilitymod.Add(0);
            MainForm.solversinglemaxdamage.Add(-1);
            MainForm.solversingleactualdamage.Add(-1);
            MainForm.solversingleresistdamage.Add(-1);
            MainForm.solversingleleveldamage.Add(-1);
            MainForm.solversingledps.Add(-1);
            MainForm.solversinglechancetohit.Add(-1);
            MainForm.solversinglecritchance.Add(-1);
            MainForm.solversingleaggro.Add(-1);
            MainForm.solversinglelock.Add(-1);
            MainForm.solversingletimeforaction.Add(-1);
            MainForm.solvermobstatsave.Add(new List<float>());
            MainForm.solvermobstatinfo.Add(new List<float>());
            MainForm.solverplayerstatsave.Add(new List<float>());
            MainForm.solverplayerstatinfo.Add(new List<float>());
        }

        private void AddSkil()
        {
            if (yholder2.Count > 1)
            {
                if (MainForm.skilllvpvp[yholder2[1]] == "1")
                {
                    MainForm.solverhaspvpversion.Add(true);
                    MainForm.solverskilllevel.Add(yholder2[SkillLevelDropdown.SelectedIndex * 2]);
                }
                else
                {
                    MainForm.solverhaspvpversion.Add(false);
                    MainForm.solverskilllevel.Add(yholder2[SkillLevelDropdown.SelectedIndex]);
                }
            }
            else
            {
                if (yholder2.Count == 1)
                {
                    MainForm.solverskilllevel.Add(yholder2[0]);
                    MainForm.solverhaspvpversion.Add(false);
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("The selected skill \"" + MainForm.skillname[yholder[SkillSearchListbox.SelectedIndex]] + "\" has no levels and cannot be used.", "Error");
                    return;
                }
            }
            MainForm.solveractiontype.Add(1);
            MainForm.solverskillid.Add(yholder[SkillSearchListbox.SelectedIndex]);
            MainForm.solverskillhittime.Add(-1);
            if (string.IsNullOrEmpty(DirectDamage.Text) == true) MainForm.solverdirectdamage.Add(0);
            else MainForm.solverdirectdamage.Add(float.Parse(DirectDamage.Text));
            MainForm.solverlockout.Add(float.Parse(MainForm.skillblocktime[yholder[SkillSearchListbox.SelectedIndex]]));
            MainForm.solverstalltime.Add(0);
            MainForm.solverstatusid.Add(-1);
            MainForm.solverstatusmaxduration.Add(-1);
            MainForm.solverstatusduration.Add(-1);
            MainForm.solverstatusticktime.Add(-1);
            MainForm.solverstatusamount.Add(-1);
            MainForm.solverstatusovercharge.Add(-1);
            MainForm.solverstatusoverchargeslash.Add(-1);
            MainForm.solverstatusoverchargecrush.Add(-1);
            MainForm.solverstatusapplied.Add(false);
            MainForm.solverstatusend.Add(false);
            MainForm.solverattackmod.Add(0);
            if (!string.IsNullOrEmpty(Strength.Text))
            {
                MainForm.solverstrengthmod.Add(float.Parse(Strength.Text));
            }
            else MainForm.solverstrengthmod.Add(0);
            if (!string.IsNullOrEmpty(Dexterity.Text))
            {
                MainForm.solverdexteritymod.Add(float.Parse(Dexterity.Text));
            }
            else MainForm.solverdexteritymod.Add(0);
            if (!string.IsNullOrEmpty(Focuss.Text))
            {
                MainForm.solverfocusmod.Add(float.Parse(Focuss.Text));
            }
            else MainForm.solverfocusmod.Add(0);
            if (!string.IsNullOrEmpty(Vitality.Text))
            {
                MainForm.solvervitalitymod.Add(float.Parse(Vitality.Text));
            }
            else MainForm.solvervitalitymod.Add(0);
            if (!string.IsNullOrEmpty(WeaponAbility.Text))
            {
                MainForm.solverweaponabilitymod.Add(float.Parse(WeaponAbility.Text));
            }
            else MainForm.solverweaponabilitymod.Add(0);
            if (!string.IsNullOrEmpty(SkillAbility.Text))
            {
                MainForm.solverskillabilitymod.Add(float.Parse(SkillAbility.Text));
            }
            else MainForm.solverskillabilitymod.Add(0);
            if (string.IsNullOrEmpty(CooldownReduction.Text) == true) MainForm.solvercooldown.Add(float.Parse(MainForm.skilllvcooldown[yholder2[SkillLevelDropdown.SelectedIndex]]));
            else MainForm.solvercooldown.Add(float.Parse(MainForm.skilllvcooldown[yholder2[SkillLevelDropdown.SelectedIndex]]) * (Math.Abs(float.Parse(CooldownReduction.Text) - 100) / 100));
            if (MainForm.skillauto[yholder[SkillSearchListbox.SelectedIndex]] == "Yes") // haste would still help cast time
            {
                if (lasttime + lastduration >= MainForm.timeholder + float.Parse(MainForm.skilllvcasttime[yholder2[SkillLevelDropdown.SelectedIndex]]) + (MainForm.solverattackspeed * attackspeedmulti))
                {
                    MainForm.solvercasttime.Add(float.Parse(MainForm.skilllvcasttime[yholder2[SkillLevelDropdown.SelectedIndex]]) + ((MainForm.solverattackspeed / 1000)) * attackspeedmulti);
                }
                else MainForm.solvercasttime.Add(float.Parse(MainForm.skilllvcasttime[yholder2[SkillLevelDropdown.SelectedIndex]]) + (MainForm.solverattackspeed / 1000));
            }
            else
            {
                MainForm.solvercasttime.Add(float.Parse(MainForm.skilllvcasttime[yholder2[SkillLevelDropdown.SelectedIndex]]));
            }
            MainForm.solversinglemaxdamage.Add(-1);
            MainForm.solversingleactualdamage.Add(-1);
            MainForm.solversingleresistdamage.Add(-1);
            MainForm.solversingleleveldamage.Add(-1);
            MainForm.solversingledps.Add(-1);
            MainForm.solversinglechancetohit.Add(-1);
            MainForm.solversinglecritchance.Add(-1);
            MainForm.solversingleaggro.Add(-1);
            MainForm.solversinglelock.Add(-1);
            MainForm.solversingletimeforaction.Add(-1);
            MainForm.solvermobstatsave.Add(new List<float>());
            MainForm.solvermobstatinfo.Add(new List<float>());
            MainForm.solverplayerstatsave.Add(new List<float>());
            MainForm.solverplayerstatinfo.Add(new List<float>());
            if (hasstatus == true)
            {
                yholder4.Clear();
                for (int i = 0; i < MainForm.statuslvid.Count; i++)
                {
                    if (MainForm.statusid[yholder3] == MainForm.statuslvid[i])
                    {
                        yholder4.Add(i);
                    }
                }
                if (yholder4.Count > 1)
                {
                    if (MainForm.statuslvpvp[yholder4[1]] == "1")
                    {
                        MainForm.solverhaspvpversion.Add(true);
                        MainForm.solverskilllevel.Add(yholder4[SkillLevelDropdown.SelectedIndex * 2]);
                    }
                    else
                    {
                        MainForm.solverhaspvpversion.Add(false);
                        MainForm.solverskilllevel.Add(yholder4[SkillLevelDropdown.SelectedIndex]);
                    }
                }
                else
                {
                    if (yholder4.Count == 1)
                    {
                        MainForm.solverskilllevel.Add(yholder4[0]);
                        MainForm.solverhaspvpversion.Add(false);
                    }
                    else // undoing the skill addition so a buggy skill(that probably doesn't even exist) doesn't confuse people
                    {
                        DialogResult dialogResult = MessageBox.Show("The selected status \"" + MainForm.skillname[yholder[SkillSearchListbox.SelectedIndex]] + "\" has no levels and cannot be used.", "Error");
                        MainForm.solveractiontype.RemoveAt(MainForm.solveractiontype.Count - 1);
                        MainForm.solverskillid.RemoveAt(MainForm.solverskillid.Count - 1);
                        MainForm.solverskilllevel.RemoveAt(MainForm.solverskilllevel.Count - 1);
                        MainForm.solverskillhittime.RemoveAt(MainForm.solverskillhittime.Count - 1);
                        MainForm.solverstatusid.RemoveAt(MainForm.solverstatusid.Count - 1);
                        MainForm.solverstatusmaxduration.RemoveAt(MainForm.solverstatusmaxduration.Count - 1);
                        MainForm.solverstatusduration.RemoveAt(MainForm.solverstatusduration.Count - 1);
                        MainForm.solverstatusticktime.RemoveAt(MainForm.solverstatusticktime.Count - 1);
                        MainForm.solverstatusamount.RemoveAt(MainForm.solverstatusamount.Count - 1);
                        MainForm.solverstatusovercharge.RemoveAt(MainForm.solverstatusovercharge.Count - 1);
                        MainForm.solverstatusoverchargeslash.RemoveAt(MainForm.solverstatusoverchargeslash.Count - 1);
                        MainForm.solverstatusoverchargecrush.RemoveAt(MainForm.solverstatusoverchargecrush.Count - 1);
                        MainForm.solverstatusapplied.RemoveAt(MainForm.solverstatusapplied.Count - 1);
                        MainForm.solverstatusend.RemoveAt(MainForm.solverstatusend.Count - 1);
                        MainForm.solverdirectdamage.RemoveAt(MainForm.solverdirectdamage.Count - 1);
                        MainForm.solvercooldown.RemoveAt(MainForm.solvercooldown.Count - 1);
                        MainForm.solvercasttime.RemoveAt(MainForm.solvercasttime.Count - 1);
                        MainForm.solverlockout.RemoveAt(MainForm.solverlockout.Count - 1);
                        MainForm.solverstalltime.RemoveAt(MainForm.solverstalltime.Count - 1);
                        MainForm.solverattackmod.RemoveAt(MainForm.solverattackmod.Count - 1);
                        MainForm.solverstrengthmod.RemoveAt(MainForm.solverstrengthmod.Count - 1);
                        MainForm.solverdexteritymod.RemoveAt(MainForm.solverdexteritymod.Count - 1);
                        MainForm.solverfocusmod.RemoveAt(MainForm.solverfocusmod.Count - 1);
                        MainForm.solvervitalitymod.RemoveAt(MainForm.solvervitalitymod.Count - 1);
                        MainForm.solverweaponabilitymod.RemoveAt(MainForm.solverweaponabilitymod.Count - 1);
                        MainForm.solverskillabilitymod.RemoveAt(MainForm.solverskillabilitymod.Count - 1);
                        MainForm.solverhaspvpversion.RemoveAt(MainForm.solverhaspvpversion.Count - 1);
                        MainForm.solversinglemaxdamage.RemoveAt(MainForm.solversinglemaxdamage.Count - 1);
                        MainForm.solversingleactualdamage.RemoveAt(MainForm.solversingleactualdamage.Count - 1);
                        MainForm.solversingleresistdamage.RemoveAt(MainForm.solversingleresistdamage.Count - 1);
                        MainForm.solversingleleveldamage.RemoveAt(MainForm.solversingleleveldamage.Count - 1);
                        MainForm.solversingledps.RemoveAt(MainForm.solversingledps.Count - 1);
                        MainForm.solversinglechancetohit.RemoveAt(MainForm.solversinglechancetohit.Count - 1);
                        MainForm.solversinglecritchance.RemoveAt(MainForm.solversinglecritchance.Count - 1);
                        MainForm.solversingleaggro.RemoveAt(MainForm.solversingleaggro.Count - 1);
                        MainForm.solversinglelock.RemoveAt(MainForm.solversinglelock.Count - 1);
                        MainForm.solversingletimeforaction.RemoveAt(MainForm.solversingletimeforaction.Count - 1);
                        MainForm.solvermobstatsave.RemoveAt(MainForm.solvermobstatsave.Count - 1);
                        MainForm.solvermobstatinfo.RemoveAt(MainForm.solvermobstatinfo.Count - 1);
                        MainForm.solverplayerstatsave.RemoveAt(MainForm.solverplayerstatsave.Count - 1);
                        MainForm.solverplayerstatinfo.RemoveAt(MainForm.solverplayerstatinfo.Count - 1);
                        return;
                    }
                }
                MainForm.solveractiontype.Add(2);
                MainForm.solverskillid.Add(yholder[SkillSearchListbox.SelectedIndex]);
                MainForm.solverskillhittime.Add(-1);
                MainForm.solverstatusid.Add(yholder3);
                MainForm.solverstatusmaxduration.Add(-1);
                MainForm.solverstatusduration.Add(-1);
                MainForm.solverstatusticktime.Add(-1);
                MainForm.solverstatusamount.Add(-1);
                MainForm.solverstatusovercharge.Add(0);
                MainForm.solverstatusoverchargeslash.Add(0);
                MainForm.solverstatusoverchargecrush.Add(0);
                MainForm.solverstatusapplied.Add(false);
                MainForm.solverstatusend.Add(false);
                MainForm.solverdirectdamage.Add(0);
                MainForm.solvercooldown.Add(float.Parse(MainForm.statuslvduration[yholder4[SkillLevelDropdown.SelectedIndex]]));
                MainForm.solvercasttime.Add(0);
                MainForm.solverlockout.Add(0);
                if (MainForm.statustick[yholder3] == "N/A") MainForm.solverstalltime.Add(-1);
                else MainForm.solverstalltime.Add(float.Parse(MainForm.statustick[yholder3]));
                MainForm.solverattackmod.Add(0);
                if (!string.IsNullOrEmpty(Strength.Text))
                {
                    MainForm.solverstrengthmod.Add(float.Parse(Strength.Text));
                }
                else MainForm.solverstrengthmod.Add(0);
                if (!string.IsNullOrEmpty(Dexterity.Text))
                {
                    MainForm.solverdexteritymod.Add(float.Parse(Dexterity.Text));
                }
                else MainForm.solverdexteritymod.Add(0);
                if (!string.IsNullOrEmpty(Focuss.Text))
                {
                    MainForm.solverfocusmod.Add(float.Parse(Focuss.Text));
                }
                else MainForm.solverfocusmod.Add(0);
                if (!string.IsNullOrEmpty(Vitality.Text))
                {
                    MainForm.solvervitalitymod.Add(float.Parse(Vitality.Text));
                }
                else MainForm.solvervitalitymod.Add(0);
                MainForm.solverweaponabilitymod.Add(0);
                if (!string.IsNullOrEmpty(SkillAbility.Text))
                {
                    MainForm.solverskillabilitymod.Add(float.Parse(SkillAbility.Text));
                }
                else MainForm.solverskillabilitymod.Add(0);
                MainForm.solversinglemaxdamage.Add(-1);
                MainForm.solversingleactualdamage.Add(-1);
                MainForm.solversingleresistdamage.Add(-1);
                MainForm.solversingleleveldamage.Add(-1);
                MainForm.solversingledps.Add(-1);
                MainForm.solversinglechancetohit.Add(-1);
                MainForm.solversinglecritchance.Add(-1);
                MainForm.solversingleaggro.Add(-1);
                MainForm.solversinglelock.Add(-1);
                MainForm.solversingletimeforaction.Add(-1);
                MainForm.solvermobstatsave.Add(new List<float>());
                MainForm.solvermobstatinfo.Add(new List<float>());
                MainForm.solverplayerstatsave.Add(new List<float>());
                MainForm.solverplayerstatinfo.Add(new List<float>());
            }
        }

        private void AddEmptySpace_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(EmptySpaceSeconds.Text))
            {
                AddSpace(float.Parse(EmptySpaceSeconds.Text));
                this.Close();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("\"Empty Space\" seconds cannot be blank.", "Error");
            }
        }

        private void AddAutoAttack_Click(object sender, EventArgs e)
        {
            autohandled = false;
            timercount = 0;
            if (MainForm.solveractiontype.Count > 0)
            {
                for (int x = 0; x < MainForm.solveractiontype.Count; x++)
                {
                    switch (MainForm.solveractiontype[MainForm.solveractiontype.Count - x - 1])
                    {
                        case 0:
                            if (MainForm.solvercooldown[MainForm.solvercooldown.Count - x - 1] <= timercount)
                            {
                                AddAuto(MainForm.solverattackspeed / 1000);
                                autohandled = true;
                                this.Close();
                                return;
                            }
                            else
                            {
                                DialogResult dialogResult = MessageBox.Show("The \"Auto Attack\" isn't ready yet! It needs " + (MainForm.solverattackspeed / 1000 - timercount) + " more seconds of empty space to recharge. Would you like to add " + (MainForm.solverattackspeed / 1000 - timercount) + " seconds of empty space to be able to use an \"Auto Attack?\"", "Error", MessageBoxButtons.YesNo);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    AddSpace(MainForm.solverattackspeed / 1000 - timercount);
                                    AddAuto(MainForm.solverattackspeed / 1000);
                                    autohandled = true;
                                    this.Close();
                                    return;
                                }
                                else if (dialogResult == DialogResult.No)
                                {
                                    return;
                                }
                            }
                            break;
                        case 3:
                            timercount = timercount + MainForm.solvercasttime[MainForm.solvercasttime.Count - 1 - x];
                            break;
                    }
                }
            }
            else
            {
                AddAuto(MainForm.solverattackspeed / 1000);
                autohandled = true;
                this.Close();
            }
            if (autohandled == false)
            {
                AddAuto(MainForm.solverattackspeed / 1000);
                autohandled = true;
                this.Close();
            }
        }

        private void AddSkill_Click(object sender, EventArgs e)
        {
            timercount = 0;
            skillhandled = false;
            if (MainForm.solveractiontype.Count > 0)
            {
                for (int x = 0; x < MainForm.solveractiontype.Count; x++)
                {
                    if (MainForm.solveractiontype[MainForm.solveractiontype.Count - x - 1] == 3)
                    {
                        timercount = timercount + MainForm.solvercasttime[MainForm.solvercasttime.Count - x];
                    }
                    else if (MainForm.solveractiontype[MainForm.solveractiontype.Count - x - 1] == 1)
                    {
                        if (Convert.ToInt32(MainForm.skillid[MainForm.solverskillid[MainForm.solverskillid.Count - x - 1]]) == Convert.ToInt32(MainForm.skillid[yholder[SkillSearchListbox.SelectedIndex]]))
                        {
                            if (MainForm.solvercooldown[MainForm.solveractiontype.Count - x - 1] - MainForm.solverlockout[MainForm.solveractiontype.Count - x - 1] >= timercount)
                            {
                                DialogResult dialogResult = MessageBox.Show("\"" + MainForm.skillname[yholder[SkillSearchListbox.SelectedIndex]] + "\" isn't ready yet! It needs " + (MainForm.solvercooldown[MainForm.solveractiontype.Count - x - 1] - MainForm.solverlockout[MainForm.solveractiontype.Count - x - 1] - timercount) + " more seconds to recharge. Would you like to add " + (MainForm.solvercooldown[MainForm.solveractiontype.Count - x - 1] - MainForm.solverlockout[MainForm.solveractiontype.Count - x - 1] - timercount) + " seconds of empty space to be able to use " + "\"" + MainForm.skillname[yholder[SkillSearchListbox.SelectedIndex]] + "\"?", "Error", MessageBoxButtons.YesNo);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    AddSpace(MainForm.solvercooldown[MainForm.solveractiontype.Count - x - 1] - MainForm.solverlockout[MainForm.solveractiontype.Count - x - 1] - timercount);
                                    AddSkil();
                                    skillhandled = true;
                                    this.Close();
                                    return;
                                }
                                else if (dialogResult == DialogResult.No)
                                {
                                    skillhandled = true;
                                    return;
                                }
                            }
                        }
                        else
                        {
                            timercount = timercount + MainForm.solvercasttime[MainForm.solverskillid.Count - x - 1] + MainForm.solverlockout[MainForm.solverskillid.Count - x - 1];
                        }
                    }
                }
                if (skillhandled == false)
                {
                    AddSkil();
                    this.Close();
                }
            }
            else
            {
                AddSkil();
                this.Close();
            }
        }

        private void ValueTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textbox = sender as TextBox;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) // numbers are allowed, no text
            {
                if (!Char.Equals(e.KeyChar, '-')) // 1 negative sign allowed, and it must be the first character
                {
                    e.Handled = true;
                }
                else
                {
                    if (textbox.Text.Length > 0)
                    {
                        e.Handled = true;
                    }
                }
            }
        }
    }
}
