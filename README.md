WebM for Lazys 
=============
A wrapper around ffmpeg and AviSynth made for converting videos to WebM without having to use the command line, [Original project](https://gitgud.io/nixx/WebMConverter#webm-for-retards-).

- **Download it [here][LatestDownload].**

Important to know:
* Requires .NET Framework 4.5 (Windows 7 comes with 3.5, so you might want to [update][DotNet45])
* Requires [AviSynth][AviSynth] (2.6.0, 32-bit)
* Already includes ffmpeg
* Only works on Windows (I assume Linux users don't need GUIs)

### Changelog

#### Version 3.0.0
* Fixed laggy trim functionality (with 4k files is a still a little slower)
* Now you can use Space key to play 100 frames in trim functionality
* Set the exact % value in change rate functionality 
* Now your settings are remembered 
* Gfycat integration using browser-based OAuth authentication. Upload your gfy after convert with one click

This software is released under the MIT license. See LICENSE.md .

If you have any issues with this program, you may report them on [here][NewIssue].

 [LatestDownload]: https://github.com/argorar/WebMConverter/releases/tag/3.0.0
 [DotNet45]: https://www.microsoft.com/en-us/download/details.aspx?id=30653
 [AviSynth]: http://avisynth.nl/index.php/Main_Page#Official_builds
 [NewIssue]: https://github.com/argorar/WebMConverter/issues
