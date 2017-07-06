using LoLMetroAT.Models;
using LoLMetroAT.ViewModels;
using MahApps.Metro.Controls;
using MahApps.Metro.SimpleChildWindow;
using RiotSharp.Match_V3;
using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

namespace LoLMetroAT.Views
{
    /// <summary>
    /// GameMatchView.xaml の相互作用ロジック
    /// </summary>
    public partial class GameMatchView : UserControl
    {
        private const int TEAM_ID_1 = 100;
        private const int TEAM_ID_2 = 200;

        public GameMatchView()
        {
            InitializeComponent();
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Some operations with this row
            GameDetailView gdv = new GameDetailView();
            DataGridRow row = sender as DataGridRow;
            MainWindow mw = this.TryFindParent<MetroWindow>() as MainWindow;

            try
            {
                MatchReferenceBinding dcMrb = (MatchReferenceBinding)row.DataContext;
                gdv = GameDetailViewInit(dcMrb);
                mw.GameDetailChildWindow.Content = gdv;
            }
            catch(Exception ex)
            {
                ((GameDetailViewModel)gdv.DataContext).ErrorMessage = ex.Message;
            }
            finally
            {
                mw.LoLDataRefresh.IsEnabled = false;
                mw.LoLSummonerLogin.IsEnabled = false;
                mw.GameDetailChildWindow.IsOpen = true;
            }
        }

        private GameDetailView GameDetailViewInit(MatchReferenceBinding dcMrb)
        {
            GameDetailView gdv = new GameDetailView();
            GameDetailViewModel gdvm = new GameDetailViewModel();

            if (dcMrb.MatchDetail == null)
            {
                dcMrb.MatchDetail = MainWindow.m_RiotApi.GetMatch(MainWindow.m_Region, dcMrb.MatchReference.GameId);
            }

            gdvm.Teams = dcMrb.MatchDetail.Teams;
            gdvm.GameCreation = dcMrb.MatchDetail.GameCreation;
            //gdvm.GameDuration = dcMrb.MatchDetail.GameDuration;

            //gdvm.Timeline = dcMrb.MatchDetail.Timeline;
            //gdvm.MapType = dcMrb.MatchDetail.MapType;
            //gdvm.MatchId = dcMrb.MatchDetail.MatchId;
            //gdvm.MatchMode = dcMrb.MatchDetail.MatchMode;
            //gdvm.MatchType = dcMrb.MatchDetail.MatchType;
            //gdvm.MatchVersion = dcMrb.MatchDetail.MatchVersion;
            //gdvm.QueueType = dcMrb.MatchDetail.QueueType;
            //gdvm.Region = dcMrb.MatchDetail.Region;
            //gdvm.Season = dcMrb.MatchDetail.Season;
            gdv.DataContext = gdvm;

            if (dcMrb.MatchDetail.Participants.Count > 10)
            {

            }
            else
            {
                ParticipantDto[] lstPart1 = dcMrb.MatchDetail.Participants.Where(part => part.TeamId == TEAM_ID_1).ToArray();
                ParticipantDto[] lstPart2 = dcMrb.MatchDetail.Participants.Where(part => part.TeamId == TEAM_ID_2).ToArray();

                GameDetailItemViewsInit(dcMrb, lstPart1, gdv.SP1.Children);
                GameDetailItemViewsInit(dcMrb, lstPart2, gdv.SP2.Children);
            }

            return gdv;
        }

        private void GameDetailItemViewsInit(
            MatchReferenceBinding dcMrb,
            ParticipantDto[] lstPart, 
            UIElementCollection Children)
        {
            long allTotalDamageDealtToChampions = lstPart.Sum(part => part.Stats.TotalDamageDealtToChampions);

            for (int i = 0; i < lstPart.Length; i++)
            {
                var child = Children[i];
                var part = lstPart[i];

                GameDetailItemView gdiv = (GameDetailItemView)child;
                GameDetailItemViewModel gdivm = new GameDetailItemViewModel();
                gdivm.Part = part;

                if (gdivm.Part.ChampionId == dcMrb.MatchReference.Champion)
                    gdivm.IsSelfDataFlag = true;
                else
                    gdivm.IsSelfDataFlag = false;

                gdivm.PartIdentity = dcMrb.MatchDetail.ParticipantIdentities.SingleOrDefault(partIdent => partIdent.ParticipantId == part.ParticipantId);

                gdivm.AllDamageDealtToChampions = allTotalDamageDealtToChampions;

                gdiv.DataContext = gdivm;
            }
        }
    }
}
