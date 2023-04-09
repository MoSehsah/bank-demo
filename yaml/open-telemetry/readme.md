# Open Telemetry Setup Guide

We can do distributed tracing with the Banking Demo App without any code change, thanks to `Tanzu Application Platform`

## To Deploy OpenTelemetry (Mandatory)

```bash
kubectl apply -f open-telemetry/01-opentelemetry-operator.yaml

```

## Option 1 - Tanzu Observability 

```bash
kubectl apply -f wavefront/01-wavefront-operator.yaml
kubectl apply -f wavefront/02-wavefront-secret.yaml
kubectl apply -f wavefront/03-wf-proxy.yaml
kubectl apply -f open-telemetry/02-opentelemetry-instrumentation.yaml
```

## Option 2 - Jaeger

```bash
kubectl apply -f jaeger/01-jaeger-deploy.yaml
kubectl apply -f open-telemetry/02-opentelemetry-instrumentation.yaml
```