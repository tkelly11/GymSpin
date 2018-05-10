using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Reflection;

using Xamarin.Forms;

namespace FinalProject
{
    public partial class WorkoutPage : ContentPage
    {
        public WorkoutPage()
        {
            InitializeComponent();
            Title = "Workout";
        }

        protected override void OnAppearing()
        {

            this.WorkoutDescription.Text = Workout.Description;
            base.OnAppearing();
        }

        public Workout Workout { get; set; }
        bool stats = true;

        void PRReps_Toggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            

            if(stats == true)
            {
                PRLabel.IsVisible = true;
                RepsLabel.IsVisible = true;
                replabel2.IsVisible = true;
                replabel3.IsVisible = true;
                prlabel2.IsVisible = true;
                prlabel3.IsVisible = true;
                astricks.IsVisible = true;
                txtPR.IsVisible = true;
                txtReps.IsVisible = true;
                stats = false;
            }
            else if(stats == false)
            {
                PRLabel.IsVisible = false;
                RepsLabel.IsVisible = false;
                replabel2.IsVisible = false;
                replabel3.IsVisible = false;
                prlabel2.IsVisible = false;
                prlabel3.IsVisible = false;
                astricks.IsVisible = false;
                txtPR.IsVisible = false;
                txtReps.IsVisible = false;
                stats = true;
            }

        }
        string PersonalRecord;
        string Repsholder;

        void Submit_Clicked(object sender, System.EventArgs e)
        {
            
            if(txtPR.Text != string.Empty){
                prlabel2.Text = txtPR.Text;
                PersonalRecord = txtPR.Text;
                txtPR.Text = string.Empty;
            }

            if(txtReps.Text != string.Empty)
            {
                replabel2.Text = txtReps.Text;
                Repsholder = txtReps.Text;
                txtReps.Text = string.Empty;
            }

            prlabel2.Text = Repsholder; 
            replabel2.Text = PersonalRecord;



        }
    }
}
