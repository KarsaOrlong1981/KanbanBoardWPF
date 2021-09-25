using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace KanbanBoardWPF
{
    public class Card
    {
        string status;
        string cardContent;
        Label labCard;
        Brush cardColor;
        public Card(string content, Brush color)
        {
            cardContent = content;
            cardColor = color;

        }
        public Label SetCard()
        {
            
            Label card = new Label
            {
                Width = 100,
                Background = cardColor,
                FontSize = 20.0,
                Foreground = Brushes.Black,
                Tag = "To Do"
            };
            AccessText txt = new AccessText();
            txt.TextWrapping = TextWrapping.Wrap;
            txt.Text = cardContent;
            card.Content = txt;
            
            return card;
          
        }

        public void RemoveCard(Label card,Grid position)
        {
            position.Children.Remove(card);
        }
    }
}
