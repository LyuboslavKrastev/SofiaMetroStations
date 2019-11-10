using Xamarin.Forms;
using System;
using System.Linq;
using SofiaMetroStations.Data;
using System.Collections.Generic;

namespace SofiaMetroStations
{
    public class StationDetailsPage : ContentPage
    {
        private Button route_1_button;
        private Button route_2_button;

        private const string ARROW_DOWN = "SHOW";
        private const string ARROW_UP = "HIDE";

        private StackLayout route_1_detailsLayout;
        private StackLayout route_2_detailsLayout;


        public StationDetailsPage(StationDetails details, string stationName)
        {
            var mainLabel = new Label
            {
                Text = $"Choose a route for station {stationName}",
                FontSize = 30
            };

            var route_1_name = new Label { Text = details.Route_1_Name, FontSize = 20 };
            var route_2_name = new Label { Text = details.Route_2_Name, FontSize = 20 };

            var modified_route_1_times = details.Route_1.Replace(",", " | ");
            var modified_route_2_times = details.Route_2.Replace(",", " | ");


            var view = new ScrollView();

            route_1_button = new Button
            {
                Text = ARROW_DOWN,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center
            };

            route_1_button.Clicked += (sender, e) =>
            {
                if (route_1_button.Text.Equals(ARROW_DOWN))
                {
                    route_1_button.Text = ARROW_UP;
                    route_1_detailsLayout.IsVisible = true;
                }
                else
                {
                    route_1_button.Text = ARROW_DOWN;
                    route_1_detailsLayout.IsVisible = false;
                }
            };

            route_2_button = new Button
            {
                Text = ARROW_DOWN,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center
            };

            route_2_button.Clicked += (sender, e) =>
            {
                if (route_2_button.Text.Equals(ARROW_DOWN))
                {
                    route_2_button.Text = ARROW_UP;
                    route_2_detailsLayout.IsVisible = true;
                }
                else
                {
                    route_2_button.Text = ARROW_DOWN;
                    route_2_detailsLayout.IsVisible = false;
                }
            };

            var route_1_baseLayout = new StackLayout
            {
                Children = { route_1_name, route_1_button },
                BackgroundColor = Color.Orange,
                Orientation = StackOrientation.Horizontal
            };

            var route_1_details = new Label
            {
                Text = modified_route_1_times,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.Center
            };

            route_1_detailsLayout = new StackLayout
            {
                Children = { route_1_details },
                BackgroundColor = Color.LightBlue,
                IsVisible = false
            };

            var route_2_baseLayout = new StackLayout
            {
                Children = { route_2_name, route_2_button },
                BackgroundColor = Color.Orange,
                Orientation = StackOrientation.Horizontal
            };

            var route_2_details = new Label
            {
                Text = modified_route_2_times,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.Center
            };

            route_2_detailsLayout = new StackLayout
            {
                Children = { route_2_details },
                BackgroundColor = Color.LightBlue,
                IsVisible = false
            };

            var layoutAll = new StackLayout
            {
                Children = {mainLabel, route_1_baseLayout, route_1_detailsLayout, route_2_baseLayout, route_2_detailsLayout },
                Spacing = 0,
                Padding = new Thickness(10, 10, 10, 10),
                Orientation = StackOrientation.Vertical
            };

            view.Content = layoutAll;
            Content = view;
        }
    }
}

