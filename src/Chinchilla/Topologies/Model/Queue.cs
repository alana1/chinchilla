using System;

namespace Chinchilla.Topologies.Model
{
    public class Queue : Bindable, IQueue
    {
        public Queue()
        {
            Durability = Durability.Transient;
            IsAutoDelete = true;
        }

        public Queue(string name)
        {
            Name = name;
            Durability = Durability.Durable;
        }

        public Durability Durability { get; set; }

        public bool IsAutoDelete { get; set; }

        public bool IsExclusive { get; set; }

        public TimeSpan? MessageTimeToLive { get; set; }

        public TimeSpan? QueueAutoExpire { get; set; }

        public string DeadLetterExchange { get; set; }

        public override void Visit(ITopologyVisitor visitor)
        {
            visitor.Visit(this);

            foreach (var binding in Bindings)
            {
                binding.Visit(visitor);
            }
        }

        public override string ToString()
        {
            return string.Format("[Queue Name: {0}]", Name);
        }
    }
}