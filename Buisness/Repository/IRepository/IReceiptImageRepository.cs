using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Repository.IRepository
{
    public interface IReceiptImageRepository
    {
      public Task<int> CreateReceiptImage(ReceiptImageDTO receiptImageDTO);
        public Task<int> DeleteReceiptImageById(int imageId);

        //public Task<int> DeleteReceiptImageByProductId(int imageId); (devo prima implementare la possibilità di cancellare un evento.....)
        public Task<IEnumerable<ReceiptImageDTO>> GetAllReceiptImages(int feeId); 
    }
}
