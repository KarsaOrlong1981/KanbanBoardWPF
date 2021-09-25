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
    /// Interaktionslogik für KanBanBoard.xaml
    /// </summary>
    public partial class KanBanBoard : Window
    {
        string cardContent;
        Brush cardColor;
        bool isNewCard;
        Label kanbanCard;
        Card card;
        CardOptions options;
        public KanBanBoard(string content,Brush color,bool newCard)
        {
            InitializeComponent();
            if(newCard == true)
            {
                card = new Card(content, color);
                kanbanCard = card.SetCard();
                
                kanbanCard.MouseDown += new MouseButtonEventHandler(CardClick);
                grid.Children.Add(kanbanCard);
                if (Convert.ToString (kanbanCard.Tag) == "To Do")
                {
                    Grid.SetColumn(kanbanCard, 0);
                    //für die Row mit einer Schleife alle rows der Spalte 0 durchlaufen und mit einem int wert an die nächste freie pos setzen.
                    Grid.SetRow(kanbanCard, 1);
                }
                
            }
        }

        private void CardClick(object sender, MouseButtonEventArgs e)
        {
            //Hier muss ein Auswahl menue angezeigt werden um zwichen den optionen Bearbeiten, Löschen und Status ändern zu wählen
            //das ganze löse ich mit einer switch case konstruktion.
            options = new CardOptions(kanbanCard, grid);
            options.Show();
        }
    }
}
