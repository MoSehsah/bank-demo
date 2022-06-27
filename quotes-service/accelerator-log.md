# Accelerator Log

## Options
```json
{
  "deploymentType" : "workload",
  "projectName" : "quotes-service",
  "sourceRepositoryPrefix" : "dev.local"
}
```
## Log
```
┏ engine (Chain)
┃  Info Running Chain(Combo, UniquePath)
┃ ┏ engine.transformations[0] (Combo)
┃ ┃  Info Combo running as Chain(Merge(merge), UniquePath(UseLast))
┃ ┃ engine.transformations[0].merge (Chain)
┃ ┃  Info Running Chain(Merge, UniquePath)
┃ ┃ ┏ engine.transformations[0].merge.transformations[0] (Merge)
┃ ┃ ┃  Info Running Merge(Combo, Combo, Combo, Combo, Combo, Combo, Combo, Combo)
┃ ┃ ┃ ┏ engine.transformations[0].merge.transformations[0].sources[0] (Combo)
┃ ┃ ┃ ┃  Info Combo running as Chain(Include, Exclude)
┃ ┃ ┃ ┃ engine.transformations[0].merge.transformations[0].sources[0].<combo> (Chain)
┃ ┃ ┃ ┃  Info Running Chain(Include, Exclude)
┃ ┃ ┃ ┃ ┏ engine.transformations[0].merge.transformations[0].sources[0].<combo>.transformations[0] (Include)
┃ ┃ ┃ ┃ ┃  Info Will include [**]
┃ ┃ ┃ ┃ ┃ Debug .github/workflows/code-scan.yml matched [**] -> included
┃ ┃ ┃ ┃ ┃ Debug .github/workflows/codeql-analysis.yml matched [**] -> included
┃ ┃ ┃ ┃ ┃ Debug .gitignore matched [**] -> included
┃ ┃ ┃ ┃ ┃ Debug .mvn/wrapper/MavenWrapperDownloader.java matched [**] -> included
┃ ┃ ┃ ┃ ┃ Debug .mvn/wrapper/maven-wrapper.jar matched [**] -> included
┃ ┃ ┃ ┃ ┃ Debug .mvn/wrapper/maven-wrapper.properties matched [**] -> included
┃ ┃ ┃ ┃ ┃ Debug LICENSE matched [**] -> included
┃ ┃ ┃ ┃ ┃ Debug README.md matched [**] -> included
┃ ┃ ┃ ┃ ┃ Debug catalog/catalog-info.yaml matched [**] -> included
┃ ┃ ┃ ┃ ┃ Debug grype.yaml matched [**] -> included
┃ ┃ ┃ ┃ ┃ Debug kubernetes/k8s/DEPLOYING.md matched [**] -> included
┃ ┃ ┃ ┃ ┃ Debug kubernetes/k8s/Tiltfile matched [**] -> included
┃ ┃ ┃ ┃ ┃ Debug kubernetes/k8s/deployment.yaml matched [**] -> included
┃ ┃ ┃ ┃ ┃ Debug kubernetes/k8s/service.yaml matched [**] -> included
┃ ┃ ┃ ┃ ┃ Debug kubernetes/tap/DEPLOYING.md matched [**] -> included
┃ ┃ ┃ ┃ ┃ Debug kubernetes/tap/Tiltfile matched [**] -> included
┃ ┃ ┃ ┃ ┃ Debug kubernetes/tap/workload.yaml matched [**] -> included
┃ ┃ ┃ ┃ ┃ Debug mvnw matched [**] -> included
┃ ┃ ┃ ┃ ┃ Debug mvnw.cmd matched [**] -> included
┃ ┃ ┃ ┃ ┃ Debug pom.xml matched [**] -> included
┃ ┃ ┃ ┃ ┃ Debug src/main/java/com/example/helloapp/HelloAppApplication.java matched [**] -> included
┃ ┃ ┃ ┃ ┃ Debug src/main/resources/application.properties matched [**] -> included
┃ ┃ ┃ ┃ ┗ Debug src/test/java/com/example/helloapp/HelloAppApplicationTests.java matched [**] -> included
┃ ┃ ┃ ┃ ┏ engine.transformations[0].merge.transformations[0].sources[0].<combo>.transformations[1] (Exclude)
┃ ┃ ┃ ┃ ┃  Info Will exclude [pom.xml, README.md, grype.yaml, kubernetes/**, catalog/*.yaml, .github/workflows/**]
┃ ┃ ┃ ┃ ┃ Debug .github/workflows/code-scan.yml matched [pom.xml, README.md, grype.yaml, kubernetes/**, catalog/*.yaml, .github/workflows/**] -> excluded
┃ ┃ ┃ ┃ ┃ Debug .github/workflows/codeql-analysis.yml matched [pom.xml, README.md, grype.yaml, kubernetes/**, catalog/*.yaml, .github/workflows/**] -> excluded
┃ ┃ ┃ ┃ ┃ Debug .gitignore didn't match [pom.xml, README.md, grype.yaml, kubernetes/**, catalog/*.yaml, .github/workflows/**] -> included
┃ ┃ ┃ ┃ ┃ Debug .mvn/wrapper/MavenWrapperDownloader.java didn't match [pom.xml, README.md, grype.yaml, kubernetes/**, catalog/*.yaml, .github/workflows/**] -> included
┃ ┃ ┃ ┃ ┃ Debug .mvn/wrapper/maven-wrapper.jar didn't match [pom.xml, README.md, grype.yaml, kubernetes/**, catalog/*.yaml, .github/workflows/**] -> included
┃ ┃ ┃ ┃ ┃ Debug .mvn/wrapper/maven-wrapper.properties didn't match [pom.xml, README.md, grype.yaml, kubernetes/**, catalog/*.yaml, .github/workflows/**] -> included
┃ ┃ ┃ ┃ ┃ Debug LICENSE didn't match [pom.xml, README.md, grype.yaml, kubernetes/**, catalog/*.yaml, .github/workflows/**] -> included
┃ ┃ ┃ ┃ ┃ Debug README.md matched [pom.xml, README.md, grype.yaml, kubernetes/**, catalog/*.yaml, .github/workflows/**] -> excluded
┃ ┃ ┃ ┃ ┃ Debug catalog/catalog-info.yaml matched [pom.xml, README.md, grype.yaml, kubernetes/**, catalog/*.yaml, .github/workflows/**] -> excluded
┃ ┃ ┃ ┃ ┃ Debug grype.yaml matched [pom.xml, README.md, grype.yaml, kubernetes/**, catalog/*.yaml, .github/workflows/**] -> excluded
┃ ┃ ┃ ┃ ┃ Debug kubernetes/k8s/DEPLOYING.md matched [pom.xml, README.md, grype.yaml, kubernetes/**, catalog/*.yaml, .github/workflows/**] -> excluded
┃ ┃ ┃ ┃ ┃ Debug kubernetes/k8s/Tiltfile matched [pom.xml, README.md, grype.yaml, kubernetes/**, catalog/*.yaml, .github/workflows/**] -> excluded
┃ ┃ ┃ ┃ ┃ Debug kubernetes/k8s/deployment.yaml matched [pom.xml, README.md, grype.yaml, kubernetes/**, catalog/*.yaml, .github/workflows/**] -> excluded
┃ ┃ ┃ ┃ ┃ Debug kubernetes/k8s/service.yaml matched [pom.xml, README.md, grype.yaml, kubernetes/**, catalog/*.yaml, .github/workflows/**] -> excluded
┃ ┃ ┃ ┃ ┃ Debug kubernetes/tap/DEPLOYING.md matched [pom.xml, README.md, grype.yaml, kubernetes/**, catalog/*.yaml, .github/workflows/**] -> excluded
┃ ┃ ┃ ┃ ┃ Debug kubernetes/tap/Tiltfile matched [pom.xml, README.md, grype.yaml, kubernetes/**, catalog/*.yaml, .github/workflows/**] -> excluded
┃ ┃ ┃ ┃ ┃ Debug kubernetes/tap/workload.yaml matched [pom.xml, README.md, grype.yaml, kubernetes/**, catalog/*.yaml, .github/workflows/**] -> excluded
┃ ┃ ┃ ┃ ┃ Debug mvnw didn't match [pom.xml, README.md, grype.yaml, kubernetes/**, catalog/*.yaml, .github/workflows/**] -> included
┃ ┃ ┃ ┃ ┃ Debug mvnw.cmd didn't match [pom.xml, README.md, grype.yaml, kubernetes/**, catalog/*.yaml, .github/workflows/**] -> included
┃ ┃ ┃ ┃ ┃ Debug pom.xml matched [pom.xml, README.md, grype.yaml, kubernetes/**, catalog/*.yaml, .github/workflows/**] -> excluded
┃ ┃ ┃ ┃ ┃ Debug src/main/java/com/example/helloapp/HelloAppApplication.java didn't match [pom.xml, README.md, grype.yaml, kubernetes/**, catalog/*.yaml, .github/workflows/**] -> included
┃ ┃ ┃ ┃ ┃ Debug src/main/resources/application.properties didn't match [pom.xml, README.md, grype.yaml, kubernetes/**, catalog/*.yaml, .github/workflows/**] -> included
┃ ┃ ┃ ┗ ┗ Debug src/test/java/com/example/helloapp/HelloAppApplicationTests.java didn't match [pom.xml, README.md, grype.yaml, kubernetes/**, catalog/*.yaml, .github/workflows/**] -> included
┃ ┃ ┃ ┏ engine.transformations[0].merge.transformations[0].sources[1] (Combo)
┃ ┃ ┃ ┃  Info Combo running as Chain(Include, Chain(chain))
┃ ┃ ┃ ┃ engine.transformations[0].merge.transformations[0].sources[1].<combo> (Chain)
┃ ┃ ┃ ┃  Info Running Chain(Include, Chain)
┃ ┃ ┃ ┃ ┏ engine.transformations[0].merge.transformations[0].sources[1].<combo>.transformations[0] (Include)
┃ ┃ ┃ ┃ ┃  Info Will include [pom.xml]
┃ ┃ ┃ ┃ ┃ Debug .github/workflows/code-scan.yml didn't match [pom.xml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug .github/workflows/codeql-analysis.yml didn't match [pom.xml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug .gitignore didn't match [pom.xml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug .mvn/wrapper/MavenWrapperDownloader.java didn't match [pom.xml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug .mvn/wrapper/maven-wrapper.jar didn't match [pom.xml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug .mvn/wrapper/maven-wrapper.properties didn't match [pom.xml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug LICENSE didn't match [pom.xml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug README.md didn't match [pom.xml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug catalog/catalog-info.yaml didn't match [pom.xml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug grype.yaml didn't match [pom.xml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug kubernetes/k8s/DEPLOYING.md didn't match [pom.xml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug kubernetes/k8s/Tiltfile didn't match [pom.xml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug kubernetes/k8s/deployment.yaml didn't match [pom.xml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug kubernetes/k8s/service.yaml didn't match [pom.xml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug kubernetes/tap/DEPLOYING.md didn't match [pom.xml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug kubernetes/tap/Tiltfile didn't match [pom.xml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug kubernetes/tap/workload.yaml didn't match [pom.xml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug mvnw didn't match [pom.xml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug mvnw.cmd didn't match [pom.xml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug pom.xml matched [pom.xml] -> included
┃ ┃ ┃ ┃ ┃ Debug src/main/java/com/example/helloapp/HelloAppApplication.java didn't match [pom.xml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug src/main/resources/application.properties didn't match [pom.xml] -> excluded
┃ ┃ ┃ ┃ ┗ Debug src/test/java/com/example/helloapp/HelloAppApplicationTests.java didn't match [pom.xml] -> excluded
┃ ┃ ┃ ┃ ┏ engine.transformations[0].merge.transformations[0].sources[1].<combo>.transformations[1] (Chain)
┃ ┃ ┃ ┃ ┃  Info Running Chain(ReplaceText)
┃ ┃ ┃ ┃ ┃ ┏ engine.transformations[0].merge.transformations[0].sources[1].<combo>.transformations[1].transformations[0] (ReplaceText)
┃ ┃ ┃ ┗ ┗ ┗  Info Will replace [hello-fun->quotes-service]
┃ ┃ ┃ ┏ engine.transformations[0].merge.transformations[0].sources[2] (Combo)
┃ ┃ ┃ ┃  Info Condition (#deploymentType == 'k8s-simple') evaluated to false
┃ ┃ ┃ ┗ null ()
┃ ┃ ┃ ┏ engine.transformations[0].merge.transformations[0].sources[3] (Combo)
┃ ┃ ┃ ┃  Info Condition (#deploymentType == 'k8s-simple') evaluated to false
┃ ┃ ┃ ┗ null ()
┃ ┃ ┃ ┏ engine.transformations[0].merge.transformations[0].sources[4] (Combo)
┃ ┃ ┃ ┃  Info Condition (#deploymentType == 'workload') evaluated to true
┃ ┃ ┃ ┃  Info Combo running as Chain(Include, Chain(chain))
┃ ┃ ┃ ┃ engine.transformations[0].merge.transformations[0].sources[4].<combo> (Chain)
┃ ┃ ┃ ┃  Info Condition (#deploymentType == 'workload') evaluated to true
┃ ┃ ┃ ┃  Info Running Chain(Include, Chain)
┃ ┃ ┃ ┃ ┏ engine.transformations[0].merge.transformations[0].sources[4].<combo>.transformations[0] (Include)
┃ ┃ ┃ ┃ ┃  Info Will include [kubernetes/tap/workload.yaml]
┃ ┃ ┃ ┃ ┃ Debug .github/workflows/code-scan.yml didn't match [kubernetes/tap/workload.yaml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug .github/workflows/codeql-analysis.yml didn't match [kubernetes/tap/workload.yaml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug .gitignore didn't match [kubernetes/tap/workload.yaml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug .mvn/wrapper/MavenWrapperDownloader.java didn't match [kubernetes/tap/workload.yaml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug .mvn/wrapper/maven-wrapper.jar didn't match [kubernetes/tap/workload.yaml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug .mvn/wrapper/maven-wrapper.properties didn't match [kubernetes/tap/workload.yaml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug LICENSE didn't match [kubernetes/tap/workload.yaml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug README.md didn't match [kubernetes/tap/workload.yaml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug catalog/catalog-info.yaml didn't match [kubernetes/tap/workload.yaml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug grype.yaml didn't match [kubernetes/tap/workload.yaml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug kubernetes/k8s/DEPLOYING.md didn't match [kubernetes/tap/workload.yaml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug kubernetes/k8s/Tiltfile didn't match [kubernetes/tap/workload.yaml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug kubernetes/k8s/deployment.yaml didn't match [kubernetes/tap/workload.yaml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug kubernetes/k8s/service.yaml didn't match [kubernetes/tap/workload.yaml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug kubernetes/tap/DEPLOYING.md didn't match [kubernetes/tap/workload.yaml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug kubernetes/tap/Tiltfile didn't match [kubernetes/tap/workload.yaml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug kubernetes/tap/workload.yaml matched [kubernetes/tap/workload.yaml] -> included
┃ ┃ ┃ ┃ ┃ Debug mvnw didn't match [kubernetes/tap/workload.yaml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug mvnw.cmd didn't match [kubernetes/tap/workload.yaml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug pom.xml didn't match [kubernetes/tap/workload.yaml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug src/main/java/com/example/helloapp/HelloAppApplication.java didn't match [kubernetes/tap/workload.yaml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug src/main/resources/application.properties didn't match [kubernetes/tap/workload.yaml] -> excluded
┃ ┃ ┃ ┃ ┗ Debug src/test/java/com/example/helloapp/HelloAppApplicationTests.java didn't match [kubernetes/tap/workload.yaml] -> excluded
┃ ┃ ┃ ┃ ┏ engine.transformations[0].merge.transformations[0].sources[4].<combo>.transformations[1] (Chain)
┃ ┃ ┃ ┃ ┃  Info Running Chain(ReplaceText, RewritePath)
┃ ┃ ┃ ┃ ┃ ┏ engine.transformations[0].merge.transformations[0].sources[4].<combo>.transformations[1].transformations[0] (ReplaceText)
┃ ┃ ┃ ┃ ┃ ┗  Info Will replace [: hello-fun->: quotes-service]
┃ ┃ ┃ ┃ ┃ ┏ engine.transformations[0].merge.transformations[0].sources[4].<combo>.transformations[1].transformations[1] (RewritePath)
┃ ┃ ┃ ┗ ┗ ┗ Debug Path 'kubernetes/tap/workload.yaml' matched '^(?<folder>.*/)?(?<filename>([^/]+?|)(?=(?<ext>\.[^/.]*)?)$)' with groups {ext=.yaml, folder=kubernetes/tap/, filename=workload.yaml, g0=kubernetes/tap/workload.yaml, g1=kubernetes/tap/, g2=workload.yaml, g3=workload.yaml, g4=.yaml} and was rewritten to 'config/workload.yaml'
┃ ┃ ┃ ┏ engine.transformations[0].merge.transformations[0].sources[5] (Combo)
┃ ┃ ┃ ┃  Info Condition (#deploymentType == 'workload') evaluated to true
┃ ┃ ┃ ┃  Info Combo running as Chain(Include, Chain(chain))
┃ ┃ ┃ ┃ engine.transformations[0].merge.transformations[0].sources[5].<combo> (Chain)
┃ ┃ ┃ ┃  Info Condition (#deploymentType == 'workload') evaluated to true
┃ ┃ ┃ ┃  Info Running Chain(Include, Chain)
┃ ┃ ┃ ┃ ┏ engine.transformations[0].merge.transformations[0].sources[5].<combo>.transformations[0] (Include)
┃ ┃ ┃ ┃ ┃  Info Will include [kubernetes/tap/Tiltfile]
┃ ┃ ┃ ┃ ┃ Debug .github/workflows/code-scan.yml didn't match [kubernetes/tap/Tiltfile] -> excluded
┃ ┃ ┃ ┃ ┃ Debug .github/workflows/codeql-analysis.yml didn't match [kubernetes/tap/Tiltfile] -> excluded
┃ ┃ ┃ ┃ ┃ Debug .gitignore didn't match [kubernetes/tap/Tiltfile] -> excluded
┃ ┃ ┃ ┃ ┃ Debug .mvn/wrapper/MavenWrapperDownloader.java didn't match [kubernetes/tap/Tiltfile] -> excluded
┃ ┃ ┃ ┃ ┃ Debug .mvn/wrapper/maven-wrapper.jar didn't match [kubernetes/tap/Tiltfile] -> excluded
┃ ┃ ┃ ┃ ┃ Debug .mvn/wrapper/maven-wrapper.properties didn't match [kubernetes/tap/Tiltfile] -> excluded
┃ ┃ ┃ ┃ ┃ Debug LICENSE didn't match [kubernetes/tap/Tiltfile] -> excluded
┃ ┃ ┃ ┃ ┃ Debug README.md didn't match [kubernetes/tap/Tiltfile] -> excluded
┃ ┃ ┃ ┃ ┃ Debug catalog/catalog-info.yaml didn't match [kubernetes/tap/Tiltfile] -> excluded
┃ ┃ ┃ ┃ ┃ Debug grype.yaml didn't match [kubernetes/tap/Tiltfile] -> excluded
┃ ┃ ┃ ┃ ┃ Debug kubernetes/k8s/DEPLOYING.md didn't match [kubernetes/tap/Tiltfile] -> excluded
┃ ┃ ┃ ┃ ┃ Debug kubernetes/k8s/Tiltfile didn't match [kubernetes/tap/Tiltfile] -> excluded
┃ ┃ ┃ ┃ ┃ Debug kubernetes/k8s/deployment.yaml didn't match [kubernetes/tap/Tiltfile] -> excluded
┃ ┃ ┃ ┃ ┃ Debug kubernetes/k8s/service.yaml didn't match [kubernetes/tap/Tiltfile] -> excluded
┃ ┃ ┃ ┃ ┃ Debug kubernetes/tap/DEPLOYING.md didn't match [kubernetes/tap/Tiltfile] -> excluded
┃ ┃ ┃ ┃ ┃ Debug kubernetes/tap/Tiltfile matched [kubernetes/tap/Tiltfile] -> included
┃ ┃ ┃ ┃ ┃ Debug kubernetes/tap/workload.yaml didn't match [kubernetes/tap/Tiltfile] -> excluded
┃ ┃ ┃ ┃ ┃ Debug mvnw didn't match [kubernetes/tap/Tiltfile] -> excluded
┃ ┃ ┃ ┃ ┃ Debug mvnw.cmd didn't match [kubernetes/tap/Tiltfile] -> excluded
┃ ┃ ┃ ┃ ┃ Debug pom.xml didn't match [kubernetes/tap/Tiltfile] -> excluded
┃ ┃ ┃ ┃ ┃ Debug src/main/java/com/example/helloapp/HelloAppApplication.java didn't match [kubernetes/tap/Tiltfile] -> excluded
┃ ┃ ┃ ┃ ┃ Debug src/main/resources/application.properties didn't match [kubernetes/tap/Tiltfile] -> excluded
┃ ┃ ┃ ┃ ┗ Debug src/test/java/com/example/helloapp/HelloAppApplicationTests.java didn't match [kubernetes/tap/Tiltfile] -> excluded
┃ ┃ ┃ ┃ ┏ engine.transformations[0].merge.transformations[0].sources[5].<combo>.transformations[1] (Chain)
┃ ┃ ┃ ┃ ┃  Info Running Chain(ReplaceText, ReplaceText, RewritePath)
┃ ┃ ┃ ┃ ┃ ┏ engine.transformations[0].merge.transformations[0].sources[5].<combo>.transformations[1].transformations[0] (ReplaceText)
┃ ┃ ┃ ┃ ┃ ┗  Info Will replace [hello-fun->quotes-service]
┃ ┃ ┃ ┃ ┃ ┏ engine.transformations[0].merge.transformations[0].sources[5].<combo>.transformations[1].transformations[1] (ReplaceText)
┃ ┃ ┃ ┃ ┃ ┗  Info Will replace [dev.local->dev.local]
┃ ┃ ┃ ┃ ┃ ┏ engine.transformations[0].merge.transformations[0].sources[5].<combo>.transformations[1].transformations[2] (RewritePath)
┃ ┃ ┃ ┗ ┗ ┗ Debug Path 'kubernetes/tap/Tiltfile' matched '^(?<folder>.*/)?(?<filename>([^/]+?|)(?=(?<ext>\.[^/.]*)?)$)' with groups {ext=null, folder=kubernetes/tap/, filename=Tiltfile, g0=kubernetes/tap/Tiltfile, g1=kubernetes/tap/, g2=Tiltfile, g3=Tiltfile, g4=null} and was rewritten to 'Tiltfile'
┃ ┃ ┃ ┏ engine.transformations[0].merge.transformations[0].sources[6] (Combo)
┃ ┃ ┃ ┃  Info Condition (#deploymentType != 'none') evaluated to true
┃ ┃ ┃ ┃  Info Combo running as Chain(Include, Chain(chain))
┃ ┃ ┃ ┃ engine.transformations[0].merge.transformations[0].sources[6].<combo> (Chain)
┃ ┃ ┃ ┃  Info Condition (#deploymentType != 'none') evaluated to true
┃ ┃ ┃ ┃  Info Running Chain(Include, Chain)
┃ ┃ ┃ ┃ ┏ engine.transformations[0].merge.transformations[0].sources[6].<combo>.transformations[0] (Include)
┃ ┃ ┃ ┃ ┃  Info Will include [catalog/*.yaml]
┃ ┃ ┃ ┃ ┃ Debug .github/workflows/code-scan.yml didn't match [catalog/*.yaml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug .github/workflows/codeql-analysis.yml didn't match [catalog/*.yaml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug .gitignore didn't match [catalog/*.yaml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug .mvn/wrapper/MavenWrapperDownloader.java didn't match [catalog/*.yaml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug .mvn/wrapper/maven-wrapper.jar didn't match [catalog/*.yaml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug .mvn/wrapper/maven-wrapper.properties didn't match [catalog/*.yaml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug LICENSE didn't match [catalog/*.yaml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug README.md didn't match [catalog/*.yaml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug catalog/catalog-info.yaml matched [catalog/*.yaml] -> included
┃ ┃ ┃ ┃ ┃ Debug grype.yaml didn't match [catalog/*.yaml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug kubernetes/k8s/DEPLOYING.md didn't match [catalog/*.yaml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug kubernetes/k8s/Tiltfile didn't match [catalog/*.yaml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug kubernetes/k8s/deployment.yaml didn't match [catalog/*.yaml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug kubernetes/k8s/service.yaml didn't match [catalog/*.yaml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug kubernetes/tap/DEPLOYING.md didn't match [catalog/*.yaml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug kubernetes/tap/Tiltfile didn't match [catalog/*.yaml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug kubernetes/tap/workload.yaml didn't match [catalog/*.yaml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug mvnw didn't match [catalog/*.yaml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug mvnw.cmd didn't match [catalog/*.yaml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug pom.xml didn't match [catalog/*.yaml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug src/main/java/com/example/helloapp/HelloAppApplication.java didn't match [catalog/*.yaml] -> excluded
┃ ┃ ┃ ┃ ┃ Debug src/main/resources/application.properties didn't match [catalog/*.yaml] -> excluded
┃ ┃ ┃ ┃ ┗ Debug src/test/java/com/example/helloapp/HelloAppApplicationTests.java didn't match [catalog/*.yaml] -> excluded
┃ ┃ ┃ ┃ ┏ engine.transformations[0].merge.transformations[0].sources[6].<combo>.transformations[1] (Chain)
┃ ┃ ┃ ┃ ┃  Info Running Chain(ReplaceText)
┃ ┃ ┃ ┃ ┃ ┏ engine.transformations[0].merge.transformations[0].sources[6].<combo>.transformations[1].transformations[0] (ReplaceText)
┃ ┃ ┃ ┗ ┗ ┗  Info Will replace [hello-fun->quotes-service]
┃ ┃ ┃ ┏ README (Combo)
┃ ┃ ┃ ┃  Info Combo running as Chain(Merge(merge), UniquePath(Append))
┃ ┃ ┃ ┃ README.merge (Chain)
┃ ┃ ┃ ┃  Info Running Chain(Merge, UniquePath)
┃ ┃ ┃ ┃ ┏ README.merge.transformations[0] (Merge)
┃ ┃ ┃ ┃ ┃  Info Running Merge(Combo, Combo, Combo)
┃ ┃ ┃ ┃ ┃ ┏ README.merge.transformations[0].sources[0] (Combo)
┃ ┃ ┃ ┃ ┃ ┃  Info Combo running as Chain(Include, Chain(chain))
┃ ┃ ┃ ┃ ┃ ┃ README.merge.transformations[0].sources[0].<combo> (Chain)
┃ ┃ ┃ ┃ ┃ ┃  Info Running Chain(Include, Chain)
┃ ┃ ┃ ┃ ┃ ┃ ┏ README.merge.transformations[0].sources[0].<combo>.transformations[0] (Include)
┃ ┃ ┃ ┃ ┃ ┃ ┃  Info Will include [README.md]
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug .github/workflows/code-scan.yml didn't match [README.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug .github/workflows/codeql-analysis.yml didn't match [README.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug .gitignore didn't match [README.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug .mvn/wrapper/MavenWrapperDownloader.java didn't match [README.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug .mvn/wrapper/maven-wrapper.jar didn't match [README.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug .mvn/wrapper/maven-wrapper.properties didn't match [README.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug LICENSE didn't match [README.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug README.md matched [README.md] -> included
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug catalog/catalog-info.yaml didn't match [README.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug grype.yaml didn't match [README.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug kubernetes/k8s/DEPLOYING.md didn't match [README.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug kubernetes/k8s/Tiltfile didn't match [README.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug kubernetes/k8s/deployment.yaml didn't match [README.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug kubernetes/k8s/service.yaml didn't match [README.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug kubernetes/tap/DEPLOYING.md didn't match [README.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug kubernetes/tap/Tiltfile didn't match [README.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug kubernetes/tap/workload.yaml didn't match [README.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug mvnw didn't match [README.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug mvnw.cmd didn't match [README.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug pom.xml didn't match [README.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug src/main/java/com/example/helloapp/HelloAppApplication.java didn't match [README.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug src/main/resources/application.properties didn't match [README.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┗ Debug src/test/java/com/example/helloapp/HelloAppApplicationTests.java didn't match [README.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┏ README.merge.transformations[0].sources[0].<combo>.transformations[1] (Chain)
┃ ┃ ┃ ┃ ┃ ┃ ┃  Info Running Chain(ReplaceText)
┃ ┃ ┃ ┃ ┃ ┃ ┃ ┏ README.merge.transformations[0].sources[0].<combo>.transformations[1].transformations[0] (ReplaceText)
┃ ┃ ┃ ┃ ┃ ┗ ┗ ┗  Info Will replace [hello-fun template repo->quotes-service]
┃ ┃ ┃ ┃ ┃ ┏ README.merge.transformations[0].sources[1] (Combo)
┃ ┃ ┃ ┃ ┃ ┃  Info Condition (#deploymentType == 'k8s-simple') evaluated to false
┃ ┃ ┃ ┃ ┃ ┗ null ()
┃ ┃ ┃ ┃ ┃ ┏ README.merge.transformations[0].sources[2] (Combo)
┃ ┃ ┃ ┃ ┃ ┃  Info Condition (#deploymentType == 'workload') evaluated to true
┃ ┃ ┃ ┃ ┃ ┃  Info Combo running as Chain(Include, Chain(chain))
┃ ┃ ┃ ┃ ┃ ┃ README.merge.transformations[0].sources[2].<combo> (Chain)
┃ ┃ ┃ ┃ ┃ ┃  Info Condition (#deploymentType == 'workload') evaluated to true
┃ ┃ ┃ ┃ ┃ ┃  Info Running Chain(Include, Chain)
┃ ┃ ┃ ┃ ┃ ┃ ┏ README.merge.transformations[0].sources[2].<combo>.transformations[0] (Include)
┃ ┃ ┃ ┃ ┃ ┃ ┃  Info Will include [kubernetes/tap/DEPLOYING.md]
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug .github/workflows/code-scan.yml didn't match [kubernetes/tap/DEPLOYING.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug .github/workflows/codeql-analysis.yml didn't match [kubernetes/tap/DEPLOYING.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug .gitignore didn't match [kubernetes/tap/DEPLOYING.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug .mvn/wrapper/MavenWrapperDownloader.java didn't match [kubernetes/tap/DEPLOYING.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug .mvn/wrapper/maven-wrapper.jar didn't match [kubernetes/tap/DEPLOYING.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug .mvn/wrapper/maven-wrapper.properties didn't match [kubernetes/tap/DEPLOYING.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug LICENSE didn't match [kubernetes/tap/DEPLOYING.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug README.md didn't match [kubernetes/tap/DEPLOYING.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug catalog/catalog-info.yaml didn't match [kubernetes/tap/DEPLOYING.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug grype.yaml didn't match [kubernetes/tap/DEPLOYING.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug kubernetes/k8s/DEPLOYING.md didn't match [kubernetes/tap/DEPLOYING.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug kubernetes/k8s/Tiltfile didn't match [kubernetes/tap/DEPLOYING.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug kubernetes/k8s/deployment.yaml didn't match [kubernetes/tap/DEPLOYING.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug kubernetes/k8s/service.yaml didn't match [kubernetes/tap/DEPLOYING.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug kubernetes/tap/DEPLOYING.md matched [kubernetes/tap/DEPLOYING.md] -> included
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug kubernetes/tap/Tiltfile didn't match [kubernetes/tap/DEPLOYING.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug kubernetes/tap/workload.yaml didn't match [kubernetes/tap/DEPLOYING.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug mvnw didn't match [kubernetes/tap/DEPLOYING.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug mvnw.cmd didn't match [kubernetes/tap/DEPLOYING.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug pom.xml didn't match [kubernetes/tap/DEPLOYING.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug src/main/java/com/example/helloapp/HelloAppApplication.java didn't match [kubernetes/tap/DEPLOYING.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┃ Debug src/main/resources/application.properties didn't match [kubernetes/tap/DEPLOYING.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┗ Debug src/test/java/com/example/helloapp/HelloAppApplicationTests.java didn't match [kubernetes/tap/DEPLOYING.md] -> excluded
┃ ┃ ┃ ┃ ┃ ┃ ┏ README.merge.transformations[0].sources[2].<combo>.transformations[1] (Chain)
┃ ┃ ┃ ┃ ┃ ┃ ┃  Info Running Chain(ReplaceText, RewritePath)
┃ ┃ ┃ ┃ ┃ ┃ ┃ ┏ README.merge.transformations[0].sources[2].<combo>.transformations[1].transformations[0] (ReplaceText)
┃ ┃ ┃ ┃ ┃ ┃ ┃ ┗  Info Will replace [hello-fun->quotes-service]
┃ ┃ ┃ ┃ ┃ ┃ ┃ ┏ README.merge.transformations[0].sources[2].<combo>.transformations[1].transformations[1] (RewritePath)
┃ ┃ ┃ ┃ ┗ ┗ ┗ ┗ Debug Path 'kubernetes/tap/DEPLOYING.md' matched '^(?<folder>.*/)?(?<filename>([^/]+?|)(?=(?<ext>\.[^/.]*)?)$)' with groups {ext=.md, folder=kubernetes/tap/, filename=DEPLOYING.md, g0=kubernetes/tap/DEPLOYING.md, g1=kubernetes/tap/, g2=DEPLOYING.md, g3=DEPLOYING.md, g4=.md} and was rewritten to 'README.md'
┃ ┃ ┃ ┃ ┏ README.merge.transformations[1] (UniquePath)
┃ ┃ ┗ ┗ ┗ Debug Multiple representations for path 'README.md', will concatenate them together
┃ ┗ ╺ engine.transformations[0].merge.transformations[1] (UniquePath)
┗ ╺ engine.transformations[1] (UniquePath)
```
