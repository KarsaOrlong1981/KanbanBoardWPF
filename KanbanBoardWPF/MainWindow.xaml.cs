using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Ribbon;
using System.Windows.Forms;
using Button = System.Windows.Controls.Button;
using TextBox = System.Windows.Controls.TextBox;
using MessageBox = System.Windows.MessageBox;

namespace KanbanBoardWPF
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      
        Brush color;
        Image picColor;
        Image picSet;
        Image smiley;
        System.Windows.Controls.TextBox ctb;
        string content;
        Frame frameColor;
        Grid btnGrid;

        public MainWindow()
        {
            InitializeComponent();

            frameColor = new Frame();
            picColor = new Image();
            picColor.Source = new BitmapImage(new Uri("icons/palette48.png", UriKind.Relative));
            picSet = new Image();
            picSet.Source = new BitmapImage(new Uri("icons/stecknadel30.png", UriKind.Relative));
            smiley = new Image();
            smiley.Source = new BitmapImage(new Uri("icons/smiley.png", UriKind.Relative));


            Button toDoBTN = new Button
            {
                Height = 40,
                Width = 200,
                Content = "Neue To Do Karte erstellen",
                Background = Brushes.Cyan,
                Foreground = Brushes.Black
            };
            toDoBTN.Click += new RoutedEventHandler(SetNewElement);

            Button showBoardBTN = new Button
            {
                Height = 40,
                Width = 200,
                Content = "Kanban Board anzeigen",
                Background = Brushes.Cyan,
                Foreground = Brushes.Black
            };
            showBoardBTN.Click += new RoutedEventHandler(ShowKanban);

           
            grid.Children.Add(toDoBTN);
            grid.Children.Add(showBoardBTN);
            Grid.SetRow(toDoBTN, 0);
            Grid.SetRow(showBoardBTN, 1);
        }

        private void ShowKanban(object sender, RoutedEventArgs e)
        {
            string dummy = string.Empty;

            KanBanBoard board = new KanBanBoard(dummy, color, false);
            board.Show();
            Close();
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
            frameColor = frame;
            TextBox tb = new TextBox
            {
                Margin = new Thickness(10),
                FontSize = 20.0,
                Width = 375,
                TextWrapping = TextWrapping.Wrap,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
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
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left


            };
            addColor.Click += new RoutedEventHandler(SetColor);

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
                HorizontalAlignment = System.Windows.HorizontalAlignment.Right


            };
            set.Click += new RoutedEventHandler(SetNewCard);
            Button patch = new Button
            {
                Width = 48,
                Height = 48,
                Content = smiley,
                ToolTip = "Anheften",
                Foreground = Brushes.Black,
                Background = Brushes.LightGray,
                Margin = new Thickness(10),
                BorderBrush = Brushes.LightGray,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center


            };
            patch.Click += new RoutedEventHandler(SetNewPatch);

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
            grid.Children.Add(patch);
            Grid.SetRow(tb, 0);
            Grid.SetRow(addColor, 2);
            Grid.SetRow(set, 2);
            Grid.SetRow(patch, 2);
            frame.Content = grid;

            canvas.Children.Add(frame);
            tb.Focus();

            color = frame.Background;
        }

        private void SetNewPatch(object sender, RoutedEventArgs e)
        {
            
        }

        private void SetColor(object sender, RoutedEventArgs e)
        {
            //einen neuen Standarddialog von Windows zur Farbauswahl erzeugen
            ColorDialog selectColor = new ColorDialog();
            //wurde der Dialog über OK geschlossen
            if (selectColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //dann die Farbe zuweisen
                //das geht nur über einen Umweg
                Color colorWPF = Color.FromArgb(selectColor.Color.A, selectColor.Color.R, selectColor.Color.G, selectColor.Color.B);
                color = new SolidColorBrush(colorWPF);
                frameColor.Background = color;
            }
        }

        private void SetNewCard(object sender, RoutedEventArgs e)
        {
            if (ctb.Text != string.Empty)
            {
                content = ctb.Text;
                KanBanBoard board = new KanBanBoard(content, color, true);
                board.Show();
                Close();
            }
            else
                MessageBox.Show("Bitte einen Text in die karte eintragen.");
        }

       


    }
}
