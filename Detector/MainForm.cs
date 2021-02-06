using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;
using System.Windows.Forms;
using Detector.Graph;
using Detector.Models;
using Detector.Utilities;
using TensorFlow;

namespace Detector
{
    public partial class MainForm : Form
    {
        #region Consts

        private static readonly ResourceManager Resources;

        // graph
        private const string TrainerDetectionPath = @"..\..\..\Trainer\research\object_detection";
        private static readonly string ModelFilePath = Path.Combine(TrainerDetectionPath, @"inference_graph\frozen_inference_graph.pb");
        private GraphClient GraphClient;

        private static readonly ImagePredictor ImagePredictor;

        #endregion

        #region Fields

        private readonly Task graphRunningTask;
        private ImageFileModel inputImage;
        private Task imageFileToTensorTask;
        private TFTensor imageFileTensor;

        #endregion

        #region Constructors

        static MainForm()
        {
            Resources = new ResourceManager(typeof(MainForm));
            ImagePredictor = new ImagePredictor();
        }

        public MainForm()
        {
            InitializeComponent();
            busyIndicator.ImageLocation = "giphy.gif";

            graphRunningTask = Task.Run(async () =>
            {
                await Task.Delay(50);

                try
                {
                    GraphClient = new GraphClient(File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), ModelFilePath)));
                }
                catch (Exception)
                {
                    MessageBox.Show("Trained model not found or it is an attempt to download in the wrong format",
                        "Model Not Found",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    Close();
                }
            });
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            GraphClient?.Dispose();
            base.OnFormClosing(e);
        }

        #endregion

        #region Methods

        #region Private methods

        private void openImageFileButton_Click(object sender, EventArgs e)
        {
            if (imageFileDialog.ShowDialog() != DialogResult.OK)
                return;

            inputImage = new ImageFileModel(imageFileDialog.FileName);
            if (inputImage.FullPath == imageBox.ImageLocation)
                return;

            imageBox.ImageLocation = inputImage.FullPath;
            busyIndicator.Visible = true;
            imageFileToTensorTask = Task.Run(async () =>
            {
                if (!ImagePredictor.CanPredict(inputImage.Name)) return;

                TFTensor tensor = await GetImageFileToTensor();
                busyIndicator.Visible = false;
                await GraphClient.Run(tensor);
            });
        }

        private async void detectButton_Click(object sender, EventArgs e)
        {
            if (imageBox.Image == null)
            {
                MessageBox.Show("Image must be choosen", "Please, choose an image", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            busyIndicator.Visible = true;
            await Task.WhenAll(graphRunningTask, imageFileToTensorTask);

            if (showBoxesCheckBox.Checked)
            {
                ImagePredictor.DrawBoxes(inputImage, GraphClient.Outputs);
                imageBox.ImageLocation = ImagePredictor.PredictedFile.FullPath;
            }

            List<ImagePredictionModel> predictions = ImagePredictor.GetPredictions(GraphClient.Outputs);

            busyIndicator.Visible = false;
            if (!predictions.Any())
                MessageBox.Show("Please upload an image with higher quality", "No Match Found", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            else if (!showBoxesCheckBox.Checked)
            {
                string message = string.Format(Resources.GetString(predictions.Count > 1 ? "MatchesFound" : "MatchFound"),
                    ImagePredictor.PredictedFile.Name);
                MessageBox.Show(
                    $"{message}{string.Join(Environment.NewLine, predictions.Select(p => string.Format(Resources.GetString("MatchItemText"), p.Name, p.Score)))}",
                    "Match Found",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Information);
            }
        }

        private async Task<TFTensor> GetImageFileToTensor()
        {
            await Task.Delay(50);

            imageFileTensor?.Dispose();
            using (Bitmap bitmap = (Bitmap) Image.FromFile(inputImage.FullPath))
            {
                byte[,,,] matrix = new byte[1, bitmap.Size.Height, bitmap.Size.Width, 3];
                for (int iy = 0; iy < bitmap.Size.Height; iy++)
                for (int ix = 0; ix < bitmap.Size.Width; ix++)
                {
                    Color pixel = bitmap.GetPixel(ix, iy);
                    matrix[0, iy, ix, 0] = pixel.R;
                    matrix[0, iy, ix, 1] = pixel.G;
                    matrix[0, iy, ix, 2] = pixel.B;
                }

                imageFileTensor = matrix;
            }

            return imageFileTensor;
        }

        #endregion

        #endregion
    }
}