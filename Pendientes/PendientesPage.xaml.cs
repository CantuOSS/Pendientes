using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Pendientes
{
	public partial class PendientesPage : ContentPage
	{
		public PendientesPage()
		{
			InitializeComponent();
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			// Reset the 'resume' id, since we just want to re-start here
			((App)Application.Current).ResumeAtTodoId = -1;
			listView.ItemsSource = await App.Database.GetItemsAsync();
		}

		async void OnItemAdded(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new TodoItemPage
			{
				BindingContext = new TodoItem()
			});
		}

		async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			((App)Application.Current).ResumeAtTodoId = (e.SelectedItem as TodoItem).ID;
			Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as TodoItem).ID);

			await Navigation.PushAsync(new TodoItemPage
			{
				BindingContext = e.SelectedItem as TodoItem
			});
		}
	}
}
