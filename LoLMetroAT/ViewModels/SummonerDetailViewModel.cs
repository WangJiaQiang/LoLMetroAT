using JetBrains.Annotations;
using RiotSharp.League_V3;
using RiotSharp.Summoner_V3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace LoLMetroAT.ViewModels
{
    public class SummonerDetailViewModel : INotifyPropertyChanged
    {
        public SummonerDetailViewModel()
        {

        }

        public SummonerDetailViewModel(SummonerDTO summoner)
        {
            Summoner = summoner;
        }

        private SummonerDTO m_Summoner;
        [DisplayName("Summoner")]
        public SummonerDTO Summoner
        {
            get { return m_Summoner; }
            set
            {
                m_Summoner = value;
                OnPropertyChanged("Summoner");

                GetLeaguePositionsAsync();
            }
        }

        private async void GetLeaguePositionsAsync()
        {
            await Task.Run(() =>
            {
                var lpDtos = MainWindow.m_RiotApi.GetLeaguePositionsBySummoner(m_Summoner.Region, m_Summoner.Id);
                if (lpDtos != null && lpDtos.Count > 0)
                {
                    LeaguePosition = lpDtos[0];
                }
            });
        }

        public bool IsEnabled
        {
            get;
            private set;
        }

        private LeaguePositionDTO m_LeaguePositionDTO;
        [DisplayName("LeaguePosition")]
        public LeaguePositionDTO LeaguePosition
        {
            get { return m_LeaguePositionDTO; }
            set
            {
                m_LeaguePositionDTO = value;
                OnPropertyChanged("LeaguePosition");

                if (m_LeaguePositionDTO != null)
                {
                    WinningPercentage = (Math.Round((decimal)m_LeaguePositionDTO.Wins / (decimal)(m_LeaguePositionDTO.Wins + m_LeaguePositionDTO.Losses) * 100, 2)).ToString();
                }
            }
        }

        private string m_WinningPercentage;
        [DisplayName("WinningPercentage")]
        public string WinningPercentage
        {
            get
            {
                string strRet = string.Empty;
                if (m_Summoner.Region == RiotSharp.Misc.Region.jp)
                {
                    strRet = "勝率";
                }
                else
                {
                    strRet = "AVG";
                }

                return string.Format("{0}：{1}%", strRet, m_WinningPercentage);
            }
            set
            {
                m_WinningPercentage = value;
                OnPropertyChanged("WinningPercentage");
            }
        }
















        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
