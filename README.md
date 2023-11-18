# Enumeration

A small collection of .Net assemblies that can be used to enumerate a host. It is better to load these in to memory than run them from disk. Or incorporate them in the C2 beacon if you have a .Net C2.

[EnumEDR](https://github.com/plackyhacker/Enumeration/tree/main/EnumEDR)

This is a .Net version of the Cobalt Strike aggressor script [EDR.cna](https://github.com/harleyQu1nn/AggressorScripts/blob/master/EDR.cna). The code is [here](https://github.com/plackyhacker/Enumeration/blob/main/EnumEDR/EnumEDR/Program.cs).

**Usage**

```
EnumEDR.exe <host>
```

**Example**

<img width="924" alt="Screenshot 2023-11-18 at 15 15 29" src="https://github.com/plackyhacker/Enumeration/assets/42491100/b42c241c-26a9-4e3b-b2e9-eed8d647e9dd">
