#!/bin/bash

# update below values.
export harborURL="harbor.tap.corp.com/tap-15"
export IMGPKG_REGISTRY_HOSTNAME="harbor-url"
export IMGPKG_REGISTRY_USERNAME="user"
export IMGPKG_REGISTRY_PASSWORD="pass"
export REGISTRY_CA_PATH="./ca.crt"
# do not edit below.
#---
export configserver="projects.registry.vmware.com/tanzu_meta_pocs/banking-demo/configserver:latest"
export jaeger="projects.registry.vmware.com/tanzu_meta_pocs/banking-demo/jaegertracing/all-in-one:1.42.0"
export otel="projects.registry.vmware.com/tanzu_meta_pocs/banking-demo/opentelemetry-operator:0.74.0"
export rbac="projects.registry.vmware.com/tanzu_meta_pocs/banking-demo/kube-rbac-proxy:v0.13.0"
export wfoperator="projects.registry.vmware.com/tanzu_observability/kubernetes-operator:2.2.0"

mkdir -p airgapped-files/images

imgpkg copy -i $configserver --to-tar=airgapped-files/images/configserver.tar
imgpkg copy -i $jaeger --to-tar=airgapped-files/images/jaeger.tar
imgpkg copy -i $otel --to-tar=airgapped-files/images/otel.tar
imgpkg copy -i $rbac --to-tar=airgapped-files/images/rbac.tar
imgpkg copy -i $wfoperator --to-tar=airgapped-files/images/wfoperator.tar

imgpkg copy \
  --tar airgapped-files/images/configserver.tar \
  --to-repo $harborURL/configserver \
  --include-non-distributable-layers \
  --registry-ca-cert-path $REGISTRY_CA_PATH

imgpkg copy \
  --tar airgapped-files/images/jaeger.tar \
  --to-repo $harborURL/jaeger \
  --include-non-distributable-layers \
  --registry-ca-cert-path $REGISTRY_CA_PATH

imgpkg copy \
  --tar airgapped-files/images/otel.tar \
  --to-repo $harborURL/otel \
  --include-non-distributable-layers \
  --registry-ca-cert-path $REGISTRY_CA_PATH

imgpkg copy \
  --tar airgapped-files/images/rbac.tar \
  --to-repo $harborURL/kube-rbac-proxy \
  --include-non-distributable-layers \
  --registry-ca-cert-path $REGISTRY_CA_PATH

imgpkg copy \
  --tar airgapped-files/images/wfoperator.tar \
  --to-repo $harborURL/wfoperator \
  --include-non-distributable-layers \
  --registry-ca-cert-path $REGISTRY_CA_PATH