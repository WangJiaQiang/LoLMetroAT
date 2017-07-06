using JetBrains.Annotations;
using RiotSharp.Match_V3;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LoLMetroAT.ViewModels
{
    public class GameDetailItemViewModel : INotifyPropertyChanged
    {
        private ParticipantDto m_Participant;
        /// <summary>
        /// Participant
        /// </summary>
        [DisplayName("Part")]
        public ParticipantDto Part
        { 
            get { return m_Participant; } 
            set 
            { 
                m_Participant = value;
                OnPropertyChanged("Part");

                m_AllMinionsKilled = m_Participant.Stats.TotalMinionsKilled;
                OnPropertyChanged("AllMinionsKilled");

                m_Kda = string.Format("{0} / {1} / {2}", m_Participant.Stats.Kills, m_Participant.Stats.Deaths, m_Participant.Stats.Assists);
                OnPropertyChanged("KDA");
            } 
        }

        private ParticipantIdentityDto m_ParticipantIdentity;
        /// <summary>
        /// Participant Identity.
        /// </summary>
        [DisplayName("PartIdentity")]
        public ParticipantIdentityDto PartIdentity { get { return m_ParticipantIdentity; } set { m_ParticipantIdentity = value; OnPropertyChanged("PartIdentity"); } }


        private bool m_IsSelfDataFlag = false;
        [DisplayName("IsSelfDataFlag")]
        public bool IsSelfDataFlag
        {
            get { return m_IsSelfDataFlag; }
            set
            {
                m_IsSelfDataFlag = value;
                OnPropertyChanged("IsSelfDataFlag");
            }
        }


        long m_AllDamageDealtToChampions;
        [DisplayName("AllDamageDealtToChampions")]
        public long AllDamageDealtToChampions
        {
            get { return m_AllDamageDealtToChampions; }
            set
            {
                m_AllDamageDealtToChampions = value;
                OnPropertyChanged("AllDamageDealtToChampions");
            }
        }

        long m_AllMinionsKilled;
        [DisplayName("AllMinionsKilled")]
        public long AllMinionsKilled
        {
            get { return m_AllMinionsKilled; }
            set
            {
                m_AllMinionsKilled = value;
                OnPropertyChanged("AllMinionsKilled");
            }
        }

        string m_Kda;
        [DisplayName("KDA")]
        public string KDA
        {
            get { return m_Kda; }
            set
            {
                m_Kda = value;
                OnPropertyChanged("KDA");
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
