# SCADA 

***Project Overview:***
Designed and implemented a SCADA system for monitoring and controlling industrial processes, supporting analog and digital I/O operations. The system enables user registration, tag management (creation, modification, deletion), and real-time data visualization via a trending interface.

***Key Functionalities:***
    Implemented SCADA Core, handling client-server communication and processing real-time signals from simulated and external devices.
    Developed Database Manager for managing tags, user authentication, and persistence of system configurations.
    Integrated a real-time alarming system with configurable thresholds and priority-based logging.
    Designed a Report Manager for retrieving historical data and generating detailed alarm reports.
    Implemented system state persistence, ensuring safe shutdown and recovery from configuration files.

***Key Technologies:***
C#, WCF, XML, SQL, multithreading, and real-time data processing.

---


### Analog and digital tags with the following properties:
DI (digital input) | DO (digital output) | AI (analog input) | AO (analog output)
--- | --- | --- | --- 
| tag name (id) |  tag name (id) |  tag name (id) |  tag name (id) 
| description   |  description   |  description |  description 
| I/O address   |  I/O address   |  I/O address |  I/O address 
| driver        |  initial value |  driver      |  initial value 
| on/off scan   |                |  scan time   |  low limit
| scan time     |                |  alarms      |  high limit
|               |                |  on/off scan |  units 
|               |                |  low limit   |   
|               |                |  high limit  |   
|               |                |  units       |  

# System Architecture

![image](https://github.com/user-attachments/assets/238eac9d-5d9d-479a-996f-557b3ebcd611)




