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
using System.Windows.Shapes;

namespace KanbanBoardWPF
{
    /// <summary>
    /// Interaktionslogik für CardOptions.xaml
    /// </summary>
    public partial class CardOptions : Window
    {
        Label labCard;
        Grid posGrid;
        Card choosenCard;
        public CardOptions(Label card,Grid pos)
        {
            InitializeComponent();
            labCard = card;
            posGrid = pos;
            choosenCard = new Card(string.Empty,Brushes.White);
        }

        private void status_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToString(labCard.Tag) == "To Do")
                labCard.Tag = "Doing";
            if (Convert.ToString(labCard.Tag) == "Doing")
                labCard.Tag = "Done";

        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            choosenCard.RemoveCard(labCard, posGrid);
            Close();
        }
    }
}
