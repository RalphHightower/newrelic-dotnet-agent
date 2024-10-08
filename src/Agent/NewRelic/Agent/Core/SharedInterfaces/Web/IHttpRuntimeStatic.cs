// Copyright 2020 New Relic, Inc. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

namespace NewRelic.Agent.Core.SharedInterfaces.Web
{
    public interface IHttpRuntimeStatic
    {
        string AppDomainAppVirtualPath { get; }
    }
}
