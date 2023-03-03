using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HeroesAgeBestiary
{
    public partial class MainForm : Form
    {
        static int GCD(int[] numbers)
        {
            return numbers.Aggregate(GCD);
        }

        static int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        string[] mobspawn = File.ReadAllLines(@"Resources\Database\spawnpoints.txt");
        string[] mobspawnsplitcomma;
        string[] mobspawnsplitquote;
        List<string> moblistmob = new List<string>();
        List<string> zoneidmob = new List<string>();
        int mobspawncounter;
        string[] zones = File.ReadAllLines(@"Resources\Database\zones.txt");
        string[] zonesplit;
        List<string> zoneid = new List<string>();

        int indexstore;

        string[] tiers;
        List<string> tiersorttype = new List<string>();
        List<string> tiersortname = new List<string>();
        List<string> tiersortgroup = new List<string>();
        List<string> tieruniquesortgroup = new List<string>();
        List<int> tieruniquesortweight = new List<int>();
        int tierunsorted;
        string[] tiersplit;
        int tierlocation = -1;
        bool spotskip = false;

        string[] mobs;
        string[] mobsplitcomma;
        public static List<string> mobname = new List<string>();
        public static List<string> mobid = new List<string>();
        public static List<string> moblevel = new List<string>();
        List<string> mobstar = new List<string>();
        public static List<string> mobhealth = new List<string>();
        List<string> mobenergy = new List<string>();
        List<string> mobattack = new List<string>();
        public static List<string> mobdefence = new List<string>();
        public static List<string> mobopinion = new List<string>();
        public static List<string> mobxp = new List<string>();
        List<string> mobgold = new List<string>();
        public static List<string> mobaggrorange = new List<string>();
        List<string> mobfollowrange = new List<string>();
        List<string> mobattackrange = new List<string>();
        List<string> mobattackspeed = new List<string>();
        List<string> mobmissilespeed = new List<string>();
        public static List<string> mobpiercedamage = new List<string>();
        public static List<string> mobslashdamage = new List<string>();
        public static List<string> mobcrushdamage = new List<string>();
        public static List<string> mobpoisondamage = new List<string>();
        public static List<string> mobtruedamage = new List<string>();
        public static List<string> mobheatdamage = new List<string>();
        public static List<string> mobcolddamage = new List<string>();
        public static List<string> mobmagicdamage = new List<string>();
        public static List<string> mobdivinedamage = new List<string>();
        public static List<string> mobchaosdamage = new List<string>();
        List<string> mobfishingdamage = new List<string>();
        public static List<string> mobpierceresist = new List<string>();
        public static List<string> mobslashresist = new List<string>();
        public static List<string> mobcrushresist = new List<string>();
        public static List<string> mobpoisonresist = new List<string>();
        public static List<string> mobtrueresist = new List<string>();
        public static List<string> mobheatresist = new List<string>();
        public static List<string> mobcoldresist = new List<string>();
        public static List<string> mobmagicresist = new List<string>();
        public static List<string> mobdivineresist = new List<string>();
        public static List<string> mobchaosresist = new List<string>();
        public static List<string> mobphysicalevade = new List<string>();
        public static List<string> mobspellevade = new List<string>();
        public static List<string> mobmoveevade = new List<string>();
        public static List<string> mobwoundevade = new List<string>();
        public static List<string> mobweakevade = new List<string>();
        public static List<string> mobmentalevade = new List<string>();
        public static List<int> xholder = new List<int>();
        public static List<int> xholderamount = new List<int>();

        string[] items;
        string[] itemsets;
        string[] itemsetrewards;
        string[] specialvariables; // for variables that are uncommon so space doesn't have to be wasted on instances that do not contain it
        string[] lootsets;
        string[] loottables;
        string[] loottableitems;
        string[] moblootsets;
        string[] skills;
        string[] skilllv;
        string[] status;
        string[] statuslv;

        string[] itemsplit;
        public static List<string> itemid = new List<string>();
        public static List<string> itemname = new List<string>();
        public static List<string> itemdescription = new List<string>();
        public static List<string> itemstackable = new List<string>();
        public static List<string> itemarmor = new List<string>();
        public static List<string> itemequipslot = new List<string>();
        public static List<string> itembuy = new List<string>();
        public static List<string> itemsell = new List<string>();
        public static List<string> itemweight = new List<string>();
        public static List<string> itemattackspeed = new List<string>();
        public static List<string> itemsubtype = new List<string>();
        public static List<string> itemnotrade = new List<string>();
        public static List<string> itemdamagelist = new List<string>();
        public static List<string> itembonuslist = new List<string>();
        public static List<string> itemrequirementlist = new List<string>();
        public static List<string> itemclasslist = new List<string>();
        public static List<string> itemskillid = new List<string>();
        public static List<string> itemskilllevel = new List<string>();
        public static List<string> itemattackrange = new List<string>();
        public static List<string> itemmissilespeed = new List<string>();
        public static List<string> itemblockslots = new List<string>();
        public static List<string> itemprocskillid = new List<string>();
        public static List<string> itemprocskilllevel = new List<string>();
        public static List<string> itemprocskillchance = new List<string>();
        public static List<string> itemequipskillid = new List<string>();
        public static List<string> itemequipskilllevel = new List<string>();
        public static List<string> itembindonequip = new List<string>();
        public static List<string> itemstatbonus = new List<string>();
        public static List<string> itemabilitybonus = new List<string>();
        public static List<string> itemskillbonus = new List<string>();
        public static List<string> itemmaxcharges = new List<string>();
        public static List<string> itemdestroyonnocharge = new List<string>();
        public static List<string> itemevasionlist = new List<string>();
        public static List<string> itemimportantitem = new List<string>();
        public static List<string> itemcooldown = new List<string>(); // null if default, only has a number if it has a listed special cooldown
        public static List<string> itemboosts = new List<string>(); // type 0 is direct damage, type 1 is cooldown
        public static List<string> itemstatuses = new List<string>();

        string[] specialvariable;
        public static List<string> itemidimmunity = new List<string>();
        public static List<string> itemimmunityvalues = new List<string>();
        public static List<string> itemidresistance = new List<string>();
        public static List<string> itemresistancevalues = new List<string>();

        string[] itemsetsplit;
        public static List<string> itemsetid = new List<string>();
        public static List<string> itemsetitemid = new List<string>();

        string[] itemsetrewardsplit;
        public static List<string> itemsetrewardid = new List<string>();
        public static List<string> itemsetrewarditemid = new List<string>();
        public static List<string> itemsetrewardamount = new List<string>(); // how many set items are needed for set bonus

        public static List<int> zholder = new List<int>();
        List<List<int>> ziholder = new List<List<int>>();
        int zilength = 0;
        int zilength2 = 0;
        string zisearch;
        bool ziwarning = false;
        bool nameskip3 = false;

        string[] tableitemsplit;
        List<string> tableitemloottableid = new List<string>();
        List<string> tableitemitemid = new List<string>();
        List<string> tableitemamount = new List<string>();
        List<string> tableitemweight = new List<string>();

        string[] tablesplit;
        List<string> tableloottableid = new List<string>();
        List<string> tablename = new List<string>();

        string[] setsplit;
        List<string> setid = new List<string>();
        List<string> settableid = new List<string>();
        List<string> setweight = new List<string>();

        string[] mobsplit;
        List<string> mobtemplateid = new List<string>();
        List<string> mobloottableid = new List<string>();
        List<string> moblootamount = new List<string>();

        string[] mobability;
        string[] mobabilitysplit;
        public static List<string> mobabilitymobid = new List<string>();
        public static List<string> mobabilityabilityid = new List<string>();
        public static List<string> mobabilityamount = new List<string>();

        string[] mobskill;
        string[] mobskillsplit;
        public static List<string> mobskillmobid = new List<string>();
        public static List<string> mobskillskillid = new List<string>();
        public static List<string> mobskilllevel = new List<string>();

        string[] ability;
        string[] abilitysplit;
        public static List<string> abilityid = new List<string>();
        public static List<string> abilityname = new List<string>();

        public static string mobidcross;
        public static bool skillopen = false;
        public static bool spawnopen = false;
        List<string> itemtablesearch = new List<string>();
        List<string> itemdupechecker = new List<string>();
        List<int> itemdupechecker2 = new List<int>();
        List<string> itemdupechecker3 = new List<string>();

        public static List<string> loottableidlist = new List<string>();
        public static List<int> xholderloot = new List<int>();
        public static List<string> nameeditorlist = new List<string>();
        List<int> xholderloot2 = new List<int>();
        List<string> result = new List<string>();

        List<string> nameholder = new List<string>();
        List<int> xholderloot3 = new List<int>();
        List<float> setweighthold = new List<float>();
        float setweighttotal;

        List<string> nameholder2 = new List<string>();
        List<int> xholderloot4 = new List<int>();
        List<float> setweighthold2 = new List<float>();
        float setweighttotal2;

        List<List<int>> xiholder = new List<List<int>>();
        int xilength = 0;
        int xilength2 = 0;
        string xisearch;
        bool xiwarning = false;
        bool nameskip = false;
        List<List<int>> xiitemholder = new List<List<int>>();
        List<List<int>> xitableholder = new List<List<int>>();
        List<List<int>> xisetholder = new List<List<int>>();
        List<List<int>> ximobholder = new List<List<int>>();

        List<List<int>> xi2holder = new List<List<int>>();
        int xi2length = 0;
        int xi2length2 = 0;
        string xi2search;
        bool xi2warning = false;
        bool nameskip2 = false;
        List<List<int>> xi2itemholder = new List<List<int>>();
        List<List<int>> xi2tableholder = new List<List<int>>();
        List<List<int>> xi2tableholder2 = new List<List<int>>();

        CultureInfo ci = new CultureInfo("en-US");

        public MainForm()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            tiers = File.ReadAllLines(@"Resources\Settings\tiers.txt");
            for (int x = 0; x < tiers.Length; x++)
            {
                tiersplit = tiers[x].Split('~');
                tiersorttype.Add(tiersplit[0]);
                tiersortname.Add(tiersplit[1]);
                tiersortgroup.Add(tiersplit[2]);
                if (tieruniquesortgroup.IndexOf(tiersplit[2]) == -1)
                {
                    tieruniquesortgroup.Add(tiersplit[2]);
                    tieruniquesortweight.Add(0);
                }
            }
            mobs = File.ReadAllLines(@"Resources\Database\moblist.txt");
            xiholder.Add(new List<int>());
            for (int x = 0; x < mobs.Length; x++)
            {
                mobsplitcomma = mobs[x].Split('~');
                mobid.Add(mobsplitcomma[0]);
                mobname.Add(mobsplitcomma[1]);
                mobaggrorange.Add(mobsplitcomma[2]);
                mobfollowrange.Add(mobsplitcomma[3]);
                mobopinion.Add(mobsplitcomma[4]);
                moblevel.Add(mobsplitcomma[5]);
                mobhealth.Add(mobsplitcomma[6]);
                mobgold.Add(mobsplitcomma[7]);
                mobattack.Add(mobsplitcomma[8]);
                mobdefence.Add(mobsplitcomma[9]);
                mobattackspeed.Add(mobsplitcomma[10]);
                mobenergy.Add(mobsplitcomma[11]);
                mobpiercedamage.Add(mobsplitcomma[12]);
                mobslashdamage.Add(mobsplitcomma[13]);
                mobcrushdamage.Add(mobsplitcomma[14]);
                mobheatdamage.Add(mobsplitcomma[15]);
                mobcolddamage.Add(mobsplitcomma[16]);
                mobmagicdamage.Add(mobsplitcomma[17]);
                mobpoisondamage.Add(mobsplitcomma[18]);
                mobdivinedamage.Add(mobsplitcomma[19]);
                mobchaosdamage.Add(mobsplitcomma[20]);
                mobtruedamage.Add(mobsplitcomma[21]);
                mobfishingdamage.Add(mobsplitcomma[22]);
                mobpierceresist.Add(mobsplitcomma[23]);
                mobslashresist.Add(mobsplitcomma[24]);
                mobcrushresist.Add(mobsplitcomma[25]);
                mobheatresist.Add(mobsplitcomma[26]);
                mobcoldresist.Add(mobsplitcomma[27]);
                mobmagicresist.Add(mobsplitcomma[28]);
                mobpoisonresist.Add(mobsplitcomma[29]);
                mobdivineresist.Add(mobsplitcomma[30]);
                mobchaosresist.Add(mobsplitcomma[31]);
                mobtrueresist.Add(mobsplitcomma[32]);
                mobstar.Add(mobsplitcomma[33]);
                mobattackrange.Add(mobsplitcomma[34]);
                mobmissilespeed.Add(mobsplitcomma[35]);
                mobxp.Add(mobsplitcomma[36]);
                mobphysicalevade.Add(mobsplitcomma[37]);
                mobspellevade.Add(mobsplitcomma[38]);
                mobmoveevade.Add(mobsplitcomma[39]);
                mobwoundevade.Add(mobsplitcomma[40]);
                mobweakevade.Add(mobsplitcomma[41]);
                mobmentalevade.Add(mobsplitcomma[42]);

                xiholder[0].Add(x);
            }
            items = File.ReadAllLines(@"Resources\Database\itemlist.txt");
            itemsets = File.ReadAllLines(@"Resources\Database\setbonusitem.txt");
            itemsetrewards = File.ReadAllLines(@"Resources\Database\setbonusreward.txt");
            specialvariables = File.ReadAllLines(@"Resources\Database\specialvariables.txt");
            lootsets = File.ReadAllLines(@"Resources\Database\lootsetlist.txt");
            loottables = File.ReadAllLines(@"Resources\Database\loottablelist.txt");
            loottableitems = File.ReadAllLines(@"Resources\Database\loottableitemlist.txt");
            moblootsets = File.ReadAllLines(@"Resources\Database\moblootsetlist.txt");
            skills = File.ReadAllLines(@"Resources\Database\skilltemplates.txt");
            skilllv = File.ReadAllLines(@"Resources\Database\skilltemplatelevels.txt");
            status = File.ReadAllLines(@"Resources\Database\statuseffecttemplates.txt");
            statuslv = File.ReadAllLines(@"Resources\Database\statustemplatelevels.txt");
            mobability = File.ReadAllLines(@"Resources\Database\mobabilities.txt");
            mobskill = File.ReadAllLines(@"Resources\Database\mobskills.txt");
            ability = File.ReadAllLines(@"Resources\Database\abilitylist.txt");
            aura = File.ReadAllLines(@"Resources\Database\aurasubeffects.txt");
            effect = File.ReadAllLines(@"Resources\Database\charactereffects.txt");
            xiitemholder.Add(new List<int>());
            xi2itemholder.Add(new List<int>());
            ziholder.Add(new List<int>());
            for (int x = 0; x < items.Length; x++)
            {
                itemsplit = items[x].Split('~');
                itemid.Add(itemsplit[0]);
                itemname.Add(itemsplit[1]);
                itemdescription.Add(itemsplit[2]);
                itemstackable.Add(itemsplit[3]);
                itemarmor.Add(itemsplit[4]);
                itemequipslot.Add(itemsplit[5]);
                itembuy.Add(itemsplit[6]);
                itemsell.Add(itemsplit[7]);
                itemweight.Add(itemsplit[8]);
                itemattackspeed.Add(itemsplit[9]);
                itemsubtype.Add(itemsplit[10]);
                itemnotrade.Add(itemsplit[11]);
                itemdamagelist.Add(itemsplit[12]);
                itembonuslist.Add(itemsplit[13]);
                itemrequirementlist.Add(itemsplit[14]);
                itemclasslist.Add(itemsplit[15]);
                itemskillid.Add(itemsplit[16]);
                itemskilllevel.Add(itemsplit[17]);
                itemattackrange.Add(itemsplit[18]);
                itemmissilespeed.Add(itemsplit[19]);
                itemblockslots.Add(itemsplit[20]);
                itemprocskillid.Add(itemsplit[21]);
                itemprocskilllevel.Add(itemsplit[22]);
                itemprocskillchance.Add(itemsplit[23]);
                itemequipskillid.Add(itemsplit[24]);
                itemequipskilllevel.Add(itemsplit[25]);
                itembindonequip.Add(itemsplit[26]);
                itemstatbonus.Add(itemsplit[27]);
                itemabilitybonus.Add(itemsplit[28]);
                itemskillbonus.Add(itemsplit[29]);
                itemmaxcharges.Add(itemsplit[30]);
                itemdestroyonnocharge.Add(itemsplit[31]);
                itemevasionlist.Add(itemsplit[32]);
                itemimportantitem.Add(itemsplit[33]);
                itemcooldown.Add(itemsplit[34]);
                itemboosts.Add(itemsplit[35]);
                itemstatuses.Add(itemsplit[36]);

                xiitemholder[0].Add(x);
                xi2itemholder[0].Add(x);
                ziholder[0].Add(x);
            }
            for (int x = 0; x < itemsets.Length; x++)
            {
                itemsetsplit = itemsets[x].Split('~');
                itemsetid.Add(itemsetsplit[0]);
                itemsetitemid.Add(itemsetsplit[1]);
            }
            for (int x = 0; x < itemsetrewards.Length; x++)
            {
                itemsetrewardsplit = itemsetrewards[x].Split('~');
                itemsetrewardid.Add(itemsetrewardsplit[0]);
                itemsetrewarditemid.Add(itemsetrewardsplit[1]);
                itemsetrewardamount.Add(itemsetrewardsplit[2]);
            }
            int lines = Convert.ToInt32(specialvariables[0]) + 1;
            for (int x = 1; x < lines; x++)
            {
                specialvariable = specialvariables[x].Split('~');
                itemidresistance.Add(specialvariable[0]);
                itemresistancevalues.Add(specialvariable[1]);
            }
            int lines2 = Convert.ToInt32(specialvariables[lines]);
            for (int x = lines + 1; x < lines + lines2 + 1; x++)
            {
                specialvariable = specialvariables[x].Split('~');
                itemidimmunity.Add(specialvariable[0]);
                itemimmunityvalues.Add(specialvariable[1]);
            }
            xitableholder.Add(new List<int>());
            xi2tableholder.Add(new List<int>());
            for (int x = 0; x < loottableitems.Length; x++)
            {
                tableitemsplit = loottableitems[x].Split('~');
                tableitemloottableid.Add(tableitemsplit[0]);
                tableitemitemid.Add(tableitemsplit[1]);
                tableitemamount.Add(tableitemsplit[2]);
                tableitemweight.Add(tableitemsplit[3]);

                xitableholder[0].Add(x);
                xi2tableholder[0].Add(x);
            }
            xi2tableholder2.Add(new List<int>());
            for (int x = 0; x < loottables.Length; x++)
            {
                tablesplit = loottables[x].Split('~');
                tableloottableid.Add(tablesplit[0]);
                tablename.Add(tablesplit[1]);

                xi2tableholder2[0].Add(x);
            }
            xisetholder.Add(new List<int>());
            xi2holder.Add(new List<int>());
            for (int x = 0; x < lootsets.Length; x++)
            {
                setsplit = lootsets[x].Split('~');
                setid.Add(setsplit[0]);
                settableid.Add(setsplit[1]);
                setweight.Add(setsplit[2]);

                xisetholder[0].Add(x);
                xi2holder[0].Add(x);
            }
            ximobholder.Add(new List<int>());
            for (int x = 0; x < moblootsets.Length; x++)
            {
                mobsplit = moblootsets[x].Split('~');
                mobtemplateid.Add(mobsplit[0]);
                mobloottableid.Add(mobsplit[1]);
                moblootamount.Add(mobsplit[2]);

                ximobholder[0].Add(x);
            }
            yiholder.Add(new List<int>());
            for (int x = 0; x < skills.Length; x++)
            {
                skillsplit = skills[x].Split('~');
                skillid.Add(skillsplit[0]);
                skillname.Add(skillsplit[1]);
                skilltarget.Add(skillsplit[2]);
                skillstatus.Add(skillsplit[3]);
                skillaoe.Add(skillsplit[4]);
                skillrange.Add(skillsplit[5]);
                skilldamagetype.Add(skillsplit[6]);
                skillability.Add(skillsplit[7]);
                skillsubtype.Add(skillsplit[8]);
                skillmissilespeed.Add(skillsplit[9]);
                skillreporttime.Add(skillsplit[10]);
                skillblocktime.Add(skillsplit[11]);
                skillprimstat.Add(skillsplit[12]);
                skillprimmod.Add(skillsplit[13]);
                skillauto.Add(skillsplit[14]);
                skillevasion.Add(skillsplit[15]);

                yiholder[0].Add(x);
            }
            for (int x = 0; x < skilllv.Length; x++)
            {
                skilllvsplit = skilllv[x].Split('~');
                skilllvid.Add(skilllvsplit[0]);
                skilllvlevel.Add(skilllvsplit[1]);
                skilllvinitialdamage.Add(skilllvsplit[2]);
                skilllvcasttime.Add(skilllvsplit[3]);
                skilllvcooldown.Add(skilllvsplit[4]);
                skilllvenergy.Add(skilllvsplit[5]);
                skilllvinterrupt.Add(skilllvsplit[6]);
                skilllvreq.Add(skilllvsplit[7]);
                skilllvpvp.Add(skilllvsplit[8]);
                skilllvbaseamount.Add(skilllvsplit[9]);
                skilllvaggromulti.Add(skilllvsplit[10]);
            }
            yi2holder.Add(new List<int>());
            for (int x = 0; x < status.Length; x++)
            {
                statussplit = status[x].Split('~');
                statusid.Add(statussplit[0]);
                statusname.Add(statussplit[1]);
                statuseffect.Add(statussplit[2]);
                statusdamage.Add(statussplit[3]);
                statusitem.Add(statussplit[4]);
                statusdeath.Add(statussplit[5]);
                statusability.Add(statussplit[6]);
                statusbreak.Add(statussplit[7]);
                statuspause.Add(statussplit[8]);
                statustick.Add(statussplit[9]);
                statusaura.Add(statussplit[10]);

                yi2holder[0].Add(x);
            }
            for (int x = 0; x < statuslv.Length; x++)
            {
                statuslvsplit = statuslv[x].Split('~');
                statuslvid.Add(statuslvsplit[0]);
                statuslvlevel.Add(statuslvsplit[1]);
                statuslvinitial.Add(statuslvsplit[2]);
                statuslvduration.Add(statuslvsplit[3]);
                statuslvpvp.Add(statuslvsplit[4]);
                statuslvbase.Add(statuslvsplit[5]);
            }
            for (int x = 0; x < mobability.Length; x++)
            {
                mobabilitysplit = mobability[x].Split('~');
                mobabilitymobid.Add(mobabilitysplit[0]);
                mobabilityabilityid.Add(mobabilitysplit[1]);
                mobabilityamount.Add(mobabilitysplit[2]);
            }
            for (int x = 0; x < mobskill.Length; x++)
            {
                mobskillsplit = mobskill[x].Split('~');
                mobskillmobid.Add(mobskillsplit[0]);
                mobskillskillid.Add(mobskillsplit[1]);
                mobskilllevel.Add(mobskillsplit[2]);
            }
            for (int x = 0; x < ability.Length; x++)
            {
                abilitysplit = ability[x].Split('~');
                abilityid.Add(abilitysplit[0]);
                abilityname.Add(abilitysplit[1]);
            }
            for (int i = 0; i < mobspawn.Length; i++)
            {
                mobspawnsplitcomma = mobspawn[i].Split('~');
                zoneidmob.Add(mobspawnsplitcomma[1]);
                moblistmob.Add(mobspawnsplitcomma[7]);
            }
            for (int i = 0; i < zones.Length; i++)
            {
                zonesplit = zones[i].Split('~');
                zoneid.Add(zonesplit[0]);
            }
            for (int i = 0; i < aura.Length; i++)
            {
                aurasplit = aura[i].Split('~');
                auraid.Add(aurasplit[0]);
                auraeffectid.Add(aurasplit[1]);
                auratarget.Add(aurasplit[2]);
                aurarange.Add(aurasplit[3]);
            }
            for (int i = 0; i < effect.Length; i++)
            {
                effectsplit = effect[i].Split('~');
                effectid.Add(effectsplit[0]);
                effectname.Add(effectsplit[1]);
                effecttype.Add(effectsplit[2]);
                effectarmor.Add(effectsplit[3]);
                effectbonus.Add(effectsplit[4]);
                effectdamage.Add(effectsplit[5]);
                effectevasion.Add(effectsplit[6]);
                effectimmune.Add(effectsplit[7]);
                effectreduction.Add(effectsplit[8]);
                effectstat.Add(effectsplit[9]);
                effectability.Add(effectsplit[10]);
                effectskill.Add(effectsplit[11]);
            }
            AdvancedSearch = new ItemAdvancedSearch();
        }

        // #Page1

        private void MonsterNameSearchTextbox_TextChanged(object sender, EventArgs e)
        {
            if (nameskip == false)
            {
                MonsterSearchListbox.BeginUpdate();
                MonsterSearchListbox.Items.Clear();
                xholder.Clear();
                Level.Text = "???";
                Star.Text = "???";
                Health.Text = "???";
                Energy.Text = "???";
                Attack.Text = "???";
                Defence.Text = "???";
                XP.Text = "???";
                MobOpinion.Text = "???";
                Aggro.Text = "???";
                Follow.Text = "???";
                Range.Text = "???";
                Speed.Text = "???";
                MissileSpeed.Text = "???";
                Gold.Text = "???";
                DamagePierce.Text = "???";
                DamageSlash.Text = "???";
                DamageCrush.Text = "???";
                DamageHeat.Text = "???";
                DamageCold.Text = "???";
                DamageMagic.Text = "???";
                DamagePoison.Text = "???";
                DamageDivine.Text = "???";
                DamageChaos.Text = "???";
                DamageTrue.Text = "???";
                DamageFishing.Text = "???";
                ResistPierce.Text = "???";
                ResistSlash.Text = "???";
                ResistCrush.Text = "???";
                ResistHeat.Text = "???";
                ResistCold.Text = "???";
                ResistMagic.Text = "???";
                ResistPoison.Text = "???";
                ResistDivine.Text = "???";
                ResistChaos.Text = "???";
                ResistTrue.Text = "???";
                EvadePhysical.Text = "???";
                EvadeSpell.Text = "???";
                EvadeMove.Text = "???";
                EvadeWound.Text = "???";
                EvadeWeak.Text = "???";
                EvadeMental.Text = "???";
                if (MonsterSearchListbox.SelectedIndex == -1)
                {
                    EnemySkillButton.Enabled = false;
                    EnemySpawnButton.Enabled = false;
                    SpawnPoints.Text = "Spawn Points: ???";
                }
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
                if (AutoSearchCheckbox.Checked == true && ItemSearchCheckbox.Checked == true)
                {
                    itemtablesearch.Clear();
                    itemdupechecker.Clear();
                    if (xilength > MonsterNameSearchTextbox.Text.Length && xiwarning == false)
                    {
                        for (int i = 0; i < xiholder[MonsterNameSearchTextbox.Text.Length].Count; i++)
                        {
                            MonsterSearchListbox.Items.Add(mobname[xiholder[MonsterNameSearchTextbox.Text.Length][i]]);
                            xholder.Add(xiholder[MonsterNameSearchTextbox.Text.Length][i]);
                        }
                        xiitemholder.RemoveRange(MonsterNameSearchTextbox.Text.Length + 1, xilength - MonsterNameSearchTextbox.Text.Length);
                        xitableholder.RemoveRange(MonsterNameSearchTextbox.Text.Length + 1, xilength - MonsterNameSearchTextbox.Text.Length);
                        xisetholder.RemoveRange(MonsterNameSearchTextbox.Text.Length + 1, xilength - MonsterNameSearchTextbox.Text.Length);
                        ximobholder.RemoveRange(MonsterNameSearchTextbox.Text.Length + 1, xilength - MonsterNameSearchTextbox.Text.Length);
                        xiholder.RemoveRange(MonsterNameSearchTextbox.Text.Length + 1, xilength - MonsterNameSearchTextbox.Text.Length);
                        xilength = MonsterNameSearchTextbox.Text.Length;
                    }
                    else
                    {
                        if (xiwarning == true)
                        {
                            xilength = 0;
                            xiitemholder.RemoveRange(1, xiitemholder.Count - 1);
                            xitableholder.RemoveRange(1, xitableholder.Count - 1);
                            xisetholder.RemoveRange(1, xisetholder.Count - 1);
                            ximobholder.RemoveRange(1, ximobholder.Count - 1);
                            xiholder.RemoveRange(1, xiholder.Count - 1);
                        }
                        xilength2 = xilength;
                        for (int f = 0; f < MonsterNameSearchTextbox.Text.Length - xilength2; f++)
                        {
                            itemtablesearch.Clear();
                            itemdupechecker.Clear();
                            itemdupechecker2.Clear();
                            itemdupechecker3.Clear();
                            xiitemholder.Add(new List<int>());
                            xitableholder.Add(new List<int>());
                            xisetholder.Add(new List<int>());
                            ximobholder.Add(new List<int>());
                            xiholder.Add(new List<int>());
                            for (int a = 0; a < xiitemholder[xilength].Count; a++)
                            {
                                if (itemname[xiitemholder[xilength][a]].ToUpper().Contains(MonsterNameSearchTextbox.Text.ToUpper()))
                                {
                                    xiitemholder[xilength + 1].Add(xiitemholder[xilength][a]);
                                    for (int b = 0; b < xitableholder[xilength].Count; b++)
                                    {
                                        if (itemid[xiitemholder[xilength][a]] == tableitemitemid[xitableholder[xilength][b]])
                                        {
                                            xitableholder[xilength + 1].Add(xitableholder[xilength][b]);
                                            if (itemtablesearch.IndexOf(tableitemloottableid[xitableholder[xilength][b]]) == -1)
                                            {
                                                itemtablesearch.Add(tableitemloottableid[xitableholder[xilength][b]]);
                                            }
                                        }
                                    }
                                }
                            }
                            for (int a = 0; a < itemtablesearch.Count; a++)
                            {
                                for (int b = 0; b < xisetholder[xilength].Count; b++)
                                {
                                    if (itemtablesearch[a] == settableid[xisetholder[xilength][b]] && itemdupechecker.IndexOf(settableid[xisetholder[xilength][b]]) == -1)
                                    {
                                        itemdupechecker.Add(mobid[xisetholder[xilength][b]]);
                                        xisetholder[xilength + 1].Add(xisetholder[xilength][b]);
                                        for (int c = 0; c < ximobholder[xilength].Count; c++)
                                        {
                                            if (setid[xisetholder[xilength][b]] == mobloottableid[ximobholder[xilength][c]] && itemdupechecker2.IndexOf(ximobholder[xilength][c]) == -1)
                                            {
                                                itemdupechecker2.Add(ximobholder[xilength][c]);
                                                ximobholder[xilength + 1].Add(ximobholder[xilength][c]);
                                                for (int d = 0; d < xiholder[xilength].Count; d++)
                                                {
                                                    if (mobtemplateid[ximobholder[xilength][c]] == mobid[xiholder[xilength][d]] && itemdupechecker3.IndexOf(mobid[xiholder[xilength][d]]) == -1)
                                                    {
                                                        itemdupechecker3.Add(mobid[xiholder[xilength][d]]);
                                                        xiholder[xilength + 1].Add(xiholder[xilength][d]);
                                                        MonsterSearchListbox.Items.Add(mobname[xiholder[xilength][d]]);
                                                        xholder.Add(xiholder[xilength][d]);
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            xilength = xilength + 1;
                        }
                    }
                }
                else
                {
                    xilength2 = MonsterNameSearchTextbox.Text.Length - xilength;
                    if (xilength > MonsterNameSearchTextbox.Text.Length && xiwarning == false)
                    {
                        for (int i = 0; i < xiholder[MonsterNameSearchTextbox.Text.Length].Count; i++)
                        {
                            if (mobname[xiholder[MonsterNameSearchTextbox.Text.Length][i]].ToUpper().Contains(MonsterNameSearchTextbox.Text.ToUpper()))
                            {
                                MonsterSearchListbox.Items.Add(mobname[xiholder[MonsterNameSearchTextbox.Text.Length][i]]);
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
                                if (mobname[xiholder[xilength][i]].ToUpper().Contains(MonsterNameSearchTextbox.Text.Substring(0, xilength + 1).ToUpper()))
                                {
                                    xiholder[xilength + 1].Add(xiholder[xilength][i]);
                                }
                            }
                            xilength = xilength + 1;
                        }
                        for (int i = 0; i < xiholder[xilength].Count; i++)
                        {
                            xholder.Add(xiholder[xilength][i]);
                            MonsterSearchListbox.Items.Add(mobname[xiholder[xilength][i]]);
                        }
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
            if (MonsterSearchListbox.SelectedIndex == -1)
            {
                EnemySkillButton.Enabled = false;
                EnemySpawnButton.Enabled = false;
                SpawnPoints.Text = "Spawn Points: ???";
            }
            if (AutoSearchCheckbox.Checked == true && ItemSearchCheckbox.Checked == true)
            {
                itemtablesearch.Clear();
                itemdupechecker.Clear();
                for (int b = 0; b < tableitemitemid.Count; b++)
                {
                    if (MonsterIDSearchTextbox.Text == tableitemitemid[b])
                    {
                        if (itemtablesearch.IndexOf(tableitemloottableid[b]) == -1)
                        {
                            itemtablesearch.Add(tableitemloottableid[b]);
                        }
                    }
                }
                if (itemtablesearch.Count > 0)
                {
                    for (int a = 0; a < itemtablesearch.Count; a++)
                    {
                        for (int b = 0; b < settableid.Count; b++)
                        {
                            if (itemtablesearch[a] == settableid[b])
                            {
                                for (int c = 0; c < mobloottableid.Count; c++)
                                {
                                    if (setid[b] == mobloottableid[c])
                                    {
                                        for (int d = 0; d < mobid.Count; d++)
                                        {
                                            if (mobtemplateid[c] == mobid[d])
                                            {
                                                if (itemdupechecker.IndexOf(mobid[d]) == -1)
                                                {
                                                    itemdupechecker.Add(mobid[d]);
                                                    MonsterSearchListbox.Items.Add(mobname[d]);
                                                    xholder.Add(d);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    string message = "No Results/Invalid ID";
                    string title = "Error";
                    MessageBox.Show(message, title);
                    Thread.CurrentThread.CurrentCulture = ci;
                    Thread.CurrentThread.CurrentUICulture = ci;
                }
            }
            else
            {
                int x = mobid.IndexOf(MonsterIDSearchTextbox.Text);
                if (x != -1)
                {
                    nameskip = true;
                    MonsterNameSearchTextbox.Text = "";
                    nameskip = false;
                    xiwarning = true;
                    MonsterNameSearchTextbox.Text = mobname[x];
                    for (int y = 0; y < xholder.Count; y++)
                    {
                        if (mobid[xholder[y]] == mobid[x])
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
                    Thread.CurrentThread.CurrentCulture = ci;
                    Thread.CurrentThread.CurrentUICulture = ci;
                }
            }
        }

        private void MonsterSearchListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MonsterSearchListbox.SelectedIndex > -1)
            {
                IDSearch(xholder[MonsterSearchListbox.SelectedIndex]);
            }
        }

        private void IDSearch(int idlocation)
        {
            if (AutoSearchCheckbox.Checked == false || ItemSearchCheckbox.Checked == false)
            {
                MonsterIDSearchTextbox.Text = mobid[xholder[MonsterSearchListbox.SelectedIndex]];
            }
            Level.Text = moblevel[idlocation];
            Star.Text = mobstar[idlocation];
            Health.Text = mobhealth[idlocation];
            Energy.Text = mobenergy[idlocation];
            Attack.Text = mobattack[idlocation];
            Defence.Text = mobdefence[idlocation];
            MobOpinion.Text = mobopinion[idlocation];
            XP.Text = mobxp[idlocation];
            Gold.Text = mobgold[idlocation];
            Aggro.Text = mobaggrorange[idlocation];
            Follow.Text = mobfollowrange[idlocation];
            Range.Text = mobattackrange[idlocation];
            Speed.Text = mobattackspeed[idlocation];
            MissileSpeed.Text = mobmissilespeed[idlocation];
            DamagePierce.Text = mobpiercedamage[idlocation];
            DamageSlash.Text = mobslashdamage[idlocation];
            DamageCrush.Text = mobcrushdamage[idlocation];
            DamagePoison.Text = mobpoisondamage[idlocation];
            DamageTrue.Text = mobtruedamage[idlocation];
            DamageHeat.Text = mobheatdamage[idlocation];
            DamageCold.Text = mobcolddamage[idlocation];
            DamageMagic.Text = mobmagicdamage[idlocation];
            DamageDivine.Text = mobdivinedamage[idlocation];
            DamageChaos.Text = mobchaosdamage[idlocation];
            DamageFishing.Text = mobfishingdamage[idlocation];
            ResistPierce.Text = mobpierceresist[idlocation];
            ResistSlash.Text = mobslashresist[idlocation];
            ResistCrush.Text = mobcrushresist[idlocation];
            ResistPoison.Text = mobpoisonresist[idlocation];
            ResistTrue.Text = mobtrueresist[idlocation];
            ResistHeat.Text = mobheatresist[idlocation];
            ResistCold.Text = mobcoldresist[idlocation];
            ResistMagic.Text = mobmagicresist[idlocation];
            ResistDivine.Text = mobdivineresist[idlocation];
            ResistChaos.Text = mobchaosresist[idlocation];
            EvadePhysical.Text = mobphysicalevade[idlocation];
            EvadeSpell.Text = mobspellevade[idlocation];
            EvadeMove.Text = mobmoveevade[idlocation];
            EvadeWound.Text = mobwoundevade[idlocation];
            EvadeWeak.Text = mobweakevade[idlocation];
            EvadeMental.Text = mobmentalevade[idlocation];
            if (mobskillmobid.IndexOf(mobid[xholder[MonsterSearchListbox.SelectedIndex]]) != -1 || mobabilitymobid.IndexOf(mobid[xholder[MonsterSearchListbox.SelectedIndex]]) != -1)
            {
                if (skillopen == false)
                {
                    EnemySkillButton.Enabled = true;
                }
            }
            else
            {
                EnemySkillButton.Enabled = false;
            }
            if (AutoSearchCheckbox.Checked == true)
            {
                LootTableNameSearchTextbox.Clear();
                LootSetSearchListbox.Items.Clear();
                LootTableSearchListbox.Items.Clear();
                LootTableListbox.Items.Clear();
                loottableidlist.Clear();
                xholderloot.Clear();
                nameeditorlist.Clear();
                xholderloot2.Clear();
                xholderamount.Clear();
                result.Clear();
                int v = 0;
                for (int x = 0; x < mobtemplateid.Count; x++)
                {
                    if (mobtemplateid[x] == mobid[xholder[MonsterSearchListbox.SelectedIndex]])
                    {
                        for (int y = 0; y < settableid.Count; y++)
                        {
                            if (setid[y] == mobloottableid[x])
                            {
                                if (xholderloot2.Count == 0)
                                {
                                    xholderloot2.Add(y);
                                    xholderamount.Add(x);
                                }
                                else if (mobloottableid[x] != mobloottableid[xholderamount[v]])
                                {
                                    v = v + 1;
                                    xholderloot2.Add(y);
                                    xholderamount.Add(x);

                                }
                            }
                        }
                    }
                }
                v = 0;
                for (int z = 0; z < xholderamount.Count; z++)
                {
                    if (Convert.ToInt32(moblootamount[xholderamount[z]]) == 1)
                    {
                        LootSetSearchListbox.Items.Add("Drop Slot #" + Convert.ToString(z + 1));
                    }
                    else LootSetSearchListbox.Items.Add("Drop Slot #" + Convert.ToString(z + 1) + " x" + moblootamount[xholderamount[z]]);
                }
            }
            mobspawncounter = 0;
            for (int x = 0; x < moblistmob.Count; x++)
            {
                mobspawnsplitcomma = mobspawn[x].Split('~');
                mobspawnsplitquote = mobspawnsplitcomma[7].Split('|', ';');
                for (int i = 0; i < mobspawnsplitquote.Length; i = i + 2)
                {
                    if (mobspawnsplitquote[i] == mobid[xholder[MonsterSearchListbox.SelectedIndex]])
                    {
                        if (zoneid.IndexOf(zoneidmob[x]) != -1)
                        {
                            mobspawncounter = mobspawncounter + 1;
                        }
                    }
                }
            }
            if (mobspawncounter > 0)
            {
                SpawnPoints.Text = "Spawn Points: " + mobspawncounter;
                if (spawnopen == false)
                {
                    EnemySpawnButton.Enabled = true;
                }
            }
            else
            {
                SpawnPoints.Text = "Spawn Points: 0";
                EnemySpawnButton.Enabled = false;
            }
        }

        private void LootTableNameSearchTextbox_TextChanged(object sender, EventArgs e)
        {
            if (nameskip2 == false)
            {
                LootSetSearchListbox.BeginUpdate();
                LootSetSearchListbox.Items.Clear();
                LootTableSearchListbox.Items.Clear();
                LootTableListbox.Items.Clear();
                loottableidlist.Clear();
                xholderloot.Clear();
                nameeditorlist.Clear();
                xholderloot2.Clear();
                result.Clear();
                if (string.IsNullOrEmpty(xi2search) == false)
                {
                    if (xi2search.Length > LootTableNameSearchTextbox.Text.Length)
                    {
                        if (xi2search.Substring(0, LootTableNameSearchTextbox.Text.Length) != LootTableNameSearchTextbox.Text)
                        {
                            xi2warning = true;
                        }
                    }
                    else
                    {
                        if (LootTableNameSearchTextbox.Text.Substring(0, xi2search.Length) != xi2search)
                        {
                            xi2warning = true;
                        }
                    }
                }
                if (AutoSearchCheckbox.Checked == false && ItemSearchCheckbox.Checked == true)
                {
                    itemtablesearch.Clear();
                    itemdupechecker.Clear();
                    if (xi2length > LootTableNameSearchTextbox.Text.Length && xi2warning == false)
                    {
                        for (int i = 0; i < xi2tableholder2[LootTableNameSearchTextbox.Text.Length].Count; i++)
                        {
                            xholderloot.Add(xi2tableholder2[LootTableNameSearchTextbox.Text.Length][i]);
                        }
                        xi2itemholder.RemoveRange(LootTableNameSearchTextbox.Text.Length + 1, xi2length - LootTableNameSearchTextbox.Text.Length);
                        xi2tableholder.RemoveRange(LootTableNameSearchTextbox.Text.Length + 1, xi2length - LootTableNameSearchTextbox.Text.Length);
                        xi2tableholder2.RemoveRange(LootTableNameSearchTextbox.Text.Length + 1, xi2length - LootTableNameSearchTextbox.Text.Length);
                        xi2holder.RemoveRange(LootTableNameSearchTextbox.Text.Length + 1, xi2length - LootTableNameSearchTextbox.Text.Length);
                        xi2length = LootTableNameSearchTextbox.Text.Length;
                    }
                    else
                    {
                        if (xi2warning == true)
                        {
                            xi2length = 0;
                            xi2itemholder.RemoveRange(1, xi2itemholder.Count - 1);
                            xi2tableholder.RemoveRange(1, xi2tableholder.Count - 1);
                            xi2tableholder2.RemoveRange(1, xi2tableholder2.Count - 1);
                            xi2holder.RemoveRange(1, xi2holder.Count - 1);
                        }
                        xi2length2 = xi2length;
                        for (int f = 0; f < LootTableNameSearchTextbox.Text.Length - xi2length2; f++)
                        {
                            itemtablesearch.Clear();
                            itemdupechecker.Clear();
                            itemdupechecker2.Clear();
                            itemdupechecker3.Clear();
                            xi2itemholder.Add(new List<int>());
                            xi2tableholder.Add(new List<int>());
                            xi2tableholder2.Add(new List<int>());
                            xi2holder.Add(new List<int>());
                            for (int a = 0; a < xi2itemholder[xi2length].Count; a++)
                            {
                                if (itemname[xi2itemholder[xi2length][a]].ToUpper().Contains(LootTableNameSearchTextbox.Text.ToUpper()))
                                {
                                    xi2itemholder[xi2length + 1].Add(xi2itemholder[xi2length][a]);
                                    for (int b = 0; b < xi2tableholder[xi2length].Count; b++)
                                    {
                                        if (itemid[xi2itemholder[xi2length][a]] == tableitemitemid[xi2tableholder[xi2length][b]])
                                        {
                                            xi2tableholder[xi2length + 1].Add(xi2tableholder[xi2length][b]);
                                            for (int c = 0; c < xi2tableholder2[xi2length].Count; c++)
                                            {
                                                if (tableitemloottableid[xi2tableholder[xi2length][b]] == tableloottableid[xi2tableholder2[xi2length][c]])
                                                {
                                                    if (itemtablesearch.IndexOf(tableitemloottableid[xi2tableholder[xi2length][b]]) == -1)
                                                    {
                                                        xi2tableholder2[xi2length + 1].Add(xi2tableholder2[xi2length][c]);
                                                        itemtablesearch.Add(tableitemloottableid[xi2tableholder[xi2length][b]]);
                                                        for (int d = 0; d < xi2holder[xi2length].Count; d++)
                                                        {
                                                            if (tableitemloottableid[xi2tableholder[xi2length][b]] == settableid[xi2holder[xi2length][d]])
                                                            {
                                                                if (itemdupechecker.IndexOf(settableid[xi2holder[xi2length][d]]) == -1)
                                                                {
                                                                    itemdupechecker.Add(settableid[xi2holder[xi2length][d]]);
                                                                    nameeditorlist.Add(tablename[xi2tableholder2[xi2length][c]]);
                                                                    xholderloot.Add(xi2tableholder2[xi2length][c]);
                                                                    xi2holder[xi2length + 1].Add(xi2holder[xi2length][d]);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            xi2length = xi2length + 1;
                        }
                    }
                }
                else
                {
                    xi2length2 = LootTableNameSearchTextbox.Text.Length - xi2length;
                    if (xi2length > LootTableNameSearchTextbox.Text.Length && xi2warning == false)
                    {
                        for (int i = 0; i < xi2tableholder2[LootTableNameSearchTextbox.Text.Length].Count; i++)
                        {
                            if (tablename[xi2tableholder2[LootTableNameSearchTextbox.Text.Length][i]].ToUpper().Contains(LootTableNameSearchTextbox.Text.ToUpper()))
                            {
                                nameeditorlist.Add(tablename[xi2tableholder2[LootTableNameSearchTextbox.Text.Length][i]]);
                                xholderloot.Add(xi2tableholder2[LootTableNameSearchTextbox.Text.Length][i]);
                            }
                        }
                        xi2tableholder2.RemoveRange(LootTableNameSearchTextbox.Text.Length + 1, xi2length - LootTableNameSearchTextbox.Text.Length);
                        xi2length = LootTableNameSearchTextbox.Text.Length;
                    }
                    else
                    {
                        if (xi2warning == true)
                        {
                            xi2length = 0;
                            xi2tableholder2.RemoveRange(1, xi2tableholder2.Count - 1);
                        }
                        xi2length2 = xi2length;
                        for (int a = 0; a < LootTableNameSearchTextbox.Text.Length - xi2length2; a++)
                        {
                            xi2tableholder2.Add(new List<int>());
                            for (int i = 0; i < xi2tableholder2[xi2length].Count; i++)
                            {
                                if (tablename[xi2tableholder2[xi2length][i]].ToUpper().Contains(LootTableNameSearchTextbox.Text.Substring(0, xi2length + 1).ToUpper()))
                                {
                                    xi2tableholder2[xi2length + 1].Add(xi2tableholder2[xi2length][i]);
                                }
                            }
                            xi2length = xi2length + 1;
                        }
                        for (int i = 0; i < xi2tableholder2[xi2length].Count; i++)
                        {
                            if (tablename[xi2tableholder2[LootTableNameSearchTextbox.Text.Length][i]].ToUpper().Contains(LootTableNameSearchTextbox.Text.ToUpper()))
                            {
                                nameeditorlist.Add(tablename[xi2tableholder2[LootTableNameSearchTextbox.Text.Length][i]]);
                                xholderloot.Add(xi2tableholder2[LootTableNameSearchTextbox.Text.Length][i]);
                            }
                        }
                    }
                }
                for (int x = 0; x < xholderloot.Count; x++)
                {
                    for (int y = 0; y < settableid.Count; y++)
                    {
                        if (tableloottableid[xholderloot[x]] == settableid[y])
                        {
                            if (settableid[y] != "-1")
                            {
                                result.Add(settableid[y]);
                                xholderloot2.Add(y);
                            }
                        }
                    }
                }
                for (int x = 0; x < xholderloot2.Count; x++)
                {
                    LootSetSearchListbox.Items.Add("[" + setid[Convert.ToInt32(xholderloot2[x])] + "] " + tablename[tableloottableid.IndexOf(settableid[Convert.ToInt32(xholderloot2[x])])]);
                }
                LootSetSearchListbox.EndUpdate();
                xi2search = LootTableNameSearchTextbox.Text;
                xi2warning = false;
            }
        }

        private void LootTableIDSearchButton_Click(object sender, EventArgs e)
        {
            LootSetSearchListbox.Items.Clear();
            LootTableSearchListbox.Items.Clear();
            LootTableListbox.Items.Clear();
            loottableidlist.Clear();
            xholderloot.Clear();
            nameeditorlist.Clear();
            xholderloot2.Clear();
            result.Clear();

            if (AutoSearchCheckbox.Checked == false && ItemSearchCheckbox.Checked == true)
            {
                itemtablesearch.Clear();
                itemdupechecker.Clear();
                for (int b = 0; b < tableitemitemid.Count; b++)
                {
                    if (LootTableIDSearchTextbox.Text == tableitemitemid[b])
                    {
                        for (int c = 0; c < tableloottableid.Count; c++)
                        {
                            if (tableitemloottableid[b] == tableloottableid[c])
                            {
                                if (itemtablesearch.IndexOf(tableitemloottableid[b]) == -1)
                                {
                                    itemtablesearch.Add(tableitemloottableid[b]);
                                    for (int d = 0; d < settableid.Count; d++)
                                    {
                                        if (tableitemloottableid[b] == settableid[d])
                                        {
                                            if (itemdupechecker.IndexOf(settableid[d]) == -1)
                                            {
                                                itemdupechecker.Add(settableid[d]);
                                                nameeditorlist.Add(tablename[c]);
                                                xholderloot.Add(c);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (xholderloot.Count > 0)
                {
                    for (int x = 0; x < xholderloot.Count; x++)
                    {
                        for (int y = 0; y < settableid.Count; y++)
                        {
                            if (tableloottableid[xholderloot[x]] == settableid[y])
                            {
                                if (settableid[y] != "-1")
                                {
                                    result.Add(settableid[y]);
                                    xholderloot2.Add(y);
                                }
                            }
                        }
                    }
                }
                else
                {
                    string message = "No Results/Invalid ID";
                    string title = "Error";
                    MessageBox.Show(message, title);
                    Thread.CurrentThread.CurrentCulture = ci;
                    Thread.CurrentThread.CurrentUICulture = ci;
                }
            }
            else
            {
                for (int x = 0; x < settableid.Count; x++)
                {
                    if (LootTableIDSearchTextbox.Text == setid[x])
                    {
                        xholderloot2.Add(x);
                    }
                }
                if (xholderloot2.Count == 0)
                {
                    string message = "Invalid ID";
                    string title = "Error";
                    MessageBox.Show(message, title);
                    Thread.CurrentThread.CurrentCulture = ci;
                    Thread.CurrentThread.CurrentUICulture = ci;
                }
            }
            for (int x = 0; x < xholderloot2.Count; x++)
            {
                if (tableloottableid.IndexOf(settableid[Convert.ToInt32(xholderloot2[x])]) != -1)
                {
                    LootSetSearchListbox.Items.Add("[" + setid[Convert.ToInt32(xholderloot2[x])] + "] " + tablename[tableloottableid.IndexOf(settableid[Convert.ToInt32(xholderloot2[x])])]);
                }
                else
                {
                    LootSetSearchListbox.Items.Add("[" + setid[Convert.ToInt32(xholderloot2[x])] + "] Invalid(?)");
                }
            }
        }

        private void LootSetSearchListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LootSetSearchListbox.SelectedIndex > -1)
            {
                float weightadding = 0;
                LootTableSearchListbox.Items.Clear();
                LootTableListbox.Items.Clear();
                nameholder.Clear();
                xholderloot3.Clear();
                setweighthold.Clear();
                if (AutoSearchCheckbox.Checked == true || ItemSearchCheckbox.Checked == false)
                {
                    LootTableIDSearchTextbox.Text = setid[Convert.ToInt32(xholderloot2[LootSetSearchListbox.SelectedIndex])];
                }
                for (int x = 0; x < setid.Count; x++)
                {
                    if (setid[Convert.ToInt32(xholderloot2[LootSetSearchListbox.SelectedIndex])] == setid[x])
                    {
                        if (tableloottableid.IndexOf(settableid[x]) != -1)
                        {
                            setweighthold.Add(float.Parse(setweight[x]));
                            xholderloot3.Add(tableloottableid.IndexOf(settableid[x]));
                            nameholder.Add(tablename[tableloottableid.IndexOf(settableid[x])]);
                        }
                        else
                        {
                            setweighthold.Add(float.Parse(setweight[x]));
                            xholderloot3.Add(tableloottableid.IndexOf(settableid[x]));
                            nameholder.Add("Invalid(?)");
                        }
                    }
                }
                for (int x = 0; x < setweighthold.Count; x++)
                {
                    weightadding = weightadding + setweighthold[x];
                }
                setweighttotal = weightadding;
                ReloadTableRates();
                weightadding = 0;
            }
        }

        private void ReloadTableRates()
        {
            indexstore = LootTableSearchListbox.SelectedIndex;
            LootTableSearchListbox.Items.Clear();
            LootTableSearchListbox.SelectedIndex = -1;
            if (ShowPercentages.Checked == true)
            {
                for (int x = 0; x < setweighthold.Count; x++)
                {
                    LootTableSearchListbox.Items.Add(((setweighthold[x] / setweighttotal) * 100).ToString() + "% " + nameholder[x]);
                }
            }
            else if (ShowFractions.Checked == true)
            {
                int[] numerators = new int[setweighthold.Count + 1];
                for (int x = 0; x < setweighthold.Count; x++)
                {
                    numerators[x] = Convert.ToInt32(setweighthold[x]);
                }
                numerators[setweighthold.Count] = Convert.ToInt32(setweighttotal);
                int result = GCD(numerators);
                LootTableSearchListbox.BeginUpdate();
                for (int x = 0; x < numerators.Length - 1; x++)
                {
                    LootTableSearchListbox.Items.Add((numerators[x] / result) + "/" + (numerators[setweighthold.Count] / result) + " " + nameholder[x]);
                }
                LootTableSearchListbox.EndUpdate();
            }
            spotskip = true;
            LootTableSearchListbox.SelectedIndex = indexstore;
            spotskip = false;
        }

        private void LootTableSearchListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (spotskip == false)
            {
                if (LootTableSearchListbox.SelectedIndex > -1)
                {
                    float weightadding = 0;

                    LootTableListbox.Items.Clear();
                    nameholder2.Clear();
                    xholderloot4.Clear();
                    setweighthold2.Clear();
                    for (int x = 0; x < tableitemloottableid.Count; x++)
                    {
                        if (xholderloot3[LootTableSearchListbox.SelectedIndex] != -1)
                        {
                            if (tableloottableid[Convert.ToInt32(xholderloot3[LootTableSearchListbox.SelectedIndex])] == tableitemloottableid[x])
                            {
                                if (tableloottableid.IndexOf(tableitemloottableid[x]) != -1)
                                {
                                    setweighthold2.Add(float.Parse(tableitemweight[x]));
                                    xholderloot4.Add(Convert.ToInt32(tableitemamount[x]));
                                    if (itemid.IndexOf(tableitemitemid[x]) > -1)
                                    {
                                        nameholder2.Add(itemname[itemid.IndexOf(tableitemitemid[x])]);
                                    }
                                    else nameholder2.Add("Nothing");
                                }
                            }
                        }
                    }
                    for (int x = 0; x < setweighthold2.Count; x++)
                    {
                        weightadding = weightadding + setweighthold2[x];
                    }
                    if (ShowItems.Checked == true)
                    {
                        for (int x = 0; x < xholderloot4.Count; x++)
                        {
                            if (xholderloot4[x] != -1)
                            {
                                if (xholderloot4[x] > 1)
                                {
                                    nameholder2[x] = nameholder2[x] + " x" + xholderloot4[x];
                                }
                            }
                        }
                    }
                    setweighttotal2 = weightadding;
                    weightadding = 0;
                    ReloadLootTableItems();
                }
            }
        }

        private void ReloadLootTableItems()
        {
            LootTableListbox.Items.Clear();
            LootTableListbox.BeginUpdate();
            if (ShowItems.Checked == true)
            {
                int[] numerators = new int[setweighthold2.Count + 1];
                for (int x = 0; x < xholderloot4.Count; x++)
                {
                    if (nameholder2[x].ToUpper().Contains(DropTableFilter.Text.ToUpper()))
                    {
                        if (ShowPercentages.Checked == true)
                        {
                            if (CombinedChance.Checked == true)
                            {
                                LootTableListbox.Items.Add((((setweighthold2[x] / setweighttotal2) * 100) * (setweighthold[LootTableSearchListbox.SelectedIndex] / setweighttotal)).ToString() + "% " + nameholder2[x]);
                            }
                            else if (BasicChance.Checked == true)
                            {
                                LootTableListbox.Items.Add(((setweighthold2[x] / setweighttotal2) * 100).ToString() + "% " + nameholder2[x]);
                            }
                        }
                        else if (ShowFractions.Checked == true)
                        {
                            if (CombinedChance.Checked == true)
                            {
                                for (int y = 0; y < setweighthold2.Count; y++)
                                {
                                    numerators[y] = Convert.ToInt32(setweighthold2[y] * (setweighthold[LootTableSearchListbox.SelectedIndex] / setweighttotal));
                                }
                            }
                            else if (BasicChance.Checked == true)
                            {
                                for (int y = 0; y < setweighthold2.Count; y++)
                                {
                                    numerators[y] = Convert.ToInt32(setweighthold2[y]);
                                }
                            }
                        }
                    }
                }
                if (ShowFractions.Checked == true)
                {
                    numerators[setweighthold2.Count] = Convert.ToInt32(setweighttotal2);
                    int result = GCD(numerators);
                    LootTableListbox.BeginUpdate();
                    for (int y = 0; y < numerators.Length - 1; y++)
                    {
                        LootTableListbox.Items.Add((numerators[y] / result) + "/" + (numerators[setweighthold2.Count] / result) + " " + nameholder2[y]);
                    }
                    LootTableListbox.EndUpdate();
                }
            }
            else if (ShowTiers.Checked == true)
            {
                for (int x = 0; x < xholderloot4.Count; x++)
                {
                    for (int y = 0; y < tiersortname.Count; y++)
                    {
                        if (tiersorttype[y] == "2")
                        {
                            if (tiersortname[y].Length <= nameholder2[x].Length)
                            {
                                if (nameholder2[x].Substring(nameholder2[x].Length - tiersortname[y].Length, tiersortname[y].Length) == tiersortname[y])
                                {
                                    tierlocation = y;
                                    break;
                                }
                            }
                        }
                    }
                    if (tierlocation == -1)
                    {
                        for (int y = 0; y < tiersortname.Count; y++)
                        {
                            if (tiersorttype[y] == "1")
                            {
                                if (tiersortname[y].Length <= nameholder2[x].Length)
                                {
                                    if (nameholder2[x].Substring(0, tiersortname[y].Length) == tiersortname[y])
                                    {
                                        tierlocation = y;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if (tierlocation == -1)
                    {
                        for (int y = 0; y < tiersortname.Count; y++)
                        {
                            if (tiersorttype[y] == "0")
                            {
                                if (nameholder2[x].Contains(tiersortname[y]))
                                {
                                    tierlocation = y;
                                    break;
                                }
                            }
                        }
                    }
                    if (tierlocation != -1)
                    {
                        switch (tiersorttype[tierlocation])
                        {
                            case "0":
                                tieruniquesortweight[tieruniquesortgroup.IndexOf(tiersortgroup[tierlocation])] = tieruniquesortweight[tieruniquesortgroup.IndexOf(tiersortgroup[tierlocation])] + Convert.ToInt32(setweighthold2[x]);
                                break;
                            case "1":
                                tieruniquesortweight[tieruniquesortgroup.IndexOf(tiersortgroup[tierlocation])] = tieruniquesortweight[tieruniquesortgroup.IndexOf(tiersortgroup[tierlocation])] + Convert.ToInt32(setweighthold2[x]);
                                break;
                            case "2":
                                tieruniquesortweight[tieruniquesortgroup.IndexOf(tiersortgroup[tierlocation])] = tieruniquesortweight[tieruniquesortgroup.IndexOf(tiersortgroup[tierlocation])] + Convert.ToInt32(setweighthold2[x]);
                                break;
                        }
                    }
                    else
                    {
                        tierunsorted = tierunsorted + Convert.ToInt32(setweighthold2[x]);
                    }
                    tierlocation = -1;
                }
                int[] numerators = new int[tieruniquesortweight.Count + 1];
                for (int x = 0; x < tieruniquesortweight.Count; x++)
                {
                    if (tieruniquesortgroup[x].ToUpper().Contains(DropTableFilter.Text.ToUpper()))
                    {
                        if (tieruniquesortweight[x] > 0)
                        {
                            if (ShowPercentages.Checked == true)
                            {
                                if (CombinedChance.Checked == true)
                                {
                                    LootTableListbox.Items.Add((((tieruniquesortweight[x] / setweighttotal2) * 100) * (setweighthold[LootTableSearchListbox.SelectedIndex] / setweighttotal)).ToString() + "% " + tieruniquesortgroup[x]);
                                }
                                else if (BasicChance.Checked == true)
                                {
                                    LootTableListbox.Items.Add(((tieruniquesortweight[x] / setweighttotal2) * 100).ToString() + "% " + tieruniquesortgroup[x]);
                                }
                            }
                            else if (ShowFractions.Checked == true)
                            {
                                if (CombinedChance.Checked == true)
                                {
                                    for (int y = 0; y < tieruniquesortweight.Count; y++)
                                    {
                                        numerators[y] = Convert.ToInt32(tieruniquesortweight[y] * (setweighthold[LootTableSearchListbox.SelectedIndex] / setweighttotal));
                                    }
                                }
                                else if (BasicChance.Checked == true)
                                {
                                    for (int y = 0; y < tieruniquesortweight.Count; y++)
                                    {
                                        numerators[y] = Convert.ToInt32(tieruniquesortweight[y]);
                                    }
                                }
                            }
                        }
                    }
                }
                if (ShowFractions.Checked == true)
                {
                    numerators[tieruniquesortweight.Count] = Convert.ToInt32(setweighttotal2);
                    int result = GCD(numerators);
                    LootTableListbox.BeginUpdate();
                    for (int y = 0; y < numerators.Length - 1; y++)
                    {
                        if (tieruniquesortweight[y] > 0)
                        {
                            LootTableListbox.Items.Add((numerators[y] / result) + "/" + (numerators[tieruniquesortweight.Count] / result) + " " + tieruniquesortgroup[y]);
                        }
                    }
                    LootTableListbox.EndUpdate();
                }
            }
            if (tierunsorted > 0)
            {
                if (ShowPercentages.Checked == true)
                {
                    if (CombinedChance.Checked == true)
                    {
                        LootTableListbox.Items.Add((((tierunsorted / setweighttotal2) * 100) * (setweighthold[LootTableSearchListbox.SelectedIndex] / setweighttotal)).ToString() + "% Unsorted");
                    }
                    else if (BasicChance.Checked == true)
                    {
                        LootTableListbox.Items.Add(((tierunsorted / setweighttotal2) * 100).ToString() + "% Unsorted");
                    }
                }
                else if (ShowFractions.Checked == true)
                {
                    if (CombinedChance.Checked == true)
                    {
                        int[] numerators = new int[2];
                        numerators[0] = Convert.ToInt32(tierunsorted * (setweighthold[LootTableSearchListbox.SelectedIndex] / setweighttotal));
                        numerators[1] = Convert.ToInt32(setweighttotal2);
                        int result = GCD(numerators);
                        LootTableListbox.BeginUpdate();
                        LootTableListbox.Items.Add((numerators[0] / result) + "/" + (numerators[1] / result) + " Unsorted");
                        LootTableListbox.EndUpdate();
                    }
                    else if (BasicChance.Checked == true)
                    {
                        int[] numerators = new int[2];
                        numerators[0] = Convert.ToInt32(tierunsorted);
                        numerators[1] = Convert.ToInt32(setweighttotal2);
                        int result = GCD(numerators);
                        LootTableListbox.BeginUpdate();
                        LootTableListbox.Items.Add((numerators[0] / result) + "/" + (numerators[1] / result) + " Unsorted");
                        LootTableListbox.EndUpdate();
                    }
                }
            }
            tierunsorted = 0;
            for (int x = 0; x < tieruniquesortweight.Count; x++)
            {
                tieruniquesortweight[x] = 0;
            }
            LootTableListbox.EndUpdate();
        }

        private void DropTableFilter_TextChanged(object sender, EventArgs e)
        {
            if (LootTableSearchListbox.SelectedIndex != -1)
            {
                ReloadLootTableItems();
            }
        }

        private void ShowPercentages_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPercentages.Checked == true)
            {
                ShowPercentages.Enabled = false;
                ShowFractions.Checked = false;
                ShowFractions.Enabled = true;
                ReloadLootTableItems();
                ReloadTableRates();
            }
        }

        private void ShowFractions_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowFractions.Checked == true)
            {
                ShowFractions.Enabled = false;
                ShowPercentages.Checked = false;
                ShowPercentages.Enabled = true;
                ReloadLootTableItems();
                ReloadTableRates();
            }
        }

        private void CombinedChance_CheckedChanged(object sender, EventArgs e)
        {
            if (CombinedChance.Checked == true)
            {
                CombinedChance.Enabled = false;
                BasicChance.Checked = false;
                BasicChance.Enabled = true;
                ReloadLootTableItems();
            }
        }

        private void BasicChance_CheckedChanged(object sender, EventArgs e)
        {
            if (BasicChance.Checked == true)
            {
                BasicChance.Enabled = false;
                CombinedChance.Checked = false;
                CombinedChance.Enabled = true;
                ReloadLootTableItems();
            }
        }

        private void ShowItems_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowItems.Checked == true)
            {
                ShowItems.Enabled = false;
                ShowTiers.Checked = false;
                ShowTiers.Enabled = true;
                ReloadLootTableItems();
            }
        }

        private void ShowTiers_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowTiers.Checked == true)
            {
                ShowTiers.Enabled = false;
                ShowItems.Checked = false;
                ShowItems.Enabled = true;
                ReloadLootTableItems();
            }
        }

        private void AutoSearchCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (AutoSearchCheckbox.Checked == true)
            {
                LootTableSearchListbox.Items.Clear();
                LootTableListbox.Items.Clear();
                label41.Enabled = false;
                label42.Enabled = false;
                label44.Enabled = false;
                LootTableNameSearchTextbox.Enabled = false;
                LootTableIDSearchTextbox.Enabled = false;
                LootTableIDSearchButton.Enabled = false;
            }
            else
            {
                LootTableSearchListbox.Items.Clear();
                LootTableListbox.Items.Clear();
                label41.Enabled = true;
                label42.Enabled = true;
                label44.Enabled = true;
                LootTableNameSearchTextbox.Enabled = true;
                LootTableIDSearchTextbox.Enabled = true;
                LootTableIDSearchButton.Enabled = true;
            }
        }

        private void ItemSearchCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (AutoSearchCheckbox.Checked == true)
            {
                xiholder.RemoveRange(1, xiholder.Count - 1);
                nameskip = true;
                MonsterNameSearchTextbox.Text = "";
                MonsterIDSearchTextbox.Text = "";
                nameskip = false;
                xilength = 0;
                MonsterSearchListbox.Items.Clear();
                SpawnPoints.Text = "Spawn Points: ???";
                EnemySpawnButton.Enabled = false;
                EnemySkillButton.Enabled = false;
                Level.Text = "???";
                Star.Text = "???";
                Health.Text = "???";
                Energy.Text = "???";
                Attack.Text = "???";
                Defence.Text = "???";
                MobOpinion.Text = "???";
                XP.Text = "???";
                Gold.Text = "???";
                Aggro.Text = "???";
                Follow.Text = "???";
                Range.Text = "???";
                Speed.Text = "???";
                MissileSpeed.Text = "???";
                DamagePierce.Text = "???";
                DamageSlash.Text = "???";
                DamageCrush.Text = "???";
                DamagePoison.Text = "???";
                DamageTrue.Text = "???";
                DamageHeat.Text = "???";
                DamageCold.Text = "???";
                DamageMagic.Text = "???";
                DamageDivine.Text = "???";
                DamageChaos.Text = "???";
                DamageFishing.Text = "???";
                ResistPierce.Text = "???";
                ResistSlash.Text = "???";
                ResistCrush.Text = "???";
                ResistPoison.Text = "???";
                ResistTrue.Text = "???";
                ResistHeat.Text = "???";
                ResistCold.Text = "???";
                ResistMagic.Text = "???";
                ResistDivine.Text = "???";
                ResistChaos.Text = "???";
                EvadePhysical.Text = "???";
                EvadeSpell.Text = "???";
                EvadeMove.Text = "???";
                EvadeWound.Text = "???";
                EvadeWeak.Text = "???";
                EvadeMental.Text = "???";
            }
            else
            {
                xi2holder.RemoveRange(1, xi2holder.Count - 1);
                nameskip2 = true;
                LootTableNameSearchTextbox.Text = "";
                LootTableIDSearchTextbox.Text = "";
                nameskip2 = false;
                xi2length = 0;
            }
            nameskip2 = true;
            LootTableNameSearchTextbox.Text = "";
            LootTableIDSearchTextbox.Text = "";
            nameskip2 = false;
            LootSetSearchListbox.Items.Clear();
            LootTableSearchListbox.Items.Clear();
            LootTableListbox.Items.Clear();
            nameholder2.Clear();
            xholderloot4.Clear();
            setweighthold2.Clear();
        }

        public void SwitchItemSearch()
        {
            if (AutoSearchCheckbox.Checked == true)
            {
                ItemSearchCheckbox.Checked = false;
            }
        }

        private void EnemySkillButton_Click(object sender, EventArgs e)
        {
            EnemySkillButton.Enabled = false;
            skillopen = true;
            mobidcross = mobid[xholder[MonsterSearchListbox.SelectedIndex]];
            MobSkillPage EnemySkillPage = new MobSkillPage(this);
            EnemySkillPage.Text = mobname[xholder[MonsterSearchListbox.SelectedIndex]] + "(Skills/Abilities)";
            EnemySkillPage.Show();
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

        public void EnemySkillButtonOpen()
        {
            this.EnemySkillButton.Enabled = true;
        }

        private void EnemySpawnButton_Click(object sender, EventArgs e)
        {
            EnemySpawnButton.Enabled = false;
            spawnopen = true;
            mobidcross = mobid[xholder[MonsterSearchListbox.SelectedIndex]];
            MobSpawnPage EnemySpawnPage = new MobSpawnPage(this);
            EnemySpawnPage.Show();
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

        public void EnemySpawnButtonOpen()
        {
            this.EnemySpawnButton.Enabled = true;
        }

        public void EnemySpawnIDSearch(int ID)
        {
            if (MonsterSearchListbox.SelectedIndex == -1)
            {
                EnemySkillButton.Enabled = false;
            }
            int x = mobid.IndexOf(ID.ToString());
            if (x != -1)
            {
                if (!mobname[mobid.IndexOf(ID.ToString())].ToUpper().Contains(xisearch.ToUpper()))
                {
                    xiwarning = true;
                }
                MonsterNameSearchTextbox.Text = mobname[x];
                for (int y = 0; y < xholder.Count; y++)
                {
                    if (mobid[xholder[y]] == mobid[x])
                    {
                        MonsterSearchListbox.SelectedIndex = y;
                    }
                }
                IDSearch(x);
            }
            else
            {
                string message = "Invalid ID";
                string title = "Error";
                MessageBox.Show(message, title);
                Thread.CurrentThread.CurrentCulture = ci;
                Thread.CurrentThread.CurrentUICulture = ci;
            }
        }

        // #Page2

        string[] skillsplit;
        public static List<string> skillid = new List<string>();
        public static List<string> skillname = new List<string>();
        List<string> skilltarget = new List<string>();
        public static List<string> skillstatus = new List<string>();
        List<string> skillaoe = new List<string>();
        List<string> skillrange = new List<string>();
        List<string> skilldamagetype = new List<string>();
        List<string> skillability = new List<string>();
        List<string> skillsubtype = new List<string>();
        List<string> skillmissilespeed = new List<string>();
        List<string> skillreporttime = new List<string>();
        public static List<string> skillblocktime = new List<string>();
        List<string> skillprimstat = new List<string>();
        List<string> skillprimmod = new List<string>();
        public static List<string> skillauto = new List<string>();
        List<string> skillevasion = new List<string>();
        public static List<int> yholder = new List<int>();
        public static List<int> yholderamount = new List<int>();
        public static List<int> yholderid = new List<int>();
        public static List<int> yholder2 = new List<int>();
        public static List<string> statusidlist = new List<string>();
        public static List<int> yholder3 = new List<int>();
        public static List<int> yholder4 = new List<int>();
        bool statusonskill;
        bool autosearch = true;
        int statusskillcarry;

        string[] skilllvsplit;
        public static List<string> skilllvid = new List<string>();
        public static List<string> skilllvlevel = new List<string>();
        List<string> skilllvinitialdamage = new List<string>();
        public static List<string> skilllvcasttime = new List<string>();
        public static List<string> skilllvcooldown = new List<string>();
        List<string> skilllvenergy = new List<string>();
        List<string> skilllvinterrupt = new List<string>();
        List<string> skilllvreq = new List<string>();
        public static List<string> skilllvpvp = new List<string>();
        List<string> skilllvbaseamount = new List<string>();
        List<string> skilllvaggromulti = new List<string>();

        string[] statussplit;
        public static List<string> statusid = new List<string>();
        public static List<string> statusname = new List<string>();
        public static List<string> statuseffect = new List<string>();
        List<string> statusdamage = new List<string>();
        List<string> statusitem = new List<string>();
        List<string> statusdeath = new List<string>();
        List<string> statusability = new List<string>();
        List<string> statusbreak = new List<string>();
        List<string> statuspause = new List<string>();
        public static List<string> statustick = new List<string>();
        public static List<string> statusaura = new List<string>();

        string[] statuslvsplit;
        public static List<string> statuslvid = new List<string>();
        List<string> statuslvlevel = new List<string>();
        public static List<string> statuslvinitial = new List<string>();
        public static List<string> statuslvduration = new List<string>();
        public static List<string> statuslvpvp = new List<string>();
        public static List<string> statuslvbase = new List<string>();

        string[] aura;
        string[] aurasplit;
        public static List<string> auraid = new List<string>();
        public static List<string> auraeffectid = new List<string>();
        public static List<string> auratarget = new List<string>();
        public static List<string> aurarange = new List<string>();

        string[] effect;
        string[] effectsplit;
        public static List<string> effectid = new List<string>();
        public static List<string> effectname = new List<string>();
        public static List<string> effecttype = new List<string>();
        public static List<string> effectarmor = new List<string>();
        public static List<string> effectbonus = new List<string>();
        public static List<string> effectdamage = new List<string>();
        public static List<string> effectevasion = new List<string>();
        public static List<string> effectimmune = new List<string>();
        public static List<string> effectreduction = new List<string>();
        public static List<string> effectstat = new List<string>();
        public static List<string> effectability = new List<string>();
        public static List<string> effectskill = new List<string>();

        List<List<int>> yiholder = new List<List<int>>();
        int yilength = 0;
        int yilength2 = 0;
        string yisearch;
        bool yiwarning = false;

        List<List<int>> yi2holder = new List<List<int>>();
        int yi2length = 0;
        int yi2length2 = 0;
        string yi2search;
        bool yi2warning = false;

        public static int auracarry = 0;
        public static int effectcarry = 0;
        public static string abilitycarry = "0";
        bool skilllevelskip = false;
        bool statuslevelskip = false;

        private void SkillNameSearchTextbox_TextChanged(object sender, EventArgs e)
        {
            SkillSearchListbox.Items.Clear();
            SkillLevelDropdown.Items.Clear();
            StatusNameSearchTextbox.Clear();
            StatusLevelDropdown.Items.Clear();
            AutoDamageSkill.Text = "???";
            CriticalAllowedSkill.Text = "???";
            AggroMultiSkill.Text = "???";
            AOESkill.Text = "???";
            CastingRangeSkill.Text = "???";
            CastingTimeSkill.Text = "???";
            CooldownSkill.Text = "???";
            ReportTimeSkill.Text = "???";
            LockoutTimeSkill.Text = "???";
            MissileSpeedSkill.Text = "???";
            InitialValueSkill.Text = "???";
            BaseValueSkill.Text = "???";
            DamageTypeSkill.Text = "???";
            EnergyCostSkill.Text = "???";
            LevelRequiredSkill.Text = "???";
            WeaponRequiredSkill.Text = "???";
            StatusInflictedSkill.Text = "???";
            CastingTargetSkill.Text = "???";
            EvasionUsedSkill.Text = "???";
            InterruptibilitySkill.Text = "???";
            StatusFormula1.Text = "Status Formula 1: NO STATUS AND/OR LEVEL SELECTED";
            StatusFormula2.Text = "Status Formula 2: NO STATUS AND/OR LEVEL SELECTED";
            DeathRemovesStatus.Text = "???";
            AggroRemovesStatus.Text = "???";
            AggroPausesStatus.Text = "???";
            DurationStatus.Text = "???";
            TickRateStatus.Text = "???";
            UpToLevelStatus.Text = "???";
            CriticalAllowedStatus.Text = "???";
            InitialValueStatus.Text = "???";
            BaseValueStatus.Text = "???";
            DamageTypeStatus.Text = "???";
            yholder.Clear();
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
                    if (skillname[yiholder[SkillNameSearchTextbox.Text.Length][i]].ToUpper().Contains(SkillNameSearchTextbox.Text.ToUpper()))
                    {
                        SkillSearchListbox.Items.Add(skillname[yiholder[SkillNameSearchTextbox.Text.Length][i]]);
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
                        if (skillname[yiholder[yilength][i]].ToUpper().Contains(SkillNameSearchTextbox.Text.Substring(0, yilength + 1).ToUpper()))
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
                    SkillSearchListbox.Items.Add(skillname[yiholder[yilength][i]]);
                }
            }
            SkillSearchListbox.EndUpdate();
            yisearch = SkillNameSearchTextbox.Text;
            yiwarning = false;
        }

        private void SkillSearchListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            statusonskill = false;
            ExtraDataButton.Enabled = false;
            yholder2.Clear();
            if (SkillSearchListbox.SelectedIndex > -1)
            {
                SkillLevelDropdown.Items.Clear();
                if (statusid.IndexOf(skillstatus[yholder[SkillSearchListbox.SelectedIndex]]) != -1)
                {
                    StatusInflictedSkill.Text = statusname[statusid.IndexOf(skillstatus[yholder[SkillSearchListbox.SelectedIndex]])];
                    statusonskill = true;
                }
                else
                {
                    StatusInflictedSkill.Text = "None";
                    if (AutoSearchStatusCheckbox.Checked == true)
                    {
                        yholder3.Clear();
                        StatusSearchListbox.Items.Clear();
                        StatusNameSearchTextbox.Text = null;
                        StatusLevelDropdown.Items.Clear();
                        UpToLevelStatus.Text = "???";
                        DamageTypeStatus.Text = "???";
                        DeathRemovesStatus.Text = "???";
                        AggroRemovesStatus.Text = "???";
                        AggroPausesStatus.Text = "???";
                        TickRateStatus.Text = "???";
                        InitialValueStatus.Text = "???";
                        DurationStatus.Text = "???";
                        BaseValueStatus.Text = "???";
                        CriticalAllowedStatus.Text = "???";
                        StatusFormula1.Text = "Status Formula 1: ???";
                        StatusFormula2.Text = "Status Formula 2: ???";
                    }
                }
                CastingTargetSkill.Text = skilltarget[yholder[SkillSearchListbox.SelectedIndex]];
                AOESkill.Text = skillaoe[yholder[SkillSearchListbox.SelectedIndex]];
                CastingRangeSkill.Text = skillrange[yholder[SkillSearchListbox.SelectedIndex]];
                DamageTypeSkill.Text = skilldamagetype[yholder[SkillSearchListbox.SelectedIndex]];
                WeaponRequiredSkill.Text = skillsubtype[yholder[SkillSearchListbox.SelectedIndex]];
                MissileSpeedSkill.Text = skillmissilespeed[yholder[SkillSearchListbox.SelectedIndex]];
                ReportTimeSkill.Text = skillreporttime[yholder[SkillSearchListbox.SelectedIndex]];
                LockoutTimeSkill.Text = skillblocktime[yholder[SkillSearchListbox.SelectedIndex]];
                AutoDamageSkill.Text = skillauto[yholder[SkillSearchListbox.SelectedIndex]];
                EvasionUsedSkill.Text = skillevasion[yholder[SkillSearchListbox.SelectedIndex]];
                int old = -1;
                if (skilllvid.IndexOf(skillid[yholder[SkillSearchListbox.SelectedIndex]]) != -1)
                {
                    for (int i = 0; i < skilllvid.Count; i++)
                    {
                        if (skillid[yholder[SkillSearchListbox.SelectedIndex]] == skilllvid[i])
                        {
                            if (Convert.ToInt32(skilllvlevel[i]) != old)
                            {
                                SkillLevelDropdown.Items.Add((Convert.ToInt32(skilllvlevel[i]) + 1).ToString());
                            }
                            old = Convert.ToInt32(skilllvlevel[i]);
                            yholder2.Add(i);
                        }
                    }
                }
                if (SkillLevelDropdown.Items.Count > 0)
                {
                    skilllevelskip = true;
                    SkillLevelDropdown.SelectedIndex = 0;
                    skilllevelskip = false;
                    if (yholder2.Count > 1)
                    {
                        if (skilllvpvp[yholder2[1]] == "1")
                        {
                            if (skilllvinitialdamage[yholder2[0]] != skilllvinitialdamage[yholder2[1]])
                            {
                                InitialValueSkill.Text = skilllvinitialdamage[yholder2[0]] + "(" + skilllvinitialdamage[yholder2[1]] + ")";
                            }
                            else InitialValueSkill.Text = skilllvinitialdamage[yholder2[0]];
                            if (skilllvcasttime[yholder2[0]] != skilllvcasttime[yholder2[1]])
                            {
                                CastingTimeSkill.Text = skilllvcasttime[yholder2[0]] + "(" + skilllvcasttime[yholder2[1]] + ")";
                            }
                            else CastingTimeSkill.Text = skilllvcasttime[yholder2[0]];
                            if (skilllvcooldown[yholder2[0]] != skilllvcooldown[yholder2[1]])
                            {
                                CooldownSkill.Text = skilllvcooldown[yholder2[0]] + "(" + skilllvcooldown[yholder2[1]] + ")";
                            }
                            else CooldownSkill.Text = skilllvcooldown[yholder2[0]];
                            if (skilllvenergy[yholder2[0]] != skilllvenergy[yholder2[1]])
                            {
                                EnergyCostSkill.Text = skilllvenergy[yholder2[0]] + "(" + skilllvenergy[yholder2[1]] + ")";
                            }
                            else EnergyCostSkill.Text = skilllvenergy[yholder2[0]];
                            if (skilllvinterrupt[yholder2[0]] != skilllvinterrupt[yholder2[1]])
                            {
                                InterruptibilitySkill.Text = skilllvinterrupt[yholder2[0]] + "%(" + skilllvinterrupt[yholder2[1]] + "%)";
                            }
                            else InterruptibilitySkill.Text = skilllvinterrupt[yholder2[0]] + "%";
                            if (skilllvreq[yholder2[0]] != skilllvreq[yholder2[1]])
                            {
                                LevelRequiredSkill.Text = skilllvreq[yholder2[0]] + "(" + skilllvreq[yholder2[1]] + ")";
                            }
                            else LevelRequiredSkill.Text = skilllvreq[yholder2[0]];
                            if (skilllvbaseamount[yholder2[0]] != skilllvbaseamount[yholder2[1]])
                            {
                                BaseValueSkill.Text = skilllvbaseamount[yholder2[0]] + "(" + skilllvbaseamount[yholder2[1]] + ")";
                            }
                            else BaseValueSkill.Text = skilllvbaseamount[yholder2[0]];
                            if (skilllvaggromulti[yholder2[0]] != skilllvaggromulti[yholder2[1]])
                            {
                                AggroMultiSkill.Text = skilllvaggromulti[yholder2[0]] + "(" + skilllvaggromulti[yholder2[1]] + ")";
                            }
                            else AggroMultiSkill.Text = skilllvaggromulti[yholder2[0]];
                            if (((skilllvinitialdamage[yholder2[0]] != "0" || skilllvinitialdamage[yholder2[1]] != "0" || skilllvbaseamount[yholder2[0]] != "0" || skilllvbaseamount[yholder2[1]] != "0") == true || skillauto[yholder[SkillSearchListbox.SelectedIndex]] == "Yes") && (skillability[yholder[SkillSearchListbox.SelectedIndex]] != "None" || skillid[yholder[SkillSearchListbox.SelectedIndex]] == "212" || skillid[yholder[SkillSearchListbox.SelectedIndex]] == "252") && (skillid[yholder[SkillSearchListbox.SelectedIndex]] != "145" && skillid[yholder[SkillSearchListbox.SelectedIndex]] != "32" && skillid[yholder[SkillSearchListbox.SelectedIndex]] != "33" && skillid[yholder[SkillSearchListbox.SelectedIndex]] != "34" && skillid[yholder[SkillSearchListbox.SelectedIndex]] != "128"))
                            {
                                CriticalAllowedSkill.Text = "Yes";
                            }
                            else
                            {
                                CriticalAllowedSkill.Text = "No";
                            }
                        }
                        else
                        {
                            InitialValueSkill.Text = skilllvinitialdamage[yholder2[0]];
                            CastingTimeSkill.Text = skilllvcasttime[yholder2[0]];
                            CooldownSkill.Text = skilllvcooldown[yholder2[0]];
                            EnergyCostSkill.Text = skilllvenergy[yholder2[0]];
                            InterruptibilitySkill.Text = skilllvinterrupt[yholder2[0]] + "%";
                            LevelRequiredSkill.Text = skilllvreq[yholder2[0]];
                            BaseValueSkill.Text = skilllvbaseamount[yholder2[0]];
                            AggroMultiSkill.Text = skilllvaggromulti[yholder2[0]];
                            if (((skilllvinitialdamage[yholder2[0]] != "0" || skilllvbaseamount[yholder2[0]] != "0") == true || skillauto[yholder[SkillSearchListbox.SelectedIndex]] == "Yes") && (skillability[yholder[SkillSearchListbox.SelectedIndex]] != "None" || skillid[yholder[SkillSearchListbox.SelectedIndex]] == "212" || skillid[yholder[SkillSearchListbox.SelectedIndex]] == "252") && (skillid[yholder[SkillSearchListbox.SelectedIndex]] != "145" && skillid[yholder[SkillSearchListbox.SelectedIndex]] != "32" && skillid[yholder[SkillSearchListbox.SelectedIndex]] != "33" && skillid[yholder[SkillSearchListbox.SelectedIndex]] != "34" && skillid[yholder[SkillSearchListbox.SelectedIndex]] != "128"))
                            {
                                CriticalAllowedSkill.Text = "Yes";
                            }
                            else
                            {
                                CriticalAllowedSkill.Text = "No";
                            }
                        }
                    }
                    else
                    {
                        InitialValueSkill.Text = skilllvinitialdamage[yholder2[0]];
                        CastingTimeSkill.Text = skilllvcasttime[yholder2[0]];
                        CooldownSkill.Text = skilllvcooldown[yholder2[0]];
                        EnergyCostSkill.Text = skilllvenergy[yholder2[0]];
                        InterruptibilitySkill.Text = skilllvinterrupt[yholder2[0]] + "%";
                        LevelRequiredSkill.Text = skilllvreq[yholder2[0]];
                        BaseValueSkill.Text = skilllvbaseamount[yholder2[0]];
                        AggroMultiSkill.Text = skilllvaggromulti[yholder2[0]];
                        if (((skilllvinitialdamage[yholder2[0]] != "0" || skilllvbaseamount[yholder2[0]] != "0") == true || skillauto[yholder[SkillSearchListbox.SelectedIndex]] == "Yes") && (skillability[yholder[SkillSearchListbox.SelectedIndex]] != "None" || skillid[yholder[SkillSearchListbox.SelectedIndex]] == "212" || skillid[yholder[SkillSearchListbox.SelectedIndex]] == "252") && (skillid[yholder[SkillSearchListbox.SelectedIndex]] != "145" && skillid[yholder[SkillSearchListbox.SelectedIndex]] != "32" && skillid[yholder[SkillSearchListbox.SelectedIndex]] != "33" && skillid[yholder[SkillSearchListbox.SelectedIndex]] != "34" && skillid[yholder[SkillSearchListbox.SelectedIndex]] != "128"))
                        {
                            CriticalAllowedSkill.Text = "Yes";
                        }
                        else
                        {
                            CriticalAllowedSkill.Text = "No";
                        }
                    }
                    if (skillauto[yholder[SkillSearchListbox.SelectedIndex]] == "Yes")
                    {
                        SkillFormula.Text = "Skill Formula: " + skilllvbaseamount[yholder2[0]] + " + " + skilllvinitialdamage[yholder2[0]] + " * (1 + √(" + skillprimstat[yholder[SkillSearchListbox.SelectedIndex]] + "/" + skillprimmod[yholder[SkillSearchListbox.SelectedIndex]] + ") + √(" + skillability[yholder[SkillSearchListbox.SelectedIndex]] + "/100)) + Auto Damage";
                    }
                    else
                    {
                        SkillFormula.Text = "Skill Formula: " + skilllvbaseamount[yholder2[0]] + " + " + skilllvinitialdamage[yholder2[0]] + " * (1 + √(" + skillprimstat[yholder[SkillSearchListbox.SelectedIndex]] + "/" + skillprimmod[yholder[SkillSearchListbox.SelectedIndex]] + ") + √(" + skillability[yholder[SkillSearchListbox.SelectedIndex]] + "/100))";
                    }
                }
                else
                {
                    InitialValueSkill.Text = "???";
                    CastingTimeSkill.Text = "???";
                    CooldownSkill.Text = "???";
                    EnergyCostSkill.Text = "???";
                    InterruptibilitySkill.Text = "???";
                    LevelRequiredSkill.Text = "???";
                    BaseValueSkill.Text = "???";
                    AggroMultiSkill.Text = "???";
                    CriticalAllowedSkill.Text = "???";
                    SkillFormula.Text = "Skill Formula: ???";
                }
            }
            if (AutoSearchStatusCheckbox.Checked == true && statusonskill == true)
            {
                StatusLevelDropdown.Items.Clear();
                yholder4.Clear();
                int olda = -1;
                for (int i = 0; i < statuslvid.Count; i++)
                {
                    if (statusid[statusid.IndexOf(skillstatus[yholder[SkillSearchListbox.SelectedIndex]])] == statuslvid[i])
                    {
                        if (Convert.ToInt32(statuslvlevel[i]) != olda)
                        {
                            StatusLevelDropdown.Items.Add((Convert.ToInt32(statuslvlevel[i]) + 1).ToString());
                        }
                        olda = Convert.ToInt32(statuslvlevel[i]);
                        yholder4.Add(i);
                    }
                }
                StatusNameSearchTextbox.Text = statusname[statusid.IndexOf(skillstatus[yholder[SkillSearchListbox.SelectedIndex]])];
                StatusSearchListbox.Items.Clear();
                statusskillcarry = statusid.IndexOf(skillstatus[yholder[SkillSearchListbox.SelectedIndex]]);
                if (StatusLevelDropdown.Items.Count > 0)
                {
                    statuslevelskip = true;
                    StatusLevelDropdown.SelectedIndex = 0;
                    statuslevelskip = false;
                    DamageTypeStatus.Text = statusdamage[statusskillcarry];
                    DeathRemovesStatus.Text = statusdeath[statusskillcarry];
                    AggroRemovesStatus.Text = statusbreak[statusskillcarry];
                    AggroPausesStatus.Text = statuspause[statusskillcarry];
                    TickRateStatus.Text = statustick[statusskillcarry];
                    StatusDisplay(0);
                }
                else
                {
                    DamageTypeStatus.Text = "???";
                    DeathRemovesStatus.Text = "???";
                    AggroRemovesStatus.Text = "???";
                    AggroPausesStatus.Text = "???";
                    TickRateStatus.Text = "???";
                    InitialValueStatus.Text = "???";
                    DurationStatus.Text = "???";
                    BaseValueStatus.Text = "???";
                    CriticalAllowedStatus.Text = "???";
                    StatusFormula1.Text = "Status Formula 1: ???";
                    StatusFormula2.Text = "Status Formula 2: ???";
                    UpToLevelStatus.Text = "???";
                }
            }
        }

        private void SkillLevelDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (skilllevelskip == false)
            {
                if (SkillLevelDropdown.SelectedIndex > -1)
                {
                    if (yholder2.Count > 1)
                    {
                        if (skilllvpvp[yholder2[1]] == "1")
                        {
                            if (skilllvinitialdamage[yholder2[SkillLevelDropdown.SelectedIndex * 2]] != skilllvinitialdamage[yholder2[SkillLevelDropdown.SelectedIndex * 2 + 1]])
                            {
                                InitialValueSkill.Text = skilllvinitialdamage[yholder2[SkillLevelDropdown.SelectedIndex * 2]] + "(" + skilllvinitialdamage[yholder2[SkillLevelDropdown.SelectedIndex * 2 + 1]] + ")";
                            }
                            else InitialValueSkill.Text = skilllvinitialdamage[yholder2[SkillLevelDropdown.SelectedIndex * 2]];
                            if (skilllvcasttime[yholder2[SkillLevelDropdown.SelectedIndex * 2]] != skilllvcasttime[yholder2[SkillLevelDropdown.SelectedIndex * 2 + 1]])
                            {
                                CastingTimeSkill.Text = skilllvcasttime[yholder2[SkillLevelDropdown.SelectedIndex * 2]] + "(" + skilllvcasttime[yholder2[SkillLevelDropdown.SelectedIndex * 2 + 1]] + ")";
                            }
                            else CastingTimeSkill.Text = skilllvcasttime[yholder2[SkillLevelDropdown.SelectedIndex * 2]];
                            if (skilllvcooldown[yholder2[SkillLevelDropdown.SelectedIndex * 2]] != skilllvcooldown[yholder2[SkillLevelDropdown.SelectedIndex * 2 + 1]])
                            {
                                CooldownSkill.Text = skilllvcooldown[yholder2[SkillLevelDropdown.SelectedIndex * 2]] + "(" + skilllvcooldown[yholder2[SkillLevelDropdown.SelectedIndex * 2 + 1]] + ")";
                            }
                            else CooldownSkill.Text = skilllvcooldown[yholder2[SkillLevelDropdown.SelectedIndex * 2]];
                            if (skilllvenergy[yholder2[SkillLevelDropdown.SelectedIndex * 2]] != skilllvenergy[yholder2[SkillLevelDropdown.SelectedIndex * 2 + 1]])
                            {
                                EnergyCostSkill.Text = skilllvenergy[yholder2[SkillLevelDropdown.SelectedIndex * 2]] + "(" + skilllvenergy[yholder2[SkillLevelDropdown.SelectedIndex * 2 + 1]] + ")";
                            }
                            else EnergyCostSkill.Text = skilllvenergy[yholder2[SkillLevelDropdown.SelectedIndex * 2]];
                            if (skilllvinterrupt[yholder2[SkillLevelDropdown.SelectedIndex * 2]] != skilllvinterrupt[yholder2[SkillLevelDropdown.SelectedIndex * 2 + 1]])
                            {
                                InterruptibilitySkill.Text = skilllvinterrupt[yholder2[SkillLevelDropdown.SelectedIndex * 2]] + "%(" + skilllvinterrupt[yholder2[SkillLevelDropdown.SelectedIndex * 2 + 1]] + "%)";
                            }
                            else InterruptibilitySkill.Text = skilllvinterrupt[yholder2[SkillLevelDropdown.SelectedIndex * 2]] + "%";
                            if (skilllvreq[yholder2[SkillLevelDropdown.SelectedIndex * 2]] != skilllvreq[yholder2[SkillLevelDropdown.SelectedIndex * 2 + 1]])
                            {
                                LevelRequiredSkill.Text = skilllvreq[yholder2[SkillLevelDropdown.SelectedIndex * 2]] + "(" + skilllvreq[yholder2[SkillLevelDropdown.SelectedIndex * 2 + 1]] + ")";
                            }
                            else LevelRequiredSkill.Text = skilllvreq[yholder2[SkillLevelDropdown.SelectedIndex * 2]];
                            if (skilllvbaseamount[yholder2[SkillLevelDropdown.SelectedIndex * 2]] != skilllvbaseamount[yholder2[SkillLevelDropdown.SelectedIndex * 2 + 1]])
                            {
                                BaseValueSkill.Text = skilllvbaseamount[yholder2[SkillLevelDropdown.SelectedIndex * 2]] + "(" + skilllvbaseamount[yholder2[SkillLevelDropdown.SelectedIndex * 2 + 1]] + ")";
                            }
                            else BaseValueSkill.Text = skilllvbaseamount[yholder2[SkillLevelDropdown.SelectedIndex * 2]];
                            if (skilllvaggromulti[yholder2[SkillLevelDropdown.SelectedIndex * 2]] != skilllvaggromulti[yholder2[SkillLevelDropdown.SelectedIndex * 2 + 1]])
                            {
                                AggroMultiSkill.Text = skilllvaggromulti[yholder2[SkillLevelDropdown.SelectedIndex * 2]] + "(" + skilllvaggromulti[yholder2[SkillLevelDropdown.SelectedIndex * 2 + 1]] + ")";
                            }
                            else AggroMultiSkill.Text = skilllvaggromulti[yholder2[SkillLevelDropdown.SelectedIndex * 2]];
                            if (((skilllvinitialdamage[yholder2[0]] != "0" || skilllvinitialdamage[yholder2[1]] != "0" || skilllvbaseamount[yholder2[0]] != "0" || skilllvbaseamount[yholder2[1]] != "0") == true || skillauto[yholder[SkillSearchListbox.SelectedIndex]] == "Yes") && (skillability[yholder[SkillSearchListbox.SelectedIndex]] != "None" && skillability[yholder[SkillSearchListbox.SelectedIndex]] != "???" || skillid[yholder[SkillSearchListbox.SelectedIndex]] == "212" || skillid[yholder[SkillSearchListbox.SelectedIndex]] == "252") && (skillid[yholder[SkillSearchListbox.SelectedIndex]] != "145" && skillid[yholder[SkillSearchListbox.SelectedIndex]] != "32" && skillid[yholder[SkillSearchListbox.SelectedIndex]] != "33" && skillid[yholder[SkillSearchListbox.SelectedIndex]] != "34" && skillid[yholder[SkillSearchListbox.SelectedIndex]] != "128"))
                            {
                                CriticalAllowedSkill.Text = "Yes";
                            }
                            else
                            {
                                CriticalAllowedSkill.Text = "No";
                            }
                            if (skillauto[yholder[SkillSearchListbox.SelectedIndex]] == "Yes")
                            {
                                SkillFormula.Text = "Skill Formula: " + skilllvbaseamount[yholder2[SkillLevelDropdown.SelectedIndex * 2]] + " + " + skilllvinitialdamage[yholder2[SkillLevelDropdown.SelectedIndex * 2]] + " * (1 + √(" + skillprimstat[yholder[SkillSearchListbox.SelectedIndex]] + "/" + skillprimmod[yholder[SkillSearchListbox.SelectedIndex]] + ") + √(" + skillability[yholder[SkillSearchListbox.SelectedIndex]] + "/100)) + Auto Damage";
                            }
                            else
                            {
                                SkillFormula.Text = "Skill Formula: " + skilllvbaseamount[yholder2[SkillLevelDropdown.SelectedIndex * 2]] + " + " + skilllvinitialdamage[yholder2[SkillLevelDropdown.SelectedIndex * 2]] + " * (1 + √(" + skillprimstat[yholder[SkillSearchListbox.SelectedIndex]] + "/" + skillprimmod[yholder[SkillSearchListbox.SelectedIndex]] + ") + √(" + skillability[yholder[SkillSearchListbox.SelectedIndex]] + "/100))";
                            }
                        }
                        else
                        {
                            InitialValueSkill.Text = skilllvinitialdamage[yholder2[SkillLevelDropdown.SelectedIndex]];
                            CastingTimeSkill.Text = skilllvcasttime[yholder2[SkillLevelDropdown.SelectedIndex]];
                            CooldownSkill.Text = skilllvcooldown[yholder2[SkillLevelDropdown.SelectedIndex]];
                            EnergyCostSkill.Text = skilllvenergy[yholder2[SkillLevelDropdown.SelectedIndex]];
                            InterruptibilitySkill.Text = skilllvinterrupt[yholder2[SkillLevelDropdown.SelectedIndex]] + "%";
                            LevelRequiredSkill.Text = skilllvreq[yholder2[SkillLevelDropdown.SelectedIndex]];
                            BaseValueSkill.Text = skilllvbaseamount[yholder2[SkillLevelDropdown.SelectedIndex]];
                            AggroMultiSkill.Text = skilllvaggromulti[yholder2[SkillLevelDropdown.SelectedIndex]];
                            if (((skilllvinitialdamage[yholder2[0]] != "0" || skilllvbaseamount[yholder2[0]] != "0") == true || skillauto[yholder[SkillSearchListbox.SelectedIndex]] == "Yes") && (statusability[statusskillcarry] != "None" && statusability[statusskillcarry] != "???" || skillid[yholder[SkillSearchListbox.SelectedIndex]] == "212" || skillid[yholder[SkillSearchListbox.SelectedIndex]] == "252"))
                            {
                                CriticalAllowedSkill.Text = "Yes";
                            }
                            else
                            {
                                CriticalAllowedSkill.Text = "No";
                            }
                            if (skillauto[yholder[SkillSearchListbox.SelectedIndex]] == "Yes")
                            {
                                SkillFormula.Text = "Skill Formula: " + skilllvbaseamount[yholder2[SkillLevelDropdown.SelectedIndex]] + " + " + skilllvinitialdamage[yholder2[SkillLevelDropdown.SelectedIndex]] + " * (1 + √(" + skillprimstat[yholder[SkillSearchListbox.SelectedIndex]] + "/" + skillprimmod[yholder[SkillSearchListbox.SelectedIndex]] + ") + √(" + skillability[yholder[SkillSearchListbox.SelectedIndex]] + "/100)) + Auto Damage";
                            }
                            else
                            {
                                SkillFormula.Text = "Skill Formula: " + skilllvbaseamount[yholder2[SkillLevelDropdown.SelectedIndex]] + " + " + skilllvinitialdamage[yholder2[SkillLevelDropdown.SelectedIndex]] + " * (1 + √(" + skillprimstat[yholder[SkillSearchListbox.SelectedIndex]] + "/" + skillprimmod[yholder[SkillSearchListbox.SelectedIndex]] + ") + √(" + skillability[yholder[SkillSearchListbox.SelectedIndex]] + "/100))";
                            }
                        }
                    }
                    else
                    {
                        InitialValueSkill.Text = skilllvinitialdamage[yholder2[SkillLevelDropdown.SelectedIndex * 2]];
                        CastingTimeSkill.Text = skilllvcasttime[yholder2[SkillLevelDropdown.SelectedIndex * 2]];
                        CooldownSkill.Text = skilllvcooldown[yholder2[SkillLevelDropdown.SelectedIndex * 2]];
                        EnergyCostSkill.Text = skilllvenergy[yholder2[SkillLevelDropdown.SelectedIndex * 2]];
                        InterruptibilitySkill.Text = skilllvinterrupt[yholder2[SkillLevelDropdown.SelectedIndex * 2]] + "%";
                        LevelRequiredSkill.Text = skilllvreq[yholder2[SkillLevelDropdown.SelectedIndex * 2]];
                        BaseValueSkill.Text = skilllvbaseamount[yholder2[SkillLevelDropdown.SelectedIndex * 2]];
                        AggroMultiSkill.Text = skilllvaggromulti[yholder2[SkillLevelDropdown.SelectedIndex * 2]];
                        if (((skilllvinitialdamage[yholder2[0]] != "0" || skilllvbaseamount[yholder2[0]] != "0") == true || skillauto[yholder[SkillSearchListbox.SelectedIndex]] == "Yes") && (statusability[statusskillcarry] != "None" && statusability[statusskillcarry] != "???" || skillid[yholder[SkillSearchListbox.SelectedIndex]] == "212" || skillid[yholder[SkillSearchListbox.SelectedIndex]] == "252"))
                        {
                            CriticalAllowedSkill.Text = "Yes";
                        }
                        else
                        {
                            CriticalAllowedSkill.Text = "No";
                        }
                        if (skillauto[yholder[SkillSearchListbox.SelectedIndex]] == "Yes")
                        {
                            SkillFormula.Text = "Skill Formula: " + skilllvbaseamount[yholder2[SkillLevelDropdown.SelectedIndex]] + " + " + skilllvinitialdamage[yholder2[SkillLevelDropdown.SelectedIndex]] + " * (1 + √(" + skillprimstat[yholder[SkillSearchListbox.SelectedIndex]] + "/" + skillprimmod[yholder[SkillSearchListbox.SelectedIndex]] + ") + √(" + skillability[yholder[SkillSearchListbox.SelectedIndex]] + "/100)) + Auto Damage";
                        }
                        else
                        {
                            SkillFormula.Text = "Skill Formula: " + skilllvbaseamount[yholder2[SkillLevelDropdown.SelectedIndex]] + " + " + skilllvinitialdamage[yholder2[SkillLevelDropdown.SelectedIndex]] + " * (1 + √(" + skillprimstat[yholder[SkillSearchListbox.SelectedIndex]] + "/" + skillprimmod[yholder[SkillSearchListbox.SelectedIndex]] + ") + √(" + skillability[yholder[SkillSearchListbox.SelectedIndex]] + "/100))";
                        }
                    }
                    if (AutoSearchStatusCheckbox.Checked == true && statusonskill == true)
                    {
                        if (StatusLevelDropdown.Items.Count > 0)
                        {
                            statuslevelskip = true;
                            StatusLevelDropdown.SelectedIndex = SkillLevelDropdown.SelectedIndex;
                            statuslevelskip = false;
                        }
                    }
                }
            }
        }

        private void StatusNameSearchTextbox_TextChanged(object sender, EventArgs e)
        {
            if (autosearch == false)
            {
                StatusSearchListbox.Items.Clear();
                StatusLevelDropdown.Items.Clear();
                StatusFormula1.Text = "Status Formula 1: NO STATUS AND/OR LEVEL SELECTED";
                StatusFormula2.Text = "Status Formula 2: NO STATUS AND/OR LEVEL SELECTED";
                DeathRemovesStatus.Text = "???";
                AggroRemovesStatus.Text = "???";
                AggroPausesStatus.Text = "???";
                DurationStatus.Text = "???";
                TickRateStatus.Text = "???";
                UpToLevelStatus.Text = "???";
                CriticalAllowedStatus.Text = "???";
                InitialValueStatus.Text = "???";
                BaseValueStatus.Text = "???";
                DamageTypeStatus.Text = "???";
                yholder3.Clear();
                StatusSearchListbox.BeginUpdate();
                yi2length2 = StatusNameSearchTextbox.Text.Length - yi2length;
                if (string.IsNullOrEmpty(yi2search) == false)
                {
                    if (yi2search.Length > StatusNameSearchTextbox.Text.Length)
                    {
                        if (yi2search.Substring(0, StatusNameSearchTextbox.Text.Length) != StatusNameSearchTextbox.Text)
                        {
                            yi2warning = true;
                        }
                    }
                    else
                    {
                        if (StatusNameSearchTextbox.Text.Substring(0, yi2search.Length) != yi2search)
                        {
                            yi2warning = true;
                        }
                    }
                }
                if (yi2length > StatusNameSearchTextbox.Text.Length && yi2warning == false)
                {
                    for (int i = 0; i < yi2holder[StatusNameSearchTextbox.Text.Length].Count; i++)
                    {
                        if (statusname[yi2holder[StatusNameSearchTextbox.Text.Length][i]].ToUpper().Contains(StatusNameSearchTextbox.Text.ToUpper()))
                        {
                            StatusSearchListbox.Items.Add(statusname[yi2holder[StatusNameSearchTextbox.Text.Length][i]]);
                            yholder3.Add(yi2holder[StatusNameSearchTextbox.Text.Length][i]);
                        }
                    }
                    yi2holder.RemoveRange(StatusNameSearchTextbox.Text.Length + 1, yi2length - StatusNameSearchTextbox.Text.Length);
                    yi2length = StatusNameSearchTextbox.Text.Length;
                }
                else
                {
                    if (yi2warning == true)
                    {
                        yi2length = 0;
                        yi2holder.RemoveRange(1, yi2holder.Count - 1);
                    }
                    yi2length2 = yi2length;
                    for (int a = 0; a < StatusNameSearchTextbox.Text.Length - yi2length2; a++)
                    {
                        yi2holder.Add(new List<int>());
                        for (int i = 0; i < yi2holder[yi2length].Count; i++)
                        {
                            if (statusname[yi2holder[yi2length][i]].ToUpper().Contains(StatusNameSearchTextbox.Text.Substring(0, yi2length + 1).ToUpper()))
                            {
                                yi2holder[yi2length + 1].Add(yi2holder[yi2length][i]);
                            }
                        }
                        yi2length = yi2length + 1;
                    }
                    for (int i = 0; i < yi2holder[yi2length].Count; i++)
                    {
                        yholder3.Add(yi2holder[yi2length][i]);
                        StatusSearchListbox.Items.Add(statusname[yi2holder[yi2length][i]]);
                    }
                }
                StatusSearchListbox.EndUpdate();
                yi2search = StatusNameSearchTextbox.Text;
                yi2warning = false;
            }
        }

        private void StatusSearchListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            yholder4.Clear();
            if (StatusSearchListbox.SelectedIndex > -1)
            {
                if (statusaura[yholder3[StatusSearchListbox.SelectedIndex]] != "0" || effectid.IndexOf(statusid[yholder3[StatusSearchListbox.SelectedIndex]]) != -1)
                {
                    ExtraDataButton.Enabled = true;
                }
                else ExtraDataButton.Enabled = false;
                StatusLevelDropdown.Items.Clear();
                DamageTypeStatus.Text = statusdamage[yholder3[StatusSearchListbox.SelectedIndex]];
                DeathRemovesStatus.Text = statusdeath[yholder3[StatusSearchListbox.SelectedIndex]];
                AggroRemovesStatus.Text = statusbreak[yholder3[StatusSearchListbox.SelectedIndex]];
                AggroPausesStatus.Text = statuspause[yholder3[StatusSearchListbox.SelectedIndex]];
                TickRateStatus.Text = statustick[yholder3[StatusSearchListbox.SelectedIndex]];
                int old = -1;
                if (statuslvid.IndexOf(statusid[yholder3[StatusSearchListbox.SelectedIndex]]) != -1)
                {
                    for (int i = 0; i < statuslvid.Count; i++)
                    {
                        if (statusid[yholder3[StatusSearchListbox.SelectedIndex]] == statuslvid[i])
                        {
                            if (Convert.ToInt32(statuslvlevel[i]) != old)
                            {
                                StatusLevelDropdown.Items.Add((Convert.ToInt32(statuslvlevel[i]) + 1).ToString());
                            }
                            old = Convert.ToInt32(statuslvlevel[i]);
                            yholder4.Add(i);
                        }
                    }
                }
                if (StatusLevelDropdown.Items.Count > 0)
                {
                    statuslevelskip = true;
                    StatusLevelDropdown.SelectedIndex = 0;
                    statuslevelskip = false;
                }
                else
                {
                    DamageTypeStatus.Text = statusdamage[yholder3[StatusSearchListbox.SelectedIndex]];
                    DeathRemovesStatus.Text = statusdeath[yholder3[StatusSearchListbox.SelectedIndex]];
                    AggroRemovesStatus.Text = statusbreak[yholder3[StatusSearchListbox.SelectedIndex]];
                    AggroPausesStatus.Text = statuspause[yholder3[StatusSearchListbox.SelectedIndex]];
                    TickRateStatus.Text = statustick[yholder3[StatusSearchListbox.SelectedIndex]];
                    InitialValueStatus.Text = "???";
                    DurationStatus.Text = "???";
                    BaseValueStatus.Text = "???";
                    CriticalAllowedStatus.Text = "???";
                    StatusFormula1.Text = "Status Formula 1: ???";
                    StatusFormula2.Text = "Status Formula 2: ???";
                    UpToLevelStatus.Text = "???";
                }
            }
        }

        private void StatusLevelDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (statuslevelskip == false)
            {
                if (autosearch == false)
                {
                    StatusDisplay(1);
                }
                else
                {
                    StatusDisplay(0);
                }
            }
        }

        private void AutoSearchStatusCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (AutoSearchStatusCheckbox.Checked == false)
            {
                StatusSearchListbox.Items.Clear();
                StatusSearchListbox.Enabled = true;
                label102.Enabled = true;
                label104.Enabled = true;
                StatusNameSearchTextbox.Enabled = true;
                StatusLevelDropdown.Enabled = true;
                autosearch = false;
                StatusAutoSearchGroupbox.Visible = true;

                label60.Enabled = false;
                label57.Enabled = false;
                label58.Enabled = false;
                SkillNameSearchTextbox.Enabled = false;
                SkillNameSearchTextbox.Text = null;
                SkillLevelDropdown.Enabled = false;
                SkillLevelDropdown.Items.Clear();
                SkillSearchListbox.Enabled = false;
                SkillSearchListbox.Items.Clear();
                SkillFormula.Enabled = false;
                SkillFormula.Text = "Skill Formula: ???????????????????????????????????";
                label77.Enabled = false;
                label77.Text = "Auto Formula: ?????????????????????????????????";
                label95.Enabled = false;
                label83.Enabled = false;
                AutoDamageSkill.Enabled = false;
                AutoDamageSkill.Text = "???";
                label94.Enabled = false;
                CriticalAllowedSkill.Enabled = false;
                CriticalAllowedSkill.Text = "???";
                label87.Enabled = false;
                AggroMultiSkill.Enabled = false;
                AggroMultiSkill.Text = "???";
                label92.Enabled = false;
                AOESkill.Enabled = false;
                AOESkill.Text = "???";
                label82.Enabled = false;
                CastingRangeSkill.Enabled = false;
                CastingRangeSkill.Text = "???";
                label81.Enabled = false;
                CastingTimeSkill.Enabled = false;
                CastingTimeSkill.Text = "???";
                label80.Enabled = false;
                CooldownSkill.Enabled = false;
                CooldownSkill.Text = "???";
                label100.Enabled = false;
                ReportTimeSkill.Enabled = false;
                ReportTimeSkill.Text = "???";
                label99.Enabled = false;
                LockoutTimeSkill.Enabled = false;
                LockoutTimeSkill.Text = "???";
                label97.Enabled = false;
                MissileSpeedSkill.Enabled = false;
                MissileSpeedSkill.Text = "???";
                label78.Enabled = false;
                InitialValueSkill.Enabled = false;
                InitialValueSkill.Text = "???";
                label79.Enabled = false;
                BaseValueSkill.Enabled = false;
                BaseValueSkill.Text = "???";
                label93.Enabled = false;
                DamageTypeSkill.Enabled = false;
                DamageTypeSkill.Text = "???";
                label85.Enabled = false;
                EnergyCostSkill.Enabled = false;
                EnergyCostSkill.Text = "???";
                label86.Enabled = false;
                LevelRequiredSkill.Enabled = false;
                LevelRequiredSkill.Text = "???";
                label101.Enabled = false;
                WeaponRequiredSkill.Enabled = false;
                WeaponRequiredSkill.Text = "???";
                label96.Enabled = false;
                StatusInflictedSkill.Enabled = false;
                StatusInflictedSkill.Text = "???";
                label91.Enabled = false;
                CastingTargetSkill.Enabled = false;
                CastingTargetSkill.Text = "???";
                label98.Enabled = false;
                EvasionUsedSkill.Enabled = false;
                EvasionUsedSkill.Text = "???";
                label84.Enabled = false;
                InterruptibilitySkill.Enabled = false;
                InterruptibilitySkill.Text = "???";
                label119.Enabled = false;
                label33.Enabled = false;
                AutoFinal.Enabled = false;
                AutoFinal.Text = "???";
                label120.Enabled = false;
                SkillFinal.Enabled = false;
                SkillFinal.Text = "???";

                StatusNameSearchTextbox.Text = null;
                StatusLevelDropdown.Items.Clear();
                StatusSearchListbox.Items.Clear();
                StatusFormula1.Text = "Status Formula 1: NO STATUS AND/OR LEVEL SELECTED";
                StatusFormula2.Text = "Status Formula 2: NO STATUS AND/OR LEVEL SELECTED";
                DeathRemovesStatus.Text = "???";
                AggroRemovesStatus.Text = "???";
                AggroPausesStatus.Text = "???";
                DurationStatus.Text = "???";
                TickRateStatus.Text = "???";
                UpToLevelStatus.Text = "???";
                CriticalAllowedStatus.Text = "???";
                InitialValueStatus.Text = "???";
                BaseValueStatus.Text = "???";
                DamageTypeStatus.Text = "???";
                Status1Final.Text = "???";
                Status2Final.Text = "???";
            }
            else
            {
                StatusSearchListbox.Items.Clear();
                StatusSearchListbox.Enabled = false;
                label102.Enabled = false;
                label104.Enabled = false;
                StatusNameSearchTextbox.Enabled = false;
                StatusLevelDropdown.Enabled = false;
                autosearch = true;
                StatusAutoSearchGroupbox.Visible = false;

                label60.Enabled = true;
                label57.Enabled = true;
                label58.Enabled = true;
                SkillNameSearchTextbox.Enabled = true;
                SkillLevelDropdown.Enabled = true;
                SkillSearchListbox.Enabled = true;
                SkillFormula.Enabled = true;
                SkillFormula.Text = "Skill Formula: NO SKILL AND/OR LEVEL SELECTED";
                label77.Enabled = true;
                label77.Text = "Auto Formula: (Pierce+Slash+Crush) * (1 + √(Strength/40) + √(Weapon Ability/280)) + (Heat+Cold+Magic+Poison+Divine)";
                label95.Enabled = true;
                label83.Enabled = true;
                AutoDamageSkill.Enabled = true;
                label94.Enabled = true;
                CriticalAllowedSkill.Enabled = true;
                label87.Enabled = true;
                AggroMultiSkill.Enabled = true;
                label92.Enabled = true;
                AOESkill.Enabled = true;
                label82.Enabled = true;
                CastingRangeSkill.Enabled = true;
                label81.Enabled = true;
                CastingTimeSkill.Enabled = true;
                label80.Enabled = true;
                CooldownSkill.Enabled = true;
                label100.Enabled = true;
                ReportTimeSkill.Enabled = true;
                label99.Enabled = true;
                LockoutTimeSkill.Enabled = true;
                label97.Enabled = true;
                MissileSpeedSkill.Enabled = true;
                label78.Enabled = true;
                InitialValueSkill.Enabled = true;
                label79.Enabled = true;
                BaseValueSkill.Enabled = true;
                label93.Enabled = true;
                DamageTypeSkill.Enabled = true;
                label85.Enabled = true;
                EnergyCostSkill.Enabled = true;
                label86.Enabled = true;
                LevelRequiredSkill.Enabled = true;
                label101.Enabled = true;
                WeaponRequiredSkill.Enabled = true;
                label96.Enabled = true;
                StatusInflictedSkill.Enabled = true;
                label91.Enabled = true;
                CastingTargetSkill.Enabled = true;
                label98.Enabled = true;
                EvasionUsedSkill.Enabled = true;
                label84.Enabled = true;
                InterruptibilitySkill.Enabled = true;
                label119.Enabled = true;
                label33.Enabled = true;
                AutoFinal.Enabled = true;
                label120.Enabled = true;
                SkillFinal.Enabled = true;

                StatusNameSearchTextbox.Text = null;
                StatusLevelDropdown.Items.Clear();
                StatusSearchListbox.Items.Clear();
                StatusFormula1.Text = "Status Formula 1: NO STATUS AND/OR LEVEL SELECTED";
                StatusFormula2.Text = "Status Formula 2: NO STATUS AND/OR LEVEL SELECTED";
                DeathRemovesStatus.Text = "???";
                AggroRemovesStatus.Text = "???";
                AggroPausesStatus.Text = "???";
                DurationStatus.Text = "???";
                TickRateStatus.Text = "???";
                UpToLevelStatus.Text = "???";
                CriticalAllowedStatus.Text = "???";
                InitialValueStatus.Text = "???";
                BaseValueStatus.Text = "???";
                DamageTypeStatus.Text = "???";
                Status1Final.Text = "???";
                Status2Final.Text = "???";
            }
        }

        private void CalculateSkillButton_Click(object sender, EventArgs e)
        {
            List<TextBox> PrimStats = new List<TextBox>();
            PrimStats.Add(StrengthTextbox);
            PrimStats.Add(DexterityTextbox);
            PrimStats.Add(FocusTextbox);
            PrimStats.Add(VitalityTextbox);
            PrimStats.Add(new TextBox());
            int primstat = 0;
            int pvpmode = 0;
            float ability = 0;
            float primstatmod = 0; // prevents divides by zero from making a huge negative number
            string statustype;
            if (string.IsNullOrEmpty(PierceTextbox.Text) == true)
            {
                PierceTextbox.Text = "0";
            }
            if (string.IsNullOrEmpty(SlashTextbox.Text) == true)
            {
                SlashTextbox.Text = "0";
            }
            if (string.IsNullOrEmpty(CrushTextbox.Text) == true)
            {
                CrushTextbox.Text = "0";
            }
            if (string.IsNullOrEmpty(HeatTextbox.Text) == true)
            {
                HeatTextbox.Text = "0";
            }
            if (string.IsNullOrEmpty(ColdTextbox.Text) == true)
            {
                ColdTextbox.Text = "0";
            }
            if (string.IsNullOrEmpty(MagicTextbox.Text) == true)
            {
                MagicTextbox.Text = "0";
            }
            if (string.IsNullOrEmpty(PoisonTextbox.Text) == true)
            {
                PoisonTextbox.Text = "0";
            }
            if (string.IsNullOrEmpty(DivineTextbox.Text) == true)
            {
                DivineTextbox.Text = "0";
            }
            if (string.IsNullOrEmpty(StrengthTextbox.Text) == true)
            {
                StrengthTextbox.Text = "0";
            }
            if (string.IsNullOrEmpty(DexterityTextbox.Text) == true)
            {
                DexterityTextbox.Text = "0";
            }
            if (string.IsNullOrEmpty(FocusTextbox.Text) == true)
            {
                FocusTextbox.Text = "0";
            }
            if (string.IsNullOrEmpty(VitalityTextbox.Text) == true)
            {
                VitalityTextbox.Text = "0";
            }
            if (string.IsNullOrEmpty(WeaponAbilityTextbox.Text) == true)
            {
                WeaponAbilityTextbox.Text = "0";
            }
            if (string.IsNullOrEmpty(SkillAbilityTextbox.Text) == true)
            {
                SkillAbilityTextbox.Text = "0";
            }
            if (string.IsNullOrEmpty(SkillBoostTextbox.Text) == true)
            {
                SkillBoostTextbox.Text = "0";
            }
            if (string.IsNullOrEmpty(StatusOnlyStat.Text) == true)
            {
                StatusOnlyStat.Text = "0";
            }
            if (string.IsNullOrEmpty(StatusOnlyDivisor.Text) == true || StatusOnlyDivisor.Text == "0")
            {
                StatusOnlyDivisor.Text = "1";
            }
            if (string.IsNullOrEmpty(StatusOnlyAbility.Text) == true)
            {
                StatusOnlyAbility.Text = "0";
            }
            float automulti = (float)(Math.Sqrt(Convert.ToInt32(StrengthTextbox.Text) / 40.0) + Math.Sqrt(Convert.ToInt32(WeaponAbilityTextbox.Text) / 280.0) + 1);
            int autoflatdmg = Convert.ToInt32(HeatTextbox.Text) + Convert.ToInt32(ColdTextbox.Text) + Convert.ToInt32(MagicTextbox.Text) + Convert.ToInt32(PoisonTextbox.Text) + Convert.ToInt32(DivineTextbox.Text);
            solverpierce = Convert.ToInt32(PierceTextbox.Text);
            solverslash = Convert.ToInt32(SlashTextbox.Text);
            solvercrush = Convert.ToInt32(CrushTextbox.Text);
            AutoFinal.Text = ((int)(automulti * solverpierce) + (int)(automulti * solverslash) + (int)(automulti * solvercrush) + autoflatdmg).ToString() + " Damage";
            if (autosearch == true)
            {
                PrimStats[4].Text = "0";
                AutoFinal.Text = ((int)(automulti * solverpierce) + (int)(automulti * solverslash) + (int)(automulti * solvercrush) + autoflatdmg).ToString() + " Damage";
            }
            else
            {
                PrimStats[4].Text = StatusOnlyStat.Text;
                AutoFinal.Text = "???";
            }
            string finalizer;
            finalizer = null;
            if (autosearch == true && SkillSearchListbox.SelectedIndex != -1)
            {
                if (skillability[yholder[SkillSearchListbox.SelectedIndex]] != "None") ability = float.Parse(SkillAbilityTextbox.Text);
                else ability = 0;
                if (SkillSearchListbox.SelectedIndex != -1)
                {
                    if (skillprimstat[yholder[SkillSearchListbox.SelectedIndex]] == "Strength") primstat = 0;
                    else if (skillprimstat[yholder[SkillSearchListbox.SelectedIndex]] == "Dexterity") primstat = 1;
                    else if (skillprimstat[yholder[SkillSearchListbox.SelectedIndex]] == "Focus") primstat = 2;
                    else if (skillprimstat[yholder[SkillSearchListbox.SelectedIndex]] == "Vitality") primstat = 3;
                    else primstat = 4;
                    if (yholder2.Count > 1)
                    {
                        if (skilllvpvp[yholder2[1]] == "1") pvpmode = 2;
                        else pvpmode = 1;
                    }
                    else pvpmode = 1;
                    if (primstat == 4 || float.Parse(skillprimmod[yholder[SkillSearchListbox.SelectedIndex]]) == 0) primstatmod = 1;
                    else primstatmod = float.Parse(skillprimmod[yholder[SkillSearchListbox.SelectedIndex]]);
                    if (SkillLevelDropdown.Items.Count > 0)
                    {
                        if (skillid[yholder[SkillSearchListbox.SelectedIndex]] == "145")
                        {
                            finalizer = (int)Math.Ceiling(float.Parse(skilllvbaseamount[yholder2[SkillLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(skilllvinitialdamage[yholder2[SkillLevelDropdown.SelectedIndex * pvpmode]]) * (1 + Math.Sqrt(ability / 100.0f) + Math.Sqrt(float.Parse(PrimStats[primstat].Text) / primstatmod))) + -float.Parse(SkillBoostTextbox.Text) + " Energy";
                            SkillFinal.Text = finalizer.Substring(1);
                        }
                        else if (skillid[yholder[SkillSearchListbox.SelectedIndex]] == "156")
                        {
                            SkillFinal.Text = (int)Math.Ceiling((float.Parse(skilllvbaseamount[yholder2[SkillLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(skilllvinitialdamage[yholder2[SkillLevelDropdown.SelectedIndex * pvpmode]]) * (1 + Math.Sqrt(ability / 100.0f) + Math.Sqrt(float.Parse(PrimStats[primstat].Text) / primstatmod)))) + float.Parse(SkillBoostTextbox.Text) + " Energy";
                        }
                        else if (skillid[yholder[SkillSearchListbox.SelectedIndex]] == "32" || skillid[yholder[SkillSearchListbox.SelectedIndex]] == "33" || skillid[yholder[SkillSearchListbox.SelectedIndex]] == "34" || skillid[yholder[SkillSearchListbox.SelectedIndex]] == "128")
                        {
                            SkillFinal.Text = (int)Math.Ceiling((float.Parse(skilllvbaseamount[yholder2[SkillLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(skilllvinitialdamage[yholder2[SkillLevelDropdown.SelectedIndex * pvpmode]]) * (1 + Math.Sqrt(ability / 100.0f) + Math.Sqrt(float.Parse(PrimStats[primstat].Text) / primstatmod)))) + float.Parse(SkillBoostTextbox.Text) + " Aggro";
                        }
                        else if (skillid[yholder[SkillSearchListbox.SelectedIndex]] == "212" || skillid[yholder[SkillSearchListbox.SelectedIndex]] == "252")
                        {
                            SkillFinal.Text = (((int)(automulti * solverpierce) + (int)(automulti * solverslash) + (int)(automulti * solvercrush) + autoflatdmg) * 2).ToString() + " Damage";
                        }
                        else if (skillid[yholder[SkillSearchListbox.SelectedIndex]] == "342")
                        {
                            SkillFinal.Text = (((float.Parse(skilllvinitialdamage[yholder2[SkillLevelDropdown.SelectedIndex]]) + float.Parse(skilllvbaseamount[yholder2[SkillLevelDropdown.SelectedIndex]])) * -1) + float.Parse(SkillBoostTextbox.Text)).ToString() + " Concentration";
                        }
                        else if (float.Parse(skilllvenergy[yholder2[SkillLevelDropdown.SelectedIndex]]) < 0)
                        {
                            if (float.Parse(skilllvbaseamount[yholder2[SkillLevelDropdown.SelectedIndex]]) < 0 || float.Parse(skilllvinitialdamage[yholder2[SkillLevelDropdown.SelectedIndex]]) < 0 && skilltarget[yholder[SkillSearchListbox.SelectedIndex]] == "Self")
                            {
                                SkillFinal.Text = ((float.Parse(skilllvenergy[yholder2[SkillLevelDropdown.SelectedIndex]]) * -1) + float.Parse(SkillBoostTextbox.Text)).ToString() + " HP/Energy";
                            }
                            else SkillFinal.Text = ((float.Parse(skilllvenergy[yholder2[SkillLevelDropdown.SelectedIndex]]) * -1) + float.Parse(SkillBoostTextbox.Text)).ToString() + " Energy";
                        }
                        else if (float.Parse(skilllvinitialdamage[yholder2[SkillLevelDropdown.SelectedIndex]]) < 0 || float.Parse(skilllvbaseamount[yholder2[SkillLevelDropdown.SelectedIndex]]) < 0)
                        {
                            finalizer = (int)Math.Ceiling((float.Parse(skilllvbaseamount[yholder2[SkillLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(skilllvinitialdamage[yholder2[SkillLevelDropdown.SelectedIndex * pvpmode]]) * (1 + Math.Sqrt(ability / 100.0f) + Math.Sqrt(float.Parse(PrimStats[primstat].Text) / primstatmod)))) + float.Parse(SkillBoostTextbox.Text) + " Health";
                            SkillFinal.Text = finalizer.Substring(1);
                        }
                        else
                        {
                            if (skillauto[yholder[SkillSearchListbox.SelectedIndex]] == "Yes")
                            {
                                SkillFinal.Text = (int)Math.Ceiling((float.Parse(skilllvbaseamount[yholder2[SkillLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(skilllvinitialdamage[yholder2[SkillLevelDropdown.SelectedIndex * pvpmode]]) * (1 + Math.Sqrt(ability / 100.0f) + Math.Sqrt(float.Parse(PrimStats[primstat].Text) / primstatmod)))) + ((int)(automulti * solverpierce) + (int)(automulti * solverslash) + (int)(automulti * solvercrush) + autoflatdmg) + float.Parse(SkillBoostTextbox.Text) + " Damage";
                            }
                            else
                            {
                                SkillFinal.Text = (int)Math.Ceiling((float.Parse(skilllvbaseamount[yholder2[SkillLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(skilllvinitialdamage[yholder2[SkillLevelDropdown.SelectedIndex * pvpmode]]) * (1 + Math.Sqrt(ability / 100.0f) + Math.Sqrt(float.Parse(PrimStats[primstat].Text) / primstatmod)))) + float.Parse(SkillBoostTextbox.Text) + " Damage";
                            }
                        }
                    }
                    else SkillFinal.Text = "???";
                }
                else
                {
                    SkillFinal.Text = "???";
                    Status1Final.Text = "???";
                    Status2Final.Text = "???";
                }
            }
            if (StatusLevelDropdown.SelectedIndex > -1)
            {
                if (StatusLevelDropdown.Items.Count > 0)
                {
                    if (autosearch == false)
                    {
                        ability = float.Parse(StatusOnlyAbility.Text);
                        primstatmod = float.Parse(StatusOnlyDivisor.Text);
                        statustype = statuseffect[yholder3[StatusSearchListbox.SelectedIndex]];
                    }
                    else
                    {
                        if (statusability[statusskillcarry] != "None") ability = float.Parse(SkillAbilityTextbox.Text);
                        else ability = 0;
                        statustype = statuseffect[statusskillcarry];
                    }
                    switch (statustype)
                    {
                        case "-1":
                            Status1Final.Text = "N/A";
                            Status2Final.Text = "N/A";
                            break;
                        case "0":
                            Status1Final.Text = (int)Math.Ceiling((float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) * (1 + Math.Sqrt(ability / 100.0f) + Math.Sqrt(float.Parse(PrimStats[primstat].Text) / primstatmod)))) + " Armour";
                            Status2Final.Text = "N/A";
                            break;
                        case "1":
                            Status1Final.Text = (int)Math.Ceiling((float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) * (1 + Math.Sqrt(ability / 100.0f) + Math.Sqrt(float.Parse(PrimStats[primstat].Text) / primstatmod)))) + " Health/Tick";
                            Status2Final.Text = "N/A";
                            break;
                        case "2":
                            Status1Final.Text = (int)Math.Ceiling((float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) * (1 + Math.Sqrt(ability / 100.0f) + Math.Sqrt(float.Parse(PrimStats[primstat].Text) / primstatmod)))) + " Energy/Tick";
                            Status2Final.Text = "N/A";
                            break;
                        case "3":
                            Status1Final.Text = (int)Math.Ceiling((float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) * (1 + Math.Sqrt(ability / 100.0f) + Math.Sqrt(float.Parse(PrimStats[primstat].Text) / primstatmod)))) + " Damage/Tick";
                            Status2Final.Text = "N/A";
                            break;
                        case "4":
                            Status1Final.Text = (int)Math.Ceiling((float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) * (1 + Math.Sqrt(ability / 100.0f) + Math.Sqrt(float.Parse(PrimStats[primstat].Text) / primstatmod)))) + " Attack";
                            Status2Final.Text = "N/A";
                            break;
                        case "5":
                            Status1Final.Text = "Root If LVL <= " + (float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]));
                            Status2Final.Text = "N/A";
                            break;
                        case "6":
                            Status1Final.Text = (int)Math.Ceiling((float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) * (1 + Math.Sqrt(ability / 100.0f) + Math.Sqrt(float.Parse(PrimStats[primstat].Text) / primstatmod)))) + " Damage/Auto";
                            Status2Final.Text = "N/A";
                            break;
                        case "7":
                            {
                                float multi = ((int)Math.Ceiling(((float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) * (1 + Math.Sqrt(ability / 100.0f) + Math.Sqrt(float.Parse(PrimStats[primstat].Text) / primstatmod))))) / 5) / 100.0f;
                                Status1Final.Text = (int)Math.Ceiling((float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) * (1 + Math.Sqrt(ability / 100.0f) + Math.Sqrt(float.Parse(PrimStats[primstat].Text) / primstatmod)))) + " Attack";
                                Status2Final.Text = (int)((multi * solverpierce) + (int)(multi * solverslash) + (int)(multi * solvercrush)) + " Damage";
                            }
                            break;
                        case "8":
                            Status1Final.Text = (float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]])) + "% Move Speed";
                            Status2Final.Text = "N/A";
                            break;
                        case "9":
                            Status1Final.Text = "Hide If LVL <= " + (float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]));
                            Status2Final.Text = "N/A";
                            break;
                        case "10":
                            Status1Final.Text = (int)Math.Ceiling((float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) * (1 + Math.Sqrt(ability / 100.0f) + Math.Sqrt(float.Parse(PrimStats[primstat].Text) / primstatmod)))) + " Max Health";
                            Status2Final.Text = "N/A";
                            break;
                        case "11":
                            Status1Final.Text = (int)Math.Ceiling((float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) * (1 + Math.Sqrt(ability / 100.0f) + Math.Sqrt(float.Parse(PrimStats[primstat].Text) / primstatmod)))) + " Max Energy";
                            Status2Final.Text = "N/A";
                            break;
                        case "12":
                            Status1Final.Text = (int)Math.Ceiling((float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) * (1 + Math.Sqrt(ability / 100.0f) + Math.Sqrt(float.Parse(PrimStats[primstat].Text) / primstatmod)))) + " Resistance";
                            Status2Final.Text = "N/A";
                            break;
                        case "13":
                            Status1Final.Text = (float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) * (1 + Math.Sqrt(ability / 100.0f) + Math.Sqrt(float.Parse(PrimStats[primstat].Text) / primstatmod))).ToString("0.0") + "x Shield Limit";
                            Status2Final.Text = "N/A";
                            break;
                        case "14":
                            {
                                float multi = ((int)Math.Ceiling(((float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) * (1 + Math.Sqrt(ability / 100.0f) + Math.Sqrt(float.Parse(PrimStats[primstat].Text) / primstatmod))))) / 10) / 100.0f;
                                Status1Final.Text = (int)Math.Ceiling((float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) * (1 + Math.Sqrt(ability / 100.0f) + Math.Sqrt(float.Parse(PrimStats[primstat].Text) / primstatmod)))) + " Attack";
                                Status2Final.Text = (int)((multi * solverpierce) + (int)(multi * solverslash) + (int)(multi * solvercrush)) + " Damage";
                            }
                            break;
                        case "15":
                            Status1Final.Text = (int)Math.Ceiling((float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) * (1 + Math.Sqrt(ability / 100.0f) + Math.Sqrt(float.Parse(PrimStats[primstat].Text) / primstatmod)))) + " Defence";
                            Status2Final.Text = "N/A";
                            break;
                        case "16":
                            Status1Final.Text = (int)Math.Ceiling((float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) * (1 + Math.Sqrt(ability / 100.0f) + Math.Sqrt(float.Parse(PrimStats[primstat].Text) / primstatmod)))) + " Damage";
                            Status2Final.Text = "N/A";
                            break;
                        case "17":
                            Status1Final.Text = (float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]])) + "% ATK Speed";
                            Status2Final.Text = "N/A";
                            break;
                        case "18":
                            Status1Final.Text = "Halved Damage";
                            Status2Final.Text = "N/A";
                            break;
                        case "19":
                            Status1Final.Text = "Invisible";
                            Status2Final.Text = "N/A";
                            break;
                        case "20":
                            Status1Final.Text = (float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]])) + "% Player Size";
                            Status2Final.Text = "N/A";
                            break;
                        case "21":
                            Status1Final.Text = (float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]])) + "x Experience";
                            Status2Final.Text = "N/A";
                            break;
                        case "22":
                            Status1Final.Text = (float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]])) + "% Camouflage";
                            Status2Final.Text = "N/A";
                            break;
                        case "23":
                            if (StatusLevelDropdown.Text == "1")
                            {
                                Status1Final.Text = "Combination";
                            }
                            if (StatusLevelDropdown.Text == "2")
                            {
                                Status1Final.Text = "Super Combination";
                            }
                            if (StatusLevelDropdown.Text == "3")
                            {
                                Status1Final.Text = "Heroic Combination";
                            }
                            Status2Final.Text = "N/A";
                            break;
                        case "24":
                            Status1Final.Text = (float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]])) + "x Ability Rate";
                            Status2Final.Text = "N/A";
                            break;
                        case "25":
                            Status1Final.Text = "LVL'd Move Speed(-)";
                            Status2Final.Text = "N/A";
                            break;
                        case "26":
                            Status1Final.Text = "70% Camo LV<=" + (float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]));
                            Status2Final.Text = "N/A";
                            break;
                        case "27":
                            Status1Final.Text = (int)Math.Ceiling((float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) * (1 + Math.Sqrt(ability / 100.0f) + Math.Sqrt(float.Parse(PrimStats[primstat].Text) / primstatmod)))) + " Damage Shield";
                            Status2Final.Text = "N/A";
                            break;
                        case "28":
                            Status1Final.Text = "Freeze LV <= " + (float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]));
                            Status2Final.Text = "N/A";
                            break;
                        case "29":
                            Status1Final.Text = "Play Dead LV<=" + (float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]));
                            Status2Final.Text = "N/A";
                            break;
                        case "30":
                            Status1Final.Text = "1.5x ASPD LV<=" + (float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]));
                            Status2Final.Text = "N/A";
                            break;
                        case "31":
                            Status1Final.Text = "Stun If LVL <= " + (float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]));
                            Status2Final.Text = "N/A";
                            break;
                        case "32":
                            Status1Final.Text = (int)Math.Ceiling((float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) * (1 + Math.Sqrt(ability / 100.0f) + Math.Sqrt(float.Parse(PrimStats[primstat].Text) / primstatmod)))) + " Physical Evade";
                            Status2Final.Text = "N/A";
                            break;
                        case "33":
                            Status1Final.Text = "Silence If LVL <= " + (float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]));
                            Status2Final.Text = "N/A";
                            break;
                        case "34":
                            Status1Final.Text = "Stasis If LVL <= " + (float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]));
                            Status2Final.Text = "N/A";
                            break;
                        case "35":
                            Status1Final.Text = (int)Math.Ceiling((float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) * (1 + Math.Sqrt(ability / 100.0f) + Math.Sqrt(float.Parse(PrimStats[primstat].Text) / primstatmod)))) + "HP+En/Tick";
                            Status2Final.Text = "N/A";
                            break;
                        case "36":
                            Status1Final.Text = (float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) * (1 + Math.Sqrt(ability / 100.0f) + Math.Sqrt(float.Parse(PrimStats[primstat].Text) / primstatmod))).ToString("0.0") + "x HP+Energy";
                            Status2Final.Text = "N/A";
                            break;
                        case "37":
                            Status1Final.Text = statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]] + " Max Health";
                            Status2Final.Text = statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]] + "x Max Health";
                            break;
                        case "38":
                            Status1Final.Text = statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]] + " Max Energy";
                            Status2Final.Text = statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]] + "x Max Energy";
                            break;
                        case "39":
                            Status1Final.Text = statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]] + " Armour";
                            Status2Final.Text = statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]] + "x Armour";
                            break;
                        case "40":
                            Status1Final.Text = statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]] + " Defence";
                            Status2Final.Text = statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]] + "x Defence";
                            break;
                        case "41":
                            Status1Final.Text = statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]] + " Attack";
                            Status2Final.Text = statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]] + "x Attack";
                            break;
                        case "42":
                            Status1Final.Text = statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]] + " Health/Tick";
                            Status2Final.Text = statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]] + "x Health/Tick";
                            break;
                        case "43":
                            Status1Final.Text = statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]] + " Energy/Tick";
                            Status2Final.Text = statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]] + "x Energy/Tick";
                            break;
                        case "44":
                            Status1Final.Text = (int)Math.Ceiling((float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) * (1 + Math.Sqrt(ability / 100.0f) + Math.Sqrt(float.Parse(PrimStats[primstat].Text) / primstatmod)))) + " All Evades";
                            Status2Final.Text = "N/A";
                            break;
                        case "45":
                            Status1Final.Text = (int)Math.Ceiling((float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) * (1 + Math.Sqrt(ability / 100.0f) + Math.Sqrt(float.Parse(PrimStats[primstat].Text) / primstatmod)))) + " Ice Shard/Blast";
                            Status2Final.Text = "N/A";
                            break;
                        case "46":
                            Status1Final.Text = (int)Math.Ceiling((float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) * (1 + Math.Sqrt(ability / 100.0f) + Math.Sqrt(float.Parse(PrimStats[primstat].Text) / primstatmod)))) + " Fire Bolt/Storm";
                            Status2Final.Text = "N/A";
                            break;
                        case "47":
                            Status1Final.Text = (float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) * (1 + Math.Sqrt(ability / 100.0f) + Math.Sqrt(float.Parse(PrimStats[primstat].Text) / primstatmod))).ToString("0.0") + "x Damage";
                            Status2Final.Text = "N/A";
                            break;
                        case "48":
                            Status1Final.Text = "Hungry Pet";
                            Status2Final.Text = "N/A";
                            break;
                        case "49":
                            Status1Final.Text = (float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]])) + "x Fishing EXP";
                            Status2Final.Text = "N/A";
                            break;
                        case "50":
                            Status1Final.Text = (int)Math.Ceiling((float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) * (1 + Math.Sqrt(ability / 100.0f) + Math.Sqrt(float.Parse(PrimStats[primstat].Text) / primstatmod)))) + " Fishing DMG/T";
                            Status2Final.Text = "N/A";
                            break;
                        case "51":
                            Status1Final.Text = "Dismounted";
                            Status2Final.Text = "N/A";
                            break;
                        case "52":
                            Status1Final.Text = "Aura Effect";
                            Status2Final.Text = "N/A";
                            break;
                        case "53":
                            Status1Final.Text = "Heal/DMG Swap(x3)";
                            Status2Final.Text = "N/A";
                            break;
                        case "54":
                            Status1Final.Text = statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]] + " Reduction";
                            Status2Final.Text = "N/A";
                            break;
                        case "55":
                            Status1Final.Text = "Jubilation Elixir";
                            Status2Final.Text = "N/A";
                            break;
                        case "56":
                            Status1Final.Text = (float.Parse(statuslvbase[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]]) + float.Parse(statuslvinitial[yholder4[StatusLevelDropdown.SelectedIndex * pvpmode]])) + "x Gold Rate";
                            Status2Final.Text = "N/A";
                            break;
                        default:
                            Status1Final.Text = "???";
                            Status2Final.Text = "???";
                            break;
                    }
                }
                else
                {
                    Status1Final.Text = "???";
                    Status2Final.Text = "???";
                }
            }
            else
            {
                Status1Final.Text = "???";
                Status2Final.Text = "???";
            }
        }

        private void StatusDisplay(int loadtype)
        {
            int amount = 0;
            int hold = 0;
            int holdpvp = 0;
            int holdpvp1 = 0;
            if (loadtype == 2)
            {
                amount = 0;
                hold = 0;
                holdpvp = 0;
                holdpvp1 = 1;
            }
            else
            {
                amount = 1;
                hold = yholder4[StatusLevelDropdown.SelectedIndex];
                if (yholder4.Count > 1)
                {
                    if (statuslvpvp[yholder4[1]] == "1")
                    {
                        holdpvp = yholder4[StatusLevelDropdown.SelectedIndex * 2];
                        holdpvp1 = yholder4[StatusLevelDropdown.SelectedIndex * 2 + 1];
                    }
                }
            }
            if (StatusLevelDropdown.SelectedIndex > -1 || loadtype == 2)
            {
                if (yholder4.Count > amount)
                {
                    if (statuslvpvp[yholder4[1]] == "1")
                    {
                        if (statuslvinitial[holdpvp] != statuslvinitial[holdpvp1])
                        {
                            InitialValueStatus.Text = statuslvinitial[holdpvp] + "(" + statuslvinitial[holdpvp1] + ")";
                        }
                        else InitialValueStatus.Text = statuslvinitial[holdpvp];
                        if (statuslvduration[holdpvp] != statuslvduration[holdpvp1])
                        {
                            DurationStatus.Text = statuslvduration[holdpvp] + "(" + statuslvduration[holdpvp1] + ")";
                        }
                        else DurationStatus.Text = statuslvduration[holdpvp];
                        if (statuslvbase[holdpvp] != statuslvbase[holdpvp1])
                        {
                            BaseValueStatus.Text = statuslvbase[holdpvp] + "(" + statuslvbase[holdpvp1] + ")";
                        }
                        else BaseValueStatus.Text = statuslvbase[holdpvp];
                        StatusDisplayPVP(loadtype, 1);
                    }
                    else
                    {
                        InitialValueStatus.Text = statuslvinitial[hold];
                        DurationStatus.Text = statuslvduration[hold];
                        BaseValueStatus.Text = statuslvbase[hold];
                        StatusDisplayPVP(loadtype, 0);
                    }
                }
                else
                {
                    InitialValueStatus.Text = statuslvinitial[hold];
                    DurationStatus.Text = statuslvduration[hold];
                    BaseValueStatus.Text = statuslvbase[hold];
                    StatusDisplayPVP(loadtype, 0);
                }
            }
            else
            {
                InitialValueStatus.Text = "???";
                DurationStatus.Text = "???";
                BaseValueStatus.Text = "???";
                CriticalAllowedStatus.Text = "???";
                StatusFormula1.Text = "Status Formula 1: ???";
                StatusFormula2.Text = "Status Formula 2: ???";
            }
        }

        private void StatusDisplayPVP(int loadtype, int pvpmode)
        {
            int hold = 0;
            int pvphold = 0;
            string stat = null;
            string ability = null;
            string divisor = null;
            switch (loadtype)
            {
                case 0:
                    hold = statusskillcarry;
                    stat = skillprimstat[yholder[SkillSearchListbox.SelectedIndex]];
                    ability = statusability[statusskillcarry];
                    divisor = skillprimmod[yholder[SkillSearchListbox.SelectedIndex]];
                    break;
                case 1:
                case 2:
                    hold = yholder3[StatusSearchListbox.SelectedIndex];
                    stat = "P.Stat";
                    ability = statusability[yholder3[StatusSearchListbox.SelectedIndex]];
                    divisor = "Divisor";
                    break;
            }
            switch (pvpmode)
            {
                case 0:
                    pvphold = yholder4[StatusLevelDropdown.SelectedIndex];
                    break;
                case 1:
                    pvphold = yholder4[StatusLevelDropdown.SelectedIndex * 2];
                    break;
                case 2:
                    pvphold = yholder4[0];
                    break;
            }
            if (statusaura[hold] != "0" || effectid.IndexOf(statusid[hold]) != -1)
            {
                ExtraDataButton.Enabled = true;
            }
            else ExtraDataButton.Enabled = false;
            switch (statuseffect[hold])
            {
                case "-1":
                    StatusFormula1.Text = "Visual: Status Does Nothing(Bonuses Might Come From Invisible Item)";
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "0":
                    StatusFormula1.Text = "Armour(+): " + statuslvbase[pvphold] + " + " + statuslvinitial[pvphold] + " * (1 + √(" + stat + "/" + divisor + ") + √(" + ability + "/100))";
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "1":
                    StatusFormula1.Text = "Health Regen(+): " + statuslvbase[pvphold] + " + " + statuslvinitial[pvphold] + " * (1 + √(" + stat + "/" + divisor + ") + √(" + ability + "/100))";
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    if ((float.Parse(statuslvinitial[pvphold]) > 0 || float.Parse(statuslvbase[pvphold]) > 0) && statusability[hold] != "None" && statusability[hold] != "???" && statusitem[hold] == "No")
                    {
                        CriticalAllowedStatus.Text = "Yes";
                    }
                    else
                    {
                        CriticalAllowedStatus.Text = "No";
                    }
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "2":
                    StatusFormula1.Text = "Energy Regen(+): " + statuslvbase[pvphold] + " + " + statuslvinitial[pvphold] + " * (1 + √(" + stat + "/" + divisor + ") + √(" + ability + "/100))";
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "3":
                    StatusFormula1.Text = "Damage: " + statuslvbase[pvphold] + " + " + statuslvinitial[pvphold] + " * (1 + √(" + stat + "/" + divisor + ") + √(" + ability + "/100))";
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    if ((float.Parse(statuslvinitial[pvphold]) > 0 || float.Parse(statuslvbase[pvphold]) > 0) && statusability[hold] != "None" && statusability[hold] != "???" && statusitem[hold] == "No")
                    {
                        CriticalAllowedStatus.Text = "Yes";
                    }
                    else
                    {
                        CriticalAllowedStatus.Text = "No";
                    }
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "4":
                    StatusFormula1.Text = "Attack(+): " + statuslvbase[pvphold] + " + " + statuslvinitial[pvphold] + " * (1 + √(" + stat + "/" + divisor + ") + √(" + ability + "/100))";
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "5":
                    StatusFormula1.Text = "Root: 0% Movement Speed If Enemy LVL <= " + statuslvinitial[pvphold];
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = statuslvinitial[pvphold];
                    break;
                case "6":
                    StatusFormula1.Text = "Cloak Damage: " + statuslvbase[pvphold] + " + " + statuslvinitial[pvphold] + " * (1 + √(" + stat + "/" + divisor + ") + √(" + ability + "/100))";
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "7":
                    StatusFormula1.Text = "Attack(+): " + statuslvbase[pvphold] + " + " + statuslvinitial[pvphold] + " * (1 + √(" + stat + "/" + divisor + ") + √(" + ability + "/100))";
                    StatusFormula2.Text = "P.DMG(x): (" + statuslvbase[pvphold] + "+" + statuslvinitial[pvphold] + "*(1+√(" + stat + "/" + divisor + ")+√(" + ability + "/100))/500)";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "8":
                    StatusFormula1.Text = "Movement Speed(%+): " + statuslvbase[pvphold] + " + " + statuslvinitial[pvphold];
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "9":
                    StatusFormula1.Text = "Hide: Invisible If Enemy LVL <= " + statuslvbase[pvphold] + " + " + statuslvinitial[pvphold];
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = (Convert.ToInt32(statuslvinitial[pvphold]) + Convert.ToInt32(statuslvbase[pvphold])).ToString();
                    break;
                case "10":
                    StatusFormula1.Text = "Max Health(+): " + statuslvbase[pvphold] + " + " + statuslvinitial[pvphold] + " * (1 + √(" + stat + "/" + divisor + ") + √(" + ability + "/100))";
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "11":
                    StatusFormula1.Text = "Max Energy(+): " + statuslvbase[pvphold] + " + " + statuslvinitial[pvphold] + " * (1 + √(" + stat + "/" + divisor + ") + √(" + ability + "/100))";
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "12":
                    StatusFormula1.Text = "Resistance(+): " + statuslvbase[pvphold] + " + " + statuslvinitial[pvphold] + " * (1 + √(" + stat + "/" + divisor + ") + √(" + ability + "/100))";
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "13":
                    StatusFormula1.Text = "Old E. Shield: (" + statuslvbase[pvphold] + " + " + statuslvinitial[pvphold] + " * (1 + √(" + stat + "/" + divisor + ") + √(" + ability + "/100))) * DMG";
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "14":
                    StatusFormula1.Text = "Attack(+): " + statuslvbase[pvphold] + " + " + statuslvinitial[pvphold] + " * (1 + √(" + stat + "/" + divisor + ") + √(" + ability + "/100))";
                    StatusFormula2.Text = "P.DMG(x): (" + statuslvbase[pvphold] + "+" + statuslvinitial[pvphold] + "*(1+√(" + stat + "/" + divisor + ")+√(" + ability + "/100))/1000)";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "15":
                    StatusFormula1.Text = "Defence(+): " + statuslvbase[pvphold] + " + " + statuslvinitial[pvphold] + " * (1 + √(" + stat + "/" + divisor + ") + √(" + ability + "/100))";
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "16":
                    StatusFormula1.Text = "Damage(+): " + statuslvbase[pvphold] + " + " + statuslvinitial[pvphold] + " * (1 + √(" + stat + "/" + divisor + ") + √(" + ability + "/100))";
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "17":
                    StatusFormula1.Text = "Attack Speed(%-): " + statuslvbase[pvphold] + " + " + statuslvinitial[pvphold];
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "18":
                    StatusFormula1.Text = "Damage(%-): 50";
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "19":
                    StatusFormula1.Text = "Invisibility: Works On Every Enemy Except Ones That See Through";
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "20":
                    StatusFormula1.Text = "Size(%): " + statuslvbase[pvphold] + " + " + statuslvinitial[pvphold];
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "21":
                    StatusFormula1.Text = "Experience Rate(x): " + statuslvbase[pvphold] + " + " + statuslvinitial[pvphold];
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "22":
                    StatusFormula1.Text = "Camouflage(%): " + statuslvbase[pvphold] + " + " + statuslvinitial[pvphold];
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "23":
                    StatusFormula1.Text = "Combination: Every Elixir(or potion), Doesn't Stack w/Other Combos";
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "24":
                    StatusFormula1.Text = "Ability Rate(x): " + statuslvbase[pvphold] + " + " + statuslvinitial[pvphold];
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "25":
                    StatusFormula1.Text = "Movement Speed(50-95%): 90 + (CasterLVL - TargetLVL) / 2";
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = statuslvinitial[yholder4[0]];
                    break;
                case "26":
                    StatusFormula1.Text = "Camouflage(%): 70% Camouflage If Enemy LVL <= " + statuslvbase[pvphold] + " + " + statuslvinitial[pvphold];
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = (Convert.ToInt32(statuslvinitial[pvphold]) + Convert.ToInt32(statuslvbase[pvphold])).ToString();
                    break;
                case "27":
                    StatusFormula1.Text = "Damage Shield: " + statuslvbase[pvphold] + " + " + statuslvinitial[pvphold] + " * (1 + √(" + stat + "/" + divisor + ") + √(" + ability + "/100))";
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "28":
                    StatusFormula1.Text = "Freeze: No Auto/Skill/Moving If Enemy LVL <= " + statuslvbase[pvphold] + " + " + statuslvinitial[pvphold];
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = (Convert.ToInt32(statuslvinitial[pvphold]) + Convert.ToInt32(statuslvbase[pvphold])).ToString();
                    break;
                case "29":
                    StatusFormula1.Text = "Play Dead: No Auto/Skill/Targeting You If Enemy LVL <= " + statuslvbase[pvphold] + " + " + statuslvinitial[pvphold];
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = (Convert.ToInt32(statuslvinitial[pvphold]) + Convert.ToInt32(statuslvbase[pvphold])).ToString();
                    break;
                case "30":
                    StatusFormula1.Text = "Attack Speed(%+): Attack Speed +50% If Enemy LVL <= " + statuslvbase[pvphold] + " + " + statuslvinitial[pvphold];
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = (Convert.ToInt32(statuslvinitial[pvphold]) + Convert.ToInt32(statuslvbase[pvphold])).ToString();
                    break;
                case "31":
                    StatusFormula1.Text = "Stun: No Auto/Skill/Move/Regening If Enemy LVL <= " + statuslvbase[pvphold] + " + " + statuslvinitial[pvphold];
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = (Convert.ToInt32(statuslvinitial[pvphold]) + Convert.ToInt32(statuslvbase[pvphold])).ToString();
                    break;
                case "32":
                    StatusFormula1.Text = "Phys Evade(+): " + statuslvbase[pvphold] + " + " + statuslvinitial[pvphold] + " * (1 + √(" + stat + "/" + divisor + ") + √(" + ability + "/100))";
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "33":
                    StatusFormula1.Text = "Silenced: Stops Skills From Working";
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = (Convert.ToInt32(statuslvinitial[pvphold]) + Convert.ToInt32(statuslvbase[pvphold])).ToString();
                    break;
                case "34":
                    StatusFormula1.Text = "Stasis: Stops Regeneration From Working";
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = (Convert.ToInt32(statuslvinitial[pvphold]) + Convert.ToInt32(statuslvbase[pvphold])).ToString();
                    break;
                case "35":
                    StatusFormula1.Text = "HP/E Regen(+): " + statuslvbase[pvphold] + " + " + statuslvinitial[pvphold] + " * (1 + √(" + stat + "/" + divisor + ") + √(" + ability + "/100))";
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "36":
                    StatusFormula1.Text = "Health+Energy(x): " + statuslvbase[pvphold] + " + " + statuslvinitial[pvphold] + " * (1 + √(" + stat + "/" + divisor + ") + √(" + ability + "/100))";
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "37":
                    StatusFormula1.Text = "Health(+): " + statuslvinitial[pvphold];
                    StatusFormula2.Text = "Health(x): " + statuslvbase[pvphold];
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "38":
                    StatusFormula1.Text = "Energy(+): " + statuslvinitial[pvphold];
                    StatusFormula2.Text = "Energy(x): " + statuslvbase[pvphold];
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "39":
                    StatusFormula1.Text = "Armour(+): " + statuslvinitial[pvphold];
                    StatusFormula2.Text = "Armour(x): " + statuslvbase[pvphold];
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "40":
                    StatusFormula1.Text = "Defence(+): " + statuslvinitial[pvphold];
                    StatusFormula2.Text = "Defence(x): " + statuslvbase[pvphold];
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "41":
                    StatusFormula1.Text = "Attack(+): " + statuslvinitial[pvphold];
                    StatusFormula2.Text = "Attack(x): " + statuslvbase[pvphold];
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "42":
                    StatusFormula1.Text = "Health Regen(+): " + statuslvinitial[pvphold];
                    StatusFormula2.Text = "Health Regen(x+): " + statuslvbase[pvphold];
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "43":
                    StatusFormula1.Text = "Energy Regen(+): " + statuslvinitial[pvphold];
                    StatusFormula2.Text = "Energy Regen(x+): " + statuslvbase[pvphold];
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "44":
                    StatusFormula1.Text = "All Evasions(+): " + statuslvbase[pvphold] + " + " + statuslvinitial[pvphold] + " * (1 + √(" + stat + "/" + divisor + ") + √(" + ability + "/100))";
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "45":
                    StatusFormula1.Text = "Ice Shards/Blast(+): " + statuslvbase[pvphold] + " + " + statuslvinitial[pvphold] + " * (1 + √(" + stat + "/" + divisor + ") + √(" + ability + "/100))";
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "46":
                    StatusFormula1.Text = "Fire Bolt/Storm(+): " + statuslvbase[pvphold] + " + " + statuslvinitial[pvphold] + " * (1 + √(" + stat + "/" + divisor + ") + √(" + ability + "/100))";
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "47":
                    StatusFormula1.Text = "Damage(x): " + statuslvbase[pvphold] + " + " + statuslvinitial[pvphold] + " * (1 + √(" + stat + "/" + divisor + ") + √(" + ability + "/100))";
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "48":
                    StatusFormula1.Text = "Pet Hungry: You Wont Get Your Pets Stats/Skills Or See It";
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "49":
                    StatusFormula1.Text = "Fishing Experience Rate(x): " + statuslvbase[pvphold] + " + " + statuslvinitial[pvphold];
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "50":
                    StatusFormula1.Text = "Concentration DMG: " + statuslvbase[pvphold] + " + " + statuslvinitial[pvphold] + " * (1 + √(" + stat + "/" + divisor + ") + √(" + ability + "/100))";
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "51":
                    StatusFormula1.Text = "Dismounted: You Wont Get Your Battlemounts Speed/Stats/Skills Or See It";
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "52":
                    StatusFormula1.Text = "Aura: Inflicts Another Status When In Range";
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "53":
                    StatusFormula1.Text = "Reverse: Swaps Damage/Healing And Multiplies By 3";
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "54":
                    StatusFormula1.Text = "Reduction Change(?): " + statuslvbase[pvphold];
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "55":
                    StatusFormula1.Text = "Combination + Gold: A Heroic Combo With 10% More Gold";
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                case "56":
                    StatusFormula1.Text = "Gold Rate(x): " + statuslvbase[pvphold] + " + " + statuslvinitial[pvphold];
                    StatusFormula2.Text = "Status Formula 2: Not Used";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
                default:
                    StatusFormula1.Text = "Status Formula 1: ???";
                    StatusFormula2.Text = "Status Formula 2: ???";
                    CriticalAllowedStatus.Text = "No";
                    UpToLevelStatus.Text = "N/A";
                    break;
            }
        }

        private void KeyPressNumberOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ExtraDataButton_Click(object sender, EventArgs e)
        {
            int index;
            if (AutoSearchStatusCheckbox.Checked == true)
            {
                index = statusskillcarry;
            }
            else index = yholder3[StatusSearchListbox.SelectedIndex];
            if (statusaura[index] != "-1" && statusaura[index] != "0")
            {
                auracarry = auraid.IndexOf(statusaura[index]);
                effectcarry = effectid.IndexOf(auraeffectid[auraeffectid.IndexOf(auraeffectid[auracarry])]);
            }
            else
            {
                auracarry = -1;
                if (effectid.IndexOf(statusid[index]) != -1)
                {
                    effectcarry = effectid.IndexOf(statusid[index]);
                }
                else effectcarry = -1;
            }
            abilitycarry = statusability[index];
            StatusExtraData ExtraData = new StatusExtraData();
            if (yholder3.Count > 0)
            {
                ExtraData.Text = statusname[index] + " Extra Data";
            }
            else ExtraData.Text = StatusNameSearchTextbox.Text + " Extra Data";
            ExtraData.Show();
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

        // #Page3

        public static int solvermobid = -1;
        public static bool solverpvp = false;
        public static float solvermoblevel;
        public static float solverhealth;
        public static float solverdefence;
        public static float solveraggro;
        public static float solverxp;
        public static float solverphysical;
        public static float solverspell;
        public static float solvermovement;
        public static float solverwounding;
        public static float solverweakening;
        public static float solvermental;
        public static float solverpluspierceresist;
        public static float solverplusslashresist;
        public static float solverpluscrushresist;
        public static float solverplusheatresist;
        public static float solverpluscoldresist;
        public static float solverplusmagicresist;
        public static float solverpluspoisonresist;
        public static float solverplusdivineresist;
        public static float solverpluschaosresist;
        public static float solverplustrueresist;
        public static float solverpercentpierceresist;
        public static float solverpercentslashresist;
        public static float solverpercentcrushresist;
        public static float solverpercentheatresist;
        public static float solverpercentcoldresist;
        public static float solverpercentmagicresist;
        public static float solverpercentpoisonresist;
        public static float solverpercentdivineresist;
        public static float solverpercentchaosresist;
        public static float solverpercenttrueresist;

        public static float solverplayerlevel = 0;
        public static float solverattack = 0;
        public static float solverweaponability = 0;
        public static float solverskillability = 0;
        public static float solvercritstrike = 0;
        public static float solvercritskills = 0;
        public static int solverclass = 0;
        public static float solverattackspeed = 0;
        public static float solverstrength = 0;
        public static float solverdexterity = 0;
        public static float solverfocus = 0;
        public static float solvervitality = 0;
        public static float solverpierce = 0;
        public static float solverslash = 0;
        public static float solvercrush = 0;
        public static float solverpoison = 0;
        public static float solverheat = 0;
        public static float solvercold = 0;
        public static float solvermagic = 0;
        public static float solverdivine = 0;
        public static float solverchaos = 0;
        public static float solvertrue = 0;

        public static List<int> solveractiontype = new List<int>(); // 0 auto, 1 skill, 2 status, 3 empty, 4 status ending message
        public static List<int> solverskillid = new List<int>();
        public static List<int> solverskilllevel = new List<int>();
        public static List<float> solverskillhittime = new List<float>(); // so statuses can see when they should begin/end
        public static List<int> solverstatusid = new List<int>();
        public static List<float> solverstatusmaxduration = new List<float>(); // holds start time on statuses to help calculate time remaining
        public static List<float> solverstatusduration = new List<float>(); // holds time left on statuses
        public static List<float> solverstatusticktime = new List<float>(); // holds another instance of duration to keep track of how many ticks to update
        public static List<float> solverstatusamount = new List<float>();
        public static List<float> solverstatusovercharge = new List<float>(); // holds unapplied amounts of statuses(example: magic lure and a magic phoenix on an enemy with low resist, it will reapply the full amount of the other one when one expires)
        public static List<float> solverstatusoverchargeslash = new List<float>(); // for holding armor
        public static List<float> solverstatusoverchargecrush = new List<float>(); // for holding armor
        public static List<bool> solverstatusapplied = new List<bool>(); // so each status only is applied once
        public static List<bool> solverstatusend = new List<bool>(); // keeps the status revert from applying more than once
        public static List<float> solverdirectdamage = new List<float>();
        public static List<float> solvercooldown = new List<float>();
        public static List<float> solvercasttime = new List<float>();
        public static List<float> solverlockout = new List<float>();
        public static List<float> solverstalltime = new List<float>(); // so statuses can tick without interrupting skills and such
        public static List<bool> solverhaspvpversion = new List<bool>();

        public static List<float> solverattackmod = new List<float>(); // these are for gear swap modifiers
        public static List<float> solverstrengthmod = new List<float>();
        public static List<float> solverdexteritymod = new List<float>();
        public static List<float> solverfocusmod = new List<float>();
        public static List<float> solvervitalitymod = new List<float>();
        public static List<float> solverweaponabilitymod = new List<float>();
        public static List<float> solverskillabilitymod = new List<float>();

        public static List<float> solversinglemaxdamage = new List<float>(); // these are so everything doesn't have to be recalculated to view individual skills
        public static List<float> solversingleactualdamage = new List<float>();
        public static List<float> solversingleresistdamage = new List<float>();
        public static List<float> solversingleleveldamage = new List<float>();
        public static List<float> solversingledps = new List<float>();
        public static List<float> solversinglechancetohit = new List<float>();
        public static List<float> solversinglecritchance = new List<float>();
        public static List<float> solversingleaggro = new List<float>();
        public static List<float> solversinglelock = new List<float>();
        public static List<float> solversingletimeforaction = new List<float>();

        public static List<List<float>> solvermobstatsave = new List<List<float>>(); // to save stats at the time of actions occuring, so they can be used for the relevancy mode
        public static List<List<float>> solvermobstatinfo = new List<List<float>>(); // 0 = pierce resist, 1 = slash, 2 crush, 3 heat, 4 cold, 5 magic, 6 poison, 7 divine, 8 chaos, 9 true, 10 defence, 11 physical, 12 spell, 13 movement, 14 wounding, 15 weakening
        public static List<List<float>> solverplayerstatsave = new List<List<float>>(); // this does the same thing but for player stats, they are separated so they can neatly be matched up with related things(pierce damage with pierce resist, etc)
        public static List<List<float>> solverplayerstatinfo = new List<List<float>>(); // 0 = pierce damage, 1 = slash, 2 crush, 3 heat, 4 cold, 5 magic, 6 = poison, 7 divine, 8 chaos, 9 true, 10 attack

        bool fireattuneactive = false;
        float fireattuneamount = 0;
        bool iceattuneactive = false;
        float iceattuneamount = 0;
        bool damagemultiplieractive = false;
        float damagemultiplieramount = 0;

        public static int solvermaxdamage = 0;
        public static int solverresistdamage = 0;
        public static int solverleveldamage = 0;
        public static float solverdps = 0;
        public static float solverchancetohit = 0;
        public static float solvercritchance = 0;
        public static float solveraggrogenerated = 0;
        public static float solverlockcontribution = 0;
        public static float solvertimeforaction = 0;

        public static float solverpiercedamage = 0;
        public static float solverslashdamage = 0;
        public static float solvercrushdamage = 0;
        public static float solverheatdamage = 0;
        public static float solvercolddamage = 0;
        public static float solvermagicdamage = 0;
        public static float solverpoisondamage = 0;
        public static float solverdivinedamage = 0;
        public static float solverchaosdamage = 0;
        public static float solvertruedamage = 0;

        public static bool mobdone = false;
        public static bool playerdone = false;

        float levelfactorholder = 0;
        float aggrofactorholder = 0;
        float maxdamageholder = 0;
        float leveldamageholder = 0;
        float resistdamageholder = 0;
        public static float timeholder = 0;
        public static List<float> solverchancetohittotal = new List<float>();
        public static List<float> solvercritchancetotal = new List<float>();

        public static float solvertempdefence;
        public static float solvertempphysical;
        public static float solvertempspell;
        public static float solvertempmovement;
        public static float solvertempwounding;
        public static float solvertempweakening;
        public static float solvertempmental;
        public static float solvertemppierceplus; // pierce/slash/crush buffs only add flat damage(aside from food which isnt supported), the original values are still used for true physical damage equations while this is just buff additions
        public static float solvertempslashplus;
        public static float solvertempcrushplus;
        public static float solvertempheat; // original + buffs for normal flat damage types
        public static float solvertempcold;
        public static float solvertempmagic;
        public static float solvertemppoison;
        public static float solvertempdivine;
        public static float solvertempchaos;
        public static float solvertemptrue;
        public static float solvertemppluspierceresist;
        public static float solvertempplusslashresist;
        public static float solvertemppluscrushresist;
        public static float solvertempplusheatresist;
        public static float solvertemppluscoldresist;
        public static float solvertempplusmagicresist;
        public static float solvertemppluspoisonresist;
        public static float solvertempplusdivineresist;
        public static float solvertemppluschaosresist;
        public static float solvertempplustrueresist;
        public static float solvertempattack;
        public static float solverlowpluspierceresist; // low is for showing the minimum point for resist
        public static float solverlowplusslashresist;
        public static float solverlowpluscrushresist;
        public static float solverlowplusheatresist;
        public static float solverlowpluscoldresist;
        public static float solverlowplusmagicresist;
        public static float solverlowpluspoisonresist;
        public static float solverlowplusdivineresist;
        public static float solverlowpluschaosresist;
        public static float solverlowplustrueresist;
        public static float solverlowdefence; // minimum point of defence
        public static float solverhighattack; // high to show the highest attack point
        public static float solverlowattack;
        public static float solverhighstrength;
        public static float solverlowstrength;
        public static float solverhighdexterity;
        public static float solverlowdexterity;
        public static float solverhighfocus;
        public static float solverlowfocus;
        public static float solverhighvitality;
        public static float solverlowvitality;
        public static float solverhighweaponability;
        public static float solverlowweaponability;
        public static float solverhighskillability;
        public static float solverlowskillability;
        public static float solverlowphysical;
        public static float solverlowspell;
        public static float solverlowmovement;
        public static float solverlowwounding;
        public static float solverlowweakening;
        // mental attack evasion can't be lowered

        bool usepvp = false;
        bool pvpevasioncap = false;
        bool usemoblevel = false;
        bool useattack = false;
        bool usedefence = false;
        bool usephysicalevade = false;
        bool usespellevade = false;
        bool usemovementevade = false;
        bool usewoundingevade = false;
        bool useweakeningevade = false;
        bool usementalevade = false;
        bool usepierceresist = false;
        bool useslashresist = false;
        bool usecrushresist = false;
        bool useheatresist = false;
        bool usecoldresist = false;
        bool usemagicresist = false;
        bool usepoisonresist = false;
        bool usedivineresist = false;
        bool usechaosresist = false;
        bool usetrueresist = false;
        bool usepierce = false;
        bool useslash = false;
        bool usecrush = false;
        bool useheat = false;
        bool usecold = false;
        bool usemagic = false;
        bool usepoison = false;
        bool usedivine = false;
        bool usechaos = false;
        bool usetrue = false;
        bool usestrength = false;
        bool usedexterity = false;
        bool usefocus = false;
        bool usevitality = false;
        bool useweaponability = false;
        bool useskillability = false;
        bool usecritstrike = false;
        bool usecritskills = false;

        bool mobtotalrelevance = true;
        bool playertotalrelevance = true;

        private void EnterMobStats_Click(object sender, EventArgs e)
        {
            using (DPSSolverMob DPSMobPage = new DPSSolverMob())
            {
                DPSMobPage.ShowDialog();
                Thread.CurrentThread.CurrentCulture = ci;
                Thread.CurrentThread.CurrentUICulture = ci;
                SolverRecalculate();
                EnterMobStats.Text = "Edit Mob Stats";
            }
        }

        private void EnterPlayerStats_Click(object sender, EventArgs e)
        {
            using (DPSSolverPlayer DPSPlayerPage = new DPSSolverPlayer())
            {
                DPSPlayerPage.ShowDialog();
                Thread.CurrentThread.CurrentCulture = ci;
                Thread.CurrentThread.CurrentUICulture = ci;
                SolverRecalculate();
                EnterPlayerStats.Text = "Edit Player Stats";
            }
        }

        private void EnterAction_Click(object sender, EventArgs e)
        {
            using (DPSSolverAction DPSActionPage = new DPSSolverAction())
            {
                DPSActionPage.ShowDialog();
                Thread.CurrentThread.CurrentCulture = ci;
                Thread.CurrentThread.CurrentUICulture = ci;
                SolverRecalculate();
            }
        }

        private void DeleteAction_Click(object sender, EventArgs e)
        {
            for (int i = solveractiontype.Count - 1; i >= 0; i--)
            {
                if (solveractiontype[i] != 4)
                {
                    solveractiontype.RemoveAt(i);
                    solverskillid.RemoveAt(i);
                    solverskilllevel.RemoveAt(i);
                    solverskillhittime.RemoveAt(i);
                    solverstatusid.RemoveAt(i);
                    solverstatusmaxduration.RemoveAt(i);
                    solverstatusduration.RemoveAt(i);
                    solverstatusticktime.RemoveAt(i);
                    solverstatusamount.RemoveAt(i);
                    solverstatusovercharge.RemoveAt(i);
                    solverstatusoverchargeslash.RemoveAt(i);
                    solverstatusoverchargecrush.RemoveAt(i);
                    solverstatusapplied.RemoveAt(i);
                    solverstatusend.RemoveAt(i);
                    solverdirectdamage.RemoveAt(i);
                    solvercooldown.RemoveAt(i);
                    solvercasttime.RemoveAt(i);
                    solverlockout.RemoveAt(i);
                    solverstalltime.RemoveAt(i);
                    solverhaspvpversion.RemoveAt(i);
                    solverattackmod.RemoveAt(i);
                    solverstrengthmod.RemoveAt(i);
                    solverdexteritymod.RemoveAt(i);
                    solverfocusmod.RemoveAt(i);
                    solvervitalitymod.RemoveAt(i);
                    solverweaponabilitymod.RemoveAt(i);
                    solverskillabilitymod.RemoveAt(i);
                    solversinglemaxdamage.RemoveAt(i);
                    solversingleactualdamage.RemoveAt(i);
                    solversingleresistdamage.RemoveAt(i);
                    solversingleleveldamage.RemoveAt(i);
                    solversingledps.RemoveAt(i);
                    solversinglechancetohit.RemoveAt(i);
                    solversinglecritchance.RemoveAt(i);
                    solversingleaggro.RemoveAt(i);
                    solversinglelock.RemoveAt(i);
                    solversingletimeforaction.RemoveAt(i);
                    SolverRecalculate();
                    break;
                }
            }
            OriginalMaxDamage.Text = "???";
            ActualDamage.Text = "???";
            DamageResist.Text = "???";
            DamageLevel.Text = "???";
            DPS.Text = "???";
            ChanceToHit.Text = "???";
            CriticalHitChance.Text = "???";
            AggroGenerated.Text = "???";
            LockContribution.Text = "???";
            TimeForAction.Text = "???";
            if (ActionsUsedListbox.Items.Count == 0)
            {
                OriginalMaxDamageTotal.Text = "???";
                ActualDamageTotal.Text = "???";
                DamageResistTotal.Text = "???";
                DamageLevelTotal.Text = "???";
                DPSTotal.Text = "???";
                ChanceToHitTotal.Text = "???";
                CriticalChanceTotal.Text = "???";
                AggroGeneratedTotal.Text = "???";
                LockContributionTotal.Text = "???";
                TimeForActionTotal.Text = "???";
            }
        }

        private void ActionsUsedListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActionsUsedListbox.SelectedIndex != -1)
            {
                if (solversinglemaxdamage[ActionsUsedListbox.SelectedIndex] == -1) OriginalMaxDamage.Text = "N/A";
                else OriginalMaxDamage.Text = solversinglemaxdamage[ActionsUsedListbox.SelectedIndex].ToString("0");
                if (solversingleactualdamage[ActionsUsedListbox.SelectedIndex] == -1) ActualDamage.Text = "N/A";
                else ActualDamage.Text = solversingleactualdamage[ActionsUsedListbox.SelectedIndex].ToString("0");
                if (solversingleresistdamage[ActionsUsedListbox.SelectedIndex] == -1) DamageResist.Text = "N/A";
                else DamageResist.Text = solversingleresistdamage[ActionsUsedListbox.SelectedIndex].ToString("0");
                if (solversingleleveldamage[ActionsUsedListbox.SelectedIndex] == -1) DamageLevel.Text = "N/A";
                else DamageLevel.Text = solversingleleveldamage[ActionsUsedListbox.SelectedIndex].ToString("0");
                if (solversingledps[ActionsUsedListbox.SelectedIndex] == -1) DPS.Text = "N/A";
                else if (solversingledps[ActionsUsedListbox.SelectedIndex] == -2) DPS.Text = "Infinite";
                else DPS.Text = solversingledps[ActionsUsedListbox.SelectedIndex].ToString("0");
                ChanceToHit.Text = solversinglechancetohit[ActionsUsedListbox.SelectedIndex].ToString("0.00") + "%";
                if (solversinglecritchance[ActionsUsedListbox.SelectedIndex] == -1) CriticalHitChance.Text = "N/A";
                else CriticalHitChance.Text = solversinglecritchance[ActionsUsedListbox.SelectedIndex].ToString("0.00") + "%";
                if (solversingleaggro[ActionsUsedListbox.SelectedIndex] == -1) AggroGenerated.Text = "N/A";
                else AggroGenerated.Text = solversingleaggro[ActionsUsedListbox.SelectedIndex].ToString("0");
                if (solversinglelock[ActionsUsedListbox.SelectedIndex] == -1) LockContribution.Text = "N/A";
                else LockContribution.Text = solversinglelock[ActionsUsedListbox.SelectedIndex].ToString("0.00") + "%";
                TimeForAction.Text = solversingletimeforaction[ActionsUsedListbox.SelectedIndex].ToString() + "s";

                if (ActionsUsedListbox.SelectedIndex != -1)
                {
                    if (mobtotalrelevance == false)
                    {
                        RelevantMobStatsListbox.Items.Clear();
                        for (int i = 0; i < solvermobstatinfo[ActionsUsedListbox.SelectedIndex].Count; i++)
                        {
                            switch (solvermobstatinfo[ActionsUsedListbox.SelectedIndex][i])
                            {
                                case 0:
                                    if (solverpercentpierceresist < 1)
                                    {
                                        RelevantMobStatsListbox.Items.Add("Pierce Resist: " + solvermobstatsave[ActionsUsedListbox.SelectedIndex][i] + " + " + Math.Abs((solverpercentpierceresist - 1) * 100) + "%");
                                    }
                                    else
                                    {
                                        RelevantMobStatsListbox.Items.Add("Pierce Resist: " + solvermobstatsave[ActionsUsedListbox.SelectedIndex][i]);
                                    }
                                    break;
                                case 1:
                                    if (solverpercentslashresist < 1)
                                    {
                                        RelevantMobStatsListbox.Items.Add("Slash Resist: " + solvermobstatsave[ActionsUsedListbox.SelectedIndex][i] + " + " + Math.Abs((solverpercentslashresist - 1) * 100) + "%");
                                    }
                                    else
                                    {
                                        RelevantMobStatsListbox.Items.Add("Slash Resist: " + solvermobstatsave[ActionsUsedListbox.SelectedIndex][i]);
                                    }
                                    break;
                                case 2:
                                    if (solverpercentcrushresist < 1)
                                    {
                                        RelevantMobStatsListbox.Items.Add("Crush Resist: " + solvermobstatsave[ActionsUsedListbox.SelectedIndex][i] + " + " + Math.Abs((solverpercentcrushresist - 1) * 100) + "%");
                                    }
                                    else
                                    {
                                        RelevantMobStatsListbox.Items.Add("Crush Resist: " + solvermobstatsave[ActionsUsedListbox.SelectedIndex][i]);
                                    }
                                    break;
                                case 3:
                                    if (solverpercentheatresist < 1)
                                    {
                                        RelevantMobStatsListbox.Items.Add("Heat Resist: " + solvermobstatsave[ActionsUsedListbox.SelectedIndex][i] + " + " + Math.Abs((solverpercentheatresist - 1) * 100) + "%");
                                    }
                                    else
                                    {
                                        RelevantMobStatsListbox.Items.Add("Heat Resist: " + solvermobstatsave[ActionsUsedListbox.SelectedIndex][i]);
                                    }
                                    break;
                                case 4:
                                    if (solverpercentcoldresist < 1)
                                    {
                                        RelevantMobStatsListbox.Items.Add("Cold Resist: " + solvermobstatsave[ActionsUsedListbox.SelectedIndex][i] + " + " + Math.Abs((solverpercentcoldresist - 1) * 100) + "%");
                                    }
                                    else
                                    {
                                        RelevantMobStatsListbox.Items.Add("Cold Resist: " + solvermobstatsave[ActionsUsedListbox.SelectedIndex][i]);
                                    }
                                    break;
                                case 5:
                                    if (solverpercentmagicresist < 1)
                                    {
                                        RelevantMobStatsListbox.Items.Add("Magic Resist: " + solvermobstatsave[ActionsUsedListbox.SelectedIndex][i] + " + " + Math.Abs((solverpercentmagicresist - 1) * 100) + "%");
                                    }
                                    else
                                    {
                                        RelevantMobStatsListbox.Items.Add("Magic Resist: " + solvermobstatsave[ActionsUsedListbox.SelectedIndex][i]);
                                    }
                                    break;
                                case 6:
                                    if (solverpercentpoisonresist < 1)
                                    {
                                        RelevantMobStatsListbox.Items.Add("Poison Resist: " + solvermobstatsave[ActionsUsedListbox.SelectedIndex][i] + " + " + Math.Abs((solverpercentpoisonresist - 1) * 100) + "%");
                                    }
                                    else
                                    {
                                        RelevantMobStatsListbox.Items.Add("Poison Resist: " + solvermobstatsave[ActionsUsedListbox.SelectedIndex][i]);
                                    }
                                    break;
                                case 7:
                                    if (solverpercentdivineresist < 1)
                                    {
                                        RelevantMobStatsListbox.Items.Add("Divine Resist: " + solvermobstatsave[ActionsUsedListbox.SelectedIndex][i] + " + " + Math.Abs((solverpercentdivineresist - 1) * 100) + "%");
                                    }
                                    else
                                    {
                                        RelevantMobStatsListbox.Items.Add("Divine Resist: " + solvermobstatsave[ActionsUsedListbox.SelectedIndex][i]);
                                    }
                                    break;
                                case 8:
                                    if (solverpercentchaosresist < 1)
                                    {
                                        RelevantMobStatsListbox.Items.Add("Chaos Resist: " + solvermobstatsave[ActionsUsedListbox.SelectedIndex][i] + " + " + Math.Abs((solverpercentchaosresist - 1) * 100) + "%");
                                    }
                                    else
                                    {
                                        RelevantMobStatsListbox.Items.Add("Chaos Resist: " + solvermobstatsave[ActionsUsedListbox.SelectedIndex][i]);
                                    }
                                    break;
                                case 9:
                                    if (solverpercenttrueresist < 1)
                                    {
                                        RelevantMobStatsListbox.Items.Add("True Resist: " + solvermobstatsave[ActionsUsedListbox.SelectedIndex][i] + " + " + Math.Abs((solverpercenttrueresist - 1) * 100) + "%");
                                    }
                                    else
                                    {
                                        RelevantMobStatsListbox.Items.Add("True Resist: " + solvermobstatsave[ActionsUsedListbox.SelectedIndex][i]);
                                    }
                                    break;
                                case 10:
                                    RelevantMobStatsListbox.Items.Add("Defence: " + solvermobstatsave[ActionsUsedListbox.SelectedIndex][i]);
                                    break;
                                case 11:
                                    RelevantMobStatsListbox.Items.Add("Physical Evasion: " + solvermobstatsave[ActionsUsedListbox.SelectedIndex][i]);
                                    break;
                                case 12:
                                    RelevantMobStatsListbox.Items.Add("Spell Evasion: " + solvermobstatsave[ActionsUsedListbox.SelectedIndex][i]);
                                    break;
                                case 13:
                                    RelevantMobStatsListbox.Items.Add("Movement Evasion: " + solvermobstatsave[ActionsUsedListbox.SelectedIndex][i]);
                                    break;
                                case 14:
                                    RelevantMobStatsListbox.Items.Add("Wounding Evasion: " + solvermobstatsave[ActionsUsedListbox.SelectedIndex][i]);
                                    break;
                                case 15:
                                    RelevantMobStatsListbox.Items.Add("Weakening Evasion: " + solvermobstatsave[ActionsUsedListbox.SelectedIndex][i]);
                                    break;
                            }
                        }
                        if (solverskillid[ActionsUsedListbox.SelectedIndex] != -1)
                        {
                            if (skillevasion[solverskillid[ActionsUsedListbox.SelectedIndex]] == "Mental")
                            {
                                RelevantMobStatsListbox.Items.Add("Mental Evasion: " + solvermental);
                            }
                        }
                        if (solvermoblevel > solverplayerlevel)
                        {
                            RelevantMobStatsListbox.Items.Add("Enemy Level: " + solvermoblevel);
                            RelevantMobStatsListbox.Items.Add("PvP(No Damage Lost From Level)");
                        }
                        if (solveractiontype[ActionsUsedListbox.SelectedIndex] == 1 && solversinglechancetohit[ActionsUsedListbox.SelectedIndex] == 70)
                        {
                            RelevantMobStatsListbox.Items.Add("PvP(30% Miss Cap Triggered)"); // saves a little processing time to not check for the extremely rare instance of something landing on the cap but not triggering it
                        }
                    }
                    if (playertotalrelevance == false)
                    {
                        RelevantPlayerStatsListbox.Items.Clear();
                        for (int i = 0; i < solverplayerstatinfo[ActionsUsedListbox.SelectedIndex].Count; i++)
                        {
                            switch (solverplayerstatinfo[ActionsUsedListbox.SelectedIndex][i])
                            {
                                case 0:
                                    RelevantPlayerStatsListbox.Items.Add("Pierce Damage: " + solverplayerstatsave[ActionsUsedListbox.SelectedIndex][i]);
                                    break;
                                case 1:
                                    RelevantPlayerStatsListbox.Items.Add("Slash Damage: " + solverplayerstatsave[ActionsUsedListbox.SelectedIndex][i]);
                                    break;
                                case 2:
                                    RelevantPlayerStatsListbox.Items.Add("Crush Damage: " + solverplayerstatsave[ActionsUsedListbox.SelectedIndex][i]);
                                    break;
                                case 3:
                                    RelevantPlayerStatsListbox.Items.Add("Heat Damage: " + solverplayerstatsave[ActionsUsedListbox.SelectedIndex][i]);
                                    break;
                                case 4:
                                    RelevantPlayerStatsListbox.Items.Add("Cold Damage: " + solverplayerstatsave[ActionsUsedListbox.SelectedIndex][i]);
                                    break;
                                case 5:
                                    RelevantPlayerStatsListbox.Items.Add("Magic Damage: " + solverplayerstatsave[ActionsUsedListbox.SelectedIndex][i]);
                                    break;
                                case 6:
                                    RelevantPlayerStatsListbox.Items.Add("Poison Damage: " + solverplayerstatsave[ActionsUsedListbox.SelectedIndex][i]);
                                    break;
                                case 7:
                                    RelevantPlayerStatsListbox.Items.Add("Divine Damage: " + solverplayerstatsave[ActionsUsedListbox.SelectedIndex][i]);
                                    break;
                                case 8:
                                    RelevantPlayerStatsListbox.Items.Add("Chaos Damage: " + solverplayerstatsave[ActionsUsedListbox.SelectedIndex][i]);
                                    break;
                                case 9:
                                    RelevantPlayerStatsListbox.Items.Add("True Damage: " + solverplayerstatsave[ActionsUsedListbox.SelectedIndex][i]);
                                    break;
                                case 10:
                                    RelevantPlayerStatsListbox.Items.Add("Attack: " + solverplayerstatsave[ActionsUsedListbox.SelectedIndex][i]);
                                    break;
                            }
                        }
                        if (solverskillid[ActionsUsedListbox.SelectedIndex] != -1)
                        {
                            switch (skillprimstat[solverskillid[ActionsUsedListbox.SelectedIndex]])
                            {
                                case "Strength":
                                    RelevantPlayerStatsListbox.Items.Add("Strength: " + (solverstrength + solverstrengthmod[ActionsUsedListbox.SelectedIndex]));
                                    break;
                                case "Dexterity":
                                    RelevantPlayerStatsListbox.Items.Add("Dexterity: " + (solverdexterity + solverdexteritymod[ActionsUsedListbox.SelectedIndex]));
                                    break;
                                case "Focus":
                                    RelevantPlayerStatsListbox.Items.Add("Focus: " + (solverfocus + solverfocusmod[ActionsUsedListbox.SelectedIndex]));
                                    break;
                                case "Vitality":
                                    RelevantPlayerStatsListbox.Items.Add("Vitality: " + (solvervitality + solvervitalitymod[ActionsUsedListbox.SelectedIndex]));
                                    break;
                            }
                            if (skillauto[solverskillid[ActionsUsedListbox.SelectedIndex]] == "Yes")
                            {
                                RelevantPlayerStatsListbox.Items.Add("Weapon Ability: " + (solverweaponability + solverweaponabilitymod[ActionsUsedListbox.SelectedIndex]));
                            }
                            if (skillability[solverskillid[ActionsUsedListbox.SelectedIndex]] != "None")
                            {
                                RelevantPlayerStatsListbox.Items.Add("Skill Ability: " + (solverskillability + solverskillabilitymod[ActionsUsedListbox.SelectedIndex]));
                            }
                        }
                        switch (solveractiontype[ActionsUsedListbox.SelectedIndex])
                        {
                            case 0:
                                RelevantPlayerStatsListbox.Items.Add("Weapon Ability: " + (solverweaponability + solverweaponabilitymod[ActionsUsedListbox.SelectedIndex]));
                                RelevantPlayerStatsListbox.Items.Add("Critical Strike: " + solvercritstrike);
                                break;
                            case 1:
                            case 2:
                                RelevantPlayerStatsListbox.Items.Add("Critical Skills: " + solvercritskills);
                                break;
                        }
                        RelevantPlayerStatsListbox.Items.Add("Player Level: " + solverplayerlevel);
                        if (solverpvp == true && solverhaspvpversion[ActionsUsedListbox.SelectedIndex] == true)
                        {
                            RelevantPlayerStatsListbox.Items.Add("PvP(PvP Altered Skill)");
                        }
                    }
                }
            }
            else
            {
                OriginalMaxDamage.Text = "???";
                ActualDamage.Text = "???";
                DamageResist.Text = "???";
                DamageLevel.Text = "???";
                DPS.Text = "???";
                ChanceToHit.Text = "???";
                CriticalHitChance.Text = "???";
                AggroGenerated.Text = "???";
                LockContribution.Text = "???";
                TimeForAction.Text = "???";
            }
        }

        private void MobRelevance_Click(object sender, EventArgs e)
        {
            if (mobtotalrelevance == true)
            {
                mobtotalrelevance = false;
                MobRelevance.Text = "Relevance Mode: Total";
                RelevantMobStatsListbox.Items.Clear();
            }
            else
            {
                mobtotalrelevance = true;
                MobRelevance.Text = "Relevance Mode: Selected";
                SolverRecalculate();
            }
        }

        private void PlayerRelevance_Click(object sender, EventArgs e)
        {
            if (playertotalrelevance == true)
            {
                playertotalrelevance = false;
                PlayerRelevance.Text = "Relevance Mode: Total";
                RelevantPlayerStatsListbox.Items.Clear();
            }
            else
            {
                playertotalrelevance = true;
                PlayerRelevance.Text = "Relevance Mode: Selected";
                SolverRecalculate();
            }
        }

        private void SolverRecalculate() // level is not a factor in pvp aside from the resistance equation
        {
            if (mobdone == true && playerdone == true)
            {
                if (solveractiontype.Count > 0) DeleteAction.Enabled = true;
                else DeleteAction.Enabled = false;

                RelevantPlayerStatsListbox.Items.Clear();
                RelevantMobStatsListbox.Items.Clear();

                ActionsUsedListbox.Items.Clear();
                EnterAction.Enabled = true;
                MobRelevance.Enabled = true;
                PlayerRelevance.Enabled = true;
                ExtraDataLabel.Enabled = true;
                SkillMissMultiplierLabel.Enabled = true;
                SkillMissMultiplier.Enabled = true;
                AutoRollLabel.Enabled = true;
                AutoRoll.Enabled = true;
                SkillRollLabel.Enabled = true;
                SkillRoll.Enabled = true;
                DamageForLockLabel.Enabled = true;
                DamageForLock.Enabled = true;
                OriginalAggroRangeLabel.Enabled = true;
                OriginalAggroRange.Enabled = true;
                ActualAggroRangeLabel.Enabled = true;
                ActualAggroRange.Enabled = true;
                ExperienceGainedLabel.Enabled = true;
                ExperienceGained.Enabled = true;
                Drawing1.Enabled = true;

                TotalOutcomeLabel.Enabled = true;
                OriginalMaxDamageTotalLabel.Enabled = true;
                OriginalMaxDamageTotal.Enabled = true;
                ActualDamageTotalLabel.Enabled = true;
                ActualDamageTotal.Enabled = true;
                DamageResistTotalLabel.Enabled = true;
                DamageResistTotal.Enabled = true;
                DamageLevelTotalLabel.Enabled = true;
                DamageLevelTotal.Enabled = true;
                DPSTotalLabel.Enabled = true;
                DPSTotal.Enabled = true;
                ChanceToHitTotalLabel.Enabled = true;
                ChanceToHitTotal.Enabled = true;
                CriticalChanceTotalLabel.Enabled = true;
                CriticalChanceTotal.Enabled = true;
                AggroGeneratedTotalLabel.Enabled = true;
                AggroGeneratedTotal.Enabled = true;
                LockContributionTotalLabel.Enabled = true;
                LockContributionTotal.Enabled = true;
                TimeForActionTotalLabel.Enabled = true;
                TimeForActionTotal.Enabled = true;

                ActionsUsedLabel.Enabled = true;
                ActionsUsedListbox.Enabled = true;
                SelectedOutcomeLabel.Enabled = true;
                OriginalMaxDamageLabel.Enabled = true;
                OriginalMaxDamage.Enabled = true;
                ActualDamageLabel.Enabled = true;
                ActualDamage.Enabled = true;
                DamageResistLabel.Enabled = true;
                DamageResist.Enabled = true;
                DamageLevelLabel.Enabled = true;
                DamageLevel.Enabled = true;
                DPSLabel.Enabled = true;
                DPS.Enabled = true;
                ChanceToHitLabel.Enabled = true;
                ChanceToHit.Enabled = true;
                CriticalChanceLabel.Enabled = true;
                CriticalHitChance.Enabled = true;
                AggroGeneratedLabel.Enabled = true;
                AggroGenerated.Enabled = true;
                LockContributionLabel.Enabled = true;
                LockContribution.Enabled = true;
                TimeForActionLabel.Enabled = true;
                TimeForAction.Enabled = true;

                usepvp = false;
                pvpevasioncap = false;
                usemoblevel = false;
                useattack = false;
                usedefence = false;
                usephysicalevade = false;
                usespellevade = false;
                usemovementevade = false;
                usewoundingevade = false;
                useweakeningevade = false;
                usementalevade = false;
                usepierceresist = false;
                useslashresist = false;
                usecrushresist = false;
                useheatresist = false;
                usecoldresist = false;
                usemagicresist = false;
                usepoisonresist = false;
                usedivineresist = false;
                usechaosresist = false;
                usetrueresist = false;
                usepierce = false;
                useslash = false;
                usecrush = false;
                useheat = false;
                usecold = false;
                usemagic = false;
                usepoison = false;
                usedivine = false;
                usechaos = false;
                usetrue = false;
                usestrength = false;
                usedexterity = false;
                usefocus = false;
                usevitality = false;
                useweaponability = false;
                useskillability = false;
                usecritstrike = false;
                usecritskills = false;

                solvermaxdamage = 0;
                solverresistdamage = 0;
                solverleveldamage = 0;
                solverdps = 0;
                solverchancetohit = 0;
                solvercritchance = 0;
                solveraggrogenerated = 0;
                solverlockcontribution = 0;
                solvertimeforaction = 0;
                maxdamageholder = 0;
                leveldamageholder = 0;
                resistdamageholder = 0;
                solverchancetohittotal.Clear();
                solvercritchancetotal.Clear();

                solverpiercedamage = 0;
                solverslashdamage = 0;
                solvercrushdamage = 0;
                solverheatdamage = 0;
                solvercolddamage = 0;
                solvermagicdamage = 0;
                solverpoisondamage = 0;
                solverdivinedamage = 0;
                solverchaosdamage = 0;
                solvertruedamage = 0;

                solvertempdefence = solverdefence;
                solvertempphysical = solverphysical;
                solvertempspell = solverspell;
                solvertempmovement = solvermovement;
                solvertempwounding = solverwounding;
                solvertempweakening = solverweakening;
                solvertempmental = solvermental;
                solvertemppierceplus = 0;
                solvertempslashplus = 0;
                solvertempcrushplus = 0;
                solvertempheat = solverheat;
                solvertempcold = solvercold;
                solvertempmagic = solvermagic;
                solvertemppoison = solverpoison;
                solvertempdivine = solverdivine;
                solvertempchaos = solverchaos;
                solvertemptrue = solvertrue;
                solvertemppluspierceresist = solverpluspierceresist;
                solvertempplusslashresist = solverplusslashresist;
                solvertemppluscrushresist = solverpluscrushresist;
                solvertempplusheatresist = solverplusheatresist;
                solvertemppluscoldresist = solverpluscoldresist;
                solvertempplusmagicresist = solverplusmagicresist;
                solvertemppluspoisonresist = solverpluspoisonresist;
                solvertempplusdivineresist = solverplusdivineresist;
                solvertemppluschaosresist = solverpluschaosresist;
                solvertempplustrueresist = solverplustrueresist;
                solvertempattack = solverattack;
                solverlowpluspierceresist = solverpluspierceresist;
                solverlowplusslashresist = solverplusslashresist;
                solverlowpluscrushresist = solverpluscrushresist;
                solverlowplusheatresist = solverplusheatresist;
                solverlowpluscoldresist = solverpluscoldresist;
                solverlowplusmagicresist = solverplusmagicresist;
                solverlowpluspoisonresist = solverpluspoisonresist;
                solverlowplusdivineresist = solverplusdivineresist;
                solverlowpluschaosresist = solverpluschaosresist;
                solverlowplustrueresist = solverplustrueresist;
                solverlowdefence = solverdefence;
                solverhighattack = solverattack;
                solverlowattack = solverattack;
                solverhighstrength = solverstrength;
                solverlowstrength = solverstrength;
                solverhighdexterity = solverdexterity;
                solverlowdexterity = solverdexterity;
                solverhighfocus = solverfocus;
                solverlowfocus = solverfocus;
                solverhighvitality = solvervitality;
                solverlowvitality = solvervitality;
                solverhighweaponability = solverweaponability;
                solverlowweaponability = solverweaponability;
                solverhighskillability = solverskillability;
                solverlowskillability = solverskillability;
                solverlowphysical = solverphysical;
                solverlowspell = solverspell;
                solverlowmovement = solvermovement;
                solverlowwounding = solverwounding;
                solverlowweakening = solverweakening;

                fireattuneactive = false;
                fireattuneamount = 0;
                iceattuneactive = false;
                iceattuneamount = 0;
                damagemultiplieractive = false;
                damagemultiplieramount = 0;

                switch (solverclass)
                {
                    case 0:
                        SkillMissMultiplier.Text = "0.95";
                        AutoRoll.Text = "30%";
                        SkillRoll.Text = "30%";
                        break;
                    case 1:
                        SkillMissMultiplier.Text = "0.7";
                        AutoRoll.Text = "40%";
                        SkillRoll.Text = "50%";
                        break;
                    case 2:
                        SkillMissMultiplier.Text = "0.7";
                        AutoRoll.Text = "40%";
                        SkillRoll.Text = "50%";
                        break;
                    case 3:
                        SkillMissMultiplier.Text = "0.7";
                        AutoRoll.Text = "30%";
                        SkillRoll.Text = "40%";
                        break;
                    case 4:
                        SkillMissMultiplier.Text = "0.95";
                        AutoRoll.Text = "30%";
                        SkillRoll.Text = "30%";
                        break;
                }
                OriginalAggroRange.Text = (solveraggro).ToString();
                if (solverplayerlevel > solvermoblevel)
                {
                    if (solverplayerlevel > 220)
                    {
                        if (220 > solvermoblevel + 10)
                        {
                            DamageForLock.Text = (solverhealth * (((220 - (solvermoblevel + 10)) / 190) * 0.9 + 0.1)).ToString("0");
                        }
                        else DamageForLock.Text = (solverhealth * 0.1).ToString("0");
                    }
                    else
                    {
                        if (solverplayerlevel > solvermoblevel + 10)
                        {
                            DamageForLock.Text = (solverhealth * (((solverplayerlevel - (solvermoblevel + 10)) / 190) * 0.9 + 0.1)).ToString("0");
                        }
                        else DamageForLock.Text = (solverhealth * 0.1).ToString("0");
                    }
                    if (((1 - 1.25 * (solverplayerlevel - solvermoblevel) / 100) * solveraggro) > 0)
                    {
                        ActualAggroRange.Text = ((1 - 1.25 * (solverplayerlevel - solvermoblevel) / 100) * solveraggro).ToString("0.00");
                    }
                    else ActualAggroRange.Text = "0";
                    ExperienceGained.Text = ((int)Math.Round(Math.Pow(0.75, (solverplayerlevel - solvermoblevel)) * solverxp)).ToString();
                    levelfactorholder = 1;
                    if ((solverplayerlevel - solvermoblevel) > 20)
                    {
                        if ((solverplayerlevel - solvermoblevel) > 50)
                        {
                            aggrofactorholder = 0.1f;
                        }
                        else
                        {
                            aggrofactorholder = ((1 - (((solverplayerlevel - solvermoblevel) - 20) / 30)) * 0.9f) + 0.1f;
                        }
                    }
                    usemoblevel = true;
                }
                else if (solverplayerlevel < solvermoblevel)
                {
                    if (solverplayerlevel < solvermoblevel - 10)
                    {
                        DamageForLock.Text = (solverhealth * ((((solvermoblevel - 10) - solverplayerlevel) / 190) * 0.9 + 0.1)).ToString("0");
                    }
                    else DamageForLock.Text = (solverhealth * 0.1).ToString("0");
                    ActualAggroRange.Text = (solveraggro).ToString();
                    ExperienceGained.Text = solverxp.ToString();
                    if (solverpvp == false)
                    {
                        levelfactorholder = 1 - 0.04f * (solvermoblevel - solverplayerlevel);
                        if (levelfactorholder < 0.1) levelfactorholder = 0.1f;
                    }
                    else levelfactorholder = 1;
                    if ((solvermoblevel - solverplayerlevel) > 10)
                    {
                        aggrofactorholder = 1 + (solvermoblevel - solverplayerlevel - 10) * 0.2f;
                    }
                    usemoblevel = true;
                }
                else
                {
                    DamageForLock.Text = (solverhealth * 0.1).ToString("0");
                    ActualAggroRange.Text = (solveraggro).ToString();
                    ExperienceGained.Text = solverxp.ToString();
                    levelfactorholder = 1;
                    aggrofactorholder = 1;
                }

                float primstatmod;
                int primstat;
                List<float> PrimStats = new List<float>();
                List<float> PrimStatsMod = new List<float>();
                PrimStats.Add(solverstrength);
                PrimStats.Add(solverdexterity);
                PrimStats.Add(solverfocus);
                PrimStats.Add(solvervitality);
                PrimStats.Add(0);

                float ability = 0;
                bool noability = false;

                int pvpmode;

                timeholder = 0;
                for (int i = 0; i < solveractiontype.Count; i++)
                {
                    if (solveractiontype[i] == 2)
                    {
                        solverstatusapplied[i] = false;
                        solverstatusend[i] = false;
                    }
                    if (solveractiontype[i] == 4)
                    {
                        solveractiontype.RemoveAt(i);
                        solverskillid.RemoveAt(i);
                        solverskilllevel.RemoveAt(i);
                        solverskillhittime.RemoveAt(i);
                        solverstatusid.RemoveAt(i);
                        solverstatusmaxduration.RemoveAt(i);
                        solverstatusduration.RemoveAt(i);
                        solverstatusticktime.RemoveAt(i);
                        solverstatusamount.RemoveAt(i);
                        solverstatusovercharge.RemoveAt(i);
                        solverstatusoverchargeslash.RemoveAt(i);
                        solverstatusoverchargecrush.RemoveAt(i);
                        solverstatusapplied.RemoveAt(i);
                        solverstatusend.RemoveAt(i);
                        solverdirectdamage.RemoveAt(i);
                        solvercooldown.RemoveAt(i);
                        solvercasttime.RemoveAt(i);
                        solverlockout.RemoveAt(i);
                        solverstalltime.RemoveAt(i);
                        solverhaspvpversion.RemoveAt(i);
                        solverattackmod.RemoveAt(i);
                        solverstrengthmod.RemoveAt(i);
                        solverdexteritymod.RemoveAt(i);
                        solverfocusmod.RemoveAt(i);
                        solvervitalitymod.RemoveAt(i);
                        solverweaponabilitymod.RemoveAt(i);
                        solverskillabilitymod.RemoveAt(i);
                        solversinglemaxdamage.RemoveAt(i);
                        solversingleactualdamage.RemoveAt(i);
                        solversingleresistdamage.RemoveAt(i);
                        solversingleleveldamage.RemoveAt(i);
                        solversingledps.RemoveAt(i);
                        solversinglechancetohit.RemoveAt(i);
                        solversinglecritchance.RemoveAt(i);
                        solversingleaggro.RemoveAt(i);
                        solversinglelock.RemoveAt(i);
                        solversingletimeforaction.RemoveAt(i);
                    }
                }
                for (int i = 0; i < solveractiontype.Count; i++)
                {
                    solversinglemaxdamage[i] = -1;
                    solversingleactualdamage[i] = -1;
                    solversingleresistdamage[i] = -1;
                    solversingleleveldamage[i] = -1;
                    solversingledps[i] = -1;
                    solversinglechancetohit[i] = 100;
                    solversinglecritchance[i] = -1;
                    solversingleaggro[i] = -1;
                    solversinglelock[i] = -1;
                    solversingletimeforaction[i] = -1;
                    solvermobstatsave[i].Clear();
                    solvermobstatinfo[i].Clear();
                    solverplayerstatsave[i].Clear();
                    solverplayerstatinfo[i].Clear();
                }
                for (int x = 0; x < solveractiontype.Count; x++)
                {
                    if (solverstrength + solverstrengthmod[x] > solverhighstrength)
                    {
                        solverhighstrength = solverstrength + solverstrengthmod[x];
                    }
                    else if (solverstrength + solverstrengthmod[x] < solverlowstrength)
                    {
                        solverlowstrength = solverstrength + solverstrengthmod[x];
                    }
                    if (solverdexterity + solverdexteritymod[x] > solverhighdexterity)
                    {
                        solverhighdexterity = solverdexterity + solverdexteritymod[x];
                    }
                    else if (solverdexterity + solverdexteritymod[x] < solverlowdexterity)
                    {
                        solverlowdexterity = solverdexterity + solverdexteritymod[x];
                    }
                    if (solverfocus + solverfocusmod[x] > solverhighfocus)
                    {
                        solverhighfocus = solverfocus + solverfocusmod[x];
                    }
                    else if (solverfocus + solverfocusmod[x] < solverlowfocus)
                    {
                        solverlowfocus = solverfocus + solverfocusmod[x];
                    }
                    if (solvervitality + solvervitalitymod[x] > solverhighvitality)
                    {
                        solverhighvitality = solvervitality + solvervitalitymod[x];
                    }
                    else if (solvervitality + solvervitalitymod[x] < solverlowvitality)
                    {
                        solverlowvitality = solvervitality + solvervitalitymod[x];
                    }
                    if (solverweaponability + solverweaponabilitymod[x] > solverhighweaponability)
                    {
                        solverhighweaponability = solverweaponability + solverweaponabilitymod[x];
                    }
                    else if (solverweaponability + solverweaponabilitymod[x] < solverlowweaponability)
                    {
                        solverlowweaponability = solverweaponability + solverweaponabilitymod[x];
                    }
                    if (solverskillability + solverskillabilitymod[x] > solverhighskillability)
                    {
                        solverhighskillability = solverskillability + solverskillabilitymod[x];
                    }
                    else if (solverskillability + solverskillabilitymod[x] < solverlowskillability)
                    {
                        solverlowskillability = solverskillability + solverskillabilitymod[x];
                    }
                    int autoflatdmg = (int)(solvertemppierceplus + solvertempslashplus + solvertempcrushplus + solvertempheat + solvertempcold + solvertempmagic + solvertemppoison + solvertempdivine + solvertempchaos + solvertemptrue);
                    float automulti = (float)(Math.Sqrt((solverstrength + solverstrengthmod[x]) / 40.0) + Math.Sqrt((solverweaponability + solverweaponabilitymod[x]) / 280.0)) + 1;
                    solverleveldamage = 0;
                    resistdamageholder = 0;
                    if (solverskillid[x] != -1)
                    {
                        if (skillability[solverskillid[x]] != "None")
                        {
                            ability = solverskillability;
                            noability = false;
                        }
                        else
                        {
                            ability = 0;
                            noability = true;
                        }
                    }
                    if (solverpvp == true && solverhaspvpversion[x] == true)
                    {
                        pvpmode = 1;
                        usepvp = true;
                    }
                    else pvpmode = 0;
                    switch (solveractiontype[x])
                    {
                        case 0:
                            if (damagemultiplieractive == true)
                            {
                                maxdamageholder = ((int)(automulti * solverpierce) + (int)(automulti * solverslash) + (int)(automulti * solvercrush) + autoflatdmg) * damagemultiplieramount;
                            }
                            else
                            {
                                maxdamageholder = (int)(automulti * solverpierce) + (int)(automulti * solverslash) + (int)(automulti * solvercrush) + autoflatdmg;
                            }
                            solversinglemaxdamage[x] = maxdamageholder;
                            solvermaxdamage = (int)(solvermaxdamage + maxdamageholder);
                            leveldamageholder = solvermaxdamage * levelfactorholder;
                            solversingleleveldamage[x] = (int)(solversinglemaxdamage[x] - (solversinglemaxdamage[x] * levelfactorholder));
                            solverleveldamage = (int)(solverleveldamage + (solvermaxdamage - leveldamageholder));
                            if (solverpierce > 0 || solvertemppierceplus > 0)
                            {
                                solverpiercedamage = solverpiercedamage + (int)(automulti * solverpierce + solvertemppierceplus);
                                resistdamageholder = resistdamageholder + (((int)(automulti * solverpierce + solvertemppierceplus) * levelfactorholder) - (((int)(automulti * solverpierce + solvertemppierceplus) * levelfactorholder) * (1 - (solvertemppluspierceresist / (solvertemppluspierceresist + 6 + 3 * solverplayerlevel)))) * solverpercentpierceresist);
                                usepierce = true;
                                usepierceresist = true;
                                usestrength = true;
                                solvermobstatsave[x].Add(solvertemppluspierceresist);
                                solvermobstatinfo[x].Add(0);
                                solverplayerstatsave[x].Add((int)(automulti * solverpierce + solvertemppierceplus));
                                solverplayerstatinfo[x].Add(0);
                            }
                            if (solverslash > 0 || solvertempslashplus > 0)
                            {
                                solverslashdamage = solverslashdamage + (int)(automulti * solverslash + solvertempslashplus);
                                resistdamageholder = resistdamageholder + (((int)(automulti * solverslash + solvertempslashplus) * levelfactorholder) - (((int)(automulti * solverslash + solvertempslashplus) * levelfactorholder) * (1 - (solvertempplusslashresist / (solvertempplusslashresist + 6 + 3 * solverplayerlevel)))) * solverpercentslashresist);
                                useslash = true;
                                useslashresist = true;
                                usestrength = true;
                                solvermobstatsave[x].Add(solvertempplusslashresist);
                                solvermobstatinfo[x].Add(1);
                                solverplayerstatsave[x].Add((int)(automulti * solverslash + solvertempslashplus));
                                solverplayerstatinfo[x].Add(1);
                            }
                            if (solvercrush > 0 || solvertempcrushplus > 0)
                            {
                                solvercrushdamage = solvercrushdamage + (int)(automulti * solvercrush + solvertempcrushplus);
                                resistdamageholder = resistdamageholder + (((int)(automulti * solvercrush + solvertempcrushplus) * levelfactorholder) - (((int)(automulti * solvercrush + solvertempcrushplus) * levelfactorholder) * (1 - (solvertemppluscrushresist / (solvertemppluscrushresist + 6 + 3 * solverplayerlevel)))) * solverpercentcrushresist);
                                usecrush = true;
                                usecrushresist = true;
                                usestrength = true;
                                solvermobstatsave[x].Add(solvertemppluscrushresist);
                                solvermobstatinfo[x].Add(2);
                                solverplayerstatsave[x].Add((int)(automulti * solvercrush + solvertempcrushplus));
                                solverplayerstatinfo[x].Add(2);
                            }
                            if (solvertempheat > 0)
                            {
                                solverheatdamage = solverheatdamage + solvertempheat;
                                resistdamageholder = resistdamageholder + ((solvertempheat * levelfactorholder) - ((solvertempheat * levelfactorholder) * (1 - (solvertempplusheatresist / (solvertempplusheatresist + 6 + 3 * solverplayerlevel)))) * solverpercentheatresist);
                                useheat = true;
                                useheatresist = true;
                                solvermobstatsave[x].Add(solvertempplusheatresist);
                                solvermobstatinfo[x].Add(3);
                                solverplayerstatsave[x].Add(solvertempheat);
                                solverplayerstatinfo[x].Add(3);
                            }
                            if (solvertempcold > 0)
                            {
                                solvercolddamage = solvercolddamage + solvertempcold;
                                resistdamageholder = resistdamageholder + ((solvertempcold * levelfactorholder) - ((solvertempcold * levelfactorholder) * (1 - (solvertemppluscoldresist / (solvertemppluscoldresist + 6 + 3 * solverplayerlevel)))) * solverpercentcoldresist);
                                usecold = true;
                                usecoldresist = true;
                                solvermobstatsave[x].Add(solvertemppluscoldresist);
                                solvermobstatinfo[x].Add(4);
                                solverplayerstatsave[x].Add(solvertempcold);
                                solverplayerstatinfo[x].Add(4);
                            }
                            if (solvertempmagic > 0)
                            {
                                solvermagicdamage = solvermagicdamage + solvertempmagic;
                                resistdamageholder = resistdamageholder + ((solvertempmagic * levelfactorholder) - ((solvertempmagic * levelfactorholder) * (1 - (solvertempplusmagicresist / (solvertempplusmagicresist + 6 + 3 * solverplayerlevel)))) * solverpercentmagicresist);
                                usemagic = true;
                                usemagicresist = true;
                                solvermobstatsave[x].Add(solvertempplusmagicresist);
                                solvermobstatinfo[x].Add(5);
                                solverplayerstatsave[x].Add(solvertempmagic);
                                solverplayerstatinfo[x].Add(5);
                            }
                            if (solvertemppoison > 0)
                            {
                                solverpoisondamage = solverpoisondamage + solvertemppoison;
                                resistdamageholder = resistdamageholder + ((solvertemppoison * levelfactorholder) - ((solvertemppoison * levelfactorholder) * (1 - (solvertemppluspoisonresist / (solvertemppluspoisonresist + 6 + 3 * solverplayerlevel)))) * solverpercentpoisonresist);
                                usepoison = true;
                                usepoisonresist = true;
                                solvermobstatsave[x].Add(solvertemppluspoisonresist);
                                solvermobstatinfo[x].Add(6);
                                solverplayerstatsave[x].Add(solvertemppoison);
                                solverplayerstatinfo[x].Add(6);
                            }
                            if (solvertempdivine > 0)
                            {
                                solverdivinedamage = solverdivinedamage + solvertempdivine;
                                resistdamageholder = resistdamageholder + ((solvertempdivine * levelfactorholder) - ((solvertempdivine * levelfactorholder) * (1 - (solvertempplusdivineresist / (solvertempplusdivineresist + 6 + 3 * solverplayerlevel)))) * solverpercentdivineresist);
                                usedivine = true;
                                usedivineresist = true;
                                solvermobstatsave[x].Add(solvertempplusdivineresist);
                                solvermobstatinfo[x].Add(7);
                                solverplayerstatsave[x].Add(solvertempdivine);
                                solverplayerstatinfo[x].Add(7);
                            }
                            if (solvertempchaos > 0)
                            {
                                solverchaosdamage = solverchaosdamage + solvertempchaos;
                                resistdamageholder = resistdamageholder + ((solvertempchaos * levelfactorholder) - ((solvertempchaos * levelfactorholder) * (1 - (solvertemppluschaosresist / (solvertemppluschaosresist + 6 + 3 * solverplayerlevel)))) * solverpercentchaosresist);
                                usechaos = true;
                                usechaosresist = true;
                                solvermobstatsave[x].Add(solvertemppluschaosresist);
                                solvermobstatinfo[x].Add(8);
                                solverplayerstatsave[x].Add(solvertempchaos);
                                solverplayerstatinfo[x].Add(8);
                            }
                            if (solvertemptrue > 0)
                            {
                                solvertruedamage = solvertruedamage + solvertemptrue;
                                resistdamageholder = resistdamageholder + ((solvertemptrue * levelfactorholder) - ((solvertemptrue * levelfactorholder) * (1 - (solvertempplustrueresist / (solvertempplustrueresist + 6 + 3 * solverplayerlevel)))) * solverpercenttrueresist);
                                usetrue = true;
                                usetrueresist = true;
                                solvermobstatsave[x].Add(solvertempplustrueresist);
                                solvermobstatinfo[x].Add(9);
                                solverplayerstatsave[x].Add(solvertemptrue);
                                solverplayerstatinfo[x].Add(9);
                            }
                            solversingleresistdamage[x] = (int)resistdamageholder;
                            solverresistdamage = (int)(solverresistdamage + resistdamageholder);
                            if (solverdefence > 0)
                            {
                                solvertempattack = solvertempattack + solverattackmod[x];
                                solverchancetohittotal.Add((solvertempattack / (solvertempattack + solvertempdefence)) * 100);
                                solversinglechancetohit[x] = (solvertempattack / (solvertempattack + solvertempdefence)) * 100;
                                solvertempattack = solvertempattack - solverattackmod[x];
                            }
                            else
                            {
                                solverchancetohittotal.Add(100);
                                solversinglechancetohit[x] = 100;
                            }
                            solvercritchancetotal.Add(0.08f * ((solvercritstrike + 40) / (solvercritstrike + 40 + 10 * (solvermoblevel + 3))) * 100);
                            solversinglecritchance[x] = 0.08f * ((solvercritstrike + 40) / (solvercritstrike + 40 + 10 * (solvermoblevel + 3))) * 100;
                            solveraggrogenerated = solveraggrogenerated + (maxdamageholder - resistdamageholder - (maxdamageholder - (maxdamageholder * levelfactorholder))) * 1.5f;
                            solversingleaggro[x] = (solversinglemaxdamage[x] - solversingleresistdamage[x] - (solversinglemaxdamage[x] - (solversinglemaxdamage[x] * levelfactorholder))) * 1.5f;
                            ActionsUsedListbox.Items.Add("Auto Attack");
                            solverskillhittime[x] = timeholder;
                            solversingletimeforaction[x] = 0;
                            solversingleactualdamage[x] = solversinglemaxdamage[x] - solversingleresistdamage[x] - solversingleleveldamage[x];
                            solversingledps[x] = -2; // code for infinite(it has infinite dps because it has no cast time)
                            solversinglelock[x] = (solversingleactualdamage[x] / float.Parse(DamageForLock.Text)) * 100;
                            useattack = true;
                            usedefence = true;
                            usecritstrike = true;
                            useweaponability = true;
                            solvermobstatsave[x].Add(solvertempdefence);
                            solvermobstatinfo[x].Add(10);
                            solverplayerstatsave[x].Add(solvertempattack + solverattackmod[x]);
                            solverplayerstatinfo[x].Add(10);
                            break;
                        case 1:
                            if (float.Parse(skilllvbaseamount[solverskilllevel[x]]) >= 0 && float.Parse(skilllvinitialdamage[solverskilllevel[x]]) >= 0 && skillid[solverskillid[x]] != "145") // no sacrifice or heals
                            {
                                PrimStatsMod.Clear();
                                PrimStatsMod.Add(solverstrengthmod[x]);
                                PrimStatsMod.Add(solverdexteritymod[x]);
                                PrimStatsMod.Add(solverfocusmod[x]);
                                PrimStatsMod.Add(solvervitalitymod[x]);
                                PrimStatsMod.Add(0);

                                primstatmod = float.Parse(skillprimmod[solverskillid[x]]);

                                if (skillprimstat[solverskillid[x]] == "Strength")
                                {
                                    primstat = 0;
                                    usestrength = true;
                                }
                                else if (skillprimstat[solverskillid[x]] == "Dexterity")
                                {
                                    primstat = 1;
                                    usedexterity = true;
                                }
                                else if (skillprimstat[solverskillid[x]] == "Focus")
                                {
                                    primstat = 2;
                                    usefocus = true;
                                }
                                else if (skillprimstat[solverskillid[x]] == "Vitality")
                                {
                                    primstat = 3;
                                    usevitality = true;
                                }
                                else primstat = 4;
                                if (primstat == 4 || float.Parse(skillprimmod[solverskillid[x]]) == 0) primstatmod = 1;
                                else primstatmod = float.Parse(skillprimmod[solverskillid[x]]);

                                int evasiontype;
                                List<float> evasions = new List<float>();
                                evasions.Add(solvertempphysical);
                                evasions.Add(solvertempspell);
                                evasions.Add(solvertempmovement);
                                evasions.Add(solvertempwounding);
                                evasions.Add(solvertempweakening);
                                evasions.Add(solvertempmental);
                                evasions.Add(0);

                                if (skillevasion[solverskillid[x]] == "Physical")
                                {
                                    evasiontype = 0;
                                    usephysicalevade = true;
                                }
                                else if (skillevasion[solverskillid[x]] == "Spell")
                                {
                                    evasiontype = 1;
                                    usespellevade = true;
                                }
                                else if (skillevasion[solverskillid[x]] == "Movement")
                                {
                                    evasiontype = 2;
                                    usemovementevade = true;
                                }
                                else if (skillevasion[solverskillid[x]] == "Wounding")
                                {
                                    evasiontype = 3;
                                    usewoundingevade = true;
                                }
                                else if (skillevasion[solverskillid[x]] == "Weakening")
                                {
                                    evasiontype = 4;
                                    useweakeningevade = true;
                                }
                                else if (skillevasion[solverskillid[x]] == "Mental")
                                {
                                    evasiontype = 5;
                                    usementalevade = true;
                                }
                                else evasiontype = 6; // None

                                int evasionclassroll = 0;
                                List<float> evasionroll = new List<float>();
                                evasionroll.Add(0.95f);
                                evasionroll.Add(0.7f);
                                evasionroll.Add(0.7f);
                                evasionroll.Add(0.7f);
                                evasionroll.Add(0.95f);

                                switch (solverclass)
                                {
                                    case 0:
                                        evasionclassroll = 0;
                                        break;
                                    case 1:
                                        evasionclassroll = 1;
                                        break;
                                    case 2:
                                        evasionclassroll = 2;
                                        break;
                                    case 3:
                                        evasionclassroll = 3;
                                        break;
                                    case 4:
                                        evasionclassroll = 4;
                                        break;
                                }
                                float skillmaxdamage = 0;
                                if ((skillid[solverskillid[x]] == "11" || skillid[solverskillid[x]] == "126") && fireattuneactive == true)
                                {
                                    skillmaxdamage = (int)Math.Ceiling((float.Parse(skilllvbaseamount[solverskilllevel[x] + pvpmode]) + float.Parse(skilllvinitialdamage[solverskilllevel[x] + pvpmode]) * (1 + Math.Sqrt((ability + solverskillabilitymod[x]) / 100.0f) + Math.Sqrt((PrimStats[primstat] + PrimStatsMod[primstat]) / primstatmod)))) + solverdirectdamage[x] + fireattuneamount;
                                }
                                else if ((skillid[solverskillid[x]] == "42" || skillid[solverskillid[x]] == "221") && iceattuneactive == true)
                                {
                                    skillmaxdamage = (int)Math.Ceiling((float.Parse(skilllvbaseamount[solverskilllevel[x] + pvpmode]) + float.Parse(skilllvinitialdamage[solverskilllevel[x] + pvpmode]) * (1 + Math.Sqrt((ability + solverskillabilitymod[x]) / 100.0f) + Math.Sqrt((PrimStats[primstat] + PrimStatsMod[primstat]) / primstatmod)))) + solverdirectdamage[x] + iceattuneamount;
                                }
                                else skillmaxdamage = (int)Math.Ceiling((float.Parse(skilllvbaseamount[solverskilllevel[x] + pvpmode]) + float.Parse(skilllvinitialdamage[solverskilllevel[x] + pvpmode]) * (1 + Math.Sqrt((ability + solverskillabilitymod[x]) / 100.0f) + Math.Sqrt((PrimStats[primstat] + PrimStatsMod[primstat]) / primstatmod)))) + solverdirectdamage[x];
                                if (skillauto[solverskillid[x]] == "Yes")
                                {
                                    if (damagemultiplieractive == true)
                                    {
                                        maxdamageholder = ((int)(automulti * solverpierce) + (int)(automulti * solverslash) + (int)(automulti * solvercrush) + autoflatdmg + skillmaxdamage) * damagemultiplieramount;
                                    }
                                    else
                                    {
                                        maxdamageholder = (int)(automulti * solverpierce) + (int)(automulti * solverslash) + (int)(automulti * solvercrush) + autoflatdmg + skillmaxdamage;
                                    }
                                    if (solverpierce > 0 || solvertemppierceplus > 0)
                                    {
                                        solverpiercedamage = solverpiercedamage + (int)(automulti * solverpierce + solvertemppierceplus);
                                        resistdamageholder = resistdamageholder + (((int)(automulti * solverpierce + solvertemppierceplus) * levelfactorholder) - (((int)(automulti * solverpierce + solvertemppierceplus) * levelfactorholder) * (1 - (solvertemppluspierceresist / (solvertemppluspierceresist + 6 + 3 * solverplayerlevel)))) * solverpercentpierceresist);
                                        usepierce = true;
                                        usepierceresist = true;
                                        useweaponability = true;
                                        usestrength = true;
                                        solvermobstatsave[x].Add(solvertemppluspierceresist);
                                        solvermobstatinfo[x].Add(0);
                                        solverplayerstatsave[x].Add((int)(automulti * solverpierce + solvertemppierceplus));
                                        solverplayerstatinfo[x].Add(0);
                                    }
                                    if (solverslash > 0 || solvertempslashplus > 0)
                                    {
                                        solverslashdamage = solverslashdamage + (int)(automulti * solverslash + solvertempslashplus);
                                        resistdamageholder = resistdamageholder + (((int)(automulti * solverslash + solvertempslashplus) * levelfactorholder) - (((int)(automulti * solverslash + solvertempslashplus) * levelfactorholder) * (1 - (solvertempplusslashresist / (solvertempplusslashresist + 6 + 3 * solverplayerlevel)))) * solverpercentslashresist);
                                        useslash = true;
                                        useslashresist = true;
                                        useweaponability = true;
                                        usestrength = true;
                                        solvermobstatsave[x].Add(solvertempplusslashresist);
                                        solvermobstatinfo[x].Add(1);
                                        solverplayerstatsave[x].Add((int)(automulti * solverslash + solvertempslashplus));
                                        solverplayerstatinfo[x].Add(1);
                                    }
                                    if (solvercrush > 0 || solvertempcrushplus > 0)
                                    {
                                        solvercrushdamage = solvercrushdamage + (int)(automulti * solvercrush + solvertempcrushplus);
                                        resistdamageholder = resistdamageholder + (((int)(automulti * solvercrush + solvertempcrushplus) * levelfactorholder) - (((int)(automulti * solvercrush + solvertempcrushplus) * levelfactorholder) * (1 - (solvertemppluscrushresist / (solvertemppluscrushresist + 6 + 3 * solverplayerlevel)))) * solverpercentcrushresist);
                                        usecrush = true;
                                        usecrushresist = true;
                                        useweaponability = true;
                                        usestrength = true;
                                        solvermobstatsave[x].Add(solvertemppluscrushresist);
                                        solvermobstatinfo[x].Add(2);
                                        solverplayerstatsave[x].Add((int)(automulti * solvercrush + solvertempcrushplus));
                                        solverplayerstatinfo[x].Add(2);
                                    }
                                    if (solvertempheat > 0)
                                    {
                                        solverheatdamage = solverheatdamage + solvertempheat;
                                        resistdamageholder = resistdamageholder + ((solvertempheat * levelfactorholder) - ((solvertempheat * levelfactorholder) * (1 - (solvertempplusheatresist / (solvertempplusheatresist + 6 + 3 * solverplayerlevel)))) * solverpercentheatresist);
                                        useheat = true;
                                        useheatresist = true;
                                        solvermobstatsave[x].Add(solvertempplusheatresist);
                                        solvermobstatinfo[x].Add(3);
                                        solverplayerstatsave[x].Add(solvertempheat);
                                        solverplayerstatinfo[x].Add(3);
                                    }
                                    if (solvertempcold > 0)
                                    {
                                        solvercolddamage = solvercolddamage + solvertempcold;
                                        resistdamageholder = resistdamageholder + ((solvertempcold * levelfactorholder) - ((solvertempcold * levelfactorholder) * (1 - (solvertemppluscoldresist / (solvertemppluscoldresist + 6 + 3 * solverplayerlevel)))) * solverpercentcoldresist);
                                        usecold = true;
                                        usecoldresist = true;
                                        solvermobstatsave[x].Add(solvertemppluscoldresist);
                                        solvermobstatinfo[x].Add(4);
                                        solverplayerstatsave[x].Add(solvertempcold);
                                        solverplayerstatinfo[x].Add(4);
                                    }
                                    if (solvertempmagic > 0)
                                    {
                                        solvermagicdamage = solvermagicdamage + solvertempmagic;
                                        resistdamageholder = resistdamageholder + ((solvertempmagic * levelfactorholder) - ((solvertempmagic * levelfactorholder) * (1 - (solvertempplusmagicresist / (solvertempplusmagicresist + 6 + 3 * solverplayerlevel)))) * solverpercentmagicresist);
                                        usemagic = true;
                                        usemagicresist = true;
                                        solvermobstatsave[x].Add(solvertempplusmagicresist);
                                        solvermobstatinfo[x].Add(5);
                                        solverplayerstatsave[x].Add(solvertempmagic);
                                        solverplayerstatinfo[x].Add(5);
                                    }
                                    if (solvertemppoison > 0)
                                    {
                                        solverpoisondamage = solverpoisondamage + solvertemppoison;
                                        resistdamageholder = resistdamageholder + ((solvertemppoison * levelfactorholder) - ((solvertemppoison * levelfactorholder) * (1 - (solvertemppluspoisonresist / (solvertemppluspoisonresist + 6 + 3 * solverplayerlevel)))) * solverpercentpoisonresist);
                                        usepoison = true;
                                        usepoisonresist = true;
                                        solvermobstatsave[x].Add(solvertemppluspoisonresist);
                                        solvermobstatinfo[x].Add(6);
                                        solverplayerstatsave[x].Add(solvertemppoison);
                                        solverplayerstatinfo[x].Add(6);
                                    }
                                    if (solvertempdivine > 0)
                                    {
                                        solverdivinedamage = solverdivinedamage + solvertempdivine;
                                        resistdamageholder = resistdamageholder + ((solvertempdivine * levelfactorholder) - ((solvertempdivine * levelfactorholder) * (1 - (solvertempplusdivineresist / (solvertempplusdivineresist + 6 + 3 * solverplayerlevel)))) * solverpercentdivineresist);
                                        usedivine = true;
                                        usedivineresist = true;
                                        solvermobstatsave[x].Add(solvertempplusdivineresist);
                                        solvermobstatinfo[x].Add(7);
                                        solverplayerstatsave[x].Add(solvertempdivine);
                                        solverplayerstatinfo[x].Add(7);
                                    }
                                    if (solvertempchaos > 0)
                                    {
                                        solverchaosdamage = solverchaosdamage + solvertempchaos;
                                        resistdamageholder = resistdamageholder + ((solvertempchaos * levelfactorholder) - ((solvertempchaos * levelfactorholder) * (1 - (solvertemppluschaosresist / (solvertemppluschaosresist + 6 + 3 * solverplayerlevel)))) * solverpercentchaosresist);
                                        usechaos = true;
                                        usechaosresist = true;
                                        solvermobstatsave[x].Add(solvertemppluschaosresist);
                                        solvermobstatinfo[x].Add(8);
                                        solverplayerstatsave[x].Add(solvertempchaos);
                                        solverplayerstatinfo[x].Add(8);
                                    }
                                    if (solvertemptrue > 0)
                                    {
                                        solvertruedamage = solvertruedamage + solvertemptrue;
                                        resistdamageholder = resistdamageholder + ((solvertemptrue * levelfactorholder) - ((solvertemptrue * levelfactorholder) * (1 - (solvertempplustrueresist / (solvertempplustrueresist + 6 + 3 * solverplayerlevel)))) * solverpercenttrueresist);
                                        usetrue = true;
                                        usetrueresist = true;
                                        solvermobstatsave[x].Add(solvertempplustrueresist);
                                        solvermobstatinfo[x].Add(9);
                                        solverplayerstatsave[x].Add(solvertemptrue);
                                        solverplayerstatinfo[x].Add(9);
                                    }
                                }
                                else
                                {
                                    if (damagemultiplieractive == true)
                                    {
                                        maxdamageholder = skillmaxdamage * damagemultiplieramount;
                                    }
                                    else
                                    {
                                        maxdamageholder = skillmaxdamage;
                                    }
                                }
                                solversinglemaxdamage[x] = (int)maxdamageholder;
                                solvermaxdamage = (int)(solvermaxdamage + maxdamageholder);
                                leveldamageholder = solvermaxdamage * levelfactorholder;
                                solverleveldamage = (int)(solverleveldamage + (solvermaxdamage - leveldamageholder));
                                solversingleleveldamage[x] = (int)(solversinglemaxdamage[x] - (solversinglemaxdamage[x] * levelfactorholder));
                                int damagetype = -1; // saves the damage type of the skill for selected relevance so it only has to be written out once instead of 10 times
                                switch (skilldamagetype[solverskillid[x]])
                                {
                                    case "Pierce":
                                        resistdamageholder = resistdamageholder + ((skillmaxdamage * levelfactorholder) - ((skillmaxdamage * levelfactorholder) * (1 - (solvertemppluspierceresist / (solvertemppluspierceresist + 6 + 3 * solverplayerlevel)))) * solverpercentpierceresist);
                                        if (skillmaxdamage > 0)
                                        {
                                            solverpiercedamage = solverpiercedamage + skillmaxdamage;
                                            usepierce = true;
                                            usepierceresist = true;
                                            damagetype = 0;
                                        }
                                        break;
                                    case "Slash":
                                        resistdamageholder = resistdamageholder + ((skillmaxdamage * levelfactorholder) - ((skillmaxdamage * levelfactorholder) * (1 - (solvertempplusslashresist / (solvertempplusslashresist + 6 + 3 * solverplayerlevel)))) * solverpercentslashresist);
                                        if (skillmaxdamage > 0)
                                        {
                                            solverslashdamage = solverslashdamage + skillmaxdamage;
                                            useslash = true;
                                            useslashresist = true;
                                            damagetype = 1;
                                        }
                                        break;
                                    case "Crush":
                                        resistdamageholder = resistdamageholder + ((skillmaxdamage * levelfactorholder) - ((skillmaxdamage * levelfactorholder) * (1 - (solvertemppluscrushresist / (solvertemppluscrushresist + 6 + 3 * solverplayerlevel)))) * solverpercentcrushresist);
                                        if (skillmaxdamage > 0)
                                        {
                                            solvercrushdamage = solvercrushdamage + skillmaxdamage;
                                            usecrush = true;
                                            usecrushresist = true;
                                            damagetype = 2;
                                        }
                                        break;
                                    case "Heat":
                                        resistdamageholder = resistdamageholder + ((skillmaxdamage * levelfactorholder) - ((skillmaxdamage * levelfactorholder) * (1 - (solvertempplusheatresist / (solvertempplusheatresist + 6 + 3 * solverplayerlevel)))) * solverpercentheatresist);
                                        if (skillmaxdamage > 0)
                                        {
                                            solverheatdamage = solverheatdamage + skillmaxdamage;
                                            useheat = true;
                                            useheatresist = true;
                                            damagetype = 3;
                                        }
                                        break;
                                    case "Cold":
                                        resistdamageholder = resistdamageholder + ((skillmaxdamage * levelfactorholder) - ((skillmaxdamage * levelfactorholder) * (1 - (solvertemppluscoldresist / (solvertemppluscoldresist + 6 + 3 * solverplayerlevel)))) * solverpercentcoldresist);
                                        if (skillmaxdamage > 0)
                                        {
                                            solvercolddamage = solvercolddamage + skillmaxdamage;
                                            usecold = true;
                                            usecoldresist = true;
                                            damagetype = 4;
                                        }
                                        break;
                                    case "Magic":
                                        resistdamageholder = resistdamageholder + ((skillmaxdamage * levelfactorholder) - ((skillmaxdamage * levelfactorholder) * (1 - (solvertempplusmagicresist / (solvertempplusmagicresist + 6 + 3 * solverplayerlevel)))) * solverpercentmagicresist);
                                        if (skillmaxdamage > 0)
                                        {
                                            solvermagicdamage = solvermagicdamage + skillmaxdamage;
                                            usemagic = true;
                                            usemagicresist = true;
                                            damagetype = 5;
                                        }
                                        break;
                                    case "Poison":
                                        resistdamageholder = resistdamageholder + ((skillmaxdamage * levelfactorholder) - ((skillmaxdamage * levelfactorholder) * (1 - (solvertemppluspoisonresist / (solvertemppluspoisonresist + 6 + 3 * solverplayerlevel)))) * solverpercentpoisonresist);
                                        if (skillmaxdamage > 0)
                                        {
                                            solverpoisondamage = solverpoisondamage + skillmaxdamage;
                                            usepoison = true;
                                            usepoisonresist = true;
                                            damagetype = 6;
                                        }
                                        break;
                                    case "Divine":
                                        resistdamageholder = resistdamageholder + ((skillmaxdamage * levelfactorholder) - ((skillmaxdamage * levelfactorholder) * (1 - (solvertempplusdivineresist / (solvertempplusdivineresist + 6 + 3 * solverplayerlevel)))) * solverpercentdivineresist);
                                        if (skillmaxdamage > 0)
                                        {
                                            solverdivinedamage = solverdivinedamage + skillmaxdamage;
                                            usedivine = true;
                                            usedivineresist = true;
                                            damagetype = 7;
                                        }
                                        break;
                                    case "Chaos":
                                        resistdamageholder = resistdamageholder + ((skillmaxdamage * levelfactorholder) - ((skillmaxdamage * levelfactorholder) * (1 - (solvertemppluschaosresist / (solvertemppluschaosresist + 6 + 3 * solverplayerlevel)))) * solverpercentchaosresist);
                                        if (skillmaxdamage > 0)
                                        {
                                            solverchaosdamage = solverchaosdamage + skillmaxdamage;
                                            usechaos = true;
                                            usechaosresist = true;
                                            damagetype = 8;
                                        }
                                        break;
                                    default:
                                        resistdamageholder = resistdamageholder + ((skillmaxdamage * levelfactorholder) - ((skillmaxdamage * levelfactorholder) * (1 - (solvertempplustrueresist / (solvertempplustrueresist + 6 + 3 * solverplayerlevel)))) * solverpercenttrueresist);
                                        if (skillmaxdamage > 0)
                                        {
                                            solvertruedamage = solvertruedamage + skillmaxdamage;
                                            usetrue = true;
                                            usetrueresist = true;
                                            damagetype = 9;
                                        }
                                        break;
                                }
                                int order = 0;
                                bool autoandskill = false; // if an auto and skill share a damage type this will be true, this is needed so it knows if it should add a new instance
                                if (skillauto[solverskillid[x]] == "Yes" && solverplayerstatinfo[x].Count > 0) // to check if other damage types are used previously, and order them properly if so
                                {
                                    for (int i = 9; i >= 0; i--)
                                    {
                                        if (solverplayerstatinfo[x].IndexOf(i) != -1)
                                        {
                                            if (damagetype == i)
                                            {
                                                solverplayerstatsave[x][solverplayerstatinfo[x].IndexOf(i)] = solverplayerstatsave[x][solverplayerstatinfo[x].IndexOf(0)] + skillmaxdamage;
                                                autoandskill = true;
                                            }
                                            else if (damagetype > i)
                                            {
                                                order++;
                                            }
                                        }
                                    }
                                }
                                if (autoandskill == false)
                                {
                                    if (order == 0 || solverplayerstatinfo[x].Count == 0) // no hits from above just adds it normally
                                    {
                                        switch (damagetype)
                                        {
                                            case 0:
                                                solvermobstatsave[x].Add(solvertemppluspierceresist);
                                                solvermobstatinfo[x].Add(0);
                                                solverplayerstatsave[x].Add(skillmaxdamage);
                                                solverplayerstatinfo[x].Add(0);
                                                break;
                                            case 1:
                                                solvermobstatsave[x].Add(solvertempplusslashresist);
                                                solvermobstatinfo[x].Add(1);
                                                solverplayerstatsave[x].Add(skillmaxdamage);
                                                solverplayerstatinfo[x].Add(1);
                                                break;
                                            case 2:
                                                solvermobstatsave[x].Add(solvertemppluscrushresist);
                                                solvermobstatinfo[x].Add(2);
                                                solverplayerstatsave[x].Add(skillmaxdamage);
                                                solverplayerstatinfo[x].Add(2);
                                                break;
                                            case 3:
                                                solvermobstatsave[x].Add(solvertempplusheatresist);
                                                solvermobstatinfo[x].Add(3);
                                                solverplayerstatsave[x].Add(skillmaxdamage);
                                                solverplayerstatinfo[x].Add(3);
                                                break;
                                            case 4:
                                                solvermobstatsave[x].Add(solvertemppluscoldresist);
                                                solvermobstatinfo[x].Add(4);
                                                solverplayerstatsave[x].Add(skillmaxdamage);
                                                solverplayerstatinfo[x].Add(4);
                                                break;
                                            case 5:
                                                solvermobstatsave[x].Add(solvertempplusmagicresist);
                                                solvermobstatinfo[x].Add(5);
                                                solverplayerstatsave[x].Add(skillmaxdamage);
                                                solverplayerstatinfo[x].Add(5);
                                                break;
                                            case 6:
                                                solvermobstatsave[x].Add(solvertemppluspoisonresist);
                                                solvermobstatinfo[x].Add(6);
                                                solverplayerstatsave[x].Add(skillmaxdamage);
                                                solverplayerstatinfo[x].Add(6);
                                                break;
                                            case 7:
                                                solvermobstatsave[x].Add(solvertempplusdivineresist);
                                                solvermobstatinfo[x].Add(7);
                                                solverplayerstatsave[x].Add(skillmaxdamage);
                                                solverplayerstatinfo[x].Add(7);
                                                break;
                                            case 8:
                                                solvermobstatsave[x].Add(solvertemppluschaosresist);
                                                solvermobstatinfo[x].Add(8);
                                                solverplayerstatsave[x].Add(skillmaxdamage);
                                                solverplayerstatinfo[x].Add(8);
                                                break;
                                            case 9:
                                                solvermobstatsave[x].Add(solvertempplustrueresist);
                                                solvermobstatinfo[x].Add(9);
                                                solverplayerstatsave[x].Add(skillmaxdamage);
                                                solverplayerstatinfo[x].Add(9);
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        switch (damagetype)
                                        {
                                            case 0:
                                                solvermobstatsave[x].Insert(solverplayerstatinfo[x].Count - order - 1, solvertemppluspierceresist);
                                                solvermobstatinfo[x].Insert(solverplayerstatinfo[x].Count - order - 1, 0);
                                                solverplayerstatsave[x].Insert(solverplayerstatinfo[x].Count - order - 1, skillmaxdamage);
                                                solverplayerstatinfo[x].Insert(solverplayerstatinfo[x].Count - order - 1, 0);
                                                break;
                                            case 1:
                                                solvermobstatsave[x].Insert(solverplayerstatinfo[x].Count - order - 1, solvertempplusslashresist);
                                                solvermobstatinfo[x].Insert(solverplayerstatinfo[x].Count - order - 1, 1);
                                                solverplayerstatsave[x].Insert(solverplayerstatinfo[x].Count - order - 1, skillmaxdamage);
                                                solverplayerstatinfo[x].Insert(solverplayerstatinfo[x].Count - order - 1, 1);
                                                break;
                                            case 2:
                                                solvermobstatsave[x].Insert(solverplayerstatinfo[x].Count - order - 1, solvertemppluscrushresist);
                                                solvermobstatinfo[x].Insert(solverplayerstatinfo[x].Count - order - 1, 2);
                                                solverplayerstatsave[x].Insert(solverplayerstatinfo[x].Count - order - 1, skillmaxdamage);
                                                solverplayerstatinfo[x].Insert(solverplayerstatinfo[x].Count - order - 1, 2);
                                                break;
                                            case 3:
                                                solvermobstatsave[x].Insert(solverplayerstatinfo[x].Count - order - 1, solvertempplusheatresist);
                                                solvermobstatinfo[x].Insert(solverplayerstatinfo[x].Count - order - 1, 3);
                                                solverplayerstatsave[x].Insert(solverplayerstatinfo[x].Count - order - 1, skillmaxdamage);
                                                solverplayerstatinfo[x].Insert(solverplayerstatinfo[x].Count - order - 1, 3);
                                                break;
                                            case 4:
                                                solvermobstatsave[x].Insert(solverplayerstatinfo[x].Count - order - 1, solvertemppluscoldresist);
                                                solvermobstatinfo[x].Insert(solverplayerstatinfo[x].Count - order - 1, 4);
                                                solverplayerstatsave[x].Insert(solverplayerstatinfo[x].Count - order - 1, skillmaxdamage);
                                                solverplayerstatinfo[x].Insert(solverplayerstatinfo[x].Count - order - 1, 4);
                                                break;
                                            case 5:
                                                solvermobstatsave[x].Insert(solverplayerstatinfo[x].Count - order - 1, solvertempplusmagicresist);
                                                solvermobstatinfo[x].Insert(solverplayerstatinfo[x].Count - order - 1, 5);
                                                solverplayerstatsave[x].Insert(solverplayerstatinfo[x].Count - order - 1, skillmaxdamage);
                                                solverplayerstatinfo[x].Insert(solverplayerstatinfo[x].Count - order - 1, 5);
                                                break;
                                            case 6:
                                                solvermobstatsave[x].Insert(solverplayerstatinfo[x].Count - order - 1, solvertemppluspoisonresist);
                                                solvermobstatinfo[x].Insert(solverplayerstatinfo[x].Count - order - 1, 6);
                                                solverplayerstatsave[x].Insert(solverplayerstatinfo[x].Count - order - 1, skillmaxdamage);
                                                solverplayerstatinfo[x].Insert(solverplayerstatinfo[x].Count - order - 1, 6);
                                                break;
                                            case 7:
                                                solvermobstatsave[x].Insert(solverplayerstatinfo[x].Count - order - 1, solvertempplusdivineresist);
                                                solvermobstatinfo[x].Insert(solverplayerstatinfo[x].Count - order - 1, 7);
                                                solverplayerstatsave[x].Insert(solverplayerstatinfo[x].Count - order - 1, skillmaxdamage);
                                                solverplayerstatinfo[x].Insert(solverplayerstatinfo[x].Count - order - 1, 7);
                                                break;
                                            case 8:
                                                solvermobstatsave[x].Insert(solverplayerstatinfo[x].Count - order - 1, solvertemppluschaosresist);
                                                solvermobstatinfo[x].Insert(solverplayerstatinfo[x].Count - order - 1, 8);
                                                solverplayerstatsave[x].Insert(solverplayerstatinfo[x].Count - order - 1, skillmaxdamage);
                                                solverplayerstatinfo[x].Insert(solverplayerstatinfo[x].Count - order - 1, 8);
                                                break;
                                            case 9: // its the last one so its always last anyway
                                                solvermobstatsave[x].Add(solvertempplustrueresist);
                                                solvermobstatinfo[x].Add(9);
                                                solverplayerstatsave[x].Add(skillmaxdamage);
                                                solverplayerstatinfo[x].Add(9);
                                                break;
                                        }
                                    }
                                }
                                solversingleresistdamage[x] = (int)resistdamageholder;
                                solverresistdamage = (int)(solverresistdamage + resistdamageholder);
                                if ((evasions[evasiontype] > 0 && solverplayerlevel > 0) && evasiontype != 6) // 0 in both would result in a divide by zero
                                {
                                    float evasion = Math.Abs(((evasions[evasiontype] * evasionroll[evasionclassroll]) / (evasions[evasiontype] + 50 * solverplayerlevel)) - 1) * 100;
                                    if (evasion < 70 && solverpvp == true)
                                    {
                                        evasion = 70;
                                        pvpevasioncap = true;
                                    }
                                    solverchancetohittotal.Add(evasion);
                                    solversinglechancetohit[x] = evasion;
                                }
                                else
                                {
                                    solverchancetohittotal.Add(100);
                                    solversinglechancetohit[x] = 100;
                                }
                                solvercritchancetotal.Add(0.12f * ((solvercritskills + 40) / (solvercritskills + 40 + 10 * (solvermoblevel + 3))) * 100);
                                solversinglecritchance[x] = 0.12f * ((solvercritskills + 40) / (solvercritskills + 40 + 10 * (solvermoblevel + 3))) * 100;
                                solveraggrogenerated = (solveraggrogenerated + (maxdamageholder - resistdamageholder - (maxdamageholder - (maxdamageholder * levelfactorholder))) * 1.5f) + float.Parse(skilllvaggromulti[solverskilllevel[x] + pvpmode]);
                                solversingleaggro[x] = ((solversinglemaxdamage[x] - solversingleresistdamage[x] - (solversinglemaxdamage[x] - (solversinglemaxdamage[x] * levelfactorholder))) * 1.5f) + float.Parse(skilllvaggromulti[solverskilllevel[x] + pvpmode]);
                                if (skillstatus[solverskillid[x]] == "0") ActionsUsedListbox.Items.Add(skillname[solverskillid[x]] + "(Level " + (Convert.ToInt32(skilllvlevel[solverskilllevel[x]]) + 1) + ")");
                                else ActionsUsedListbox.Items.Add(skillname[solverskillid[x]] + "(Level " + (Convert.ToInt32(skilllvlevel[solverskilllevel[x]]) + 1) + " Skill)");
                                solverskillhittime[x] = timeholder + solvercasttime[x];
                                timeholder = timeholder + solvercasttime[x] + solverlockout[x];
                                solversingletimeforaction[x] = solvercasttime[x] + solverlockout[x];
                                solversingleactualdamage[x] = solversinglemaxdamage[x] - solversingleresistdamage[x] - solversingleleveldamage[x];
                                if (solvercasttime[x] + solverlockout[x] > 0)
                                {
                                    solversingledps[x] = solversingleactualdamage[x] / (solvercasttime[x] + solverlockout[x]);
                                }
                                else solversingledps[x] = -2;
                                solversinglelock[x] = (solversingleactualdamage[x] / float.Parse(DamageForLock.Text)) * 100;
                                usecritskills = true;
                                if (noability == false) useskillability = true;
                                switch (evasiontype)
                                {
                                    case 0:
                                        solvermobstatsave[x].Add(solvertempphysical);
                                        solvermobstatinfo[x].Add(11);
                                        break;
                                    case 1:
                                        solvermobstatsave[x].Add(solvertempspell);
                                        solvermobstatinfo[x].Add(12);
                                        break;
                                    case 2:
                                        solvermobstatsave[x].Add(solvertempmovement);
                                        solvermobstatinfo[x].Add(13);
                                        break;
                                    case 3:
                                        solvermobstatsave[x].Add(solvertempwounding);
                                        solvermobstatinfo[x].Add(14);
                                        break;
                                    case 4:
                                        solvermobstatsave[x].Add(solvertempweakening);
                                        solvermobstatinfo[x].Add(15);
                                        break;
                                }
                                if (skillid[solverskillid[x]] == "33" || skillid[solverskillid[x]] == "128")
                                {
                                    solvermaxdamage = (int)(solvermaxdamage - maxdamageholder);
                                    solverleveldamage = (int)(solverleveldamage - (solvermaxdamage - leveldamageholder));
                                    solverresistdamage = (int)(solverresistdamage - resistdamageholder);
                                    solversinglemaxdamage[x] = 0;
                                    solversingleleveldamage[x] = 0;
                                    solversingleresistdamage[x] = 0;
                                    solversingleactualdamage[x] = 0;
                                }
                            }
                            else
                            {
                                ActionsUsedListbox.Items.Add(skillname[solverskillid[x]] + "(Unsupported)");
                                timeholder = timeholder + solvercasttime[x] + solverlockout[x];
                            }
                            break;
                        case 2:
                            bool validstatus = true;
                            for (int i = 0; i < x; i++) // testing for status overcasts/overrides
                            {
                                if (solveractiontype[i] == 2)
                                {
                                    if (solverstatusid[i] == solverstatusid[x])
                                    {
                                        if (solverstatusmaxduration[i] + solverskillhittime[i] < timeholder)
                                        {
                                            validstatus = false;
                                        }
                                        else if (solverstatusmaxduration[i] + solverskillhittime[i] >= timeholder)
                                        {
                                            if (solverskilllevel[x] >= solverskilllevel[i])
                                            {
                                                solverstatusduration[i] = 0;
                                                solverstatusticktime[i] = 0;
                                            }
                                            else
                                            {
                                                validstatus = false;
                                                ActionsUsedListbox.Items.Add(statusname[solverstatusid[x]] + "(Status Resisted!)");
                                                solveractiontype.Add(4);
                                                solverskillid.Add(-1);
                                                solverskilllevel.Add(-1);
                                                solverskillhittime.Add(-1);
                                                solverstatusid.Add(-1);
                                                solverstatusmaxduration.Add(-1);
                                                solverstatusduration.Add(-1);
                                                solverstatusticktime.Add(-1);
                                                solverstatusamount.Add(-1);
                                                solverstatusovercharge.Add(-1);
                                                solverstatusoverchargeslash.Add(-1);
                                                solverstatusoverchargecrush.Add(-1);
                                                solverstatusapplied.Add(false);
                                                solverstatusend.Add(false);
                                                solverdirectdamage.Add(0);
                                                solvercooldown.Add(0);
                                                solvercasttime.Add(0);
                                                solverlockout.Add(0);
                                                solverstalltime.Add(0);
                                                solverhaspvpversion.Add(false);
                                                solverattackmod.Add(0);
                                                solverstrengthmod.Add(0);
                                                solverdexteritymod.Add(0);
                                                solverfocusmod.Add(0);
                                                solvervitalitymod.Add(0);
                                                solverweaponabilitymod.Add(0);
                                                solverskillabilitymod.Add(0);
                                                solversinglemaxdamage.Add(-1);
                                                solversingleactualdamage.Add(-1);
                                                solversingleresistdamage.Add(-1);
                                                solversingleleveldamage.Add(-1);
                                                solversingledps.Add(-1);
                                                solversinglechancetohit.Add(-1);
                                                solversinglecritchance.Add(-1);
                                                solversingleaggro.Add(-1);
                                                solversinglelock.Add(-1);
                                                solversingletimeforaction.Add(-1);
                                            }
                                        }
                                    }
                                    else if ((solverstatusid[i] == 19 && solverstatusid[x] == 0) || (solverstatusid[i] == 142 && solverstatusid[x] == 141))
                                    {
                                        validstatus = false;
                                        ActionsUsedListbox.Items.Add(statusname[solverstatusid[x]] + "(Status Resisted!)");
                                        solveractiontype.Add(4);
                                        solverskillid.Add(-1);
                                        solverskilllevel.Add(-1);
                                        solverskillhittime.Add(-1);
                                        solverstatusid.Add(-1);
                                        solverstatusmaxduration.Add(-1);
                                        solverstatusduration.Add(-1);
                                        solverstatusticktime.Add(-1);
                                        solverstatusamount.Add(-1);
                                        solverstatusovercharge.Add(-1);
                                        solverstatusoverchargeslash.Add(-1);
                                        solverstatusoverchargecrush.Add(-1);
                                        solverstatusapplied.Add(false);
                                        solverstatusend.Add(false);
                                        solverdirectdamage.Add(0);
                                        solvercooldown.Add(0);
                                        solvercasttime.Add(0);
                                        solverlockout.Add(0);
                                        solverstalltime.Add(0);
                                        solverhaspvpversion.Add(false);
                                        solverattackmod.Add(0);
                                        solverstrengthmod.Add(0);
                                        solverdexteritymod.Add(0);
                                        solverfocusmod.Add(0);
                                        solvervitalitymod.Add(0);
                                        solverweaponabilitymod.Add(0);
                                        solverskillabilitymod.Add(0);
                                        solversinglemaxdamage.Add(-1);
                                        solversingleactualdamage.Add(-1);
                                        solversingleresistdamage.Add(-1);
                                        solversingleleveldamage.Add(-1);
                                        solversingledps.Add(-1);
                                        solversinglechancetohit.Add(-1);
                                        solversinglecritchance.Add(-1);
                                        solversingleaggro.Add(-1);
                                        solversinglelock.Add(-1);
                                        solversingletimeforaction.Add(-1);
                                    }
                                }
                            }
                            if (validstatus == true)
                            {
                                if (solverstatusapplied[x] == false)
                                {
                                    PrimStatsMod.Clear();
                                    PrimStatsMod.Add(solverstrengthmod[x]);
                                    PrimStatsMod.Add(solverdexteritymod[x]);
                                    PrimStatsMod.Add(solverfocusmod[x]);
                                    PrimStatsMod.Add(solvervitalitymod[x]);
                                    PrimStatsMod.Add(0);

                                    primstatmod = float.Parse(skillprimmod[solverskillid[x]]);

                                    if (skillprimstat[solverskillid[x]] == "Strength")
                                    {
                                        primstat = 0;
                                        usestrength = true;
                                    }
                                    else if (skillprimstat[solverskillid[x]] == "Dexterity")
                                    {
                                        primstat = 1;
                                        usedexterity = true;
                                    }
                                    else if (skillprimstat[solverskillid[x]] == "Focus")
                                    {
                                        primstat = 2;
                                        usefocus = true;
                                    }
                                    else if (skillprimstat[solverskillid[x]] == "Vitality")
                                    {
                                        primstat = 3;
                                        usevitality = true;
                                    }
                                    else primstat = 4;
                                    if (primstat == 4 || float.Parse(skillprimmod[solverskillid[x]]) == 0) primstatmod = 1;
                                    else primstatmod = float.Parse(skillprimmod[solverskillid[x]]);

                                    solverstatusmaxduration[x] = float.Parse(statuslvduration[solverskilllevel[x] + pvpmode]);
                                    solverstatusduration[x] = float.Parse(statuslvduration[solverskilllevel[x] + pvpmode]);
                                    solverstatusticktime[x] = float.Parse(statuslvduration[solverskilllevel[x] + pvpmode]);
                                    switch (statuseffect[solverstatusid[x]])
                                    {
                                        case "0":
                                            int armorvalue = 0;
                                            armorvalue = (int)Math.Ceiling((float.Parse(statuslvbase[solverskilllevel[x] + pvpmode]) + float.Parse(statuslvinitial[solverskilllevel[x] + pvpmode]) * (1 + Math.Sqrt((ability + solverskillabilitymod[x]) / 100.0f) + Math.Sqrt((PrimStats[primstat] + PrimStatsMod[primstat]) / primstatmod))));
                                            if (armorvalue > 0) ActionsUsedListbox.Items.Add(statusname[solverstatusid[x]] + "(Unsupported)");
                                            else
                                            {
                                                if (solvertemppluspierceresist + armorvalue > 0)
                                                {
                                                    solvertemppluspierceresist = solvertemppluspierceresist + armorvalue;
                                                    solverstatusamount[x] = armorvalue;
                                                }
                                                else
                                                {
                                                    solverstatusamount[x] = armorvalue + Math.Abs(solvertemppluspierceresist + armorvalue);
                                                    solverstatusovercharge[x] = -(armorvalue - (armorvalue + Math.Abs(solvertemppluspierceresist + armorvalue)));
                                                    solvertemppluspierceresist = 0;
                                                }
                                                if (solvertempplusslashresist + armorvalue > 0)
                                                {
                                                    solvertempplusslashresist = solvertempplusslashresist + armorvalue;
                                                    solverstatusamount[x] = armorvalue;
                                                }
                                                else
                                                {
                                                    solverstatusamount[x] = armorvalue + Math.Abs(solvertemppluspierceresist + armorvalue);
                                                    solverstatusoverchargeslash[x] = -(armorvalue - (armorvalue + Math.Abs(solvertempplusslashresist + armorvalue)));
                                                    solvertempplusslashresist = 0;
                                                }
                                                if (solvertemppluscrushresist + armorvalue > 0)
                                                {
                                                    solvertemppluscrushresist = solvertemppluscrushresist + armorvalue;
                                                    solverstatusamount[x] = armorvalue;
                                                }
                                                else
                                                {
                                                    solverstatusamount[x] = armorvalue + Math.Abs(solvertemppluspierceresist + armorvalue);
                                                    solverstatusoverchargecrush[x] = -(armorvalue - (armorvalue + Math.Abs(solvertemppluscrushresist + armorvalue)));
                                                    solvertemppluscrushresist = 0;
                                                }
                                                ActionsUsedListbox.Items.Add(statusname[solverstatusid[x]] + "(" + armorvalue + " Armour)");
                                            }
                                            if (solvertemppluspierceresist < solverlowpluspierceresist) solverlowpluspierceresist = solvertemppluspierceresist;
                                            if (solvertempplusslashresist < solverlowplusslashresist) solverlowplusslashresist = solvertempplusslashresist;
                                            if (solvertemppluscrushresist < solverlowpluscrushresist) solverlowpluscrushresist = solvertemppluscrushresist;
                                            break;
                                        case "3":
                                            int damagevalue = 0;
                                            damagevalue = (int)Math.Ceiling((float.Parse(statuslvbase[solverskilllevel[x] + pvpmode]) + float.Parse(statuslvinitial[solverskilllevel[x] + pvpmode]) * (1 + Math.Sqrt((ability + solverskillabilitymod[x]) / 100.0f) + Math.Sqrt((PrimStats[primstat] + PrimStatsMod[primstat]) / primstatmod))));
                                            ActionsUsedListbox.Items.Add(statusname[solverstatusid[x]] + "(" + damagevalue + "x" + (solverstatusmaxduration[x] / Convert.ToInt32(statustick[solverstatusid[x]])) + " DMG/Tick)");
                                            solverstatusamount[x] = damagevalue;

                                            solversinglemaxdamage[x] = solverstatusamount[x] * (int)(solverstatusmaxduration[x] / Convert.ToInt32(statustick[solverstatusid[x]])); // calculates the relevant selected stats
                                            solversingleleveldamage[x] = (int)(solversinglemaxdamage[x] - (solversinglemaxdamage[x] * levelfactorholder));
                                            switch (statusdamage[solverstatusid[x]])
                                            {
                                                case "Pierce":
                                                    solversingleresistdamage[x] = (solversinglemaxdamage[x] * levelfactorholder) - ((solversinglemaxdamage[x] * levelfactorholder) * (1 - (solvertemppluspierceresist / (solvertemppluspierceresist + 6 + 3 * solverplayerlevel)))) * solverpercentpierceresist;
                                                    if (solverstatusamount[x] > 0)
                                                    {
                                                        usepierce = true;
                                                        usepierceresist = true;
                                                        solvermobstatsave[x].Add(solvertemppluspierceresist);
                                                        solvermobstatinfo[x].Add(0);
                                                        solverplayerstatsave[x].Add(solversinglemaxdamage[x]);
                                                        solverplayerstatinfo[x].Add(0);
                                                    }
                                                    break;
                                                case "Slash":
                                                    solversingleresistdamage[x] = (solversinglemaxdamage[x] * levelfactorholder) - ((solversinglemaxdamage[x] * levelfactorholder) * (1 - (solvertempplusslashresist / (solvertempplusslashresist + 6 + 3 * solverplayerlevel)))) * solverpercentslashresist;
                                                    if (solverstatusamount[x] > 0)
                                                    {
                                                        useslash = true;
                                                        useslashresist = true;
                                                        solvermobstatsave[x].Add(solvertempplusslashresist);
                                                        solvermobstatinfo[x].Add(1);
                                                        solverplayerstatsave[x].Add(solversinglemaxdamage[x]);
                                                        solverplayerstatinfo[x].Add(1);
                                                    }
                                                    break;
                                                case "Crush":
                                                    solversingleresistdamage[x] = (solversinglemaxdamage[x] * levelfactorholder) - ((solversinglemaxdamage[x] * levelfactorholder) * (1 - (solvertemppluscrushresist / (solvertemppluscrushresist + 6 + 3 * solverplayerlevel)))) * solverpercentcrushresist;
                                                    if (solverstatusamount[x] > 0)
                                                    {
                                                        usecrush = true;
                                                        usecrushresist = true;
                                                        solvermobstatsave[x].Add(solvertemppluscrushresist);
                                                        solvermobstatinfo[x].Add(2);
                                                        solverplayerstatsave[x].Add(solversinglemaxdamage[x]);
                                                        solverplayerstatinfo[x].Add(2);
                                                    }
                                                    break;
                                                case "Heat":
                                                    solversingleresistdamage[x] = (solversinglemaxdamage[x] * levelfactorholder) - ((solversinglemaxdamage[x] * levelfactorholder) * (1 - (solvertempplusheatresist / (solvertempplusheatresist + 6 + 3 * solverplayerlevel)))) * solverpercentheatresist;
                                                    if (solverstatusamount[x] > 0)
                                                    {
                                                        useheat = true;
                                                        useheatresist = true;
                                                        solvermobstatsave[x].Add(solvertempplusheatresist);
                                                        solvermobstatinfo[x].Add(3);
                                                        solverplayerstatsave[x].Add(solversinglemaxdamage[x]);
                                                        solverplayerstatinfo[x].Add(3);
                                                    }
                                                    break;
                                                case "Cold":
                                                    solversingleresistdamage[x] = (solversinglemaxdamage[x] * levelfactorholder) - ((solversinglemaxdamage[x] * levelfactorholder) * (1 - (solvertemppluscoldresist / (solvertemppluscoldresist + 6 + 3 * solverplayerlevel)))) * solverpercentcoldresist;
                                                    if (solverstatusamount[x] > 0)
                                                    {
                                                        usecold = true;
                                                        usecoldresist = true;
                                                        solvermobstatsave[x].Add(solvertemppluscoldresist);
                                                        solvermobstatinfo[x].Add(4);
                                                        solverplayerstatsave[x].Add(solversinglemaxdamage[x]);
                                                        solverplayerstatinfo[x].Add(4);
                                                    }
                                                    break;
                                                case "Magic":
                                                    solversingleresistdamage[x] = (solversinglemaxdamage[x] * levelfactorholder) - ((solversinglemaxdamage[x] * levelfactorholder) * (1 - (solvertempplusmagicresist / (solvertempplusmagicresist + 6 + 3 * solverplayerlevel)))) * solverpercentmagicresist;
                                                    if (solverstatusamount[x] > 0)
                                                    {
                                                        usemagic = true;
                                                        usemagicresist = true;
                                                        solvermobstatsave[x].Add(solvertempplusmagicresist);
                                                        solvermobstatinfo[x].Add(5);
                                                        solverplayerstatsave[x].Add(solversinglemaxdamage[x]);
                                                        solverplayerstatinfo[x].Add(5);
                                                    }
                                                    break;
                                                case "Poison":
                                                    solversingleresistdamage[x] = (solversinglemaxdamage[x] * levelfactorholder) - ((solversinglemaxdamage[x] * levelfactorholder) * (1 - (solvertemppluspoisonresist / (solvertemppluspoisonresist + 6 + 3 * solverplayerlevel)))) * solverpercentpoisonresist;
                                                    if (solverstatusamount[x] > 0)
                                                    {
                                                        usepoison = true;
                                                        usepoisonresist = true;
                                                        solvermobstatsave[x].Add(solvertemppluspoisonresist);
                                                        solvermobstatinfo[x].Add(6);
                                                        solverplayerstatsave[x].Add(solversinglemaxdamage[x]);
                                                        solverplayerstatinfo[x].Add(6);
                                                    }
                                                    break;
                                                case "Divine":
                                                    solversingleresistdamage[x] = (solversinglemaxdamage[x] * levelfactorholder) - ((solversinglemaxdamage[x] * levelfactorholder) * (1 - (solvertempplusdivineresist / (solvertempplusdivineresist + 6 + 3 * solverplayerlevel)))) * solverpercentdivineresist;
                                                    if (solverstatusamount[x] > 0)
                                                    {
                                                        usedivine = true;
                                                        usedivineresist = true;
                                                        solvermobstatsave[x].Add(solvertempplusdivineresist);
                                                        solvermobstatinfo[x].Add(7);
                                                        solverplayerstatsave[x].Add(solversinglemaxdamage[x]);
                                                        solverplayerstatinfo[x].Add(7);
                                                    }
                                                    break;
                                                case "Chaos":
                                                    solversingleresistdamage[x] = (solversinglemaxdamage[x] * levelfactorholder) - ((solversinglemaxdamage[x] * levelfactorholder) * (1 - (solvertemppluschaosresist / (solvertemppluschaosresist + 6 + 3 * solverplayerlevel)))) * solverpercentchaosresist;
                                                    if (solverstatusamount[x] > 0)
                                                    {
                                                        usechaos = true;
                                                        usechaosresist = true;
                                                        solvermobstatsave[x].Add(solvertemppluschaosresist);
                                                        solvermobstatinfo[x].Add(8);
                                                        solverplayerstatsave[x].Add(solversinglemaxdamage[x]);
                                                        solverplayerstatinfo[x].Add(8);
                                                    }
                                                    break;
                                                default: // true damage
                                                    solversingleresistdamage[x] = (solversinglemaxdamage[x] * levelfactorholder) - ((solversinglemaxdamage[x] * levelfactorholder) * (1 - (solvertempplustrueresist / (solvertempplustrueresist + 6 + 3 * solverplayerlevel)))) * solverpercenttrueresist;
                                                    if (solverstatusamount[x] > 0)
                                                    {
                                                        usetrue = true;
                                                        usetrueresist = true;
                                                        solvermobstatsave[x].Add(solvertempplustrueresist);
                                                        solvermobstatinfo[x].Add(9);
                                                        solverplayerstatsave[x].Add(solversinglemaxdamage[x]);
                                                        solverplayerstatinfo[x].Add(9);
                                                    }
                                                    break;
                                            }
                                            solversingleaggro[x] = (solversinglemaxdamage[x] - solversingleresistdamage[x] - (solversinglemaxdamage[x] - (solversinglemaxdamage[x] * levelfactorholder)) * 1.5f) + float.Parse(skilllvaggromulti[solverskilllevel[x]]);
                                            solversinglecritchance[x] = 0.12f * ((solvercritskills + 40) / (solvercritskills + 40 + 10 * (solvermoblevel + 3))) * 100;
                                            solversingleactualdamage[x] = solversinglemaxdamage[x] - solversingleresistdamage[x] - solversingleleveldamage[x];
                                            if (solverstatusmaxduration[x] > 0)
                                            {
                                                solversingledps[x] = solversingleactualdamage[x] / solverstatusmaxduration[x];
                                            }
                                            else solversingledps[x] = 0;
                                            solversinglechancetohit[x] = 100;
                                            solversinglelock[x] = (solversingleactualdamage[x] / float.Parse(DamageForLock.Text)) * 100;
                                            break;
                                        case "4":
                                            int attackvalue = 0;
                                            attackvalue = (int)Math.Ceiling((float.Parse(statuslvbase[solverskilllevel[x] + pvpmode]) + float.Parse(statuslvinitial[solverskilllevel[x] + pvpmode]) * (1 + Math.Sqrt((ability + solverskillabilitymod[x]) / 100.0f) + Math.Sqrt((PrimStats[primstat] + PrimStatsMod[primstat]) / primstatmod))));
                                            if (attackvalue < 0) ActionsUsedListbox.Items.Add(statusname[solverstatusid[x]] + "(Unsupported)");
                                            else
                                            {
                                                solvertempattack = solvertempattack + attackvalue;
                                                solverstatusamount[x] = attackvalue;
                                                ActionsUsedListbox.Items.Add(statusname[solverstatusid[x]] + "(+" + attackvalue + " Attack)");
                                            }
                                            if (solvertempattack > solverhighattack) solverhighattack = solvertempattack;
                                            break;
                                        case "7":
                                            float boostvalue = 0;
                                            boostvalue = (int)Math.Ceiling((float.Parse(statuslvbase[solverskilllevel[x] + pvpmode]) + float.Parse(statuslvinitial[solverskilllevel[x] + pvpmode]) * (1 + Math.Sqrt((ability + solverskillabilitymod[x]) / 100.0f) + Math.Sqrt((PrimStats[primstat] + PrimStatsMod[primstat]) / primstatmod))));
                                            solvertempattack = solvertempattack + boostvalue;
                                            automulti = automulti + (boostvalue / 500);
                                            ActionsUsedListbox.Items.Add(statusname[solverstatusid[x]] + "(+" + boostvalue + " ATK +" + (int)((boostvalue / 500) * (solverpierce + solverslash + solvercrush)) + " DMG)");
                                            solverstatusamount[x] = boostvalue;
                                            if (solvertempattack > solverhighattack) solverhighattack = solvertempattack;
                                            break;
                                        case "12":
                                            int resistvalue = 0;
                                            resistvalue = (int)Math.Ceiling((float.Parse(statuslvbase[solverskilllevel[x] + pvpmode]) + float.Parse(statuslvinitial[solverskilllevel[x] + pvpmode]) * (1 + Math.Sqrt((ability + solverskillabilitymod[x]) / 100.0f) + Math.Sqrt((PrimStats[primstat] + PrimStatsMod[primstat]) / primstatmod))));
                                            if (resistvalue > 0) ActionsUsedListbox.Items.Add(statusname[solverstatusid[x]] + "(Unsupported)");
                                            else switch (statusdamage[solverstatusid[x]])
                                                {
                                                    case "Pierce":
                                                        if (solvertemppluspierceresist + resistvalue > 0)
                                                        {
                                                            solvertemppluspierceresist = solvertemppluspierceresist + resistvalue;
                                                            solverstatusamount[x] = resistvalue;
                                                        }
                                                        else
                                                        {
                                                            solverstatusamount[x] = resistvalue + Math.Abs(solvertemppluspierceresist + resistvalue);
                                                            solverstatusovercharge[x] = -(resistvalue - (resistvalue + Math.Abs(solvertemppluspierceresist + resistvalue)));
                                                            solvertemppluspierceresist = 0;
                                                        }
                                                        ActionsUsedListbox.Items.Add(statusname[solverstatusid[x]] + "(" + resistvalue + " " + statusdamage[solverstatusid[x]] + " Resist)");
                                                        if (solvertemppluspierceresist < solverlowpluspierceresist) solverlowpluspierceresist = solvertemppluspierceresist;
                                                        break;
                                                    case "Slash":
                                                        if (solvertempplusslashresist + resistvalue > 0)
                                                        {
                                                            solvertempplusslashresist = solvertempplusslashresist + resistvalue;
                                                            solverstatusamount[x] = resistvalue;
                                                        }
                                                        else
                                                        {
                                                            solverstatusamount[x] = resistvalue + Math.Abs(solvertempplusslashresist + resistvalue);
                                                            solverstatusovercharge[x] = -(resistvalue - (resistvalue + Math.Abs(solvertempplusslashresist + resistvalue)));
                                                            solvertempplusslashresist = 0;
                                                        }
                                                        ActionsUsedListbox.Items.Add(statusname[solverstatusid[x]] + "(" + resistvalue + " " + statusdamage[solverstatusid[x]] + " Resist)");
                                                        if (solvertempplusslashresist < solverlowplusslashresist) solverlowplusslashresist = solvertempplusslashresist;
                                                        break;
                                                    case "Crush":
                                                        if (solvertemppluscrushresist + resistvalue > 0)
                                                        {
                                                            solvertemppluscrushresist = solvertemppluscrushresist + resistvalue;
                                                            solverstatusamount[x] = resistvalue;
                                                        }
                                                        else
                                                        {
                                                            solverstatusamount[x] = resistvalue + Math.Abs(solvertemppluscrushresist + resistvalue);
                                                            solverstatusovercharge[x] = -(resistvalue - (resistvalue + Math.Abs(solvertemppluscrushresist + resistvalue)));
                                                            solvertemppluscrushresist = 0;
                                                        }
                                                        ActionsUsedListbox.Items.Add(statusname[solverstatusid[x]] + "(" + resistvalue + " " + statusdamage[solverstatusid[x]] + " Resist)");
                                                        if (solvertemppluscrushresist < solverlowpluscrushresist) solverlowpluscrushresist = solvertemppluscrushresist;
                                                        break;
                                                    case "Poison":
                                                        if (solvertemppluspoisonresist + resistvalue > 0)
                                                        {
                                                            solvertemppluspoisonresist = solvertemppluspoisonresist + resistvalue;
                                                            solverstatusamount[x] = resistvalue;
                                                        }
                                                        else
                                                        {
                                                            solverstatusamount[x] = resistvalue + Math.Abs(solvertemppluspoisonresist + resistvalue);
                                                            solverstatusovercharge[x] = -(resistvalue - (resistvalue + Math.Abs(solvertemppluspoisonresist + resistvalue)));
                                                            solvertemppluspoisonresist = 0;
                                                        }
                                                        ActionsUsedListbox.Items.Add(statusname[solverstatusid[x]] + "(" + resistvalue + " " + statusdamage[solverstatusid[x]] + " Resist)");
                                                        if (solvertemppluspoisonresist < solverlowpluspoisonresist) solverlowpluspoisonresist = solvertemppluspoisonresist;
                                                        break;
                                                    case "Heat":
                                                        if (solvertempplusheatresist + resistvalue > 0)
                                                        {
                                                            solvertempplusheatresist = solvertempplusheatresist + resistvalue;
                                                            solverstatusamount[x] = resistvalue;
                                                        }
                                                        else
                                                        {
                                                            solverstatusamount[x] = resistvalue + Math.Abs(solvertempplusheatresist + resistvalue);
                                                            solverstatusovercharge[x] = -(resistvalue - (resistvalue + Math.Abs(solvertempplusheatresist + resistvalue)));
                                                            solvertempplusheatresist = 0;
                                                        }
                                                        ActionsUsedListbox.Items.Add(statusname[solverstatusid[x]] + "(" + resistvalue + " " + statusdamage[solverstatusid[x]] + " Resist)");
                                                        if (solvertempplusheatresist < solverlowplusheatresist) solverlowplusheatresist = solvertempplusheatresist;
                                                        break;
                                                    case "Cold":
                                                        if (solvertemppluscoldresist + resistvalue > 0)
                                                        {
                                                            solvertemppluscoldresist = solvertemppluscoldresist + resistvalue;
                                                            solverstatusamount[x] = resistvalue;
                                                        }
                                                        else
                                                        {
                                                            solverstatusamount[x] = resistvalue + Math.Abs(solvertemppluscoldresist + resistvalue);
                                                            solverstatusovercharge[x] = -(resistvalue - (resistvalue + Math.Abs(solvertemppluscoldresist + resistvalue)));
                                                            solvertemppluscoldresist = 0;
                                                        }
                                                        ActionsUsedListbox.Items.Add(statusname[solverstatusid[x]] + "(" + resistvalue + " " + statusdamage[solverstatusid[x]] + " Resist)");
                                                        if (solvertemppluscoldresist < solverlowpluscoldresist) solverlowpluscoldresist = solvertemppluscoldresist;
                                                        break;
                                                    case "Magic":
                                                        if (solvertempplusmagicresist + resistvalue > 0)
                                                        {
                                                            solvertempplusmagicresist = solvertempplusmagicresist + resistvalue;
                                                            solverstatusamount[x] = resistvalue;
                                                        }
                                                        else
                                                        {
                                                            solverstatusamount[x] = resistvalue + Math.Abs(solvertempplusmagicresist + resistvalue);
                                                            solverstatusovercharge[x] = -(resistvalue - (resistvalue + Math.Abs(solvertempplusmagicresist + resistvalue)));
                                                            solvertempplusmagicresist = 0;
                                                        }
                                                        ActionsUsedListbox.Items.Add(statusname[solverstatusid[x]] + "(" + resistvalue + " " + statusdamage[solverstatusid[x]] + " Resist)");
                                                        if (solvertempplusmagicresist < solverlowplusmagicresist) solverlowplusmagicresist = solvertempplusmagicresist;
                                                        break;
                                                    case "Divine":
                                                        if (solvertempplusdivineresist + resistvalue > 0)
                                                        {
                                                            solvertempplusdivineresist = solvertempplusdivineresist + resistvalue;
                                                            solverstatusamount[x] = resistvalue;
                                                        }
                                                        else
                                                        {
                                                            solverstatusamount[x] = resistvalue + Math.Abs(solvertempplusdivineresist + resistvalue);
                                                            solverstatusovercharge[x] = -(resistvalue - (resistvalue + Math.Abs(solvertempplusdivineresist + resistvalue)));
                                                            solvertempplusdivineresist = 0;
                                                        }
                                                        ActionsUsedListbox.Items.Add(statusname[solverstatusid[x]] + "(" + resistvalue + " " + statusdamage[solverstatusid[x]] + " Resist)");
                                                        if (solvertempplusdivineresist < solverlowplusdivineresist) solverlowplusdivineresist = solvertempplusdivineresist;
                                                        break;
                                                    case "Chaos":
                                                        if (solvertemppluschaosresist + resistvalue > 0)
                                                        {
                                                            solvertemppluschaosresist = solvertemppluschaosresist + resistvalue;
                                                            solverstatusamount[x] = resistvalue;
                                                        }
                                                        else
                                                        {
                                                            solverstatusamount[x] = resistvalue + Math.Abs(solvertemppluschaosresist + resistvalue);
                                                            solverstatusovercharge[x] = -(resistvalue - (resistvalue + Math.Abs(solvertemppluschaosresist + resistvalue)));
                                                            solvertemppluschaosresist = 0;
                                                        }
                                                        ActionsUsedListbox.Items.Add(statusname[solverstatusid[x]] + "(" + resistvalue + " " + statusdamage[solverstatusid[x]] + " Resist)");
                                                        if (solvertemppluschaosresist < solverlowpluschaosresist) solverlowpluschaosresist = solvertemppluschaosresist;
                                                        break;
                                                    default: // true damage
                                                        if (solvertempplustrueresist + resistvalue > 0)
                                                        {
                                                            solvertempplustrueresist = solvertempplustrueresist + resistvalue;
                                                            solverstatusamount[x] = resistvalue;
                                                        }
                                                        else
                                                        {
                                                            solverstatusamount[x] = resistvalue + Math.Abs(solvertempplustrueresist + resistvalue);
                                                            solverstatusovercharge[x] = -(resistvalue - (resistvalue + Math.Abs(solvertempplustrueresist + resistvalue)));
                                                            solvertempplustrueresist = 0;
                                                        }
                                                        ActionsUsedListbox.Items.Add(statusname[solverstatusid[x]] + "(" + resistvalue + " " + statusdamage[solverstatusid[x]] + " Resist)");
                                                        if (solvertempplustrueresist < solverlowplustrueresist) solverlowplustrueresist = solvertempplustrueresist;
                                                        break;
                                                }
                                            break;
                                        case "14":
                                            float boostvalue2 = 0;
                                            boostvalue2 = (int)Math.Ceiling((float.Parse(statuslvbase[solverskilllevel[x] + pvpmode]) + float.Parse(statuslvinitial[solverskilllevel[x] + pvpmode]) * (1 + Math.Sqrt((ability + solverskillabilitymod[x]) / 100.0f) + Math.Sqrt((PrimStats[primstat] + PrimStatsMod[primstat]) / primstatmod))));
                                            solvertempattack = solvertempattack + boostvalue2;
                                            automulti = automulti + (boostvalue2 / 500);
                                            ActionsUsedListbox.Items.Add(statusname[solverstatusid[x]] + "(" + boostvalue2 + " ATK + " + (int)((boostvalue2 / 1000) * (solverpierce + solverslash + solvercrush)) + " DMG)");
                                            solverstatusamount[x] = boostvalue2;
                                            if (solvertempattack > solverhighattack) solverhighattack = solvertempattack;
                                            break;
                                        case "15":
                                            int defencevalue = 0;
                                            defencevalue = (int)Math.Ceiling((float.Parse(statuslvbase[solverskilllevel[x] + pvpmode]) + float.Parse(statuslvinitial[solverskilllevel[x] + pvpmode]) * (1 + Math.Sqrt((ability + solverskillabilitymod[x]) / 100.0f) + Math.Sqrt((PrimStats[primstat] + PrimStatsMod[primstat]) / primstatmod))));
                                            if (defencevalue > 0) ActionsUsedListbox.Items.Add(statusname[solverstatusid[x]] + "(Unsupported)");
                                            else
                                            {
                                                if (solvertempdefence + defencevalue > 0)
                                                {
                                                    solvertempdefence = solvertempdefence + defencevalue;
                                                    solverstatusamount[x] = defencevalue;
                                                }
                                                else
                                                {
                                                    solverstatusamount[x] = defencevalue + Math.Abs(solvertempdefence + defencevalue);
                                                    solverstatusovercharge[x] = -(defencevalue - (defencevalue + Math.Abs(solvertempdefence + defencevalue)));
                                                    solvertempdefence = 0;
                                                }
                                                ActionsUsedListbox.Items.Add(statusname[solverstatusid[x]] + "(" + defencevalue + " Defence)");
                                            }
                                            if (solvertempdefence < solverlowdefence) solverlowdefence = solvertempdefence;
                                            break;
                                        case "16":
                                            int damagebonusvalue = 0;
                                            damagebonusvalue = (int)Math.Ceiling((float.Parse(statuslvbase[solverskilllevel[x] + pvpmode]) + float.Parse(statuslvinitial[solverskilllevel[x] + pvpmode]) * (1 + Math.Sqrt((ability + solverskillabilitymod[x]) / 100.0f) + Math.Sqrt((PrimStats[primstat] + PrimStatsMod[primstat]) / primstatmod))));
                                            if (damagebonusvalue < 0) ActionsUsedListbox.Items.Add(statusname[solverstatusid[x]] + "(Unsupported)");
                                            else switch (statusdamage[solverstatusid[x]])
                                                {
                                                    case "Pierce":
                                                        solvertemppierceplus = solvertemppierceplus + damagebonusvalue;
                                                        solverstatusamount[x] = damagebonusvalue;
                                                        break;
                                                    case "Slash":
                                                        solvertempslashplus = solvertempslashplus + damagebonusvalue;
                                                        solverstatusamount[x] = damagebonusvalue;
                                                        break;
                                                    case "Crush":
                                                        solvertempcrushplus = solvertempcrushplus + damagebonusvalue;
                                                        solverstatusamount[x] = damagebonusvalue;
                                                        break;
                                                    case "Poison":
                                                        solvertemppoison = solvertemppoison + damagebonusvalue;
                                                        solverstatusamount[x] = damagebonusvalue;
                                                        break;
                                                    case "Heat":
                                                        solvertempheat = solvertempheat + damagebonusvalue;
                                                        solverstatusamount[x] = damagebonusvalue;
                                                        break;
                                                    case "Cold":
                                                        solvertempcold = solvertempcold + damagebonusvalue;
                                                        solverstatusamount[x] = damagebonusvalue;
                                                        break;
                                                    case "Magic":
                                                        solvertempmagic = solvertempmagic + damagebonusvalue;
                                                        solverstatusamount[x] = damagebonusvalue;
                                                        break;
                                                    case "Divine":
                                                        solvertempdivine = solvertempdivine + damagebonusvalue;
                                                        solverstatusamount[x] = damagebonusvalue;
                                                        break;
                                                    case "Chaos":
                                                        solvertempchaos = solvertempchaos + damagebonusvalue;
                                                        solverstatusamount[x] = damagebonusvalue;
                                                        break;
                                                    default:
                                                        solvertemptrue = solvertemptrue + damagebonusvalue;
                                                        solverstatusamount[x] = damagebonusvalue;
                                                        break;
                                                }
                                            ActionsUsedListbox.Items.Add(statusname[solverstatusid[x]] + "(+" + damagebonusvalue + " " + statusdamage[solverstatusid[x]] + " Damage)");
                                            break;
                                        case "41":
                                            int attacklixvalue = 0;
                                            attacklixvalue = (int)Math.Ceiling(((float.Parse(statuslvbase[solverskilllevel[x] + pvpmode]) * solverattack) + float.Parse(statuslvinitial[solverskilllevel[x] + pvpmode])));
                                            if (attacklixvalue < 0) ActionsUsedListbox.Items.Add(statusname[solverstatusid[x]] + "(Unsupported)");
                                            else
                                            {
                                                solvertempattack = solvertempattack + attacklixvalue;
                                                solverstatusamount[x] = attacklixvalue;
                                                ActionsUsedListbox.Items.Add(statusname[solverstatusid[x]] + "(+" + attacklixvalue + " Attack)");
                                            }
                                            if (solvertempattack > solverhighattack) solverhighattack = solvertempattack;
                                            break;
                                        case "44":
                                            int evasionvalue = 0;
                                            evasionvalue = (int)Math.Ceiling((float.Parse(statuslvbase[solverskilllevel[x] + pvpmode]) + float.Parse(statuslvinitial[solverskilllevel[x] + pvpmode]) * (1 + Math.Sqrt((ability + solverskillabilitymod[x]) / 100.0f) + Math.Sqrt((PrimStats[primstat] + PrimStatsMod[primstat]) / primstatmod))));
                                            if (evasionvalue > 0) ActionsUsedListbox.Items.Add(statusname[solverstatusid[x]] + "(Unsupported)");
                                            else
                                            {
                                                if (solvertempphysical + evasionvalue > 0)
                                                {
                                                    solvertempphysical = solvertempphysical + evasionvalue;
                                                    solverstatusamount[x] = evasionvalue;
                                                }
                                                else
                                                {
                                                    solverstatusamount[x] = evasionvalue + Math.Abs(solvertempphysical + evasionvalue);
                                                    solverstatusovercharge[x] = -(evasionvalue - (evasionvalue + Math.Abs(solvertempphysical + evasionvalue)));
                                                    solvertempphysical = 0;
                                                }
                                                if (solvertempspell + evasionvalue > 0)
                                                {
                                                    solvertempspell = solvertempspell + evasionvalue;
                                                    solverstatusamount[x] = evasionvalue;
                                                }
                                                else
                                                {
                                                    solverstatusamount[x] = evasionvalue + Math.Abs(solvertempspell + evasionvalue);
                                                    solverstatusovercharge[x] = -(evasionvalue - (evasionvalue + Math.Abs(solvertempspell + evasionvalue)));
                                                    solvertempspell = 0;
                                                }
                                                if (solvertempmovement + evasionvalue > 0)
                                                {
                                                    solvertempmovement = solvertempmovement + evasionvalue;
                                                    solverstatusamount[x] = evasionvalue;
                                                }
                                                else
                                                {
                                                    solverstatusamount[x] = evasionvalue + Math.Abs(solvertempmovement + evasionvalue);
                                                    solverstatusovercharge[x] = -(evasionvalue - (evasionvalue + Math.Abs(solvertempmovement + evasionvalue)));
                                                    solvertempmovement = 0;
                                                }
                                                if (solvertempwounding + evasionvalue > 0)
                                                {
                                                    solvertempwounding = solvertempwounding + evasionvalue;
                                                    solverstatusamount[x] = evasionvalue;
                                                }
                                                else
                                                {
                                                    solverstatusamount[x] = evasionvalue + Math.Abs(solvertempwounding + evasionvalue);
                                                    solverstatusovercharge[x] = -(evasionvalue - (evasionvalue + Math.Abs(solvertempwounding + evasionvalue)));
                                                    solvertempwounding = 0;
                                                }
                                                if (solvertempweakening + evasionvalue > 0)
                                                {
                                                    solvertempweakening = solvertempweakening + evasionvalue;
                                                    solverstatusamount[x] = evasionvalue;
                                                }
                                                else
                                                {
                                                    solverstatusamount[x] = evasionvalue + Math.Abs(solvertempweakening + evasionvalue);
                                                    solverstatusovercharge[x] = -(evasionvalue - (evasionvalue + Math.Abs(solvertempweakening + evasionvalue)));
                                                    solvertempweakening = 0;
                                                }
                                                ActionsUsedListbox.Items.Add(statusname[solverstatusid[x]] + "(" + evasionvalue + " Evasion)");
                                            }
                                            if (solvertempphysical < solverlowphysical) solverlowphysical = solvertempphysical;
                                            if (solvertempspell < solverlowspell) solverlowspell = solvertempspell;
                                            if (solvertempmovement < solverlowmovement) solverlowmovement = solvertempmovement;
                                            if (solvertempwounding < solverlowwounding) solverlowwounding = solvertempwounding;
                                            if (solvertempweakening < solverlowweakening) solverlowweakening = solvertempweakening;
                                            break;
                                        case "45":
                                            iceattuneamount = (int)Math.Ceiling((float.Parse(statuslvbase[solverskilllevel[x] + pvpmode]) + float.Parse(statuslvinitial[solverskilllevel[x] + pvpmode]) * (1 + Math.Sqrt((ability + solverskillabilitymod[x]) / 100.0f) + Math.Sqrt((PrimStats[primstat] + PrimStatsMod[primstat]) / primstatmod))));
                                            iceattuneactive = true;
                                            ActionsUsedListbox.Items.Add(statusname[solverstatusid[x]] + "(+" + iceattuneamount + " Shard/Blast)");
                                            break;
                                        case "46":
                                            fireattuneamount = (int)Math.Ceiling((float.Parse(statuslvbase[solverskilllevel[x] + pvpmode]) + float.Parse(statuslvinitial[solverskilllevel[x] + pvpmode]) * (1 + Math.Sqrt((ability + solverskillabilitymod[x]) / 100.0f) + Math.Sqrt((PrimStats[primstat] + PrimStatsMod[primstat]) / primstatmod))));
                                            fireattuneactive = true;
                                            ActionsUsedListbox.Items.Add(statusname[solverstatusid[x]] + "(+" + fireattuneamount + " Bolt/Storm)");
                                            break;
                                        case "47":
                                            damagemultiplieramount = (int)Math.Ceiling((float.Parse(statuslvbase[solverskilllevel[x] + pvpmode]) + float.Parse(statuslvinitial[solverskilllevel[x] + pvpmode]) * (1 + Math.Sqrt((ability + solverskillabilitymod[x]) / 100.0f) + Math.Sqrt((PrimStats[primstat] + PrimStatsMod[primstat]) / primstatmod))));
                                            damagemultiplieractive = true;
                                            ActionsUsedListbox.Items.Add(statusname[solverstatusid[x]] + "(" + damagemultiplieramount + "x Damage)");
                                            break;
                                        default:
                                            ActionsUsedListbox.Items.Add(statusname[solverstatusid[x]] + "(Unsupported)");
                                            break;
                                    }
                                    solversingletimeforaction[x] = solverstatusmaxduration[x];
                                    solverskillhittime[x] = solverskillhittime[x - 1];
                                    solverstatusapplied[x] = true;
                                }
                            }
                            break;
                        case 3:
                            solversingletimeforaction[x] = solvercasttime[x];
                            timeholder = timeholder + solvercasttime[x];
                            ActionsUsedListbox.Items.Add("Empty Space(" + solvercasttime[x] + "s)");
                            break;
                    }
                    for (int i = 0; i < solverstatusduration.Count; i++)
                    {
                        if (solveractiontype[i] == 2 && solverstatusapplied[i] == true)
                        {
                            solverstatusduration[i] = solverstatusmaxduration[i] + solverskillhittime[i] - timeholder;
                            if (solverstatusend[i] == false)
                            {
                                if (solverstatusduration[i] <= 0)
                                {
                                    if (solverstatusamount[i] <= 0)
                                    {
                                        switch (statuseffect[solverstatusid[i]])
                                        {
                                            case "0":
                                                solvertemppluspierceresist = solvertemppluspierceresist - solverstatusamount[i];
                                                solvertempplusslashresist = solvertempplusslashresist - solverstatusamount[i];
                                                solvertemppluscrushresist = solvertemppluscrushresist - solverstatusamount[i];
                                                break;
                                            case "3":
                                                maxdamageholder = solverstatusamount[i];
                                                solvermaxdamage = (int)(solvermaxdamage + maxdamageholder);
                                                leveldamageholder = solvermaxdamage * levelfactorholder;
                                                solverleveldamage = (int)(solverleveldamage + (solvermaxdamage - leveldamageholder));
                                                switch (statusdamage[solverstatusid[i]])
                                                {
                                                    case "Pierce":
                                                        solverpiercedamage = solverpiercedamage + maxdamageholder;
                                                        resistdamageholder = (maxdamageholder * levelfactorholder) - ((maxdamageholder * levelfactorholder) * (1 - (solvertemppluspierceresist / (solvertemppluspierceresist + 6 + 3 * solverplayerlevel)))) * solverpercentpierceresist;
                                                        if (solverstatusamount[i] > 0)
                                                        {
                                                            usepierce = true;
                                                            usepierceresist = true;
                                                            solvermobstatsave[i].Add(solvertemppluspierceresist);
                                                            solvermobstatinfo[i].Add(0);
                                                            solverplayerstatsave[i].Add(maxdamageholder);
                                                            solverplayerstatinfo[i].Add(0);
                                                        }
                                                        break;
                                                    case "Slash":
                                                        solverslashdamage = solverslashdamage + maxdamageholder;
                                                        resistdamageholder = (maxdamageholder * levelfactorholder) - ((maxdamageholder * levelfactorholder) * (1 - (solvertempplusslashresist / (solvertempplusslashresist + 6 + 3 * solverplayerlevel)))) * solverpercentslashresist;
                                                        if (solverstatusamount[i] > 0)
                                                        {
                                                            useslash = true;
                                                            useslashresist = true;
                                                            solvermobstatsave[i].Add(solvertempplusslashresist);
                                                            solvermobstatinfo[i].Add(1);
                                                            solverplayerstatsave[i].Add(maxdamageholder);
                                                            solverplayerstatinfo[i].Add(1);
                                                        }
                                                        break;
                                                    case "Crush":
                                                        solvercrushdamage = solvercrushdamage + maxdamageholder;
                                                        resistdamageholder = (maxdamageholder * levelfactorholder) - ((maxdamageholder * levelfactorholder) * (1 - (solvertemppluscrushresist / (solvertemppluscrushresist + 6 + 3 * solverplayerlevel)))) * solverpercentcrushresist;
                                                        if (solverstatusamount[i] > 0)
                                                        {
                                                            usecrush = true;
                                                            usecrushresist = true;
                                                            solvermobstatsave[i].Add(solvertemppluscrushresist);
                                                            solvermobstatinfo[i].Add(2);
                                                            solverplayerstatsave[i].Add(maxdamageholder);
                                                            solverplayerstatinfo[i].Add(2);
                                                        }
                                                        break;
                                                    case "Heat":
                                                        solverheatdamage = solverheatdamage + maxdamageholder;
                                                        resistdamageholder = (maxdamageholder * levelfactorholder) - ((maxdamageholder * levelfactorholder) * (1 - (solvertempplusheatresist / (solvertempplusheatresist + 6 + 3 * solverplayerlevel)))) * solverpercentheatresist;
                                                        if (solverstatusamount[i] > 0)
                                                        {
                                                            useheat = true;
                                                            useheatresist = true;
                                                            solvermobstatsave[i].Add(solvertempplusheatresist);
                                                            solvermobstatinfo[i].Add(3);
                                                            solverplayerstatsave[i].Add(maxdamageholder);
                                                            solverplayerstatinfo[i].Add(3);
                                                        }
                                                        break;
                                                    case "Cold":
                                                        solvercolddamage = solvercolddamage + maxdamageholder;
                                                        resistdamageholder = (maxdamageholder * levelfactorholder) - ((maxdamageholder * levelfactorholder) * (1 - (solvertemppluscoldresist / (solvertemppluscoldresist + 6 + 3 * solverplayerlevel)))) * solverpercentcoldresist;
                                                        if (solverstatusamount[i] > 0)
                                                        {
                                                            usecold = true;
                                                            usecoldresist = true;
                                                            solvermobstatsave[i].Add(solvertemppluscoldresist);
                                                            solvermobstatinfo[i].Add(4);
                                                            solverplayerstatsave[i].Add(maxdamageholder);
                                                            solverplayerstatinfo[i].Add(4);
                                                        }
                                                        break;
                                                    case "Magic":
                                                        solvermagicdamage = solvermagicdamage + maxdamageholder;
                                                        resistdamageholder = (maxdamageholder * levelfactorholder) - ((maxdamageholder * levelfactorholder) * (1 - (solvertempplusmagicresist / (solvertempplusmagicresist + 6 + 3 * solverplayerlevel)))) * solverpercentmagicresist;
                                                        if (solverstatusamount[i] > 0)
                                                        {
                                                            usemagic = true;
                                                            usemagicresist = true;
                                                            solvermobstatsave[i].Add(solvertempplusmagicresist);
                                                            solvermobstatinfo[i].Add(5);
                                                            solverplayerstatsave[i].Add(maxdamageholder);
                                                            solverplayerstatinfo[i].Add(5);
                                                        }
                                                        break;
                                                    case "Poison":
                                                        solverpoisondamage = solverpoisondamage + maxdamageholder;
                                                        resistdamageholder = (maxdamageholder * levelfactorholder) - ((maxdamageholder * levelfactorholder) * (1 - (solvertemppluspoisonresist / (solvertemppluspoisonresist + 6 + 3 * solverplayerlevel)))) * solverpercentpoisonresist;
                                                        if (solverstatusamount[i] > 0)
                                                        {
                                                            usepoison = true;
                                                            usepoisonresist = true;
                                                            solvermobstatsave[i].Add(solvertemppluspoisonresist);
                                                            solvermobstatinfo[i].Add(6);
                                                            solverplayerstatsave[i].Add(maxdamageholder);
                                                            solverplayerstatinfo[i].Add(6);
                                                        }
                                                        break;
                                                    case "Divine":
                                                        solverdivinedamage = solverdivinedamage + maxdamageholder;
                                                        resistdamageholder = (maxdamageholder * levelfactorholder) - ((maxdamageholder * levelfactorholder) * (1 - (solvertempplusdivineresist / (solvertempplusdivineresist + 6 + 3 * solverplayerlevel)))) * solverpercentdivineresist;
                                                        if (solverstatusamount[i] > 0)
                                                        {
                                                            usedivine = true;
                                                            usedivineresist = true;
                                                            solvermobstatsave[i].Add(solvertempplusdivineresist);
                                                            solvermobstatinfo[i].Add(7);
                                                            solverplayerstatsave[i].Add(maxdamageholder);
                                                            solverplayerstatinfo[i].Add(7);
                                                        }
                                                        break;
                                                    case "Chaos":
                                                        solverchaosdamage = solverchaosdamage + maxdamageholder;
                                                        resistdamageholder = (maxdamageholder * levelfactorholder) - ((maxdamageholder * levelfactorholder) * (1 - (solvertemppluschaosresist / (solvertemppluschaosresist + 6 + 3 * solverplayerlevel)))) * solverpercentchaosresist;
                                                        if (solverstatusamount[i] > 0)
                                                        {
                                                            usechaos = true;
                                                            usechaosresist = true;
                                                            solvermobstatsave[i].Add(solvertemppluschaosresist);
                                                            solvermobstatinfo[i].Add(8);
                                                            solverplayerstatsave[i].Add(maxdamageholder);
                                                            solverplayerstatinfo[i].Add(8);
                                                        }
                                                        break;
                                                    default: // true damage
                                                        solvertruedamage = solvertruedamage + maxdamageholder;
                                                        resistdamageholder = (maxdamageholder * levelfactorholder) - ((maxdamageholder * levelfactorholder) * (1 - (solvertempplustrueresist / (solvertempplustrueresist + 6 + 3 * solverplayerlevel)))) * solverpercenttrueresist;
                                                        if (solverstatusamount[i] > 0)
                                                        {
                                                            usetrue = true;
                                                            usetrueresist = true;
                                                            solvermobstatsave[i].Add(solvertempplustrueresist);
                                                            solvermobstatinfo[i].Add(9);
                                                            solverplayerstatsave[i].Add(maxdamageholder);
                                                            solverplayerstatinfo[i].Add(9);
                                                        }
                                                        break;
                                                }
                                                solverresistdamage = (int)(solverresistdamage + resistdamageholder);
                                                solveraggrogenerated = (solveraggrogenerated + (maxdamageholder - resistdamageholder - (maxdamageholder - (maxdamageholder * levelfactorholder))) * 1.5f) + float.Parse(skilllvaggromulti[solverskilllevel[i]]);
                                                break;
                                            case "4":
                                                solvertempattack = solvertempattack - solverstatusamount[i];
                                                break;
                                            case "7":
                                                solvertempattack = solvertempattack - solverstatusamount[i];
                                                automulti = automulti - solverstatusamount[i];
                                                break;
                                            case "12":
                                                switch (statusdamage[solverstatusid[i]])
                                                {
                                                    case "Pierce":
                                                        solvertemppluspierceresist = solvertemppluspierceresist - solverstatusamount[i];
                                                        break;
                                                    case "Slash":
                                                        solvertempplusslashresist = solvertempplusslashresist - solverstatusamount[i];
                                                        break;
                                                    case "Crush":
                                                        solvertemppluscrushresist = solvertemppluscrushresist - solverstatusamount[i];
                                                        break;
                                                    case "Poison":
                                                        solvertemppluspoisonresist = solvertemppluspoisonresist - solverstatusamount[i];
                                                        break;
                                                    case "Heat":
                                                        solvertempplusheatresist = solvertempplusheatresist - solverstatusamount[i];
                                                        break;
                                                    case "Cold":
                                                        solvertemppluscoldresist = solvertemppluscoldresist - solverstatusamount[i];
                                                        break;
                                                    case "Magic":
                                                        solvertempplusmagicresist = solvertempplusmagicresist - solverstatusamount[i];
                                                        break;
                                                    case "Divine":
                                                        solvertempplusdivineresist = solvertempplusdivineresist - solverstatusamount[i];
                                                        break;
                                                    case "Chaos":
                                                        solvertemppluschaosresist = solvertemppluschaosresist - solverstatusamount[i];
                                                        break;
                                                    default:
                                                        solvertempplustrueresist = solvertempplustrueresist - solverstatusamount[i];
                                                        break;
                                                }
                                                break;
                                            case "14":
                                                solvertempattack = solvertempattack - solverstatusamount[i];
                                                automulti = automulti - solverstatusamount[i];
                                                break;
                                            case "15":
                                                solvertempdefence = solvertempdefence - solverstatusamount[i];
                                                break;
                                            case "16":
                                                switch (statusdamage[solverstatusid[i]])
                                                {
                                                    case "Pierce":
                                                        solvertemppierceplus = solvertemppierceplus - solverstatusamount[i];
                                                        break;
                                                    case "Slash":
                                                        solvertempslashplus = solvertempslashplus - solverstatusamount[i];
                                                        break;
                                                    case "Crush":
                                                        solvertempcrushplus = solvertempcrushplus - solverstatusamount[i];
                                                        break;
                                                    case "Poison":
                                                        solvertemppoison = solvertemppoison - solverstatusamount[i];
                                                        break;
                                                    case "Heat":
                                                        solvertempheat = solvertempheat - solverstatusamount[i];
                                                        break;
                                                    case "Cold":
                                                        solvertempcold = solvertempcold - solverstatusamount[i];
                                                        break;
                                                    case "Magic":
                                                        solvertempmagic = solvertempmagic - solverstatusamount[i];
                                                        break;
                                                    case "Divine":
                                                        solvertempdivine = solvertempdivine - solverstatusamount[i];
                                                        break;
                                                    case "Chaos":
                                                        solvertempchaos = solvertempchaos - solverstatusamount[i];
                                                        break;
                                                    default:
                                                        solvertemptrue = solvertemptrue - solverstatusamount[i];
                                                        break;
                                                }
                                                break;
                                            case "41":
                                                solvertempattack = solvertempattack - solverstatusamount[i];
                                                break;
                                            case "44":
                                                solvertempphysical = solvertempphysical - solverstatusamount[i];
                                                solvertempspell = solvertempspell - solverstatusamount[i];
                                                solvertempmovement = solvertempmovement - solverstatusamount[i];
                                                solvertempwounding = solvertempwounding - solverstatusamount[i];
                                                solvertempweakening = solvertempweakening - solverstatusamount[i];
                                                break;
                                            case "45":
                                                iceattuneactive = false;
                                                break;
                                            case "46":
                                                fireattuneactive = false;
                                                break;
                                        }
                                    }
                                    solverstatusend[i] = true;
                                    ActionsUsedListbox.Items.Add(statusname[solverstatusid[i]] + "(Status Expired)");
                                    solveractiontype.Add(4);
                                    solverskillid.Add(-1);
                                    solverskilllevel.Add(-1);
                                    solverskillhittime.Add(-1);
                                    solverstatusid.Add(-1);
                                    solverstatusmaxduration.Add(-1);
                                    solverstatusduration.Add(-1);
                                    solverstatusticktime.Add(-1);
                                    solverstatusamount.Add(-1);
                                    solverstatusovercharge.Add(-1);
                                    solverstatusoverchargeslash.Add(-1);
                                    solverstatusoverchargecrush.Add(-1);
                                    solverstatusapplied.Add(false);
                                    solverstatusend.Add(false);
                                    solverdirectdamage.Add(0);
                                    solvercooldown.Add(0);
                                    solvercasttime.Add(0);
                                    solverlockout.Add(0);
                                    solverstalltime.Add(0);
                                    solverhaspvpversion.Add(false);
                                    solversinglemaxdamage.Add(-1);
                                    solversingleactualdamage.Add(-1);
                                    solversingleresistdamage.Add(-1);
                                    solversingleleveldamage.Add(-1);
                                    solversingledps.Add(-1);
                                    solversinglechancetohit.Add(-1);
                                    solversinglecritchance.Add(-1);
                                    solversingleaggro.Add(-1);
                                    solversinglelock.Add(-1);
                                    solversingletimeforaction.Add(-1);
                                }
                                else
                                {
                                    switch (statuseffect[solverstatusid[i]])
                                    {
                                        case "0":
                                            break;
                                    }
                                }
                            }
                        }
                    }
                    for (int i = 0; i < solverstatusduration.Count; i++)
                    {
                        if (solveractiontype[i] == 2 && solverstatusapplied[i] == true)
                        {
                            if (statuseffect[solverstatusid[i]] == "3")
                            {
                                if (solverstatusticktime[i] > 0 && solverstatusduration[i] <= 0)
                                {
                                    solverstatusduration[i] = 0.00001f; // lower than any attack speed could be(value given to pass the below check and make sure all ticks happen if an extremely slow attack occurs beforehand)
                                }
                            }
                            if (solverstatusduration[i] > 0)
                            {
                                switch (statuseffect[solverstatusid[i]])
                                {
                                    case "0":
                                        if (solverstatusovercharge[i] > 0 && solvertemppluspierceresist > 0)
                                        {
                                            if (solvertemppluspierceresist - solverstatusovercharge[i] <= 0)
                                            {
                                                solvertemppluspierceresist = 0;
                                                solverstatusovercharge[i] = Math.Abs(solvertemppluspierceresist - solverstatusovercharge[i]);
                                            }
                                            else
                                            {
                                                solvertemppluspierceresist = solvertemppluspierceresist - solverstatusovercharge[i];
                                                solverstatusovercharge[i] = 0;
                                            }
                                        }
                                        if (solverstatusoverchargeslash[i] > 0 && solvertempplusslashresist > 0)
                                        {
                                            if (solvertempplusslashresist - solverstatusoverchargeslash[i] <= 0)
                                            {
                                                solvertempplusslashresist = 0;
                                                solverstatusoverchargeslash[i] = Math.Abs(solvertempplusslashresist - solverstatusoverchargeslash[i]);
                                            }
                                            else
                                            {
                                                solvertempplusslashresist = solvertempplusslashresist - solverstatusoverchargeslash[i];
                                                solverstatusoverchargeslash[i] = 0;
                                            }
                                        }
                                        if (solverstatusoverchargecrush[i] > 0 && solvertemppluscrushresist > 0)
                                        {
                                            if (solvertemppluscrushresist - solverstatusoverchargecrush[i] <= 0)
                                            {
                                                solvertemppluscrushresist = 0;
                                                solverstatusoverchargecrush[i] = Math.Abs(solvertemppluscrushresist - solverstatusoverchargecrush[i]);
                                            }
                                            else
                                            {
                                                solvertemppluscrushresist = solvertemppluscrushresist - solverstatusoverchargecrush[i];
                                                solverstatusoverchargecrush[i] = 0;
                                            }
                                        }
                                        break;
                                    case "3":
                                        if (solverstatusmaxduration[i] - solverstatusduration[i] > Convert.ToInt32(statustick[solverstatusid[i]]))
                                        {
                                            maxdamageholder = solverstatusamount[i] * ((int)(solverstatusticktime[i] / Convert.ToInt32(statustick[solverstatusid[i]])) - (int)(solverstatusduration[i] / Convert.ToInt32(statustick[solverstatusid[i]])));
                                            solverstatusticktime[i] = solverstatusduration[i];
                                            solvermaxdamage = (int)(solvermaxdamage + maxdamageholder);
                                            leveldamageholder = solvermaxdamage * levelfactorholder;
                                            solverleveldamage = (int)(solverleveldamage + (solvermaxdamage - leveldamageholder));
                                            switch (statusdamage[solverstatusid[i]])
                                            {
                                                case "Pierce":
                                                    solverpiercedamage = solverpiercedamage + maxdamageholder;
                                                    resistdamageholder = (maxdamageholder * levelfactorholder) - ((maxdamageholder * levelfactorholder) * (1 - (solvertemppluspierceresist / (solvertemppluspierceresist + 6 + 3 * solverplayerlevel)))) * solverpercentpierceresist;
                                                    if (solverstatusamount[i] > 0)
                                                    {
                                                        usepierce = true;
                                                        usepierceresist = true;
                                                        solvermobstatsave[i].Add(solvertemppluspierceresist);
                                                        solvermobstatinfo[i].Add(0);
                                                        solverplayerstatsave[i].Add(maxdamageholder);
                                                        solverplayerstatinfo[i].Add(0);
                                                    }
                                                    break;
                                                case "Slash":
                                                    solverslashdamage = solverslashdamage + maxdamageholder;
                                                    resistdamageholder = (maxdamageholder * levelfactorholder) - ((maxdamageholder * levelfactorholder) * (1 - (solvertempplusslashresist / (solvertempplusslashresist + 6 + 3 * solverplayerlevel)))) * solverpercentslashresist;
                                                    if (solverstatusamount[i] > 0)
                                                    {
                                                        useslash = true;
                                                        useslashresist = true;
                                                        solvermobstatsave[i].Add(solvertempplusslashresist);
                                                        solvermobstatinfo[i].Add(1);
                                                        solverplayerstatsave[i].Add(maxdamageholder);
                                                        solverplayerstatinfo[i].Add(1);
                                                    }
                                                    break;
                                                case "Crush":
                                                    solvercrushdamage = solvercrushdamage + maxdamageholder;
                                                    resistdamageholder = (maxdamageholder * levelfactorholder) - ((maxdamageholder * levelfactorholder) * (1 - (solvertemppluscrushresist / (solvertemppluscrushresist + 6 + 3 * solverplayerlevel)))) * solverpercentcrushresist;
                                                    if (solverstatusamount[i] > 0)
                                                    {
                                                        usecrush = true;
                                                        usecrushresist = true;
                                                        solvermobstatsave[i].Add(solvertemppluscrushresist);
                                                        solvermobstatinfo[i].Add(2);
                                                        solverplayerstatsave[i].Add(maxdamageholder);
                                                        solverplayerstatinfo[i].Add(2);
                                                    }
                                                    break;
                                                case "Heat":
                                                    solverheatdamage = solverheatdamage + maxdamageholder;
                                                    resistdamageholder = (maxdamageholder * levelfactorholder) - ((maxdamageholder * levelfactorholder) * (1 - (solvertempplusheatresist / (solvertempplusheatresist + 6 + 3 * solverplayerlevel)))) * solverpercentheatresist;
                                                    if (solverstatusamount[i] > 0)
                                                    {
                                                        useheat = true;
                                                        useheatresist = true;
                                                        solvermobstatsave[i].Add(solvertempplusheatresist);
                                                        solvermobstatinfo[i].Add(3);
                                                        solverplayerstatsave[i].Add(maxdamageholder);
                                                        solverplayerstatinfo[i].Add(3);
                                                    }
                                                    break;
                                                case "Cold":
                                                    solvercolddamage = solvercolddamage + maxdamageholder;
                                                    resistdamageholder = (maxdamageholder * levelfactorholder) - ((maxdamageholder * levelfactorholder) * (1 - (solvertemppluscoldresist / (solvertemppluscoldresist + 6 + 3 * solverplayerlevel)))) * solverpercentcoldresist;
                                                    if (solverstatusamount[i] > 0)
                                                    {
                                                        usecold = true;
                                                        usecoldresist = true;
                                                        solvermobstatsave[i].Add(solvertemppluscoldresist);
                                                        solvermobstatinfo[i].Add(4);
                                                        solverplayerstatsave[i].Add(maxdamageholder);
                                                        solverplayerstatinfo[i].Add(4);
                                                    }
                                                    break;
                                                case "Magic":
                                                    solvermagicdamage = solvermagicdamage + maxdamageholder;
                                                    resistdamageholder = (maxdamageholder * levelfactorholder) - ((maxdamageholder * levelfactorholder) * (1 - (solvertempplusmagicresist / (solvertempplusmagicresist + 6 + 3 * solverplayerlevel)))) * solverpercentmagicresist;
                                                    if (solverstatusamount[i] > 0)
                                                    {
                                                        usemagic = true;
                                                        usemagicresist = true;
                                                        solvermobstatsave[i].Add(solvertempplusmagicresist);
                                                        solvermobstatinfo[i].Add(5);
                                                        solverplayerstatsave[i].Add(maxdamageholder);
                                                        solverplayerstatinfo[i].Add(5);
                                                    }
                                                    break;
                                                case "Poison":
                                                    solverpoisondamage = solverpoisondamage + maxdamageholder;
                                                    resistdamageholder = (maxdamageholder * levelfactorholder) - ((maxdamageholder * levelfactorholder) * (1 - (solvertemppluspoisonresist / (solvertemppluspoisonresist + 6 + 3 * solverplayerlevel)))) * solverpercentpoisonresist;
                                                    if (solverstatusamount[i] > 0)
                                                    {
                                                        usepoison = true;
                                                        usepoisonresist = true;
                                                        solvermobstatsave[i].Add(solvertemppluspoisonresist);
                                                        solvermobstatinfo[i].Add(6);
                                                        solverplayerstatsave[i].Add(maxdamageholder);
                                                        solverplayerstatinfo[i].Add(6);
                                                    }
                                                    break;
                                                case "Divine":
                                                    solverdivinedamage = solverdivinedamage + maxdamageholder;
                                                    resistdamageholder = (maxdamageholder * levelfactorholder) - ((maxdamageholder * levelfactorholder) * (1 - (solvertempplusdivineresist / (solvertempplusdivineresist + 6 + 3 * solverplayerlevel)))) * solverpercentdivineresist;
                                                    if (solverstatusamount[i] > 0)
                                                    {
                                                        usedivine = true;
                                                        usedivineresist = true;
                                                        solvermobstatsave[i].Add(solvertempplusdivineresist);
                                                        solvermobstatinfo[i].Add(7);
                                                        solverplayerstatsave[i].Add(maxdamageholder);
                                                        solverplayerstatinfo[i].Add(7);
                                                    }
                                                    break;
                                                case "Chaos":
                                                    solverchaosdamage = solverchaosdamage + maxdamageholder;
                                                    resistdamageholder = (maxdamageholder * levelfactorholder) - ((maxdamageholder * levelfactorholder) * (1 - (solvertemppluschaosresist / (solvertemppluschaosresist + 6 + 3 * solverplayerlevel)))) * solverpercentchaosresist;
                                                    if (solverstatusamount[i] > 0)
                                                    {
                                                        usechaos = true;
                                                        usechaosresist = true;
                                                        solvermobstatsave[i].Add(solvertemppluschaosresist);
                                                        solvermobstatinfo[i].Add(8);
                                                        solverplayerstatsave[i].Add(maxdamageholder);
                                                        solverplayerstatinfo[i].Add(8);
                                                    }
                                                    break;
                                                default: // true damage
                                                    solvertruedamage = solvertruedamage + maxdamageholder;
                                                    resistdamageholder = (maxdamageholder * levelfactorholder) - ((maxdamageholder * levelfactorholder) * (1 - (solvertempplustrueresist / (solvertempplustrueresist + 6 + 3 * solverplayerlevel)))) * solverpercenttrueresist;
                                                    if (solverstatusamount[i] > 0)
                                                    {
                                                        usetrue = true;
                                                        usetrueresist = true;
                                                        solvermobstatsave[i].Add(solvertempplustrueresist);
                                                        solvermobstatinfo[i].Add(9);
                                                        solverplayerstatsave[i].Add(maxdamageholder);
                                                        solverplayerstatinfo[i].Add(9);
                                                    }
                                                    break;
                                            }
                                            solverresistdamage = (int)(solverresistdamage + resistdamageholder);
                                            solveraggrogenerated = (solveraggrogenerated + (maxdamageholder - resistdamageholder - (maxdamageholder - (maxdamageholder * levelfactorholder))) * 1.5f) + float.Parse(skilllvaggromulti[solverskilllevel[i]]);
                                        }
                                        else solverstatusticktime[i] = solverstatusduration[i];
                                        break;
                                    case "12":
                                        if (solverstatusamount[i] <= 0)
                                        {
                                            switch (statusdamage[solverstatusid[i]])
                                            {
                                                case "Pierce":
                                                    if (solverstatusovercharge[i] > 0 && solvertemppluspierceresist > 0)
                                                    {
                                                        if (solvertemppluspierceresist - solverstatusovercharge[i] <= 0)
                                                        {
                                                            solvertemppluspierceresist = 0;
                                                            solverstatusovercharge[i] = Math.Abs(solvertemppluspierceresist - solverstatusovercharge[i]);
                                                        }
                                                        else
                                                        {
                                                            solvertemppluspierceresist = solvertemppluspierceresist - solverstatusovercharge[i];
                                                            solverstatusovercharge[i] = 0;
                                                        }
                                                    }
                                                    break;
                                                case "Slash":
                                                    if (solverstatusovercharge[i] > 0 && solvertempplusslashresist > 0)
                                                    {
                                                        if (solvertempplusslashresist - solverstatusovercharge[i] <= 0)
                                                        {
                                                            solvertempplusslashresist = 0;
                                                            solverstatusovercharge[i] = Math.Abs(solvertempplusslashresist - solverstatusovercharge[i]);
                                                        }
                                                        else
                                                        {
                                                            solvertempplusslashresist = solvertempplusslashresist - solverstatusovercharge[i];
                                                            solverstatusovercharge[i] = 0;
                                                        }
                                                    }
                                                    break;
                                                case "Crush":
                                                    if (solverstatusovercharge[i] > 0 && solvertemppluscrushresist > 0)
                                                    {
                                                        if (solvertemppluscrushresist - solverstatusovercharge[i] <= 0)
                                                        {
                                                            solvertemppluscrushresist = 0;
                                                            solverstatusovercharge[i] = Math.Abs(solvertemppluscrushresist - solverstatusovercharge[i]);
                                                        }
                                                        else
                                                        {
                                                            solvertemppluscrushresist = solvertemppluscrushresist - solverstatusovercharge[i];
                                                            solverstatusovercharge[i] = 0;
                                                        }
                                                    }
                                                    break;
                                                case "Poison":
                                                    if (solverstatusovercharge[i] > 0 && solvertemppluspoisonresist > 0)
                                                    {
                                                        if (solvertemppluspoisonresist - solverstatusovercharge[i] <= 0)
                                                        {
                                                            solvertemppluspoisonresist = 0;
                                                            solverstatusovercharge[i] = Math.Abs(solvertemppluspoisonresist - solverstatusovercharge[i]);
                                                        }
                                                        else
                                                        {
                                                            solvertemppluspoisonresist = solvertemppluspoisonresist - solverstatusovercharge[i];
                                                            solverstatusovercharge[i] = 0;
                                                        }
                                                    }
                                                    break;
                                                case "Heat":
                                                    if (solverstatusovercharge[i] > 0 && solvertempplusheatresist > 0)
                                                    {
                                                        if (solvertempplusheatresist - solverstatusovercharge[i] <= 0)
                                                        {
                                                            solvertempplusheatresist = 0;
                                                            solverstatusovercharge[i] = Math.Abs(solvertempplusheatresist - solverstatusovercharge[i]);
                                                        }
                                                        else
                                                        {
                                                            solvertempplusheatresist = solvertempplusheatresist - solverstatusovercharge[i];
                                                            solverstatusovercharge[i] = 0;
                                                        }
                                                    }
                                                    break;
                                                case "Cold":
                                                    if (solverstatusovercharge[i] > 0 && solvertemppluscoldresist > 0)
                                                    {
                                                        if (solvertemppluscoldresist - solverstatusovercharge[i] <= 0)
                                                        {
                                                            solvertemppluscoldresist = 0;
                                                            solverstatusovercharge[i] = Math.Abs(solvertemppluscoldresist - solverstatusovercharge[i]);
                                                        }
                                                        else
                                                        {
                                                            solvertemppluscoldresist = solvertemppluscoldresist - solverstatusovercharge[i];
                                                            solverstatusovercharge[i] = 0;
                                                        }
                                                    }
                                                    break;
                                                case "Magic":
                                                    if (solverstatusovercharge[i] > 0 && solvertempplusmagicresist > 0)
                                                    {
                                                        if (solvertempplusmagicresist - solverstatusovercharge[i] <= 0)
                                                        {
                                                            solvertempplusmagicresist = 0;
                                                            solverstatusovercharge[i] = Math.Abs(solvertempplusmagicresist - solverstatusovercharge[i]);
                                                        }
                                                        else
                                                        {
                                                            solvertempplusmagicresist = solvertempplusmagicresist - solverstatusovercharge[i];
                                                            solverstatusovercharge[i] = 0;
                                                        }
                                                    }
                                                    break;
                                                case "Divine":
                                                    if (solverstatusovercharge[i] > 0 && solvertempplusdivineresist > 0)
                                                    {
                                                        if (solvertempplusdivineresist - solverstatusovercharge[i] <= 0)
                                                        {
                                                            solvertempplusdivineresist = 0;
                                                            solverstatusovercharge[i] = Math.Abs(solvertempplusdivineresist - solverstatusovercharge[i]);
                                                        }
                                                        else
                                                        {
                                                            solvertempplusdivineresist = solvertempplusdivineresist - solverstatusovercharge[i];
                                                            solverstatusovercharge[i] = 0;
                                                        }
                                                    }
                                                    break;
                                                case "Chaos":
                                                    if (solverstatusovercharge[i] > 0 && solvertemppluschaosresist > 0)
                                                    {
                                                        if (solvertemppluschaosresist - solverstatusovercharge[i] <= 0)
                                                        {
                                                            solvertemppluschaosresist = 0;
                                                            solverstatusovercharge[i] = Math.Abs(solvertemppluschaosresist - solverstatusovercharge[i]);
                                                        }
                                                        else
                                                        {
                                                            solvertemppluschaosresist = solvertemppluschaosresist - solverstatusovercharge[i];
                                                            solverstatusovercharge[i] = 0;
                                                        }
                                                    }
                                                    break;
                                                default:
                                                    if (solverstatusovercharge[i] > 0 && solvertempplustrueresist > 0)
                                                    {
                                                        if (solvertempplustrueresist - solverstatusovercharge[i] <= 0)
                                                        {
                                                            solvertempplustrueresist = 0;
                                                            solverstatusovercharge[i] = Math.Abs(solvertempplustrueresist - solverstatusovercharge[i]);
                                                        }
                                                        else
                                                        {
                                                            solvertempplustrueresist = solvertempplustrueresist - solverstatusovercharge[i];
                                                            solverstatusovercharge[i] = 0;
                                                        }
                                                    }
                                                    break;
                                            }
                                        }
                                        break;
                                    case "15":
                                        if (solverstatusovercharge[i] > 0 && solvertempdefence > 0)
                                        {
                                            if (solvertempdefence - solverstatusovercharge[i] <= 0)
                                            {
                                                solvertempdefence = 0;
                                                solverstatusovercharge[i] = Math.Abs(solvertempdefence - solverstatusovercharge[i]);
                                            }
                                            else
                                            {
                                                solvertempdefence = solvertempdefence - solverstatusovercharge[i];
                                                solverstatusovercharge[i] = 0;
                                            }
                                        }
                                        break;
                                    case "44":
                                        if (solverstatusovercharge[i] > 0 && solvertempphysical > 0)
                                        {
                                            if (solvertempphysical - solverstatusovercharge[i] <= 0)
                                            {
                                                solvertempphysical = 0;
                                                solverstatusovercharge[i] = Math.Abs(solvertempphysical - solverstatusovercharge[i]);
                                            }
                                            else
                                            {
                                                solvertempphysical = solvertempphysical - solverstatusovercharge[i];
                                                solverstatusovercharge[i] = 0;
                                            }
                                        }
                                        if (solverstatusovercharge[i] > 0 && solvertempspell > 0)
                                        {
                                            if (solvertempspell - solverstatusovercharge[i] <= 0)
                                            {
                                                solvertempspell = 0;
                                                solverstatusovercharge[i] = Math.Abs(solvertempspell - solverstatusovercharge[i]);
                                            }
                                            else
                                            {
                                                solvertempspell = solvertempspell - solverstatusovercharge[i];
                                                solverstatusovercharge[i] = 0;
                                            }
                                        }
                                        if (solverstatusovercharge[i] > 0 && solvertempmovement > 0)
                                        {
                                            if (solvertempmovement - solverstatusovercharge[i] <= 0)
                                            {
                                                solvertempmovement = 0;
                                                solverstatusovercharge[i] = Math.Abs(solvertempmovement - solverstatusovercharge[i]);
                                            }
                                            else
                                            {
                                                solvertempmovement = solvertempmovement - solverstatusovercharge[i];
                                                solverstatusovercharge[i] = 0;
                                            }
                                        }
                                        if (solverstatusovercharge[i] > 0 && solvertempwounding > 0)
                                        {
                                            if (solvertempwounding - solverstatusovercharge[i] <= 0)
                                            {
                                                solvertempwounding = 0;
                                                solverstatusovercharge[i] = Math.Abs(solvertempwounding - solverstatusovercharge[i]);
                                            }
                                            else
                                            {
                                                solvertempwounding = solvertempwounding - solverstatusovercharge[i];
                                                solverstatusovercharge[i] = 0;
                                            }
                                        }
                                        if (solverstatusovercharge[i] > 0 && solvertempweakening > 0)
                                        {
                                            if (solvertempweakening - solverstatusovercharge[i] <= 0)
                                            {
                                                solvertempweakening = 0;
                                                solverstatusovercharge[i] = Math.Abs(solvertempweakening - solverstatusovercharge[i]);
                                            }
                                            else
                                            {
                                                solvertempweakening = solvertempweakening - solverstatusovercharge[i];
                                                solverstatusovercharge[i] = 0;
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                    }
                }
                if (solveractiontype.Count > 0)
                {
                    OriginalMaxDamageTotal.Text = solvermaxdamage.ToString("0");
                    ActualDamageTotal.Text = (solvermaxdamage - solverresistdamage - solverleveldamage).ToString("0");
                    DamageResistTotal.Text = solverresistdamage.ToString("0");
                    DamageLevelTotal.Text = solverleveldamage.ToString("0");
                    DPSTotal.Text = ((solvermaxdamage - solverresistdamage - solverleveldamage) / (timeholder - solverlockout[solverlockout.Count - 1])).ToString("0");
                    if (solverchancetohittotal.Count > 0) ChanceToHitTotal.Text = solverchancetohittotal.Average().ToString("0.00") + "%";
                    else ChanceToHitTotal.Text = "N/A";
                    if (solvercritchancetotal.Count > 0) CriticalChanceTotal.Text = solvercritchancetotal.Average().ToString("0.00") + "%";
                    else CriticalChanceTotal.Text = "N/A";
                    AggroGeneratedTotal.Text = solveraggrogenerated.ToString("0");
                    LockContributionTotal.Text = (((solvermaxdamage - solverresistdamage - solverleveldamage) / float.Parse(DamageForLock.Text)) * 100).ToString("0.00") + "%";
                    TimeForActionTotal.Text = (timeholder - solverlockout[solverlockout.Count - 1]).ToString() + "s";

                    if (mobtotalrelevance == true)
                    {
                        if (usepierceresist == true)
                        {
                            if (solverpercentpierceresist < 1)
                            {
                                if (solverlowpluspierceresist != solverpluspierceresist)
                                {
                                    RelevantMobStatsListbox.Items.Add("Pierce Resist: " + solverlowpluspierceresist + " - " + solverpluspierceresist + " + " + Math.Abs((solverpercentpierceresist - 1) * 100) + "%");
                                }
                                else
                                {
                                    RelevantMobStatsListbox.Items.Add("Pierce Resist: " + solverpluspierceresist + " + " + Math.Abs((solverpercentpierceresist - 1) * 100) + "%");
                                }
                            }
                            else
                            {
                                if (solverlowpluspierceresist != solverpluspierceresist)
                                {
                                    RelevantMobStatsListbox.Items.Add("Pierce Resist: " + solverlowpluspierceresist + " - " + solverpluspierceresist);
                                }
                                else
                                {
                                    RelevantMobStatsListbox.Items.Add("Pierce Resist: " + solverpluspierceresist);
                                }
                            }
                        }
                        if (useslashresist == true)
                        {
                            if (solverpercentslashresist < 1)
                            {
                                if (solverlowplusslashresist != solverplusslashresist)
                                {
                                    RelevantMobStatsListbox.Items.Add("Slash Resist: " + solverlowplusslashresist + " - " + solverplusslashresist + " + " + Math.Abs((solverpercentslashresist - 1) * 100) + "%");
                                }
                                else
                                {
                                    RelevantMobStatsListbox.Items.Add("Slash Resist: " + solverplusslashresist + " + " + Math.Abs((solverpercentslashresist - 1) * 100) + "%");
                                }
                            }
                            else
                            {
                                if (solverlowplusslashresist != solverplusslashresist)
                                {
                                    RelevantMobStatsListbox.Items.Add("Slash Resist: " + solverlowplusslashresist + " - " + solverplusslashresist);
                                }
                                else
                                {
                                    RelevantMobStatsListbox.Items.Add("Slash Resist: " + solverplusslashresist);
                                }
                            }
                        }
                        if (usecrushresist == true)
                        {
                            if (solverpercentcrushresist < 1)
                            {
                                if (solverlowpluscrushresist != solverpluscrushresist)
                                {
                                    RelevantMobStatsListbox.Items.Add("Crush Resist: " + solverlowpluscrushresist + " - " + solverpluscrushresist + " + " + Math.Abs((solverpercentcrushresist - 1) * 100) + "%");
                                }
                                else
                                {
                                    RelevantMobStatsListbox.Items.Add("Crush Resist: " + solverpluscrushresist + " + " + Math.Abs((solverpercentcrushresist - 1) * 100) + "%");
                                }
                            }
                            else
                            {
                                if (solverlowpluscrushresist != solverpluscrushresist)
                                {
                                    RelevantMobStatsListbox.Items.Add("Crush Resist: " + solverlowpluscrushresist + " - " + solverpluscrushresist);
                                }
                                else
                                {
                                    RelevantMobStatsListbox.Items.Add("Crush Resist: " + solverpluscrushresist);
                                }
                            }
                        }
                        if (useheatresist == true)
                        {
                            if (solverpercentheatresist < 1)
                            {
                                if (solverlowplusheatresist != solverplusheatresist)
                                {
                                    RelevantMobStatsListbox.Items.Add("Heat Resist: " + solverlowplusheatresist + " - " + solverplusheatresist + " + " + Math.Abs((solverpercentheatresist - 1) * 100) + "%");
                                }
                                else
                                {
                                    RelevantMobStatsListbox.Items.Add("Heat Resist: " + solverplusheatresist + " + " + Math.Abs((solverpercentheatresist - 1) * 100) + "%");
                                }
                            }
                            else
                            {
                                if (solverlowplusheatresist != solverplusheatresist)
                                {
                                    RelevantMobStatsListbox.Items.Add("Heat Resist: " + solverlowplusheatresist + " - " + solverplusheatresist);
                                }
                                else
                                {
                                    RelevantMobStatsListbox.Items.Add("Heat Resist: " + solverplusheatresist);
                                }
                            }
                        }
                        if (usecoldresist == true)
                        {
                            if (solverpercentcoldresist < 1)
                            {
                                if (solverlowpluscoldresist != solverpluscoldresist)
                                {
                                    RelevantMobStatsListbox.Items.Add("Cold Resist: " + solverlowpluscoldresist + " - " + solverpluscoldresist + " + " + Math.Abs((solverpercentcoldresist - 1) * 100) + "%");
                                }
                                else
                                {
                                    RelevantMobStatsListbox.Items.Add("Cold Resist: " + solverpluscoldresist + " + " + Math.Abs((solverpercentcoldresist - 1) * 100) + "%");
                                }
                            }
                            else
                            {
                                if (solverlowpluscoldresist != solverpluscoldresist)
                                {
                                    RelevantMobStatsListbox.Items.Add("Cold Resist: " + solverlowpluscoldresist + " - " + solverpluscoldresist);
                                }
                                else
                                {
                                    RelevantMobStatsListbox.Items.Add("Cold Resist: " + solverpluscoldresist);
                                }
                            }
                        }
                        if (usemagicresist == true)
                        {
                            if (solverpercentmagicresist < 1)
                            {
                                if (solverlowplusmagicresist != solverplusmagicresist)
                                {
                                    RelevantMobStatsListbox.Items.Add("Magic Resist: " + solverlowplusmagicresist + " - " + solverplusmagicresist + " + " + Math.Abs((solverpercentmagicresist - 1) * 100) + "%");
                                }
                                else
                                {
                                    RelevantMobStatsListbox.Items.Add("Magic Resist: " + solverplusmagicresist + " + " + Math.Abs((solverpercentmagicresist - 1) * 100) + "%");
                                }
                            }
                            else
                            {
                                if (solverlowplusmagicresist != solverplusmagicresist)
                                {
                                    RelevantMobStatsListbox.Items.Add("Magic Resist: " + solverlowplusmagicresist + " - " + solverplusmagicresist);
                                }
                                else
                                {
                                    RelevantMobStatsListbox.Items.Add("Magic Resist: " + solverplusmagicresist);
                                }
                            }
                        }
                        if (usepoisonresist == true)
                        {
                            if (solverpercentpoisonresist < 1)
                            {
                                if (solverlowpluspoisonresist != solverpluspoisonresist)
                                {
                                    RelevantMobStatsListbox.Items.Add("Poison Resist: " + solverlowpluspoisonresist + " - " + solverpluspoisonresist + " + " + Math.Abs((solverpercentpoisonresist - 1) * 100) + "%");
                                }
                                else
                                {
                                    RelevantMobStatsListbox.Items.Add("Poison Resist: " + solverpluspoisonresist + " + " + Math.Abs((solverpercentpoisonresist - 1) * 100) + "%");
                                }
                            }
                            else
                            {
                                if (solverlowpluspoisonresist != solverpluspoisonresist)
                                {
                                    RelevantMobStatsListbox.Items.Add("Poison Resist: " + solverlowpluspoisonresist + " - " + solverpluspoisonresist);
                                }
                                else
                                {
                                    RelevantMobStatsListbox.Items.Add("Poison Resist: " + solverpluspoisonresist);
                                }
                            }
                        }
                        if (usedivineresist == true)
                        {
                            if (solverpercentdivineresist < 1)
                            {
                                if (solverlowplusdivineresist != solverplusdivineresist)
                                {
                                    RelevantMobStatsListbox.Items.Add("Divine Resist: " + solverlowplusdivineresist + " - " + solverplusdivineresist + " + " + Math.Abs((solverpercentdivineresist - 1) * 100) + "%");
                                }
                                else
                                {
                                    RelevantMobStatsListbox.Items.Add("Divine Resist: " + solverplusdivineresist + " + " + Math.Abs((solverpercentdivineresist - 1) * 100) + "%");
                                }
                            }
                            else
                            {
                                if (solverlowplusdivineresist != solverplusdivineresist)
                                {
                                    RelevantMobStatsListbox.Items.Add("Divine Resist: " + solverlowplusdivineresist + " - " + solverplusdivineresist);
                                }
                                else
                                {
                                    RelevantMobStatsListbox.Items.Add("Divine Resist: " + solverplusdivineresist);
                                }
                            }
                        }
                        if (usechaosresist == true)
                        {
                            if (solverpercentchaosresist < 1)
                            {
                                if (solverlowpluschaosresist != solverpluschaosresist)
                                {
                                    RelevantMobStatsListbox.Items.Add("Chaos Resist: " + solverlowpluschaosresist + " - " + solverpluschaosresist + " + " + Math.Abs((solverpercentchaosresist - 1) * 100) + "%");
                                }
                                else
                                {
                                    RelevantMobStatsListbox.Items.Add("Chaos Resist: " + solverpluschaosresist + " + " + Math.Abs((solverpercentchaosresist - 1) * 100) + "%");
                                }
                            }
                            else
                            {
                                if (solverlowpluschaosresist != solverpluschaosresist)
                                {
                                    RelevantMobStatsListbox.Items.Add("Chaos Resist: " + solverlowpluschaosresist + " - " + solverpluschaosresist);
                                }
                                else
                                {
                                    RelevantMobStatsListbox.Items.Add("Chaos Resist: " + solverpluschaosresist);
                                }
                            }
                        }
                        if (usetrueresist == true)
                        {
                            if (solverpercenttrueresist < 1)
                            {
                                if (solverlowplustrueresist != solverplustrueresist)
                                {
                                    RelevantMobStatsListbox.Items.Add("True Resist: " + solverlowplustrueresist + " - " + solverplustrueresist + " + " + Math.Abs((solverpercenttrueresist - 1) * 100) + "%");
                                }
                                else
                                {
                                    RelevantMobStatsListbox.Items.Add("True Resist: " + solverplustrueresist + " + " + Math.Abs((solverpercenttrueresist - 1) * 100) + "%");
                                }
                            }
                            else
                            {
                                if (solverlowplustrueresist != solverplustrueresist)
                                {
                                    RelevantMobStatsListbox.Items.Add("True Resist: " + solverlowplustrueresist + " - " + solverplustrueresist);
                                }
                                else
                                {
                                    RelevantMobStatsListbox.Items.Add("True Resist: " + solverplustrueresist);
                                }
                            }
                        }
                        if (usedefence == true)
                        {
                            if (solverlowdefence != solverdefence)
                            {
                                RelevantMobStatsListbox.Items.Add("Defence: " + solverlowdefence + " - " + solverdefence);
                            }
                            else
                            {
                                RelevantMobStatsListbox.Items.Add("Defence: " + solverdefence);
                            }
                        }
                        if (usephysicalevade == true)
                        {
                            if (solverlowphysical != solverphysical)
                            {
                                RelevantMobStatsListbox.Items.Add("Physical Evasion: " + solverlowphysical + " - " + solverphysical);
                            }
                            else
                            {
                                RelevantMobStatsListbox.Items.Add("Physical Evasion: " + solverphysical);
                            }
                        }
                        if (usespellevade == true)
                        {
                            if (solverlowspell != solverspell)
                            {
                                RelevantMobStatsListbox.Items.Add("Spell Evasion: " + solverlowspell + " - " + solverspell);
                            }
                            else
                            {
                                RelevantMobStatsListbox.Items.Add("Spell Evasion: " + solverspell);
                            }
                        }
                        if (usemovementevade == true)
                        {
                            if (solverlowmovement != solvermovement)
                            {
                                RelevantMobStatsListbox.Items.Add("Movement Evasion: " + solverlowmovement + " - " + solvermovement);
                            }
                            else
                            {
                                RelevantMobStatsListbox.Items.Add("Movement Evasion: " + solvermovement);
                            }
                        }
                        if (usewoundingevade == true)
                        {
                            if (solverlowwounding != solverwounding)
                            {
                                RelevantMobStatsListbox.Items.Add("Wounding Evasion: " + solverlowwounding + " - " + solverwounding);
                            }
                            else
                            {
                                RelevantMobStatsListbox.Items.Add("Wounding Evasion: " + solverwounding);
                            }
                        }
                        if (useweakeningevade == true)
                        {
                            if (solverlowweakening != solverweakening)
                            {
                                RelevantMobStatsListbox.Items.Add("Weakening Evasion: " + solverlowweakening + " - " + solverweakening);
                            }
                            else
                            {
                                RelevantMobStatsListbox.Items.Add("Weakening Evasion: " + solverweakening);
                            }
                        }
                        if (usementalevade == true) RelevantMobStatsListbox.Items.Add("Mental Evasion: " + solvermental); // can't be lowered by negative all evasions
                        if (usemoblevel == true) RelevantMobStatsListbox.Items.Add("Enemy Level: " + solvermoblevel);
                        if (solverpvp == true && usemoblevel == true)
                        {
                            RelevantMobStatsListbox.Items.Add("PvP(No Damage Lost From Level)");
                        }
                        if (pvpevasioncap == true)
                        {
                            RelevantMobStatsListbox.Items.Add("PvP(30% Miss Cap Triggered)");
                        }
                    }
                    if (playertotalrelevance == true)
                    {
                        if (usepierce == true) RelevantPlayerStatsListbox.Items.Add("Pierce Damage: " + solverpiercedamage);
                        if (useslash == true) RelevantPlayerStatsListbox.Items.Add("Slash Damage: " + solverslashdamage);
                        if (usecrush == true) RelevantPlayerStatsListbox.Items.Add("Crush Damage: " + solvercrushdamage);
                        if (useheat == true) RelevantPlayerStatsListbox.Items.Add("Heat Damage: " + solverheatdamage);
                        if (usecold == true) RelevantPlayerStatsListbox.Items.Add("Cold Damage: " + solvercolddamage);
                        if (usemagic == true) RelevantPlayerStatsListbox.Items.Add("Magic Damage: " + solvermagicdamage);
                        if (usepoison == true) RelevantPlayerStatsListbox.Items.Add("Poison Damage: " + solverpoisondamage);
                        if (usedivine == true) RelevantPlayerStatsListbox.Items.Add("Divine Damage: " + solverdivinedamage);
                        if (usechaos == true) RelevantPlayerStatsListbox.Items.Add("Chaos Damage: " + solverchaosdamage);
                        if (usetrue == true) RelevantPlayerStatsListbox.Items.Add("True Damage: " + solvertruedamage);
                        if (useattack == true)
                        {
                            if (solverhighattack > solverattack)
                            {
                                RelevantPlayerStatsListbox.Items.Add("Attack: " + solverattack + " - " + solverhighattack);
                            }
                            else if (solverlowattack < solverattack)
                            {
                                RelevantPlayerStatsListbox.Items.Add("Attack: " + solverlowattack + " - " + solverattack);
                            }
                            else
                            {
                                RelevantPlayerStatsListbox.Items.Add("Attack: " + solverattack);
                            }
                        }
                        if (usestrength == true)
                        {
                            if (solverhighstrength > solverstrength)
                            {
                                RelevantPlayerStatsListbox.Items.Add("Strength: " + solverstrength + " - " + solverhighstrength);
                            }
                            else if (solverlowstrength < solverstrength)
                            {
                                RelevantPlayerStatsListbox.Items.Add("Strength: " + solverlowstrength + " - " + solverstrength);
                            }
                            else
                            {
                                RelevantPlayerStatsListbox.Items.Add("Strength: " + solverstrength);
                            }
                        }
                        if (usedexterity == true)
                        {
                            if (solverhighdexterity > solverdexterity)
                            {
                                RelevantPlayerStatsListbox.Items.Add("Dexterity: " + solverdexterity + " - " + solverhighdexterity);
                            }
                            else if (solverlowdexterity < solverdexterity)
                            {
                                RelevantPlayerStatsListbox.Items.Add("Dexterity: " + solverlowdexterity + " - " + solverdexterity);
                            }
                            else
                            {
                                RelevantPlayerStatsListbox.Items.Add("Dexterity: " + solverdexterity);
                            }
                        }
                        if (usefocus == true)
                        {
                            if (solverhighfocus > solverfocus)
                            {
                                RelevantPlayerStatsListbox.Items.Add("Focus: " + solverfocus + " - " + solverhighfocus);
                            }
                            else if (solverlowfocus < solverfocus)
                            {
                                RelevantPlayerStatsListbox.Items.Add("Focus: " + solverlowfocus + " - " + solverfocus);
                            }
                            else
                            {
                                RelevantPlayerStatsListbox.Items.Add("Focus: " + solverfocus);
                            }
                        }
                        if (usevitality == true)
                        {
                            if (solverhighvitality > solvervitality)
                            {
                                RelevantPlayerStatsListbox.Items.Add("Vitality: " + solvervitality + " - " + solverhighvitality);
                            }
                            else if (solverlowvitality < solvervitality)
                            {
                                RelevantPlayerStatsListbox.Items.Add("Vitality: " + solverlowvitality + " - " + solvervitality);
                            }
                            else
                            {
                                RelevantPlayerStatsListbox.Items.Add("Vitality: " + solvervitality);
                            }
                        }
                        if (useweaponability == true)
                        {
                            if (solverhighweaponability > solverweaponability)
                            {
                                RelevantPlayerStatsListbox.Items.Add("Weapon Ability: " + solverweaponability + " - " + solverhighweaponability);
                            }
                            else if (solverlowweaponability < solverweaponability)
                            {
                                RelevantPlayerStatsListbox.Items.Add("Weapon Ability: " + solverlowweaponability + " - " + solverweaponability);
                            }
                            else
                            {
                                RelevantPlayerStatsListbox.Items.Add("Weapon Ability: " + solverweaponability);
                            }
                        }
                        if (useskillability == true)
                        {
                            if (solverhighskillability > solverskillability)
                            {
                                RelevantPlayerStatsListbox.Items.Add("Skill Ability: " + solverskillability + " - " + solverhighskillability);
                            }
                            else if (solverlowskillability < solverskillability)
                            {
                                RelevantPlayerStatsListbox.Items.Add("Skill Ability: " + solverlowskillability + " - " + solverskillability);
                            }
                            else
                            {
                                RelevantPlayerStatsListbox.Items.Add("Skill Ability: " + solverskillability);
                            }
                        }
                        if (usecritstrike == true) RelevantPlayerStatsListbox.Items.Add("Critical Strike: " + solvercritstrike);
                        if (usecritskills == true) RelevantPlayerStatsListbox.Items.Add("Critical Skills: " + solvercritskills);
                        RelevantPlayerStatsListbox.Items.Add("Player Level: " + solverplayerlevel);
                        if (usepvp == true)
                        {
                            RelevantPlayerStatsListbox.Items.Add("PvP(PvP Altered Skill(s))");
                        }
                    }
                }
            }
        }

        // #Page4
        ItemAdvancedSearch AdvancedSearch;
        string[] commasplit;
        string[] commasplit2;
        bool itemstatmode = false; // false = ingame only, true = all
        public static List<string> setbonuses = new List<string>();

        private void ItemNameSearchTextbox_TextChanged(object sender, EventArgs e)
        {
            if (nameskip3 == false && ItemStatSearchCheckbox.Checked == false)
            {
                ItemSearchListbox.Items.Clear();
                ItemDescriptionTextbox.Clear();
                ItemStatsListbox.Items.Clear();
                zholder.Clear();
                ItemSearchListbox.BeginUpdate();
                zilength2 = ItemNameSearchTextbox.Text.Length - zilength;
                if (string.IsNullOrEmpty(zisearch) == false)
                {
                    if (zisearch.Length > ItemNameSearchTextbox.Text.Length)
                    {
                        if (zisearch.Substring(0, ItemNameSearchTextbox.Text.Length) != ItemNameSearchTextbox.Text)
                        {
                            ziwarning = true;
                        }
                    }
                    else
                    {
                        if (ItemNameSearchTextbox.Text.Substring(0, zisearch.Length) != zisearch)
                        {
                            ziwarning = true;
                        }
                    }
                }
                if (zilength > ItemNameSearchTextbox.Text.Length && ziwarning == false)
                {
                    for (int i = 0; i < ziholder[ItemNameSearchTextbox.Text.Length].Count; i++)
                    {
                        if (itemname[ziholder[ItemNameSearchTextbox.Text.Length][i]].ToUpper().Contains(ItemNameSearchTextbox.Text.ToUpper()))
                        {
                            ItemSearchListbox.Items.Add(itemname[ziholder[ItemNameSearchTextbox.Text.Length][i]]);
                            zholder.Add(ziholder[ItemNameSearchTextbox.Text.Length][i]);
                        }
                    }
                    ziholder.RemoveRange(ItemNameSearchTextbox.Text.Length + 1, zilength - ItemNameSearchTextbox.Text.Length);
                    zilength = ItemNameSearchTextbox.Text.Length;
                }
                else
                {
                    if (ziwarning == true)
                    {
                        zilength = 0;
                        ziholder.RemoveRange(1, ziholder.Count - 1);
                    }
                    zilength2 = zilength;
                    for (int a = 0; a < ItemNameSearchTextbox.Text.Length - zilength2; a++)
                    {
                        ziholder.Add(new List<int>());
                        for (int i = 0; i < ziholder[zilength].Count; i++)
                        {
                            if (itemname[ziholder[zilength][i]].ToUpper().Contains(ItemNameSearchTextbox.Text.Substring(0, zilength + 1).ToUpper()))
                            {
                                ziholder[zilength + 1].Add(ziholder[zilength][i]);
                            }
                        }
                        zilength = zilength + 1;
                    }
                    zholder.Clear();
                    for (int i = 0; i < ziholder[zilength].Count; i++)
                    {
                        zholder.Add(ziholder[zilength][i]);
                        ItemSearchListbox.Items.Add(itemname[ziholder[zilength][i]]);
                    }
                }
                ItemSearchListbox.EndUpdate();
                zisearch = ItemNameSearchTextbox.Text;
                ziwarning = false;
            }
        }

        private void ItemSearchListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadItems();
        }

        private void ReloadItems()
        {
            if (ItemSearchListbox.SelectedIndex != -1)
            {
                ItemDescriptionTextbox.Clear();
                ItemStatsListbox.Items.Clear();
                SetBonusButton.Enabled = false;
                SetBonusButton.Text = "Set Bonus: None";
                setbonuses.Clear();
                if (ItemStatSearchCheckbox.Checked == true)
                {
                    ItemNameSearchTextbox.Text = itemname[zholder[ItemSearchListbox.SelectedIndex]];
                }
                ItemIDSearchTextbox.Text = itemid[zholder[ItemSearchListbox.SelectedIndex]];
                ItemDescriptionTextbox.Text = itemdescription[zholder[ItemSearchListbox.SelectedIndex]];
                if ((itemequipslot[zholder[ItemSearchListbox.SelectedIndex]] != "-1" && itemequipslot[zholder[ItemSearchListbox.SelectedIndex]] != "-2") || itemstatmode == true)
                {
                    ItemStatsListbox.Items.Add("Slot: " + GetEquipmentSlot(itemequipslot[zholder[ItemSearchListbox.SelectedIndex]]));
                }
                if (itemstatmode == true)
                {
                    if (!string.IsNullOrEmpty(itemblockslots[zholder[ItemSearchListbox.SelectedIndex]]))
                    {
                        string blockedslots = null;
                        commasplit = itemblockslots[zholder[ItemSearchListbox.SelectedIndex]].Split(',');
                        for (int i = 0; i < commasplit.Length; i++)
                        {
                            if (i > 0)
                            {
                                blockedslots = blockedslots + ", " + GetEquipmentSlot(commasplit[i]);
                            }
                            else blockedslots = GetEquipmentSlot(commasplit[i]); // comma only added if there is more than one slot
                        }
                        ItemStatsListbox.Items.Add("Blocked Slots: " + blockedslots);
                    }
                    ItemStatsListbox.Items.Add("Subtype: " + GetSubtype(itemsubtype[zholder[ItemSearchListbox.SelectedIndex]]));
                }
                //axe, blunt sword 2h, broom, staff, bow(but not bow?)
                commasplit = itemblockslots[zholder[ItemSearchListbox.SelectedIndex]].Split(',');
                bool twohander = false;
                for (int i = 0; i < commasplit.Length; i++)
                {
                    if (commasplit[i] == "5") twohander = true;
                }
                switch (itemsubtype[zholder[ItemSearchListbox.SelectedIndex]])
                {
                    case "8":
                    case "13":
                    case "14":
                    case "15":
                    case "21":
                        twohander = true;
                        break;
                }
                if (itemequipslot[zholder[ItemSearchListbox.SelectedIndex]] == "0")
                {
                    if (twohander == true) ItemStatsListbox.Items.Add("Two Handed");
                    else ItemStatsListbox.Items.Add("One Handed");
                }
                if (!string.IsNullOrEmpty(itemdamagelist[zholder[ItemSearchListbox.SelectedIndex]]))
                {
                    commasplit = itemdamagelist[zholder[ItemSearchListbox.SelectedIndex]].Split(';');
                    for (int i = 0; i < commasplit.Length; i++)
                    {
                        commasplit2 = commasplit[i].Split('^');
                        switch (commasplit2[0])
                        {
                            case "0":
                                ItemStatsListbox.Items.Add("Piercing Damage: " + commasplit2[1]);
                                break;
                            case "1":
                                ItemStatsListbox.Items.Add("Slashing Damage: " + commasplit2[1]);
                                break;
                            case "2":
                                ItemStatsListbox.Items.Add("Crushing Damage: " + commasplit2[1]);
                                break;
                            case "3":
                                ItemStatsListbox.Items.Add("Heat Damage: " + commasplit2[1]);
                                break;
                            case "4":
                                ItemStatsListbox.Items.Add("Cold Damage: " + commasplit2[1]);
                                break;
                            case "5":
                                ItemStatsListbox.Items.Add("Magic Damage: " + commasplit2[1]);
                                break;
                            case "6":
                                ItemStatsListbox.Items.Add("Poison Damage: " + commasplit2[1]);
                                break;
                            case "7":
                                ItemStatsListbox.Items.Add("Divine Damage: " + commasplit2[1]);
                                break;
                            case "8":
                                ItemStatsListbox.Items.Add("Chaos Damage: " + commasplit2[1]);
                                break;
                            case "9":
                                ItemStatsListbox.Items.Add("True Damage: " + commasplit2[1]);
                                break;
                            case "15":
                                ItemStatsListbox.Items.Add("Fishing Power: " + commasplit2[1]);
                                break;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(itemboosts[zholder[ItemSearchListbox.SelectedIndex]]) && itemstatmode == true)
                {
                    commasplit = itemboosts[zholder[ItemSearchListbox.SelectedIndex]].Split(';');
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
                                        ItemStatsListbox.Items.Add(skillname[skillid.IndexOf(commasplit2[0])] + " Energy: +" + commasplit2[2]); // energy harvest
                                    }
                                    else if (commasplit2[0] == "33" || commasplit2[0] == "128") // taunt and warcry
                                    {
                                        ItemStatsListbox.Items.Add(skillname[skillid.IndexOf(commasplit2[0])] + " Aggro: +" + commasplit2[2]);
                                    }
                                    else if (commasplit2[0] == "197") // rescue
                                    {
                                        ItemStatsListbox.Items.Add(skillname[skillid.IndexOf(commasplit2[0])] + " Boost(?): +" + commasplit2[2]); // might be broken
                                    }
                                    else ItemStatsListbox.Items.Add(skillname[skillid.IndexOf(commasplit2[0])] + " Damage: +" + commasplit2[2]);
                                }
                                else
                                {
                                    if (commasplit2[0] == "145")
                                    {
                                        ItemStatsListbox.Items.Add(skillname[skillid.IndexOf(commasplit2[0])] + " Energy: +" + commasplit2[2].Substring(1, commasplit2[2].Length - 1)); // sacrifice
                                    }
                                    else if (commasplit2[0] == "32" || commasplit2[0] == "34") // calm and distract
                                    {
                                        ItemStatsListbox.Items.Add(skillname[skillid.IndexOf(commasplit2[0])] + " Aggro Drop: +" + commasplit2[2].Substring(1, commasplit2[2].Length - 1));
                                    }
                                    else ItemStatsListbox.Items.Add(skillname[skillid.IndexOf(commasplit2[0])] + " Heal: +" + commasplit2[2].Substring(1, commasplit2[2].Length - 1));
                                }
                                break;
                            case "1":
                                ItemStatsListbox.Items.Add(skillname[skillid.IndexOf(commasplit2[0])] + " Cooldown: -" + commasplit2[2] + "%");
                                break;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(itemattackspeed[zholder[ItemSearchListbox.SelectedIndex]]))
                {
                    ItemStatsListbox.Items.Add("Attack Speed: " + itemattackspeed[zholder[ItemSearchListbox.SelectedIndex]]);
                }
                if (itemstatmode == true)
                {
                    if (!string.IsNullOrEmpty(itemattackrange[zholder[ItemSearchListbox.SelectedIndex]]))
                    {
                        ItemStatsListbox.Items.Add("Attack Range: " + itemattackrange[zholder[ItemSearchListbox.SelectedIndex]]);
                    }
                    if (!string.IsNullOrEmpty(itemmissilespeed[zholder[ItemSearchListbox.SelectedIndex]]))
                    {
                        ItemStatsListbox.Items.Add("Missile Speed: " + itemmissilespeed[zholder[ItemSearchListbox.SelectedIndex]]);
                    }
                }
                if (!string.IsNullOrEmpty(itemstatbonus[zholder[ItemSearchListbox.SelectedIndex]]))
                {
                    commasplit = itemstatbonus[zholder[ItemSearchListbox.SelectedIndex]].Split(';');
                    for (int i = 0; i < commasplit.Length; i++)
                    {
                        commasplit2 = commasplit[i].Split('^');
                        switch (commasplit2[0])
                        {
                            case "0":
                                ItemStatsListbox.Items.Add("Strength: " + commasplit2[1]);
                                break;
                            case "1":
                                ItemStatsListbox.Items.Add("Dexterity: " + commasplit2[1]);
                                break;
                            case "2":
                                ItemStatsListbox.Items.Add("Focus: " + commasplit2[1]);
                                break;
                            case "3":
                                ItemStatsListbox.Items.Add("Vitality: " + commasplit2[1]);
                                break;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(itemskillbonus[zholder[ItemSearchListbox.SelectedIndex]]))
                {
                    commasplit = itemskillbonus[zholder[ItemSearchListbox.SelectedIndex]].Split(';');
                    for (int i = 0; i < commasplit.Length; i++)
                    {
                        commasplit2 = commasplit[i].Split('^');
                        ItemStatsListbox.Items.Add(skillname[skillid.IndexOf(commasplit2[0])] + " skill level: " + commasplit2[1]);
                    }
                }
                if (itemskillid[zholder[ItemSearchListbox.SelectedIndex]] != "0" && itemstatmode == true)
                {
                    ItemStatsListbox.Items.Add("Skill On Use: " + skillname[skillid.IndexOf(itemskillid[zholder[ItemSearchListbox.SelectedIndex]])] + "(Level " + (Convert.ToInt32(itemskilllevel[zholder[ItemSearchListbox.SelectedIndex]]) + 1) + ")");
                }
                if (itemprocskillid[zholder[ItemSearchListbox.SelectedIndex]] != "0")
                {
                    if (itemstatmode == true)
                    {
                        ItemStatsListbox.Items.Add("Proc Skill: " + skillname[skillid.IndexOf(itemprocskillid[zholder[ItemSearchListbox.SelectedIndex]])] + "(Level " + (Convert.ToInt32(itemprocskilllevel[zholder[ItemSearchListbox.SelectedIndex]]) + 1) + ")");
                    }
                    else
                    {
                        ItemStatsListbox.Items.Add("Proc Skill: " + skillname[skillid.IndexOf(itemprocskillid[zholder[ItemSearchListbox.SelectedIndex]])]);
                    }
                    ItemStatsListbox.Items.Add("Proc Chance: " + float.Parse(itemprocskillchance[zholder[ItemSearchListbox.SelectedIndex]]) * 100 + "%");
                    List<int> energylist = new List<int>();
                    if (skilllvid.IndexOf(itemprocskillid[zholder[ItemSearchListbox.SelectedIndex]]) != -1)
                    {
                        for (int i = 0; i < skilllvid.Count; i++)
                        {
                            if (itemprocskillid[zholder[ItemSearchListbox.SelectedIndex]] == skilllvid[i])
                            {
                                energylist.Add(i);
                            }
                        }
                        string amount = "0"; // stores the number so we can ignore it if it doesn't use energy
                        if (energylist.Count > 1 && energylist.Count > Convert.ToInt32(itemprocskilllevel[zholder[ItemSearchListbox.SelectedIndex]])) // make this visible with all information on later
                        {
                            if (skilllvpvp[energylist[1]] == "1")
                            {
                                amount = skilllvenergy[energylist[Convert.ToInt32(itemprocskilllevel[zholder[ItemSearchListbox.SelectedIndex]])] + Convert.ToInt32(itemprocskilllevel[zholder[ItemSearchListbox.SelectedIndex]])];
                            }
                            else amount = skilllvenergy[energylist[Convert.ToInt32(itemprocskilllevel[zholder[ItemSearchListbox.SelectedIndex]])]];
                        }
                        else if (energylist.Count == 1)
                        {
                            amount = skilllvenergy[energylist[0]];
                        }
                        if (Convert.ToInt32(amount) > 0) ItemStatsListbox.Items.Add("Proc Energy Cost: " + amount);
                    }
                }
                if (itemequipskillid[zholder[ItemSearchListbox.SelectedIndex]] != "0")
                {
                    if (itemstatmode == true)
                    {
                        ItemStatsListbox.Items.Add("Gives Skill: " + skillname[skillid.IndexOf(itemequipskillid[zholder[ItemSearchListbox.SelectedIndex]])] + "(Level " + (Convert.ToInt32(itemequipskilllevel[zholder[ItemSearchListbox.SelectedIndex]]) + 1) + ")");
                    }
                    else
                    {
                        ItemStatsListbox.Items.Add("Gives Skill: " + skillname[skillid.IndexOf(itemequipskillid[zholder[ItemSearchListbox.SelectedIndex]])]);
                    }
                }
                if ((itemequipslot[zholder[ItemSearchListbox.SelectedIndex]] != "16" && itemequipslot[zholder[ItemSearchListbox.SelectedIndex]] != "-1" && itemequipslot[zholder[ItemSearchListbox.SelectedIndex]] != "-2") || itemmaxcharges[zholder[ItemSearchListbox.SelectedIndex]] == "-1")
                {
                    if (Convert.ToInt32(itemmaxcharges[zholder[ItemSearchListbox.SelectedIndex]]) > 0) // 0 is not shown
                    {
                        ItemStatsListbox.Items.Add("Max Charges: " + itemmaxcharges[zholder[ItemSearchListbox.SelectedIndex]]);
                        if (itemstatmode == true)
                        {
                            if (itemdestroyonnocharge[zholder[ItemSearchListbox.SelectedIndex]] == "1")
                            {
                                ItemStatsListbox.Items.Add("Destroyed at Zero Charges: Yes");
                            }
                            else ItemStatsListbox.Items.Add("Destroyed at Zero Charges: No");
                        }
                    }
                    else if (Convert.ToInt32(itemmaxcharges[zholder[ItemSearchListbox.SelectedIndex]]) < 0) // under 0 is infinite
                    {
                        ItemStatsListbox.Items.Add("Infinite Uses");
                    }
                }
                if (!string.IsNullOrEmpty(itemstatuses[zholder[ItemSearchListbox.SelectedIndex]]) && itemstatmode == true)
                {
                    commasplit = itemstatuses[zholder[ItemSearchListbox.SelectedIndex]].Split(';');
                    for (int i = 0; i < commasplit.Length; i++)
                    {
                        commasplit2 = commasplit[i].Split('^');
                        ItemStatsListbox.Items.Add("Gives Status: " + statusname[statusid.IndexOf(commasplit2[0])] + "(Level " + (Convert.ToInt32(commasplit2[1]) + 1) + ")");
                    }
                }
                if (!string.IsNullOrEmpty(itemabilitybonus[zholder[ItemSearchListbox.SelectedIndex]]))
                {
                    commasplit = itemabilitybonus[zholder[ItemSearchListbox.SelectedIndex]].Split(';');
                    for (int i = 0; i < commasplit.Length; i++)
                    {
                        commasplit2 = commasplit[i].Split('^');
                        ItemStatsListbox.Items.Add(GetAbility(commasplit2[0]) + ": " + commasplit2[1]);
                    }
                }
                if (itemarmor[zholder[ItemSearchListbox.SelectedIndex]] != "0")
                {
                    ItemStatsListbox.Items.Add("Armour: " + itemarmor[zholder[ItemSearchListbox.SelectedIndex]]);
                }
                if (!string.IsNullOrEmpty(itembonuslist[zholder[ItemSearchListbox.SelectedIndex]]))
                {
                    commasplit = itembonuslist[zholder[ItemSearchListbox.SelectedIndex]].Split(';');
                    for (int i = 0; i < commasplit.Length; i++)
                    {
                        commasplit2 = commasplit[i].Split('^');
                        switch (commasplit2[0])
                        {
                            case "0":
                                ItemStatsListbox.Items.Add("Resist Pierce: " + commasplit2[1]);
                                break;
                            case "1":
                                ItemStatsListbox.Items.Add("Resist Slash: " + commasplit2[1]);
                                break;
                            case "2":
                                ItemStatsListbox.Items.Add("Resist Crush: " + commasplit2[1]);
                                break;
                            case "3":
                                ItemStatsListbox.Items.Add("Resist Heat: " + commasplit2[1]);
                                break;
                            case "4":
                                ItemStatsListbox.Items.Add("Resist Cold: " + commasplit2[1]);
                                break;
                            case "5":
                                ItemStatsListbox.Items.Add("Resist Magic: " + commasplit2[1]);
                                break;
                            case "6":
                                ItemStatsListbox.Items.Add("Resist Poison: " + commasplit2[1]);
                                break;
                            case "7":
                                ItemStatsListbox.Items.Add("Resist Divine: " + commasplit2[1]);
                                break;
                            case "8":
                                ItemStatsListbox.Items.Add("Resist Chaos: " + commasplit2[1]);
                                break;
                            case "9":
                                ItemStatsListbox.Items.Add("Resist True: " + commasplit2[1]);
                                break;
                            case "10":
                                ItemStatsListbox.Items.Add("Attack: " + commasplit2[1]);
                                break;
                            case "11":
                                ItemStatsListbox.Items.Add("Defence: " + commasplit2[1]);
                                break;
                            case "12":
                                ItemStatsListbox.Items.Add("Health: " + commasplit2[1]);
                                break;
                            case "13":
                                ItemStatsListbox.Items.Add("Energy: " + commasplit2[1]);
                                break;
                            case "15":
                                ItemStatsListbox.Items.Add("Resist Fishing: " + commasplit2[1]);
                                break;
                            case "16":
                                ItemStatsListbox.Items.Add("Concentration: " + commasplit2[1]);
                                break;
                        }
                    }
                }
                if (itemstatmode == true)
                {
                    for (int i = 0; i < itemidresistance.Count; i++)
                    {
                        if (itemid[zholder[ItemSearchListbox.SelectedIndex]] == itemidresistance[i])
                        {
                            if (!string.IsNullOrEmpty(itemresistancevalues[i]))
                            {
                                commasplit = itemresistancevalues[i].Split(';');
                                for (int x = 0; x < commasplit.Length; x++)
                                {
                                    commasplit2 = commasplit[x].Split('^');
                                    switch (commasplit2[0])
                                    {
                                        case "0":
                                            ItemStatsListbox.Items.Add("Pierce Damage Reduction: " + float.Parse(commasplit2[1]) * 100 + "%");
                                            break;
                                        case "1":
                                            ItemStatsListbox.Items.Add("Slash Damage Reduction: " + float.Parse(commasplit2[1]) * 100 + "%");
                                            break;
                                        case "2":
                                            ItemStatsListbox.Items.Add("Crush Damage Reduction: " + float.Parse(commasplit2[1]) * 100 + "%");
                                            break;
                                        case "3":
                                            ItemStatsListbox.Items.Add("Heat Damage Reduction: " + float.Parse(commasplit2[1]) * 100 + "%");
                                            break;
                                        case "4":
                                            ItemStatsListbox.Items.Add("Cold Damage Reduction: " + float.Parse(commasplit2[1]) * 100 + "%");
                                            break;
                                        case "5":
                                            ItemStatsListbox.Items.Add("Magic Damage Reduction: " + float.Parse(commasplit2[1]) * 100 + "%");
                                            break;
                                        case "6":
                                            ItemStatsListbox.Items.Add("Poison Damage Reduction: " + float.Parse(commasplit2[1]) * 100 + "%");
                                            break;
                                        case "7":
                                            ItemStatsListbox.Items.Add("Divine Damage Reduction: " + float.Parse(commasplit2[1]) * 100 + "%");
                                            break;
                                        case "8":
                                            ItemStatsListbox.Items.Add("Chaos Damage Reduction: " + float.Parse(commasplit2[1]) * 100 + "%");
                                            break;
                                        case "9":
                                            ItemStatsListbox.Items.Add("True Damage Reduction: " + float.Parse(commasplit2[1]) * 100 + "%");
                                            break;
                                        case "15":
                                            ItemStatsListbox.Items.Add("Fishing Damage Reduction: " + float.Parse(commasplit2[1]) * 100 + "%");
                                            break;
                                    }
                                }
                            }
                        }
                    }
                    for (int i = 0; i < itemidimmunity.Count; i++)
                    {
                        if (itemid[zholder[ItemSearchListbox.SelectedIndex]] == itemidimmunity[i])
                        {
                            if (!string.IsNullOrEmpty(itemimmunityvalues[i]))
                            {
                                commasplit = itemimmunityvalues[i].Split(';');
                                for (int x = 0; x < commasplit.Length; x++)
                                {
                                    commasplit2 = commasplit[x].Split('^');
                                    switch (commasplit2[0])
                                    {
                                        case "0":
                                            ItemStatsListbox.Items.Add("Pierce Immunity Chance: " + float.Parse(commasplit2[1]) * 100 + "%");
                                            break;
                                        case "1":
                                            ItemStatsListbox.Items.Add("Slash Immunity Chance: " + float.Parse(commasplit2[1]) * 100 + "%");
                                            break;
                                        case "2":
                                            ItemStatsListbox.Items.Add("Crush Immunity Chance: " + float.Parse(commasplit2[1]) * 100 + "%");
                                            break;
                                        case "3":
                                            ItemStatsListbox.Items.Add("Heat Immunity Chance: " + float.Parse(commasplit2[1]) * 100 + "%");
                                            break;
                                        case "4":
                                            ItemStatsListbox.Items.Add("Cold Immunity Chance: " + float.Parse(commasplit2[1]) * 100 + "%");
                                            break;
                                        case "5":
                                            ItemStatsListbox.Items.Add("Magic Immunity Chance: " + float.Parse(commasplit2[1]) * 100 + "%");
                                            break;
                                        case "6":
                                            ItemStatsListbox.Items.Add("Poison Immunity Chance: " + float.Parse(commasplit2[1]) * 100 + "%");
                                            break;
                                        case "7":
                                            ItemStatsListbox.Items.Add("Divine Immunity Chance: " + float.Parse(commasplit2[1]) * 100 + "%");
                                            break;
                                        case "8":
                                            ItemStatsListbox.Items.Add("Chaos Immunity Chance: " + float.Parse(commasplit2[1]) * 100 + "%");
                                            break;
                                        case "9":
                                            ItemStatsListbox.Items.Add("True Immunity Chance: " + float.Parse(commasplit2[1]) * 100 + "%");
                                            break;
                                        case "15":
                                            ItemStatsListbox.Items.Add("Fishing Immunity Chance: " + float.Parse(commasplit2[1]) * 100 + "%");
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
                if (!string.IsNullOrEmpty(itemevasionlist[zholder[ItemSearchListbox.SelectedIndex]]))
                {
                    commasplit = itemevasionlist[zholder[ItemSearchListbox.SelectedIndex]].Split(';');
                    for (int i = 0; i < commasplit.Length; i++)
                    {
                        commasplit2 = commasplit[i].Split('^');
                        switch (commasplit2[0])
                        {
                            case "0":
                                ItemStatsListbox.Items.Add("Physical Attack Evasion: " + commasplit2[1]);
                                break;
                            case "1":
                                ItemStatsListbox.Items.Add("Spell Attack Evasion: " + commasplit2[1]);
                                break;
                            case "2":
                                ItemStatsListbox.Items.Add("Movement Attack Evasion: " + commasplit2[1]);
                                break;
                            case "3":
                                ItemStatsListbox.Items.Add("Wounding Attack Evasion: " + commasplit2[1]);
                                break;
                            case "4":
                                ItemStatsListbox.Items.Add("Weakening Attack Evasion: " + commasplit2[1]);
                                break;
                            case "5":
                                ItemStatsListbox.Items.Add("Mental Attack Evasion: " + commasplit2[1]);
                                break;
                        }
                    }
                }
                if (itembindonequip[zholder[ItemSearchListbox.SelectedIndex]] == "1")
                {
                    ItemStatsListbox.Items.Add("Binds on Equip");
                }
                if (itemnotrade[zholder[ItemSearchListbox.SelectedIndex]] == "1")
                {
                    ItemStatsListbox.Items.Add("NO TRADE");
                }
                if (itemimportantitem[zholder[ItemSearchListbox.SelectedIndex]] == "1")
                {
                    ItemStatsListbox.Items.Add("Important Item");
                }
                if (!string.IsNullOrEmpty(itemclasslist[zholder[ItemSearchListbox.SelectedIndex]]))
                {
                    commasplit = itemclasslist[zholder[ItemSearchListbox.SelectedIndex]].Split(',');
                    for (int i = 0; i < commasplit.Length; i++)
                    {
                        switch (commasplit[i])
                        {
                            case "1":
                                ItemStatsListbox.Items.Add("Class required: Warrior");
                                break;
                            case "2":
                                ItemStatsListbox.Items.Add("Class required: Druid");
                                break;
                            case "3":
                                ItemStatsListbox.Items.Add("Class required: Mage");
                                break;
                            case "4":
                                ItemStatsListbox.Items.Add("Class required: Ranger");
                                break;
                            case "5":
                                ItemStatsListbox.Items.Add("Class required: Rogue");
                                break;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(itemrequirementlist[zholder[ItemSearchListbox.SelectedIndex]]))
                {
                    commasplit = itemrequirementlist[zholder[ItemSearchListbox.SelectedIndex]].Split(';');
                    for (int i = 0; i < commasplit.Length; i++)
                    {
                        commasplit2 = commasplit[i].Split('^');
                        switch (commasplit2[0])
                        {
                            case "0":
                                ItemStatsListbox.Items.Add("Strength Requirement: " + commasplit2[1]);
                                break;
                            case "1":
                                ItemStatsListbox.Items.Add("Dexterity Requirement: " + commasplit2[1]);
                                break;
                            case "2":
                                ItemStatsListbox.Items.Add("Focus Requirement: " + commasplit2[1]);
                                break;
                            case "3":
                                ItemStatsListbox.Items.Add("Vitality Requirement: " + commasplit2[1]);
                                break;
                            case "4":
                                if (commasplit2[1] == "1")
                                {
                                    ItemStatsListbox.Items.Add("Male only");
                                }
                                else if (commasplit2[1] == "2")
                                {
                                    ItemStatsListbox.Items.Add("Female only");
                                }
                                break;
                            case "5":
                                if (itemsubtype[zholder[ItemSearchListbox.SelectedIndex]] == "54" || itemsubtype[zholder[ItemSearchListbox.SelectedIndex]] == "59")
                                {
                                    ItemStatsListbox.Items.Add("Level Requirement (fishing): " + commasplit2[1]);
                                }
                                else if (itemsubtype[zholder[ItemSearchListbox.SelectedIndex]] == "66")
                                {
                                    ItemStatsListbox.Items.Add("Level Requirement (cooking): " + commasplit2[1]);
                                }
                                else
                                {
                                    ItemStatsListbox.Items.Add("Level Requirement: " + commasplit2[1]);
                                }
                                break;
                        }
                    }
                }
                if (itemweight[zholder[ItemSearchListbox.SelectedIndex]] != "0")
                {
                    ItemStatsListbox.Items.Add("Weight: " + itemweight[zholder[ItemSearchListbox.SelectedIndex]]);
                }
                if (itemstatmode == true)
                {
                    if (!string.IsNullOrEmpty(itemcooldown[zholder[ItemSearchListbox.SelectedIndex]]))
                    {
                        ItemStatsListbox.Items.Add("Item Cooldown: " + itemcooldown[zholder[ItemSearchListbox.SelectedIndex]] + "s");
                    }
                    if (itemstackable[zholder[ItemSearchListbox.SelectedIndex]] == "1")
                    {
                        ItemStatsListbox.Items.Add("Stackable: Yes");
                    }
                    else ItemStatsListbox.Items.Add("Stackable: No");
                    if (!string.IsNullOrEmpty(itembuy[zholder[ItemSearchListbox.SelectedIndex]]))
                    {
                        ItemStatsListbox.Items.Add("Buy Price: " + itembuy[zholder[ItemSearchListbox.SelectedIndex]]);
                    }
                    if (!string.IsNullOrEmpty(itemsell[zholder[ItemSearchListbox.SelectedIndex]]))
                    {
                        ItemStatsListbox.Items.Add("Sell Price: " + itemsell[zholder[ItemSearchListbox.SelectedIndex]]);
                    }
                }
                for (int i = 0; i < itemsetitemid.Count; i++)
                {
                    if (itemsetitemid[i] == itemid[zholder[ItemSearchListbox.SelectedIndex]] && setbonuses.Contains(itemsetid[i]) == false)
                    {
                        setbonuses.Add(itemsetid[i]);
                    }
                }
                if (setbonuses.Count == 1)
                {
                    SetBonusButton.Text = "Set Bonus: " + itemname[itemid.IndexOf(itemsetrewarditemid[itemsetrewardid.IndexOf(setbonuses[0])])];
                    SetBonusButton.Enabled = true;
                }
                else if (setbonuses.Count > 1)
                {
                    SetBonusButton.Text = "Set Bonus: " + setbonuses.Count + " Set Bonuses Found";
                    SetBonusButton.Enabled = true;
                }
            }
            else
            {
                ItemDescriptionTextbox.Clear();
                ItemStatsListbox.Items.Clear();
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
                    return "Error"; // shouldnt happen
            }
        }

        private string GetSubtype(string idindex)
        {
            switch (idindex)
            {
                case "0":
                    return "None";
                case "1":
                    return "Sword";
                case "2":
                    return "Axe";
                case "3":
                    return "Blunt";
                case "4":
                    return "Cloth";
                case "5":
                    return "Leather";
                case "6":
                    return "Chain";
                case "7":
                    return "Plate";
                case "8":
                    return "Staff";
                case "9":
                    return "Dagger";
                case "10":
                    return "Wand";
                case "11":
                    return "Bow";
                case "12":
                    return "Shield";
                case "13":
                    return "2H Sword";
                case "14":
                    return "2H Axe";
                case "15":
                    return "2H Blunt";
                case "16":
                    return "Quiver";
                case "17":
                    return "Offhand Dagger";
                case "18":
                    return "Offhand Sword";
                case "19":
                    return "Spear";
                case "20":
                    return "Totem";
                case "21":
                    return "Broom";
                case "22":
                    return "Sled";
                case "23":
                    return "Hand to Hand";
                case "24":
                    return "Fashion";
                case "25":
                    return "Jewelry";
                case "26":
                    return "Carpet";
                case "27":
                    return "Novelty Broom";
                case "28":
                    return "Novelty Wand";
                case "29":
                    return "Lute";
                case "30":
                    return "Dragonstaff";
                case "31":
                    return "Flute";
                case "32":
                    return "Harp";
                case "33":
                    return "2H Novelty";
                case "34":
                    return "Novelty Staff Mount";
                case "35":
                    return "Horn";
                case "36":
                    return "Novelty Blunt";
                case "37":
                    return "Bat Mount";
                case "38":
                    return "Wings";
                case "39":
                    return "Drum";
                case "40":
                    return "Bagpipes";
                case "41":
                    return "Eagle Mount";
                case "42":
                    return "Test";
                case "43":
                    return "Crow";
                case "44":
                    return "Sparrow";
                case "45":
                    return "Sparrowhawk";
                case "46":
                    return "Cape";
                case "47":
                    return "Horse";
                case "48":
                    return "Banshee Blade";
                case "49":
                    return "Samhain Crow";
                case "50":
                    return "Samhain Wings";
                case "51":
                    return "Play Dead";
                case "52":
                    return "Banner";
                case "53":
                    return "Boar";
                case "54":
                    return "Fishing Rod";
                case "55":
                    return "Long Totem";
                case "56":
                    return "Offhand Book";
                case "57":
                    return "2H Spear";
                case "58":
                    return "Pet Food";
                case "59":
                    return "Fishing Item";
                case "60":
                    return "Token";
                case "61":
                    return "Consumable";
                case "62":
                    return "Battlemount";
                case "63":
                    return "Battlemount Wand";
                case "64":
                    return "Battlemount Bow";
                case "65":
                    return "Battlemount Unarmed";
                case "66":
                    return "Cooking";
                default:
                    return "Error"; // shouldnt happen
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
                    return "Error"; // shouldnt happen
            }
        }

        private void ItemDescriptionTextbox_TextChanged(object sender, EventArgs e)
        {
            if (ItemDescriptionTextbox.Text.Split('\n').Length > 6)
            {
                ItemDescriptionTextbox.ScrollBars = ScrollBars.Vertical;
            }
            else
            {
                ItemDescriptionTextbox.ScrollBars = ScrollBars.None;
            }
        }

        private void ItemDisplayModeButton_Click(object sender, EventArgs e)
        {
            if (itemstatmode == true)
            {
                itemstatmode = false;
                ItemDisplayModeButton.Text = "Display Mode: In-Game Stats Only";
                ReloadItems();
            }
            else
            {
                itemstatmode = true;
                ItemDisplayModeButton.Text = "Display Mode: Extended Stats";
                ReloadItems();
            }
        }

        private void SetBonusButton_Click(object sender, EventArgs e)
        {
            ItemSetDisplay SetBonusDisplay = new ItemSetDisplay();
            SetBonusDisplay.Show();
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

        private void ItemStatSearchCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (ItemStatSearchCheckbox.Checked == true)
            {
                ItemSearchLabel.Enabled = false;
                ItemSearchByNameLabel.Enabled = false;
                ItemSearchByIDLabel.Enabled = false;
                ItemNameSearchTextbox.Enabled = false;
                ItemIDSearchTextbox.Enabled = false;
                ItemIDSearchButton.Enabled = false;
                nameskip3 = true;
                ItemNameSearchTextbox.Text = "";
                nameskip3 = false;
                ItemIDSearchTextbox.Text = "";
                ItemAdvancedSearchButton.Enabled = true;
                ItemSearchListbox.Items.Clear();
                ItemDescriptionTextbox.Clear();
                ItemStatsListbox.Items.Clear();
                zholder.Clear();
            }
            else
            {
                ItemSearchLabel.Enabled = true;
                ItemSearchByNameLabel.Enabled = true;
                ItemSearchByIDLabel.Enabled = true;
                ItemNameSearchTextbox.Enabled = true;
                ItemIDSearchTextbox.Enabled = true;
                ItemIDSearchButton.Enabled = true;
                nameskip3 = true;
                ItemNameSearchTextbox.Text = "";
                nameskip3 = false;
                ItemIDSearchTextbox.Text = "";
                ItemAdvancedSearchButton.Enabled = false;
                ItemSearchListbox.Items.Clear();
                ItemDescriptionTextbox.Clear();
                ItemStatsListbox.Items.Clear();
                zholder.Clear();
            }
        }

        private void ItemAdvancedSearchButton_Click(object sender, EventArgs e)
        {
            ItemSearchListbox.Items.Clear();
            ItemDescriptionTextbox.Clear();
            ItemStatsListbox.Items.Clear();
            zholder.Clear();
            AdvancedSearch.ShowDialog();
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            ItemSearchListbox.BeginUpdate();
            for (int x = 0; x < zholder.Count; x++)
            {
                ItemSearchListbox.Items.Add(itemname[zholder[x]]);
            }
            ItemSearchListbox.EndUpdate();
            if (zholder.Count > 0)
            {
                ItemAdvancedSearchButton.Text = "Advanced Search: Active";
            }
            else ItemAdvancedSearchButton.Text = "Advanced Search: Inactive";
        }

        private void ItemIDSearchButton_Click(object sender, EventArgs e)
        {
            ItemSearchListbox.Items.Clear();
            zholder.Clear();
            int x = itemid.IndexOf(ItemIDSearchTextbox.Text);
            if (x != -1)
            {
                nameskip3 = true;
                ItemNameSearchTextbox.Text = "";
                nameskip3 = false;
                ziwarning = true;
                ItemNameSearchTextbox.Text = itemname[x];
                for (int y = 0; y < zholder.Count; y++)
                {
                    if (itemid[zholder[y]] == itemid[x])
                    {
                        ItemSearchListbox.SelectedIndex = y;
                    }
                }
            }
            else
            {
                string message = "Invalid ID";
                string title = "Error";
                MessageBox.Show(message, title);
                Thread.CurrentThread.CurrentCulture = ci;
                Thread.CurrentThread.CurrentUICulture = ci;
            }
        }
    }
}
