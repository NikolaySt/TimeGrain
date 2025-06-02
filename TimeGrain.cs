// --------------------------------------------------------------
//  Copyright (c) Lani Corporation.  All rights reserved.
// --------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lani.Abstractions.Aware.Grains;
using Lani.Extended.Node.Common;

namespace Lani.Misc.SourceCode.TimePackage;

[GrainConfiguration(nameof(TimeConfigs))]
public class TimeGrain : LaniGrain
{
    private TimeConfigs? _config;

    public override Task<bool> CanExecuteAsync(IHyperArgs args)
    {
        return Task.FromResult(args is ITimeArgs);
    }

    public override async Task ConfigAsync(IGrainConfig? config = null)
    {
        if (config is TimeConfigs value)
            _config = value;
        else
            if (config == null)
            throw new Exception($"The provided configuration ({nameof(TimeConfigs)}) is null");

        await Task.CompletedTask;
    }

    public override async Task<IHyperArgs> ExecuteAsync(IHyperArgs args)
    {
        try
        {
            var task = args switch
            {
                GetCurrentTimeArgs getCurrentTimeArgs => OnExecuteAsync(getCurrentTimeArgs),

                _ => throw new NotImplementedException(),
            };

            var resultArgs = await task;
            return resultArgs;
        }
        catch (Exception ex)
        {
            args.SetFailed(new Abstractions.Infrastructure.ExecutionResult(false, ex.Message));
        }

        return args;
    }

    private async Task<IHyperArgs> OnExecuteAsync(GetCurrentTimeArgs args)
    {
        var tz = TimeZoneInfo.FindSystemTimeZoneById(args.TimeZone);
        var currentTimeInTz = TimeZoneInfo.ConvertTime(DateTime.UtcNow.AddDays(100), tz);
        args.SetResult(currentTimeInTz);
        return args;
    }
}
