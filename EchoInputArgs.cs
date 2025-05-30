// --------------------------------------------------------------
//  Copyright (c) Lani Corporation.  All rights reserved.
// --------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lani.Misc.SourceCode.TimePackage;

public sealed class EchoInputArgs : EchoArgs<string>, IEchoArgs
{
    public string Input { get; set; } = default!;

    protected override void OnBlockStore(WriteProvider writeProvider)
    {
        base.OnBlockStore(writeProvider);
        using var writer = writeProvider.ObtainSubBlockWriter(0);
        writer.WriteAny(Input);
    }

    protected override void OnBlockLoad(ReadProvider readProvider)
    {
        base.OnBlockLoad(readProvider);
        using var reader = readProvider.ObtainSubBlockReader(true);
        Input = reader.ReadAny<string>();
    }
}
