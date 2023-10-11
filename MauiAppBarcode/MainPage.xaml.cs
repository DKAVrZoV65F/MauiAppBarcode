
using CommunityToolkit.Maui.Storage;

namespace MauiAppBarcode
{
    public partial class MainPage : ContentPage
    {
        string pathToImage = "";

        public MainPage()
        {
            InitializeComponent();
        }

        async void predict()
        {
            //Load sample data
            var imageBytes = File.ReadAllBytes(pathToImage);
            MLModel1.ModelInput sampleData = new MLModel1.ModelInput()
            {
                ImageSource = imageBytes,
            };

            //Load model and predict output
            var result = MLModel1.Predict(sampleData);
            await DisplayAlert("Результаты", result.PredictedLabel.ToString(), "OK");
        }


        private async void predictionClicked(object sender, EventArgs e)
        {
            if (pathToImage.Equals("")) return;

            string result = "";
            // Create single instance of sample data from first line of dataset for model input
            var imageBytes = File.ReadAllBytes(pathToImage);
            MLModel1.ModelInput sampleData = new MLModel1.ModelInput()
            {
                ImageSource = imageBytes,
            };

            Int32 max = 14;
            
            // Make a single prediction on the sample data and print results.
            var sortedScoresWithLabel = MLModel1.PredictAllLabels(sampleData);
            result += $"{"Class",-40}{"Score",-20}\n";
            result += $"{"-----",-40}{"-----",-20}\n";

            foreach (var score in sortedScoresWithLabel)
            {
                result += $"{score.Key,-40}{Math.Round(score.Value * 100)+"%".PadRight(20 + (score.Key.Length - 14))}\n";
            }
            await DisplayAlert("Результаты", result, "OK");
        }

        private async void selectImageClicked(object sender, EventArgs e)
        {
            var folder = await FilePicker.PickAsync(default);

            if (folder == null) return;

            imageForPrediction.Source = folder.FullPath;
            pathToImage = folder.FullPath;
        }
    }
}
