# WebXplorer

* C# WPF application 'web browser' built on internet explorer's rendering engine. This was mainly created as just a fun project to mess around and learn more of the capabilities of WPF. 

* As 99% of you know on this site this isn't at all what you would call a proper web browser, it's just creating essentially a mini IE11 window inside of your application and controlling it programatically. When you invoke the WebBrowser object you are using SHDOCVW.dll which is the same HTML rendering engine used by IE.

* Will work on porting the whole thing to Chromium using Cefsharp at some point, at the moment a lot of things don't work on IE's rendering engine that would work on Chromium; things like some JavaScript, CSS3 and HTML5 audio/video elements.
