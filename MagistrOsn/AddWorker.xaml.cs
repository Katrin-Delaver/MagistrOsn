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

namespace MagistrOsn
{
    /// <summary>
    /// Логика взаимодействия для AddWorker.xaml
    /// </summary>
    public partial class AddWorker : Page
    {
        MagistrDBEntities context;
        public AddWorker(MagistrDBEntities cont)
        {
            InitializeComponent();
            context = cont;
            positionBox.ItemsSource = context.Positions.ToList();
            flag = true;
        }

        bool flag; //добавление - true, редактирование - false


        private void SaveWorker(object sender, RoutedEventArgs e)
        {
            if (flag == true)
            {
                Worker worker = new Worker()
                {
                    TabNum = Convert.ToInt32(tabBox.Text),
                    Name = fioBox.Text,
                    dateStartJob = Convert.ToDateTime(dateBox.SelectedDate),
                    salary = Convert.ToDecimal(salaryBox.Text),
                    position = (positionBox.SelectedItem as Positions).IDPosition,
                    password = passBox.Text
                };
                context.Worker.Add(worker);
                context.SaveChanges();
                NavigationService.Navigate(new TeacherPage());
            }
            else
            {
                context.Worker.Find(work.TabNum).Name = fioBox.Text;
                context.Worker.Find(work.TabNum).dateStartJob = Convert.ToDateTime(dateBox.SelectedDate);
                context.Worker.Find(work.TabNum).salary = Convert.ToDecimal(salaryBox.Text);
                context.Worker.Find(work.TabNum).position = (positionBox.SelectedItem as Positions).IDPosition;
                context.Worker.Find(work.TabNum).password = passBox.Text;
                context.SaveChanges();
                NavigationService.Navigate(new TeacherPage());

            }

        }
        Worker work;

        public AddWorker(MagistrDBEntities cont, Worker worker) //конструктор редактирования
        {
            InitializeComponent();
            context = cont;
            positionBox.ItemsSource = context.Positions.ToList();
            work = worker;
            tabBox.Text = worker.TabNum.ToString();
            fioBox.Text = worker.Name;
            dateBox.SelectedDate = worker.dateStartJob;
            salaryBox.Text = worker.salary.ToString();
            positionBox.SelectedItem = worker.Positions;
            passBox.Text = worker.password;
            flag = false;
        }
    }
}
