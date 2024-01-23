using AutoMapper;
using Buisness.Repository.IRepository;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Repository
{
    public class ReceiptImagesRepository : IReceiptImageRepository
    {
        private readonly ApplicationDBContext _db;
        private readonly IMapper _mapper;

        public ReceiptImagesRepository(ApplicationDBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<int> CreateReceiptImage(ReceiptImageDTO receiptImageDTO)
        {
           var image = _mapper.Map<ReceiptImageDTO, ReceiptImage>(receiptImageDTO);   
            await _db.ReceiptImagesList.AddAsync(image);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteReceiptImageById(int imageId)
        {
            var image = await _db.ReceiptImagesList.FindAsync(imageId);
            _db.ReceiptImagesList.Remove(image);
            return await _db.SaveChangesAsync();
         }

     

        public async Task<IEnumerable<ReceiptImageDTO>> GetAllReceiptImages(int feeId)
        {
            return _mapper.Map<IEnumerable<ReceiptImage>, IEnumerable<ReceiptImageDTO>>(
                            await _db.ReceiptImagesList.Where(x => x.FeeId == feeId).ToListAsync());


        }
    }
}


