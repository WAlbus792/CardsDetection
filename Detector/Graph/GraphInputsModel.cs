using TensorFlow;

namespace Detector.Graph
{
    public class GraphInputsModel
    {
        public GraphInputsModel(TFGraph graph)
        {
            ImageTensor = graph["image_tensor"][0];
            DetectionBoxes = graph["detection_boxes"][0];
            DetectionScores = graph["detection_scores"][0];
            DetectionClasses = graph["detection_classes"][0];
            NumDetections = graph["num_detections"][0];
        }

        public TFOutput ImageTensor { get; set; }
        public TFOutput DetectionBoxes { get; set; }
        public TFOutput DetectionScores { get; set; }
        public TFOutput DetectionClasses { get; set; }
        public TFOutput NumDetections { get; set; }
    }
}