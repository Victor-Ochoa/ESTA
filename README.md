# Event Sourcing System with Marten, Aspire and Hangfire

This project is a study of Event Sourcing using Marten and Aspire. It demonstrates how to implement an Event Sourcing system in .NET 9.

## Overview

Event Sourcing is a pattern where state changes are logged as a sequence of events. This project uses Marten for event storage and Aspire for managing the system infrastructure.

## Technologies Used

- **.NET 9**
- **Marten**: A library for .NET that provides event sourcing and document database capabilities.
- **Aspire**: A tool for managing system infrastructure.
- **Hangfire**: A tool for background jobs.

## Project Structure

### Applications
- **ESTA.Admin**: Admin API project.
- **ESTA.OrderApi**: The main API project.
- **ESTA.AppHost**: Application host project.

### Domains
- **ESTA.Domain.Order**: Contains domain models for orders.
- **ESTA.Domain.Shared**: Contains shared domain models and interfaces.
- **ESTA.Domain.Admin**: Contains domain models for admin functionalities.

### Others
- **ESTA.Shared.EventData**: Contains event data handling and repository implementations for events.
- **ESTA.Shared.Data**: Contains shared data handling functionalities.
- **ESTA.Shared.Service.Order**: Contains service for orders.
- **ESTA.ServiceDefaults**: Contains default service configurations.


## Conclusion

This project serves as a practical example of implementing Event Sourcing in .NET using Marten, Aspire and Hangfire. It showcases the benefits of event sourcing and provides a solid foundation for further development.

Feel free to explore the code and reach out if you have any questions or suggestions.

---

Thank you for considering my project. I hope it demonstrates my skills and understanding of Event Sourcing and .NET development.