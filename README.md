PowerPlanSwitch
===============

A Windows service to switch the power plans depending on the machine power connectivity.

A big thanks to https://github.com/andy722/power-plan-switcher for providing the foundation for my service.

Finally a windows service to automatically switch power plans when you connect / disconnect the power to your windows laptop and also when you are low on power.

No more clicking through the power options to switch power plans.

This is a visual studio 2013 project using .net framework 4.

Installation steps:

Compile the project in release configuration.

Start visual studio command prompt.

in the bin\release folder run 
         
         installutil PowerPlanSwitch.exe

This will bring up a user credentials dialog where you can use your credentials to install the service.

The service will run under the credentials used during the install process.

Next steps:

Allow custom power plans.

Bundle up binaries with installutil and instructions.

