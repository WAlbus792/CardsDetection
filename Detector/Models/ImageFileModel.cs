using System.IO;

namespace Detector.Models
{
    public class ImageFileModel
    {
        public ImageFileModel(string fileFullPath)
        {
            FullPath = fileFullPath;
            Name = Path.GetFileName(FullPath);
        }

        public ImageFileModel(string fileName, string dir)
        {
            Name = fileName;
            FullPath = Path.Combine(dir, fileName);
        }

        public string FullPath { get; }
        public string Name { get; }
    }
}