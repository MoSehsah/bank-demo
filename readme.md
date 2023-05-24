# Tanzu Banking Demo App

![Alt text](images/banking-demo-arch-claims.png?raw=true "Architecture")

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
  - User service can provision PostgreSQL instance automatically and store it's data on PostgreSQL
  - Quote service can provision Redis instance automatically and store it's data on Redis
  - Integration with Open Telemetry allowing us to change observability tool easily, like Jaeger to Tanzu Observability
  - Integration with Tanzu Observability for distributed tracing
  - API endpoints generated automatically with Supply Chain and available at TAP-GUI
  - AirGapped (Internet-less) mode for POCs. That mode does not need connection to IEX-Trading-Cloud.


## Deploy to Tanzu Application Platform (TAP)

Deploy App Accelerator:
```
kubectl apply -f accelerator-deploy.yaml -n accelerator-system
```

Create or explore the file through TAP GUI and deploy whichever microservice with workload.yaml

If you have chosen OpenTelemetry you need to setup the otel operator like below.

```bash
kubectl apply -f yaml/open-telemetry/open-telemetry/01-opentelemetry-operator.yaml

```
Then, depending on the observability tool chosen, use option-1 or option-2.

#### OpenTelemetry Option 1 - Tanzu Observability 

```bash
kubectl apply -f yaml/open-telemetry/wavefront/01-wavefront-operator.yaml
kubectl apply -f yaml/open-telemetry/wavefront/02-wavefront-secret.yaml
kubectl apply -f yaml/open-telemetry/wavefront/03-wf-proxy.yaml
kubectl apply -f yaml/open-telemetry/open-telemetry/02-opentelemetry-instrumentation.yaml
```

#### OpenTelemetry Option 2 - Jaeger

```bash
kubectl apply -f yaml/open-telemetry/jaeger/01-jaeger-deploy.yaml
kubectl apply -f yaml/open-telemetry/open-telemetry/02-opentelemetry-instrumentation.yaml
```

After setting up the OpenTelemetry;

To set up whole environment, run the accelerator and run following workload.yaml files in consequent order.
```
kubectl apply -f config-server/config/workload.yaml
kubectl apply -f discovery-server/config/workload.yaml
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

![Alt text](images/jaeger-distributed.png?raw=true "Jaeger Distributed Tracing")

![Alt text](images/to-distributed.png?raw=true "Tanzu Observability Distributed Tracing")