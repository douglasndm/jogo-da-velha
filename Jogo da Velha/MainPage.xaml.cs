using Jogo_da_Velha.Classes;
using Jogo_da_Velha.Models;
using System;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Jogo_da_Velha
{
    public sealed partial class MainPage : Page
    {
        Player[] players = new Player[2];

        int velhas, vez;
        int movimentos = 0;

        public MainPage()
        {
            this.InitializeComponent();

            Customization.ChangeTitleBarColor(Colors.DeepSkyBlue, Colors.White);

            DesativarTodosBotoes();
            GridJogo.Opacity = 0;
        }

        private async void VerificarSeJogadorGanhor()
        {
            if ((string)button1.Content == "X" && (string)button2.Content == "X" && (string)button3.Content == "X" ||
                (string)button4.Content == "X" && (string)button5.Content == "X" && (string)button6.Content == "X" ||
                (string)button7.Content == "X" && (string)button8.Content == "X" && (string)button9.Content == "X" ||

                (string)button1.Content == "X" && (string)button4.Content == "X" && (string)button7.Content == "X" ||
                (string)button2.Content == "X" && (string)button5.Content == "X" && (string)button8.Content == "X" ||
                (string)button3.Content == "X" && (string)button6.Content == "X" && (string)button9.Content == "X" ||

                (string)button1.Content == "X" && (string)button5.Content == "X" && (string)button9.Content == "X" ||
                (string)button3.Content == "X" && (string)button5.Content == "X" && (string)button7.Content == "X")
            {
                players[0].Points++;
                AtualizarPlacar();
                DesativarTodosBotoes();

                var dialog = new MessageDialog(players[0].Name + " ganhou essa rodada!");
                await dialog.ShowAsync();

                NovaPartida();
            }
            else if ((string)button1.Content == "O" && (string)button2.Content == "O" && (string)button3.Content == "O" ||
                     (string)button4.Content == "O" && (string)button5.Content == "O" && (string)button6.Content == "O" ||
                     (string)button7.Content == "O" && (string)button8.Content == "O" && (string)button9.Content == "O" ||

                     (string)button1.Content == "O" && (string)button4.Content == "O" && (string)button7.Content == "O" ||
                     (string)button2.Content == "O" && (string)button5.Content == "O" && (string)button8.Content == "O" ||
                     (string)button3.Content == "O" && (string)button6.Content == "O" && (string)button9.Content == "O" ||

                     (string)button1.Content == "O" && (string)button5.Content == "O" && (string)button9.Content == "O" ||
                     (string)button3.Content == "O" && (string)button5.Content == "O" && (string)button7.Content == "O")
            {
                players[1].Points++;
                AtualizarPlacar();
                DesativarTodosBotoes();

                var dialog = new MessageDialog(players[1].Name + " ganhou essa rodada!");
                await dialog.ShowAsync();

                NovaPartida();
            }
            else if (movimentos >= 9)
            {
                velhas++;
                var dialog = new MessageDialog("Deu velha!\nNinguém ganhou essa rodada");
                await dialog.ShowAsync();

                AtualizarPlacar();
                NovaPartida();
            }
        }


        private void NovaPartida()
        {
            LimparBotoes();
            AtivarTodosBotoes();
            movimentos = 0;
        }

        private void LimparBotoes()
        {
            button1.Content = "";
            button2.Content = "";
            button3.Content = "";
            button4.Content = "";
            button5.Content = "";
            button6.Content = "";
            button7.Content = "";
            button8.Content = "";
            button9.Content = "";
        }


        private async void button_play_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_jogador1.Text != "" && textBox_jogador2.Text != "")
            {
                players[0] = new Player();
                players[1] = new Player();

                players[0].Name = textBox_jogador1.Text.Trim();
                players[1].Name = textBox_jogador2.Text.Trim();

                NovoJogo();
            }
            else
            {
                var message = new MessageDialog("Digite o nome de todos os jogadores.");
                await message.ShowAsync();
            }
        }

        private void NovoJogo()
        {
            players[0].Points = 0;
            players[1].Points = 0;

            vez = 1;

            AtualizarPlacar();
            VerificarVez();

            GridDadosJogadores.Visibility = Visibility.Collapsed;

            textBox_jogador1.IsEnabled = false;
            textBox_jogador2.IsEnabled = false;
            button_play.IsEnabled = false;

            AtivarTodosBotoes();

            Placar.Visibility = Visibility.Visible;
            GridJogo.Opacity = 100;
        }

        private void AtivarTodosBotoes()
        {
            button1.IsEnabled = true;
            button2.IsEnabled = true;
            button3.IsEnabled = true;
            button4.IsEnabled = true;
            button5.IsEnabled = true;
            button6.IsEnabled = true;
            button7.IsEnabled = true;
            button8.IsEnabled = true;
            button9.IsEnabled = true;
        }

        private void DesativarTodosBotoes()
        {
            button1.IsEnabled = false;
            button2.IsEnabled = false;
            button3.IsEnabled = false;
            button4.IsEnabled = false;
            button5.IsEnabled = false;
            button6.IsEnabled = false;
            button7.IsEnabled = false;
            button8.IsEnabled = false;
            button9.IsEnabled = false;
        }


        private void AtualizarPlacar()
        {
            TextBlockPlacar1.Text = String.Format("{0} está com {1} pontos", players[0].Name, players[0].Points);
            TextBlockPlacar2.Text = String.Format("{0} está com {1} pontos", players[1].Name, players[1].Points);

            TextBlockVelhas.Text = String.Format("{0} velhas", velhas);
        }

        private void VerificarVez()
        {
            switch (vez)
            {
                case 1:
                    TextBlockVez.Text = string.Format("Vez de " + players[0].Name);
                    break;
                default:
                    TextBlockVez.Text = string.Format("Vez de " + players[1].Name);
                    break;
            }
        }

        private void TrocaVez()
        {
            switch (vez)
            {
                case 1:
                    vez = 2;
                    TextBlockVez.Text = string.Format("Vez de " + players[0].Name);
                    break;
                default:
                    vez = 1;
                    TextBlockVez.Text = string.Format("Vez de " + players[1].Name);
                    break;
            }
        }

        private void ButtonGame_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            if (vez == 1)
            {
                btn.Content = "X";
            }
            else
            {
                btn.Content = "O";
            }

            movimentos++;
            btn.IsEnabled = false;
            VerificarSeJogadorGanhor();
            TrocaVez();
        }
    }
}
