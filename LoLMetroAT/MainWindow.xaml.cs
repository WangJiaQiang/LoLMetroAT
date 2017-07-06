using LoLMetroAT.Models;
using LoLMetroAT.ViewModels;
using LoLMetroAT.Views;
using MahApps.Metro;
using MahApps.Metro.Controls;
using RiotSharp;
using RiotSharp.Champion_Mastery_V3;
using RiotSharp.Lol_Static_Data_V3;
using RiotSharp.Match_V3;
using RiotSharp.Misc;
using RiotSharp.Summoner_V3;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace LoLMetroAT
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private readonly static string apiKey = ConfigurationManager.AppSettings["ApiKey"];

        public static RiotApi m_RiotApi = RiotApi.GetInstance(apiKey);
        public static StaticRiotApi m_StaticRiotApi = StaticRiotApi.GetInstance(apiKey);

        public static Region m_Region = Region.jp;

        /// <summary>
        /// 
        /// </summary>
        public readonly MainWindowViewModel _viewModel;

        /// <summary>
        /// 
        /// </summary>
        private DispatcherTimer _timer = null;

        /// <summary>
        /// 
        /// </summary>
        private LoginView _loginView = null;

        /// <summary>
        /// 
        /// </summary>
        private SummonerDTO _loginSummoner = null;

        public MainWindow()
        {
            _viewModel = new MainWindowViewModel();
            DataContext = _viewModel;

            InitializeComponent();

            // タイマーを作成する
            _timer = new DispatcherTimer(DispatcherPriority.Normal, this.Dispatcher);
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += new EventHandler(DispatcherTimer_Tick);
            // タイマーの実行開始
            _timer.Start();
        }

        private void LoginViewInit()
        {
            _loginView = new LoginView();
            var loginViewModel = new LoginViewModel();
            loginViewModel.Enums = Enum.GetNames(typeof(Region));

            _loginView.DataContext = loginViewModel;

            _loginView.LoginBtn.Click += LoginBtn_Click;
            _loginView.CancelBtn.Click += CancelBtn_Click;
        }

        #region Main Event

        private void MetroWindow_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this._viewModel.AccentColors == null)
            {
                this._viewModel.AccentColors = ThemeManager.Accents
                                .Select(a => new AccentColorMenuData() { Name = a.Name, ColorBrush = a.Resources["AccentColorBrush"] as Brush })
                                .ToList();
            }

            LoginViewInit();
            this.LoginChildWindow.Content = _loginView;
            this.LoginChildWindow.IsOpen = true;
        }

        private void CancelBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.LoginChildWindow.IsOpen = false;
            this.Close();
        }

        private void LoginBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var lvm = (LoginViewModel)_loginView.DataContext;

            if (!string.IsNullOrEmpty(lvm.SummonerName) && !string.IsNullOrEmpty(lvm.Region))
            {
                this._loginView.FindChild<MetroProgressBar>("IsIndeterminatePB").Visibility = System.Windows.Visibility.Visible;
                this._loginView.FindChild<StackPanel>("StackPanel1").IsEnabled = false;
                this._loginView.FindChild<StackPanel>("StackPanel2").IsEnabled = false;
                this.GetLoginData(lvm.Region, lvm.SummonerName, true);
            }
            else
            {
                if (string.IsNullOrEmpty(lvm.SummonerName))
                {
                    lvm.SetInitFlag("SummonerName", true);

                    this._loginView.FindChild<TextBox>("TbxSummonerName").Text = string.Empty;
                    this._loginView.FindChild<TextBox>("TbxSummonerName").Focus();
                }

                if (string.IsNullOrEmpty(lvm.Region))
                {
                    lvm.SetInitFlag("Region", true);

                    this._loginView.FindChild<ComboBox>("CBoxRegion").SelectedIndex = 0;
                    this._loginView.FindChild<ComboBox>("CBoxRegion").SelectedIndex = -1;
                    this._loginView.FindChild<ComboBox>("CBoxRegion").Focus();
                }
            }
        }

        private void LoLSummonerLogin_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.LoginChildWindow.IsOpen = true;
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            // 現在時刻の更新(処理はメインスレッドで実行される)
            this.CurrentDate.Text = DateTime.Now.ToString();
        }

        #endregion

        private void DoEvents()
        {
            DispatcherFrame frame = new DispatcherFrame();
            var callback = new DispatcherOperationCallback(ExitFrames);
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, callback, frame);
            Dispatcher.PushFrame(frame);
        }

        private object ExitFrames(object obj)
        {
            ((DispatcherFrame)obj).Continue = false;
            return null;
        }

        // 非同期実行するためのデリゲート
        delegate LoginState LoginDelegate(string reg, string summName, bool loginTypeFlg);

        public void GetLoginData(string reg, string summName, bool loginTypeFlg)
        {
            // 実行するデリゲートを作成
            LoginDelegate sampleDelegate =
                new LoginDelegate(this.LoginDelegatingMethod);

            // コールバック関数
            AsyncCallback callback = new AsyncCallback(this.LoginCallBackMethod);

            // 非同期実行の呼び出し
            IAsyncResult ar =
                sampleDelegate.BeginInvoke(reg, summName, loginTypeFlg, callback, null);
        }

        // 非同期させたい（重たい）処理
        private LoginState LoginDelegatingMethod(string reg, string summName, bool loginTypeFlg)
        {
            LoginState loginStateRet = new LoginState();
            loginStateRet.LoginTypeFlg = loginTypeFlg;

            try
            {
                Region region = (Region)Enum.Parse(typeof(Region), reg);

                RiotSharp.Misc.Language language = RiotSharp.Misc.Language.en_US;
                if (region == Region.jp)
                {
                    language = RiotSharp.Misc.Language.ja_JP;
                }

                if (m_Region == region)
                {
                    if (!LoLStaticData.LoLStaticDataAlreadyLoaded())
                    {
                        //LoLStaticData.ItemsStaticData = m_StaticRiotApi.GetStaticItems(region, ItemData.all, language);
                        //LoLStaticData.ChampionsStaticData = m_StaticRiotApi.GetStaticChampions(region, ChampionData.all, language);
                        //LoLStaticData.SummonerSpellsStaticData = m_StaticRiotApi.GetStaticSummonerSpells(region, SummonerSpellData.all, language);
                    }
                }
                else
                {
                    //LoLStaticData.ItemsStaticData = m_StaticRiotApi.GetStaticItems(region, ItemData.all, language);
                    //LoLStaticData.ChampionsStaticData = m_StaticRiotApi.GetStaticChampions(region, ChampionData.all, language);
                    //LoLStaticData.SummonerSpellsStaticData = m_StaticRiotApi.GetStaticSummonerSpells(region, SummonerSpellData.all, language);
                }

                m_Region = region;

                _loginSummoner = m_RiotApi.GetSummonerByName(region, summName);

                var matches = m_RiotApi.GetMacthAllByAccountId(region, _loginSummoner.AccountId).Matches;
                var mrbListBk = new List<MatchReferenceBinding>();
                foreach (MatchReferenceDto mr in matches)
                {
                    var mrb = new MatchReferenceBinding();
                    mrb.MatchReference = mr;
                    mrbListBk.Add(mrb);
                }
                if (_viewModel.ListMatchReference != null) 
                {
                    _viewModel.ListMatchReference.Clear();
                    
                }
                if (_viewModel.ListMatchReferenceBK != null)
                {
                    _viewModel.ListMatchReferenceBK.Clear();
                }

                _viewModel.ListMatchReferenceBK = mrbListBk;
                _viewModel.ListMatchReference = mrbListBk;

                var championMasteries = m_RiotApi.GetChampionMasteries(region, _loginSummoner.Id);
                var cmbList = new List<ChampionMasteryBinding>();
                foreach (ChampionMasteryDTO cmDto in championMasteries)
                {
                    var cmb = new ChampionMasteryBinding(cmDto);
                    cmbList.Add(cmb);
                }

                for (int i = cmbList.Count - 1; i >= 0; i--)
                {
                    var existDto = _viewModel.ListMatchReferenceBK.Where(lmrBk => lmrBk.MatchReference.Champion == cmbList[i].ChampionMastery.ChampionId);

                    if (existDto == null || existDto.ToArray().Length == 0)
                    {
                        cmbList.RemoveAt(i);
                    }
                }
                if (_viewModel.ListChampionMasteries != null) _viewModel.ListChampionMasteries.Clear();

                var cmbEmpty = new ChampionMasteryBinding(new ChampionMasteryDTO());
                cmbEmpty.ChampionMastery.ChampionId = -1;
                cmbList.Insert(0, cmbEmpty);

                _viewModel.ListChampionMasteries = cmbList;

                loginStateRet.LoginErrorFlg = false;
                loginStateRet.LoginErrorMessage = string.Empty;
            }
            catch (RiotSharpException rsEx)
            {
                _viewModel.ListMatchReference = null;

                loginStateRet.LoginErrorFlg = true;
                loginStateRet.LoginErrorMessage = rsEx.Message;
            }
            catch (Exception ex)
            {
                _viewModel.ListMatchReference = null;

                if (ex.InnerException != null && ex.InnerException is RiotSharpException)
                {
                    loginStateRet.LoginErrorMessage = ex.InnerException.Message;
                }
                else
                {
                    loginStateRet.LoginErrorMessage = ex.Message;
                }

                loginStateRet.LoginErrorFlg = true;
            }

            return loginStateRet;
        }

        // コールバック関数：スレッド終了後の処理を記述
        private void LoginCallBackMethod(IAsyncResult ar)
        {
            // AsyncResultに変換
            AsyncResult asyncResult = ar as AsyncResult;

            // 非同期の呼び出しが行われたデリゲート オブジェクトを取得
            LoginDelegate sampleDelegate =
                asyncResult.AsyncDelegate as LoginDelegate;

            Dispatcher.Invoke(() =>
            {
                // 処理結果取得
                LoginState LoginStateRet = sampleDelegate.EndInvoke(ar);

                this.DataContext = null;

                this.ControlStateReBack();

                ((LoginViewModel)this._loginView.DataContext).ErrorMsg = LoginStateRet.LoginErrorMessage;

                // Set property or change UI compomponents.  
                if (!LoginStateRet.LoginErrorFlg)
                {
                    if (LoginStateRet.LoginTypeFlg)
                    {
                        this.LoginChildWindow.IsOpen = false;
                        if (!_viewModel.ShowCloseButtonFlg) _viewModel.ShowCloseButtonFlg = true;
                    }

                    this.SummonerDView.DataContext = new SummonerDetailViewModel(_loginSummoner);
                }

                this.DataContext = _viewModel;
                this.MainTabControl.SelectedIndex = 0;
                this.MainSubTabControl.SelectedIndex = 0;
            });
        }



        // 非同期実行するためのデリゲート
        delegate void MatchDetailDelegate();

        public void GetMatchDetailData()
        {
            // 実行するデリゲートを作成
            MatchDetailDelegate sampleDelegate =
                new MatchDetailDelegate(this.MatchDetailDelegatingMethod);

            // コールバック関数
            AsyncCallback callback = new AsyncCallback(this.MatchDetailCallBackMethod);

            // 非同期実行の呼び出し
            IAsyncResult ar =
                sampleDelegate.BeginInvoke(callback, null);
        }

        private void MatchDetailDelegatingMethod()
        {
            try
            {
                //foreach (MatchReferenceBinding mrb in _viewModel.ListMatchReference)
                //{
                //    var matchDetail = riotApi.GetMatch(m_Region, mrb.MatchReference.GameID);

                //    mrb.MatchDetail = matchDetail;

                //    mrb.IsMySelfWinnerCentent = mrb.MatchDetail.Participants.SingleOrDefault
                //        (part => part.ChampionId == mrb.MatchReference.ChampionID
                //        ).Stats.Winner == true ? "VICTORY" : "DEFEAT";
                //}
            }
            catch (Exception ex)
            {

            }
        }

        private void MatchDetailCallBackMethod(IAsyncResult ar) { }

        private void ControlStateReBack()
        {
            // Set property or change UI compomponents.  
            this._loginView.FindChild<MetroProgressBar>("IsIndeterminatePB").Visibility = System.Windows.Visibility.Hidden;
            this._loginView.FindChild<StackPanel>("StackPanel1").IsEnabled = true;
            this._loginView.FindChild<StackPanel>("StackPanel2").IsEnabled = true;
        }

        private void GameDetailChildWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.LoLSummonerLogin.IsEnabled == false)
            {
                this.LoLSummonerLogin.IsEnabled = true;
            }

            if (this.LoLDataRefresh.IsEnabled == false)
            {
                this.LoLDataRefresh.IsEnabled = true;
            }
        }

        private void LoLDataRefresh_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cmb = ((sender as ComboBox).SelectedItem as ChampionMasteryBinding);

            if (cmb != null)
            {
                if (cmb.ChampionMastery.ChampionId == -1)
                {
                    _viewModel.ListMatchReference = _viewModel.ListMatchReferenceBK;
                }
                else
                {
                    _viewModel.ListMatchReference = _viewModel.ListMatchReferenceBK.Where(lmr => lmr.MatchReference.Champion == cmb.ChampionMastery.ChampionId).ToList();
                }
            }
        }

        private void MetroAnimatedSingleRowTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (!e.Source.Equals(this.MainSubTabControl)) return;
                
                // LeaguesRank 処理
                if (this.TILeaguesRank.IsSelected)
                {
                    var leaguesRank = m_RiotApi.GetLeaguesBySummoner(m_Region, _loginSummoner.Id);

                    if (leaguesRank != null && leaguesRank.Count > 0)
                    {
                        if (leaguesRank != null && leaguesRank.Count > 0)
                        {
                            this.LeaguesRankV.DataContext = leaguesRank[0];

                            string myRank = leaguesRank[0].Entries.SingleOrDefault(entrie => entrie.PlayerOrTeamName == _loginSummoner.Name).Rank;

                            foreach (var tabItem in this.LeaguesRankV.LRTabControl.Items)
                            {
                                TabItem tItem = (TabItem)tabItem;

                                if (tItem.Header.ToString() == myRank)
                                {
                                    this.LeaguesRankV.LoginName = _loginSummoner.Name;
                                    this.LeaguesRankV.LRTabControl.SelectedItem = tItem;
                                    break;
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException is RiotSharpException)
                {
                    MessageBox.Show(ex.InnerException.Message, this.Name);
                }
                else
                {
                    MessageBox.Show(ex.Message, this.Name);
                }
            }
        }
    }
}
