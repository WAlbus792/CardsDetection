namespace Detector.Models
{
    public class ImagePredictionModel : ImageLabelModel
    {
        public ImagePredictionModel(ImageLabelModel model, float score): base(model.Id, model.Name) => Score = score;

        public float Score { get; }
    }
}