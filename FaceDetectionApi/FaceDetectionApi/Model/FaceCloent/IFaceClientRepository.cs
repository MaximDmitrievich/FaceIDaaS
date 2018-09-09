using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceDetectionApi
{
    public interface IFaceClientRepository : IDisposable
    {
        Task<bool> CreatePerson(Model model);
        Task<bool> CheckPerson(Model model);
        void Dispose();
    }
}
