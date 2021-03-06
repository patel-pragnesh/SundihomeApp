﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SundihomeApp.Views.Furniture;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SundihomeApp.Views.Cells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OutgoingFurnitureProductViewCell : ViewCell
    {
        public OutgoingFurnitureProductViewCell()
        {
            InitializeComponent();
        }
        private async void Tapped(object sender, EventArgs e)
        {
            var grid = sender as StackLayout;
            TapGestureRecognizer tapGesture = grid.GestureRecognizers[0] as TapGestureRecognizer;
            Guid PostId = Guid.Parse(tapGesture.CommandParameter.ToString());
            await Shell.Current.Navigation.PushAsync(new ProductDetailPage(PostId));
        }
    }
}
