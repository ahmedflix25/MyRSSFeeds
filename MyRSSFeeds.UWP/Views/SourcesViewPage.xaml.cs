﻿using MyRSSFeeds.Core.Helpers;
using MyRSSFeeds.UWP.ViewModels;
using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace MyRSSFeeds.UWP.Views
{
    public sealed partial class SourcesViewPage : Page
    {
        public SourcesViewModel ViewModel { get; } = new SourcesViewModel();

        public SourcesViewPage()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel.LoadDataAsync(new Progress<int>(percent => ViewModel.ProgressCurrent = percent), ViewModel.TokenSource.Token).FireAndGet();
        }
    }
}
