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
using DesktopApp.Models;
using DesktopApp.IRepositories;
using DesktopApp.Service;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;

namespace DesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly UserService _userService = new UserService();
        User NewUser = new User();
        
        
        User selectedUser = new User();
        public MainWindow()
        {
            InitializeComponent();
            GetAllUsers();

            NewUserGrid.DataContext = NewUser;
        }

        public async void GetAllUsers()
        {
            AllUsers.ItemsSource = await _userService.GetAll();
        }

        private async void AddUser(object s, RoutedEventArgs e)
        {
            Random r = new Random();
            int id = r.Next();
            NewUser.Id = id;
            await _userService.Add(NewUser);
            GetAllUsers();
            NewUser = new User();
            NewUserGrid.DataContext = NewUser;
        }

        private async void DeleteUser(object sender, RoutedEventArgs e)
        {
            var userToDelete = (sender as FrameworkElement).DataContext as User;
            var x = await _userService.Remove(userToDelete.Id);
            GetAllUsers();

        }

        private void SelectUserToEdit(object sender, RoutedEventArgs e)
        {
            selectedUser = (sender as FrameworkElement).DataContext as User;
            UpdateProductGrid.DataContext = selectedUser;

        }


        private async void UpdateItem(object sender, RoutedEventArgs e)
        {
            await _userService.Update(selectedUser, selectedUser.Id);
            GetAllUsers();

        }


    }
       

}
