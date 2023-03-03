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
    public partial class StatusExtraData : Form
    {
        int auraindex = MainForm.auracarry;
        int effectindex = MainForm.effectcarry;
        string abilityindex = MainForm.abilitycarry;
        string effecttype = "0";
        string[] commasplit;
        string[] commasplit2;
        string formula;

        public StatusExtraData()
        {
            InitializeComponent();

            if (auraindex != -1)
            {
                switch (MainForm.auratarget[auraindex])
                {
                    case "0":
                        AuraTarget.Text = "Aura Target: None";
                        break;
                    case "1":
                        AuraTarget.Text = "Aura Target: Mob";
                        break;
                    case "2":
                        AuraTarget.Text = "Aura Target: Player";
                        break;
                    case "4":
                        AuraTarget.Text = "Aura Target: Enemy";
                        break;
                    case "8":
                        AuraTarget.Text = "Aura Target: Not Enemy";
                        break;
                }
                AuraRange.Text = "Aura Range: " + MainForm.aurarange[auraindex];
            }
            else
            {
                AuraInfo.Enabled = false;
                AuraTarget.Enabled = false;
                AuraRange.Enabled = false;
                Drawing1.Enabled = false;
            }
            if (effectindex != -1)
            {
                CharacterEffectName.Text = "Character Effect Name: " + MainForm.effectname[effectindex];
                effecttype = MainForm.effecttype[effectindex];
                switch (effecttype)
                {
                    case "2":
                    case "3":
                        if (abilityindex != "None")
                        {
                            CharacterEffectListbox.Items.Add("Formula: Value * (Value * (" + abilityindex + "/2000))");
                            CharacterEffectListbox.Items.Add("(Only applies to values with (Uses Formula))");
                        }
                        break;
                }
                if ((effecttype == "2" || effecttype == "3") && abilityindex != "None")
                {
                    formula = " (Uses Formula)";
                }
                else formula = "";
                if (!string.IsNullOrEmpty(MainForm.effectdamage[effectindex]))
                {
                    commasplit = MainForm.effectdamage[effectindex].Split(';');
                    for (int i = 0; i < commasplit.Length; i++)
                    {
                        commasplit2 = commasplit[i].Split('^');
                        switch (commasplit2[0])
                        {
                            case "0":
                                CharacterEffectListbox.Items.Add("Piercing Damage: " + commasplit2[1] + formula);
                                break;
                            case "1":
                                CharacterEffectListbox.Items.Add("Slashing Damage: " + commasplit2[1] + formula);
                                break;
                            case "2":
                                CharacterEffectListbox.Items.Add("Crushing Damage: " + commasplit2[1] + formula);
                                break;
                            case "3":
                                CharacterEffectListbox.Items.Add("Heat Damage: " + commasplit2[1] + formula);
                                break;
                            case "4":
                                CharacterEffectListbox.Items.Add("Cold Damage: " + commasplit2[1] + formula);
                                break;
                            case "5":
                                CharacterEffectListbox.Items.Add("Magic Damage: " + commasplit2[1] + formula);
                                break;
                            case "6":
                                CharacterEffectListbox.Items.Add("Poison Damage: " + commasplit2[1] + formula);
                                break;
                            case "7":
                                CharacterEffectListbox.Items.Add("Divine Damage: " + commasplit2[1] + formula);
                                break;
                            case "8":
                                CharacterEffectListbox.Items.Add("Chaos Damage: " + commasplit2[1] + formula);
                                break;
                            case "9":
                                CharacterEffectListbox.Items.Add("True Damage: " + commasplit2[1] + formula);
                                break;
                            case "15":
                                CharacterEffectListbox.Items.Add("Fishing Power: " + commasplit2[1] + formula);
                                break;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(MainForm.effectstat[effectindex]))
                {
                    commasplit = MainForm.effectstat[effectindex].Split(';');
                    for (int i = 0; i < commasplit.Length; i++)
                    {
                        commasplit2 = commasplit[i].Split('^');
                        switch (commasplit2[0])
                        {
                            case "0":
                                CharacterEffectListbox.Items.Add("Strength: " + commasplit2[1]);
                                break;
                            case "1":
                                CharacterEffectListbox.Items.Add("Dexterity: " + commasplit2[1]);
                                break;
                            case "2":
                                CharacterEffectListbox.Items.Add("Focus: " + commasplit2[1]);
                                break;
                            case "3":
                                CharacterEffectListbox.Items.Add("Vitality: " + commasplit2[1]);
                                break;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(MainForm.effectskill[effectindex]))
                {
                    commasplit = MainForm.effectskill[effectindex].Split(';');
                    for (int i = 0; i < commasplit.Length; i++)
                    {
                        commasplit2 = commasplit[i].Split('^');
                        CharacterEffectListbox.Items.Add(MainForm.skillname[MainForm.skillid.IndexOf(commasplit2[0])] + " skill level: " + commasplit2[1]);
                    }
                }
                if (!string.IsNullOrEmpty(MainForm.effectability[effectindex]))
                {
                    commasplit = MainForm.effectability[effectindex].Split(';');
                    for (int i = 0; i < commasplit.Length; i++)
                    {
                        commasplit2 = commasplit[i].Split('^');
                        CharacterEffectListbox.Items.Add(GetAbility(commasplit2[0]) + ": " + commasplit2[1]);
                    }
                }
                if (!string.IsNullOrEmpty(MainForm.effectarmor[effectindex]))
                {
                    if (MainForm.effectarmor[effectindex] != "0")
                    {
                        CharacterEffectListbox.Items.Add("Armour: " + MainForm.effectarmor[effectindex]);
                    }
                }
                if (!string.IsNullOrEmpty(MainForm.effectbonus[effectindex]))
                {
                    commasplit = MainForm.effectbonus[effectindex].Split(';');
                    for (int i = 0; i < commasplit.Length; i++)
                    {
                        commasplit2 = commasplit[i].Split('^');
                        switch (commasplit2[0])
                        {
                            case "0":
                                CharacterEffectListbox.Items.Add("Resist Pierce: " + commasplit2[1] + formula);
                                break;
                            case "1":
                                CharacterEffectListbox.Items.Add("Resist Slash: " + commasplit2[1] + formula);
                                break;
                            case "2":
                                CharacterEffectListbox.Items.Add("Resist Crush: " + commasplit2[1] + formula);
                                break;
                            case "3":
                                CharacterEffectListbox.Items.Add("Resist Heat: " + commasplit2[1] + formula);
                                break;
                            case "4":
                                CharacterEffectListbox.Items.Add("Resist Cold: " + commasplit2[1] + formula);
                                break;
                            case "5":
                                CharacterEffectListbox.Items.Add("Resist Magic: " + commasplit2[1] + formula);
                                break;
                            case "6":
                                CharacterEffectListbox.Items.Add("Resist Poison: " + commasplit2[1] + formula);
                                break;
                            case "7":
                                CharacterEffectListbox.Items.Add("Resist Divine: " + commasplit2[1] + formula);
                                break;
                            case "8":
                                CharacterEffectListbox.Items.Add("Resist Chaos: " + commasplit2[1] + formula);
                                break;
                            case "9":
                                CharacterEffectListbox.Items.Add("Resist True: " + commasplit2[1] + formula);
                                break;
                            case "10":
                                CharacterEffectListbox.Items.Add("Attack: " + commasplit2[1] + formula);
                                break;
                            case "11":
                                CharacterEffectListbox.Items.Add("Defence: " + commasplit2[1] + formula);
                                break;
                            case "12":
                                CharacterEffectListbox.Items.Add("Health: " + commasplit2[1] + formula);
                                break;
                            case "13":
                                CharacterEffectListbox.Items.Add("Energy: " + commasplit2[1] + formula);
                                break;
                            case "15":
                                CharacterEffectListbox.Items.Add("Resist Fishing: " + commasplit2[1] + formula);
                                break;
                            case "16":
                                CharacterEffectListbox.Items.Add("Concentration: " + commasplit2[1] + formula);
                                break;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(MainForm.effectreduction[effectindex]))
                {
                    commasplit = MainForm.effectreduction[effectindex].Split(';');
                    for (int x = 0; x < commasplit.Length; x++)
                    {
                        commasplit2 = commasplit[x].Split('^');
                        switch (commasplit2[0])
                        {
                            case "0":
                                CharacterEffectListbox.Items.Add("Pierce Damage Reduction: " + float.Parse(commasplit2[1]) * 100 + "%" + formula);
                                break;
                            case "1":
                                CharacterEffectListbox.Items.Add("Slash Damage Reduction: " + float.Parse(commasplit2[1]) * 100 + "%" + formula);
                                break;
                            case "2":
                                CharacterEffectListbox.Items.Add("Crush Damage Reduction: " + float.Parse(commasplit2[1]) * 100 + "%" + formula);
                                break;
                            case "3":
                                CharacterEffectListbox.Items.Add("Heat Damage Reduction: " + float.Parse(commasplit2[1]) * 100 + "%" + formula);
                                break;
                            case "4":
                                CharacterEffectListbox.Items.Add("Cold Damage Reduction: " + float.Parse(commasplit2[1]) * 100 + "%" + formula);
                                break;
                            case "5":
                                CharacterEffectListbox.Items.Add("Magic Damage Reduction: " + float.Parse(commasplit2[1]) * 100 + "%" + formula);
                                break;
                            case "6":
                                CharacterEffectListbox.Items.Add("Poison Damage Reduction: " + float.Parse(commasplit2[1]) * 100 + "%" + formula);
                                break;
                            case "7":
                                CharacterEffectListbox.Items.Add("Divine Damage Reduction: " + float.Parse(commasplit2[1]) * 100 + "%" + formula);
                                break;
                            case "8":
                                CharacterEffectListbox.Items.Add("Chaos Damage Reduction: " + float.Parse(commasplit2[1]) * 100 + "%" + formula);
                                break;
                            case "9":
                                CharacterEffectListbox.Items.Add("True Damage Reduction: " + float.Parse(commasplit2[1]) * 100 + "%" + formula);
                                break;
                            case "15":
                                CharacterEffectListbox.Items.Add("Fishing Damage Reduction: " + float.Parse(commasplit2[1]) * 100 + "%" + formula);
                                break;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(MainForm.effectimmune[effectindex]))
                {
                    commasplit = MainForm.effectimmune[effectindex].Split(';');
                    for (int x = 0; x < commasplit.Length; x++)
                    {
                        commasplit2 = commasplit[x].Split('^');
                        switch (commasplit2[0])
                        {
                            case "0":
                                CharacterEffectListbox.Items.Add("Pierce Immunity Chance: " + float.Parse(commasplit2[1]) * 100 + "%" + formula);
                                break;
                            case "1":
                                CharacterEffectListbox.Items.Add("Slash Immunity Chance: " + float.Parse(commasplit2[1]) * 100 + "%" + formula);
                                break;
                            case "2":
                                CharacterEffectListbox.Items.Add("Crush Immunity Chance: " + float.Parse(commasplit2[1]) * 100 + "%" + formula);
                                break;
                            case "3":
                                CharacterEffectListbox.Items.Add("Heat Immunity Chance: " + float.Parse(commasplit2[1]) * 100 + "%" + formula);
                                break;
                            case "4":
                                CharacterEffectListbox.Items.Add("Cold Immunity Chance: " + float.Parse(commasplit2[1]) * 100 + "%" + formula);
                                break;
                            case "5":
                                CharacterEffectListbox.Items.Add("Magic Immunity Chance: " + float.Parse(commasplit2[1]) * 100 + "%" + formula);
                                break;
                            case "6":
                                CharacterEffectListbox.Items.Add("Poison Immunity Chance: " + float.Parse(commasplit2[1]) * 100 + "%" + formula);
                                break;
                            case "7":
                                CharacterEffectListbox.Items.Add("Divine Immunity Chance: " + float.Parse(commasplit2[1]) * 100 + "%" + formula);
                                break;
                            case "8":
                                CharacterEffectListbox.Items.Add("Chaos Immunity Chance: " + float.Parse(commasplit2[1]) * 100 + "%" + formula);
                                break;
                            case "9":
                                CharacterEffectListbox.Items.Add("True Immunity Chance: " + float.Parse(commasplit2[1]) * 100 + "%" + formula);
                                break;
                            case "15":
                                CharacterEffectListbox.Items.Add("Fishing Immunity Chance: " + float.Parse(commasplit2[1]) * 100 + "%" + formula);
                                break;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(MainForm.effectevasion[effectindex]))
                {
                    commasplit = MainForm.effectevasion[effectindex].Split(';');
                    for (int i = 0; i < commasplit.Length; i++)
                    {
                        commasplit2 = commasplit[i].Split('^');
                        switch (commasplit2[0])
                        {
                            case "0":
                                CharacterEffectListbox.Items.Add("Physical Attack Evasion: " + commasplit2[1] + formula);
                                break;
                            case "1":
                                CharacterEffectListbox.Items.Add("Spell Attack Evasion: " + commasplit2[1] + formula);
                                break;
                            case "2":
                                CharacterEffectListbox.Items.Add("Movement Attack Evasion: " + commasplit2[1] + formula);
                                break;
                            case "3":
                                CharacterEffectListbox.Items.Add("Wounding Attack Evasion: " + commasplit2[1] + formula);
                                break;
                            case "4":
                                CharacterEffectListbox.Items.Add("Weakening Attack Evasion: " + commasplit2[1] + formula);
                                break;
                            case "5":
                                CharacterEffectListbox.Items.Add("Mental Attack Evasion: " + commasplit2[1] + formula);
                                break;
                        }
                    }
                }
            }
            else
            {
                CharacterEffectInfo.Enabled = false;
                CharacterEffectName.Enabled = false;
                CharacterEffectListbox.Enabled = false;
            }
        }

        private string GetAbility(string idindex)
        {
            switch (idindex)
            {
                case "-1":
                    return "None";
                case "0":
                    return "Sword";
                case "1":
                    return "Blunt";
                case "2":
                    return "Axe";
                case "3":
                    return "Staff";
                case "4":
                    return "Dagger";
                case "5":
                    return "Wand";
                case "6":
                    return "Bow";
                case "7":
                    return "Melee Combat";
                case "8":
                    return "Ranged Combat";
                case "9":
                    return "Physical Fitness";
                case "10":
                    return "Nature Magic";
                case "11":
                    return "Cunning";
                case "12":
                    return "Ice Magic";
                case "13":
                    return "Fire Magic";
                case "14":
                    return "First Aid";
                case "15":
                    return "Spear";
                case "16":
                    return "Totem";
                case "17":
                    return "Novelty";
                case "18":
                    return "Hand to Hand";
                case "19":
                    return "Fortitude";
                case "20":
                    return "Warding";
                case "21":
                    return "Reflex";
                case "22":
                    return "Vigour";
                case "23":
                    return "Willpower";
                case "24":
                    return "Dog Taming";
                case "25":
                    return "Rabbit Taming";
                case "26":
                    return "Fishing";
                case "27":
                    return "Bear Taming";
                case "28":
                    return "Spirit Taming";
                case "29":
                    return "Critical Strike";
                case "30":
                    return "Critical Skills";
                case "31":
                    return "Treasure Hunter";
                case "32":
                    return "Scholar";
                case "33":
                    return "Wolf Taming";
                case "34":
                    return "Spider Taming";
                case "35":
                    return "Boar Taming";
                case "36":
                    return "Wolf Riding";
                case "37":
                    return "Bear Riding";
                case "38":
                    return "Cooking Proficiency";
                case "39":
                    return "Cooking Mastery";
                case "40":
                    return "Dragon Taming";
                case "41":
                    return "Chicken Taming";
                case "42":
                    return "Horse Riding";
                case "43":
                    return "Elk Riding";
                case "44":
                    return "Eagle Taming";
                case "45":
                    return "Phoenix Taming";
                case "46":
                    return "Tiger Riding";
                case "47":
                    return "Pig Taming";
                case "48":
                    return "Seedling Taming";
                case "49":
                    return "Hellsteed Riding";
                case "50":
                    return "Reindeer Taming";
                case "51":
                    return "Imp Taming";
                default:
                    return "Error";
            }
        }
    }
}
