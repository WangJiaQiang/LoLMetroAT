using LoLMetroAT.ViewModels;
using MahApps.Metro.Controls;
using RiotSharp.League_V3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LoLMetroAT.Views
{
    /// <summary>
    /// LeaguesRankView.xaml の相互作用ロジック
    /// </summary>
    public partial class LeaguesRankView : UserControl
    {
        public string LoginName { get; set; }

        public LeaguesRankView()
        {
            InitializeComponent();
        }

        private void MetroAnimatedSingleRowTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.DataContext != null)
            {
                string rank = ((TabItem)((MetroAnimatedSingleRowTabControl)sender).SelectedValue).Header.ToString();

                if (this.DataContext.GetType().ToString() != "RiotSharp.League_V3.LeagueListDTO")
                {
                    return;
                }

                var leagueItems = ((LeagueListDTO)this.DataContext).Entries.Where(entr => entr.Rank == rank).ToList();

                List<LeaguesRankDataModel> lrdList = new List<LeaguesRankDataModel>();
                foreach (var lItem in leagueItems)
                {
                    LeaguesRankDataModel lrdm = new LeaguesRankDataModel(lItem);
                    if (lItem.PlayerOrTeamName == LoginName)
                    {
                        lrdm.IsMyForeground = "OrangeRed";
                    }

                    if (lItem.MiniSeries != null)
                    {
                        lrdm.IsPromotionFlg = true;
                        lrdm.IsPromotionBG = "Azure";
                    }
                    else
                    {
                        lrdm.IsPromotionFlg = false;
                        lrdm.IsPromotionBG = "White";
                    }
                        

                    lrdm.WinningPercentage = string.Format("{0}%",
                        (Math.Round((decimal)lItem.Wins / (decimal)(lItem.Wins + lItem.Losses) * 100, 2)).ToString());

                    lrdList.Add(lrdm);
                }

                lrdList.Sort(delegate(LeaguesRankDataModel lrdX, LeaguesRankDataModel lrdY)
                {
                    if (lrdX.LeagueItem.LeaguePoints > lrdY.LeagueItem.LeaguePoints)
                    {
                        return -1;
                    }
                    else if (lrdX.LeagueItem.LeaguePoints < lrdY.LeagueItem.LeaguePoints)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                });

                for (int i = lrdList.Count - 1; i >= 0; i--)
                {
                    if (lrdList[i].LeagueItem.MiniSeries != null)
                    {
                        LeaguesRankDataModel lrdBK = new LeaguesRankDataModel();
                        lrdBK = lrdList[i];
                        lrdList.Remove(lrdList[i]);

                        lrdList.Insert(0, lrdBK);
                    }
                }

                int msIndex = 0;
                for (int index = 0; index < lrdList.Count; index++)
                {
                    if (lrdList[index].LeagueItem.MiniSeries == null)
                    {
                        lrdList[index].RowNumber = (msIndex + 1).ToString();
                        msIndex++;
                    }
                    else
                    {
                        lrdList[index].RowNumber = "★";
                    }
                }

                this.LeaguesRankDataGV.LeaguesRankDataGrid.ItemsSource = lrdList;


                if (lrdList != null && lrdList.Count > 0)
                {
                    if (lrdList.SingleOrDefault(li => li.LeagueItem.PlayerOrTeamName == LoginName) != null)
                    {
                        int index = lrdList.IndexOf(lrdList.SingleOrDefault(li => li.LeagueItem.PlayerOrTeamName == LoginName));
                        if ((index + 5) > (lrdList.Count - 1))
                        {
                            this.LeaguesRankDataGV.LeaguesRankDataGrid.ScrollIntoView(lrdList.LastOrDefault());
                        }
                        else
                        {
                            this.LeaguesRankDataGV.LeaguesRankDataGrid.ScrollIntoView(lrdList[index + 5]);
                        }

                    }
                    else
                    {
                        this.LeaguesRankDataGV.LeaguesRankDataGrid.ScrollIntoView(lrdList[0]);
                    }
                }
            }
        }
    }
}
