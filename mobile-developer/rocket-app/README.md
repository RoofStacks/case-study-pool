![RoofStacks Logo](../../roofstacks-logo.png)

# Rocket App

## Table of Contents
  - [Summary](#summary)
  - [Details](#details)
  - [Solution](#solution)
  
## Summary
Imagine that you have mobile rocket app. It contains rocket listing and detail pages.


## Details
- A simple mobile application will be developed using [SpaceX API](https://github.com/r-spacex/SpaceX-API).
- We expect you to come up with a two tab and four screen application. We have listed some of the UI requirements below.
- First Tab Screen
  - Rocket List
    - You will list all the available all SpaceX Rockets.
    - You should add favorite button and you will keep up in local database.
    - User must add or remove favorite rocket.
    - Each item must have a thumbnail of the rocket, rocket name and rocket descritpton (if rocket has image or has description).
    - Clicking an item will launch the rocket detail screen.
  - Rocket Detail
    - This screen will show all the details about a particular movie item.
    - There should be a rocket image, title description, summary etc.
    - There must be favorite button.
    - Show the clickable favorite button with its previous state (user selected the rocket as favorite or not).
    - Show rocket images in a slidable gallery.
- Second tab screen
  - List favorite rockets of the user.
  - Each item must have unfavorite button (If user click unfavorite button UI must be reload).
  - Clicking an item will launch the rocket detail screen.
- The developed application will be evaluated independently of the design.
- For IOS:
  - MVVM or VIP (Clean Swift) application architecture.
  - Protocol-oriented programming.
  - The Codable protocol.
  - You can use Alamofire, Moya, URLSession or native networking in Swift (Moya preferred).
  - Storyboard or XIB.
  - Xcode 13.2 and Swift 5 or higher.
- For Android:
  - It should be developed using kotlin.
  - MVP or MVVM application architecture (MVVM is our preference).
  

## Solution
Design a system that contains all rules in the details and please make a readme file to explain your solution. You could also draw diagrams and flow charts. You could use any software language, platform, tool, library, or framework except those specified as required in the details section. Please push your solution to GitHub and share the related URL with us.