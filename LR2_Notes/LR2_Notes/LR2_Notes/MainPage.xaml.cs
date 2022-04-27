using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LR2_Notes
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async protected override void OnAppearing()
        {
            collectionView.ItemsSource = await App.Database.GetNotesAsync();
        }

        async void Add_Button_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(descriptionEntry.Text))
            {
                await App.Database.SaveNoteAsync(new Note
                {
                    Date = dataPicker.Date.ToString("dd/MM/yyyy"),
                    Time = timePicker.Time.ToString(),
                    Description = descriptionEntry.Text
                });

                descriptionEntry.Text = string.Empty;
                dataPicker.Date = DateTime.Now;
                timePicker.Time = new TimeSpan(0, 0, 0);
                collectionView.ItemsSource = await App.Database.GetNotesAsync();
            }
        }

        async void Update_Button_Clicked(object sender, EventArgs e)
        {
            if (lastSelection != null)
            {
                lastSelection.Date = dataPicker.Date.ToString("dd/MM/yyyy");
                lastSelection.Time = timePicker.Time.ToString();
                lastSelection.Description = descriptionEntry.Text;
                await App.Database.UpdateNoteAsync(lastSelection);

                collectionView.ItemsSource = await App.Database.GetNotesAsync();
            }
        }

        async void Delete_Button_Clicked(object sender, EventArgs e)
        {
            if(lastSelection != null)
            {
                await App.Database.DeleteNoteAsync(lastSelection);

                collectionView.ItemsSource = await App.Database.GetNotesAsync();

                descriptionEntry.Text = string.Empty;
                dataPicker.Date = DateTime.Now;
                timePicker.Time = new TimeSpan(0, 0, 0);
            }
        }

        Note lastSelection;
        private void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lastSelection = e.CurrentSelection[0] as Note;

            dataPicker.Date = DateTime.Parse(lastSelection.Date);
            timePicker.Time = TimeSpan.Parse(lastSelection.Time);
            descriptionEntry.Text = lastSelection.Description;
        }
    }
}
