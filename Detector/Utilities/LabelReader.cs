using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Detector.Models;
using Newtonsoft.Json;

namespace Detector.Utilities
{
    public static class LabelMapReader
    {
        internal static IEnumerable<ImageLabelModel> ReadFromFile(string filePath) => File.ReadAllText(filePath)
           .Trim()
           .Split(new[] { "item" }, StringSplitOptions.RemoveEmptyEntries)
           .Select(jsonObjStr =>
            {
                string[] propertyLines = jsonObjStr.Trim().Split(new[] { "\r\n", "{", "}" }, StringSplitOptions.RemoveEmptyEntries);
                return "{" + string.Join(",", propertyLines.Select(propLine => "\"" + propLine.Trim().Replace(":", "\":"))) + "}";
            })
           .Select(JsonConvert.DeserializeObject<ImageLabelModel>)
           .ToList();
    }
}