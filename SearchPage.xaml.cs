using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace SWProjv1
{
    //look into using gridform instead of listbox
    ///.Add to add to list
    /// <summary>
    /// Interaction logic for SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        String type;
        public SearchPage(String type)
        {
            try
            {
                Server.Init();
            }
            catch (Exception e) { }
            InitializeComponent();
			CreateButton.Click += newmessage_click;

			this.type = type;
            type_txt.Text = type+"s";
			if (type == "Message")
				CreateButton.Visibility = Visibility.Visible;
			else
				CreateButton.Visibility = Visibility.Hidden;

		}

		private void search_btn_Click(object sender, RoutedEventArgs e)
        {

			try
			{
                Server.setCommand(type, "");
                List<ListBoxItem> listy = Server.runQuery("SWProjv1." + type);
				foreach (ListBoxItem lbi in listy)
                {
                    lbi.PreviewMouseDown += Item_PreviewMouseDown2;
                }
                searchItems.ItemsSource = listy;


			}
			catch (Exception exceptyone)
            {
				MessageBox.Show(exceptyone.ToString());
				//searchText_test.Text = exceptyone.ToString();
			}
        }

        private void Item_PreviewMouseDown2(object sender, MouseButtonEventArgs e)
        {
            //searchItem.Visibility=Visibility.Visible;
            try
            {

				Grid searchItem;
				switch (type)
                {
                    case "Room":
                        searchItem = Room.selectedRoom.grid;
                        break;
                    case "Student":
                        searchItem = Student.selectedStudent.grid;
                        break;
					case "Message":
						searchItem = Message.selectedMessage.grid;
						break;
					case "Key":
						searchItem = TempKey.selectedKey.grid;
						break;
					case "RA Application":
						searchItem = RAApplicationData.selectedApplication.grid;
						break;
					default:
                        searchItem = new Grid();
                        break;
                }
                Grid.SetColumn(searchItem, 1);
                Grid.SetRow(searchItem, 3);
				while (grid.Children.Count > 4)
					grid.Children.RemoveAt(grid.Children.Count-1);
				grid.Children.Add(searchItem);
            }
            catch (Exception) {

			}
        }

		private void newmessage_click(object sender, RoutedEventArgs e)
		{
		}
	}
}
