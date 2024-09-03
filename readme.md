# .NET 8 Application with Docker, Terraform, and CI/CD

This repository contains a sample .NET 8 application designed to demonstrate modern development and deployment practices. The application connects to an Azure SQL Database using Entity Framework, providing a complete example of a cloud-based solution. The repo includes:

- **.NET 8 Application**: A simple web application built on the latest .NET 8 framework.
- **Azure SQL Database**: The application is configured to connect to an Azure SQL Database, using Entity Framework for data access.
- **Dockerfile**: Configuration to containerize the application for consistent and portable deployment.
- **Terraform Files**: Infrastructure as code (IaC) scripts to provision and manage cloud resources required to run the application.
- **CI/CD Pipelines**: 
  - **Application Pipeline**: Automates building, testing, and deploying the .NET 8 application using GitHub Actions.
  - **Infrastructure Pipeline**: Manages the deployment and updates of the infrastructure using Terraform and GitHub Actions.


## Getting Started

1. **Clone the Repository**:  
   ```bash
   git clone https://github.com/your-username/your-repo.git
   cd your-repo

## Create the Infrastructure

You have two options for setting up the infrastructure:

### 1. Manual Setup

You can create the infrastructure manually using the Azure Portal. Follow these steps to provision the necessary resources for your application.

### 2. Automated Setup with Terraform

To automatically create the infrastructure using Terraform, follow these steps:

1. **Configure a Service Principal**:
   - Create a service principal in Azure with Contributor access to your subscription. This allows Terraform to provision resources on your behalf.

2. **Store Service Principal Credentials**:
   - Add the service principal credentials (such as `client_id`, `client_secret`, `tenant_id`, and `subscription_id`) as GitHub Secrets in your repository. This ensures that the Terraform pipeline can securely access your Azure subscription.

3. **Execute Terraform Files**:
   - Use the infrastructure pipeline to apply the Terraform configurations. This will automatically provision the required resources.

For detailed instructions on setting up a service principal and storing secrets, refer to the [Azure documentation](https://docs.microsoft.com/azure/active-directory/develop/howto-create-service-principal-portal) and the [GitHub Actions documentation](https://docs.github.com/en/actions/security-guides/encrypted-secrets).

By using the Terraform pipeline, you streamline the infrastructure setup process and ensure consistency across environments.


## Configure Azure SQL Database Connection

To connect your .NET 8 application to an Azure SQL Database, follow these steps to update the connection string in the `appsettings.json` file:

1. **Locate the `appsettings.json` File**:
   Find the `appsettings.json` file in the root directory of your project.

2. **Update the Connection String**:
   Open the `appsettings.json` file and locate the `ConnectionStrings` section. Modify the `AzApp` connection string with your Azure SQL Database details. The updated section should look like this:

   ```json
   {
     "ConnectionStrings": {
       "AzApp": "<your-connection-here>"
     }
   }

The migrations have already been set up. Simply run the application, and the changes will automatically be applied to your Azure SQL Database.

## Running the Application with Docker

To build and run the application using Docker, follow these steps:

1. **Build the Docker Image**:

   ```bash
   docker build -t your-app .

## Running the .NET Application Using .NET CLI

To run your .NET application using the .NET CLI, follow these steps:

1. **Open a Command Line Interface**:
   Use a terminal or command prompt.

2. **Navigate to the Project Directory**:
   Change to the directory where your `.csproj` file is located. For example:
   ```bash
   cd path/to/your/project

3. **Restore Command**:
   Restore all application dependencies
   ```bash
   dotnet restore

4. **Run Command**:
   Run the application
   ```bash
   dotnet build
