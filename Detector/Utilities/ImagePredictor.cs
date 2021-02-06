using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Detector.Graph;
using Detector.Models;

namespace Detector.Utilities
{
    public class ImagePredictor
    {
        #region Consts

        private static readonly string LabelMapPath = Path.Combine(@"..\..\..\Trainer\research\object_detection\training\labelmap.pbtxt");

        private static readonly string OutputFolderPath = Path.Combine(Environment.CurrentDirectory, "test_images");

        #endregion

        #region Fields

        private ImageEditor imageEditor;
        private List<ImagePredictionModel> predictions = new List<ImagePredictionModel>();

        private bool needDrawBoxes;
        private bool needPredict;

        #endregion

        #region Constructors

        public ImagePredictor()
        {
            Categories = LabelMapReader.ReadFromFile(Path.Combine(Directory.GetCurrentDirectory(), LabelMapPath));

            if (Directory.Exists(OutputFolderPath)) Directory.Delete(OutputFolderPath, true);
            Directory.CreateDirectory(OutputFolderPath);
        }

        #endregion

        #region Properties

        public ImageFileModel PredictedFile { get; private set; }

        #endregion

        #region Methods

        #region Public methods

        public List<ImagePredictionModel> GetPredictions(GraphOutputsModel outputs, double minScore = 0.8)
        {
            if (needPredict || needDrawBoxes)
            {
                if (needPredict) predictions = new List<ImagePredictionModel>();

                int x = outputs.Boxes.GetLength(0);
                int y = outputs.Boxes.GetLength(1);

                for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                {
                    if (outputs.Scores[i, j] < minScore) continue;

                    ImagePredictionModel prediction = null;
                    int imageClass = Convert.ToInt32(outputs.Classes[i, j]);
                    if (needPredict)
                    {
                        ImageLabelModel imageLabel = Categories.First(item => item.Id == imageClass);
                        prediction = new ImagePredictionModel(imageLabel, outputs.Scores[i, j]);
                        predictions.Add(prediction);
                    }

                    if (needDrawBoxes)
                    {
                        if (prediction is null)
                            prediction = predictions.First(p => p.Id == imageClass);
                        float ymin = outputs.Boxes[i, j, 0];
                        float xmin = outputs.Boxes[i, j, 1];
                        float ymax = outputs.Boxes[i, j, 2];
                        float xmax = outputs.Boxes[i, j, 3];
                        imageEditor.AddBox(xmin, xmax, ymin, ymax, $"{prediction.Name} : {Math.Round(prediction.Score * 100)}%");
                    }
                }

                needPredict = false;
            }

            return predictions;
        }

        public void DrawBoxes(ImageFileModel file, GraphOutputsModel outputs, double minScore = 0.8)
        {
            if (!needDrawBoxes) return;

            PredictedFile = new ImageFileModel(file.Name, OutputFolderPath);
            File.Delete(PredictedFile.FullPath);
            using (imageEditor = new ImageEditor(file.FullPath, PredictedFile.FullPath))
                predictions = GetPredictions(outputs, minScore);

            needDrawBoxes = false;
        }

        public bool CanPredict(string inputImageName)
        {
            bool imageChanged = PredictedFile is null || inputImageName != PredictedFile.Name;
            if (imageChanged)
                needDrawBoxes = needPredict = true;
            return imageChanged;
        }

        #endregion

        #endregion

        private static IEnumerable<ImageLabelModel> Categories;
    }
}