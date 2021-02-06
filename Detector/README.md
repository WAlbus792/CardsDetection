1. Install ara TensorFlowSharp 1.5.0 (kaxvac train exac model-i TensorFlow-i versiayic)\
After installation you need also take the _libtensorflow.dll_ file (from path: "{SolutionDir}\packages\TensorFlowSharp.{version}\runtimes\{OSVersion}\native") and put in _bin/Debug_ folder
####
2. Install Newtonsoft.JSON (_if not installed_) for parsing labelmap.pbtxt (using [LabelReader](Utilities/LabelReader.cs)) to class object for showing the names of the objects