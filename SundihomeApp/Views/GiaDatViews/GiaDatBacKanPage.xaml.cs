﻿using System;
using System.Collections.Generic;
using SundihomeApp.Helpers;
using SundihomeApp.ViewModels.GiaDatViewModels;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace SundihomeApp.Views.GiaDatViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GiaDatBacKanPage : ContentPage
    {
        public GiaDatBacKanPageViewModel viewModel;
        public GiaDatBacKanPage()
        {
            InitializeComponent();
            this.BindingContext = viewModel = new GiaDatBacKanPageViewModel();
            On<iOS>().SetUseSafeArea(true);
            Init();

        }
        public async void Init()
        {
            await viewModel.GetDistrictAsync();
            loadingPopup.IsVisible = false;
        }

        private async void District_Changed(object sender, EventArgs e)
        {
            loadingPopup.IsVisible = true;
            this.viewModel.StreetDistances.Clear();
            this.viewModel.Street = null;
            this.viewModel.StreetDistance = null;
            await this.viewModel.LoadStreets();
            loadingPopup.IsVisible = false;
        }


        private async void Street_Changed(object sender, EventArgs e)
        {
            loadingPopup.IsVisible = true;
            await this.viewModel.LoadStreetDistances();
            if (this.viewModel.StreetDistances.Count > 0)
            {
                this.viewModel.StreetDistance = this.viewModel.StreetDistances[0];
            }
            else
            {
                this.viewModel.StreetDistance = null;
            }
            loadingPopup.IsVisible = false;
        }
    }
}
