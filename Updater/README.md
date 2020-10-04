The certificate was generated with the following command:
```
C:\Program Files (x86)\Windows Kits\8.1\bin\x64>makecert -n "CN=nixx quality-88d1c5f0-e3e0-445a-8e11-a02441ab6ca8" -r -a sha512 -ss My -sky signature -pe
```

The executables are signed with the following command:
```
C:\Program Files (x86)\Windows Kits\8.1\bin\x64>signtool sign /t http://timestamp.verisign.com/scripts/timstamp.dll /n "nixx quality-88d1c5f0-e3e0-445a-8e11-a02441ab6ca8" C:\Users\Linus\Documents\Code\WebMConverter\bin\Release\WebMConverter.exe
```
