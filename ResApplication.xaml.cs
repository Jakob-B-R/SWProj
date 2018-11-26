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

namespace SWProjv1
{
    /// <summary>
    /// Interaction logic for ResApplication.xaml
    /// </summary>
    public partial class ResApplication : Page
    {
        public ResApplication()
        {
            InitializeComponent();
        }

        private void submit_btn_Click(object sender, RoutedEventArgs e)
        {
            
            String mbTitle = "";
            String mbMessage = "";
			if (name_inp.Text != "" && stdNum_inp.Text != "" && lname_inp.Text != "" && otherName.Text != "" && schoolYear.Text != "" && gender.Text != "" && email.Text != "" && streetAddress.Text != "" && city.Text != "" && region.Text != "" && postalCode.Text != "" && phoneCountryCode.Text != "" && phoneAreaCode.Text != "" && phoneNumber.Text != "" && preferedBuilding.Text != "" && smokes.Text != "" && liveWithSmoke.Text != "" && drinks.Text != "" && marijuana.Text != "" && liveWithMarijuana.Text != "" && socialLevel.Text != "" && bedtime.Text != "" && wakeUp.Text != "" && volumeLevel.Text != "" && overnightVisitors.Text != "" && cleanliness.Text != "" && studyInRoom.Text != "" && mealPlan.Text != "")
            {
				Server.Executer("EXEC SubmitApplication '"+stdNum_inp.Text+"', '"+name_inp.Text+"', '"+lname_inp.Text+"', '"+otherName.Text+"', "+schoolYear.Text+", '"+gender.Text+"', '"+email.Text+"', '"+streetAddress.Text+"', '"+city.Text+"', '"+region.Text+"', '"+country.Text+"', '"+postalCode.Text+"', '"+phoneCountryCode.Text+"', '"+phoneAreaCode.Text+"', '"+phoneNumber.Text+"', '"+preferedBuilding.Text+"', "+smokes.Text+", "+liveWithSmoke.Text+", "+drinks.Text+", "+liveWithDrink.Text+", "+marijuana.Text+", "+liveWithMarijuana.Text+", '"+socialLevel.Text+"', '"+bedtime.Text+"', '"+wakeUp.Text+"', '"+volumeLevel.Text+"', "+overnightVisitors.Text+", '"+cleanliness.Text+"', "+studyInRoom.Text+","+roomateRequest.Text+",'"+roomateName.Text+"','"+roomateStudentNum.Text+"','"+mealPlan.Text+"'");
				mbTitle = "Success!";
				mbMessage = "Application Successful! :)";
            }
            else
            {
                mbTitle = "Fail!";
                mbMessage = "Request Denied\nFill out all fields";
            }
            MessageBox.Show(mbMessage, mbTitle);
        }
    }
}
