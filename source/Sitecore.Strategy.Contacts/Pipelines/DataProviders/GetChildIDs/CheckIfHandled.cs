﻿using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Diagnostics;
using Sitecore.Strategy.Contacts.Pipelines.DataProviders.IsHandled;
using Sitecore.Pipelines;

namespace Sitecore.Strategy.Contacts.Pipelines.DataProviders.GetChildIDs
{
    public class CheckIfHandled
    {
        public virtual void Process(GetChildIDsArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            Assert.ArgumentNotNull(args.ItemDefinition, "args.ItemDefinition");
            var args2 = new IsHandledArgs(args.ItemDefinition.ID, args.Context);
            args2.IncludeAllIds = true;
            CorePipeline.Run("contactFacetDataProvider.isHandled", args2);
            if (!args2.IsHandled)
            {
                args.AbortPipeline();
            }
        }
    }
}