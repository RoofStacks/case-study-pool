![RoofStacks Logo](../../roofstacks-logo.png)

# Report Visualizer

## Table of Contents
- [Summary](#summary)
- [Details](#details)
- [Solution](#solution)

## Summary
We want to build a system between firebase, GCP big query, and data studio. Imagine that you've some data on firebase. You could integrate it with the GCP big query. And create some sets to visualize them in the data studio. And your last mission is that integrates a data studio report with a basic web app to show your report on the app.

## Details
- You should create a firebase project that puts 2 firestore collections into it.
- Collections : 
Users => [username (string), email(string), createdAt(timestamp), modifiedAt(timestamp)]
Items => [userId/userRef (string), itemName(string), createdAt(timestamp), modifiedAt(timestamp)]
- Your users have items that contain some basic fields. You could build your collection index, collection groups, etc. in your way.
- Then you should create a big query project and integrate the firebase to sync data.
- And you should use your bigQuery things in any data studio template.
- Last mission is to show the data/query on a web app.
- You can build your own queries, APIs to show data in the web app, you are free in all.

## Solution
Design a system that contains all rules in the details and please make a readme file to explain your solution. You could also draw diagrams and flow charts. You could use any software language, platform, tool, library, or framework except those specified as required in the details section. Please push your solution to GitHub and share the related URL with us.