﻿using Chinchilla.Specifications.Messages;
using Machine.Fakes;
using Machine.Specifications;
using RabbitMQ.Client;

namespace Chinchilla.Specifications
{
    public class PublishChannelSpecification
    {
        [Subject(typeof(PublishChannel))]
        public class when_disposing : WithSubject<PublishChannel>
        {
            Because of = () =>
                Subject.Dispose();

            It should_abort_model = () =>
                The<IModel>().WasToldTo(m => m.Abort());

            It should_dispose_model = () =>
                The<IModel>().WasToldTo(m => m.Dispose());
        }

        [Subject(typeof(PublishChannel))]
        public class when_disposing_multiple_times : WithSubject<PublishChannel>
        {
            Because of = () =>
            {
                Subject.Dispose();
                Subject.Dispose();
            };

            It should_abort_model = () =>
                The<IModel>().WasToldTo(m => m.Abort()).OnlyOnce();

            It should_dispose_model = () =>
                The<IModel>().WasToldTo(m => m.Dispose()).OnlyOnce();
        }

        [Subject(typeof(PublishChannel))]
        public class when_publishing : WithSubject<PublishChannel>
        {
            Because of = () =>
                Subject.Publish(new TestMessage());

            It should_serialize_message = () =>
                The<IMessageSerializer>().WasToldTo(s => s.Serialize(Param.IsAny<IMessage<TestMessage>>()));
        }
    }
}