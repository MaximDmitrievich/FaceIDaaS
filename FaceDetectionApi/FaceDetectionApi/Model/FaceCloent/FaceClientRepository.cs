using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceDetectionApi
{
    public class FaceClientRepository : IFaceClientRepository
    {
        public FaceClientRepository(FaceClientContext context)
        {
            _context = context;
        }

        private readonly FaceClientContext _context;

        public async Task<bool> CreatePerson(Model model)
        {
            return await _context.CreatePerson(model);
        }
        public async Task<bool> CheckPerson(Model model)
        {
            return await _context.CheckPerson(model);
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
