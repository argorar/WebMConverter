WebM for Lazys 
=============
A wrapper around ffmpeg and AviSynth made for converting videos to WebM without having to use the command line, fork of [this project](https://gitgud.io/nixx/WebMConverter#webm-for-retards-).

- **Download it [here][LatestDownload].**

Important to know:
* Requires .NET Framework 4.5 (Windows 7 comes with 3.5, so you might want to [update][DotNet45])
* Requires Microsoft Visual C++ 2010 (x86) [Download here][MVC]
* Requires [AviSynth][AviSynth] (2.6.0, 32-bit)
* Already includes ffmpeg
* Only works on Windows 

## Features

You can get and edit your video easly with the next options.

### Download

Paste the url of the video you want. I will download the best quality for you.
* Support for [+1000 sites][Sites]
* You can choose the default path for all your new videos
* Load the video in the app with just one click

![download](img/download.JPG)

### Trim

Trim precisely the length, with a simple interface. You can do multiple trims if you need.

![trim](img/trim.JPG)

### Crop

Crop what is just important for you, just move the edges with the mouse.

![crop](img/crop.JPG)

### Filter

If your video looks dark, you can change it.

![filter](img/light.JPG)

### Caption

Add text, change font, size, position, also set when it start and end.

![caption](img/caption.JPG)

### There is More that you can do

* Add subtitle
* Resize 
* If you want your video to go reverse, i can do it for you
* Overlay your logo
* Change the speed
* Rotate
* Fade
* Disable audio
* Get specific filesize in final result
* Get high quality video
* Interpolate, more frames to your video

### Upload to Gfycat

I upload your new masterpiece for you with just one click.

### Changelog

#### Version 3.0.0
* Fixed laggy trim functionality (with 4k files is a still a little slower)
* Now you can use Space key to play 100 frames in trim functionality
* Set the exact % value in change rate functionality 
* Now your settings are remembered 
* Gfycat integration using browser-based OAuth authentication. Upload your gfy after convert with one click

#### Version 3.1.0
* Added option to interpolate frames in Advanced/Encoding
* Improved trim lag going forward with 4k videos

#### Version 3.2.0
* Now you can set when you want your caption to start and end
* In caption form you can advance frame by frame changing *start frame* value. You can use mouse wheel too
* Changed algorithm to interpolate
* Now the update feature is enabled

#### Version 3.2.1
* Interpolation result is better now
* Minor changes in *New update available*
* Fixed when your drop a file, that make your settings reset 

#### Version 3.2.2
* Fixed Gfycat title

#### Version 3.2.3
* Improved performance of function to get frames on multiprocessor systems

#### Version 3.2.4
* Now you can working editing other video while the file upload to gfycat

#### Version 3.3.0
* Download your video is easy now (support +1000 sites), [see more information.][Sites]

#### Versin 3.3.1
* Bring dark videos to light, try it in Advanced> Processing> Colors levels
* Minor changes to performance in filters

#### Versin 3.3.2
* Revert new filter, it is causing collateral issues

#### Versin 3.3.3
* Lighten Filter is back, come and say hi

### License
This software is released under the MIT license.

If you have any issues with this program, you may report them on [here][NewIssue].

 [LatestDownload]: https://github.com/argorar/WebMConverter/releases/latest
 [DotNet45]: https://www.microsoft.com/en-us/download/details.aspx?id=30653
 [AviSynth]: http://avisynth.nl/index.php/Main_Page#Official_builds
 [NewIssue]: https://github.com/argorar/WebMConverter/issues
 [MVC]: https://www.microsoft.com/en-us/download/details.aspx?id=8328
 [Sites]: https://ytdl-org.github.io/youtube-dl/supportedsites.html
