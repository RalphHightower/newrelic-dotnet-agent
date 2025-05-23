// Copyright 2020 New Relic, Inc. All rights reserved.
// SPDX-License-Identifier: Apache-2.0


using NewRelic.Agent.IntegrationTestHelpers;
using NewRelic.Agent.IntegrationTestHelpers.RemoteServiceFixtures;
using NewRelic.Agent.IntegrationTests.Shared.Wcf;
using Xunit;

namespace NewRelic.Agent.IntegrationTests.WCF.Service.Self
{
    public abstract class WCFService_Self : WCFServiceTestBase
    {
        public WCFService_Self(ConsoleDynamicMethodFixtureFWLatest fixture, ITestOutputHelper output, WCFBindingType bindingType, WCFLegacyTracingTestOption testOption)
            : base(fixture, output, bindingType, testOption, HostingModel.Self, ASPCompatibilityMode.Disabled, new WCFLogHelpers_SelfHosted(fixture))
        {
        }
    }

    public class WCFService_Self_NetTCP : WCFService_Self
    {
        public WCFService_Self_NetTCP(ConsoleDynamicMethodFixtureFWLatest fixture, ITestOutputHelper output)
            : base(fixture, output, WCFBindingType.NetTcp, WCFLegacyTracingTestOption.None)
        {
        }
    }

    public class WCFService_Self_WebHTTP : WCFService_Self
    {
        public WCFService_Self_WebHTTP(ConsoleDynamicMethodFixtureFWLatest fixture, ITestOutputHelper output)
            : base(fixture, output, WCFBindingType.WebHttp, WCFLegacyTracingTestOption.None)
        {
        }
    }

    public class WCFService_Self_WSHTTP : WCFService_Self
    {
        public WCFService_Self_WSHTTP(ConsoleDynamicMethodFixtureFWLatest fixture, ITestOutputHelper output)
            : base(fixture, output, WCFBindingType.WSHttp, WCFLegacyTracingTestOption.None)
        {
        }
    }

    public class WCFService_Self_BasicHTTP : WCFService_Self
    {
        public WCFService_Self_BasicHTTP(ConsoleDynamicMethodFixtureFWLatest fixture, ITestOutputHelper output)
            : base(fixture, output, WCFBindingType.BasicHttp, WCFLegacyTracingTestOption.None)
        {
        }
    }

    public class WCFService_Self_WebHTTP_DT : WCFService_Self
    {
        public WCFService_Self_WebHTTP_DT(ConsoleDynamicMethodFixtureFWLatest fixture, ITestOutputHelper output)
            : base(fixture, output, WCFBindingType.WebHttp, WCFLegacyTracingTestOption.DT)
        {
        }
    }

    public class WCFService_Self_WSHTTP_DT : WCFService_Self
    {
        public WCFService_Self_WSHTTP_DT(ConsoleDynamicMethodFixtureFWLatest fixture, ITestOutputHelper output)
            : base(fixture, output, WCFBindingType.WSHttp, WCFLegacyTracingTestOption.DT)
        {
        }
    }

    public class WCFService_Self_BasicHTTP_DT : WCFService_Self
    {
        public WCFService_Self_BasicHTTP_DT(ConsoleDynamicMethodFixtureFWLatest fixture, ITestOutputHelper output)
            : base(fixture, output, WCFBindingType.BasicHttp, WCFLegacyTracingTestOption.DT)
        {
        }
    }

    public class WCFService_Self_NetTCP_DT : WCFService_Self
    {
        public WCFService_Self_NetTCP_DT(ConsoleDynamicMethodFixtureFWLatest fixture, ITestOutputHelper output)
            : base(fixture, output, WCFBindingType.NetTcp, WCFLegacyTracingTestOption.DT)
        {
        }
    }

    public class WCFService_Self_WebHTTP_CAT : WCFService_Self
    {
        public WCFService_Self_WebHTTP_CAT(ConsoleDynamicMethodFixtureFWLatest fixture, ITestOutputHelper output)
            : base(fixture, output, WCFBindingType.WebHttp, WCFLegacyTracingTestOption.CAT)
        {
        }
    }

    public class WCFService_Self_WSHTTP_CAT : WCFService_Self
    {
        public WCFService_Self_WSHTTP_CAT(ConsoleDynamicMethodFixtureFWLatest fixture, ITestOutputHelper output)
            : base(fixture, output, WCFBindingType.WSHttp, WCFLegacyTracingTestOption.CAT)
        {
        }
    }

    public class WCFService_Self_BasicHTTP_CAT : WCFService_Self
    {
        public WCFService_Self_BasicHTTP_CAT(ConsoleDynamicMethodFixtureFWLatest fixture, ITestOutputHelper output)
            : base(fixture, output, WCFBindingType.BasicHttp, WCFLegacyTracingTestOption.CAT)
        {
        }
    }

    public class WCFService_Self_NetTCP_CAT : WCFService_Self
    {
        public WCFService_Self_NetTCP_CAT(ConsoleDynamicMethodFixtureFWLatest fixture, ITestOutputHelper output)
            : base(fixture, output, WCFBindingType.NetTcp, WCFLegacyTracingTestOption.CAT)
        {
        }
    }

    public class WCFService_Self_Custom : WCFService_Self
    {
        public WCFService_Self_Custom(ConsoleDynamicMethodFixtureFWLatest fixture, ITestOutputHelper output)
            : base(fixture, output, WCFBindingType.Custom, WCFLegacyTracingTestOption.CAT)
        {
        }
    }

    public class WCFService_Self_CustomClass : WCFService_Self
    {
        public WCFService_Self_CustomClass(ConsoleDynamicMethodFixtureFWLatest fixture, ITestOutputHelper output)
            : base(fixture, output, WCFBindingType.CustomClass, WCFLegacyTracingTestOption.CAT)
        {
        }
    }
}
