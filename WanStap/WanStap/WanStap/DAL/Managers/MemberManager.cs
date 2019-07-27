using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WanStap.DAL.Repository;
using WanStap.DTO;
using WanStap.Models;

namespace WanStap.DAL.Managers
{
    public class MemberManager
    {
        private IGenericRepository<Member> _member;

        public MemberManager(WanStapContext context)
        {
            _member = new GenericRepository<Member>(context);
        }

        public Member InsertMember(MemberDTO dto, string user, string id)
        {
            try
            {
                var member = new Member()
                {
                    Birthdate = dto.Birthdate,
                    CreatedBy = user,
                    CreatedDateTime = _member.GetCurrentDate(),
                    FirstName = dto.FirstName,
                    Id = id,
                    MemberTypeId = dto.MemberTypeId,
                    MiddleName = dto.MiddleName,
                    PhoneNumber = dto.PhoneNumber,
                    UserName = dto.UserName,
                    LastName = dto.LastName
                };

                _member.Insert(member);
                _member.SaveChanges();
                return member;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}