# player for ZTZBX Framework

### **Requirements**
- [core-ztzbx](https://github.com/ZTZBX/core-ztzbx)
- [notification](https://github.com/ZTZBX/notification)
- [fivem-mysql](https://github.com/ZTZBX/fivem-mysql)


To edit it, open `player.sln` in Visual Studio.

To build it, run `build.cmd`. To run it, run the following commands to make a symbolic link in your server data directory:

```dos
cd /d [PATH TO THIS RESOURCE]
mklink /d X:\cfx-server-data\resources\[local]\player dist
```

Afterwards, you can use `ensure player` in your server.cfg or server console to start the resource.