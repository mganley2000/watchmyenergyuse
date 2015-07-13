Imported from google code. A Windows .NET application that acquires, stores, and presents power and energy consumption data for individual devices in your home.

This is a C# project. It will build using Visual Studio 2008 with .NET Framework 3.5. It uses a port of Python code, xbee.py XbeePy, to extract the Zigbee data. It uses ZedGraph for near real-time and historical charts, and a Scheduler for scheduling the sampling of the power data for live charting. The database used is SQLite.

You must build one or more power monitoring devices that you plug-in to your wall outlets. This page illustrates exactly what to do: https://learn.adafruit.com/tweet-a-watt/

Summarized, build the receiver: http://www.ladyada.net/make/tweetawatt/receiver.html

Update the firmware and configure all the Zigbee transmitter chips: http://www.ladyada.net/make/tweetawatt/config.html

Modify the "Kill A Watt" hardware and install the transmitter chip in each: http://www.ladyada.net/make/tweetawatt/solder.html

Finally, monitor and chart power usage of these devices with this .NET desktop application. You can try the code available here. Perhaps you can improve and expand this code.

In progress is the hardware for a whole-house monitor to add as a metering device to this project.

Also feeding data to the Google App Engine to chart usage on a widget page. A lot like Google Power Meter. Also an install-as-service mode.
