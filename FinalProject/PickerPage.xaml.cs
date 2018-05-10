using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Reflection;

namespace FinalProject
{
    public partial class PickerPage : ContentPage
    {
        public PickerPage()
        {
            InitializeComponent();

            Title = "Spin";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();


            string theJson = "{}";


            Type type = typeof(PickerPage);

            var assembly = type.GetTypeInfo().Assembly;

            const string myDataJsonResourceName = "FinalProject.ExamplesSource.json";

            using (var resourceStream = assembly.GetManifestResourceStream(myDataJsonResourceName))
            using (var reader = new System.IO.StreamReader(resourceStream))
            {

                theJson = reader.ReadToEnd();
            }



            //List<Workout> workouts = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Workout>>(theJson);

            this.workoutData = Newtonsoft.Json.JsonConvert.DeserializeObject<MyWorkout>(theJson);



            //PickedWorkout.Text = workouts.ToString();
        }

        MyWorkout workoutData;
        WorkoutCategory ChoosenCategory;

        public void Spinner()
        {
            /*
            List<string> Workouts = new List<string>();
            Workouts.Add("Chest");
            Workouts.Add("Shoulder");
            Workouts.Add("Back");
            Workouts.Add("Legs");
            Workouts.Add("Abs");
            Workouts.Add("Arms");
            */

            Random rnd = new Random();
            int RandomPicker = rnd.Next(workoutData.Categories.Count);
            this.ChoosenCategory = workoutData.Categories[RandomPicker];
            string picked = this.ChoosenCategory.Name;

            PickedWorkout.Text = picked;
            PickedWorkout.FontSize = 40;
            PickedWorkout.HorizontalTextAlignment = TextAlignment.Center;
            PickedWorkout.Margin = new Thickness(-100,0,0,0);
            Random rndColor = new Random();
            PickedWorkout.TextColor = Color.DarkRed;
          
            if (PickedWorkout.Text == "Arms")
            {
                Image.Source = "arms.png";
                Warning.Text = string.Empty;
            }
            else if (PickedWorkout.Text == "Legs")
            {
                Image.Source = "legs.png";
                Warning.Text = "Legs has been Choosen, proceed with Caution!";
            }
            else if (PickedWorkout.Text == "Shoulders")
            {
                Image.Source = "shoulder.png";
                Warning.Text = string.Empty;
            }
            else if (PickedWorkout.Text == "Back")
            {
                Image.Source = "back.png";
                Warning.Text = string.Empty;
            }
            else if (PickedWorkout.Text == "Abs")
            {
                Image.Source = "abs.png";
                Warning.Text = string.Empty;
            }
            else if (PickedWorkout.Text == "Chest")
            {
                Image.Source = "chest.png";
                Warning.Text = string.Empty;
            }
            else 
            {
                Image.Source = null;
                Warning.Text = string.Empty;
            }

        }

        void SpinHandle_Clicked(object sender, System.EventArgs e)
        {
            Spinner();
        }

         void ExamplesHandle_Clicked(object sender, System.EventArgs e)
        {
            ExamplesPage p = new ExamplesPage();
            p.Category = this.ChoosenCategory;
             Navigation.PushAsync(p);
        }
    }
}
