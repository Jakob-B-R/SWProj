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
        public String type;
        public SearchPage(String type)
        {
            try
            {
                Server.Init();
            }
            catch (Exception e)
            {
                
            }
            InitializeComponent();
            this.type = type;
            type_txt.Text = type+"s";
        }

        private void search_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Server.setCommand(type, "");
                List<ListBoxItem> ll = Server.runQuery("SWProjv1." + type);
                searchItems.ItemsSource = ll;
                foreach(ListBoxItem litem in ll)
                {
                    litem.PreviewMouseDown += listboxtouch;
                }
            }
            catch (Exception exceptyone)
            {
                searchText_test.Text = exceptyone.ToString();
            }
        }
        public void listboxtouch(object sender, RoutedEventArgs e)
        {
            /*searchItem.Children.Clear();
            searchItem.Children.Add(searchText_test);
            Button addFurny = new Button();
            addFurny.Width = 50;
            addFurny.Height = 50;
            addFurny.Content = "+";*/
            searchText_test.Text = "";
            String[] splitter = ((ListBoxItem)sender).Content.ToString().Split();
            SqlDataReader red = Server.run_query("SELECT buildingLocation, roomSide, building, mailingAddress, phoneNumber, Room.roomID, studentID, dateEntered, dateLeft, furnitureName, serialNumber FROM Room, RoomHistory, Furniture  WHERE Room.buildingLocation = '" + splitter[0] +  "' AND Room.roomSide = '" + splitter[1] + "' AND Room.building = '" + splitter[2] + "'  AND Room.roomID = RoomHistory.roomID AND Room.roomID = Furniture.roomID;");
            //problems if no roomhistory
            bool firstRun = false;
            while (red.Read())
            {
                if (!firstRun)
                {
                    searchText_test.Text +=
                        red.GetString(0) + "\n" +
                        red.GetString(1) + "\n" +
                        red.GetString(2) + "\n" +
                        red.GetString(3) + "\n" +
                        red.GetString(4) + "\n" +
                        red.GetString(5) + "\n" +
                        red.GetString(6) + "\n" +
                        red.GetDateTime(7).ToString() + "\n" +
                        red.GetDateTime(8).ToString() + "\n\n FURNITURE \n" +
                        red.GetString(9) + "\t\t" +
                        red.GetString(10) + "\n";
                }
                else
                {
                    searchText_test.Text +=
                        red.GetString(9) + "\t\t" +
                        red.GetString(10) + "\n";
                }
                firstRun = true;
            }
           // searchItem.Children.Add(addFurny);
            red.Close();
        }
    }
}
