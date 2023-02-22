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


//ответы
//121 Первый университет, основанный в Болонье, Италия - 1088 г.
//122 Конец Первой мировой войны - 1918 г.
//123 Первые противозачаточные таблетки стали доступны для женщин - 1960 г.
//124 Родился Уильям Шекспир - 1564 г.
//125 Первое использование современной бумаги - 105AD
//126 Основание коммунистического Китая - 1949 г.
//127 Мартин Лютер начинает Реформацию - 1517 г.
//128 Конец Второй мировой войны - 1945 г.
//129 Чингисхан начинает завоевание Азии - 1206 год.
//130 Рождение Будды - 486 г. до н.э.
 
namespace Quiz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> Questions = new List<string>()
            { "Первый университет, основанный в Болонье, Италия",
            "Конец Первой мировой войны",
            "Первая противозачаточная таблетка для женщин",
            "Уильям Шекспир родился?",
            "Первое использование современной бумаги",
            "Основан коммунистический Китай",
            "Мартин Лютер начинает Реформацию",
            "Конец Второй мировой войны",
            "Чингисхан начинает свое завоевание Азии",
            "Рождение Будды"};

        List<string> Answers = new List<string>()
            { "1088",
            "1918",
            "1960",
            "1564",
            "105",
            "1949",
            "1517",
            "1945",
            "1206",
            "486"
            };

        public MainWindow()
        {
            InitializeComponent();

            Random random = new Random();   
            Task.Text = Questions[random.Next(0, Questions.Count)];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Questions.Count < 1)    // Проверка: Если игра сыграна и список вопросов пуст
            {
                Answer.Text = "";
                return;
            }

            string answ = Answer.Text;      // сохраняем ответ в переменную

            if (!String.IsNullOrEmpty(answ) )      // если был введен ответ, заходим в условие (иначе ничего не происходит)
            {
                int index = Questions.IndexOf(Task.Text);   // Находим индекс вопроса/ответа

                if (answ == Answers[index])  // если введенный текст совпадает с ответом, то инкрементируем очки
                {
                    int count = int.Parse((Score.Content).ToString());
                    Score.Content = ++count;
                }

                Questions.RemoveAt(index);    //  Удаляем из списков вопрос и ответ по индексу
                Answers.RemoveAt(index);

                if (Questions.Count < 1)   // Если вопросы закончились - итоговая инфо
                {
                    Answer.Text = "";
                    Task.Text = "Вы прошли Викторину!";
                    int scores = int.Parse((Score.Content).ToString());
                    if (scores > 7)
                        Level.Text = "Ваш уровень: Профессионал!";
                    else if (scores > 4)
                        Level.Text = "Ваш уровень: Высокий!";
                    else if (scores > 2)
                        Level.Text = "Ваш уровень: Средний!";
                    else
                        Level.Text = "Ваш уровень: Низкий!";
                    return;
                }
                else    // Иначе рандомно выбираем след вопрос из списка
                {
                    Random random = new Random();
                    Task.Text = Questions[random.Next(0, Questions.Count)];
                }

                Answer.Text = "";
            }
        }

        private void Call_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("You called message box!!!", "QUIZ", MessageBoxButton.YesNoCancel);
            if (MessageBoxResult.Yes == result)
            {
                MessageBox.Show("All its Yes!", "QUIZ", MessageBoxButton.OK);
            }
            else { MessageBox.Show(result.ToString(), "QUIZ", MessageBoxButton.OK); }
        }
    }
}
