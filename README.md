# Cruise Reservation Web App
## Overall Project Summary
ASP.NET application that provides on-line cruise reservations for a cruise line. The application consists of web forms and provides navigation between them through the use of buttons and links.
When the application first opens, the traveller will be presented with a login screen. The traveller will provide his/her Oracle login information. The application will validate the credentials by logging into Oracle. After logging in, the traveller is presented with a screen that allows them to select the type of operation they want to perform: (1) View existing cruise reservations, (2) Reserve a cruise, (3) Manage the cruise destinations, or (4) Logout.
### Cruise Reservations Page
The cruise reservations page contains a list of cruises that are currently reserved for the traveller. Any of these reservations can be cancelled by clicking the corresponding Cancel Reservation button.
### Reservation Page
The reservation page allows the traveller to make a new reservation by specifying the cruise ship and the desired cabin number to be reserved. Attempts to reserve a cabin that has previously been reserved will display an appropriate error message.
### Cruise Destination Management Page
The cruise destination management page contains the current list of destinations for each cruise ship. Any of these destinations can be removed from the cruise by clicking the corresponding Remove Destination button. The administrator can also add new destinations to a cruise from a list of available destinations.
