using System;
using WanStap.DAL.Repository;
using WanStap.DTO;
using WanStap.Models;

namespace WanStap.DAL.Managers
{
    public class MemberTypeManager
    {
        private IGenericRepository<MemberType> _memberType;

        public MemberTypeManager(WanStapContext context)
        {
            _memberType = new GenericRepository<MemberType>(context);
        }

        public MemberType InsertMemberType(MemberTypeDTO dto)
        {
            try
            {
                var memberType = new MemberType()
                {
                    Name = dto.Name,
                    Description = dto.Description,
                    CreatedBy = "test",
                    CreatedDateTime = _memberType.GetCurrentDate()
                };

                _memberType.Insert(memberType);
                _memberType.SaveChanges();
                return memberType;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}