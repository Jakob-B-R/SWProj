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
		/*
		 * TODO://Allow reply and acknowledging the messages
		 * 
		 */
		public static Message selectedMessage { get; set; }
		public String Text { get; set; }
		public String senderID { get; set; }
		public String recieverID { get; set; }
		public String dateSent { get; set; }
		public Grid grid;
		public String senderName { get; set; }
		public ListBoxItem listboxitem;
		public bool messageAcknowledged { get; set; }
		public Message(String Text, String senderID, String recieverID, String dateSent, String senderName)
		{
			this.Text = Text;
			this.senderID = senderID;
			this.recieverID = recieverID;
			this.dateSent = dateSent;
			this.senderName = senderName;
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
			textbox.TextWrapping = System.Windows.TextWrapping.Wrap;
			textbox.Text = Text;
			grid.Children.Add(textbox);
		}
		private void Item_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			selectedMessage = this;
			selectedMessage.grid = grid;
		}
		public void setListBoxItem()
		{
			listboxitem = new ListBoxItem();
			listboxitem.Content = this.senderName;
			listboxitem.PreviewMouseDown += Item_PreviewMouseDown;
		}
	}
}
