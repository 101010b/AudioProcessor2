# AudioProcessor2
AudioProcessor V2

This software is a interactive tool to interact with all your computers sound inputs and outputs. It allows live recoding and playback and a whole bunch of processing tools in between. It can also be used as a learning/educational tool to directly show/demonstrate the effects of filters/ring modulators in a very intuitive way.

Some of the features are:
* Recording from any Windows Sound device including ASIO and WASAPI (for loopback of currently playing sounds)
* Playback on any Windows Sound device including ASIO
* low latency usin ASIO devices
* Virtual Oscilloscope with trigger features
* Spectrum analysis (with flexible block sizes and window functions)
* Waterfall Spectrum Analyzer
* Configurable filters
* Virtual Network Analyzer to analyze external sound transmission or other circuits
* Signal Display and Calibration
* WaveFile Reader and Writer
* MIDI Input
* Special elements to add some synthesizer features
* With sound devices that can record at samplerates up to 192 kHz it can also be used to downconvert ultrasonic signals to the hearable range

## Installation
Clone this repostitory onto your system.
Compile using Visual Studio 2017++

## Dependencies
The Tool depends on some other systems which are included either as submodules or need NuGet to install them.
* NAudio - See https://github.com/naudio/NAudio for more details
* FFTWSharp - See https://github.com/tszalay/FFTWSharp for more details. This lib is embedded in the code as git submodule in the externals/FFTWSharp directory. 

## License
GPLv3 - see license.txt for more details