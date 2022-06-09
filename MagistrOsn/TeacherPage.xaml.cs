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
    /// Логика взаимодействия для TeacherPage.xaml
    /// </summary>
    public partial class TeacherPage : Page
    {
        MagistrDBEntities context;
        public TeacherPage()
        {
            InitializeComponent();
            context = new MagistrDBEntities();
            workertable.ItemsSource = context.Worker.ToList();

            var positionList = context.Positions.ToList();
            positionList.Insert(0, new Positions() { Title = "Все", IDPosition = 0 });
            positionBox.ItemsSource = positionList;
        }


        public void RefreshData()
        {
            var list = context.Worker.ToList();
            if (positionBox.SelectedIndex>0)
            {
                Positions pos = positionBox.SelectedItem as Positions;
                list = list.Where(x => x.Positions == pos).ToList();
            }

            if(!string.IsNullOrWhiteSpace(fioBox.Text))
            {
                list = list.Where(x => x.Name.ToLower().Contains(fioBox.Text.ToLower())).ToList();
            }
            workertable.ItemsSource = list;
        }

        private void ChangePosition(object sender, SelectionChangedEventArgs e)
        {
            RefreshData();
        }

        private void ChangeFio(object sender, TextChangedEventArgs e)
        {
            RefreshData();
        }

        private void AddWorker(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddWorker(context));
        }

        private void EditWorker(object sender, RoutedEventArgs e)
        {
            Worker worker = workertable.SelectedItem as Worker;
            NavigationService.Navigate(new AddWorker(context, worker));
        }

        private void DeleteWorker(object sender, RoutedEventArgs e)
        {
            
            MessageBoxResult res = MessageBox.Show("Вы уверены, что хотите удалить сотруднкиа?", "Подтверждение", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                try
                {
                    Worker worker = workertable.SelectedItem as Worker;
                    

                    context.Worker.Remove(worker);
                    context.SaveChanges();
                    NavigationService.Navigate(new TeacherPage());
                }
                catch
                {
                    MessageBox.Show("Ошибка, удлите все курсы данного работника!");
                }
            }

        }
    }
}
