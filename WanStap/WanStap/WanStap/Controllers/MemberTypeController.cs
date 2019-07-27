using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity.Owin;
using WanStap.Models;
using WanStap.DAL.Managers;
using WanStap.DTO;

namespace WanStap.Controllers
{
    [RoutePrefix("api/MemberType")]
    public class MemberTypeController : ApiController
    {
        private MemberTypeManager _memberTypeManager;
        public MemberTypeController()
        {
            _memberTypeManager = new MemberTypeManager(new WanStapContext());
        }

        public MemberTypeManager MemberTypeManager
        {
            get
            {
                return _memberTypeManager ?? new MemberTypeManager(System.Web.HttpContext.Current.GetOwinContext().Get<WanStapContext>());
            }
            private set
            {
                _memberTypeManager = value;
            }
        }

        // GET: MemberType
        [Route("Add")]
        [HttpPost]
        public IHttpActionResult Add(MemberTypeDTO model)
        {
            var result = _memberTypeManager.InsertMemberType(model);
            if(result == null)
            {
                return BadRequest("Error adding member type.");
            }
            return Ok(result);
        }
    }
}