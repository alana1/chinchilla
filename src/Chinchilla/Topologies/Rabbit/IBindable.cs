﻿namespace Chinchilla.Topologies.Rabbit
{
    public interface IBindable
    {
        string Name { get; set; }

        bool HasName { get; }

        void BindTo(IExchange exchange, params string[] routingKeys);

        void Visit(ITopologyVisitor visitor);
    }
}