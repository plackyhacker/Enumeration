# Enumeration

A small collection of .Net assemblies that can be used to enumerate a host. It is better to load these in to memory than run them from disk. Or incorporate them in the C2 beacon if you have a .Net C2.

## Endpoint Detection and Response

[EDR](https://github.com/plackyhacker/Enumeration/blob/main/Classes/EDR.cs)

This is a .Net version of the Cobalt Strike aggressor script [EDR.cna](https://github.com/harleyQu1nn/AggressorScripts/blob/master/EDR.cna).

**Example**

<img width="924" alt="Screenshot 2023-11-18 at 15 15 29" src="https://github.com/plackyhacker/Enumeration/assets/42491100/b42c241c-26a9-4e3b-b2e9-eed8d647e9dd">

## Processes

[Processes](https://github.com/plackyhacker/Enumeration/blob/main/Classes/Processes.cs)

This is a .Net class to enumerate the running processes on a compromised host.

**Example**

<img width="1065" alt="Screenshot 2023-11-19 at 08 56 21" src="https://github.com/plackyhacker/Enumeration/assets/42491100/107448b1-4d3b-4a36-9cc0-6c5cd919794d">
