using System;
using WanStap.DAL.Repository;
using WanStap.DTO;
using WanStap.Models;

namespace WanStap.DAL.Managers
{
    public class EstablishmentManager
    {
        private IGenericRepository<Establishment> _establishment;

        public EstablishmentManager(WanStapContext context)
        {
            _establishment = new GenericRepository<Establishment>(context);
        }

        public Establishment InsertEstablishment(EstablishmentDTO dto, int user)
        {
            try
            {
                var establishment = new Establishment()
                {
                    CreatedBy = user,
                    CreatedDateTime = _establishment.GetCurrentDate(),
                    Capacity = dto.Capacity,
                    EstablishmentTypeID = dto.EstablishmentTypeID,
                    MemberId = dto.MemberId,
                    Name = dto.Name
                };

                _establishment.Insert(establishment);
                _establishment.SaveChanges();
                return establishment;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}