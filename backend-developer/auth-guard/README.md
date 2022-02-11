![RoofStacks Logo](../../roofstacks-logo.png)

# Auth Guard

## Table of Contents
- [Summary](#summary)
- [Details](#details)
- [Solution](#solution)

## Summary
Imagine that you have an employee service. This service persists some employee data like name, gender, age, etc. We want to defend this service with another authentication guard service. All requests must be transmitted on auth guard before arriving at the employee service.

## Details
- Employee service and auth guard have to be separated.  You can define different APIs on employee service like create employee, toggle employee activity.
- Auth guard must support OAuth/OpenID protocol. It can create a token to call employee service APIs securely. All auth flow must be run at the top of tokenized requests.
- There should be a pre-defined client on auth guard.
- The token should be created by ClientID and Client Secret as Client Credentials flow.
- When the client can create a token successfully by auth guard, it could be used to request employee APIs.
- All happy/negative paths (warnings, errors) should be considered as well.

## Solution
Design a system that contains all rules in the details and please make a readme file to explain your solution. You could also draw diagrams and flow charts. You could use any software language, platform, tool, library, or framework. Please push your solution to GitHub and share the related URL with us.
