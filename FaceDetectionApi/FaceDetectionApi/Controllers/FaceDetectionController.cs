using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FaceDetectionApi;
using Microsoft.AspNetCore.Mvc;

namespace FaceDetectionApi.Controllers
{
    [Route("api/facedetection")]
    public class FaceDetectionController : Controller
    {
        public FaceDetectionController(IFaceClientRepository repository)
        {
            _repository = repository;
        }

        private readonly IFaceClientRepository _repository;

        [HttpGet]
        public async Task<string> Get()
        {
            return "HelloPes";
        }

        [HttpPost]
        [Route("create")]
        public async Task<bool> CreatePerson([FromBody]Model model)
        {
            return await _repository.CreatePerson(model);
        }
        
        [HttpPost]
        [Route("check")]
        public async Task<bool> CheckPerson([FromBody]Model model)
        {
            return await _repository.CheckPerson(model);
        }
    }
}
