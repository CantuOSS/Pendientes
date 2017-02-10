using Xamarin.Forms;

namespace Pendientes
{
	public partial class App : Application
	{
		static TodoItemDatabase database;
		public App()
		{
			InitializeComponent();

			Resources = new ResourceDictionary();
			Resources.Add("blue", Color.Blue);
			Resources.Add("primaryDarkGreen", Color.FromHex("6FA22E"));

			var nav = new NavigationPage(new PendientesPage());
			nav.BarBackgroundColor = (Color)Current.Resources["blue"];
			nav.BarTextColor = Color.White;

			MainPage = nav;
		}

		public static TodoItemDatabase Database
		{
			get
			{
				if (database == null)
				{
					database = new TodoItemDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoSQLite.db3"));
				}
				return database;
			}
		}

		public int ResumeAtTodoId { get; set; }

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
