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


## Updates

Get the last update with just one click.

![update](img/update.JPG)

## What can i do?

You can get and edit your video easly with the next options.

### Download

Paste the url of the video you want and press enter, the download will start. You will get the best quality.
* Support for [+1000 sites][Sites]
* You can choose the default path for all your new videos
* Load the new video in the app with just one click

![download](img/download.JPG)

### Trim

Trim :scissors: precisely the length, with a simple interface. You can do multiple trims if you need.

![trim](img/trim.JPG)

### Crop

Crop what is just important for you, just move the edges with the mouse or use the keys :arrow_up: :arrow_right: :arrow_down: :arrow_left:.
* ```Row keys``` to move
* ```Shift + Row``` keys to move faster
* ```Alt + Row Keys``` to increase/decrease the size 
* ```Ctrl + Right or Left``` to change preview
* You can use mouse wheel over time line

![crop](img/crop.JPG)

### Filter

If your video looks dark, you can try with some filters.

![filter](img/light.JPG)

### Caption

Add text, change font, size, position, also set when it start and end.

![caption](img/caption.JPG)

### Rotate

![rotate](img/rotate.JPG)

### Loop
<div style='position:relative; padding-bottom:calc(56.25% + 44px)'><iframe src='https://gfycat.com/ifr/AnimatedUnimportantAlligatorsnappingturtle' frameborder='0' scrolling='no' width='100%' height='100%' style='position:absolute;top:0;left:0;'></iframe></div>

### Merge
Drag and drop video files inside the app, search for the new video in source path. *The group of videos must have the same encodes / dimensions*.
### There is More that you can do

* Add subtitle
* Resize 
* Reverse
* Overlay your logo
* Change the speed
* Fade
* Disable audio
* Get specific filesize in final result
* Get high quality video
* Interpolate, more frames to your video
* Deinterlace

### Upload to Gfycat

Upload your new masterpiece with just one click. *A Gfycat account is required.*

## Changelog

#### Version 3.6.2
* Add time line to crop filter
* Redundancy in preview eliminated in the filter trim, can bring a small improvement in performance

#### Version 3.6.1
* Set CRF to 16 with 4k videos
* Set max audio quality as default
* Fix incorrect result message when convert with loop 

#### Version 3.6.0
* Add Loop function, forward and reverse making an infinite effect. You *can't* use filter or interpolation with it
* Add Dark Filter
* Enable ShareX option after convert
* Now sort files by the filename in merge videos
* Fix Unauthorized issue with gfycat

#### Version 3.5.2
* Fix bug that break updates, some problem to get DNS with IPS

#### Version 3.5.1
* Fix message error when you use interpolation
* Fix errors when you work offline
* Check if Microsoft Visual C++ 2010 (x86) is installed, if not, it will open the download page

#### Version 3.5.0
* Merge two or more videos in one, just drag and drop them inside the app. Search for the new merged file in source path
* *Limitations:* The group of videos must have the same encodes / dimensions

#### Version 3.4.0
* Deinterlace gets the job done efficiently. Remember to do this before editing, so the overall experience is not affected. You can use trim to save time and get what you need.


#### Version 3.3.3
* Lighten Filter is back, come and say hi

#### Version 3.3.2
* Revert new filter, it is causing collateral issues

#### Version 3.3.1
* Bring dark videos to light, try it in Advanced> Processing> Filters
* Minor changes to performance in filters

#### Version 3.3.0
* Download your video is easy now (support +1000 sites), [see more information.][Sites]

#### Version 3.2.4
* Now you can working editing other video while the file upload to gfycat

#### Version 3.2.3
* Improved performance of function to get frames on multiprocessor systems

#### Version 3.2.2
* Fixed Gfycat title

#### Version 3.2.1
* Interpolation result is better now
* Minor changes in *New update available*
* Fixed when your drop a file, that make your settings reset

#### Version 3.2.0
* Now you can set when you want your caption to start and end
* In caption form you can advance frame by frame changing *start frame* value. You can use mouse wheel too
* Changed algorithm to interpolate
* Now the update feature is enabled

#### Version 3.1.0
* Added option to interpolate frames in Advanced/Encoding
* Improved trim lag going forward with 4k videos

#### Version 3.0.0
* Fixed laggy trim functionality (with 4k files is a still a little slower)
* Now you can use Space key to play 100 frames in trim functionality
* Set the exact % value in change rate functionality 
* Now your settings are remembered 
* Gfycat integration using browser-based OAuth authentication. Upload your gfy after convert with one click

## License
This software is released under the MIT license.


## Issues
If you have any issues with this program, you may report them on [here][NewIssue].

 [LatestDownload]: https://github.com/argorar/WebMConverter/releases/latest
 [DotNet45]: https://www.microsoft.com/en-us/download/details.aspx?id=30653
 [AviSynth]: http://avisynth.nl/index.php/Main_Page#Official_builds
 [NewIssue]: https://github.com/argorar/WebMConverter/issues
 [MVC]: https://www.microsoft.com/en-us/download/details.aspx?id=8328
 [Sites]: https://ytdl-org.github.io/youtube-dl/supportedsites.html
