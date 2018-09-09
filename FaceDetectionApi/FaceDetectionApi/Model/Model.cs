using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceDetectionApi
{
    public class Model
    {
        public string Name { get; set; }
        public string FaceId { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public Emotion Emotions { get; set; }
        public byte[] byteContent { get; set; }
    }
}
