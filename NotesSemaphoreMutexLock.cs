
/*
 a *lock* : allows only one thread to enter the part that's locked and the lock is not shared with any other processes.

A *mutex* is the same as a lock but it can be system wide (shared by multiple processes).

A *semaphore* does the same as a mutex but allows x number of threads to enter, 
this can be used for example to limit the number of cpu, io or ram intensive tasks running at the same time.

You also have read/write locks that allows either unlimited number of readers or 1 writer at any given time.
 
 
 */