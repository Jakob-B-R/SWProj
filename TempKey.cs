using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace SWProjv1
{
	public class TempKey
	{
		public static TempKey selectedKey { get; set; }
		public String keyID { get; set; }
		public bool isAssigned { get; set; }
		public String RAAssignedID { get; set; }
		public String RAReturnedID {get; set;}
		public String studentAssigned { get; set; }
		public String roomID { get; set; }
		public String dateAssigned { get; set; }
		public String dateRecieved { get; set; }
		public Grid grid;
		public ListBoxItem listboxitem;
		public TempKey()
		{
			grid = new Grid();
			//grid definitions
			TextBox text = new TextBox();
			text.Text = "TempKey";
			Grid.SetRow(text, 0);
			Grid.SetColumn(text, 0);
			//set text into grid spots
			grid.Children.Add(text);
		}
		private void Item_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			selectedKey = new TempKey();
			selectedKey.grid = grid;
		}
		public void setListBoxItem()
		{
			listboxitem = new ListBoxItem();
			listboxitem.Content = "listbox contents";
			listboxitem.PreviewMouseDown += Item_PreviewMouseDown;
		}
	}
}
