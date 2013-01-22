﻿using Chinchilla.Integration.Features.Messages;
using NUnit.Framework;

namespace Chinchilla.Integration.Features
{
    [TestFixture]
    public class RequestResponseFeature : WithApi
    {
        [Test, Explicit]
        public void ShouldCreatePublisher()
        {
            using (var bus = Depot.Connect("localhost/integration"))
            {
                using (var requester = bus.CreateRequester<CapitalizeMessage, CapitalizedMessage>())
                {
                    CapitalizedMessage capitalized = null;

                    requester.Request(
                        new CapitalizeMessage("where am i?"),
                        response => { capitalized = response; });

                    Assert.That(capitalized, Is.Not.Null);
                    Assert.That(capitalized.Result, Is.EqualTo("WHERE AM I?"));
                }
            }
        }
    }
}
