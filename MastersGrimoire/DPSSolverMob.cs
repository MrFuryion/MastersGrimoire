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
    public partial class DPSSolverMob : Form
    {
        public DPSSolverMob()
        {
            InitializeComponent();
            xiholder.Add(new List<int>());
            for (int x = 0; x < MainForm.mobname.Count; x++)
            {
                xiholder[0].Add(x);
            }
            if (MainForm.solvermobid == -2)
            {
                CustomMobCheckbox.Checked = true;
                if (MainForm.solverpvp == true) PVPMode.Checked = true;
                Level.Text = MainForm.solvermoblevel.ToString();
                Health.Text = MainForm.solverhealth.ToString();
                Defence.Text = MainForm.solverdefence.ToString();
                XP.Text = MainForm.solverxp.ToString();
                Aggro.Text = MainForm.solveraggro.ToString();
                ResistPierce.Text = MainForm.solverpluspierceresist.ToString();
                ResistPiercePercent.Text = Math.Abs((MainForm.solverpercentpierceresist * 100) - 100).ToString();
                ResistSlash.Text = MainForm.solverplusslashresist.ToString();
                ResistSlashPercent.Text = Math.Abs((MainForm.solverpercentslashresist * 100) - 100).ToString();
                ResistCrush.Text = MainForm.solverpluscrushresist.ToString();
                ResistCrushPercent.Text = Math.Abs((MainForm.solverpercentcrushresist * 100) - 100).ToString();
                ResistHeat.Text = MainForm.solverplusheatresist.ToString();
                ResistHeatPercent.Text = Math.Abs((MainForm.solverpercentheatresist * 100) - 100).ToString();
                ResistCold.Text = MainForm.solverpluscoldresist.ToString();
                ResistColdPercent.Text = Math.Abs((MainForm.solverpercentcoldresist * 100) - 100).ToString();
                ResistMagic.Text = MainForm.solverplusmagicresist.ToString();
                ResistMagicPercent.Text = Math.Abs((MainForm.solverpercentmagicresist * 100) - 100).ToString();
                ResistPoison.Text = MainForm.solverpluspoisonresist.ToString();
                ResistPoisonPercent.Text = Math.Abs((MainForm.solverpercentpoisonresist * 100) - 100).ToString();
                ResistDivine.Text = MainForm.solverplusdivineresist.ToString();
                ResistDivinePercent.Text = Math.Abs((MainForm.solverpercentdivineresist * 100) - 100).ToString();
                ResistChaos.Text = MainForm.solverpluschaosresist.ToString();
                ResistChaosPercent.Text = Math.Abs((MainForm.solverpercentchaosresist * 100) - 100).ToString();
                ResistTrue.Text = MainForm.solverplustrueresist.ToString();
                ResistTruePercent.Text = Math.Abs((MainForm.solverpercenttrueresist * 100) - 100).ToString();
                EvadePhysical.Text = MainForm.solverphysical.ToString();
                EvadeSpell.Text = MainForm.solverspell.ToString();
                EvadeMove.Text = MainForm.solvermovement.ToString();
                EvadeWound.Text = MainForm.solverwounding.ToString();
                EvadeWeak.Text = MainForm.solverweakening.ToString();
                EvadeMental.Text = MainForm.solvermental.ToString();
            }
            else if (MainForm.solvermobid != -1)
            {
                MonsterNameSearchTextbox.Text = MainForm.mobname[MainForm.solvermobid];
                IDSearch(MainForm.solvermobid);
            }
        }

        List<int> xholder = new List<int>();
        List<List<int>> xiholder = new List<List<int>>();
        int xilength = 0;
        int xilength2 = 0;
        string xisearch;
        bool xiwarning = false;
        bool nameskip = false;
        string[] sub;

    private void MonsterNameSearchTextbox_TextChanged(object sender, EventArgs e)
        {
            if (nameskip == false)
            {
                MonsterSearchListbox.BeginUpdate();
                MonsterSearchListbox.Items.Clear();
                xholder.Clear();
                if (MonsterSearchListbox.SelectedIndex == -1) SaveSelectedMob.Enabled = false;
                else SaveSelectedMob.Enabled = true;
                if (string.IsNullOrEmpty(xisearch) == false)
                {
                    if (xisearch.Length > MonsterNameSearchTextbox.Text.Length)
                    {
                        if (xisearch.Substring(0, MonsterNameSearchTextbox.Text.Length) != MonsterNameSearchTextbox.Text)
                        {
                            xiwarning = true;
                        }
                    }
                    else
                    {
                        if (MonsterNameSearchTextbox.Text.Substring(0, xisearch.Length) != xisearch)
                        {
                            xiwarning = true;
                        }
                    }
                }
                    xilength2 = MonsterNameSearchTextbox.Text.Length - xilength;
                if (xilength > MonsterNameSearchTextbox.Text.Length && xiwarning == false)
                {
                    for (int i = 0; i < xiholder[MonsterNameSearchTextbox.Text.Length].Count; i++)
                    {
                        if (MainForm.mobname[xiholder[MonsterNameSearchTextbox.Text.Length][i]].ToUpper().Contains(MonsterNameSearchTextbox.Text.ToUpper()))
                        {
                            MonsterSearchListbox.Items.Add(MainForm.mobname[xiholder[MonsterNameSearchTextbox.Text.Length][i]]);
                            xholder.Add(xiholder[MonsterNameSearchTextbox.Text.Length][i]);
                        }
                    }
                    xiholder.RemoveRange(MonsterNameSearchTextbox.Text.Length + 1, xilength - MonsterNameSearchTextbox.Text.Length);
                    xilength = MonsterNameSearchTextbox.Text.Length;
                }
                else
                {
                    if (xiwarning == true)
                    {
                        xilength = 0;
                        xiholder.RemoveRange(1, xiholder.Count - 1);
                    }
                    xilength2 = xilength;
                    for (int a = 0; a < MonsterNameSearchTextbox.Text.Length - xilength2; a++)
                    {
                        xiholder.Add(new List<int>());
                        for (int i = 0; i < xiholder[xilength].Count; i++)
                        {
                            if (MainForm.mobname[xiholder[xilength][i]].ToUpper().Contains(MonsterNameSearchTextbox.Text.Substring(0, xilength + 1).ToUpper()))
                            {
                                xiholder[xilength + 1].Add(xiholder[xilength][i]);
                            }
                        }
                        xilength = xilength + 1;
                    }
                    for (int i = 0; i < xiholder[xilength].Count; i++)
                    {
                        xholder.Add(xiholder[xilength][i]);
                        MonsterSearchListbox.Items.Add(MainForm.mobname[xiholder[xilength][i]]);
                    }
                }
                MonsterSearchListbox.EndUpdate();
                xisearch = MonsterNameSearchTextbox.Text;
                xiwarning = false;
            }
        }

        private void MonsterIDSearchButton_Click(object sender, EventArgs e)
        {
            MonsterSearchListbox.Items.Clear();
            xholder.Clear();
            if (MonsterSearchListbox.SelectedIndex == -1) SaveSelectedMob.Enabled = false;
            else SaveSelectedMob.Enabled = true;
            int x = MainForm.mobid.IndexOf(MonsterIDSearchTextbox.Text);
            if (x != -1)
            {
                nameskip = true;
                MonsterNameSearchTextbox.Text = "";
                nameskip = false;
                xiwarning = true;
                MonsterNameSearchTextbox.Text = MainForm.mobname[x];
                for (int y = 0; y < xholder.Count; y++)
                {
                    if (MainForm.mobid[xholder[y]] == MainForm.mobid[x])
                    {
                        MonsterSearchListbox.SelectedIndex = y;
                    }
                }
            }
            else
            {
                string message = "Invalid ID";
                string title = "Error";
                MessageBox.Show(message, title);
            }
        }

        private void MonsterSearchListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MonsterSearchListbox.SelectedIndex > -1)
            {
                IDSearch(xholder[MonsterSearchListbox.SelectedIndex]);
                MonsterIDSearchTextbox.Text = MainForm.mobid[xholder[MonsterSearchListbox.SelectedIndex]];
            }
        }

        private void IDSearch(int idlocation)
        {
            if (MonsterSearchListbox.SelectedIndex == -1) SaveSelectedMob.Enabled = false;
            else SaveSelectedMob.Enabled = true;
            Level.Text = MainForm.moblevel[idlocation];
            Health.Text = MainForm.mobhealth[idlocation];
            Defence.Text = MainForm.mobdefence[idlocation];
            XP.Text = MainForm.mobxp[idlocation];
            Aggro.Text = MainForm.mobaggrorange[idlocation];
            if (MainForm.mobpierceresist[idlocation] == "Immune")
            {
                ResistPierce.Text = "0";
                ResistPiercePercent.Text = "100";
            }
            else if (MainForm.mobpierceresist[idlocation].Contains("%"))
            {
                sub = MainForm.mobpierceresist[idlocation].Split(' ');
                ResistPierce.Text = sub[0];
                ResistPiercePercent.Text = sub[2].Substring(0, sub[2].Length - 1);
            }
            else
            {
                ResistPierce.Text = MainForm.mobpierceresist[idlocation];
                ResistPiercePercent.Text = "0";
            }
            if (MainForm.mobslashresist[idlocation] == "Immune")
            {
                ResistSlash.Text = "0";
                ResistSlashPercent.Text = "100";
            }
            else if (MainForm.mobslashresist[idlocation].Contains("%"))
            {
                sub = MainForm.mobslashresist[idlocation].Split(' ');
                ResistSlash.Text = sub[0];
                ResistSlashPercent.Text = sub[2].Substring(0, sub[2].Length - 1);
            }
            else
            {
                ResistSlash.Text = MainForm.mobslashresist[idlocation];
                ResistSlashPercent.Text = "0";
            }
            if (MainForm.mobcrushresist[idlocation] == "Immune")
            {
                ResistCrush.Text = "0";
                ResistCrushPercent.Text = "100";
            }
            else if (MainForm.mobcrushresist[idlocation].Contains("%"))
            {
                sub = MainForm.mobcrushresist[idlocation].Split(' ');
                ResistCrush.Text = sub[0];
                ResistCrushPercent.Text = sub[2].Substring(0, sub[2].Length - 1);
            }
            else
            {
                ResistCrush.Text = MainForm.mobcrushresist[idlocation];
                ResistCrushPercent.Text = "0";
            }
            if (MainForm.mobheatresist[idlocation] == "Immune")
            {
                ResistHeat.Text = "0";
                ResistHeatPercent.Text = "100";
            }
            else if (MainForm.mobheatresist[idlocation].Contains("%"))
            {
                sub = MainForm.mobheatresist[idlocation].Split(' ');
                ResistHeat.Text = sub[0];
                ResistHeatPercent.Text = sub[2].Substring(0, sub[2].Length - 1);
            }
            else
            {
                ResistHeat.Text = MainForm.mobheatresist[idlocation];
                ResistHeatPercent.Text = "0";
            }
            if (MainForm.mobcoldresist[idlocation] == "Immune")
            {
                ResistCold.Text = "0";
                ResistColdPercent.Text = "100";
            }
            else if (MainForm.mobcoldresist[idlocation].Contains("%"))
            {
                sub = MainForm.mobcoldresist[idlocation].Split(' ');
                ResistCold.Text = sub[0];
                ResistColdPercent.Text = sub[2].Substring(0, sub[2].Length - 1);
            }
            else
            {
                ResistCold.Text = MainForm.mobcoldresist[idlocation];
                ResistColdPercent.Text = "0";
            }
            if (MainForm.mobmagicresist[idlocation] == "Immune")
            {
                ResistMagic.Text = "0";
                ResistMagicPercent.Text = "100";
            }
            else if (MainForm.mobmagicresist[idlocation].Contains("%"))
            {
                sub = MainForm.mobmagicresist[idlocation].Split(' ');
                ResistMagic.Text = sub[0];
                ResistMagicPercent.Text = sub[2].Substring(0, sub[2].Length - 1);
            }
            else
            {
                ResistMagic.Text = MainForm.mobmagicresist[idlocation];
                ResistMagicPercent.Text = "0";
            }
            if (MainForm.mobpoisonresist[idlocation] == "Immune")
            {
                ResistPoison.Text = "0";
                ResistPoisonPercent.Text = "100";
            }
            else if (MainForm.mobpoisonresist[idlocation].Contains("%"))
            {
                sub = MainForm.mobpoisonresist[idlocation].Split(' ');
                ResistPoison.Text = sub[0];
                ResistPoisonPercent.Text = sub[2].Substring(0, sub[2].Length - 1);
            }
            else
            {
                ResistPoison.Text = MainForm.mobpoisonresist[idlocation];
                ResistPoisonPercent.Text = "0";
            }
            if (MainForm.mobtrueresist[idlocation] == "Immune")
            {
                ResistTrue.Text = "0";
                ResistTruePercent.Text = "100";
            }
            else if (MainForm.mobtrueresist[idlocation].Contains("%"))
            {
                sub = MainForm.mobtrueresist[idlocation].Split(' ');
                ResistTrue.Text = sub[0];
                ResistTruePercent.Text = sub[2].Substring(0, sub[2].Length - 1);
            }
            else
            {
                ResistTrue.Text = MainForm.mobtrueresist[idlocation];
                ResistTruePercent.Text = "0";
            }
            if (MainForm.mobdivineresist[idlocation] == "Immune")
            {
                ResistDivine.Text = "0";
                ResistDivinePercent.Text = "100";
            }
            else if (MainForm.mobdivineresist[idlocation].Contains("%"))
            {
                sub = MainForm.mobdivineresist[idlocation].Split(' ');
                ResistDivine.Text = sub[0];
                ResistDivinePercent.Text = sub[2].Substring(0, sub[2].Length - 1);
            }
            else
            {
                ResistDivine.Text = MainForm.mobdivineresist[idlocation];
                ResistDivinePercent.Text = "0";
            }
            if (MainForm.mobchaosresist[idlocation] == "Immune")
            {
                ResistChaos.Text = "0";
                ResistChaosPercent.Text = "100";
            }
            else if (MainForm.mobchaosresist[idlocation].Contains("%"))
            {
                sub = MainForm.mobchaosresist[idlocation].Split(' ');
                ResistChaos.Text = sub[0];
                ResistChaosPercent.Text = sub[2].Substring(0, sub[2].Length - 1);
            }
            else
            {
                ResistChaos.Text = MainForm.mobchaosresist[idlocation];
                ResistChaosPercent.Text = "0";
            }
            EvadePhysical.Text = MainForm.mobphysicalevade[idlocation];
            EvadeSpell.Text = MainForm.mobspellevade[idlocation];
            EvadeMove.Text = MainForm.mobmoveevade[idlocation];
            EvadeWound.Text = MainForm.mobwoundevade[idlocation];
            EvadeWeak.Text = MainForm.mobweakevade[idlocation];
            EvadeMental.Text = MainForm.mobmentalevade[idlocation];
        }

        private void CustomMobCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (CustomMobCheckbox.Checked == true)
            {
                MonsterSearchLabel.Enabled = false;
                MonsterNameSearchTextbox.Enabled = false;
                MonsterIDSearchTextbox.Enabled = false;
                SearchByNameLabel.Enabled = false;
                SearchByIDLabel.Enabled = false;
                MonsterSearchListbox.Enabled = false;
                MonsterNameSearchTextbox.Text = null;
                MonsterIDSearchTextbox.Text = null;
                MonsterSearchListbox.Items.Clear();
                PVPMode.Enabled = true;
                Level.Enabled = true;
                Health.Enabled = true;
                Defence.Enabled = true;
                XP.Enabled = true;
                Aggro.Enabled = true;
                ResistPierce.Enabled = true;
                ResistPiercePercent.Enabled = true;
                ResistSlash.Enabled = true;
                ResistSlashPercent.Enabled = true;
                ResistCrush.Enabled = true;
                ResistCrushPercent.Enabled = true;
                ResistPoison.Enabled = true;
                ResistPoisonPercent.Enabled = true;
                ResistTrue.Enabled = true;
                ResistTruePercent.Enabled = true;
                ResistHeat.Enabled = true;
                ResistHeatPercent.Enabled = true;
                ResistCold.Enabled = true;
                ResistColdPercent.Enabled = true;
                ResistMagic.Enabled = true;
                ResistMagicPercent.Enabled = true;
                ResistDivine.Enabled = true;
                ResistDivinePercent.Enabled = true;
                ResistChaos.Enabled = true;
                ResistChaosPercent.Enabled = true;
                EvadePhysical.Enabled = true;
                EvadeSpell.Enabled = true;
                EvadeMove.Enabled = true;
                EvadeWound.Enabled = true;
                EvadeWeak.Enabled = true;
                EvadeMental.Enabled = true;
                GeneralLabel.Enabled = true;
                EvasionsLabel.Enabled = true;
                ResistLabel.Enabled = true;
                ResistPercentLabel.Enabled = true;
                Drawing1.Enabled = true;
                Drawing2.Enabled = true;
                LevelLabel.Enabled = true;
                HealthLabel.Enabled = true;
                DefenceLabel.Enabled = true;
                XPLabel.Enabled = true;
                AggroLabel.Enabled = true;
                PierceLabel.Enabled = true;
                PiercePercentLabel.Enabled = true;
                SlashLabel.Enabled = true;
                SlashPercentLabel.Enabled = true;
                CrushLabel.Enabled = true;
                CrushPercentLabel.Enabled = true;
                PoisonLabel.Enabled = true;
                PoisonPercentLabel.Enabled = true;
                TrueLabel.Enabled = true;
                TruePercentLabel.Enabled = true;
                HeatLabel.Enabled = true;
                HeatPercentLabel.Enabled = true;
                ColdLabel.Enabled = true;
                ColdPercentLabel.Enabled = true;
                MagicLabel.Enabled = true;
                MagicPercentLabel.Enabled = true;
                DivineLabel.Enabled = true;
                DivinePercentLabel.Enabled = true;
                ChaosLabel.Enabled = true;
                ChaosPercentLabel.Enabled = true;
                PhysicalLabel.Enabled = true;
                SpellLabel.Enabled = true;
                MoveLabel.Enabled = true;
                WoundLabel.Enabled = true;
                WeakLabel.Enabled = true;
                MentalLabel.Enabled = true;
                SaveSelectedMob.Enabled = true;
            }
            else
            {
                MonsterSearchLabel.Enabled = true;
                MonsterNameSearchTextbox.Enabled = true;
                MonsterIDSearchTextbox.Enabled = true;
                SearchByNameLabel.Enabled = true;
                SearchByIDLabel.Enabled = true;
                MonsterSearchListbox.Enabled = true;
                PVPMode.Enabled = false;
                PVPMode.Checked = false;
                Level.Enabled = false;
                Health.Enabled = false;
                Defence.Enabled = false;
                XP.Enabled = false;
                Aggro.Enabled = false;
                ResistPierce.Enabled = false;
                ResistPiercePercent.Enabled = false;
                ResistSlash.Enabled = false;
                ResistSlashPercent.Enabled = false;
                ResistCrush.Enabled = false;
                ResistCrushPercent.Enabled = false;
                ResistPoison.Enabled = false;
                ResistPoisonPercent.Enabled = false;
                ResistTrue.Enabled = false;
                ResistTruePercent.Enabled = false;
                ResistHeat.Enabled = false;
                ResistHeatPercent.Enabled = false;
                ResistCold.Enabled = false;
                ResistColdPercent.Enabled = false;
                ResistMagic.Enabled = false;
                ResistMagicPercent.Enabled = false;
                ResistDivine.Enabled = false;
                ResistDivinePercent.Enabled = false;
                ResistChaos.Enabled = false;
                ResistChaosPercent.Enabled = false;
                EvadePhysical.Enabled = false;
                EvadeSpell.Enabled = false;
                EvadeMove.Enabled = false;
                EvadeWound.Enabled = false;
                EvadeWeak.Enabled = false;
                EvadeMental.Enabled = false;
                GeneralLabel.Enabled = false;
                EvasionsLabel.Enabled = false;
                ResistLabel.Enabled = false;
                ResistPercentLabel.Enabled = false;
                Drawing1.Enabled = false;
                Drawing2.Enabled = false;
                LevelLabel.Enabled = false;
                HealthLabel.Enabled = false;
                DefenceLabel.Enabled = false;
                XPLabel.Enabled = false;
                AggroLabel.Enabled = false;
                PierceLabel.Enabled = false;
                PiercePercentLabel.Enabled = false;
                SlashLabel.Enabled = false;
                SlashPercentLabel.Enabled = false;
                CrushLabel.Enabled = false;
                CrushPercentLabel.Enabled = false;
                PoisonLabel.Enabled = false;
                PoisonPercentLabel.Enabled = false;
                TrueLabel.Enabled = false;
                TruePercentLabel.Enabled = false;
                HeatLabel.Enabled = false;
                HeatPercentLabel.Enabled = false;
                ColdLabel.Enabled = false;
                ColdPercentLabel.Enabled = false;
                MagicLabel.Enabled = false;
                MagicPercentLabel.Enabled = false;
                DivineLabel.Enabled = false;
                DivinePercentLabel.Enabled = false;
                ChaosLabel.Enabled = false;
                ChaosPercentLabel.Enabled = false;
                PhysicalLabel.Enabled = false;
                SpellLabel.Enabled = false;
                MoveLabel.Enabled = false;
                WoundLabel.Enabled = false;
                WeakLabel.Enabled = false;
                MentalLabel.Enabled = false;
                SaveSelectedMob.Enabled = false;
                Level.Text = "0";
                Health.Text = "0";
                Defence.Text = "0";
                XP.Text = "0";
                Aggro.Text = "0";
                ResistPierce.Text = "0";
                ResistPiercePercent.Text = "0";
                ResistSlash.Text = "0";
                ResistSlashPercent.Text = "0";
                ResistCrush.Text = "0";
                ResistCrushPercent.Text = "0";
                ResistPoison.Text = "0";
                ResistPoisonPercent.Text = "0";
                ResistTrue.Text = "0";
                ResistTruePercent.Text = "0";
                ResistHeat.Text = "0";
                ResistHeatPercent.Text = "0";
                ResistCold.Text = "0";
                ResistColdPercent.Text = "0";
                ResistMagic.Text = "0";
                ResistMagicPercent.Text = "0";
                ResistDivine.Text = "0";
                ResistDivinePercent.Text = "0";
                ResistChaos.Text = "0";
                ResistChaosPercent.Text = "0";
                EvadePhysical.Text = "0";
                EvadeSpell.Text = "0";
                EvadeMove.Text = "0";
                EvadeWound.Text = "0";
                EvadeWeak.Text = "0";
                EvadeMental.Text = "0";
            }
        }

        private void KeyPressNumberOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Aggro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                if (!Char.Equals(e.KeyChar, '.'))
                {
                    e.Handled = true;
                }
                else
                {
                    if (Aggro.Text.Contains('.'))
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void SaveSelectedMob_Click(object sender, EventArgs e)
        {
            if (MonsterSearchListbox.SelectedIndex > -1) MainForm.solvermobid = xholder[MonsterSearchListbox.SelectedIndex]; // not actually an id, just where its located
            else MainForm.solvermobid = -2; // special value to tell it to load a custom mob if reopened
            if (PVPMode.Checked == true) MainForm.solverpvp = true;
            else MainForm.solverpvp = false;
            if (string.IsNullOrEmpty(Level.Text) == true) MainForm.solvermoblevel = 0;
            else MainForm.solvermoblevel = float.Parse(Level.Text);
            if (string.IsNullOrEmpty(Health.Text) == true) MainForm.solverhealth = 0;
            else MainForm.solverhealth = float.Parse(Health.Text);
            if (string.IsNullOrEmpty(Defence.Text) == true) MainForm.solverdefence = 0;
            else MainForm.solverdefence = float.Parse(Defence.Text);
            if (string.IsNullOrEmpty(XP.Text) == true) MainForm.solverxp = 0;
            else MainForm.solverxp = float.Parse(XP.Text);
            if (string.IsNullOrEmpty(Aggro.Text) == true) MainForm.solveraggro = 0;
            else MainForm.solveraggro = float.Parse(Aggro.Text);
            if (string.IsNullOrEmpty(ResistPierce.Text) == true) MainForm.solverpluspierceresist = 0;
            else MainForm.solverpluspierceresist = float.Parse(ResistPierce.Text);
            if (string.IsNullOrEmpty(ResistPiercePercent.Text) == true || Convert.ToInt32(ResistPiercePercent.Text) > 100) MainForm.solverpercentpierceresist = 0;
            else MainForm.solverpercentpierceresist = (Math.Abs(float.Parse(ResistPiercePercent.Text) - 100) / 100);
            if (string.IsNullOrEmpty(ResistSlash.Text) == true) MainForm.solverplusslashresist = 0;
            else MainForm.solverplusslashresist = float.Parse(ResistSlash.Text);
            if (string.IsNullOrEmpty(ResistSlashPercent.Text) == true || Convert.ToInt32(ResistSlashPercent.Text) > 100) MainForm.solverpercentslashresist = 0;
            else MainForm.solverpercentslashresist = (Math.Abs(float.Parse(ResistSlashPercent.Text) - 100) / 100);
            if (string.IsNullOrEmpty(ResistCrush.Text) == true) MainForm.solverpluscrushresist = 0;
            else MainForm.solverpluscrushresist = float.Parse(ResistCrush.Text);
            if (string.IsNullOrEmpty(ResistCrushPercent.Text) == true || Convert.ToInt32(ResistCrushPercent.Text) > 100) MainForm.solverpercentcrushresist = 0;
            else MainForm.solverpercentcrushresist = (Math.Abs(float.Parse(ResistCrushPercent.Text) - 100) / 100);
            if (string.IsNullOrEmpty(ResistPoison.Text) == true) MainForm.solverpluspoisonresist = 0;
            else MainForm.solverpluspoisonresist = float.Parse(ResistPoison.Text);
            if (string.IsNullOrEmpty(ResistPoisonPercent.Text) == true || Convert.ToInt32(ResistPoisonPercent.Text) > 100) MainForm.solverpercentpoisonresist = 0;
            else MainForm.solverpercentpoisonresist = (Math.Abs(float.Parse(ResistPoisonPercent.Text) - 100) / 100);
            if (string.IsNullOrEmpty(ResistTrue.Text) == true) MainForm.solverplustrueresist = 0;
            else MainForm.solverplustrueresist = float.Parse(ResistTrue.Text);
            if (string.IsNullOrEmpty(ResistTruePercent.Text) == true || Convert.ToInt32(ResistTruePercent.Text) > 100) MainForm.solverpercenttrueresist = 0;
            else MainForm.solverpercenttrueresist = (Math.Abs(float.Parse(ResistTruePercent.Text) - 100) / 100);
            if (string.IsNullOrEmpty(ResistHeat.Text) == true) MainForm.solverplusheatresist = 0;
            else MainForm.solverplusheatresist = float.Parse(ResistHeat.Text);
            if (string.IsNullOrEmpty(ResistHeatPercent.Text) == true || Convert.ToInt32(ResistHeatPercent.Text) > 100) MainForm.solverpercentheatresist = 0;
            else MainForm.solverpercentheatresist = (Math.Abs(float.Parse(ResistHeatPercent.Text) - 100) / 100);
            if (string.IsNullOrEmpty(ResistCold.Text) == true) MainForm.solverpluscoldresist = 0;
            else MainForm.solverpluscoldresist = float.Parse(ResistCold.Text);
            if (string.IsNullOrEmpty(ResistColdPercent.Text) == true || Convert.ToInt32(ResistColdPercent.Text) > 100) MainForm.solverpercentcoldresist = 0;
            else MainForm.solverpercentcoldresist = (Math.Abs(float.Parse(ResistColdPercent.Text) - 100) / 100);
            if (string.IsNullOrEmpty(ResistMagic.Text) == true) MainForm.solverplusmagicresist = 0;
            else MainForm.solverplusmagicresist = float.Parse(ResistMagic.Text);
            if (string.IsNullOrEmpty(ResistMagicPercent.Text) == true || Convert.ToInt32(ResistMagicPercent.Text) > 100) MainForm.solverpercentmagicresist = 0;
            else MainForm.solverpercentmagicresist = (Math.Abs(float.Parse(ResistMagicPercent.Text) - 100) / 100);
            if (string.IsNullOrEmpty(ResistDivine.Text) == true) MainForm.solverplusdivineresist = 0;
            else MainForm.solverplusdivineresist = float.Parse(ResistDivine.Text);
            if (string.IsNullOrEmpty(ResistDivinePercent.Text) == true || Convert.ToInt32(ResistDivinePercent.Text) > 100) MainForm.solverpercentdivineresist = 0;
            else MainForm.solverpercentdivineresist = (Math.Abs(float.Parse(ResistDivinePercent.Text) - 100) / 100);
            if (string.IsNullOrEmpty(ResistChaos.Text) == true) MainForm.solverpluschaosresist = 0;
            else MainForm.solverpluschaosresist = float.Parse(ResistChaos.Text);
            if (string.IsNullOrEmpty(ResistChaosPercent.Text) == true || Convert.ToInt32(ResistChaosPercent.Text) > 100) MainForm.solverpercentchaosresist = 0;
            else MainForm.solverpercentchaosresist = (Math.Abs(float.Parse(ResistChaosPercent.Text) - 100) / 100);
            if (string.IsNullOrEmpty(EvadePhysical.Text) == true) MainForm.solverphysical = 0;
            else MainForm.solverphysical = float.Parse(EvadePhysical.Text);
            if (string.IsNullOrEmpty(EvadeSpell.Text) == true) MainForm.solverspell = 0;
            else MainForm.solverspell = float.Parse(EvadeSpell.Text);
            if (string.IsNullOrEmpty(EvadeMove.Text) == true) MainForm.solvermovement = 0;
            else MainForm.solvermovement = float.Parse(EvadeMove.Text);
            if (string.IsNullOrEmpty(EvadeWound.Text) == true) MainForm.solverwounding = 0;
            else MainForm.solverwounding = float.Parse(EvadeWound.Text);
            if (string.IsNullOrEmpty(EvadeWeak.Text) == true) MainForm.solverweakening = 0;
            else MainForm.solverweakening = float.Parse(EvadeWeak.Text);
            if (string.IsNullOrEmpty(EvadeMental.Text) == true) MainForm.solvermental = 0;
            else MainForm.solvermental = float.Parse(EvadeMental.Text);
            MainForm.mobdone = true;
            this.Close();
        }
    }
}
