﻿namespace EventsRealisation.EventsWork
{
    public class Subscribe<T> 
    {
        public IPublisher<T> Publisher { get; private set; }
        public Subscribe(IPublisher<T> publisher)
        {
            Publisher = publisher;
        }
    }
}
