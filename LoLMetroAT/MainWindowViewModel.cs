using JetBrains.Annotations;
using LoLMetroAT.Models;
using MahApps.Metro;
using RiotSharp.Champion_Mastery_V3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace LoLMetroAT
{
    /// <summary>
    /// 主要なウィンドウ眺めモデル
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged, IDataErrorInfo, IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        public MainWindowViewModel()
        {

        }

        #region プロパティ

        /// <summary>
        /// アクセント色
        /// </summary>
        public List<AccentColorMenuData> AccentColors { get; set; }

        List<MatchReferenceBinding> m_listMatchReference = null;
        [DisplayName("ListMatchReference")]
        public List<MatchReferenceBinding> ListMatchReference
        {
            get
            {
                return m_listMatchReference;
            }
            set
            {
                this.m_listMatchReference = value;
                RaisePropertyChanged("ListMatchReference");
            }
        }

        List<MatchReferenceBinding> m_listMatchReferenceBk = null;
        [DisplayName("ListMatchReferenceBK")]
        public List<MatchReferenceBinding> ListMatchReferenceBK
        {
            get
            {
                return m_listMatchReferenceBk;
            }
            set
            {
                this.m_listMatchReferenceBk = value;
                RaisePropertyChanged("ListMatchReferenceBK");
            }
        }

        List<ChampionMasteryBinding> m_listChampionMasteries = null;
        [DisplayName("ListChampionMasteries")]
        public List<ChampionMasteryBinding> ListChampionMasteries
        {
            get
            {
                return m_listChampionMasteries;
            }
            set
            {
                this.m_listChampionMasteries = value;
                RaisePropertyChanged("ListChampionMasteries");
            }
        }

        /// <summary>
        /// 主要なスクリーン幅
        /// </summary>
        public double PrimaryScreenWidth { 
            get 
            { 
                //return SystemParameters.PrimaryScreenWidth * 0.8; 
                return 1024;
            } 
        }

        /// <summary>
        /// 主要なスクリーン高さ
        /// </summary>
        public double PrimaryScreenHeight { 
            get 
            { 
                //return SystemParameters.PrimaryScreenHeight * 0.7; 
                return 768;
            } 
        }

        /// <summary>
        /// 
        /// </summary>
        public string TabAllGamesName
        {
            get
            {
                // return string.Format("All Rank Games x{0}", MatchListToFrom ==null ? 0: MatchListToFrom.Count);
                return "All Rank Games";
            }
        }

        Boolean m_showCloseButtonFlg = false;
        [DisplayName("ShowCloseButtonFlg")]
        public Boolean ShowCloseButtonFlg
        {
            get
            {
                return m_showCloseButtonFlg;
            }
            set
            {
                this.m_showCloseButtonFlg = value;
                RaisePropertyChanged("ShowCloseButtonFlg");
            }
        }

        #endregion

        /// <summary>
        /// プロパティ変更イベント
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        //[NotifyPropertyChangedInvocator]
        //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    var handler = PropertyChanged;
        //    if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        //}

        /// <summary>
        /// 必要ならば、プロパティ変更イベントを上げます。
        /// </summary>
        /// <param name="propertyName">変わったプロパティの名前。</param>
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string this[string columnName]
        {
            get
            {
                return null;
            }
        }

        public string Error { get { return string.Empty; } }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

    /// <summary>
    /// アクセント色メニューデータ
    /// </summary>
    public class AccentColorMenuData
    {
        public string Name { get; set; }
        public Brush BorderColorBrush { get; set; }
        public Brush ColorBrush { get; set; }

        private ICommand changeAccentCommand;

        public ICommand ChangeAccentCommand
        {
            get { return this.changeAccentCommand ?? (changeAccentCommand = new SimpleCommand { CanExecuteDelegate = x => true, ExecuteDelegate = x => this.DoChangeTheme(x) }); }
        }

        protected virtual void DoChangeTheme(object sender)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            var accent = ThemeManager.GetAccent(this.Name);
            ThemeManager.ChangeAppStyle(Application.Current, accent, theme.Item1);
        }
    }

    /// <summary>
    /// 簡単なコマンド
    /// </summary>
    public class SimpleCommand : ICommand
    {
        public Predicate<object> CanExecuteDelegate { get; set; }
        public Action<object> ExecuteDelegate { get; set; }

        public bool CanExecute(object parameter)
        {
            if (CanExecuteDelegate != null)
                return CanExecuteDelegate(parameter);
            return true; // if there is no can execute default to true
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            if (ExecuteDelegate != null)
                ExecuteDelegate(parameter);
        }
    }
}
