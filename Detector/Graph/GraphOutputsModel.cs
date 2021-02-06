using TensorFlow;

namespace Detector.Graph
{
    public class GraphOutputsModel
    {
        public GraphOutputsModel(TFTensor[] output)
        {
            Boxes = (float[,,]) output[0].GetValue();
            Scores = (float[,]) output[1].GetValue();
            Classes = (float[,]) output[2].GetValue();
        }

        public float[,,] Boxes { get; }
        public float[,] Scores { get; }
        public float[,] Classes { get; }
    }
}