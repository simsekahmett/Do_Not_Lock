This is a simple WinForms project that aims to keep the computer from being locked, keep teams status online always, and provide functionality to be running on Windows startup.

When the app is activated, it sends a numpad event in the background twice every 5 minutes to keep the computer from being locked due to inactivity. This is done by simulating user activity, as most operating systems are designed to keep the computer from locking when there is user activity.

By sending a numpad event, the app is essentially telling the operating system that there is user activity happening, even though it is being done in the background. This ensures that the computer does not get locked due to inactivity, which is especially useful for situations where you need to keep the computer running for extended periods without interacting with it.

The reason why the app sends the numpad event twice every 5 minutes is to ensure that the previous state is maintained. This is because some operating systems may require more frequent user activity to prevent the computer from locking, and sending the event twice every 5 minutes helps ensure that the computer stays active and does not lock due to inactivity.

## Screenshots
When app is inactive;

![](/WindowsFormsApplication1/screenshots/active.jpg)

When app is active;

![](/WindowsFormsApplication1/screenshots/not_active.jpg)

When app is minimized;

![](/WindowsFormsApplication1/screenshots/dontlock.gif)

## Installation
Clone the repository or download the zip file.
Open the solution in Visual Studio.
Build the solution to generate the executable file.
Run the executable file to start the application.

## Features
Prevent computer from being locked: This application prevents the computer from being locked due to inactivity. It does this by simulating user activity at regular intervals.

Keep Teams status online: The application keeps Microsoft Teams status online always. It does this by sending a request to Teams server at regular intervals.

Run on Windows start: The application provides the functionality to be running on Windows start. This means that the application will start automatically when you log in to your Windows account.

Save "Start on Windows" function: Once the application is running, it will save the "Start on Windows" function. This means that even if you close the application, it will start automatically when you log in to your Windows account.

Hide when minimized: When you minimize the application, it will hide itself and show in the taskbar's hidden icons section. This keeps your taskbar clean and clutter-free.

Notification when minimized: When the application is minimized, it will display a notification icon with the activate status of the app. This is to indicate that the application is still running in the background.

## Usage
Run the executable file to start the application.
The application will run in the background, preventing the computer from being locked and keeping the Teams status online.
You can minimize the application, and it will hide itself in the taskbar's hidden icons section.
To close the application, right-click on the notification icon and select "Exit."
Contributing
Contributions are welcome. If you find a bug or have a feature request, please submit an issue or create a pull request.

## License
This project is licensed under the MIT License - see the LICENSE.md file for details.
