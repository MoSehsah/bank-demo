# Tanzu Banking Demo App

![Alt text](images/banking-demo-architecture.png?raw=true "Architecture")

This repo provides an example Spring microservice architecture and can be deployed via Tanzu Application Platform.

- Fully functional trading app with:
  - User service creates user profiles
  - Account service creates accounts for users
  - Portfolio service holds trade information
  - Quote service fetches value of given trade symbol.
- Utilizes several Spring ecosystem core components:
  - Config Server fetches application config from Git
  - Discovery Server (Eureka) allows each application to be register and fetch services.
- Other capabilities
  - Quote service is inter changeable between Quote service developed with Spring or .Net-Core.
  - Porfolio service can store it's data on PostgreSQL
  - Integration with Tanzu Observability for distributed tracing
  - API endpoints available at TAP-GUI
  - User service can store it's data on Redis (In Progress)


## Deploy to Tanzu Application Platform (TAP)

Deploy App Accelerator:
```
kubectl apply -f tap-accelerator-deploy.yaml -n accelerator-system
```

Create or explore the file through TAP GUI and deploy whichever microservice with workload.yaml

To set up whole environment, run the accelerator and run following workload.yaml files in consequent order.
```
kubectl apply -f config-server/config/workload.yaml
kubectl apply -f discover-server/config/workload.yaml
kubectl apply -f account-service/config/workload.yaml
kubectl apply -f user-service/config/workload.yaml
kubectl apply -f quote-service/config/workload.yaml
kubectl apply -f portfolio-service/config/workload.yaml
kubectl apply -f web-ui/config/workload.yaml
```


## Develop Apps and Deploy to TAP (Developer Persona)

Create file through TAP GUI and deploy whichever microservice with workload.yaml

First deploy spring components.
```
kubectl apply -f config-server/config/workload.yaml
kubectl apply -f discover-server/config/workload.yaml
```

Then, go to chosen app's dir and run tilt.

```
tilt up
```

After you complete the development, do ```git push```  .

## Screenshots

![Alt text](images/accounts.png?raw=true "Accounts")

![Alt text](images/portfolio.png?raw=true "Portfolio")

![Alt text](images/trade.png?raw=true "Trade")

![Alt text](images/dependency-diagram.png?raw=true "TAP Dependency Diagram")

