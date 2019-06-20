# logq
A simple, fast queue-based logger. 

This class allows you to write a log item to a queue which is processed in the background to persist the data. Super-fast.

Right now if just dumps data to a text file but can be easily extended to write to a db (which is how it actually runs in a live environment).
