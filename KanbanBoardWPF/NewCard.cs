using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace KanbanBoardWPF
{
    public class NewCard
    {
        Brush color;
        Image picColor;
        Image picSet;
        TextBox ctb;
        string content;
        Canvas canvas;
        Grid btnGrid;
        //In die karten muss noch die Option Aufkleber hinzugefügt werden
        public NewCard(Canvas can,Grid  btngrid)
        {
            canvas = can;
            btnGrid = btngrid;
            picColor = new Image();
            picColor.Source = new BitmapImage(new Uri("icons/palette48.png", UriKind.Relative));
            picSet = new Image();
            picSet.Source = new BitmapImage(new Uri("icons/stecknadel30.png", UriKind.Relative));

            Button toDoBTN = new Button
            {
                Height = 40,
                Width = 200,
                Content = "Neue To Do Karte erstellen",
                Background = Brushes.Cyan,
                Foreground = Brushes.Black
            };
            toDoBTN.Click += new RoutedEventHandler(SetNewElement);

            Button busyBTN  = new Button
            {
                Height = 40,
                Width = 200,
                Content = "Neue Busy Karte erstellen",
                Background = Brushes.Cyan,
                Foreground = Brushes.Black
            };
            busyBTN.Click += new RoutedEventHandler(SetNewElement);

            btnGrid.Children.Add(toDoBTN);
            btnGrid.Children.Add(busyBTN);
            Grid.SetRow(toDoBTN, 0);
            Grid.SetRow(busyBTN, 1);
        }

        private void SetNewElement(object sender, RoutedEventArgs e)
        {
            Frame frame = new Frame
            {
                Background = Brushes.LightGray,
                Width = 400,

            };
            Canvas.SetLeft(frame, 400);
            Canvas.SetTop(frame, 40);

            TextBox tb = new TextBox
            {
                Margin = new Thickness(10),
                FontSize = 20.0,
                Width = 375,
                TextWrapping = TextWrapping.Wrap,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                Focusable = true,
                BorderBrush = Brushes.LightGray,
                Background = Brushes.LightGray

            };
            ctb = tb;

            Button addColor = new Button
            {
                Width = 48,
                Height = 48,
                Content = picColor,
                ToolTip = "Farbe wählen",
                Foreground = Brushes.Black,
                Background = Brushes.LightGray,
                Margin = new Thickness(10),
                BorderBrush = Brushes.LightGray,
                HorizontalAlignment = HorizontalAlignment.Left


            };

            Button set = new Button
            {
                Width = 48,
                Height = 48,
                Content = picSet,
                ToolTip = "Anheften",
                Foreground = Brushes.Black,
                Background = Brushes.LightGray,
                Margin = new Thickness(10),
                BorderBrush = Brushes.LightGray,
                HorizontalAlignment = HorizontalAlignment.Right


            };
            set.Click += new RoutedEventHandler(SetNewCard);

            Grid grid = new Grid { };
            RowDefinition row1 = new RowDefinition();
            RowDefinition row2 = new RowDefinition();
            RowDefinition row3 = new RowDefinition();
            row1.Height = new GridLength(1, GridUnitType.Star);
            row2.Height = new GridLength(1, GridUnitType.Star);
            row3.Height = new GridLength(1, GridUnitType.Star);

            grid.RowDefinitions.Add(row1);
            grid.RowDefinitions.Add(row2);
            grid.RowDefinitions.Add(row3);

            grid.Children.Add(tb);
            grid.Children.Add(addColor);
            grid.Children.Add(set);
            Grid.SetRow(tb, 0);
            Grid.SetRow(addColor, 2);
            Grid.SetRow(set, 2);
            frame.Content = grid;

            canvas.Children.Add(frame);
            tb.Focus();

            color = frame.Background;
        }

        private void SetNewCard(object sender, RoutedEventArgs e)
        {
            content = ctb.Text;
            Label card = new Label
            {
                Width = 400,
                Background = color,
                FontSize = 20.0,
                Foreground = Brushes.Black
            };
            AccessText txt = new AccessText();
            txt.TextWrapping = TextWrapping.Wrap;
            txt.Text = content;
            card.Content = txt;
            Canvas.SetLeft(card, 200);
            Canvas.SetTop(card, 200);
            canvas.Children.Add(card);
        }
    }
}
