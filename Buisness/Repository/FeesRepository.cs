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
    public class FeesRepository : IFeesRepository
    {
        private readonly ApplicationDBContext _db;
        private readonly IMapper _mapper;

        public FeesRepository(ApplicationDBContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }

      
         

        public async Task<FeesDTO> CreateFee(FeesDTO feesDTO)
        {
            Fees fee = _mapper.Map<FeesDTO, Fees>(feesDTO);

            //contacts.CreatedDate = DateTime.Now;
            //contacts.CreatedBy = "";

            var addedFee = await _db.FeesList.AddAsync(fee);
            await _db.SaveChangesAsync();
            return _mapper.Map<FeesDTO>(addedFee.Entity);

        }

        public async Task<IEnumerable<FeesDTO>> GetAllFees()
        {
            try
            {
                IEnumerable<Fees> fees = await _db.FeesList.ToListAsync();
                IEnumerable<FeesDTO> FeesDTOs = _mapper.Map<IEnumerable<FeesDTO>>(fees);
                if (fees == null)
                {
                    // Gestisci il caso o registra un messaggio di errore.
                    Console.WriteLine("Error: _db.ContactsList gave null.");
                    return Enumerable.Empty<FeesDTO>(); // ritorna un enumerable vuoto.
                }

                if (FeesDTOs == null)
                {
                    // Gestisci il caso o registra un messaggio di errore.
                    Console.WriteLine("Error: mapping gave null.");
                    return Enumerable.Empty<FeesDTO>(); // ritorna un enumerable vuoto.
                }

                return FeesDTOs;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore in GetAllContacts: {ex}");
                throw; // Rilancia l'eccezione o gestiscila come preferisci.
            }

        }

        public async Task<IEnumerable<FeesDTO>> ProductIdFees(long? ProductId)
        {
            return _mapper.Map<IEnumerable<Fees>, IEnumerable<FeesDTO>>(
                            await _db.FeesList.Where(x => x.ProductId == ProductId).ToListAsync());

        }

        public async Task<int> DeleteFees(int feeId)
        {
            var feeDetails = await _db.FeesList.FindAsync(feeId);

            if (feeDetails != null)
            {

                _db.FeesList.Remove(feeDetails);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<FeesDTO> GetFee(int feeId)
        {
            try
            {

                FeesDTO fee = _mapper.Map<Fees, FeesDTO>(

                    await _db.FeesList.Include(x => x.FeesReceipt).FirstOrDefaultAsync(x => x.Id == feeId));

                return fee;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<FeesDTO> UpdateFee(int FeeId, FeesDTO feesDTO)
        {
            try
            {


                if (FeeId == feesDTO.Id)
                {
                    Fees feeDetails = await _db.FeesList.FindAsync(FeeId);
                    Fees fee = _mapper.Map<FeesDTO, Fees>(feesDTO, feeDetails);
                    fee.CreatedAt = DateTime.Now;
                    var updatedFee = _db.FeesList.Update(fee);
                    await _db.SaveChangesAsync();
                    return _mapper.Map<Fees, FeesDTO>(updatedFee.Entity);


                }
                else
                {
                    return null;
                    //invalid
                }
            }
            catch (Exception ex)
            {
                return null;

            }
        }

    }
}
