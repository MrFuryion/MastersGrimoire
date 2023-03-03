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
    public partial class ItemAdvancedSearch : Form
    {
        List<ComboBox> FilterCombo = new List<ComboBox>();
        List<TextBox> FilterTextBox = new List<TextBox>();
        List<ListBox> FilterListBox = new List<ListBox>();
        List<Label> FilterLabel = new List<Label>();
        int vertical = 12;
        int sorthold = 0;
        int sorthold2 = 0;
        int sorthold3 = 0;
        int sorthold4 = 0;
        int sorthold5 = 0;
        List<int> indexhold = new List<int>(); // category and subcategory use this to hold the previous selected index, search textbox uses it to hold the type of data held(skill, status, or set), search listbox uses it to hold the index of the data displayed
        bool sizeincrease;
        bool sizedecrease;
        List<List<string>> FilterSlotValues = new List<List<string>>(); // not needed for subtypes(they line up with normal indexing) or abilities(they line up if None is removed, and no one will search for a none ability boost), or requirements(these need extra info)

        List<List<int>> yholder = new List<List<int>>();
        List<List<List<int>>> yiholder = new List<List<List<int>>>();
        List<int> yilength = new List<int>();
        List<int> yilength2 = new List<int>();
        List<string> yisearch = new List<string>();
        List<bool> yiwarning = new List<bool>();

        List<List<int>> yholder3 = new List<List<int>>();
        List<List<List<int>>> yi2holder = new List<List<List<int>>>();
        List<int> yi2length = new List<int>();
        List<int> yi2length2 = new List<int>();
        List<string> yi2search = new List<string>();
        List<bool> yi2warning = new List<bool>();

        List<List<int>> yholder4 = new List<List<int>>(); // holds index of sets
        List<List<List<int>>> yi3holder = new List<List<List<int>>>();
        List<int> yi3length = new List<int>();
        List<int> yi3length2 = new List<int>();
        List<string> yi3search = new List<string>();
        List<bool> yi3warning = new List<bool>();

        List<string> itemsetrewarditemname = new List<string>(); // holds names of sets
        List<string> itemsetrewardid = new List<string>(); // holds IDs of sets

        List<int> skillholder = new List<int>();
        List<int> statusholder = new List<int>();
        List<int> setholder = new List<int>();
        bool skillflip = false;
        bool statusflip = false; // for clearing the text without tripping the text changed methods
        bool setflip = false;

        List<int> categoryholder = new List<int>(); // they hold the type of categories used so the proper amount of controls can be deleted when the button is pressed

        List<int> zholder = new List<int>(); // holds an initial list of items(so it can be reset easily)
        List<int> zzholder = new List<int>(); // holds a list to work with and narrow down to the desired results

        private bool VariableComparison(int ValueA, int ValueB, int IndexSelected)
        {
            switch(IndexSelected)
            {
                case 0:
                    if (ValueA > ValueB) return true;
                    else return false;
                case 1:
                    if (ValueA >= ValueB) return true;
                    else return false;
                case 2:
                    if (ValueA == ValueB) return true;
                    else return false;
                case 3:
                    if (ValueA <= ValueB) return true;
                    else return false;
                case 4:
                    if (ValueA < ValueB) return true;
                    else return false;
                case 5:
                    if (ValueA != ValueB) return true;
                    else return false;
                    default: return false;
            }
        }

        public ItemAdvancedSearch()
        {
            InitializeComponent();
            FilterSlotValues.Add(new List<string> { "-2" });
            FilterSlotValues.Add(new List<string> { "-1" });
            FilterSlotValues.Add(new List<string> { "0" });
            FilterSlotValues.Add(new List<string> { "1" });
            FilterSlotValues.Add(new List<string> { "2" });
            FilterSlotValues.Add(new List<string> { "3" });
            FilterSlotValues.Add(new List<string> { "4" });
            FilterSlotValues.Add(new List<string> { "5" });
            FilterSlotValues.Add(new List<string> { "6" });
            FilterSlotValues.Add(new List<string> { "7" });
            FilterSlotValues.Add(new List<string> { "8", "9", "10", "11" }); // ring
            FilterSlotValues.Add(new List<string> { "12", "13" }); // wrist
            FilterSlotValues.Add(new List<string> { "14" });
            FilterSlotValues.Add(new List<string> { "15" });
            FilterSlotValues.Add(new List<string> { "16" });
            FilterSlotValues.Add(new List<string> { "17" });
            FilterSlotValues.Add(new List<string> { "18" });
            FilterSlotValues.Add(new List<string> { "19" });
            FilterSlotValues.Add(new List<string> { "20" });
            FilterSlotValues.Add(new List<string> { "21" });
            FilterSlotValues.Add(new List<string> { "22" });

            for (int x = 0; x < MainForm.itemsetrewardid.Count; x++)
            {
                if (!itemsetrewardid.Contains(MainForm.itemsetrewardid[x]))
                {
                    itemsetrewardid.Add(MainForm.itemsetrewardid[x]);
                    itemsetrewarditemname.Add(MainForm.itemname[MainForm.itemid.IndexOf(MainForm.itemsetrewarditemid[x])]);
                }
            }
            for (int x = 0; x < MainForm.itemid.Count; x++)
            {
                zholder.Add(x);
            }
        }

        private void AddFilterButton_Click(object sender, EventArgs e)
        {
            categoryholder.Add(FilterGroupBox.Controls.Count);

            FilterCombo.Add(new ComboBox());
            FilterGroupBox.Controls.Add(FilterCombo[FilterCombo.Count - 1]);
            FilterCombo[FilterCombo.Count - 1].Items.AddRange(new string[] { "Slot", "Subtype", "Requirement", "Damage", "Resistance", "Trait", "Stat", "Evasion", "Skill", "Status", "Flag" });
            FilterCombo[FilterCombo.Count - 1].SelectedIndex = 0;
            FilterCombo[FilterCombo.Count - 1].SelectedIndexChanged += new EventHandler(this.VariableComboBox_SelectedIndexChanged);
            FilterCombo[FilterCombo.Count - 1].Location = new Point(6, vertical);
            FilterCombo[FilterCombo.Count - 1].Size = new Size(84, 21);
            FilterCombo[FilterCombo.Count - 1].DropDownStyle = ComboBoxStyle.DropDownList;
            indexhold.Add(0);

            FilterCombo.Add(new ComboBox());
            FilterGroupBox.Controls.Add(FilterCombo[FilterCombo.Count - 1]);
            FilterCombo[FilterCombo.Count - 1].Items.AddRange(new string[] { "None", "Unequipable", "Main Hand", "Head", "Chest", "Leg", "Feet", "Offhand", "Hands", "Misc", "Ring", "Wrist", "Neck", "Hat", "Top", "Bottoms", "Shoes", "Gloves", "Companion", "Saddle", "Mount" });
            FilterCombo[FilterCombo.Count - 1].SelectedIndex = 0;
            FilterCombo[FilterCombo.Count - 1].SelectedIndexChanged += new EventHandler(this.VariableSubComboBox_SelectedIndexChanged);
            FilterCombo[FilterCombo.Count - 1].Location = new Point(95, vertical);
            FilterCombo[FilterCombo.Count - 1].Size = new Size(299, 21);
            FilterCombo[FilterCombo.Count - 1].DropDownStyle = ComboBoxStyle.DropDownList;
            indexhold.Add(0);

            vertical = vertical + 26;

            RemoveFilterButton.Enabled = true;
            StartSearchButton.Enabled = true;
        }

        private void VariableComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            sorthold = FilterGroupBox.Controls.IndexOf((ComboBox)sender);
            ComboBox Category = FilterGroupBox.Controls[sorthold] as ComboBox;
            if (indexhold[sorthold] != Category.SelectedIndex) // only act if the sort type changes, no reason otherwise
            {
                ComboBox SubCategory = FilterGroupBox.Controls[sorthold + 1] as ComboBox;
                sizeincrease = false;
                sizedecrease = false;
                int indexshiftpoint = 0;
                int indexshiftamount = 0;
                switch (Category.SelectedIndex)
                {
                    case 0:
                        SubCategory.Items.Clear();
                        SubCategory.Items.AddRange(new string[] { "None", "Unequipable", "Main Hand", "Head", "Chest", "Leg", "Feet", "Offhand", "Hands", "Misc", "Ring", "Wrist", "Neck", "Hat", "Top", "Bottoms", "Shoes", "Gloves", "Companion", "Saddle", "Mount" });
                        if (indexhold[sorthold] == 10)
                        {
                            FilterGroupBox.Controls.RemoveAt(sorthold + 2);
                            indexhold.RemoveAt(sorthold + 2);
                            SubCategory.Size = new Size(299, 21);
                            indexshiftpoint = sorthold + 1;
                            indexshiftamount = -1;
                        }
                        else if (indexhold[sorthold] == 8 || indexhold[sorthold] == 9)
                        {
                            if (indexhold[sorthold] == 8)
                            {
                                int deletedindex = indexhold[sorthold + 6];
                                yholder.RemoveAt(deletedindex);
                                yiholder.RemoveAt(deletedindex);
                                yilength.RemoveAt(deletedindex);
                                yilength2.RemoveAt(deletedindex);
                                yisearch.RemoveAt(deletedindex);
                                yiwarning.RemoveAt(deletedindex);
                                skillholder.RemoveAt(deletedindex);
                            }
                            else if (indexhold[sorthold] == 9 && indexhold[sorthold2] == 0)
                            {
                                int deletedindex = indexhold[sorthold + 6];
                                yholder3.RemoveAt(deletedindex);
                                yi2holder.RemoveAt(deletedindex);
                                yi2length.RemoveAt(deletedindex);
                                yi2length2.RemoveAt(deletedindex);
                                yi2search.RemoveAt(deletedindex);
                                yi2warning.RemoveAt(deletedindex);
                                statusholder.RemoveAt(deletedindex);
                            }
                            else // 9 and 1
                            {
                                int deletedindex = indexhold[sorthold + 4];
                                for (int i = deletedindex + 1; i < setholder.Count; i++)
                                {
                                    indexhold[setholder[i]] = setholder[i] - 1;
                                }
                                yholder4.RemoveAt(deletedindex);
                                yi3holder.RemoveAt(deletedindex);
                                yi3length.RemoveAt(deletedindex);
                                yi3length2.RemoveAt(deletedindex);
                                yi3search.RemoveAt(deletedindex);
                                yi3warning.RemoveAt(deletedindex);
                                setholder.RemoveAt(deletedindex);
                            }
                            FilterGroupBox.Controls.RemoveAt(sorthold + 2);
                            FilterGroupBox.Controls.RemoveAt(sorthold + 2);
                            FilterGroupBox.Controls.RemoveAt(sorthold + 2);
                            indexhold.RemoveAt(sorthold + 2);
                            indexhold.RemoveAt(sorthold + 2);
                            indexhold.RemoveAt(sorthold + 2);
                            indexshiftpoint = sorthold + 1;
                            indexshiftamount = -3;
                            if (!(indexhold[sorthold] == 9 && indexhold[sorthold2] == 1))
                            {
                                FilterGroupBox.Controls.RemoveAt(sorthold + 2);
                                FilterGroupBox.Controls.RemoveAt(sorthold + 2);
                                indexhold.RemoveAt(sorthold + 2);
                                indexhold.RemoveAt(sorthold + 2);
                                indexshiftamount = indexshiftamount - 2;
                                SubCategory.Size = new Size(299, 21);
                            }
                            sizedecrease = true;
                        }
                        else if (indexhold[sorthold] != 1 && !(indexhold[sorthold] == 2 && (indexhold[sorthold2] == 7 || indexhold[sorthold2] == 8))) // 1 has the same layout, no need to change
                        {
                            FilterGroupBox.Controls.RemoveAt(sorthold + 2);
                            FilterGroupBox.Controls.RemoveAt(sorthold + 2);
                            indexhold.RemoveAt(sorthold + 2);
                            indexhold.RemoveAt(sorthold + 2);
                            indexshiftpoint = sorthold + 1;
                            indexshiftamount = -2;
                            SubCategory.Size = new Size(299, 21);
                            if (indexhold[sorthold] == 6 && indexhold[sorthold2] == 4)
                            {
                                Category.Size = new Size(84, 21);
                                SubCategory.Location = new Point(95, Category.Location.Y);

                                FilterGroupBox.Controls.RemoveAt(sorthold2 + 1);
                                indexhold.RemoveAt(sorthold2 + 1);
                                indexshiftamount = indexshiftamount - 1;
                            }
                        }
                        SubCategory.SelectedIndex = 0;
                        break;
                    case 1:
                        SubCategory.Items.Clear();
                        SubCategory.Items.AddRange(new string[] { "None", "Sword", "Axe", "Blunt", "Cloth", "Leather", "Chain", "Plate", "Staff", "Dagger", "Wand", "Bow", "Shield", "2H Sword", "2H Axe", "2H Blunt", "Quiver", "Offhand Dagger", "Offhand Sword", "Spear", "Totem", "Broom", "Sled", "Hand to Hand", "Fashion", "Jewelry", "Carpet", "Novelty Broom", "Novelty Wand", "Lute", "Dragonstaff", "Flute", "Harp", "2H Novelty", "Novelty Staff Mount", "Horn", "Novelty Blunt", "Bat Mount", "Wings", "Drum", "Bagpipes", "Eagle Mount", "Test", "Crow", "Sparrow", "Sparrowhawk", "Cape", "Horse", "Banshee Blade", "Samhain Crow", "Samhain Wings", "Play Dead", "Banner", "Boar", "Fishing Rod", "Long Totem", "Offhand Book", "2H Spear", "Pet Food", "Fishing Item", "Token", "Consumable", "Battlemount", "Battlemount Wand", "Battlemount Bow", "Battlemount Unarmed", "Cooking" });
                        if (indexhold[sorthold] == 10)
                        {
                            FilterGroupBox.Controls.RemoveAt(sorthold + 2);
                            indexhold.RemoveAt(sorthold + 2);
                            indexshiftpoint = sorthold + 1;
                            indexshiftamount = -1;
                            SubCategory.Size = new Size(299, 21);
                        }
                        else if (indexhold[sorthold] == 8 || indexhold[sorthold] == 9)
                        {
                            if (indexhold[sorthold] == 8)
                            {
                                int deletedindex = indexhold[sorthold + 6];
                                yholder.RemoveAt(deletedindex);
                                yiholder.RemoveAt(deletedindex);
                                yilength.RemoveAt(deletedindex);
                                yilength2.RemoveAt(deletedindex);
                                yisearch.RemoveAt(deletedindex);
                                yiwarning.RemoveAt(deletedindex);
                                skillholder.RemoveAt(deletedindex);
                            }
                            else if (indexhold[sorthold] == 9 && indexhold[sorthold2] == 0)
                            {
                                int deletedindex = indexhold[sorthold + 6];
                                for (int i = deletedindex + 1; i < statusholder.Count; i++)
                                {
                                    indexhold[statusholder[i]] = statusholder[i] - 1;
                                }
                                yholder3.RemoveAt(deletedindex);
                                yi2holder.RemoveAt(deletedindex);
                                yi2length.RemoveAt(deletedindex);
                                yi2length2.RemoveAt(deletedindex);
                                yi2search.RemoveAt(deletedindex);
                                yi2warning.RemoveAt(deletedindex);
                                statusholder.RemoveAt(deletedindex);
                            }
                            else
                            {
                                int deletedindex = indexhold[sorthold + 4];
                                for (int i = deletedindex + 1; i < setholder.Count; i++)
                                {
                                    indexhold[setholder[i]] = setholder[i] - 1;
                                }
                                yholder4.RemoveAt(deletedindex);
                                yi3holder.RemoveAt(deletedindex);
                                yi3length.RemoveAt(deletedindex);
                                yi3length2.RemoveAt(deletedindex);
                                yi3search.RemoveAt(deletedindex);
                                yi3warning.RemoveAt(deletedindex);
                                setholder.RemoveAt(deletedindex);
                            }
                            FilterGroupBox.Controls.RemoveAt(sorthold + 2);
                            FilterGroupBox.Controls.RemoveAt(sorthold + 2);
                            FilterGroupBox.Controls.RemoveAt(sorthold + 2);
                            indexhold.RemoveAt(sorthold + 2);
                            indexhold.RemoveAt(sorthold + 2);
                            indexhold.RemoveAt(sorthold + 2);
                            indexshiftpoint = sorthold + 1;
                            indexshiftamount = -3;
                            if (!(indexhold[sorthold] == 9 && indexhold[sorthold2] == 1))
                            {
                                FilterGroupBox.Controls.RemoveAt(sorthold + 2);
                                FilterGroupBox.Controls.RemoveAt(sorthold + 2);
                                indexhold.RemoveAt(sorthold + 2);
                                indexhold.RemoveAt(sorthold + 2);
                                indexshiftamount = indexshiftamount - 2;
                                SubCategory.Size = new Size(299, 21);
                            }
                            sizedecrease = true;
                        }
                        else if (indexhold[sorthold] != 0) // same as above
                        {
                            if (!(indexhold[sorthold] == 2 && (indexhold[sorthold2] == 7 || indexhold[sorthold2] == 8)))
                            {
                                FilterGroupBox.Controls.RemoveAt(sorthold + 2);
                                FilterGroupBox.Controls.RemoveAt(sorthold + 2);
                                indexhold.RemoveAt(sorthold + 2);
                                indexhold.RemoveAt(sorthold + 2);
                                indexshiftpoint = sorthold + 1;
                                indexshiftamount = -2;
                                SubCategory.Size = new Size(299, 21);
                                if (indexhold[sorthold] == 6 && indexhold[sorthold2] == 4)
                                {
                                    Category.Size = new Size(84, 21);
                                    SubCategory.Location = new Point(95, Category.Location.Y);

                                    FilterGroupBox.Controls.RemoveAt(sorthold2 + 1);
                                    indexhold.RemoveAt(sorthold2 + 1);
                                    indexshiftamount = indexshiftamount - 1;
                                }
                            }
                        }
                        SubCategory.SelectedIndex = 0;
                        break;
                    case 2:
                        SubCategory.Items.Clear();
                        SubCategory.Items.AddRange(new string[] { "Strength Requirement", "Dexterity Requirement", "Focus Requirement", "Vitality Requirement", "Level Requirement", "Level Requirement(fishing)", "Level Requirement(cooking)", "Male Only", "Female Only" });
                        if (indexhold[sorthold] == 0 || indexhold[sorthold] == 1)
                        {
                            SubCategory.Size = new Size(157, 21);

                            FilterTextBox.Add(new TextBox());
                            FilterGroupBox.Controls.Add(FilterTextBox[FilterTextBox.Count - 1]);
                            FilterTextBox[FilterTextBox.Count - 1].Location = new Point(298, Category.Location.Y);
                            FilterTextBox[FilterTextBox.Count - 1].Size = new Size(96, 21);
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 2);
                            indexhold.Insert(sorthold + 2, 0);

                            FilterCombo.Add(new ComboBox());
                            FilterGroupBox.Controls.Add(FilterCombo[FilterCombo.Count - 1]);
                            FilterCombo[FilterCombo.Count - 1].Items.AddRange(new string[] { ">", ">=", "==", "<=", "<", "!=" });
                            FilterCombo[FilterCombo.Count - 1].SelectedIndex = 0;
                            FilterCombo[FilterCombo.Count - 1].Location = new Point(257, Category.Location.Y);
                            FilterCombo[FilterCombo.Count - 1].Size = new Size(36, 21);
                            FilterCombo[FilterCombo.Count - 1].DropDownStyle = ComboBoxStyle.DropDownList;
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 2);
                            indexhold.Insert(sorthold + 2, 0);

                            TextBox Value = FilterGroupBox.Controls[sorthold + 3] as TextBox;
                            Value.KeyPress += new KeyPressEventHandler(this.ValueTextbox_KeyPress);
                            Value.ShortcutsEnabled = false;
                            Value.Text = "0";

                            indexshiftpoint = sorthold + 3;
                            indexshiftamount = 2;
                        }
                        else if (indexhold[sorthold] == 10)
                        {
                            ComboBox Comparison = FilterGroupBox.Controls[sorthold + 2] as ComboBox;
                            Comparison.Items.Clear();
                            Comparison.Items.AddRange(new string[] { ">", ">=", "==", "<=", "<", "!=" });
                            Comparison.SelectedIndex = 0;
                            Comparison.Location = new Point(257, Category.Location.Y);
                            Comparison.Size = new Size(36, 21);

                            FilterTextBox.Add(new TextBox());
                            FilterGroupBox.Controls.Add(FilterTextBox[FilterTextBox.Count - 1]);
                            FilterTextBox[FilterTextBox.Count - 1].Location = new Point(298, Category.Location.Y);
                            FilterTextBox[FilterTextBox.Count - 1].Size = new Size(96, 21);
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 3);
                            indexhold.Insert(sorthold + 2, 0);

                            TextBox Value = FilterGroupBox.Controls[sorthold + 3] as TextBox;
                            Value.KeyPress += new KeyPressEventHandler(this.ValueTextbox_KeyPress);
                            Value.ShortcutsEnabled = false;
                            Value.Text = "0";

                            indexshiftpoint = sorthold + 3;
                            indexshiftamount = 1;
                        }
                        else if (indexhold[sorthold] == 8 || indexhold[sorthold] == 9)
                        {
                            if (indexhold[sorthold] == 9 && indexhold[sorthold2] == 1)
                            {
                                int deletedindex = indexhold[sorthold + 4];
                                for (int i = deletedindex + 1; i < setholder.Count; i++)
                                {
                                    indexhold[setholder[i]] = setholder[i] - 1;
                                }
                                yholder4.RemoveAt(deletedindex);
                                yi3holder.RemoveAt(deletedindex);
                                yi3length.RemoveAt(deletedindex);
                                yi3length2.RemoveAt(deletedindex);
                                yi3search.RemoveAt(deletedindex);
                                yi3warning.RemoveAt(deletedindex);
                                setholder.RemoveAt(deletedindex);

                                FilterGroupBox.Controls.RemoveAt(sorthold + 2);
                                FilterGroupBox.Controls.RemoveAt(sorthold + 2);
                                FilterGroupBox.Controls.RemoveAt(sorthold + 2);
                                indexhold.RemoveAt(sorthold + 2);
                                indexhold.RemoveAt(sorthold + 2);
                                indexhold.RemoveAt(sorthold + 2);
                                indexshiftpoint = sorthold + 3;
                                indexshiftamount = -3;

                                SubCategory.Size = new Size(157, 21);

                                FilterTextBox.Add(new TextBox());
                                FilterGroupBox.Controls.Add(FilterTextBox[FilterTextBox.Count - 1]);
                                FilterTextBox[FilterTextBox.Count - 1].Location = new Point(298, Category.Location.Y);
                                FilterTextBox[FilterTextBox.Count - 1].Size = new Size(96, 21);
                                FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 2);
                                indexhold.Insert(sorthold + 2, 0);

                                FilterCombo.Add(new ComboBox());
                                FilterGroupBox.Controls.Add(FilterCombo[FilterCombo.Count - 1]);
                                FilterCombo[FilterCombo.Count - 1].Items.AddRange(new string[] { ">", ">=", "==", "<=", "<", "!=" });
                                FilterCombo[FilterCombo.Count - 1].SelectedIndex = 0;
                                FilterCombo[FilterCombo.Count - 1].Location = new Point(257, Category.Location.Y);
                                FilterCombo[FilterCombo.Count - 1].Size = new Size(36, 21);
                                FilterCombo[FilterCombo.Count - 1].DropDownStyle = ComboBoxStyle.DropDownList;
                                FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 2);
                                indexhold.Insert(sorthold + 2, 0);

                                TextBox Value = FilterGroupBox.Controls[sorthold + 3] as TextBox;
                                Value.KeyPress += new KeyPressEventHandler(this.ValueTextbox_KeyPress);
                                Value.ShortcutsEnabled = false;
                                Value.Text = "0";

                                indexshiftpoint = sorthold + 3;
                                indexshiftamount = 2;
                            }
                            else
                            {
                                if (indexhold[sorthold] == 8)
                                {
                                    int deletedindex = indexhold[sorthold + 6];
                                    yholder.RemoveAt(deletedindex);
                                    yiholder.RemoveAt(deletedindex);
                                    yilength.RemoveAt(deletedindex);
                                    yilength2.RemoveAt(deletedindex);
                                    yisearch.RemoveAt(deletedindex);
                                    yiwarning.RemoveAt(deletedindex);
                                    skillholder.RemoveAt(deletedindex);
                                }
                                else if (indexhold[sorthold] == 9 && indexhold[sorthold2] == 0)
                                {
                                    int deletedindex = indexhold[sorthold + 6];
                                    for (int i = deletedindex + 1; i < statusholder.Count; i++)
                                    {
                                        indexhold[statusholder[i]] = statusholder[i] - 1;
                                    }
                                    yholder3.RemoveAt(deletedindex);
                                    yi2holder.RemoveAt(deletedindex);
                                    yi2length.RemoveAt(deletedindex);
                                    yi2length2.RemoveAt(deletedindex);
                                    yi2search.RemoveAt(deletedindex);
                                    yi2warning.RemoveAt(deletedindex);
                                    statusholder.RemoveAt(deletedindex);
                                }
                                FilterGroupBox.Controls.RemoveAt(sorthold + 4);
                                FilterGroupBox.Controls.RemoveAt(sorthold + 4);
                                FilterGroupBox.Controls.RemoveAt(sorthold + 4);
                                indexhold.RemoveAt(sorthold + 4);
                                indexhold.RemoveAt(sorthold + 4);
                                indexhold.RemoveAt(sorthold + 4);
                                indexshiftpoint = sorthold + 3;
                                indexshiftamount = -3;
                            }
                            sizedecrease = true;
                        }
                        else if (indexhold[sorthold] == 6 && indexhold[sorthold2] == 4)
                        {
                            Category.Size = new Size(84, 21);
                            SubCategory.Size = new Size(157, 21);
                            SubCategory.Location = new Point(95, Category.Location.Y);

                            FilterGroupBox.Controls.RemoveAt(sorthold2 + 1);
                            indexhold.RemoveAt(sorthold2 + 1);
                            indexshiftpoint = sorthold2 + 2;
                            indexshiftamount = -1;
                        }
                        SubCategory.SelectedIndex = 0;
                        break;
                    case 3:
                        SubCategory.Items.Clear();
                        SubCategory.Items.AddRange(new string[] { "Piercing Damage", "Slashing Damage", "Crushing Damage", "Heat Damage", "Cold Damage", "Magic Damage", "Poison Damage", "Divine Damage", "Chaos Damage", "True Damage", "Fishing Power" });
                        if (indexhold[sorthold] == 0 || indexhold[sorthold] == 1 || (indexhold[sorthold] == 2 && (indexhold[sorthold2] == 7 || indexhold[sorthold2] == 8)))
                        {
                            SubCategory.Size = new Size(157, 21);

                            FilterTextBox.Add(new TextBox());
                            FilterGroupBox.Controls.Add(FilterTextBox[FilterTextBox.Count - 1]);
                            FilterTextBox[FilterTextBox.Count - 1].Location = new Point(298, Category.Location.Y);
                            FilterTextBox[FilterTextBox.Count - 1].Size = new Size(96, 21);
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 2);
                            indexhold.Insert(sorthold + 2, 0);

                            FilterCombo.Add(new ComboBox());
                            FilterGroupBox.Controls.Add(FilterCombo[FilterCombo.Count - 1]);
                            FilterCombo[FilterCombo.Count - 1].Items.AddRange(new string[] { ">", ">=", "==", "<=", "<", "!=" });
                            FilterCombo[FilterCombo.Count - 1].SelectedIndex = 0;
                            FilterCombo[FilterCombo.Count - 1].Location = new Point(257, Category.Location.Y);
                            FilterCombo[FilterCombo.Count - 1].Size = new Size(36, 21);
                            FilterCombo[FilterCombo.Count - 1].DropDownStyle = ComboBoxStyle.DropDownList;
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 2);
                            indexhold.Insert(sorthold + 2, 0);

                            TextBox Value = FilterGroupBox.Controls[sorthold + 3] as TextBox;
                            Value.KeyPress += new KeyPressEventHandler(this.ValueTextbox_KeyPress);
                            Value.ShortcutsEnabled = false;
                            Value.Text = "0";

                            indexshiftpoint = sorthold + 3;
                            indexshiftamount = 2;
                        }
                        else if (indexhold[sorthold] == 10)
                        {
                            ComboBox Comparison = FilterGroupBox.Controls[sorthold + 2] as ComboBox;
                            Comparison.Items.Clear();
                            Comparison.Items.AddRange(new string[] { ">", ">=", "==", "<=", "<", "!=" });
                            Comparison.SelectedIndex = 0;
                            Comparison.Location = new Point(257, Category.Location.Y);
                            Comparison.Size = new Size(36, 21);

                            FilterTextBox.Add(new TextBox());
                            FilterGroupBox.Controls.Add(FilterTextBox[FilterTextBox.Count - 1]);
                            FilterTextBox[FilterTextBox.Count - 1].Location = new Point(298, Category.Location.Y);
                            FilterTextBox[FilterTextBox.Count - 1].Size = new Size(96, 21);
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 3);
                            indexhold.Insert(sorthold + 2, 0);

                            TextBox Value = FilterGroupBox.Controls[sorthold + 3] as TextBox;
                            Value.KeyPress += new KeyPressEventHandler(this.ValueTextbox_KeyPress);
                            Value.ShortcutsEnabled = false;
                            Value.Text = "0";

                            indexshiftpoint = sorthold + 3;
                            indexshiftamount = 1;
                        }
                        else if (indexhold[sorthold] == 8 || indexhold[sorthold] == 9)
                        {
                            if (indexhold[sorthold] == 9 && indexhold[sorthold2] == 1)
                            {
                                int deletedindex = indexhold[sorthold + 4];
                                for (int i = deletedindex + 1; i < setholder.Count; i++)
                                {
                                    indexhold[setholder[i]] = setholder[i] - 1;
                                }
                                yholder4.RemoveAt(deletedindex);
                                yi3holder.RemoveAt(deletedindex);
                                yi3length.RemoveAt(deletedindex);
                                yi3length2.RemoveAt(deletedindex);
                                yi3search.RemoveAt(deletedindex);
                                yi3warning.RemoveAt(deletedindex);
                                setholder.RemoveAt(deletedindex);

                                FilterGroupBox.Controls.RemoveAt(sorthold + 2);
                                FilterGroupBox.Controls.RemoveAt(sorthold + 2);
                                FilterGroupBox.Controls.RemoveAt(sorthold + 2);
                                indexhold.RemoveAt(sorthold + 2);
                                indexhold.RemoveAt(sorthold + 2);
                                indexhold.RemoveAt(sorthold + 2);
                                indexshiftpoint = sorthold + 3;
                                indexshiftamount = -3;

                                SubCategory.Size = new Size(157, 21);

                                FilterTextBox.Add(new TextBox());
                                FilterGroupBox.Controls.Add(FilterTextBox[FilterTextBox.Count - 1]);
                                FilterTextBox[FilterTextBox.Count - 1].Location = new Point(298, Category.Location.Y);
                                FilterTextBox[FilterTextBox.Count - 1].Size = new Size(96, 21);
                                FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 2);
                                indexhold.Insert(sorthold + 2, 0);

                                FilterCombo.Add(new ComboBox());
                                FilterGroupBox.Controls.Add(FilterCombo[FilterCombo.Count - 1]);
                                FilterCombo[FilterCombo.Count - 1].Items.AddRange(new string[] { ">", ">=", "==", "<=", "<", "!=" });
                                FilterCombo[FilterCombo.Count - 1].SelectedIndex = 0;
                                FilterCombo[FilterCombo.Count - 1].Location = new Point(257, Category.Location.Y);
                                FilterCombo[FilterCombo.Count - 1].Size = new Size(36, 21);
                                FilterCombo[FilterCombo.Count - 1].DropDownStyle = ComboBoxStyle.DropDownList;
                                FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 2);
                                indexhold.Insert(sorthold + 2, 0);

                                TextBox Value = FilterGroupBox.Controls[sorthold + 3] as TextBox;
                                Value.KeyPress += new KeyPressEventHandler(this.ValueTextbox_KeyPress);
                                Value.ShortcutsEnabled = false;
                                Value.Text = "0";

                                indexshiftpoint = sorthold + 3;
                                indexshiftamount = 2;
                            }
                            else
                            {
                                if (indexhold[sorthold] == 8)
                                {
                                    int deletedindex = indexhold[sorthold + 6];
                                    yholder.RemoveAt(deletedindex);
                                    yiholder.RemoveAt(deletedindex);
                                    yilength.RemoveAt(deletedindex);
                                    yilength2.RemoveAt(deletedindex);
                                    yisearch.RemoveAt(deletedindex);
                                    yiwarning.RemoveAt(deletedindex);
                                    skillholder.RemoveAt(deletedindex);
                                }
                                else if (indexhold[sorthold] == 9 && indexhold[sorthold2] == 0)
                                {
                                    int deletedindex = indexhold[sorthold + 6];
                                    for (int i = deletedindex + 1; i < statusholder.Count; i++)
                                    {
                                        indexhold[statusholder[i]] = statusholder[i] - 1;
                                    }
                                    yholder3.RemoveAt(deletedindex);
                                    yi2holder.RemoveAt(deletedindex);
                                    yi2length.RemoveAt(deletedindex);
                                    yi2length2.RemoveAt(deletedindex);
                                    yi2search.RemoveAt(deletedindex);
                                    yi2warning.RemoveAt(deletedindex);
                                    statusholder.RemoveAt(deletedindex);
                                }
                                FilterGroupBox.Controls.RemoveAt(sorthold + 4);
                                FilterGroupBox.Controls.RemoveAt(sorthold + 4);
                                FilterGroupBox.Controls.RemoveAt(sorthold + 4);
                                indexhold.RemoveAt(sorthold + 4);
                                indexhold.RemoveAt(sorthold + 4);
                                indexhold.RemoveAt(sorthold + 4);
                                indexshiftpoint = sorthold + 3;
                                indexshiftamount = -3;
                            }
                            sizedecrease = true;
                        }
                        else if (indexhold[sorthold] == 6 && indexhold[sorthold2] == 4)
                        {
                            Category.Size = new Size(84, 21);
                            SubCategory.Size = new Size(157, 21);
                            SubCategory.Location = new Point(95, Category.Location.Y);

                            FilterGroupBox.Controls.RemoveAt(sorthold2 + 1);
                            indexhold.RemoveAt(sorthold2 + 1);
                            indexshiftpoint = sorthold2 + 2;
                            indexshiftamount = -1;
                        }
                        SubCategory.SelectedIndex = 0;
                        break;
                    case 4:
                        SubCategory.Items.Clear();
                        SubCategory.Items.AddRange(new string[] { "Resist Pierce", "Resist Slash", "Resist Crush", "Resist Heat", "Resist Cold", "Resist Magic", "Resist Poison", "Resist Divine", "Resist Chaos", "Resist True", "Resist Fishing" });
                        if (indexhold[sorthold] == 0 || indexhold[sorthold] == 1 || (indexhold[sorthold] == 2 && (indexhold[sorthold2] == 7 || indexhold[sorthold2] == 8)))
                        {
                            SubCategory.Size = new Size(157, 21);

                            FilterTextBox.Add(new TextBox());
                            FilterGroupBox.Controls.Add(FilterTextBox[FilterTextBox.Count - 1]);
                            FilterTextBox[FilterTextBox.Count - 1].Location = new Point(298, Category.Location.Y);
                            FilterTextBox[FilterTextBox.Count - 1].Size = new Size(96, 21);
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 2);
                            indexhold.Insert(sorthold + 2, 0);

                            FilterCombo.Add(new ComboBox());
                            FilterGroupBox.Controls.Add(FilterCombo[FilterCombo.Count - 1]);
                            FilterCombo[FilterCombo.Count - 1].Items.AddRange(new string[] { ">", ">=", "==", "<=", "<", "!=" });
                            FilterCombo[FilterCombo.Count - 1].SelectedIndex = 0;
                            FilterCombo[FilterCombo.Count - 1].Location = new Point(257, Category.Location.Y);
                            FilterCombo[FilterCombo.Count - 1].Size = new Size(36, 21);
                            FilterCombo[FilterCombo.Count - 1].DropDownStyle = ComboBoxStyle.DropDownList;
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 2);
                            indexhold.Insert(sorthold + 2, 0);

                            TextBox Value = FilterGroupBox.Controls[sorthold + 3] as TextBox;
                            Value.KeyPress += new KeyPressEventHandler(this.ValueTextbox_KeyPress);
                            Value.ShortcutsEnabled = false;
                            Value.Text = "0";

                            indexshiftpoint = sorthold + 3;
                            indexshiftamount = 2;
                        }
                        else if (indexhold[sorthold] == 10)
                        {
                            ComboBox Comparison = FilterGroupBox.Controls[sorthold + 2] as ComboBox;
                            Comparison.Items.Clear();
                            Comparison.Items.AddRange(new string[] { ">", ">=", "==", "<=", "<", "!=" });
                            Comparison.SelectedIndex = 0;
                            Comparison.Location = new Point(257, Category.Location.Y);
                            Comparison.Size = new Size(36, 21);

                            FilterTextBox.Add(new TextBox());
                            FilterGroupBox.Controls.Add(FilterTextBox[FilterTextBox.Count - 1]);
                            FilterTextBox[FilterTextBox.Count - 1].Location = new Point(298, Category.Location.Y);
                            FilterTextBox[FilterTextBox.Count - 1].Size = new Size(96, 21);
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 3);
                            indexhold.Insert(sorthold + 2, 0);

                            TextBox Value = FilterGroupBox.Controls[sorthold + 3] as TextBox;
                            Value.KeyPress += new KeyPressEventHandler(this.ValueTextbox_KeyPress);
                            Value.ShortcutsEnabled = false;
                            Value.Text = "0";

                            indexshiftpoint = sorthold + 3;
                            indexshiftamount = 1;
                        }
                        else if (indexhold[sorthold] == 8 || indexhold[sorthold] == 9)
                        {
                            if (indexhold[sorthold] == 9 && indexhold[sorthold2] == 1)
                            {
                                int deletedindex = indexhold[sorthold + 4];
                                for (int i = deletedindex + 1; i < setholder.Count; i++)
                                {
                                    indexhold[setholder[i]] = setholder[i] - 1;
                                }
                                yholder4.RemoveAt(deletedindex);
                                yi3holder.RemoveAt(deletedindex);
                                yi3length.RemoveAt(deletedindex);
                                yi3length2.RemoveAt(deletedindex);
                                yi3search.RemoveAt(deletedindex);
                                yi3warning.RemoveAt(deletedindex);
                                setholder.RemoveAt(deletedindex);

                                FilterGroupBox.Controls.RemoveAt(sorthold + 2);
                                FilterGroupBox.Controls.RemoveAt(sorthold + 2);
                                FilterGroupBox.Controls.RemoveAt(sorthold + 2);
                                indexhold.RemoveAt(sorthold + 2);
                                indexhold.RemoveAt(sorthold + 2);
                                indexhold.RemoveAt(sorthold + 2);
                                indexshiftpoint = sorthold + 3;
                                indexshiftamount = -3;

                                SubCategory.Size = new Size(157, 21);

                                FilterTextBox.Add(new TextBox());
                                FilterGroupBox.Controls.Add(FilterTextBox[FilterTextBox.Count - 1]);
                                FilterTextBox[FilterTextBox.Count - 1].Location = new Point(298, Category.Location.Y);
                                FilterTextBox[FilterTextBox.Count - 1].Size = new Size(96, 21);
                                FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 2);
                                indexhold.Insert(sorthold + 2, 0);

                                FilterCombo.Add(new ComboBox());
                                FilterGroupBox.Controls.Add(FilterCombo[FilterCombo.Count - 1]);
                                FilterCombo[FilterCombo.Count - 1].Items.AddRange(new string[] { ">", ">=", "==", "<=", "<", "!=" });
                                FilterCombo[FilterCombo.Count - 1].SelectedIndex = 0;
                                FilterCombo[FilterCombo.Count - 1].Location = new Point(257, Category.Location.Y);
                                FilterCombo[FilterCombo.Count - 1].Size = new Size(36, 21);
                                FilterCombo[FilterCombo.Count - 1].DropDownStyle = ComboBoxStyle.DropDownList;
                                FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 2);
                                indexhold.Insert(sorthold + 2, 0);

                                TextBox Value = FilterGroupBox.Controls[sorthold + 3] as TextBox;
                                Value.KeyPress += new KeyPressEventHandler(this.ValueTextbox_KeyPress);
                                Value.ShortcutsEnabled = false;
                                Value.Text = "0";

                                indexshiftpoint = sorthold + 3;
                                indexshiftamount = 2;
                            }
                            else
                            {
                                if (indexhold[sorthold] == 8)
                                {
                                    int deletedindex = indexhold[sorthold + 6];
                                    yholder.RemoveAt(deletedindex);
                                    yiholder.RemoveAt(deletedindex);
                                    yilength.RemoveAt(deletedindex);
                                    yilength2.RemoveAt(deletedindex);
                                    yisearch.RemoveAt(deletedindex);
                                    yiwarning.RemoveAt(deletedindex);
                                    skillholder.RemoveAt(deletedindex);
                                }
                                else if (indexhold[sorthold] == 9 && indexhold[sorthold2] == 0)
                                {
                                    int deletedindex = indexhold[sorthold + 6];
                                    for (int i = deletedindex + 1; i < statusholder.Count; i++)
                                    {
                                        indexhold[statusholder[i]] = statusholder[i] - 1;
                                    }
                                    yholder3.RemoveAt(deletedindex);
                                    yi2holder.RemoveAt(deletedindex);
                                    yi2length.RemoveAt(deletedindex);
                                    yi2length2.RemoveAt(deletedindex);
                                    yi2search.RemoveAt(deletedindex);
                                    yi2warning.RemoveAt(deletedindex);
                                    statusholder.RemoveAt(deletedindex);
                                }
                                FilterGroupBox.Controls.RemoveAt(sorthold + 4);
                                FilterGroupBox.Controls.RemoveAt(sorthold + 4);
                                FilterGroupBox.Controls.RemoveAt(sorthold + 4);
                                indexhold.RemoveAt(sorthold + 4);
                                indexhold.RemoveAt(sorthold + 4);
                                indexhold.RemoveAt(sorthold + 4);
                                indexshiftpoint = sorthold + 3;
                                indexshiftamount = -3;
                            }
                            sizedecrease = true;
                        }
                        else if (indexhold[sorthold] == 6 && indexhold[sorthold2] == 4)
                        {
                            Category.Size = new Size(84, 21);
                            SubCategory.Size = new Size(157, 21);
                            SubCategory.Location = new Point(95, Category.Location.Y);

                            FilterGroupBox.Controls.RemoveAt(sorthold2 + 1);
                            indexhold.RemoveAt(sorthold2 + 1);
                            indexshiftpoint = sorthold2 + 2;
                            indexshiftamount = -1;
                        }
                        SubCategory.SelectedIndex = 0;
                        break;
                    case 5:
                        SubCategory.Items.Clear();
                        SubCategory.Items.AddRange(new string[] { "Attack Speed", "Attack Range", "Missile Speed", "Item Cooldown", "Buy Price", "Sell Price" });
                        if (indexhold[sorthold] == 0 || indexhold[sorthold] == 1 || (indexhold[sorthold] == 2 && (indexhold[sorthold2] == 7 || indexhold[sorthold2] == 8)))
                        {
                            SubCategory.Size = new Size(157, 21);

                            FilterTextBox.Add(new TextBox());
                            FilterGroupBox.Controls.Add(FilterTextBox[FilterTextBox.Count - 1]);
                            FilterTextBox[FilterTextBox.Count - 1].Location = new Point(298, Category.Location.Y);
                            FilterTextBox[FilterTextBox.Count - 1].Size = new Size(96, 21);
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 2);
                            indexhold.Insert(sorthold + 2, 0);

                            FilterCombo.Add(new ComboBox());
                            FilterGroupBox.Controls.Add(FilterCombo[FilterCombo.Count - 1]);
                            FilterCombo[FilterCombo.Count - 1].Items.AddRange(new string[] { ">", ">=", "==", "<=", "<", "!=" });
                            FilterCombo[FilterCombo.Count - 1].SelectedIndex = 0;
                            FilterCombo[FilterCombo.Count - 1].Location = new Point(257, Category.Location.Y);
                            FilterCombo[FilterCombo.Count - 1].Size = new Size(36, 21);
                            FilterCombo[FilterCombo.Count - 1].DropDownStyle = ComboBoxStyle.DropDownList;
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 2);
                            indexhold.Insert(sorthold + 2, 0);

                            TextBox Value = FilterGroupBox.Controls[sorthold + 3] as TextBox;
                            Value.KeyPress += new KeyPressEventHandler(this.ValueTextbox_KeyPress);
                            Value.ShortcutsEnabled = false;
                            Value.Text = "0";

                            indexshiftpoint = sorthold + 3;
                            indexshiftamount = 2;
                        }
                        else if (indexhold[sorthold] == 10)
                        {
                            ComboBox Comparison = FilterGroupBox.Controls[sorthold + 2] as ComboBox;
                            Comparison.Items.Clear();
                            Comparison.Items.AddRange(new string[] { ">", ">=", "==", "<=", "<", "!=" });
                            Comparison.SelectedIndex = 0;
                            Comparison.Location = new Point(257, Category.Location.Y);
                            Comparison.Size = new Size(36, 21);

                            FilterTextBox.Add(new TextBox());
                            FilterGroupBox.Controls.Add(FilterTextBox[FilterTextBox.Count - 1]);
                            FilterTextBox[FilterTextBox.Count - 1].Location = new Point(298, Category.Location.Y);
                            FilterTextBox[FilterTextBox.Count - 1].Size = new Size(96, 21);
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 3);
                            indexhold.Insert(sorthold + 2, 0);

                            TextBox Value = FilterGroupBox.Controls[sorthold + 3] as TextBox;
                            Value.KeyPress += new KeyPressEventHandler(this.ValueTextbox_KeyPress);
                            Value.ShortcutsEnabled = false;
                            Value.Text = "0";

                            indexshiftpoint = sorthold + 3;
                            indexshiftamount = 1;
                        }
                        else if (indexhold[sorthold] == 8 || indexhold[sorthold] == 9)
                        {
                            if (indexhold[sorthold] == 9 && indexhold[sorthold2] == 1)
                            {
                                int deletedindex = indexhold[sorthold + 4];
                                for (int i = deletedindex + 1; i < setholder.Count; i++)
                                {
                                    indexhold[setholder[i]] = setholder[i] - 1;
                                }
                                yholder4.RemoveAt(deletedindex);
                                yi3holder.RemoveAt(deletedindex);
                                yi3length.RemoveAt(deletedindex);
                                yi3length2.RemoveAt(deletedindex);
                                yi3search.RemoveAt(deletedindex);
                                yi3warning.RemoveAt(deletedindex);
                                setholder.RemoveAt(deletedindex);

                                FilterGroupBox.Controls.RemoveAt(sorthold + 2);
                                FilterGroupBox.Controls.RemoveAt(sorthold + 2);
                                FilterGroupBox.Controls.RemoveAt(sorthold + 2);
                                indexhold.RemoveAt(sorthold + 2);
                                indexhold.RemoveAt(sorthold + 2);
                                indexhold.RemoveAt(sorthold + 2);
                                indexshiftpoint = sorthold + 3;
                                indexshiftamount = -3;

                                SubCategory.Size = new Size(157, 21);

                                FilterTextBox.Add(new TextBox());
                                FilterGroupBox.Controls.Add(FilterTextBox[FilterTextBox.Count - 1]);
                                FilterTextBox[FilterTextBox.Count - 1].Location = new Point(298, Category.Location.Y);
                                FilterTextBox[FilterTextBox.Count - 1].Size = new Size(96, 21);
                                FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 2);
                                indexhold.Insert(sorthold + 2, 0);

                                FilterCombo.Add(new ComboBox());
                                FilterGroupBox.Controls.Add(FilterCombo[FilterCombo.Count - 1]);
                                FilterCombo[FilterCombo.Count - 1].Items.AddRange(new string[] { ">", ">=", "==", "<=", "<", "!=" });
                                FilterCombo[FilterCombo.Count - 1].SelectedIndex = 0;
                                FilterCombo[FilterCombo.Count - 1].Location = new Point(257, Category.Location.Y);
                                FilterCombo[FilterCombo.Count - 1].Size = new Size(36, 21);
                                FilterCombo[FilterCombo.Count - 1].DropDownStyle = ComboBoxStyle.DropDownList;
                                FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 2);
                                indexhold.Insert(sorthold + 2, 0);

                                TextBox Value = FilterGroupBox.Controls[sorthold + 3] as TextBox;
                                Value.KeyPress += new KeyPressEventHandler(this.ValueTextbox_KeyPress);
                                Value.ShortcutsEnabled = false;
                                Value.Text = "0";

                                indexshiftpoint = sorthold + 3;
                                indexshiftamount = 2;
                            }
                            else
                            {
                                if (indexhold[sorthold] == 8)
                                {
                                    int deletedindex = indexhold[sorthold + 6];
                                    yholder.RemoveAt(deletedindex);
                                    yiholder.RemoveAt(deletedindex);
                                    yilength.RemoveAt(deletedindex);
                                    yilength2.RemoveAt(deletedindex);
                                    yisearch.RemoveAt(deletedindex);
                                    yiwarning.RemoveAt(deletedindex);
                                    skillholder.RemoveAt(deletedindex);
                                }
                                else if (indexhold[sorthold] == 9 && indexhold[sorthold2] == 0)
                                {
                                    int deletedindex = indexhold[sorthold + 6];
                                    for (int i = deletedindex + 1; i < statusholder.Count; i++)
                                    {
                                        indexhold[statusholder[i]] = statusholder[i] - 1;
                                    }
                                    yholder3.RemoveAt(deletedindex);
                                    yi2holder.RemoveAt(deletedindex);
                                    yi2length.RemoveAt(deletedindex);
                                    yi2length2.RemoveAt(deletedindex);
                                    yi2search.RemoveAt(deletedindex);
                                    yi2warning.RemoveAt(deletedindex);
                                    statusholder.RemoveAt(deletedindex);
                                }
                                FilterGroupBox.Controls.RemoveAt(sorthold + 4);
                                FilterGroupBox.Controls.RemoveAt(sorthold + 4);
                                FilterGroupBox.Controls.RemoveAt(sorthold + 4);
                                indexhold.RemoveAt(sorthold + 4);
                                indexhold.RemoveAt(sorthold + 4);
                                indexhold.RemoveAt(sorthold + 4);
                                indexshiftpoint = sorthold + 3;
                                indexshiftamount = -3;
                            }
                            sizedecrease = true;
                        }
                        else if (indexhold[sorthold] == 6 && indexhold[sorthold2] == 4)
                        {
                            Category.Size = new Size(84, 21);
                            SubCategory.Size = new Size(157, 21);
                            SubCategory.Location = new Point(95, Category.Location.Y);

                            FilterGroupBox.Controls.RemoveAt(sorthold2 + 1);
                            indexhold.RemoveAt(sorthold2 + 1);
                            indexshiftpoint = sorthold2 + 2;
                            indexshiftamount = -1;
                        }
                        SubCategory.SelectedIndex = 0;
                        break;
                    case 6:
                        SubCategory.Items.Clear();
                        SubCategory.Items.AddRange(new string[] { "Strength", "Dexterity", "Focus", "Vitality", "Ability", "Armour", "Attack", "Defence", "Health", "Energy", "Concentration", "Weight" });
                        if (indexhold[sorthold] == 0 || indexhold[sorthold] == 1 || (indexhold[sorthold] == 2 && (indexhold[sorthold2] == 7 || indexhold[sorthold2] == 8)))
                        {
                            SubCategory.Size = new Size(157, 21);

                            FilterTextBox.Add(new TextBox());
                            FilterGroupBox.Controls.Add(FilterTextBox[FilterTextBox.Count - 1]);
                            FilterTextBox[FilterTextBox.Count - 1].Location = new Point(298, Category.Location.Y);
                            FilterTextBox[FilterTextBox.Count - 1].Size = new Size(96, 21);
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 2);
                            indexhold.Insert(sorthold + 2, 0);

                            FilterCombo.Add(new ComboBox());
                            FilterGroupBox.Controls.Add(FilterCombo[FilterCombo.Count - 1]);
                            FilterCombo[FilterCombo.Count - 1].Items.AddRange(new string[] { ">", ">=", "==", "<=", "<", "!=" });
                            FilterCombo[FilterCombo.Count - 1].SelectedIndex = 0;
                            FilterCombo[FilterCombo.Count - 1].Location = new Point(257, Category.Location.Y);
                            FilterCombo[FilterCombo.Count - 1].Size = new Size(36, 21);
                            FilterCombo[FilterCombo.Count - 1].DropDownStyle = ComboBoxStyle.DropDownList;
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 2);
                            indexhold.Insert(sorthold + 2, 0);

                            TextBox Value = FilterGroupBox.Controls[sorthold + 3] as TextBox;
                            Value.KeyPress += new KeyPressEventHandler(this.ValueTextbox_KeyPress);
                            Value.ShortcutsEnabled = false;
                            Value.Text = "0";

                            indexshiftpoint = sorthold + 3;
                            indexshiftamount = 2;
                        }
                        else if (indexhold[sorthold] == 10)
                        {
                            ComboBox Comparison = FilterGroupBox.Controls[sorthold + 2] as ComboBox;
                            Comparison.Items.Clear();
                            Comparison.Items.AddRange(new string[] { ">", ">=", "==", "<=", "<", "!=" });
                            Comparison.SelectedIndex = 0;
                            Comparison.Location = new Point(257, Category.Location.Y);
                            Comparison.Size = new Size(36, 21);

                            FilterTextBox.Add(new TextBox());
                            FilterGroupBox.Controls.Add(FilterTextBox[FilterTextBox.Count - 1]);
                            FilterTextBox[FilterTextBox.Count - 1].Location = new Point(298, Category.Location.Y);
                            FilterTextBox[FilterTextBox.Count - 1].Size = new Size(96, 21);
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 3);
                            indexhold.Insert(sorthold + 2, 0);

                            TextBox Value = FilterGroupBox.Controls[sorthold + 3] as TextBox;
                            Value.KeyPress += new KeyPressEventHandler(this.ValueTextbox_KeyPress);
                            Value.ShortcutsEnabled = false;
                            Value.Text = "0";

                            indexshiftpoint = sorthold + 3;
                            indexshiftamount = 1;
                        }
                        else if (indexhold[sorthold] == 8 || indexhold[sorthold] == 9)
                        {
                            if (indexhold[sorthold] == 9 && indexhold[sorthold2] == 1)
                            {
                                int deletedindex = indexhold[sorthold + 4];
                                for (int i = deletedindex + 1; i < setholder.Count; i++)
                                {
                                    indexhold[setholder[i]] = setholder[i] - 1;
                                }
                                yholder4.RemoveAt(deletedindex);
                                yi3holder.RemoveAt(deletedindex);
                                yi3length.RemoveAt(deletedindex);
                                yi3length2.RemoveAt(deletedindex);
                                yi3search.RemoveAt(deletedindex);
                                yi3warning.RemoveAt(deletedindex);
                                setholder.RemoveAt(deletedindex);

                                FilterGroupBox.Controls.RemoveAt(sorthold + 2);
                                FilterGroupBox.Controls.RemoveAt(sorthold + 2);
                                FilterGroupBox.Controls.RemoveAt(sorthold + 2);
                                indexhold.RemoveAt(sorthold + 2);
                                indexhold.RemoveAt(sorthold + 2);
                                indexhold.RemoveAt(sorthold + 2);
                                indexshiftpoint = sorthold + 3;
                                indexshiftamount = -3;

                                SubCategory.Size = new Size(157, 21);

                                FilterTextBox.Add(new TextBox());
                                FilterGroupBox.Controls.Add(FilterTextBox[FilterTextBox.Count - 1]);
                                FilterTextBox[FilterTextBox.Count - 1].Location = new Point(298, Category.Location.Y);
                                FilterTextBox[FilterTextBox.Count - 1].Size = new Size(96, 21);
                                FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 2);
                                indexhold.Insert(sorthold + 2, 0);

                                FilterCombo.Add(new ComboBox());
                                FilterGroupBox.Controls.Add(FilterCombo[FilterCombo.Count - 1]);
                                FilterCombo[FilterCombo.Count - 1].Items.AddRange(new string[] { ">", ">=", "==", "<=", "<", "!=" });
                                FilterCombo[FilterCombo.Count - 1].SelectedIndex = 0;
                                FilterCombo[FilterCombo.Count - 1].Location = new Point(257, Category.Location.Y);
                                FilterCombo[FilterCombo.Count - 1].Size = new Size(36, 21);
                                FilterCombo[FilterCombo.Count - 1].DropDownStyle = ComboBoxStyle.DropDownList;
                                FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 2);
                                indexhold.Insert(sorthold + 2, 0);

                                TextBox Value = FilterGroupBox.Controls[sorthold + 3] as TextBox;
                                Value.KeyPress += new KeyPressEventHandler(this.ValueTextbox_KeyPress);
                                Value.ShortcutsEnabled = false;
                                Value.Text = "0";

                                indexshiftpoint = sorthold + 3;
                                indexshiftamount = 2;
                            }
                            else
                            {
                                if (indexhold[sorthold] == 8)
                                {
                                    int deletedindex = indexhold[sorthold + 6];
                                    yholder.RemoveAt(deletedindex);
                                    yiholder.RemoveAt(deletedindex);
                                    yilength.RemoveAt(deletedindex);
                                    yilength2.RemoveAt(deletedindex);
                                    yisearch.RemoveAt(deletedindex);
                                    yiwarning.RemoveAt(deletedindex);
                                    skillholder.RemoveAt(deletedindex);
                                }
                                else if (indexhold[sorthold] == 9 && indexhold[sorthold2] == 0)
                                {
                                    int deletedindex = indexhold[sorthold + 6];
                                    for (int i = deletedindex + 1; i < statusholder.Count; i++)
                                    {
                                        indexhold[statusholder[i]] = statusholder[i] - 1;
                                    }
                                    yholder3.RemoveAt(deletedindex);
                                    yi2holder.RemoveAt(deletedindex);
                                    yi2length.RemoveAt(deletedindex);
                                    yi2length2.RemoveAt(deletedindex);
                                    yi2search.RemoveAt(deletedindex);
                                    yi2warning.RemoveAt(deletedindex);
                                    statusholder.RemoveAt(deletedindex);
                                }
                                FilterGroupBox.Controls.RemoveAt(sorthold + 4);
                                FilterGroupBox.Controls.RemoveAt(sorthold + 4);
                                FilterGroupBox.Controls.RemoveAt(sorthold + 4);
                                indexhold.RemoveAt(sorthold + 4);
                                indexhold.RemoveAt(sorthold + 4);
                                indexhold.RemoveAt(sorthold + 4);
                                indexshiftpoint = sorthold + 3;
                                indexshiftamount = -3;
                            }
                            sizedecrease = true;
                        }
                        SubCategory.SelectedIndex = 0;
                        break;
                    case 7:
                        SubCategory.Items.Clear();
                        SubCategory.Items.AddRange(new string[] { "Physical Attack Evasion", "Spell Attack Evasion", "Movement Attack Evasion", "Wounding Attack Evasion", "Weakening Attack Evasion", "Mental Attack Evasion" });
                        if (indexhold[sorthold] == 0 || indexhold[sorthold] == 1 || (indexhold[sorthold] == 2 && (indexhold[sorthold2] == 7 || indexhold[sorthold2] == 8)))
                        {
                            SubCategory.Size = new Size(157, 21);

                            FilterTextBox.Add(new TextBox());
                            FilterGroupBox.Controls.Add(FilterTextBox[FilterTextBox.Count - 1]);
                            FilterTextBox[FilterTextBox.Count - 1].Location = new Point(298, Category.Location.Y);
                            FilterTextBox[FilterTextBox.Count - 1].Size = new Size(96, 21);
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 2);
                            indexhold.Insert(sorthold + 2, 0);

                            FilterCombo.Add(new ComboBox());
                            FilterGroupBox.Controls.Add(FilterCombo[FilterCombo.Count - 1]);
                            FilterCombo[FilterCombo.Count - 1].Items.AddRange(new string[] { ">", ">=", "==", "<=", "<", "!=" });
                            FilterCombo[FilterCombo.Count - 1].SelectedIndex = 0;
                            FilterCombo[FilterCombo.Count - 1].Location = new Point(257, Category.Location.Y);
                            FilterCombo[FilterCombo.Count - 1].Size = new Size(36, 21);
                            FilterCombo[FilterCombo.Count - 1].DropDownStyle = ComboBoxStyle.DropDownList;
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 2);
                            indexhold.Insert(sorthold + 2, 0);

                            TextBox Value = FilterGroupBox.Controls[sorthold + 3] as TextBox;
                            Value.KeyPress += new KeyPressEventHandler(this.ValueTextbox_KeyPress);
                            Value.ShortcutsEnabled = false;
                            Value.Text = "0";

                            indexshiftpoint = sorthold + 3;
                            indexshiftamount = 2;
                        }
                        else if (indexhold[sorthold] == 10)
                        {
                            ComboBox Comparison = FilterGroupBox.Controls[sorthold + 2] as ComboBox;
                            Comparison.Items.Clear();
                            Comparison.Items.AddRange(new string[] { ">", ">=", "==", "<=", "<", "!=" });
                            Comparison.SelectedIndex = 0;
                            Comparison.Location = new Point(257, Category.Location.Y);
                            Comparison.Size = new Size(36, 21);

                            FilterTextBox.Add(new TextBox());
                            FilterGroupBox.Controls.Add(FilterTextBox[FilterTextBox.Count - 1]);
                            FilterTextBox[FilterTextBox.Count - 1].Location = new Point(298, Category.Location.Y);
                            FilterTextBox[FilterTextBox.Count - 1].Size = new Size(96, 21);
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 3);
                            indexhold.Insert(sorthold + 2, 0);

                            TextBox Value = FilterGroupBox.Controls[sorthold + 3] as TextBox;
                            Value.KeyPress += new KeyPressEventHandler(this.ValueTextbox_KeyPress);
                            Value.ShortcutsEnabled = false;
                            Value.Text = "0";

                            indexshiftpoint = sorthold + 3;
                            indexshiftamount = 1;
                        }
                        else if (indexhold[sorthold] == 8 || indexhold[sorthold] == 9)
                        {
                            if (indexhold[sorthold] == 9 && indexhold[sorthold2] == 1)
                            {
                                int deletedindex = indexhold[sorthold + 4];
                                for (int i = deletedindex + 1; i < setholder.Count; i++)
                                {
                                    indexhold[setholder[i]] = setholder[i] - 1;
                                }
                                yholder4.RemoveAt(deletedindex);
                                yi3holder.RemoveAt(deletedindex);
                                yi3length.RemoveAt(deletedindex);
                                yi3length2.RemoveAt(deletedindex);
                                yi3search.RemoveAt(deletedindex);
                                yi3warning.RemoveAt(deletedindex);
                                setholder.RemoveAt(deletedindex);

                                FilterGroupBox.Controls.RemoveAt(sorthold + 2);
                                FilterGroupBox.Controls.RemoveAt(sorthold + 2);
                                FilterGroupBox.Controls.RemoveAt(sorthold + 2);
                                indexhold.RemoveAt(sorthold + 2);
                                indexhold.RemoveAt(sorthold + 2);
                                indexhold.RemoveAt(sorthold + 2);
                                indexshiftpoint = sorthold + 3;
                                indexshiftamount = -3;

                                SubCategory.Size = new Size(157, 21);

                                FilterTextBox.Add(new TextBox());
                                FilterGroupBox.Controls.Add(FilterTextBox[FilterTextBox.Count - 1]);
                                FilterTextBox[FilterTextBox.Count - 1].Location = new Point(298, Category.Location.Y);
                                FilterTextBox[FilterTextBox.Count - 1].Size = new Size(96, 21);
                                FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 2);
                                indexhold.Insert(sorthold + 2, 0);

                                FilterCombo.Add(new ComboBox());
                                FilterGroupBox.Controls.Add(FilterCombo[FilterCombo.Count - 1]);
                                FilterCombo[FilterCombo.Count - 1].Items.AddRange(new string[] { ">", ">=", "==", "<=", "<", "!=" });
                                FilterCombo[FilterCombo.Count - 1].SelectedIndex = 0;
                                FilterCombo[FilterCombo.Count - 1].Location = new Point(257, Category.Location.Y);
                                FilterCombo[FilterCombo.Count - 1].Size = new Size(36, 21);
                                FilterCombo[FilterCombo.Count - 1].DropDownStyle = ComboBoxStyle.DropDownList;
                                FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 2);
                                indexhold.Insert(sorthold + 2, 0);

                                TextBox Value = FilterGroupBox.Controls[sorthold + 3] as TextBox;
                                Value.KeyPress += new KeyPressEventHandler(this.ValueTextbox_KeyPress);
                                Value.ShortcutsEnabled = false;
                                Value.Text = "0";

                                indexshiftpoint = sorthold + 3;
                                indexshiftamount = 2;
                            }
                            else
                            {
                                if (indexhold[sorthold] == 8)
                                {
                                    int deletedindex = indexhold[sorthold + 6];
                                    yholder.RemoveAt(deletedindex);
                                    yiholder.RemoveAt(deletedindex);
                                    yilength.RemoveAt(deletedindex);
                                    yilength2.RemoveAt(deletedindex);
                                    yisearch.RemoveAt(deletedindex);
                                    yiwarning.RemoveAt(deletedindex);
                                    skillholder.RemoveAt(deletedindex);
                                }
                                else if (indexhold[sorthold] == 9 && indexhold[sorthold2] == 0)
                                {
                                    int deletedindex = indexhold[sorthold + 6];
                                    for (int i = deletedindex + 1; i < statusholder.Count; i++)
                                    {
                                        indexhold[statusholder[i]] = statusholder[i] - 1;
                                    }
                                    yholder3.RemoveAt(deletedindex);
                                    yi2holder.RemoveAt(deletedindex);
                                    yi2length.RemoveAt(deletedindex);
                                    yi2length2.RemoveAt(deletedindex);
                                    yi2search.RemoveAt(deletedindex);
                                    yi2warning.RemoveAt(deletedindex);
                                    statusholder.RemoveAt(deletedindex);
                                }
                                FilterGroupBox.Controls.RemoveAt(sorthold + 4);
                                FilterGroupBox.Controls.RemoveAt(sorthold + 4);
                                FilterGroupBox.Controls.RemoveAt(sorthold + 4);
                                indexhold.RemoveAt(sorthold + 4);
                                indexhold.RemoveAt(sorthold + 4);
                                indexhold.RemoveAt(sorthold + 4);
                                indexshiftpoint = sorthold + 3;
                                indexshiftamount = -3;
                            }
                            sizedecrease = true;
                        }
                        else if (indexhold[sorthold] == 6 && indexhold[sorthold2] == 4)
                        {
                            Category.Size = new Size(84, 21);
                            SubCategory.Size = new Size(157, 21);
                            SubCategory.Location = new Point(95, Category.Location.Y);

                            FilterGroupBox.Controls.RemoveAt(sorthold2 + 1);
                            indexhold.RemoveAt(sorthold2 + 1);
                            indexshiftpoint = sorthold2 + 2;
                            indexshiftamount = -1;
                        }
                        SubCategory.SelectedIndex = 0;
                        break;
                    case 8:
                        SubCategory.Items.Clear();
                        SubCategory.Items.AddRange(new string[] { "Skill Points", "Direct Boost", "Cooldown Reduction", "Proc Skill", "Give Skill", "Skill On Use" });
                        if (indexhold[sorthold] == 0 || indexhold[sorthold] == 1 || (indexhold[sorthold] == 2 && (indexhold[sorthold2] == 7 || indexhold[sorthold2] == 8)))
                        {
                            SubCategory.Size = new Size(157, 21);

                            FilterListBox.Add(new ListBox());
                            FilterGroupBox.Controls.Add(FilterListBox[FilterListBox.Count - 1]);
                            FilterListBox[FilterListBox.Count - 1].Location = new Point(6, Category.Location.Y + 51);
                            FilterListBox[FilterListBox.Count - 1].Size = new Size(388, 100);
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 2);
                            indexhold.Insert(sorthold + 2, skillholder.Count);

                            FilterTextBox.Add(new TextBox());
                            FilterGroupBox.Controls.Add(FilterTextBox[FilterTextBox.Count - 1]);
                            FilterTextBox[FilterTextBox.Count - 1].Location = new Point(95, Category.Location.Y + 26);
                            FilterTextBox[FilterTextBox.Count - 1].Size = new Size(299, 21);
                            FilterTextBox[FilterTextBox.Count - 1].TextChanged += new EventHandler(this.SkillNameSearchTextbox_TextChanged);
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 2);
                            indexhold.Insert(sorthold + 2, 0);

                            FilterLabel.Add(new Label());
                            FilterGroupBox.Controls.Add(FilterLabel[FilterLabel.Count - 1]);
                            FilterLabel[FilterLabel.Count - 1].Location = new Point(5, Category.Location.Y + 29);
                            FilterLabel[FilterLabel.Count - 1].Text = "Search By Name:";
                            FilterLabel[FilterLabel.Count - 1].AutoSize = true;
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 2);
                            indexhold.Insert(sorthold + 2, 0);

                            FilterTextBox.Add(new TextBox());
                            FilterGroupBox.Controls.Add(FilterTextBox[FilterTextBox.Count - 1]);
                            FilterTextBox[FilterTextBox.Count - 1].Location = new Point(298, Category.Location.Y);
                            FilterTextBox[FilterTextBox.Count - 1].Size = new Size(96, 21);
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 2);
                            indexhold.Insert(sorthold + 2, 0);

                            FilterCombo.Add(new ComboBox());
                            FilterGroupBox.Controls.Add(FilterCombo[FilterCombo.Count - 1]);
                            FilterCombo[FilterCombo.Count - 1].Items.AddRange(new string[] { ">", ">=", "==", "<=", "<", "!=" });
                            FilterCombo[FilterCombo.Count - 1].SelectedIndex = 0;
                            FilterCombo[FilterCombo.Count - 1].Location = new Point(257, Category.Location.Y);
                            FilterCombo[FilterCombo.Count - 1].Size = new Size(36, 21);
                            FilterCombo[FilterCombo.Count - 1].DropDownStyle = ComboBoxStyle.DropDownList;
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 2);
                            indexhold.Insert(sorthold + 2, 0);

                            TextBox Value = FilterGroupBox.Controls[sorthold + 3] as TextBox;
                            Value.KeyPress += new KeyPressEventHandler(this.ValueTextbox_KeyPress);
                            Value.ShortcutsEnabled = false;
                            Value.Text = "0";

                            sizeincrease = true;

                            indexshiftpoint = sorthold + 6;
                            indexshiftamount = 5;
                        }
                        else if (indexhold[sorthold] == 10)
                        {
                            ComboBox Comparison = FilterGroupBox.Controls[sorthold + 2] as ComboBox;
                            Comparison.Items.Clear();
                            Comparison.Items.AddRange(new string[] { ">", ">=", "==", "<=", "<", "!=" });
                            Comparison.SelectedIndex = 0;
                            Comparison.Location = new Point(257, Category.Location.Y);
                            Comparison.Size = new Size(36, 21);

                            FilterListBox.Add(new ListBox());
                            FilterGroupBox.Controls.Add(FilterListBox[FilterListBox.Count - 1]);
                            FilterListBox[FilterListBox.Count - 1].Location = new Point(6, Category.Location.Y + 51);
                            FilterListBox[FilterListBox.Count - 1].Size = new Size(388, 100);
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 3);
                            indexhold.Insert(sorthold + 2, 0);

                            FilterTextBox.Add(new TextBox());
                            FilterGroupBox.Controls.Add(FilterTextBox[FilterTextBox.Count - 1]);
                            FilterTextBox[FilterTextBox.Count - 1].Location = new Point(95, Category.Location.Y + 26);
                            FilterTextBox[FilterTextBox.Count - 1].Size = new Size(299, 21);
                            FilterTextBox[FilterTextBox.Count - 1].TextChanged += new EventHandler(this.SkillNameSearchTextbox_TextChanged);
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 3);
                            indexhold.Insert(sorthold + 2, 0);

                            FilterLabel.Add(new Label());
                            FilterGroupBox.Controls.Add(FilterLabel[FilterLabel.Count - 1]);
                            FilterLabel[FilterLabel.Count - 1].Location = new Point(5, Category.Location.Y + 29);
                            FilterLabel[FilterLabel.Count - 1].Text = "Search By Name:";
                            FilterLabel[FilterLabel.Count - 1].AutoSize = true;
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 3);
                            indexhold.Insert(sorthold + 2, 0);

                            FilterTextBox.Add(new TextBox());
                            FilterGroupBox.Controls.Add(FilterTextBox[FilterTextBox.Count - 1]);
                            FilterTextBox[FilterTextBox.Count - 1].Location = new Point(298, Category.Location.Y);
                            FilterTextBox[FilterTextBox.Count - 1].Size = new Size(96, 21);
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 3);
                            indexhold.Insert(sorthold + 2, 0);

                            TextBox Value = FilterGroupBox.Controls[sorthold + 3] as TextBox;
                            Value.KeyPress += new KeyPressEventHandler(this.ValueTextbox_KeyPress);
                            Value.ShortcutsEnabled = false;
                            Value.Text = "0";

                            sizeincrease = true;

                            indexshiftpoint = sorthold + 6;
                            indexshiftamount = 4;
                        }
                        else if (indexhold[sorthold] != 9)
                        {
                            if (indexhold[sorthold] == 6 && indexhold[sorthold2] == 4)
                            {
                                Category.Size = new Size(84, 21);
                                SubCategory.Size = new Size(157, 21);
                                SubCategory.Location = new Point(95, Category.Location.Y);

                                FilterGroupBox.Controls.RemoveAt(sorthold2 + 1);
                                indexhold.RemoveAt(sorthold2 + 1);
                                indexshiftpoint = sorthold2 + 5;
                                indexshiftamount = -1;
                            }

                            FilterListBox.Add(new ListBox());
                            FilterGroupBox.Controls.Add(FilterListBox[FilterListBox.Count - 1]);
                            FilterListBox[FilterListBox.Count - 1].Location = new Point(6, Category.Location.Y + 51);
                            FilterListBox[FilterListBox.Count - 1].Size = new Size(388, 100);
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 4);
                            indexhold.Insert(sorthold + 4, 0);

                            FilterTextBox.Add(new TextBox());
                            FilterGroupBox.Controls.Add(FilterTextBox[FilterTextBox.Count - 1]);
                            FilterTextBox[FilterTextBox.Count - 1].Location = new Point(95, Category.Location.Y + 26);
                            FilterTextBox[FilterTextBox.Count - 1].Size = new Size(299, 21);
                            FilterTextBox[FilterTextBox.Count - 1].TextChanged += new EventHandler(this.SkillNameSearchTextbox_TextChanged);
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 4);
                            indexhold.Insert(sorthold + 2, 0);

                            FilterLabel.Add(new Label());
                            FilterGroupBox.Controls.Add(FilterLabel[FilterLabel.Count - 1]);
                            FilterLabel[FilterLabel.Count - 1].Location = new Point(5, Category.Location.Y + 29);
                            FilterLabel[FilterLabel.Count - 1].Text = "Search By Name:";
                            FilterLabel[FilterLabel.Count - 1].AutoSize = true;
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 4);
                            indexhold.Insert(sorthold + 2, 0);

                            sizeincrease = true;

                            indexshiftpoint = sorthold + 6;
                            indexshiftamount = 3;
                        }
                        else if (indexhold[sorthold] == 9 && indexhold[sorthold2] == 1)
                        {
                            int deletedindex = indexhold[sorthold + 4];
                            for (int i = deletedindex + 1; i < setholder.Count; i++)
                            {
                                indexhold[setholder[i]] = setholder[i] - 1;
                            }
                            yholder4.RemoveAt(deletedindex);
                            yi3holder.RemoveAt(deletedindex);
                            yi3length.RemoveAt(deletedindex);
                            yi3length2.RemoveAt(deletedindex);
                            yi3search.RemoveAt(deletedindex);
                            yi3warning.RemoveAt(deletedindex);
                            setholder.RemoveAt(deletedindex);

                            SubCategory.Size = new Size(157, 21);

                            FilterTextBox.Add(new TextBox());
                            FilterGroupBox.Controls.Add(FilterTextBox[FilterTextBox.Count - 1]);
                            FilterTextBox[FilterTextBox.Count - 1].Location = new Point(298, Category.Location.Y);
                            FilterTextBox[FilterTextBox.Count - 1].Size = new Size(96, 21);
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 2);
                            indexhold.Insert(sorthold + 2, 0);

                            FilterCombo.Add(new ComboBox());
                            FilterGroupBox.Controls.Add(FilterCombo[FilterCombo.Count - 1]);
                            FilterCombo[FilterCombo.Count - 1].Items.AddRange(new string[] { ">", ">=", "==", "<=", "<", "!=" });
                            FilterCombo[FilterCombo.Count - 1].SelectedIndex = 0;
                            FilterCombo[FilterCombo.Count - 1].Location = new Point(257, Category.Location.Y);
                            FilterCombo[FilterCombo.Count - 1].Size = new Size(36, 21);
                            FilterCombo[FilterCombo.Count - 1].DropDownStyle = ComboBoxStyle.DropDownList;
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 2);
                            indexhold.Insert(sorthold + 2, 0);

                            TextBox Value = FilterGroupBox.Controls[sorthold + 3] as TextBox;
                            Value.KeyPress += new KeyPressEventHandler(this.ValueTextbox_KeyPress);
                            Value.ShortcutsEnabled = false;
                            Value.Text = "0";

                            TextBox Search = FilterGroupBox.Controls[sorthold + 5] as TextBox;

                            Search.TextChanged -= SetNameSearchTextbox_TextChanged;
                            Search.TextChanged += new EventHandler(this.SkillNameSearchTextbox_TextChanged);
                            skillflip = true;
                            Search.Clear();
                            skillflip = false;

                            ListBox SearchList = FilterGroupBox.Controls[sorthold + 6] as ListBox;

                            SearchList.Items.Clear();

                            indexshiftpoint = sorthold + 6;
                            indexshiftamount = 2;
                        }
                        else
                        {
                            int deletedindex = indexhold[sorthold + 6];
                            for (int i = deletedindex + 1; i < statusholder.Count; i++)
                            {
                                indexhold[statusholder[i]] = statusholder[i] - 1;
                            }
                            yholder3.RemoveAt(deletedindex);
                            yi2holder.RemoveAt(deletedindex);
                            yi2length.RemoveAt(deletedindex);
                            yi2length2.RemoveAt(deletedindex);
                            yi2search.RemoveAt(deletedindex);
                            yi2warning.RemoveAt(deletedindex);
                            statusholder.RemoveAt(deletedindex);

                            TextBox Search = FilterGroupBox.Controls[sorthold + 5] as TextBox;

                            Search.TextChanged -= StatusNameSearchTextbox_TextChanged;
                            Search.TextChanged += new EventHandler(this.SkillNameSearchTextbox_TextChanged);
                            skillflip = true;
                            Search.Clear();
                            skillflip = false;

                            ListBox SearchList = FilterGroupBox.Controls[sorthold + 6] as ListBox;

                            SearchList.Items.Clear();
                        }

                        yholder.Add(new List<int>());
                        yiholder.Add(new List<List<int>>());
                        yilength.Add(0);
                        yilength2.Add(0);
                        yisearch.Add("");
                        yiwarning.Add(false);
                        skillholder.Add(sorthold + 6);

                        yiholder[yiholder.Count - 1].Add(new List<int>());
                        for (int x = 0; x < MainForm.skillname.Count; x++)
                        {
                            yiholder[yiholder.Count - 1][0].Add(x);
                        }

                        SubCategory.SelectedIndex = 0;
                        break;
                    case 9:
                        SubCategory.Items.Clear();
                        SubCategory.Items.AddRange(new string[] { "Give Status", "Set Bonus" });
                        if (indexhold[sorthold] == 0 || indexhold[sorthold] == 1 || (indexhold[sorthold] == 2 && (indexhold[sorthold2] == 7 || indexhold[sorthold2] == 8)))
                        {
                            SubCategory.Size = new Size(157, 21);

                            FilterListBox.Add(new ListBox());
                            FilterGroupBox.Controls.Add(FilterListBox[FilterListBox.Count - 1]);
                            FilterListBox[FilterListBox.Count - 1].Location = new Point(6, Category.Location.Y + 51);
                            FilterListBox[FilterListBox.Count - 1].Size = new Size(388, 100);
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 2);
                            indexhold.Insert(sorthold + 2, 0);

                            FilterTextBox.Add(new TextBox());
                            FilterGroupBox.Controls.Add(FilterTextBox[FilterTextBox.Count - 1]);
                            FilterTextBox[FilterTextBox.Count - 1].Location = new Point(95, Category.Location.Y + 26);
                            FilterTextBox[FilterTextBox.Count - 1].Size = new Size(299, 21);
                            FilterTextBox[FilterTextBox.Count - 1].TextChanged += new EventHandler(this.StatusNameSearchTextbox_TextChanged);
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 2);
                            indexhold.Insert(sorthold + 2, 0);

                            FilterLabel.Add(new Label());
                            FilterGroupBox.Controls.Add(FilterLabel[FilterLabel.Count - 1]);
                            FilterLabel[FilterLabel.Count - 1].Location = new Point(5, Category.Location.Y + 29);
                            FilterLabel[FilterLabel.Count - 1].Text = "Search By Name:";
                            FilterLabel[FilterLabel.Count - 1].AutoSize = true;
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 2);
                            indexhold.Insert(sorthold + 2, 0);

                            FilterTextBox.Add(new TextBox());
                            FilterGroupBox.Controls.Add(FilterTextBox[FilterTextBox.Count - 1]);
                            FilterTextBox[FilterTextBox.Count - 1].Location = new Point(298, Category.Location.Y);
                            FilterTextBox[FilterTextBox.Count - 1].Size = new Size(96, 21);
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 2);
                            indexhold.Insert(sorthold + 2, 0);

                            FilterCombo.Add(new ComboBox());
                            FilterGroupBox.Controls.Add(FilterCombo[FilterCombo.Count - 1]);
                            FilterCombo[FilterCombo.Count - 1].Items.AddRange(new string[] { ">", ">=", "==", "<=", "<", "!=" });
                            FilterCombo[FilterCombo.Count - 1].SelectedIndex = 0;
                            FilterCombo[FilterCombo.Count - 1].Location = new Point(257, Category.Location.Y);
                            FilterCombo[FilterCombo.Count - 1].Size = new Size(36, 21);
                            FilterCombo[FilterCombo.Count - 1].DropDownStyle = ComboBoxStyle.DropDownList;
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 2);
                            indexhold.Insert(sorthold + 2, 0);

                            TextBox Value = FilterGroupBox.Controls[sorthold + 3] as TextBox;
                            Value.KeyPress += new KeyPressEventHandler(this.ValueTextbox_KeyPress);
                            Value.ShortcutsEnabled = false;
                            Value.Text = "0";

                            sizeincrease = true;

                            indexshiftpoint = sorthold + 6;
                            indexshiftamount = 5;
                        }
                        else if (indexhold[sorthold] == 10)
                        {
                            ComboBox Comparison = FilterGroupBox.Controls[sorthold + 2] as ComboBox;
                            Comparison.Items.Clear();
                            Comparison.Items.AddRange(new string[] { ">", ">=", "==", "<=", "<", "!=" });
                            Comparison.SelectedIndex = 0;
                            Comparison.Location = new Point(257, Category.Location.Y);
                            Comparison.Size = new Size(36, 21);

                            FilterListBox.Add(new ListBox());
                            FilterGroupBox.Controls.Add(FilterListBox[FilterListBox.Count - 1]);
                            FilterListBox[FilterListBox.Count - 1].Location = new Point(6, Category.Location.Y + 51);
                            FilterListBox[FilterListBox.Count - 1].Size = new Size(388, 100);
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 3);
                            indexhold.Insert(sorthold + 2, 0);

                            FilterTextBox.Add(new TextBox());
                            FilterGroupBox.Controls.Add(FilterTextBox[FilterTextBox.Count - 1]);
                            FilterTextBox[FilterTextBox.Count - 1].Location = new Point(95, Category.Location.Y + 26);
                            FilterTextBox[FilterTextBox.Count - 1].Size = new Size(299, 21);
                            FilterTextBox[FilterTextBox.Count - 1].TextChanged += new EventHandler(this.StatusNameSearchTextbox_TextChanged);
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 3);
                            indexhold.Insert(sorthold + 2, 0);

                            FilterLabel.Add(new Label());
                            FilterGroupBox.Controls.Add(FilterLabel[FilterLabel.Count - 1]);
                            FilterLabel[FilterLabel.Count - 1].Location = new Point(5, Category.Location.Y + 29);
                            FilterLabel[FilterLabel.Count - 1].Text = "Search By Name:";
                            FilterLabel[FilterLabel.Count - 1].AutoSize = true;
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 3);
                            indexhold.Insert(sorthold + 2, 0);

                            FilterTextBox.Add(new TextBox());
                            FilterGroupBox.Controls.Add(FilterTextBox[FilterTextBox.Count - 1]);
                            FilterTextBox[FilterTextBox.Count - 1].Location = new Point(298, Category.Location.Y);
                            FilterTextBox[FilterTextBox.Count - 1].Size = new Size(96, 21);
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 3);
                            indexhold.Insert(sorthold + 2, 0);

                            TextBox Value = FilterGroupBox.Controls[sorthold + 3] as TextBox;
                            Value.KeyPress += new KeyPressEventHandler(this.ValueTextbox_KeyPress);
                            Value.ShortcutsEnabled = false;
                            Value.Text = "0";

                            sizeincrease = true;

                            indexshiftpoint = sorthold + 6;
                            indexshiftamount = 4;
                        }
                        else if (indexhold[sorthold] != 8)
                        {
                            if (indexhold[sorthold] == 6 && indexhold[sorthold2] == 4)
                            {
                                Category.Size = new Size(84, 21);
                                SubCategory.Size = new Size(157, 21);
                                SubCategory.Location = new Point(95, Category.Location.Y);

                                FilterGroupBox.Controls.RemoveAt(sorthold2 + 1);
                                indexhold.RemoveAt(sorthold2 + 1);
                                indexshiftpoint = sorthold2 + 5;
                                indexshiftamount = -1;
                            }

                            FilterListBox.Add(new ListBox());
                            FilterGroupBox.Controls.Add(FilterListBox[FilterListBox.Count - 1]);
                            FilterListBox[FilterListBox.Count - 1].Location = new Point(6, Category.Location.Y + 51);
                            FilterListBox[FilterListBox.Count - 1].Size = new Size(388, 100);
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 4);
                            indexhold.Insert(sorthold + 4, 0);

                            FilterTextBox.Add(new TextBox());
                            FilterGroupBox.Controls.Add(FilterTextBox[FilterTextBox.Count - 1]);
                            FilterTextBox[FilterTextBox.Count - 1].Location = new Point(95, Category.Location.Y + 26);
                            FilterTextBox[FilterTextBox.Count - 1].Size = new Size(299, 21);
                            FilterTextBox[FilterTextBox.Count - 1].TextChanged += new EventHandler(this.StatusNameSearchTextbox_TextChanged);
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 4);
                            indexhold.Insert(sorthold + 2, 0);

                            FilterLabel.Add(new Label());
                            FilterGroupBox.Controls.Add(FilterLabel[FilterLabel.Count - 1]);
                            FilterLabel[FilterLabel.Count - 1].Location = new Point(5, Category.Location.Y + 29);
                            FilterLabel[FilterLabel.Count - 1].Text = "Search By Name:";
                            FilterLabel[FilterLabel.Count - 1].AutoSize = true;
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 4);
                            indexhold.Insert(sorthold + 2, 0);

                            sizeincrease = true;

                            indexshiftpoint = sorthold + 6;
                            indexshiftamount = 3;
                        }
                        else
                        {
                            int deletedindex = indexhold[sorthold + 6];
                            yholder.RemoveAt(deletedindex);
                            yiholder.RemoveAt(deletedindex);
                            yilength.RemoveAt(deletedindex);
                            yilength2.RemoveAt(deletedindex);
                            yisearch.RemoveAt(deletedindex);
                            yiwarning.RemoveAt(deletedindex);
                            skillholder.RemoveAt(deletedindex);

                            TextBox Search = FilterGroupBox.Controls[sorthold + 5] as TextBox;

                            Search.TextChanged -= SkillNameSearchTextbox_TextChanged;
                            Search.TextChanged += new EventHandler(this.StatusNameSearchTextbox_TextChanged);
                            statusflip = true;
                            Search.Clear();
                            statusflip = false;

                            ListBox SearchList = FilterGroupBox.Controls[sorthold + 6] as ListBox;

                            SearchList.Items.Clear();
                        }

                        yholder3.Add(new List<int>());
                        yi2holder.Add(new List<List<int>>());
                        yi2length.Add(0);
                        yi2length2.Add(0);
                        yi2search.Add("");
                        yi2warning.Add(false);
                        statusholder.Add(sorthold + 6);

                        yi2holder[yi2holder.Count - 1].Add(new List<int>());
                        for (int x = 0; x < MainForm.statusname.Count; x++)
                        {
                            yi2holder[yi2holder.Count - 1][0].Add(x);
                        }

                        SubCategory.SelectedIndex = 0;
                        break;
                    case 10:
                        SubCategory.Items.Clear();
                        SubCategory.Items.AddRange(new string[] { "Important Item", "Binds on Equip", "NO TRADE", "Stackable" });
                        if (indexhold[sorthold] == 0 || indexhold[sorthold] == 1 || (indexhold[sorthold] == 2 && (indexhold[sorthold2] == 7 || indexhold[sorthold2] == 8)))
                        {
                            SubCategory.Size = new Size(157, 21);

                            FilterCombo.Add(new ComboBox());
                            FilterGroupBox.Controls.Add(FilterCombo[FilterCombo.Count - 1]);
                            FilterCombo[FilterCombo.Count - 1].Items.AddRange(new string[] { "True", "False" });
                            FilterCombo[FilterCombo.Count - 1].SelectedIndex = 0;
                            FilterCombo[FilterCombo.Count - 1].Location = new Point(257, Category.Location.Y);
                            FilterCombo[FilterCombo.Count - 1].Size = new Size(137, 21);
                            FilterCombo[FilterCombo.Count - 1].DropDownStyle = ComboBoxStyle.DropDownList;
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 2);
                            indexhold.Insert(sorthold + 2, 0);

                            indexshiftpoint = sorthold + 3;
                            indexshiftamount = 1;
                        }
                        else if (indexhold[sorthold] == 8 || indexhold[sorthold] == 9)
                        {
                            if (indexhold[sorthold] == 9 && indexhold[sorthold2] == 1)
                            {
                                int deletedindex = indexhold[sorthold + 4];
                                for (int i = deletedindex + 1; i < setholder.Count; i++)
                                {
                                    indexhold[setholder[i]] = setholder[i] - 1;
                                }
                                yholder4.RemoveAt(deletedindex);
                                yi3holder.RemoveAt(deletedindex);
                                yi3length.RemoveAt(deletedindex);
                                yi3length2.RemoveAt(deletedindex);
                                yi3search.RemoveAt(deletedindex);
                                yi3warning.RemoveAt(deletedindex);
                                setholder.RemoveAt(deletedindex);

                                FilterGroupBox.Controls.RemoveAt(sorthold + 2);
                                FilterGroupBox.Controls.RemoveAt(sorthold + 2);
                                FilterGroupBox.Controls.RemoveAt(sorthold + 2);
                                indexhold.RemoveAt(sorthold + 2);
                                indexhold.RemoveAt(sorthold + 2);
                                indexhold.RemoveAt(sorthold + 2);
                                indexshiftpoint = sorthold + 3;
                                indexshiftamount = -3;

                                SubCategory.Size = new Size(157, 21);

                                FilterCombo.Add(new ComboBox());
                                FilterGroupBox.Controls.Add(FilterCombo[FilterCombo.Count - 1]);
                                FilterCombo[FilterCombo.Count - 1].Items.AddRange(new string[] { "True", "False" });
                                FilterCombo[FilterCombo.Count - 1].SelectedIndex = 0;
                                FilterCombo[FilterCombo.Count - 1].Location = new Point(257, Category.Location.Y);
                                FilterCombo[FilterCombo.Count - 1].Size = new Size(137, 21);
                                FilterCombo[FilterCombo.Count - 1].DropDownStyle = ComboBoxStyle.DropDownList;
                                FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold + 2);
                                indexhold.Insert(sorthold + 2, 0);

                                indexshiftpoint = sorthold + 3;
                                indexshiftamount = 1;
                            }
                            else
                            {
                                if (indexhold[sorthold] == 8)
                                {
                                    int deletedindex = indexhold[sorthold + 6];
                                    yholder.RemoveAt(deletedindex);
                                    yiholder.RemoveAt(deletedindex);
                                    yilength.RemoveAt(deletedindex);
                                    yilength2.RemoveAt(deletedindex);
                                    yisearch.RemoveAt(deletedindex);
                                    yiwarning.RemoveAt(deletedindex);
                                    skillholder.RemoveAt(deletedindex);
                                }
                                else if (indexhold[sorthold] == 9 && indexhold[sorthold2] == 0)
                                {
                                    int deletedindex = indexhold[sorthold + 6];
                                    for (int i = deletedindex + 1; i < statusholder.Count; i++)
                                    {
                                        indexhold[statusholder[i]] = statusholder[i] - 1;
                                    }
                                    yholder3.RemoveAt(deletedindex);
                                    yi2holder.RemoveAt(deletedindex);
                                    yi2length.RemoveAt(deletedindex);
                                    yi2length2.RemoveAt(deletedindex);
                                    yi2search.RemoveAt(deletedindex);
                                    yi2warning.RemoveAt(deletedindex);
                                    statusholder.RemoveAt(deletedindex);
                                }

                                ComboBox Comparison = FilterGroupBox.Controls[sorthold + 2] as ComboBox;
                                Comparison.Items.Clear();
                                Comparison.Items.AddRange(new string[] { "True", "False" });
                                Comparison.SelectedIndex = 0;
                                Comparison.Location = new Point(257, Category.Location.Y);
                                Comparison.Size = new Size(137, 21);

                                FilterGroupBox.Controls.RemoveAt(sorthold + 3);
                                FilterGroupBox.Controls.RemoveAt(sorthold + 3);
                                FilterGroupBox.Controls.RemoveAt(sorthold + 3);
                                FilterGroupBox.Controls.RemoveAt(sorthold + 3);
                                indexhold.RemoveAt(sorthold + 3);
                                indexhold.RemoveAt(sorthold + 3);
                                indexhold.RemoveAt(sorthold + 3);
                                indexhold.RemoveAt(sorthold + 3);
                                indexshiftpoint = sorthold + 3;
                                indexshiftamount = -4;
                            }
                            sizedecrease = true;
                        }
                        else
                        {
                            if (indexhold[sorthold] == 6 && indexhold[sorthold2] == 4)
                            {
                                Category.Size = new Size(84, 21);
                                SubCategory.Size = new Size(157, 21);
                                SubCategory.Location = new Point(95, Category.Location.Y);

                                FilterGroupBox.Controls.RemoveAt(sorthold2 + 1);
                                indexhold.RemoveAt(sorthold2 + 1);
                                indexshiftpoint = sorthold2 + 2;
                                indexshiftamount = -1;
                            }

                            ComboBox Comparison = FilterGroupBox.Controls[sorthold + 2] as ComboBox;
                            Comparison.Items.Clear();
                            Comparison.Items.AddRange(new string[] { "True", "False" });
                            Comparison.SelectedIndex = 0;
                            Comparison.Location = new Point(257, Category.Location.Y);
                            Comparison.Size = new Size(137, 21);

                            FilterGroupBox.Controls.RemoveAt(sorthold + 3);
                            indexhold.RemoveAt(sorthold + 3);
                            indexshiftamount = indexshiftamount - 1;
                        }
                        SubCategory.SelectedIndex = 0;
                        break;
                }
                if (sizeincrease == true)
                {
                    vertical = vertical + 125;
                    for (int i = sorthold + 7; i < FilterGroupBox.Controls.Count; i++)
                    {
                        FilterGroupBox.Controls[i].Location = new Point(FilterGroupBox.Controls[i].Location.X, FilterGroupBox.Controls[i].Location.Y + 125);
                    }
                }
                else if (sizedecrease == true)
                {
                    vertical = vertical - 125;
                    int indexvariable;
                    switch (Category.SelectedIndex)
                    {
                        case 0:
                        case 1:
                            indexvariable = 2;
                            break;
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                            indexvariable = 4;
                            break;
                        default: // 10
                            indexvariable = 3;
                            break;
                    }
                    for (int i = sorthold + indexvariable; i < FilterGroupBox.Controls.Count; i++)
                    {
                        FilterGroupBox.Controls[i].Location = new Point(FilterGroupBox.Controls[i].Location.X, FilterGroupBox.Controls[i].Location.Y - 125);
                    }
                }
                for (int i = 0; i < skillholder.Count; i++)
                {
                    if (skillholder[i] > indexshiftpoint)
                    {
                        skillholder[i] = skillholder[i] + indexshiftamount;
                    }
                }
                for (int i = 0; i < statusholder.Count; i++)
                {
                    if (statusholder[i] > indexshiftpoint)
                    {
                        statusholder[i] = statusholder[i] + indexshiftamount;
                    }
                }
                for (int i = 0; i < setholder.Count; i++)
                {
                    if (setholder[i] > indexshiftpoint)
                    {
                        setholder[i] = setholder[i] + indexshiftamount;
                    }
                }
                for (int i = 0; i < categoryholder.Count; i++)
                {
                    if (categoryholder[i] > sorthold)
                    {
                        categoryholder[i] = categoryholder[i] + indexshiftamount;
                    }
                }
                indexhold[sorthold] = Category.SelectedIndex;
            }
        }

        private void VariableSubComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            sorthold2 = FilterGroupBox.Controls.IndexOf((ComboBox)sender);
            ComboBox SubCategory = FilterGroupBox.Controls[sorthold2] as ComboBox;
            if (indexhold[sorthold2] != SubCategory.SelectedIndex) // only act if the sort type changes, no reason otherwise
            {
                int indexshiftpoint = 0;
                int indexshiftamount = 0;
                ComboBox Category = FilterGroupBox.Controls[sorthold2 - 1] as ComboBox;
                switch (Category.SelectedIndex)
                {
                    case 2:
                        if (indexhold[sorthold2] == 7 || indexhold[sorthold2] == 8)
                        {
                            if (SubCategory.SelectedIndex != 7 && SubCategory.SelectedIndex != 8)
                            {
                                SubCategory.Size = new Size(157, 21);

                                FilterTextBox.Add(new TextBox());
                                FilterGroupBox.Controls.Add(FilterTextBox[FilterTextBox.Count - 1]);
                                FilterTextBox[FilterTextBox.Count - 1].Location = new Point(298, Category.Location.Y);
                                FilterTextBox[FilterTextBox.Count - 1].Size = new Size(96, 21);
                                FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold2 + 1);
                                indexhold.Insert(sorthold2 + 1, 0);

                                FilterCombo.Add(new ComboBox());
                                FilterGroupBox.Controls.Add(FilterCombo[FilterCombo.Count - 1]);
                                FilterCombo[FilterCombo.Count - 1].Items.AddRange(new string[] { ">", ">=", "==", "<=", "<", "!=" });
                                FilterCombo[FilterCombo.Count - 1].SelectedIndex = 0;
                                FilterCombo[FilterCombo.Count - 1].Location = new Point(257, Category.Location.Y);
                                FilterCombo[FilterCombo.Count - 1].Size = new Size(36, 21);
                                FilterCombo[FilterCombo.Count - 1].DropDownStyle = ComboBoxStyle.DropDownList;
                                FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold2 + 1);
                                indexhold.Insert(sorthold2 + 1, 0);

                                TextBox Value = FilterGroupBox.Controls[sorthold + 3] as TextBox;
                                Value.KeyPress += new KeyPressEventHandler(this.ValueTextbox_KeyPress);
                                Value.ShortcutsEnabled = false;
                                Value.Text = "0";

                                indexshiftpoint = sorthold2 + 2;
                                indexshiftamount = 2;
                            }
                        }
                        else
                        {
                            if (SubCategory.SelectedIndex == 7 || SubCategory.SelectedIndex == 8)
                            {
                                FilterGroupBox.Controls.RemoveAt(sorthold2 + 1);
                                FilterGroupBox.Controls.RemoveAt(sorthold2 + 1);
                                indexhold.RemoveAt(sorthold2 + 1);
                                indexhold.RemoveAt(sorthold2 + 1);
                                SubCategory.Size = new Size(299, 21);
                                indexshiftpoint = sorthold2 + 1;
                                indexshiftamount = -2;
                            }
                        }
                        break;
                    case 6:
                        if (indexhold[sorthold2] == 4) // no second check needed because an if statement above blocks out using the same index
                        {
                            Category.Size = new Size(84, 21);
                            SubCategory.Size = new Size(157, 21);
                            SubCategory.Location = new Point(95, Category.Location.Y);

                            FilterGroupBox.Controls.RemoveAt(sorthold2 + 1);
                            indexhold.RemoveAt(sorthold2 + 1);
                            indexshiftpoint = sorthold2 + 2;
                            indexshiftamount = -1;
                        }
                        else
                        {
                            if (SubCategory.SelectedIndex == 4)
                            {
                                Category.Size = new Size(50, 21);
                                SubCategory.Size = new Size(66, 21);
                                SubCategory.Location = new Point(61, Category.Location.Y);

                                FilterCombo.Add(new ComboBox());
                                FilterGroupBox.Controls.Add(FilterCombo[FilterCombo.Count - 1]);
                                FilterCombo[FilterCombo.Count - 1].Items.AddRange(new string[] { "Sword", "Blunt", "Axe", "Staff", "Dagger", "Wand", "Bow", "Melee Combat", "Ranged Combat", "Physical Fitness", "Nature Magic", "Cunning", "Ice Magic", "Fire Magic", "First Aid", "Spear", "Totem", "Novelty", "Hand to Hand", "Fortitude", "Warding", "Reflex", "Vigour", "Willpower", "Dog Taming", "Rabbit Taming", "Fishing", "Bear Taming", "Spirit Taming", "Critical Strike", "Critical Skills", "Treasure Hunter", "Scholar", "Wolf Taming", "Spider Taming", "Boar Taming", "Wolf Taming", "Bear Taming", "Cooking Proficiency", "Cooking Mastery", "Dragon Taming", "Chicken Taming", "Horse Riding", "Elk Riding", "Eagle Taming", "Phoenix Taming", "Tiger Riding", "Pig Taming", "Seedling Taming", "Hellsteed Riding", "Reindeer Taming", "Imp Taming" });
                                FilterCombo[FilterCombo.Count - 1].SelectedIndex = 0;
                                FilterCombo[FilterCombo.Count - 1].Location = new Point(132, Category.Location.Y);
                                FilterCombo[FilterCombo.Count - 1].Size = new Size(120, 21);
                                FilterCombo[FilterCombo.Count - 1].DropDownStyle = ComboBoxStyle.DropDownList;
                                FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold2 + 1);
                                indexhold.Insert(sorthold2 + 1, 0);

                                indexshiftpoint = sorthold2 + 3;
                                indexshiftamount = 1;
                            }
                        }
                        break;
                    case 9:
                        if (indexhold[sorthold2] == 1) // same as above
                        {
                            int deletedindex = indexhold[sorthold + 4];
                            for (int i = deletedindex + 1; i < setholder.Count; i++)
                            {
                                indexhold[setholder[i]] = setholder[i] - 1;
                            }
                            yholder4.RemoveAt(deletedindex);
                            yi3holder.RemoveAt(deletedindex);
                            yi3length.RemoveAt(deletedindex);
                            yi3length2.RemoveAt(deletedindex);
                            yi3search.RemoveAt(deletedindex);
                            yi3warning.RemoveAt(deletedindex);
                            setholder.RemoveAt(deletedindex);

                            SubCategory.Size = new Size(157, 21);

                            FilterTextBox.Add(new TextBox());
                            FilterGroupBox.Controls.Add(FilterTextBox[FilterTextBox.Count - 1]);
                            FilterTextBox[FilterTextBox.Count - 1].Location = new Point(298, Category.Location.Y);
                            FilterTextBox[FilterTextBox.Count - 1].Size = new Size(96, 21);
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold2 + 1);
                            indexhold.Insert(sorthold2 + 1, 0);

                            FilterCombo.Add(new ComboBox());
                            FilterGroupBox.Controls.Add(FilterCombo[FilterCombo.Count - 1]);
                            FilterCombo[FilterCombo.Count - 1].Items.AddRange(new string[] { ">", ">=", "==", "<=", "<", "!=" });
                            FilterCombo[FilterCombo.Count - 1].SelectedIndex = 0;
                            FilterCombo[FilterCombo.Count - 1].Location = new Point(257, Category.Location.Y);
                            FilterCombo[FilterCombo.Count - 1].Size = new Size(36, 21);
                            FilterCombo[FilterCombo.Count - 1].DropDownStyle = ComboBoxStyle.DropDownList;
                            FilterGroupBox.Controls.SetChildIndex(FilterGroupBox.Controls[FilterGroupBox.Controls.Count - 1], sorthold2 + 1);
                            indexhold.Insert(sorthold2 + 1, 0);

                            TextBox Value = FilterGroupBox.Controls[sorthold + 3] as TextBox;
                            Value.KeyPress += new KeyPressEventHandler(this.ValueTextbox_KeyPress);
                            Value.ShortcutsEnabled = false;
                            Value.Text = "0";

                            indexshiftpoint = sorthold2 + 5;
                            indexshiftamount = 2;

                            TextBox Search = FilterGroupBox.Controls[sorthold + 5] as TextBox;

                            ListBox SearchList = FilterGroupBox.Controls[sorthold + 6] as ListBox;

                            SearchList.Items.Clear();

                            Search.TextChanged -= SetNameSearchTextbox_TextChanged;
                            Search.TextChanged += new EventHandler(this.StatusNameSearchTextbox_TextChanged);
                            statusflip = true;
                            Search.Clear();
                            statusflip = false;

                            yholder3.Add(new List<int>());
                            yi2holder.Add(new List<List<int>>());
                            yi2length.Add(0);
                            yi2length2.Add(0);
                            yi2search.Add("");
                            yi2warning.Add(false);
                            statusholder.Add(sorthold + 6);

                            yi2holder[yi2holder.Count - 1].Add(new List<int>());
                            for (int x = 0; x < MainForm.statusname.Count; x++)
                            {
                                yi2holder[yi2holder.Count - 1][0].Add(x);
                            }
                        }
                        else
                        {
                            if (SubCategory.SelectedIndex == 1)
                            {
                                int deletedindex = indexhold[sorthold + 6];
                                for (int i = deletedindex + 1; i < statusholder.Count; i++)
                                {
                                    indexhold[statusholder[i]] = statusholder[i] - 1;
                                }
                                yholder3.RemoveAt(deletedindex);
                                yi2holder.RemoveAt(deletedindex);
                                yi2length.RemoveAt(deletedindex);
                                yi2length2.RemoveAt(deletedindex);
                                yi2search.RemoveAt(deletedindex);
                                yi2warning.RemoveAt(deletedindex);
                                statusholder.RemoveAt(deletedindex);

                                TextBox Search = FilterGroupBox.Controls[sorthold + 5] as TextBox;

                                ListBox SearchList = FilterGroupBox.Controls[sorthold + 6] as ListBox;

                                SearchList.Items.Clear();

                                Search.TextChanged -= StatusNameSearchTextbox_TextChanged;
                                Search.TextChanged += new EventHandler(this.SetNameSearchTextbox_TextChanged);
                                setflip = true;
                                Search.Clear();
                                setflip = false;

                                FilterGroupBox.Controls.RemoveAt(sorthold2 + 1);
                                FilterGroupBox.Controls.RemoveAt(sorthold2 + 1);
                                indexhold.RemoveAt(sorthold2 + 1);
                                indexhold.RemoveAt(sorthold2 + 1);
                                indexshiftpoint = sorthold2 + 3;
                                indexshiftamount = -2;
                                SubCategory.Size = new Size(299, 21);

                                yholder4.Add(new List<int>());
                                yi3holder.Add(new List<List<int>>());
                                yi3length.Add(0);
                                yi3length2.Add(0);
                                yi3search.Add("");
                                yi3warning.Add(false);
                                setholder.Add(sorthold + 4);

                                yi3holder[yi3holder.Count - 1].Add(new List<int>());
                                for (int x = 0; x < itemsetrewarditemname.Count; x++)
                                {
                                    yi3holder[yi3holder.Count - 1][0].Add(x);
                                }
                            }
                        }
                        break;
                }
                for (int i = 0; i < skillholder.Count; i++)
                {
                    if (skillholder[i] > indexshiftpoint)
                    {
                        skillholder[i] = skillholder[i] + indexshiftamount;
                    }
                }
                for (int i = 0; i < statusholder.Count; i++)
                {
                    if (statusholder[i] > indexshiftpoint)
                    {
                        statusholder[i] = statusholder[i] + indexshiftamount;
                    }
                }
                for (int i = 0; i < setholder.Count; i++)
                {
                    if (setholder[i] > indexshiftpoint)
                    {
                        setholder[i] = setholder[i] + indexshiftamount;
                    }
                }
                for (int i = 0; i < categoryholder.Count; i++)
                {
                    if (categoryholder[i] > sorthold2 - 1)
                    {
                        categoryholder[i] = categoryholder[i] + indexshiftamount;
                    }
                }
                indexhold[sorthold2] = SubCategory.SelectedIndex;
            }
        }

        private void SkillNameSearchTextbox_TextChanged(object sender, EventArgs e)
        {
            if (skillflip == false)
            {
                sorthold3 = FilterGroupBox.Controls.IndexOf((TextBox)sender);
                ListBox SkillList = FilterGroupBox.Controls[sorthold3 + 1] as ListBox;
                int dataindex = indexhold[sorthold3 + 1];
                SkillList.Items.Clear();
                yholder[dataindex].Clear();
                SkillList.BeginUpdate();
                TextBox SkillSearch = FilterGroupBox.Controls[sorthold3] as TextBox;
                yilength2[dataindex] = SkillSearch.Text.Length - yilength[dataindex];
                if (string.IsNullOrEmpty(yisearch[dataindex]) == false)
                {
                    if (yisearch[dataindex].Length > SkillSearch.Text.Length)
                    {
                        if (yisearch[dataindex].Substring(0, SkillSearch.Text.Length) != SkillSearch.Text)
                        {
                            yiwarning[dataindex] = true;
                        }
                    }
                    else
                    {
                        if (SkillSearch.Text.Substring(0, yisearch[dataindex].Length) != yisearch[dataindex])
                        {
                            yiwarning[dataindex] = true;
                        }
                    }
                }
                if (yilength[dataindex] > SkillSearch.Text.Length && yiwarning[dataindex] == false)
                {
                    for (int i = 0; i < yiholder[dataindex][SkillSearch.Text.Length].Count; i++)
                    {
                        if (MainForm.skillname[yiholder[dataindex][SkillSearch.Text.Length][i]].ToUpper().Contains(SkillSearch.Text.ToUpper()))
                        {
                            SkillList.Items.Add(MainForm.skillname[yiholder[dataindex][SkillSearch.Text.Length][i]]);
                            yholder[dataindex].Add(yiholder[dataindex][SkillSearch.Text.Length][i]);
                        }
                    }
                    yiholder[dataindex].RemoveRange(SkillSearch.Text.Length + 1, yilength[dataindex] - SkillSearch.Text.Length);
                    yilength[dataindex] = SkillSearch.Text.Length;
                }
                else
                {
                    if (yiwarning[dataindex] == true)
                    {
                        yilength[dataindex] = 0;
                        yiholder[dataindex].RemoveRange(1, yiholder[dataindex].Count - 1);
                    }
                    yilength2[dataindex] = yilength[dataindex];
                    for (int a = 0; a < SkillSearch.Text.Length - yilength2[dataindex]; a++)
                    {
                        yiholder[dataindex].Add(new List<int>());
                        for (int i = 0; i < yiholder[dataindex][yilength[dataindex]].Count; i++)
                        {
                            if (MainForm.skillname[yiholder[dataindex][yilength[dataindex]][i]].ToUpper().Contains(SkillSearch.Text.Substring(0, yilength[dataindex] + 1).ToUpper()))
                            {
                                yiholder[dataindex][yilength[dataindex] + 1].Add(yiholder[dataindex][yilength[dataindex]][i]);
                            }
                        }
                        yilength[dataindex] = yilength[dataindex] + 1;
                    }
                    yholder[dataindex].Clear();
                    for (int i = 0; i < yiholder[dataindex][yilength[dataindex]].Count; i++)
                    {
                        yholder[dataindex].Add(yiholder[dataindex][yilength[dataindex]][i]);
                        SkillList.Items.Add(MainForm.skillname[yiholder[dataindex][yilength[dataindex]][i]]);
                    }
                }
                SkillList.EndUpdate();
                yisearch[dataindex] = SkillSearch.Text;
                yiwarning[dataindex] = false;
            }
        }

        private void StatusNameSearchTextbox_TextChanged(object sender, EventArgs e)
        {
            if (statusflip == false)
            {
                sorthold4 = FilterGroupBox.Controls.IndexOf((TextBox)sender);
                ListBox StatusList = FilterGroupBox.Controls[sorthold4 + 1] as ListBox;
                int dataindex = indexhold[sorthold4 + 1];
                StatusList.Items.Clear();
                yholder3[dataindex].Clear();
                StatusList.BeginUpdate();
                TextBox StatusSearch = FilterGroupBox.Controls[sorthold4] as TextBox;
                yi2length2[dataindex] = StatusSearch.Text.Length - yi2length[dataindex];
                if (string.IsNullOrEmpty(yi2search[dataindex]) == false)
                {
                    if (yi2search[dataindex].Length > StatusSearch.Text.Length)
                    {
                        if (yi2search[dataindex].Substring(0, StatusSearch.Text.Length) != StatusSearch.Text)
                        {
                            yi2warning[dataindex] = true;
                        }
                    }
                    else
                    {
                        if (StatusSearch.Text.Substring(0, yi2search[dataindex].Length) != yi2search[dataindex])
                        {
                            yi2warning[dataindex] = true;
                        }
                    }
                }
                if (yi2length[dataindex] > StatusSearch.Text.Length && yi2warning[dataindex] == false)
                {
                    for (int i = 0; i < yi2holder[dataindex][StatusSearch.Text.Length].Count; i++)
                    {
                        if (MainForm.statusname[yi2holder[dataindex][StatusSearch.Text.Length][i]].ToUpper().Contains(StatusSearch.Text.ToUpper()))
                        {
                            StatusList.Items.Add(MainForm.statusname[yi2holder[dataindex][StatusSearch.Text.Length][i]]);
                            yholder3[dataindex].Add(yi2holder[dataindex][StatusSearch.Text.Length][i]);
                        }
                    }
                    yi2holder[dataindex].RemoveRange(StatusSearch.Text.Length + 1, yi2length[dataindex] - StatusSearch.Text.Length);
                    yi2length[dataindex] = StatusSearch.Text.Length;
                }
                else
                {
                    if (yi2warning[dataindex] == true)
                    {
                        yi2length[dataindex] = 0;
                        yi2holder[dataindex].RemoveRange(1, yi2holder[dataindex].Count - 1);
                    }
                    yi2length2[dataindex] = yi2length[dataindex];
                    for (int a = 0; a < StatusSearch.Text.Length - yi2length2[dataindex]; a++)
                    {
                        yi2holder[dataindex].Add(new List<int>());
                        for (int i = 0; i < yi2holder[dataindex][yi2length[dataindex]].Count; i++)
                        {
                            if (MainForm.statusname[yi2holder[dataindex][yi2length[dataindex]][i]].ToUpper().Contains(StatusSearch.Text.Substring(0, yi2length[dataindex] + 1).ToUpper()))
                            {
                                yi2holder[dataindex][yi2length[dataindex] + 1].Add(yi2holder[dataindex][yi2length[dataindex]][i]);
                            }
                        }
                        yi2length[dataindex] = yi2length[dataindex] + 1;
                    }
                    for (int i = 0; i < yi2holder[dataindex][yi2length[dataindex]].Count; i++)
                    {
                        yholder3[dataindex].Add(yi2holder[dataindex][yi2length[dataindex]][i]);
                        StatusList.Items.Add(MainForm.statusname[yi2holder[dataindex][yi2length[dataindex]][i]]);
                    }
                }
                StatusList.EndUpdate();
                yi2search[dataindex] = StatusSearch.Text;
                yi2warning[dataindex] = false;
            }
        }

        private void SetNameSearchTextbox_TextChanged(object sender, EventArgs e)
        {
            if (setflip == false)
            {
                sorthold5 = FilterGroupBox.Controls.IndexOf((TextBox)sender);
                ListBox SetList = FilterGroupBox.Controls[sorthold5 + 1] as ListBox;
                int dataindex = indexhold[sorthold5 + 1];
                SetList.Items.Clear();
                yholder4[dataindex].Clear();
                SetList.BeginUpdate();
                TextBox SetSearch = FilterGroupBox.Controls[sorthold5] as TextBox;
                yi3length2[dataindex] = SetSearch.Text.Length - yi3length[dataindex];
                if (string.IsNullOrEmpty(yi3search[dataindex]) == false)
                {
                    if (yi3search[dataindex].Length > SetSearch.Text.Length)
                    {
                        if (yi3search[dataindex].Substring(0, SetSearch.Text.Length) != SetSearch.Text)
                        {
                            yi3warning[dataindex] = true;
                        }
                    }
                    else
                    {
                        if (SetSearch.Text.Substring(0, yi3search[dataindex].Length) != yi3search[dataindex])
                        {
                            yi3warning[dataindex] = true;
                        }
                    }
                }
                if (yi3length[dataindex] > SetSearch.Text.Length && yi3warning[dataindex] == false)
                {
                    for (int i = 0; i < yi3holder[dataindex][SetSearch.Text.Length].Count; i++)
                    {
                        if (itemsetrewarditemname[yi3holder[dataindex][SetSearch.Text.Length][i]].ToUpper().Contains(SetSearch.Text.ToUpper()))
                        {
                            SetList.Items.Add(itemsetrewarditemname[yi3holder[dataindex][SetSearch.Text.Length][i]]);
                            yholder4[dataindex].Add(yi3holder[dataindex][SetSearch.Text.Length][i]);
                        }
                    }
                    yi3holder[dataindex].RemoveRange(SetSearch.Text.Length + 1, yi3length[dataindex] - SetSearch.Text.Length);
                    yi3length[dataindex] = SetSearch.Text.Length;
                }
                else
                {
                    if (yi3warning[dataindex] == true)
                    {
                        yi3length[dataindex] = 0;
                        yi3holder[dataindex].RemoveRange(1, yi3holder[dataindex].Count - 1);
                    }
                    yi3length2[dataindex] = yi3length[dataindex];
                    for (int a = 0; a < SetSearch.Text.Length - yi3length2[dataindex]; a++)
                    {
                        yi3holder[dataindex].Add(new List<int>());
                        for (int i = 0; i < yi3holder[dataindex][yi3length[dataindex]].Count; i++)
                        {
                            if (itemsetrewarditemname[yi3holder[dataindex][yi3length[dataindex]][i]].ToUpper().Contains(SetSearch.Text.Substring(0, yi3length[dataindex] + 1).ToUpper()))
                            {
                                yi3holder[dataindex][yi3length[dataindex] + 1].Add(yi3holder[dataindex][yi3length[dataindex]][i]);
                            }
                        }
                        yi3length[dataindex] = yi3length[dataindex] + 1;
                    }
                    for (int i = 0; i < yi3holder[dataindex][yi3length[dataindex]].Count; i++)
                    {
                        yholder4[dataindex].Add(yi3holder[dataindex][yi3length[dataindex]][i]);
                        SetList.Items.Add(itemsetrewarditemname[yi3holder[dataindex][yi3length[dataindex]][i]]);
                    }
                }
                SetList.EndUpdate();
                yi3search[dataindex] = SetSearch.Text;
                yi3warning[dataindex] = false;
            }
        }

        private void RemoveFilterButton_Click(object sender, EventArgs e)
        {
            if (FilterGroupBox.Controls.Count > 0)
            {
                int deletehold = categoryholder[categoryholder.Count - 1];
                ComboBox Category = FilterGroupBox.Controls[deletehold] as ComboBox;
                ComboBox SubCategory = FilterGroupBox.Controls[deletehold + 1] as ComboBox;
                switch (Category.SelectedIndex)
                {
                    case 0:
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        categoryholder.RemoveAt(categoryholder.Count - 1);
                        break;
                    case 1:
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        categoryholder.RemoveAt(categoryholder.Count - 1);
                        break;
                    case 2:
                        if (SubCategory.SelectedIndex != 7 && SubCategory.SelectedIndex != 8)
                        {
                            FilterGroupBox.Controls.RemoveAt(deletehold);
                            FilterGroupBox.Controls.RemoveAt(deletehold);
                            indexhold.RemoveAt(deletehold);
                            indexhold.RemoveAt(deletehold);
                        }
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        categoryholder.RemoveAt(categoryholder.Count - 1);
                        break;
                    case 3:
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        categoryholder.RemoveAt(categoryholder.Count - 1);
                        break;
                    case 4:
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        categoryholder.RemoveAt(categoryholder.Count - 1);
                        break;
                    case 5:
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        categoryholder.RemoveAt(categoryholder.Count - 1);
                        break;
                    case 6:
                        if (SubCategory.SelectedIndex == 4)
                        {
                            FilterGroupBox.Controls.RemoveAt(deletehold);
                            indexhold.RemoveAt(deletehold);
                        }
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        categoryholder.RemoveAt(categoryholder.Count - 1);
                        break;
                    case 7:
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        categoryholder.RemoveAt(categoryholder.Count - 1);
                        break;
                    case 8:
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        categoryholder.RemoveAt(categoryholder.Count - 1);
                        skillholder.RemoveAt(skillholder.Count - 1);
                        vertical = vertical - 125;
                        break;
                    case 9:
                        if (SubCategory.SelectedIndex == 1)
                        {
                            setholder.RemoveAt(setholder.Count - 1);
                        }
                        else
                        {
                            FilterGroupBox.Controls.RemoveAt(deletehold);
                            FilterGroupBox.Controls.RemoveAt(deletehold);
                            indexhold.RemoveAt(deletehold);
                            indexhold.RemoveAt(deletehold);
                            statusholder.RemoveAt(statusholder.Count - 1);
                        }
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        categoryholder.RemoveAt(categoryholder.Count - 1);
                        vertical = vertical - 125;
                        break;
                    case 10:
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        FilterGroupBox.Controls.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        indexhold.RemoveAt(deletehold);
                        categoryholder.RemoveAt(categoryholder.Count - 1);
                        break;
                }
                vertical = vertical - 26;
                if (FilterGroupBox.Controls.Count == 0)
                {
                    RemoveFilterButton.Enabled = false;
                    StartSearchButton.Enabled = false;
                }
            }
        }

        private void StartSearchButton_Click(object sender, EventArgs e)
        {
            string[] commasplit;
            string[] commasplit2;
            zzholder.Clear();
            zzholder.AddRange(zholder);
            for (int i = 0; i < FilterGroupBox.Controls.Count;)
            {
                int skillschecked = 0; // for counting which skillholder to use, same idea for statuses and sets
                int statuseschecked = 0;
                int setschecked = 0;
                ComboBox Category = FilterGroupBox.Controls[i] as ComboBox;
                ComboBox SubCategory = FilterGroupBox.Controls[i + 1] as ComboBox;
                switch (Category.SelectedIndex)
                {
                    case 0:
                        for (int x = 0; x < zzholder.Count; x++)
                        {
                            if (!FilterSlotValues[SubCategory.SelectedIndex].Contains(MainForm.itemequipslot[zzholder[x]]))
                            {
                                zzholder.RemoveAt(x);
                                x--;
                            }
                        }
                        i = i + 2;
                        break;
                    case 1:
                        for (int x = 0; x < zzholder.Count; x++)
                        {
                            if (SubCategory.SelectedIndex != Convert.ToInt32(MainForm.itemsubtype[zzholder[x]]))
                            {
                                zzholder.RemoveAt(x);
                                x--;
                            }
                        }
                        i = i + 2;
                        break;
                    case 2:
                        {
                            ComboBox CompareSign;
                            TextBox Value;
                            int firstvalue = 0;
                            int secondvalue = 0;
                            bool deleteflag = false; // if anything is a mismatch it will be marked for deletion so it doesnt delete more than once
                            bool valuefound = false; // value to hold if the searched variable is found in a list, if not it checks if you are searching for a value involving 0(the absence of a value would be 0 anyway, and its important to include these)
                            switch (SubCategory.SelectedIndex)
                            {
                                case 0: // primary stats
                                case 1:
                                case 2:
                                case 3:
                                    CompareSign = FilterGroupBox.Controls[i + 2] as ComboBox;
                                    Value = FilterGroupBox.Controls[i + 3] as TextBox;
                                    firstvalue = SubCategory.SelectedIndex;
                                    if (string.IsNullOrEmpty(Value.Text) || Value.Text == "-") secondvalue = 0;
                                    else secondvalue = Convert.ToInt32(Value.Text);
                                    for (int x = 0; x < zzholder.Count; x++)
                                    {
                                        if (!string.IsNullOrEmpty(MainForm.itemrequirementlist[zzholder[x]]))
                                        {
                                            valuefound = false;
                                            commasplit = MainForm.itemrequirementlist[zzholder[x]].Split(';');
                                            for (int y = 0; y < commasplit.Length; y++)
                                            {
                                                commasplit2 = commasplit[y].Split('^');
                                                if (Convert.ToInt32(commasplit2[0]) == firstvalue)
                                                {
                                                    valuefound = true;
                                                    if (VariableComparison(Convert.ToInt32(commasplit2[1]), secondvalue, CompareSign.SelectedIndex) == true)
                                                    {
                                                        deleteflag = false;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        deleteflag = true;
                                                    }
                                                }
                                                else
                                                {
                                                    deleteflag = true;
                                                }
                                            }
                                        }
                                        else deleteflag = true;
                                        if (valuefound == false)
                                        {
                                            if (VariableComparison(0, secondvalue, CompareSign.SelectedIndex) == true)
                                            {
                                                deleteflag = false;
                                            }
                                        }
                                        if (deleteflag == true)
                                        {
                                            deleteflag = false;
                                            zzholder.RemoveAt(x);
                                            x--;
                                        }
                                    }
                                    i = i + 4;
                                    break;
                                case 4: // level requirements
                                case 5:
                                case 6:
                                    CompareSign = FilterGroupBox.Controls[i + 2] as ComboBox;
                                    Value = FilterGroupBox.Controls[i + 3] as TextBox;
                                    firstvalue = 5;
                                    if (string.IsNullOrEmpty(Value.Text) || Value.Text == "-") secondvalue = 0;
                                    else secondvalue = Convert.ToInt32(Value.Text);
                                    for (int x = 0; x < zzholder.Count; x++)
                                    {
                                        if (!string.IsNullOrEmpty(MainForm.itemrequirementlist[zzholder[x]]))
                                        {
                                            valuefound = false;
                                            commasplit = MainForm.itemrequirementlist[zzholder[x]].Split(';');
                                            for (int y = 0; y < commasplit.Length; y++)
                                            {
                                                commasplit2 = commasplit[y].Split('^');
                                                if (Convert.ToInt32(commasplit2[0]) == firstvalue)
                                                {
                                                    valuefound = true;
                                                    if (VariableComparison(Convert.ToInt32(commasplit2[1]), secondvalue, CompareSign.SelectedIndex) == true)
                                                    {
                                                        deleteflag = false;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        deleteflag = true;
                                                    }
                                                }
                                                else
                                                {
                                                    deleteflag = true;
                                                }
                                            }
                                        }
                                        else deleteflag = true;
                                        if (valuefound == false)
                                        {
                                            if (VariableComparison(0, secondvalue, CompareSign.SelectedIndex) == true)
                                            {
                                                deleteflag = false;
                                            }
                                        }
                                        if (deleteflag == true)
                                        {
                                            deleteflag = false;
                                            zzholder.RemoveAt(x);
                                            x--;
                                        }
                                    }
                                    if (SubCategory.SelectedIndex == 4) // removing items that have a fishing or cooking requirement
                                    {
                                        for (int x = 0; x < zzholder.Count; x++)
                                        {
                                            if (MainForm.itemsubtype[zzholder[x]] == "54" || MainForm.itemsubtype[zzholder[x]] == "59" || MainForm.itemsubtype[zzholder[x]] == "66")
                                            {
                                                zzholder.RemoveAt(x);
                                                x--;
                                            }
                                        }
                                    }
                                    else if (SubCategory.SelectedIndex == 5) // checking for subtype if fishing level
                                    {
                                        for (int x = 0; x < zzholder.Count; x++)
                                        {
                                            if (!(MainForm.itemsubtype[zzholder[x]] == "54" || MainForm.itemsubtype[zzholder[x]] == "59"))
                                            {
                                                zzholder.RemoveAt(x);
                                                x--;
                                            }
                                        }
                                    }
                                    else if (SubCategory.SelectedIndex == 6) // same for cooking
                                    {
                                        for (int x = 0; x < zzholder.Count; x++)
                                        {
                                            if (MainForm.itemsubtype[zzholder[x]] != "66")
                                            {
                                                zzholder.RemoveAt(x);
                                                x--;
                                            }
                                        }
                                    }
                                    i = i + 4;
                                    break;
                                case 7: // Male/Female only
                                case 8:
                                    firstvalue = 4;
                                    if (SubCategory.SelectedIndex == 7) secondvalue = 1;
                                    else secondvalue = 2;
                                    for (int x = 0; x < zzholder.Count; x++)
                                    {
                                        if (!string.IsNullOrEmpty(MainForm.itemrequirementlist[zzholder[x]]))
                                        {
                                            commasplit = MainForm.itemrequirementlist[zzholder[x]].Split(';');
                                            for (int y = 0; y < commasplit.Length; y++)
                                            {
                                                commasplit2 = commasplit[y].Split('^');
                                                if (Convert.ToInt32(commasplit2[0]) == firstvalue)
                                                {
                                                    if (Convert.ToInt32(commasplit2[1]) == secondvalue)
                                                    {
                                                        deleteflag = false;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        deleteflag = true;
                                                    }
                                                }
                                                else
                                                {
                                                    deleteflag = true;
                                                }
                                            }
                                        }
                                        else deleteflag = true;
                                        if (deleteflag == true)
                                        {
                                            zzholder.RemoveAt(x);
                                            x--;
                                        }
                                    }
                                    i = i + 2;
                                    break;
                            }
                        }
                        break;
                    case 3:
                        {
                            ComboBox CompareSign = FilterGroupBox.Controls[i + 2] as ComboBox;
                            TextBox Value = FilterGroupBox.Controls[i + 3] as TextBox;
                            int firstvalue;
                            if (SubCategory.SelectedIndex != 10) firstvalue = SubCategory.SelectedIndex;
                            else firstvalue = 15;
                            int secondvalue;
                            if (string.IsNullOrEmpty(Value.Text) || Value.Text == "-") secondvalue = 0;
                            else secondvalue = Convert.ToInt32(Value.Text);
                            bool deleteflag = false;
                            bool valuefound = false;
                            for (int x = 0; x < zzholder.Count; x++)
                            {
                                if (!string.IsNullOrEmpty(MainForm.itemdamagelist[zzholder[x]]))
                                {
                                    valuefound = false;
                                    commasplit = MainForm.itemdamagelist[zzholder[x]].Split(';');
                                    for (int y = 0; y < commasplit.Length; y++)
                                    {
                                        commasplit2 = commasplit[y].Split('^');
                                        if (Convert.ToInt32(commasplit2[0]) == firstvalue)
                                        {
                                            valuefound = true;
                                            if (VariableComparison(Convert.ToInt32(commasplit2[1]), secondvalue, CompareSign.SelectedIndex) == true)
                                            {
                                                deleteflag = false;
                                                break;
                                            }
                                            else
                                            {
                                                deleteflag = true;
                                            }
                                        }
                                        else
                                        {
                                            deleteflag = true;
                                        }
                                    }
                                }
                                else deleteflag = true;
                                if (valuefound == false)
                                {
                                    if (VariableComparison(0, secondvalue, CompareSign.SelectedIndex) == true)
                                    {
                                        deleteflag = false;
                                    }
                                }
                                if (deleteflag == true)
                                {
                                    deleteflag = false;
                                    zzholder.RemoveAt(x);
                                    x--;
                                }
                            }
                            i = i + 4;
                        }
                        break;
                    case 4:
                        {
                            ComboBox CompareSign = FilterGroupBox.Controls[i + 2] as ComboBox;
                            TextBox Value = FilterGroupBox.Controls[i + 3] as TextBox;
                            int firstvalue;
                            if (SubCategory.SelectedIndex != 10) firstvalue = SubCategory.SelectedIndex;
                            else firstvalue = 15;
                            int secondvalue;
                            if (string.IsNullOrEmpty(Value.Text) || Value.Text == "-") secondvalue = 0;
                            else secondvalue = Convert.ToInt32(Value.Text);
                            bool deleteflag = false;
                            bool valuefound = false;
                            for (int x = 0; x < zzholder.Count; x++)
                            {
                                if (!string.IsNullOrEmpty(MainForm.itembonuslist[zzholder[x]]))
                                {
                                    valuefound = false;
                                    commasplit = MainForm.itembonuslist[zzholder[x]].Split(';');
                                    for (int y = 0; y < commasplit.Length; y++)
                                    {
                                        commasplit2 = commasplit[y].Split('^');
                                        if (Convert.ToInt32(commasplit2[0]) == firstvalue)
                                        {
                                            valuefound = true;
                                            if (VariableComparison(Convert.ToInt32(commasplit2[1]), secondvalue, CompareSign.SelectedIndex) == true)
                                            {
                                                deleteflag = false;
                                                break;
                                            }
                                            else
                                            {
                                                deleteflag = true;
                                            }
                                        }
                                        else
                                        {
                                            deleteflag = true;
                                        }
                                    }
                                }
                                else deleteflag = true;
                                if (valuefound == false)
                                {
                                    if (VariableComparison(0, secondvalue, CompareSign.SelectedIndex) == true)
                                    {
                                        deleteflag = false;
                                    }
                                }
                                if (deleteflag == true)
                                {
                                    deleteflag = false;
                                    zzholder.RemoveAt(x);
                                    x--;
                                }
                            }
                            i = i + 4;
                        }
                        break;
                    case 5:
                        {
                            List<List<string>> DataList = new List<List<string>> { MainForm.itemattackspeed, MainForm.itemattackrange, MainForm.itemmissilespeed, MainForm.itemcooldown, MainForm.itembuy, MainForm.itemsell };
                            ComboBox CompareSign = FilterGroupBox.Controls[i + 2] as ComboBox;
                            TextBox Value = FilterGroupBox.Controls[i + 3] as TextBox;
                            int firstvalue = SubCategory.SelectedIndex;
                            int secondvalue;
                            if (string.IsNullOrEmpty(Value.Text) || Value.Text == "-") secondvalue = 0;
                            else secondvalue = Convert.ToInt32(Value.Text);
                            for (int x = 0; x < zzholder.Count; x++)
                            {
                                if (!string.IsNullOrEmpty(DataList[firstvalue][zzholder[x]]))
                                {
                                    if (VariableComparison(Convert.ToInt32(DataList[firstvalue][zzholder[x]]), secondvalue, CompareSign.SelectedIndex) == false)
                                    {
                                        zzholder.RemoveAt(x);
                                        x--;
                                    }
                                }
                                else
                                {
                                    zzholder.RemoveAt(x);
                                    x--;
                                }
                            }
                        }
                        i = i + 4;
                        break;
                    case 6:
                        {
                            List<List<string>> DataList = new List<List<string>> { MainForm.itemstatbonus, MainForm.itemabilitybonus, MainForm.itembonuslist, MainForm.itemarmor, MainForm.itemweight };
                            ComboBox CompareSign = null;
                            ComboBox AbilityUsed;
                            TextBox Value = null;
                            int datavalue = 0;
                            int firstvalue = 0;
                            int secondvalue = 0;
                            bool deleteflag = false;
                            bool valuefound = false;
                            switch (SubCategory.SelectedIndex)
                            {
                                case 0:
                                case 1:
                                case 2:
                                case 3:
                                    CompareSign = FilterGroupBox.Controls[i + 2] as ComboBox;
                                    Value = FilterGroupBox.Controls[i + 3] as TextBox;
                                    datavalue = 0;
                                    firstvalue = SubCategory.SelectedIndex;
                                    break;
                                case 4:
                                    AbilityUsed = FilterGroupBox.Controls[i + 2] as ComboBox;
                                    CompareSign = FilterGroupBox.Controls[i + 3] as ComboBox;
                                    Value = FilterGroupBox.Controls[i + 4] as TextBox;
                                    datavalue = 1;
                                    firstvalue = AbilityUsed.SelectedIndex;
                                    i++;
                                        break;
                                case 5: // do seperate calculation as this doesnt use a split
                                    CompareSign = FilterGroupBox.Controls[i + 2] as ComboBox;
                                    Value = FilterGroupBox.Controls[i + 3] as TextBox;
                                    datavalue = 3;
                                    break;
                                case 6:
                                case 7:
                                case 8:
                                case 9:
                                case 10:
                                    CompareSign = FilterGroupBox.Controls[i + 2] as ComboBox;
                                    Value = FilterGroupBox.Controls[i + 3] as TextBox;
                                    datavalue = 2;
                                    if (SubCategory.SelectedIndex != 10)
                                    {
                                        firstvalue = SubCategory.SelectedIndex + 4; // lines up to bonus list with +4
                                    }
                                    else firstvalue = 16;
                                    break;
                                case 11:
                                    CompareSign = FilterGroupBox.Controls[i + 2] as ComboBox;
                                    Value = FilterGroupBox.Controls[i + 3] as TextBox;
                                    datavalue = 4;
                                    break;
                            }
                            if (string.IsNullOrEmpty(Value.Text) || Value.Text == "-") secondvalue = 0;
                            else secondvalue = Convert.ToInt32(Value.Text);
                            if (SubCategory.SelectedIndex != 5 && SubCategory.SelectedIndex != 11)
                            {
                                for (int x = 0; x < zzholder.Count; x++)
                                {
                                    if (!string.IsNullOrEmpty(DataList[datavalue][zzholder[x]]))
                                    {
                                        commasplit = DataList[datavalue][zzholder[x]].Split(';');
                                        for (int y = 0; y < commasplit.Length; y++)
                                        {
                                            valuefound = false;
                                            commasplit2 = commasplit[y].Split('^');
                                            if (Convert.ToInt32(commasplit2[0]) == firstvalue)
                                            {
                                                valuefound = true;
                                                if (VariableComparison(Convert.ToInt32(commasplit2[1]), secondvalue, CompareSign.SelectedIndex) == true)
                                                {
                                                    deleteflag = false;
                                                    break;
                                                }
                                                else
                                                {
                                                    deleteflag = true;
                                                }
                                            }
                                            else
                                            {
                                                deleteflag = true;
                                            }
                                        }
                                    }
                                    else deleteflag = true;
                                    if (valuefound == false)
                                    {
                                        if (VariableComparison(0, secondvalue, CompareSign.SelectedIndex) == true)
                                        {
                                            deleteflag = false;
                                        }
                                    }
                                    if (deleteflag == true)
                                    {
                                        deleteflag = false;
                                        zzholder.RemoveAt(x);
                                        x--;
                                    }
                                }
                            }
                            else
                            {
                                for (int x = 0; x < zzholder.Count; x++)
                                {
                                    if (!string.IsNullOrEmpty(DataList[datavalue][zzholder[x]]))
                                    {
                                        if (VariableComparison(Convert.ToInt32(DataList[datavalue][zzholder[x]]), secondvalue, CompareSign.SelectedIndex) == false)
                                        {
                                            zzholder.RemoveAt(x);
                                            x--;
                                        }
                                    }
                                    else
                                    {
                                        zzholder.RemoveAt(x);
                                        x--;
                                    }
                                }
                            }
                            i = i + 4;
                        }
                        break;
                    case 7:
                        {
                            ComboBox CompareSign = FilterGroupBox.Controls[i + 2] as ComboBox;
                            TextBox Value = FilterGroupBox.Controls[i + 3] as TextBox;
                            int firstvalue = SubCategory.SelectedIndex;
                            int secondvalue;
                            if (string.IsNullOrEmpty(Value.Text) || Value.Text == "-") secondvalue = 0;
                            else secondvalue = Convert.ToInt32(Value.Text);
                            bool deleteflag = false;
                            bool valuefound = false;
                            for (int x = 0; x < zzholder.Count; x++)
                            {
                                if (!string.IsNullOrEmpty(MainForm.itemevasionlist[zzholder[x]]))
                                {
                                    valuefound = false;
                                    commasplit = MainForm.itemevasionlist[zzholder[x]].Split(';');
                                    for (int y = 0; y < commasplit.Length; y++)
                                    {
                                        commasplit2 = commasplit[y].Split('^');
                                        if (Convert.ToInt32(commasplit2[0]) == firstvalue)
                                        {
                                            valuefound = true;
                                            if (VariableComparison(Convert.ToInt32(commasplit2[1]), secondvalue, CompareSign.SelectedIndex) == true)
                                            {
                                                deleteflag = false;
                                                break;
                                            }
                                            else
                                            {
                                                deleteflag = true;
                                            }
                                        }
                                        else
                                        {
                                            deleteflag = true;
                                        }
                                    }
                                }
                                else deleteflag = true;
                                if (valuefound == false)
                                {
                                    if (VariableComparison(0, secondvalue, CompareSign.SelectedIndex) == true)
                                    {
                                        deleteflag = false;
                                    }
                                }
                                if (deleteflag == true)
                                {
                                    deleteflag = false;
                                    zzholder.RemoveAt(x);
                                    x--;
                                }
                            }
                            i = i + 4;
                        }
                        break;
                    case 8:
                        {
                            List<List<string>> DataList = new List<List<string>> { MainForm.itemskillbonus, MainForm.itemboosts, MainForm.itemprocskillid, MainForm.itemprocskilllevel, MainForm.itemequipskillid, MainForm.itemequipskilllevel, MainForm.itemskillid, MainForm.itemskilllevel };
                            ComboBox CompareSign = FilterGroupBox.Controls[i + 2] as ComboBox;
                            TextBox Value = FilterGroupBox.Controls[i + 3] as TextBox;
                            ListBox ListPick = FilterGroupBox.Controls[i + 6] as ListBox;
                            int datavalue = 0;
                            int datavalue2 = 0;
                            string firstvalue = null;
                            int secondvalue;
                            if (string.IsNullOrEmpty(Value.Text) || Value.Text == "-") secondvalue = 0;
                            else secondvalue = Convert.ToInt32(Value.Text);
                            bool deleteflag = false;
                            bool valuefound = false;
                            switch (SubCategory.SelectedIndex)
                            {
                                case 0:
                                    firstvalue = MainForm.skillid[yholder[indexhold[skillholder[setschecked]]][ListPick.SelectedIndex]];
                                    break;
                                case 1:
                                case 2:
                                    if (SubCategory.SelectedIndex == 1)
                                    {
                                        datavalue2 = 0;
                                    }
                                    else datavalue2 = 1;
                                    firstvalue = MainForm.skillid[yholder[indexhold[skillholder[setschecked]]][ListPick.SelectedIndex]];
                                    break;
                                case 3:
                                    datavalue = 2;
                                    datavalue2 = 3;
                                    firstvalue = MainForm.skillid[yholder[indexhold[skillholder[setschecked]]][ListPick.SelectedIndex]];
                                    break;
                                case 4:
                                    datavalue = 4;
                                    datavalue2 = 5;
                                    firstvalue = MainForm.skillid[yholder[indexhold[skillholder[setschecked]]][ListPick.SelectedIndex]];
                                    break;
                                case 5:
                                    datavalue = 6;
                                    datavalue2 = 7;
                                    firstvalue = MainForm.skillid[yholder[indexhold[skillholder[setschecked]]][ListPick.SelectedIndex]];
                                    break;
                            }
                            if (SubCategory.SelectedIndex == 0)
                            {
                                for (int x = 0; x < zzholder.Count; x++)
                                {
                                    if (!string.IsNullOrEmpty(DataList[0][zzholder[x]]))
                                    {
                                        valuefound = false;
                                        commasplit = DataList[0][zzholder[x]].Split(';');
                                        for (int y = 0; y < commasplit.Length; y++)
                                        {
                                            commasplit2 = commasplit[y].Split('^');
                                            if (commasplit2[0] == firstvalue)
                                            {
                                                valuefound = true;
                                                if (VariableComparison(Convert.ToInt32(commasplit2[1]), secondvalue, CompareSign.SelectedIndex) == true)
                                                {
                                                    deleteflag = false;
                                                    break;
                                                }
                                                else
                                                {
                                                    deleteflag = true;
                                                }
                                            }
                                            else
                                            {
                                                deleteflag = true;
                                            }
                                        }
                                    }
                                    else deleteflag = true;
                                    if (valuefound == false)
                                    {
                                        if (VariableComparison(0, secondvalue, CompareSign.SelectedIndex) == true)
                                        {
                                            deleteflag = false;
                                        }
                                    }
                                    if (deleteflag == true)
                                    {
                                        deleteflag = false;
                                        zzholder.RemoveAt(x);
                                        x--;
                                    }
                                }
                            }
                            else if (SubCategory.SelectedIndex == 1 || SubCategory.SelectedIndex == 2)
                            {
                                for (int x = 0; x < zzholder.Count; x++)
                                {
                                    if (!string.IsNullOrEmpty(DataList[1][zzholder[x]]))
                                    {
                                        valuefound = false;
                                        commasplit = DataList[1][zzholder[x]].Split(';');
                                        for (int y = 0; y < commasplit.Length; y++)
                                        {
                                            commasplit2 = commasplit[y].Split('^');
                                            if (commasplit2[0] == firstvalue && Convert.ToInt32(commasplit2[1]) == datavalue2)
                                            {
                                                valuefound = true;
                                                if (VariableComparison(Convert.ToInt32(commasplit2[2]), secondvalue, CompareSign.SelectedIndex) == true)
                                                {
                                                    deleteflag = false;
                                                    break;
                                                }
                                                else
                                                {
                                                    deleteflag = true;
                                                }
                                            }
                                            else
                                            {
                                                deleteflag = true;
                                            }
                                        }
                                    }
                                    else deleteflag = true;
                                    if (valuefound == false)
                                    {
                                        if (VariableComparison(0, secondvalue, CompareSign.SelectedIndex) == true)
                                        {
                                            deleteflag = false;
                                        }
                                    }
                                    if (deleteflag == true)
                                    {
                                        deleteflag = false;
                                        zzholder.RemoveAt(x);
                                        x--;
                                    }
                                }
                            }
                            else
                            {
                                for (int x = 0; x < zzholder.Count; x++)
                                {
                                    if (!string.IsNullOrEmpty(DataList[datavalue][zzholder[x]]))
                                    {
                                        valuefound = false;
                                        if (DataList[datavalue][zzholder[x]] != firstvalue)
                                        {
                                            deleteflag = true;
                                        }
                                        else if (!string.IsNullOrEmpty(DataList[datavalue2][zzholder[x]]))
                                        {
                                            valuefound = true;
                                            if (VariableComparison(Convert.ToInt32(DataList[datavalue2][zzholder[x]]) + 1, secondvalue, CompareSign.SelectedIndex) == true)
                                            {
                                                deleteflag = false;
                                            }
                                        }
                                        if (valuefound == false)
                                        {
                                            if (VariableComparison(0, secondvalue, CompareSign.SelectedIndex) == true)
                                            {
                                                deleteflag = false;
                                            }
                                        }
                                        if (deleteflag == true)
                                        {
                                            deleteflag = false;
                                            zzholder.RemoveAt(x);
                                            x--;
                                        }
                                    }
                                    else
                                    {
                                        zzholder.RemoveAt(x);
                                        x--;
                                    }
                                }
                            }
                            skillschecked++;
                            i = i + 7;
                        }
                        break;
                    case 9:
                        {
                            ComboBox CompareSign;
                            TextBox Value;
                            ListBox ListPick;
                            string firstvalue;
                            bool deleteflag = false;
                            bool valuefound = false;
                            if (SubCategory.SelectedIndex == 0)
                            {
                                CompareSign = FilterGroupBox.Controls[i + 2] as ComboBox;
                                Value = FilterGroupBox.Controls[i + 3] as TextBox;
                                ListPick = FilterGroupBox.Controls[i + 6] as ListBox;
                                firstvalue = MainForm.statusid[yholder3[indexhold[statusholder[statuseschecked]]][ListPick.SelectedIndex]];
                                int secondvalue;
                                if (string.IsNullOrEmpty(Value.Text) || Value.Text == "-") secondvalue = 0;
                                else secondvalue = Convert.ToInt32(Value.Text);
                                for (int x = 0; x < zzholder.Count; x++)
                                {
                                    if (!string.IsNullOrEmpty(MainForm.itemstatuses[zzholder[x]]))
                                    {
                                        commasplit = MainForm.itemstatuses[zzholder[x]].Split(';');
                                        for (int y = 0; y < commasplit.Length; y++)
                                        {
                                            commasplit2 = commasplit[y].Split('^');
                                            if (commasplit2[0] == firstvalue)
                                            {
                                                valuefound = true;
                                                if (VariableComparison(Convert.ToInt32(commasplit2[1]), secondvalue, CompareSign.SelectedIndex) == true)
                                                {
                                                    deleteflag = false;
                                                    break;
                                                }
                                                else
                                                {
                                                    deleteflag = true;
                                                }
                                            }
                                            else
                                            {
                                                deleteflag = true;
                                            }
                                        }
                                    }
                                    else deleteflag = true;
                                    if (valuefound == false)
                                    {
                                        if (VariableComparison(0, secondvalue, CompareSign.SelectedIndex) == true)
                                        {
                                            deleteflag = false;
                                        }
                                    }
                                    if (deleteflag == true)
                                    {
                                        deleteflag = false;
                                        zzholder.RemoveAt(x);
                                        x--;
                                    }
                                }
                                statuseschecked++;
                                i = i + 2;
                            }
                            else
                            {
                                ListPick = FilterGroupBox.Controls[i + 4] as ListBox;
                                firstvalue = MainForm.itemsetrewardid[yholder4[indexhold[setholder[setschecked]]][ListPick.SelectedIndex]];
                                List<int> templist = new List<int>();
                                for (int x = 0; x < MainForm.itemsetitemid.Count; x++)
                                {
                                    if (MainForm.itemsetid[x] == firstvalue)
                                    {
                                        templist.Add(MainForm.itemid.IndexOf(MainForm.itemsetitemid[x]));
                                    }
                                }
                                for (int x = 0; x < templist.Count; x++)
                                {
                                    if (zzholder.IndexOf(templist[x]) == -1)
                                    {
                                        templist.RemoveAt(x);
                                        x--;
                                    }
                                }
                                zzholder.Clear();
                                zzholder.AddRange(templist);
                            }
                            setschecked++;
                            i = i + 5;
                        }
                        break;
                    case 10:
                        {
                            List<List<string>> DataList = new List<List<string>> { MainForm.itemimportantitem, MainForm.itembindonequip, MainForm.itemnotrade, MainForm.itemstackable };
                            ComboBox TruthBox = FilterGroupBox.Controls[i + 2] as ComboBox;
                            int firstvalue = SubCategory.SelectedIndex;
                            int secondvalue = TruthBox.SelectedIndex;
                            if (secondvalue == 0)
                            {
                                for (int x = 0; x < zzholder.Count; x++)
                                {
                                    if (DataList[firstvalue][zzholder[x]] == "0")
                                    {
                                        zzholder.RemoveAt(x);
                                        x--;
                                    }
                                }
                            }
                            else
                            {
                                for (int x = 0; x < zzholder.Count; x++)
                                {
                                    if (DataList[firstvalue][zzholder[x]] == "1")
                                    {
                                        zzholder.RemoveAt(x);
                                        x--;
                                    }
                                }
                            }
                        }
                        i = i + 3;
                        break;
                }
            }
            MainForm.zholder.AddRange(zzholder);
            this.Hide();
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