using SofiaMetroStations.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SofiaMetroStations
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        readonly IList<Station> stations = new ObservableCollection<Station>();
        readonly StationManager manager = new StationManager();

        public MainPage()
        {
            BindingContext = stations;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            await this.RetrieveStations();
            base.OnAppearing();
        }

        async void OnRefresh(object sender, EventArgs e)
        {
            await RetrieveStations();
        }

        private async Task RetrieveStations()
        {
            var stationCollection = await manager.GetAll();

            foreach (Station station in stationCollection)
            {
                if (stations.All(b => b.Id != station.Id))
                    stations.Add(station);
            }
        }

        async void OnDetails(object sender, ItemTappedEventArgs e)
        {
            Station station = (Station)e.Item;

            StationDetails details = await manager.GetStationTimes(station.Id);

            await Navigation.PushModalAsync(
                new StationDetailsPage(details, station.Name));
        }
    }
}
