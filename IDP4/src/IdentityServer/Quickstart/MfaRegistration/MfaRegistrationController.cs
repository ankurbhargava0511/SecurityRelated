// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using IdentityModel;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace IdentityServerHost.Quickstart.UI
{
    /// <summary>
    /// This controller processes the consent UI
    /// </summary>
    [SecurityHeaders]
    [Authorize]
    public class MfaRegistrationController : Controller
    {
        //private readonly ILocalUserService _localUserService;
        private readonly char[] chars =
           "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        public MfaRegistrationViewModel View { get; set; }

        [BindProperty]
        public MfaRegistrationInputModel Input { get; set; }


        /// <summary>
        /// Shows the consent screen
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var rndon = new Random();

            byte[] tokenData = new Byte[64];
            rndon.NextBytes(tokenData);

            var result = new StringBuilder(16);
            for (int i = 0; i < 16; i++)
            {
                var rnd = BitConverter.ToUInt32(tokenData, i * 4);
                var idx = rnd % chars.Length;

                result.Append(chars[idx]);
            }

            var secret = result.ToString();

            var subject = User.FindFirst(JwtClaimTypes.Subject)?.Value;
            //var user = await _localUserService.GetUserBySubjectAsync(subject);

            var keyUri = string.Format(
               "otpauth://totp/{0}:{1}?secret={2}&issuer={0}",
               WebUtility.UrlEncode("Ankur"),
               WebUtility.UrlEncode("ankur.bhargava@jet2.com"),
               secret);

            View = new MfaRegistrationViewModel
            {
                KeyUri = keyUri
            };

            Input = new MfaRegistrationInputModel
            {
                Secret = secret
            };

            return View("Index", View);
        }

        /// <summary>
        /// Handles the consent screen postback
        /// </summary>
        [HttpPost]
        
        public async Task<IActionResult> Index( string str)
        {
            if (ModelState.IsValid)
            {
                string testsecret = Input.Secret;
                var subject = User.FindFirst(JwtClaimTypes.Subject)?.Value;
                return Redirect("~/");
            }
            else
            {
                return View("Index");
            }
        }

       
    }
}