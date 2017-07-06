using JetBrains.Annotations;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace LoLMetroAT.ViewModels
{
    public class LoginViewModel : IDataErrorInfo, INotifyPropertyChanged
    {
        public LoginViewModel()
        {

        }

        public string[] Enums { get; set; }

        private bool m_SummonerNameInitFlag = false;
        private string m_SummonerName = string.Empty;
        public string SummonerName
        {
            get
            {
                return m_SummonerName;
            }
            set
            {
                m_SummonerName = value;

                m_SummonerNameInitFlag = true;
            }
        }

        private bool m_RegionInitFlag = false;
        private string m_Region = string.Empty;
        public string Region
        {
            get
            {
                return m_Region;
            }
            set
            {
                m_Region = value;

                m_RegionInitFlag = true;
            }
        }

        private string m_ErrorMsg = string.Empty;
        public string ErrorMsg
        {
            get
            {
                return m_ErrorMsg;
            }
            set
            {
                m_ErrorMsg = value;
                OnPropertyChanged();
            }
        }

        public void SetInitFlag(string columnName, bool flag)
        {
            if (columnName == "SummonerName")
            {
                m_SummonerNameInitFlag = true;
            }
            else if (columnName == "Region")
            {
                m_RegionInitFlag = true;
            }
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == "SummonerName")
                {
                    if (this.m_SummonerNameInitFlag && string.IsNullOrWhiteSpace(this.m_SummonerName))
                    {
                        return "Please Check Your Summoner Name.";
                    }
                }

                if (columnName == "Region")
                {
                    if (this.m_RegionInitFlag && string.IsNullOrWhiteSpace(this.m_Region))
                    {
                        return "Please Check Your Region.";
                    }
                }

                return null;
            }
        }

        public string Error { get { return string.Empty; } }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
