﻿using MyRSSFeeds.ViewModels;
using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace MyRSSFeeds.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
            ViewModel.Initialize(webView);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel.LoadDataAsync(new Progress<int>(percent => ViewModel.ProgressCurrent = percent), ViewModel.TokenSource.Token).ConfigureAwait(true);
        }
    }
}