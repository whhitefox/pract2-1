using System;
using System.Windows;
using System.Windows.Documents;
using System.Collections.Generic;

namespace Практическая1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string player = "O";
        string bot = "X";
        string[] data;
        int[,] combinations = new int[,] {
            {0, 1, 2},
            {3, 4, 5},
            {6, 7, 8},
            {0, 3, 6},
            {1, 4, 7},
            {2, 5, 8},
            {0, 4, 8},
            {2, 4, 6}
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            StartGame();
        }

        private void StartGame()
        {
            startButton.Content = "Заново";
            if (player == "O")
            {
                player = "X";
                bot = "O";
            }
            else
            {
                player = "O";
                bot = "X";
            }
            playerLabel.Content = $"Вы: {player}";
            winnerLabel.Visibility = Visibility.Hidden;

            data = new string[9];
            foreach (var d in data)
            {
                Console.WriteLine(d);
            }
            ClearButtons();
            EnableButtons();

            if (bot == "X")
            {
                BotMove();
            }
        }

        private void EndGame(string winner)
        {
            DisableButtons();
            winnerLabel.Visibility = Visibility.Visible;
            winnerLabel.Content = $"Победитель: {winner}";
            startButton.Content = "Начать";
        }

        private void EnableButtons()
        {
            button0.IsEnabled = true;
            button1.IsEnabled = true;
            button2.IsEnabled = true;
            button3.IsEnabled = true;
            button4.IsEnabled = true;
            button5.IsEnabled = true;
            button6.IsEnabled = true;
            button7.IsEnabled = true;
            button8.IsEnabled = true;
        }

        private void DisableButtons()
        {
            button0.IsEnabled = false;
            button1.IsEnabled = false;
            button2.IsEnabled = false;
            button3.IsEnabled = false;
            button4.IsEnabled = false;
            button5.IsEnabled = false;
            button6.IsEnabled = false;
            button7.IsEnabled = false;
            button8.IsEnabled = false;
        }

        private void ClearButtons()
        {
            button0.Content = "";
            button1.Content = "";
            button2.Content = "";
            button3.Content = "";
            button4.Content = "";
            button5.Content = "";
            button6.Content = "";
            button7.Content = "";
            button8.Content = "";
        }

        private string GetWinner()
        {
            for (int i = 0; i < combinations.GetLength(0); i++)
            {
                string first = data[combinations[i, 0]];
                string second = data[combinations[i, 1]];
                string third = data[combinations[i, 2]];
                if (first == second && second == third)
                {
                    return first;
                }
            }

            bool nichya = true;
            foreach (string value in data)
            {
                if (value == null)
                {
                    nichya = false;
                    break;
                }
            }

            if (nichya)
            {
                return "Ничья";
            }

            return null;
        }

        private void PlayerMove(int cell)
        {
            data[cell] = player;
            
            string winner = GetWinner();
            if (winner != null)
            {
                EndGame(winner);
            }
            else
            {
                BotMove();
            }
        }

        private void BotMove()
        {
            Random random = new Random();
            List<int> empty = new List<int>();
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == null)
                {
                    empty.Add(i);
                }
            }
            
            int number = random.Next(0, empty.Count);
            Console.WriteLine(number);
            int cell = empty[number];
            data[cell] = bot;
            
            switch (cell)
            {
                case 0:
                    button0.Content = bot;
                    button0.IsEnabled = false;
                    break;
                case 1:
                    button1.Content = bot;
                    button1.IsEnabled = false;
                    break;
                case 2:
                    button2.Content = bot;
                    button2.IsEnabled = false;
                    break;
                case 3:
                    button3.Content = bot;
                    button3.IsEnabled = false;
                    break;
                case 4:
                    button4.Content = bot;
                    button4.IsEnabled = false;
                    break;
                case 5:
                    button5.Content = bot;
                    button5.IsEnabled = false;
                    break;
                case 6:
                    button6.Content = bot;
                    button6.IsEnabled = false;
                    break;
                case 7:
                    button7.Content = bot;
                    button7.IsEnabled = false;
                    break;
                case 8:
                    button8.Content = bot;
                    button8.IsEnabled = false;
                    break;
            }

            string winner = GetWinner();
            if (winner != null)
            {
                EndGame(winner);
            }
        }

        private void button0_Click(object sender, RoutedEventArgs e)
        {
            button0.IsEnabled = false;
            button0.Content = player;
            PlayerMove(0);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            button1.IsEnabled = false;
            button1.Content = player;
            PlayerMove(1);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            button2.IsEnabled = false;
            button2.Content = player;
            PlayerMove(2);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            button3.IsEnabled = false;
            button3.Content = player;
            PlayerMove(3);
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            button4.IsEnabled = false;
            button4.Content = player;
            PlayerMove(4);
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            button5.IsEnabled = false;
            button5.Content = player;
            PlayerMove(5);
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            button6.IsEnabled = false;
            button6.Content = player;
            PlayerMove(6);
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            button7.IsEnabled = false;
            button7.Content = player;
            PlayerMove(7);
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            button8.IsEnabled = false;
            button8.Content = player;
            PlayerMove(8);
        }
    }
}
