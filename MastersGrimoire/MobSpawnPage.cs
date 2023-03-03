using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HeroesAgeBestiary
{
    public partial class MobSpawnPage : Form
    {
        public static int numerator = 0;
        public static int denominator = 0;

        bool checkignore = false;

        double percentx;
        double percenty;
        List<Image> uneditedmaps = new List<Image>();
        Image editedmap;
        List<string> zoneid = new List<string>();
        List<string> minx = new List<string>();
        List<string> maxx = new List<string>();
        List<string> minz = new List<string>();
        List<string> maxz = new List<string>();
        double pixelvaluex;
        double pixelvaluez;
        List<string> uneditedname = new List<string>();
        string[] zonesplit;
        string[] zones = File.ReadAllLines(@"Resources\Database\zones.txt");

        List<string> spawnidmob = new List<string>();
        List<string> zoneidmob = new List<string>();
        List<string> respawntimemob = new List<string>();
        List<string> spawnxmob = new List<string>();
        List<string> spawnymob = new List<string>();
        List<string> spawnzmob = new List<string>();
        List<string> patrolmob = new List<string>();
        List<string> moblistmob = new List<string>();
        List<string> patrolspeedmob = new List<string>();
        List<string> spawnanglemob = new List<string>();
        string[] mobspawnsplitcomma;
        string[] mobspawnsplitquote;
        string[] mobspawnsplitquote2;
        string[] mobspawn = File.ReadAllLines(@"Resources\Database\spawnpoints.txt");
        string mobselected = MainForm.mobidcross;
        bool breaker = false;
        List<int> zoneselectedmobcount = new List<int>();
        int zonesave = 0;
        List<int> spawnidselectedmobs = new List<int>();
        int spawnidselected;
        List<int> spawnidzonemobs = new List<int>();
        float weightadding;
        List<float> weighthold = new List<float>();
        List<string> nameholder = new List<string>();
        int spawntangle;
        int spawntangle2;
        bool selecteddot;
        bool spawnhasmob;
        List<string> mobsinspawn = new List<string>();

        Bitmap bmp;
        List<Rectangle> spawnrectangles = new List<Rectangle>();
        List<Point> polypoints = new List<Point>();
        Rectangle radirectangle;
        List<Rectangle> dotlist = new List<Rectangle>();
        List<int> dottype = new List<int>();
        Pen penselected;
        Pen penmob;
        Pen penunrelated;
        Brush brushselected;
        Brush brushmob;
        Brush brushunrelated;
        int selectedred;
        int selectedgreen;
        int selectedblue;
        int mobred;
        int mobgreen;
        int mobblue;
        int unrelatedred;
        int unrelatedgreen;
        int unrelatedblue;
        string setread = File.ReadAllText(@"Resources\Settings\spawnpage.txt");
        string[] settings;

        MainForm mainscreen;
        public MobSpawnPage(MainForm mainpage)
        {
            InitializeComponent();
            mainscreen = mainpage;
            for (int i = 0; i < zones.Length; i++)
            {
                zonesplit = zones[i].Split('~');
                zoneid.Add(zonesplit[0]);
                uneditedmaps.Add(Image.FromFile(@"Resources\Maps\" + zonesplit[2]));
                uneditedname.Add(zonesplit[1]);
                zoneselectedmobcount.Add(0);
                minx.Add(zonesplit[3]);
                maxx.Add(zonesplit[4]);
                minz.Add(zonesplit[5]);
                maxz.Add(zonesplit[6]);
            }
            for (int i = 0; i < mobspawn.Length; i++)
            {
                mobspawnsplitcomma = mobspawn[i].Split('~');
                spawnidmob.Add(mobspawnsplitcomma[0]);
                zoneidmob.Add(mobspawnsplitcomma[1]);
                respawntimemob.Add(mobspawnsplitcomma[2]);
                spawnxmob.Add(mobspawnsplitcomma[3]);
                spawnymob.Add(mobspawnsplitcomma[4]);
                spawnzmob.Add(mobspawnsplitcomma[5]);
                patrolmob.Add(mobspawnsplitcomma[6]);
                moblistmob.Add(mobspawnsplitcomma[7]);
                patrolspeedmob.Add(mobspawnsplitcomma[8]);
                spawnanglemob.Add(mobspawnsplitcomma[9]);
            }
            settings = setread.Split('~');
            if (settings[0] == "1") ShowPercent.Checked = true;
            if (settings[1] == "1") ShowFraction.Checked = true;
            if (settings[2] == "1") ShowOtherSpawns.Checked = true;
            if (settings[3] == "1") ShowMovementPaths.Checked = true;
            penselected = new Pen(Color.FromArgb(Convert.ToInt32(settings[4]), Convert.ToInt32(settings[5]), Convert.ToInt32(settings[6])), 1);
            brushselected = new SolidBrush(Color.FromArgb(Convert.ToInt32(settings[4]), Convert.ToInt32(settings[5]), Convert.ToInt32(settings[6])));
            SelectedSpawnColor.BackColor = Color.FromArgb(Convert.ToInt32(settings[4]), Convert.ToInt32(settings[5]), Convert.ToInt32(settings[6]));
            penmob = new Pen(Color.FromArgb(Convert.ToInt32(settings[7]), Convert.ToInt32(settings[8]), Convert.ToInt32(settings[9])), 1);
            brushmob = new SolidBrush(Color.FromArgb(Convert.ToInt32(settings[7]), Convert.ToInt32(settings[8]), Convert.ToInt32(settings[9])));
            ContainsMobColor.BackColor = Color.FromArgb(Convert.ToInt32(settings[7]), Convert.ToInt32(settings[8]), Convert.ToInt32(settings[9]));
            penunrelated = new Pen(Color.FromArgb(Convert.ToInt32(settings[10]), Convert.ToInt32(settings[11]), Convert.ToInt32(settings[12])), 1);
            brushunrelated = new SolidBrush(Color.FromArgb(Convert.ToInt32(settings[10]), Convert.ToInt32(settings[11]), Convert.ToInt32(settings[12])));
            OtherSpawnsColor.BackColor = Color.FromArgb(Convert.ToInt32(settings[10]), Convert.ToInt32(settings[11]), Convert.ToInt32(settings[12]));
            selectedred = Convert.ToInt32(settings[4]);
            selectedgreen = Convert.ToInt32(settings[5]);
            selectedblue = Convert.ToInt32(settings[6]);
            mobred = Convert.ToInt32(settings[7]);
            mobgreen = Convert.ToInt32(settings[8]);
            mobblue = Convert.ToInt32(settings[9]);
            unrelatedred = Convert.ToInt32(settings[10]);
            unrelatedgreen = Convert.ToInt32(settings[11]);
            unrelatedblue = Convert.ToInt32(settings[12]);
            breaker = false;
            for (int x = 0; x < moblistmob.Count; x++)
            {
                mobspawnsplitcomma = mobspawn[x].Split('~');
                mobspawnsplitquote = mobspawnsplitcomma[7].Split('|', ';');
                for (int i = 0; i < mobspawnsplitquote.Length; i = i + 2)
                {
                    if (mobspawnsplitquote[i] == mobselected)
                    {
                        for (int z = 0; z < zoneid.Count; z++)
                        {
                            if (breaker == false)
                            {
                                if (zoneid[z] == zoneidmob[x])
                                {
                                    MobSelectedLabel.Text = "Mob Selected: " + MainForm.mobname[MainForm.mobid.IndexOf(mobselected)] + "[" + MainForm.mobid[MainForm.mobid.IndexOf(mobselected)] + "]";
                                    spawnidselectedmobs.Add(x);
                                    spawnidselected = x;
                                    zoneselectedmobcount[z] = zoneselectedmobcount[z] + 1;
                                    zonesave = z;
                                    breaker = true;
                                }
                            }
                            else
                            {
                                if (zoneid[z] == zoneidmob[x])
                                {
                                    spawnidselectedmobs.Add(x);
                                    zoneselectedmobcount[z] = zoneselectedmobcount[z] + 1;
                                }
                            }
                        }
                    }
                }
            }
            for (int x = 0; x < zoneselectedmobcount.Count; x++)
            {
                if (zoneselectedmobcount[x] == 1)
                {
                    CurrentZoneSelected.Items.Add(uneditedname[x] + " (" + zoneselectedmobcount[x] + " Spawn)");
                }
                else if (zoneselectedmobcount[x] > 1)
                {
                    CurrentZoneSelected.Items.Add(uneditedname[x] + " (" + zoneselectedmobcount[x] + " Spawns)");
                }
                else
                {
                    CurrentZoneSelected.Items.Add(uneditedname[x]);
                }
            }
            if (breaker == false)
            {
                CurrentZoneSelected.SelectedIndex = 0;
            }
            else
            {
                CurrentZoneSelected.SelectedIndex = zonesave;
            }
            if (spawnidselectedmobs.Count > 0)
            {
                MobSpawnNumber.Text = "Spawn (1 of " + spawnidselectedmobs.Count + ")";
            }
            else
            {
                MobSpawnNumber.Text = "Spawn (0 of 0)";
            }
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        static int GCD(int[] numbers)
        {
            return numbers.Aggregate(GCD);
        }

        static int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        private void ReloadDrawing(int height, int width, int loadmode)
        {
            SpawnPointSelected.Text = "Spawn Point Selected:";
            SpawnLocation.Text = "Spawn Location:";
            MovementType.Text = "Movement Type:";
            RespawnTime.Text = "Respawn Time:";
            SpawnPointMobRoute.Items.Clear();
            PossibleMobSpawns.Items.Clear();
            SwitchMobButton.Enabled = false;
            selecteddot = false;
            spawnidzonemobs.Clear();
            spawnrectangles.Clear();
            dotlist.Clear();
            dottype.Clear();
            if (loadmode == 1)
            {
                if (Zoom1.Enabled == false)
                {
                    editedmap = ResizeImage(uneditedmaps[CurrentZoneSelected.SelectedIndex], 512, 512);
                    width = 512;
                    height = 512;
                }
                if (Zoom15.Enabled == false)
                {
                    editedmap = ResizeImage(uneditedmaps[CurrentZoneSelected.SelectedIndex], 768, 768);
                    width = 768;
                    height = 768;
                }
                if (Zoom2.Enabled == false)
                {
                    editedmap = ResizeImage(uneditedmaps[CurrentZoneSelected.SelectedIndex], 1024, 1024);
                    width = 1024;
                    height = 1024;
                }
                if (Zoom3.Enabled == false)
                {
                    editedmap = ResizeImage(uneditedmaps[CurrentZoneSelected.SelectedIndex], 1536, 1536);
                    width = 1536;
                    height = 1536;
                }
                if (Zoom4.Enabled == false)
                {
                    editedmap = ResizeImage(uneditedmaps[CurrentZoneSelected.SelectedIndex], 2048, 2048);
                    width = 2048;
                    height = 2048;
                }
                if (Zoom6.Enabled == false)
                {
                    editedmap = ResizeImage(uneditedmaps[CurrentZoneSelected.SelectedIndex], 3072, 3072);
                    width = 3072;
                    height = 3072;
                }
                if (Zoom8.Enabled == false)
                {
                    editedmap = ResizeImage(uneditedmaps[CurrentZoneSelected.SelectedIndex], 4096, 4096);
                    width = 4096;
                    height = 4096;
                }
            }
            editedmap = ResizeImage(uneditedmaps[CurrentZoneSelected.SelectedIndex], width, height);
            pixelvaluex = (double)editedmap.Width / (float.Parse(maxx[CurrentZoneSelected.SelectedIndex]) - float.Parse(minx[CurrentZoneSelected.SelectedIndex]));
            pixelvaluez = (double)editedmap.Height / (float.Parse(maxz[CurrentZoneSelected.SelectedIndex]) - float.Parse(minz[CurrentZoneSelected.SelectedIndex]));
            bmp = new Bitmap(editedmap);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                if (ShowOtherSpawns.Checked == true)
                {
                    for (int x = 0; x < zoneidmob.Count; x++)
                    {
                        if (zoneidmob[x] == zoneid[CurrentZoneSelected.SelectedIndex])
                        {
                            for (int y = 0; y < spawnidselectedmobs.Count; y++)
                            {
                                if (spawnidselectedmobs[y] != x)
                                {
                                    if (ShowMovementPaths.Checked == true)
                                    {
                                        mobspawnsplitquote = patrolmob[x].Split(' ');
                                        if (mobspawnsplitquote[0] == "random")
                                        {
                                            radirectangle = new Rectangle((int)((float.Parse(spawnxmob[x]) - float.Parse(minx[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluex) - (int)(float.Parse(mobspawnsplitquote[1]) * (double)pixelvaluex), (int)(((float.Parse(spawnzmob[x]) * -1) + float.Parse(maxz[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluez) - (int)(float.Parse(mobspawnsplitquote[1]) * (double)pixelvaluez), (int)(float.Parse(mobspawnsplitquote[1]) * (double)pixelvaluex) * 2, (int)(float.Parse(mobspawnsplitquote[1]) * (double)pixelvaluez) * 2);
                                            g.DrawEllipse(penunrelated, radirectangle);
                                        }
                                        else if (mobspawnsplitquote[0] == "patrol")
                                        {
                                            polypoints.Clear();
                                            mobspawnsplitquote2 = mobspawnsplitquote[1].Split('|', ';');
                                            polypoints.Add(new Point((int)((float.Parse(spawnxmob[x]) - float.Parse(minx[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluex), (int)(((float.Parse(spawnzmob[x]) * -1) + float.Parse(maxz[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluez)));
                                            for (int i = 0; i < mobspawnsplitquote2.Length; i = i + 4)
                                            {
                                                polypoints.Add(new Point((int)((float.Parse(mobspawnsplitquote2[i]) - float.Parse(minx[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluex), (int)(((float.Parse(mobspawnsplitquote2[i + 2]) * -1) + float.Parse(maxz[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluez)));
                                            }
                                            g.DrawPolygon(penunrelated, polypoints.ToArray());
                                        }
                                    }
                                    spawnidzonemobs.Add(x);
                                    spawnrectangles.Add(new Rectangle((int)((float.Parse(spawnxmob[x]) - float.Parse(minx[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluex) - 2, (int)(((float.Parse(spawnzmob[x]) * -1) + float.Parse(maxz[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluez) - 2, 5, 5));
                                    dotlist.Add(new Rectangle((int)((float.Parse(spawnxmob[x]) - float.Parse(minx[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluex) - 1, (int)(((float.Parse(spawnzmob[x]) * -1) + float.Parse(maxz[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluez) - 1, 3, 3));
                                    dottype.Add(0);
                                    break;
                                }
                            }
                        }
                    }
                }
                for (int x = 0; x < zoneidmob.Count; x++)
                {
                    if (zoneidmob[x] == zoneid[CurrentZoneSelected.SelectedIndex])
                    {
                        for (int y = 0; y < spawnidselectedmobs.Count; y++)
                        {
                            if (spawnidselectedmobs[y] == x && spawnidselected != x)
                            {
                                if (ShowMovementPaths.Checked == true)
                                {
                                    mobspawnsplitquote = patrolmob[x].Split(' ');
                                    if (mobspawnsplitquote[0] == "random")
                                    {
                                        radirectangle = new Rectangle((int)((float.Parse(spawnxmob[x]) - float.Parse(minx[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluex) - (int)(float.Parse(mobspawnsplitquote[1]) * (double)pixelvaluex), (int)(((float.Parse(spawnzmob[x]) * -1) + float.Parse(maxz[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluez) - (int)(float.Parse(mobspawnsplitquote[1]) * (double)pixelvaluez), (int)(float.Parse(mobspawnsplitquote[1]) * (double)pixelvaluex) * 2, (int)(float.Parse(mobspawnsplitquote[1]) * (double)pixelvaluez) * 2);
                                        g.DrawEllipse(penmob, radirectangle);
                                    }
                                    else if (mobspawnsplitquote[0] == "patrol")
                                    {
                                        polypoints.Clear();
                                        mobspawnsplitquote2 = mobspawnsplitquote[1].Split('|', ';');
                                        polypoints.Add(new Point((int)((float.Parse(spawnxmob[x]) - float.Parse(minx[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluex), (int)(((float.Parse(spawnzmob[x]) * -1) + float.Parse(maxz[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluez)));
                                        for (int i = 0; i < mobspawnsplitquote2.Length; i = i + 4)
                                        {
                                            polypoints.Add(new Point((int)((float.Parse(mobspawnsplitquote2[i]) - float.Parse(minx[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluex), (int)(((float.Parse(mobspawnsplitquote2[i + 2]) * -1) + float.Parse(maxz[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluez)));
                                        }
                                        g.DrawPolygon(penmob, polypoints.ToArray());
                                    }
                                }
                                spawnidzonemobs.Add(x);
                                spawnrectangles.Add(new Rectangle((int)((float.Parse(spawnxmob[x]) - float.Parse(minx[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluex) - 2, (int)(((float.Parse(spawnzmob[x]) * -1) + float.Parse(maxz[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluez) - 2, 5, 5));
                                dotlist.Add(new Rectangle((int)((float.Parse(spawnxmob[x]) - float.Parse(minx[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluex) - 1, (int)(((float.Parse(spawnzmob[x]) * -1) + float.Parse(maxz[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluez) - 1, 3, 3));
                                dottype.Add(1);
                                break;
                            }
                        }
                    }
                }
                int[] numerators = null;
                for (int x = 0; x < zoneidmob.Count; x++)
                {
                    if (zoneidmob[x] == zoneid[CurrentZoneSelected.SelectedIndex])
                    {
                        for (int y = 0; y < spawnidselectedmobs.Count; y++)
                        {
                            if (spawnidselected == x)
                            {
                                weightadding = 0;
                                weighthold.Clear();
                                nameholder.Clear();
                                mobsinspawn.Clear();
                                SpawnPointMobRoute.Items.Clear();
                                PossibleMobSpawns.Items.Clear();
                                if (ShowMovementPaths.Checked == true)
                                {
                                    mobspawnsplitquote = patrolmob[x].Split(' ');
                                    if (mobspawnsplitquote[0] == "random")
                                    {
                                        radirectangle = new Rectangle((int)((float.Parse(spawnxmob[x]) - float.Parse(minx[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluex) - (int)(float.Parse(mobspawnsplitquote[1]) * (double)pixelvaluex), (int)(((float.Parse(spawnzmob[x]) * -1) + float.Parse(maxz[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluez) - (int)(float.Parse(mobspawnsplitquote[1]) * (double)pixelvaluez), (int)(float.Parse(mobspawnsplitquote[1]) * (double)pixelvaluex) * 2, (int)(float.Parse(mobspawnsplitquote[1]) * (double)pixelvaluez) * 2);
                                        g.DrawEllipse(penselected, radirectangle);
                                    }
                                    else if (mobspawnsplitquote[0] == "patrol")
                                    {
                                        polypoints.Clear();
                                        mobspawnsplitquote2 = mobspawnsplitquote[1].Split('|', ';');
                                        polypoints.Add(new Point((int)((float.Parse(spawnxmob[x]) - float.Parse(minx[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluex), (int)(((float.Parse(spawnzmob[x]) * -1) + float.Parse(maxz[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluez)));
                                        for (int i = 0; i < mobspawnsplitquote2.Length; i = i + 4)
                                        {
                                            polypoints.Add(new Point((int)((float.Parse(mobspawnsplitquote2[i]) - float.Parse(minx[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluex), (int)(((float.Parse(mobspawnsplitquote2[i + 2]) * -1) + float.Parse(maxz[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluez)));
                                        }
                                        g.DrawPolygon(penselected, polypoints.ToArray());
                                    }
                                }
                                spawnidzonemobs.Add(x);
                                spawnrectangles.Add(new Rectangle((int)((float.Parse(spawnxmob[x]) - float.Parse(minx[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluex) - 2, (int)(((float.Parse(spawnzmob[x]) * -1) + float.Parse(maxz[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluez) - 2, 5, 5));
                                dotlist.Add(new Rectangle((int)((float.Parse(spawnxmob[x]) - float.Parse(minx[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluex) - 1, (int)(((float.Parse(spawnzmob[x]) * -1) + float.Parse(maxz[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluez) - 1, 3, 3));
                                dottype.Add(2);
                                spawntangle = spawnrectangles.Count - 1;
                                spawntangle2 = x;
                                SpawnPointSelected.Text = "Spawn Point Selected: " + spawnidmob[spawnidzonemobs[spawnrectangles.Count - 1]];
                                SpawnLocation.Text = "Spawn Location: (X:" + spawnxmob[spawnidzonemobs[spawnrectangles.Count - 1]] + " Y:" + spawnymob[spawnidzonemobs[spawnrectangles.Count - 1]] + " Z:" + spawnzmob[spawnidzonemobs[spawnrectangles.Count - 1]] + ") ∠" + spawnanglemob[spawnidzonemobs[spawnrectangles.Count - 1]] + "°";
                                mobspawnsplitquote = patrolmob[spawnidzonemobs[spawnrectangles.Count - 1]].Split(' ');
                                if (mobspawnsplitquote[0] == "stand")
                                {
                                    MovementType.Text = "Movement Type: Stand (" + patrolspeedmob[spawnidzonemobs[spawnrectangles.Count - 1]] + "x Speed)";
                                    SpawnPointMobRoute.Items.Add("Doesn't Move");
                                }
                                else if (mobspawnsplitquote[0] == "random")
                                {
                                    MovementType.Text = "Movement Type: Random (" + patrolspeedmob[spawnidzonemobs[spawnrectangles.Count - 1]] + "x Speed)";
                                    if (mobspawnsplitquote[3] == mobspawnsplitquote[4])
                                    {
                                        SpawnPointMobRoute.Items.Add("Randomly Walks Around...");
                                        SpawnPointMobRoute.Items.Add("Radius: " + mobspawnsplitquote[1]);
                                        SpawnPointMobRoute.Items.Add("Mob Wait Chance: " + mobspawnsplitquote[2] + "%");
                                        SpawnPointMobRoute.Items.Add("Wait Time: " + mobspawnsplitquote[3] + " sec");
                                    }
                                    else
                                    {
                                        SpawnPointMobRoute.Items.Add("Randomly Walks Around...");
                                        SpawnPointMobRoute.Items.Add("Radius: " + mobspawnsplitquote[1]);
                                        SpawnPointMobRoute.Items.Add("Mob Wait Chance: " + mobspawnsplitquote[2] + "%");
                                        SpawnPointMobRoute.Items.Add("Wait Time: " + mobspawnsplitquote[3] + " sec - " + mobspawnsplitquote[4] + " sec");
                                    }
                                }
                                else if (mobspawnsplitquote[0] == "patrol")
                                {
                                    MovementType.Text = "Movement Type: Patrol (" + patrolspeedmob[spawnidzonemobs[spawnrectangles.Count - 1]] + "x Speed)";
                                    mobspawnsplitquote2 = mobspawnsplitquote[1].Split('|', ';');
                                    for (int i = 0; i < mobspawnsplitquote2.Length; i = i + 4)
                                    {
                                        SpawnPointMobRoute.Items.Add(((i / 4) + 1) + ": (X:" + mobspawnsplitquote2[i] + " Y:" + mobspawnsplitquote2[i + 1] + " Z:" + mobspawnsplitquote2[i + 2] + ") " + mobspawnsplitquote2[i + 3] + " sec");
                                    }
                                }
                                RespawnTime.Text = "Respawn Time: " + respawntimemob[spawnidzonemobs[spawnrectangles.Count - 1]];
                                mobspawnsplitquote2 = moblistmob[spawnidzonemobs[spawnrectangles.Count - 1]].Split('|', ';');
                                for (int z = 0; z < mobspawnsplitquote2.Length; z = z + 2)
                                {
                                    weighthold.Add(Convert.ToInt32(mobspawnsplitquote2[z + 1]));
                                    if (MainForm.mobid.IndexOf(mobspawnsplitquote2[z]) > -1)
                                    {
                                        nameholder.Add(MainForm.mobname[MainForm.mobid.IndexOf(mobspawnsplitquote2[z])] + "[" + MainForm.mobid[MainForm.mobid.IndexOf(mobspawnsplitquote2[z])] + "]");
                                        mobsinspawn.Add(MainForm.mobid[MainForm.mobid.IndexOf(mobspawnsplitquote2[z])]);
                                    }
                                    else
                                    {
                                        nameholder.Add("Nothing");
                                        mobsinspawn.Add("-1");
                                    }
                                }
                                for (int z = 0; z < weighthold.Count; z++)
                                {
                                    weightadding = weightadding + weighthold[z];
                                }
                                for (int z = 0; z < nameholder.Count; z++)
                                {
                                    if (ShowPercent.Checked == true)
                                    {
                                        PossibleMobSpawns.Items.Add(((weighthold[z] / weightadding) * 100).ToString() + "% " + nameholder[z]);
                                    }
                                    else if (ShowFraction.Checked == true)
                                    {
                                        numerators = new int[weighthold.Count + 1];
                                        for (int v = 0; v < weighthold.Count; v++)
                                        {
                                            numerators[v] = Convert.ToInt32(weighthold[v]);
                                        }
                                    }
                                }
                                selecteddot = true;
                                break;
                            }
                        }
                    }
                }
                if (ShowFraction.Checked == true && nameholder.Count > 0)
                {
                    numerators[weighthold.Count] = Convert.ToInt32(weightadding);
                    int result = GCD(numerators);
                    PossibleMobSpawns.BeginUpdate();
                    for (int y = 0; y < numerators.Length - 1; y++)
                    {
                        PossibleMobSpawns.Items.Add((numerators[y] / result) + "/" + (numerators[weighthold.Count] / result) + " " + nameholder[y]);
                    }
                    PossibleMobSpawns.EndUpdate();
                }
                for (int z = 0; z < dotlist.Count; z++)
                {
                    switch (dottype[z])
                    {
                        case 0:
                            g.FillRectangle(Brushes.Black, spawnrectangles[z]);
                            g.FillRectangle(brushunrelated, dotlist[z]);
                            break;
                        case 1:
                            g.FillRectangle(Brushes.Black, spawnrectangles[z]);
                            g.FillRectangle(brushmob, dotlist[z]);
                            break;
                        case 2:
                            g.FillRectangle(Brushes.Black, spawnrectangles[z]);
                            g.FillRectangle(brushselected, dotlist[z]);
                            break;
                    }
                }
            }
            if (loadmode == 0)
            {
                MapPictureBox.Image = bmp;
                editedmap = bmp;
            }
            else if (loadmode == 1)
            {
                MapPictureBox.Image = bmp;
                PicturePanel.HorizontalScroll.Value = (int)(PicturePanel.HorizontalScroll.Maximum * percentx);
                PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty);
                PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty);
                editedmap = bmp;
            }
        }

        private void Zoom1_Click(object sender, EventArgs e)
        {
            ReloadDrawing(512, 512, 0);
            PicturePanel.AutoScroll = false;
            Zoom1.Enabled = false;
            Zoom15.Enabled = true;
            Zoom2.Enabled = true;
            Zoom3.Enabled = true;
            Zoom4.Enabled = true;
            Zoom6.Enabled = true;
            Zoom8.Enabled = true;
        }

        private void Zoom15_Click(object sender, EventArgs e)
        {
            ReloadDrawing(768, 768, 0);
            PicturePanel.AutoScroll = true;
            if (Zoom1.Enabled == false)
            {
                PicturePanel.HorizontalScroll.Value = 130;
                PicturePanel.VerticalScroll.Value = 130;
                PicturePanel.VerticalScroll.Value = 130;
            }
            else if (Zoom2.Enabled == false)
            {
                if (((int)(PicturePanel.HorizontalScroll.Maximum * percentx) - 60) >= 0)
                {
                    PicturePanel.HorizontalScroll.Value = (int)(PicturePanel.HorizontalScroll.Maximum * percentx) - 60;
                }
                else PicturePanel.HorizontalScroll.Value = 0;
                if (((int)(PicturePanel.VerticalScroll.Maximum * percenty) - 60) >= 0)
                {
                    PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) - 60;
                    PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) - 60;
                }
                else PicturePanel.VerticalScroll.Value = 0;
            }
            else if (Zoom3.Enabled == false)
            {
                if (((int)(PicturePanel.HorizontalScroll.Maximum * percentx) - 110) >= 0)
                {
                    PicturePanel.HorizontalScroll.Value = (int)(PicturePanel.HorizontalScroll.Maximum * percentx) - 110;
                }
                else PicturePanel.HorizontalScroll.Value = 0;
                if (((int)(PicturePanel.VerticalScroll.Maximum * percenty) - 110) >= 0)
                {
                    PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) - 110;
                    PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) - 110;
                }
                else PicturePanel.VerticalScroll.Value = 0;
            }
            else if (Zoom4.Enabled == false)
            {
                if (((int)(PicturePanel.HorizontalScroll.Maximum * percentx) - 140) >= 0)
                {
                    PicturePanel.HorizontalScroll.Value = (int)(PicturePanel.HorizontalScroll.Maximum * percentx) - 140;
                }
                else PicturePanel.HorizontalScroll.Value = 0;
                if (((int)(PicturePanel.VerticalScroll.Maximum * percenty) - 140) >= 0)
                {
                    PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) - 140;
                    PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) - 140;
                }
                else PicturePanel.VerticalScroll.Value = 0;
            }
            else if (Zoom6.Enabled == false)
            {
                if (((int)(PicturePanel.HorizontalScroll.Maximum * percentx) - 179) >= 0)
                {
                    PicturePanel.HorizontalScroll.Value = (int)(PicturePanel.HorizontalScroll.Maximum * percentx) - 179;
                }
                else PicturePanel.HorizontalScroll.Value = 0;
                if (((int)(PicturePanel.VerticalScroll.Maximum * percenty) - 179) >= 0)
                {
                    PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) - 179;
                    PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) - 179;
                }
                else PicturePanel.VerticalScroll.Value = 0;
            }
            else if (Zoom8.Enabled == false)
            {
                if (((int)(PicturePanel.HorizontalScroll.Maximum * percentx) - 193) >= 0)
                {
                    PicturePanel.HorizontalScroll.Value = (int)(PicturePanel.HorizontalScroll.Maximum * percentx) - 193;
                }
                else PicturePanel.HorizontalScroll.Value = 0;
                if (((int)(PicturePanel.VerticalScroll.Maximum * percenty) - 193) >= 0)
                {
                    PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) - 193;
                    PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) - 193;
                }
                else PicturePanel.VerticalScroll.Value = 0;
            }
            percentx = (double)PicturePanel.HorizontalScroll.Value / PicturePanel.HorizontalScroll.Maximum;
            percenty = (double)PicturePanel.VerticalScroll.Value / PicturePanel.VerticalScroll.Maximum;
            Zoom1.Enabled = true;
            Zoom15.Enabled = false;
            Zoom2.Enabled = true;
            Zoom3.Enabled = true;
            Zoom4.Enabled = true;
            Zoom6.Enabled = true;
            Zoom8.Enabled = true;
        }

        private void Zoom2_Click(object sender, EventArgs e)
        {
            ReloadDrawing(1024, 1024, 0);
            PicturePanel.AutoScroll = true;
            if (Zoom1.Enabled == false)
            {
                PicturePanel.HorizontalScroll.Value = 250;
                PicturePanel.VerticalScroll.Value = 250;
                PicturePanel.VerticalScroll.Value = 250;
            }
            else if (Zoom15.Enabled == false)
            {
                PicturePanel.HorizontalScroll.Value = (int)(PicturePanel.HorizontalScroll.Maximum * percentx) + 80;
                PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) + 80;
                PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) + 80;
            }
            else if (Zoom3.Enabled == false)
            {
                if (((int)(PicturePanel.HorizontalScroll.Maximum * percentx) - 80) >= 0)
                {
                    PicturePanel.HorizontalScroll.Value = (int)(PicturePanel.HorizontalScroll.Maximum * percentx) - 80;
                }
                else PicturePanel.HorizontalScroll.Value = 0;
                if (((int)(PicturePanel.VerticalScroll.Maximum * percenty) - 80) >= 0)
                {
                    PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) - 80;
                    PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) - 80;
                }
                else PicturePanel.VerticalScroll.Value = 0;
            }
            else if (Zoom4.Enabled == false)
            {
                if (((int)(PicturePanel.HorizontalScroll.Maximum * percentx) - 114) >= 0)
                {
                    PicturePanel.HorizontalScroll.Value = (int)(PicturePanel.HorizontalScroll.Maximum * percentx) - 114;
                }
                else PicturePanel.HorizontalScroll.Value = 0;
                if (((int)(PicturePanel.VerticalScroll.Maximum * percenty) - 114) >= 0)
                {
                    PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) - 114;
                    PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) - 114;
                }
                else PicturePanel.VerticalScroll.Value = 0;
            }
            else if (Zoom6.Enabled == false)
            {
                if (((int)(PicturePanel.HorizontalScroll.Maximum * percentx) - 159) >= 0)
                {
                    PicturePanel.HorizontalScroll.Value = (int)(PicturePanel.HorizontalScroll.Maximum * percentx) - 159;
                }
                else PicturePanel.HorizontalScroll.Value = 0;
                if (((int)(PicturePanel.VerticalScroll.Maximum * percenty) - 159) >= 0)
                {
                    PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) - 159;
                    PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) - 159;
                }
                else PicturePanel.VerticalScroll.Value = 0;
            }
            else if (Zoom8.Enabled == false)
            {
                if (((int)(PicturePanel.HorizontalScroll.Maximum * percentx) - 183) >= 0)
                {
                    PicturePanel.HorizontalScroll.Value = (int)(PicturePanel.HorizontalScroll.Maximum * percentx) - 183;
                }
                else PicturePanel.HorizontalScroll.Value = 0;
                if (((int)(PicturePanel.VerticalScroll.Maximum * percenty) - 183) >= 0)
                {
                    PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) - 183;
                    PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) - 183;
                }
                else PicturePanel.VerticalScroll.Value = 0;
            }
            percentx = (double)PicturePanel.HorizontalScroll.Value / PicturePanel.HorizontalScroll.Maximum;
            percenty = (double)PicturePanel.VerticalScroll.Value / PicturePanel.VerticalScroll.Maximum;
            Zoom1.Enabled = true;
            Zoom15.Enabled = true;
            Zoom2.Enabled = false;
            Zoom3.Enabled = true;
            Zoom4.Enabled = true;
            Zoom6.Enabled = true;
            Zoom8.Enabled = true;
        }

        private void Zoom3_Click(object sender, EventArgs e)
        {
            ReloadDrawing(1536, 1536, 0);
            PicturePanel.AutoScroll = true;
            if (Zoom1.Enabled == false)
            {
                PicturePanel.HorizontalScroll.Value = 500;
                PicturePanel.VerticalScroll.Value = 500;
                PicturePanel.VerticalScroll.Value = 500;
            }
            else if (Zoom15.Enabled == false)
            {
                PicturePanel.HorizontalScroll.Value = (int)(PicturePanel.HorizontalScroll.Maximum * percentx) + 220;
                PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) + 220;
                PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) + 220;
            }
            else if (Zoom2.Enabled == false)
            {
                PicturePanel.HorizontalScroll.Value = (int)(PicturePanel.HorizontalScroll.Maximum * percentx) + 120;
                PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) + 120;
                PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) + 120;
            }
            else if (Zoom4.Enabled == false)
            {
                if (((int)(PicturePanel.HorizontalScroll.Maximum * percentx) - 60) >= 0)
                {
                    PicturePanel.HorizontalScroll.Value = (int)(PicturePanel.HorizontalScroll.Maximum * percentx) - 60;
                }
                else PicturePanel.HorizontalScroll.Value = 0;
                if (((int)(PicturePanel.VerticalScroll.Maximum * percenty) - 60) >= 0)
                {
                    PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) - 60;
                    PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) - 60;
                }
                else PicturePanel.VerticalScroll.Value = 0;
            }
            else if (Zoom6.Enabled == false)
            {
                if (((int)(PicturePanel.HorizontalScroll.Maximum * percentx) - 128) >= 0)
                {
                    PicturePanel.HorizontalScroll.Value = (int)(PicturePanel.HorizontalScroll.Maximum * percentx) - 128;
                }
                else PicturePanel.HorizontalScroll.Value = 0;
                if (((int)(PicturePanel.VerticalScroll.Maximum * percenty) - 128) >= 0)
                {
                    PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) - 128;
                    PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) - 128;
                }
                else PicturePanel.VerticalScroll.Value = 0;
            }
            else if (Zoom8.Enabled == false)
            {
                if (((int)(PicturePanel.HorizontalScroll.Maximum * percentx) - 155) >= 0)
                {
                    PicturePanel.HorizontalScroll.Value = (int)(PicturePanel.HorizontalScroll.Maximum * percentx) - 155;
                }
                else PicturePanel.HorizontalScroll.Value = 0;
                if (((int)(PicturePanel.VerticalScroll.Maximum * percenty) - 155) >= 0)
                {
                    PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) - 155;
                    PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) - 155;
                }
                else PicturePanel.VerticalScroll.Value = 0;
            }
            percentx = (double)PicturePanel.HorizontalScroll.Value / PicturePanel.HorizontalScroll.Maximum;
            percenty = (double)PicturePanel.VerticalScroll.Value / PicturePanel.VerticalScroll.Maximum;
            Zoom1.Enabled = true;
            Zoom15.Enabled = true;
            Zoom2.Enabled = true;
            Zoom3.Enabled = false;
            Zoom4.Enabled = true;
            Zoom6.Enabled = true;
            Zoom8.Enabled = true;
        }

        private void Zoom4_Click(object sender, EventArgs e)
        {
            ReloadDrawing(2048, 2048, 0);
            PicturePanel.AutoScroll = true;
            if (Zoom1.Enabled == false)
            {
                PicturePanel.HorizontalScroll.Value = 750;
                PicturePanel.VerticalScroll.Value = 750;
                PicturePanel.VerticalScroll.Value = 750;
            }
            else if (Zoom15.Enabled == false)
            {
                PicturePanel.HorizontalScroll.Value = (int)(PicturePanel.HorizontalScroll.Maximum * percentx) + 380;
                PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) + 380;
                PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) + 380;
            }
            else if (Zoom2.Enabled == false)
            {
                PicturePanel.HorizontalScroll.Value = (int)(PicturePanel.HorizontalScroll.Maximum * percentx) + 230;
                PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) + 230;
                PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) + 230;
            }
            else if (Zoom3.Enabled == false)
            {
                PicturePanel.HorizontalScroll.Value = (int)(PicturePanel.HorizontalScroll.Maximum * percentx) + 80;
                PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) + 80;
                PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) + 80;
            }
            else if (Zoom6.Enabled == false)
            {
                if (((int)(PicturePanel.HorizontalScroll.Maximum * percentx) - 78) >= 0)
                {
                    PicturePanel.HorizontalScroll.Value = (int)(PicturePanel.HorizontalScroll.Maximum * percentx) - 78;
                }
                else PicturePanel.HorizontalScroll.Value = 0;
                if (((int)(PicturePanel.VerticalScroll.Maximum * percenty) - 78) >= 0)
                {
                    PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) - 78;
                    PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) - 78;
                }
                else PicturePanel.VerticalScroll.Value = 0;
            }
            else if (Zoom8.Enabled == false)
            {
                if (((int)(PicturePanel.HorizontalScroll.Maximum * percentx) - 119) >= 0)
                {
                    PicturePanel.HorizontalScroll.Value = (int)(PicturePanel.HorizontalScroll.Maximum * percentx) - 119;
                }
                else PicturePanel.HorizontalScroll.Value = 0;
                if (((int)(PicturePanel.VerticalScroll.Maximum * percenty) - 119) >= 0)
                {
                    PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) - 119;
                    PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) - 119;
                }
                else PicturePanel.VerticalScroll.Value = 0;
            }
            percentx = (double)PicturePanel.HorizontalScroll.Value / PicturePanel.HorizontalScroll.Maximum;
            percenty = (double)PicturePanel.VerticalScroll.Value / PicturePanel.VerticalScroll.Maximum;
            Zoom1.Enabled = true;
            Zoom15.Enabled = true;
            Zoom2.Enabled = true;
            Zoom3.Enabled = true;
            Zoom4.Enabled = false;
            Zoom6.Enabled = true;
            Zoom8.Enabled = true;
        }

        private void Zoom6_Click(object sender, EventArgs e)
        {
            ReloadDrawing(3072, 3072, 0);
            PicturePanel.AutoScroll = true;
            if (Zoom1.Enabled == false)
            {
                PicturePanel.HorizontalScroll.Value = 1250;
                PicturePanel.VerticalScroll.Value = 1250;
                PicturePanel.VerticalScroll.Value = 1250;
            }
            else if (Zoom15.Enabled == false)
            {
                PicturePanel.HorizontalScroll.Value = (int)(PicturePanel.HorizontalScroll.Maximum * percentx) + 720;
                PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) + 720;
                PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) + 720;
            }
            else if (Zoom2.Enabled == false)
            {
                PicturePanel.HorizontalScroll.Value = (int)(PicturePanel.HorizontalScroll.Maximum * percentx) + 480;
                PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) + 480;
                PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) + 480;
            }
            else if (Zoom3.Enabled == false)
            {
                PicturePanel.HorizontalScroll.Value = (int)(PicturePanel.HorizontalScroll.Maximum * percentx) + 260;
                PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) + 260;
                PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) + 260;
            }
            else if (Zoom4.Enabled == false)
            {
                PicturePanel.HorizontalScroll.Value = (int)(PicturePanel.HorizontalScroll.Maximum * percentx) + 120;
                PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) + 120;
                PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) + 120;
            }
            else if (Zoom8.Enabled == false)
            {
                if (((int)(PicturePanel.HorizontalScroll.Maximum * percentx) - 62) >= 0)
                {
                    PicturePanel.HorizontalScroll.Value = (int)(PicturePanel.HorizontalScroll.Maximum * percentx) - 62;
                }
                else PicturePanel.HorizontalScroll.Value = 0;
                if (((int)(PicturePanel.VerticalScroll.Maximum * percenty) - 62) >= 0)
                {
                    PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) - 62;
                    PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) - 62;
                }
                else PicturePanel.VerticalScroll.Value = 0;
            }
            percentx = (double)PicturePanel.HorizontalScroll.Value / PicturePanel.HorizontalScroll.Maximum;
            percenty = (double)PicturePanel.VerticalScroll.Value / PicturePanel.VerticalScroll.Maximum;
            Zoom1.Enabled = true;
            Zoom15.Enabled = true;
            Zoom2.Enabled = true;
            Zoom3.Enabled = true;
            Zoom4.Enabled = true;
            Zoom6.Enabled = false;
            Zoom8.Enabled = true;
        }

        private void Zoom8_Click(object sender, EventArgs e)
        {
            ReloadDrawing(4096, 4096, 0);
            PicturePanel.AutoScroll = true;
            if (Zoom1.Enabled == false)
            {
                PicturePanel.HorizontalScroll.Value = 1750;
                PicturePanel.VerticalScroll.Value = 1750;
                PicturePanel.VerticalScroll.Value = 1750;
            }
            else if (Zoom15.Enabled == false)
            {
                PicturePanel.HorizontalScroll.Value = (int)(PicturePanel.HorizontalScroll.Maximum * percentx) + 1035;
                PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) + 1035;
                PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) + 1035;
            }
            else if (Zoom2.Enabled == false)
            {
                PicturePanel.HorizontalScroll.Value = (int)(PicturePanel.HorizontalScroll.Maximum * percentx) + 735;
                PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) + 735;
                PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) + 735;
            }
            else if (Zoom3.Enabled == false)
            {
                PicturePanel.HorizontalScroll.Value = (int)(PicturePanel.HorizontalScroll.Maximum * percentx) + 420;
                PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) + 420;
                PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) + 420;
            }
            else if (Zoom4.Enabled == false)
            {
                PicturePanel.HorizontalScroll.Value = (int)(PicturePanel.HorizontalScroll.Maximum * percentx) + 240;
                PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) + 240;
                PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) + 240;
            }
            else if (Zoom6.Enabled == false)
            {
                PicturePanel.HorizontalScroll.Value = (int)(PicturePanel.HorizontalScroll.Maximum * percentx) + 86;
                PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) + 86;
                PicturePanel.VerticalScroll.Value = (int)(PicturePanel.VerticalScroll.Maximum * percenty) + 86;
            }
            percentx = (double)PicturePanel.HorizontalScroll.Value / PicturePanel.HorizontalScroll.Maximum;
            percenty = (double)PicturePanel.VerticalScroll.Value / PicturePanel.VerticalScroll.Maximum;
            Zoom1.Enabled = true;
            Zoom15.Enabled = true;
            Zoom2.Enabled = true;
            Zoom3.Enabled = true;
            Zoom4.Enabled = true;
            Zoom6.Enabled = true;
            Zoom8.Enabled = false;
        }

        private void PicturePanel_Scroll(object sender, ScrollEventArgs e)
        {
            percentx = (double)PicturePanel.HorizontalScroll.Value / PicturePanel.HorizontalScroll.Maximum;
            percenty = (double)PicturePanel.VerticalScroll.Value / PicturePanel.VerticalScroll.Maximum;
        }

        private void PicturePanel_MouseWheel(object sender, MouseEventArgs e)
        {
            percentx = (double)PicturePanel.HorizontalScroll.Value / PicturePanel.HorizontalScroll.Maximum;
            percenty = (double)PicturePanel.VerticalScroll.Value / PicturePanel.VerticalScroll.Maximum;
        }

        private void CurrentZoneSelected_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadDrawing(512, 512, 0);
            PicturePanel.AutoScroll = false;
            Zoom1.Enabled = false;
            Zoom15.Enabled = true;
            Zoom2.Enabled = true;
            Zoom3.Enabled = true;
            Zoom4.Enabled = true;
            Zoom6.Enabled = true;
            Zoom8.Enabled = true;
            checkignore = true;
        }

        private void MapPictureBox_Click(object sender, EventArgs e)
        {
            weightadding = 0;
            weighthold.Clear();
            nameholder.Clear();
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;
            for (int x = 0; x < spawnrectangles.Count; x++)
            {
                if ((coordinates.X > spawnrectangles[x].X) && (coordinates.X < spawnrectangles[x].X + spawnrectangles[x].Width) && (coordinates.Y > spawnrectangles[x].Y) && (coordinates.Y < spawnrectangles[x].Y + spawnrectangles[x].Height))
                {
                    SpawnPointMobRoute.Items.Clear();
                    PossibleMobSpawns.Items.Clear();
                    mobsinspawn.Clear();
                    spawnhasmob = false;
                    SpawnPointSelected.Text = "Spawn Point Selected: " + spawnidmob[spawnidzonemobs[x]];
                    SpawnLocation.Text = "Spawn Location: (X:" + spawnxmob[spawnidzonemobs[x]] + " Y:" + spawnymob[spawnidzonemobs[x]] + " Z:" + spawnzmob[spawnidzonemobs[x]] + ") ∠" + spawnanglemob[spawnidzonemobs[x]] + "°";
                    mobspawnsplitquote = patrolmob[spawnidzonemobs[x]].Split(' ');
                    if (mobspawnsplitquote[0] == "stand")
                    {
                        MovementType.Text = "Movement Type: Stand (" + patrolspeedmob[spawnidzonemobs[x]] + "x Speed)";
                        SpawnPointMobRoute.Items.Add("Doesn't Move");
                    }
                    else if (mobspawnsplitquote[0] == "random")
                    {
                        MovementType.Text = "Movement Type: Random (" + patrolspeedmob[spawnidzonemobs[x]] + "x Speed)";
                        if (mobspawnsplitquote[3] == mobspawnsplitquote[4])
                        {
                            SpawnPointMobRoute.Items.Add("Randomly Walks Around...");
                            SpawnPointMobRoute.Items.Add("Radius: " + mobspawnsplitquote[1]);
                            SpawnPointMobRoute.Items.Add("Mob Wait Chance: " + mobspawnsplitquote[2] + "%");
                            SpawnPointMobRoute.Items.Add("Wait Time: " + mobspawnsplitquote[3] + " sec");
                        }
                        else
                        {
                            SpawnPointMobRoute.Items.Add("Randomly Walks Around...");
                            SpawnPointMobRoute.Items.Add("Radius: " + mobspawnsplitquote[1]);
                            SpawnPointMobRoute.Items.Add("Mob Wait Chance: " + mobspawnsplitquote[2] + "%");
                            SpawnPointMobRoute.Items.Add("Wait Time: " + mobspawnsplitquote[3] + " sec - " + mobspawnsplitquote[4] + " sec");
                        }
                    }
                    else if (mobspawnsplitquote[0] == "patrol")
                    {
                        MovementType.Text = "Movement Type: Patrol (" + patrolspeedmob[spawnidzonemobs[x]] + "x Speed)";
                        mobspawnsplitquote2 = mobspawnsplitquote[1].Split('|', ';');
                        for (int i = 0; i < mobspawnsplitquote2.Length; i = i + 4)
                        {
                            SpawnPointMobRoute.Items.Add(((i / 4) + 1) + ": (X:" + mobspawnsplitquote2[i] + " Y:" + mobspawnsplitquote2[i + 1] + " Z:" + mobspawnsplitquote2[i + 2] + ") " + mobspawnsplitquote2[i + 3] + " sec");
                        }
                    }
                    RespawnTime.Text = "Respawn Time: " + respawntimemob[spawnidzonemobs[x]];
                    mobspawnsplitquote2 = moblistmob[spawnidzonemobs[x]].Split('|', ';');
                    for (int y = 0; y < mobspawnsplitquote2.Length; y = y + 2)
                    {
                        weighthold.Add(Convert.ToInt32(mobspawnsplitquote2[y + 1]));
                        if (MainForm.mobid.IndexOf(mobspawnsplitquote2[y]) > -1)
                        {
                            nameholder.Add(MainForm.mobname[MainForm.mobid.IndexOf(mobspawnsplitquote2[y])] + "[" + MainForm.mobid[MainForm.mobid.IndexOf(mobspawnsplitquote2[y])] + "]");
                            mobsinspawn.Add(MainForm.mobid[MainForm.mobid.IndexOf(mobspawnsplitquote2[y])]);
                            if (mobselected == mobspawnsplitquote2[y])
                            {
                                for (int z = 0; z < spawnidselectedmobs.Count; z++)
                                {
                                    if (spawnidmob[spawnidzonemobs[x]] == spawnidmob[spawnidselectedmobs[z]])
                                    {
                                        MobSpawnNumber.Text = "Spawn (" + (z + 1) + " of " + spawnidselectedmobs.Count + ")";
                                        spawnhasmob = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            nameholder.Add("Nothing");
                            mobsinspawn.Add("-1");
                        }
                    }
                    if (spawnhasmob == false)
                    {
                        MobSpawnNumber.Text = "Spawn (X of " + spawnidselectedmobs.Count + ")";
                    }
                    for (int y = 0; y < weighthold.Count; y++)
                    {
                        weightadding = weightadding + weighthold[y];
                    }
                    int[] numerators = new int[weighthold.Count + 1];
                    for (int y = 0; y < nameholder.Count; y++)
                    {
                        if (ShowPercent.Checked == true)
                        {
                            PossibleMobSpawns.Items.Add(((weighthold[y] / weightadding) * 100).ToString() + "% " + nameholder[y]);
                        }
                        else if (ShowFraction.Checked == true)
                        {
                            for (int v = 0; v < weighthold.Count; v++)
                            {
                                numerators[v] = Convert.ToInt32(weighthold[v]);
                            }
                        }
                    }
                    if (ShowFraction.Checked == true)
                    {
                        numerators[weighthold.Count] = Convert.ToInt32(weightadding);
                        int result = GCD(numerators);
                        PossibleMobSpawns.BeginUpdate();
                        for (int z = 0; z < numerators.Length - 1; z++)
                        {
                            PossibleMobSpawns.Items.Add((numerators[z] / result) + "/" + (numerators[weighthold.Count] / result) + " " + nameholder[z]);
                        }
                        PossibleMobSpawns.EndUpdate();
                    }
                    bmp = new Bitmap(editedmap);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        if (selecteddot == true)
                        {
                            if (spawnidselectedmobs.IndexOf(spawntangle2) == -1)
                            {
                                if (ShowMovementPaths.Checked == true)
                                {
                                    mobspawnsplitquote = patrolmob[spawnidzonemobs[spawntangle]].Split(' ');
                                    if (mobspawnsplitquote[0] == "random")
                                    {
                                        radirectangle = new Rectangle((int)((float.Parse(spawnxmob[spawnidzonemobs[spawntangle]]) - float.Parse(minx[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluex) - (int)(float.Parse(mobspawnsplitquote[1]) * (double)pixelvaluex), (int)(((float.Parse(spawnzmob[spawnidzonemobs[spawntangle]]) * -1) + float.Parse(maxz[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluez) - (int)(float.Parse(mobspawnsplitquote[1]) * (double)pixelvaluez), (int)(float.Parse(mobspawnsplitquote[1]) * (double)pixelvaluex) * 2, (int)(float.Parse(mobspawnsplitquote[1]) * (double)pixelvaluez) * 2);
                                        g.DrawEllipse(penunrelated, radirectangle);
                                    }
                                    else if (mobspawnsplitquote[0] == "patrol")
                                    {
                                        polypoints.Clear();
                                        mobspawnsplitquote2 = mobspawnsplitquote[1].Split('|', ';');
                                        polypoints.Add(new Point((int)((float.Parse(spawnxmob[spawnidzonemobs[spawntangle]]) - float.Parse(minx[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluex), (int)(((float.Parse(spawnzmob[spawnidzonemobs[spawntangle]]) * -1) + float.Parse(maxz[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluez)));
                                        for (int i = 0; i < mobspawnsplitquote2.Length; i = i + 4)
                                        {
                                            polypoints.Add(new Point((int)((float.Parse(mobspawnsplitquote2[i]) - float.Parse(minx[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluex), (int)(((float.Parse(mobspawnsplitquote2[i + 2]) * -1) + float.Parse(maxz[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluez)));
                                        }
                                        g.DrawPolygon(penunrelated, polypoints.ToArray());
                                    }
                                }
                                g.FillRectangle(Brushes.Black, spawnrectangles[spawntangle].X, spawnrectangles[spawntangle].Y, 5, 5);
                                g.FillRectangle(brushunrelated, spawnrectangles[spawntangle].X + 1, spawnrectangles[spawntangle].Y + 1, 3, 3);
                            }
                            else if (spawnidselectedmobs.IndexOf(spawntangle2) != -1)
                            {
                                if (ShowMovementPaths.Checked == true)
                                {
                                    mobspawnsplitquote = patrolmob[spawnidzonemobs[spawntangle]].Split(' ');
                                    if (mobspawnsplitquote[0] == "random")
                                    {
                                        radirectangle = new Rectangle((int)((float.Parse(spawnxmob[spawnidzonemobs[spawntangle]]) - float.Parse(minx[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluex) - (int)(float.Parse(mobspawnsplitquote[1]) * (double)pixelvaluex), (int)(((float.Parse(spawnzmob[spawnidzonemobs[spawntangle]]) * -1) + float.Parse(maxz[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluez) - (int)(float.Parse(mobspawnsplitquote[1]) * (double)pixelvaluez), (int)(float.Parse(mobspawnsplitquote[1]) * (double)pixelvaluex) * 2, (int)(float.Parse(mobspawnsplitquote[1]) * (double)pixelvaluez) * 2);
                                        g.DrawEllipse(penmob, radirectangle);
                                    }
                                    else if (mobspawnsplitquote[0] == "patrol")
                                    {
                                        polypoints.Clear();
                                        mobspawnsplitquote2 = mobspawnsplitquote[1].Split('|', ';');
                                        polypoints.Add(new Point((int)((float.Parse(spawnxmob[spawnidzonemobs[spawntangle]]) - float.Parse(minx[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluex), (int)(((float.Parse(spawnzmob[spawnidzonemobs[spawntangle]]) * -1) + float.Parse(maxz[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluez)));
                                        for (int i = 0; i < mobspawnsplitquote2.Length; i = i + 4)
                                        {
                                            polypoints.Add(new Point((int)((float.Parse(mobspawnsplitquote2[i]) - float.Parse(minx[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluex), (int)(((float.Parse(mobspawnsplitquote2[i + 2]) * -1) + float.Parse(maxz[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluez)));
                                        }
                                        g.DrawPolygon(penmob, polypoints.ToArray());
                                    }
                                }
                                g.FillRectangle(Brushes.Black, spawnrectangles[spawntangle].X, spawnrectangles[spawntangle].Y, 5, 5);
                                g.FillRectangle(brushmob, spawnrectangles[spawntangle].X + 1, spawnrectangles[spawntangle].Y + 1, 3, 3);
                            }
                        }
                        if (ShowMovementPaths.Checked == true)
                        {
                            mobspawnsplitquote = patrolmob[spawnidzonemobs[x]].Split(' ');
                            if (mobspawnsplitquote[0] == "random")
                            {
                                radirectangle = new Rectangle((int)((float.Parse(spawnxmob[spawnidzonemobs[x]]) - float.Parse(minx[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluex) - (int)(float.Parse(mobspawnsplitquote[1]) * (double)pixelvaluex), (int)(((float.Parse(spawnzmob[spawnidzonemobs[x]]) * -1) + float.Parse(maxz[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluez) - (int)(float.Parse(mobspawnsplitquote[1]) * (double)pixelvaluez), (int)(float.Parse(mobspawnsplitquote[1]) * (double)pixelvaluex) * 2, (int)(float.Parse(mobspawnsplitquote[1]) * (double)pixelvaluez) * 2);
                                g.DrawEllipse(penselected, radirectangle);
                            }
                            else if (mobspawnsplitquote[0] == "patrol")
                            {
                                polypoints.Clear();
                                mobspawnsplitquote2 = mobspawnsplitquote[1].Split('|', ';');
                                polypoints.Add(new Point((int)((float.Parse(spawnxmob[spawnidzonemobs[x]]) - float.Parse(minx[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluex), (int)(((float.Parse(spawnzmob[spawnidzonemobs[x]]) * -1) + float.Parse(maxz[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluez)));
                                for (int i = 0; i < mobspawnsplitquote2.Length; i = i + 4)
                                {
                                    polypoints.Add(new Point((int)((float.Parse(mobspawnsplitquote2[i]) - float.Parse(minx[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluex), (int)(((float.Parse(mobspawnsplitquote2[i + 2]) * -1) + float.Parse(maxz[CurrentZoneSelected.SelectedIndex])) * (double)pixelvaluez)));
                                }
                                g.DrawPolygon(penselected, polypoints.ToArray());
                            }
                        }
                        g.FillRectangle(Brushes.Black, spawnrectangles[x].X, spawnrectangles[x].Y, 5, 5);
                        g.FillRectangle(brushselected, spawnrectangles[x].X + 1, spawnrectangles[x].Y + 1, 3, 3);
                        selecteddot = true;
                    }
                    spawntangle = x;
                    spawntangle2 = spawnidzonemobs[x];
                    MapPictureBox.Image = bmp;
                    editedmap = bmp;
                    SwitchMobButton.Enabled = false;
                    spawnidselected = spawnidzonemobs[x];
                    break;
                }
            }
        }

        private void ShowPercent_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPercent.Checked == true)
            {
                ShowPercent.Enabled = false;
                ShowPercentLabel.Enabled = false;
                ShowFractionLabel.Enabled = true;
                ShowFraction.Checked = false;
                ShowFraction.Enabled = true;
                PossibleMobSpawns.Items.Clear();
                for (int x = 0; x < nameholder.Count; x++)
                {
                    PossibleMobSpawns.Items.Add(((weighthold[x] / weightadding) * 100).ToString() + "% " + nameholder[x]);
                }
            }
        }

        private void ShowPercentLabel_Click(object sender, EventArgs e)
        {
            if (ShowPercent.Checked == true)
            {
                ShowPercent.Checked = false;
            }
            else
            {
                ShowPercent.Checked = true;
            }
        }

        private void ShowFraction_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowFraction.Checked == true)
            {
                ShowFraction.Enabled = false;
                ShowFractionLabel.Enabled = false;
                ShowPercentLabel.Enabled = true;
                ShowPercent.Checked = false;
                ShowPercent.Enabled = true;
                PossibleMobSpawns.Items.Clear();
                if (weighthold.Count > 0)
                {
                    int[] numerators = new int[weighthold.Count + 1];
                    for (int v = 0; v < weighthold.Count; v++)
                    {
                        numerators[v] = Convert.ToInt32(weighthold[v]);
                    }
                    numerators[weighthold.Count] = Convert.ToInt32(weightadding);
                    int result = GCD(numerators);
                    PossibleMobSpawns.BeginUpdate();
                    for (int z = 0; z < numerators.Length - 1; z++)
                    {
                        PossibleMobSpawns.Items.Add((numerators[z] / result) + "/" + (numerators[weighthold.Count] / result) + " " + nameholder[z]);
                    }
                    PossibleMobSpawns.EndUpdate();
                }
            }
        }

        private void ShowFractionLabel_Click(object sender, EventArgs e)
        {
            if (ShowFraction.Checked == true)
            {
                ShowFraction.Checked = false;
            }
            else
            {
                ShowFraction.Checked = true;
            }
        }

        private void ShowOtherSpawns_CheckedChanged(object sender, EventArgs e)
        {
            if (checkignore == true)
            {
                ReloadDrawing(0, 0, 1);
            }
        }

        private void ShowOtherSpawnsLabel_Click(object sender, EventArgs e)
        {
            if (ShowOtherSpawns.Checked == true)
            {
                ShowOtherSpawns.Checked = false;
            }
            else
            {
                ShowOtherSpawns.Checked = true;
            }
        }

        private void ShowMovementPaths_CheckedChanged(object sender, EventArgs e)
        {
            if (checkignore == true)
            {
                ReloadDrawing(0, 0, 1);
            }
        }

        private void ShowMovementPathsLabel_Click(object sender, EventArgs e)
        {
            if (ShowMovementPaths.Checked == true)
            {
                ShowMovementPaths.Checked = false;
            }
            else
            {
                ShowMovementPaths.Checked = true;
            }
        }

        private void SwitchMobButton_Click(object sender, EventArgs e)
        {
            breaker = false;
            uneditedname.Clear();
            zoneselectedmobcount.Clear();
            spawnidselectedmobs.Clear();
            spawnidselected = spawnidzonemobs[spawntangle];
            zonesave = CurrentZoneSelected.SelectedIndex;
            CurrentZoneSelected.Items.Clear();
            for (int i = 0; i < zones.Length; i++)
            {
                zonesplit = zones[i].Split('~');
                uneditedname.Add(zonesplit[1]);
                zoneselectedmobcount.Add(0);
            }
            mobselected = mobsinspawn[PossibleMobSpawns.SelectedIndex];
            for (int x = 0; x < moblistmob.Count; x++)
            {
                mobspawnsplitcomma = mobspawn[x].Split('~');
                mobspawnsplitquote = mobspawnsplitcomma[7].Split('|', ';');
                for (int i = 0; i < mobspawnsplitquote.Length; i = i + 2)
                {
                    if (mobspawnsplitquote[i] == mobselected)
                    {
                        for (int z = 0; z < zoneid.Count; z++)
                        {
                            if (breaker == false)
                            {
                                if (zoneid[z] == zoneidmob[x])
                                {
                                    MobSelectedLabel.Text = "Mob Selected: " + MainForm.mobname[MainForm.mobid.IndexOf(mobselected)] + "[" + MainForm.mobid[MainForm.mobid.IndexOf(mobselected)] + "]";
                                    spawnidselectedmobs.Add(x);
                                    zoneselectedmobcount[z] = zoneselectedmobcount[z] + 1;
                                    breaker = true;
                                }
                            }
                            else
                            {
                                if (zoneid[z] == zoneidmob[x])
                                {
                                    spawnidselectedmobs.Add(x);
                                    zoneselectedmobcount[z] = zoneselectedmobcount[z] + 1;
                                }
                            }
                        }
                    }
                }
            }
            for (int x = 0; x < zoneselectedmobcount.Count; x++)
            {
                if (zoneselectedmobcount[x] == 1)
                {
                    CurrentZoneSelected.Items.Add(uneditedname[x] + " (" + zoneselectedmobcount[x] + " Spawn)");
                }
                else if (zoneselectedmobcount[x] > 1)
                {
                    CurrentZoneSelected.Items.Add(uneditedname[x] + " (" + zoneselectedmobcount[x] + " Spawns)");
                }
                else
                {
                    CurrentZoneSelected.Items.Add(uneditedname[x]);
                }
            }
            CurrentZoneSelected.SelectedIndex = zonesave;
            for (int z = 0; z < spawnidselectedmobs.Count; z++)
            {
                if (spawnidmob[spawnidselected] == spawnidmob[spawnidselectedmobs[z]])
                {
                    MobSpawnNumber.Text = "Spawn (" + (z + 1) + " of " + spawnidselectedmobs.Count + ")";
                    spawnhasmob = true;
                }
            }
            SwitchMobButton.Enabled = false;
        }

        private void MobJumpLeft_Click(object sender, EventArgs e)
        {
            if (MobSpawnNumber.Text.Substring(0, 8) == "Spawn (X")
            {
                spawnidselected = spawnidselectedmobs[0];
                if (zoneidmob[spawnidselected] != zoneid[CurrentZoneSelected.SelectedIndex])
                {
                    CurrentZoneSelected.SelectedIndex = zoneid.IndexOf(zoneidmob[spawnidselected]);
                }
                else
                {
                    ReloadDrawing(512, 512, 0);
                }
            }
            else if (spawnidselectedmobs.IndexOf(spawnidselected) - 1 == -1)
            {
                spawnidselected = spawnidselectedmobs[spawnidselectedmobs.Count - 1];
                if (zoneidmob[spawnidselected] != zoneid[CurrentZoneSelected.SelectedIndex])
                {
                    CurrentZoneSelected.SelectedIndex = zoneid.IndexOf(zoneidmob[spawnidselected]);
                }
                else
                {
                    ReloadDrawing(512, 512, 0);
                }
            }
            else
            {
                spawnidselected = spawnidselectedmobs[spawnidselectedmobs.IndexOf(spawnidselected) - 1];
                if (zoneidmob[spawnidselected] != zoneid[CurrentZoneSelected.SelectedIndex])
                {
                    CurrentZoneSelected.SelectedIndex = zoneid.IndexOf(zoneidmob[spawnidselected]);
                }
                else
                {
                    ReloadDrawing(512, 512, 0);
                }
            }
            for (int z = 0; z < spawnidselectedmobs.Count; z++)
            {
                if (spawnidmob[spawnidselected] == spawnidmob[spawnidselectedmobs[z]])
                {
                    MobSpawnNumber.Text = "Spawn (" + (z + 1) + " of " + spawnidselectedmobs.Count + ")";
                    spawnhasmob = true;
                }
            }
        }

        private void MobJumpRight_Click(object sender, EventArgs e)
        {
            if (MobSpawnNumber.Text.Substring(0, 8) == "Spawn (X")
            {
                spawnidselected = spawnidselectedmobs[0];
                if (zoneidmob[spawnidselected] != zoneid[CurrentZoneSelected.SelectedIndex])
                {
                    CurrentZoneSelected.SelectedIndex = zoneid.IndexOf(zoneidmob[spawnidselected]);
                }
                else
                {
                    ReloadDrawing(512, 512, 0);
                }
            }
            else if (spawnidselectedmobs.IndexOf(spawnidselected) + 2 > spawnidselectedmobs.Count)
            {
                spawnidselected = spawnidselectedmobs[0];
                if (zoneidmob[spawnidselected] != zoneid[CurrentZoneSelected.SelectedIndex])
                {
                    CurrentZoneSelected.SelectedIndex = zoneid.IndexOf(zoneidmob[spawnidselected]);
                }
                else
                {
                    ReloadDrawing(512, 512, 0);
                }
            }
            else
            {
                spawnidselected = spawnidselectedmobs[spawnidselectedmobs.IndexOf(spawnidselected) + 1];
                if (zoneidmob[spawnidselected] != zoneid[CurrentZoneSelected.SelectedIndex])
                {
                    CurrentZoneSelected.SelectedIndex = zoneid.IndexOf(zoneidmob[spawnidselected]);
                }
                else
                {
                    ReloadDrawing(512, 512, 0);
                }
            }
            for (int z = 0; z < spawnidselectedmobs.Count; z++)
            {
                if (spawnidmob[spawnidselected] == spawnidmob[spawnidselectedmobs[z]])
                {
                    MobSpawnNumber.Text = "Spawn (" + (z + 1) + " of " + spawnidselectedmobs.Count + ")";
                    spawnhasmob = true;
                }
            }
        }

        private void PossibleMobSpawns_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PossibleMobSpawns.SelectedIndex != -1)
            {
                if (mobsinspawn[PossibleMobSpawns.SelectedIndex] != "-1")
                {
                    mainscreen.SwitchItemSearch();
                    mainscreen.EnemySpawnIDSearch(Convert.ToInt32(mobsinspawn[PossibleMobSpawns.SelectedIndex]));
                    SwitchMobButton.Enabled = true;
                }
                else
                {
                    SwitchMobButton.Enabled = false;
                }
            }
            else
            {
                SwitchMobButton.Enabled = false;
            }
        }

        private void SelectedSpawnColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.ShowDialog();
            SelectedSpawnColor.BackColor = colorDlg.Color;
            penselected = new Pen(colorDlg.Color, 1);
            brushselected = new SolidBrush(colorDlg.Color);
            selectedred = colorDlg.Color.R;
            selectedgreen = colorDlg.Color.G;
            selectedblue = colorDlg.Color.B;
            ReloadDrawing(0, 0, 1);
        }

        private void ContainsMobColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.ShowDialog();
            ContainsMobColor.BackColor = colorDlg.Color;
            penmob = new Pen(colorDlg.Color, 1);
            brushmob = new SolidBrush(colorDlg.Color);
            mobred = colorDlg.Color.R;
            mobgreen = colorDlg.Color.G;
            mobblue = colorDlg.Color.B;
            ReloadDrawing(0, 0, 1);
        }

        private void OtherSpawnsColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.ShowDialog();
            OtherSpawnsColor.BackColor = colorDlg.Color;
            penunrelated = new Pen(colorDlg.Color, 1);
            brushunrelated = new SolidBrush(colorDlg.Color);
            unrelatedred = colorDlg.Color.R;
            unrelatedgreen = colorDlg.Color.G;
            unrelatedblue = colorDlg.Color.B;
            ReloadDrawing(0, 0, 1);
        }

        private void MobSpawnPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ShowPercent.Checked == true)
            {
                settings[0] = "1";
            }
            else
            {
                settings[0] = "0";
            }
            if (ShowFraction.Checked == true)
            {
                settings[1] = "1";
            }
            else
            {
                settings[1] = "0";
            }
            if (ShowOtherSpawns.Checked == true)
            {
                settings[2] = "1";
            }
            else
            {
                settings[2] = "0";
            }
            if (ShowMovementPaths.Checked == true)
            {
                settings[3] = "1";
            }
            else
            {
                settings[3] = "0";
            }
            settings[4] = selectedred.ToString();
            settings[5] = selectedgreen.ToString();
            settings[6] = selectedblue.ToString();
            settings[7] = mobred.ToString();
            settings[8] = mobgreen.ToString();
            settings[9] = mobblue.ToString();
            settings[10] = unrelatedred.ToString();
            settings[11] = unrelatedgreen.ToString();
            settings[12] = unrelatedblue.ToString();
            File.WriteAllText(@"Resources\Settings\spawnpage.txt", String.Join("~", settings));
            MainForm.spawnopen = false;
            mainscreen.EnemySpawnButtonOpen();
        }
    }
}