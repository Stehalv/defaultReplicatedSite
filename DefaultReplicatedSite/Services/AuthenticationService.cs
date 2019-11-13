using MakoLibrary.Services;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Web;

namespace DefaultReplicatedSite
{
    public static class Teqnavi
    {
        public static MakoService ServiceContext()
        {
            // We can get a service context in two ways
            // 1) pass in credentials - this will create a token (validating through sub-routine API's within the library)
            // 2) pass in a valid token
            // if you hvae a valid token it is always best to use it rather than re-authenitcating and re-building the token, saving on performance

            // check if we have already created a new token during this request, if so use it! (SaveToken Function)
            if (HttpContext.Current.Items["MakoJWT"] != null)
            {
                return new MakoService(HttpContext.Current.Items["MakoJWT"].ToString());
            }

            // check token exists and is valid - if not renew/create
            HttpCookie cookie = HttpContext.Current.Request.Cookies[Settings.API.APITokenName];

            if (cookie != null)
            {
                var token = cookie.Value;

                // renew token if less than defined time limit
                var jwtHandler = new JwtSecurityTokenHandler();
                if (jwtHandler.CanReadToken(token))
                {
                    var jwt = jwtHandler.ReadJwtToken(token);

                    if (DateTime.UtcNow.AddMinutes(Settings.API.TokenRenewTimeout) > jwt.ValidTo)
                    {
                        var request = new MakoService(cookie.Value).RenewToken();

                        if (request.Success)
                        {
                            SaveToken(request.Data.Token);

                            return new MakoService(request.Data.Token);
                        }
                    }
                    else if (jwt.ValidTo > DateTime.UtcNow)
                    {
                        return new MakoService(token);
                    }
                }
            }

            var service = new MakoService(Settings.API.TokenUsername, Settings.API.TokenPassword, Settings.API.CompanyId, MakoLibrary.Services.Environment.Production);
            SaveToken(service.Token);

            return service;
        }

        private static void SaveToken(string token)
        {
            // only want to renew once, so save to the request (cookie won't be updated until client request)
            HttpContext.Current.Items.Add("MakoJWT", token);

            HttpCookie cookie = HttpContext.Current.Request.Cookies[Settings.API.APITokenName];

            cookie = new HttpCookie(Settings.API.APITokenName, token)
            {
                HttpOnly = true
            };

            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}