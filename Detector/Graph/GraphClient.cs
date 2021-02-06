using System;
using System.Threading.Tasks;
using TensorFlow;

namespace Detector.Graph
{
    public class GraphClient : IDisposable
    {
        #region Fields

        private readonly TFGraph graph;

        #endregion

        #region Constructors

        public GraphClient(byte[] buffer)
        {
            graph = new TFGraph();
            graph.Import(buffer);

            Inputs = new GraphInputsModel(graph);
        }

        #endregion

        #region Properties

        public GraphInputsModel Inputs { get; }
        public GraphOutputsModel Outputs { get; private set; }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            graph?.Abort();
            graph?.Dispose();
        }

        #endregion

        #region Methods

        #region Public methods

        public static implicit operator TFGraph(GraphClient model) => model.graph;

        #endregion

        #endregion

        public async Task Run(TFTensor imageFileTensor)
        {
            await Task.Delay(50);

            TFTensor[] output;
            using (TFSession session = new TFSession(graph))
                output = session.GetRunner()
                   .AddInput(Inputs.ImageTensor, imageFileTensor)
                   .Fetch(Inputs.DetectionBoxes, Inputs.DetectionScores, Inputs.DetectionClasses, Inputs.NumDetections)
                   .Run();

            Outputs = new GraphOutputsModel(output);
        }
    }
}