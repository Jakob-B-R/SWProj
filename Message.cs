using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace SWProjv1
{

	public class Message
	{
		public static Message selectedMessage { get; set; }
		public String Text { get; set; }
		public String senderID { get; set; }
		public String recieverID { get; set; }
		public String dateSent { get; set; }
		public Grid grid;
		public String senderName;
		public ListBoxItem listboxitem;
		public bool messageAcknowledged { get; set; }
		public Message()
		{
			grid = new Grid();
			grid.RowDefinitions.Add(new RowDefinition());
			grid.RowDefinitions.Add(new RowDefinition());
			grid.RowDefinitions.Add(new RowDefinition());
			grid.RowDefinitions.Add(new RowDefinition());
			grid.ColumnDefinitions.Add(new ColumnDefinition());
			grid.ColumnDefinitions.Add(new ColumnDefinition());
			grid.ColumnDefinitions.Add(new ColumnDefinition());
			grid.ColumnDefinitions.Add(new ColumnDefinition());

			TextBox textbox = new TextBox();
			Grid.SetRow(textbox, 0);
			Grid.SetColumn(textbox, 0);
			textbox.Text = senderName;
		}
		private void Item_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			selectedMessage = new Message();
			selectedMessage.grid = grid;
		}
		public void setListBoxItem()
		{
			listboxitem = new ListBoxItem();
			listboxitem.Content = "listbox contents";
			listboxitem.PreviewMouseDown += Item_PreviewMouseDown;
		}
	}
}
