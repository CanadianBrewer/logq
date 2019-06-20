# logq
A simple, fast queue-based logger. 

This class (LogQ) allows you to write a log item to a queue which is processed in the background to persist the data. Super-fast. I came up with this after seeing an article on `BlockingCollection<T>` and while there are faster ways to do this now, this is simple, maintainable, and has worked really well in production environments.

Right now if just dumps data to a text file but can be easily extended to write to a db (which is how it actually runs in a live environment).

LogProducer is just a console app to show how LogQ can be used.
