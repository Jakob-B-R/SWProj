using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
namespace SWProjv1
{
    public class RAApplicationData
    {
        public static RAApplicationData selectedApplication { get; set; }
        public ListBoxItem listboxitem { get; set; }
        public Grid grid { get; set; }
        public String Name { get; set; }
        public Button accept { get; set; }
        public Button Deny { get; set; }
        public Boolean isAck { get; set; }
        public Boolean isAcc { get; set; }
        public int ID { get; set; }
		public String reason { get; set; }
        public String stuID { get; set; }
        public RAApplicationData(String name, Boolean isAck, Boolean isAcc, int ID, String stuID, String reason)
        {
            this.stuID = stuID;
            this.Name = name;
            this.isAck = isAck;
            this.isAcc = isAcc;
            this.ID = ID;
			this.reason = reason;
            grid = new Grid();
        }
        private void Item_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
			setGrid();
			selectedApplication = this;
        }
        public void setListBoxItem()
        {
            listboxitem = new ListBoxItem();
            listboxitem.Content = this.Name;
            listboxitem.PreviewMouseDown += Item_PreviewMouseDown;
        }

		void setGrid()
		{
			grid.Children.Clear();
			for (int i = 0; i < 3; i++)
			{
				RowDefinition rd = new RowDefinition();
				rd.Height = new GridLength(20, GridUnitType.Star);
				grid.RowDefinitions.Add(rd);
			}
			TextBlock name_lbl = new TextBlock();
			name_lbl.Text = Name;
			name_lbl.HorizontalAlignment = HorizontalAlignment.Center;
			name_lbl.VerticalAlignment = VerticalAlignment.Center;
			Grid.SetRow(name_lbl, 0);

			TextBlock room_lbl = new TextBlock();
			room_lbl.Text = reason;
			room_lbl.HorizontalAlignment = HorizontalAlignment.Center;
			room_lbl.VerticalAlignment = VerticalAlignment.Center;
			Grid.SetRow(room_lbl, 1);

			UniformGrid uGrid = new UniformGrid();
			uGrid.Columns = 5;
			uGrid.Rows = 2;
			uGrid.Children.Add(new TextBlock());
			Button accept_btn = new Button();
			accept_btn.Content = "Accept";
			accept_btn.Click += Accept_btn_Click;
			uGrid.Children.Add(accept_btn);
			uGrid.Children.Add(new TextBlock());
			Button deny_btn = new Button();
			deny_btn.Content = "Deny";
			deny_btn.Click += Deny_btn_Click;
			uGrid.Children.Add(deny_btn);
			uGrid.Children.Add(new TextBlock());
			Grid.SetRow(uGrid, 2);

			grid.Children.Add(name_lbl);
			grid.Children.Add(room_lbl);
			grid.Children.Add(uGrid);
		}

		private void Deny_btn_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Request Denied");
			Server.Executer("UPDATE RAApplication SET isAcknowledged = 1, isAccepted = 0 WHERE RAApplicationID = " + ID.ToString());
		}

		private void Accept_btn_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Request Accepted");
			Server.Executer("UPDATE RAApplication SET isAcknowledged = 1, isAccepted = 1 WHERE RAApplicationID = " + ID.ToString());
			Server.Executer("INSERT INTO RA VALUES('" + stuID + "', '" + stuID + "')");
		}
	}
}