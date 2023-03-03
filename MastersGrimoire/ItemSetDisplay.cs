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
    public partial class ItemSetDisplay : Form
    {
        List<string> setbonus = MainForm.setbonuses; // save the variable so we can keep this an independent window without conflicts
        List<string> setslots = new List<string>(); // saves what slots are present for the set to organize them, rings only, etc

        public ItemSetDisplay()
        {
            InitializeComponent();
            for (int i = 0; i < setbonus.Count; i++)
            {
                SetBonusSelected.Items.Add(MainForm.itemname[MainForm.itemid.IndexOf(MainForm.itemsetrewarditemid[MainForm.itemsetrewardid.IndexOf(setbonus[i])])]);
            }
            SetBonusSelected.SelectedIndex = 0;
            SetEquipSort.SelectedIndex = 0;
        }

        private void LoadSets()
        {
            SetItemParts.Items.Clear();
            SetItemReward.Items.Clear();
            SetEquipSort.Items.Clear();
            setslots.Clear();
            string setbonusselected = setbonus[SetBonusSelected.SelectedIndex];
            int setbonusitem = MainForm.itemid.IndexOf(MainForm.itemsetrewarditemid[MainForm.itemsetrewardid.IndexOf(setbonus[SetBonusSelected.SelectedIndex])]);
            SetBonusReward.Text = "Set Bonus Reward: " + MainForm.itemname[setbonusitem];
            SetBonusAmount.Text = "Items Below Required To Activate Set Bonus: " + MainForm.itemsetrewardamount[MainForm.itemsetrewardid.IndexOf(setbonusselected)];
            string[] commasplit;
            string[] commasplit2;

            setslots.Add("-3"); // unused by any slot, just to fill up space for Any
            SetEquipSort.Items.Add("Any");
            for (int i = 0; i < MainForm.itemsetid.Count; i++)
            {
                if (MainForm.itemsetid[i] == setbonusselected)
                {
                    if (setslots.Contains(MainForm.itemequipslot[MainForm.itemid.IndexOf(MainForm.itemsetitemid[i])]) == false)
                    {
                        setslots.Add(MainForm.itemequipslot[MainForm.itemid.IndexOf(MainForm.itemsetitemid[i])]);
                    }
                }
            }
            for (int i = 1; i < setslots.Count; i++) // skip our manual Any addition
            {
                SetEquipSort.Items.Add(GetEquipmentSlot(setslots[i]));
            }
            SetEquipSort.SelectedIndex = 0;
            if (!string.IsNullOrEmpty(MainForm.itemdamagelist[setbonusitem]))
            {
                commasplit = MainForm.itemdamagelist[setbonusitem].Split(';');
                for (int i = 0; i < commasplit.Length; i++)
                {
                    commasplit2 = commasplit[i].Split('^');
                    switch (commasplit2[0])
                    {
                        case "0":
                            SetItemReward.Items.Add("Piercing Damage: " + commasplit2[1]);
                            break;
                        case "1":
                            SetItemReward.Items.Add("Slashing Damage: " + commasplit2[1]);
                            break;
                        case "2":
                            SetItemReward.Items.Add("Crushing Damage: " + commasplit2[1]);
                            break;
                        case "3":
                            SetItemReward.Items.Add("Heat Damage: " + commasplit2[1]);
                            break;
                        case "4":
                            SetItemReward.Items.Add("Cold Damage: " + commasplit2[1]);
                            break;
                        case "5":
                            SetItemReward.Items.Add("Magic Damage: " + commasplit2[1]);
                            break;
                        case "6":
                            SetItemReward.Items.Add("Poison Damage: " + commasplit2[1]);
                            break;
                        case "7":
                            SetItemReward.Items.Add("Divine Damage: " + commasplit2[1]);
                            break;
                        case "8":
                            SetItemReward.Items.Add("Chaos Damage: " + commasplit2[1]);
                            break;
                        case "9":
                            SetItemReward.Items.Add("True Damage: " + commasplit2[1]);
                            break;
                        case "15":
                            SetItemReward.Items.Add("Fishing Power: " + commasplit2[1]);
                            break;
                    }
                }
            }
            if (!string.IsNullOrEmpty(MainForm.itemboosts[setbonusitem]))
            {
                commasplit = MainForm.itemboosts[setbonusitem].Split(';');
                for (int i = 0; i < commasplit.Length; i++)
                {
                    commasplit2 = commasplit[i].Split('^');
                    switch (commasplit2[1]) // 0 = direct boost, 1 = percent reduction
                    {
                        case "0":
                            if (float.Parse(commasplit2[2]) >= 0)
                            {
                                if (commasplit2[0] == "156")
                                {
                                    SetItemReward.Items.Add(MainForm.skillname[MainForm.skillid.IndexOf(commasplit2[0])] + " Energy: +" + commasplit2[2]); // energy harvest
                                }
                                else if (commasplit2[0] == "33" || commasplit2[0] == "128") // taunt and warcry
                                {
                                    SetItemReward.Items.Add(MainForm.skillname[MainForm.skillid.IndexOf(commasplit2[0])] + " Aggro: +" + commasplit2[2]);
                                }
                                else if (commasplit2[0] == "197") // rescue
                                {
                                    SetItemReward.Items.Add(MainForm.skillname[MainForm.skillid.IndexOf(commasplit2[0])] + " Boost(?): +" + commasplit2[2]); // might be broken
                                }
                                else SetItemReward.Items.Add(MainForm.skillname[MainForm.skillid.IndexOf(commasplit2[0])] + " Damage: +" + commasplit2[2]);
                            }
                            else
                            {
                                if (commasplit2[0] == "145")
                                {
                                    SetItemReward.Items.Add(MainForm.skillname[MainForm.skillid.IndexOf(commasplit2[0])] + " Energy: +" + commasplit2[2].Substring(1, commasplit2[2].Length - 1)); // sacrifice
                                }
                                else if (commasplit2[0] == "32" || commasplit2[0] == "34") // calm and distract
                                {
                                    SetItemReward.Items.Add(MainForm.skillname[MainForm.skillid.IndexOf(commasplit2[0])] + " Aggro Drop: +" + commasplit2[2].Substring(1, commasplit2[2].Length - 1));
                                }
                                else SetItemReward.Items.Add(MainForm.skillname[MainForm.skillid.IndexOf(commasplit2[0])] + " Heal: +" + commasplit2[2].Substring(1, commasplit2[2].Length - 1));
                            }
                            break;
                        case "1":
                            SetItemReward.Items.Add(MainForm.skillname[MainForm.skillid.IndexOf(commasplit2[0])] + " Cooldown: -" + commasplit2[2] + "%");
                            break;
                    }
                }
            }
            if (!string.IsNullOrEmpty(MainForm.itemstatbonus[setbonusitem]))
            {
                commasplit = MainForm.itemstatbonus[setbonusitem].Split(';');
                for (int i = 0; i < commasplit.Length; i++)
                {
                    commasplit2 = commasplit[i].Split('^');
                    switch (commasplit2[0])
                    {
                        case "0":
                            SetItemReward.Items.Add("Strength: " + commasplit2[1]);
                            break;
                        case "1":
                            SetItemReward.Items.Add("Dexterity: " + commasplit2[1]);
                            break;
                        case "2":
                            SetItemReward.Items.Add("Focus: " + commasplit2[1]);
                            break;
                        case "3":
                            SetItemReward.Items.Add("Vitality: " + commasplit2[1]);
                            break;
                    }
                }
            }
            if (!string.IsNullOrEmpty(MainForm.itemskillbonus[setbonusitem]))
            {
                commasplit = MainForm.itemskillbonus[setbonusitem].Split(';');
                for (int i = 0; i < commasplit.Length; i++)
                {
                    commasplit2 = commasplit[i].Split('^');
                    SetItemReward.Items.Add(MainForm.skillname[MainForm.skillid.IndexOf(commasplit2[0])] + " skill level: " + commasplit2[1]);
                }
            }
            if (MainForm.itemequipskillid[setbonusitem] != "0")
            {
                SetItemReward.Items.Add("Gives Skill: " + MainForm.skillname[MainForm.skillid.IndexOf(MainForm.itemequipskillid[setbonusitem])] + "(Level " + (Convert.ToInt32(MainForm.itemequipskilllevel[setbonusitem]) + 1) + ")");
            }
            if (!string.IsNullOrEmpty(MainForm.itemstatuses[setbonusitem]))
            {
                commasplit = MainForm.itemstatuses[setbonusitem].Split(';');
                for (int i = 0; i < commasplit.Length; i++)
                {
                    commasplit2 = commasplit[i].Split('^');
                    SetItemReward.Items.Add("Gives Status: " + MainForm.statusname[MainForm.statusid.IndexOf(commasplit2[0])] + "(Level " + (Convert.ToInt32(commasplit2[1]) + 1) + ")");
                }
            }
            if (!string.IsNullOrEmpty(MainForm.itemabilitybonus[setbonusitem]))
            {
                commasplit = MainForm.itemabilitybonus[setbonusitem].Split(';');
                for (int i = 0; i < commasplit.Length; i++)
                {
                    commasplit2 = commasplit[i].Split('^');
                    SetItemReward.Items.Add(GetAbility(commasplit2[0]) + ": " + commasplit2[1]);
                }
            }
            if (MainForm.itemarmor[setbonusitem] != "0")
            {
                SetItemReward.Items.Add("Armour: " + MainForm.itemarmor[setbonusitem]);
            }
            if (!string.IsNullOrEmpty(MainForm.itembonuslist[setbonusitem]))
            {
                commasplit = MainForm.itembonuslist[setbonusitem].Split(';');
                for (int i = 0; i < commasplit.Length; i++)
                {
                    commasplit2 = commasplit[i].Split('^');
                    switch (commasplit2[0])
                    {
                        case "0":
                            SetItemReward.Items.Add("Resist Pierce: " + commasplit2[1]);
                            break;
                        case "1":
                            SetItemReward.Items.Add("Resist Slash: " + commasplit2[1]);
                            break;
                        case "2":
                            SetItemReward.Items.Add("Resist Crush: " + commasplit2[1]);
                            break;
                        case "3":
                            SetItemReward.Items.Add("Resist Heat: " + commasplit2[1]);
                            break;
                        case "4":
                            SetItemReward.Items.Add("Resist Cold: " + commasplit2[1]);
                            break;
                        case "5":
                            SetItemReward.Items.Add("Resist Magic: " + commasplit2[1]);
                            break;
                        case "6":
                            SetItemReward.Items.Add("Resist Poison: " + commasplit2[1]);
                            break;
                        case "7":
                            SetItemReward.Items.Add("Resist Divine: " + commasplit2[1]);
                            break;
                        case "8":
                            SetItemReward.Items.Add("Resist Chaos: " + commasplit2[1]);
                            break;
                        case "9":
                            SetItemReward.Items.Add("Resist True: " + commasplit2[1]);
                            break;
                        case "10":
                            SetItemReward.Items.Add("Attack: " + commasplit2[1]);
                            break;
                        case "11":
                            SetItemReward.Items.Add("Defence: " + commasplit2[1]);
                            break;
                        case "12":
                            SetItemReward.Items.Add("Health: " + commasplit2[1]);
                            break;
                        case "13":
                            SetItemReward.Items.Add("Energy: " + commasplit2[1]);
                            break;
                        case "15":
                            SetItemReward.Items.Add("Resist Fishing: " + commasplit2[1]);
                            break;
                        case "16":
                            SetItemReward.Items.Add("Concentration: " + commasplit2[1]);
                            break;
                    }
                }
            }
            for (int i = 0; i < MainForm.itemidresistance.Count; i++)
            {
                if (MainForm.itemid[setbonusitem] == MainForm.itemidresistance[i])
                {
                    if (!string.IsNullOrEmpty(MainForm.itemresistancevalues[i]))
                    {
                        commasplit = MainForm.itemresistancevalues[i].Split(';');
                        for (int x = 0; x < commasplit.Length; x++)
                        {
                            commasplit2 = commasplit[x].Split('^');
                            switch (commasplit2[0])
                            {
                                case "0":
                                    SetItemReward.Items.Add("Pierce Damage Reduction: " + float.Parse(commasplit2[1]) * 100 + "%");
                                    break;
                                case "1":
                                    SetItemReward.Items.Add("Slash Damage Reduction: " + float.Parse(commasplit2[1]) * 100 + "%");
                                    break;
                                case "2":
                                    SetItemReward.Items.Add("Crush Damage Reduction: " + float.Parse(commasplit2[1]) * 100 + "%");
                                    break;
                                case "3":
                                    SetItemReward.Items.Add("Heat Damage Reduction: " + float.Parse(commasplit2[1]) * 100 + "%");
                                    break;
                                case "4":
                                    SetItemReward.Items.Add("Cold Damage Reduction: " + float.Parse(commasplit2[1]) * 100 + "%");
                                    break;
                                case "5":
                                    SetItemReward.Items.Add("Magic Damage Reduction: " + float.Parse(commasplit2[1]) * 100 + "%");
                                    break;
                                case "6":
                                    SetItemReward.Items.Add("Poison Damage Reduction: " + float.Parse(commasplit2[1]) * 100 + "%");
                                    break;
                                case "7":
                                    SetItemReward.Items.Add("Divine Damage Reduction: " + float.Parse(commasplit2[1]) * 100 + "%");
                                    break;
                                case "8":
                                    SetItemReward.Items.Add("Chaos Damage Reduction: " + float.Parse(commasplit2[1]) * 100 + "%");
                                    break;
                                case "9":
                                    SetItemReward.Items.Add("True Damage Reduction: " + float.Parse(commasplit2[1]) * 100 + "%");
                                    break;
                                case "15":
                                    SetItemReward.Items.Add("Fishing Damage Reduction: " + float.Parse(commasplit2[1]) * 100 + "%");
                                    break;
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < MainForm.itemidimmunity.Count; i++)
            {
                if (MainForm.itemid[setbonusitem] == MainForm.itemidimmunity[i])
                {
                    if (!string.IsNullOrEmpty(MainForm.itemimmunityvalues[i]))
                    {
                        commasplit = MainForm.itemimmunityvalues[i].Split(';');
                        for (int x = 0; x < commasplit.Length; x++)
                        {
                            commasplit2 = commasplit[x].Split('^');
                            switch (commasplit2[0])
                            {
                                case "0":
                                    SetItemReward.Items.Add("Pierce Immunity Chance: " + float.Parse(commasplit2[1]) * 100 + "%");
                                    break;
                                case "1":
                                    SetItemReward.Items.Add("Slash Immunity Chance: " + float.Parse(commasplit2[1]) * 100 + "%");
                                    break;
                                case "2":
                                    SetItemReward.Items.Add("Crush Immunity Chance: " + float.Parse(commasplit2[1]) * 100 + "%");
                                    break;
                                case "3":
                                    SetItemReward.Items.Add("Heat Immunity Chance: " + float.Parse(commasplit2[1]) * 100 + "%");
                                    break;
                                case "4":
                                    SetItemReward.Items.Add("Cold Immunity Chance: " + float.Parse(commasplit2[1]) * 100 + "%");
                                    break;
                                case "5":
                                    SetItemReward.Items.Add("Magic Immunity Chance: " + float.Parse(commasplit2[1]) * 100 + "%");
                                    break;
                                case "6":
                                    SetItemReward.Items.Add("Poison Immunity Chance: " + float.Parse(commasplit2[1]) * 100 + "%");
                                    break;
                                case "7":
                                    SetItemReward.Items.Add("Divine Immunity Chance: " + float.Parse(commasplit2[1]) * 100 + "%");
                                    break;
                                case "8":
                                    SetItemReward.Items.Add("Chaos Immunity Chance: " + float.Parse(commasplit2[1]) * 100 + "%");
                                    break;
                                case "9":
                                    SetItemReward.Items.Add("True Immunity Chance: " + float.Parse(commasplit2[1]) * 100 + "%");
                                    break;
                                case "15":
                                    SetItemReward.Items.Add("Fishing Immunity Chance: " + float.Parse(commasplit2[1]) * 100 + "%");
                                    break;
                            }
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(MainForm.itemevasionlist[setbonusitem]))
            {
                commasplit = MainForm.itemevasionlist[setbonusitem].Split(';');
                for (int i = 0; i < commasplit.Length; i++)
                {
                    commasplit2 = commasplit[i].Split('^');
                    switch (commasplit2[0])
                    {
                        case "0":
                            SetItemReward.Items.Add("Physical Attack Evasion: " + commasplit2[1]);
                            break;
                        case "1":
                            SetItemReward.Items.Add("Spell Attack Evasion: " + commasplit2[1]);
                            break;
                        case "2":
                            SetItemReward.Items.Add("Movement Attack Evasion: " + commasplit2[1]);
                            break;
                        case "3":
                            SetItemReward.Items.Add("Wounding Attack Evasion: " + commasplit2[1]);
                            break;
                        case "4":
                            SetItemReward.Items.Add("Weakening Attack Evasion: " + commasplit2[1]);
                            break;
                        case "5":
                            SetItemReward.Items.Add("Mental Attack Evasion: " + commasplit2[1]);
                            break;
                    }
                }
            }
        }

        private void ReloadSets()
        {
            SetItemParts.Items.Clear();
            string setbonusselected = setbonus[SetBonusSelected.SelectedIndex];

            for (int i = 0; i < MainForm.itemsetid.Count; i++)
            {
                if (MainForm.itemsetid[i] == setbonusselected && (MainForm.itemequipslot[MainForm.itemid.IndexOf(MainForm.itemsetitemid[i])] == setslots[SetEquipSort.SelectedIndex] || SetEquipSort.SelectedIndex == 0))
                {
                    SetItemParts.Items.Add(MainForm.itemname[MainForm.itemid.IndexOf(MainForm.itemsetitemid[i])] + "[" + MainForm.itemsetitemid[i] + "]");
                }
            }
        }

        private string GetEquipmentSlot(string idindex)
        {
            switch (idindex)
            {
                case "-2":
                    return "None";
                case "-1":
                    return "Unequipable";
                case "0":
                    return "Main Hand";
                case "1":
                    return "Head";
                case "2":
                    return "Chest";
                case "3":
                    return "Leg";
                case "4":
                    return "Feet";
                case "5":
                    return "Offhand";
                case "6":
                    return "Hands";
                case "7":
                    return "Misc";
                case "8":
                case "9":
                case "10":
                case "11":
                    return "Ring";
                case "12":
                case "13":
                    return "Wrist";
                case "14":
                    return "Neck";
                case "15":
                    return "Hat";
                case "16":
                    return "Top";
                case "17":
                    return "Bottoms";
                case "18":
                    return "Shoes";
                case "19":
                    return "Gloves";
                case "20":
                    return "Companion";
                case "21":
                    return "Saddle";
                case "22":
                    return "Mount";
                default:
                    return "Error";
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

        private void SetEquipSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadSets();
        }

        private void SetBonusSelected_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSets();
        }
    }
}
