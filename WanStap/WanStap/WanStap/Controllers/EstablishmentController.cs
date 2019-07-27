using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity.Owin;
using WanStap.Models;
using WanStap.DAL.Managers;
using WanStap.DTO;

namespace WanStap.Controllers
{
    public class EstablishmentController : ApiController
    {
        private EstablishmentManager _establishmentManager;
        public EstablishmentController()
        {
            _establishmentManager = new EstablishmentManager(new WanStapContext());
        }

        public EstablishmentManager MemberTypeManager
        {
            get
            {
                return _establishmentManager ?? new EstablishmentManager(System.Web.HttpContext.Current.GetOwinContext().Get<WanStapContext>());
            }
            private set
            {
                _establishmentManager = value;
            }
        }

        [Route("Add")]
        [HttpPost]
        public IHttpActionResult Add(EstablishmentDTO model)
        {
            var result = _establishmentManager.InsertEstablishment(model, 0);
            if (result == null)
            {
                return BadRequest("Error adding establishment.");
            }
            return Ok(result);
        }
    }
}