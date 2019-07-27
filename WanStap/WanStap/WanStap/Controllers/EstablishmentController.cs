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

        [HttpPost]
        [Route("api/establishment/Add")]
        public IHttpActionResult Add(EstablishmentDTO model)
        {
            var result = _establishmentManager.InsertEstablishment(model, 0);
            if (result == null)
            {
                return BadRequest("Error adding establishment.");
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("api/establishment/Edit")]
        public IHttpActionResult Edit(EstablishmentUpdateDTO model)
        {
            var result = _establishmentManager.UpdateEstablishment(model, 0);
            if (result == null)
            {
                return BadRequest("Error editing establishment.");
            }
            return Ok(result);
        }
    }
}