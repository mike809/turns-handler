turns-handler
=============

How to use:

1- Install driver
2- Run server
3- Run Client and login

Login guest credentials:
1- username: mike,    password: durakuzz1 /n
2- username: richddr, password: durakuzz

Program to manage the turns of people in medical exams.

This is a client-server desktop application intended to be
used by medical centers to enable multiple people to serve
patients at the same time.

We have a database with the different medical exams from 4
different medical departments. Each exam has it's duration.
The server takes care of assigning the time for each of the
patients exams, it look for an empty space in the schedule
where it can fit the exam, making sure it doesn't overlap
with another exam from that department or another exam from
the same patient.
