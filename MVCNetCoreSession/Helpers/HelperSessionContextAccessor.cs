using MVCNetCoreSession.Extensions;
using MVCNetCoreSession.Models;

namespace MVCNetCoreSession.Helpers
{
    public class HelperSessionContextAccessor
    {
        IHttpContextAccessor contextAccessor;
        

        public HelperSessionContextAccessor(IHttpContextAccessor contextAccesor)
        {
            this.contextAccessor = contextAccessor;
        }

        public  List<Mascota> GetMascotasSession()
        {

            List<Mascota> mascotas =
            this.contextAccessor.HttpContext
            .Session.GetObject<List<Mascota>>("MASCOTAS");
            return mascotas;
        }
           
    }
}
