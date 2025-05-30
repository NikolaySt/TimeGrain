// --------------------------------------------------------------
//  Copyright (c) Lani Corporation.  All rights reserved.
// --------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lani.Abstractions.Aware.Connectors.PackageLoader;

namespace Lani.Misc.SourceCode.TimePackage;

public abstract class TimeArgs<T> : LaniPackageArgs<T>
{
    protected override void OnBlockStore(WriteProvider writeProvider)
    {
        base.OnBlockStore(writeProvider);
        using var writer = writeProvider.ObtainSubBlockWriter(0);
    }

    protected override void OnBlockLoad(ReadProvider readProvider)
    {
        base.OnBlockLoad(readProvider);
        using var reader = readProvider.ObtainSubBlockReader(true);
    }
}
