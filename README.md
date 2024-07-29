# ASP.NET Portfolio Project

## Overview

This project is a portfolio website built using ASP.NET with a 3-layered architecture and Data Transfer Objects (DTOs). The portfolio includes sections for skills, experience, and projects, all of which can be managed through a control panel. Authentication logic is implemented to secure the control panel.

## Features

- **3-Layered Architecture**: The project is organized into Presentation, Business, and Data layers to promote separation of concerns and maintainability.
- **Data Transfer Objects (DTOs)**: Used to transfer data between layers.
- **Control Panel**: Allows for easy management of the portfolio content, including skills, experience, and projects.
- **Authentication**: Ensures that only authorized users can access the control panel.

## Project Structure

- **Presentation Layer**: Contains the views and controllers for the portfolio website.
- **Business Layer**: Contains the business logic and services.
- **Data Layer**: Contains the data access logic and repository classes.

## Technologies Used

- ASP.NET Core
- Entity Framework Core
- AutoMapper (for DTO mapping)
- Identity for authentication
- SQL Server (or any preferred relational database)

## Usage

### Control Panel

- **Skills Management**: Add, update, or delete skills.
- **Experience Management**: Add, update, or delete work experiences.
- **Project Management**: Add, update, or delete projects.

### Authentication

- Register an admin user via the registration page or seed an admin user in the database.
- Login to access the control panel.
