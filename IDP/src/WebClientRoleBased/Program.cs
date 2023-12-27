using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme =  "Cookies";//CookieAuthenticationDefaults.AuthenticationScheme;//
    options.DefaultChallengeScheme =  "oidc";//OpenIdConnectDefaults.AuthenticationScheme;//
})
    .AddCookie("Cookies", options =>
    {
        options.AccessDeniedPath = "/AccesDenied";
    })
    .AddOpenIdConnect("oidc", options =>
    {
        options.SignInScheme = "Cookies";
        options.Authority = "https://localhost:5001";

        options.ClientId = "webRolebase";
        options.ClientSecret = "secret";
        options.ResponseType = "code";
        // signoutCallbackpath  => default
        // this is a dictanary to map old microsoft claim system for backwordcompatibilityt
        // JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

        options.Scope.Clear();
        options.Scope.Add("openid");
        options.Scope.Add("profile");
        options.Scope.Add("api1");
        options.Scope.Add("offline_access");
        options.GetClaimsFromUserInfoEndpoint = true;
        options.Scope.Add("verification");
        options.Scope.Add("roles");
        options.ClaimActions.MapJsonKey("email_verified", "email_verified");
        options.ClaimActions.MapJsonKey("role", "role");
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            RoleClaimType = "role"
        };
        //options.GetClaimsFromUserInfoEndpoint = true;

        options.SaveTokens = true;
    })
    ;


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages().RequireAuthorization();

app.Run();
