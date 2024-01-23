using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Repository.IRepository
{
    public interface IFeesRepository
    {
        public Task<IEnumerable<FeesDTO>> GetAllFees();

        public Task<FeesDTO> CreateFee(FeesDTO feesDTO);

        public Task<FeesDTO> GetFee(int feeId);


        public Task<IEnumerable<FeesDTO>> ProductIdFees(long? ProductId);

        public Task<int> DeleteFees(int feeId);

        public Task<FeesDTO> UpdateFee(int FeeId, FeesDTO feesDTO);


    }
}
