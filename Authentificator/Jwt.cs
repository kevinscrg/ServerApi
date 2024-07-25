using System.Security.Claims;

namespace ServerApi.Authentificator
{
    public class Jwt
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }

        public static int validateToken(ClaimsIdentity identity)
        {
            try
            {
                if (identity.Claims.Count() == 0) throw new Exception("verify the token validation");

                var id = identity.Claims.FirstOrDefault(c => c.Type == "Id").Value;
                return Int32.Parse(id);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
