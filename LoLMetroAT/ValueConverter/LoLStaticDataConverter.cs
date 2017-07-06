using LoLMetroAT.Models;
using MahApps.Metro;
using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace LoLMetroAT.ValueConverter
{
    public class LoLStaticDataConverter : IValueConverter
    {
        private const string VIDEOS = "http://universe-meeps.leagueoflegends.com/v1/assets/videos/lissandra-splashvideo.webm";

        private const string CHAMPION_SQUARE_IMG = "ChampionSquare.png";
        private const string ITEM_SQUARE_IMG = "ItemSquare.png";

        private const string CHAMPION_IMG_FMT = "http://ddragon.leagueoflegends.com/cdn/{0}/img/champion/{1}";
        private const string SUMMONER_SPELL_IMG_FMT = "http://ddragon.leagueoflegends.com/cdn/{0}/img/spell/{1}";
        private const string SUMMONER_PEOFILE_ICON_FMT = "http://ddragon.leagueoflegends.com/cdn/{0}/img/profileicon/{1}.png";
        private const string ITEM_IMG_FMT = "http://ddragon.leagueoflegends.com/cdn/{0}/img/item/{1}.png";

        //LoLMetroAT;component/Images/Rank_Frame/challenger.png
        //http://opgg-static.akamaized.net/images/borders2/{0}.png
        private const string RANK_FRAME_IMG_FMT = "../Images/Rank_Frame/{0}.png";

        //private const string CHAMPION_IMG_FMT = @"D:\ICF_AutoCapsule_Disabled\7plusWork\WangjqWork\Tool\待ち帰り\LoLTool\LoLTool\ChampionsImages\{0}{1}";
        //private const string SUMMONER_SPELL_IMG_FMT = @"D:\ICF_AutoCapsule_Disabled\7plusWork\WangjqWork\Tool\待ち帰り\LoLTool\LoLTool\SummonerSpellsImages\spell\{0}";
        //private const string ITEM_IMG_FMT = @"D:\ICF_AutoCapsule_Disabled\7plusWork\WangjqWork\Tool\待ち帰り\LoLTool\LoLTool\ItemsImages\{0}.png";
        //private const string SUMMONER_PEOFILE_ICON_FMT = "";
        //http://opgg-static.akamaized.net/images/borders2/challenger.png
        //http://opgg-static.akamaized.net/images/medals/gold_1.png


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object retVal = null;

            ConverterType paramImgType = (ConverterType)parameter;


            switch (paramImgType)
            {
                case ConverterType.RankFrame:

                    retVal = string.Format(RANK_FRAME_IMG_FMT, value.ToString().ToLower());

                    break;

                case ConverterType.ChampionImg:

                    if (LoLStaticData.ChampionsStaticData != null)
                    {
                        var cStaticChampionI = LoLStaticData.ChampionsStaticData.Data.SingleOrDefault(chp => chp.Value.Id.ToString() == value.ToString()).Value;

                        if (cStaticChampionI == null)
                        {
                            retVal = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Images", CHAMPION_SQUARE_IMG);
                        }
                        else
                        {
                            //retVal = string.Format(CHAMPION_IMG_FMT, cStaticChampionI.Image.Full.Replace(".png", ""), "_Square_0.png");
                            retVal = string.Format(CHAMPION_IMG_FMT, LoLStaticData.ChampionsStaticData.Version, cStaticChampionI.Image.Full);
                        }
                    }


                    break;

                case ConverterType.SummonerImg:

                    break;

                case ConverterType.SummonerSpellImg:

                    var cStaticSummonerSpellI = "";// LoLStaticData.SummonerSpellsStaticData.Data.SingleOrDefault(sspell => sspell.Value.Id.ToString() == value.ToString()).Value;

                    if (cStaticSummonerSpellI == null)
                    {
                        retVal = "Error!!!";
                    }
                    else
                    {
                        //retVal = string.Format(SUMMONER_SPELL_IMG_FMT, cStaticSummonerSpellI.Image.Full);
                        retVal = "";// string.Format(SUMMONER_SPELL_IMG_FMT, LoLStaticData.ChampionStaticData.Version, cStaticSummonerSpellI.Image.Full);
                    }

                    break;

                case ConverterType.ItemImg:

                    if (value.ToString() == "0")
                    {
                        retVal = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Images", ITEM_SQUARE_IMG);
                    }
                    else
                    {
                        //retVal = string.Format(ITEM_IMG_FMT, value.ToString());
                        retVal = ""; // string.Format(ITEM_IMG_FMT, LoLStaticData.ChampionStaticData.Version, value.ToString());
                    }

                    break;

                case ConverterType.ProFileIcon:

                    if (LoLStaticData.ChampionsStaticData == null)
                        break;

                    retVal = string.Format(SUMMONER_PEOFILE_ICON_FMT, LoLStaticData.ChampionsStaticData.Version, value);

                    break;

                case ConverterType.SummonerLaneImg:

                    string loctionImagePath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, @"Images\");

                    string imageName = string.Empty;
                    switch (value.ToString().ToUpper())
                    {
                        case "TOP":
                            imageName = string.Format("{0}{1}", value, "_icon.png");
                            break;
                        case "MID":
                            imageName = string.Format("{0}{1}", value, "dle_icon.png");
                            break;
                        case "JUNGLE":
                            imageName = string.Format("{0}{1}", value, "r_icon.png");
                            break;
                        case "BOTTOM":
                            imageName = string.Format("{0}{1}", value, "_icon.png");
                            break;
                        case "SUPPORT":
                            imageName = string.Format("{0}{1}", value, "_icon.png");
                            break;
                    }

                    retVal = System.IO.Path.Combine(loctionImagePath, imageName);

                    break;

                case ConverterType.TierImg:

                    string loctionTierImagePath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, @"Images\Tier_icons\");

                    if (!string.IsNullOrEmpty(value.ToString()))
                    {
                        string[] td = value.ToString().Split(' ');

                        string imageTierName = string.Empty;

                        if (td[0] == "MASTER" || td[0] == "CHALLENGER")
                        {
                            imageTierName = string.Format("{0}{1}", td[0], ".png");
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(td[1].Trim()))
                            {
                                imageTierName = string.Format("{0}{1}", td[0].Trim(), ".png");
                            }
                            else
                            {
                                imageTierName = string.Format("{0}_{1}{2}", td[0], td[1], ".png");
                            }
                        }

                        retVal = System.IO.Path.Combine(loctionTierImagePath, imageTierName);
                    }

                    break;

                case ConverterType.ChampionName:

                    if (LoLStaticData.ChampionsStaticData == null)
                        break;

                    var cStaticChampionN = LoLStaticData.ChampionsStaticData.Data.SingleOrDefault(chp => chp.Value.Id.ToString() == value.ToString()).Value;

                    if (cStaticChampionN == null)
                    {
                        retVal = "";
                    }
                    else
                    {
                        retVal = cStaticChampionN.Name;
                    }

                    // retVal = LoLStaticData.ChampionStaticData.Champions.SingleOrDefault(chp => chp.Value.Id.Equals(value)).Value.Name;
                    break;


                case ConverterType.VisibilityFlag:

                    if (value.ToString() == "-1")
                    {
                        retVal = "Hidden";
                    }
                    else
                    {
                        retVal = "Visible";
                    }

                    break;

                case ConverterType.ChampionTitle:

                    var cStaticChampionT = "";// LoLStaticData.ChampionStaticData.Data.SingleOrDefault(chp => chp.Value.Id.ToString() == value.ToString()).Value;

                    if (cStaticChampionT == null)
                    {
                        retVal = "Error!!!";
                    }
                    else
                    {
                        retVal = ""; // cStaticChampionT.Title;
                    }

                    break;

                case ConverterType.ItemBorderBrush:

                    if ((bool)value)
                    {
                        retVal = System.Windows.Media.Brushes.Tan;
                    }
                    else
                    {
                        var color = ThemeManager.GetResourceFromAppStyle(Application.Current.MainWindow, "AccentColorBrush");
                        retVal = (System.Windows.Media.Brush)color;
                    }

                    break;

                case ConverterType.ItemForeground:

                    if ((bool)value)
                    {
                        retVal = System.Windows.Media.Brushes.Goldenrod;
                    }
                    else
                    {
                        // var color = ThemeManager.GetResourceFromAppStyle(Application.Current.MainWindow, "AccentColorBrush");
                    }

                    break;

                case ConverterType.ItemBorderThickness:

                    if ((bool)value)
                    {
                        retVal = 2;
                    }
                    else
                    {
                        retVal = 1;
                    }

                    break;

                //case ConverterType.HeaderTitleForWLCnt:

                //    if (value == null)
                //        break;

                //    if (value.ToString().ToUpper() == "JP")
                //    {
                //        retVal = "勝 / 敗";
                //    }
                //    else
                //    {
                //        retVal = "W / L";
                //    }

                //    break;
                //case ConverterType.HeaderTitleForWinningPercentage:

                //    if (value == null)
                //        break;

                //    if (value.ToString().ToUpper() == "JP")
                //    {
                //        retVal = "勝率";
                //    }
                //    else
                //    {
                //        retVal = "AVG";
                //    }

                //    break;
                //case ConverterType.HeaderTitleForChampionPoints:

                //    if (value == null)
                //        break;

                //    if (value.ToString().ToUpper() == "JP")
                //    {
                //        retVal = "熟練度";
                //    }
                //    else
                //    {
                //        retVal = "CPoints";
                //    }

                //    break;
                //case ConverterType.HeaderTitleForTierDivision:

                //    if (value == null)
                //        break;

                //    if (value.ToString().ToUpper() == "JP")
                //    {
                //        retVal = "ティア　ディビジョン";
                //    }
                //    else
                //    {
                //        retVal = "Tier　Division";
                //    }

                //    break;

                case ConverterType.TabItemHeaderIconDispFlg:

                    if ((bool)value)
                    {
                        retVal = "BookHardcoverOpenWriting";
                    }
                    else
                    {
                        retVal = "BookPerspective";
                    }

                    break;

                case ConverterType.LeagueHeaderBKDispFlg:

                    if ((bool)value)
                    {

                    }
                    else
                    {

                    }

                    break;
            }

            return retVal;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }

        public static string Convert(object value, ConverterType ct)
        {
            string retVal = string.Empty;

            switch (ct)
            {
                case ConverterType.ChampionImg:
                    // retVal = string.Format(CHAMPION_IMG_FMT, LoLStaticData.ChampionStaticData.Version, LoLStaticData.ChampionStaticData.Data.SingleOrDefault(chp => chp.Value.Id.Equals(value)).Value.Image.Full);
                    break;

                case ConverterType.SummonerImg:

                    break;

                case ConverterType.SummonerSpellImg:

                    break;

                case ConverterType.ItemImg:

                    break;

                case ConverterType.ProFileIcon:


                    break;

                case ConverterType.SummonerLaneImg:

                    break;

                case ConverterType.ChampionName:
                    // retVal = LoLStaticData.ChampionStaticData.Data.SingleOrDefault(chp => chp.Value.Id.Equals(value)).Value.Name;
                    break;

                case ConverterType.ChampionTitle:
                    // retVal = LoLStaticData.ChampionStaticData.Data.SingleOrDefault(chp => chp.Value.Id.Equals(value)).Value.Title;
                    break;
            }

            return retVal;
        }
    }

    public enum ConverterType
    {
        SummonerImg = 0,
        ChampionImg = 1,
        SummonerSpellImg = 2,
        ItemImg = 3,
        ChampionName = 4,
        ChampionTitle = 5,
        ProFileIcon = 6,
        SummonerLaneImg = 7,
        ItemBorderBrush = 8,
        ItemBorderThickness = 9,
        TierImg = 10,
        ItemForeground = 11,
        TabItemHeaderIconDispFlg = 12,
        VisibilityFlag = 13,
        RankFrame = 14,
        LeagueHeaderBKDispFlg = 15
    }
}
