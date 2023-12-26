﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System.Collections.Generic;

namespace IdentityServerHost.Quickstart.UI
{
    public class MfaRegistrationViewModel : MfaRegistrationInputModel
    {
        public string KeyUri { get; set; }
    }
}
