using JetBrains.Annotations;
using RiotSharp.League_V3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace LoLMetroAT.ViewModels
{
    public class LeaguesRankDataModel : INotifyPropertyChanged
    {
        public LeaguesRankDataModel() { }

        public LeaguesRankDataModel(LeagueItemDTO item)
        {
            m_LeagueItem = item;
        }

        private string m_RowNumber;
        /// <summary>
        /// RowNumber
        /// </summary>
        [DisplayName("RowNumber")]
        public string RowNumber
        {
            get { return m_RowNumber; }
            set
            {
                m_RowNumber = value;
                OnPropertyChanged("RowNumber");
            }
        }

        private LeagueItemDTO m_LeagueItem;
        /// <summary>
        /// LeagueItem
        /// </summary>
        [DisplayName("LeagueItem")]
        public LeagueItemDTO LeagueItem
        {
            get { return m_LeagueItem; }
            set
            {
                m_LeagueItem = value;
                OnPropertyChanged("LeagueItem");
            }
        }

        private string m_IsMyForeground = "#879292";
        /// <summary>
        /// IsMyForeground
        /// </summary>
        [DisplayName("IsMyForeground")]
        public string IsMyForeground
        {
            get { return m_IsMyForeground; }
            set
            {
                m_IsMyForeground = value;
                OnPropertyChanged("IsMyForeground");
            }
        }

        private string m_IsPromotionBG = "White";
        /// <summary>
        /// IsPromotionBG
        /// </summary>
        [DisplayName("IsPromotionBG")]
        public string IsPromotionBG
        {
            get { return m_IsPromotionBG; }
            set
            {
                m_IsPromotionBG = value;
                OnPropertyChanged("IsPromotionBG");
            }
        }


        private bool m_IsPromotionFlg = false;
        /// <summary>
        /// IsPromotionFlg
        /// </summary>
        [DisplayName("IsPromotionFlg")]
        public bool IsPromotionFlg
        {
            get { return m_IsPromotionFlg; }
            set
            {
                m_IsPromotionFlg = value;
                OnPropertyChanged("IsPromotionFlg");

                if (m_IsPromotionFlg)
                {
                    LeaguePointsVisibility = "Hidden";
                    PromotionVisibility = "Visible";

                    PromotionContent = string.Format("昇格中：{0}勝 / {1}敗", m_LeagueItem.MiniSeries.Wins, m_LeagueItem.MiniSeries.Losses);
                }
                else
                {
                    LeaguePointsVisibility = "Visible";
                    PromotionVisibility = "Hidden";
                }
            }
        }

        private string m_PromotionContent;
        /// <summary>
        /// PromotionContent
        /// </summary>
        [DisplayName("PromotionContent")]
        public string PromotionContent
        {
            get { return m_PromotionContent; }
            set
            {
                m_PromotionContent = value;
                OnPropertyChanged("PromotionContent");
            }
        }

        private string m_LeaguePointsVisibility;
        /// <summary>
        /// IsPromotionFlg
        /// </summary>
        [DisplayName("LeaguePointsVisibility")]
        public string LeaguePointsVisibility
        {
            get { return m_LeaguePointsVisibility; }
            set
            {
                m_LeaguePointsVisibility = value;
                OnPropertyChanged("LeaguePointsVisibility");
            }
        }

        private string m_PromotionVisibility;
        /// <summary>
        /// IsPromotionFlg
        /// </summary>
        [DisplayName("PromotionVisibility")]
        public string PromotionVisibility
        {
            get { return m_PromotionVisibility; }
            set
            {
                m_PromotionVisibility = value;
                OnPropertyChanged("PromotionVisibility");
            }
        }

        private string m_WinningPercentage;
        [DisplayName("WinningPercentage")]
        public string WinningPercentage
        {
            get
            {
                return m_WinningPercentage;
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
