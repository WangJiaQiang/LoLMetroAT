using JetBrains.Annotations;
using RiotSharp.Match_V3;
using RiotSharp.Match_V3.Enums;
using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Animation;

namespace LoLMetroAT.ViewModels
{
    public class GameDetailViewModel : INotifyPropertyChanged
    {
        private MapType m_MapType;
        /// <summary>
        /// Map type.
        /// </summary>
        [DisplayName("MapType")]
        public MapType MapType { get { return m_MapType; } set { m_MapType = value; OnPropertyChanged("MapType"); } }

        private DateTime m_GameCreation;
        /// <summary>
        /// Match creation time. Designates when the team select lobby is created and/or the match is made through
        /// match making, not when the game actually starts.
        /// </summary>
        [DisplayName("GameCreation")]
        public DateTime GameCreation { get { return m_GameCreation; } set { m_GameCreation = value; OnPropertyChanged("GameCreation"); } }

        private TimeSpan m_GameDuration;
        /// <summary>
        /// Match duration.
        /// </summary>
        [DisplayName("GameDuration")]
        public TimeSpan GameDuration { get { return m_GameDuration; } set { m_GameDuration = value; OnPropertyChanged("GameDuration"); } }

        private long m_MatchId;
        /// <summary>
        /// Match ID.
        /// </summary>
        [DisplayName("MatchId")]
        public long MatchId { get { return m_MatchId; } set { m_MatchId = value; OnPropertyChanged("MatchId"); } }

        private string m_MatchMode;
        /// <summary>
        /// Match mode.
        /// </summary>
        [DisplayName("MatchMode")]
        public string MatchMode { get { return m_MatchMode; } set { m_MatchMode = value; OnPropertyChanged("MatchMode"); } }

        private GameType m_MatchType;
        [DisplayName("MatchType")]
        public GameType MatchType { get { return m_MatchType; } set { m_MatchType = value; OnPropertyChanged("MatchType"); } }

        private string m_MatchVersion;
        /// <summary>
        /// Match version.
        /// </summary>
        [DisplayName("MatchVersion")]
        public string MatchVersion { get { return m_MatchVersion; } set { m_MatchVersion = value; OnPropertyChanged("MatchVersion"); } }

        ///// <summary>
        ///// Participants identity information.
        ///// </summary>
        //[DisplayName("participantIdentities")]
        //public List<ParticipantIdentity> ParticipantIdentities { get; set; }

        ///// <summary>
        ///// Participants information
        ///// </summary>
        //[DisplayName("participants")]
        //public List<Participant> Participants { get; set; }

        private QueueType m_QueueType;
        /// <summary>
        /// Match queue type.
        /// </summary>
        [DisplayName("QueueType")]
        public QueueType QueueType { get { return m_QueueType; } set { m_QueueType = value; OnPropertyChanged("QueueType"); } }

        private Region m_Region;
        /// <summary>
        /// Region where the match was played.
        /// </summary>
        [DisplayName("Region")]
        public Region Region { get { return m_Region; } set { m_Region = value; OnPropertyChanged("Region"); } }

        private Season m_Season;
        /// <summary>
        /// Season match was played.
        /// </summary>
        [DisplayName("Season")]
        public Season Season { get { return m_Season; } set { m_Season = value; OnPropertyChanged("Season"); } }

        private List<TeamStatsDto> m_Teams;
        /// <summary>
        /// Team information.
        /// </summary>
        [DisplayName("Teams")]
        public List<TeamStatsDto> Teams { get { return m_Teams; } set { m_Teams = value; OnPropertyChanged("Teams"); } }

        private Timeline m_Timeline;
        /// <summary>
        /// Match timeline data. Not included by default.
        /// </summary>
        [DisplayName("Timeline")]
        public Timeline Timeline { get { return m_Timeline; } set { m_Timeline = value; OnPropertyChanged("Timeline"); } }


        private string m_ErrorMessage;
        [DisplayName("ErrorMessage")]
        public string ErrorMessage { get { return m_ErrorMessage; } set { m_ErrorMessage = value; OnPropertyChanged("ErrorMessage"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
