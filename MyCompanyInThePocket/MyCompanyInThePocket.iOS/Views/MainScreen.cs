using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using MyCompanyInThePocket.Core.Resources;
using MyCompanyInThePocket.Core.ViewModels;
using UIKit;

namespace MyCompanyInThePocket.iOS.Views
{
	public class MainScreenView : BaseTabBarScreen<MainScreenViewModel>
	{
		private int _nbTabBarCreated;

        public MainScreenView()
        {
			Title = "MainScreen";
			this.ViewControllerSelected +=	Handle_ViewControllerSelected;
        }

		void Handle_ViewControllerSelected(object sender, UITabBarSelectionEventArgs e)
		{
			// On définit comme titre de la page le nom de la page sélectionnée
			Title = TabBar.SelectedItem.Title;
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			var viewControllers =
				new UIViewController[]
				{
					CreateTabFor(StringValues.Main_Meetings_Title_Text, "ic_menu_timeline", ViewModel.MeetingsVM),
					CreateTabFor(StringValues.Main_Meetings_Title_Text, "ic_menu_timeline", ViewModel.MeetingsVM),
					CreateTabFor(StringValues.Main_Meetings_Title_Text, "ic_menu_timeline", ViewModel.MeetingsVM),
					CreateTabFor(StringValues.Main_Settings_Title_Text, "ic_menu_settings", ViewModel.SettingsVM),
				};
			ViewControllers = viewControllers;
			SelectedViewController = ViewControllers[0];
			Title = SelectedViewController.Title;
        }


		private UIViewController CreateTabFor(string title, string imageName, IMvxViewModel viewModel)
		{
			// Création de l'écran correspondant au viewModel;
			var screen = this.CreateViewControllerFor(viewModel) as UIViewController;
			SetTitleAndTabBarItem(screen, title, imageName);
			return screen;
		}

		private void SetTitleAndTabBarItem(UIViewController screen, string title, string imageName)
		{
			screen.Title = title;

			var image = UIImage.FromBundle($"Resources/TabBar/{imageName}.png");

			screen.TabBarItem = new UITabBarItem(title, image ,_nbTabBarCreated);
			_nbTabBarCreated++;
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
			NavigationController.SetNavigationBarHidden(false, true);
		}
    }
}
