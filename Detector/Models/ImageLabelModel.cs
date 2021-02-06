namespace Detector.Models
{
    public class ImageLabelModel
    {
        public ImageLabelModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }

        public string Name { get; }
    }
}