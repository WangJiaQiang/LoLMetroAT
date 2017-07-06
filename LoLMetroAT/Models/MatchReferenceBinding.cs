using JetBrains.Annotations;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using RiotSharp.Match_V3;

namespace LoLMetroAT.Models
{
    public class MatchReferenceBinding : INotifyPropertyChanged
    {
        private MatchReferenceDto m_matchReferenceDto;
        [DisplayName("MatchReference")]
        public MatchReferenceDto MatchReference
        {
            get { return m_matchReferenceDto; }
            set
            {
                if (Equals(value, m_matchReferenceDto)) return;
                m_matchReferenceDto = value;
                OnPropertyChanged("MatchReference");
            }
        }

        private MatchDto m_matchDetailDto;
        [DisplayName("MatchDetail")]
        public MatchDto MatchDetail
        {
            get { return m_matchDetailDto; }
            set
            {
                if (Equals(value, m_matchDetailDto)) return;
                m_matchDetailDto = value;
                OnPropertyChanged("MatchDetail");

                m_isMySelfWinnerCentent = m_matchDetailDto.Participants.SingleOrDefault(part => part.ChampionId == m_matchReferenceDto.Champion
                        ).Stats.Win == true ? "VICTORY" : "DEFEAT";
                OnPropertyChanged("IsMySelfWinnerCentent");
            }
        }

        private string m_isMySelfWinnerCentent;
        [DisplayName("IsMySelfWinnerCentent")]
        public string IsMySelfWinnerCentent
        {
            get { return m_isMySelfWinnerCentent; }
            set
            {
                m_isMySelfWinnerCentent = value;
                OnPropertyChanged("IsMySelfWinnerCentent");
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
