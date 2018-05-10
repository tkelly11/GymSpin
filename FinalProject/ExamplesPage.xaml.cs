using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Reflection;

namespace FinalProject
{
    public partial class ExamplesPage : ContentPage
    {
        public ExamplesPage()
        {
            InitializeComponent();

            Title = "Examples";
        }

       protected override void OnAppearing()
        {
            
            this.Workoutlist.ItemsSource = Category.Workouts;
            base.OnAppearing();
        }
        public WorkoutCategory Category { get; set; }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            WorkoutPage wp = new WorkoutPage();
            wp.Workout = (Workout)e.SelectedItem;
            Navigation.PushAsync(wp);


        }
    }
}
