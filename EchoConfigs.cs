// --------------------------------------------------------------
//  Copyright (c) Lani Corporation.  All rights reserved.
// --------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lani.Abstractions.Aware.Grains;

namespace Lani.Misc.SourceCode.TimePackage;

public class EchoConfigs : IGrainConfig
{
    public string Input { get; set; } = string.Empty;
}
