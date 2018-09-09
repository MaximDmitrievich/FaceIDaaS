using FaceDetectionApi.Utils;
using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FaceDetectionApi
{
    public class FaceClientContext
    {
        private readonly IFaceClient _client;

        public FaceClientContext(IFaceClient client)
        {
            _client = client;
            _client.Endpoint = Consts.Endpoint;
        }

        public async Task<bool> CreatePerson(Model model)
        {
            bool result = false;

            Person person = await _client.PersonGroupPerson.CreateAsync(Consts.personGroupId, model.Name);

            MemoryStream memstream = new MemoryStream(model.byteContent, 0, model.byteContent.Length);

            await _client.PersonGroupPerson.AddFaceFromStreamAsync(Consts.personGroupId, person.PersonId, memstream);

            await _client.PersonGroup.TrainAsync(Consts.personGroupId);

            while (true)
            {
                TrainingStatus trainingStatus = null;
                trainingStatus = await _client.PersonGroup.GetTrainingStatusAsync(Consts.personGroupId);
                if (trainingStatus.Status != TrainingStatusType.Running)
                {
                    result = true;
                    break;
                }
                await Task.Delay(1000);
            }

            return result;
        }

        public async Task<bool> CheckPerson(Model model)
        {
            bool result = false;
            if (model.Name != null && model.Name.Length > 0) {
                result = true;
            }
            await Task.Delay(1);
            return result;
        }
        
        public void Dispose()
        {
            //_client.Dispose();
        }
    }
}
