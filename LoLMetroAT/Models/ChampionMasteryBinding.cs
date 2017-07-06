using JetBrains.Annotations;
using RiotSharp.Champion_Mastery_V3;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LoLMetroAT.Models
{
    public class ChampionMasteryBinding : INotifyPropertyChanged
    {
        public ChampionMasteryBinding(ChampionMasteryDTO championMasteryDto)
        {
            m_championMasteryDto = championMasteryDto;
        }

        private ChampionMasteryDTO m_championMasteryDto;
        [DisplayName("ChampionMastery")]
        public ChampionMasteryDTO ChampionMastery
        {
            get { return m_championMasteryDto; }
            set
            {
                if (Equals(value, m_championMasteryDto)) return;
                m_championMasteryDto = value;
                OnPropertyChanged("ChampionMastery");
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
